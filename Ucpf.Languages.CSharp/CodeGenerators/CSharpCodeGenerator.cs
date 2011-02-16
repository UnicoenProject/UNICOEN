using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.Common.CodeGenerators;

namespace Ucpf.Languages.CSharp.CodeGenerators {
	[Export(typeof(CodeGenerator))]
	public class CSharpCodeGenerator : CodeGeneratorBase {
		private static CSharpCodeGenerator _instance;

		private CSharpCodeGenerator() {}

		public static CSharpCodeGenerator Instance {
			get { return _instance ?? (_instance = new CSharpCodeGenerator()); }
		}

		public override string ParserName {
			get { return "C#4.0"; }
		}

		public override string DefaultExtension {
			get { return new[] { ".cs" }[0]; }
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