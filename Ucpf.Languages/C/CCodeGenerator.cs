using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.C
{
	[Export(typeof(ICodeGenerator))]
	public class CCodeGenerator : CodeGenerator
	{
		private static CCodeGenerator _instance;
		public static CCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new CCodeGenerator()); }
		}

		private CCodeGenerator() { }

		public override string ParserName
		{
			get { return GlobalInformation.CLanguage; }
		}

		public override string DefaultExtension
		{
			get { return GlobalInformation.CExtensions[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element)
		{
			switch (element.Value)
			{
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


