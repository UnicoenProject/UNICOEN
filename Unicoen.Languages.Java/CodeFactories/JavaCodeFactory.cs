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
using System.Linq;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;

namespace Unicoen.Languages.Java.CodeFactories {
	public partial class JavaCodeFactory
			: CodeFactory, IUnifiedModelVisitor<VisitorState, bool> {
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

		private static readonly Decoration Empty = new Decoration();

		private static readonly Decoration AndDelimiter =
				new Decoration { Delimiter = " & " };

		private static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		private static readonly Decoration SpaceDelimiter =
				new Decoration { EachRight = " " };

		private static readonly Decoration NewLineDelimiter =
				new Decoration { Delimiter = "\n" };

		public static JavaCodeFactory Instance = new JavaCodeFactory();

		public override string Generate(
				IUnifiedElement model, TextWriter writer, string indentSign) {
			var buff = new StringWriter();
			model.Accept(this, new VisitorState(writer, indentSign));
			return buff.ToString();
		}

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			return Generate(model, writer, "\t");
		}

		private static string GetKeyword(UnifiedClassKind kind) {
			switch (kind) {
			case UnifiedClassKind.Class:
				return "class";
			case UnifiedClassKind.Interface:
				return "interface";
			case UnifiedClassKind.Namespace:
				return "package";
			case UnifiedClassKind.Enum:
				return "enum";
			case UnifiedClassKind.Module:
				return "module";
			default:
				throw new ArgumentOutOfRangeException("kind");
			}
			return null;
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

		#region program, namespace, class, method, filed ...

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedProgram element, VisitorState state) {
			foreach (var stmt in element) {
				if (stmt.TryAccept(this, state))
					state.Writer.Write(";");
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedClassDefinition element, VisitorState state) {
			var keyword = GetKeyword(element.Kind);
			if (element.Kind == UnifiedClassKind.Namespace) {
				state.Writer.Write(keyword);
				state.WriteSpace();
				element.Name.TryAccept(this, state);
				return true;
			}
			state.WriteIndent();
			element.Modifiers.TryAccept(this, state);
			state.Writer.Write(keyword);
			state.WriteSpace();
			element.Name.TryAccept(this, state);
			element.TypeParameters.TryAccept(this, state);
			element.Constrains.TryAccept(this, state);
			element.Body.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFunctionDefinition element, VisitorState state) {
			state.WriteIndent();
			element.Modifiers.TryAccept(this, state);
			element.TypeParameters.TryAccept(this, state);
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			element.Name.TryAccept(this, state);
			element.Parameters.TryAccept(this, state);
			element.Throws.TryAccept(this, state.Set(Throws));
			element.Body.TryAccept(this, state);
			return element.Body == null;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedParameter element, VisitorState state) {
			var removed = element.Modifiers.Remove(m => m.Name == "...");
			element.Modifiers.TryAccept(this, state);
			element.Type.TryAccept(this, state);
			state.WriteSpace();
			if (removed)
				state.Writer.Write("... ");
			element.Name.TryAccept(this, state);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedModifier element, VisitorState state) {
			state.Writer.Write(element.Name);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedType element, VisitorState state) {
			element.Name.TryAccept(this, state);
			element.Arguments.TryAccept(this, state);
			element.Supplements.TryAccept(this, state);
			return false;
		}

		#endregion

		#region statement

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

		// e.g. static{...}
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedSpecialBlock element, VisitorState state) {
			state.WriteIndent();
			switch (element.Kind) {
			case UnifiedSpecialBlockKind.Synchronized:
				state.Writer.Write("synchronized");
				break;
			case UnifiedSpecialBlockKind.Fix:
				state.Writer.Write("fix");
				break;
			case UnifiedSpecialBlockKind.Using:
				state.Writer.Write("using");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (element.Value != null) {
				state.Writer.Write("(");
				element.Value.TryAccept(this, state);
				state.Writer.Write(")");
			}
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
				UnifiedIf ifStatement, VisitorState state) {
			state.Writer.Write("if (");
			ifStatement.Condition.TryAccept(this, state);
			state.Writer.WriteLine(")");
			ifStatement.Body.TryAccept(this, state);
			if (ifStatement.FalseBody != null) {
				state.WriteIndent();
				state.Writer.WriteLine("else");
				ifStatement.FalseBody.TryAccept(this, state);
			}
			return false;
		}

		// e.g. catch(Exception e){...}
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedCatch element, VisitorState state) {
			state.Writer.Write("catch");
			element.Parameters.TryAccept(this, state);
			element.Body.TryAccept(this, state);
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
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
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeParameter element, VisitorState state) {
			element.Type.TryAccept(this, state);
			element.Constrains.TryAccept(this, state.Set(AndDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTypeSupplement element, VisitorState state) {
			switch (element.Kind) {
			case UnifiedTypeSupplementKind.Array:
				element.Arguments.TryAccept(this, state.Set(SquareBracket));
				break;
			default:
				break;
			}
			return false;
		}

		// a ? b : c
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedTernaryOperator element, VisitorState state) {
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
			if (element.Value.ToString() == "True")
				state.Writer.Write("true");
			if (element.Value.ToString() == "False")
				state.Writer.Write("false");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedFractionLiteral element, VisitorState state) {
			state.Writer.Write(element.Value);
			switch (element.Kind) {
			case UnifiedFractionLiteralKind.Single:
				state.Writer.Write("f");
				break;
			case UnifiedFractionLiteralKind.Double:
				state.Writer.Write("d");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIntegerLiteral element, VisitorState state) {
			state.Writer.Write(element.Value);
			switch (element.Kind) {
			case UnifiedIntegerLiteralKind.Int32:
				break;
			case UnifiedIntegerLiteralKind.Int64:
				state.Writer.Write("l");
				break;
			case UnifiedIntegerLiteralKind.BigInteger:
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedStringLiteral element, VisitorState state) {
			var delimiter = '"';
			switch (element.Kind) {
			case UnifiedStringLiteralKind.Char:
				delimiter = '\'';
				break;
			case UnifiedStringLiteralKind.String:
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			state.Writer.Write(delimiter + element.Value + delimiter);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedNullLiteral element, VisitorState state) {
			state.Writer.Write("null");
			return false;
		}

		#endregion

		#region expression

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedBinaryOperator op, VisitorState state) {
			state.Writer.Write(op.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedArgument arg, VisitorState state) {
			arg.Value.TryAccept(this, state);
			return false;
		}

		#endregion

		#region value

		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedIdentifier identifier, VisitorState state) {
			state.Writer.Write(identifier.Value);
			return false;
		}

		#endregion

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
			case (UnifiedUnaryOperatorKind.Unknown):
				state.Writer.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		// classname(identifier of constructor)...??
		bool IUnifiedModelVisitor<VisitorState, bool>.Visit(
				UnifiedConstructorDefinition element, VisitorState state) {
			switch (element.Kind) {
			case UnifiedConstructorDefinitionKind.Constructor:
				element.Modifiers.TryAccept(this, state);
				element.TypeParameters.TryAccept(this, state);
				var p = element.Ancestors()
						.First(e => e is UnifiedClassDefinition);
				((UnifiedClassDefinition)p).Name.Accept(this, state);
				element.Parameters.TryAccept(this, state);
				element.Body.TryAccept(this, state);
				break;
			case UnifiedConstructorDefinitionKind.StaticInitializer:
				state.Writer.Write("static ");
				element.Body.TryAccept(this, state);
				break;
			case UnifiedConstructorDefinitionKind.InstanceInitializer:
				element.Body.TryAccept(this, state);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
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
			state.Writer.Write(":");
			state.WriteSpace();
			element.Set.TryAccept(this, state);
			state.Writer.Write(")");

			element.Body.TryAccept(this, state);
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
			element.Modifiers.TryAccept(this, state);
			element.Value.TryAccept(this, state);
			element.Constrains.TryAccept(this, state.Set(AndDelimiter));
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
			}
}