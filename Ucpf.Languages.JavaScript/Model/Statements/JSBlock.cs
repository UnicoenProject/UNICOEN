using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.JavaScript.Model
{
	// statementBlock
	// : '{' LT!* statementList? LT!* '}'
	
    // statementList
	// : statement (LT!* statement)*

	public class JSBlock : JSStatement, IBlock
	{
		//property
		public IList<IStatement> Statements { get; private set; }

		//constructor
		public JSBlock(XElement xElement)
		{
			//TODO null check
			Statements = xElement.Element("statementList").Elements("statement")
				.Select(e => JSStatement.CreateStatement(e)).Cast<IStatement>().ToList();
		}

		//function
		public override void Accept(IModelToCode conv)
		{
			conv.Generate((IBlock)this);
		}
		
		public override string ToString() {
			string str = null;
			foreach (var stat in Statements) {
				str += stat.ToString();
			}
			return str;
		}

		//Common-Interface
		IList<IStatement> IBlock.Statements
		{
			get
			{
				return Statements;
			}
		}
	}
}
