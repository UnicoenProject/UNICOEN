using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedClassDefinition
		: UnifiedExpressionWithBlock<UnifiedClassDefinition> {
		public UnifiedModifierCollection Modifiers { get; set; }
		public string Name { get; set; }

		public UnifiedClassDefinition() {
			Modifiers = new UnifiedModifierCollection();
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
			yield return Body;
		}
		}
}