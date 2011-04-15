using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ucpf.Applications.Metrics.Utils;
using Ucpf.Core.Model;

namespace Ucpf.Applications.Metrics.Cores {
	public class Loc {
		public static bool Run(IList<string> args) {
			foreach (var arg in args) {
				// do a given path indicate directory?
				if (Directory.Exists(arg)) {
					// find .rb files from a given directory path
					//foreach (var path in Directory.GetFiles(arg, "*.rb", SearchOption.AllDirectories)) {
					//    PrintCyclomatic(path);
					//}
				}
						// or do a given path indicate file?
				else if (File.Exists(arg)) {
					// not check the extension
					MetricsPrinter.PrintMetrics("LOC(lines of code)", arg, GetTargetElements);
				}
			}
			return true;
		}

		private static IEnumerable<IUnifiedElement> GetTargetElements(
				IUnifiedElement model) {
			return model.GetElements()
					.Where(e => e is IUnifiedExpression && e.Parent is UnifiedBlock);
		}
	}
}