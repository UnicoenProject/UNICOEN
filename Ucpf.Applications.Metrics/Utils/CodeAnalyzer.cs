using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Paraiba.Collections.Generic;
using Paraiba.Text;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Languages.CSharp;
using Ucpf.Languages.Java.CodeGeneraotr;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Applications.Metrics.Utils {
	public static class CodeAnalyzer {
		private static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext.ToLower()) {
			case ".cs":
				return CSharpModelFactory.CreateModel(code);
			case ".java":
				return JavaModelFactory.CreateModel(code);
			}
			return null;
		}

		private static void InitializeCounter(IUnifiedElement model,
		                                      IDictionary<string, int> counter) {
			var outers = model.GetElements()
					.Where(e => e is UnifiedClassDefinition ||
					            e is UnifiedFunctionDefinition);
			foreach (var e in outers) {
				var outerStr = GetOutersString(e);
				counter[outerStr] = 0;
			}
		}

		private static void CountElements(IEnumerable<IUnifiedElement> targets,
		                                  IDictionary<string, int> counter) {
			foreach (var e in targets) {
				var outerStr = GetOutersString(e);
				counter.Increment(outerStr);
			}
		}

		private static string GetOutersName(IUnifiedElement element) {
			var klass = element as UnifiedClassDefinition;
			if (klass != null) {
				return "[class] " + JavaCodeGenerator.Generate(klass.Name);
			}
			var method = element as UnifiedFunctionDefinition;
			if (method != null) {
				return "[method] " + JavaCodeGenerator.Generate(method.Name);
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