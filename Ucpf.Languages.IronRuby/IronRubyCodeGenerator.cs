using System;
using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.IronRuby
{
	//[Export(typeof(CodeGenerator))]
	public class IronRubyCodeGenerator : CodeGenerator
	{
		private static IronRubyCodeGenerator _instance;
		public static IronRubyCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new IronRubyCodeGenerator()); }
		}

		private IronRubyCodeGenerator() { }

		public override string ParserName
		{
			get { return "Ruby1.8"; }
		}

		public override string DefaultExtension
		{
			get { return new[] { ".rb" }[0]; }
		}

		public override string Generate(XElement root)
		{
			return IronRubyParser.ParseXml(root);
		}
	}
}


