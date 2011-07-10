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
using System.Linq;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.Java.CodeFactories {
	public partial class JavaCodeFactoryVisitor
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

		private static readonly Decoration ColonMostLeft =
				new Decoration { MostLeft = ":" };

		private static readonly Decoration NullDelimiter =
				new Decoration { Delimiter = null };

		private static readonly Decoration AndDelimiter =
				new Decoration { Delimiter = " & " };

		private static readonly Decoration CommaDelimiter =
				new Decoration { Delimiter = ", " };

		private static readonly Decoration SpaceEachRight =
				new Decoration { EachRight = " " };

		private static readonly Decoration NewLineDelimiter =
				new Decoration { Delimiter = "\n" };

		private static readonly Decoration SemiColonDelimiter =
				new Decoration { Delimiter = ";" };

		private static readonly Decoration ForBlock =
				new Decoration { MostLeft = "{", EachRight = ";", MostRight = "}" };

		private static readonly Decoration ForTopBlock =
				new Decoration { EachRight = ";" };

		#region program, namespace, class, method, filed ...

		public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg.Set(ForTopBlock));
			return false;
		}

		public override bool Visit(UnifiedNamespace element, VisitorArgument arg) {
			arg.Write("package ");
			element.Name.TryAccept(this, arg);
			arg.Write(";");
			element.Body.TryAccept(this, arg.Set(SemiColonDelimiter));
			return false;
		}

		private bool Visit(
				UnifiedPackageBase element, VisitorArgument arg, string keyword) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			arg.Write(keyword + " ");
			element.Name.TryAccept(this, arg);
			element.GenericParameters.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedClass element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		public override bool Visit(UnifiedInterface element, VisitorArgument arg) {
			return Visit(element, arg, "interface");
		}

		public override bool Visit(UnifiedStruct element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		public override bool Visit(UnifiedEnum element, VisitorArgument arg) {
			return Visit(element, arg, "enum");
		}

		public override bool Visit(UnifiedModule element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		public override bool Visit(UnifiedUnion element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		public override bool Visit(
				UnifiedAnnotationDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "@interface");
		}

		public override bool Visit(
				UnifiedFunctionDefinition element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			element.GenericParameters.TryAccept(this, arg);
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Throws.TryAccept(this, arg.Set(Throws));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		public override bool Visit(UnifiedParameter element, VisitorArgument arg) {
			var isVariableLength = false;
			if (element.Modifiers != null) {
				var newModifiers = element.Modifiers.DeepCopy();
				isVariableLength = newModifiers.Remove(m => m.Name == "...");
				newModifiers.TryAccept(this, arg);
			}
			element.Type.TryAccept(this, arg);
			arg.WriteSpace();
			if (isVariableLength) {
				arg.Write("... ");
			}
			element.Names.TryAccept(this, arg.Set(CommaDelimiter));
			return false;
		}

		public override bool Visit(UnifiedModifier element, VisitorArgument arg) {
			arg.Write(element.Name);
			return false;
		}

		#endregion

		#region statement

		public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
			if (!string.IsNullOrEmpty(arg.Decoration.MostLeft)) {
				arg.WriteLine(arg.Decoration.MostLeft);
				arg = arg.IncrementDepth();
			}
			foreach (var stmt in element) {
				arg.WriteIndent();
				if (stmt.TryAccept(this, arg))
					arg.Write(arg.Decoration.EachRight);
				arg.WriteLine();
			}
			if (!string.IsNullOrEmpty(arg.Decoration.MostRight)) {
				arg = arg.DecrementDepth();
				arg.WriteIndent();
				arg.WriteLine(arg.Decoration.MostRight);
			}
			return false;
		}

		public override bool Visit(UnifiedSynchronized element, VisitorArgument arg) {
			arg.WriteIndent();
			arg.Write("synchronized (");
			element.Value.TryAccept(this, arg);
			arg.Write(")");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedIf ifStatement, VisitorArgument arg) {
			arg.Write("if (");
			ifStatement.Condition.TryAccept(this, arg);
			arg.Write(")");
			ifStatement.Body.TryAccept(this, arg.Set(ForBlock));
			if (ifStatement.ElseBody != null) {
				arg.WriteIndent();
				arg.WriteLine("else");
				ifStatement.ElseBody.TryAccept(this, arg.Set(ForBlock));
			}
			return false;
		}

		// e.g. catch(Exception e){...}
		public override bool Visit(UnifiedCatch element, VisitorArgument arg) {
			arg.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
		public override bool Visit(UnifiedTry element, VisitorArgument arg) {
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
			// Javaはメソッド呼び出しにModifiersがない
			//element.Modifiers.TryAccept(this, arg);
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
			arg.Write("super");
			return false;
		}

		public override bool Visit(UnifiedThisIdentifier element, VisitorArgument arg) {
			arg.Write("this");
			return false;
		}

		public override bool Visit(UnifiedTypeof element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.Write(".class");
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

		public override bool Visit(UnifiedConstructor element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			element.GenericParameters.TryAccept(this, arg);
			var p = element.Ancestors<UnifiedPackageBase>().First();
			p.Name.Accept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedInstanceInitializer element, VisitorArgument arg) {
			arg.Write("static ");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedStaticInitializer element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedFor element, VisitorArgument arg) {
			var defList = element.Initializer as UnifiedVariableDefinitionList;
			var endBracket = "";
			if (defList.IsNotEmpty()) {
				arg.WriteLine("{");
				element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
				arg.WriteLine(";");
				endBracket = "}";
			}
			arg.Write("for(");
			arg.Write("; ");
			element.Condition.TryAccept(this, arg);
			arg.Write(";");
			element.Step.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			arg.Write(endBracket);
			return false;
		}

		public override bool Visit(UnifiedForeach element, VisitorArgument arg) {
			arg.Write("for(");
			element.Element.TryAccept(this, arg);
			arg.WriteSpace();
			arg.Write(":");
			arg.WriteSpace();
			element.Set.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
			arg.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
			arg.Write("do");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			arg.Write("while(");
			element.Condition.TryAccept(this, arg);
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
			element.Modifiers.TryAccept(this, arg);
			element.Value.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		public override bool Visit(UnifiedSwitch element, VisitorArgument arg) {
			arg.Write("switch(");
			element.Value.TryAccept(this, arg);
			arg.Write(") {");

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
			arg.Write("/*");
			arg.Write(element.Content);
			arg.Write("*/");
			return false;
		}

		public override bool Visit(
				UnifiedVariableDefinition element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
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
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedConstType element, VisitorArgument arg) {
			arg.Write("final ");
			element.Type.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedPointerType element, VisitorArgument arg) {
			arg.Write("/* * */");
			element.Type.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedReferenceType element, VisitorArgument arg) {
			arg.Write("/* & */");
			element.Type.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedVolatileType element, VisitorArgument arg) {
			arg.Write("volatile ");
			element.Type.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedStructType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedUnionType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedGenericType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			//arg.Write("<");
			element.Arguments.TryAccept(this, arg);
			//arg.Write(">");
			return true;
		}

		public override bool Visit(UnifiedArrayType element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			arg.Write("[");
			element.Arguments.TryAccept(this, arg.Set(CommaDelimiter));
			arg.Write("]");
			return true;
		}
			}
}