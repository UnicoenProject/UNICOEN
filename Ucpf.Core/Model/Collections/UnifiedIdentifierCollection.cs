using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   ジェネリックタイプにおける実引数の集合を表します。
	/// </summary>
	public class UnifiedIdentifierCollection
			: UnifiedElementCollection
			  		<UnifiedIdentifier, UnifiedIdentifierCollection> {
		private UnifiedIdentifierCollection() {}

		private UnifiedIdentifierCollection(
				IEnumerable<UnifiedIdentifier> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(IUnifiedModelVisitor<TData> visitor,
		                                   TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedIdentifierCollection Create() {
			return new UnifiedIdentifierCollection();
		}

		public static UnifiedIdentifierCollection Create(
				params UnifiedIdentifier[] elements) {
			return new UnifiedIdentifierCollection(elements);
		}

		public static UnifiedIdentifierCollection Create(
				IEnumerable<UnifiedIdentifier> elements) {
			return new UnifiedIdentifierCollection(elements);
		}
			  		}
}