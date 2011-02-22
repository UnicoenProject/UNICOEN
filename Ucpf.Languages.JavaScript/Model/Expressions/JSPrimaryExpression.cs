using System;
using System.Xml.Linq;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;

namespace Ucpf.Languages.JavaScript.Model.Expressions {
	//TODO implement some Common-Interface
	public class JSPrimaryExpression : JSExpression, IPrimaryExpression {
		//property

		//constructor
		public JSPrimaryExpression(XElement node) {
			Identifier = node.Value;
		}

		public String Identifier { get; private set; }

		//function

		#region IPrimaryExpression Members

		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		//Common-Interface
		string IPrimaryExpression.Name {
			get { return Identifier; }
			set { throw new NotImplementedException(); }
		}

		#endregion

		public override string ToString() {
			return Identifier;
		}
	}
}