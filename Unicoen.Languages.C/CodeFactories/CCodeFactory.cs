#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.IO;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;
using Unicoen.Languages.Java.CodeFactories;

namespace Unicoen.Languages.C.CodeFactories {
	public partial class CCodeFactory
			: CodeFactory, IUnifiedModelVisitor<VisitorState, bool> {
		/// <summary>
		///   Expressionが括弧を付けるためのDecorationです
		/// </summary>
		private static readonly Decoration Paren =
				new Decoration { MostLeft = "(", Delimiter = ", ", MostRight = ")" };

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

		public override string Generate(
				IUnifiedElement model, TextWriter writer, string indentSign) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBinaryOperator element, VisitorState state) {
			state.Writer.Write(element.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedUnaryOperator element, VisitorState state) {
			state.Writer.Write(element.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedArgument element, VisitorState state) {
			element.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBlock element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCall element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFunctionDefinition element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIf element, VisitorState state) {
			// if(){...}
			state.Writer.Write("if (");
			element.Condition.TryAccept(this, state);
			state.Writer.Write(")");
			element.Body.TryAccept(this, state);
			// else...
			if (element.ElseBody != null) {
				state.Writer.Write("else");
				element.ElseBody.TryAccept(this, state);
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedParameter element, VisitorState state) {
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			element.Names.TryAccept(this, state);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIdentifier element, VisitorState state) {
			state.Writer.Write(element.Value);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedModifier element, VisitorState state) {
			state.Writer.Write(element.Name);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedImport element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントで出力する
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element + " */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedConstructorDefinition element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedProgram element, VisitorState state) {
			foreach (var stmt in element) {
				if (stmt.TryAccept(this, state)) {
					state.Writer.Write(";");
				}
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedClassDefinition element, VisitorState state) {
			switch (element.Kind) {
			case (UnifiedClassKind.Enum):
				state.Writer.Write("enum");
				state.WriteSpace();
				element.Name.TryAccept(this, state);
				element.Body.TryAccept(this, state);
				break;
			default:
				state.Writer.WriteLine("/* ElementNotInC */");
				state.Writer.WriteLine("/* " + element + " */");
				break;
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedNew element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFor element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedForeach element, VisitorState state) {
			// C言語にない要素なので，その旨をコメントとして出力する
			state.Writer.WriteLine("/* ElementNotInC */");
			state.Writer.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedProperty element, VisitorState state) {
			element.Owner.TryAccept(this, state);
			state.Writer.Write(element.Delimiter);
			element.Name.Accept(this, state);
			return false;
		}
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedWhile element, VisitorState state) {
			state.Writer.Write("while (");
			element.Condition.TryAccept(this, state);
			state.Writer.Write(")");
			element.Body.TryAccept(this, state);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedDoWhile element, VisitorState state) {
			state.Writer.Write("do");
			element.Body.TryAccept(this, state);
			state.Writer.Write("while(");
			element.Condition.Accept(this, state);
			state.Writer.Write(");");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIndexer element, VisitorState state) {
			element.Target.TryAccept(this, state);
			element.Arguments.TryAccept(this, state.Set(SquareBracket));

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeArgument element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSwitch element, VisitorState state) {
			state.Writer.Write("switch (");
			element.Value.TryAccept(this, state);
			state.Writer.Write(") {");
			element.Cases.TryAccept(this, state);
			state.Writer.Write("}");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCase element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSpecialBlock element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCatch element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTry element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeConstrain element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC: ");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeParameter element, VisitorState state) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			state.Writer.Write("/* ");
			state.Writer.Write("ElementNotInC :");
			state.Writer.Write(element.ToString());
			state.Writer.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeSupplement element, VisitorState state) {
			var kind = element.Kind;

			switch (kind) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedLabel element, VisitorState state) {
			element.Name.TryAccept(this, state);
			state.Writer.Write(": ");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBooleanLiteral element, VisitorState state) {
			if (element.Value) {
				state.Writer.Write("1"); // trueのとき
			} else {
				state.Writer.Write("0"); // falseのとき
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFractionLiteral element, VisitorState state) {
			state.Writer.Write(element.Value);

			var kind = element.Kind;
			switch (kind) {
			case UnifiedFractionLiteralKind.Single:
				state.Writer.Write("f");
				break;
			case UnifiedFractionLiteralKind.Double:
				state.Writer.Write("d"); // あってもなくてもいい
				break;
			default:
				break;
			}

			// TODO: long doubleをどう扱うか？
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIntegerLiteral element, VisitorState state) {
			state.Writer.Write(element.Value);

			var kind = element.Kind;
			switch (kind) {
			case UnifiedIntegerLiteralKind.BigInteger:
			case UnifiedIntegerLiteralKind.Int32:
			case UnifiedIntegerLiteralKind.Int64:
				break;
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedStringLiteral element, VisitorState state) {
			var kind = element.Kind;
			var delimiter = "";

			switch (kind) {
			case UnifiedStringLiteralKind.Char:
				delimiter = "'";
				break;
			case UnifiedStringLiteralKind.String:
				delimiter = "\"";
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}

			state.Writer.Write(delimiter + element.Value + delimiter);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedNullLiteral element, VisitorState state) {
			state.Writer.Write("NULL");
			return false;
		}
			}
}