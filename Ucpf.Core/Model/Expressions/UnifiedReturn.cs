using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedReturn : UnifiedExpression {
		private UnifiedExpression _value;

		public UnifiedExpression Value {
			get { return _value; }
			set {
				_value = value;
				if (value != null) value.Parent = this;
			}
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Value;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Value, v => Value = (UnifiedExpression)v);
		}
	}
}