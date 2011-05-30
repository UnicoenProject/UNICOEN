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
using System.Linq;
using System.Text;
using Unicoen.Apps.Translator.Filter;
using Unicoen.Core.Model;
using Unicoen.Languages.C;
using Unicoen.Languages.Java;

namespace Unicoen.Apps.Translator {
	internal delegate string CodeGenerator(UnifiedProgram model);

	internal delegate UnifiedProgram ModelGenerator(string code);

	class Program {
		public static void Main(string[] args) {
			#region garbage

			/*
			const string filePath =
					@"C:\Users\T.Kamiya\Desktop\Projects\Unicoen\fixture\Java\input\default\Student.java";
			var code = File.ReadAllText(filePath, Encoding.Default);
			var model = JavaFactory.GenerateModel(code);

			var functions =
					Finder.Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(model);
			foreach (var f in functions) {
				Console.WriteLine(f.Name.Value);
			}
			var a = FunctionFinder.Instance.FindByName("getName", functions);
			Console.WriteLine(a.Count);

			var func = a.ElementAt(0);
			func.Name.Value = "RewittenFunctionName";

			functions =
					Finder.Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(model);
			foreach (var f in functions) {
				Console.WriteLine(f.Name.Value);
			}
			a = FunctionFinder.Instance.FindByName("getName", functions);
			 * */
			#endregion

			if (args.Length != 3) {
				Console.WriteLine("error");
				return;
			}


			var filePath = args[0];
			var srcLang = args[1];


			
			ModelGenerator modelGenerator;
			switch (srcLang) {
				case "java":
				case "Java":
					modelGenerator = new ModelGenerator(JavaFactory.GenerateModel);
					break;
				case "c":
				case "C":
					modelGenerator = new ModelGenerator(CFactory.GenerateModel);
					break;
				default:
					modelGenerator = new ModelGenerator(CFactory.GenerateModel);
					break;

			}

			// return;

			var destLang = args[2];
			CodeGenerator codeGenerator;
			switch (destLang) {
				case "java":
				case "Java":
					codeGenerator = new CodeGenerator(JavaFactory.GenerateCode);
					break;
				case "c":
				case "C":
					codeGenerator = new CodeGenerator(CFactory.GenerateCode);
					break;
				default:
					codeGenerator = new CodeGenerator(CFactory.GenerateCode);
					break;
			}

			var code = File.ReadAllText(filePath, Encoding.Default);
			var model = modelGenerator(code);
			var output = codeGenerator(model);

			Console.WriteLine(output);
		}

		public void Dump(UnifiedProgram program) {
			var generatedSourceCode = JavaFactory.GenerateCode(program);
			Console.WriteLine(generatedSourceCode);
		}

		public class Item {
			public string Str { get; set; }
		}
	}
}