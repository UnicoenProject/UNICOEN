using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedModifier : UnifiedElement {

	public string Name { get; set; }

	public override void Accept(IUnifiedModelVisitor visitor) {
		visitor.Visit(this);
	}

	public override string ToString() {
		return UnifiedModelToXml.ToXml(this).ToString();
	}
}
}
