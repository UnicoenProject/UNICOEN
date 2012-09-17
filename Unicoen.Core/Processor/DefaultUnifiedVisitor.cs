#region License

// Copyright (C) 2011-2012 The Unicoen Project
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

using Unicoen.Model;

namespace Unicoen.Processor {
	public abstract class DefaultUnifiedVisitor : IUnifiedVisitor {
		#region IUnifiedVisitor Members

		public virtual void Visit(UnifiedBinaryOperator element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUnaryOperator element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedArgument element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedArgumentCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedBinaryExpression element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedBlock element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedCall element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedFunctionDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedIf element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedParameter element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedParameterCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedModifier element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedModifierCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedImport element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedProgram element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedNew element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedFor element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedForeach element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUnaryExpression element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedProperty element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedExpressionCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedWhile element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedDoWhile element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedIndexer element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedGenericArgument element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedGenericArgumentCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSwitch element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedCaseCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedCase element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedCatch element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedTypeCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedCatchCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedTry element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedCast element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedGenericParameterCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedTypeConstrainCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedGenericParameter element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedTernaryExpression element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedIdentifierCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedLabel element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedBooleanLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedFractionLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedBigIntLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedInt8Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedInt16Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedInt31Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedInt32Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedInt64Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUInt8Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUInt16Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUInt31Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUInt32Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUInt64Literal element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedStringLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedNullLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUsing element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedListComprehension element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedListLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedKeyValue element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedMapComprehension element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedMapLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSlice element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedComment element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedAnnotation element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedAnnotationCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedVariableDefinitionList element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedVariableDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedArrayType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedGenericType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedBasicType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedCharLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedIterableLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedArrayLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSetLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedTupleLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedIterableComprehension element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSetComprehension element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedInterfaceDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedClassDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedStructDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedEnumDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedModuleDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUnionDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedAnnotationDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedNamespaceDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedBreak element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedContinue element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedReturn element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedGoto element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedYieldReturn element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedYieldBreak element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedDelete element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedThrow element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedAssert element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedExec element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedStringConversion element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedPass element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedPrint element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedPrintChevron element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedWith element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedFix element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSynchronized element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedConstType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedPointerType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedUnionType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedStructType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedVolatileType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedReferenceType element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedConstructor element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedStaticInitializer element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedInstanceInitializer element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedLambda element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedConstructorConstrain element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedExtendConstrain element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedImplementsConstrain element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedReferenceConstrain element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSuperConstrain element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedValueConstrain element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSuperIdentifier element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedThisIdentifier element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedLabelIdentifier element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSizeof element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedTypeof element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedVariableIdentifier element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedRegularExpressionLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedPropertyDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedPropertyDefinitionPart element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSelectQuery element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedWhereQuery element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedLetQuery element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedOrderByQuery element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedJoinQuery element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedGroupByQuery element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedOrderByKeyCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedOrderByKey element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedLinqExpression element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedDefault element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedValueIdentifier element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedEventDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedFromQuery element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedProc element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedEigenClassDefinition element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedEigenConstrain element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedRange element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedRetry element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedRedo element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedSymbolLiteral element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedDefined element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedAlias element) {
			element.TryAcceptAllChildren(this);
		}

		public void Visit(UnifiedUncheckedBlock element) {
			element.TryAcceptAllChildren(this);
		}

		public void Visit(UnifiedCheckedBlock element) {
			element.TryAcceptAllChildren(this);
		}

		public void Visit(UnifiedCommentCollection element) {
			element.TryAcceptAllChildren(this);
		}

		public virtual void Visit(UnifiedTypeIdentifier element) {
			element.TryAcceptAllChildren(this);
		}

		#endregion
	}

