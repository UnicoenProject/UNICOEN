using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Model;

namespace Unicoen.Apps.RefactoringDSL.NamespaceDetector {
	public class Helper {
		// node から親をたどって行って，types のうち一番早く見つかったものを返す．見つからなかったら null
		public static IUnifiedElement GetFirstFoundNode(UnifiedElement node, IEnumerable<IEnumerable<Type>> typeArray) {
			foreach (var ancestor in node.Ancestors()) {
				foreach (var types in typeArray) {
					foreach (var t in types) {
						if (ancestor.GetType().Equals(t)) {
							return ancestor;
						}
					}
				}
			}
			return null;

		}

		// 自分の親になりうる，かつ，名前空間構成要素になり得る要素タイプを返却する
		public static NamespaceType[] GetParentTypes(NamespaceType type) {
			switch(type) {
				case NamespaceType.Package:
					return new NamespaceType[] { };
				case NamespaceType.Class:
					return new NamespaceType[] { NamespaceType.Class, NamespaceType.Package };
				case NamespaceType.Function:
					return new NamespaceType[] { NamespaceType.Class, NamespaceType.Package, NamespaceType.Function};
				case NamespaceType.Variable:
					return new NamespaceType[] {NamespaceType.Class, NamespaceType.Function, NamespaceType.TemporaryScope};
				case NamespaceType.TemporaryScope:
					return new NamespaceType[] {NamespaceType.Function};
				default:
					throw new InvalidOperationException();

			}
		}

		// タイプから型へ変換（上へトラバースするときに使う）
		public static IEnumerable<Type> Namespace2UnifiedType(NamespaceType type) {
			switch(type) {
				case NamespaceType.Package:
					return new List<Type> { UnifiedNamespaceDefinition.Create().GetType() };
				case NamespaceType.Class:
					return new List<Type> { UnifiedClassDefinition.Create().GetType() };
				case NamespaceType.Function:
					return new List<Type> { UnifiedFunctionDefinition.Create().GetType() };
				case NamespaceType.TemporaryScope:
					return new List<Type> {
						UnifiedFor.Create().GetType(),
						UnifiedWhile.Create().GetType(),
						UnifiedDoWhile.Create().GetType(),
				};
				default:
					throw new InvalidOperationException();

			}
			
		}

	}
}
