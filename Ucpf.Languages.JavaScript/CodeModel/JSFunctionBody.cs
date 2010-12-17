using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// functionBody
	// : '{' LT!* sourceElements LT!* '}'

	// sourceElements
	// : sourceElement (LT!* sourceElement)*

	// sourceElement
	// : functionDeclaration
	// | statement
	public class JSFunctionBody {

		//constructor
		public JSFunctionBody(XElement node) {
			FunctionDeclarations = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("functionDeclaration").Select(
					            	e2 => new JSFunctionDeclaration(e2))
					);
			Statements = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("statement").Select(
					            	e2 => JSStatement.CreateStatement(e2))
					);
		}

		//field
		public IEnumerable<JSFunctionDeclaration> FunctionDeclarations { get; private set; }
		public IEnumerable<JSStatement> Statements { get; private set; }

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}