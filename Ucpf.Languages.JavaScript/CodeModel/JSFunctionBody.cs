using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel.Statements;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel 
{
	// functionBody
	// : '{' LT!* sourceElements LT!* '}'

	// sourceElements
	// : sourceElement (LT!* sourceElement)*

	// sourceElement
	// : functionDeclaration
	// | statement

	public class JSFunctionBody : IBlock
	{
		//properties
		public IList<IFunction> FunctionDeclarations { get; private set; }
		public IList<IStatement> Statements { get; private set; }

		//constructor
		public JSFunctionBody(XElement node) {
			FunctionDeclarations = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("functionDeclaration").Select(
					            	e2 => new JSFunction(e2))
					).Cast<IFunction>().ToList();
			Statements = node.Element("sourceElements").Elements(
					"sourceElement")
					.SelectMany(e =>
					            e.Elements("statement").Select(
					            	e2 => JSStatement.CreateStatement(e2))
					).Cast<IStatement>().ToList();
		}

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		//Common-Interface
		IList<IStatement> IBlock.Statements {
			get {
				return Statements;
			}
		}

		//TODO How deal with FunctionDeclarations?

		void ICodeElement.Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}

	}
}