using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;
using Ucpf.Common.OldModel;

namespace Ucpf.Languages.C.Model {
	public class CFunction : IFunction {
		// properties
		public CFunction(XElement node) {
			// ReturnType
			ReturnType = new CType(node.Element("declaration_specifiers")
				.Element("type_specifier")
				.Element("TOKEN")
				.Value);
			// Name
			Name =
				node.Element("declarator").Element("direct_declarator").Element("IDENTIFIER")
					.Value;

			// Parameters
			Parameters =
				node.Descendants("parameter_list").Elements("parameter_declaration")
					.Select(e => {
						var type =
							new CType(
								e.Element("declaration_specifiers").Element("type_specifier").Element(
									"TOKEN").Value);
						var name =
							e.Element("declarator").Element("direct_declarator").Element("IDENTIFIER")
								.Value;
						return new CVariable(type, name);
					}).Cast<IVariable>().ToList();

			// Body
			Body =
				new CBlock(node.Element("compound_statement").Element("statement_list"));
		}

		public CType ReturnType { get; private set; }
		public string Name { get; private set; }
		public IList<IVariable> Parameters { get; private set; }
		public CBlock Body { get; private set; }

		// constructor

		// acceptor

		#region IFunction Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		IType IFunction.ReturnType {
			get { return ReturnType; }
			set { throw new NotImplementedException(); }
		}

		string IFunction.Name {
			get { return Name; }
			set { throw new NotImplementedException(); }
		}

		IList<IVariable> IFunction.Parameters {
			get { return Parameters; }
			set { throw new NotImplementedException(); }
		}

		IBlock IFunction.Body {
			get { return Body; }
			set { throw new NotImplementedException(); }
		}

		#endregion
	}
}