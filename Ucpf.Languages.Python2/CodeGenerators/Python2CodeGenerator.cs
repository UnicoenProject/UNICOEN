using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.Common.CodeGenerators;

namespace Ucpf.Languages.Python2.CodeGenerators {
	[Export(typeof(CodeGenerator))]
	public class Python2CodeGenerator : CodeGeneratorBase {
		private static Python2CodeGenerator _instance;

		private Python2CodeGenerator() {}

		public static Python2CodeGenerator Instance {
			get { return _instance ?? (_instance = new Python2CodeGenerator()); }
		}

		public override string ParserName {
			get { return "Python2"; }
		}

		public override string DefaultExtension {
			get { return new[] { ".py" }[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			switch (element.Name.LocalName) {
			case "NEWLINE":
				WriteLine();
				break;

			case "INDENT":
				Depth++;
				break;

			case "DEDENT":
				Depth--;
				break;

			default:
				return false;
			}

			return true;
		}
	}
}