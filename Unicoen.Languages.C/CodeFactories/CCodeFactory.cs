using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;

namespace Unicoen.Languages.C.CodeFactories {
	public partial class CCodeFactory : CodeFactory, IUnifiedModelVisitor<VisitorState, bool> {
		/// <summary>
		/// Expressionが括弧を付けるためのDecorationです
		/// </summary>
		private static readonly Decoration Paren =
				new Decoration() {
					MostLeft = "(",
					Delimiter = ", ",
					MostRight = ")"
				};
		private static readonly Decoration Bracket =
				new Decoration { MostLeft = "{", Delimiter = ", ", MostRight = "}" };

		private static readonly Decoration SquareBracket =
				new Decoration { MostLeft = "[", Delimiter = ", ", MostRight = "]" };

		private static readonly Decoration Empty = new Decoration();

		private static readonly Decoration AndDelimiter =
				new Decoration { Delimiter = " & " };

		private static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		private static readonly Decoration SpaceDelimiter =
				new Decoration { EachRight = " " };

		private static readonly Decoration NewLineDelimiter =
				new Decoration { Delimiter = "\n" };

		public static CCodeFactory Instance = new CCodeFactory();

		public override string Generate(IUnifiedElement model, TextWriter writer, string indentSign) {
			var buff = new StringWriter();
			model.Accept(this, new VisitorState(writer, indentSign));
			return buff.ToString();
		}

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			return Generate(model, writer, "\t");
		}


