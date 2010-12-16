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
	public class CUnaryOperator//  : IUnaryOperator
	{
		// constructor
		public CUnaryOperator(string sign, UnaryOperatorType type)
		{
			Sign = sign;
			Type = type;
		}

		// acceptor
		public void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		// properties
		public string Sign { get; private set; }
		public UnaryOperatorType Type { get; private set; }

		public static CUnaryOperator Create(XElement opeNode)
		{
			var opeHash = new Hashtable();

			opeHash["++"] = UnaryOperatorType.PrefixIncrement;
			opeHash["--"] = UnaryOperatorType.PrefixDecrement;
			opeHash["+"] = UnaryOperatorType.Plus;
			opeHash["-"] = UnaryOperatorType.Minus;
			opeHash["!"] = UnaryOperatorType.Not;
			opeHash["~"] = UnaryOperatorType.BitReverse;
			opeHash["&"] = UnaryOperatorType.Address;
			opeHash["*"] = UnaryOperatorType.Indirect;

			var opeSign = opeNode.Value;
			var opeType = opeHash[opeSign];
			if (opeType != null)
			{
				return new CUnaryOperator(opeSign, (UnaryOperatorType)opeType);
			}
			else
			{
				throw new InvalidOperationException();
			}

		}

		public static CUnaryOperator CreatePost(XElement opeNode)
		{
			var opeHash = new Hashtable();

			opeHash["++"] = UnaryOperatorType.PostfixIncrement;
			opeHash["--"] = UnaryOperatorType.PostfixDecrement;

			// should the following procedure be extracted to a method?? 
			var opeSign = opeNode.Value;
			var opeType = opeHash[opeSign];
			if (opeType != null)
			{
				return new CUnaryOperator(opeSign, (UnaryOperatorType)opeType);
			}
			else
			{
				throw new InvalidOperationException();
			}
		}

	}
}
