using System;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel.Statements {
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

		public JSStatement(XElement xElement) {
			_node = xElement;
		}

		public static JSStatement CreateStatement(XElement xElement) {
			var element = xElement.Element("statement").Elements().First();
			if (element.Name.LocalName == "ifStatement")
				return new JSIfStatement(xElement);
			if (element.Name.LocalName == "returnStatement")
				return new JSReturnStatement(xElement);
			throw new NotImplementedException();
		}
	}
}