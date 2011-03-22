using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model.Visitors {
	public abstract class DefaultUnifiedModelVisitor : IUnifiedModelVisitor  {
		public virtual void Visit<T>(UnifiedTypedLiteral<T> element) {
			
		}

		public virtual void Visit(UnifiedBinaryOperator element) {
			
		}

		public virtual void Visit(UnifiedUnaryOperator element) {
			
		}

		public virtual void Visit(UnifiedArgument element) {
			
		}

		public virtual void Visit(UnifiedArgumentCollection element) {
			
		}

		public virtual void Visit(UnifiedBinaryExpression element) {
			
		}

		public virtual void Visit(UnifiedBlock element) {
			
		}

		public virtual void Visit(UnifiedCall element) {
			
		}

		public virtual void Visit(UnifiedFunctionDefinition element) {
			
		}

		public virtual void Visit(UnifiedIf element) {
			
		}

		public virtual void Visit(UnifiedParameter element) {
			
		}

		public virtual void Visit(UnifiedParameterCollection element) {
			
		}

		public virtual void Visit(UnifiedReturn element) {
			
		}

		public virtual void Visit(UnifiedVariable element) {
			
		}

		public virtual void Visit(UnifiedModifier element) {
			
		}

		public virtual void Visit(UnifiedModifierCollection element) {
			
		}

		public virtual void Visit(UnifiedImport element) {
			
		}

		public virtual void Visit(UnifiedConstructorDefinition element) {
			
		}

		public virtual void Visit(UnifiedProgram element) {
			
		}

		public virtual void Visit(UnifiedClassDefinition element) {
			
		}

		public virtual void Visit(UnifiedVariableDefinition element) {
			
		}

		public virtual void Visit(UnifiedNew element) {
			
		}

		public virtual void Visit(UnifiedLiteral element) {
			
		}

		public virtual void Visit(UnifiedArrayNew element) {
			
		}

		public virtual void Visit(UnifiedFor element) {
			
		}

		public virtual void Visit(UnifiedForeach element) {
			
		}

		public virtual void Visit(UnifiedUnaryExpression element) {
			
		}

		public virtual void Visit(UnifiedProperty element) {
			
		}

		public virtual void Visit(UnifiedType element) {
			
		}

		public virtual void Visit(UnifiedExpressionCollection element) {
			
		}

		public virtual void Visit(UnifiedWhile element) {
			
		}

		public virtual void Visit(UnifiedDoWhile element) {
			
		}

		public virtual void Visit(UnifiedBreak element) {
			
		}

		public virtual void Visit(UnifiedContinue element) {
			
		}

		public virtual void Visit(UnifiedNamespace element) {
			
		}

		public virtual void Visit(UnifiedIndexer element) {
			
		}

		public virtual void Visit(UnifiedTypeParameter element) {
			
		}

		public virtual void Visit(UnifiedTypeParameterCollection element) {
			
		}
	}
}
