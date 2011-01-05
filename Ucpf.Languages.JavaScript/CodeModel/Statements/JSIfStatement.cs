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
			TrueBlock = JSStatement.CreateStatement(node.Element("statement"));
			ElseBlock = node.Elements("statement").Skip(1).Select(e => JSStatement.CreateStatement(e));
		}

		//field
		public JSExpression ConditionalExpression { get; private set; }
		public JSStatement TrueBlock { get; private set; }
		public IEnumerable<JSStatement> ElseBlock { get; private set; }

		//function
		public override void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString()
		{
			return "if(" + ConditionalExpression.ToString() + ") {"
				+ TrueBlock.ToString() + "} else {"
				+ ElseBlock.ToString() + "}";
		}
	}
}