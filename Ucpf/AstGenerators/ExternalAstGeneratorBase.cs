using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using Paraiba.Core;
using Paraiba.IO;

namespace Ucpf.AstGenerators
{
	public abstract class ExternalAstGeneratorBase : AstGeneratorReaderBase
	{
		protected abstract string ProcessorPath { get; }

		protected abstract string[] Arguments { get; }

		public override XElement Generate(TextReader reader, bool ignoreArrange = false)
		{
			var info = new ProcessStartInfo {
				FileName = ProcessorPath,
				Arguments = Arguments.JoinString(" "),
				CreateNoWindow = true,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				UseShellExecute = false,
			};
			using (var p = Process.Start(info)) {
				p.StandardInput.WriteFromStream(reader);
				p.StandardInput.Close();
				return XDocument.Load(p.StandardOutput).Root;
			}
		}
	}
}
