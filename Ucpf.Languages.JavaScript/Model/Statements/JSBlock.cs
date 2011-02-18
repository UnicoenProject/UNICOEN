using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Statements;

using Ucpf.Common.Visitors;

namespace Ucpf.Languages.JavaScript.Model.Statements {
	// statementBlock
	// : '{' LT!* statementList? LT!* '}'

	// statementList
	// : statement (LT!* statement)*

	public class JSBlock : JSStatement, IBlock {
		//property

		//constructor
		public JSBlock(XElement xElement) {
			//TODO null check
			Statements = xElement.Element("statementList").Elements("statement")
				.Select(e => CreateStatement(e)).Cast<IStatement>().ToList();
		}

		public IList<IStatement> Statements { get; private set; }

		//function

		#region IBlock Members

		public override void Accept(IModelToCode conv) {
			conv.Generate((IBlock)this);
		}

		//Common-Interface
		IList<IStatement> IBlock.Statements {
			get { return Statements; }
		}

		#endregion

		public override string ToString() {
			string str = null;
			foreach (var stat in Statements) {
				str += stat.ToString();
			}
			return str;
		}
	}
}