using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.Translator {
	/// <summary>
	/// inputFilePath の構造XMLを outputDirPath に出力するユーティリティ
	/// </summary>
	public class XMLGenerator {
		public static void GenerateXML(string inputFilePath, string outputDirPath) {
			if (!File.Exists(inputFilePath)) {
				throw new FileNotFoundException();
			}

			var ext = Path.GetExtension(inputFilePath);
			Console.WriteLine(ext);
			Func<string, UnifiedProgram> modelGenerator;
			switch (ext) {
				case ".java":
					modelGenerator = JavaFactory.GenerateModel;
					break;
				case ".js":
					modelGenerator = JavaScriptFactory.GenerateModel;
					break;
				default:
					throw new NotImplementedException();

			}

			var model = modelGenerator(File.ReadAllText(inputFilePath));
			var fileName = Path.GetFileName(inputFilePath);
			var path = outputDirPath + fileName + ".xml";

			using (var fs = new FileStream(path, FileMode.Create)) {
				using (var writer = new StreamWriter(fs)) {
					writer.WriteLine(model.ToXml());
				}
			}
		}
	}
}