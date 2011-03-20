using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedConstructorDefinition : UnifiedExpressionWithBlock<UnifiedConstructorDefinition> {
		public UnifiedModifierCollection Modifiers { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }

		public UnifiedConstructorDefinition() {
			Modifiers = new UnifiedModifierCollection();
			Parameters = new UnifiedParameterCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Modifiers;
			yield return Parameters;
			yield return Body;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Modifiers, v => Modifiers = (UnifiedModifierCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Parameters, v => Parameters = (UnifiedParameterCollection)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Body, v => Body = (UnifiedBlock)v);
		}
	}
}