using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CAssignmentOperator : COperator, IAssignmentOperator
	{
		public string Sign { get; private set; }
		public AssignmentOperatorType Type { get; private set; }

		public CAssignmentOperator(string sign, AssignmentOperatorType type) {
			Sign = sign;
			Type = type;
		}

		private static readonly IDictionary<string, AssignmentOperatorType> Sign2Type;

		static CAssignmentOperator() {
			Sign2Type = new Dictionary<string, AssignmentOperatorType>();
			// Arithmetic
			Sign2Type["="] = AssignmentOperatorType.SimpleAssignment;
			Sign2Type["+="] = AssignmentOperatorType.PlusAssignment;
			Sign2Type["-="] = AssignmentOperatorType.MinusAssignment;
			Sign2Type["*="] = AssignmentOperatorType.MultiAssignment;
		}

		public override string ToString()
		{
			return Sign;
		}

		public static CAssignmentOperator Create(XElement node)
		{
			var sign = node.Value;
			var type = Sign2Type[sign];
			return new CAssignmentOperator(sign, type);
		}

		public void Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}
	}
}
