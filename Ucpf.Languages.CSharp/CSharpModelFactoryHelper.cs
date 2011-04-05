using System;
using System.Collections.Generic;
using Ucpf.Core.Model;

namespace Ucpf.Languages.CSharp {
	public static class CSharpModelFactoryHelper {
		private static readonly Dictionary<UnifiedBinaryOperatorType, string> BinaryOperatorSigns;
		private static readonly Dictionary<UnifiedUnaryOperatorType, string> UnaryOperatorSigns;

		static CSharpModelFactoryHelper() {
			BinaryOperatorSigns = new Dictionary<UnifiedBinaryOperatorType, string>();
			BinaryOperatorSigns[UnifiedBinaryOperatorType.AddAssign] = "+=";
			BinaryOperatorSigns[UnifiedBinaryOperatorType.Assign] = "=";
			BinaryOperatorSigns[UnifiedBinaryOperatorType.LessThan] = "<";

			UnaryOperatorSigns = new Dictionary<UnifiedUnaryOperatorType, string>();
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PostDecrementAssign] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PreDecrementAssign] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PostIncrementAssign] = "++";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PreIncrementAssign] = "++";
		}

		public static UnifiedBinaryExpression CreateAssignExpression(IUnifiedExpression lhs, IUnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.Assign, rhs);
		}

		public static UnifiedBinaryExpression CreateLesserExpression(IUnifiedExpression lhs, IUnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.LessThan, rhs);
		}

		public static UnifiedBinaryExpression CreateExpression(IUnifiedExpression leftOperand, UnifiedBinaryOperatorType operatorType, IUnifiedExpression rightOperand) {
			if (!BinaryOperatorSigns.ContainsKey(operatorType))
				throw new NotImplementedException();
			return new UnifiedBinaryExpression {
				LeftHandSide = leftOperand,
				RightHandSide = rightOperand,
				Operator = new UnifiedBinaryOperator(BinaryOperatorSigns[operatorType], operatorType),
			};
		}

		public static UnifiedUnaryExpression CreateExpression(IUnifiedExpression operand, UnifiedUnaryOperatorType operatorType) {
			if (!UnaryOperatorSigns.ContainsKey(operatorType))
				throw new NotImplementedException();
			return new UnifiedUnaryExpression {
				Operand = operand,
				Operator = new UnifiedUnaryOperator(UnaryOperatorSigns[operatorType], operatorType),
			};
		}
	}
}