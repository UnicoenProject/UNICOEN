using OpenCodeProcessorFramework.Languages.Java;

namespace Ucpf.Languages.Tests.Temp
{
	public static class SemanticFactory
	{
		public static JavaStatement Statement(string code)
		{
			var element = JavaAstGenerator.Instance.Generate(code, p => p.statement());
			return SemanticAnalyzer.Statement(element);
		}
	}
}