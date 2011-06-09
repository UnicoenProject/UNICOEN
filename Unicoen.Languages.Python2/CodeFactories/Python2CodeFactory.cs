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
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.Python2.CodeFactories {
	public partial class Python2CodeFactory
			: CodeFactory, IUnifiedModelVisitor<VisitorArgument, bool> {
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

		private static string GetKeyword(UnifiedClassKind kind) {
			switch (kind) {
			case UnifiedClassKind.Class:
				return "class";
			case UnifiedClassKind.Interface:
				return "class";
			case UnifiedClassKind.Namespace:
				return null;
			case UnifiedClassKind.Enum:
				return "class";
			case UnifiedClassKind.Module:
				return "class";
			case UnifiedClassKind.Annotation:
				return "class";
			case UnifiedClassKind.Struct:
				return "class";
			case UnifiedClassKind.Union:
				return "class";
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
				return "# goto in C, C#";
			case UnifiedSpecialExpressionKind.Return:
				return "return";
			case UnifiedSpecialExpressionKind.YieldReturn:
				return "# yield return in C#";
			case UnifiedSpecialExpressionKind.Throw:
				return "raise";
			case UnifiedSpecialExpressionKind.Retry:
				return "# retry in Ruby";
			case UnifiedSpecialExpressionKind.Redo:
				return "# redo in Ruby";
			case UnifiedSpecialExpressionKind.Yield:
				return "# yield in Ruby";
			case UnifiedSpecialExpressionKind.Assert:
				return "assert";
			case UnifiedSpecialExpressionKind.Delete:
				return "delete";
			case UnifiedSpecialExpressionKind.Exec:
				return "exec";
			case UnifiedSpecialExpressionKind.Global:
				return "global";
			case UnifiedSpecialExpressionKind.Pass:
				return "pass";
			case UnifiedSpecialExpressionKind.Print:
				return "print";
			case UnifiedSpecialExpressionKind.PrintChevron:
				return "print >>";
			case UnifiedSpecialExpressionKind.StringConversion:
				return null;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		#region program, namespace, class, method, filed ...

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedProgram element, VisitorArgument arg) {
			element.Comments.TryAccept(this, arg);
			arg.WriteLine();
			foreach (var stmt in element) {
				stmt.TryAccept(this, arg);
				arg.WriteLine();
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedClassDefinition element, VisitorArgument arg) {
			var keyword = GetKeyword(element.Kind);
			if (element.Kind == UnifiedClassKind.Namespace) {
				// パッケージはディレクトリ構造で表現
				arg.Write("# ");
				element.Modifiers.TryAccept(this, arg);
				arg.Write(keyword);
				arg.WriteSpace();
				element.Name.TryAccept(this, arg);
				return false;
			}
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write(keyword);
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedModifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		#endregion

		#region statement

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBlock element, VisitorArgument arg) {
			foreach (var stmt in element) {
				arg.WriteIndent();
				stmt.TryAccept(this, arg);
				arg.WriteLine();
			}
			return false;
		}

		// e.g. static{...}
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSpecialBlock element, VisitorArgument arg) {
			switch (element.Kind) {
			case UnifiedSpecialBlockKind.Synchronized:
				arg.Write("synchronized");
				break;
			case UnifiedSpecialBlockKind.Fix:
				arg.Write("fix");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			if (element.Value != null) {
				arg.Write("(");
				element.Value.TryAccept(this, arg);
				arg.Write(")");
			}
			arg = arg.IncrementDepth();
			foreach (var stmt in element.Body) {
				arg.WriteIndent();
				if (stmt.TryAccept(this, arg))
					arg.Write(";");
			}
			arg.WriteIndent();
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCatch element, VisitorArgument arg) {
			arg.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg);
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeConstrain element, VisitorArgument arg) {
			throw new InvalidOperationException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeParameter element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedTypeSupplement element, VisitorArgument arg) {
			switch (element.Kind) {
			case UnifiedTypeSupplementKind.Array:
				element.Arguments.TryAccept(this, arg.Set(SquareBracket));
				break;
			default:
				break;
			}
			return false;
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedStringLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCharLiteral element, VisitorArgument arg) {
			arg.Write(element.Value);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNullLiteral element, VisitorArgument arg) {
			arg.Write("null");
			return false;
		}

		#endregion

		#region expression

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedBinaryOperator element, VisitorArgument arg) {
			arg.Write(element.Sign);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArgument element, VisitorArgument arg) {
			arg.Write("/*");
			element.Modifiers.TryAccept(this, arg);
			arg.Write("*/");
			element.Value.TryAccept(this, arg);
			return false;
		}

		#endregion

		#region value

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIdentifier identifier, VisitorArgument arg) {
			arg.Write(identifier.Value);
			return false;
		}

		#endregion

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
			case (UnifiedUnaryOperatorKind.Unknown):
				arg.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		// classname(identifier of constructor)...??
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedConstructorDefinition element, VisitorArgument arg) {
			switch (element.Kind) {
			case UnifiedConstructorDefinitionKind.Constructor:
				element.Modifiers.TryAccept(this, arg);
				element.TypeParameters.TryAccept(this, arg);
				var p = element.Ancestors()
						.First(e => e is UnifiedClassDefinition);
				((UnifiedClassDefinition)p).Name.Accept(this, arg);
				element.Parameters.TryAccept(this, arg);
				element.Body.TryAccept(this, arg);
				break;
			case UnifiedConstructorDefinitionKind.StaticInitializer:
				arg.Write("static ");
				element.Body.TryAccept(this, arg);
				break;
			case UnifiedConstructorDefinitionKind.InstanceInitializer:
				element.Body.TryAccept(this, arg);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDoWhile element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg);
			arg.Write("while ");
			element.Condition.TryAccept(this, arg);
			arg.WriteLine(":");

			element.Body.TryAccept(this, arg.IncrementDepth());
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
			element.Modifiers.TryAccept(this, arg);
			element.Value.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedCase element, VisitorArgument arg) {
			throw new InvalidOperationException("このメソッドは呼び出せません。");
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
			arg.Write("/* using ");
			element.Matchers.TryAccept(this, arg);
			arg.WriteLine(" { */");
			element.Matchers.TryAccept(this, arg);
			arg.WriteLine("//extracted from above");
			arg.WriteLine("/* } */");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedList element, VisitorArgument arg) {
			element.Elements.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedKeyValue element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictonary element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedListComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSlice element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedComment element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSupplementType element, VisitorArgument arg) {
			switch (element.Kind) {
			case UnifiedSupplementTypeKind.Const:
				arg.Write("final ");
				element.Type.TryAccept(this, arg);
				break;
			case UnifiedSupplementTypeKind.Pointer:
				element.Type.TryAccept(this, arg);
				arg.Write("/* * */");
				break;
			case UnifiedSupplementTypeKind.Reference:
				element.Type.TryAccept(this, arg);
				arg.Write("/* & */");
				break;
			case UnifiedSupplementTypeKind.Volatile:
				arg.Write("volatile ");
				element.Type.TryAccept(this, arg);
				break;
			case UnifiedSupplementTypeKind.Struct:
				element.Type.TryAccept(this, arg);
				break;
			case UnifiedSupplementTypeKind.Union:
				element.Type.TryAccept(this, arg);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedGenericType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			//arg.Write("<");
			element.Arguments.TryAccept(this, arg);
			//arg.Write(">");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArrayType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.Write("[");
			element.Arguments.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("]");
			return false;
		}
			}
}