	public abstract class DefaultUnifiedVisitor<TArg>
			: IUnifiedVisitor<TArg> {
		#region IUnifiedVisitor<TArg> Members

		public virtual void Visit(UnifiedBinaryOperator element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUnaryOperator element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedArgument element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedArgumentCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedBinaryExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedBlock element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCall element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedFunctionDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedIf element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedParameter element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedParameterCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedModifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedModifierCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedImport element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedProgram element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedNew element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedFor element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedForeach element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUnaryExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedProperty element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedExpressionCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedWhile element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedDoWhile element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedIndexer element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedGenericArgument element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedGenericArgumentCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSwitch element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCaseCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCase element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCatch element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedTypeCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCatchCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedTry element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCast element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedGenericParameterCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedTypeConstrainCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedGenericParameter element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedTernaryExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedIdentifierCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedLabel element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedBooleanLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedFractionLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedBigIntLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedInt8Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedInt16Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedInt31Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedInt32Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedInt64Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUInt8Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUInt16Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUInt31Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUInt32Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUInt64Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedStringLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedNullLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUsing element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedListComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedListLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedKeyValue element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedMapComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedMapLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSlice element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedComment element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedAnnotation element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedAnnotationCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedVariableDefinitionList element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedVariableDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedArrayType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedGenericType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedBasicType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCharLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedIterableLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedArrayLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSetLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedTupleLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedIterableComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSetComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedInterfaceDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedClassDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedStructDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedEnumDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedModuleDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUnionDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedAnnotationDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedNamespaceDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedBreak element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedContinue element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedReturn element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedGoto element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedYieldReturn element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedYieldBreak element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedDelete element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedThrow element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedAssert element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedExec element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedStringConversion element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedPass element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedPrint element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedPrintChevron element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedWith element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedFix element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSynchronized element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedConstType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedPointerType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUnionType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedStructType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedVolatileType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedReferenceType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedConstructor element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedStaticInitializer element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedInstanceInitializer element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedLambda element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedConstructorConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedExtendConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedImplementsConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedReferenceConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSuperConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedValueConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSuperIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedThisIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedLabelIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSizeof element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedTypeof element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedVariableIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedRegularExpressionLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedPropertyDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(
				UnifiedPropertyDefinitionPart element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSelectQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedWhereQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedLetQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedOrderByQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedJoinQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedGroupByQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedOrderByKeyCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedOrderByKey element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedLinqExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedDefault element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedValueIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedEventDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedFromQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedProc element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedEigenClassDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedEigenConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedRange element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedRedo element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedRetry element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedSymbolLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedDefined element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedAlias element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedUncheckedBlock element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedCheckedBlock element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public void Visit(UnifiedCommentCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		public virtual void Visit(UnifiedTypeIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
		}

		#endregion
			}

	public abstract class DefaultUnifiedVisitor<TArg, TResult>
			: IUnifiedVisitor<TArg, TResult> {
		#region IUnifiedVisitor<TArg,TResult> Members

		public virtual TResult Visit(UnifiedBinaryOperator element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedPropertyDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedPropertyDefinitionPart element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSelectQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedWhereQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLetQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedOrderByQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedJoinQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGroupByQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedOrderByKeyCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedOrderByKey element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLinqExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDefault element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedValueIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedEventDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFromQuery element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedProc element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedEigenClassDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedEigenConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedRange element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedRedo element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedRetry element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public TResult Visit(UnifiedSymbolLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDefined element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedAlias element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUncheckedBlock element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public TResult Visit(UnifiedCheckedBlock element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public TResult Visit(UnifiedCommentCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnaryOperator element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedArgument element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedArgumentCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBinaryExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBlock element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCall element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedFunctionDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIf element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedParameter element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedParameterCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedModifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedModifierCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedImport element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedProgram element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedNew element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFor element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedForeach element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnaryExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedProperty element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedExpressionCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedWhile element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDoWhile element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIndexer element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGenericArgument element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedGenericArgumentCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSwitch element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCaseCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCase element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCatch element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTypeCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCatchCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTry element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCast element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedGenericParameterCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedTypeConstrainCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGenericParameter element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTernaryExpression element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedIdentifierCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLabel element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBooleanLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFractionLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBigIntLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt8Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt16Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt31Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt32Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt64Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt8Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt16Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt31Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt32Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt64Literal element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStringLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedNullLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUsing element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedListComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedListLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedKeyValue element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedMapComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedMapLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSlice element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedComment element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedAnnotation element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedAnnotationCollection element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedVariableDefinitionList element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedVariableDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedArrayType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGenericType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBasicType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCharLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIterableLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedArrayLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSetLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTupleLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedIterableComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSetComprehension element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedInterfaceDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedClassDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStructDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedEnumDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedModuleDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnionDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedAnnotationDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedNamespaceDefinition element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBreak element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedContinue element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedReturn element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGoto element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedYieldReturn element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedYieldBreak element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDelete element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedThrow element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedAssert element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedExec element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStringConversion element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPass element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPrint element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPrintChevron element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedWith element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFix element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSynchronized element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedConstType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPointerType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnionType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedVolatileType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStructType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedReferenceType element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedConstructor element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStaticInitializer element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedInstanceInitializer element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLambda element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedConstructorConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedExtendConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedImplementsConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedReferenceConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSuperConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedValueConstrain element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSuperIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedThisIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLabelIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSizeof element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTypeof element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedVariableIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedRegularExpressionLiteral element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTypeIdentifier element, TArg arg) {
			element.TryAcceptAllChildren(this, arg);
			return default(TResult);
		}

		#endregion

		private void TryAcceptAll(UnifiedElement element, TArg arg) {
			foreach (var child in element.Elements()) {
				child.TryAccept(this, arg);
			}
		}
			}
}