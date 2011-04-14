using System;
using System.IO;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Languages.Java.CodeGeneraotr
{
	public partial class JavaCodeGenerator : IUnifiedModelVisitor<TokenInfo, bool>
	{
		public static string Generate(UnifiedProgram program)
		{
			var buff = new StringWriter();
			var visitor = new JavaCodeGenerator(buff);
			visitor.Visit(program, new TokenInfo());
			return buff.ToString();
		}

		private readonly TextWriter _writer;
		private int _indent;

		public string IndentSpace { get; set; }

		private JavaCodeGenerator(TextWriter writer)
		{
			_writer = writer;
			_indent = 0;
			IndentSpace = "\t";
		}

		private void WriteIndent()
		{
			for (int i = 0; i < _indent; i++)
				_writer.Write(IndentSpace);
		}

		public void WriteSpace()
		{
			_writer.Write(" ");
		}

		#region program, namespace, class, method, filed ...

		public bool Visit(UnifiedProgram element, TokenInfo data)
		{
			foreach (var elem in element) {
				elem.Accept(this, data);
			}
			return false;
		}

		public string GetKeyword(UnifiedClassKind kind)
		{
			switch (kind) {
			case UnifiedClassKind.Class:
				return "class";
			case UnifiedClassKind.Interface:
				return "interface";
			case UnifiedClassKind.Namespace:
				return "package";
			case UnifiedClassKind.Enum:
				return "enum";
			case UnifiedClassKind.Module:
				return "module";
			default:
				throw new ArgumentOutOfRangeException("kind");
			}
			return null;
		}

		public bool Visit(UnifiedClassDefinition element, TokenInfo data)
		{
			var keyword = GetKeyword(element.Kind);
			if (element.Kind == UnifiedClassKind.Namespace) {
				_writer.Write(keyword);
				WriteSpace();
				element.Name.Accept(this, data);
				return true;
			}
			WriteIndent();
			element.Modifiers.Accept(this, data);
			_writer.Write(keyword);
			WriteSpace();
			element.Name.Accept(this, data);
			element.TypeParameters.TryAccept(this, data);
			element.Body.TryAccept(this, data);
			return false;
		}

		public bool Visit(UnifiedFunctionDefinition element, TokenInfo data)
		{
			WriteIndent();
			element.Modifiers.Accept(this, data);
			element.Type.Accept(this, data);
			WriteSpace();
			element.TypeParameters.TryAccept(this, data);
			element.Name.Accept(this, data);
			element.Parameters.Accept(this, data);
			element.Body.TryAccept(this, data);
			return element.Body == null;
		}

		public bool Visit(UnifiedParameter element, TokenInfo data)
		{
			element.Modifiers.Accept(this, data);
			element.Type.Accept(this, data);
			WriteSpace();
			_writer.Write(element.Name.Value);
			return false;
		}

		public bool Visit(UnifiedModifier element, TokenInfo data)
		{
			_writer.Write(element.Name);
			return false;
		}

		public bool Visit(UnifiedType element, TokenInfo data)
		{
			_writer.Write(element.Name.Value);
			element.Supplements.TryAccept(this, data);
			return false;
		}

		#endregion

		#region statement

		public bool Visit(UnifiedBlock element, TokenInfo data)
		{
			WriteIndent();
			_writer.WriteLine("{");
			_indent++;
			foreach (var stmt in element) {
				WriteIndent();
				if (stmt.Accept(this, data))
					_writer.Write(";");
			}
			_indent--;
			WriteIndent();
			_writer.WriteLine("}");
			return false;
		}

		// e.g. static{...}
		public bool Visit(UnifiedSpecialBlock element, TokenInfo data)
		{
			WriteIndent();
			_writer.Write(element.Kind);
			if (element.Value != null) {
				_writer.Write("(");
				_writer.Write(element.Value);
				_writer.Write(")");
			}
			_writer.Write("{");
			_indent++;
			foreach (var stmt in element.Body) {
				WriteIndent();
				if (stmt.Accept(this, data))
					_writer.Write(";");
			}
			_indent--;
			WriteIndent();
			_writer.Write("}");
			return false;
		}

		public bool Visit(UnifiedIf ifStatement, TokenInfo data)
		{
			_writer.Write("if (");
			ifStatement.Condition.Accept(this, data);
			_writer.WriteLine(")");
			ifStatement.Body.Accept(this, data);
			if (ifStatement.FalseBody != null) {
				WriteIndent();
				_writer.WriteLine("else");
				ifStatement.FalseBody.Accept(this, data);
			}
			return false;
		}

		// e.g. catch(Exception e){...}
		public bool Visit(UnifiedCatch element, TokenInfo data)
		{
			_writer.Write("catch");
			element.Parameters.TryAccept(this, data);
			element.Body.Accept(this, data);
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
		public bool Visit(UnifiedTry element, TokenInfo data)
		{
			// try block
			_writer.Write("try");
			element.Body.Accept(this, data);

			// catch blocks
			element.Catches.Accept(this, data);

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				_writer.Write("finally");
				finallyBlock.Accept(this, data);
			}
			return false;
		}

		public bool Visit(UnifiedTypeConstrain element, TokenInfo data)
		{
			throw new InvalidOperationException();
		}

		public bool Visit(UnifiedTypeParameter element, TokenInfo data)
		{
			element.Type.Accept(this, data);
			element.Constrains.Accept(this, new TokenInfo { Delimiter = " & " });
			return false;
		}

		public bool Visit(UnifiedTypeSupplement element, TokenInfo data)
		{
			switch (element.Kind) {
			case UnifiedTypeSupplementKind.Array:
				element.Arguments.TryAccept(this,
					new TokenInfo { MostLeft = "[", Delimiter = ", ", MostRight = "]", });
				break;
			default:
				break;
			}
			return false;
		}

		// a ? b : c
		public bool Visit(UnifiedTernaryOperator element, TokenInfo data)
		{
			switch (element.Kind) {
			case (UnifiedTernaryOperatorKind.Conditional):
				_writer.Write(element.FirstSign);
				break;
			default:
				break;
			}
			return false;
		}

		public bool Visit(UnifiedVariableDefinitionBody element, TokenInfo data)
		{
			element.Name.TryAccept(this, data);
			element.Supplements.TryAccept(this, data);
			if (element.InitialValue != null) {
				_writer.Write(" = ");
				element.InitialValue.Accept(this, data);
			}
			element.Body.TryAccept(this, data);
			return false;
		}

		public bool Visit(UnifiedQualifiedIdentifier element, TokenInfo data)
		{
			_writer.Write(element.Value);
			return false;
		}

		public bool Visit(UnifiedLabel element, TokenInfo data)
		{
			element.Name.Accept(this, data);
			_writer.Write(":");
			return false;
		}

		// There is not 'yield' in java?
		public string GetKeyword(UnifiedSpecialExpressionKind kind)
		{
			switch (kind) {
			case UnifiedSpecialExpressionKind.Break:
				return "break";
			case UnifiedSpecialExpressionKind.Continue:
				return "continue";
			case UnifiedSpecialExpressionKind.Goto:
				return "goto";
			case UnifiedSpecialExpressionKind.Return:
				return "return";
			case UnifiedSpecialExpressionKind.YieldReturn:
				return "/* yield return in C# */";
			case UnifiedSpecialExpressionKind.Throw:
				return "throw";
			case UnifiedSpecialExpressionKind.Retry:
				return "/* retry in Ruby */";
			case UnifiedSpecialExpressionKind.Redo:
				return "/* redo in Ruby */";
			case UnifiedSpecialExpressionKind.Yield:
				return "/* yield in Ruby */";
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		#endregion

		#region expression

		public bool Visit(UnifiedBinaryOperator op, TokenInfo data)
		{
			_writer.Write(op.Sign);
			return false;
		}

		public bool Visit(UnifiedArgument arg, TokenInfo data)
		{
			arg.Value.TryAccept(this, data);
			return false;
		}

		#endregion

		#region value

		public bool Visit(UnifiedIdentifier identifier, TokenInfo data)
		{
			_writer.Write(identifier.Value);
			return false;
		}

		public bool Visit(UnifiedLiteral lit, TokenInfo data)
		{
			_writer.Write(lit.ToString());
			return false;
		}

		public bool Visit<T>(UnifiedTypedLiteral<T> lit, TokenInfo data)
		{
			_writer.Write(lit.Value);
			return false;
		}

		#endregion

		public bool Visit(UnifiedUnaryOperator element, TokenInfo data)
		{
			var kind = element.Kind;
			switch (kind) {
			case (UnifiedUnaryOperatorKind.Negate):
				_writer.Write("-");
				break;
			case (UnifiedUnaryOperatorKind.Not):
				_writer.Write("!");
				break;
			case (UnifiedUnaryOperatorKind.PostDecrementAssign):
			case (UnifiedUnaryOperatorKind.PreDecrementAssign):
				_writer.Write("--");
				break;
			case (UnifiedUnaryOperatorKind.PostIncrementAssign):
			case (UnifiedUnaryOperatorKind.PreIncrementAssign):
				_writer.Write("++");
				break;
			case (UnifiedUnaryOperatorKind.UnaryPlus):
				_writer.Write("+");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				_writer.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		// classname(identifier of constructor)...??
		public bool Visit(UnifiedConstructorDefinition element, TokenInfo data)
		{
			element.Modifiers.Accept(this, data);
			element.Name.Accept(this, data);
			element.Parameters.Accept(this, data);
			element.Body.Accept(this, data);
			return false;
		}

		public bool Visit(UnifiedFor element, TokenInfo data)
		{
			_writer.Write("for(");
			element.Initializer.Accept(this, data);
			_writer.Write("; ");
			element.Condition.Accept(this, data);
			_writer.Write(";");
			element.Step.Accept(this, data);
			_writer.Write(")");

			element.Body.Accept(this, data);
			return false;
		}

		public bool Visit(UnifiedForeach element, TokenInfo data)
		{
			_writer.Write("for(");
			element.Element.Accept(this, data);
			WriteSpace();
			_writer.Write(":");
			WriteSpace();
			element.Set.Accept(this, data);
			_writer.Write(")");

			element.Body.Accept(this, data);
			return false;
		}

		public bool Visit(UnifiedProperty element, TokenInfo data)
		{
			element.Owner.Accept(this, data);
			_writer.Write(element.Delimiter);
			element.Name.Accept(this, data);
			return false;
		}

		public bool Visit(UnifiedWhile element, TokenInfo data)
		{
			_writer.Write("while(");
			element.Condition.Accept(this, data);
			_writer.Write(")");

			element.Body.Accept(this, data);
			return false;
		}

		public bool Visit(UnifiedDoWhile element, TokenInfo data)
		{
			_writer.Write("do");
			element.Body.Accept(this, data);
			_writer.Write("while(");
			element.Condition.Accept(this, data);
			_writer.Write(");");
			return false;
		}

		public bool Visit(UnifiedIndexer element, TokenInfo data)
		{
			element.Target.Accept(this, data);
			element.Arguments.Accept(this,
				new TokenInfo { MostLeft = "[", Delimiter = ", ", MostRight = "]" });
			return false;
		}

		public bool Visit(UnifiedTypeArgument element, TokenInfo data)
		{
			element.Modifiers.Accept(this, data);
			element.Value.Accept(this, data);
			element.Constrains.Accept(this, new TokenInfo { Delimiter = " & " });
			return false;
		}

		public bool Visit(UnifiedSwitch element, TokenInfo data)
		{
			_writer.Write("switch(");
			element.Value.Accept(this, data);
			_writer.Write(") {");

			element.Cases.Accept(this, data);
			_writer.Write("}");
			return false;
		}

		public bool Visit(UnifiedCase element, TokenInfo data)
		{
			_writer.Write("case(");
			element.Condition.Accept(this, data);
			_writer.Write(") :\n");
			element.Body.Accept(this, data);
			return false;
		}
	}
}