using System;
using System.Linq;
using Ucpf.Applications.Metrics.Apps;

namespace Ucpf.Applications.Metrics {
	public class Program {
		private const string S = "  ";
		private const int W = 12;

		private static readonly string Usage =
				"Ucpf.Applications.Metrics 1.0.0" + "\n" +
				"Copyright (C) 2011 Kazunori SAKAMOTO" + "\n" +
				"" + "\n" +
				"Usage: Metrics <command> [args]" + "\n" +
				"" + "\n" +
				"The commands are:" + "\n" +
				S + "loc".PadRight(W) + "Meausre LOC (lines of code)" + "\n" +
				S + "cyclomatic".PadRight(W) + "Measure cyclomatic complexity" + "\n" +
				"";

		public static bool Print(string message) {
			Console.WriteLine(message);
			return false;
		}

		private static bool Run(string[] args) {
			if (args.Length < 1)
				return Print(Usage);

			var newArgs = args.Skip(1).ToArray();
			switch (args[0]) {
			case "loc":
				return Loc.Run(newArgs);
			case "cyclomatic":
				return Cyclomatic.Run(newArgs);
			}
			return Print(Usage);
		}

		private static void Main(string[] args) {
			if (Run(args))
				Environment.Exit(1);
			Environment.Exit(0);
		}
	}
}