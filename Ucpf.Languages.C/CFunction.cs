using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class CFunction
	{
		private XElement _node;		// function_definition
		public CType ReturnType
		{
			get
			{
				return new CType(_node.Element("declaration_specifiers").Element("type_specifier").Value);

			}
		}
		public string Name
		{
			get
			{
				string a = _node.Element("declarator").Element("direct_declarator").Value;
				string b = _node.Element("declarator").Element("direct_declarator").Element("declarator_suffix").Value;
				return a.Substring(0, a.Length - b.Length);
			}
		}
		public IEnumerable<CVariable> Arguments
		{
			get
			{
				return _node.Descendants("parameter_list").Elements("parameter_declaration")
					.Select(e => new CVariable(new CType(e.Element("declaration_specifiers").Element("type_specifier").Value),
						e.Element("declarator").Element("direct_declarator").Value));
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
