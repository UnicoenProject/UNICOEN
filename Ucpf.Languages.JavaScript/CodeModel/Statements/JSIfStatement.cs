using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// ifStatement
	// : 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?
	public class JSIfStatement : JSStatement {

		//constructor
		public JSIfStatement(XElement node) : base(node) {
			ConditionalExpression = JSExpression.CreateExpression(node.Element("expression"));
			TrueBlock = new JSStatement(node.Element("statement"));
			ElseBlock = node.Elements("statement").Skip(1).Select(e => new JSStatement(e));
		}

		//field
		public JSExpression ConditionalExpression { get; private set; }
		public JSStatement TrueBlock { get; private set; }
		public IEnumerable<JSStatement> ElseBlock { get; private set; }

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}