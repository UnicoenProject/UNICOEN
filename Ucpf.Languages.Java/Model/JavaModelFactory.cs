using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Ucpf.Common.Model;

namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory {

		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			return new UnifiedFunctionDefinition {
				Modifiers = node.Element("modifiers").Elements().Select(e => e.Value),
				ReturnType = node.Element("type").Elements().ElementAt(0).Value,
				Name = node.Element("IDENTIFIER").Value,
				Parameters =
					CreateParameterCollection(node.Element("formalParameterList")),
				Block = CreateBlock(node.Element("block"))
			};
		}

		private static UnifiedBlock CreateBlock(XElement xElement) {
			var unifiedBlock = new UnifiedBlock();

			var element = xElement.Element("blockStatement")
				.Element("statement");

			if (element.Elements().First().Name.LocalName == "TOKEN" 
				&& element.Elements().First().Value == "if") {
				unifiedBlock.Add(CreateIfExpression(element).ToStatement());
			}
			throw new NotImplementedException("in CreateBlock");
		}

		private static UnifiedIf CreateIfExpression(XElement xElement) {
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