using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.JavaScript.CodeFactories;
using Unicoen.Languages.JavaScript.ModelFactories;

namespace Unicoen.Languages.JavaScript
{
	public static class JavaScriptFactory {

		public static readonly JavaScriptCodeFactory CodeFactory;
		public static readonly JavaScriptModelFactory ModelFactory;

		static JavaScriptFactory() {
			CodeFactory = new JavaScriptCodeFactory();
			ModelFactory = new JavaScriptModelFactory();
		}

		public static string GenerateCode(IUnifiedElement model) {
			return CodeFactory.Generate(model);
		}

		public static UnifiedProgram GenerateModel(string code) {
			return ModelFactory.Generate(code);
		}
	}
}