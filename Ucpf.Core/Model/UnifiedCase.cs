using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedCase : UnifiedElement {
		private UnifiedExpression _condition;

		public UnifiedExpression Condition {
			get { return _condition; }
			set {
				_condition = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				_body = value;
				if (value != null) value.Parent = this;
			}
		}

		public UnifiedCase() {
			Body = new UnifiedBlock();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Condition;
			yield return Body;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Condition, v => Condition = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}

		public UnifiedCase AddToBody(UnifiedExpression expression) {
			Body.Add(expression);
			return this;
		}
	}
}