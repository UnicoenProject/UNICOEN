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
				return e.Name.LocalName == "Identifier";
			}).First().Value;

			//TODO want to ignore TOKEN under "arguments"
			//Arguments
			Arguments = node.Element("arguments").Elements().Where(e => e.Name.LocalName != "TOKEN")
				.Select(e2 => JSExpression.CreateExpression(e2));
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