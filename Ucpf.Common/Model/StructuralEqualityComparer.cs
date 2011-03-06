using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Ucpf.Common.Model {
	public class StructuralEqualityComparer : IEqualityComparer<object> {
		public static StructuralEqualityComparer Instance =
			new StructuralEqualityComparer();

		#region IEqualityComparer<object> Members

		bool IEqualityComparer<object>.Equals(object x, object y) {
			return StructuralEquals(x, y);
		}

		public int GetHashCode(object x) {
			var xs = x as IEnumerable;
			if (xs != null) {
				return xs.Cast<object>().Aggregate(0,
					(v, o) => v ^ o.GetHashCode() * 11);
			}

			var type = x.GetType();
			if (!type.IsEnum && type.Namespace.StartsWith("Ucpf.Common.Model")) {
				return x.GetType().GetProperties()
					.Select(prop => prop.GetValue(x, null).GetHashCode())
					.Aggregate(0, (v, o) => v ^ o.GetHashCode() * 11);
			}

			return x.GetHashCode();
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

			var xs = x as IEnumerable;
			if (xs != null) {
				var ret = xs.Cast<object>().SequenceEqual(
					((IEnumerable)y).Cast<object>(),
					Instance);
				return ret;
			}

			if (!type.IsEnum && type.Namespace.StartsWith("Ucpf.Common.Model")) {
				var ret = x.GetType().GetProperties()
					.All(prop => StructuralEquals(
						prop.GetValue(x, null), prop.GetValue(y, null)));
				return ret;
			}

			{
				var ret = x.Equals(y);
				return ret;
			}
		}
	}
}