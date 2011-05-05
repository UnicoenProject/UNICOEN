using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.C.CodeFactories;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Translator {
	class Program {
		static void Main(string[] args) {
			const string filePath =
					@"C:\Users\T.Kamiya\Desktop\Projects\Unicoen\fixture\Java\input\default\Student.java";
			var code = File.ReadAllText(filePath, Encoding.Default);
			var model = JavaModelFactory.Instance.Generate(code);

			var functions =
					Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(model);
			foreach (var f in functions) {
				Console.WriteLine(f.Name.Value);
			}
			var a = FunctionFinder.Instance.FindByName("getName", functions);
			Console.WriteLine(a.Count);

			var func = a.ElementAt(0);
			func.Name.Value = "RewittenFunctionName";



			functions = Finder.Instance.GetAllElements<UnifiedFunctionDefinition>(model);
			foreach (var f in functions) {
				Console.WriteLine(f.Name.Value);
			}
			a = FunctionFinder.Instance.FindByName("getName", functions);

		}

		public void Dump(UnifiedProgram program) {
			var generatedSourceCode = JavaCodeFactory.Instance.Generate(program);
			Console.WriteLine(generatedSourceCode);
		}
		
		
		public class Item {
			public string Str { get; set; }
		}
	}



}
