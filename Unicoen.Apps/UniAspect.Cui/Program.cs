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
using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Paraiba.Text;
using Unicoen.Apps.UniAspect.Cui.AspectCompiler;
using Unicoen.Apps.UniAspect.Cui.Visitor;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.UniAspect.Cui {
	public class Program {
		private const string Usage =
				"Usage: aries <rootDirectoryPath> <aspectFilePath>\nyou should specify missing parameter(s).";

		private static readonly Dictionary<string, string> TargetLanguage =
				new Dictionary<string, string>();

		static Program() {
			TargetLanguage.Add(".java", "Java");
			TargetLanguage.Add(".js", "JavaScript");
			TargetLanguage.Add(".cs", "CSharp");
			TargetLanguage.Add(".c", "C");
			TargetLanguage.Add(".rb", "Ruby");
			TargetLanguage.Add(".py", "Python");
		}

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

			//TODO 動かす際にはfilePathにディレクトリを指定する
			const string filePath = "";
			const string aspectPath = "../../fixture/Aspect/input/partial_aspect/before_execution.txt";

			//アスペクト情報を持つオブジェクトを生成する
			var aspect = new ANTLRFileStream(aspectPath);
			var lexer = new AriesLexer(aspect);
			var tokens = new CommonTokenStream(lexer);
			var parser = new AriesParser(tokens);

			//アスペクトファイルを解析してASTを生成する
			var result = parser.aspect();
			var ast = (CommonTree)result.Tree;

			//ASTを走査してパース結果をアスペクトオブジェクトとしてvisitor内に格納する
			var visitor = new AstVisitor();
			visitor.Visit(ast, 0, null);

			//指定されたパス以下にあるソースコードのパスをすべて取得します
			var targetFiles = AspectAdaptor.Collect(filePath);

			foreach (var file in targetFiles) {
				//対象ファイルの拡張子を取得
				var fileExtension = Path.GetExtension(file);

				//対象言語のソースコードでない場合は次の対象へ進む
				string langType;
				if (fileExtension == null
				    || !TargetLanguage.TryGetValue(fileExtension, out langType))
					continue;

				var code = File.ReadAllText(file, XEncoding.SJIS);
				var model = CodeProcessor.CodeProcessor.CreateModel(fileExtension, code);

				//アスペクトの合成を行う
				AspectAdaptor.Weave(langType, model, visitor);

				//とりえあず標準出力に表示;
				switch (langType) {
				case "Java":
					Console.WriteLine(JavaFactory.GenerateCode(model));
					Console.WriteLine();
					break;
				case "JavaScript":
					Console.WriteLine(JavaScriptFactory.GenerateCode(model));
					Console.WriteLine();
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}
	}
}