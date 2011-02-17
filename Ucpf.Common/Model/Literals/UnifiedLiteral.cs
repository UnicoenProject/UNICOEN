namespace Ucpf.Common.Model {
	public class UnifiedLiteral : UnifiedExpression {
		// 詳細なリテラルクラスがある言語で表現できない際に必要
		// 例：整数型しか存在しない言語におけるDecimalLiteral
		public string Value { get; set; }
	}
}