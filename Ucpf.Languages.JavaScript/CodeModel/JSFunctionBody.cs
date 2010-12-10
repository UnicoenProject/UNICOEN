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
		private readonly XElement _node;

		public JSFunctionBody(XElement xElement) {
			_node = xElement;
		}

		public IEnumerable<JSFunctionDeclaration> FunctionDeclarations {
			get {
				return _node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("functionDeclaration").Select(
					            	e2 => new JSFunctionDeclaration(e2))
					);
			}
		}

		public IEnumerable<JSStatement> Statements {
			get {
				return _node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("statement").Select(
					            	e2 => JSStatement.CreateStatement(e2))
					);
			}
		}
	}
}