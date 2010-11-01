using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Paraiba.Text;

namespace Ucpf.AstGenerators
{
	public abstract class AstGeneratorReaderBase : IAstGenerator
	{
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		public abstract XElement Generate(TextReader reader, bool ignoreArrange = false);

		public virtual XElement Generate(Stream stream, bool ignoreArrange = false)
		{
            using (var reader = new StreamReader(stream, XEncoding.SJIS)) {
                return Generate(reader, ignoreArrange);
            }
		}

		public virtual XElement GenerateFromText(string text, bool ignoreArrange = false)
		{
			using (var reader = new StringReader(text)) {
				return Generate(reader, ignoreArrange);
			}
		}

		public virtual XElement GenerateFromFile(string fileName, bool ignoreArrange = false)
		{
			using (var stream = new FileStream(fileName, FileMode.Open)) {
				return Generate(stream, ignoreArrange);
			}
		}
	}
}
