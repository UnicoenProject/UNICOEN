using System;
using System.Collections.Generic;
using Ucpf.Common.Model;

namespace Ucpf.Languages.CSharp {
	public static class CSharpModelFactoryHelper {
		private static readonly Dictionary<UnifiedBinaryOperatorType, string> BinaryOperatorSigns;
		private static readonly Dictionary<UnifiedUnaryOperatorType, string> UnaryOperatorSigns;

		static CSharpModelFactoryHelper() {
			BinaryOperatorSigns = new Dictionary<UnifiedBinaryOperatorType, string>();
			BinaryOperatorSigns[UnifiedBinaryOperatorType.AddAssignment] = "+=";
			BinaryOperatorSigns[UnifiedBinaryOperatorType.Assignment] = "=";
			BinaryOperatorSigns[UnifiedBinaryOperatorType.Lesser] = "<";

			UnaryOperatorSigns = new Dictionary<UnifiedUnaryOperatorType, string>();
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PostfixDecrement] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PrefixDecrement] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PostfixIncrement] = "++";
			UnaryOperatorSigns[UnifiedUnaryOperatorType.PrefixIncrement] = "++";
		}

		public static UnifiedBinaryExpression CreateAssignExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.Assignment, rhs);
		}

		public static UnifiedBinaryExpression CreateLesserExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.Lesser, rhs);
		}

		public static UnifiedBinaryExpression CreateExpression(UnifiedExpression leftOperand, UnifiedBinaryOperatorType operatorType, UnifiedExpression rightOperand) {
			if (!BinaryOperatorSigns.ContainsKey(operatorType))
				throw new NotImplementedException();
			return new UnifiedBinaryExpression {
				LeftHandSide = leftOperand,
				RightHandSide = rightOperand,
				Operator = new UnifiedBinaryOperator(BinaryOperatorSigns[operatorType], operatorType),
			};
		}

		public static UnifiedUnaryExpression CreateExpression(UnifiedExpression operand, UnifiedUnaryOperatorType operatorType) {
			if (!UnaryOperatorSigns.ContainsKey(operatorType))
				throw new NotImplementedException();
			return new UnifiedUnaryExpression {
				Operand = operand,
				Operator = new UnifiedUnaryOperator(UnaryOperatorSigns[operatorType], operatorType),
			};
		}
	}
}