using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedVariable : UnifiedExpression {
		public string Name { get; set; }

		public UnifiedVariable(string name) {
			this.Name = name;
		}

		public override void Accept(IUnifiedModelVisitor conv) {
			conv.Visit(this);
		}
	}
}
