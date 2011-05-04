using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp.CodeFactories;
using Unicoen.Languages.CSharp.ModelFactories;

namespace Unicoen.Languages.CSharp {
	public static class CSharpFactory {

		private static readonly CSharpCodeFactory CodeFactory = new CSharpCodeFactory();
		private static readonly CSharpModelFactory ModelFactory = new CSharpModelFactory();

		public static string GenerateCode(IUnifiedElement model) {
			return CodeFactory.Generate(model);
		}

		public static UnifiedProgram GenerateModel(string code) {
			return ModelFactory.Generate(code);
		}
	}
}
