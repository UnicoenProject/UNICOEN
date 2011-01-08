using System;
using System.Xml.Linq;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel 
{
	//TODO implement some Common-Interface
	public class JSPrimaryExpression : JSExpression 
	{
		//property
		public String Identifier { get; private set;}

		//constructor
		public JSPrimaryExpression(XElement node) 
		{
			Identifier = node.Value;
		}

		//function
		public override void Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString()
		{
			return Identifier;
		}
	}
}