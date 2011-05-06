using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;
using Unicoen.Languages.Java.CodeFactories;

namespace Unicoen.Languages.JavaScript.CodeFactories
{
	public partial class JavaScriptCodeFactory : CodeFactory, IUnifiedModelVisitor<VisitorState, bool>
	{
		private static readonly Decoration Paren =
				new Decoration { MostLeft = "(", Delimiter = ", ", MostRight = ")" };

		private static readonly Decoration Bracket =
				new Decoration { MostLeft = "{", Delimiter = ", ", MostRight = "}" };

		private static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		public override string Generate(IUnifiedElement model, TextWriter writer, string indentSign) {
			var buff = new StringWriter();
			model.Accept(this, new VisitorState(writer, indentSign));
			return buff.ToString();
		}

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			return Generate(model, writer, "\t");
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBinaryOperator op, VisitorState state) {
			state.Writer.Write(op.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedUnaryOperator element, VisitorState state) {
			var kind = element.Kind;
			switch(kind) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedArgument arg, VisitorState state) {
			arg.Value.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBlock element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedFunctionDefinition element, VisitorState state) {
			state.WriteIndent();
			state.Writer.Write("function");
			state.WriteSpace();
			element.Name.TryAccept(this, state);
			element.Parameters.TryAccept(this, state);
			element.Body.TryAccept(this, state);
			return element.Body == null;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIf ifStatement, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedParameter element, VisitorState state) {
			element.Name.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIdentifier identifier, VisitorState state) {
			state.Writer.Write(identifier.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedModifier element, VisitorState state) {
			//JavaScriptでは修飾子は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedImport element, VisitorState state) {
			//JavaScriptでは外部ファイル読み込み文は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedConstructorDefinition element, VisitorState state) {
			//JavaScriptではコンストラクタ宣言は出現しない
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedProgram element, VisitorState state) {
			foreach (var sourceElement in element) {
				if (sourceElement.TryAccept(this, state))
					state.Writer.Write(";");
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedClassDefinition element, VisitorState state) {
			//JavaScriptの場合はオブジェクト宣言を表します
			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinition element, VisitorState state) {
			element.Bodys.TryAccept(this, state);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedFor element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedForeach element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedUnaryExpression element, VisitorState state) {
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

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedProperty element, VisitorState state) {
			element.Owner.TryAccept(this, state);
			state.Writer.Write(element.Delimiter);
			element.Name.TryAccept(this, state);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedType element, VisitorState state) {
			element.Name.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedWhile element, VisitorState state) {
			state.Writer.Write("while(");
			element.Condition.TryAccept(this, state);
			state.Writer.Write(")");

			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedDoWhile element, VisitorState state) {
			state.Writer.Write("do");
			element.Body.TryAccept(this, state);
			state.Writer.Write("while(");
			element.Condition.TryAccept(this, state);
			//TODO セミコロンが付かないことも許容されるがどうするか
			state.Writer.Write(");");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIndexer element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeArgument element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeArgumentCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSwitch element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCaseCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCase element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSpecialExpression element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSpecialBlock element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCatch element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCatchCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTry element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedCast element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeParameterCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeConstrain element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeConstrainCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeParameter element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeSupplement element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTypeSupplementCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTernaryOperator element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedTernaryExpression element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinitionBody element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedVariableDefinitionBodyCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIdentifierCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedLabel element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedExpressionList element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedBooleanLiteral element, VisitorState state) {
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedMatcher element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedMatcherCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedUsing element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedListComprehension element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedIfExpression element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedList element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedKeyValue element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedDictionaryComprehension element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedKeyValueCollection element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedDictonary element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedSlice element, VisitorState state) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(UnifiedComment element, VisitorState state) {
			throw new NotImplementedException();
		}
	}
}
