using System;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.C.Model {
	public class CUnaryExpression : CExpression, IUnaryExpression {
		// properties
		public CUnaryExpression(CUnaryOperator ope, XElement expNode) {
			Operator = ope;
			if (expNode.Name.LocalName == "primary_expression") {
				Term = new CPrimaryExpression(expNode);
			} else {
				Term = Create(expNode);
			}
		}

		public CUnaryOperator Operator { get; private set; }
		public CExpression Term { get; private set; }

		// constructor

		// acceptor

		#region IUnaryExpression Members

		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		IUnaryOperator IUnaryExpression.Operator {
			get { return Operator; }
			set { throw new NotImplementedException(); }
		}

		IExpression IUnaryExpression.Term {
			get { return Term; }
			set { throw new NotImplementedException(); }
		}

		#endregion

		public override string ToString() {
			return Operator.ToString() + Term;
		}
	}
}