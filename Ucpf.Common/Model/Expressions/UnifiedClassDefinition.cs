using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model.Expressions {

	public class UnifiedClassDefinition : UnifiedElement{

		public string Name { get; set; }
		public UnifiedBlock Body { get; set; }

		public override void Accept(IUnifiedModelVisitor conv) {
			throw new NotImplementedException();
		}
	}
}
