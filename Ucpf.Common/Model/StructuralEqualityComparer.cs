using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ucpf.Common.Model {
	public class StructuralEqualityComparer : IEqualityComparer<object> {
		public static StructuralEqualityComparer Instance =
			new StructuralEqualityComparer();

		#region IEqualityComparer<object> Members

		public bool Equals(object x, object y) {
			return StructuralEquals(x, y);
		}

		public int GetHashCode(object obj) {
			return obj.GetType().GetProperties(BindingFlags.Public)
				.Select(prop => prop.GetValue(obj, null).GetHashCode())
				.Aggregate((o1, o2) => o1 * 11 ^ o2 * 17);
		}

		#endregion

		public static bool StructuralEquals(object x, object y) {
			// check reference
			if (ReferenceEquals(x, y))
				return true;
			// check null
			if (x == null || y == null)
				return false;
			// check type
			var type = x.GetType();
			if (!type.Equals(y.GetType()))
				return false;

			if (type.Name == "UnifiedArgumentCollection") {
				type = type;
			}

			var xs = x as IEnumerable;
			if (xs != null) {
				return xs.Cast<object>().SequenceEqual(
					((IEnumerable)y).Cast<object>(),
					Instance);
			}

			if (!type.IsEnum && type.Namespace.StartsWith("Ucpf.Common.Model")) {
				return x.GetType().GetProperties()
					.All(prop => StructuralEquals(
						prop.GetValue(x, null), prop.GetValue(y, null)));
			}

			return x.Equals(y);
		}
	}
}