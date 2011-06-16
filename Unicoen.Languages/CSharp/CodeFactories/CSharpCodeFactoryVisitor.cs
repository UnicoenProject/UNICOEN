using System;
using System.Text;
using Unicoen.Core.Processor;
using Unicoen.Core.Model;
using System.IO;

namespace Unicoen.Languages.CSharp.CodeFactories {

	internal class CSharpCodeFactoryVisitor : IUnifiedVisitor {

		private readonly TextWriter _writer;
		private readonly CSharpCodeStyle _style;

		private int _indent = 0;

		public CSharpCodeFactoryVisitor(TextWriter writer, CSharpCodeStyle style) {
			_writer = writer;
			_style = style;
		}

		private void WriteSpace() {
			_writer.Write(" ");
		}

		private void WriteIndent() {
			for (int i = 0; i < _indent; i++)
				_writer.Write(_style.Indent);
		}

		private void VisitUnlessNull<T>(T element) where T : class, IUnifiedElement {
			if (element != null)
				element.Accept(this);
		}

		#region VisitorCode

		public void Visit(UnifiedBinaryOperator element) {
			_writer.Write(element.Sign);
		}

		public void Visit(UnifiedUnaryOperator element) {
			_writer.Write(element.Sign);
		}

		public void Visit(UnifiedArgument element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArgumentCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBinaryExpression element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBlock element) {
			bool hasBracket = element.Parent is UnifiedBlock;
			if (hasBracket) {
			}


			throw new NotImplementedException();
		}

		public void Visit(UnifiedCall element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedFunction element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIf element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedParameter element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedParameterCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedModifier element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedModifierCollection element) {
			foreach(var mod in element) {
				_writer.Write(mod.Name);
				WriteSpace();
			}
		}

		public void Visit(UnifiedImport element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProgram element) {
			foreach (var elem in element) {
				elem.Accept(this);
			}
		}

		public void Visit(UnifiedNew element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedFor element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedForeach element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUnaryExpression element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProperty element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedExpressionCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedWhile element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedDoWhile element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIndexer element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeArgument element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedGenericArgumentCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSwitch element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCaseCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCase element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCatch element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCatchCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTry element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCast element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedGenericParameterCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeConstrainCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeParameter element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTernaryExpression element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIdentifierCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedLabel element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBooleanLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedFractionLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIntegerLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedStringLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNullLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedMatcher element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedMatcherCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUsing element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedListComprehension element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedList element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedKeyValue element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedDictionaryComprehension element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedDictionary element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSlice element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedComment element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedAnnotation element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedAnnotationCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinitionList element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArrayType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedGenericType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSimpleType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedCharLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIterable element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArray element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSet element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTuple element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIterableComprehension element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSetComprehension element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedInterface element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedClass element) {
			WriteIndent();
			VisitUnlessNull(element.Modifiers);
			_writer.Write("class");
			WriteSpace();
			_writer.Write(element.Name);
			WriteSpace();
			VisitUnlessNull(element.GenericParameters);
			VisitUnlessNull(element.Constrains);
			if (_style.LineBreak.AfterClass) {
				_writer.WriteLine();
				WriteIndent();
			}
			else {
				WriteSpace();
			}
			_writer.Write("{");
			_indent++;
			VisitUnlessNull(element.Body);
			_indent--;
			WriteIndent();
			_writer.Write("}");
			_writer.WriteLine();
		}

		public void Visit(UnifiedStruct element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedEnum element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedModule element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUnion element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedAnnotationDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNamespace element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedBreak element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedContinue element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedReturn element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedGoto element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedYieldReturn element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedDelete element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedThrow element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedAssert element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedExec element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedStringConversion element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedPass element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedPrint element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedPrintChevron element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedWith element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedFix element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSynchronized element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedConstType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedPointerType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedUnionType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedStructType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVolatileType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedReferenceType element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedConstructor element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedStaticInitializer element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedInstanceInitializer element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedLambda element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedDefaultConstrain element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedExtendConstrain element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedImplementsConstrain element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedReferenceConstrain element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSuperConstrain element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedValueConstrain element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSuperIdentifier element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedThisIdentifier element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedLabelIdentifier element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedSizeof element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedTypeof element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableIdentifier element) {
			throw new NotImplementedException();
		}

		#endregion

	}
}
