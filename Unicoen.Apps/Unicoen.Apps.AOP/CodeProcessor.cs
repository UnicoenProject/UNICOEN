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
using System.Xml.Linq;
using Code2Xml.Languages.Java.CodeToXmls;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java;
using Unicoen.Languages.Java.ModelFactories;
using Unicoen.Languages.JavaScript;
using Unicoen.Languages.JavaScript.ModelFactories;

namespace Unicoen.Apps.Aop {
	/// <summary>
	///   アスペクト指向プログラミングに必要なソースコードの加工処理メソッドを保有します。
	/// </summary>
	public class CodeProcessor {
		/// <summary>
		/// 与えられたソースコードを共通モデルに変換します
		/// </summary>
		/// <param name="ext">対象言語の拡張子</param>
		/// <param name="code">対象ソースコードの中身</param>
		/// <returns></returns>
		public static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpFactory.GenerateModel(code);
			case ".java":
				return JavaFactory.GenerateModel(code);
			case ".js":
				return JavaScriptFactory.GenerateModel(code);
			}
			//TODO implement 他の言語についても実装する
			throw new NotImplementedException();
		}

		/// <summary>
		///   与えられたコードを共通コードモデルとして生成します。
		/// </summary>
		/// <param name="language">対象言語</param>
		/// <param name = "code">コード断片</param>
		/// <returns></returns>
		public static UnifiedBlock CreateAdvice(string language, string code) {
			//generate model from string advice (as UnifiedBlock)
			XElement ast = null;
			UnifiedBlock actual = null;
			code = "{ " + code + " }";

			switch (language) {
				case "Java":
					ast = JavaCodeToXml.Instance.Generate(code, p => p.block());
					actual = JavaModelFactoryHelper.CreateBlock(ast);
					break;
				case "JavaScript":
					ast = JavaScriptCodeToXml.Instance.Generate(code, p => p.statementBlock());
					actual = JavaScriptModelFactoryHelper.CreateStatementBlock(ast);
					break;
				default:
					throw new NotImplementedException();
			}
			actual.Normalize();

			return actual;
		}

		/// <summary>
		///   与えられたコードをインタータイプ宣言のために共通コードモデルとして生成します
		/// </summary>
		/// <param name="language">対象言語</param>
		/// <param name="code">コード断片</param>
		/// <returns></returns>
		public static List<IUnifiedExpression> CreateIntertype(string language, string code) {
			XElement ast = null;
			var actual = new List<IUnifiedExpression>();

			switch (language) {
				case "Java":
					//classBodyとしてパースするために中括弧を補う
					code = "{ " + code + " }";
					ast = JavaCodeToXml.Instance.Generate(code, p => p.classBody());
					var classBody = JavaModelFactoryHelper.CreateClassBody(ast);
					foreach (var e in classBody) {
						var method = e as UnifiedFunction;
						var field = e as UnifiedVariableDefinitionList;
						if(field != null)
							actual.Add(field);
						if(method != null)
							actual.Add(method);
					}
					break;

				case "JavaScript":
					ast = JavaScriptCodeToXml.Instance.Generate(code, p => p.program());
					var program = JavaScriptModelFactoryHelper.CreateProgram(ast);
					foreach(var e in program) {
						actual.Add(e);
					}
					break;
				default:
					throw new NotImplementedException();
			}
			return actual;
		}

		#region Execution

		/// <summary>
		///   指定された関数ブロックの先頭に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeExecution(
				IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//get function list
			var functions = root.Descendants<UnifiedFunction>();

			foreach (var e in functions) {
				//weave given advice, when function's name matches given Regex
				var m = regex.Match(e.Name.Name);
				if (m.Success)
					e.Body.Insert(0, advice);
			}
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
			var functions = root.Descendants<UnifiedFunction>();

			foreach (var function in functions) {
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
					function.Body.Add(advice);
				} else {
					foreach (var returnStmt in returns) {
						var block = returnStmt.Parent as UnifiedBlock;
						if (block == null)
							continue;
						block.Insert(block.IndexOf(returnStmt, 0), advice);
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

		#endregion

		#region Call

		/// <summary>
		///   指定された関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeCall(
				IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//get cass list
			var calls = root.Descendants<UnifiedCall>().ToList();

			//親要素がUnifiedBlockの場合に、その関数呼び出しは単項式であると判断する。
			foreach (var call in calls) {
				//プロパティでない関数呼び出しのみを扱う
				//e.g. write()はOK. Math.max()はNG.
				var functionName = call.Function as UnifiedIdentifier;
				if(functionName == null)
					continue;

				// 現状ではToString()とのマッチングを行う。
				var m = regex.Match(functionName.Name);
				if (!m.Success)
					continue;
				
				//TODO JavaScriptの場合に親がブロックではない場合があるので、それに対応できるようにする
				var block = call.Parent as UnifiedBlock;
				if (block == null)
					continue;
				block.Insert(block.IndexOf(call, 0), advice);
			}
		}

		/// <summary>
		///   指定された関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "regex">対象関数を指定する正規表現</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterCall(
				IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//get cass list
			var calls = root.Descendants<UnifiedCall>().ToList();

			//親要素がUnifiedBlockの場合に、その関数呼び出しは単項式であると判断する。
			foreach (var call in calls) {
				//プロパティでない関数呼び出しのみを扱う
				//e.g. write()はOK. Math.max()はNG.
				var functionName = call.Function as UnifiedIdentifier;
				if(functionName == null)
					continue;

				var m = regex.Match(functionName.Name);
				if (!m.Success)
					continue;

				var block = call.Parent as UnifiedBlock;
				if (block == null)
					continue;
				block.Insert(block.IndexOf(call, 0) + 1, advice);
			}
		}

		/// <summary>
		///   すべての関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeCallAll(IUnifiedElement root, UnifiedBlock advice) {
			InsertAtBeforeCall(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   すべての関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルードノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterCallAll(IUnifiedElement root, UnifiedBlock advice) {
			InsertAtAfterCall(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   指定された関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeCallByName(
				IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtBeforeCall(root, new Regex("^" + name + "$"), advice);
		}

		/// <summary>
		///   指定された関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルードノード</param>
		/// <param name = "name">対象関数の名前</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterCallByName(
				IUnifiedElement root, string name, UnifiedBlock advice) {
			InsertAtAfterCall(root, new Regex("^" + name + "$"), advice);
		}

		#endregion
	}
}