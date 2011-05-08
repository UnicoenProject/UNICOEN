#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Code2Xml.Languages.Java.CodeToXmls;
using Unicoen.Core.Model;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Aop {
	/// <summary>
	///   アスペクト指向プログラミングに必要なソースコードの加工処理メソッドを保有します。
	/// </summary>
	public class CodeProcessor {
		#region Utilities

		/// <summary>
		///   指定されたモデルから、指定されたタイプのリストを返します。
		/// </summary>
		/// <typeparam name = "T">指定する共通コードモデルのタイプ</typeparam>
		/// <param name = "root">要素を取得する共通コードモデルのルートノード</param>
		/// <returns></returns>
		//GetElementsBySpecifiedComponent<UnifiedNew>(null);
		public static IEnumerable<T> GetElementsByType<T>(IUnifiedElement root)
				where T : class {
			foreach (var e in root.Descendants()) {
				var result = e as T;
				if (result != null) {
					yield return result;
				}
			}
		}

		/// <summary>
		///   指定されたモデルから、指定されたタイプのリストを返します。
		/// </summary>
		/// <param name = "root">要素を取得する共通コードモデルのルートノード</param>
		/// <param name = "type">指定する共通コードモデルのタイプ</param>
		/// <returns></returns>
		//GetElementsBySpecifiedComponent(null, typeof(UnifiedNew));
		public static IEnumerable<IUnifiedElement> GetElementsByType(
				IUnifiedElement root, Type type) {
			foreach (var e in root.Descendants()) {
				if (type.IsInstanceOfType(e)) {
					yield return e;
				}
			}
		}

		/// <summary>
		///   与えられたコードを共通コードモデルとして生成します。
		/// </summary>
		/// <param name = "code">コード断片</param>
		/// <returns></returns>
		public static UnifiedBlock CreateAdvice(string code) {
			//generate model from string advice (as UnifiedBlock)
			var ast = JavaCodeToXml.Instance.Generate(code, p => p.block());
			var actual = JavaModelFactoryHelper.CreateBlock(ast);
			actual.Normalize();

			return actual;
		}

		#endregion

		#region Execution

		/// <summary>
		///   指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecution(
				IUnifiedElement root, Regex regex, string advice) {
			//get function list
			var functions = GetElementsByType<UnifiedFunctionDefinition>(root);
			//create advice as model
			var actual = CreateAdvice(advice);

			foreach (var e in functions) {
				//weave given advice, when function's name matches given Regex
				var m = regex.Match(e.Name.Value);
				if (m.Success)
					e.Body.Insert(0, actual);
			}
		}

		/// <summary>
		///   指定された関数ブロックの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecution(
				IUnifiedElement root, Regex regex, string advice) {
			//get function list
			var functions = GetElementsByType<UnifiedFunctionDefinition>(root);
			//create advice as model
			var actual = CreateAdvice(advice);

			foreach (var function in functions) {
				//when function's name doesn't match given Regex, ignore current functionDefinition
				var m = regex.Match(function.Name.Value);
				if (!m.Success)
					continue;

				/*ToList()を呼び出しておかないと例外を吐く
				 * 【例外】
				 * C# エラーメッセージ:コレクションが変更されました。
				 * 列挙操作は実行されない可能性があります。
				 */
				var returns =
						GetElementsByType<UnifiedSpecialExpression>(function).Where(
								e => e.Kind == UnifiedSpecialExpressionKind.Return).ToList();

				if (returns.Count() == 0) {
					//case function don't have return statement
					function.Body.Add(actual);
				} else {
					foreach (var returnStmt in returns) {
						var block = returnStmt.Parent as UnifiedBlock;
						if (block == null)
							continue;
						block.Insert(block.IndexOf(returnStmt, 0), actual);
					}
				}
			}
		}

		/// <summary>
		///   すべての関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecutionAll(
				IUnifiedElement root, string advice) {
			InsertAtBeforeExecution(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   すべての関数の後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecutionAll(
				IUnifiedElement root, string advice) {
			InsertAtAfterExecution(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   名前で指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecutionByName(
				IUnifiedElement root, string name, string advice) {
			InsertAtBeforeExecution(root, new Regex("^" + name + "$"), advice);
		}

		/// <summary>
		///   名前で指定された関数の後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterExecutionByName(
				IUnifiedElement root, string name, string advice) {
			InsertAtAfterExecution(root, new Regex("^" + name + "$"), advice);
		}

		#endregion

		#region Call

		/// <summary>
		///   指定された関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeCall(
				IUnifiedElement root, Regex regex, string advice) {
			//get cass list
			var calls = GetElementsByType<UnifiedCall>(root).ToList();
			//create advice as model
			var actual = CreateAdvice(advice);

			//親要素がUnifiedBlockの場合に、その関数呼び出しは単項式であると判断する。
			foreach (var call in calls) {
				//TODO IUnifiedExpressionとのマッチングをどのように行うのか考える
				// 現状ではToString()とのマッチングを行う。
				var m = regex.Match(call.Function.ToString());
				if (!m.Success)
					continue;

				var block = call.Parent as UnifiedBlock;
				if (block == null)
					continue;
				block.Insert(block.IndexOf(call, 0), actual);
			}
		}

		/// <summary>
		///   指定された関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterCall(
				IUnifiedElement root, Regex regex, string advice) {
			//get cass list
			var calls = GetElementsByType<UnifiedCall>(root).ToList();
			//create advice as model
			var actual = CreateAdvice(advice);

			//親要素がUnifiedBlockの場合に、その関数呼び出しは単項式であると判断する。
			foreach (var call in calls) {
				//TODO IUnifiedExpressionとのマッチングをどのように行うのか考える
				// 現状ではToString()とのマッチングを行う-> 共通コードモデルのXMLが返ってくるので、
				// 呼び出す関数の名前をexpressionから抽出する仕組みが必要
				var m = regex.Match(call.Function.ToString());
				if (!m.Success)
					continue;

				var block = call.Parent as UnifiedBlock;
				if (block == null)
					continue;
				block.Insert(block.IndexOf(call, 0) + 1, actual);
			}
		}

		/// <summary>
		///   すべての関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeCallAll(IUnifiedElement root, string advice) {
			InsertAtBeforeCall(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   すべての関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルードノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterCallAll(IUnifiedElement root, string advice) {
			InsertAtAfterCall(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   指定された関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeCallByName(
				IUnifiedElement root, string name, string advice) {
			InsertAtBeforeCall(root, new Regex("^" + name + "$"), advice);
		}

		/// <summary>
		///   指定された関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルードノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterCallByName(
				IUnifiedElement root, string name, string advice) {
			InsertAtAfterCall(root, new Regex("^" + name + "$"), advice);
		}

		#endregion
	}
}