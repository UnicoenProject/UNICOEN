using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CFunction
	{
		private XElement _node;		// function_definition
		public CType ReturnType
		{
			get
			{
				return new CType(
					_node.Element("declaration_specifiers")
					.Element("type_specifier")
					.Element("TOKEN")
					.Value);
			}
		}
		public string Name
		{
			get
			{
				return _node.Element("declarator").Element("direct_declarator").Element("IDENTIFIER").Value;
			}
		}
		public IEnumerable<CVariable> Parameters
		{
			get
			{
				return _node.Descendants("parameter_list").Elements("parameter_declaration")
					.Select(e => new CVariable(
						new CType(e.Element("declaration_specifiers").Element("type_specifier").Element("TOKEN").Value),
						e.Element("declarator").Element("direct_declarator").Element("IDENTIFIER").Value));
			}
		}

		public CBlock Body
		{
			get
			{
				return new CBlock(_node.Element("compound_statement").Element("statement_list"));
			}
		}

		// constructor
		public CFunction(XElement node)
		{
			_node = node;
		}
	}
}
