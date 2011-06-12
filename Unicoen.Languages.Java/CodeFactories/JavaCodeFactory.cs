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

namespace Unicoen.Languages.Java.CodeFactories {
	public partial class JavaCodeFactory
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

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedProgram element, VisitorArgument arg) {
			foreach (var stmt in element) {
				if (stmt.TryAccept(this, arg))
					arg.Write(";");
			}
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedNamespace element, VisitorArgument arg) {
			arg.Write("package ");
			element.Name.TryAccept(this, arg);
			return true;
		}

		private bool Visit(UnifiedPackageBase element, VisitorArgument arg, string keyword) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write(keyword + " ");
			element.Name.TryAccept(this, arg);
			element.TypeParameters.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg);
			element.Body.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedClass element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedInterface element, VisitorArgument arg) {
			return Visit(element, arg, "interface");
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedStruct element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedEnum element, VisitorArgument arg) {
			return Visit(element, arg, "enum");
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedModule element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedUnion element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedAnnotationDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "@interface");
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			arg.WriteIndent();
			element.Modifiers.TryAccept(this, arg);
			element.TypeParameters.TryAccept(this, arg);
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Throws.TryAccept(this, arg.Set(Throws));
			element.Body.TryAccept(this, arg);
			return element.Body == null;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedParameter element, VisitorArgument arg) {
			var isVariableLength = element.Modifiers != null
			                       && element.Modifiers.Remove(m => m.Name == "...");
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			if (isVariableLength) {
				arg.Write("... ");
			}
			element.Names.TryAccept(this, arg.Set(CommaDelimiter));
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
			arg.WriteIndent();
			arg.WriteLine("{");
			arg = arg.IncrementDepth();
			foreach (var stmt in element) {
				arg.WriteIndent();
				if (stmt.TryAccept(this, arg))
					arg.Write(";");
			}
			arg.WriteIndent();
			arg.WriteLine("}");
			return false;
		}

		// e.g. static{...}
		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSpecialBlock element, VisitorArgument arg) {
			arg.WriteIndent();
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
			arg.Write("{");
			arg = arg.IncrementDepth();
			foreach (var stmt in element.Body) {
				arg.WriteIndent();
				if (stmt.TryAccept(this, arg))
					arg.Write(";");
			}
			arg.WriteIndent();
			arg.Write("}");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedIf ifStatement, VisitorArgument arg) {
			arg.Write("if (");
			ifStatement.Condition.TryAccept(this, arg);
			arg.WriteLine(")");
			ifStatement.Body.TryAccept(this, arg);
			if (ifStatement.ElseBody != null) {
				arg.WriteIndent();
				arg.WriteLine("else");
				ifStatement.ElseBody.TryAccept(this, arg);
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
				var p = element.Ancestors<UnifiedPackageBase>().First();
				p.Name.Accept(this, arg);
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
			arg.Write("for(");
			element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("; ");
			element.Condition.TryAccept(this, arg);
			arg.Write(";");
			element.Step.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(")");

			element.Body.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedForeach element, VisitorArgument arg) {
			arg.Write("for(");
			element.Element.TryAccept(this, arg);
			arg.WriteSpace();
			arg.Write(":");
			arg.WriteSpace();
			element.Set.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg);
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDoWhile element, VisitorArgument arg) {
			arg.Write("do");
			element.Body.TryAccept(this, arg);
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
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
			element.Modifiers.TryAccept(this, arg);
			element.Value.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedSwitch element, VisitorArgument arg) {
			arg.Write("switch(");
			element.Value.TryAccept(this, arg);
			arg.Write(") {");

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
			element.Body.TryAccept(this, arg);
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
				UnifiedKeyValue element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictionaryComprehension element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedDictionary element, VisitorArgument arg) {
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
			arg.Write("/*");
			arg.Write(element.Content);
			arg.Write("*/");
			return false;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedVariableDefinition element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write(" ");
			element.Type.TryAccept(this, arg);
			arg.Write(" ");
			element.Name.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(Paren));

			// アノテーションの場合は String value() default "test";
			var setterSign = " = ";
			var klass = element.GrandParent() as UnifiedAnnotationDefinition;
			if (klass != null) {
				setterSign = " default ";
			}

			if (element.InitialValue != null) {
				arg.Write(setterSign);
				element.InitialValue.TryAccept(this, arg.Set(Bracket));
			}
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
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedGenericType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			//arg.Write("<");
			element.Arguments.TryAccept(this, arg);
			//arg.Write(">");
			return true;
		}

		bool IUnifiedModelVisitor<VisitorArgument, bool>.Visit(
				UnifiedArrayType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.Write("[");
			element.Arguments.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("]");
			return true;
		}
			}
}