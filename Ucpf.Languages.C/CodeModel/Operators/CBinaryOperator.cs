using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CBinaryOperator : COperator, IBinaryOperator
	{
		public CBinaryOperator(string sign, BinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		public void Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}

		public string Sign { get; private set; }

		public BinaryOperatorType Type { get; private set; }

		private static readonly IDictionary<string, BinaryOperatorType> Sign2Type;

		static CBinaryOperator() {
			Sign2Type = new Dictionary<string, BinaryOperatorType>();
			// Arithmetic
			Sign2Type["+"]	= BinaryOperatorType.Addition;
			Sign2Type["-"]	= BinaryOperatorType.Subtraction;
			Sign2Type["*"]	= BinaryOperatorType.Multiplication;
			Sign2Type["/"]	= BinaryOperatorType.Division;
			Sign2Type["%"]	= BinaryOperatorType.Modulo;
			// Comparison
			Sign2Type["<"]	= BinaryOperatorType.Lesser;
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

		public override string ToString()
		{
			return Sign;
		}

		public static CBinaryOperator Create(XElement node)
		{
			var sign = node.Value;
			var type = Sign2Type[sign];
			return new CBinaryOperator(sign, type);
		}
	}
}
