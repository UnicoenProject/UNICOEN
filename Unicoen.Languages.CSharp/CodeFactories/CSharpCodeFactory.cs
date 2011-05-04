using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unicoen.Core.CodeFactories;
using System.IO;
using Unicoen.Core.Model;

namespace Unicoen.Languages.CSharp.CodeFactories {

	public class CSharpCodeFactory : CodeFactory {

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			return Generate(model, writer, "\t");
		}

		public override string Generate(IUnifiedElement model, TextWriter writer, string indentSign) {
			throw new NotImplementedException();
		}

	}
}
