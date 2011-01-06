using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel.Expressions;
using Ucpf.Common.CodeModel.Statements;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// ifStatement
	// : 'if' LT!* '(' LT!* expression LT!* ')' LT!* statement (LT!* 'else' LT!* statement)?
	public class JSIfStatement : JSStatement, IIfStatement {

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

		IExpression IIfStatement.Condition {
			get {
				return ConditionalExpression;
			}
			set {
				throw new NotImplementedException();
			}
		}

		//TODO consider that TrueBlock is not always "IBlock" in JS.
		IBlock IIfStatement.TrueBlock {
			get {
				return (IBlock)TrueBlock;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IBlock IIfStatement.FalseBlock {
			get {
				return null;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IList<IElseIfBlock> IIfStatement.ElseIfBlocks {
			get {
				throw new NotImplementedException();
			}
			set {
				throw new NotImplementedException();
			}
		}

		//function
		public override void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		void ICodeElement.Accept(ICodeModelToCode conv) {
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