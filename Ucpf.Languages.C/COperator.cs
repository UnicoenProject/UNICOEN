using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C
{
	public class COperator
	{
		private XElement _node;

		public COperator Operator
		{
			get
			{
				return CreateOperator(_node);
			}
		}

		public string ToString()
		{
			return Operator.ToString();
		}

		public static COperator CreateOperator(XElement node){
			var ope = node.Element("TOKEN");
			if(ope != null){
				switc(judge)
				
		}


		// constructor
		public COperator(XElement node)
		{
			_node = node;
		}
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