using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedNamespace : UnifiedElement {
		public string Name { get; set; }

		private UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				_body = value;
				if (value != null) value.Parent = this;
			}
		}

		public UnifiedNamespace AddToBody(UnifiedExpression expression) {
			Body.Add(expression);
			return this;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Body;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}
	}
}