using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Xml.Linq;
using Paraiba.Core;
using Paraiba.IO;

namespace Ucpf.AstGenerators {
	[ContractClass(typeof(ExternalAstGeneratorContract))]
	public abstract class ExternalAstGenerator : AstGenerator {
		protected abstract string ProcessorPath { get; }

		protected abstract string[] Arguments { get; }

		protected virtual string WorkingDirectory {
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				return "";
			}
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

	[ContractClassFor(typeof(ExternalAstGenerator))]
	abstract class ExternalAstGeneratorContract : ExternalAstGenerator {

		protected override string ProcessorPath
		{
			get {
				Contract.Ensures(Contract.Result<string>() != null);
				throw new System.NotImplementedException();
			}
		}

		protected override string[] Arguments
		{
			get {
				Contract.Ensures(Contract.Result<string[]>() != null);
				throw new System.NotImplementedException();
			}
		}
	}
}