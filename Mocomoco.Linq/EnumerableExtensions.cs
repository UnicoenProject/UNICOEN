using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mocomoco.Linq
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<Tuple<T, T>> Split2<T>(this IEnumerable<T> source) {
			var enumerator = source.GetEnumerator();
			while (enumerator.MoveNext()) {
				var item1 = enumerator.Current;
				if (!enumerator.MoveNext())
					yield break;
				var item2 = enumerator.Current;
				yield return Tuple.Create(item1, item2);
			}
		}
	}
}