		private static string GetKeyword(UnifiedClassKind kind) {
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

		private static string GetKeyword(UnifiedSpecialExpressionKind kind) {
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




		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBinaryOperator element, VisitorState state) {
			state.Writer.Write(element.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedUnaryOperator element, VisitorState state) {
			state.Writer.Write(element.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedArgument element, VisitorState state) {
			element.TryAccept(this, state);
			return false;
		}




		public static Tuple<string, string> GetRequiredParen(IUnifiedElement element) {
			var parent = element.Parent;
			if (parent is UnifiedBinaryExpression || parent is UnifiedUnaryExpression || parent is UnifiedTernaryExpression) {
				return Tuple.Create("(", ")");
			}
			return Tuple.Create("", "");
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBinaryExpression element, VisitorState state) {
			var paren = GetRequiredParen(element);
			state.Writer.Write(paren.Item1);
			element.LeftHandSide.TryAccept(this, state);
			state.WriteSpace();
			element.Operator.TryAccept(this, state);
			state.WriteSpace();
			element.RightHandSide.TryAccept(this, state);
			state.Writer.Write(paren.Item2);

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBlock element, VisitorState state) {
			state.WriteIndent();
			state.Writer.WriteLine("{");
			state = state.IncrementIndentDepth();
			foreach (var stmt in element) {
				state.WriteIndent();
				if (stmt.TryAccept(this, state)) {
					state.Writer.Write(";");
				}
			}

			state.WriteIndent();
			state.Writer.WriteLine(";");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCall element, VisitorState state) {
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, state);
				state.Writer.Write(prop.Delimiter);
				prop.Name.TryAccept(this, state);
			} else {
				throw new NotImplementedException();
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedFunctionDefinition element, VisitorState state) {
			// C言語に存在しない要素は省略
			
			state.WriteIndent();
			element.Modifiers.TryAccept(this, state);
			// element.TypeParameters.TryAccept(this, state);
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			element.Name.TryAccept(this, state);
			element.Body.TryAccept(this, state);

			return element.Body == null;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIf element, VisitorState state) {
			// if(){...}
			state.Writer.Write("if (");
			element.Condition.TryAccept(this, state);
			state.Writer.Write(")");
			element.Body.TryAccept(this, state);
			// else...
			if (element.FalseBody != null) {
				state.Writer.Write("else");
				element.FalseBody.TryAccept(this, state);
			}

			return false;

		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedParameter element, VisitorState state) {
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			element.Name.TryAccept(this, state);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIdentifier element, VisitorState state) {
			state.Writer.Write(element.Value);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedModifier element, VisitorState state) {
			state.Writer.Write(element.Name);
			return false;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedImport element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントで出力する
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element.ToString() + " */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedConstructorDefinition element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedProgram element, VisitorState state) {
			foreach (var stmt in element) {
				if (stmt.TryAccept(this, state)) {
					state.Writer.Write(";");
				}

				return false;

			}
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedClassDefinition element, VisitorState state) {
			switch (element.Kind) {
			case(UnifiedClassKind.Enum) :
				state.Writer.Write("enum");
				state.WriteSpace();
				element.Name.TryAccept(this, state);
				element.Body.TryAccept(this, state);
				break;
			default:
				throw new NotImplementedException();
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinition element, VisitorState state) {
			element.Modifiers.TryAccept(this, state);
			state.WriteSpace();
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			element.Bodys.TryAccept(this, state);
			
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedNew element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedFor element, VisitorState state) {
			state.Writer.Write("for (");
			element.Initializer.TryAccept(this, state);
			state.Writer.Write("; ");
			element.Condition.TryAccept(this, state);
			state.Writer.Write("; ");
			element.Step.TryAccept(this, state);
			state.Writer.Write(")");

			element.Body.TryAccept(this, state);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedForeach element, VisitorState state) {
			// C言語にない要素なので，その旨をコメントとして出力する
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element.ToString() + " */");
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedUnaryExpression element, VisitorState state) {
			var paren = GetRequiredParen(element);
			state.Writer.Write(paren.Item1);

			var ope = element.Operator;
			switch (ope.Kind) {
			case UnifiedUnaryOperatorKind.PostDecrementAssign:
			case UnifiedUnaryOperatorKind.PostIncrementAssign:
				element.Operand.TryAccept(this, state);
				ope.TryAccept(this, state);
				break;
			default:
				ope.TryAccept(this, state);
				element.Operand.TryAccept(this, state);
				break;
			}

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedProperty element, VisitorState state) {
			element.Owner.TryAccept(this, state);
			state.Writer.Write(element.Delimiter);
			element.Name.Accept(this, state);
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedType element, VisitorState state) {
			element.Name.TryAccept(this, state);
			element.Arguments.TryAccept(this, state);
			element.Supplements.TryAccept(this, state);
			return false;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedWhile element, VisitorState state) {
			state.Writer.Write("while (");
			element.Condition.TryAccept(this, state);
			state.Writer.Write(")");
			element.Body.TryAccept(this, state);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedDoWhile element, VisitorState state) {
			state.Writer.Write("do");
			element.Body.TryAccept(this, state);
			state.Writer.Write("while(");
			element.Condition.Accept(this, state);
			state.Writer.Write(");");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIndexer element, VisitorState state) {
			element.Target.TryAccept(this, state);
			element.Arguments.TryAccept(this, state.Set(SquareBracket));

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeArgument element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSwitch element, VisitorState state) {
			state.Writer.Write("switch (");
			element.Value.TryAccept(this, state);
			state.Writer.Write(") {");
			element.Cases.TryAccept(this, state);
			state.Writer.Write("}");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCase element, VisitorState state) {
			if (element.Condition == null) {
				state.Writer.Write("default: ");
			} else {
				state.Writer.Write("case ");
				element.Condition.TryAccept(this, state);
				state.Writer.Write(":");
			}
			element.Body.Accept(this, state);

			return false;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSpecialExpression element, VisitorState state) {
			var keyword = GetKeyword(element.Kind);
			state.Writer.Write(keyword);
			state.WriteSpace();
			element.Value.TryAccept(this, state);

			return true;

		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSpecialBlock element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCatch element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTry element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		// (int)a, (int)(a + b)
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCast element, VisitorState state) {
			state.Writer.Write("(");
			element.Type.TryAccept(this, state);
			state.Writer.Write(")");
			element.Expression.TryAccept(this, state.Set(Paren));

			return true;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeConstrain element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC: ");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeParameter element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeSupplement element, VisitorState state) {
			var kind = element.Kind;

			switch(kind) {
			case UnifiedTypeSupplementKind.Array:
				element.Arguments.TryAccept(this, state.Set(SquareBracket));
				break;
			case UnifiedTypeSupplementKind.Pointer:
				state.Writer.Write("*");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}

			return false;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTernaryOperator element, VisitorState state) {
			switch (element.Kind) {
			case UnifiedTernaryOperatorKind.Conditional:
				state.Writer.Write(element.FirstSign);
				break;
			default:
				break;
			}

			return false;
		}

		private static Tuple<string, string> GetKeyword(UnifiedTernaryOperatorKind kind) {
			switch (kind) {
			case UnifiedTernaryOperatorKind.Conditional:
				return Tuple.Create("?", ":");
			default:
				throw new ArgumentException("kind");
			}

		}
		// a ? b : c;
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTernaryExpression element, VisitorState state) {
			var paren = GetRequiredParen(element);
			var keywords = GetKeyword(element.Operator.Kind);

			state.Writer.Write(paren.Item1);
			element.FirstExpression.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" " + keywords.Item1 + " ");
			element.SecondExpression.TryAccept(this, state.Set(Paren));
			state.Writer.Write(" " + keywords.Item2 + " ");
			element.LastExpression.TryAccept(this, state.Set(Paren));

			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinitionBody element, VisitorState state) {
			element.Name.TryAccept(this, state);
			if (element.InitialValue != null) {
				state.Writer.Write(" = ");
				element.InitialValue.TryAccept(this, state);
			}

			return true;
		}


		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedLabel element, VisitorState state) {
			element.Name.TryAccept(this, state);
			state.Writer.Write(" :");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedExpressionList element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBooleanLiteral element, VisitorState state) {
			if (element.Value) {
				state.Writer.Write("1");		// trueのとき
			} else {
				state.Writer.Write("0");		// falseのとき
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedFractionLiteral element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIntegerLiteral element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedStringLiteral element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedNullLiteral element, VisitorState state) {
			state.Writer.Write("NULL");
			return false;
		}


	}
}
