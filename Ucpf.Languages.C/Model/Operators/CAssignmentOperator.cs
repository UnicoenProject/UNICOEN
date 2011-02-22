using System.Collections.Generic;
using System.Xml.Linq;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Languages.C.Model.Operators {
	public class CAssignmentOperator : COperator, IAssignmentOperator {
		private static readonly IDictionary<string, AssignmentOperatorType> Sign2Type;

		static CAssignmentOperator() {
			Sign2Type = new Dictionary<string, AssignmentOperatorType>();
			// Arithmetic
			Sign2Type["="] = AssignmentOperatorType.SimpleAssignment;
			Sign2Type["+="] = AssignmentOperatorType.PlusAssignment;
			Sign2Type["-="] = AssignmentOperatorType.MinusAssignment;
			Sign2Type["*="] = AssignmentOperatorType.MultiAssignment;
		}

		public CAssignmentOperator(string sign, AssignmentOperatorType type) {
			Sign = sign;
			Type = type;
		}

		#region IAssignmentOperator Members

		public string Sign { get; private set; }
		public AssignmentOperatorType Type { get; private set; }

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		public override string ToString() {
			return Sign;
		}

		public static CAssignmentOperator Create(XElement node) {
			var sign = node.Value;
			var type = Sign2Type[sign];
			return new CAssignmentOperator(sign, type);
		}
	}
}