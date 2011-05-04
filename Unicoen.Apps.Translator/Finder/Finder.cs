using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;

namespace Unicoen.Apps.Translator {
	public class Finder {
		public static Boolean HasParameter(UnifiedFunctionDefinition func, Parameter param) {
			if (func.Name.Equals(param.Name) && func.Type.Name.Equals(param.TypeName)) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// programに含まれるT型の要素をすべて取得します．
		/// </summary>
		/// <example>
		/// <c>var functionList = GetAllElements&lt;UnifiedFunctionDefinition&gt;(program); </c>
		/// </example>
		/// <typeparam name="T"></typeparam>
		/// <param name="program"></param>
		/// <returns></returns>
		public static List<T> GetAllElements<T>(UnifiedProgram program) {
			var elements = program.GetElements();
			var list = new List<T>();

			foreach (var element in elements) {
				GetAllElement(element, list);
			}

			return list;
		}

		private static void GetAllElement<T>(IUnifiedElement element, List<T> list) {
			if (element == null) {
				return;
			}

			var elements = element.GetElements();
			if (elements == null) {
				return;
			}
			foreach (var e in elements) {
				if (e != null) {
					if (e is T) {
						list.Add((T)e);
					}
					GetAllElement(e, list);
				}

			}
		}
	}


	public class Parameter {
		public string Name { get; set; }
		public string TypeName { get; set; }
	}
}
