﻿#region License

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
			: CodeFactory, IUnifiedVisitor<bool, VisitorArgument> {
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

		public override void Generate(
				IUnifiedElement model, TextWriter writer, string indentSign) {
			model.Accept(this, new VisitorArgument(writer, indentSign));
		}

		public override void Generate(IUnifiedElement model, TextWriter writer) {
			Generate(model, writer, "\t");
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedBinaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedUnaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedArgument element, VisitorArgument arg) {
			if (element.Modifiers.IsEmptyOrNull()) {
				arg.Write("/*");
				element.Modifiers.TryAccept(this, arg);
				arg.Write("*/");
			}
			element.Value.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedBlock element, VisitorArgument arg) {
			arg.WriteLine();
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
			arg.WriteLine("}");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCall element, VisitorArgument arg) {
			var prop = element.Function as UnifiedProperty;
			if (prop != null) {
				prop.Owner.TryAccept(this, arg);
				arg.Write(prop.Delimiter);
				element.GenericArguments.TryAccept(this, arg);
				prop.Name.TryAccept(this, arg);
			} else {
				// Javaでifが実行されるケースは存在しないが、言語変換のため
				if (element.GenericArguments != null)
					arg.Write("this.");
				element.GenericArguments.TryAccept(this, arg);
				element.Function.TryAccept(this, arg);
			}
			element.Arguments.TryAccept(this, arg.Set(Paren));
			return true;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedFunction element, VisitorArgument arg) {
			// C言語に存在しない要素は省略

			arg.WriteIndent();
			arg.Write("/* ");
			element.Modifiers.TryAccept(this, arg);
			arg.Write(" */");
			// element.GenericParameters.TryAccept(this, arg);
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Body.TryAccept(this, arg);

			return element.Body == null;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedParameter element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			element.Names.TryAccept(this, arg);

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedVariableIdentifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedLabelIdentifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedSuperIdentifier element, VisitorArgument arg) {
			arg.Write("/*" + element.Name + "*/");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedThisIdentifier element, VisitorArgument arg) {
			arg.Write("/*" + element.Name + "*/");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedModifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedImport element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントで出力する
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedProgram element, VisitorArgument arg) {
			foreach (var stmt in element) {
				if (stmt.TryAccept(this, arg)) {
					arg.Write(";");
				}
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedNew element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedForeach element, VisitorArgument arg) {
			// C言語にない要素なので，その旨をコメントとして出力する
			arg.WriteLine("/* ElementNotInC */");
			arg.WriteLine("/* " + element + " */");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedProperty element, VisitorArgument arg) {
			element.Owner.TryAccept(this, arg);
			arg.Write(element.Delimiter);
			element.Name.Accept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while (");
			element.Condition.TryAccept(this, arg);
			arg.Write(")");
			element.Body.TryAccept(this, arg);

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedDoWhile element, VisitorArgument arg) {
			arg.Write("do");
			element.Body.TryAccept(this, arg);
			arg.Write("while(");
			element.Condition.Accept(this, arg);
			arg.Write(");");

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedIndexer element, VisitorArgument arg) {
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(SquareBracket));

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedSwitch element, VisitorArgument arg) {
			arg.Write("switch (");
			element.Value.TryAccept(this, arg);
			arg.Write(") {");
			element.Cases.TryAccept(this, arg);
			arg.Write("}");

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCatch element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC :");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedTry element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC :");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedTypeParameter element, VisitorArgument arg) {
			// C言語に存在しない要素なので，その旨をコメントとして出力する
			arg.Write("/* ");
			arg.Write("ElementNotInC :");
			arg.Write(element.ToString());
			arg.Write(" */");

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedLabel element, VisitorArgument arg) {
			element.Name.TryAccept(this, arg);
			arg.Write(": ");

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedBooleanLiteral element, VisitorArgument arg) {
			if (element.Value) {
				arg.Write("1"); // trueのとき
			} else {
				arg.Write("0"); // falseのとき
			}

			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCharLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedStringLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("NULL");
			return false;
		}
			}
}