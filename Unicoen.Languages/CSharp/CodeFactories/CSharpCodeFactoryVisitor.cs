using System;
using System.IO;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.CSharp.CodeFactories {
	internal class CSharpCodeFactoryVisitor : IUnifiedVisitor<bool, int> {
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

		public bool Visit(UnifiedBinaryOperator element, int arg) {
			_writer.Write(element.Sign);
			return false;
		}

		public bool Visit(UnifiedUnaryOperator element, int arg) {
			_writer.Write(element.Sign);
			return false;
		}

		public bool Visit(UnifiedArgument element, int arg) {
			element.Modifiers.TryAccept(this, arg, WriteSpace);
			element.Target.TryAccept(this, arg, WriteCollon);
			element.Value.Accept(this, arg);
			return false;
		}

		public bool Visit(UnifiedArgumentCollection element, int arg) {
			var separator = "";
			foreach (var elem in element) {
				_writer.Write(separator);
				separator = ", ";
				elem.TryAccept(this, arg + 1);
			}
			return true;
		}

		public bool Visit(UnifiedBinaryExpression element, int arg) {
			element.LeftHandSide.Accept(this, arg);
			WriteSpace();
			element.Operator.Accept(this, arg);
			WriteSpace();
			element.RightHandSide.Accept(this, arg);
			return true;
		}

		public bool Visit(UnifiedBlock element, int arg) {
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
			_writer.WriteLine();
			return false;
		}

		public bool Visit(UnifiedCall element, int arg) {
			element.Function.TryAccept(this, arg + 1);
			element.GenericArguments.TryAccept(this, arg + 1);
			_writer.Write("(");
			element.Arguments.Accept(this, arg + 1);
			_writer.Write(")");
			return true;
		}

		public bool Visit(UnifiedFunction element, int arg) {
			element.Modifiers.TryAccept(this, arg + 1);
			element.Type.Accept(this, arg + 1);
			_writer.Write(" ");
			element.Name.Accept(this, arg + 1);
			element.GenericParameters.TryAccept(this, arg + 1);
			element.Parameters.Accept(this, arg + 1);
			if (element.Body == null) {
				return true;
			}
			else {
				return element.Body.Accept(this, arg + 1);
			}
		}

		public bool Visit(UnifiedIf element, int arg) {
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

		public bool Visit(UnifiedParameter element, int arg) {
			element.Annotations.TryAccept(this, arg, WriteSpace);
			element.Modifiers.TryAccept(this, arg, WriteSpace);
			element.Type.Accept(this, arg + 1);
			WriteSpace();
			element.Names.Accept(this, arg + 1);
			return false;
		}

		public bool Visit(UnifiedParameterCollection element, int arg) {
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

		public bool Visit(UnifiedModifier element, int arg) {
			_writer.Write(element.Name);
			return false;
		}

		public bool Visit(UnifiedModifierCollection element, int arg) {
			foreach (var mod in element) {
				mod.TryAccept(this, arg + 1, WriteSpace);
			}
			return false;
		}

		public bool Visit(UnifiedImport element, int arg) {
			_writer.Write("import ");
			element.Alias.TryAccept(this, arg, () => _writer.Write(" = "));
			element.Name.Accept(this, arg);
			return true;
		}

		public bool Visit(UnifiedProgram element, int arg) {
			foreach (var elem in element) {
				elem.Accept(this, arg);
			}
			return false;
		}

		public bool Visit(UnifiedNew element, int arg) {
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

		public bool Visit(UnifiedFor element, int arg) {
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

		public bool Visit(UnifiedForeach element, int arg) {
			_writer.Write("foreach");
			_writer.Write("(");
			element.Element.Accept(this, arg);
			_writer.Write(" in ");
			element.Set.Accept(this, arg);
			_writer.Write(")");
			element.Body.Accept(this, arg);
			return false;
		}

		public bool Visit(UnifiedUnaryExpression element, int arg) {
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

		public bool Visit(UnifiedProperty element, int arg) {
			element.Owner.Accept(this, arg);
			_writer.Write(element.Delimiter);
			element.Name.Accept(this, arg);
			return true;
		}

		public bool Visit(UnifiedExpressionCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedWhile element, int arg) {
			_writer.Write("while");
			WriteSpace();
			_writer.Write("(");
			element.Condition.Accept(this, arg);
			_writer.Write(")");
			element.Body.Accept(this, arg);
			return false;
		}

		public bool Visit(UnifiedDoWhile element, int arg) {
			_writer.Write("do");
			element.Body.Accept(this, arg);
			_writer.Write("while");
			WriteSpace();
			_writer.Write("(");
			element.Condition.Accept(this, arg);
			_writer.Write(")");
			return true;
		}

		public bool Visit(UnifiedIndexer element, int arg) {
			element.Target.Accept(this, arg);
			_writer.Write("[");
			element.Arguments.TryAccept(this, arg);
			_writer.Write("]");
			return true;
		}

		public bool Visit(UnifiedTypeArgument element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedGenericArgumentCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSwitch element, int arg) {
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

		public bool Visit(UnifiedCaseCollection element, int arg) {
			foreach (var uCase in element) {
				uCase.Accept(this, arg + 1);
			}
			return false;
		}

		public bool Visit(UnifiedCase element, int arg) {
			WriteIndent(arg);
			if (element.Condition != null) {
				_writer.Write("case ");
				element.Condition.Accept(this, arg);
			}
			else {
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

		public bool Visit(UnifiedCatch element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedTypeCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedCatchCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedTry element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedCast element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedGenericParameterCollection element, int arg) {
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

		public bool Visit(UnifiedTypeConstrainCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedTypeParameter element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedTernaryExpression element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedIdentifierCollection element, int arg) {
			foreach (var id in element) {
				id.TryAccept(this, arg + 1, WriteSpace);
			}
			return false;
		}

		public bool Visit(UnifiedLabel element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedBooleanLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedFractionLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedIntegerLiteral element, int arg) {
			_writer.Write(element.Value);
			return true;
		}

		public bool Visit(UnifiedStringLiteral element, int arg) {
			// TODO: escpae when string include back slash
			_writer.Write(element.Value);
			return true;
		}

		public bool Visit(UnifiedNullLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedMatcher element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedMatcherCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedUsing element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedListComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedList element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedKeyValue element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedDictionaryComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedDictionary element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSlice element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedComment element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedAnnotation element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedAnnotationCollection element, int arg) {
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

		public bool Visit(UnifiedVariableDefinitionList element, int arg) {
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

		public bool Visit(UnifiedVariableDefinition element, int arg) {
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

		public bool Visit(UnifiedArrayType element, int arg) {
			element.Type.TryAccept(this, arg);
			_writer.Write("[");
			element.Arguments.Accept(this, arg);
			_writer.Write("]");
			return false;
		}

		public bool Visit(UnifiedGenericType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSimpleType element, int arg) {
			element.NameExpression.TryAccept(this, arg);
			return false;
		}

		public bool Visit(UnifiedCharLiteral element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedIterable element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedArray element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSet element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedTuple element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedIterableComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSetComprehension element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedInterface element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedClass element, int arg) {
			WriteIndent(arg);
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
			}
			else {
				WriteSpace();
			}
			element.Body.TryAccept(this, arg + 1);
			return false;
		}

		public bool Visit(UnifiedStruct element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedEnum element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedModule element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedUnion element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedAnnotationDefinition element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedNamespace element, int arg) {
			element.Annotations.TryAccept(this, arg);
			_writer.Write("namespace ");
			element.Name.Accept(this, arg);
			_writer.Write(" ");
			element.Body.Accept(this, arg);
			return false;
		}

		public bool Visit(UnifiedBreak element, int arg) {
			_writer.Write("break");
			return true;
		}

		public bool Visit(UnifiedContinue element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedReturn element, int arg) {
			_writer.Write("return");
			if (element.Value != null) {
				WriteSpace();
				element.Value.Accept(this, arg);
			}
			return true;
		}

		public bool Visit(UnifiedGoto element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedYieldReturn element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedDelete element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedThrow element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedAssert element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedExec element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedStringConversion element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedPass element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedPrint element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedPrintChevron element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedWith element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedFix element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSynchronized element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedConstType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedPointerType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedUnionType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedVolatileType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedStructType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedReferenceType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedConstructor element, int arg) {
			var classDef = null as UnifiedClass;
			var elem = element as IUnifiedElement;
			while (classDef == null) {
				elem = elem.Parent;
				if (elem == null) throw new InvalidOperationException("Constructor must be declared in a class declaration scope.");
				classDef = elem as UnifiedClass;
			}
			element.Modifiers.TryAccept(this, arg + 1);
			classDef.Name.TryAccept(this, arg + 1);
			element.GenericParameters.TryAccept(this, arg + 1);
			element.Parameters.TryAccept(this, arg + 1);
			element.Body.TryAccept(this, arg + 1);
			return false;
		}

		public bool Visit(UnifiedStaticInitializer element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedInstanceInitializer element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedLambda element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedDefaultConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedExtendConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedImplementsConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedReferenceConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSuperConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedValueConstrain element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSuperIdentifier element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedThisIdentifier element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedLabelIdentifier element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSizeof element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedTypeof element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedVariableIdentifier element, int arg) {
			_writer.Write(element.Name);
			return true;
		}
	}

	#region exntension method

	internal static class ElementExtension {

		internal static bool? TryAccept(this IUnifiedElement element, CSharpCodeFactoryVisitor visitor, int arg) {
			if (element == null)
				return null;
			return element.Accept(visitor, arg);
		}

		internal static bool TryAccept(this IUnifiedElement element, CSharpCodeFactoryVisitor visitor, int arg, Action action) {
			if (element == null)
				return false;
			var result = element.Accept(visitor, arg);
			action();
			return result;
		}
	}

	#endregion

}
