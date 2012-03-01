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
		// labeled_statementは２つのExpressionを必要とするので、
		// それに合わせてこの関数の返り値はIEnumerable<IUnifiedExpression>になります。
		public static IEnumerable<UnifiedExpression> CreateStatement(
				XElement node) {
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
				var label = first.FirstElement();
				if (label.Name == "IDENTIFIER") {
					yield return UnifiedLabel.Create(label.Value);
					yield return CreateStatement(first.NthElement(2)).First();
				}
				yield break;
			case "compound_statement":
				yield return CreateCompoundStatement(first);
				yield break;
			case "expression_statement":
				yield return CreateExpressionStatement(first);
				yield break;
			case "selection_statement":
				yield return CreateSelectionStatement(first);
				yield break;
			case "iteration_statement":
				yield return CreateIterationStatement(first);
				yield break;
			case "jump_statement":
				yield return CreateJumpStatement(first);
				yield break;
			default:
				throw new InvalidOperationException();
			}
		}

		public static IEnumerable<UnifiedExpression> CreateLabeledStatement(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labeled_statement");
			/*
			labeled_statement
			: IDENTIFIER ':' statement
			| 'case' constant_expression ':' statement
			| 'default' ':' statement
			 */

			// ラベルに関わるオブジェクトは、それぞれが必要となる箇所で直接生成されます。
			// case文はUnifiedElementであり、CreateStatementの型をIEnumerable<UnifiedElement>にすることを防ぐため
			throw new InvalidOperationException();
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
					var stmt = statement;
					block.Add(stmt);
				}
			}
			return block;
		}

		public static IEnumerable<UnifiedExpression> CreateStatementList(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "statement_list");
			/* statement_list
			 * : statement+
			 */
			return node.Elements("statement").SelectMany(CreateStatement);
		}

		public static UnifiedExpression CreateExpressionStatement(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expression_statement");
			/*
			expression_statement
			: ';'
			| expression ';'
			*/

			var first = node.FirstElement();
			return first.Name == "expression"
						   ? CreateExpression(first).First() : null;
		}

		public static UnifiedExpression CreateSelectionStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "selection_statement");
			/*
			selection_statement
			: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
			| 'switch' '(' expression ')' statement
			*/

			// TODO switch文のstatementについて、{}がないと単一のstatementしか取得できないため対応を考える

			var first = node.FirstElement();
			if (first.Value == "if") {
				var statements = node.Elements("statement");
				var trueBlock = CreateStatement(statements.ElementAt(0));
				// statementが２つある場合はelse文がある
				if (statements.Count() == 2) {
					return
							UnifiedIf.Create(
									CreateExpression(node.NthElement(2)).First(),
									trueBlock.ToBlock(),
									CreateStatement(statements.ElementAt(1)).
											ToBlock());
				}
				return
						UnifiedIf.Create(
								CreateExpression(node.NthElement(2)).First(),
								trueBlock.ToBlock());
			}

			if (first.Value == "switch") {
				// statementの中身を解析して、この関数内で直接UnifiedCaseを生成します。
				// labeled_statementから辿って、このノードに到達するまでにlabeled_statementがなければ、
				// そのlabeled_statementはこのノードのケース文です

				var cases = UnifiedCaseCollection.Create();
				var labels = node.DescendantsAndSelf("labeled_statement").
						Where(e => e.FirstElement().Name != "IDENTIFIER").
						Where(
								e =>
								!e.AncestorsUntil(node).Any(
										e2 =>
										e2.Name == "selection_statement"
										&& e2.Value.StartsWith("switch")));

				foreach (var e in labels) {
					cases.Add(CreateCaseOrDefault(e));
				}
				return
						UnifiedSwitch.Create(
								CreateExpression(node.NthElement(2)).First(),
								cases);
			}
			throw new InvalidOperationException();
		}

		private static UnifiedCase CreateCaseOrDefault(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "labeled_statement");
			/*
			labeled_statement
			: IDENTIFIER ':' statement
			| 'case' constant_expression ':' statement
			| 'default' ':' statement
			 */

			var first = node.FirstElement();
			switch (first.Value) {
			case "case":
				return
						UnifiedCase.Create(
								CreateConstantExpression(node.NthElement(1)),
								UnifiedBlock.Create(
										CreateStatement(node.NthElement(3))));
			case "default":
				return
						UnifiedCase.CreateDefault(
								UnifiedBlock.Create(
										CreateStatement(node.NthElement(2))));
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedExpression CreateIterationStatement(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "iteration_statement");
			/*
			iteration_statement
			: 'while' '(' expression ')' statement
			| 'do' statement 'while' '(' expression ')' ';'
			| 'for' '(' expression_statement expression_statement expression? ')' statement
			 */

			var first = node.FirstElement().Value;
			var body =
					UnifiedBlock.Create(
							CreateStatement(node.FirstElement("statement")));
			switch (first) {
			case "while":
				return
						UnifiedWhile.Create(
								CreateExpression(node.NthElement(2)).First(),
								body);
			case "do":
				return
						UnifiedDoWhile.Create(
								CreateExpression(node.NthElement(4)).First(),
								body);
			case "for":
				var step = node.Element("expression") != null ?
																	  CreateExpression
																			  (
																					  node
																							  .
																							  FirstElement
																							  (
																									  "expression"))
																			  .
																			  First
																			  ()
								   : null;
				return UnifiedFor.Create(
						CreateExpressionStatement(node.NthElement(2)),
						CreateExpressionStatement(node.NthElement(3)),
						step, body);
			default:
				throw new InvalidOperationException();
			}
		}

		public static UnifiedExpression CreateJumpStatement(XElement node) {
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
								UnifiedLabelIdentifier.Create(
										node.NthElement(1).Value));
			case "continue":
				return UnifiedContinue.Create();
			case "break":
				return UnifiedBreak.Create();
			case "return":
				var expression = node.Element("expression");
				if (expression != null) {
					return
							UnifiedReturn.Create(
									CreateExpression(expression).First());
				}
				return UnifiedReturn.Create();
			default:
				throw new InvalidOperationException();
			}
		}
	}
}