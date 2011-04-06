using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedCase : UnifiedElement {
		private IUnifiedExpression _condition;

		public IUnifiedExpression Condition {
			get { return _condition; }
			set {
				_condition = SetParentOfChild(value, _condition);
			}
		}

		private UnifiedBlock _body;

		public UnifiedBlock Body {
			get { return _body; }
			set {
				_body = SetParentOfChild(value, _body);
			}
		}

		public UnifiedCase() {
			Body = UnifiedBlock.Create();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Condition;
			yield return Body;
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Condition, v => Condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<IUnifiedElement, Action<IUnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_condition, v => _condition = (IUnifiedExpression)v);
			yield return Tuple.Create<IUnifiedElement, Action<IUnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}

		public UnifiedCase AddToBody(IUnifiedExpression expression) {
			Body.Add(expression);
			return this;
		}
	}
}