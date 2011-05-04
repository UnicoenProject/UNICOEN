using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.C.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Translator {
	class Program {
		static void Main(string[] args) {
			const string filePath =
					@"C:\Users\T.Kamiya\Desktop\Unicoen\fixture\Java\input\default\Student.java";
			var code = File.ReadAllText(filePath, Encoding.Default);
			var model = JavaModelFactory.Instance.Generate(code);

			var functions = Finder.GetAllElements<UnifiedFunctionDefinition>(model);
			foreach (var f in functions) {
				Console.WriteLine(f.Name.Value);
			}
			var a = FunctionFinder.Instance.FindByName("getName", functions);
			Console.WriteLine(a.Count);

			var item1 = new Item {
				Str = "item1"
			};
			var item2 = new Item {
				Str = "item2"
			};

			var list = new List<Item>();
			list.Add(item1);
			list.Add(item2);
			Bar(list);

			foreach (var item in list) {
				Console.WriteLine(item.Str);
			}
		}

		public static void Foo(Item item, string str) {
			item.Str = "Rewrote + " + str;
		}

		public static void Bar(List<Item> list) {
			foreach (var item in list) {
				Foo(item, item.Str);
			}
		}

		public static string GetExtention(LanguageType type) {
			switch (type) {
				case LanguageType.C:
					return "c";
				case LanguageType.Java:
					return "java";
				case LanguageType.CSharp:
					return "cs";
				case LanguageType.Ruby:
					return "rb";
				case LanguageType.Python:
					return "py";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}


	}

	public enum LanguageType {
		C,
		Java,
		CSharp,
		Ruby,
		Python,
	}

	public class Item {
		public string Str { get; set; }
	}



}
