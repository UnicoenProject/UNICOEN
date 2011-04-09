﻿using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Ucpf.Core.Model.Extensions
{
	public static class ModelSweeper
	{
		public static IEnumerable<IUnifiedElement> ParentsAndSelf(
			this IUnifiedElement element)
		{
			Contract.Requires(element != null);
			yield return element;
			IUnifiedElement parent;
			while ((parent = element.Parent) != null) {
				yield return parent;
			}
		}

		public static IEnumerable<IUnifiedElement> Descendants(
			this IUnifiedElement element)
		{
			Contract.Requires(element != null);
			var children = element.GetElements()
				.Where(e => e != null);
			return children.Aggregate(children,
				(current, elem) => current.Concat(elem.Descendants()));
		}

		public static IEnumerable<IUnifiedElement> DescendantsAndSelf(
			this IUnifiedElement element)
		{
			Contract.Requires(element != null);
			var children = Enumerable.Repeat(element, 1)
				.Concat(element.GetElements().Where(e => e != null));
			return children.Aggregate(children,
				(current, elem) => current.Concat(elem.Descendants()));
		}
	}
}