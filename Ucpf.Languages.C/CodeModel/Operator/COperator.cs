using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class COperator
	{
		public static string[] arithmeticOperators		= { "+", "-", "*", "/", "%" };
		public static string[] bitOperators				= { "&", "|", "^", "~" };
		public static string[] shiftOperators			= { "<<",	">>" };
		public static string[] comparisonOperators		= { "<=", "<", ">=", ">", "==", "!=" };
		public static string[] logicalOperators			= { "&&", "||" };
		public static string[] assignmentOperators		= { "=", "+=", "-=", "*=", "/=" }; // TODO :: research and implement

		// private XElement ope;

		// private XElement _node;

		public String Name { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public static COperator CreateOperator(XElement node)
		{
			// TODO :: Move and make Create***Operator method
			var opeName = node.Value;
			if (arithmeticOperators.Contains(opeName))
			{
				return CArithmeticOperator.CreateArithmeticOperator(node);
			}
			else if (bitOperators.Contains(opeName))
			{
				return CBitOperator.CreateBitOperator(node);
			}
			else if (shiftOperators.Contains(opeName))
			{
				return CShiftOperator.CreateShiftOperator(node);
			}
			else if (comparisonOperators.Contains(opeName))
			{
				return CComparisonOperator.CreateComparisonOperator(node);
			}
			else if (logicalOperators.Contains(opeName))
			{
				return CLogicalOperator.CreateLogicalOperator(node);
			}
			else if (assignmentOperators.Contains(opeName))
			{
				return CAssignmentOperator.CreateAssignmentOperator(node);
			}
			// else return new COperator(opeName);			// TODO :: change to throwing "InvalidOperationException"
			throw new InvalidOperationException();
		}


		public static COperator CreatePrefixOperator(XElement node)
		{
			// TODO :: move below switching to subclasses
			switch (node.Value)
			{
				case "++":
					return new CPrefixIncrementOperator();
				case "--":
					return new CPrefixDecrementOperator();
				default :
					throw new InvalidOperationException();
			}
		}

		public static COperator CreatePostfixOperator(XElement node)
		{
			// TODO :: move below switching to subclasses
			switch (node.Value)
			{
				case "++":
					return new CPostfixIncrementOperator();
				case "--":
					return new CPostfixDecrementOperator();
				default:
					throw new InvalidOperationException();
			}
		}


		// constructor :: calling from outer classes is prohibitted.
		protected COperator(string name)
		{
			Name = name;
		}
		// TODO :: (maybe) delete below constructor
		protected COperator() { }


	}
}
