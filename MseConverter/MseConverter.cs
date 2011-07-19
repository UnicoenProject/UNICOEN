using System.IO;
using Unicoen.CodeFactories;
using Unicoen.Model;
using Unicoen.Processor;

namespace MseConverter
{
	public class MseConverter : CodeFactory {
		public override void Generate(IUnifiedElement codeObject, TextWriter writer, string indentSign) {
			writer.WriteLine("(Moose.Model (id: 1)");
			writer.WriteLine("\t(entity");
			codeObject.Accept(new MseConvertVisitor(writer), new VisitorArgument());
			writer.WriteLine("\t)");
			//TODO 言語の種類を出力
			writer.WriteLine("(sourceLanguage language))");
		}

		public override void Generate(IUnifiedElement codeObject, TextWriter writer) {
			Generate(codeObject, writer, "\t");
		}
	}
}
