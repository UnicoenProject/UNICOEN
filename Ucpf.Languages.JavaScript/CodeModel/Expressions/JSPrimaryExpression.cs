using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	public class JSPrimaryExpression : JSExpression {
		private readonly XElement _node;

		public JSPrimaryExpression(XElement xElement) {
			_node = xElement;
		}

		public String Identifier {
			get { return _node.Value; }
		}
	}
}