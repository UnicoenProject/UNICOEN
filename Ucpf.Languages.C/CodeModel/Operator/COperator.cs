﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class COperator
	{
		// private XElement _node;

		public String Name { get; set; }

		public string ToString()
		{
			return Name;
		}

		public static COperator CreateOperator(XElement node)
		{
			return new COperator(node.Value);
		}
		public static COperator CreateBeforeOperator(XElement node)
		{
			switch (node.Value)
			{
				case "++":
					return new CIncrementBeforOperator();
				case "--":
					return new CDecrementBeforeOperator();
				default :
					throw new InvalidOperationException();
			}


		}
		public static COperator CreateAfterOperator(XElement node)
		{
			switch (node.Value)
			{
				case "++":
					return new CIncrementAfterOperator();
				case "--":
					return new CDecrementAfterOperator();
				default:
					throw new InvalidOperationException();
			}
		}


		// constructor
		public COperator(string name)
		{
			Name = name;
		}
		public COperator() { }

	}
}

/*
 * Binary Operator of C
 * arithmetic operator :: * / % + -
 * bit operator :: << >> & | ^ ~
 * substitution operator :: =,+=,-=,*=,/= 
 * comparison operator :: <=, <, >=, >, ==, != 
 * logical oeprator :: && ||
*/