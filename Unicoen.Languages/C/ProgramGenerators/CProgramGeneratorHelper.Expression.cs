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
using Paraiba.Xml.Linq;
using Unicoen.Model;
using Unicoen.ProgramGenerators;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ProgramGenerators {
	// for Expressions
	public static partial class CProgramGeneratorHelper {
		// Expressions
		public static UnifiedSet<UnifiedArgument> CreateArgumentExpressionList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "argument_expression_list");
			/*
			argument_expression_list
			:   assignment_expression (',' assignment_expression)*
			*/

			var arguments = node.Elements("assignment_expression").
					Select(CreateAssignmentExpression).
					Select(e => UnifiedArgument.Create(e));
			return UnifiedSet<UnifiedArgument>.Create(arguments);
		}

		public static UnifiedExpression CreateAdditiveExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additive_expression");
			/*
			additive_expression
			: (multiplicative_expression) ('+' multiplicative_expression | '-' multiplicative_expression)*
			*/

			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateMultiplicativeExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateMultiplicativeExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicative_expression");
			/*
			multiplicative_expression
			: (cast_expression) ('*' cast_expression | '/' cast_expression | '%' cast_expression)*
			*/

			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateCastExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateCastExpression(XElement node) {
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

		public static UnifiedExpression CreateUnaryExpression(XElement node) {
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
			var first = node.FirstElement();
			if (first.Name == "postfix_expression") {
				return
						CreatePostfixExpression(
								node.Element("postfix_expression"));
			}
			if (first.Value == "sizeof") {
				var expression = node.NthElement(1).Name == "unary_expression" ?
																					   CreateUnaryExpression
																							   (
																									   node
																											   .
																											   NthElement
																											   (
																													   1))
										 : CreateTypeName(node.NthElement(2));
				UnifiedSizeof.Create(expression);
			}
			if (first.Name == "unary_operator") {
				return UnifiedProgramGeneratorHelper.CreatePrefixUnaryExpression
						(
								node, CreateCastExpression,
								Sign2PrefixUnaryOperator);
			}
			return UnifiedProgramGeneratorHelper.CreatePrefixUnaryExpression(
					node, CreateUnaryExpression, Sign2PrefixUnaryOperator);
		}

		public static UnifiedExpression CreatePostfixExpression(XElement node) {
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

			var result =
					CreatePrimaryExpression(node.Element("primary_expression"));
			var elements = node.Elements().Skip(1); //先頭以外のすべての要素を取得
			var length = elements.Count();

			for (var i = 0; i < length; i++) {
				switch (elements.ElementAt(i++).Value) {
				case "[":
					result = UnifiedIndexer.Create(
							result,
							UnifiedSet<UnifiedArgument>.Create(
									UnifiedArgument.Create(
											CreateExpression(
													elements.ElementAt(i++)).
													ElementAt(0))));
					i++; // ']'読み飛ばし
					break;
				case "(":
					if (elements.ElementAt(i).Name == "argument_expression_list") {
						result = UnifiedCall.Create(
								result,
								CreateArgumentExpressionList(
										elements.ElementAt(i++)));
					} else {
						result = UnifiedCall.Create(
								result, UnifiedSet<UnifiedArgument>.Create());
					}
					i++; // ')'読み飛ばし
					break;
				case ".":
					result = UnifiedProperty.Create(
							".", result,
							UnifiedIdentifier.CreateVariable(
									elements.ElementAt(i++).Value));
					break;
				case "->":
					result = UnifiedProperty.Create(
							"->", result,
							UnifiedIdentifier.CreateVariable(
									elements.ElementAt(i++).Value));
					// TODO ポインタ型に展開してから処理するのか？
					break;
				case "++":
					result = UnifiedUnaryExpression.Create(
							result,
							UnifiedUnaryOperator.Create(
									"++",
									UnifiedUnaryOperatorKind.PostIncrementAssign));
					break;
				case "--":
					result = UnifiedUnaryExpression.Create(
							result,
							UnifiedUnaryOperator.Create(
									"--",
									UnifiedUnaryOperatorKind.PostDecrementAssign));
					break;
				default:
					throw new InvalidOperationException();
				}
			}

			return result;
		}

		public static UnifiedExpression CreatePrimaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary_expression");
			/*
			primary_expression
			: IDENTIFIER
			| constant
			| '(' expression ')'
			*/

			var first = node.FirstElement();
			if (first.Name == "IDENTIFIER") {
				return UnifiedVariableIdentifier.Create(first.Value);
			}
			if (first.Name == "constant") {
				return CreateConstant(first);
			}
			var second = node.NthElement(1);
			if (second.Name == "expression") {
				return CreateExpression(second).ElementAt(0);
			}
			throw new InvalidOperationException();
		}

		public static UnifiedExpression CreateConstant(XElement node) {
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
			var first = node.FirstElement().FirstElement();
			switch (first.Name()) {
			case "HEX_LITERAL":
				return CreateHexLiteral(first);
			case "OCTAL_LITERAL":
				return CreateOctalLiteral(first);
			case "DECIMAL_LITERAL":
				return CreateDecimalLiteral(first);
			case "CHARACTER_LITERAL":
				return CreateCharacterLiteral(first);
			case "STRING_LITERAL":
				return CreateStringLiteral(first);
			case "FLOATING_POINT_LITERAL":
				return CreateFloatingPointLiteral(first);
			default:
				throw new InvalidOperationException();
			}
		}

		// いろいろなところから呼ばれるが、返り値はIEnumerable<UnifiedExpression>でいいのか
		public static IEnumerable<UnifiedExpression> CreateExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression");
			/* expression
			 * : assignment_expression (',' assignment_expression)*
			 */

			return
					node.Elements("assignment_expression").Select(
							CreateAssignmentExpression);
		}

		public static UnifiedExpression CreateConstantExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "constant_expression");
			/*
			constant_expression
			: conditional_expression
			 */

			return CreateConditionalExpression(node.FirstElement());
		}

		public static UnifiedExpression CreateAssignmentExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignment_expression");
			/*
			assignment_expression
			: lvalue assignment_operator assignment_expression
			| conditional_expression
			 */
			var first = node.FirstElement();

			if (first.Name == "conditional_expression") {
				return CreateConditionalExpression(first);
			}
			if (first.Name == "lvalue") {
				return UnifiedBinaryExpression.Create(
						CreateLvalue(first),
						CreateAssignmentOperator(node.ElementAt(1)),
						CreateAssignmentExpression(node.ElementAt(2)));
			}
			throw new InvalidOperationException();
		}

		public static UnifiedExpression CreateLvalue(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lvalue");
			/*
			lvalue
			:	unary_expression
			*/

			return CreateUnaryExpression(node.ElementAt(0));
		}

		public static UnifiedExpression CreateConditionalExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditional_expression");
			/*
			conditional_expression
			: logical_or_expression ('?' expression ':' conditional_expression)?
			*/

			if (node.Elements().Count() == 1) {
				return CreateLogicalOrExpression(node.FirstElement());
			}

			return UnifiedTernaryExpression.Create(
					CreateLogicalOrExpression(node.ElementAt(0)),
					CreateExpression(node.NthElement(2)).First(),
					CreateConditionalExpression(node.NthElement(4)));
		}

		public static UnifiedExpression CreateLogicalOrExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_or_expression");
			/*
			logical_or_expression
			: logical_and_expression ('||' logical_and_expression)*
			 */

			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateLogicalAndExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateLogicalAndExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_and_expression");
			/*
			logical_and_expression
			: inclusive_or_expression ('&&' inclusive_or_expression)*
			 */

			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateInclusiveOrExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateInclusiveOrExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "inclusive_or_expression");
			/*
			inclusive_or_expression
			: exclusive_or_expression ('|' exclusive_or_expression)*
			*/

			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateExclusiveOrExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateExclusiveOrExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exclusive_or_expression");
			/*
			exclusive_or_expression
			: and_expression ('^' and_expression)*
			*/
			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateAndExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateAndExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_expression");
			/*
			and_expression
			: equality_expression ('&' equality_expression)*
			 */
			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateEqualityExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateEqualityExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equality_expression");
			/*
			equality_expression
			: relational_expression (('=='|'!=') relational_expression)*
			*/
			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateRelationalExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateRelationalExpression(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relational_expression");
			/*
			relational_expression
			: shift_expression (('<'|'>'|'<='|'>=') shift_expression)*
			*/
			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateShiftExpression, Sign2BinaryOperator);
		}

		public static UnifiedExpression CreateShiftExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shift_expression");
			/*
			shift_expression
			: additive_expression (('<<'|'>>') additive_expression)*
			*/
			return UnifiedProgramGeneratorHelper.CreateBinaryExpression(
					node, CreateAdditiveExpression, Sign2BinaryOperator);
		}
	}
}