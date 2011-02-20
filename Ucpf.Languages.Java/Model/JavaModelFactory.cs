using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Ucpf.Common.Model;

namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory {

		public static UnifiedDefineFunction CreateDefineFunction(XElement node) {
			return new UnifiedDefineFunction {
				Modifiers = node.Element("modifiers").Elements().Select(e => e.Value),
				ReturnType = node.Element("Type").Elements().ElementAt(0).Value,
				Name = node.Element("IDENTIFIER").Value,
				Parameters =
					CreateParameterCollection(node.Element("formalParameterList")),
				Block = CreateBlock(node.Element("block"))
			};
		}

		private static UnifiedBlock CreateBlock(XElement xElement) {
			var element = xElement.Element("Statement").Elements().First();
			var unifiedBlock = new UnifiedBlock ();
			if (element.Name.LocalName == "TOKEN" && element.Value == "if") {
				unifiedBlock.Add(CreateIfStatement());
			}
			throw new NotImplementedException();
		}

		private static UnifiedIf CreateIfStatement() {
			throw new NotImplementedException();
		}

		private static UnifiedParameterCollection CreateParameterCollection(XElement element) {
			throw new NotImplementedException();
		}

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