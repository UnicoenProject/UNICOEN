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
using System.Xml.Linq;
using Mocomoco.Xml.Linq;
using Unicoen.Core.Model;

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

		public static IUnifiedElement CreateAdditiveExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "additive_expression");
			/*
			additive_expression
			: (multiplicative_expression) ('+' multiplicative_expression | '-' multiplicative_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateMultiplicativeExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "multiplicative_expression");
			/*
			multiplicative_expression
			: (cast_expression) ('*' cast_expression | '/' cast_expression | '%' cast_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateCastExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "cast_expression");
			/*
			cast_expression
			: '(' type_name ')' cast_expression
			| unary_expression
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateUnaryExpression(XElement node) {
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

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePostfixExpression(XElement node) {
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

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePrimaryExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "primary_expression");
			/*
			primary_expression
			: IDENTIFIER
			| constant
			| '(' expression ')'
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateConstant(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "constant");
			/*
			constant
			:   HEX_LITERAL
			|   OCTAL_LITERAL
			|   DECIMAL_LITERAL
			|	CHARACTER_LITERAL
			|	STRING_LITERAL
			|   FLOATING_POINT_LITERAL
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static UnifiedExpressionList CreateExpression(XElement node) {
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

		public static IUnifiedElement CreateAssignmentExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assignment_expression");
			/*
			assignment_expression
			: lvalue assignment_operator assignment_expression
			| conditional_expression
			 */

			throw new NotImplementedException(); //TODO: implement
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

		public static IUnifiedElement CreateConditionalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "conditional_expression");
			/*
			conditional_expression
			: logical_or_expression ('?' expression ':' conditional_expression)?
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogicalOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_or_expression");
			/*
			logical_or_expression
			: logical_and_expression ('||' logical_and_expression)*
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLogicalAndExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "logical_and_expression");
			/*
			logical_and_expression
			: inclusive_or_expression ('&&' inclusive_or_expression)*
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateInclusiveOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "inclusive_or_expression");
			/*
			inclusive_or_expression
			: exclusive_or_expression ('|' exclusive_or_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExclusiveOrExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exclusive_or_expression");
			/*
			exclusive_or_expression
			: and_expression ('^' and_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAndExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_expression");
			/*
			and_expression
			: equality_expression ('&' equality_expression)*
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateEqualityExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "equality_expression");
			/*
			equality_expression
			: relational_expression (('=='|'!=') relational_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateRelationalExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "relational_expression");
			/*
			relational_expression
			: shift_expression (('<'|'>'|'<='|'>=') shift_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateShiftExpression(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shift_expression");
			/*
			shift_expression
			: additive_expression (('<<'|'>>') additive_expression)*
			*/

			throw new NotImplementedException(); //TODO: implement
		}
	}
}