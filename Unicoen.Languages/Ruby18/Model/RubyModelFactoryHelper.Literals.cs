using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using IronRuby.StandardLibrary.Yaml;
using UniUni.Xml.Linq;
using Unicoen.Model;
using Unicoen.Processor;

namespace Unicoen.Languages.Ruby18.Model {
	public partial class RubyModelFactoryHelper {
		public static IUnifiedExpression CreateFloat(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Float");
			return UnifiedFractionLiteral.Create(double.Parse(node.Value),
				UnifiedFractionLiteralKind.Double);
		}

		public static IUnifiedExpression CreateBignum(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Bignum");
			return UnifiedInt32Literal.Create(LiteralFuzzyParser.ParseBigInteger(node.Value));
		}

		public static IUnifiedExpression CreateFixnum(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "Fixnum");
			return UnifiedInt32Literal.Create(LiteralFuzzyParser.ParseInt32(node.Value));
		}

		public static IUnifiedExpression CreateLit(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lit");
			return CreateExpresion(node.FirstElement());
		}

		private static IUnifiedExpression CreateString(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "String");
			return UnifiedStringLiteral.Create(node.Value);
		}
	}
}
