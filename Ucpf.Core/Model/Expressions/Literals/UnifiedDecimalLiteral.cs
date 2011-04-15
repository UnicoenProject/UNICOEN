using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   Decimal型であるリテラルを表します。
	/// </summary>
	public class UnifiedDecimalLiteral : UnifiedTypedLiteral<decimal> {
		private UnifiedDecimalLiteral() {}

		public static UnifiedDecimalLiteral Create(double value) {
			return Create((decimal)value);
		}

		public static UnifiedDecimalLiteral Create(decimal value) {
			return new UnifiedDecimalLiteral { Value = value };
		}

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

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield break;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield break;
		}
	}
}