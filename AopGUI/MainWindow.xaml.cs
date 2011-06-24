using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using Microsoft.Win32;

namespace AopGUI
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
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
			//weave
			WeavedSourceArea.Text = "weaved";

			var p = new Process();
			StreamReader reader;

			p.StartInfo.FileName = "../../lib/Unicoen.Apps.Aop.exe";
			p.StartInfo.Arguments = "aries " + TargetPath.Text + " " + AspectPath.Text;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.CreateNoWindow = true;

			p.Start();
			p.WaitForExit();

			reader = p.StandardOutput;

			var result = "";
			while(reader.Peek() > -1)
			{
				result += reader.ReadLine();
			}
			WeavedSourceArea.Text = result;
		}
	}
}
