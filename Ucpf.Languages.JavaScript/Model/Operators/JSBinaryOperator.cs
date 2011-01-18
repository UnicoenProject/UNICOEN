using System;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.ModelToCode;

namespace Ucpf.Languages.JavaScript.Model {
	public class JSBinaryOperator : IBinaryOperator {
		//properties
		public JSBinaryOperator(string sign, BinaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		#region IBinaryOperator Members

		public string Sign { get; private set; }
		public BinaryOperatorType Type { get; private set; }

		void ICodeElement.Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		//constructor

		//function
		public static JSBinaryOperator Create(XElement node) {
			//TODO implement more OperatorType cases
			string name = node.Value;
			BinaryOperatorType type;

			switch (name) {
			case "+":
				type = BinaryOperatorType.Addition;
				break;
			case "-":
				type = BinaryOperatorType.Subtraction;
				break;
			case "<":
				type = BinaryOperatorType.Lesser;
				break;
			default:
				throw new InvalidOperationException();
			}

			return new JSBinaryOperator(name, type);
		}

		public void Accept(JSModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString() {
			return Sign;
		}
	}
}