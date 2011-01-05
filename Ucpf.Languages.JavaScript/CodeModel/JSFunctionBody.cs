using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// functionBody
	// : '{' LT!* sourceElements LT!* '}'

	// sourceElements
	// : sourceElement (LT!* sourceElement)*

	// sourceElement
	// : functionDeclaration
	// | statement
	public class JSFunctionBody : IBlock{

		//constructor
		public JSFunctionBody(XElement node) {
			FunctionDeclarations = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("functionDeclaration").Select(
					            	e2 => new JSFunctionDeclaration(e2))
					).Cast<IFunction>().ToList();
			Statements = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("statement").Select(
					            	e2 => JSStatement.CreateStatement(e2))
					).Cast<IStatement>().ToList();
		}

		//field
		public IList<IFunction> FunctionDeclarations { get; private set; }
		public IList<IStatement> Statements { get; private set; }

		IList<IStatement> IBlock.Statements {
			get {
				return Statements;
			}
		}

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		void ICodeElement.Accept(ICodeModelToCode conv) {
			throw new NotImplementedException();
		}

	}
}