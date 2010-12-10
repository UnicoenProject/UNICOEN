using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	public class JSPrefixIncreamentOperator : JSOperator {
		public JSPrefixIncreamentOperator(XElement xElement)
			: base(xElement) {}

		public String OperatorName {
			get { return "++"; }
		}
	}
}