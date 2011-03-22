using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedForeach : UnifiedExpressionWithBlock<UnifiedForeach> {
		private UnifiedVariableDefinition _element;

		public UnifiedVariableDefinition Element {
			get { return _element; }
			set {
				_element = value;
				if (value != null) value.Parent = this;
			}
		}

		private UnifiedExpression _set;

		public UnifiedExpression Set {
			get { return _set; }
			set {
				_set = value;
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
			yield return Element;
			yield return Set;
			yield return Body;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Element, v => Element = (UnifiedVariableDefinition)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Set, v => Set = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}
	}
}