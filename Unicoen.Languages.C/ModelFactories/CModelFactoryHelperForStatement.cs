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
using System.Xml.Linq;
using Mocomoco.Xml.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Languages.C.ModelFactories {
	// for Statement
	public static partial class CModelFactoryHelper {
		public static IUnifiedExpression CreateStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement");
			/*
			statement
			: labeled_statement
			| compound_statement
			| expression_statement
			| selection_statement
			| iteration_statement
			| jump_statement
			 */

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLabeledStatement(XElement node) {
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

			throw new NotImplementedException(); //TODO: implement
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

		public static IUnifiedElement CreateExpressionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression_statement");
			/*
			expression_statement
			: ';'
			| expression ';'
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSelectionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selection_statement");
			/*
			selection_statement
			: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
			| 'switch' '(' expression ')' statement
			*/

			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateIterationStatement(XElement node) {
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

		public static IUnifiedElement CreateJumpStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "jump_statement");
			/*
			jump_statement
			: 'goto' IDENTIFIER ';'
			| 'continue' ';'
			| 'break' ';'
			| 'return' ';'
			| 'return' expression ';'
			 */

			throw new NotImplementedException(); //TODO: implement
		}
	}
}