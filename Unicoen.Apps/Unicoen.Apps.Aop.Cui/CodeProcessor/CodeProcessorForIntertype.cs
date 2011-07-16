using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Aop
{
	public partial class CodeProcessor {
		
		/// <summary>
		///   指定されたクラスまたはプログラムに指定されたフィールドやメソッドを追加します。
		/// </summary>
		/// <param name = "program">メンバーを追加するモデルのルートノード</param>
		/// <param name = "name">対象となるクラスやプログラムを指定する名前</param>
		/// <param name = "members">挿入するメンバーのリスト</param>
		public static void AddIntertypeDeclaration(
				UnifiedProgram program, string name, List<IUnifiedExpression> members) {
			//クラスのリストを取得(Java, C#向け)
			var classes = program.Descendants<UnifiedClassDefinition>();
			if (classes.Count() > 0) {
				foreach (var c in classes) {
					var className = c.Name as UnifiedIdentifier;
					if (className != null && className.Name == name) {
						foreach (var e in members) {
							c.Body.Insert(0, e);
						}
					}
				}
				return;
			}

			//プログラムに対してメンバーを追加(JavaScript向け)
			if (program != null) {
				foreach (var e in members) {
					program.Body.Insert(0, e);
				}
			}
		}
	}
}
