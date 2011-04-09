using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;

namespace Paraiba.Xml.Linq
{
	/// <summary>
	///   レシーバーがnullであっても動作するXElementの拡張メソッドを集めたクラスです。
	/// </summary>
	public static class XElementSafeExtensions
	{
		/// <summary>
		///   レシーバーがnullであっても動作するXElementExtensions.HasElement()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static bool SafeHasElement(this XElement element)
		{
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
		[Pure]
		public static bool SafeHasElement(this XElement element,
		                                  string name)
		{
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
		[Pure]
		public static bool SafeHasContent(this XElement element,
		                                  string value)
		{
			if (element == null)
				return false;
			return element.HasContent(value);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Element(name)メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeElement(this XElement element,
		                                   string name)
		{
			if (element == null)
				return null;
			return element.Element(name);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements()メソッドです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static IEnumerable<XElement> SafeElements(this XElement element)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeElements(this XElement element,
		                                                 string name)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeElementsAfterSelf(
			this XElement element)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeElementsAfterSelf(
			this XElement element,
			string name)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeElementsBeforeSelf(
			this XElement element)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeElementsBeforeSelf(
			this XElement element,
			string name)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeDescendants(this XElement element)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeDescendants(this XElement element,
		                                                    string name)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeDescendantsAndSelf(
			this XElement element)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeDescendantsAndSelf(
			this XElement element, string name)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeAncestors(this XElement element)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeAncestors(this XElement element,
		                                                  string name)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeAncestorsAndSelf(this XElement element)
		{
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
		[Pure]
		public static IEnumerable<XElement> SafeAncestorsAndSelf(
			this XElement element, string name)
		{
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
		[Pure]
		public static string SafeName(this XElement element)
		{
			if (element == null)
				return null;
			return element.Name.LocalName;
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Valueプロパティです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static string SafeValue(this XElement element)
		{
			if (element == null)
				return null;
			return element.Value;
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Parentです。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeParent(this XElement element)
		{
			if (element == null)
				return null;
			return element.Parent;
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafePreviousElement(this XElement element)
		{
			if (element == null)
				return null;
			return element.LastElementBeforeSelfOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeNextElement(this XElement element)
		{
			if (element == null)
				return null;
			return element.FirstElementAfterSelfOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeFirstElement(this XElement element)
		{
			if (element == null)
				return null;
			return element.Elements().FirstOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeLastElement(this XElement element)
		{
			if (element == null)
				return null;
			return element.Elements().LastOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.Elements().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeNthElement(this XElement element, int index)
		{
			if (element == null)
				return null;
			return element.Elements().ElementAtOrDefault(index);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeFirstElementBeforeSelf(this XElement element)
		{
			if (element == null)
				return null;
			return element.ElementsBeforeSelf().FirstOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeLastElementBeforeSelf(this XElement element)
		{
			if (element == null)
				return null;
			return element.ElementsBeforeSelf().LastOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsBeforeSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeNthElementBeforeSelf(this XElement element,
		                                                int index)
		{
			if (element == null)
				return null;
			return element.ElementsBeforeSelf().ElementAtOrDefault(index);
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeFirstElementAfterSelf(this XElement element)
		{
			if (element == null)
				return null;
			return element.ElementsAfterSelf().FirstOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeLastElementAfterSelf(this XElement element)
		{
			if (element == null)
				return null;
			return element.ElementsAfterSelf().LastOrDefault();
		}

		/// <summary>
		///   レシーバーがnullであっても動作するXElement.ElementsAfterSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static XElement SafeNthElementAfterSelf(this XElement element,
		                                               int index)
		{
			if (element == null)
				return null;
			return element.ElementsAfterSelf().ElementAtOrDefault(index);
		}
	}
}