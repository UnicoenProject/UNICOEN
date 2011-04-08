using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Scripting.Math;
using Ucpf.Core.Model;

namespace Ucpf.Languages.Ruby18.Model {
	public class RubyModelFactory {
		private static readonly Dictionary<string, UnifiedBinaryOperatorType> Sign2Type;

		static RubyModelFactory() {
			Sign2Type = new Dictionary<string, UnifiedBinaryOperatorType>();
			Sign2Type["+"] = UnifiedBinaryOperatorType.Add;
			Sign2Type["-"] = UnifiedBinaryOperatorType.Subtract;
			Sign2Type["*"] = UnifiedBinaryOperatorType.Multiply;
			Sign2Type["/"] = UnifiedBinaryOperatorType.Divide;
			Sign2Type["%"] = UnifiedBinaryOperatorType.Modulo;
			Sign2Type["<"] = UnifiedBinaryOperatorType.LessThan;
			Sign2Type["<="] = UnifiedBinaryOperatorType.LessThanOrEqual;
			Sign2Type[">"] = UnifiedBinaryOperatorType.GreaterThan;
			Sign2Type[">="] = UnifiedBinaryOperatorType.GreaterThanOrEqual;
		}

		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "true" ||
							  node.Name.LocalName == "false");
			return UnifiedBooleanLiteral.Create(node.Name.LocalName == "true");
		}

		public static UnifiedStringLiteral CreateStringLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "str");
			return UnifiedStringLiteral.Create(node.Value);
		}

		public static UnifiedLiteral CreateLiteral(XElement node) {
			if (node.Name.LocalName == "lit") {
				switch (node.Elements().First().Name.LocalName) {
					case "Fixnum":
						return UnifiedIntegerLiteral.Create(
							BigInteger.Parse(node.Value));
				}
			}
			throw new NotImplementedException();
		}

		public static UnifiedDecimalLiteral CreateDecimalLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "lit");
			return UnifiedDecimalLiteral.Create(Decimal.Parse(node.Value));
		}

		public static UnifiedBinaryOperator CreateOperator(string sign) {
			UnifiedBinaryOperatorType result;
			return Sign2Type.TryGetValue(sign, out result)
					? UnifiedBinaryOperator.Create(sign, result) : null;
		}

		public static IUnifiedExpression CreateCall(XElement node) {
			Contract.Requires(node.Name.LocalName == "call");
			var funcName = node.Elements().ElementAt(1).Value;
			if (node.Elements().ElementAt(2).Elements().Count() == 1) {
				var @operator = CreateOperator(funcName);
				if (@operator != null) {
					return UnifiedBinaryExpression.Create(CreateExpression(node.Elements().First()), @operator, CreateExpression(node.Elements().ElementAt(2).Elements().First()));
				}
			}
			return UnifiedCall.Create(UnifiedIdentifier.CreateUnknown(funcName), UnifiedArgumentCollection.Create(
					node.Elements().ElementAt(2).Elements()
						.Select(e => UnifiedArgument.Create(CreateExpression(e)))));
		}

		public static IUnifiedExpression CreateExpression(XElement node) {
			var elems = node.Elements();
			switch (node.Name.LocalName) {
			case "lit":
				return CreateLiteral(node);
			case "lvar":
				return UnifiedIdentifier.CreateUnknown(node.Value);
			case "call":
				return CreateCall(node);
			case "if":
				return UnifiedIf.Create(CreateExpression(elems.ElementAt(0)),
						CreateBlock(elems.ElementAt(1)), CreateBlock(elems.ElementAt(2)));
			case "return":
				return UnifiedJump.CreateReturn(
					CreateExpression(elems.First()));
			default:
				throw new NotImplementedException();
			}
		}

		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			Contract.Requires(node.Name.LocalName == "defn");
			var elems = node.Elements();
			return UnifiedFunctionDefinition.Create(
				elems.First().Value,
				UnifiedParameterCollection.Create(
					elems.ElementAt(1).Elements()
						.Select(e => UnifiedParameter.Create(e.Value))),
				CreateBlock(elems.ElementAt(2).Elements().First())
			);
		}

		private static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node.Name.LocalName == "block");
			return UnifiedBlock.Create(
				node.Elements()
					.Where(e => e.Name.LocalName != "nil")
					.Select(CreateExpression));
		}
	}
}