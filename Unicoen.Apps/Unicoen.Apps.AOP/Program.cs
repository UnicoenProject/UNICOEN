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
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.Aop {
	public class Program {

		//TODO write usage
		private const string Usage = "Usage:";
		private static readonly string[] TargetLanguage = new[] { ".java", ".js" };

		private static void Main(string[] args) {
			/* params
			 *  :  args[0] -> コマンド名
			 *  :  args[1] -> ウィーブ対象フォルダのパス
			 *  :  args[2] -> アスペクトファイルのパス
			 */
			
			/*
			var symbol = args[0];
			if(!symbol.Equals("aries")) {
				Console.WriteLine(Usage);
				return;
			}
			*/

			//var filePath = args[1];
			//var aspectPath = args[2];
			//TODO 一時実験用のファイルパス -> 最終的には引数で取るようにする
			var filePath = "../../fixture/AspectCompiler/mainInput";
			var aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/before_execution.txt";

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

			//指定されたパス以下にあるソースコードのパスをすべて取得します
			var targetFiles = AspectAdaptor.Collect(filePath);

			foreach (var file in targetFiles) {
				var fileExtension = Path.GetExtension(file);
				//対象言語のソースコードでない場合はコンティニュー
				if(Array.IndexOf(TargetLanguage, fileExtension) < 0) //TODO これでフィルタリングが正しいか確認
					continue;

				var code = File.ReadAllText(file, XEncoding.SJIS);
				var model = CodeProcessor.CreateModel(fileExtension, code);
				
				//TODO もっとスマートな変換を考える(そもそも変換しない方法も検討する)
				string langType;
				switch(fileExtension) {
					case ".java":
						langType = "Java";
						break;
					case ".js":
						langType = "JavaScript";
						break;
					default:
						throw new NotImplementedException();
				}

				//アスペクトの合成を行う
				AspectAdaptor.Weave(langType, model, visitor);

				//とりえあず標準出力に表示);
				switch(langType) {
					case "Java":
						Console.WriteLine(JavaFactory.GenerateCode(model));
						break;
					case "JavaScript":
						Console.WriteLine(JavaScriptFactory.GenerateCode(model));
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}
	}
}