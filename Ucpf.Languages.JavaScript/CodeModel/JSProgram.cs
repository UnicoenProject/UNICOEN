using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// program
	// : LT!* sourceElements LT!* EOF!

	// sourceElements
	// : sourceElement (LT!* sourceElement)*

	// sourceElement
	// : functionDeclaration
	// | statement
	public class JSProgram {

		//constructor
		public JSProgram(XElement node) {
			Functions = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("functionDeclaration").Select(
					            	e2 => new JSFunctionDeclaration(e2))
					);
			Statements = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("statement").Select(
					            	e2 => new JSStatement(e2))
					);
		}

		//field
		public IEnumerable<JSFunctionDeclaration> Functions { get; private set; }
		public IEnumerable<JSStatement> Statements { get; private set; }
	
		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}