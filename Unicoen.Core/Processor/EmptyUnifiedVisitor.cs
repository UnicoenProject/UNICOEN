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

using Unicoen.Model;

namespace Unicoen.Processor {
	public abstract class EmptyUnifiedVisitor : IUnifiedVisitor {
		public virtual void Visit(UnifiedBinaryOperator element) {}

		public virtual void Visit(UnifiedUnaryOperator element) {}

		public virtual void Visit(UnifiedArgument element) {}

		public virtual void Visit(UnifiedArgumentCollection element) {}

		public virtual void Visit(UnifiedBinaryExpression element) {}

		public virtual void Visit(UnifiedBlock element) {}

		public virtual void Visit(UnifiedCall element) {}

		public virtual void Visit(UnifiedFunctionDefinition element) {}

		public virtual void Visit(UnifiedIf element) {}

		public virtual void Visit(UnifiedParameter element) {}

		public virtual void Visit(UnifiedParameterCollection element) {}

		public virtual void Visit(UnifiedModifier element) {}

		public virtual void Visit(UnifiedModifierCollection element) {}

		public virtual void Visit(UnifiedImport element) {}

		public virtual void Visit(UnifiedProgram element) {}

		public virtual void Visit(UnifiedNew element) {}

		public virtual void Visit(UnifiedFor element) {}

		public virtual void Visit(UnifiedForeach element) {}

		public virtual void Visit(UnifiedUnaryExpression element) {}

		public virtual void Visit(UnifiedProperty element) {}

		public virtual void Visit(UnifiedExpressionCollection element) {}

		public virtual void Visit(UnifiedWhile element) {}

		public virtual void Visit(UnifiedDoWhile element) {}

		public virtual void Visit(UnifiedIndexer element) {}

		public virtual void Visit(UnifiedGenericArgument element) {}

		public virtual void Visit(UnifiedGenericArgumentCollection element) {}

		public virtual void Visit(UnifiedSwitch element) {}

		public virtual void Visit(UnifiedCaseCollection element) {}

		public virtual void Visit(UnifiedCase element) {}

		public virtual void Visit(UnifiedCatch element) {}

		public virtual void Visit(UnifiedTypeCollection element) {}

		public virtual void Visit(UnifiedCatchCollection element) {}

		public virtual void Visit(UnifiedTry element) {}

		public virtual void Visit(UnifiedCast element) {}

		public virtual void Visit(UnifiedGenericParameterCollection element) {}

		public virtual void Visit(UnifiedTypeConstrainCollection element) {}

		public virtual void Visit(UnifiedGenericParameter element) {}

		public virtual void Visit(UnifiedTernaryExpression element) {}

		public virtual void Visit(UnifiedIdentifierCollection element) {}

		public virtual void Visit(UnifiedLabel element) {}

		public virtual void Visit(UnifiedBooleanLiteral element) {}

		public virtual void Visit(UnifiedFractionLiteral element) {}

		public virtual void Visit(UnifiedBigIntLiteral element) {}

		public virtual void Visit(UnifiedInt8Literal element) {}

		public virtual void Visit(UnifiedInt16Literal element) {}

		public virtual void Visit(UnifiedInt31Literal element) {}

		public virtual void Visit(UnifiedInt32Literal element) {}

		public virtual void Visit(UnifiedInt64Literal element) {}

		public virtual void Visit(UnifiedUInt8Literal element) {}

		public virtual void Visit(UnifiedUInt16Literal element) {}

		public virtual void Visit(UnifiedUInt31Literal element) {}

		public virtual void Visit(UnifiedUInt32Literal element) {}

		public virtual void Visit(UnifiedUInt64Literal element) {}

		public virtual void Visit(UnifiedStringLiteral element) {}

		public virtual void Visit(UnifiedNullLiteral element) {}

		public virtual void Visit(UnifiedUsing element) {}

		public virtual void Visit(UnifiedListComprehension element) {}

		public virtual void Visit(UnifiedListLiteral element) {}

		public virtual void Visit(UnifiedKeyValue element) {}

		public virtual void Visit(UnifiedMapComprehension element) {}

		public virtual void Visit(UnifiedMapLiteral element) {}

		public virtual void Visit(UnifiedSlice element) {}

		public virtual void Visit(UnifiedComment element) {}

		public virtual void Visit(UnifiedAnnotation element) {}

		public virtual void Visit(UnifiedAnnotationCollection element) {}

		public virtual void Visit(UnifiedVariableDefinitionList element) {}

		public virtual void Visit(UnifiedVariableDefinition element) {}

