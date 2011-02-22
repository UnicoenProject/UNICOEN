using System;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedLiteral : UnifiedExpression {
		// 詳細なリテラルクラスがある言語で表現できない際に必要
		// 例：整数型しか存在しない言語におけるDecimalLiteral
		public string Value { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}