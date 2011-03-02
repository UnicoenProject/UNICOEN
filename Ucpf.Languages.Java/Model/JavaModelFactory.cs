using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;
using System.Xml.Linq;
using Ucpf.Common.Model;

namespace Ucpf.Languages.Java.Model {
	public class JavaModelFactory {

		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			var modifiers = new UnifiedModifierCollection(node.Element("modifiers")
				.Elements().Select(e => new UnifiedModifier() { Name = e.Value } ));
			var returnType = node.Element("type").Elements().ElementAt(0).Value;
			var name = node.Element("IDENTIFIER").Value;
			var parameter = CreateParameterCollection(node.Element("formalParameters"));
			var block = new UnifiedBlock();

			return new UnifiedFunctionDefinition {
				Modifiers = modifiers,
				ReturnType = new UnifiedType { Name = returnType },
				Name = name,
				Parameters = parameter,
				Block = block
			};
		}

		private static UnifiedBlock CreateBlock(XElement xElement) {
			var unifiedBlock = new UnifiedBlock();

			var element = xElement.Element("blockStatement")
				.Element("statement");

			if (element.Elements().First().Name.LocalName == "TOKEN" 
				&& element.Elements().First().Value == "if") {
				unifiedBlock.Add(CreateIfExpression(element));
			}
			throw new NotImplementedException("in CreateBlock");
		}

		private static UnifiedIf CreateIfExpression(XElement xElement) {
			throw new NotImplementedException();
		}

		private static UnifiedParameterCollection CreateParameterCollection(XElement element) {

			return new UnifiedParameterCollection(
				element.Element("formalParameterDecls")
					.Elements("normalParameterDecl")
					.Select(e => new UnifiedParameter() {
						Modifier = new UnifiedModifier(),
						Type = new UnifiedType { Name = e.Element("type").Elements().First().Value },
						Name = e.Element("IDENTIFIER").Value
					}));
			// throw new NotImplementedException();
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