using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel.Operators;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.C.CodeModel
{
	public class CUnaryOperator : COperator, IUnaryOperator
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
		private static readonly IDictionary<string, UnaryOperatorType> Sign2Type;

		static CUnaryOperator() {
			Sign2Type = new Dictionary<string, UnaryOperatorType>();
			Sign2Type["++"] = UnaryOperatorType.PrefixIncrement;
			Sign2Type["--"] = UnaryOperatorType.PrefixDecrement;
			Sign2Type["+"] = UnaryOperatorType.Plus;
			Sign2Type["-"] = UnaryOperatorType.Minus;
			Sign2Type["!"] = UnaryOperatorType.Not;
			Sign2Type["~"] = UnaryOperatorType.BitReverse;
			Sign2Type["&"] = UnaryOperatorType.Address;
			Sign2Type["*"] = UnaryOperatorType.Indirect;
		}

		public static CUnaryOperator CreatePrefix(XElement node)
		{
			var sign = node.Value;
			var type = Sign2Type[sign];
			return new CUnaryOperator(sign, type);
		}

		public static CUnaryOperator CreatePostfix(XElement node)
		{
			// TODO: fix format setting
			var sign = node.Value;
			var type =
				sign == "++" ? UnaryOperatorType.PostfixIncrement
					: sign == "--" ? UnaryOperatorType.PostfixDecrement
					  	: Sign2Type[sign];
			return new CUnaryOperator(sign, type);
		}


		string IUnaryOperator.Sign
		{
			get { return Sign; }
		}

		UnaryOperatorType IUnaryOperator.Type
		{
			get { return Type; }
		}

		void ICodeElement.Accept(ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}

}
