using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public abstract class UnifiedElement {
		public abstract void Accept(IUnifiedModelVisitor visitor);
	}
}
