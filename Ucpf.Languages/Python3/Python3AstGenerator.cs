﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using Ucpf.AstGenerators;

namespace Ucpf.Languages.Python3
{
	[Export(typeof(IAstGenerator))]
	public class Python3AstGenerator : ExternalAstGeneratorBase
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
			get { return GlobalInformation.Python3Language; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return GlobalInformation.PythonExtensions; }
		}

		private Python3AstGenerator() { }
	}
}
