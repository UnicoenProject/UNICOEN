using System.Collections.Generic;

namespace Ucpf.Languages.C.Model {
	public class CEntireTypeTransRule : CRule
	{
		// constructor
		public CEntireTypeTransRule(List<Dictionary<string, string>> ruleList, string defaultType = "")
		{
			Rules = ruleList;
			DefaultType = defaultType;
			Type = "EntireTrypeTrans";
		}

		public List<Dictionary<string, string>> Rules { get; set; }
		public string DefaultType { get; set; }
	}
}