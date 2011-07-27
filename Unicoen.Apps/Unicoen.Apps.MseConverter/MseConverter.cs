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

using System.IO;
using Unicoen.Languages.CSharp.ModelFactories;
using Unicoen.Languages.Java.ModelFactories;
using Unicoen.Languages.JavaScript.ModelFactories;
using Unicoen.Languages.Python2.ModelFactories;
using Unicoen.Languages.Ruby18.Model;
using Unicoen.Model;

namespace Unicoen.Apps.MseConverter {
	public class MseConverter {
		private readonly MseConvertVisitor _visitor;

		public MseConverter(TextWriter writer) {
			_visitor = new MseConvertVisitor(writer);
		}

		public void Generate(string dirPath, TextWriter writer) {
			dirPath = Path.GetFullPath(dirPath);
			var filePaths = Directory.EnumerateFiles(
					dirPath, "*", SearchOption.AllDirectories);

			writer.WriteLine("(Moose.Model (id: 1)");
			writer.WriteLine("(entity");
			
			//言語による色付けをするための処理
			writer.WriteLine("(FAMIX.Namespace (id: 2)");
			writer.WriteLine("(name 'ColorSample'))");
			writer.WriteLine("(FAMIX.Class (id: 3)");
			writer.WriteLine("(name 'Java')");
			writer.WriteLine("(belongsTo (idref: 2))");
			writer.WriteLine("(WMC 0.00))");
			writer.WriteLine("(FAMIX.Class (id: 4)");
			writer.WriteLine("(name 'Ruby')");
			writer.WriteLine("(belongsTo (idref: 2))");
			writer.WriteLine("(WMC 4.00))");

			foreach (var filePath in filePaths) {
				//名前空間、クラスがない場合向けにファイルネームを登録しておく
				var namespaceName = filePath.Substring(dirPath.Length + 1);
				_visitor.DefaultNamespace = UnifiedNamespaceDefinition.Create(
						null, null, UnifiedVariableIdentifier.Create(namespaceName));
				_visitor.DefaultClass = UnifiedClassDefinition.Create(
						null, null, UnifiedVariableIdentifier.Create(namespaceName));
				switch (Path.GetExtension(filePath)) {
				case ".java":
					//_visitor.CodeFactory = new JavaCodeFactory();
					_visitor.LanguageValue = 0;
					new JavaModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".js":
					//_visitor.CodeFactory = new JavaScriptCodeFactory();
					_visitor.LanguageValue = 2;
					new JavaScriptModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".cs":
					//_visitor.CodeFactory = new CSharpCodeFactory();
					_visitor.LanguageValue = 1;
					new CSharpModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".rb":
					//_visitor.CodeFactory = new Ruby18CodeFactory();
					_visitor.LanguageValue = 4;
					new Ruby18ModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".py":
					//_visitor.CodeFactory = new Python2CodeFactory();
					_visitor.LanguageValue = 3;
					new Python2ModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				}
			}
			writer.WriteLine("\t))");
		}
	}
}