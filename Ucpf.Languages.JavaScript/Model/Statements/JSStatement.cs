using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.ModelToCode;
using Ucpf.Common.OldModel.Statements;

namespace Ucpf.Languages.JavaScript.Model.Statements {
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

	public class JSStatement : IStatement {
		//constructor

		//function

		#region IStatement Members

		public virtual void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		public static JSStatement CreateStatement(XElement xElement) {
			var element = xElement.Elements().First();

			//case statementBlock
			if (element.Name.LocalName == "statementBlock")
				return new JSBlock(element);

			//case ifStatement
			if (element.Name.LocalName == "ifStatement")
				return new JSIfStatement(element);

			//case returnStatement
			if (element.Name.LocalName == "returnStatement")
				return new JSReturnStatement(element);

			//case error
			throw new NotImplementedException();
		}

		public override string ToString() {
			//return _node.Value;
			throw new NotImplementedException();
		}
	}
}