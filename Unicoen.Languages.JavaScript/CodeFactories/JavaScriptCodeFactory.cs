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

namespace Unicoen.Languages.JavaScript.CodeFactories {
	public partial class JavaScriptCodeFactory
			: CodeFactory, IUnifiedModelVisitor<VisitorState, bool> {
		private static readonly Decoration Paren =
				new Decoration { MostLeft = "(", Delimiter = ", ", MostRight = ")" };

		private static readonly Decoration Bracket =
				new Decoration { MostLeft = "{", Delimiter = ", ", MostRight = "}" };

		private static readonly Decoration SquareBracket =
				new Decoration { MostLeft = "[", Delimiter = ", ", MostRight = "]" };

		private static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		public override string Generate(
				IUnifiedElement model, TextWriter writer, string indentSign) {
			var buff = new StringWriter();
			model.Accept(this, new VisitorState(writer, indentSign));
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBinaryOperator op, VisitorState state) {
			state.Writer.Write(op.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedUnaryOperator element, VisitorState state) {
			var kind = element.Kind;
			switch (kind) {
			case (UnifiedUnaryOperatorKind.Negate):
				state.Writer.Write("-");
				break;
			case (UnifiedUnaryOperatorKind.Not):
				state.Writer.Write("!");
				break;
			case (UnifiedUnaryOperatorKind.PostDecrementAssign):
			case (UnifiedUnaryOperatorKind.PreDecrementAssign):
				state.Writer.Write("--");
				break;
			case (UnifiedUnaryOperatorKind.PostIncrementAssign):
			case (UnifiedUnaryOperatorKind.PreIncrementAssign):
				state.Writer.Write("++");
				break;
			case (UnifiedUnaryOperatorKind.UnaryPlus):
				state.Writer.Write("+");
				break;
			case (UnifiedUnaryOperatorKind.OnesComplement):
				state.Writer.Write("~");
				break;
			case (UnifiedUnaryOperatorKind.Delete):
				state.Writer.Write("delete");
				break;
			case (UnifiedUnaryOperatorKind.Void):
				state.Writer.Write("void");
				break;
			case (UnifiedUnaryOperatorKind.Typeof):
				state.Writer.Write("typeof");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				state.Writer.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedArgument arg, VisitorState state) {
			arg.Value.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBlock element, VisitorState state) {
			state.WriteIndent();
			state.Writer.WriteLine("{");
			state = state.IncrementIndentDepth();
			foreach (var stmt in element) {
				state.WriteIndent();
				if (stmt.TryAccept(this, state))
					state.Writer.Write(";");
			}
			state.WriteIndent();
			state.Writer.WriteLine("}");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFunctionDefinition element, VisitorState state) {
			state.WriteIndent();
			state.Writer.Write("function");
			state.WriteSpace();
			element.Name.TryAccept(this, state);
			element.Parameters.TryAccept(this, state);
			element.Body.TryAccept(this, state);
			return element.Body == null;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIf ifStatement, VisitorState state) {
			state.Writer.Write("if (");
			ifStatement.Condition.TryAccept(this, state);
			state.Writer.WriteLine(")");
			ifStatement.Body.TryAccept(this, state);
			if (ifStatement.ElseBody != null) {
				state.WriteIndent();
				state.Writer.WriteLine("else");
				ifStatement.ElseBody.TryAccept(this, state);
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedParameter element, VisitorState state) {
			element.Names.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIdentifier identifier, VisitorState state) {
			state.Writer.Write(identifier.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedModifier element, VisitorState state) {
			//JavaScriptでは修飾子は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedImport element, VisitorState state) {
			//JavaScriptでは外部ファイル読み込み文は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedConstructorDefinition element, VisitorState state) {
			//JavaScriptではコンストラクタ宣言は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedProgram element, VisitorState state) {
			foreach (var sourceElement in element) {
				if (sourceElement.TryAccept(this, state))
					state.Writer.Write(";");
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedClassDefinition element, VisitorState state) {
			//JavaScriptの場合はオブジェクト宣言を表します
			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedVariableDefinition element, VisitorState state) {
			element.Bodys.TryAccept(this, state);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFor element, VisitorState state) {
			state.Writer.Write("for(");
			element.Initializer.TryAccept(this, state.Set(CommaDelimiter));
			state.Writer.Write("; ");
			element.Condition.TryAccept(this, state);
			state.Writer.Write(";");
			element.Step.TryAccept(this, state.Set(CommaDelimiter));
			state.Writer.Write(")");

			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedForeach element, VisitorState state) {
			state.Writer.Write("for(");
			element.Element.TryAccept(this, state);
			state.WriteSpace();
			state.Writer.Write("in");
			state.WriteSpace();
			element.Set.TryAccept(this, state);
			state.Writer.Write(")");

			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedUnaryExpression element, VisitorState state) {
			//e.g. a++ || a--
			if (element.Operator.Kind == UnifiedUnaryOperatorKind.PostIncrementAssign ||
			    element.Operator.Kind == UnifiedUnaryOperatorKind.PostDecrementAssign) {
				element.Operand.TryAccept(this, state.Set(Paren));
				element.Operator.TryAccept(this, state);
			} else {
				element.Operator.TryAccept(this, state);
				element.Operand.TryAccept(this, state.Set(Paren));
			}
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedProperty element, VisitorState state) {
			element.Owner.TryAccept(this, state);
			state.Writer.Write(element.Delimiter);
			element.Name.TryAccept(this, state);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedType element, VisitorState state) {
			element.Name.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedWhile element, VisitorState state) {
			state.Writer.Write("while(");
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
			element.Condition.TryAccept(this, state);
			//TODO セミコロンが付かないことも許容されるがどうするか
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
			//JavaScriptでは型引数は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeArgumentCollection element, VisitorState state) {
			//JavaScriptでは型引数は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSwitch element, VisitorState state) {
			state.Writer.Write("switch(");
			element.Value.TryAccept(this, state);
			state.Writer.Write(") {");

			element.Cases.TryAccept(this, state);
			state.Writer.Write("}");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCase element, VisitorState state) {
			if (element.Condition == null) {
				state.Writer.Write("default:\n");
			} else {
				state.Writer.Write("case ");
				element.Condition.TryAccept(this, state);
				state.Writer.Write(":\n");
			}
			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSpecialExpression element, VisitorState state) {
			state.Writer.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				state.WriteSpace();
				element.Value.TryAccept(this, state);
			}
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSpecialBlock element, VisitorState state) {
			state.WriteIndent();
			switch (element.Kind) {
			case UnifiedSpecialBlockKind.With:
				state.Writer.Write("with");
				break;
			default:
				//JavaScriptではwith文のみ使用可能
				//TODO 他の言語モデルの変換の際に、synchronizedなどが来たらどう対処するのか
				throw new ArgumentOutOfRangeException();
			}
			if (element.Value != null) {
				state.Writer.Write("(");
				element.Value.TryAccept(this, state);
				state.Writer.Write(")");
			}

			//TODO なぜelement.Body.TryAcceptしないのか(Javaからの流用)
			state.Writer.Write("{");
			state = state.IncrementIndentDepth();
			foreach (var stmt in element.Body) {
				state.WriteIndent();
				if (stmt.TryAccept(this, state))
					state.Writer.Write(";");
			}
			state.WriteIndent();
			state.Writer.Write("}");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCatch element, VisitorState state) {
			state.Writer.Write("catch");
			element.Matchers.TryAccept(this, state.Set(Paren));
			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCatchCollection element, VisitorState state) {
			//JavaScriptではcatch節の列挙は出現しない
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTry element, VisitorState state) {
			// try block
			state.Writer.Write("try");
			element.Body.TryAccept(this, state);

			// catch blocks
			element.Catches.TryAccept(this, state);

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				state.Writer.Write("finally");
				finallyBlock.TryAccept(this, state);
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeConstrain element, VisitorState state) {
			//JavaScriptでは継承を示す識別子は出現しない(?)
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeConstrainCollection element, VisitorState state) {
			//JavaScriptでは継承を示す識別子は出現しない(?)
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeParameter element, VisitorState state) {
			//JavaScriptでは型パラメータは出現しない
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeSupplement element, VisitorState state) {
			//JavaScriptでは型宣言時に'[]'は出現しない
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTernaryOperator element, VisitorState state) {
			//TODO 実際には呼ばれない(?)
			switch (element.Kind) {
			case (UnifiedTernaryOperatorKind.Conditional):
				state.Writer.Write(element.FirstSign);
				break;
			default:
				break;
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedVariableDefinitionBody element, VisitorState state) {
			element.Name.TryAccept(this, state);
			element.Supplements.TryAccept(this, state);
			if (element.InitialValue != null) {
				state.Writer.Write(" = ");
				element.InitialValue.TryAccept(this, state.Set(Bracket));
			}
			element.Arguments.TryAccept(this, state.Set(Paren));
			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedLabel element, VisitorState state) {
			element.Name.TryAccept(this, state);
			state.Writer.Write(":");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBooleanLiteral element, VisitorState state) {
			if (element.Value)
				state.Writer.Write("true");
			else
				state.Writer.Write("false");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFractionLiteral element, VisitorState state) {
			state.Writer.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIntegerLiteral element, VisitorState state) {
			state.Writer.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedStringLiteral element, VisitorState state) {
			state.Writer.Write('"' + element.Value + '"');
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedNullLiteral element, VisitorState state) {
			state.Writer.Write("null");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedMatcher element, VisitorState state) {
			element.Modifiers.TryAccept(this, state);
			state.Writer.Write(" ");
			element.Matcher.TryAccept(this, state);
			state.Writer.Write(" ");
			element.As.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedUsing element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedListComprehension element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIfExpression element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedList element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedKeyValue element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedDictionaryComprehension element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedKeyValueCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedDictonary element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSlice element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedComment element, VisitorState state) {
			throw new NotImplementedException();
		}
			}
}