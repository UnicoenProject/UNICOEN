using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace OpenCodeProcessorFramework.Languages.Ruby
{
	[Export(typeof(ICodeGenerator))]
	public class RubyCodeGenerator : CodeGeneratorBase
	{
		private static RubyCodeGenerator _instance;
		public static RubyCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new RubyCodeGenerator()); }
		}

		private RubyCodeGenerator() { }

		public override string ParserName
		{
			get { return GlobalInformation.RubyLanguage; }
		}

		public override string DefaultExtension
		{
			get { return GlobalInformation.RubyExtensions[0]; }
		}

		public override string Generate(XElement root)
		{
			return RubyParser.ParseXml(root);
		}
	}
}


