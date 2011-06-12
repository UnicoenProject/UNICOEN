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
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.C.CodeFactories {
	public partial class CCodeFactory
			: CodeFactory, IUnifiedModelVisitor<VisitorArgument, bool> {
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
			model.Accept(this, new VisitorArgument(writer, indentSign));
			return buff.ToString();
		}

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			return Generate(model, writer, "\t");
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBinaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedUnaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArgument element, VisitorArgument arg) {
			if (element.Modifiers.IsEmptyOrNull()) {
				arg.Write("/*");
				element.Modifiers.TryAccept(this, arg);
				arg.Write("*/");
			}
			element.Value.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBlock element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.WriteLine("{");
			arg = arg.IncrementDepth();
			foreach (var stmt in element) {
				arg.WriteIndent();
				if (stmt.TryAccept(this, arg)) {
					arg.Write(";");
				}
			}

			arg.WriteIndent();
			arg.WriteLine(";");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCall element, VisitorArgument arg) {
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, arg);
				arg.Write(prop.Delimiter);
				element.TypeArguments.TryAccept(this, arg);
				prop.Name.TryAccept(this, arg);
			} else {
				// Javaでifが実行されるケースは存在しないが、言語変換のため
				if (element.TypeArguments != null)
					arg.Write("this.");
				element.TypeArguments.TryAccept(this, arg);
				element.Function.TryAccept(this, arg);
			}
			element.Arguments.TryAccept(this, arg.Set(Paren));
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			// C言語に存在しない要素は省略

			arg.WriteIndent();
			element.Modifiers.TryAccept(this, arg);
			// element.TypeParameters.TryAccept(this, arg);
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Body.TryAccept(this, arg);

			return element.Body == null;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIf element, VisitorArgument arg) {
			// if(){...}
			arg.Write("if (");
			element.Condition.TryAccept(this, arg);
			arg.Write(")");
			element.Body.TryAccept(this, arg);
			// else...
			if (element.ElseBody != null) {
				arg.Write("else");
				element.ElseBody.TryAccept(this, arg);
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedParameter element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			element.Names.TryAccept(this, arg);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIdentifier element, VisitorArgument arg) {
			arg.Write(element.Value);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedModifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedImport element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントで出力する
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedConstructorDefinition element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedProgram element, VisitorArgument arg) {
			foreach (var stmt in element) {
				if (stmt.TryAccept(this, arg)) {
					arg.Write(";");
				}
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNew element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedFor element, VisitorArgument arg) {
			arg.Write("for (");
			element.Initializer.TryAccept(this, arg);
			arg.Write("; ");
			element.Condition.TryAccept(this, arg);
			arg.Write("; ");
			element.Step.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedForeach element, VisitorArgument arg) {
			// C言語にない要素なので，その旨をコメントとして出力する
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedProperty element, VisitorArgument arg) {
			element.Owner.TryAccept(this, arg);
			arg.Write(element.Delimiter);
			element.Name.Accept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while (");
			element.Condition.TryAccept(this, arg);
			arg.Write(")");
			element.Body.TryAccept(this, arg);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDoWhile element, VisitorArgument arg) {
			arg.Write("do");
			element.Body.TryAccept(this, arg);
			arg.Write("while(");
			element.Condition.Accept(this, arg);
			arg.Write(");");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIndexer element, VisitorArgument arg) {
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(SquareBracket));

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeArgument element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSwitch element, VisitorArgument arg) {
			arg.Write("switch (");
			element.Value.TryAccept(this, arg);
			arg.Write(") {");
			element.Cases.TryAccept(this, arg);
			arg.Write("}");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCase element, VisitorArgument arg) {
			if (element.Condition == null) {
				arg.Write("default: ");
			} else {
				arg.Write("case ");
				element.Condition.TryAccept(this, arg);
				arg.Write(":");
			}
			element.Body.Accept(this, arg);

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSpecialBlock element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC :");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCatch element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC :");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTry element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC :");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeConstrain element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC: ");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeParameter element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC :");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeSupplement element, VisitorArgument arg) {
			var kind = element.Kind;

			switch (kind) {
			case UnifiedTypeSupplementKind.Array:
				element.Arguments.TryAccept(this, arg.Set(SquareBracket));
				break;
			case UnifiedTypeSupplementKind.Pointer:
				arg.Write("*");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedLabel element, VisitorArgument arg) {
			element.Name.TryAccept(this, arg);
			arg.Write(": ");

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBooleanLiteral element, VisitorArgument arg) {
			if (element.Value) {
				arg.Write("1"); // trueのとき
			} else {
				arg.Write("0"); // falseのとき
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedFractionLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);

			var kind = element.Kind;
			switch (kind) {
			case UnifiedFractionLiteralKind.Single:
				arg.Write("f");
				break;
			case UnifiedFractionLiteralKind.Double:
				arg.Write("d"); // あってもなくてもいい
				break;
			default:
				break;
			}

			// TODO: long doubleをどう扱うか？
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIntegerLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);

			var kind = element.Kind;
			switch (kind) {
			case UnifiedIntegerLiteralKind.BigInteger:
			case UnifiedIntegerLiteralKind.Int32:
			case UnifiedIntegerLiteralKind.Int64:
				break;
			}

			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCharLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNamespace element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedStringLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("NULL");
			return false;
		}
			}
}