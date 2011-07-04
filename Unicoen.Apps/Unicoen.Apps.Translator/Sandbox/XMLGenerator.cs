using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Unicoen.Core.Model;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.Translator {
	/// <summary>
	/// inputFilePath の構造XMLを outputDirPath に出力するユーティリティ
	/// </summary>
	public class XMLGenerator {
		/// <summary>
		/// inputFilePath に対応する ModelGenerator を取得する
		/// （単に拡張子で判断しているだけ）
		/// </summary>
		/// <param name="inputFilePath"></param>
		/// <returns></returns>
		private static Func<string, UnifiedProgram> GetModelGenerator(string inputFilePath) {
			var ext = Path.GetExtension(inputFilePath);
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

			return modelGenerator;

		}

		public static void GenerateXML(string inputFilePath, string outputDirPath) {
			if (!File.Exists(inputFilePath)) {
				throw new FileNotFoundException();
			}

			var modelGenerator = GetModelGenerator(inputFilePath);

			var model = modelGenerator(File.ReadAllText(inputFilePath));
			var fileName = Path.GetFileName(inputFilePath);
			var path = outputDirPath + fileName + ".xml";

			using (var fs = new FileStream(path, FileMode.Create)) {
				using (var writer = new StreamWriter(fs)) {
					writer.WriteLine(model.ToXml());
				}
			}
		}

		public static XmlDocument GenerateXML(string inputFilePath) {
			if (!File.Exists(inputFilePath)) {
				throw new FileNotFoundException();
			}

			var modelGenerator = GetModelGenerator(inputFilePath);

			var model = modelGenerator(inputFilePath);
			var xmlString = model.ToXml();

			var xmlDocument = new XmlDocument();
			var reader = new StringReader(xmlString);
			xmlDocument.Load(reader);

			return xmlDocument;

		}

		public static void GenerateDiffgram(string srcPath1, string srcPath2) {
			
		}
	}
}