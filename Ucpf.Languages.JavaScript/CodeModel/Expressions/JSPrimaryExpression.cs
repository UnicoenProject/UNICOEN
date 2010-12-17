﻿using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {

	public class JSPrimaryExpression : JSExpression {

		//constructor
		public JSPrimaryExpression(XElement node) {
			Identifier = node.Value;
		}

		//field
		public String Identifier { get; private set;}
	
		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}