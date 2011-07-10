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
using System.Diagnostics.Contracts;
using System.Linq;
using System.Xml.Linq;
using Mocomoco.Xml.Linq;
using Unicoen.Core.Model;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ModelFactories {
	// for Expressions
	public static partial class CModelFactoryHelper {
		// Expressions
		public static IUnifiedElement CreateArgumentExpressionList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "argument_expression_list");
			/*
			argument_expression_list
			:   assignment_expression (',' assignment_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateAdditiveExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additive_expression");
			/*
			additive_expression
			: (multiplicative_expression) ('+' multiplicative_expression | '-' multiplicative_expression)*
			*/
			bool first = true;
			int count = 1;
			IUnifiedExpression nodeExpression = null;
			foreach (var multiplicativeExpression in node.Elements("multiplicative_expression")) {
				if (first) {
					nodeExpression = CreateMultiplicativeExpression(multiplicativeExpression);
					first = false;
				} else {
					UnifiedBinaryOperator binaryOperator;
					switch (node.NthElement(count).Value) {
					case "+":
						binaryOperator = UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorKind.Add);
						break;
					case "-":
						binaryOperator = UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract);
						break;
					default:
						throw new InvalidOperationException();
					}
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							binaryOperator,
							CreateMultiplicativeExpression(multiplicativeExpression));
					count += 2;
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateMultiplicativeExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicative_expression");
			/*
			multiplicative_expression
			: (cast_expression) ('*' cast_expression | '/' cast_expression | '%' cast_expression)*
			*/
			bool first = true;
			int count = 1;
			IUnifiedExpression nodeExpression = null;
			foreach (var castExpression in node.Elements("cast_expression")) {
				if (first) {
					nodeExpression = CreateCastExpression(castExpression);
					first = false;
				} else {
					UnifiedBinaryOperator binaryOperator;
					switch (node.NthElement(count).Value) {
					case "*":
						binaryOperator = UnifiedBinaryOperator.Create("*", UnifiedBinaryOperatorKind.Multiply);
						break;
					case "/":
						binaryOperator = UnifiedBinaryOperator.Create("/", UnifiedBinaryOperatorKind.Divide);
						break;
					case "%":
						binaryOperator = UnifiedBinaryOperator.Create("%", UnifiedBinaryOperatorKind.Modulo);
						break;
					default:
						throw new InvalidOperationException();
					}
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							binaryOperator,
							CreateCastExpression(castExpression));
					count += 2;
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateCastExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "cast_expression");
			/*
			cast_expression
			: '(' type_name ')' cast_expression
			| unary_expression
			*/
			if (node.Element("cast_expression") != null) {
				return UnifiedCast.Create(
						CreateTypeName(node.Element("type_name")),
						CreateCastExpression(node.Element("cast_expression")));
			}
			if (node.Element("unary_expression") != null) {
				return CreateUnaryExpression(node.Element("unary_expression"));
			}
			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateUnaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "unary_expression");
			/*
			unary_expression
			: postfix_expression
			| '++' unary_expression
			| '--' unary_expression
			| unary_operator cast_expression
			| 'sizeof' unary_expression
			| 'sizeof' '(' type_name ')'
			 */
			if (node.Element("postfix_expression") != null) {
				return CreatePostfixExpression(node.Element("postfix_expression"));
			}
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreatePostfixExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "postfix_expression");
			/*
			postfix_expression
			:   primary_expression
				(   '[' expression ']'
				|   '(' ')'
				|   '(' argument_expression_list ')'
				|   '.' IDENTIFIER
				|   '->' IDENTIFIER
				|   '++'
				|   '--'
				)*
			*/

			if (node.Elements().Count() > 1) {
				throw new NotImplementedException(); //TODO: implement
			}

			return CreatePrimaryExpression(node.Element("primary_expression"));
		}

		public static IUnifiedExpression CreatePrimaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary_expression");
			/*
			primary_expression
			: IDENTIFIER
			| constant
			| '(' expression ')'
			*/
			if (node.Element("IDENTIFIER") != null) {
				return UnifiedVariableIdentifier.Create(node.Element("IDENTIFIER").Value);
			}
			if (node.Element("constant") != null) {
				return CreateConstant(node.Element("constant"));
			}
			if (node.Element("expression") != null) {
				return CreateExpression(node.Element("expression"));
			}
			throw new InvalidOperationException();
		}

		public static IUnifiedExpression CreateConstant(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "constant");
			/*
			 * constant
			 * :   hex_literal
			 * |   octal_literal
			 * |   decimal_literal
			 * |   character_literal
			 * |   string_literal
			 * |   floating_point_literal
			 * ;
			 * 
			 * hex_literal	:	HEX_LITERAL	;
			 * octal_literal :	OCTAL_LITERAL ;
			 * decimal_literal :	DECIMAL_LITERAL	;
			 * character_literal :	CHARACTER_LITERAL ;
			 * string_literal :	STRING_LITERAL	;
			 * floating_point_literal :	FLOATING_POINT_LITERAL	;
			 * */
			var firstNode = node.FirstElement().FirstElement();
			switch (firstNode.Name()) {
			case "HEX_LITERAL":
				return CreateHexLiteral(firstNode);
			case "OCTAL_LITERAL":
				return CreateOctalLiteral(firstNode);
			case "DECIMAL_LITERAL":
				return CreateDecimalLiteral(firstNode);
			case "CHARACTER_LITERAL":
				return CreateCharacterLiteral(firstNode);
			case "STRING_LITERAL":
				return CreateStringLiteral(firstNode);
			case "FLOATING_POINT_LITERAL":
				return CreateFloatingPointLiteral(firstNode);
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/* expression
			 * : assignment_expression (',' assignment_expression)*
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateConstantExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "constant_expression");
			/*
			constant_expression
			: conditional_expression
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateAssignmentExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignment_expression");
			/*
			assignment_expression
			: lvalue assignment_operator assignment_expression
			| conditional_expression
			 */
			var firstElement = node.FirstElement();
			switch (firstElement.Name()) {
			case "lvalue":
				throw new NotImplementedException(); //TODO: implement
				break;
			case "conditional_expression":
				return CreateConditionalExpression(firstElement);
			}
			throw new InvalidOperationException();
		}

		public static IUnifiedElement CreateLvalue(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lvalue");
			/*
			lvalue
			:	unary_expression
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateConditionalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditional_expression");
			/*
			conditional_expression
			: logical_or_expression ('?' expression ':' conditional_expression)?
			*/
			if (node.Element("expression") != null) {
				return UnifiedTernaryExpression.Create(
						CreateLogicalOrExpression(node.Element("logical_or_expression")),
						CreateExpression(node.Element("expression")),
						CreateConditionalExpression(node.Element("conditional_expression")));
			}

			return CreateLogicalOrExpression(node.Element("logical_or_expression"));
		}

		public static IUnifiedExpression CreateLogicalOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_or_expression");
			/*
			logical_or_expression
			: logical_and_expression ('||' logical_and_expression)*
			 */
			bool first = true;
			IUnifiedExpression nodeExpression = null;
			foreach (var andExpression in node.Elements("logical_and_expression")) {
				if (first) {
					nodeExpression = CreateLogicalAndExpression(andExpression);
					first = false;
				} else {
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							UnifiedBinaryOperator.Create("||", UnifiedBinaryOperatorKind.OrElse),
							CreateLogicalAndExpression(andExpression));
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateLogicalAndExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_and_expression");
			/*
			logical_and_expression
			: inclusive_or_expression ('&&' inclusive_or_expression)*
			 */
			bool first = true;
			IUnifiedExpression nodeExpression = null;
			foreach (var orExpression in node.Elements("inclusive_or_expression")) {
				if (first) {
					nodeExpression = CreateInclusiveOrExpression(orExpression);
					first = false;
				} else {
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							UnifiedBinaryOperator.Create("&&", UnifiedBinaryOperatorKind.AndAlso),
							CreateInclusiveOrExpression(orExpression));
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateInclusiveOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "inclusive_or_expression");
			/*
			inclusive_or_expression
			: exclusive_or_expression ('|' exclusive_or_expression)*
			*/
			bool first = true;
			IUnifiedExpression nodeExpression = null;
			foreach (var exclusiveExpression in node.Elements("exclusive_or_expression")) {
				if (first) {
					nodeExpression = CreateExclusiveOrExpression(exclusiveExpression);
					first = false;
				} else {
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							UnifiedBinaryOperator.Create("|", UnifiedBinaryOperatorKind.Or),
							CreateExclusiveOrExpression(exclusiveExpression));
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateExclusiveOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exclusive_or_expression");
			/*
			exclusive_or_expression
			: and_expression ('^' and_expression)*
			*/
			bool first = true;
			IUnifiedExpression nodeExpression = null;
			foreach (var andExpression in node.Elements("and_expression")) {
				if (first) {
					nodeExpression = CreateAndExpression(andExpression);
					first = false;
				} else {
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							UnifiedBinaryOperator.Create("^", UnifiedBinaryOperatorKind.ExclusiveOr),
							CreateAndExpression(andExpression));
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateAndExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_expression");
			/*
			and_expression
			: equality_expression ('&' equality_expression)*
			 */
			bool first = true;
			IUnifiedExpression nodeExpression = null;
			foreach (var equalityExpression in node.Elements("equality_expression")) {
				if (first) {
					nodeExpression = CreateEqualityExpression(equalityExpression);
					first = false;
				} else {
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							UnifiedBinaryOperator.Create("&", UnifiedBinaryOperatorKind.And),
							CreateEqualityExpression(equalityExpression));
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateEqualityExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equality_expression");
			/*
			equality_expression
			: relational_expression (('=='|'!=') relational_expression)*
			*/
			bool first = true;
			int count = 1;
			IUnifiedExpression nodeExpression = null;
			foreach (var relationalExpression in node.Elements("relational_expression")) {
				if (first) {
					nodeExpression = CreateRelationalExpression(relationalExpression);
					first = false;
				} else {
					UnifiedBinaryOperator binaryOperator;
					switch (node.NthElement(count).Value) {
					case "==":
						binaryOperator = UnifiedBinaryOperator.Create("==", UnifiedBinaryOperatorKind.Equal);
						break;
					case "!=":
						binaryOperator = UnifiedBinaryOperator.Create("!=", UnifiedBinaryOperatorKind.NotEqual);
						break;
					default:
						throw new InvalidOperationException();
					}
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							binaryOperator,
							CreateRelationalExpression(relationalExpression));
					count += 2;
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateRelationalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relational_expression");
			/*
			relational_expression
			: shift_expression (('<'|'>'|'<='|'>=') shift_expression)*
			*/
			bool first = true;
			int count = 1;
			IUnifiedExpression nodeExpression = null;
			foreach (var shiftExpression in node.Elements("shift_expression")) {
				if (first) {
					nodeExpression = CreateShiftExpression(shiftExpression);
					first = false;
				} else {
					UnifiedBinaryOperator binaryOperator;
					switch (node.NthElement(count).Value) {
					case "<":
						binaryOperator = UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorKind.LessThan);
						break;
					case ">":
						binaryOperator = UnifiedBinaryOperator.Create(">", UnifiedBinaryOperatorKind.GreaterThan);
						break;
					case "<=":
						binaryOperator = UnifiedBinaryOperator.Create("<=", UnifiedBinaryOperatorKind.LessThanOrEqual);
						break;
					case ">=":
						binaryOperator = UnifiedBinaryOperator.Create(">=", UnifiedBinaryOperatorKind.GreaterThanOrEqual);
						break;
					default:
						throw new InvalidOperationException();
					}
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							binaryOperator,
							CreateShiftExpression(shiftExpression));
					count += 2;
				}
			}
			return nodeExpression;
		}

		public static IUnifiedExpression CreateShiftExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shift_expression");
			/*
			shift_expression
			: additive_expression (('<<'|'>>') additive_expression)*
			*/
			bool first = true;
			int count = 1;
			IUnifiedExpression nodeExpression = null;
			foreach (var additiveExpression in node.Elements("additive_expression")) {
				if (first) {
					nodeExpression = CreateAdditiveExpression(additiveExpression);
					first = false;
				} else {
					UnifiedBinaryOperator binaryOperator;
					switch (node.NthElement(count).Value) {
					case "<<":
						binaryOperator = UnifiedBinaryOperator.Create("<<", UnifiedBinaryOperatorKind.LogicalLeftShift);
						break;
					case ">>":
						binaryOperator = UnifiedBinaryOperator.Create(">>", UnifiedBinaryOperatorKind.LogicalRightShift);
						break;
					default:
						throw new InvalidOperationException();
					}
					nodeExpression = UnifiedBinaryExpression.Create(
							nodeExpression,
							binaryOperator,
							CreateAdditiveExpression(additiveExpression));
					count += 2;
				}
			}
			return nodeExpression;
		}
	}
}