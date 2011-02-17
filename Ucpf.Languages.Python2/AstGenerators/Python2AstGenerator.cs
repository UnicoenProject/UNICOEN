using System.Collections.Generic;
using System.ComponentModel.Composition;
using Ucpf.Common;
using Ucpf.Common.AstGenerators;

namespace Ucpf.Languages.Python2.AstGenerators {
	[Export(typeof(AstGenerator))]
	public class Python2AstGenerator : ExternalAstGenerator {
		private static Python2AstGenerator _instance;

		private static readonly string[] PrivateArguments = new[] {
			"ParserScripts/Python2/ast2xml.py",
		};

		private Python2AstGenerator() {}

		public static Python2AstGenerator Instance {
			get { return _instance ?? (_instance = new Python2AstGenerator()); }
		}

		protected override string ProcessorPath {
			get { return Settings.Python2(); }
		}

		protected override string[] Arguments {
			get { return PrivateArguments; }
		}

		public override string ParserName {
			get { return "Python2"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".py" }; }
		}
	}
}