		public virtual void Visit(UnifiedArrayType element) {}

		public virtual void Visit(UnifiedGenericType element) {}

		public virtual void Visit(UnifiedBasicType element) {}

		public virtual void Visit(UnifiedCharLiteral element) {}

		public virtual void Visit(UnifiedIterableLiteral element) {}

		public virtual void Visit(UnifiedArrayLiteral element) {}

		public virtual void Visit(UnifiedSetLiteral element) {}

		public virtual void Visit(UnifiedTupleLiteral element) {}

		public virtual void Visit(UnifiedIterableComprehension element) {}

		public virtual void Visit(UnifiedSetComprehension element) {}

		public virtual void Visit(UnifiedInterfaceDefinition element) {}

		public virtual void Visit(UnifiedClassDefinition element) {}

		public virtual void Visit(UnifiedStructDefinition element) {}

		public virtual void Visit(UnifiedEnumDefinition element) {}

		public virtual void Visit(UnifiedModuleDefinition element) {}

		public virtual void Visit(UnifiedUnionDefinition element) {}

		public virtual void Visit(UnifiedAnnotationDefinition element) {}

		public virtual void Visit(UnifiedNamespaceDefinition element) {}

		public virtual void Visit(UnifiedBreak element) {}

		public virtual void Visit(UnifiedContinue element) {}

		public virtual void Visit(UnifiedReturn element) {}

		public virtual void Visit(UnifiedGoto element) {}

		public virtual void Visit(UnifiedYieldReturn element) {}

		public virtual void Visit(UnifiedYieldBreak element) {}

		public virtual void Visit(UnifiedDelete element) {}

		public virtual void Visit(UnifiedThrow element) {}

		public virtual void Visit(UnifiedAssert element) {}

		public virtual void Visit(UnifiedExec element) {}

		public virtual void Visit(UnifiedStringConversion element) {}

		public virtual void Visit(UnifiedPass element) {}

		public virtual void Visit(UnifiedPrint element) {}

		public virtual void Visit(UnifiedPrintChevron element) {}

		public virtual void Visit(UnifiedWith element) {}

		public virtual void Visit(UnifiedFix element) {}

		public virtual void Visit(UnifiedSynchronized element) {}

		public virtual void Visit(UnifiedConstType element) {}

		public virtual void Visit(UnifiedPointerType element) {}

		public virtual void Visit(UnifiedUnionType element) {}

		public virtual void Visit(UnifiedStructType element) {}

		public virtual void Visit(UnifiedVolatileType element) {}

		public virtual void Visit(UnifiedReferenceType element) {}

		public virtual void Visit(UnifiedConstructor element) {}

		public virtual void Visit(UnifiedStaticInitializer element) {}

		public virtual void Visit(UnifiedInstanceInitializer element) {}

		public virtual void Visit(UnifiedLambda element) {}
		public virtual void Visit(UnifiedDefaultConstrain element) {}

		public virtual void Visit(UnifiedExtendConstrain element) {}

		public virtual void Visit(UnifiedImplementsConstrain element) {}

		public virtual void Visit(UnifiedReferenceConstrain element) {}

		public virtual void Visit(UnifiedSuperConstrain element) {}

		public virtual void Visit(UnifiedValueConstrain element) {}

		public virtual void Visit(UnifiedSuperIdentifier element) {}

		public virtual void Visit(UnifiedThisIdentifier element) {}

		public virtual void Visit(UnifiedLabelIdentifier element) {}

		public virtual void Visit(UnifiedSizeof element) {}

		public virtual void Visit(UnifiedTypeof element) {}

		public virtual void Visit(UnifiedVariableIdentifier element) {}

		public virtual void Visit(UnifiedRegularExpressionLiteral element) {}

		public virtual void Visit(UnifiedPropertyDefinition element) {}

		public virtual void Visit(UnifiedPropertyDefinitionPart element) {}

		public virtual void Visit(UnifiedSelectQuery element) {}

		public virtual void Visit(UnifiedWhereQuery element) {}

		public virtual void Visit(UnifiedLetQuery element) {}

		public virtual void Visit(UnifiedOrderByQuery element) {}

		public virtual void Visit(UnifiedJoinQuery element) {}

		public virtual void Visit(UnifiedGroupByQuery element) {}

		public virtual void Visit(UnifiedOrderByKeyCollection element) {}

		public virtual void Visit(UnifiedOrderByKey element) {}

		public virtual void Visit(UnifiedLinqExpression element) {}

		public virtual void Visit(UnifiedDefault element) {}

		public virtual void Visit(UnifiedVaueIdentifier element) {}

