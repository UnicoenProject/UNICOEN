using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.JavaScript.Model {
	// functionDeclaration
	// : 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody

	// formalParameterList
	// : '(' (LT!* Identifier (LT!* ',' LT!* Identifier)*)? LT!* ')'

	public class JSFunction : IFunction {
		//properties
		public JSFunction(XElement node) {
			Identifier = node.Element("Identifier").Value;
			Parameters = node.Element("formalParameterList").Elements("Identifier")
				.Select(e => new JSVariable(e)).Cast<IVariable>().ToList();
			FunctionBody = new JSFunctionBody(node.Element("functionBody"));
		}

		public String Identifier { get; private set; }
		public IList<IVariable> Parameters { get; private set; }
		public JSFunctionBody FunctionBody { get; private set; }

		//constructor

		//function

		#region IFunction Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		//Comonn-Interface
		IType IFunction.ReturnType {
			//JavaScript has no explicit type modifier.
			get { return null; }
			set { throw new NotImplementedException(); }
		}

		string IFunction.Name {
			get { return Identifier; }
			set { throw new NotImplementedException(); }
		}

		IList<IVariable> IFunction.Parameters {
			get { return Parameters; }
			set { throw new NotImplementedException(); }
		}

		//TODO this cast is OK?
		IBlock IFunction.Body {
			get { return FunctionBody; }
			set { throw new NotImplementedException(); }
		}

		#endregion
	}
}