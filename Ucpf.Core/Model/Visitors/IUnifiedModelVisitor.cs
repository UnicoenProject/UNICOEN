﻿using Ucpf.Common.Model;

namespace Ucpf.Core.Model.Visitors {
	public interface IUnifiedModelVisitor {
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
		void Visit(UnifiedReturn element);
		void Visit(UnifiedVariable element);
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
	}
}