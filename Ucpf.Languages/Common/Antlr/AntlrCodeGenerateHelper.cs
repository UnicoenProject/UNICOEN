using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace Ucpf.Languages.Common.Antlr
{
	public static class AntlrCodeGenerateHelper
	{
		public static XElement WrapNode<T>(ICodeGenerator codeGen, XElement target, AntlrAstGeneratorOld<T> astGen, string beforeCode, string afterCode)
			where T : IXParser
		{
			var oldcode = codeGen.Generate(target);
			var code = beforeCode + oldcode + afterCode;
			return astGen.Generate(code,
				p => p.GetType().GetMethod(target.Name.LocalName).Invoke(p, null), true);
		}

		public static XElement WrapNode<T>(XElement node, AntlrAstGenerator<T> astGen, ICodeGenerator codeGen, string beforeCode, string afterCode)
			where T : IXParser
		{
			var oldcode = codeGen.Generate(node);
			var code = beforeCode + oldcode + afterCode;
			return astGen.Generate(code, node.Name.LocalName, true);
		}
	}
}
