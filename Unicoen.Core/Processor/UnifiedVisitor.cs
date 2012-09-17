#region License

// Copyright (C) 2011-2012 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License") { throw new NotImplementedException(); }
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
using System;

namespace Unicoen.Processor {
	public class UnifiedVisitor {
		public virtual void Visit(UnifiedBinaryOperator element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnaryOperator element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedArgument element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBinaryExpression element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBlock element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCall element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFunctionDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIf element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedParameter element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedModifier element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedImport element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedProgram element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedNew element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFor element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedForeach element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnaryExpression element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedProperty element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedWhile element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDoWhile element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIndexer element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGenericArgument element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSwitch element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCase element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCatch element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTry element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCast element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGenericParameter element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTernaryExpression element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLabel element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBooleanLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFractionLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBigIntLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt8Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt16Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt31Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt32Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt64Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt8Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt16Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt31Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt32Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt64Literal element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStringLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedNullLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUsing element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedListComprehension element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedListLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedKeyValue element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedMapComprehension element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedMapLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSlice element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedComment element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAnnotation element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVariableDefinitionList element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVariableDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedArrayType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGenericType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBasicType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCharLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIterableLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedArrayLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSetLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTupleLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIterableComprehension element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSetComprehension element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInterfaceDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedClassDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStructDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEnumDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedModuleDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnionDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAnnotationDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedNamespaceDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBreak element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedContinue element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedReturn element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGoto element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedYieldReturn element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedYieldBreak element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDelete element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedThrow element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAssert element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedExec element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStringConversion element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPass element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPrint element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPrintChevron element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedWith element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFix element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSynchronized element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedConstType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPointerType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnionType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStructType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVolatileType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedReferenceType element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedConstructor element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStaticInitializer element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInstanceInitializer element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLambda element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedConstructorConstrain element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedExtendConstrain element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedImplementsConstrain element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedClassConstrain element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSuperConstrain element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStructConstrain element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSuperIdentifier element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedThisIdentifier element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLabelIdentifier element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSizeof element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTypeof element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVariableIdentifier element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTypeIdentifier element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRegularExpressionLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPropertyDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPropertyDefinitionPart element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSelectQuery element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedWhereQuery element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLetQuery element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedOrderByQuery element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedJoinQuery element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGroupByQuery element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedOrderByKey element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLinqExpression element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDefault element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedValueIdentifier element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEventDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFromQuery element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedProc element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEigenClassDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEigenConstrain element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRange element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRetry element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRedo element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSymbolLiteral element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDefined element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAlias element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUncheckedBlock element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCheckedBlock element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDelegateDefinition element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDestructor element) { throw new NotImplementedException(); }

		public void Visit<TElement>(UnifiedSet<TElement> element)
				where TElement : UnifiedElement {
					if (element is UnifiedSet<UnifiedAnnotation>)
					{
						Visit(element as UnifiedSet<UnifiedAnnotation>);
					}
					else if (element is UnifiedSet<UnifiedArgument>)
					{
						Visit(element as UnifiedSet<UnifiedArgument>);
					}
					else if (element is UnifiedSet<UnifiedCase>)
					{
						Visit(element as UnifiedSet<UnifiedCase>);
					}
					else if (element is UnifiedSet<UnifiedCatch>)
					{
						Visit(element as UnifiedSet<UnifiedCatch>);
					}
					else if (element is UnifiedSet<UnifiedComment>)
					{
						Visit(element as UnifiedSet<UnifiedComment>);
					}
					else if (element is UnifiedSet<UnifiedExpression>)
					{
						Visit(element as UnifiedSet<UnifiedExpression>);
					}
					else if (element is UnifiedSet<UnifiedGenericArgument>)
					{
						Visit(element as UnifiedSet<UnifiedGenericArgument>);
					}
					else if (element is UnifiedSet<UnifiedGenericParameter>)
					{
						Visit(element as UnifiedSet<UnifiedGenericParameter>);
					}
					else if (element is UnifiedSet<UnifiedIdentifier>)
					{
						Visit(element as UnifiedSet<UnifiedIdentifier>);
					}
					else if (element is UnifiedSet<UnifiedModifier>)
					{
						Visit(element as UnifiedSet<UnifiedModifier>);
					}
					else if (element is UnifiedSet<UnifiedOrderByKey>)
					{
						Visit(element as UnifiedSet<UnifiedOrderByKey>);
					}
					else if (element is UnifiedSet<UnifiedParameter>)
					{
						Visit(element as UnifiedSet<UnifiedParameter>);
					}
					else if (element is UnifiedSet<UnifiedType>)
					{
						Visit(element as UnifiedSet<UnifiedType>);
					}
					else if (element is UnifiedSet<UnifiedTypeConstrain>)
					{
						Visit(element as UnifiedSet<UnifiedTypeConstrain>);
					}
					else
					{
						throw new IndexOutOfRangeException("Not supported UnifiedSet.");
					}
		}

