using System;
using System.Linq;
using System.Text.RegularExpressions;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Aop
{
	public partial class CodeProcessor {
				// a = b; a = 10; b;
		// a -> set joinpoint
		// b -> get joinpoint

		//TODO アスペクトファイルではどう記述するのだろうか？
		//普通に考えると、set : int a;のように型も指定できるのがベストなはずなので、ちょっと検討しよう

		//getはBinaryExpressionの左辺以外の変数(UnifiedVariableIdentifier)？
		//かつ、親ノードがブロックの場合とまずは少ない範囲からいきましょう
		public static void InsertAtBeforeGet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//a = b;
			//TODO とりえあずAssignのみ +=,-=などについてはおいおい
			var assignmentExpressions =
					root.Descendants<UnifiedBinaryExpression>().Where(e => e.Operator.Kind == UnifiedBinaryOperatorKind.Assign);
			
			foreach (var exp in assignmentExpressions) {

				var parent = exp.Parent as UnifiedBlock;
				var rhs = exp.RightHandSide as UnifiedVariableIdentifier;

				//親がブロック　かつ　右辺がUnifiedVariableIdentifier　でない場合は次の要素へ
				if(parent == null || rhs == null)
					continue;

				//変数名が与えられた正規表現にマッチするか確認する
				var m = regex.Match(rhs.Name);
				if (!m.Success)
					continue;

				//アドバイスの合成
				parent.Insert(parent.IndexOf(exp, 0), advice);
			}

			//int a = b;
			var variableDefinitions = root.Descendants<UnifiedVariableDefinition>();

			foreach(var definition in variableDefinitions) {
				//初期化子を変数として取得
				var identifier = definition.InitialValue as UnifiedVariableIdentifier;
				var block = definition.Parent.Parent as UnifiedBlock;
				
				//初期化子が変数でない場合は次の要素へ
				if(block == null || identifier == null)
					continue;

				//変数名が与えられた正規表現にマッチするか確認する
				var m = regex.Match(identifier.Name);
				if (!m.Success)
					continue;

				//アドバイスの合成
				var parent = definition.Parent as UnifiedVariableDefinitionList;
				block.Insert(block.IndexOf(parent, 0), advice);
			}

		}

		public static void InsertAtAfterGet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			throw new NotImplementedException();
		}


		//setはBinaryExpressionの左辺の場合？
		// a = b = cの扱いはどうする？
		public static void InsertAtBeforeSet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			throw new NotImplementedException();
		}

		public static void InsertAtAfterSet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			throw new NotImplementedException();
		}
	}
}
