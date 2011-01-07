using System;
using System.Xml.Linq;

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
		public override void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString()
		{
			return Identifier;
		}
	}
}