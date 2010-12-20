using System;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	
	public class JSOperator {

		//constructor
		public JSOperator(string identifier) {
			Identifier = identifier;
		}

		//field
		public String Identifier { get; private set; }

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString()
		{
			return Identifier;
		}

	}
}