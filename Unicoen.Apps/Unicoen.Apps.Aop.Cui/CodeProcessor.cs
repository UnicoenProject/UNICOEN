﻿#region License

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
using Code2Xml.Languages.C.CodeToXmls;
using Code2Xml.Languages.Java.CodeToXmls;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Unicoen.Core.Model;
using Unicoen.Languages.C;
using Unicoen.Languages.C.ModelFactories;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java;
using Unicoen.Languages.Java.ModelFactories;
using Unicoen.Languages.JavaScript;
using Unicoen.Languages.JavaScript.ModelFactories;
using Unicoen.Languages.Python2;

namespace Unicoen.Apps.Aop {
	/// <summary>
	///   アスペクト指向プログラミングに必要なソースコードの加工処理メソッドを保有します。
	/// </summary>
	public class CodeProcessor {
		/// <summary>
		///   与えられたソースコードを共通モデルに変換します
		/// </summary>
		/// <param name = "ext">対象言語の拡張子</param>
		/// <param name = "code">対象ソースコードの中身</param>
		/// <returns></returns>
		public static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpFactory.GenerateModel(code);
			case ".java":
				return JavaFactory.GenerateModel(code);
			case ".js":
				return JavaScriptFactory.GenerateModel(code);
			case ".c":
			case ".h":
				return CFactory.GenerateModel(code);
			case ".py":
				return Python2Factory.GenerateModel(code);
			}
			//Ruby
			throw new InvalidOperationException("対応していない言語ファイルが指定されました");
		}

		/// <summary>
		///   与えられたコードを共通コードモデルとして生成します。
		/// </summary>
		/// <param name = "language">対象言語</param>
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
			case "C":
				//TODO Cでのアスペクト合成はこれで大丈夫か確認
				ast = CCodeToXml.Instance.Generate(code, p => p.compound_statement());
				actual = CModelFactoryHelper.CreateCompoundStatement(ast);
				break;
			default:
				//CSharp, Ruby, Python
				throw new InvalidOperationException("対応していない言語が指定されました");
			}
			actual.Normalize();

			return actual;
		}

		/// <summary>
		///   与えられたコードをインタータイプ宣言のために共通コードモデルとして生成します
		/// </summary>
		/// <param name = "language">対象言語</param>
		/// <param name = "code">コード断片</param>
		/// <returns></returns>
		public static List<IUnifiedExpression> CreateIntertype(
				string language, string code) {
			XElement ast = null;
			var actual = new List<IUnifiedExpression>();

			switch (language) {
			case "Java":
				//classBodyとしてパースするために中括弧を補う
				code = "{ " + code + " }";
				ast = JavaCodeToXml.Instance.Generate(code, p => p.classBody());
				var classBody = JavaModelFactoryHelper.CreateClassBody(ast);
				foreach (var e in classBody) {
					var method = e as UnifiedFunctionDefinition;
					var field = e as UnifiedVariableDefinitionList;
					if (field != null)
						actual.Add(field);
					if (method != null)
						actual.Add(method);
				}
				break;

			case "JavaScript":
				ast = JavaScriptCodeToXml.Instance.Generate(code, p => p.program());
				var program = JavaScriptModelFactoryHelper.CreateProgram(ast);
				actual.AddRange(program.Body);
				break;
			default:
				//TODO implement 他の言語についても実装する
				throw new NotImplementedException();
			}
			return actual;
		}

		#region Intertype

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

		#endregion

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
				if (functionName == null)
					continue;

				// 現状ではToString()とのマッチングを行う。
				var m = regex.Match(functionName.Name);
				if (!m.Success)
					continue;

				//(Javaにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
				//(JavaScriptにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
				var block = call.Parent as UnifiedBlock;
				if (block != null)
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
				if (functionName == null)
					continue;

				var m = regex.Match(functionName.Name);
				if (!m.Success)
					continue;

				//(Javaにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
				//(JavaScriptにおいて)関数呼び出しの親ノードがブロックの場合、それは単独である
				var block = call.Parent as UnifiedBlock;
				if (block != null)
					block.Insert(block.IndexOf(call, 0) + 1, advice);
			}
		}

		/// <summary>
		///   すべての関数呼び出しの直前に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルートノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtBeforeCallAll(
				IUnifiedElement root, UnifiedBlock advice) {
			InsertAtBeforeCall(root, new Regex(".*"), advice);
		}

		/// <summary>
		///   すべての関数呼び出しの後に、指定されたコードを共通コードモデルとして挿入します。
		/// </summary>
		/// <param name = "root">コードを追加するモデルのルードノード</param>
		/// <param name = "advice">挿入するコード断片</param>
		public static void InsertAtAfterCallAll(
				IUnifiedElement root, UnifiedBlock advice) {
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

		#region GetSet

		// a = b; a = 10; b;
		// a -> set joinpoint
		// b -> get joinpoint

		//getはBinaryExpressionの左辺以外の変数(UnifiedVariableIdentifier)？
		//かつ、親ノードがブロックの場合とまずは少ない範囲からいきましょう
		public static void InsertAtBeforeGet(IUnifiedElement root, Regex regex, UnifiedBlock advice) {
			//a = b;
			//TODO とりえあずAssignのみ +=,-=などについてはおいおい
			var assignmentExpressions =
					root.Descendants<UnifiedBinaryExpression>().Where(e => e.Operator.Kind == UnifiedBinaryOperatorKind.Assign);
			

			//TODO int a = b;のような初期化子付きの変数宣言を対象にできていない！
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

		#endregion
	}
}