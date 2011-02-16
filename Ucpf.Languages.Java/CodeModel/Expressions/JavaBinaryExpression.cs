using Ucpf.Languages.Java.CodeModel.Operators;

namespace Ucpf.Languages.Java.CodeModel.Expressions {
	internal class javaBinaryExpression : JavaExpression {
		private JavaOperator Operator;
		private Value lValue;
		private Value rValue;
	}
}