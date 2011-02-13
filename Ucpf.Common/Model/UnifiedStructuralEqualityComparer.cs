using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ucpf.Common.Model {
	public class UnifiedStructuralEqualityComparer : UnifiedStructuralEqualityComparer<UnifiedElement> {
	}
	
	public class UnifiedStructuralEqualityComparer<T> : IEqualityComparer<T>
		where T : UnifiedElement
	{
		public static UnifiedStructuralEqualityComparer<T> Instance = new UnifiedStructuralEqualityComparer<T>();

		public static bool StructuralEquals(T x, T y)
		{
			// check type
			if (x == null || y == null)
				return false;
			if (x.GetType().Equals(y.GetType()))
				return false;
			return x.GetType().GetProperties(BindingFlags.Public)
				.All(prop => prop.GetValue(x, null)
								.Equals(prop.GetValue(y, null)));
		}

		public bool Equals(T x, T y) {
			return StructuralEquals(x, y);
		}

		public int GetHashCode(T obj) {
			return obj.GetType().GetProperties(BindingFlags.Public)
				.Select(prop => prop.GetValue(obj, null).GetHashCode())
				.Aggregate((o1, o2) => o1 * 11 ^ o2 * 17);
		}
	}
}
