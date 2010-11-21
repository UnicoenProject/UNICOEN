using System.Collections.Generic;
using System.ComponentModel.Composition;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Python2
{
	[Export(typeof(IAstGenerator))]
	public class Python2AstGenerator : ExternalAstGeneratorBase
	{
		private static Python2AstGenerator _instance;
		public static Python2AstGenerator Instance
		{
			get { return _instance ?? (_instance = new Python2AstGenerator()); }
		}

		private Python2AstGenerator() { }

		private static readonly string[] _arguments = new[] {
			"ParserScripts/Python2/ast2xml.py",
		};

		protected override string ProcessorPath
		{
			get { return ConfigReader.Python2(); }
		}

		protected override string[] Arguments
		{
			get { return _arguments; }
		}

		public override string ParserName
		{
			get { return "Python2"; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return GlobalInformation.PythonExtensions; }
		}
	}
}


