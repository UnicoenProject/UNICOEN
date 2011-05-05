using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Unicoen.Apps.Translator.Util {
	public class Util {
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
}

