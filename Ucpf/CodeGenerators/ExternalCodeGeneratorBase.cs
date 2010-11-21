using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Paraiba.Core;
using Paraiba.IO;

namespace Ucpf.CodeGenerators
{
	public abstract class ExternalCodeGeneratorBase : CodeGeneratorBase
	{
		protected abstract string ProcessorPath { get; }

		protected abstract string[] Arguments { get; }

		protected virtual string WorkingDirectory { get { return ""; } }

		public override string Generate(XElement root) {
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
				p.StandardInput.Write(root);
				p.StandardInput.Close();
				return p.StandardOutput.ReadToEnd();
			}
		}
	}
}
