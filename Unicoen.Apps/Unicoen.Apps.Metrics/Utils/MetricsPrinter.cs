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
using System.Collections.Generic;
using System.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Applications.Metrics.Utils {
	public class MetricsPrinter {
		/// <summary>
		///   Print cyclomatic of give file
		/// </summary>
		/// <param name = "meticName"></param>
		/// <param name = "filePath">a target file path</param>
		/// <param name = "getTargetElementsFunc"></param>
		public static void PrintMetrics(
				string meticName, string filePath,
				Func<IUnifiedElement, IEnumerable<IUnifiedElement>> getTargetElementsFunc) {
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