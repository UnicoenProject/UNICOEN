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
using System.IO;
using Antlr.Runtime.Tree;
using Paraiba.Text;
using Unicoen.Apps.Aop.Visitor;

namespace Unicoen.Apps.Aop {
	public class Program {

		//TODO write usage
		private const string Usage = "Usage:";

		private static void Main(string[] args) {
			/* params
			 *  :  args[0] -> コマンド名
			 *  :  args[1] -> ウィーブ対象フォルダのパス
			 *  :  args[2] -> アスペクトファイルのパス
			 */
			var symbol = args[0];
			if(!symbol.Equals("aries")) {
				Console.WriteLine(Usage);
				return;
			}

			var filePath = args[1];
			var aspectPath = args[2];

			//アスペクト情報を持つオブジェクトを生成する
			var aspect = new Antlr.Runtime.ANTLRFileStream(aspectPath);
			var lexer = new AriesLexer(aspect);
			var tokens = new Antlr.Runtime.CommonTokenStream(lexer);
			var parser = new AriesParser(tokens);

			//アスペクトファイルを解析してASTを生成する
			var result = parser.aspect();
			var ast = (CommonTree) result.Tree;

			//ASTを走査してパース結果をアスペクトオブジェクトとしてvisitor内に格納する
			var visitor = new AstVisitor();
			visitor.Visit(ast, 0, null);

			//指定されたパス以下にあるソースコードをすべて取得します
			var targetFiles = FileCollector.Collect(filePath);
			//TODO ファイルを中身で返すか、パスで返すか検討
			foreach (var file in targetFiles) {
				var fileExtension = Path.GetExtension(filePath);
				//TODO ソースコード以外のファイルだった場合にはcontinue
				var code = File.ReadAllText(file, XEncoding.SJIS);
				var model = CodeProcessor.CreateModel(fileExtension, code);

				AspectAdaptor.Weave(fileExtension, model, visitor);
				//TODO 出力処理 or ファイル書き出し処理
			}
		}
	}
}