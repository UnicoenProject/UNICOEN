using System;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model {
	public class CExpressionStatement : CStatement, IExpressionStatement {
		public CExpressionStatement(XElement node) {
			var expNode = node.Descendants("expression").First();
			Expression = CExpression.Create(expNode);
		}

		public CExpressionStatement() {}
		public CExpression Expression { get; set; }

		#region IExpressionStatement Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		IExpression IExpressionStatement.Expression {
			get { return Expression; }
			set { throw new NotImplementedException(); }
		}

		#endregion

		public new static CExpressionStatement Create(XElement node) {
			var judge = node.Element("expression_statement").Element("expression");

			if (judge != null) {
				return new CExpressionStatement(node);
			} else {
				return new CEmptyStatement();
			}
		}

		public override string ToString() {
			return Expression + ";";
		}
	}
}