using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// functionDeclaration
	// : 'function' LT!* Identifier LT!* formalParameterList LT!* functionBody

	// formalParameterList
	// : '(' (LT!* Identifier (LT!* ',' LT!* Identifier)*)? LT!* ')'

	// callExpression
	// : memberExpression LT!* arguments (LT!* callExpressionSuffix)*
	public class JSFunctionDeclaration : IFunction{

		//constructor
		public JSFunctionDeclaration(XElement node) {
			Identifier = node.Element("Identifier").Value;
			Parameters = node.Element("formalParameterList").Elements("Identifier")
				.Select(e => new JSVariable(e)).Cast<IVariable>().ToList();
			FunctionBody = new JSFunctionBody(node.Element("functionBody"));
		}

		//properties
		public String Identifier { get; private set; }
		public IList<IVariable> Parameters { get; private set; }
		public JSFunctionBody FunctionBody { get; private set; }


		//JavaScript has no explicit type modifier.
		IType IFunction.ReturnType {
			get {
				return null;
			}
			set {
				throw new NotImplementedException();
			}
		}

		string IFunction.Name {
			get {
				return Identifier;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IList<IVariable> IFunction.Parameters {
			get {
				return Parameters;
			}
			set {
				throw new NotImplementedException();
			}
		}

		IBlock IFunction.Body {
			get {
				return FunctionBody;
			}
			set {
				throw new NotImplementedException();
			}
		}

		//fucntion
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv) {
			conv.Generate(this);
		}
	}
}