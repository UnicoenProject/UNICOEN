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

namespace Unicoen.Languages.CSharp.CodeFactories {
	internal class CSharpCodeFactoryVisitor
			: ExplicitDefaultUnifiedVisitor<int, bool> {
		private readonly TextWriter _writer;
		private readonly CSharpCodeStyle _style;

		public CSharpCodeFactoryVisitor(TextWriter writer, CSharpCodeStyle style) {
			_writer = writer;
			_style = style;
		}

		#region Util

		private void WriteSpace() {
			_writer.Write(" ");
		}

		private void WriteCollon() {
			_writer.Write(": ");
		}

		private void WriteIndent(int indent) {
			for (int i = 0; i < indent; i++) _writer.Write(_style.Indent);
		}

		#endregion

		public override bool Visit(UnifiedBinaryOperator element, int arg) {
			_writer.Write(element.Sign);
			return false;
		}

		public override bool Visit(UnifiedUnaryOperator element, int arg) {
			_writer.Write(element.Sign);
			return false;
		}

		public override bool Visit(UnifiedArgument element, int arg) {
			element.Modifiers.TryAccept(this, arg, WriteSpace);
			element.Target.TryAccept(this, arg, WriteCollon);
			element.Value.Accept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedArgumentCollection element, int arg) {
			var separator = "";
			foreach (var elem in element) {
				_writer.Write(separator);
				separator = ", ";
				elem.TryAccept(this, arg + 1);
			}
			return true;
		}

		public override bool Visit(UnifiedBinaryExpression element, int arg) {
			element.LeftHandSide.Accept(this, arg);
			WriteSpace();
			element.Operator.Accept(this, arg);
			WriteSpace();
			element.RightHandSide.Accept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedBlock element, int arg) {
			_writer.Write("{");
			_writer.WriteLine();
			foreach (var elem in element) {
				WriteIndent(arg + 1);
				var hasSemmi = elem.TryAccept(this, arg + 1) ?? false;
				if (hasSemmi) {
					_writer.Write(";");
				}
				_writer.WriteLine();
			}
			WriteIndent(arg);
			_writer.Write("}");
			return false;
		}

		public override bool Visit(UnifiedCall element, int arg) {
			element.Function.TryAccept(this, arg + 1);
			element.GenericArguments.TryAccept(this, arg + 1);
			_writer.Write("(");
			element.Arguments.Accept(this, arg + 1);
			_writer.Write(")");
			return true;
		}

		public override bool Visit(UnifiedFunctionDefinition element, int arg) {
			element.Modifiers.TryAccept(this, arg + 1);
			element.Type.Accept(this, arg + 1);
			_writer.Write(" ");
			element.Name.Accept(this, arg + 1);
			element.GenericParameters.TryAccept(this, arg + 1);
			element.Parameters.Accept(this, arg + 1);
			if (element.Body == null) {
				return true;
			} else {
				return element.Body.Accept(this, arg + 1);
			}
		}

		public override bool Visit(UnifiedIf element, int arg) {
			_writer.Write("if");
			WriteSpace();
			_writer.Write("(");
			element.Condition.Accept(this, arg);
			_writer.Write(")");
			element.Body.Accept(this, arg);
			if (element.ElseBody != null) {
				_writer.WriteLine();
				WriteIndent(arg);
				_writer.Write("else");
				element.ElseBody.Accept(this, arg);
			}
			return false;
		}

		public override bool Visit(UnifiedParameter element, int arg) {
			element.Annotations.TryAccept(this, arg, WriteSpace);
			element.Modifiers.TryAccept(this, arg, WriteSpace);
			element.Type.Accept(this, arg + 1);
			WriteSpace();
			element.Names.Accept(this, arg + 1);
			return false;
		}

		public override bool Visit(UnifiedParameterCollection element, int arg) {
			_writer.Write("(");
			var separator = "";
			foreach (var elem in element) {
				_writer.Write(separator);
				separator = ", ";
				elem.TryAccept(this, arg + 1);
			}
			_writer.Write(")");
			return true;
		}

		public override bool Visit(UnifiedModifier element, int arg) {
			_writer.Write(element.Name);
			return false;
		}

		public override bool Visit(UnifiedModifierCollection element, int arg) {
			foreach (var mod in element) {
				mod.TryAccept(this, arg + 1, WriteSpace);
			}
			return false;
		}

		public override bool Visit(UnifiedImport element, int arg) {
			_writer.Write("using ");
			element.Alias.TryAccept(this, arg, () => _writer.Write(" = "));
			element.Name.Accept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedProgram element, int arg) {
			foreach (var elem in element.Body) {
				var semmi = elem.Accept(this, arg);
				if (semmi)
					_writer.Write(";");
				_writer.WriteLine();
			}
			return false;
		}

		public override bool Visit(UnifiedNew element, int arg) {
			_writer.Write("new ");
			element.Target.TryAccept(this, arg + 1);
			if (element.Arguments != null) {
				_writer.Write("(");
				element.Arguments.Accept(this, arg + 1);
				_writer.Write(")");
			}
			element.Body.TryAccept(this, arg + 1);
			element.InitialValue.TryAccept(this, arg + 1);
			return true;
		}

		public override bool Visit(UnifiedFor element, int arg) {
			_writer.Write("for");
			_writer.Write("(");
			element.Initializer.TryAccept(this, arg);
			_writer.Write(";");
			element.Condition.TryAccept(this, arg);
			_writer.Write(";");
			element.Step.TryAccept(this, arg);
			_writer.Write(")");
			element.Body.Accept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedForeach element, int arg) {
			_writer.Write("foreach");
			_writer.Write("(");
			element.Element.Accept(this, arg);
			_writer.Write(" in ");
			element.Set.Accept(this, arg);
			_writer.Write(")");
			element.Body.Accept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedUnaryExpression element, int arg) {
			bool suffix = false;
			switch (element.Operator.Kind) {
			case UnifiedUnaryOperatorKind.PostIncrementAssign:
			case UnifiedUnaryOperatorKind.PostDecrementAssign:
				suffix = true;
				break;
			}
			if (suffix == false) {
				element.Operator.Accept(this, arg);
			}
			element.Operand.Accept(this, arg);
			if (suffix) {
				element.Operator.Accept(this, arg);
			}
			return true;
		}

		public override bool Visit(UnifiedProperty element, int arg) {
			element.Owner.Accept(this, arg);
			_writer.Write(element.Delimiter);
			element.Name.Accept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedExpressionCollection element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedWhile element, int arg) {
			_writer.Write("while");
			WriteSpace();
			_writer.Write("(");
			element.Condition.Accept(this, arg);
			_writer.Write(")");
			element.Body.Accept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedDoWhile element, int arg) {
			_writer.Write("do");
			element.Body.Accept(this, arg);
			_writer.Write("while");
			WriteSpace();
			_writer.Write("(");
			element.Condition.Accept(this, arg);
			_writer.Write(")");
			return true;
		}

		public override bool Visit(UnifiedIndexer element, int arg) {
			element.Target.Accept(this, arg);
			_writer.Write("[");
			element.Arguments.TryAccept(this, arg);
			_writer.Write("]");
			return true;
		}

		public override bool Visit(UnifiedGenericArgument element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedGenericArgumentCollection element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSwitch element, int arg) {
			_writer.Write("switch");
			_writer.Write("(");
			element.Value.Accept(this, arg);
			_writer.Write(")");
			_writer.WriteLine("{");
			element.Cases.Accept(this, arg);
			_writer.WriteLine();
			_writer.Write("}");
			return false;
		}

		public override bool Visit(UnifiedCaseCollection element, int arg) {
			foreach (var uCase in element) {
				uCase.Accept(this, arg + 1);
			}
			return false;
		}

		public override bool Visit(UnifiedCase element, int arg) {
			WriteIndent(arg);
			if (element.Condition != null) {
				_writer.Write("case ");
				element.Condition.Accept(this, arg);
			} else {
				_writer.Write("default");
			}
			_writer.WriteLine(":");

			if (element.Body != null) {
				foreach (var stmt in element.Body) {
					WriteIndent(arg);
					var semmi = stmt.Accept(this, arg + 1);
					if (semmi) {
						_writer.Write(";");
					}
					_writer.WriteLine();
				}
			}

			return false;
		}

		public override bool Visit(UnifiedCatch element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedTypeCollection element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedCatchCollection element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedTry element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedCast element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedGenericParameterCollection element, int arg) {
			if (element.Count == 0)
				return false;
			_writer.Write("<");
			var sep = "";
			foreach (var gen in element) {
				_writer.Write(sep);
				sep = ", ";
				gen.Accept(this, arg + 1);
			}
			_writer.Write(">");
			return false;
		}

		public override bool Visit(UnifiedTypeConstrainCollection element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedTypeParameter element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedTernaryExpression element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedIdentifierCollection element, int arg) {
			foreach (var id in element) {
				id.TryAccept(this, arg + 1, WriteSpace);
			}
			return false;
		}

		public override bool Visit(UnifiedLabel element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedBooleanLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedFractionLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedIntegerLiteral element, int arg) {
			_writer.Write(element.Value);
			return true;
		}

		public override bool Visit(UnifiedStringLiteral element, int arg) {
			// TODO: escpae when string include back slash
			_writer.Write(element.Value);
			return true;
		}

		public override bool Visit(UnifiedNullLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedMatcher element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedMatcherCollection element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedUsing element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedListComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedList element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedKeyValue element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedDictionaryComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedDictionary element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSlice element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedComment element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedAnnotation element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedAnnotationCollection element, int arg) {
			if (element.Count == 0)
				return false;
			_writer.Write("[");
			var sep = "";
			foreach (var attr in element) {
				_writer.Write(sep);
				sep = ", ";
				attr.Accept(this, arg + 1);
			}
			_writer.Write("]");
			return false;
		}

		public override bool Visit(UnifiedVariableDefinitionList element, int arg) {
			if (element.Count == 0)
				return false;
			var first = true;
			foreach (var def in element) {
				if (first) {
					first = false;
					def.Modifiers.TryAccept(this, arg, WriteSpace);
					def.Type.Accept(this, arg);
					WriteSpace();
				}
				def.Name.Accept(this, arg);
				if (def.InitialValue != null) {
					_writer.Write(" = ");
					def.InitialValue.Accept(this, arg);
				}
			}
			return true;
		}

		public override bool Visit(UnifiedVariableDefinition element, int arg) {
			element.Modifiers.TryAccept(this, arg, WriteSpace);
			element.Type.Accept(this, arg);
			WriteSpace();
			element.Name.Accept(this, arg);
			if (element.InitialValue != null) {
				_writer.Write(" = ");
				element.InitialValue.Accept(this, arg);
			}
			return true;
		}

		public override bool Visit(UnifiedArrayType element, int arg) {
			element.Type.TryAccept(this, arg);
			_writer.Write("[");
			element.Arguments.Accept(this, arg);
			_writer.Write("]");
			return false;
		}

		public override bool Visit(UnifiedGenericType element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSimpleType element, int arg) {
			element.BasicType.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedCharLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedIterable element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedArray element, int arg) {
			_writer.Write("{ ");
			var sep = "";
			foreach (var elem in element) {
				_writer.Write(sep);
				sep = ", ";
				elem.Accept(this, arg);
			}
			_writer.Write(" }");
			return true;
		}

		public override bool Visit(UnifiedSet element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedTuple element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedIterableComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSetComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedInterface element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedClass element, int arg) {
			element.Modifiers.TryAccept(this, arg);
			_writer.Write("class");
			WriteSpace();
			element.Name.TryAccept(this, arg);
			WriteSpace();
			element.GenericParameters.TryAccept(this, arg + 1);
			element.Constrains.TryAccept(this, arg + 1);
			if (_style.LineBreak.AfterClass) {
				_writer.WriteLine();
				WriteIndent(arg);
			} else {
				WriteSpace();
			}
			element.Body.TryAccept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedStruct element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedEnum element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedModule element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedUnion element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedAnnotationDefinition element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedNamespace element, int arg) {
			element.Annotations.TryAccept(this, arg);
			_writer.Write("namespace ");
			element.Name.Accept(this, arg);
			_writer.Write(" ");
			element.Body.Accept(this, arg);
			return false;
		}

		public override bool Visit(UnifiedBreak element, int arg) {
			_writer.Write("break");
			return true;
		}

		public override bool Visit(UnifiedContinue element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedReturn element, int arg) {
			_writer.Write("return");
			if (element.Value != null) {
				WriteSpace();
				element.Value.Accept(this, arg);
			}
			return true;
		}

		public override bool Visit(UnifiedGoto element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedYieldReturn element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedDelete element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedThrow element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedAssert element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedExec element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedStringConversion element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedPass element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedPrint element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedPrintChevron element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedWith element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedFix element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSynchronized element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedConstType element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedPointerType element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedUnionType element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedVolatileType element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedStructType element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedReferenceType element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedConstructor element, int arg) {
			var classDef = null as UnifiedClass;
			var elem = element as IUnifiedElement;
			while (classDef == null) {
				elem = elem.Parent;
				if (elem == null)
					throw new InvalidOperationException(
							"Constructor must be declared in a class declaration scope.");
				classDef = elem as UnifiedClass;
			}
			element.Modifiers.TryAccept(this, arg + 1);
			classDef.Name.TryAccept(this, arg + 1);
			element.GenericParameters.TryAccept(this, arg + 1);
			element.Parameters.TryAccept(this, arg + 1);
			element.Body.TryAccept(this, arg + 1);
			return false;
		}

		public override bool Visit(UnifiedStaticInitializer element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedInstanceInitializer element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedLambda element, int arg) {
			element.Parameters.TryAccept(this, arg);
			_writer.Write(" => ");
			element.Body.Accept(this, arg);
			return true;
		}

		public override bool Visit(UnifiedDefaultConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedExtendConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedImplementsConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedReferenceConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSuperConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedValueConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSuperIdentifier element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedThisIdentifier element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedLabelIdentifier element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedSizeof element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedTypeof element, int arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(UnifiedVariableIdentifier element, int arg) {
			_writer.Write(element.Name);
			return true;
		}

		public override bool Visit(UnifiedRegularExpressionLiteral element, int arg) {
			throw new NotImplementedException();
		}
			}

	#region exntension method

	internal static class ElementExtension {
		internal static bool? TryAccept(
				this IUnifiedElement element, CSharpCodeFactoryVisitor visitor, int arg) {
			if (element == null)
				return null;
			return element.Accept(visitor, arg);
		}

		internal static bool TryAccept(
				this IUnifiedElement element, CSharpCodeFactoryVisitor visitor, int arg,
				Action action) {
			if (element == null)
				return false;
			var result = element.Accept(visitor, arg);
			action();
			return result;
		}
	}

	#endregion
}