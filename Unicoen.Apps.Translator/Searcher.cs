using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Translator {
	public class Searcher {
		public static Boolean HasParameter(UnifiedFunctionDefinition func, Parameter param) {
			if (func.Name.Equals(param.Name) && func.Type.Name.Equals(param.TypeName)) {
				return true;
			}
			return false;
		}

		// program:UnifiedProgram に含まれる関数定義（UnifiedFunctionDefinitionオブジェクト）をすべて返す
		public static List<UnifiedFunctionDefinition> GetAllFunctions(UnifiedProgram program) {
			var elements = program.GetElements();
			var list = new List<UnifiedElement>();

			foreach (var element in elements) {
				Console.WriteLine(element.GetType());
				GetAllElement(element, 1);
			}

			return null;
		}

		public static void GetAllElement(IUnifiedElement element, int c = 1) {
			if(element == null) {
				return;
			}
			
			var elements = element.GetElements();
			if (elements == null) {
				return;
			}
			foreach (var e in elements) {
				if (e != null) {
					Console.Write(GenerateRootBranch(c));
					Console.Write(e.GetType().ToString().Replace("Unicoen.Core.Model.", ""));
					Console.Write(" : " + e.ToString());
					Console.Write("\n");
					GetAllElement(e, c + 2);
				}

			}
		}

		public static string GenerateRootBranch(int c) {
			var s = "";			
			for(int i = 0; i < c + 2; i++) {
				s += " ";
			}
			s += " ";

			return s;
		}
	}

	public class Parameter {
		public string Name { get; set; }
		public string TypeName { get; set; }
	}
}
