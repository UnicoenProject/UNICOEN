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

using Unicoen.Core.Model;

namespace Unicoen.Core.Visitors {
	public interface IUnifiedModelVisitor {
		void Visit(UnifiedBinaryOperator element);
		void Visit(UnifiedUnaryOperator element);
		void Visit(UnifiedArgument element);
		void Visit(UnifiedArgumentCollection element);
		void Visit(UnifiedBinaryExpression element);
		void Visit(UnifiedBlock element);
		void Visit(UnifiedCall element);
		void Visit(UnifiedFunctionDefinition element);
		void Visit(UnifiedIf element);
		void Visit(UnifiedParameter element);
		void Visit(UnifiedParameterCollection element);
		void Visit(UnifiedIdentifier element);
		void Visit(UnifiedModifier element);
		void Visit(UnifiedModifierCollection element);
		void Visit(UnifiedImport element);
		void Visit(UnifiedConstructorDefinition element);
		void Visit(UnifiedProgram element);
		void Visit(UnifiedClassDefinition element);
		void Visit(UnifiedNew element);
		void Visit(UnifiedFor element);
		void Visit(UnifiedForeach element);
		void Visit(UnifiedUnaryExpression element);
		void Visit(UnifiedProperty element);
		void Visit(UnifiedExpressionCollection element);
		void Visit(UnifiedWhile element);
		void Visit(UnifiedDoWhile element);
		void Visit(UnifiedIndexer element);
		void Visit(UnifiedTypeArgument element);
		void Visit(UnifiedTypeArgumentCollection element);
		void Visit(UnifiedSwitch element);
		void Visit(UnifiedCaseCollection element);
		void Visit(UnifiedCase element);
		void Visit(UnifiedSpecialExpression element);
		void Visit(UnifiedSpecialBlock element);
		void Visit(UnifiedCatch element);
		void Visit(UnifiedTypeCollection element);
		void Visit(UnifiedCatchCollection element);
		void Visit(UnifiedTry element);
		void Visit(UnifiedCast element);
		void Visit(UnifiedTypeParameterCollection element);
		void Visit(UnifiedTypeConstrain element);
		void Visit(UnifiedTypeConstrainCollection element);
		void Visit(UnifiedTypeParameter element);
		void Visit(UnifiedTypeSupplement element);
		void Visit(UnifiedTypeSupplementCollection element);
		void Visit(UnifiedTernaryExpression element);
		void Visit(UnifiedIdentifierCollection element);
		void Visit(UnifiedLabel element);
		void Visit(UnifiedExpressionList element);
		void Visit(UnifiedBooleanLiteral element);
		void Visit(UnifiedFractionLiteral element);
		void Visit(UnifiedIntegerLiteral element);
		void Visit(UnifiedStringLiteral element);
		void Visit(UnifiedNullLiteral element);
		void Visit(UnifiedMatcher element);
		void Visit(UnifiedMatcherCollection element);
		void Visit(UnifiedUsing element);
		void Visit(UnifiedListComprehension element);
		void Visit(UnifiedList element);
		void Visit(UnifiedKeyValue element);
		void Visit(UnifiedDictionaryComprehension element);
		void Visit(UnifiedKeyValueCollection element);
		void Visit(UnifiedDictonary element);
		void Visit(UnifiedSlice element);
		void Visit(UnifiedComment element);
		void Visit(UnifiedAnnotation element);
		void Visit(UnifiedAnnotationCollection element);
		void Visit(UnifiedVariableDefinitionList element);
		void Visit(UnifiedVariableDefinition element);
		void Visit(UnifiedArrayType element);
		void Visit(UnifiedSupplementType element);
		void Visit(UnifiedGenericType element);
		void Visit(UnifiedSimpleType element);
	}

