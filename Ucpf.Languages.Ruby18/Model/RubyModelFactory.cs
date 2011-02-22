using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Scripting.Math;
using Ucpf.Common.Model;
using Ucpf.Common.OldModel.Operators;

namespace Ucpf.Languages.Ruby18.Model {
	public class RubyModelFactory {
		private static readonly Dictionary<string, BinaryOperatorType> Sign2Type;

		static RubyModelFactory() {
			Sign2Type = new Dictionary<string, BinaryOperatorType>();
			Sign2Type["+"] = BinaryOperatorType.Addition;
			Sign2Type["-"] = BinaryOperatorType.Subtraction;
			Sign2Type["*"] = BinaryOperatorType.Multiplication;
			Sign2Type["/"] = BinaryOperatorType.Division;
			Sign2Type["%"] = BinaryOperatorType.Modulo;
			Sign2Type["<"] = BinaryOperatorType.Lesser;
			Sign2Type["<="] = BinaryOperatorType.LesserEqual;
			Sign2Type[">"] = BinaryOperatorType.Greater;
			Sign2Type[">="] = BinaryOperatorType.GreaterEqual;
		}

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
						return new UnifiedIntegerLiteral(
							BigInteger.Parse(node.Value));
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

		public static UnifiedBinaryOperator CreateOperator(string sign) {
			BinaryOperatorType result;
			return Sign2Type.TryGetValue(sign, out result)
					? new UnifiedBinaryOperator(sign, result) : null;
		}

		public static UnifiedExpression CreateCall(XElement node) {
			Contract.Requires(node.Name.LocalName == "call");
			var funcName = node.Elements().ElementAt(1).Value;
			if (node.Elements().ElementAt(2).Elements().Count() == 1) {
				var @operator = CreateOperator(funcName);
				if (@operator != null) {
					return new UnifiedBinaryExpression {
						LeftHandSide = CreateExpression(node.Elements().First()),
						Operator = @operator,
						RightHandSide =
							CreateExpression(node.Elements().ElementAt(2).Elements().First()),
					};
				}
			}
			return new UnifiedCall {
				Function = new UnifiedVariable(funcName),
				Arguments = new UnifiedArgumentCollection(
					node.Elements().ElementAt(2).Elements()
						.Select(e => (UnifiedArgument)CreateExpression(e))),
			};
		}

		public static UnifiedExpression CreateExpression(XElement node) {
			var elems = node.Elements();
			switch (node.Name.LocalName) {
				case "lit":
					return CreateLiteral(node);
				case "lvar":
					return new UnifiedVariable(node.Value);
				case "call":
					return CreateCall(node);
				case "if":
					return new UnifiedIf {
						Condition = CreateExpression(elems.ElementAt(0)),
						TrueBlock = CreateBlock(elems.ElementAt(1)),
						FalseBlock = CreateBlock(elems.ElementAt(2)),
					};
			}
			throw new NotImplementedException();
		}

		public static UnifiedStatement CreateStatement(XElement node) {
			var elems = node.Elements();
			switch (node.Name.LocalName) {
				case "return":
					return new UnifiedReturn {
						Value = CreateExpression(elems.First())
					};
			}
			return new UnifiedExpressionStatement(
				CreateExpression(node));
			throw new NotImplementedException();
		}

		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			Contract.Requires(node.Name.LocalName == "defn");
			var elems = node.Elements();
			return new UnifiedFunctionDefinition {
				Name = elems.First().Value,
				Parameters = new UnifiedParameterCollection(
					elems.ElementAt(1).Elements()
						.Select(e => new UnifiedParameter{ Name =  e.Value })),
				Block = CreateBlock(elems.ElementAt(2).Elements().First()),
			};
		}

		private static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node.Name.LocalName == "block");
			return new UnifiedBlock(
				node.Elements()
					.Where(e => e.Name.LocalName != "nil")
					.Select(CreateStatement));
		}
	}
}