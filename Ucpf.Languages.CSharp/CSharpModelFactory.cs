using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Languages.CSharp.AstGenerators;

namespace Ucpf.Languages.CSharp {

	public class CSharpModelFactory {

		public static UnifiedBlock CreateModel(string code) {
			var xml = CSharpAstGenerator.Instance.Generate(code);
			var facotry = new CSharpModelFactory();
			return facotry.CreateModel(xml);
		}

		public UnifiedBlock CreateModel(XElement elem) {
			throw new NotImplementedException();

		}

	}
}
