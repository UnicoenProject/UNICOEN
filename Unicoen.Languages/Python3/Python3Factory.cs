using Unicoen.Languages.Python3.ProgramGenerators;
using Unicoen.Model;

namespace Unicoen.Languages.Python3 {
	public static class Python3Factory {
		public static readonly Python3CodeGenerator CodeGenerator;
		public static readonly Python3ProgramGenerator ProgramGenerator;

		static Python3Factory() {
			CodeGenerator = new Python3CodeGenerator();
			ProgramGenerator = new Python3ProgramGenerator();
		}

		public static string GenerateCode(IUnifiedElement model) {
			return CodeGenerator.Generate(model);
		}

		public static UnifiedProgram GenerateModel(string code) {
			return ProgramGenerator.Generate(code);
		}
	}
}