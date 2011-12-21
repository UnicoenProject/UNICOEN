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

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.C.ProgramGenerators {
	// for Statement
	public static partial class CProgramGeneratorHelper {
		public static IUnifiedElement CreateStatement(XElement node) {
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
			var first = node.FirstElement();
			switch (first.Name.LocalName) {
				case "labeled_statement":
					return CreateLabeledStatement(first);
				case "compound_statement":
					return CreateCompoundStatement(first);
				case "expression_statement":
					return CreateExpressionStatement(first);
				case "selection_statement":
					return CreateSelectionStatement(first);
				case "iteration_statement":
					return CreateIterationStatement(first);
				case "jump_statement":
					return CreateJumpStatement(first);
				default:
					throw new InvalidOperationException();
			}
		}

		// TODO どう対処するか検討する
		public static IUnifiedElement CreateLabeledStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labeled_statement");
			/*
			labeled_statement
			: IDENTIFIER ':' statement
			| 'case' constant_expression ':' statement
			| 'default' ':' statement
			 */

			var first = node.FirstElement();
			if(first.Value == "case") {
				var statement = CreateStatement(node.NthElement(3)) as IUnifiedExpression;
				if(statement != null)
					return UnifiedCase.Create(
						CreateConstantExpression(node.NthElement(1)), statement.ToBlock());
			}
			if(first.Value == "default") {
				var statement = CreateStatement(node.NthElement(2)) as IUnifiedExpression;
				if (statement != null)
					return UnifiedCase.CreateDefault(statement.ToBlock());
			}

			return UnifiedLabel.Create(first.Value); // TODO どうやって２つ要素を返すか検討する
			return CreateStatement(node.NthElement(2));
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
					// TODO この方法で大丈夫か検討する
					var stmt = statement as IUnifiedExpression;
					block.Add(stmt);
				}
			}
			return block;
		}

		public static IEnumerable<IUnifiedElement> CreateStatementList(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement_list");
			/* statement_list
			 * : statement+
			 */
			return node.Elements("statement").Select(CreateStatement);
		}

		public static IUnifiedExpression CreateExpressionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression_statement");
			/*
			expression_statement
			: ';'
			| expression ';'
			*/

			// TODO expressionの扱いについて検討する
			var first = node.FirstElement();
			return first.Name == "expression" ? CreateExpression(first).First() : null;
		}

		public static IUnifiedExpression CreateSelectionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selection_statement");
			/*
			selection_statement
			: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
			| 'switch' '(' expression ')' statement
			*/

			var first = node.FirstElement();
			if(first.Value == "if") {
				var statement = CreateStatement(node.NthElement(4)) as IUnifiedExpression;
				return UnifiedIf.Create(CreateExpression(node.NthElement(2)).First(), statement.ToBlock());
			}
			if(first.Value == "switch") {
				var cases = UnifiedCaseCollection.Create();
				// TODO どうやってcase文を取り出すか検討する
				return UnifiedSwitch.Create(CreateExpression(node.NthElement(2)).First(), cases);
			}
			throw new InvalidOperationException();
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
			// TODO statementの扱いを考えてから
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
					return UnifiedReturn.Create(CreateExpression(expression).First());
				}
				return UnifiedReturn.Create();
			default:
				throw new InvalidOperationException();
			}
		}
	}
}