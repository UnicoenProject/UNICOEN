using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel
{
	// statementBlock
	// : '{' LT!* statementList? LT!* '}'
	
    // statementList
	// : statement (LT!* statement)*
	public class JSBlock : JSStatement, IBlock
	{
		//constructor
		public JSBlock(XElement xElement) : base(xElement) {
			//TODO null check
			Statements = xElement.Element("statementList").Elements("statement")
				.Select(e => JSStatement.CreateStatement(e)).Cast<IStatement>().ToList();
		}

		//field
		public IList<IStatement> Statements { get; private set; }

		//function
		public override void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString() {
			string str = null;
			foreach (var stat in Statements) {
				str += stat.ToString();
			}
			return str;
		}
	}
}
