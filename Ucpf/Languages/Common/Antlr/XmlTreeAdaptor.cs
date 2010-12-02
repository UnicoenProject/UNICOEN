using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace Ucpf.Languages.Common.Antlr
{
	public class XmlTreeAdaptor : CommonTreeAdaptor {
		public object Create(IToken payload, XParserRuleReturnScope parent)
		{
			if (payload != null)
			{
				var element = new XElement("TOKEN", payload.Text);
				element.SetAttributeValue("startline", payload.Line);
				element.SetAttributeValue("startpos", payload.CharPositionInLine);
				parent.Element.Add(element);
			}
			return Create(payload);
		}

		public void AddChild(object t, object child, XParserRuleReturnScope target,
							 XParserRuleReturnScope parent)
		{
			parent.Element.Add(target.Element);
			base.AddChild(t, child);
		}
	}
}
