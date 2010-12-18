using System;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// statement
	// : statementBlock
	// | variableStatement
	// | emptyStatement
	// | expressionStatement
	// | ifStatement
	// | iterationStatement
	// | continueStatement
	// | breakStatement
	// | returnStatement
	// | withStatement
	// | labelledStatement
	// | switchStatement
	// | throwStatement
	// | tryStatement
	public class JSStatement {
		private XElement _node;

		//constructor
		public JSStatement(XElement xElement) {
			_node = xElement;
		}

		//function
		public static JSStatement CreateStatement(XElement xElement) {
			var element = xElement.Elements().First();
			Console.Write(element.Value);

			//case IfStatement
			if (element.Name.LocalName == "ifStatement")
				return new JSIfStatement(element);

			//case ReturnStatement
			if (element.Name.LocalName == "returnStatement")
				return new JSReturnStatement(element);

			//case error
			throw new NotImplementedException();
		}

		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}