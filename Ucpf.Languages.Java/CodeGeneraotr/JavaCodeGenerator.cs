using System;
using System.IO;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Languages.Java.CodeGeneraotr
{
	public partial class JavaCodeGenerator : IUnifiedModelVisitor
	{
		public static string Generate(UnifiedProgram program)
		{
			var buff = new StringWriter();
			var visitor = new JavaCodeGenerator(buff);
			visitor.Visit(program);
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

		public void Visit(UnifiedProgram program)
		{
			foreach (var elem in program) {
				elem.Accept(this);
			}
		}

		public void Visit(UnifiedClassDefinition classDefinition)
		{
			WriteIndent();
			classDefinition.Modifiers.Accept(this);
			_writer.Write("class ");
			_writer.WriteLine(classDefinition.Name.Value);
			classDefinition.Body.Accept(this);
		}

		public void Visit(UnifiedFunctionDefinition functionDefinition)
		{
			WriteIndent();
			functionDefinition.Modifiers.Accept(this);
			functionDefinition.Type.Accept(this);
			_writer.Write(" ");
			_writer.Write(functionDefinition.Name.Value);
			functionDefinition.Parameters.Accept(this);
			functionDefinition.Body.Accept(this);
		}

		public void Visit(UnifiedParameter parameter)
		{
			parameter.Modifiers.Accept(this);
			parameter.Type.Accept(this);
			_writer.Write(" ");
			_writer.Write(parameter.Name.Value);
		}

		public void Visit(UnifiedModifier mod)
		{
			_writer.Write(mod.Name);
		}

		public void Visit(UnifiedType type)
		{
			_writer.Write(type.Name.Value);
			if(type.Supplements != null)
				type.Supplements.Accept(this);
		}

		#endregion

		#region statement

		public void Visit(UnifiedBlock block)
		{
			WriteIndent();
			_writer.WriteLine("{");
			_indent++;
			foreach (var stmt in block) {
				WriteIndent();
				stmt.Accept(this);
				if (stmt is UnifiedNew || !(stmt is UnifiedExpressionWithBlock))
					_writer.Write(";");
			}
			_indent--;
			WriteIndent();
			_writer.WriteLine("}");
		}

		public void Visit(UnifiedIf ifStatement)
		{
			_writer.Write("if (");
			ifStatement.Condition.Accept(this);
			_writer.WriteLine(")");
			ifStatement.Body.Accept(this);
			if (ifStatement.FalseBody != null) {
				WriteIndent();
				_writer.WriteLine("else");
				ifStatement.FalseBody.Accept(this);
			}
		}

		public void Visit(UnifiedSpecialExpression element)
		{
			_writer.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				_writer.Write(" ");
				element.Value.Accept(this);
			}
		}

		/*
		 * Edited on 04.13
		 */

		// e.g. static{...}
		public void Visit(UnifiedSpecialBlock element)
		{
			WriteIndent();
			_writer.Write(element.Kind);
			_writer.Write("{");
			_indent++;
			foreach (var stmt in element.Body) {
				WriteIndent();
				stmt.Accept(this);
			}
			_indent--;
			WriteIndent();
			_writer.Write("}");
		}

		// e.g. catch(Exception e){...}
		public void Visit(UnifiedCatch element)
		{
			var parameters = element.Parameters;
			_writer.Write("catch(");
			foreach (var parameter in parameters) {
				parameter.Accept(this);
			}
			_writer.Write(") {");
			_indent++;
			element.Body.Accept(this);
			_indent--;
			WriteIndent();
			_writer.Write("}");
		}

		// e.g. try{...}catch(E e){...}finally{...}
		public void Visit(UnifiedTry element)
		{
			// try block
			_writer.Write("try");
			element.Body.Accept(this);

			// catch blocks
			element.Catches.Accept(this);

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				_writer.Write("finally");
				finallyBlock.Accept(this);
			}
		}

		// e.g. (Int) a  or (int)(a + b)
		public void Visit(UnifiedCast element)
		{
			var type = element.Type;
			var expression = element.Expression;

			_writer.Write("(");
			type.Accept(this);
			_writer.Write(") ");
			if (expression is UnifiedUnaryExpression) {
				expression.Accept(this);
			} else {
				_writer.Write("(");
				expression.Accept(this);
				_writer.Write(")");
			}
		}

		public void Visit(UnifiedTypeConstrain element)
		{
			var kind = element.Kind;
			var type = element.Type;
			switch (kind) {
			case (UnifiedTypeConstrainKind.Extends):
				_writer.Write(" extends ");
				type.Accept(this);
				break;
			case (UnifiedTypeConstrainKind.Implements):
				_writer.Write(" implements ");
				type.Accept(this);
				break;
			case (UnifiedTypeConstrainKind.DefaultConstructor):
			case (UnifiedTypeConstrainKind.ExtendsOrImplements):
			case (UnifiedTypeConstrainKind.ReferenceType):
			case (UnifiedTypeConstrainKind.ValueType):
				break;
			default:
				throw new InvalidOperationException();
			}
		}

		public void Visit(UnifiedTypeParameter element)
		{
			element.Type.Accept(this);
			element.Constrains.Accept(this);
		}

		public void Visit(UnifiedTypeSupplement element)
		{
			var kind = element.Kind;
			
			switch (kind) {
				case UnifiedTypeSupplementKind.Array:
					_writer.Write("[");
					if(element.Arguments != null)
						element.Arguments.Accept(this);
					_writer.Write("]");
					break;
				default:
					break;
			}
		}

		// a ? b : c
		public void Visit(UnifiedTernaryOperator element)
		{
			var kind = element.Kind;
			switch (kind) {
			case (UnifiedTernaryOperatorKind.Conditional):
				_writer.Write(element.FirstSign);
				break;
			default:
				break;
			}
		}

		public void Visit(UnifiedTernaryExpression element)
		{
			element.FirstExpression.Accept(this);
			WriteSpace();
			element.SecondExpression.Accept(this);
			WriteSpace();
			element.LastExpression.Accept(this);
			_writer.Write(";");
		}

		public void Visit(UnifiedVariableDefinitionBody element)
		{
			if(element.Name != null)
				element.Name.Accept(this);
			if(element.Supplements != null)
				element.Supplements.Accept(this);
			if(element.InitialValue != null) {
				_writer.Write("=");
				element.InitialValue.Accept(this);
			}
			if(element.Block != null)
				element.Block.Accept(this);
		}

		public void Visit(UnifiedQualifiedIdentifier element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedLabel element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedExpressionList element)
		{
			var comma = "";
			foreach (var exp in element) {
				_writer.Write(comma);
				exp.Accept(this);
				comma = ",";
			}
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

		public void Visit(UnifiedBinaryExpression expr)
		{
			//TODO 単一のBinaryExpressionの場合は"()"がいらないがどう対処するのか
			//_writer.Write("(");
			expr.LeftHandSide.Accept(this);
			expr.Operator.Accept(this);
			expr.RightHandSide.Accept(this);
			//_writer.Write(")");
		}

		public void Visit(UnifiedBinaryOperator op)
		{
			_writer.Write(op.Sign);
		}

		public void Visit(UnifiedCall call)
		{
			call.Function.Accept(this);
			_writer.Write("(");
			call.Arguments.Accept(this);
			_writer.Write(")");
		}

		public void Visit(UnifiedArgument arg)
		{
			arg.Value.Accept(this);
		}

		#endregion

		#region value

		public void Visit(UnifiedIdentifier identifier)
		{
			_writer.Write(identifier.Value);
		}

		public void Visit(UnifiedLiteral lit)
		{
			_writer.Write(lit.ToString());
		}

		public void Visit<T>(UnifiedTypedLiteral<T> lit)
		{
			_writer.Write(lit.Value);
		}

		#endregion

		#region notImplemented

		public void Visit(UnifiedUnaryOperator element)
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
		}

		public void Visit(UnifiedImport element)
		{
			_writer.Write("import ");
			element.Name.Accept(this);
		}

		// classname(identifier of constructor)...??
		public void Visit(UnifiedConstructorDefinition element)
		{
			var body = element.Body;
			var modifiers = element.Modifiers;
			var parameters = element.Parameters;
			var name = element.Name;

			modifiers.Accept(this);
			name.Accept(this);
			parameters.Accept(this);
			body.Accept(this);
		}

		// e.g. int a = 5
		public void Visit(UnifiedVariableDefinition element)
		{
			element.Modifiers.Accept(this);
			WriteSpace();
			element.Type.Accept(this);
			WriteSpace();
			element.Bodys.Accept(this);
		}

		public void Visit(UnifiedNew element)
		{
			_writer.Write("new ");
			element.Type.Accept(this);
			if (element.Arguments != null) {
				_writer.Write("(");
				element.Arguments.Accept(this);
				_writer.Write(")");
			}
			if (element.Body != null)
				element.Body.Accept(this);
		}

		public void Visit(UnifiedFor element)
		{
			var condition = element.Condition;
			var initializer = element.Initializer;
			var step = element.Step;
			var body = element.Body;

			_writer.Write("for(");
			initializer.Accept(this);
			_writer.Write("; ");
			condition.Accept(this);
			_writer.Write(";");
			step.Accept(this);
			_writer.Write(")");

			body.Accept(this);
		}

		public void Visit(UnifiedForeach fe)
		{
			var element = fe.Element;
			var aggregate = fe.Set;
			var body = fe.Body;

			_writer.Write("for(");
			element.Accept(this);
			WriteSpace();
			_writer.Write(":");
			WriteSpace();
			aggregate.Accept(this);
			_writer.Write(")");

			body.Accept(this);
		}

		public void Visit(UnifiedUnaryExpression element)
		{
			var operand = element.Operand;
			var ope = element.Operator;

			if (ope.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    ope.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				operand.Accept(this);
				ope.Accept(this);
			} else {
				ope.Accept(this);
				operand.Accept(this);
			}
		}

		public void Visit(UnifiedProperty element)
		{
			element.Owner.Accept(this);
			_writer.Write(element.Delimiter);
			element.Name.Accept(this);
		}

		public void Visit(UnifiedWhile element)
		{
			var condition = element.Condition;
			var body = element.Body;

			_writer.Write("while(");
			condition.Accept(this);
			_writer.Write(")");

			body.Accept(this);
		}

		public void Visit(UnifiedDoWhile element)
		{
			var condition = element.Condition;
			var body = element.Body;

			_writer.Write("do");
			body.Accept(this);
			_writer.Write("while(");
			condition.Accept(this);
			_writer.Write(");");
		}

		public void Visit(UnifiedIndexer element)
		{
			var arguments = element.Arguments;
			var target = element.Target;

			target.Accept(this);
			_writer.Write("[");
			arguments.Accept(this);
			_writer.Write("]");
		}

		public void Visit(UnifiedTypeArgument element)
		{
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSwitch element)
		{
			var cases = element.Cases;
			var value = element.Value;

			_writer.Write("switch(");
			value.Accept(this);
			_writer.Write(") {");

			cases.Accept(this);
			_writer.Write("}");
		}

		public void Visit(UnifiedCase element)
		{
			var body = element.Body;
			var condition = element.Condition;

			_writer.Write("case(");
			condition.Accept(this);
			_writer.Write(") :\n");
			body.Accept(this);
		}

		#endregion
	}
}