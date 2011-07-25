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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Paraiba.Linq;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.MseConverter {
	public class MseConverter {
		private readonly MseConvertVisitor _visitor;

		public MseConverter(TextWriter writer) {
			_visitor = new MseConvertVisitor(writer, new JavaCodeFactory());
		}

		public void Generate(
				IEnumerable<string> filePaths, TextWriter writer) {
			writer.WriteLine("(Moose.Model (id: 1)");
			writer.WriteLine("(entity");
			foreach (var filePath in filePaths) {
				switch (Path.GetExtension(filePath)) {
				case ".java":
					new JavaModelFactory().GenerateFromFile(filePath).Accept(_visitor);
					break;
				}
			}
			writer.WriteLine("\t)");
			writer.WriteLine("(sourceLanguage 'Java'))");
		}
	}
}