using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.C.CodeFactories;
using Unicoen.Languages.C.ModelFactories;

namespace Unicoen.Languages.C
{
	public static class CFactory {

		public static readonly CCodeFactory CodeFactory;
		public static readonly CModelFactory ModelFactory;

		static CFactory() {
			CodeFactory = new CCodeFactory();
			ModelFactory = new CModelFactory();
		}

		public static string GenerateCode(IUnifiedElement model) {
			return CodeFactory.Generate(model);
		}

		public static UnifiedProgram GenerateModel(string code) {
			return ModelFactory.Generate(code);
		}
	}
}
