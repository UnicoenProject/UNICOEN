using System.Xml.Linq;
using Antlr.Runtime;

namespace Ucpf.Languages.Common.Antlr
{
	public class XParserRuleReturnScope : ParserRuleReturnScope
	{
		public XElement Element { get; set; }

		public XParserRuleReturnScope()
		{
			Element = new XElement(GetNodeName());
		}

		private string GetNodeName()
		{
			var name = GetType().Name;
			return name.Substring(0, name.Length - 7);
		}
	}
}