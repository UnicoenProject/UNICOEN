using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using Antlr.Runtime.Tree;
using Microsoft.Win32;
using Paraiba.Text;
using Unicoen.Apps.Aop;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Core.Tests;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace AopGUI
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		private static readonly Dictionary<string, string> TargetLanguage = new Dictionary<string, string>();

		public MainWindow()
		{
			InitializeComponent();

			TargetLanguage.Add(".java", "Java");
			TargetLanguage.Add(".js", "JavaScript");
			//TargetLanguage.Add(".cs", "CSharp");
			//TargetLanguage.Add(".c", "C");
			//TargetLanguage.Add(".rb", "Ruby");
			//TargetLanguage.Add(".py", "Python");
		}

		private void WindowLoaded(object sender, RoutedEventArgs e)
		{
			//Nothing do
		}

		private void GetTargetContent(object sender, RoutedEventArgs e) {
			var dialog = new OpenFileDialog();
			dialog.FileName = "";
			dialog.DefaultExt = "*.*";
			if(dialog.ShowDialog() == true)
			{
				TargetPath.Text = dialog.FileName;
			}
			if(dialog.FileName.Length > 0)
			{
				var code = File.ReadAllText(dialog.FileName, Encoding.GetEncoding("Shift_JIS"));
				OriginalSourceArea.Text = code;
			}
		}

		private void GetAspectContent(object sender, RoutedEventArgs e)
		{
			var dialog = new OpenFileDialog();
			dialog.FileName = "";
			dialog.DefaultExt = "*.*";
			if(dialog.ShowDialog() == true)
			{
				AspectPath.Text = dialog.FileName;
			}
			if (dialog.FileName.Length > 0)
			{
				var code = File.ReadAllText(dialog.FileName, Encoding.GetEncoding("Shift_JIS"));
				AspectSourceArea.Text = code;
			}
		}

		private void Weave(object sender, RoutedEventArgs e)
		{
			//選択されたパスからファイルを取得
			var targetPath = TargetPath.Text;
			var aspectPath = AspectPath.Text;

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


			//指定されたパス以下にあるディレクトリをすべてoutput以下にコピーします
			var workPath = FixtureUtil.CleanOutputAndGetOutputPath();
			var directories = Directory.EnumerateDirectories(targetPath, "*", SearchOption.AllDirectories);
			foreach(var dir in directories) {
				var newDir = dir.Replace(targetPath, workPath);
				WeavedSourceArea.Text += newDir;
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
				if(fileExtension == null || !TargetLanguage.TryGetValue(fileExtension, out langType)) {
					//対象プログラミング言語ソースファイル以外はそのままコピーする
					File.Copy(file, newPath);
					continue;
				}

				var code = File.ReadAllText(file, XEncoding.SJIS);
				var model = CodeProcessor.CreateModel(fileExtension, code);

				//アスペクトの合成を行う
				AspectAdaptor.Weave(langType, model, visitor);

				//ファイル出力
				switch(langType) {
					case "Java":
						File.WriteAllText(newPath, JavaFactory.GenerateCode(model));
						break;
					case "JavaScript":
						File.WriteAllText(newPath, JavaScriptFactory.GenerateCode(model));
						break;
					default:
						throw new NotImplementedException();
				}

				//とりえあず標準出力に表示;
				switch(langType) {
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
			}
		}
	}
}
