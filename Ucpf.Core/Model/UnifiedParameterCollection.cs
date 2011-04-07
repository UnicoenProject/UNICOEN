using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	/// 仮引数の集合を表します。
	/// </summary>
	public class UnifiedParameterCollection
			: UnifiedElementCollection<UnifiedParameter> {
		public UnifiedParameterCollection() {}

		public UnifiedParameterCollection(IEnumerable<UnifiedParameter> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}
			}
}