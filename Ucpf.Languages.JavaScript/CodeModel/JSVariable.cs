using System;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	//TODO not implemented yet
	public class JSVariable : IVariable{

		//constructor
		public JSVariable(XElement node) {
			Name = node.Value;
		}
		
		//field
		public string Name { get; private set; }

		IType IVariable.Type {
			get {
				return null;
			}
			set {
				throw new NotImplementedException();
			}
		}

		string IVariable.Name {
			get {
				return Name;
			}
			set {
				throw new NotImplementedException();
			}
		}

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}


	}
}