using System.IO;
using System.Xml.Linq;

namespace Ucpf.CodeGenerators
{
	public interface ICodeGenerator
	{
		string ParserName { get; }
		string DefaultExtension { get; }

		string Generate(XDocument xdoc);
		string Generate(XElement root);
		string Generate(TextReader reader);
		string Generate(Stream stream);
		string GenerateFromText(string text);
		string GenerateFromFile(string fileName);
	}
}
