using System;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.JavaScript.Model {
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