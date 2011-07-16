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
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.CodeFactories {
	public partial class JavaLikeCodeFactoryVisitor {
		#region program, namespace, class, method, filed ...

		public override bool Visit(UnifiedProgram element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg.Set(ForTopBlock));
			return false;
		}

		public override bool Visit(
				UnifiedNamespaceDefinition element, VisitorArgument arg) {
			Writer.Write("package ");
			element.Name.TryAccept(this, arg);
			Writer.WriteLine(";");
			element.Body.TryAccept(this, arg);
			return false;
		}

		private bool Visit(
				UnifiedBlockDefinition element, VisitorArgument arg, string keyword) {
			element.Annotations.TryAccept(this, arg);
			element.Modifiers.TryAccept(this, arg);
			Writer.Write(keyword + " ");
			element.Name.TryAccept(this, arg);
			element.GenericParameters.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(CommaDelimiter));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedClassDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		public override bool Visit(
				UnifiedInterfaceDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "interface");
		}

		public override bool Visit(
				UnifiedStructDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		public override bool Visit(UnifiedEnumDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "enum");
		}

		public override bool Visit(
				UnifiedModuleDefinition element, VisitorArgument arg) {
			return Visit(element, arg, "class");
		}

		public override bool Visit(
				UnifiedUnionDefinition element, VisitorArgument arg) {
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
			Writer.Write(" ");
			element.Name.TryAccept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Throws.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return element.Body == null;
		}

		public override bool Visit(UnifiedParameter element, VisitorArgument arg) {
			element.Annotations.TryAccept(this, arg);
			var isVariableLength = false;
			if (!element.Modifiers.IsEmptyOrNull()) {
				var newModifiers = element.Modifiers.DeepCopy();
				isVariableLength = newModifiers.Remove(m => m.Name == "...");
				newModifiers.TryAccept(this, arg);
			}
			element.Type.TryAccept(this, arg);
			Writer.Write(" ");
			if (isVariableLength) {
				Writer.Write("... ");
			}
			element.Names.TryAccept(this, arg.Set(CommaDelimiter));
			return false;
		}

		public override bool Visit(UnifiedModifier element, VisitorArgument arg) {
			Writer.Write(element.Name);
			return false;
		}

		#endregion

		#region statement

		public override bool Visit(UnifiedBlock element, VisitorArgument arg) {
			if (!string.IsNullOrEmpty(arg.Decoration.MostLeft)) {
				Writer.WriteLine(arg.Decoration.MostLeft);
				arg = arg.IncrementDepth();
			}
			foreach (var stmt in element) {
				WriteIndent(arg);
				if (stmt.TryAccept(this, arg))
					Writer.Write(";");
				Writer.Write(arg.Decoration.EachRight);
			}
			if (!string.IsNullOrEmpty(arg.Decoration.MostRight)) {
				arg = arg.DecrementDepth();
				WriteIndent(arg);
				Writer.WriteLine(arg.Decoration.MostRight);
			}
			return false;
		}

		public override bool Visit(UnifiedSynchronized element, VisitorArgument arg) {
			WriteIndent(arg);
			Writer.Write("synchronized (");
			element.Value.TryAccept(this, arg);
			Writer.Write(")");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedIf ifStatement, VisitorArgument arg) {
			Writer.Write("if (");
			ifStatement.Condition.TryAccept(this, arg);
			Writer.Write(")");
			ifStatement.Body.TryAccept(this, arg.Set(ForBlock));
			ifStatement.ElseBody.TryAccept(
					this, arg.Set(ForBlock), GetIndent(arg) + "else");
			return false;
		}

		// e.g. catch(Exception e){...}
		public override bool Visit(UnifiedCatch element, VisitorArgument arg) {
			Writer.Write("catch");
			element.Matchers.TryAccept(this, arg.Set(Paren));
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		// e.g. try{...}catch(E e){...}finally{...}
		public override bool Visit(UnifiedTry element, VisitorArgument arg) {
			Writer.Write("try");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			element.Catches.TryAccept(this, arg);
			element.FinallyBody.TryAccept(this, arg, "finally");
			return false;
		}

		public override bool Visit(
				UnifiedGenericParameter element, VisitorArgument arg) {
			element.Type.TryAccept(this, arg);
			element.Constrains.TryAccept(this, arg.Set(AndDelimiter));
			return false;
		}

		public override bool Visit(UnifiedLabel element, VisitorArgument arg) {
			element.Name.TryAccept(this, arg);
			Writer.Write(":");
			return false;
		}

		public override bool Visit(UnifiedBooleanLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value ? "true" : "false");
			return false;
		}

		public override bool Visit(
				UnifiedFractionLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value.ToString("r"));
			switch (element.Kind) {
			case UnifiedFractionLiteralKind.Single:
				Writer.Write("f");
				break;
			case UnifiedFractionLiteralKind.Double:
				Writer.Write("d");
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return false;
		}

		public override bool Visit(UnifiedBigIntLiteral element, VisitorArgument arg) {
			Writer.Write(element.Value);
			Writer.Write("l");
			return false;
		}

		public override bool Visit(UnifiedInt8Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedInt16Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedInt31Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedInt32Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedInt64Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			Writer.Write("l");
			return false;
		}

		public override bool Visit(UnifiedUInt8Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedUInt16Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedUInt31Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedUInt32Literal element, VisitorArgument arg) {
			Writer.Write(element.Value);
			return false;
		}

		public override bool Visit(UnifiedUInt64Literal element, VisitorArgument arg) {
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

		public override bool Visit(UnifiedNullLiteral element, VisitorArgument arg) {
			Writer.Write("null");
			return false;
		}

		#endregion

		#region expression

		public override bool Visit(UnifiedBinaryOperator element, VisitorArgument arg) {
			Writer.Write(element.Sign);
			return false;
		}

		public override bool Visit(UnifiedArgument element, VisitorArgument arg) {
			// Javaはメソッド呼び出しにModifiersがないが
			element.Modifiers.TryAccept(this, arg);
			element.Target.TryAccept(this, arg, "", " = ");
			element.Value.TryAccept(this, arg);
			return false;
		}

		#endregion

		#region value

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
			Writer.Write("super");
			return false;
		}

		public override bool Visit(UnifiedThisIdentifier element, VisitorArgument arg) {
			Writer.Write("this");
			return false;
		}

		public override bool Visit(UnifiedTypeof element, VisitorArgument arg) {
			element.Value.TryAccept(this, arg);
			Writer.Write(".class");
			return false;
		}

		#endregion

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
			case (UnifiedUnaryOperatorKind.Unknown):
				Writer.Write(element.Sign);
				break;
			default:
				throw new InvalidOperationException();
			}
			return false;
		}

		public override bool Visit(UnifiedConstructor element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			element.GenericParameters.TryAccept(this, arg);
			var p = element.Ancestors<UnifiedBlockDefinition>().First();
			p.Name.Accept(this, arg);
			element.Parameters.TryAccept(this, arg);
			element.Throws.TryAccept(this, arg);
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedInstanceInitializer element, VisitorArgument arg) {
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(
				UnifiedStaticInitializer element, VisitorArgument arg) {
			Writer.Write("static ");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedFor element, VisitorArgument arg) {
			Writer.Write("for(");
			element.Initializer.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write("; ");
			element.Condition.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(";");
			element.Step.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedForeach element, VisitorArgument arg) {
			Writer.Write(ForeachKeyword);
			Writer.Write("(");
			element.Element.TryAccept(this, arg);
			Writer.Write(ForeachDelimiter);
			element.Set.TryAccept(this, arg.Set(CommaDelimiter));
			Writer.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedWhile element, VisitorArgument arg) {
			Writer.Write("while(");
			element.Condition.TryAccept(this, arg);
			Writer.Write(")");

			element.Body.TryAccept(this, arg.Set(ForBlock));
			return false;
		}

		public override bool Visit(UnifiedDoWhile element, VisitorArgument arg) {
			Writer.Write("do");
			element.Body.TryAccept(this, arg.Set(ForBlock));
			WriteIndent(arg);
			Writer.Write("while(");
			element.Condition.TryAccept(this, arg);
			Writer.Write(");");
			return false;
		}

		public override bool Visit(UnifiedIndexer element, VisitorArgument arg) {
			element.Target.TryAccept(this, arg);
			element.Arguments.TryAccept(this, arg.Set(Bracket));
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
			Writer.Write("switch(");
			element.Value.TryAccept(this, arg);
			Writer.Write(") {");

			element.Cases.TryAccept(this, arg);
			WriteIndent(arg);
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

		public override bool Visit(UnifiedMatcher element, VisitorArgument arg) {
			element.Modifiers.TryAccept(this, arg);
			Writer.Write(" ");
			element.Matcher.TryAccept(this, arg);
			Writer.Write(" ");
			element.Assign.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedUsing element, VisitorArgument arg) {
			Writer.Write("/* using ");
			element.Parts.TryAccept(this, arg);
			Writer.WriteLine(" { */");
			element.Parts.TryAccept(this, arg);
			Writer.WriteLine("/* } */");
			return false;
		}

		public override bool Visit(UnifiedComment element, VisitorArgument arg) {
			Writer.Write("/*");
			Writer.Write(element.Content);
			Writer.Write("*/");
			return false;
		}

		public override bool Visit(
				UnifiedVariableDefinition element, VisitorArgument arg) {
			// UnifiedVariableDefinitionListで処理するので呼ばれてはいけない
			throw new InvalidOperationException();
		}
	}
}