using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;

namespace Unicoen.Apps.AOP {
	/// <summary>
	/// アスペクト指向プログラミングに必要なソースコードの加工処理メソッドを保有します。
	/// </summary>
	public class CodeProcessor {
		
		public static IUnifiedElement GetFunctionDefinitionByName(IUnifiedElement root, string name) {
			foreach (var e in root.DescendantsAndSelf()) {
				if(e is UnifiedFunctionDefinition) {
					if(((UnifiedFunctionDefinition)e).Name.Value == name) {
						return e;
					}
				}
			}
			return null;
		}
	}
}
