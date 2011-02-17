using System.Collections.Generic;

namespace Ucpf.Languages.C.Model {
	public class CTypeTransRule : CRule
	{
		// constructor
		public CTypeTransRule(Dictionary<string, Dictionary<string, string>> ruleList)
		{
			VariableTypeRules = ruleList["variable"];
			MethodReturnTypeRules = ruleList["function"];

			Type = "TypeTrans";
		}


		public Dictionary<string, string> VariableTypeRules;
		public Dictionary<string, string> MethodReturnTypeRules;

	}
}