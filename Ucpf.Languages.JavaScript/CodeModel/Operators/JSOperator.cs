using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	public class JSOperator {
		private readonly XElement _node;

		public JSOperator(XElement xElement) {
			_node = xElement;
		}

		protected JSOperator() {
			throw new NotImplementedException();
		}

		public String Identifier {
			get { return _node.Value; }
		}

		public static JSOperator CreateOperator(XElement xElement) {
			if (xElement.Value == "+") {
				return new JSPlusOperator(xElement);
			}
			//TODO implement when value is "-", "*", "/", and so on.
			return null;
		}

		public static JSOperator CreatePrefixOperator(XElement xElement) {
			if (xElement.Value == "++") {
				return new JSPrefixIncreamentOperator(xElement);
			}
			//TODO implement when false.
			return null;
		}

		public static JSOperator CreatePostfixOperator(XElement xElement) {
			if (xElement.Value == "++") {
				return null;
			}
			//TODO implement when false.
			return null;
		}
	}
}