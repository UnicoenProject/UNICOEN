using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedFor : UnifiedExpressionWithBlock<UnifiedFor> {
		private UnifiedExpression _initializer;

		public UnifiedExpression Initializer {
			get { return _initializer; }
			set {
				_initializer = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedExpression _condition;

		public UnifiedExpression Condition {
			get { return _condition; }
			set {
				_condition = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedExpression _step;

		public UnifiedExpression Step {
			get { return _step; }
			set {
				_step = value;
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
			yield return Initializer;
			yield return Condition;
			yield return Step;
			yield return Body;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Initializer, v => Initializer = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Condition, v => Condition = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Step, v => Step = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}
	}
}