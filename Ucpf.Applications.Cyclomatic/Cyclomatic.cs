using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Extensions;
using Ucpf.Core.Model.Visitors;
using Ucpf.Languages.CSharp;
using Ucpf.Languages.Java.Model;
using Paraiba.Collections.Generic;

namespace Ucpf.Applications.Cyclomatic {
	public class Cyclomatic {
		public static Dictionary<string, int> Measure(string filePath) {
			var counts = new Dictionary<string, int>();
			var ext = Path.GetExtension(filePath);
			var code = File.ReadAllText(filePath);
			var model = CreateModel(ext, code);
			Initialize(model, counts);
			CountBranches(model.GetElements().Where(e => e is UnifiedIf), counts);
			CountBranches(model.GetElements().Where(e => e is UnifiedFor), counts);
			CountBranches(model.GetElements().Where(e => e is UnifiedForeach), counts);
			CountBranches(model.GetElements().Where(e => e is UnifiedWhile), counts);
			CountBranches(model.GetElements().Where(e => e is UnifiedDoWhile), counts);
			CountBranches(model.GetElements().Where(e => e is UnifiedCase), counts);
			return counts;
		}

		private static void Initialize(UnifiedElement model, IDictionary<string, int> counts) {
			var outers = model.GetElements()
				.Where(e => e is UnifiedClassDefinition ||
				            e is UnifiedFunctionDefinition);
			foreach (var e in outers) {
				var outerStr = GetOutersString(e);
				counts[outerStr] = 0;
			}
		}

		private static void CountBranches(IEnumerable<UnifiedElement> targets, IDictionary<string, int> counts) {
			foreach (var e in targets) {
				var outerStr = GetOutersString(e);
				counts.Increment(outerStr);
			}
		}

		private static UnifiedProgram CreateModel(string ext, string code) {
			switch (ext) {
			case "cs":
				return CSharpModelFactory.CreateModel(code);
			case "java":
				return JavaModelFactory.CreateModel(code);
			}
			return null;
		}

		private static string GetOutersName(UnifiedElement element) {
			var klass = element as UnifiedClassDefinition;
			if (klass != null) {
				return "class " + klass.Name;
			}
			var method = element as UnifiedFunctionDefinition;
			if (method != null) {
				return "method " + method.Name;
			}
			return null;
		}

		private static string GetOutersString(UnifiedElement target) {
			var result = "";
			foreach (var e in target.ParentsAndSelf()) {
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
	}
}
