using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using Unicoen.Model;

namespace Unicoen.Apps.UniAspect.Cui.Processor.Pointcut {
	[Export(typeof(CodeProcessor))]
	public class Execution : CodeProcessor{
		/// <summary>
		///   指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecution(
				IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//get function list
			var functions = root.Descendants<UnifiedFunctionDefinition>();

			foreach (var function in functions) {
				//関数の定義元がインターフェースまたは抽象クラスの場合はアドバイスを合成しない
				if (function.Body == null)
					continue;

				//weave given advice, when function's name matches given Regex
				var m = regex.Match(function.Name.Name);
				if (m.Success) {
					//アドバイス内の特定の変数を、現在の対象関数名で置き換える
					var copy = ReplaceSpecialToken(advice.DeepCopy(), function.Name.Name);
					//アドバイスを対象関数に合成する
					function.Body.Insert(0, copy);
				}
			}
		}
		
		/// <summary>
		/// 指定されたアドバイスに含まれる特殊文字を指定された関数名に置き換えます
		/// </summary>
		public static UnifiedBlock ReplaceSpecialToken(UnifiedBlock old, string functionName) {
			//指定されたアドバイスに含まれる変数をリストアップする
			var variables = old.Descendants<UnifiedVariableIdentifier>();
			//特殊文字に指定されている変数を指定された関数名で置き換える
			foreach (var e in variables) {
				if(e.Name.Equals("JOINPOINT_NAME"))
					e.Name = "\"" + functionName + "\"";
			}
			return old;
		}

		/// <summary>
		///   指定された関数ブロックの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecution(
				IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//get function list
			var functions = root.Descendants<UnifiedFunctionDefinition>();

