using Ucpf.Languages.Java.CodeModel.Expressions;

namespace Ucpf.Languages.Java.CodeModel {
	public class IfStatement : JavaStatement {
		private JavaExpression ConditionalExpression;
		private Block ElseBlock;
		private Block TrueBlock;
	}
}