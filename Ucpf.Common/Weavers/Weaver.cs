using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Collections.Generic;
using Paraiba.Utility;
using Paraiba.Xml.Linq;

namespace Ucpf.Common.Weavers {
	public static class Weaver {
		public static void WeaveBefore(XElement node, XElement newNode) {
			node.AddBeforeSelf(newNode);
		}

		public static void WeaveBefore(XElement node,
		                               Func<XElement, XElement> createNodeFunc) {
			node.AddBeforeSelf(createNodeFunc(node));
		}

		public static void WeaveBefore(IEnumerable<XElement> nodes,
		                               Func<XElement, XElement> createNodeFunc) {
			WeaveBefore(nodes.ToList(), createNodeFunc);
		}

		public static void WeaveBefore(IList<XElement> nodeList,
		                               Func<XElement, XElement> createNodeFunc) {
			foreach (var node in nodeList) {
				WeaveBefore(node, createNodeFunc);
			}
		}

		public static void WeaveAfter(XElement node,
		                              Func<XElement, XElement> createNodeFunc) {
			node.AddAfterSelf(createNodeFunc(node));
		}

		public static void WeaveAfter(IEnumerable<XElement> nodes,
		                              Func<XElement, XElement> createNodeFunc) {
			WeaveAfter(nodes.ToList(), createNodeFunc);
		}

		public static void WeaveAfter(IList<XElement> nodeList,
		                              Func<XElement, XElement> createNodeFunc) {
			foreach (var node in nodeList) {
				WeaveAfter(node, createNodeFunc);
			}
		}

		public static void WeaveAround(XElement node,
		                               Func<XElement, XElement> createNodeFunc) {
			node.AddAfterSelf(createNodeFunc(node));
			node.Remove();

			//// Replace処理
			//// 要素の複製防止のために先に削除して，同じ位置に挿入し直す
			//// 直前に要素があるかどうか調べる
			//var prev = element.PreviousNode;
			//if (prev != null) {
			//    element.Remove();
			//    prev.AddAfterSelf(aspect.Advice(element));
			//}
			//else {
			//    var parent = element.Parent;
			//    element.Remove();
			//    parent.AddFirst(aspect.Advice(element));
			//}
		}

		public static void WeaveAround(IEnumerable<XElement> nodes,
		                               Func<XElement, XElement> createNodeFunc) {
			WeaveAround(nodes.ToList(), createNodeFunc);
		}

		public static void WeaveAround(IList<XElement> nodeList,
		                               Func<XElement, XElement> createNodeFunc) {
			foreach (var node in nodeList) {
				WeaveAround(node, createNodeFunc);
			}
		}

		public static void SafeWeaveAround(IEnumerable<XElement> nodes,
		                                   Func<XElement, XElement> createNodeFunc) {
			var sortedDict = GetElementListsOrderedByDepth(nodes);

			foreach (var list in sortedDict.Values) {
				foreach (var node in list) {
					WeaveAround(node, createNodeFunc);
				}
			}
		}

		private static SortedDictionary<int, List<XElement>>
			GetElementListsOrderedByDepth(
			IEnumerable<XElement> nodes) {
			var cmp = Make.Comparer<int>((v1, v2) => v2 - v1);
			var sortedDict = new SortedDictionary<int, List<XElement>>(cmp);
			foreach (var element in nodes) {
				var depth = element.Depth();
				var list = sortedDict.GetValueOrDefault(depth);
				if (list == null) {
					list = new List<XElement>();
					sortedDict.Add(depth, list);
				}
				list.Add(element);
			}
			return sortedDict;
		}
	}
}