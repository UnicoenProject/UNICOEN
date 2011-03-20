using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model.Visitors {
	public class NormalizeVisitor : IUnifiedModelVisitor {
		public void Visit<T>(UnifiedTypedLiteral<T> element) {
		}

		public void Visit(UnifiedBinaryOperator element) {
		}

		public void Visit(UnifiedUnaryOperator element) {
		}

		public void Visit(UnifiedArgument element) {
			element.Value.Accept(this);
			element.Value = (UnifiedExpression)((INormalizable)element.Value).Normalize();
		}

		public void Visit(UnifiedArgumentCollection element) {
			var count = element.Count;
			for (int i = 0; i < count; i++) {
				element[i].Accept(this);
				element[i] = (UnifiedArgument)((INormalizable)element[i]).Normalize();
			}
		}

		public void Visit(UnifiedBinaryExpression element) {
			element.LeftHandSide.Accept(this);
			element.Operator.Accept(this);
			element.RightHandSide.Accept(this);
			element.LeftHandSide = (UnifiedExpression)((INormalizable)element.LeftHandSide).Normalize();
			element.Operator = (UnifiedBinaryOperator)((INormalizable)element.Operator).Normalize();
			element.RightHandSide = (UnifiedExpression)((INormalizable)element.RightHandSide).Normalize();
		}

		public void Visit(UnifiedBlock element) {
			var count = element.Count;
			for (int i = 0; i < count; i++) {
				element[i].Accept(this);
				element[i] = (UnifiedExpression)((INormalizable)element[i]).Normalize();
			}
		}

		public void Visit(UnifiedCall element) {
			element.Arguments.Accept(this);
			element.Function.Accept(this);
			element.Arguments = (UnifiedArgumentCollection)((INormalizable)element.Arguments).Normalize();
			element.Function = (UnifiedExpression)((INormalizable)element.Function).Normalize();
		}

		public void Visit(UnifiedFunctionDefinition element) {
			element.Body.Accept(this);
			element.Modifiers.Accept(this);
			element.Parameters.Accept(this);
			element.Type.Accept(this);
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

		public void Visit(UnifiedReturn element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariable element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedModifier element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedModifierCollection element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedImport element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedConstructorDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedProgram element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedClassDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedVariableDefinition element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNew element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedLiteral element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedArrayNew element) {
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

		public void Visit(UnifiedType element) {
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

		public void Visit(UnifiedBreak element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedContinue element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedNamespace element) {
			throw new NotImplementedException();
		}

		public void Visit(UnifiedIndexer element) {
			throw new NotImplementedException();
		}
	}
}
