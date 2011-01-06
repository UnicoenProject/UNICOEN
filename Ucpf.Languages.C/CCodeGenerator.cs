using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.Common.CodeGenerators;

namespace Ucpf.Languages.C
{
	[Export(typeof(CodeGenerator))]
	public class CCodeGenerator : CodeGeneratorBase
	{
		private static CCodeGenerator _instance;
		public static CCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new CCodeGenerator()); }
		}

		private CCodeGenerator() { }

		public override string ParserName
		{
			get { return "C"; }
		}

		public override string DefaultExtension
		{
			get { return new[] { ".c" }[0]; }
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


