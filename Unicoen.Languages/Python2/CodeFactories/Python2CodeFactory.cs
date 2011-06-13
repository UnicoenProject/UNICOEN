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

namespace Unicoen.Languages.Python2.CodeFactories {
	public partial class Python2CodeFactory
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

		private static readonly Decoration InequalitySignParen =
				new Decoration { MostLeft = "<", Delimiter = ", ", MostRight = ">" };

		private static readonly Decoration Throws =
				new Decoration { MostLeft = "throws ", Delimiter = ", " };

		private static readonly Decoration CommaMostLeft =
				new Decoration { MostLeft = "," };

		private static readonly Decoration Empty = new Decoration();

		private static readonly Decoration AndDelimiter =
				new Decoration { Delimiter = " & " };

		private static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		private static readonly Decoration SpaceDelimiter =
				new Decoration { EachRight = " " };

		private static readonly Decoration NewLineDelimiter =
				new Decoration { Delimiter = "\n" };

		private static readonly Decoration SemiColonDelimiter =
				new Decoration { Delimiter = ";" };

		public override string Generate(
				IUnifiedElement model, TextWriter writer, string indentSign) {
			var buff = new StringWriter();
			model.Accept(this, new VisitorArgument(writer, indentSign));
			return buff.ToString();
		}

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			return Generate(model, writer, "\t");
		}

		#region program, namespace, class, method, filed ...

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedProgram element, VisitorArgument arg) {
			element.Comments.TryAccept(this, arg);
			arg.WriteLine();
			foreach (var stmt in element) {
				stmt.TryAccept(this, arg);
				arg.WriteLine();
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedNamespace element, VisitorArgument arg) {
			// パッケージはディレクトリ構造で表現
			arg.Write("# ");
			element.Modifiers.TryAccept(this, arg);
			arg.Write("package");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedClass element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write("class");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			arg.Write(":");
			arg.Write(" # ");
			element.TypeParameters.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg);
			arg.WriteLine();

			element.Body.TryAccept(this, arg.IncrementDepth());
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedFunction element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write("def ");
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedParameter element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			element.Names.TryAccept(this, arg.Set(CommaDelimiter));
			if (element.DefaultValue != null) {
				arg.Write(" = ");
				element.DefaultValue.TryAccept(this, arg);
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedModifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		#endregion

		#region statement

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedBlock element, VisitorArgument arg) {
			foreach (var stmt in element) {
				arg.WriteIndent();
				stmt.TryAccept(this, arg);
				arg.WriteLine();
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedIf ifStatement, VisitorArgument arg) {
			arg.Write("if ");
			ifStatement.Condition.TryAccept(this, arg);
			arg.WriteLine(":");
			ifStatement.Body.TryAccept(this, arg.IncrementDepth());
			if (ifStatement.ElseBody != null) {
				arg.WriteIndent();
				arg.WriteLine("else:");
				ifStatement.ElseBody.TryAccept(this, arg.IncrementDepth());
			}
			return false;
		}

		// e.g. catch(Exception e){...}
		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCatch element, VisitorArgument arg) {
			arg.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg);
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedTry element, VisitorArgument arg) {
			// try block
			arg.Write("try");
			element.Body.TryAccept(this, arg);

			// catch blocks
			element.Catches.TryAccept(this, arg);

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				arg.Write("finally");
				finallyBlock.TryAccept(this, arg);
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedTypeParameter element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedLabel element, VisitorArgument arg) {
			element.Name.TryAccept(this, arg);
			arg.Write(":");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedBooleanLiteral element, VisitorArgument arg) {
			if (element.Value)
				arg.Write("true");
			else
				arg.Write("false");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedFractionLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			switch (element.Kind) {
			case UnifiedFractionLiteralKind.Single:
				arg.Write("f");
				break;
			case UnifiedFractionLiteralKind.Double:
				arg.Write("d");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedIntegerLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			switch (element.Kind) {
			case UnifiedIntegerLiteralKind.Int32:
				break;
			case UnifiedIntegerLiteralKind.Int64:
				arg.Write("l");
				break;
			case UnifiedIntegerLiteralKind.BigInteger:
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedStringLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCharLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("null");
			return false;
		}

		#endregion

		#region expression

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedBinaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedArgument element, VisitorArgument arg) {
			arg.Write("/*");
			element.Modifiers.TryAccept(this, arg);
			arg.Write("*/");
			element.Value.TryAccept(this, arg);
			return false;
		}

		#endregion

		#region value

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedIdentifier identifier, VisitorArgument arg) {
			arg.Write(identifier.Value);
			return false;
		}

		#endregion

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedUnaryOperator element, VisitorArgument arg) {
			var kind = element.Kind;
			switch (kind) {
			case (UnifiedUnaryOperatorKind.Negate):
				arg.Write("-");
				break;
			case (UnifiedUnaryOperatorKind.Not):
				arg.Write("!");
				break;
			case (UnifiedUnaryOperatorKind.PostDecrementAssign):
			case (UnifiedUnaryOperatorKind.PreDecrementAssign):
				arg.Write("--");
				break;
			case (UnifiedUnaryOperatorKind.PostIncrementAssign):
			case (UnifiedUnaryOperatorKind.PreIncrementAssign):
				arg.Write("++");
				break;
			case (UnifiedUnaryOperatorKind.UnaryPlus):
				arg.Write("+");
				break;
			case (UnifiedUnaryOperatorKind.OnesComplement):
				arg.Write("~");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				arg.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedFor element, VisitorArgument arg) {
			element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("while ");
			element.Condition.TryAccept(this, arg);
			arg.WriteLine(":");
			arg = arg.IncrementDepth();
			element.Body.TryAccept(this, arg);
			arg.WriteIndent();
			element.Step.TryAccept(this, arg.Set(SemiColonDelimiter));
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedForeach element, VisitorArgument arg) {
			arg.Write("for ");
			element.Element.TryAccept(this, arg);
			arg.Write(" in ");
			element.Set.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			if (element.ElseBody.IsEmptyOrNull()) {
				arg.WriteLine("else:");
				element.ElseBody.TryAccept(this, arg.IncrementDepth());
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while ");
			element.Condition.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			if (element.ElseBody.IsEmptyOrNull()) {
				arg.WriteLine("else:");
				element.ElseBody.TryAccept(this, arg.IncrementDepth());
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedDoWhile element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg);
			arg.Write("while ");
			element.Condition.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedIndexer element, VisitorArgument arg) {
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(SquareBracket));
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedTypeArgument element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			element.Value.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedSwitch element, VisitorArgument arg) {
			if (element.Cases.IsEmptyOrNull()) {
				foreach (var c in element.Cases) {
					arg.Write("if ");
					element.Value.TryAccept(this, arg);
					arg.Write(" == ");
					c.Condition.TryAccept(this, arg);
					arg.WriteLine(":");
					c.Body.TryAccept(this, arg.IncrementDepth());
				}
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCase element, VisitorArgument arg) {
			throw new InvalidOperationException("このメソッドは呼び出せません。");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedMatcher element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			arg.Write(" ");
			element.Matcher.TryAccept(this, arg);
			arg.Write(" ");
			element.As.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedUsing element, VisitorArgument arg) {
			arg.Write("/* using ");
			element.Matchers.TryAccept(this, arg);
			arg.WriteLine(" { */");
			element.Matchers.TryAccept(this, arg);
			arg.WriteLine("//extracted from above");
			arg.WriteLine("/* } */");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedKeyValue element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedDictionary element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedSlice element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedComment element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedVariableDefinition element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write(" ");
			element.Type.TryAccept(this, arg);
			arg.Write(" ");
			element.Name.TryAccept(this, arg);
			if (element.InitialValue != null) {
				arg.Write(" = ");
				element.InitialValue.TryAccept(this, arg.Set(Bracket));
			}
			element.Arguments.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedGenericType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedArrayType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.Write("[");
			element.Arguments.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("]");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(UnifiedPass element, VisitorArgument arg) {
			arg.Write("pass");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(UnifiedPrint element, VisitorArgument arg) {
			arg.Write("print ");
			element.Value.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(UnifiedPrintChevron element, VisitorArgument arg) {
			arg.Write("print >> ");
			element.Value.TryAccept(this, arg);
			return false;
		}
			}
}