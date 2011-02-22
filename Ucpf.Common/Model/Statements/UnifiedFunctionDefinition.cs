using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedFunctionDefinition : UnifiedExpression {
		public IEnumerable<String> Modifiers { get; set; }
		public String ReturnType { get; set; }
		public string Name { get; set; }
		public UnifiedParameterCollection Parameters { get; set; }
		public UnifiedBlock Block { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
