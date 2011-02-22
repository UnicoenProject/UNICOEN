using System;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;

namespace Ucpf.Languages.JavaScript.Model {
	public class JSVariable : IVariable {
		//property

		//TODO Which select: how to get name "in constructor" or "as parameter". 
		//constructor
		public JSVariable(XElement node) {
			Name = node.Value;
		}

		public string Name { get; private set; }

		//function

		#region IVariable Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		//Common-Interface
		IType IVariable.Type {
			//JavaScript has no explicit type modifier. 
			get { return null; }
			set { throw new NotImplementedException(); }
		}

		string IVariable.Name {
			get { return Name; }
			set { throw new NotImplementedException(); }
		}

		#endregion
	}
}