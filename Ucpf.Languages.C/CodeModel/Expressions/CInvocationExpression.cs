using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CInvocationExpression : CExpression
	{
		// properties
		public string FunctionName { get; private set; }
		public List<CExpression> Arguments { get; private set; }

		// constructor
		public CInvocationExpression(XElement node)
		{
			// FunctionName
			FunctionName = node.Element("primary_expression").Element("IDENTIFIER").Value;

			// Arguments
			Arguments = node.Element("argument_expression_list").Elements()
					.Select(e => Create(e))
					.ToList();
		}
		

		public override string ToString()
		{
			string str = FunctionName + "(";
			foreach (CExpression ex in Arguments)
			{
				str += ex.ToString();
				str += ",";
			}
			str = str.Substring(0, str.Length - 1);
			str += ")";

			return str;
		}


		// acceptor
		public new void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}


	}
}

