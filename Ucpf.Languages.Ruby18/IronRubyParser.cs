using System;
using System.IO;
using System.Xml.Linq;
using IronRuby;
using Paraiba.Text;

namespace Ucpf.Languages.Ruby18
{
	public static class IronRubyParser
	{
		static IronRubyParser()
		{
			var engine = Ruby.CreateEngine();
			// ir.exe.config を参照のこと
			engine.SetSearchPaths(new[] {
				@"ParserScripts\IronRubyParser",
			});

			var scope = engine.CreateScope();
			var source = engine.CreateScriptSourceFromFile(@"ParserScripts\IronRubyParser\parser.rb");
			source.Execute(scope);
			ParseCodeFunc = scope.GetVariable<Func<string, XElement>>("parse_code");
			ParseXmlFunc = scope.GetVariable<Func<XElement, string>>("parse_xml");
		}

		private static readonly Func<string, XElement> ParseCodeFunc;
		private static readonly Func<XElement, string> ParseXmlFunc;

		public static XElement ParseCodeFromString(string content) {
			return ParseCodeFunc(content);
		}

		public static XElement ParseCodeFromFile(string fileName) {
			using (var reader = new StreamReader(fileName, XEncoding.SJIS))
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