using System;
using System.Diagnostics.Contracts;
using System.Numerics;
using System.Xml.Linq;
using Ucpf.Common.Model;
using Ucpf.Common.Model;

namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory {

		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "true" || node.Name.LocalName == "false");
			return new UnifiedBooleanLiteral {
				TypedValue = node.Name.LocalName == "true"
				             	? UnifiedBoolean.True : UnifiedBoolean.False,
				Value = node.Value,
			};
		}

		public static UnifiedStringLiteral CreateStringLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "str");
			return new UnifiedStringLiteral {
				Value = node.Value,
			};
		}

		public static UnifiedLiteral CreateLiteral(XElement node) {
			// TODO: change to helper method
			Contract.Requires(node.Name.LocalName == "lit");
			return new UnifiedLiteral {
				Value = node.Value,
			};
		}

		public static UnifiedIntegerLiteral CreateIntegerLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "lit");
			return new UnifiedIntegerLiteral(BigInteger.Parse(node.Value));
		}

		public static UnifiedDecimalLiteral CreateDecimalLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "lit");
			return new UnifiedDecimalLiteral {
				TypedValue = Decimal.Parse(node.Value)
			};
		}
	}
}