using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicoen.Core.CodeFactories;
using Unicoen.Core.Model;

namespace Unicoen.Languages.JavaScript.CodeFactories
{
	public class JavaScriptCodeFactory : CodeFactory
	{
		public override string Generate(IUnifiedElement model, TextWriter writer, string indentSign) {
			throw new NotImplementedException();
		}

		public override string Generate(IUnifiedElement model, TextWriter writer) {
			throw new NotImplementedException();
		}
	}
}
