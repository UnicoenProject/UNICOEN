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
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Paraiba.Text;
using Unicoen.Apps.UniAspect.Cui;
using Unicoen.Apps.UniAspect.Cui.AspectCompiler;
using Unicoen.Apps.UniAspect.Cui.CodeProcessor;
using Unicoen.Apps.UniAspect.Cui.Visitor;
using Unicoen.Tests;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace Unicoen.Apps.Aop.Gui {
	/// <summary>
	///   MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window {
		private static readonly Dictionary<string, string> TargetLanguage =
				new Dictionary<string, string>();

		public MainWindow() {
			InitializeComponent();

			TargetLanguage.Add(".java", "Java");
			TargetLanguage.Add(".js", "JavaScript");
			//TargetLanguage.Add(".cs", "CSharp");
			//TargetLanguage.Add(".c", "C");
			//TargetLanguage.Add(".rb", "Ruby");
			//TargetLanguage.Add(".py", "Python");
		}

		private void WindowLoaded(object sender, RoutedEventArgs e) {
			//Nothing do
		}

		private void GetTargetContent(object sender, RoutedEventArgs e) {
			//フォルダ選択用のダイアログを作成
			/*
			var dialog = new FolderBrowserDialog {
					Description = @"Select Target Project"
			};
			if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				TargetPath.Text = dialog.SelectedPath;
			}
			*/

			var dialog = new OpenFileDialog();
			dialog.FileName = "";
			dialog.DefaultExt = "*.*";
			if (dialog.ShowDialog() == true) {
				TargetPath.Text = dialog.FileName;
			}
			if (dialog.FileName.Length > 0) {
				var code = File.ReadAllText(
						dialog.FileName, Encoding.GetEncoding("Shift_JIS"));
				OriginalSourceArea.Text = code;
			}
		}

		private void GetAspectContent(object sender, RoutedEventArgs e) {
			var dialog = new OpenFileDialog();
			dialog.FileName = "";
			dialog.DefaultExt = "*.*";
			if (dialog.ShowDialog() == true) {
				AspectPath.Text = dialog.FileName;
			}
			if (dialog.FileName.Length > 0) {
				var code = File.ReadAllText(
						dialog.FileName, Encoding.GetEncoding("Shift_JIS"));
				AspectSourceArea.Text = code;
			}
		}

		private void Weave(object sender, RoutedEventArgs e) {
			var javaCount = 0;
			var jsCount = 0;
			var prev = 0;

			var stopwatch = new Stopwatch();
			stopwatch.Start();

			//選択されたパスからファイルを取得
			var targetPath = TargetPath.Text;
			var aspectPath = AspectPath.Text;

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

			//指定されたパス以下にあるディレクトリをすべてoutput以下にコピーします
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();

			var directories = Directory.EnumerateDirectories(
					targetPath, "*", SearchOption.AllDirectories);
			foreach (var dir in directories) {
				var newDir = dir.Replace(targetPath, workPath);
				//WeavedSourceArea.Text += newDir;
				Directory.CreateDirectory(newDir);
			}
			//指定されたパス以下にあるソースコードのパスをすべて取得します
			var targetFiles = AspectAdaptor.Collect(targetPath);

			foreach (var file in targetFiles) {
				//対象ファイルの拡張子を取得
				var fileExtension = Path.GetExtension(file);
				var newPath = file.Replace(targetPath, workPath);

				//対象言語のソースコードでない場合は次の対象へ進む
				string langType;
				if (fileExtension == null
				    || !TargetLanguage.TryGetValue(fileExtension, out langType)) {
					//対象プログラミング言語ソースファイル以外はそのままコピーする
					File.Copy(file, newPath);
					continue;
				}

				var code = File.ReadAllText(file, XEncoding.SJIS);
				var model = CodeProcessor.CreateModel(fileExtension, code);

				//アスペクトの合成を行う
				ExtendAspectAdaptor.Weave(langType, model, visitor);

				//ファイル出力
				switch (langType) {
				case "Java":
					File.WriteAllText(newPath, JavaFactory.GenerateCode(model));
					javaCount += (CodeProcessor.WeavingCount - prev);
					break;
				case "JavaScript":
					File.WriteAllText(newPath, JavaScriptFactory.GenerateCode(model));
					jsCount += (CodeProcessor.WeavingCount - prev);
					break;
				default:
					throw new NotImplementedException();
				}

				prev = CodeProcessor.WeavingCount;

				/*
				//とりえあず標準出力に表示;
				switch (langType) {
				case "Java":
					WeavedSourceArea.Text += JavaFactory.GenerateCode(model);
					WeavedSourceArea.Text += "\n";
					break;
				case "JavaScript":
					WeavedSourceArea.Text += JavaScriptFactory.GenerateCode(model);
					WeavedSourceArea.Text += "\n";
					break;
				default:
					throw new NotImplementedException();
				}
				*/
			}
			stopwatch.Stop();
			WeavedSourceArea.Text += stopwatch.Elapsed;
			WeavedSourceArea.Text += "\nJava: " + javaCount;
			WeavedSourceArea.Text += "\nJS: " + jsCount;
		}

		private void WeaveForOne(object sender, RoutedEventArgs e) {
			//選択されたパスからファイルを取得
			var targetPath = TargetPath.Text;
			var aspectPath = AspectPath.Text;

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

			//対象ファイルの拡張子を取得
			var fileExtension = Path.GetExtension(targetPath);

			//対象言語のソースコードでない場合は次の対象へ進む
			string langType;
			if (fileExtension == null
				|| !TargetLanguage.TryGetValue(fileExtension, out langType)) {
				WeavedSourceArea.Text = "指定のプログラミング言語には対応していません";
				return;
			}

			var code = File.ReadAllText(targetPath, XEncoding.SJIS);
			var model = CodeProcessor.CreateModel(fileExtension, code);

			//アスペクトの合成を行う
			AspectAdaptor.Weave(langType, model, visitor);

			//とりえあず標準出力に表示;
			switch (langType) {
			case "Java":
				WeavedSourceArea.Text = JavaFactory.GenerateCode(model);
				break;
			case "JavaScript":
				WeavedSourceArea.Text = JavaScriptFactory.GenerateCode(model);
				break;
			default:
				throw new InvalidOperationException();
			}
		}
	}
}