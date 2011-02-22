using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ucpf.Common.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedFunctionDefinition : UnifiedStatement {
		public string[] Modifiers { get; set; }
		public string ReturnType { get; set; }
		public string Name { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }
		public UnifiedBlock Block { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
