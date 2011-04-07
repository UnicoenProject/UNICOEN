using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedProgram : UnifiedElementCollection<IUnifiedExpression, UnifiedProgram> {
		private UnifiedProgram() {}

		private UnifiedProgram(IEnumerable<IUnifiedExpression> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			return this;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
						(this[i], v => this[i] = (IUnifiedExpression)v);
			}
		}

		public static UnifiedProgram Create() {
			return new UnifiedProgram();
		}

		public static UnifiedProgram Create(params IUnifiedExpression[] elements) {
			return new UnifiedProgram(elements);
		}

		public static UnifiedProgram Create(IEnumerable<IUnifiedExpression> elements) {
			return new UnifiedProgram(elements);
		}
	}
}