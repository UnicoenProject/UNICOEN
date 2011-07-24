using System.IO;
using Unicoen.CodeFactories;
using Unicoen.Model;
using Unicoen.Processor;

namespace MseConverter
{
	public class MseConverter : CodeFactory {

		public static MseConvertVisitor Visitor;

		public MseConverter(StringWriter writer) {
			Visitor = new MseConvertVisitor(writer);
		}

		public override void Generate(IUnifiedElement codeObject, TextWriter writer, string indentSign) {
			codeObject.Accept(Visitor, new VisitorArgument());
		}

		public override void Generate(IUnifiedElement codeObject, TextWriter writer) {
			Generate(codeObject, writer, "\t");
		}
	}
}
