using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript
{
	public class JSPrefixIncreamentOperator : JSOperator
	{
		public String OperatorName
		{
			get
			{
				return "++";
			}
		}
		public JSPrefixIncreamentOperator(XElement xElement) 
			: base(xElement) { }
	}
}