	public interface IUnifiedModelVisitor<in TState> {
		void Visit(UnifiedBinaryOperator element, TState state);
		void Visit(UnifiedUnaryOperator element, TState state);
		void Visit(UnifiedArgument element, TState state);
		void Visit(UnifiedArgumentCollection element, TState state);
		void Visit(UnifiedBinaryExpression element, TState state);
		void Visit(UnifiedBlock element, TState state);
		void Visit(UnifiedCall element, TState state);
		void Visit(UnifiedFunctionDefinition element, TState state);
		void Visit(UnifiedIf element, TState state);
		void Visit(UnifiedParameter element, TState state);
		void Visit(UnifiedParameterCollection element, TState state);
		void Visit(UnifiedIdentifier element, TState state);
		void Visit(UnifiedModifier element, TState state);
		void Visit(UnifiedModifierCollection element, TState state);
		void Visit(UnifiedImport element, TState state);
		void Visit(UnifiedConstructorDefinition element, TState state);
		void Visit(UnifiedProgram element, TState state);
		void Visit(UnifiedClassDefinition element, TState state);
		void Visit(UnifiedNew element, TState state);
		void Visit(UnifiedFor element, TState state);
		void Visit(UnifiedForeach element, TState state);
		void Visit(UnifiedUnaryExpression element, TState state);
		void Visit(UnifiedProperty element, TState state);
		void Visit(UnifiedExpressionCollection element, TState state);
		void Visit(UnifiedWhile element, TState state);
		void Visit(UnifiedDoWhile element, TState state);
		void Visit(UnifiedIndexer element, TState state);
		void Visit(UnifiedTypeArgument element, TState state);
		void Visit(UnifiedTypeArgumentCollection element, TState state);
		void Visit(UnifiedSwitch element, TState state);
		void Visit(UnifiedCaseCollection element, TState state);
		void Visit(UnifiedCase element, TState state);
		void Visit(UnifiedSpecialExpression element, TState state);
		void Visit(UnifiedSpecialBlock element, TState state);
		void Visit(UnifiedCatch element, TState state);
		void Visit(UnifiedTypeCollection element, TState state);
		void Visit(UnifiedCatchCollection element, TState state);
		void Visit(UnifiedTry element, TState state);
		void Visit(UnifiedCast element, TState state);
		void Visit(UnifiedTypeParameterCollection element, TState state);
		void Visit(UnifiedTypeConstrain element, TState state);
		void Visit(UnifiedTypeConstrainCollection element, TState state);
		void Visit(UnifiedTypeParameter element, TState state);
		void Visit(UnifiedTypeSupplement element, TState state);
		void Visit(UnifiedTypeSupplementCollection element, TState state);
		void Visit(UnifiedTernaryExpression element, TState state);
		void Visit(UnifiedIdentifierCollection element, TState state);
		void Visit(UnifiedLabel element, TState state);
		void Visit(UnifiedExpressionList element, TState state);
		void Visit(UnifiedBooleanLiteral element, TState state);
		void Visit(UnifiedFractionLiteral element, TState state);
		void Visit(UnifiedIntegerLiteral element, TState state);
		void Visit(UnifiedStringLiteral element, TState state);
		void Visit(UnifiedNullLiteral element, TState state);
		void Visit(UnifiedMatcher element, TState state);
		void Visit(UnifiedMatcherCollection element, TState state);
		void Visit(UnifiedUsing element, TState state);
		void Visit(UnifiedListComprehension element, TState state);
		void Visit(UnifiedList element, TState state);
		void Visit(UnifiedKeyValue element, TState state);
		void Visit(UnifiedDictionaryComprehension element, TState state);
		void Visit(UnifiedKeyValueCollection element, TState state);
		void Visit(UnifiedDictonary element, TState state);
		void Visit(UnifiedSlice element, TState state);
		void Visit(UnifiedComment element, TState state);
		void Visit(UnifiedAnnotation element, TState state);
		void Visit(UnifiedAnnotationCollection element, TState state);
		void Visit(UnifiedVariableDefinitionList element, TState state);
		void Visit(UnifiedVariableDefinition element, TState state);
		void Visit(UnifiedArrayType element, TState state);
		void Visit(UnifiedSupplementType element, TState state);
		void Visit(UnifiedGenericType element, TState state);
		void Visit(UnifiedSimpleType element, TState state);
	}

