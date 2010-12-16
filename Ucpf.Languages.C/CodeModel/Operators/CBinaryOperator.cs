using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.CodeModel;
using Ucpf.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CBinaryOperator : IBinaryOperator
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

		public override string ToString()
		{
			return Sign;
		}


		public static CBinaryOperator Create(XElement opeNode)
		{
			Hashtable opeHash = new Hashtable();

			// TODO :: create hash table for generating Operator instance efficiently
			// Arithmetic
			opeHash["+"]	= BinaryOperatorType.Addition;
			opeHash["-"]	= BinaryOperatorType.Subtraction;
			opeHash["*"]	= BinaryOperatorType.Multiplication;
			opeHash["/"]	= BinaryOperatorType.Division;
			opeHash["%"]	= BinaryOperatorType.Modulo;
			// Comparison
			opeHash["<"]	= BinaryOperatorType.Lesser;
			opeHash["<="] = BinaryOperatorType.LesserEqual;
			opeHash[">"] = BinaryOperatorType.Greater;
			opeHash[">="] = BinaryOperatorType.GreaterEqual;
			opeHash["=="] = BinaryOperatorType.Equal;
			opeHash["!="] = BinaryOperatorType.NotEqual;
			// Shift
			opeHash["<<"] = BinaryOperatorType.LeftShift;
			opeHash[">>"] = BinaryOperatorType.RightShift;
			// Logical
			opeHash["&&"] = BinaryOperatorType.LogicalAnd;
			opeHash["||"] = BinaryOperatorType.LogicalOr;
			// Bit
			opeHash["&"] = BinaryOperatorType.BitAnd;
			opeHash["|"] = BinaryOperatorType.BitOr;
			opeHash["^"] = BinaryOperatorType.BitXor;
			opeHash["~"] = BinaryOperatorType.BitReverse;
			// Assignment
			opeHash["="] = BinaryOperatorType.Assignment;
			// TODO :: implement other 'compound' assignment operator (e.g. +=


			var opeSign = opeNode.Value;
			var opeType = opeHash[opeSign];
			
			if (opeType != null)
			{
				return new CBinaryOperator(opeSign, (BinaryOperatorType)opeType);
			}
			else
			{
				throw new InvalidOperationException();
			}

			
		}
	}
}
