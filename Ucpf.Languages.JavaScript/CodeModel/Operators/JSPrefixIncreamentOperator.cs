using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel.Operators
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