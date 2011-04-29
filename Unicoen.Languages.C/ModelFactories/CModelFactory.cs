using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Code2Xml.Languages.C.CodeToXmls;
using Unicoen.Core.Model;
using Unicoen.Core.ModelFactories;

namespace Unicoen.Languages.C.ModelFactories
{
	public class CModelFactory : ModelFactory
	{
		public static CModelFactory Instance = new CModelFactory();

		public override UnifiedProgram GenerateWithouNormalizing(string code) {
			var ast = CCodeToXml.Instance.Generate(code);
			return CModelFactoryHelper.CreateTranslation_unit(ast);
		}
	}
}
