using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.Common.Antlr {
	public static class AntlrCodeGenerateHelper {
		public static XElement WrapNode<T>(XElement node, AntlrAstGenerator<T> astGen,
		                                   CodeGenerator codeGen,
		                                   string beforeCode, string afterCode) {
			var oldcode = codeGen.Generate(node);
			var code = beforeCode + oldcode + afterCode;
			return astGen.Generate(code, node.Name.LocalName, true);
		}
	}
}