using System.Collections.Generic;
using System.ComponentModel.Composition;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Ruby18 {
	//[Export(typeof(AstGenerator))]
	public class Ruby18AstGenerator : ExternalAstGenerator {
		private static Ruby18AstGenerator _instance;

		private static readonly string[] _arguments = new[] {
			"-Ks", "ast_generator.rb",
		};

		private Ruby18AstGenerator() {}

		public static Ruby18AstGenerator Instance {
			get { return _instance ?? (_instance = new Ruby18AstGenerator()); }
		}

		protected override string ProcessorPath {
			get { return ConfigReader.Ruby18(); }
		}

		protected override string[] Arguments {
			get { return _arguments; }
		}

		public override string ParserName {
			get { return "RubyParser for Ruby 1.8"; }
		}

		public override IEnumerable<string> TargetExtensions {
			get { return new[] { ".rb" }; }
		}
	}
}