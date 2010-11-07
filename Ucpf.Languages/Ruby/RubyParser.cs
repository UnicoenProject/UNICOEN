using System;
using System.IO;
using System.Xml.Linq;
using Paraiba.Text;

namespace Ucpf.Languages.Ruby
{
	public static class RubyParser
	{
		static RubyParser()
		{
			var engine = IronRuby.Ruby.CreateEngine();
			// ir.exe.config を参照のこと
			engine.SetSearchPaths(new[] {
				@"ParserScripts\Ruby1.8",
			});

			var scope = engine.CreateScope();
			var source = engine.CreateScriptSourceFromFile(@"ParserScripts\Ruby1.8\parser.rb");
			source.Execute(scope);
			ParseCodeFunc = scope.GetVariable<Func<string, XElement>>("parse_code");
			ParseXmlFunc = scope.GetVariable<Func<XElement, string>>("parse_xml");
		}

		private static readonly Func<string, XElement> ParseCodeFunc;
		private static readonly Func<XElement, string> ParseXmlFunc;

		public static XElement ParseCodeFromString(string content)
		{
			return ParseCodeFunc(content);
		}

		public static XElement ParseCodeFromFile(string fileName)
		{
			using (var fs = new FileStream(fileName, FileMode.Open))
            using (var reader = new StreamReader(fs, XEncoding.SJIS))
			{
				return ParseCodeFromString(reader.ReadToEnd());
			}
		}

		public static XElement ParseCodeFromReader(TextReader reader)
		{
			return ParseCodeFromString(reader.ReadToEnd());
		}

		public static String ParseXml(XElement root)
		{
			return ParseXmlFunc(root);
		}
	}
}