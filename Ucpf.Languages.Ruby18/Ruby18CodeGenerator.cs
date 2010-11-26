using System;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.Ruby18
{
	[Export(typeof(CodeGenerator))]
	public class Ruby18CodeGenerator : ExternalCodeGenerator
	{
		private static Ruby18CodeGenerator _instance;

		private static readonly string[] _arguments = new[] {
			"-Ks", "code_generator.rb",
		};

		public static Ruby18CodeGenerator Instance
		{
			get { return _instance ?? (_instance = new Ruby18CodeGenerator()); }
		}

		private Ruby18CodeGenerator() { }

		public override string ParserName {
			get { return "RubyParser for Ruby 1.8"; }
		}

		public override string DefaultExtension
		{
			get { return new[] { ".rb" }[0]; }
		}

		protected override string ProcessorPath {
			get { return ConfigReader.Ruby18(); }
		}

		protected override string[] Arguments {
			get { return _arguments; }
		}
	}
}
