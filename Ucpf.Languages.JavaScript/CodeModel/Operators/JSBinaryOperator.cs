using System;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {

	public class JSBinaryOperator {

		//constructor
		public JSBinaryOperator(string sign, BinaryOperatorType type){
			Sign = sign;
			Type = type;
		}

		//field
		public string Sign { get; private set; }
		public BinaryOperatorType Type { get; private set; }

		//function
		public static JSBinaryOperator Create(XElement node) {
			
			string name = node.Value;
			BinaryOperatorType type;

			if ( name == "+") {
				type = BinaryOperatorType.Addition;
			}
			else if ( name == "<") {
				type = BinaryOperatorType.Lesser;
			}
			else {
				throw new InvalidOperationException();
			}

			return new JSBinaryOperator(name, type);
		}

		public void Accept(JSCodeModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString()
		{
			return Sign;
		}
	}
}