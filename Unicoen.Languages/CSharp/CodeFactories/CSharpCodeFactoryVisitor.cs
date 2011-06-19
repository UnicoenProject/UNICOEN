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

		private void WriteSpace() {
			_writer.Write(" ");
		}

		private void WriteIndent(int indent) {
			for (int i = 0; i < indent; i++) _writer.Write(_style.Indent);
		}

		public bool Visit(UnifiedBinaryOperator element, int arg) {
			_writer.Write(element.Sign);
			return false;
		}

		public bool Visit(UnifiedUnaryOperator element, int arg) {
			_writer.Write(element.Sign);
			return false;
		}

		public bool Visit(UnifiedArgument element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedArgumentCollection element, int arg) {
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

		public bool Visit(UnifiedBinaryExpression element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedBlock element, int arg) {
			_writer.Write("{");
			_writer.WriteLine();
			foreach (var elem in element) {
				WriteIndent(arg + 1);
				var hasSemmi = elem.TryAccept(this, arg + 1);
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
			element.Arguments.TryAccept(this, arg + 1);
			return true;
		}

		public bool Visit(UnifiedFunction element, int arg) {
			element.Modifiers.TryAccept(this, arg + 1);
			element.Type.TryAccept(this, arg + 1);
			element.Name.TryAccept(this, arg + 1);
			element.GenericParameters.TryAccept(this, arg + 1);
			element.Parameters.TryAccept(this, arg + 1);
			element.Body.TryAccept(this, arg + 1);
			return false;
		}

		public bool Visit(UnifiedIf element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedParameter element, int arg) {
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedModifierCollection element, int arg) {
			foreach (var mod in element) {
				_writer.Write(mod.Name);
				WriteSpace();
			}
			return false;
		}

		public bool Visit(UnifiedImport element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedProgram element, int arg) {
			foreach (var elem in element) {
				elem.Accept(this, arg + 1);
			}
			return false;
		}

		public bool Visit(UnifiedNew element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedFor element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedForeach element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedUnaryExpression element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedProperty element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedExpressionCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedWhile element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedDoWhile element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedIndexer element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedTypeArgument element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedGenericArgumentCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSwitch element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedCaseCollection element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedCase element, int arg) {
			throw new NotImplementedException();
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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedStringLiteral element, int arg) {
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedVariableDefinitionList element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedVariableDefinition element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedArrayType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedGenericType element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedSimpleType element, int arg) {
			return element.NameExpression.TryAccept(this, arg + 1);
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
			_writer.Write(element.Name);
			WriteSpace();
			element.GenericParameters.TryAccept(this, arg + 1);
			element.Constrains.TryAccept(this, arg + 1);
			if (_style.LineBreak.AfterClass) {
				_writer.WriteLine();
				WriteIndent(arg);
			} else {
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
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedBreak element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedContinue element, int arg) {
			throw new NotImplementedException();
		}

		public bool Visit(UnifiedReturn element, int arg) {
			throw new NotImplementedException();
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
}
