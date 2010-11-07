using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.JavaScript
{
	[Export(typeof(ICodeGenerator))]
	public class JavaScriptCodeGenerator : CodeGenerator
	{
		private static JavaScriptCodeGenerator _instance;
		public static JavaScriptCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new JavaScriptCodeGenerator()); }
		}

		private JavaScriptCodeGenerator() { }

		public override string ParserName
		{
			get { return "JavaScript"; }
		}

		public override string DefaultExtension
		{
			get { return GlobalInformation.JavaScriptExtensions[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element)
		{
			switch (element.Value)
			{
			case "\r\n":
				WriteLine();
				break;

			case "\n":
				WriteLine();
				break;

			case "\r":
				WriteLine();
				break;

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


