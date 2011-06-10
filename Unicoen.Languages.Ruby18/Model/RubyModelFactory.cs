#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Microsoft.Scripting.Math;
using Unicoen.Core.Model;
using BigInteger = System.Numerics.BigInteger;

namespace Unicoen.Languages.Ruby18.Model {
	public class RubyModelFactory {
		private static readonly Dictionary<string, UnifiedBinaryOperatorKind>
				Sign2Type;

		static RubyModelFactory() {
			Sign2Type = new Dictionary<string, UnifiedBinaryOperatorKind>();
			Sign2Type["+"] = UnifiedBinaryOperatorKind.Add;
			Sign2Type["-"] = UnifiedBinaryOperatorKind.Subtract;
			Sign2Type["*"] = UnifiedBinaryOperatorKind.Multiply;
			Sign2Type["/"] = UnifiedBinaryOperatorKind.Divide;
			Sign2Type["%"] = UnifiedBinaryOperatorKind.Modulo;
			Sign2Type["<"] = UnifiedBinaryOperatorKind.LessThan;
			Sign2Type["<="] = UnifiedBinaryOperatorKind.LessThanOrEqual;
			Sign2Type[">"] = UnifiedBinaryOperatorKind.GreaterThan;
			Sign2Type[">="] = UnifiedBinaryOperatorKind.GreaterThanOrEqual;
		}

		public static UnifiedBooleanLiteral CreateBooleanLiteral(XElement node) {
			Contract.Requires(
					node.Name.LocalName == "true" ||
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
					return UnifiedIntegerLiteral.Create(Microsoft.Scripting.Math.BigInteger.Parse(node.Value), UnifiedIntegerLiteralKind.BigInteger);
				}
			}
			throw new NotImplementedException();
		}

		public static UnifiedFractionLiteral CreateDecimalLiteral(XElement node) {
			Contract.Requires(node.Name.LocalName == "lit");
			return UnifiedFractionLiteral.Create(double.Parse(node.Value), UnifiedFractionLiteralKind.Double);
		}

		public static UnifiedBinaryOperator CreateOperator(string sign) {
			UnifiedBinaryOperatorKind result;
			return Sign2Type.TryGetValue(sign, out result)
			       		? UnifiedBinaryOperator.Create(sign, result) : null;
		}

		public static IUnifiedExpression CreateCall(XElement node) {
			Contract.Requires(node.Name.LocalName == "call");
			var funcName = node.Elements().ElementAt(1).Value;
			if (node.Elements().ElementAt(2).Elements().Count() == 1) {
				var @operator = CreateOperator(funcName);
				if (@operator != null) {
					return
							UnifiedBinaryExpression.Create(
									CreateExpression(node.Elements().First()),
									@operator,
									CreateExpression(node.Elements().ElementAt(2).Elements().First()));
				}
			}
			return UnifiedCall.Create(UnifiedIdentifier.Create(UnifiedIdentifierKind.Unknown, funcName), UnifiedArgumentCollection.Create(
					(UnifiedArgument[])node.Elements().ElementAt(2).Elements()
					                   		.Select(
					                   				e => UnifiedArgument.Create(null, null, CreateExpression(e)))));
		}

		public static IUnifiedExpression CreateExpression(XElement node) {
			var elems = node.Elements();
			switch (node.Name.LocalName) {
			case "lit":
				return CreateLiteral(node);
			case "lvar":
				return UnifiedIdentifier.Create(UnifiedIdentifierKind.Unknown, node.Value);
			case "call":
				return CreateCall(node);
			case "if":
				return UnifiedIf.Create(CreateExpression(elems.ElementAt(0)), CreateBlock(elems.ElementAt(1)), CreateBlock(elems.ElementAt(2)));
			case "return":
				return UnifiedSpecialExpression.Create(UnifiedSpecialExpressionKind.Return, CreateExpression(elems.First()));
			default:
				throw new NotImplementedException();
			}
		}

		public static UnifiedFunctionDefinition CreateDefineFunction(XElement node) {
			Contract.Requires(node.Name.LocalName == "defn");
			var elems = node.Elements();
			return UnifiedFunctionDefinition.Create(
					UnifiedFunctionDefinitionKind.Function,
					null, UnifiedModifierCollection.Create(), null, null, UnifiedIdentifier.Create(UnifiedIdentifierKind.Function, elems.First().Value), UnifiedParameterCollection.Create(
							(UnifiedParameter[])elems.ElementAt(1).Elements()
							                    		.Select(
							                    				e => UnifiedParameter.Create(
							                    						null,
							                    						null, null,
							                    						UnifiedIdentifier.Create(UnifiedIdentifierKind.Variable, e.Value).
							                    								ToCollection(),
							                    						null))), null, CreateBlock(elems.ElementAt(2).Elements().First()));
		}

		private static UnifiedBlock CreateBlock(XElement node) {
			Contract.Requires(node.Name.LocalName == "block");
			return UnifiedBlock.Create(
					(IUnifiedExpression[])node.Elements()
					                      		.Where(e => e.Name.LocalName != "nil")
					                      		.Select(CreateExpression));
		}
	}
}