using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   小数のリテラルを表します。
	/// </summary>
	public class UnifiedFractionLiteral : UnifiedTypedLiteral<double> {
		private UnifiedFractionLiteral() {}

		public UnifiedFractionLiteralKind Kind { get; set; }

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

		public static UnifiedFractionLiteral Create(double value, UnifiedFractionLiteralKind kind) {
			return new UnifiedFractionLiteral {
					Value = value,
					Kind = kind,
			};
		}

		public static UnifiedFractionLiteral CreateSingle(double value) {
			return Create(value, UnifiedFractionLiteralKind.Single);
		}

		public static UnifiedFractionLiteral CreateDouble(double value) {
			return Create(value, UnifiedFractionLiteralKind.Doulbe);
		}
	}
}