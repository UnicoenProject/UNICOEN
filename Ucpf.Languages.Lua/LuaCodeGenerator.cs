using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.Common.CodeGenerators;

namespace Ucpf.Languages.Lua {
	[Export(typeof(CodeGenerator))]
	public class LuaCodeGenerator : CodeGeneratorBase {
		private static LuaCodeGenerator _instance;

		private LuaCodeGenerator() {}

		public static LuaCodeGenerator Instance {
			get { return _instance ?? (_instance = new LuaCodeGenerator()); }
		}

		public override string ParserName {
			get { return "Lua5.1"; }
		}

		public override string DefaultExtension {
			get { return new[] { ".lua" }[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			switch (element.Value) {
			case ";":
				WriteLine(";");
				break;

			case "{":
				WriteLine("{");
				Depth++;
				break;

			case "}":
				Depth--;
				WriteLine("}");
				break;

			default:
				return false;
			}

			return true;
		}
	}
}