using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	//TODO implementation is not complete

	// callExpression
	// : memberExpression LT!* arguments (LT!* callExpressionSuffix)*

	// arguments
	// : '(' (LT!* assignmentExpression (LT!* ',' LT!* assignmentExpression)*)? LT!* ')'
	public class JSCallExpression : JSExpression {

		//constructor
		public JSCallExpression(XElement node) {

			//Identifier
			Identifier = node.Descendants().Where(e => {
				return e.Value == "Identifier";
			}).First().Value;

			//Arguments
			Arguments = node.Element("arguments").Elements()
				.Select(e => CreateExpression(e));
		}

		//field
		public String Identifier { get; private set; }
		public IEnumerable<JSExpression> Arguments { get; private set;}

		//function
		public new void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string  ToString()
		{
			var argumentList = "";
			foreach(JSExpression arg in Arguments) {
				argumentList += arg.ToString();
			}
 			return Identifier + "(" + argumentList + ")";
		}

	}
}