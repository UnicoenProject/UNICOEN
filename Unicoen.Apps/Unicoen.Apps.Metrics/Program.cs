#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Linq;
using Unicoen.Apps.Metrics.Core;

namespace Unicoen.Apps.Metrics {
	public class Program {
		private const string S = "  ";
		private const int W = 12;

		private static readonly string Usage =
				"Unicoen.Applications.Metrics 1.0.0" + "\n" +
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
				return new Loc().Run(newArgs);
			case "cyclomatic":
				return new Cyclomatic().Run(newArgs);
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