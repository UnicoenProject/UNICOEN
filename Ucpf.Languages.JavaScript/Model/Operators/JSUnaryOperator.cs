using System;
using System.Xml.Linq;
using Ucpf.Common.Model.Visitors;
using Ucpf.Common.OldModel;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Languages.JavaScript.Model.Operators {
	public class JSUnaryOperator : IUnaryOperator {
		//properties
		public JSUnaryOperator(string sign, UnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		#region IUnaryOperator Members

		public string Sign { get; private set; }
		public UnaryOperatorType Type { get; private set; }

		void ICodeElement.Accept(IModelToCode conv) {
			conv.Generate(this);
		}

		#endregion

		//constructor

		//function
		public static JSUnaryOperator CreatePrefixOperator(XElement node) {
			string name = node.Value;
			UnaryOperatorType type;

			//TODO implement more OperationType cases
			if (name == "++") {
				type = UnaryOperatorType.PrefixIncrement;
			} else {
				throw new InvalidOperationException();
			}

			return new JSUnaryOperator(name, type);
		}

		public static JSUnaryOperator CreatePostfixOperator(XElement node) {
			string name = node.Value;
			UnaryOperatorType type;

			if (name == "++") {
				type = UnaryOperatorType.PostfixIncrement;
			} else {
				throw new InvalidOperationException();
			}

			return new JSUnaryOperator(name, type);
		}

		public void Accept(JSModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString() {
			return Sign;
		}
	}
}