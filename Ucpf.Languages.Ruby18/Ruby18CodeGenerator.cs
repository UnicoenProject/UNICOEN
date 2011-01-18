using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.Common.CodeGenerators;

namespace Ucpf.Languages.Ruby18 {
	[Export(typeof(CodeGenerator))]
	public class Ruby18CodeGenerator : CodeGenerator {
		private static Ruby18CodeGenerator _instance;

		private Ruby18CodeGenerator() {}

		public static Ruby18CodeGenerator Instance {
			get { return _instance ?? (_instance = new Ruby18CodeGenerator()); }
		}

		public override string ParserName {
			get { return "Ruby1.8"; }
		}

		public override string DefaultExtension {
			get { return new[] { ".rb" }[0]; }
		}

		public override string Generate(XElement root) {
			return IronRubyParser.ParseXml(root);
		}
	}
}