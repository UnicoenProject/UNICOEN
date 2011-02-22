using System.Collections.Generic;
using System.Xml.Linq;
using Ucpf.Common.OldModel.Operators;

using Ucpf.Common.Visitors;

namespace Ucpf.Languages.C.Model.Operators {
	public class CBinaryOperator : COperator, IBinaryOperator {
		private static readonly IDictionary<string, BinaryOperatorType> Sign2Type;

		static CBinaryOperator() {
			Sign2Type = new Dictionary<string, BinaryOperatorType>();
			// Arithmetic
			Sign2Type["+"] = BinaryOperatorType.Addition;
			Sign2Type["-"] = BinaryOperatorType.Subtraction;
			Sign2Type["*"] = BinaryOperatorType.Multiplication;
			Sign2Type["/"] = BinaryOperatorType.Division;
			Sign2Type["%"] = BinaryOperatorType.Modulo;
			// Comparison
			Sign2Type["<"] = BinaryOperatorType.Lesser;
			Sign2Type["<="] = BinaryOperatorType.LesserEqual;
			Sign2Type[">"] = BinaryOperatorType.Greater;
			Sign2Type[">="] = BinaryOperatorType.GreaterEqual;
			Sign2Type["=="] = BinaryOperatorType.Equal;
			Sign2Type["!="] = BinaryOperatorType.NotEqual;
			// Shift
			Sign2Type["<<"] = BinaryOperatorType.LeftShift;
			Sign2Type[">>"] = BinaryOperatorType.RightShift;
			// Logical
			Sign2Type["&&"] = BinaryOperatorType.LogicalAnd;
			Sign2Type["||"] = BinaryOperatorType.LogicalOr;
			// Bit
			Sign2Type["&"] = BinaryOperatorType.BitAnd;
			Sign2Type["|"] = BinaryOperatorType.BitOr;
			Sign2Type["^"] = BinaryOperatorType.BitXor;
			// Assignment
			Sign2Type["="] = BinaryOperatorType.Assignment;
			// TODO :: implement other 'compound' assignment operator (e.g. +=
		}

		public CBinaryOperator(string sign, BinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		#region IBinaryOperator Members

		public void Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		public string Sign { get; private set; }

		public BinaryOperatorType Type { get; private set; }

		#endregion

		public override string ToString() {
			return Sign;
		}

		public static CBinaryOperator Create(XElement node) {
			var sign = node.Value;
			var type = Sign2Type[sign];
			return new CBinaryOperator(sign, type);
		}
	}
}