	public interface IUnifiedModelVisitor<in TState, out TResult> {
		TResult Visit(UnifiedBinaryOperator element, TState state);
		TResult Visit(UnifiedUnaryOperator element, TState state);
		TResult Visit(UnifiedArgument element, TState state);
		TResult Visit(UnifiedArgumentCollection element, TState state);
		TResult Visit(UnifiedBinaryExpression element, TState state);
		TResult Visit(UnifiedBlock element, TState state);
		TResult Visit(UnifiedCall element, TState state);
		TResult Visit(UnifiedFunctionDefinition element, TState state);
		TResult Visit(UnifiedIf element, TState state);
		TResult Visit(UnifiedParameter element, TState state);
		TResult Visit(UnifiedParameterCollection element, TState state);
		TResult Visit(UnifiedIdentifier element, TState state);
		TResult Visit(UnifiedModifier element, TState state);
		TResult Visit(UnifiedModifierCollection element, TState state);
		TResult Visit(UnifiedImport element, TState state);
		TResult Visit(UnifiedConstructorDefinition element, TState state);
		TResult Visit(UnifiedProgram element, TState state);
		TResult Visit(UnifiedClassDefinition element, TState state);
		TResult Visit(UnifiedNew element, TState state);
		TResult Visit(UnifiedFor element, TState state);
		TResult Visit(UnifiedForeach element, TState state);
		TResult Visit(UnifiedUnaryExpression element, TState state);
		TResult Visit(UnifiedProperty element, TState state);
		TResult Visit(UnifiedExpressionCollection element, TState state);
		TResult Visit(UnifiedWhile element, TState state);
		TResult Visit(UnifiedDoWhile element, TState state);
		TResult Visit(UnifiedIndexer element, TState state);
		TResult Visit(UnifiedTypeArgument element, TState state);
		TResult Visit(UnifiedTypeArgumentCollection element, TState state);
		TResult Visit(UnifiedSwitch element, TState state);
		TResult Visit(UnifiedCaseCollection element, TState state);
		TResult Visit(UnifiedCase element, TState state);
		TResult Visit(UnifiedSpecialExpression element, TState state);
		TResult Visit(UnifiedSpecialBlock element, TState state);
		TResult Visit(UnifiedCatch element, TState state);
		TResult Visit(UnifiedTypeCollection element, TState state);
		TResult Visit(UnifiedCatchCollection element, TState state);
		TResult Visit(UnifiedTry element, TState state);
		TResult Visit(UnifiedCast element, TState state);
		TResult Visit(UnifiedTypeParameterCollection element, TState state);
		TResult Visit(UnifiedTypeConstrain element, TState state);
		TResult Visit(UnifiedTypeConstrainCollection element, TState state);
		TResult Visit(UnifiedTypeParameter element, TState state);
		TResult Visit(UnifiedTypeSupplement element, TState state);
		TResult Visit(UnifiedTypeSupplementCollection element, TState state);
		TResult Visit(UnifiedTernaryExpression element, TState state);
		TResult Visit(UnifiedIdentifierCollection element, TState state);
		TResult Visit(UnifiedLabel element, TState state);
		TResult Visit(UnifiedExpressionList element, TState state);
		TResult Visit(UnifiedBooleanLiteral element, TState state);
		TResult Visit(UnifiedFractionLiteral element, TState state);
		TResult Visit(UnifiedIntegerLiteral element, TState state);
		TResult Visit(UnifiedStringLiteral element, TState state);
		TResult Visit(UnifiedNullLiteral element, TState state);
		TResult Visit(UnifiedMatcher element, TState state);
		TResult Visit(UnifiedMatcherCollection element, TState state);
		TResult Visit(UnifiedUsing element, TState state);
		TResult Visit(UnifiedListComprehension element, TState state);
		TResult Visit(UnifiedList element, TState state);
		TResult Visit(UnifiedKeyValue element, TState state);
		TResult Visit(UnifiedDictionaryComprehension element, TState state);
		TResult Visit(UnifiedKeyValueCollection element, TState state);
		TResult Visit(UnifiedDictonary element, TState state);
		TResult Visit(UnifiedSlice element, TState state);
		TResult Visit(UnifiedComment element, TState state);
		TResult Visit(UnifiedAnnotation element, TState state);
		TResult Visit(UnifiedAnnotationCollection element, TState state);
		TResult Visit(UnifiedVariableDefinitionList element, TState state);
		TResult Visit(UnifiedVariableDefinition element, TState state);
		TResult Visit(UnifiedArrayType element, TState state);
		TResult Visit(UnifiedSupplementType element, TState state);
		TResult Visit(UnifiedGenericType element, TState state);
		TResult Visit(UnifiedSimpleType element, TState state);
	}
}