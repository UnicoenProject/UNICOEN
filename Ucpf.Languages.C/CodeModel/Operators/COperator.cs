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


		// constructor :: calling from outer classes is prohibitted.
		protected COperator(string name)
		{
			Name = name;
		}
		// TODO :: (maybe) delete below constructor
		protected COperator() { }



		public String Name { get; set; }

		public override string ToString()
		{
			return Name;
		}

		public static COperator Create(XElement node)
		{
			// TODO :: Move and make Create***Operator method
			var opeName = node.Value;
			if (arithmeticOperators.Contains(opeName))
			{
				return CArithmeticOperator.Create(node);
			}
			else if (bitOperators.Contains(opeName))
			{
				return CBitOperator.Create(node);
			}
			else if (shiftOperators.Contains(opeName))
			{
				return CShiftOperator.Create(node);
			}
			else if (comparisonOperators.Contains(opeName))
			{
				return CComparisonOperator.Create(node);
			}
			else if (logicalOperators.Contains(opeName))
			{
				return CLogicalOperator.Create(node);
			}
			else if (assignmentOperators.Contains(opeName))
			{
				return CAssignmentOperator.CreateAssignmentOperator(node);
			}
			// else return new COperator(opeName);			// TODO :: delete this switching branch
			throw new InvalidOperationException();
		}

		public void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		// 2 methods below are maybe unnecessary. After confirming tests, delete these.
		/*
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
		*/


	}
}
