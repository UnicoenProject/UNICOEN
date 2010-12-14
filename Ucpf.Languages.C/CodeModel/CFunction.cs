using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CFunction
	{
		// properties
		public CType ReturnType { get; private set; }
		public string Name { get; private set; }
		public List<CVariable> Parameters { get; private set; }
		public CBlock Body { get; private set; }


		// constructor
		public CFunction(XElement node)
		{
			// ReturnType
			ReturnType = new CType(node.Element("declaration_specifiers")
										.Element("type_specifier")
										.Element("TOKEN")
										.Value);
			// Name
			Name = node.Element("declarator").Element("direct_declarator").Element("IDENTIFIER").Value;

			// Parameters
			Parameters = node.Descendants("parameter_list").Elements("parameter_declaration")
							.Select(e =>
							{
								var type = new CType(e.Element("declaration_specifiers").Element("type_specifier").Element("TOKEN").Value);
								var name = e.Element("declarator").Element("direct_declarator").Element("IDENTIFIER").Value;
								return new CVariable(type, name);
							}).ToList();

			// Body
			Body = new CBlock(node.Element("compound_statement").Element("statement_list"));
		}
		         
		
		// acceptor
		public void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
