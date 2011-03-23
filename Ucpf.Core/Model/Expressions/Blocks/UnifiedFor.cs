using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedFor : UnifiedExpressionWithBlock<UnifiedFor> {
		private UnifiedExpression _initializer;

		public UnifiedExpression Initializer {
			get { return _initializer; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedExpression)value.DeepCopy();
					}
					value.Parent = this;
				}
				_initializer = value;
			}
		}

		private UnifiedExpression _condition;

		public UnifiedExpression Condition {
			get { return _condition; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedExpression)value.DeepCopy();
					}
					value.Parent = this;
				}
				_condition = value;
			}
		}

		private UnifiedExpression _step;

		public UnifiedExpression Step {
			get { return _step; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedExpression)value.DeepCopy();
					}
					value.Parent = this;
				}
				_step = value;
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
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Initializer, v => Initializer = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Condition, v => Condition = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Step, v => Step = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_initializer, v => _initializer = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_condition, v => _condition = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_step, v => _step = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}
	}
}