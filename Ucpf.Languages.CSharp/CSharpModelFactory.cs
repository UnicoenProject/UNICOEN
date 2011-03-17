using System;
using System.IO;
using System.Linq;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;
using ICSharpCode.NRefactory.Parser;
using Ucpf.Core.Model;

namespace Ucpf.Languages.CSharp {

	public class CSharpModelFactory {

		public static UnifiedElement CreateModel(string code) {
			var reader = new StringReader(code);
			using (var parser = ParserFactory.CreateParser(SupportedLanguage.CSharp, reader)) {
				parser.Parse();
				var unit = parser.CompilationUnit;
				var visitor = new Translator();
				var model = unit.AcceptVisitor(visitor, null) as UnifiedElement;
				model.NormalizeBlock();
				return model;
			}
		}
	}

}
