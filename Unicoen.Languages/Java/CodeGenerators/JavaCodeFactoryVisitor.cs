using System.IO;
using Unicoen.CodeGenerators;

namespace Unicoen.Languages.Java.CodeGenerators {
	public class JavaCodeFactoryVisitor : JavaLikeCodeFactoryVisitor {
		public JavaCodeFactoryVisitor(TextWriter writer, string indentSign) : base(writer, indentSign) {}
	}
}
