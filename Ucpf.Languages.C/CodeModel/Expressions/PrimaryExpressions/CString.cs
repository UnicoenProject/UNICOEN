using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel.Expressions.PrimaryExpressions
{
	public class CString : CPrimaryExpression
	{
		private XElement _node;

		public string Body
		{
			get
			{
				return _node.Element("IDENTIFIER").Value;
			}
		}

		public override string ToString()
		{
			return Body;
		}

		// constructor
		public CString(XElement node)
		{
			_node = node;
		}
	}
}
