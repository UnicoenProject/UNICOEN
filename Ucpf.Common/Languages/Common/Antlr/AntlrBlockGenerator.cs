using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Paraiba.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.Common.Antlr {
	public static class AntlrBlockGenerator {
		public static XElement Generate<TParser>(XElement node,
		                                         AntlrAstGenerator<TParser> astGen,
		                                         string leftToken = "{",
		                                         string rightToken = "}") {
			Contract.Requires(node != null);
			Contract.Requires(astGen != null);
			Contract.Requires(leftToken != null);
			Contract.Requires(rightToken != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			return Generate(node, astGen, DefaultCodeGenerator.Instance, leftToken,
				rightToken);
		}

		public static XElement Generate<TParser>(XElement node,
		                                         AntlrAstGenerator<TParser> astGen,
		                                         CodeGenerator codeGen,
		                                         string leftToken = "{",
		                                         string rightToken = "}") {
			Contract.Requires(node != null);
			Contract.Requires(astGen != null);
			Contract.Requires(codeGen != null);
			Contract.Requires(leftToken != null);
			Contract.Requires(rightToken != null);
			Contract.Ensures(Contract.Result<XElement>() != null);
			var code = codeGen.Generate(node);
			if (code.StartsWith(leftToken)) {
				return node;
			}
			var newNode = astGen.Generate(leftToken + code + rightToken,
				node.Name.LocalName);
			foreach (
				var t in
					node.Descendants("TOKEN").Zip(newNode.Descendants("TOKEN").Skip(1))) {
				foreach (var attribute in t.Item1.Attributes()) {
					t.Item2.SetAttributeValue(attribute.Name, attribute.Value);
				}
			}
			return newNode;
		}
	}
}