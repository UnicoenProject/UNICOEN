using System.Collections;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel;

namespace Ucpf.Languages.C.CodeTranslation {
	public class MethodTrans {
		public static string Trans(IFunction func, string inputLang, string outputLang) {
			var cTable = new Hashtable();
			var jsTable = new Hashtable();
			var rbTable = new Hashtable();

			var lang2Table = new Hashtable();
			lang2Table["c"] = cTable;
			lang2Table["js"] = jsTable;
			lang2Table["rb"] = rbTable;

			// TODO :: consider the data structure
			cTable["assertEqual"] = "CU_ASSERT_NOT_EQUAL";
			jsTable["assertEqual"] = "assert_equal";
			rbTable["assertEqual"] = "assertEquals";

			cTable["print"] = "printf";
			jsTable["print"] = "assert_equal";
			rbTable["print"] = "puts";

			var funcName = func.Name;
			var inTable = lang2Table[inputLang] as Hashtable;
			var outTable = lang2Table[outputLang] as Hashtable;

			foreach (DictionaryEntry elm in inTable) {
				if (elm.Value as string == funcName) {
					var findKey = elm.Key as string;
					return outTable[findKey] as string;
				}
			}

			return funcName;
		}
	}
}