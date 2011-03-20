using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Paraiba.Xml.Linq {
	public static class XElementExtensions {
		/// <summary>
		///   指定したnameのXElementを保持しているか取得します。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static bool Contains(this XElement element, string name) {
			return element.Element(name) != null;
		}

		/// <summary>
		/// XElement.Name.LocalNameプロパティの戻り値を取得します。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static string Name(this XElement element) {
			return element.Name.LocalName;
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement PreviousElement(this XElement element) {
			return element.LastElementBeforeSelf();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement PreviousElementOrDefault(this XElement element) {
			return element.LastElementBeforeSelfOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement NextElement(this XElement element) {
			return element.FirstElementAfterSelf();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement NextElementOrDefault(this XElement element) {
			return element.FirstElementAfterSelfOrDefault();
		}

		/// <summary>
		/// XElement.Elements().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElement(this XElement element) {
			return element.Elements().First();
		}

		/// <summary>
		/// XElement.Elements().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementOrDefault(this XElement element) {
			return element.Elements().FirstOrDefault();
		}

		/// <summary>
		/// XElement.Elements().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElement(this XElement element) {
			return element.Elements().Last();
		}

		/// <summary>
		/// XElement.Elements().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementOrDefault(this XElement element) {
			return element.Elements().LastOrDefault();
		}

		/// <summary>
		/// XElement.Elements().ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElement(this XElement element, int index) {
			return element.Elements().ElementAt(index);
		}

		/// <summary>
		/// XElement.Elements().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementOrDefault(this XElement element, int index) {
			return element.Elements().ElementAtOrDefault(index);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementBeforeSelf(this XElement element) {
			return element.ElementsBeforeSelf().First();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementBeforeSelfOrDefault(this XElement element) {
			return element.ElementsBeforeSelf().FirstOrDefault();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementBeforeSelf(this XElement element) {
			return element.ElementsBeforeSelf().Last();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementBeforeSelfOrDefault(this XElement element) {
			return element.ElementsBeforeSelf().LastOrDefault();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementBeforeSelf(this XElement element, int index) {
			return element.ElementsBeforeSelf().ElementAt(index);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement NthElementBeforeSelfOrDefault(this XElement element, int index) {
			return element.ElementsBeforeSelf().ElementAtOrDefault(index);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementAfterSelf(this XElement element) {
			return element.ElementsAfterSelf().First();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementAfterSelfOrDefault(this XElement element) {
			return element.ElementsAfterSelf().FirstOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementAfterSelf(this XElement element) {
			return element.ElementsAfterSelf().Last();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementAfterSelfOrDefault(this XElement element) {
			return element.ElementsAfterSelf().LastOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementAfterSelf(this XElement element, int index) {
			return element.ElementsAfterSelf().ElementAt(index);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementAfterSelfOrDefault(this XElement element, int index) {
			return element.ElementsAfterSelf().ElementAtOrDefault(index);
		}
	}
}
