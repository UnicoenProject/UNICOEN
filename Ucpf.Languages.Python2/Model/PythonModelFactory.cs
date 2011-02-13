using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using Ucpf.Common.Model;

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
