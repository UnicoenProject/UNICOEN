using System.IO;
using System.Xml.Linq;

namespace Ucpf.CodeGenerators {
	public abstract class CodeGenerator {
		public abstract string ParserName { get; }
		public abstract string DefaultExtension { get; }

		public abstract string Generate(XElement root);

		public string Generate(XDocument xdoc) {
			return Generate(xdoc.Root);
		}

		public string Generate(TextReader reader) {
			return Generate(XDocument.Load(reader));
		}

		public string GenerateFromText(string text) {
			return Generate(XDocument.Parse(text));
		}

		public string GenerateFromFile(string fileName) {
			using (var stream = new StreamReader(fileName)) {
				return Generate(stream);
			}
		}
	}
}