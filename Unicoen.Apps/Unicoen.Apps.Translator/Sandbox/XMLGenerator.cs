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
using Unicoen.Core.Model;
using Unicoen.Languages.Java;
using Unicoen.Languages.JavaScript;

namespace Unicoen.Apps.Translator {
	/// <summary>
	///   ソースファイルの共通表現オブジェクトをXMLにシリアライズして出力する機能を提供します．
	/// </summary>
	public static class XmlGenerator {
		public static void GenerateXml(string inputFilePath, string outputDirPath) {
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