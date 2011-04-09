﻿namespace Ucpf.Core.Model.Visitors
{
	public interface IUnifiedModelVisitor
	{
		void Visit<T>(UnifiedTypedLiteral<T> element);
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
		void Visit(UnifiedVariableDefinition element);
		void Visit(UnifiedNew element);
		void Visit(UnifiedLiteral element);
		void Visit(UnifiedArrayNew element);
		void Visit(UnifiedFor element);
		void Visit(UnifiedForeach element);
		void Visit(UnifiedUnaryExpression element);
		void Visit(UnifiedProperty element);
		void Visit(UnifiedType element);
		void Visit(UnifiedExpressionCollection element);
		void Visit(UnifiedWhile element);
		void Visit(UnifiedDoWhile element);
		void Visit(UnifiedIndexer element);
		void Visit(UnifiedTypeParameter element);
		void Visit(UnifiedTypeParameterCollection element);
		void Visit(UnifiedSwitch element);
		void Visit(UnifiedCaseCollection element);
		void Visit(UnifiedCase element);
		void Visit(UnifiedJump element);
		void Visit(UnifiedSpecialBlock element);
		void Visit(UnifiedCatch element);
		void Visit(UnifiedTypeCollection element);
		void Visit(UnifiedCatchCollection element);
		void Visit(UnifiedTry element);
		void Visit(UnifiedCast element);
	}

	public interface IUnifiedModelVisitor<in TData, out TResult>
	{
		TResult Visit<TValue>(UnifiedTypedLiteral<TValue> element, TData data);
		TResult Visit(UnifiedBinaryOperator element, TData data);
		TResult Visit(UnifiedUnaryOperator element, TData data);
		TResult Visit(UnifiedArgument element, TData data);
		TResult Visit(UnifiedArgumentCollection element, TData data);
		TResult Visit(UnifiedBinaryExpression element, TData data);
		TResult Visit(UnifiedBlock element, TData data);
		TResult Visit(UnifiedCall element, TData data);
		TResult Visit(UnifiedFunctionDefinition element, TData data);
		TResult Visit(UnifiedIf element, TData data);
		TResult Visit(UnifiedParameter element, TData data);
		TResult Visit(UnifiedParameterCollection element, TData data);
		TResult Visit(UnifiedIdentifier element, TData data);
		TResult Visit(UnifiedModifier element, TData data);
		TResult Visit(UnifiedModifierCollection element, TData data);
		TResult Visit(UnifiedImport element, TData data);
		TResult Visit(UnifiedConstructorDefinition element, TData data);
		TResult Visit(UnifiedProgram element, TData data);
		TResult Visit(UnifiedClassDefinition element, TData data);
		TResult Visit(UnifiedVariableDefinition element, TData data);
		TResult Visit(UnifiedNew element, TData data);
		TResult Visit(UnifiedLiteral element, TData data);
		TResult Visit(UnifiedArrayNew element, TData data);
		TResult Visit(UnifiedFor element, TData data);
		TResult Visit(UnifiedForeach element, TData data);
		TResult Visit(UnifiedUnaryExpression element, TData data);
		TResult Visit(UnifiedProperty element, TData data);
		TResult Visit(UnifiedType element, TData data);
		TResult Visit(UnifiedExpressionCollection element, TData data);
		TResult Visit(UnifiedWhile element, TData data);
		TResult Visit(UnifiedDoWhile element, TData data);
		TResult Visit(UnifiedIndexer element, TData data);
		TResult Visit(UnifiedTypeParameter element, TData data);
		TResult Visit(UnifiedTypeParameterCollection element, TData data);
		TResult Visit(UnifiedSwitch element, TData data);
		TResult Visit(UnifiedCaseCollection element, TData data);
		TResult Visit(UnifiedCase element, TData data);
		TResult Visit(UnifiedJump element, TData data);
		TResult Visit(UnifiedSpecialBlock element, TData data);
		TResult Visit(UnifiedCatch element, TData data);
		TResult Visit(UnifiedTypeCollection element, TData data);
		TResult Visit(UnifiedCatchCollection element, TData data);
		TResult Visit(UnifiedTry element, TData data);
		TResult Visit(UnifiedCast element, TData data);
	}
}