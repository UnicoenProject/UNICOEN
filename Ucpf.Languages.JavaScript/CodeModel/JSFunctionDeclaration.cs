using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// functionDeclaration
	// : 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody

	// formalParameterList
	// : '(' (LT!* Identifier (LT!* ',' LT!* Identifier)*)? LT!* ')'

	// callExpression
	// : memberExpression LT!* arguments (LT!* callExpressionSuffix)*
	public class JSFunctionDeclaration {

		//constructor
		public JSFunctionDeclaration(XElement node) {
			Identifier = node.Element("Identifier").Value;
			Parameters = node.Element("formalParameterList").Elements("Identifier")
				.Select(e => new JSVariable(e));
			FunctionBody = new JSFunctionBody(node.Element("functionBody"));
		}

		//field
		public String Identifier { get; private set; }
		public IEnumerable<JSVariable> Parameters { get; private set; }
		public JSFunctionBody FunctionBody { get; private set; }

		//fucntion
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}