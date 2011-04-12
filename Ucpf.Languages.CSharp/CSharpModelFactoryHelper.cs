using System;
using System.Collections.Generic;
using Ucpf.Core.Model;

namespace Ucpf.Languages.CSharp
{
	public static class CSharpModelFactoryHelper
	{
		private static readonly Dictionary<UnifiedBinaryOperatorKind, string>
			BinaryOperatorSigns;

		private static readonly Dictionary<UnifiedUnaryOperatorKind, string>
			UnaryOperatorSigns;

		static CSharpModelFactoryHelper()
		{
			BinaryOperatorSigns = new Dictionary<UnifiedBinaryOperatorKind, string>();
			BinaryOperatorSigns[UnifiedBinaryOperatorKind.AddAssign] = "+=";
			BinaryOperatorSigns[UnifiedBinaryOperatorKind.Assign] = "=";
			BinaryOperatorSigns[UnifiedBinaryOperatorKind.LessThan] = "<";

			UnaryOperatorSigns = new Dictionary<UnifiedUnaryOperatorKind, string>();
			UnaryOperatorSigns[UnifiedUnaryOperatorKind.PostDecrementAssign] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorKind.PreDecrementAssign] = "--";
			UnaryOperatorSigns[UnifiedUnaryOperatorKind.PostIncrementAssign] = "++";
			UnaryOperatorSigns[UnifiedUnaryOperatorKind.PreIncrementAssign] = "++";
		}

		public static UnifiedBinaryExpression CreateAssignExpression(
			IUnifiedExpression lhs, IUnifiedExpression rhs)
		{
			return CreateExpression(lhs, UnifiedBinaryOperatorKind.Assign, rhs);
		}

		public static UnifiedBinaryExpression CreateLesserExpression(
			IUnifiedExpression lhs, IUnifiedExpression rhs)
		{
			return CreateExpression(lhs, UnifiedBinaryOperatorKind.LessThan, rhs);
		}

		public static UnifiedBinaryExpression CreateExpression(
			IUnifiedExpression leftOperand, UnifiedBinaryOperatorKind operatorKind,
			IUnifiedExpression rightOperand)
		{
			if (!BinaryOperatorSigns.ContainsKey(operatorKind))
				throw new NotImplementedException();
			return UnifiedBinaryExpression.Create(leftOperand,
				UnifiedBinaryOperator.Create(BinaryOperatorSigns[operatorKind], operatorKind),
				rightOperand);
		}

		public static UnifiedUnaryExpression CreateExpression(
			IUnifiedExpression operand, UnifiedUnaryOperatorKind operatorKind)
		{
			if (!UnaryOperatorSigns.ContainsKey(operatorKind))
				throw new NotImplementedException();
			return UnifiedUnaryExpression.Create(operand,
				UnifiedUnaryOperator.Create(UnaryOperatorSigns[operatorKind], operatorKind));
		}
	}
}