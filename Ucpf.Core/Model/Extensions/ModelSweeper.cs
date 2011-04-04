using System.Collections.Generic;
using System.Linq;

namespace Ucpf.Core.Model.Extensions {
	public static class ModelSweeper {
		public static IEnumerable<IUnifiedElement> ParentsAndSelf(
				this IUnifiedElement element) {
			yield return element;
			IUnifiedElement parent;
			while ((parent = element.Parent) != null) {
				yield return parent;
			}
		}

		public static IEnumerable<IUnifiedElement> Descendants(
				this IUnifiedElement element) {
			var children = element.GetElements();
			return children.Aggregate(children,
					(current, elem) => current.Concat(elem.Descendants()));
		}

		public static IEnumerable<IUnifiedElement> DescendantsAndSelf(
				this IUnifiedElement element) {
			var children = Enumerable.Repeat(element, 1).Concat(element.GetElements());
			return children.Aggregate(children,
					(current, elem) => current.Concat(elem.Descendants()));
		}
	}
}