using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.JavaScript.Model {
	//TODO implementation is not complete

	// callExpression
	// : memberExpression LT!* arguments (LT!* callExpressionSuffix)*

	// arguments
	// : '(' (LT!* assignmentExpression (LT!* ',' LT!* assignmentExpression)*)? LT!* ')'

	public class JSCallExpression : JSExpression, ICallExpression 
	{
		//properties
		public String Identifier { get; private set; }
		public IList<IExpression> Arguments { get; private set;}
	
		//constructor
		public JSCallExpression(XElement node)
		{
			//Identifier
			Identifier = node.Descendants().Where(e => {
				return e.Name.LocalName == "Identifier";
			}).First().Value;

			//TODO want to ignore TOKEN under "arguments"
			//Arguments
			Arguments = node.Element("arguments").Elements().Where(e => e.Name.LocalName != "TOKEN")
				.Select(e2 => JSExpression.CreateExpression(e2)).Cast<IExpression>().ToList();
		}

		//function
		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString()
		{
			var argumentList = "";
			foreach(JSExpression arg in Arguments) {
				argumentList += arg.ToString();
			}
 			return Identifier + "(" + argumentList + ")";
		}

		//Common-Interface
		string ICallExpression.FunctionName {
			get {
				return Identifier;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IList<IExpression> ICallExpression.Arguments {
			get {
				return Arguments;
			}
		}
	}
}