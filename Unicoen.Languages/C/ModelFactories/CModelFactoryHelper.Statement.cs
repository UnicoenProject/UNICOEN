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

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ModelFactories {
	// for Statement
	public static partial class CModelFactoryHelper {
		public static IUnifiedExpression CreateStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/* statement
			 * : labeled_statement
			 * | compound_statement
			 * | expression_statement
			 * | selection_statement
			 * | iteration_statement
			 * | jump_statement
			 */
			var firstElement = node.FirstElement();
			switch (firstElement.Name.LocalName) {
			case "labeled_statement":
				return CreateLabeledStatement(firstElement);
			case "compound_statement":
				return CreateCompoundStatement(firstElement);
			case "expression_statement":
				return CreateExpressionStatement(firstElement);
			case "selection_statement":
				return CreateSelectionStatement(firstElement);
			case "iteration_statement":
				return CreateIterationStatement(firstElement);
			case "jump_statement":
				return CreateJumpStatement(firstElement);
			default:
				throw new InvalidOperationException();
			}
		}

		public static IUnifiedExpression CreateLabeledStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labeled_statement");
			/*
			labeled_statement
			: IDENTIFIER ':' statement
			| 'case' constant_expression ':' statement
			| 'default' ':' statement
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static UnifiedBlock CreateCompoundStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "compound_statement");
			/* compound_statement
			 * : '{' declaration* statement_list? '}'
			 */

			var block = UnifiedBlock.Create();
			foreach (var declaration in node.Elements("declaration")) {
				block.Add(CreateDeclaration(declaration));
			}
			var statementList = node.Element("statement_list");
			if (statementList != null) {
				foreach (var statement in CreateStatementList(statementList)) {
					block.Add(statement);
				}
			}
			return block;
		}

		public static UnifiedExpressionCollection CreateStatementList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement_list");
			/* statement_list
			 * : statement+
			 */
			var statementList = UnifiedExpressionCollection.Create();
			foreach (var statement in node.Elements("statement_list")) {
				statementList.Add(CreateStatement(statement));
			}
			return statementList;
		}

		public static IUnifiedExpression CreateExpressionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression_statement");
			/*
			expression_statement
			: ';'
			| expression ';'
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateSelectionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selection_statement");
			/*
			selection_statement
			: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
			| 'switch' '(' expression ')' statement
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateIterationStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iteration_statement");
			/*
			iteration_statement
			: 'while' '(' expression ')' statement
			| 'do' statement 'while' '(' expression ')' ';'
			| 'for' '(' expression_statement expression_statement expression? ')' statement
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateJumpStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "jump_statement");
			/* jump_statement
			 * : 'goto' IDENTIFIER ';'
			 * | 'continue' ';'
			 * | 'break' ';'
			 * | 'return' ';'
			 * | 'return' expression ';'
			 */
			var firstElement = node.FirstElement();
			switch (firstElement.Value) {
			case "goto":
				return
						UnifiedGoto.Create(
								UnifiedLabelIdentifier.Create(node.NthElement(1).Value));
			case "continue":
				return UnifiedContinue.Create();
			case "break":
				return UnifiedBreak.Create();
			case "return":
				var expression = node.Element("expression");
				if (expression != null) {
					return UnifiedReturn.Create(CreateExpression(expression));
				}
				return UnifiedReturn.Create();
			default:
				throw new InvalidOperationException();
			}
		}
	}
}