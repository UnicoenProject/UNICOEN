using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedForeach : UnifiedExpressionWithBlock<UnifiedForeach> {
		private UnifiedVariableDefinition _element;

		public UnifiedVariableDefinition Element {
			get { return _element; }
			set { _element = SetParentOfChild(value, _element); }
		}

		private UnifiedExpression _set;

		public UnifiedExpression Set {
			get { return _set; }
			set { _set = SetParentOfChild(value, _set); }
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
				GetElementAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Element, v => Element = (UnifiedVariableDefinition)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Set, v => Set = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(Body, v => Body = (UnifiedBlock)v);
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
				GetElementAndDirectSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_element, v => _element = (UnifiedVariableDefinition)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_set, v => _set = (UnifiedExpression)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(_body, v => _body = (UnifiedBlock)v);
		}
	}
}