﻿#region License

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
using Unicoen.Core.Model;
using Unicoen.Core.Model.Expressions;

namespace Unicoen.Core.Processor {
	public abstract class ExplicitDefaultUnifiedVisitor : IUnifiedVisitor {
		public virtual void Visit(UnifiedBinaryOperator element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnaryOperator element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArgument element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArgumentCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBinaryExpression element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBlock element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCall element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFunctionDefinition element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIf element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedParameter element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedParameterCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedModifier element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedModifierCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedImport element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedProgram element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedNew element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFor element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedForeach element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnaryExpression element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedProperty element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedExpressionCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedWhile element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDoWhile element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIndexer element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGenericArgument element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGenericArgumentCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSwitch element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCaseCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCase element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCatch element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTypeCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCatchCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTry element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCast element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGenericParameterCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTypeConstrainCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTypeParameter element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTernaryExpression element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIdentifierCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLabel element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBooleanLiteral element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFractionLiteral element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIntegerLiteral element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStringLiteral element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedNullLiteral element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedMatcher element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedMatcherCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUsing element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedListComprehension element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedList element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedKeyValue element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDictionaryComprehension element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDictionary element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSlice element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedComment element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedAnnotation element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedAnnotationCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedVariableDefinitionList element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedVariableDefinition element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArrayType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGenericType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSimpleType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCharLiteral element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIterable element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArray element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSet element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTuple element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIterableComprehension element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSetComprehension element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedInterface element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedClass element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStruct element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedEnum element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedModule element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnion element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedAnnotationDefinition element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedNamespace element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBreak element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedContinue element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedReturn element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGoto element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedYieldReturn element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDelete element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedThrow element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedAssert element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedExec element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStringConversion element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPass element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPrint element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPrintChevron element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedWith element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFix element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSynchronized element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedConstType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPointerType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnionType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStructType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedVolatileType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedReferenceType element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedConstructor element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStaticInitializer element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedInstanceInitializer element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLambda element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDefaultConstrain element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedExtendConstrain element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedImplementsConstrain element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedReferenceConstrain element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSuperConstrain element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedValueConstrain element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSuperIdentifier element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedThisIdentifier element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLabelIdentifier element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSizeof element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTypeof element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedVariableIdentifier element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedRegularExpressionLiteral element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPropertyDefinition element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPropertyBody element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSelect element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedWhere element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedInto element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLet element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedOrderBy element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedJoin element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGroupBy element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedOrderByKeyCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedOrderByKey element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLinqElementCollection element) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLinq element) {
			throw new NotImplementedException();
		}
	}

	public abstract class ExplicitDefaultUnifiedVisitor<TArg>
			: IUnifiedVisitor<TArg> {
		public virtual void Visit(UnifiedBinaryOperator element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnaryOperator element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArgument element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArgumentCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBinaryExpression element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBlock element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCall element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFunctionDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIf element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedParameter element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedParameterCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedModifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedModifierCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedImport element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedProgram element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedNew element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFor element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedForeach element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnaryExpression element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedProperty element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedExpressionCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedWhile element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDoWhile element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIndexer element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGenericArgument element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedGenericArgumentCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSwitch element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCaseCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCase element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCatch element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTypeCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCatchCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTry element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCast element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedGenericParameterCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedTypeConstrainCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTypeParameter element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTernaryExpression element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedIdentifierCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLabel element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBooleanLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFractionLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIntegerLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStringLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedNullLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedMatcher element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedMatcherCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUsing element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedListComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedList element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedKeyValue element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedDictionaryComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDictionary element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSlice element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedComment element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedAnnotation element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedAnnotationCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedVariableDefinitionList element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedVariableDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArrayType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGenericType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSimpleType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedCharLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedIterable element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedArray element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSet element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTuple element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedIterableComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSetComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedInterface element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedClass element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStruct element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedEnum element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedModule element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnion element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedAnnotationDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedNamespace element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedBreak element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedContinue element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedReturn element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGoto element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedYieldReturn element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDelete element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedThrow element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedAssert element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedExec element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStringConversion element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPass element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPrint element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPrintChevron element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedWith element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedFix element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSynchronized element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedConstType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPointerType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedUnionType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStructType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedVolatileType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedReferenceType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedConstructor element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedStaticInitializer element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedInstanceInitializer element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLambda element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedDefaultConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedExtendConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedImplementsConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedReferenceConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSuperConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedValueConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSuperIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedThisIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLabelIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSizeof element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedTypeof element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedVariableIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(
				UnifiedRegularExpressionLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPropertyDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedPropertyBody element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedSelect element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedWhere element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedInto element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLet element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedOrderBy element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedJoin element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedGroupBy element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedOrderByKeyCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedOrderByKey element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLinqElementCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual void Visit(UnifiedLinq element, TArg arg) {
			throw new NotImplementedException();
		}
			}

	public abstract class ExplicitDefaultUnifiedVisitor<TArg, TResult>
			: IUnifiedVisitor<TArg, TResult> {
		public virtual TResult Visit(UnifiedBinaryOperator element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedPropertyDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedPropertyBody element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSelect element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedWhere element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedInto element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedLet element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedOrderBy element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedJoin element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedGroupBy element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedOrderByKeyCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedOrderByKey element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedLinqElementCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedLinq element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedUnaryOperator element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedArgument element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedArgumentCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedBinaryExpression element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedBlock element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedCall element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedFunctionDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedIf element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedParameter element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedParameterCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedModifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedModifierCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedImport element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedProgram element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedNew element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedFor element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedForeach element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedUnaryExpression element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedProperty element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedExpressionCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedWhile element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedDoWhile element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedIndexer element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedGenericArgument element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(
				UnifiedGenericArgumentCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSwitch element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedCaseCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedCase element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedCatch element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedTypeCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedCatchCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedTry element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedCast element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(
				UnifiedGenericParameterCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedTypeConstrainCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedTypeParameter element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedTernaryExpression element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedIdentifierCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedLabel element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedBooleanLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedFractionLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedIntegerLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedStringLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedNullLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedMatcher element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedMatcherCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedUsing element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedListComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedList element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedKeyValue element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedDictionaryComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedDictionary element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSlice element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedComment element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedAnnotation element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedAnnotationCollection element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedVariableDefinitionList element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedVariableDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedArrayType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedGenericType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSimpleType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedCharLiteral element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedIterable element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedArray element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSet element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedTuple element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedIterableComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSetComprehension element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedInterface element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedClass element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedStruct element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedEnum element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedModule element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedUnion element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedAnnotationDefinition element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedNamespace element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedBreak element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedContinue element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedReturn element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedGoto element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedYieldReturn element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedDelete element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedThrow element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedAssert element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedExec element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedStringConversion element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedPass element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedPrint element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedPrintChevron element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedWith element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedFix element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSynchronized element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedConstType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedPointerType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedUnionType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedVolatileType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedStructType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedReferenceType element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedConstructor element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedStaticInitializer element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedInstanceInitializer element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedLambda element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedDefaultConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedExtendConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedImplementsConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedReferenceConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSuperConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedValueConstrain element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSuperIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedThisIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedLabelIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedSizeof element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedTypeof element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(UnifiedVariableIdentifier element, TArg arg) {
			throw new NotImplementedException();
		}

		public virtual TResult Visit(
				UnifiedRegularExpressionLiteral element, TArg arg) {
			throw new NotImplementedException();
		}
			}
}