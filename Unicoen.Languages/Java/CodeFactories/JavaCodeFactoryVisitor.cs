using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.CodeFactories;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.Java.CodeFactories {
	public class JavaCodeFactoryVisitor : JavaLikeCodeFactoryVisitor {
		public JavaCodeFactoryVisitor(TextWriter writer, string indentSign) : base(writer, indentSign) {}
	}
}
