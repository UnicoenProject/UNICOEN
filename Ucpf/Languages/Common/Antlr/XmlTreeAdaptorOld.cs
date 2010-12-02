using System.Collections.Generic;
using System.Xml.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Ucpf.Languages.Common.Antlr {
	public class XmlTreeAdaptorOld : CommonTreeAdaptor {
		private readonly IList<XElement> _elements;
		private readonly string _tokenElementName;

		public XmlTreeAdaptorOld(IList<XElement> elements, string tokenElementName) {
			_elements = elements;
			_tokenElementName = tokenElementName;
		}

		public override object Create(IToken payload) {
			if (payload != null) {
				var element = new XElement(_tokenElementName, payload.Text);
				element.SetAttributeValue("startline", payload.Line);
				element.SetAttributeValue("startpos", payload.CharPositionInLine);
				_elements.Add(element);
			}
			return base.Create(payload);
		}

		public object Create(IToken payload, XParserRuleReturnScope parent) {
			if (payload != null) {
				var element = new XElement(_tokenElementName, payload.Text);
				element.SetAttributeValue("startline", payload.Line);
				element.SetAttributeValue("startpos", payload.CharPositionInLine);
				parent.Element.Add(element);
			}
			return Create(payload);
		}

		public void AddChild(object t, object child, XParserRuleReturnScope target,
		                     XParserRuleReturnScope parent) {
			parent.Element.Add(target.Element);
			base.AddChild(t, child);
		}
	}
}