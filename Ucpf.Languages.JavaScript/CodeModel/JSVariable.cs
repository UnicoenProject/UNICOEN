using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel {
	//TODO not implemented yet
	public class JSVariable {

		//constructor
		public JSVariable(XElement xElement) {}

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}