		public virtual void Visit(UnifiedEventDefinition element) {}

		public virtual void Visit(UnifiedFromQuery element) {}

		public virtual void Visit(UnifiedProc element) {}

		public virtual void Visit(UnifiedEigenClassDefinition element) {}

		public virtual void Visit(UnifiedEigenConstrain element) {}

		public virtual void Visit(UnifiedRange element) {}

		public virtual void Visit(UnifiedRetry element) {}

		public virtual void Visit(UnifiedRedo element) {}

		public virtual void Visit(UnifiedTypeIdentifier element) {}
	}

	public abstract class EmptyUnifiedVisitor<TArg>
			: IUnifiedVisitor<TArg> {
		public virtual void Visit(UnifiedBinaryOperator element, TArg arg) {}

		public virtual void Visit(UnifiedUnaryOperator element, TArg arg) {}

		public virtual void Visit(UnifiedArgument element, TArg arg) {}

		public virtual void Visit(UnifiedArgumentCollection element, TArg arg) {}

		public virtual void Visit(UnifiedBinaryExpression element, TArg arg) {}

		public virtual void Visit(UnifiedBlock element, TArg arg) {}

		public virtual void Visit(UnifiedCall element, TArg arg) {}

		public virtual void Visit(UnifiedFunctionDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedIf element, TArg arg) {}

		public virtual void Visit(UnifiedParameter element, TArg arg) {}

		public virtual void Visit(UnifiedParameterCollection element, TArg arg) {}

		public virtual void Visit(UnifiedModifier element, TArg arg) {}

		public virtual void Visit(UnifiedModifierCollection element, TArg arg) {}

		public virtual void Visit(UnifiedImport element, TArg arg) {}

		public virtual void Visit(UnifiedProgram element, TArg arg) {}

		public virtual void Visit(UnifiedNew element, TArg arg) {}

		public virtual void Visit(UnifiedFor element, TArg arg) {}

		public virtual void Visit(UnifiedForeach element, TArg arg) {}

		public virtual void Visit(UnifiedUnaryExpression element, TArg arg) {}

		public virtual void Visit(UnifiedProperty element, TArg arg) {}

		public virtual void Visit(
				UnifiedExpressionCollection element, TArg arg) {}

		public virtual void Visit(UnifiedWhile element, TArg arg) {}

		public virtual void Visit(UnifiedDoWhile element, TArg arg) {}

		public virtual void Visit(UnifiedIndexer element, TArg arg) {}

		public virtual void Visit(UnifiedGenericArgument element, TArg arg) {}

		public virtual void Visit(
				UnifiedGenericArgumentCollection element, TArg arg) {}

		public virtual void Visit(UnifiedSwitch element, TArg arg) {}

		public virtual void Visit(UnifiedCaseCollection element, TArg arg) {}

		public virtual void Visit(UnifiedCase element, TArg arg) {}

		public virtual void Visit(UnifiedCatch element, TArg arg) {}

		public virtual void Visit(UnifiedTypeCollection element, TArg arg) {}

		public virtual void Visit(UnifiedCatchCollection element, TArg arg) {}

		public virtual void Visit(UnifiedTry element, TArg arg) {}

		public virtual void Visit(UnifiedCast element, TArg arg) {}

		public virtual void Visit(
				UnifiedGenericParameterCollection element, TArg arg) {}

		public virtual void Visit(
				UnifiedTypeConstrainCollection element, TArg arg) {}

		public virtual void Visit(UnifiedGenericParameter element, TArg arg) {}

		public virtual void Visit(UnifiedTernaryExpression element, TArg arg) {}

		public virtual void Visit(
				UnifiedIdentifierCollection element, TArg arg) {}

		public virtual void Visit(UnifiedLabel element, TArg arg) {}

		public virtual void Visit(UnifiedBooleanLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedFractionLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedBigIntLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedInt8Literal element, TArg arg) {}

		public virtual void Visit(UnifiedInt16Literal element, TArg arg) {}

		public virtual void Visit(UnifiedInt31Literal element, TArg arg) {}

		public virtual void Visit(UnifiedInt32Literal element, TArg arg) {}

		public virtual void Visit(UnifiedInt64Literal element, TArg arg) {}

		public virtual void Visit(UnifiedUInt8Literal element, TArg arg) {}

		public virtual void Visit(UnifiedUInt16Literal element, TArg arg) {}

		public virtual void Visit(UnifiedUInt31Literal element, TArg arg) {}

		public virtual void Visit(UnifiedUInt32Literal element, TArg arg) {}

		public virtual void Visit(UnifiedUInt64Literal element, TArg arg) {}

		public virtual void Visit(UnifiedStringLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedNullLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedUsing element, TArg arg) {}

		public virtual void Visit(UnifiedListComprehension element, TArg arg) {}

		public virtual void Visit(UnifiedListLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedKeyValue element, TArg arg) {}

		public virtual void Visit(
				UnifiedMapComprehension element, TArg arg) {}

		public virtual void Visit(UnifiedMapLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedSlice element, TArg arg) {}

		public virtual void Visit(UnifiedComment element, TArg arg) {}

		public virtual void Visit(UnifiedAnnotation element, TArg arg) {}

		public virtual void Visit(
				UnifiedAnnotationCollection element, TArg arg) {}

		public virtual void Visit(
				UnifiedVariableDefinitionList element, TArg arg) {}

		public virtual void Visit(UnifiedVariableDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedArrayType element, TArg arg) {}

		public virtual void Visit(UnifiedGenericType element, TArg arg) {}

		public virtual void Visit(UnifiedBasicType element, TArg arg) {}

		public virtual void Visit(UnifiedCharLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedIterableLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedArrayLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedSetLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedTupleLiteral element, TArg arg) {}

		public virtual void Visit(
				UnifiedIterableComprehension element, TArg arg) {}

		public virtual void Visit(UnifiedSetComprehension element, TArg arg) {}

		public virtual void Visit(UnifiedInterfaceDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedClassDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedStructDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedEnumDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedModuleDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedUnionDefinition element, TArg arg) {}

		public virtual void Visit(
				UnifiedAnnotationDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedNamespaceDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedBreak element, TArg arg) {}

		public virtual void Visit(UnifiedContinue element, TArg arg) {}

		public virtual void Visit(UnifiedReturn element, TArg arg) {}

		public virtual void Visit(UnifiedGoto element, TArg arg) {}

		public virtual void Visit(UnifiedYieldReturn element, TArg arg) {}

		public virtual void Visit(UnifiedYieldBreak element, TArg arg) {}

		public virtual void Visit(UnifiedDelete element, TArg arg) {}

		public virtual void Visit(UnifiedThrow element, TArg arg) {}

		public virtual void Visit(UnifiedAssert element, TArg arg) {}

		public virtual void Visit(UnifiedExec element, TArg arg) {}

		public virtual void Visit(UnifiedStringConversion element, TArg arg) {}

		public virtual void Visit(UnifiedPass element, TArg arg) {}

		public virtual void Visit(UnifiedPrint element, TArg arg) {}

		public virtual void Visit(UnifiedPrintChevron element, TArg arg) {}

		public virtual void Visit(UnifiedWith element, TArg arg) {}

		public virtual void Visit(UnifiedFix element, TArg arg) {}

		public virtual void Visit(UnifiedSynchronized element, TArg arg) {}

		public virtual void Visit(UnifiedConstType element, TArg arg) {}

		public virtual void Visit(UnifiedPointerType element, TArg arg) {}

		public virtual void Visit(UnifiedUnionType element, TArg arg) {}

		public virtual void Visit(UnifiedStructType element, TArg arg) {}

		public virtual void Visit(UnifiedVolatileType element, TArg arg) {}

		public virtual void Visit(UnifiedReferenceType element, TArg arg) {}

		public virtual void Visit(UnifiedConstructor element, TArg arg) {}

		public virtual void Visit(UnifiedStaticInitializer element, TArg arg) {}

		public virtual void Visit(UnifiedInstanceInitializer element, TArg arg) {}

		public virtual void Visit(UnifiedLambda element, TArg arg) {}
		public virtual void Visit(UnifiedDefaultConstrain element, TArg arg) {}

		public virtual void Visit(UnifiedExtendConstrain element, TArg arg) {}

		public virtual void Visit(UnifiedImplementsConstrain element, TArg arg) {}

		public virtual void Visit(UnifiedReferenceConstrain element, TArg arg) {}

		public virtual void Visit(UnifiedSuperConstrain element, TArg arg) {}

		public virtual void Visit(UnifiedValueConstrain element, TArg arg) {}

		public virtual void Visit(UnifiedSuperIdentifier element, TArg arg) {}

		public virtual void Visit(UnifiedThisIdentifier element, TArg arg) {}

		public virtual void Visit(UnifiedLabelIdentifier element, TArg arg) {}

		public virtual void Visit(UnifiedSizeof element, TArg arg) {}

		public virtual void Visit(UnifiedTypeof element, TArg arg) {}

		public virtual void Visit(UnifiedVariableIdentifier element, TArg arg) {}

		public virtual void Visit(
				UnifiedRegularExpressionLiteral element, TArg arg) {}

		public virtual void Visit(UnifiedPropertyDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedPropertyDefinitionPart element, TArg arg) {}

		public virtual void Visit(UnifiedSelectQuery element, TArg arg) {}

		public virtual void Visit(UnifiedWhereQuery element, TArg arg) {}

		public virtual void Visit(UnifiedLetQuery element, TArg arg) {}

		public virtual void Visit(UnifiedOrderByQuery element, TArg arg) {}

		public virtual void Visit(UnifiedJoinQuery element, TArg arg) {}

		public virtual void Visit(UnifiedGroupByQuery element, TArg arg) {}

		public virtual void Visit(UnifiedOrderByKeyCollection element, TArg arg) {}

		public virtual void Visit(UnifiedOrderByKey element, TArg arg) {}

		public virtual void Visit(UnifiedLinqExpression element, TArg arg) {}

		public virtual void Visit(UnifiedDefault element, TArg arg) {}

		public virtual void Visit(UnifiedVaueIdentifier element, TArg arg) {}

		public virtual void Visit(UnifiedEventDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedFromQuery element, TArg arg) {}

		public virtual void Visit(UnifiedProc element, TArg arg) {}

		public virtual void Visit(UnifiedEigenClassDefinition element, TArg arg) {}

		public virtual void Visit(UnifiedEigenConstrain element, TArg arg) {}

		public virtual void Visit(UnifiedRange element, TArg arg) {}

		public virtual void Visit(UnifiedRedo element, TArg arg) {}

		public virtual void Visit(UnifiedRetry element, TArg arg) {}

		public virtual void Visit(UnifiedTypeIdentifier element, TArg arg) {}
			}

