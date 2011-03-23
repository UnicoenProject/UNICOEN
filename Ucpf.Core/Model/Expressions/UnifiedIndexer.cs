using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIndexer : UnifiedExpression {
		private UnifiedExpression _target;

		public UnifiedExpression Target {
			get { return _target; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedExpression)value.DeepCopy();
					}
					value.Parent = this;
				}
				_target = value;
			}
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set {
				if (value != null) {
					if (value.Parent != null) {
						value = (UnifiedArgumentCollection)value.DeepCopy();
					}
					value.Parent = this;
				}
				_arguments = value;
			}
		}

		public UnifiedIndexer() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Target;
			yield return Arguments;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Target, v => Target = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_target, v => _target = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_arguments, v => _arguments = (UnifiedArgumentCollection)v);
		}
	}
}