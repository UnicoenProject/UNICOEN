using Unicoen.Languages.Python3.ModelFactories;
using Unicoen.Model;

namespace Unicoen.Languages.Python3 {
	public static class Python3Factory {
		public static readonly Python3CodeFactory CodeFactory;
		public static readonly Python3ModelFactory ModelFactory;

		static Python3Factory() {
			CodeFactory = new Python3CodeFactory();
			ModelFactory = new Python3ModelFactory();
		}

		public static string GenerateCode(IUnifiedElement model) {
			return CodeFactory.Generate(model);
		}

		public static UnifiedProgram GenerateModel(string code) {
			return ModelFactory.Generate(code);
		}
	}
}