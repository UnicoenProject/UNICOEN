#region License

// Copyright (C) 2011 The Unicoen Project
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

using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Unicoen.Core.Model {
	public static class ModelSweeper {
		/// <summary>
		/// 深いコピーを取得します．
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="self"></param>
		/// <returns></returns>
		public static T DeepCopy<T>(this T self)
			where T : IUnifiedElement {
			return (T)self.PrivateDeepCopy();
		}

		public static IEnumerable<IUnifiedElement> Ancestors(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			var parent = element;
			while ((parent = parent.Parent) != null) {
				yield return parent;
			}
		}

		public static IEnumerable<IUnifiedElement> AncestorsAndSelf(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			yield return element;
			var parent = element;
			while ((parent = parent.Parent) != null) {
				yield return parent;
			}
		}

		public static IEnumerable<IUnifiedElement> Descendants(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			var children = element.GetElements()
					.Where(e => e != null);
			return children.Aggregate(
					children,
					(current, elem) => current.Concat(elem.Descendants()));
		}

		public static IEnumerable<IUnifiedElement> DescendantsAndSelf(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			var children = Enumerable.Repeat(element, 1)
					.Concat(element.GetElements().Where(e => e != null));
			return children.Aggregate(
					children,
					(current, elem) => current.Concat(elem.Descendants()));
		}
	}
}