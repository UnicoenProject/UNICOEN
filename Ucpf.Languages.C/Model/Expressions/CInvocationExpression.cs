using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Expressions;

namespace Ucpf.Languages.C.Model.Expressions {
	public class CInvocationExpression : CExpression, ICallExpression {
		// properties
		public CInvocationExpression(XElement node) {
			// FunctionName
			FunctionName = node.Element("primary_expression").Element("IDENTIFIER").Value;

			// Arguments
			Arguments = node.Element("argument_expression_list").Elements()
				.Select(Create)
				.Cast<IExpression>()
				.ToList();
		}

		#region ICallExpression Members

		public string FunctionName { get; set; }
		public IList<IExpression> Arguments { get; private set; }

		// constructor

		// acceptor
		public override void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		public override string ToString() {
			string str = FunctionName + "(";
			foreach (CExpression ex in Arguments) {
				str += ex.ToString();
				str += ",";
			}
			str = str.Substring(0, str.Length - 1);
			str += ")";

			return str;
		}
	}
}