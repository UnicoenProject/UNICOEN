using System;
using System.Xml.Linq;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;

namespace Ucpf.Languages.C.Model.Expressions.PrimaryExpressions {
	public class CPrimaryExpression : CExpression, IPrimaryExpression {
		// TODO :: remove the subclasses such as 'CNumber' and 'CString'

		// properties

		public CPrimaryExpression(XElement expNode) {
			Body = expNode.Value;
		}

		public string Body { get; set; }

		// acceptor

		#region IPrimaryExpression Members

		string IPrimaryExpression.Name {
			get { return Body; }
			set { throw new NotImplementedException(); }
		}

		void ICodeElement.Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString() {
			return Body;
		}
	}
}