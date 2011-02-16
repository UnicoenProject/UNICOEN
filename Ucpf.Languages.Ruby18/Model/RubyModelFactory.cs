using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Scripting.Math;
using Ucpf.Common.Model;

namespace Ucpf.Languages.Ruby18.Model {
	public class RubyModelFactory {
		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "true" ||
			                  node.Name.LocalName == "false");
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
			if (node.Name.LocalName == "lit") {
				switch (node.Elements().First().Name.LocalName) {
				case "Fixnum":
					return new UnifiedIntegerLiteral {
						TypedValue = BigInteger.Parse(node.Value)
					};
				}
			}
			return new UnifiedLiteral {
				Value = node.Value,
			};
		}

		public static UnifiedDecimalLiteral CreateDecimalLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "lit");
			return new UnifiedDecimalLiteral {
				TypedValue = Decimal.Parse(node.Value)
			};
		}

		public static UnifiedExpression CreateExpression(XElement node) {
			switch (node.Name.LocalName) {
			case "lit":
				return CreateLiteral(node);
			case "lvar":
				return new UnifiedVariable(node.Value);
			case "call":
				return new UnifiedCall {
					Function = new UnifiedVariable(node.Elements().ElementAt(1).Value),
					Arguments = new UnifiedArgumentCollection(
						node.Elements().ElementAt(2).Elements()
							.Select(e => (UnifiedArgument)CreateExpression(e))),
				};
			}
			throw new NotImplementedException();
		}

		public static UnifiedStatement CreateStatement(XElement node) {
			switch (node.Name.LocalName) {
			case "return":
				return new UnifiedReturn {
					Value = CreateExpression(node.Elements().First())
				};
			}
			throw new NotImplementedException();
		}

		public static UnifiedDefineFunction CreateDefineFunction(XElement node) {
			Contract.Requires(node.Name.LocalName == "defn");
			var elems = node.Elements();
			return new UnifiedDefineFunction {
				Name = elems.First().Value,
				Parameters = new UnifiedParameterCollection(
					elems.ElementAt(1).Elements()
						.Select(e => new UnifiedParameter(e.Value))),
				Block = new UnifiedBlock(
					elems.ElementAt(2).Elements().First().Elements()
						.Where(e => e.Name.LocalName != "nil")
						.Select(CreateStatement)),
			};
		}
	}
}