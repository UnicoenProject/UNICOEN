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
	public partial class Python2CodeFactoryVisitor
			: ExplicitDefaultUnifiedVisitor<VisitorArgument, bool> {
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

		#region program, namespace, class, method, filed ...

		public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
			element.Comments.TryAccept(this, arg);
			arg.WriteLine();
			element.Body.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedNamespace element, VisitorArgument arg) {
			// パッケージはディレクトリ構造で表現
			arg.Write("# ");
			element.Modifiers.TryAccept(this, arg);
			arg.Write("package");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedClass element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write("class");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			arg.Write(":");
			arg.Write(" # ");
			element.GenericParameters.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg);
			arg.WriteLine();

			element.Body.TryAccept(this, arg.IncrementDepth());
			return false;
		}

		public override bool Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write("def ");
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			return false;
		}

		public override bool Visit(UnifiedParameter element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			element.Names.TryAccept(this, arg.Set(CommaDelimiter));
			if (element.DefaultValue != null) {
				arg.Write(" = ");
				element.DefaultValue.TryAccept(this, arg);
			}
			return false;
		}

		public override bool Visit(UnifiedModifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		#endregion

		#region statement

		public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
			foreach (var stmt in element) {
				arg.WriteIndent();
				stmt.TryAccept(this, arg);
				arg.WriteLine();
			}
			return false;
		}

		public override bool Visit(UnifiedIf ifStatement, VisitorArgument arg) {
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
		public override bool Visit(UnifiedCatch element, VisitorArgument arg) {
			arg.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg);
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
		public override bool Visit(UnifiedTry element, VisitorArgument arg) {
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

		public override bool Visit(UnifiedTypeParameter element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		public override bool Visit(UnifiedLabel element, VisitorArgument arg) {
			element.Name.TryAccept(this, arg);
			arg.Write(":");
			return false;
		}

		public override bool Visit(UnifiedBooleanLiteral element, VisitorArgument arg) {
			if (element.Value)
				arg.Write("true");
			else
				arg.Write("false");
			return false;
		}

		public override bool Visit(
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

		public override bool Visit(UnifiedIntegerLiteral element, VisitorArgument arg) {
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

		public override bool Visit(UnifiedStringLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedCharLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("null");
			return false;
		}

		#endregion

		#region expression

		public override bool Visit(UnifiedBinaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

		public override bool Visit(UnifiedArgument element, VisitorArgument arg) {
			arg.Write("/*");
			element.Modifiers.TryAccept(this, arg);
			arg.Write("*/");
			element.Value.TryAccept(this, arg);
			return false;
		}

		#endregion

		#region value

		public override bool Visit(
				UnifiedVariableIdentifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		public override bool Visit(
				UnifiedLabelIdentifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		public override bool Visit(
				UnifiedSuperIdentifier element, VisitorArgument arg) {
			arg.Write("");
			return false;
		}

		public override bool Visit(UnifiedThisIdentifier element, VisitorArgument arg) {
			arg.Write("");
			return false;
		}

		#endregion

		public override bool Visit(UnifiedUnaryOperator element, VisitorArgument arg) {
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

		public override bool Visit(UnifiedFor element, VisitorArgument arg) {
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

		public override bool Visit(UnifiedForeach element, VisitorArgument arg) {
			arg.Write("for ");
			element.Element.TryAccept(this, arg);
			arg.Write(" in ");
			element.Set.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			if (element.ElseBody.IsNotEmpty()) {
				arg.WriteLine("else:");
				element.ElseBody.TryAccept(this, arg.IncrementDepth());
			}
			return false;
		}

		public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while ");
			element.Condition.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			if (element.ElseBody.IsNotEmpty()) {
				arg.WriteLine("else:");
				element.ElseBody.TryAccept(this, arg.IncrementDepth());
			}
			return false;
		}

		public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg);
			arg.Write("while ");
			element.Condition.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
			return false;
		}

		public override bool Visit(UnifiedIndexer element, VisitorArgument arg) {
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(SquareBracket));
			return false;
		}

		public override bool Visit(
				UnifiedGenericArgument element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			element.Value.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		public override bool Visit(UnifiedSwitch element, VisitorArgument arg) {
			if (element.Cases.IsNotEmpty()) {
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

		public override bool Visit(UnifiedCase element, VisitorArgument arg) {
			throw new InvalidOperationException("このメソッドは呼び出せません。");
			return false;
		}

		public override bool Visit(UnifiedMatcher element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			arg.Write(" ");
			element.Matcher.TryAccept(this, arg);
			arg.Write(" ");
			element.As.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedUsing element, VisitorArgument arg) {
			arg.Write("/* using ");
			element.Matchers.TryAccept(this, arg);
			arg.WriteLine(" { */");
			element.Matchers.TryAccept(this, arg);
			arg.WriteLine("//extracted from above");
			arg.WriteLine("/* } */");
			return false;
		}

		public override bool Visit(UnifiedKeyValue element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedDictionary element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSlice element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedComment element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
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

		public override bool Visit(UnifiedGenericType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedArrayType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.Write("[");
			element.Arguments.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("]");
			return false;
		}

		public override bool Visit(UnifiedPass element, VisitorArgument arg) {
			arg.Write("pass");
			return false;
		}

		public override bool Visit(UnifiedPrint element, VisitorArgument arg) {
			arg.Write("print ");
			element.Value.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedPrintChevron element, VisitorArgument arg) {
			arg.Write("print >> ");
			element.Value.TryAccept(this, arg);
			return false;
		}
			}
}