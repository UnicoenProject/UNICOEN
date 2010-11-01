using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Paraiba.Text;

namespace Ucpf.AstGenerators
{
	public abstract class AstGeneratorStringBase : IAstGenerator
	{
		public abstract string ParserName { get; }
		public abstract IEnumerable<string> TargetExtensions { get; }

		public virtual XElement Generate(TextReader reader, bool ignoreArrange = false)
		{
			return GenerateFromText(reader.ReadToEnd(), ignoreArrange);
		}

		public virtual XElement Generate(Stream stream, bool ignoreArrange = false)
		{
			using (var reader = new StreamReader(stream, XEncoding.SJIS)) {
				return Generate(reader, ignoreArrange);
			}
		}

		public abstract XElement GenerateFromText(string text, bool ignoreArrange = false);

		public virtual XElement GenerateFromFile(string fileName, bool ignoreArrange = false)
		{
			using (var stream = new FileStream(fileName, FileMode.Open)) {
				return Generate(stream, ignoreArrange);
			}
		}
	}
}
