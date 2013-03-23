#region License

// Copyright (C) 2011-2012 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unicoen.Model;

namespace Unicoen.Processor {
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
				return xs.Cast<object>().Aggregate(
						0,
						(v, o) => v ^ o.GetHashCode() * 11);
			}

			if (x is UnifiedElement) {
				return x.GetType().GetProperties()
						.Select(
								prop => {
									if (prop.Name == "Parent") {
										return
												prop.GetValue(x, null).
														GetHashCode();
									}
									return GetHashCode(prop.GetValue(x, null));
								})
						.Aggregate(0, (v, o) => v ^ o.GetHashCode() * 11);
			}

			return x.GetHashCode();
		}

		#endregion

		public static bool StructuralEquals(object x, object y) {
			// check reference
			if (ReferenceEquals(x, y)) {
				return true;
			}
			// check null
			if (x == null || y == null) {
				return false;
			}
			// check type
			var type = x.GetType();
			if (!type.Equals(y.GetType())) {
				return false;
			}

			var xs = x as IEnumerable;
			if (xs != null) {
				var ret = xs.Cast<object>().SequenceEqual(
						((IEnumerable)y).Cast<object>(),
						Instance);
				return ret;
			}

			if (x is UnifiedElement) {
				var ret = x.GetType().GetProperties()
						.Where(prop => prop.Name != "Parent")
						.All(
								prop => StructuralEquals(
										prop.GetValue(x, null),
										prop.GetValue(y, null)));
				return ret;
			}

			{
				var ret = x.Equals(y);
				return ret;
			}
		}
	}
}