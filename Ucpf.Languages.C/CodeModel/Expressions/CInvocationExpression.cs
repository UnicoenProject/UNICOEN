using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CInvocationExpression : CExpression, ICallExpression
	{
		// properties
		public string FunctionName { get; set; }
		public IList<IExpression> Arguments { get; private set; }

		// constructor
		public CInvocationExpression(XElement node)
		{
			// FunctionName
			FunctionName = node.Element("primary_expression").Element("IDENTIFIER").Value;

			// Arguments
			Arguments = node.Element("argument_expression_list").Elements()
					.Select(Create)
					.Cast<IExpression>()
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
		public void Accept(ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}

