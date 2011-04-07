using System;
using System.Xml.Linq;
using Ucpf.Core.Model;


namespace Ucpf.Languages.Python2.Model {
	public class PythonModelFactory {
		public static UnifiedStringLiteral CreateStringLiteral(XElement ast) {
			return UnifiedStringLiteral.Create("1");
		}

		public static UnifiedBlock CreateBlock(XElement elem) {
			throw new NotImplementedException();
		}
	}
}