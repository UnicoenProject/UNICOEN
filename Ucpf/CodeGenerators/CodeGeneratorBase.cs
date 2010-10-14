using System.IO;
using System.Xml.Linq;

namespace Ucpf.CodeGenerators
{
	public abstract class CodeGeneratorBase : ICodeGenerator
	{
		public abstract string ParserName { get; }
		public abstract string DefaultExtension { get; }
		public abstract string Generate(XElement root);

		public string Generate(XDocument xdoc)
		{
			return Generate(xdoc.Root);
		}

		public string Generate(TextReader reader)
		{
			return Generate(XDocument.Load(reader));
		}

		public string Generate(Stream stream)
		{
			return Generate(XDocument.Load(stream));
		}

		public string GenerateFromText(string text)
		{
			return Generate(XDocument.Parse(text));
		}

		public string GenerateFromFile(string fileName)
		{
			using (var stream = new FileStream(fileName, FileMode.Open)) {
				return Generate(stream);
			}
		}
	}
}