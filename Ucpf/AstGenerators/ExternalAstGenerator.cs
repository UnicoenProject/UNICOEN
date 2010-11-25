using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using Paraiba.Core;
using Paraiba.IO;

namespace Ucpf.AstGenerators {
	public abstract class ExternalAstGenerator : AstGenerator {
		protected abstract string ProcessorPath { get; }

		protected abstract string[] Arguments { get; }

		protected virtual string WorkingDirectory {
			get { return ""; }
		}

		public override XElement Generate(TextReader reader, bool ignoreArrange) {
			var info = new ProcessStartInfo {
				FileName = ProcessorPath,
				Arguments = Arguments.JoinString(" "),
				CreateNoWindow = true,
				RedirectStandardInput = true,
				RedirectStandardOutput = true,
				UseShellExecute = false,
				WorkingDirectory = WorkingDirectory,
			};
			using (var p = Process.Start(info)) {
				p.StandardInput.WriteFromStream(reader);
				p.StandardInput.Close();
				return XDocument.Load(p.StandardOutput).Root;
			}
		}
	}
}