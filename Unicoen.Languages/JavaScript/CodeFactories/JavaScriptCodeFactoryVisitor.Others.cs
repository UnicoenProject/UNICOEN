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
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.JavaScript.CodeFactories {
	public partial class JavaScriptCodeFactoryVisitor
			: ExplicitDefaultUnifiedVisitor<VisitorArgument, bool> {
		private static readonly Decoration Paren =
				new Decoration { MostLeft = "(", Delimiter = ", ", MostRight = ")" };

		private static readonly Decoration Bracket =
				new Decoration { MostLeft = "{", Delimiter = ", ", MostRight = "}" };

		private static readonly Decoration SquareBracket =
				new Decoration { MostLeft = "[", Delimiter = ", ", MostRight = "]" };

		private static readonly Decoration ForBlock =
				new Decoration { MostLeft = "{", Delimiter = "\n", MostRight = "}" };

		private static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		private static readonly Decoration SemiColonDelimiter =
				new Decoration { Delimiter = "; " };

		public override bool Visit(UnifiedBinaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

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
			case (UnifiedUnaryOperatorKind.Delete):
				arg.Write("delete ");
				break;
			case (UnifiedUnaryOperatorKind.Void):
				arg.Write("void ");
				break;
			case (UnifiedUnaryOperatorKind.Typeof):
				arg.Write("typeof ");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				arg.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		public override bool Visit(UnifiedArgument element, VisitorArgument arg) {
			element.Value.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
			var decoration = arg.Decoration;
			//for Block
			if (decoration.MostLeft == "{") {
				arg.WriteLine(decoration.MostLeft);
				arg = arg.IncrementDepth();

				foreach (var stmt in element) {
					arg.WriteIndent();
					if (stmt.TryAccept(this, arg))
						arg.Write(";");
					arg.Write(decoration.Delimiter);
				}
				arg = arg.DecrementDepth();
				arg.WriteIndent();
				arg.Write(decoration.MostRight);
				return false;
			}

			//empty block
			if (element.Count == 0)
				return false;

			//for expressionList
			arg.Write("(");
			var comma = "";
			foreach (var e in element) {
				arg.Write(comma);
				e.TryAccept(this, arg);
				comma = decoration.Delimiter;
			}
			arg.Write(")");
			return false;
		}

		public override bool Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.Write("function");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		public override bool Visit(UnifiedLambda element, VisitorArgument arg) {
			//λ式の場合、即時発火があり得るので全体を()で囲っておく
			arg.WriteIndent();
			arg.Write("(");
			arg.Write("function");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			arg.Write(")");
			return element.Body == null;
		}

		public override bool Visit(UnifiedIf ifStatement, VisitorArgument arg) {
			arg.Write("if (");
			ifStatement.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(")");
			ifStatement.Body.TryAccept(this, arg.Set(ForBlock));
			if (ifStatement.ElseBody != null) {
				arg.WriteIndent();
				arg.WriteLine("else");
				ifStatement.ElseBody.TryAccept(this, arg.Set(ForBlock));
			}
			return false;
		}

		public override bool Visit(UnifiedParameter element, VisitorArgument arg) {
			element.Names.TryAccept(this, arg);
			return false;
		}

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
			arg.Write("this");
			return false;
		}

		public override bool Visit(UnifiedModifier element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(UnifiedImport element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(UnifiedConstructor element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(
				UnifiedInstanceInitializer element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(
				UnifiedStaticInitializer element, VisitorArgument arg) {
			return false;
		}

		public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
			foreach (var sourceElement in element) {
				if (sourceElement.TryAccept(this, arg))
					arg.Write(";");
				arg.Write("\n");
			}
			return false;
		}

		public override bool Visit(UnifiedFor element, VisitorArgument arg) {
			arg.Write("for(");
			element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("; ");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(";");
			element.Step.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedForeach element, VisitorArgument arg) {
			arg.Write("for(");
			element.Element.TryAccept(this, arg);
			arg.WriteSpace();
			arg.Write("in");
			arg.WriteSpace();
			element.Set.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedUnaryExpression element, VisitorArgument arg) {
			//e.g. a++ || a--
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.TryAccept(this, arg.Set(Paren));
				element.Operator.TryAccept(this, arg);
			} else {
				element.Operator.TryAccept(this, arg);
				element.Operand.TryAccept(this, arg.Set(Paren));
			}
			return true;
		}

		public override bool Visit(UnifiedProperty element, VisitorArgument arg) {
			element.Owner.TryAccept(this, arg);
			arg.Write(element.Delimiter);
			element.Name.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while(");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
			arg.Write("do");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			arg.Write("while(");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(");");
			return false;
		}

		public override bool Visit(UnifiedIndexer element, VisitorArgument arg) {
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(SquareBracket));
			return false;
		}

		public override bool Visit(
				UnifiedGenericArgument element, VisitorArgument arg) {
			//JavaScript
			return false;
		}

		public override bool Visit(
				UnifiedGenericArgumentCollection element, VisitorArgument arg) {
			//JavaScript
			return false;
		}

		public override bool Visit(UnifiedSwitch element, VisitorArgument arg) {
			arg.Write("switch(");
			element.Value.TryAccept(this, arg.Set(CommaDelimiter));
			arg.WriteLine(") {");

			element.Cases.TryAccept(this, arg);
			arg.Write("}");
			return false;
		}

		public override bool Visit(UnifiedCase element, VisitorArgument arg) {
			if (element.Condition == null) {
				arg.Write("default:\n");
			} else {
				arg.Write("case ");
				element.Condition.TryAccept(this, arg);
				arg.Write(":\n");
			}
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedWith element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.Write("with (");
			element.Value.TryAccept(this, arg);
			arg.Write(")");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedCatch element, VisitorArgument arg) {
			arg.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			arg.Write(arg.Decoration.MostLeft);
			var delimiter = "";
			foreach (var e in element) {
				arg.Write(delimiter);
				e.TryAccept(this, arg);
				delimiter = arg.Decoration.Delimiter;
			}
			arg.Write(arg.Decoration.MostRight);
			return false;
		}

		public override bool Visit(UnifiedTry element, VisitorArgument arg) {
			// try block
			arg.Write("try");
			element.Body.TryAccept(this, arg.Set(ForBlock));

			// catch blocks
			element.Catches.TryAccept(this, arg.Set(SemiColonDelimiter));

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				arg.Write("finally");
				finallyBlock.TryAccept(this, arg.Set(ForBlock));
			}
			return false;
		}

		public override bool Visit(
				UnifiedTypeConstrainCollection element, VisitorArgument arg) {
			//JavaScript
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedTypeParameter element, VisitorArgument arg) {
			//JavaScript
			throw new NotImplementedException();
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
			return false;
		}

		public override bool Visit(UnifiedIntegerLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
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

		public override bool Visit(
				UnifiedNamespace element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("null");
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
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedList element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedKeyValue element, VisitorArgument arg) {
			arg.WriteIndent();
			element.Key.TryAccept(this, arg);
			arg.Write(":");
			element.Value.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedDictionary element, VisitorArgument arg) {
			arg.Write("{");
			VisitCollection(element, arg.Set(CommaDelimiter));
			arg.WriteIndent();
			arg.Write("}");
			return false;
		}

		public override bool Visit(UnifiedSlice element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedComment element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedRegularExpressionLiteral element, VisitorArgument arg) {
			arg.Write("/");
			arg.Write(element.Value);
			arg.Write("/");
			arg.Write(element.Options);
			return false;
		}

		public override bool Visit(UnifiedArray element, VisitorArgument arg) {
			//TODO 上からBracketが渡されるので、対策を考える
			//とりあえず直接"[]"を代入で対処
			arg.Write("[");
			var comma = "";
			foreach (var e in element) {
				arg.Write(comma);
				e.TryAccept(this, arg);
				comma = ",";
			}
			arg.Write("]");
			return false;
		}

		public override bool Visit(UnifiedSimpleType element, VisitorArgument arg) {
			//e.g. new new r().f
			//TODO ただし、言語変換を考えると型を出力してほしくないので、対応を考える
			element.NameExpression.TryAccept(this, arg);
			return false;
		}
			}
}