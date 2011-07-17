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

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Model {
	public static class ModelSweeper {
		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<T> Ancestors<T>(
				this IUnifiedElement element) where T : class {
			Contract.Requires(element != null);
			return element.Ancestors().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の祖先を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<T> Ancestors<T>(
				this IUnifiedElement element, T dummyForInference) where T : class {
			Contract.Requires(element != null);
			return element.Ancestors<T>();
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
		public static IEnumerable<T> AncestorsAndSelf<T>(
				this IUnifiedElement element) where T : class {
			Contract.Requires(element != null);
			return element.AncestorsAndSelf().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその祖先を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<T> AncestorsAndSelf<T>(
				this IUnifiedElement element, T dummyForInference) where T : class {
			Contract.Requires(element != null);
			return element.AncestorsAndSelf<T>();
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
		public static IEnumerable<T> Descendants<T>(
				this IUnifiedElement element)
				where T : class {
			Contract.Requires(element != null);
			return element.Descendants().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素の子孫を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<T> Descendants<T>(
				this IUnifiedElement element, T dummyForInference)
				where T : class {
			Contract.Requires(element != null);
			return element.Descendants<T>();
		}

		/// <summary>
		///   指定した要素の子孫を列挙します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> Descendants(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			var children = element.Elements()
			        .Where(e => e != null)
			        .ToList();
			foreach (var child in children) {
			    yield return child;
			}
			foreach (var child in children) {
			    foreach (var grandchild in child.Descendants()) {
			        yield return grandchild;
			    }
			}
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<T> DescendantsAndSelf<T>(
				this IUnifiedElement element) where T : class {
			Contract.Requires(element != null);
			return element.DescendantsAndSelf().OfType<T>();
		}

		/// <summary>
		///   指定した型に限定して，指定した要素とその子孫を列挙します．
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "element"></param>
		/// <param name = "dummyForInference"></param>
		/// <returns></returns>
		public static IEnumerable<T> DescendantsAndSelf<T>(
				this IUnifiedElement element, T dummyForInference) where T : class {
			Contract.Requires(element != null);
			return element.DescendantsAndSelf<T>();
		}

		/// <summary>
		///   指定した要素とその子孫を列挙します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<IUnifiedElement> DescendantsAndSelf(
				this IUnifiedElement element) {
			Contract.Requires(element != null);
			yield return element;
			foreach (var e in element.Descendants()) {
				yield return e;
			}
		}

		/// <summary>
		///   指定した集合を表現する要素が空もしくはnullであるかどうか判定します．
		/// </summary>
		/// <typeparam name = "TElement">空もしくはnullであるかどうかの判定結果</typeparam>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static bool IsEmptyOrNull<TElement>(
				this IUnifiedElementCollection<TElement> element)
				where TElement : class, IUnifiedElement {
			return element == null || element.Count == 0;
		}

		/// <summary>
		///   親の親を取得します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IUnifiedElement GrandParent(this IUnifiedElement element) {
			Contract.Requires(element != null);
			return element.Parent.SafeParent();
		}

		/// <summary>
		///   親の親の親を取得します．
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IUnifiedElement GrandGrandParent(this IUnifiedElement element) {
			Contract.Requires(element != null);
			return element.Parent.SafeParent().SafeParent();
		}
	}
}