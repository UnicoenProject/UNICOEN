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
using System.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Unicoen.Apps.UniAspect.Cui.AspectCompiler;
using Unicoen.Apps.UniAspect.Cui.AspectElement;
using Unicoen.Apps.UniAspect.Cui.Visitor;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;
using Unicoen.Model;
using Unicoen.Tests;

namespace Unicoen.Apps.UniAspect.Cui {
	public static class Weaver {

		// アスペクトファイルを解析してその結果を保持する
		private static AstVisitor _visitor;

		// アスペクトファイルを解析してその結果をフィールドに格納します
		public static void AnalizeAspect(string aspectPath) {
			//アスペクト情報を持つオブジェクトを生成する
			var aspect = new ANTLRFileStream(aspectPath);
			var lexer = new AriesLexer(aspect);
			var tokens = new CommonTokenStream(lexer);
			var parser = new AriesParser(tokens);

			//アスペクトファイルを解析してASTを生成する
			var result = parser.aspect();
			var ast = (CommonTree)result.Tree;

			//ASTを走査してパース結果をアスペクトオブジェクトとしてvisitor内に格納する
			_visitor = new AstVisitor();
			_visitor.Visit(ast, 0, null);
		}
		
		// アスペクトの合成処理を実行します
		// このメソッドはすべてのファイルに対してWeave()メソッドを呼び出す処理を行い、
		// 実際の合成処理はWeave()メソッドが行います
		public static void Run(string directoryPath) {
			
			//指定されたパス以下にあるディレクトリをすべてoutput以下にコピーします
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();
			var directories = Directory.EnumerateDirectories(
					directoryPath, "*", SearchOption.AllDirectories);
			foreach (var dir in directories) {
				var newDir = dir.Replace(directoryPath, workPath);
				//WeavedSourceArea.Text += newDir;
				Directory.CreateDirectory(newDir);
			}

			//指定されたパス以下にあるソースコードのパスをすべて取得します
			var targetFiles = Collect(directoryPath);

			foreach (var file in targetFiles) {
				var newPath = file.Replace(directoryPath, workPath);

				// 対象ファイルの統合コードオブジェクトを生成する
				var model = UniGenerators.GenerateProgramFromFile(file);
				// TODO 対応していない拡張子の場合はどうなるのか確認
				if (model == null) {
					File.Copy(file, newPath);
					continue;
				}

				//アスペクトの合成を行う
				Weave(ExtenstionToLanguageName(Path.GetExtension(file)), model);

				// TODO モデルの出力先をここに記述する
				// TODO 拡張子がこれで合っているか確認する
				switch (Path.GetExtension(file)) {
					case "Java":
						File.WriteAllText(newPath, JavaFactory.GenerateCode(model));
						break;
					case "JavaScript":
						File.WriteAllText(newPath, JavaScriptFactory.GenerateCode(model));
						break;
					default:
						throw new NotImplementedException();
				}
			}
		}

		// ポイントカットをポイントカット名で参照できるようにします
		private static readonly Dictionary<string, Pointcut> Pointcuts =
				new Dictionary<string, Pointcut>();

		// 統合コードオブジェクトに対してアスペクトの合成処理を行います
		public static void Weave(string language, UnifiedProgram model) {
			//以前のアスペクトファイルの情報を消去するために辞書の内容を初期化する
			Pointcuts.Clear();

			//与えられたモデルに対してインタータイプを合成する
			foreach (var intertype in _visitor.Intertypes) {
				if (intertype.GetLanguageType() != language)
					continue;
				var members = CodeProcessor.CodeProcessor.CreateIntertype(
						intertype.GetLanguageType(), intertype.GetContents());
				CodeProcessor.CodeProcessor.AddIntertypeDeclaration(model, intertype.GetTarget(), members);
			}

			//ポイントカットを登録する
			foreach (var pointcut in _visitor.Pointcuts) {
				var name = pointcut.GetName();
				//同じ名前のポイントカットがある場合にはエラーとする
				if (Pointcuts.ContainsKey(name))
					throw new InvalidOperationException(
							"同名のポイントカットがすでに宣言されています: " + name);
				//ポイントカットを自身の名前で登録
				Pointcuts.Add(name, pointcut);
			}

			//アドバイスの適用
			foreach (var advice in _visitor.Advices) {
				//アドバイスのターゲットがポイントカット宣言されていない場合はエラーとする
				if (!Pointcuts.ContainsKey(advice.GetTarget()))
					throw new InvalidOperationException(
							"指定されたポイントカットは宣言されていません");

				//アドバイスのターゲットが登録されていれば、それに対応するポイントカットを取得する
				Pointcut target;
				Pointcuts.TryGetValue(advice.GetTarget(), out target);

				//指定された言語のアドバイスがあればそれをモデルに変換する
				UnifiedBlock code = null;
				foreach (var languageDependBlock in advice.GetFragments()) {
					//
					if (languageDependBlock.GetLanguageType().Equals(language)) {
						code = CodeProcessor.CodeProcessor.CreateAdvice(
								language, languageDependBlock.GetContents());
						break;
					}
				}
				//現在の対象ファイルの言語向けアドバイスが定義されていない場合は次のアドバイス処理に移る
				if (code == null)
					continue;

				//ポイントカットの指定に応じて適切なアドバイスの合成処理を行う
				//TODO ワイルドカードなどへの対応
				//TODO 複数のターゲットを持つポイントカットへの対応(これはそもそもパーサを改良する必要あり)

				var methodName = target.GetTargetName().ElementAt(1);

				// アドバイスの合成
				// リフレクションを用いて、対応するメソッドが呼び出されます

				// ポイントカットの型に対応するクラスをインスタンス化するため、最初の1文字を大文字にします
				var pointcutType = target.GetPointcutType().ToUpper().Substring(0,1) + target.GetPointcutType().Substring(1);
				var type = Type.GetType("Unicoen.Apps.UniAspect.Cui.CodeProcessor." + pointcutType);
				var aspect = Activator.CreateInstance(type);

				var aOrb = advice.GetAdviceType() == "before" ? 0 : 1;
				var m = type.GetMethod(target.GetPointcutType());
				Object[] objs = {aOrb, model, methodName, code};
				m.Invoke(aspect, objs);
			}
		}

		# region Utilities

		// 指定されたフォルダ以下にあるファイルのパスのリストを返します
		public static IEnumerable<string> Collect(string folderRootPath) {
			//指定された文字列がフォルダじゃなかった場合
			if (!Directory.Exists(folderRootPath)) {
				var list = new List<string>();
				list.Add(folderRootPath);
				return list;
			}

			//指定された文字列に該当するフォルダがある場合
			return Directory.EnumerateFiles(
					folderRootPath, "*", SearchOption.AllDirectories);
		}

		// 拡張子名から言語名を返します
		private static string ExtenstionToLanguageName(string ext) {
			switch (ext) {
				case ".java":
					return "Java";
				case ".js":
					return "JavaScript";
				default:
					throw new NotImplementedException();
			}
		}

		# endregion
	}
}