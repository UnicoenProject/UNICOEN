using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Languages.JavaScript.Model;

namespace Ucpf.Languages.JavaScript.Model {
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
					            	e2 => new JSFunction(e2))
					);
			Statements = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("statement").Select(
					            	e2 => JSStatement.CreateStatement(e2))
					);
		}

		//field
		public IEnumerable<JSFunction> Functions { get; private set; }
		public IEnumerable<JSStatement> Statements { get; private set; }
	
		//function
		public void Accept(JSModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}