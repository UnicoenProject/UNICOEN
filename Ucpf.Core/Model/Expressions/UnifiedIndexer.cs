using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedIndexer : UnifiedExpression {
		private UnifiedExpression _target;

		public UnifiedExpression Target {
			get { return _target; }
			set {
				_target = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedArgumentCollection _arguments;

		public UnifiedArgumentCollection Arguments {
			get { return _arguments; }
			set {
				_arguments = value;
				if (value != null) value.Parent = this;
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
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Target, v => Target = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
		}
	}
}