using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {

	public class UnifiedArgumentCollection : UnifiedElementCollection<UnifiedArgument> {

		public UnifiedArgumentCollection() { }

		public UnifiedArgumentCollection(IEnumerable<UnifiedArgument> args) : base (args) { }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
