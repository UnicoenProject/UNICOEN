using System.IO;
using ICSharpCode.NRefactory;
using Ucpf.Core.Model;

namespace Ucpf.Languages.CSharp {
	public class CSharpModelFactory {
		public static UnifiedProgram CreateModel(string code) {
			var reader = new StringReader(code);
			using (
					var parser = ParserFactory.CreateParser(SupportedLanguage.CSharp, reader)) {
				parser.Parse();
				var unit = parser.CompilationUnit;
				var visitor = new Translator();
				var model = unit.AcceptVisitor(visitor, null) as UnifiedProgram;
				if (model == null)
					return null;
				model.Normalize();
				return model;
			}
		}
	}
}