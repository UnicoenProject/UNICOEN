using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code2Xml.Languages.JavaScript.CodeToXmls;
using Unicoen.Core.Model;
using Unicoen.Core.ModelFactories;

namespace Unicoen.Languages.JavaScript.ModelFactories
{
	public class JavaScriptModelFactory : ModelFactory
	{
		public static JavaScriptModelFactory Instance = new JavaScriptModelFactory();

		public override UnifiedProgram GenerateWithouNormalizing(string code) {
			var ast = JavaScriptCodeToXml.Instance.Generate(code);
			return JavaScriptModelFactoryHelper.CreateProgram(ast);
		}
	}
}
