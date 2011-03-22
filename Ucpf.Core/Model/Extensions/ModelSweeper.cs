using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Core.Model.Extensions {
	public static class ModelSweeper {
		public static IEnumerable<UnifiedElement> ParentsAndSelf(this UnifiedElement element) {
			yield return element;
			UnifiedElement parent;
			while ((parent = element.Parent) != null) {
				yield return parent;
			}
		}
	}
}
