using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	/// <summary>
	///   単項演算子を表します。
	/// </summary>
	public class UnifiedUnaryOperator : UnifiedElement {
		public string Sign { get; private set; }
		public UnifiedUnaryOperatorKind Kind { get; private set; }

		private UnifiedUnaryOperator() {}

		public static UnifiedUnaryOperator Create(string sign,
		                                          UnifiedUnaryOperatorKind kind) {
			return new UnifiedUnaryOperator {
					Sign = sign,
					Kind = kind,
			};
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