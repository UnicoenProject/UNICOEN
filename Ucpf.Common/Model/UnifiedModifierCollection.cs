using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedModifierCollection : UnifiedElementCollection<UnifiedModifier> {

		public UnifiedModifierCollection() { }

		public UnifiedModifierCollection(IEnumerable<UnifiedModifier> modifiers) : base (modifiers) { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override string ToString() {
			return UnifiedModelToXml.ToXml(this).ToString();
		}
	}
}
