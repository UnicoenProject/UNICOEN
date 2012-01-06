using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.CodeProcessor {
	public abstract class Aspect {
		public abstract string PointcutName { get; }

		public abstract void Before(IUnifiedElement model, string targetName, UnifiedBlock advice);
		public abstract void After(IUnifiedElement model, string targetName, UnifiedBlock advice);
		public abstract void Around(IUnifiedElement model);
	}
}
