using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Core.Visitors;

namespace Unicoen.Apps.Translator {
	public class Rewriter {
		public static Rewriter Instance = new Rewriter();

		// targetの Name.Value プロパティを newName に書き換える（関数名を書き換えるなど）
		public void RewiteIdentifierName(string newName, UnifiedElement target) {
			if (target is UnifiedFunctionDefinition) {
				((UnifiedFunctionDefinition)target).Name.Value = newName;
				return;
			}
		}

		// ある要素を置き換える
		public void ExchageElement(UnifiedType from, UnifiedType to) {
			var parent = from.Parent;
			var target =
					parent.GetElementAndSetters().Where(e => ReferenceEquals(e.Item1, from)).ElementAt(0);
			target.Item2(to);

			return;
		}

		// ある要素を削除する
		public void DeleteElement(UnifiedElement target) {
			target.Remove();
		}


	}

}
