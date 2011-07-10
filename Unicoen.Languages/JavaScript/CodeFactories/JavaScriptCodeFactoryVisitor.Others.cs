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

namespace Unicoen.Languages.JavaScript.CodeFactories {
	public partial class JavaScriptCodeFactoryVisitor {
		public override bool Visit(UnifiedBinaryOperator element, VisitorArgument arg) {
			Writer.Write(element.Sign);
			return false;
		}

		public override bool Visit(UnifiedUnaryOperator element, VisitorArgument arg) {
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
			case (UnifiedUnaryOperatorKind.Delete):
				Writer.Write("delete ");
				break;
			case (UnifiedUnaryOperatorKind.Void):
				Writer.Write("void ");
				break;
			case (UnifiedUnaryOperatorKind.Typeof):
				Writer.Write("typeof ");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				Writer.Write(element.Sign);
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
				Writer.WriteLine(decoration.MostLeft);
				arg = arg.IncrementDepth();

				foreach (var stmt in element) {
					WriteIndent(arg);
					if (stmt.TryAccept(this, arg))
						Writer.Write(";");
					Writer.Write(decoration.Delimiter);
				}
				arg = arg.DecrementDepth();
				WriteIndent(arg);
				Writer.Write(decoration.MostRight);
				return false;
			}

			//empty block
			if (element.Count == 0)
				return false;

			//for expressionList
			Writer.Write("(");
			var comma = "";
			foreach (var e in element) {
				Writer.Write(comma);
				e.TryAccept(this, arg);
				comma = decoration.Delimiter;
			}
			Writer.Write(")");
			return false;
		}

		public override bool Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			WriteIndent(arg);
			Writer.Write("function");
			Writer.Write(" ");
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		public override bool Visit(UnifiedLambda element, VisitorArgument arg) {
			//λ式の場合、即時発火があり得るので全体を()で囲っておく
			WriteIndent(arg);
			Writer.Write("(");
			Writer.Write("function");
			Writer.Write(" ");
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			Writer.Write(")");
			return element.Body == null;
		}

		public override bool Visit(UnifiedIf ifStatement, VisitorArgument arg) {
			Writer.Write("if (");
			ifStatement.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(")");
			ifStatement.Body.TryAccept(this, arg.Set(ForBlock));
			if (ifStatement.ElseBody != null) {
				WriteIndent(arg);
				Writer.WriteLine("else");
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
			Writer.Write(element.Name);
			return false;
		}

		public override bool Visit(
				UnifiedLabelIdentifier element, VisitorArgument arg) {
			Writer.Write(element.Name);
			return false;
		}

		public override bool Visit(
				UnifiedSuperIdentifier element, VisitorArgument arg) {
			Writer.Write("");
			return false;
		}

		public override bool Visit(UnifiedThisIdentifier element, VisitorArgument arg) {
			Writer.Write("this");
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
			foreach (var sourceElement in element.Body) {
				if (sourceElement.TryAccept(this, arg))
					Writer.Write(";");
				Writer.Write("\n");
			}
			return false;
		}

		public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
			Writer.Write("while(");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
			Writer.Write("do");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			Writer.Write("while(");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(");");
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
			Writer.Write("switch(");
			element.Value.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.WriteLine(") {");

			element.Cases.TryAccept(this, arg);
			Writer.Write("}");
			return false;
		}

		public override bool Visit(UnifiedCase element, VisitorArgument arg) {
			if (element.Condition == null) {
				Writer.Write("default:\n");
			} else {
				Writer.Write("case ");
				element.Condition.TryAccept(this, arg);
				Writer.Write(":\n");
			}
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedWith element, VisitorArgument arg) {
			WriteIndent(arg);
			Writer.Write("with (");
			element.Value.TryAccept(this, arg);
			Writer.Write(")");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedCatch element, VisitorArgument arg) {
			Writer.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			Writer.Write(arg.Decoration.MostLeft);
			var delimiter = "";
			foreach (var e in element) {
				Writer.Write(delimiter);
				e.TryAccept(this, arg);
				delimiter = arg.Decoration.Delimiter;
			}
			Writer.Write(arg.Decoration.MostRight);
			return false;
		}

		public override bool Visit(UnifiedTry element, VisitorArgument arg) {
			// try block
			Writer.Write("try");
			element.Body.TryAccept(this, arg.Set(ForBlock));

			// catch blocks
			element.Catches.TryAccept(this, arg.Set(SemiColonDelimiter));

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				Writer.Write("finally");
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
			Writer.Write(":");
			return false;
		}

		public override bool Visit(UnifiedBooleanLiteral element, VisitorArgument arg) {
			if (element.Value)
				Writer.Write("true");
			else
				Writer.Write("false");
			return false;
		}

		public override bool Visit(
				UnifiedFractionLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedIntegerLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedStringLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedCharLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(
				UnifiedNamespace element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedNullLiteral element, VisitorArgument arg) {
			Writer.Write("null");
			return false;
		}

		public override bool Visit(UnifiedMatcher element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			Writer.Write(" ");
			element.Matcher.TryAccept(this, arg);
			Writer.Write(" ");
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
			WriteIndent(arg);
			element.Key.TryAccept(this, arg);
			Writer.Write(":");
			element.Value.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedDictionary element, VisitorArgument arg) {
			Writer.Write("{");
			VisitCollection(element, arg.Set(CommaDelimiter));
			WriteIndent(arg);
			Writer.Write("}");
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
			Writer.Write("/");
			Writer.Write(element.Value);
			Writer.Write("/");
			Writer.Write(element.Options);
			return false;
		}

		public override bool Visit(UnifiedArray element, VisitorArgument arg) {
			//TODO 上からBracketが渡されるので、対策を考える
			//とりあえず直接"[]"を代入で対処
			Writer.Write("[");
			var comma = "";
			foreach (var e in element) {
				Writer.Write(comma);
				e.TryAccept(this, arg);
				comma = ",";
			}
			Writer.Write("]");
			return false;
		}

		public override bool Visit(UnifiedSimpleType element, VisitorArgument arg) {
			//e.g. new new r().f
			//TODO ただし、言語変換を考えると型を出力してほしくないので、対応を考える
			element.BasicType.TryAccept(this, arg);
			return false;
		}
			}
}