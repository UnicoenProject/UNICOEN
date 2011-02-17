using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedVariable : UnifiedExpression {
		public string Name { get; set; }

		// TODO: 不要では？
		public UnifiedVariable() { }

		public UnifiedVariable(string name) {
			this.Name = name;
		}
	}
}
