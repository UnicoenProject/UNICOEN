using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Ucpf.AstGenerators {
	public abstract class AstGenerator {
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		public XElement Generate(TextReader reader) {
			return Generate(reader, true);
		}

		public XElement Generate(string code) {
			return Generate(code, true);
		}

		public XElement GenerateFromFile(string path) {
			return GenerateFromFile(path, true);
		}

		public XElement GenerateFromFile(string path, bool ignoreArrange) {
			using (var reader = new StreamReader(path)) {
				return Generate(reader, ignoreArrange);
			}
		}

		public abstract XElement Generate(TextReader reader, bool ignoreArrange);

		public virtual XElement Generate(string code, bool ignoreArrange) {
			using (var reader = new StringReader(code)) {
				return Generate(reader, ignoreArrange);
			}
		}
	}
}