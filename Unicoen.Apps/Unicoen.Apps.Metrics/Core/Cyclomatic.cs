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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicoen.Applications.Metrics.Utils;
using Unicoen.Model;

namespace Unicoen.Applications.Metrics.Cores {
	public class Cyclomatic {
		public static bool Run(IList<string> args) {
			foreach (var arg in args) {
				// do a given path indicate directory?
				if (Directory.Exists(arg)) {
					// find .rb files from a given directory path
					foreach (
							var path in Directory.GetFiles(arg, "*.*", SearchOption.AllDirectories)) {
						MetricsPrinter.PrintMetrics(
								"Cyclomatic complexity", path, GetTargetElements);
					}
				}
						// or do a given path indicate file?
				else if (File.Exists(arg)) {
					// not check the extension
					MetricsPrinter.PrintMetrics(
							"Cyclomatic complexity", arg, GetTargetElements);
				}
			}
			return true;
		}

		public static IEnumerable<IUnifiedElement> GetTargetElements(
				IUnifiedElement model) {
			return model.Descendants().Where(e => e is UnifiedIf)
					.Concat(model.Descendants().Where(e => e is UnifiedFor))
					.Concat(model.Descendants().Where(e => e is UnifiedForeach))
					.Concat(model.Descendants().Where(e => e is UnifiedWhile))
					.Concat(model.Descendants().Where(e => e is UnifiedDoWhile))
					.Concat(model.Descendants().Where(e => e is UnifiedCase));
		}
	}
}