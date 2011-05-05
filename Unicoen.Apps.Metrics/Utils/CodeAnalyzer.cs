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
using System.IO;
using System.Linq;
using Paraiba.Collections.Generic;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java.CodeFactories;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Applications.Metrics.Utils {
	public static class CodeAnalyzer {
		private static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				throw new NotImplementedException();
				//return CSharpModelFactory.CreateModel(code);
			case ".java":
				return JavaModelFactory.Instance.Generate(code);
			}
			return null;
		}

		private static void InitializeCounter(
				IUnifiedElement model,
				IDictionary<string, int> counter) {
			var outers = model.GetElements()
					.Where(
							e => e is UnifiedClassDefinition ||
							     e is UnifiedFunctionDefinition);
			foreach (var e in outers) {
				var outerStr = GetOutersString(e);
				counter[outerStr] = 0;
			}
		}

		private static void CountElements(
				IEnumerable<IUnifiedElement> targets,
				IDictionary<string, int> counter) {
			foreach (var e in targets) {
				var outerStr = GetOutersString(e);
				counter.Increment(outerStr);
			}
		}

		private static string GetOutersName(IUnifiedElement element) {
			var klass = element as UnifiedClassDefinition;
			if (klass != null) {
				return "[class] " + JavaCodeFactory.Instance.Generate(klass.Name);
			}
			var method = element as UnifiedFunctionDefinition;
			if (method != null) {
				return "[method] " + JavaCodeFactory.Instance.Generate(method.Name);
			}
			return null;
		}

		private static string GetOutersString(IUnifiedElement target) {
			var result = "";
			foreach (var e in target.AncestorsAndSelf()) {
				var name = GetOutersName(e);
				if (name == null)
					continue;
				result = name + "::" + result;
			}
			if (string.IsNullOrEmpty(result)) {
				result = "::";
			}
			return result;
		}

		public static Dictionary<string, int> Measure(
				string filePath,
				Func<IUnifiedElement, IEnumerable<IUnifiedElement>> getTargetElementsFunc) {
			var counts = new Dictionary<string, int>();
			var ext = Path.GetExtension(filePath);
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var model = CreateModel(ext, code);
			InitializeCounter(model, counts);
			CountElements(getTargetElementsFunc(model), counts);
			return counts;
		}
	}
}