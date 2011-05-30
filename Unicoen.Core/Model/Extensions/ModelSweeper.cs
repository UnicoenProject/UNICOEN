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
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> Ancestors<T>(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			return element.Ancestors().Where(e => e is T);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> Ancestors<T>(
				this IUnifiedElement element, T dummyForInference) {
			Contract.Requires(element != null);
			return element.Ancestors().Where(e => e is T);
		}

		/// <summary>
		///   指定した要素の祖先を列挙します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> Ancestors(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			var parent = element;
			while ((parent = parent.Parent) != null) {
				yield return parent;
			}
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> AncestorsAndSelf<T>(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			return element.AncestorsAndSelf().Where(e => e is T);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> AncestorsAndSelf<T>(
				this IUnifiedElement element, T dummyForInference) {
			Contract.Requires(element != null);
			return element.AncestorsAndSelf().Where(e => e is T);
		}

		/// <summary>
		///   指定した要素とその祖先を列挙します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> AncestorsAndSelf(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			yield return element;
			var parent = element;
			while ((parent = parent.Parent) != null) {
				yield return parent;
			}
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> Descendants<T>(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			return element.Descendants().Where(e => e is T);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> Descendants<T>(
				this IUnifiedElement element, T dummyForInference) {
			Contract.Requires(element != null);
			return element.Descendants().Where(e => e is T);
		}

		/// <summary>
		///   指定した要素の子孫を列挙します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> Descendants(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			var children = element.GetElements()
					.Where(e => e != null);
			return children.Aggregate(
					children,
					(current, elem) => current.Concat(elem.Descendants()));
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> DescendantsAndSelf<T>(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			return element.DescendantsAndSelf().Where(e => e is T);
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> DescendantsAndSelf<T>(
				this IUnifiedElement element, T dummyForInference) {
			Contract.Requires(element != null);
			return element.DescendantsAndSelf().Where(e => e is T);
		}

		/// <summary>
		///   指定した要素とその子孫を列挙します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> DescendantsAndSelf(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			var children = Enumerable.Repeat(element, 1)
					.Concat(element.GetElements().Where(e => e != null));
			return children.Aggregate(
					children,
					(current, elem) => current.Concat(elem.Descendants()));
		}

		//public static bool IsEmptyOrNull<TElement, TSelf>(this IUnifiedElementCollection<TElement, TSelf> element)
		//        where TElement : class, IUnifiedElement {
		//    return false;
		//}
	}
}