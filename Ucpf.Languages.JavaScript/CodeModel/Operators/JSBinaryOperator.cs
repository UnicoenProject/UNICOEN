﻿using System;
using System.Xml.Linq;
using Ucpf.Common.CodeModel;
using Ucpf.Common.CodeModel.Operators;
using Ucpf.Common.CodeModelToCode;

namespace Ucpf.Languages.JavaScript.CodeModel {

	public class JSBinaryOperator : IBinaryOperator{

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
			else if ( name == "-") {
				type = BinaryOperatorType.Subtraction;
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

		void ICodeElement.Accept(ICodeModelToCode conv) {
			conv.Generate(this);
		}

		public override string ToString()
		{
			return Sign;
		}

	}
}