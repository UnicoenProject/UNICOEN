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
	public partial class JavaScriptCodeFactory
			: CodeFactory, IUnifiedModelVisitor<VisitorArgument, bool> {
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
				arg.Write("delete");
				break;
			case (UnifiedUnaryOperatorKind.Void):
				arg.Write("void");
				break;
			case (UnifiedUnaryOperatorKind.Typeof):
				arg.Write("typeof");
				break;
			case (UnifiedUnaryOperatorKind.Unknown):
				arg.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArgument element, VisitorArgument arg) {
			element.Value.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBlock element, VisitorArgument arg) {
			var decoration = arg.Decoration;
			//for Block
			if (decoration.MostLeft == "{") {
				arg.WriteLine(decoration.MostLeft);
				arg = arg.IncrementIndentDepth();

				foreach (var stmt in element) {
					arg.WriteIndent();
					if (stmt.TryAccept(this, arg))
						arg.Write(";");
					arg.Write(decoration.Delimiter);
				}
				//TODO �����ŃC���f���g��P�߂�����
				arg.WriteIndent();
				arg.Write(decoration.MostRight);
				return false;
			}

			//for expressionList
			var comma = "";
			foreach (var e in element) {
				arg.Write(comma);
				e.TryAccept(this, arg);
				comma = decoration.Delimiter;
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.Write("function");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIf ifStatement, VisitorArgument arg) {
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedParameter element, VisitorArgument arg) {
			element.Names.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIdentifier identifier, VisitorArgument arg) {
			arg.Write(identifier.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedModifier element, VisitorArgument arg) {
			//JavaScript�ł͏C���q�͏o�����Ȃ�
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedImport element, VisitorArgument arg) {
			//JavaScript�ł͊O���t�@�C���ǂݍ��ݕ��͏o�����Ȃ�
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedConstructorDefinition element, VisitorArgument arg) {
			//JavaScript�ł̓R���X�g���N�^�錾�͏o�����Ȃ�
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedProgram element, VisitorArgument arg) {
			foreach (var sourceElement in element) {
				//TODO sourceElement�͊�{�I�ɉ��s���Ă悢�Ǝv���邪�ǂ���
				if (sourceElement.TryAccept(this, arg))
					arg.WriteLine(";");
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedClassDefinition element, VisitorArgument arg) {
			//JavaScript�̏ꍇ�̓I�u�W�F�N�g�錾��\���܂�
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedFor element, VisitorArgument arg) {
			arg.Write("for(");
			element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("; ");
			element.Condition.TryAccept(this, arg);
			arg.Write(";");
			element.Step.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedForeach element, VisitorArgument arg) {
			arg.Write("for(");
			element.Element.TryAccept(this, arg);
			arg.WriteSpace();
			arg.Write("in");
			arg.WriteSpace();
			element.Set.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedProperty element, VisitorArgument arg) {
			element.Owner.TryAccept(this, arg);
			arg.Write(element.Delimiter);
			element.Name.TryAccept(this, arg);
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDoWhile element, VisitorArgument arg) {
			arg.Write("do");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
			//TODO �Z�~�R�������t���Ȃ����Ƃ���e����邪�ǂ����邩
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
			//JavaScript�ł͌^�����͏o�����Ȃ�
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeArgumentCollection element, VisitorArgument arg) {
			//JavaScript�ł͌^�����͏o�����Ȃ�
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSwitch element, VisitorArgument arg) {
			arg.Write("switch(");
			element.Value.TryAccept(this, arg);
			arg.WriteLine(") {");

			element.Cases.TryAccept(this, arg);
			arg.Write("}");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCase element, VisitorArgument arg) {
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSpecialExpression element, VisitorArgument arg) {
			arg.Write(GetKeyword(element.Kind));
			if (element.Value != null) {
				arg.WriteSpace();
				//return a,b;�̂悤�ȍۂ�value��UnifiedBlock�ł��邪�A
				//"{}"��t������ƃG���[�ɂȂ�̂ł��̂��߂̑΍�
				element.Value.TryAccept(this, arg.Set(CommaDelimiter));
			}
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSpecialBlock element, VisitorArgument arg) {
			arg.WriteIndent();
			switch (element.Kind) {
			case UnifiedSpecialBlockKind.With:
				arg.Write("with");
				break;
			default:
				//JavaScript�ł�with���̂ݎg�p�\
				//TODO ���̌��ꃂ�f���̕ϊ��̍ۂɁAsynchronized�Ȃǂ�������ǂ��Ώ�����̂�
				throw new ArgumentOutOfRangeException();
			}
			if (element.Value != null) {
				arg.Write("(");
				element.Value.TryAccept(this, arg);
				arg.Write(")");
			}

			//TODO �Ȃ�element.Body.TryAccept���Ȃ��̂�(Java����̗��p)
			arg.WriteLine("{");
			arg = arg.IncrementIndentDepth();
			foreach (var stmt in element.Body) {
				arg.WriteIndent();
				if (stmt.TryAccept(this, arg))
					arg.WriteLine(";");
			}
			arg.WriteIndent();
			arg.Write("}");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCatch element, VisitorArgument arg) {
			arg.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			//JavaScript�ł�catch�߂̗񋓂͏o�����Ȃ�
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTry element, VisitorArgument arg) {
			// try block
			arg.Write("try");
			element.Body.TryAccept(this, arg.Set(ForBlock));

			// catch blocks
			element.Catches.TryAccept(this, arg);

			// finally block
			var finallyBlock = element.FinallyBody;
			// how judge whether finalluBlock exists or not???
			if (finallyBlock != null) {
				arg.Write("finally");
				finallyBlock.TryAccept(this, arg.Set(ForBlock));
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeConstrain element, VisitorArgument arg) {
			//JavaScript�ł͌p����������ʎq�͏o�����Ȃ�(?)
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeConstrainCollection element, VisitorArgument arg) {
			//JavaScript�ł͌p����������ʎq�͏o�����Ȃ�(?)
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeParameter element, VisitorArgument arg) {
			//JavaScript�ł͌^�p�����[�^�͏o�����Ȃ�
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeSupplement element, VisitorArgument arg) {
			//JavaScript�ł͌^�錾����'[]'�͏o�����Ȃ�
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedLabel element, VisitorArgument arg) {
			element.Name.TryAccept(this, arg);
			arg.Write(":");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBooleanLiteral element, VisitorArgument arg) {
			if (element.Value)
				arg.Write("true");
			else
				arg.Write("false");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedFractionLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIntegerLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedStringLiteral element, VisitorArgument arg) {
			arg.Write('"' + element.Value + '"');
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("null");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedMatcher element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			arg.Write(" ");
			element.Matcher.TryAccept(this, arg);
			arg.Write(" ");
			element.As.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedUsing element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedList element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedKeyValue element, VisitorArgument arg) {
			arg.WriteIndent();
			element.Key.TryAccept(this, arg);
			arg.Write(":");
			element.Value.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictonary element, VisitorArgument arg) {
			arg.Write("{");
			element.KeyValues.TryAccept(this, arg.Set(CommaDelimiter));
			arg.WriteIndent();
			arg.Write("}");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSlice element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedComment element, VisitorArgument arg) {
			throw new NotImplementedException();
		}
			}
}