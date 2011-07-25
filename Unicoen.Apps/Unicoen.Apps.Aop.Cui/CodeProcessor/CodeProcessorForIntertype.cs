using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Unicoen.Model;

namespace Unicoen.Apps.Aop.Cui.CodeProcessor
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
					//クラス名を取得
					var className = c.Name as UnifiedVariableIdentifier;
					if(className == null)
						continue;

					//受け取った名前を正規表現に変換し、クラス名が一致する場合は合成する
					var regex = new Regex(name == "*" ? ".*" : name);
					var m = regex.Match(className.Name);
					if (m.Success) {
						foreach (var e in members) {
							c.Body.Insert(0, e.DeepCopy());
						}
					}
				}
				return;
			}
			//TODO interfaceのようにUnifiedClassDefinitionがない場合はここまでくるのでどう対処するか
			//とりあえず応急処置
			var interfaces = program.Descendants<UnifiedInterfaceDefinition>();
			if(interfaces.Count() > 0) return;
			var enums = program.Descendants<UnifiedEnumDefinition>();
			if(enums.Count() > 0) return;

			//プログラムに対してメンバーを追加(JavaScript向け))
			if (program != null) {
				foreach (var e in members) {
					program.Body.Insert(0, e.DeepCopy());
				}
			}
		}
	}
}
