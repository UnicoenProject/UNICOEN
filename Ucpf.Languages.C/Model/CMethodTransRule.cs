using System.Collections.Generic;

namespace Ucpf.Languages.C.Model {
	public class CMethodTransRule : CRule
	{
		// constructor
		public CMethodTransRule(List<Dictionary<string, string>> ruleList)
		{
			Rules = ruleList;

			Type = "MethodNameTrans";
		}

		public List<Dictionary<string, string>> Rules { get; set; }
	}
}