		public virtual void Visit(UnifiedSet<UnifiedAnnotation> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedArgument> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedCase> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedCatch> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedComment> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedExpression> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedGenericArgument> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedGenericParameter> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedIdentifier> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedModifier> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedOrderByKey> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedParameter> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedType> element) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedTypeConstrain> element) { throw new NotImplementedException(); }
	}

	public class UnifiedVisitor<TArg> {
		public virtual void Visit(UnifiedBinaryOperator element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnaryOperator element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedArgument element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBinaryExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBlock element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCall element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFunctionDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIf element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedParameter element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedModifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedImport element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedProgram element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedNew element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFor element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedForeach element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnaryExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedProperty element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedWhile element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDoWhile element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIndexer element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGenericArgument element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSwitch element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCase element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCatch element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTry element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGenericParameter element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTernaryExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCast element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLabel element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBooleanLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFractionLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBigIntLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt8Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt16Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt31Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt32Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInt64Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt8Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt16Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt31Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt32Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUInt64Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStringLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedNullLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUsing element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedListComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedListLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedKeyValue element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedMapComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedMapLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSlice element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedComment element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAnnotation element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVariableDefinitionList element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVariableDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedArrayType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGenericType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBasicType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCharLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIterableLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedArrayLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSetLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTupleLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedIterableComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSetComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInterfaceDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedClassDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStructDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEnumDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedModuleDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnionDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAnnotationDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedNamespaceDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedBreak element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedContinue element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedReturn element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGoto element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedYieldReturn element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedYieldBreak element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDelete element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedThrow element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAssert element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedExec element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStringConversion element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPass element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPrint element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPrintChevron element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedWith element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFix element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSynchronized element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedConstType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPointerType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUnionType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStructType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVolatileType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedReferenceType element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedConstructor element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStaticInitializer element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedInstanceInitializer element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLambda element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedConstructorConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedExtendConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedImplementsConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedClassConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSuperConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedStructConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSuperIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedThisIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLabelIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSizeof element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTypeof element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedVariableIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedTypeIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRegularExpressionLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPropertyDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedPropertyDefinitionPart element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSelectQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedWhereQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLetQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedOrderByQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedJoinQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedGroupByQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedOrderByKey element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedLinqExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDefault element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedValueIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEventDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedFromQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedProc element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEigenClassDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedEigenConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRange element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRedo element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedRetry element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSymbolLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDefined element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedAlias element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedUncheckedBlock element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedCheckedBlock element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDelegateDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedDestructor element, TArg arg) { throw new NotImplementedException(); }

		public virtual void Visit<TElement>(UnifiedSet<TElement> element, TArg arg)
				where TElement : UnifiedElement
		{
					if (element is UnifiedSet<UnifiedAnnotation>)
					{
						Visit(element as UnifiedSet<UnifiedAnnotation>, arg);
					}
					else if (element is UnifiedSet<UnifiedArgument>)
					{
						Visit(element as UnifiedSet<UnifiedArgument>, arg);
					}
					else if (element is UnifiedSet<UnifiedCase>)
					{
						Visit(element as UnifiedSet<UnifiedCase>, arg);
					}
					else if (element is UnifiedSet<UnifiedCatch>)
					{
						Visit(element as UnifiedSet<UnifiedCatch>, arg);
					}
					else if (element is UnifiedSet<UnifiedComment>)
					{
						Visit(element as UnifiedSet<UnifiedComment>, arg);
					}
					else if (element is UnifiedSet<UnifiedExpression>)
					{
						Visit(element as UnifiedSet<UnifiedExpression>, arg);
					}
					else if (element is UnifiedSet<UnifiedGenericArgument>)
					{
						Visit(element as UnifiedSet<UnifiedGenericArgument>, arg);
					}
					else if (element is UnifiedSet<UnifiedGenericParameter>)
					{
						Visit(element as UnifiedSet<UnifiedGenericParameter>, arg);
					}
					else if (element is UnifiedSet<UnifiedIdentifier>)
					{
						Visit(element as UnifiedSet<UnifiedIdentifier>, arg);
					}
					else if (element is UnifiedSet<UnifiedModifier>)
					{
						Visit(element as UnifiedSet<UnifiedModifier>, arg);
					}
					else if (element is UnifiedSet<UnifiedOrderByKey>)
					{
						Visit(element as UnifiedSet<UnifiedOrderByKey>, arg);
					}
					else if (element is UnifiedSet<UnifiedParameter>)
					{
						Visit(element as UnifiedSet<UnifiedParameter>, arg);
					}
					else if (element is UnifiedSet<UnifiedType>)
					{
						Visit(element as UnifiedSet<UnifiedType>, arg);
					}
					else if (element is UnifiedSet<UnifiedTypeConstrain>)
					{
						Visit(element as UnifiedSet<UnifiedTypeConstrain>, arg);
					}
					else
					{
						throw new IndexOutOfRangeException("Not supported UnifiedSet.");
					}
		}
		public virtual void Visit(UnifiedSet<UnifiedAnnotation> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedGenericParameter> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedTypeConstrain> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedIdentifier> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedArgument> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedParameter> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedModifier> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedExpression> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedGenericArgument> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedCase> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedType> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedCatch> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedOrderByKey> element, TArg arg) { throw new NotImplementedException(); }
		public virtual void Visit(UnifiedSet<UnifiedComment> element, TArg arg) { throw new NotImplementedException(); }

	}

	public class UnifiedVisitor<TArg, TResult> {
		public virtual TResult Visit(UnifiedBinaryOperator element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUnaryOperator element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedArgument element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedBinaryExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedBlock element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedCall element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedFunctionDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedIf element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedParameter element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedModifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedImport element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedProgram element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedNew element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedFor element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedForeach element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUnaryExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedProperty element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedWhile element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedDoWhile element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedIndexer element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedGenericArgument element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSwitch element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedCase element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedCatch element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedTry element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedCast element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedGenericParameter element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedTernaryExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedLabel element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedBooleanLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedFractionLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedBigIntLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedInt8Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedInt16Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedInt31Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedInt32Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedInt64Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUInt8Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUInt16Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUInt31Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUInt32Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUInt64Literal element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedStringLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedNullLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUsing element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedListComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedListLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedKeyValue element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedMapComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedMapLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSlice element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedComment element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedAnnotation element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedVariableDefinitionList element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedVariableDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedArrayType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedGenericType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedBasicType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedCharLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedIterableLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedArrayLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSetLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedTupleLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedIterableComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSetComprehension element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedInterfaceDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedClassDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedStructDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedEnumDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedModuleDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUnionDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedAnnotationDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedNamespaceDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedBreak element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedContinue element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedReturn element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedGoto element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedYieldReturn element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedYieldBreak element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedDelete element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedThrow element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedAssert element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedExec element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedStringConversion element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedPass element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedPrint element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedPrintChevron element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedWith element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedFix element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSynchronized element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedConstType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedPointerType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUnionType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedVolatileType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedStructType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedReferenceType element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedConstructor element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedStaticInitializer element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedInstanceInitializer element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedLambda element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedConstructorConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedExtendConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedImplementsConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedClassConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSuperConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedStructConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSuperIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedThisIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedLabelIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSizeof element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedTypeof element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedVariableIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedTypeIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedRegularExpressionLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedPropertyDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedPropertyDefinitionPart element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSelectQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedWhereQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedLetQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedOrderByQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedJoinQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedGroupByQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedOrderByKey element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedLinqExpression element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedDefault element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedValueIdentifier element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedEventDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedFromQuery element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedProc element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedEigenClassDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedEigenConstrain element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedRange element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedRedo element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedRetry element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSymbolLiteral element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedDefined element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedAlias element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedUncheckedBlock element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedCheckedBlock element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedDelegateDefinition element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedDestructor element, TArg arg) { throw new NotImplementedException(); }

		public virtual TResult Visit<TElement>(UnifiedSet<TElement> element, TArg arg)
				where TElement : UnifiedElement
		{
					if (element is UnifiedSet<UnifiedAnnotation>)
					{
						return Visit(element as UnifiedSet<UnifiedAnnotation>, arg);
					}
					else if (element is UnifiedSet<UnifiedArgument>)
					{
						return Visit(element as UnifiedSet<UnifiedArgument>, arg);
					}
					else if (element is UnifiedSet<UnifiedCase>)
					{
						return Visit(element as UnifiedSet<UnifiedCase>, arg);
					}
					else if (element is UnifiedSet<UnifiedCatch>)
					{
						return Visit(element as UnifiedSet<UnifiedCatch>, arg);
					}
					else if (element is UnifiedSet<UnifiedComment>)
					{
						return Visit(element as UnifiedSet<UnifiedComment>, arg);
					}
					else if (element is UnifiedSet<UnifiedExpression>)
					{
						return Visit(element as UnifiedSet<UnifiedExpression>, arg);
					}
					else if (element is UnifiedSet<UnifiedGenericArgument>)
					{
						return Visit(element as UnifiedSet<UnifiedGenericArgument>, arg);
					}
					else if (element is UnifiedSet<UnifiedGenericParameter>)
					{
						return Visit(element as UnifiedSet<UnifiedGenericParameter>, arg);
					}
					else if (element is UnifiedSet<UnifiedIdentifier>)
					{
						return Visit(element as UnifiedSet<UnifiedIdentifier>, arg);
					}
					else if (element is UnifiedSet<UnifiedModifier>)
					{
						return Visit(element as UnifiedSet<UnifiedModifier>, arg);
					}
					else if (element is UnifiedSet<UnifiedOrderByKey>)
					{
						return Visit(element as UnifiedSet<UnifiedOrderByKey>, arg);
					}
					else if (element is UnifiedSet<UnifiedParameter>)
					{
						return Visit(element as UnifiedSet<UnifiedParameter>, arg);
					}
					else if (element is UnifiedSet<UnifiedType>)
					{
						return Visit(element as UnifiedSet<UnifiedType>, arg);
					}
					else if (element is UnifiedSet<UnifiedTypeConstrain>)
					{
						return Visit(element as UnifiedSet<UnifiedTypeConstrain>, arg);
					}
					else
					{
						throw new IndexOutOfRangeException("Not supported UnifiedSet.");
					}
		}
		public virtual TResult Visit(UnifiedSet<UnifiedComment> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedOrderByKey> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedIdentifier> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedCase> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedExpression> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedGenericArgument> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedArgument> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedParameter> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedModifier> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedType> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedCatch> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedGenericParameter> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedTypeConstrain> element, TArg arg) { throw new NotImplementedException(); }
		public virtual TResult Visit(UnifiedSet<UnifiedAnnotation> element, TArg arg) { throw new NotImplementedException(); }

	}
}