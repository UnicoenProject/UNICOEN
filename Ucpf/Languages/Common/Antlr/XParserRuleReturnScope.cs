using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Antlr.Runtime;

namespace Ucpf.Languages.Common.Antlr {
	public class XParserRuleReturnScope : ParserRuleReturnScope {
		public XParserRuleReturnScope() {
			Element = new XElement(GetNodeName());
		}

		public XElement Element { get; set; }

		private string GetNodeName() {
			Contract.Requires(GetType().Name.EndsWith("_return"));
			var name = GetType().Name;
			return name.Substring(0, name.Length - 7);
		}
	}
}