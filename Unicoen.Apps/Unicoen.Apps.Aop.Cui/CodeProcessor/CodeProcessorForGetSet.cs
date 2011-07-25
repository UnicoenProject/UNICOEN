using System.Linq;
using System.Text.RegularExpressions;
using Unicoen.Model;

namespace Unicoen.Apps.Aop.Cui.CodeProcessor
{
	public partial class CodeProcessor {
		/* 
		 * int b = a;
		 * a -> get joinpoint
		 * b -> set joinpoint
		 */

		//TODO アスペクトファイルではどう記述するのだろうか？
		//普通に考えると、set : int a;のように型も指定できるのがベストなはずなので、ちょっと検討しよう

		//TODO AspectJではフィールドに限定された話のようなので、提案処理系ではどう扱うか考える

		/// <summary>
		/// 指定された変数参照の直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name="root">コードを追加するモデルのルートノード</param>
		/// <param name="regex">対象変数を指定する正規表現</param>
		/// <param name="advice">挿入するコード断片</param>
		public static void InsertAtBeforeGet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//a = b;
			//TODO とりえあずAssignのみ +=,-=などについてはおいおい
			var assignmentExpressions =
					root.Descendants<UnifiedBinaryExpression>().Where(e => e.Operator.Kind == UnifiedBinaryOperatorKind.Assign).ToList();
			
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
				parent.Insert(parent.IndexOf(exp, 0), advice.DeepCopy());
			}

			//int a = b;
			var variableDefinitions = root.Descendants<UnifiedVariableDefinition>().ToList();

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
				block.Insert(block.IndexOf(parent, 0), advice.DeepCopy());
			}
		}

		/// <summary>
		/// 指定された変数参照の直後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name="root">コードを追加するモデルのルートノード</param>
		/// <param name="regex">対象変数を指定する正規表現</param>
		/// <param name="advice">挿入するコード断片</param>
		public static void InsertAtAfterGet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//a = b;のb
			//TODO とりえあずAssignのみ +=,-=などについてはおいおい
			var assignmentExpressions =
					root.Descendants<UnifiedBinaryExpression>().Where(e => e.Operator.Kind == UnifiedBinaryOperatorKind.Assign).ToList();
			
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
				parent.Insert(parent.IndexOf(exp, 0) + 1, advice.DeepCopy());
			}

			//int a = b;のb
			var variableDefinitions = root.Descendants<UnifiedVariableDefinition>().ToList();

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
				block.Insert(block.IndexOf(parent, 0) + 1, advice.DeepCopy());
			}
		}

		//TODO a = b = cの扱いはどうするか考える
		public static void InsertAtBeforeSet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//a = b;のa
			//TODO とりえあずAssignのみ +=,-=などについてはおいおい
			var assignmentExpressions =
					root.Descendants<UnifiedBinaryExpression>().Where(e => e.Operator.Kind == UnifiedBinaryOperatorKind.Assign).ToList();
			
			foreach (var exp in assignmentExpressions) {

				var parent = exp.Parent as UnifiedBlock;
				var lhs = exp.LeftHandSide as UnifiedVariableIdentifier;

				//親がブロック　かつ　左辺がUnifiedVariableIdentifier　でない場合は次の要素へ
				if(parent == null || lhs == null)
					continue;

				//変数名が与えられた正規表現にマッチするか確認する
				var m = regex.Match(lhs.Name);
				if (!m.Success)
					continue;

				//アドバイスの合成
				parent.Insert(parent.IndexOf(exp, 0), advice.DeepCopy());
			}

			//int a = b;のa
			var variableDefinitions = root.Descendants<UnifiedVariableDefinition>().ToList();

			foreach(var definition in variableDefinitions) {
				//初期化子がない場合は値はセットされないので次の要素へ
				if(definition.InitialValue == null)
					continue;

				//初期化子を変数として取得
				var variable = definition.Name as UnifiedVariableIdentifier;
				var block = definition.Parent.Parent as UnifiedBlock;
				
				//初期化子が変数でない場合は次の要素へ
				if(block == null || variable == null)
					continue;

				//変数名が与えられた正規表現にマッチするか確認する
				var m = regex.Match(variable.Name);
				if (!m.Success)
					continue;

				//アドバイスの合成
				var parent = definition.Parent as UnifiedVariableDefinitionList;
				block.Insert(block.IndexOf(parent, 0), advice.DeepCopy());
			}
		}

		public static void InsertAtAfterSet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//a = b;のa
			//TODO とりえあずAssignのみ +=,-=などについてはおいおい
			var assignmentExpressions =
					root.Descendants<UnifiedBinaryExpression>().Where(e => e.Operator.Kind == UnifiedBinaryOperatorKind.Assign).ToList();
			
			foreach (var exp in assignmentExpressions) {

				var parent = exp.Parent as UnifiedBlock;
				var lhs = exp.LeftHandSide as UnifiedVariableIdentifier;

				//親がブロック　かつ　左辺がUnifiedVariableIdentifier　でない場合は次の要素へ
				if(parent == null || lhs == null)
					continue;

				//変数名が与えられた正規表現にマッチするか確認する
				var m = regex.Match(lhs.Name);
				if (!m.Success)
					continue;

				//アドバイスの合成
				parent.Insert(parent.IndexOf(exp, 0) + 1, advice.DeepCopy());
			}

			//int a = b;のa
			var variableDefinitions = root.Descendants<UnifiedVariableDefinition>().ToList();

			foreach(var definition in variableDefinitions) {
				//初期化子がない場合は値はセットされないので次の要素へ
				if(definition.InitialValue == null)
					continue;

				//初期化子を変数として取得
				var variable = definition.Name as UnifiedVariableIdentifier;
				var block = definition.Parent.Parent as UnifiedBlock;
				
				//初期化子が変数でない場合は次の要素へ
				if(block == null || variable == null)
					continue;

				//変数名が与えられた正規表現にマッチするか確認する
				var m = regex.Match(variable.Name);
				if (!m.Success)
					continue;

				//アドバイスの合成
				var parent = definition.Parent as UnifiedVariableDefinitionList;
				block.Insert(block.IndexOf(parent, 0) + 1, advice.DeepCopy());
			}
		}

		public static void InsertAtBeforeGetByName(IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtBeforeGet(root, new Regex(name), advice);
		}

		public static void InsertAtAfterGetByName(IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtAfterGet(root, new Regex(name), advice);
		}

		public static void InsertAtBeforeSetByName(IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtBeforeSet(root, new Regex(name), advice);
		}

		public static void InsertAtAfterSetByName(IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtAfterSet(root, new Regex(name), advice);
		}
	}
}
