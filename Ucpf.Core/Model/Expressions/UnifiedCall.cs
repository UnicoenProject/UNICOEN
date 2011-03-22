using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedCall : UnifiedExpression {
		private UnifiedExpression _function;

		public UnifiedExpression Function {
			get { return _function; }
			set {
				_function = value;
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

		public UnifiedCall() {
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
			yield return Function;
			yield return Arguments;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Function, v => Function = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Arguments, v => Arguments = (UnifiedArgumentCollection)v);
		}
	}
}