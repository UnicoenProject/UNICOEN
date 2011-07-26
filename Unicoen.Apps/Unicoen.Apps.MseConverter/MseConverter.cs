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
using Paraiba.Linq;
using Unicoen.CodeFactories;
using Unicoen.Languages.CSharp.ModelFactories;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;
using Unicoen.Languages.JavaScript.CodeFactories;
using Unicoen.Languages.JavaScript.ModelFactories;
using Unicoen.Languages.Python2.CodeFactories;
using Unicoen.Languages.Python2.ModelFactories;
using Unicoen.Languages.Ruby18.Model;
using Unicoen.Model;

namespace Unicoen.Apps.MseConverter {
	public class MseConverter {
		private readonly MseConvertVisitor _visitor;

		public MseConverter(TextWriter writer, string language) {
			CodeFactory factory = null;
			switch (language) {
				case "Java":
					factory = new JavaCodeFactory();
					break;
				case "JavaScript":
					factory = new JavaScriptCodeFactory();
					break;
				case "Python":
					factory = new Python2CodeFactory();
					break;
				default:
					throw new NotImplementedException();
			}
			_visitor = new MseConvertVisitor(writer, factory);
		}

		public void Generate(
				IEnumerable<string> filePaths, TextWriter writer, string language) {
			writer.WriteLine("(Moose.Model (id: 1)");
			writer.WriteLine("(entity");
			foreach (var filePath in filePaths) {
				switch (Path.GetExtension(filePath)) {
				case ".java":
					new JavaModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".js":
					new JavaScriptModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".cs":
					new CSharpModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".rb":
					new Ruby18ModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				case ".py":
					new Python2ModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				}
			}
			writer.WriteLine("\t)");
			writer.WriteLine("(sourceLanguage '" + language + "'))");
		}
	}
}