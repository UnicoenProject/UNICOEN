using System;
using System.IO;
using System.Linq;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Languages.Java.CodeGeneraotr {
	public partial class JavaCodeGenerator : IUnifiedModelVisitor<TokenInfo, bool> {
		public static string Generate(IUnifiedElement element) {
			var buff = new StringWriter();
			var visitor = new JavaCodeGenerator(buff);
			element.Accept(visitor, new TokenInfo());
			return buff.ToString();
		}

		public TextWriter Writer { get; private set; }
		private int _indent;

		private static readonly TokenInfo WithParen =
				new TokenInfo { MostLeft = "(", MostRight = ")" };

		private static readonly TokenInfo WithoutParen = new TokenInfo();

		public string IndentSpace { get; set; }

		public JavaCodeGenerator(TextWriter writer) {
			Writer = writer;
			_indent = 0;
			IndentSpace = "\t";
		}

		private void WriteIndent() {
			for (int i = 0; i < _indent; i++)
				Writer.Write(IndentSpace);
		}

		public void WriteSpace() {
			Writer.Write(" ");
		}

		#region program, namespace, class, method, filed ...

		public bool Visit(UnifiedProgram element, TokenInfo data) {
			foreach (var stmt in element) {
				if (stmt.TryAccept(this, WithoutParen))
					Writer.Write(";");
			}
			return false;
		}

		public string GetKeyword(UnifiedClassKind kind) {
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

		public bool Visit(UnifiedClassDefinition element, TokenInfo data) {
			var keyword = GetKeyword(element.Kind);
			if (element.Kind == UnifiedClassKind.Namespace) {
				Writer.Write(keyword);
				WriteSpace();
				element.Name.TryAccept(this, data);
				return true;
			}
			WriteIndent();
			element.Modifiers.TryAccept(this, data);
			Writer.Write(keyword);
			WriteSpace();
			element.Name.TryAccept(this, data);
			element.TypeParameters.TryAccept(this, data);
			element.Constrains.TryAccept(this, data);
			element.Body.TryAccept(this, data);
			return false;
		}

		public bool Visit(UnifiedFunctionDefinition element, TokenInfo data) {
			WriteIndent();
			element.Modifiers.TryAccept(this, data);
			element.TypeParameters.TryAccept(this, data);
			element.Type.TryAccept(this, data);
			WriteSpace();
			element.Name.TryAccept(this, data);
			element.Parameters.TryAccept(this, data);
			if (element.Throws != null) {
				WriteSpace();
				Writer.Write("throws");
				WriteSpace();
				element.Throws.TryAccept(this, data);
			}
			element.Body.TryAccept(this, data);
			return element.Body == null;
		}

		public bool Visit(UnifiedParameter element, TokenInfo data) {
			var removed = element.Modifiers.Remove(m => m.Name == "...");
			element.Modifiers.TryAccept(this, data);
			element.Type.TryAccept(this, data);
			WriteSpace();
			if (removed)
				Writer.Write("... ");
			Writer.Write(element.Name.Value);
			return false;
		}

		public bool Visit(UnifiedModifier element, TokenInfo data) {
			Writer.Write(element.Name);
			return false;
		}

		public bool Visit(UnifiedType element, TokenInfo data) {
			element.Name.TryAccept(this, data);
			element.Arguments.TryAccept(this, data);
			element.Supplements.TryAccept(this, data);
			return false;
		}

		#endregion

		#region statement

		public bool Visit(UnifiedBlock element, TokenInfo data) {
			WriteIndent();
			Writer.WriteLine("{");
			_indent++;
			foreach (var stmt in element) {
				WriteIndent();
				if (stmt.TryAccept(this, WithoutParen))
					Writer.Write(";");
			}
			_indent--;
			WriteIndent();
			Writer.WriteLine("}");
			return false;
		}

		// e.g. static{...}
		public bool Visit(UnifiedSpecialBlock element, TokenInfo data) {
			WriteIndent();
			switch (element.Kind) {
			case UnifiedSpecialBlockKind.Synchronized:
				Writer.Write("synchronized");
				break;
			case UnifiedSpecialBlockKind.Fix:
				Writer.Write("fix");
				break;
			case UnifiedSpecialBlockKind.Using:
				Writer.Write("using");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (element.Value != null) {
				Writer.Write("(");
				element.Value.TryAccept(this, WithoutParen);
				Writer.Write(")");
			}
			Writer.Write("{");
			_indent++;
			foreach (var stmt in element.Body) {
				WriteIndent();
				if (stmt.TryAccept(this, WithoutParen))
					Writer.Write(";");
			}
			_indent--;
			WriteIndent();
			Writer.Write("}");
			return false;
		}

		public bool Visit(UnifiedIf ifStatement, TokenInfo data) {
			Writer.Write("if (");
			ifStatement.Condition.TryAccept(this, data);
			Writer.WriteLine(")");
			ifStatement.Body.TryAccept(this, data);
			if (ifStatement.FalseBody != null) {
				WriteIndent();
				Writer.WriteLine("else");
				ifStatement.FalseBody.TryAccept(this, data);
			}
			return false;
		}

		// e.g. catch(Exception e){...}
		public bool Visit(UnifiedCatch element, TokenInfo data) {
			Writer.Write("catch");
			element.Parameters.TryAccept(this, data);
			element.Body.TryAccept(this, data);
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
		public bool Visit(UnifiedTry element, TokenInfo data) {
			// try block
			Writer.Write("try");
			element.Body.TryAccept(this, data);

			// catch blocks
			element.Catches.TryAccept(this, data);

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				Writer.Write("finally");
				finallyBlock.TryAccept(this, data);
			}
			return false;
		}

		public bool Visit(UnifiedTypeConstrain element, TokenInfo data) {
			throw new InvalidOperationException();
		}

		public bool Visit(UnifiedTypeParameter element, TokenInfo data) {
			element.Type.TryAccept(this, data);
			element.Constrains.TryAccept(this, new TokenInfo { Delimiter = " & " });
			return false;
		}

		public bool Visit(UnifiedTypeSupplement element, TokenInfo data) {
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
		public bool Visit(UnifiedTernaryOperator element, TokenInfo data) {
			switch (element.Kind) {
			case (UnifiedTernaryOperatorKind.Conditional):
				Writer.Write(element.FirstSign);
				break;
			default:
				break;
			}
			return false;
		}

		public bool Visit(UnifiedVariableDefinitionBody element, TokenInfo data) {
			element.Name.TryAccept(this, data);
			element.Supplements.TryAccept(this, data);
			if (element.InitialValue != null) {
				Writer.Write(" = ");
				element.InitialValue.TryAccept(this, data);
			}
			element.Body.TryAccept(this, data);
			return false;
		}

		public bool Visit(UnifiedQualifiedIdentifier element, TokenInfo data) {
			Writer.Write(element.Value);
			return false;
		}

		public bool Visit(UnifiedLabel element, TokenInfo data) {
			element.Name.TryAccept(this, data);
			Writer.Write(":");
			return false;
		}

		public bool Visit(UnifiedBooleanLiteral element, TokenInfo data) {
			if (element.Value.ToString() == "True")
				Writer.Write("true");
			if (element.Value.ToString() == "False")
				Writer.Write("false");
			return false;
		}

		public bool Visit(UnifiedDecimalLiteral element, TokenInfo data) {
			Writer.Write(element.Value);
			return false;
		}

		public bool Visit(UnifiedIntegerLiteral element, TokenInfo data) {
			Writer.Write(element.Value);
			return false;
		}

		public bool Visit(UnifiedStringLiteral element, TokenInfo data) {
			Writer.Write(element.Value);
			return false;
		}

		public bool Visit(UnifiedCharLiteral element, TokenInfo data) {
			Writer.Write(element.Value);
			return false;
		}

		public bool Visit(UnifiedNullLiteral element, TokenInfo data) {
			Writer.Write("null");
			return false;
		}

		// There is not 'yield' in java?
		public string GetKeyword(UnifiedSpecialExpressionKind kind) {
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

		public bool Visit(UnifiedBinaryOperator op, TokenInfo data) {
			Writer.Write(op.Sign);
			return false;
		}

		public bool Visit(UnifiedArgument arg, TokenInfo data) {
			arg.Value.TryAccept(this, data);
			return false;
		}

		#endregion

		#region value

		public bool Visit(UnifiedIdentifier identifier, TokenInfo data) {
			Writer.Write(identifier.Value);
			return false;
		}

		public bool Visit<T>(UnifiedTypedLiteral<T> lit, TokenInfo data) {
			if (lit.Value is bool)
				lit.Value = lit.Value;
			Writer.Write(lit.Value);
			return false;
		}

		#endregion

		public bool Visit(UnifiedUnaryOperator element, TokenInfo data) {
			var kind = element.Kind;
			switch (kind) {
			case (UnifiedUnaryOperatorKind.Negate):
				Writer.Write("-");
				break;
			case (UnifiedUnaryOperatorKind.Not):
				Writer.Write("!");
				break;
			case (UnifiedUnaryOperatorKind.PostDecrementAssign):
			case (UnifiedUnaryOperatorKind.PreDecrementAssign):
				Writer.Write("--");
				break;
			case (UnifiedUnaryOperatorKind.PostIncrementAssign):
			case (UnifiedUnaryOperatorKind.PreIncrementAssign):
				Writer.Write("++");
				break;
			case (UnifiedUnaryOperatorKind.UnaryPlus):
				Writer.Write("+");
				break;
			case (UnifiedUnaryOperatorKind.OnesComplement):
				Writer.Write("~");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				Writer.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		// classname(identifier of constructor)...??
		public bool Visit(UnifiedConstructorDefinition element, TokenInfo data) {
			switch (element.Kind) {
			case UnifiedConstructorDefinitionKind.Constructor:
				element.Modifiers.TryAccept(this, data);
				element.TypeParameters.TryAccept(this, data);
				var p = element.Ancestors()
						.First(e => e is UnifiedClassDefinition);
				((UnifiedClassDefinition)p).Name.Accept(this, data);
				element.Parameters.TryAccept(this, data);
				element.Body.TryAccept(this, data);
				break;
			case UnifiedConstructorDefinitionKind.StaticInitializer:
				Writer.Write("static ");
				element.Body.TryAccept(this, data);
				break;
			case UnifiedConstructorDefinitionKind.InstanceInitializer:
				element.Body.TryAccept(this, data);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		public bool Visit(UnifiedFor element, TokenInfo data) {
			Writer.Write("for(");
			element.Initializer.TryAccept(this, data);
			Writer.Write("; ");
			element.Condition.TryAccept(this, data);
			Writer.Write(";");
			element.Step.TryAccept(this, data);
			Writer.Write(")");

			element.Body.TryAccept(this, data);
			return false;
		}

		public bool Visit(UnifiedForeach element, TokenInfo data) {
			Writer.Write("for(");
			element.Element.TryAccept(this, data);
			WriteSpace();
			Writer.Write(":");
			WriteSpace();
			element.Set.TryAccept(this, data);
			Writer.Write(")");

			element.Body.TryAccept(this, data);
			return false;
		}

		public bool Visit(UnifiedWhile element, TokenInfo data) {
			Writer.Write("while(");
			element.Condition.TryAccept(this, data);
			Writer.Write(")");

			element.Body.TryAccept(this, data);
			return false;
		}

		public bool Visit(UnifiedDoWhile element, TokenInfo data) {
			Writer.Write("do");
			element.Body.TryAccept(this, data);
			Writer.Write("while(");
			element.Condition.TryAccept(this, data);
			Writer.Write(");");
			return false;
		}

		public bool Visit(UnifiedIndexer element, TokenInfo data) {
			element.Target.TryAccept(this, data);
			element.Arguments.TryAccept(this,
					new TokenInfo { MostLeft = "[", Delimiter = ", ", MostRight = "]" });
			return false;
		}

		public bool Visit(UnifiedTypeArgument element, TokenInfo data) {
			element.Modifiers.TryAccept(this, data);
			element.Value.TryAccept(this, data);
			element.Constrains.TryAccept(this, new TokenInfo { Delimiter = " & " });
			return false;
		}

		public bool Visit(UnifiedSwitch element, TokenInfo data) {
			Writer.Write("switch(");
			element.Value.TryAccept(this, data);
			Writer.Write(") {");

			element.Cases.TryAccept(this, data);
			Writer.Write("}");
			return false;
		}

		public bool Visit(UnifiedCase element, TokenInfo data) {
			if (element.Condition == null) {
				Writer.Write("default :\n");
			} else {
				Writer.Write("case(");
				element.Condition.TryAccept(this, data);
				Writer.Write(") :\n");
			}
			element.Body.TryAccept(this, data);
			return false;
		}
	}
}