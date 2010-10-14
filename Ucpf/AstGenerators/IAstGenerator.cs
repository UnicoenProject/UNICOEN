using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Ucpf.AstGenerators
{
	public interface IAstGenerator
	{
		string ParserName { get; }
		IEnumerable<string> TargetExtensions { get; }

		XElement Generate(TextReader reader, bool ignoreArrange = false);
		XElement Generate(Stream stream, bool ignoreArrange = false);
		XElement GenerateFromText(string text, bool ignoreArrange = false);
		XElement GenerateFromFile(string fileName, bool ignoreArrange = false);
	}
}
