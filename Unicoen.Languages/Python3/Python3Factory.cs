using Unicoen.Languages.Python3.ModelFactories;
using Unicoen.Model;

namespace Unicoen.Languages.Python3 {
	public static class Python3Factory {
		public static readonly Python3CodeFactory CodeFactory;
		public static readonly Python3ProgramGenerator ProgramGenerator;

		static Python3Factory() {
			CodeFactory = new Python3CodeFactory();
			ProgramGenerator = new Python3ProgramGenerator();
		}

		public static string GenerateCode(IUnifiedElement model) {
			return CodeFactory.Generate(model);
		}

		public static UnifiedProgram GenerateModel(string code) {
			return ProgramGenerator.Generate(code);
		}
	}
}