using System.Diagnostics.Contracts;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.Common.Antlr {
	public static class AntlrCodeGenerateHelper {
		public static XElement WrapNode<T>(XElement node, AntlrAstGenerator<T> astGen,
		                                   CodeGenerator codeGen,
		                                   string beforeCode, string afterCode) {
			Contract.Requires(node != null);
			Contract.Requires(astGen != null);
			Contract.Requires(codeGen != null);
			Contract.Requires(beforeCode != null);
			Contract.Requires(afterCode != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			var oldcode = codeGen.Generate(node);
			var code = beforeCode + oldcode + afterCode;
			return astGen.Generate(code, node.Name.LocalName, true);
		}
	}
}