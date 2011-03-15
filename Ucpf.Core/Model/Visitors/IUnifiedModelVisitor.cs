using Ucpf.Core.Model.Expressions;

namespace Ucpf.Core.Model.Visitors {
	public interface IUnifiedModelVisitor<in TData, out TResult>  {
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
		TResult Visit(UnifiedReturn element, TData data);
		TResult Visit(UnifiedVariable element, TData data);
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
		TResult Visit(UnifiedBreak element, TData data);
		TResult Visit(UnifiedContinue element, TData data);
	}
}