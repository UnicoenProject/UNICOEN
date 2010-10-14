using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace OpenCodeProcessorFramework.Languages.CSharp
{
	[Export(typeof(ICodeGenerator))]
	public class CSharpCodeGenerator : CodeGenerator
	{
		private static CSharpCodeGenerator _instance;
		public static CSharpCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new CSharpCodeGenerator()); }
		}

		private CSharpCodeGenerator() { }

		public override string ParserName
		{
			get { return GlobalInformation.CSharpLanguage; }
		}

		public override string DefaultExtension
		{
			get { return GlobalInformation.CSharpExtensions[0]; }
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


