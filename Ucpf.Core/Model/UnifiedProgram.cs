﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedProgram : UnifiedElementCollection<IUnifiedExpression, UnifiedProgram> {
		public UnifiedProgram() {}

		public UnifiedProgram(IEnumerable<IUnifiedExpression> elements)
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
	}
}