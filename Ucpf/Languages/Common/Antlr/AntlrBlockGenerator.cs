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
			return Generate(node, astGen, DefaultCodeGenerator.Instance, leftToken,
				rightToken);
		}

		public static XElement Generate<TParser>(XElement node,
		                                         AntlrAstGenerator<TParser> astGen,
		                                         CodeGenerator codeGen,
		                                         string leftToken = "{",
		                                         string rightToken = "}") {
			var code = codeGen.Generate(node);
			if (code.StartsWith(leftToken)) {
				return node;
			}
			var newNode = astGen.Generate(leftToken + code + rightToken,
				node.Name.LocalName, true);
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