	public abstract class EmptyUnifiedVisitor<TArg, TResult>
			: IUnifiedVisitor<TArg, TResult> {
		public virtual TResult Visit(UnifiedBinaryOperator element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPropertyDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPropertyDefinitionPart element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSelectQuery element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedWhereQuery element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLetQuery element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedOrderByQuery element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedJoinQuery element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGroupByQuery element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedOrderByKeyCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedOrderByKey element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLinqExpression element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDefault element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedVaueIdentifier element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedEventDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFromQuery element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedProc element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedEigenClassDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedEigenConstrain element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedRange element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedRedo element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedRetry element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnaryOperator element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedArgument element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedArgumentCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBinaryExpression element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBlock element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCall element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFunctionDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIf element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedParameter element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedParameterCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedModifier element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedModifierCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedImport element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedProgram element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedNew element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFor element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedForeach element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnaryExpression element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedProperty element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedExpressionCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedWhile element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDoWhile element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIndexer element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGenericArgument element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedGenericArgumentCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSwitch element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCaseCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCase element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCatch element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTypeCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCatchCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTry element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCast element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedGenericParameterCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTypeConstrainCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGenericParameter element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTernaryExpression element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIdentifierCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLabel element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBooleanLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFractionLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBigIntLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt8Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt16Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt31Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt32Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInt64Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt8Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt16Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt31Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt32Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUInt64Literal element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStringLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedNullLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUsing element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedListComprehension element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedListLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedKeyValue element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedMapComprehension element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedMapLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSlice element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedComment element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedAnnotation element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedAnnotationCollection element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedVariableDefinitionList element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedVariableDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedArrayType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGenericType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBasicType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedCharLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIterableLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedArrayLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSetLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTupleLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedIterableComprehension element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSetComprehension element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInterfaceDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedClassDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStructDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedEnumDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedModuleDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnionDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedAnnotationDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedNamespaceDefinition element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedBreak element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedContinue element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedReturn element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedGoto element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedYieldReturn element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedYieldBreak element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDelete element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedThrow element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedAssert element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedExec element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStringConversion element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPass element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPrint element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPrintChevron element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedWith element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedFix element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSynchronized element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedConstType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedPointerType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedUnionType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedVolatileType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStructType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedReferenceType element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedConstructor element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedStaticInitializer element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedInstanceInitializer element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLambda element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedDefaultConstrain element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedExtendConstrain element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedImplementsConstrain element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedReferenceConstrain element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSuperConstrain element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedValueConstrain element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSuperIdentifier element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedThisIdentifier element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedLabelIdentifier element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedSizeof element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTypeof element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedVariableIdentifier element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(
				UnifiedRegularExpressionLiteral element, TArg arg) {
			return default(TResult);
		}

		public virtual TResult Visit(UnifiedTypeIdentifier element, TArg arg) {
			return default(TResult);
		}
			}
}