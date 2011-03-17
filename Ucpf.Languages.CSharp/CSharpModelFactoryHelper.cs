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

		public static UnifiedBinaryExpression CreateAssignExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.Assign, rhs);
		}

		public static UnifiedBinaryExpression CreateLesserExpression(UnifiedExpression lhs, UnifiedExpression rhs) {
			return CreateExpression(lhs, UnifiedBinaryOperatorType.LessThan, rhs);
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

		public static UnifiedReturn CreateReturn() {
			return new UnifiedReturn();
		}

		public static UnifiedBreak CreateBreak() {
			return new UnifiedBreak();
		}

		public static UnifiedContinue CreateContinue() {
			return new UnifiedContinue();
		}
	}
}