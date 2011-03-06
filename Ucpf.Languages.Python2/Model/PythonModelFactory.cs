using System;
using System.Xml.Linq;
using Ucpf.Core.Model;
using Ucpf.Core.Model.Expressions.Literals;

namespace Ucpf.Languages.Python2.Model {
	public class PythonModelFactory {
		public static UnifiedStringLiteral CreateStringLiteral(XElement ast) {
			return new UnifiedStringLiteral {
				Value = "1"
			};
		}

		public static UnifiedBlock CreateBlock(XElement elem) {
			throw new NotImplementedException();
		}
	}
}