			foreach (var function in functions) {
				//関数の定義元がインターフェースまたは抽象クラスの場合はアドバイスを合成しない
				if (function.Body == null)
					continue;

				//when function's name doesn't match given Regex, ignore current functionDefinition
				var m = regex.Match(function.Name.Name);
				if (!m.Success)
					continue;

				/*ToList()を呼び出しておかないと例外を吐く
				 * 【例外】
				 * C# エラーメッセージ:コレクションが変更されました。
				 * 列挙操作は実行されない可能性があります。
				 */
				var returns = function.Descendants<UnifiedReturn>().ToList();

				if (returns.Count() == 0) {
					//case function don't have return statement
					function.Body.Add(advice.DeepCopy());
				} else {
					foreach (var returnStmt in returns) {
						var block = returnStmt.Parent as UnifiedBlock;
						if (block == null)
							continue;
						block.Insert(block.IndexOf(returnStmt, 0), advice.DeepCopy());
					}
				}
			}
		}

		/// <summary>
		///   指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name="statementNum">対象関数に含まれるstatement数の下限を指定する閾値</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecution(
				IUnifiedElement root, Regex regex, int statementNum, UnifiedBlock advice) {
			//関数の一覧を取得
			var functions = root.Descendants<UnifiedFunctionDefinition>();

			foreach (var function in functions) {
				//関数の定義元がインターフェースまたは抽象クラスの場合はアドバイスを合成しない
				if (function.Body == null)
					continue;

				//関数内部のStatementの一覧を取得し、閾値より多いかどうかを判定
				var innerStatements =
						ModelSweeper.Descendants(function.Body).Where(e => e.Parent.GetType().Equals(typeof(UnifiedBlock)));
				if(innerStatements.Count() < statementNum)
					continue;

				//関数名が与えられた正規表現にマッチする場合はアドバイスを合成する
				var m = regex.Match(function.Name.Name);
				if (m.Success) {
					//アドバイス内の特定の変数を、現在の対象関数名で置き換える
					var copy = ReplaceSpecialToken(advice.DeepCopy(), function.Name.Name);
					function.Body.Insert(0, copy);
				}
			}
		}

		/// <summary>
		///   指定された関数ブロックの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name="statementNum">対象関数に含まれるstatement数の下限を指定する閾値</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecution(
				IUnifiedElement root, Regex regex, int statementNum, UnifiedBlock advice) {
			//get function list
			var functions = root.Descendants<UnifiedFunctionDefinition>();

			foreach (var function in functions) {
				//関数の定義元がインターフェースまたは抽象クラスの場合はアドバイスを合成しない
				if (function.Body == null)
					continue;

				//関数内部のStatementの一覧を取得し、閾値より多いかどうかを判定
				var innerStatements =
						ModelSweeper.Descendants(function.Body).Where(e => e.Parent.GetType().Equals(typeof(UnifiedBlock)));
				if(innerStatements.Count() < statementNum)
					continue;

				//when function's name doesn't match given Regex, ignore current functionDefinition
				var m = regex.Match(function.Name.Name);
				if (!m.Success)
					continue;

				/*ToList()を呼び出しておかないと例外を吐く
				 * 【例外】
				 * C# エラーメッセージ:コレクションが変更されました。
				 * 列挙操作は実行されない可能性があります。
				 */
				var returns = function.Descendants<UnifiedReturn>().ToList();

				if (returns.Count() == 0) {
					//case function don't have return statement
					function.Body.Add(advice.DeepCopy());
				} else {
					foreach (var returnStmt in returns) {
						var block = returnStmt.Parent as UnifiedBlock;
						if (block == null)
							continue;
						block.Insert(block.IndexOf(returnStmt, 0), advice.DeepCopy());
					}
				}
			}
		}

		/// <summary>
		///   指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name="element"></param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecution(
				IUnifiedElement root, Regex regex, Type element, UnifiedBlock advice) {
			//関数の一覧を取得
			var functions = root.Descendants<UnifiedFunctionDefinition>();

			foreach (var function in functions) {
				//関数の定義元がインターフェースまたは抽象クラスの場合はアドバイスを合成しない
				if (function.Body == null)
					continue;

				//関数内部に指定された要素があるかどうかを判定
				var specifiedElements =
						ModelSweeper.Descendants(function.Body).Where(e => e.GetType().Equals(element));
				if(specifiedElements.Count() == 0)
					continue;

				//関数名が与えられた正規表現にマッチする場合はアドバイスを合成する
				var m = regex.Match(function.Name.Name);
				if (m.Success) {
					//アドバイス内の特定の変数を、現在の対象関数名で置き換える
					var copy = ReplaceSpecialToken(advice.DeepCopy(), function.Name.Name);
					function.Body.Insert(0, copy);
				}
			}
		}

		//TODO afterも実装する
		//TODO 共通部分が多いので、うまくまとめて実装する方法を考える

		/// <summary>
		///   すべての関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecutionAll(
				IUnifiedElement root, UnifiedBlock advice) {
			InsertAtBeforeExecution(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   すべての関数の後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecutionAll(
				IUnifiedElement root, UnifiedBlock advice) {
			InsertAtAfterExecution(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   名前で指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecutionByName(
				IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtBeforeExecution(root, new Regex("^" + name + "$"), advice);
		}

		/// <summary>
		///   名前で指定された関数の後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecutionByName(
				IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtAfterExecution(root, new Regex("^" + name + "$"), advice);
		}

		/// <summary>
		///   名前で指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name="statementNum">対象関数に含まれるstatement数の下限を指定する閾値</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecutionByName(
				IUnifiedElement root, string name, int statementNum, UnifiedBlock advice) {
			InsertAtBeforeExecution(root, new Regex("^" + name + "$"), statementNum, advice);
		}

		/// <summary>
		///   名前で指定された関数の後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name="statementNum">対象関数に含まれるstatement数の下限を指定する閾値</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecutionByName(
				IUnifiedElement root, string name, int statementNum, UnifiedBlock advice) {
			InsertAtAfterExecution(root, new Regex("^" + name + "$"), statementNum, advice);
		}

		/// <summary>
		///   名前で指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name="element"></param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecutionByName(
				IUnifiedElement root, string name, Type element, UnifiedBlock advice) {
			InsertAtBeforeExecution(root, new Regex("^" + name + "$"), element, advice);
		}

		public override string PointcutName {
			get { return "execution"; }
		}

		public override void Before(IUnifiedElement model, string targetName, UnifiedBlock advice) {
			InsertAtBeforeExecutionByName(model, targetName, advice);
		}

		public override void After(IUnifiedElement model, string targetName, UnifiedBlock advice) {
			InsertAtAfterExecutionByName(model, targetName, advice);
		}

		public override void Around(IUnifiedElement model) {
			throw new NotImplementedException();
		}
	}
}
