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
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

namespace Mocomoco.Xml.Linq {
	/// <summary>
	///   レシーバーがnullであっても動作するXElementの拡張メソッドを集めたクラスです。
	/// </summary>
	public static class XElementSafeExtensions {
		/// <summary>
		///   レシーバーがnullであっても動作するXElementExtensions.HasElement()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static bool SafeHasElement(this XElement element) {
			if (element == null)
				return false;
			return element.HasElement();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElementExtensions.HasElement(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name = "name"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static bool SafeHasElement(
				this XElement element,
				string name) {
			if (element == null)
				return false;
			return element.HasElement(name);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElementExtensions.HasContent(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name = "value"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static bool SafeHasContent(
				this XElement element,
				string value) {
			if (element == null)
				return false;
			return element.HasContent(value);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Element(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeElement(
				this XElement element,
				string name) {
			if (element == null)
				return null;
			return element.Element(name);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeElements(this XElement element) {
			if (element == null)
				yield break;
			foreach (var elem in element.Elements()) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeElements(
				this XElement element,
				string name) {
			if (element == null)
				yield break;
			foreach (var elem in element.Elements(name)) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeElementsAfterSelf(
				this XElement element) {
			if (element == null)
				yield break;
			foreach (var elem in element.ElementsAfterSelf()) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeElementsAfterSelf(
				this XElement element,
				string name) {
			if (element == null)
				yield break;
			foreach (var elem in element.ElementsAfterSelf(name)) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeElementsBeforeSelf(
				this XElement element) {
			if (element == null)
				yield break;
			foreach (var elem in element.ElementsBeforeSelf()) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeElementsBeforeSelf(
				this XElement element,
				string name) {
			if (element == null)
				yield break;
			foreach (var elem in element.ElementsBeforeSelf(name)) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Descendants()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeDescendants(this XElement element) {
			if (element == null)
				yield break;
			foreach (var elem in element.Descendants()) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Descendants(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeDescendants(
				this XElement element,
				string name) {
			if (element == null)
				yield break;
			foreach (var elem in element.Descendants(name)) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.DescendantsAndSelf()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeDescendantsAndSelf(
				this XElement element) {
			if (element == null)
				yield break;
			foreach (var elem in element.DescendantsAndSelf()) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.DescendantsAndSelf(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeDescendantsAndSelf(
				this XElement element, string name) {
			if (element == null)
				yield break;
			foreach (var elem in element.DescendantsAndSelf(name)) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Ancestors()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeAncestors(this XElement element) {
			if (element == null)
				yield break;
			foreach (var elem in element.Ancestors()) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Ancestors(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeAncestors(
				this XElement element,
				string name) {
			if (element == null)
				yield break;
			foreach (var elem in element.Ancestors(name)) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.AncestorsAndSelf()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeAncestorsAndSelf(
				this XElement element) {
			if (element == null)
				yield break;
			foreach (var elem in element.AncestorsAndSelf()) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.AncestorsAndSelf(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static IEnumerable<XElement> SafeAncestorsAndSelf(
				this XElement element, string name) {
			if (element == null)
				yield break;
			foreach (var elem in element.AncestorsAndSelf(name)) {
				yield return elem;
			}
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Name.LocalNameプロパティです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static string SafeName(this XElement element) {
			if (element == null)
				return null;
			return element.Name.LocalName;
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Valueプロパティです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static string SafeValue(this XElement element) {
			if (element == null)
				return null;
			return element.Value;
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Parentです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeParent(this XElement element) {
			if (element == null)
				return null;
			return element.Parent;
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafePreviousElement(this XElement element) {
			if (element == null)
				return null;
			return element.LastElementBeforeSelfOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.NextElement()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeNextElement(this XElement element) {
			if (element == null)
				return null;
			return element.NextElement();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.NextElement(int index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name = "index"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeNextElement(this XElement element, int index) {
			if (element == null)
				return null;
			return element.NextElement(index);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.NextElement(string name)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name = "name"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeNextElement(this XElement element, string name) {
			if (element == null)
				return null;
			return element.NextElement(name);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.NextElement(string name, int index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name = "name"></param>
		/// <param name = "index"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeNextElement(
				this XElement element, string name, int index) {
			if (element == null)
				return null;
			return element.NextElement(name, index);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeFirstElement(this XElement element) {
			if (element == null)
				return null;
			return element.Elements().FirstOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeLastElement(this XElement element) {
			if (element == null)
				return null;
			return element.Elements().LastOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeNthElement(this XElement element, int index) {
			if (element == null)
				return null;
			return element.Elements().ElementAtOrDefault(index);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeFirstElementBeforeSelf(this XElement element) {
			if (element == null)
				return null;
			return element.ElementsBeforeSelf().FirstOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeLastElementBeforeSelf(this XElement element) {
			if (element == null)
				return null;
			return element.ElementsBeforeSelf().LastOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeNthElementBeforeSelf(
				this XElement element,
				int index) {
			if (element == null)
				return null;
			return element.ElementsBeforeSelf().ElementAtOrDefault(index);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeFirstElementAfterSelf(this XElement element) {
			if (element == null)
				return null;
			return element.ElementsAfterSelf().FirstOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeLastElementAfterSelf(this XElement element) {
			if (element == null)
				return null;
			return element.ElementsAfterSelf().LastOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure, DebuggerStepThrough]
		public static XElement SafeNthElementAfterSelf(
				this XElement element,
				int index) {
			if (element == null)
				return null;
			return element.ElementsAfterSelf().ElementAtOrDefault(index);
		}
	}
}