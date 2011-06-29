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
			: CodeFactory, IUnifiedVisitor<bool, VisitorArgument> {
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedArgument element, VisitorArgument arg) {
			element.Value.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedBlock element, VisitorArgument arg) {
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

			//for expressionList
			var comma = "";
			foreach (var e in element) {
				arg.Write(comma);
				e.TryAccept(this, arg);
				comma = decoration.Delimiter;
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedFunction element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.Write("function");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedLambda element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.Write("function");
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedParameter element, VisitorArgument arg) {
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
			arg.Write("");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedThisIdentifier element, VisitorArgument arg) {
			arg.Write("this");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedModifier element, VisitorArgument arg) {
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedImport element, VisitorArgument arg) {
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedConstructor element, VisitorArgument arg) {
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedInstanceInitializer element, VisitorArgument arg) {
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedStaticInitializer element, VisitorArgument arg) {
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedProgram element, VisitorArgument arg) {
			foreach (var sourceElement in element) {
				if (sourceElement.TryAccept(this, arg))
					arg.Write(";");
				arg.Write("\n");
			}
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedProperty element, VisitorArgument arg) {
			element.Owner.TryAccept(this, arg);
			arg.Write(element.Delimiter);
			element.Name.TryAccept(this, arg);
			return true;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedDoWhile element, VisitorArgument arg) {
			arg.Write("do");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
			//TODO
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
				UnifiedTypeArgument element, VisitorArgument arg) {
			//JavaScript
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedGenericArgumentCollection element, VisitorArgument arg) {
			//JavaScript
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedSwitch element, VisitorArgument arg) {
			arg.Write("switch(");
			element.Value.TryAccept(this, arg);
			arg.WriteLine(") {");

			element.Cases.TryAccept(this, arg);
			arg.Write("}");
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedWith element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.Write("with (");
			element.Value.TryAccept(this, arg);
			arg.Write(")");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCatch element, VisitorArgument arg) {
			arg.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedCatchCollection element, VisitorArgument arg) {
			//JavaScript
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
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

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedTypeConstrainCollection element, VisitorArgument arg) {
			//JavaScript
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedTypeParameter element, VisitorArgument arg) {
			//JavaScript
			throw new NotImplementedException();
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
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedIntegerLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
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

		public bool Visit(UnifiedNamespace element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("null");
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
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedList element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedKeyValue element, VisitorArgument arg) {
			arg.WriteIndent();
			element.Key.TryAccept(this, arg);
			arg.Write(":");
			element.Value.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedVisitor<bool, VisitorArgument>.Visit(
				UnifiedDictionary element, VisitorArgument arg) {
			arg.Write("{");
			VisitCollection(element, arg.Set(CommaDelimiter));
			arg.WriteIndent();
			arg.Write("}");
			return false;
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
				UnifiedRegularExpressionLiteral element, VisitorArgument arg) {
			arg.Write(element.Options);
			arg.Write(element.Value);
			arg.Write(element.Options);
			return false;
		}
			}
}