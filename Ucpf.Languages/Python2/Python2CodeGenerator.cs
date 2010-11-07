using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.Python2
{
	[Export(typeof(ICodeGenerator))]
	public class Python2CodeGenerator : CodeGenerator
	{
		private static Python2CodeGenerator _instance;
		public static Python2CodeGenerator Instance
		{
			get { return _instance ?? (_instance = new Python2CodeGenerator()); }
		}

		private Python2CodeGenerator() { }

		public override string ParserName
		{
			get { return GlobalInformation.Python2Language; }
		}

		public override string DefaultExtension
		{
			get { return GlobalInformation.Python3Extensions[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element)
		{
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


