using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.Languages.C.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.Translator
{
	class Program
	{
		static void Main(string[] args)
		{
			const string filePath =
					@"C:\Users\T.Kamiya\Desktop\Unicoen\fixture\Java\input\default\Student.java";
			var code = File.ReadAllText(filePath, Encoding.Default);
			var model = JavaModelFactory.Instance.Generate(code);
			var cCode = CCodeFactory.Instance.Generate(model);
			File.WriteAllText("test.txt", cCode);
		}

		public static string GetExtention(LanguageType type)
		{
			switch (type)
			{
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

	public enum LanguageType
	{
		C,
		Java,
		CSharp,
		Ruby,
		Python,
	}



}
