using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using Antlr.Runtime.Tree;
using Microsoft.Win32;
using Paraiba.Text;
using Unicoen.Apps.Aop;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace AopGUI
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		private static readonly string[] TargetLanguage = new[] { ".java", ".js" };

		public MainWindow()
		{
			InitializeComponent();
		}

		private void WindowLoaded(object sender, RoutedEventArgs e)
		{
			//Nothing do
		}

		private void GetTargetContent(object sender, RoutedEventArgs e)
		{
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
			var filePath = TargetPath.Text;
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

			//指定されたパス以下にあるソースコードのパスをすべて取得します
			var targetFiles = AspectAdaptor.Collect(filePath);

			foreach (var file in targetFiles) {
				var fileExtension = Path.GetExtension(file);
				//対象言語のソースコードでない場合はコンティニュー
				if (Array.IndexOf(TargetLanguage, fileExtension) < 0) //TODO これでフィルタリングが正しいか確認
					continue;

				var code = File.ReadAllText(file, XEncoding.SJIS);
				var model = CodeProcessor.CreateModel(fileExtension, code);

				//TODO もっとスマートな変換を考える(そもそも変換しない方法も検討する)
				string langType;
				switch (fileExtension) {
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
				switch (langType) {
				case "Java":
					WeavedSourceArea.Text += JavaFactory.GenerateCode(model);
					WeavedSourceArea.Text += "\n";
					break;
				case "JavaScript":
					WeavedSourceArea.Text += JavaScriptFactory.GenerateCode(model);
					break;
				default:
					throw new NotImplementedException();
				}
			}
		}
	}
}
