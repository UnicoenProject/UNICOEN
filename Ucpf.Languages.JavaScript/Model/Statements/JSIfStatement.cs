using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;
using Ucpf.Common.OldModel.Statements;
using Ucpf.Languages.JavaScript.Model.Expressions;

namespace Ucpf.Languages.JavaScript.Model.Statements {
	// ifStatement
	// : 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?

	public class JSIfStatement : JSStatement, IIfStatement {
		//properties
		public JSIfStatement(XElement node) {
			//TODO implement "if else" block
			ConditionalExpression =
				JSExpression.CreateExpression(node.Element("expression"));
			TrueBlock = CreateStatement(node.Element("statement"));
			ElseBlock = node.Elements("statement").Skip(1)
				.Select(e => CreateStatement(e)).Cast<IStatement>().ToList();
		}

		public JSExpression ConditionalExpression { get; private set; }
		public JSStatement TrueBlock { get; private set; }
		public IList<IStatement> ElseBlock { get; private set; }

		//constructor

		//function

		#region IIfStatement Members

		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		//Common-Interface
		IExpression IIfStatement.Condition {
			get { return ConditionalExpression; }
			set { throw new NotImplementedException(); }
		}

		//TODO consider that TrueBlock is not always "IBlock" in JS.
		IBlock IIfStatement.TrueBlock {
			get { return (IBlock)TrueBlock; }
			set { throw new NotImplementedException(); }
		}

		IBlock IIfStatement.FalseBlock {
			get { return (IBlock)ElseBlock.First(); }
			set { throw new NotImplementedException(); }
		}

		IList<IElseIfBlock> IIfStatement.ElseIfBlocks {
			get { throw new NotImplementedException(); }
			set { throw new NotImplementedException(); }
		}

		#endregion

		public override string ToString() {
			return "if(" + ConditionalExpression + ") {"
			       + TrueBlock + "} else {"
			       + ElseBlock + "}";
		}
	}
}