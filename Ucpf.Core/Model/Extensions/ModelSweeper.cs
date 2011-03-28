using System.Collections.Generic;
using System.Linq;

namespace Ucpf.Core.Model.Extensions {
	public static class ModelSweeper {
		public static IEnumerable<UnifiedElement> ParentsAndSelf(
				this UnifiedElement element) {
			yield return element;
			UnifiedElement parent;
			while ((parent = element.Parent) != null) {
				yield return parent;
			}
		}

		public static IEnumerable<UnifiedElement> Descendants(
				this UnifiedElement element) {
			var children = element.GetElements();
			return children.Aggregate(children,
					(current, elem) => current.Concat(elem.Descendants()));
		}

		public static IEnumerable<UnifiedElement> DescendantsAndSelf(
				this UnifiedElement element) {
			var children = Enumerable.Repeat(element, 1).Concat(element.GetElements());
			return children.Aggregate(children,
					(current, elem) => current.Concat(elem.Descendants()));
		}
	}
}