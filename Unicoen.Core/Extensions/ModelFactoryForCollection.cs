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

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Unicoen.Model {
	public static class ProgramGeneratorForCollection {
		public static UnifiedSet<UnifiedAnnotation> Merge(
				this IEnumerable<UnifiedSet<UnifiedAnnotation>> collections) {
			return collections.ToList().Merge();
		}

		public static UnifiedSet<UnifiedAnnotation> Merge(
				this IList<UnifiedSet<UnifiedAnnotation>> collections) {
			Contract.Requires<InvalidOperationException>(
					collections.All(c => c.Parent == null));
			if (collections.Count == 0) {
				return UnifiedSet<UnifiedAnnotation>.Create();
			}
			var ret = collections[0];
			for (int i = 1; i < collections.Count; i++) {
				ret.AddRange(collections[i].ElementsThenClear());
			}
			return ret;
		}

		public static UnifiedSet<T> ToSet<T>(this IEnumerable<T> collection)
				where T : UnifiedElement {
			return UnifiedSet<T>.Create(collection);
		}

		public static UnifiedSet<T> ToSet<T>(this T singleton)
				where T : UnifiedElement {
			if (singleton == null) {
				return UnifiedSet<T>.Create();
			}
			return UnifiedSet<T>.Create(singleton);
		}
	}
}