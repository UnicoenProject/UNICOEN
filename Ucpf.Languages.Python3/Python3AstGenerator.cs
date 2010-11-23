using System.Collections.Generic;
using System.ComponentModel.Composition;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Python3
{
	[Export(typeof(AstGenerator))]
	public class Python3AstGenerator : ExternalAstGenerator
	{
		private static Python3AstGenerator _instance;
		public static Python3AstGenerator Instance
		{
			get { return _instance ?? (_instance = new Python3AstGenerator()); }
		}

		private static readonly string[] _arguments = new[] {
			"ParserScripts/Python3/st2xml.py",
		};

		protected override string ProcessorPath
		{
			get { return ConfigReader.Python3(); }
		}

		protected override string[] Arguments
		{
			get { return _arguments; }
		}

		public override string ParserName
		{
			get { return "Python3"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return new[] { ".py" }; }
		}

		private Python3AstGenerator() { }
	}
}
