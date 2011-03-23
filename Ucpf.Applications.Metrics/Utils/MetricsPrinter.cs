using System;
using System.Collections.Generic;
using System.Linq;
using Ucpf.Core.Model;

namespace Ucpf.Applications.Metrics.Utils {
	public class MetricsPrinter {
		/// <summary>
		///   Print cyclomatic of give file
		/// </summary>
		/// <param name = "meticName"></param>
		/// <param name = "filePath">a target file path</param>
		/// <param name = "getTargetElementsFunc"></param>
		public static void PrintMetrics(
				string meticName, string filePath,
				Func<UnifiedElement, IEnumerable<UnifiedElement>> getTargetElementsFunc) {
			Console.WriteLine("**** " + meticName + " of " + filePath + " ****");

			var result = CodeAnalyzer.Measure(filePath, getTargetElementsFunc);

			var newTagSet = TagProcessor.HierarchizeTags(result.Keys);

			foreach (var tag in newTagSet) {
				var count = result.Where(p => p.Key.StartsWith(tag))
						.Aggregate(1, (s, p) => s + p.Value);
				Console.WriteLine(tag + " " + count);
			}
		}
	}
}