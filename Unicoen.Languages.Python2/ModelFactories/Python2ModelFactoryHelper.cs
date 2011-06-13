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
using Mocomoco.Linq;
using Mocomoco.Xml.Linq;
using Paraiba.Linq;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.Python2.ModelFactories {
	public static class Python2ModelFactoryHelper {
		public static Dictionary<string, UnifiedBinaryOperator> Sign2BinaryOperator;

		public static Dictionary<string, UnifiedUnaryOperator>
				Sign2PrefixUnaryOperator;

		static Python2ModelFactoryHelper() {
			Sign2BinaryOperator =
					ModelFactoryHelper.CreateBinaryOperatorDictionary();
			Sign2PrefixUnaryOperator =
					ModelFactoryHelper.CreatePrefixUnaryOperatorDictionaryForJava();
		}

		public static IUnifiedElement CreateSingle_input(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "single_input");
			/*
			 * single_input: NEWLINE | simple_stmt | compound_stmt NEWLINE
			 */
			return node.Elements("stmt")
					.SelectMany(CreateStmt)
					.ToProgram();
		}

		public static UnifiedProgram CreateFile_input(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "file_input");
			/*
			 * file_input: (NEWLINE | stmt)* ENDMARKER
			 */
			return node.Elements("stmt")
					.SelectMany(CreateStmt)
					.ToProgram();
		}

		public static UnifiedAnnotation CreateDecorator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorator");
			/*
			 * decorator: '@' dotted_name [ '(' [arglist] ')' ] NEWLINE
			 */
			var arglistNode = node.Element("arglist");
			var arglist = arglistNode != null
			              		? CreateArglist(arglistNode)
			              		: null;
			return UnifiedAnnotation.Create(
					name: CreateDotted_name(node.NthElement(1)).ToProperty("."),
					arguments: arglist
					);
		}

		public static UnifiedAnnotationCollection CreateDecorators(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorators");
			/*
			 * decorators: decorator+
			 */
			return node.Elements().Select(CreateDecorator).ToCollection();
		}

		public static IUnifiedExpression CreateDecorated(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorated");
			/*
			 * decorated: decorators (classdef | funcdef)
			 */
			var decorators = CreateDecorators(node.FirstElement());
			var second = node.NthElement(1);
			if (second.Name() == "classdef") {
				var classDef = CreateClassdef(second);
				classDef.Annotations = decorators;
				return classDef;
			} else {
				var funcDef = CreateFuncdef(second);
				funcDef.Annotations = decorators;
				return funcDef;
			}
		}

		public static UnifiedFunction CreateFuncdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "funcdef");
			/*
			 * funcdef: 'def' NAME parameters ':' suite
			 */
			return UnifiedFunction.Create(
					null, UnifiedModifierCollection.Create(), null, null,
					UnifiedIdentifier.Create(
							UnifiedIdentifierKind.Function, node.NthElement(1).Value),
					CreateParameters(node.NthElement(2)), null, CreateSuite(node.LastElement()));
		}

		public static UnifiedParameterCollection CreateParameters(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameters");
			/*
			 * parameters: '(' [varargslist] ')'
			 */
			var varargslist = node.Element("varargslist");
			return varargslist != null
			       		? CreateVarargslist(varargslist)
			       		: UnifiedParameterCollection.Create();
		}

		public static UnifiedParameterCollection CreateVarargslist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "varargslist");
			/*
			 * varargslist: ((fpdef ['=' test] ',')*
			 *               ('*' NAME [',' '**' NAME] | '**' NAME) |
			 *               fpdef ['=' test] (',' fpdef ['=' test])* [','])
			 */
			var ps = node.Elements("fpdef")
					.Select(
							e => {
								var next = e.NextElementOrDefault();
								var names = CreateFpdef(e);
								if (next == null || next.Value != "=")
									return UnifiedParameter.Create(
											null,
											null, null,
											names.Select(
													name =>
													UnifiedIdentifier.Create(UnifiedIdentifierKind.Variable, name)).
													ToCollection(), null);
								return UnifiedParameter.Create(
										null,
										null, null,
										names.Select(
												name1 =>
												UnifiedIdentifier.Create(UnifiedIdentifierKind.Variable, name1)).
												ToCollection(),
										CreateTest(next.NextElement()));
							});
			var ps2 = node.Elements("NAME")
					.Select(
							e =>
							UnifiedParameter.Create(
									null,
									UnifiedModifier.Create(e.PreviousElement().Value).
											ToCollection(), null,
									UnifiedIdentifier.Create(UnifiedIdentifierKind.Variable, e.Value).
											ToCollection(),
									null));
			return ps.Concat(ps2).ToCollection();
		}

		public static IEnumerable<string> CreateFpdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fpdef");
			/*
			 * fpdef: NAME | '(' fplist ')'
			 */
			var first = node.FirstElement();
			return first.Name() == "NAME"
			       		? Enumerable.Repeat(first.Value, 1)
			       		: CreateFplist(node.NthElement(1));
		}

		public static IEnumerable<string> CreateFplist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fplist");
			/*
			 * fplist: fpdef (',' fpdef)* [',']
			 */
			return node.Elements("fpdef")
					.SelectMany(CreateFpdef);
		}

		public static IEnumerable<IUnifiedExpression> CreateStmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "stmt");
			/*
			 * stmt: simple_stmt | compound_stmt
			 */
			var first = node.FirstElement();
			return first.Name() == "simple_stmt"
			       		? CreateSimple_stmt(first)
			       		: Enumerable.Repeat(CreateCompound_stmt(first), 1);
		}

		public static IEnumerable<IUnifiedExpression> CreateSimple_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "simple_stmt");
			/*
			 * simple_stmt: small_stmt (';' small_stmt)* [';'] NEWLINE
			 */
			return node.Elements("small_stmt")
					.SelectMany(CreateSmall_stmt);
		}

		public static IEnumerable<IUnifiedExpression> CreateSmall_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "small_stmt");
			/*
			 * small_stmt: (expr_stmt | print_stmt  | del_stmt | pass_stmt | flow_stmt |
			 *              import_stmt | global_stmt | exec_stmt | assert_stmt)
			 */
			var first = node.FirstElement();
			switch (first.Name()) {
			case "expr_stmt":
				yield return CreateExpr_stmt(first);
				break;
			case "print_stmt":
				yield return CreatePrint_stmt(first);
				break;
			case "del_stmt":
				yield return CreateDel_stmt(first);
				break;
			case "pass_stmt":
				yield return CreatePass_stmt(first);
				break;
			case "flow_stmt":
				yield return CreateFlow_stmt(first);
				break;
			case "import_stmt":
				foreach (var stmt in CreateImport_stmt(first)) {
					yield return stmt;
				}
				break;
			case "global_stmt":
				yield return CreateGlobal_stmt(first);
				break;
			case "exec_stmt":
				yield return CreateExec_stmt(first);
				break;
			case "assert_stmt":
				yield return CreateAssert_stmt(first);
				break;
			default:
				throw new IndexOutOfRangeException();
			}
		}

		public static IUnifiedExpression CreateExpr_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expr_stmt");
			/*
			 * expr_stmt: testlist (augassign (yield_expr|testlist) |
			 *								  ('=' (yield_expr|testlist))*)
			 */
			return ModelFactoryHelper.CreateBinaryExpressionForRightAssociation(
					node,
					e => CreateTestlist(e).ToSmartTupleLiteral(),
					e => e.Name() == "yield_expr"
					     		? CreateYield_expr(e)
					     		: CreateTestlist(e).ToSmartTupleLiteral(),
					Sign2BinaryOperator);
		}

		public static IUnifiedElement CreateAugassign(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "augassign");
			/*
			 * augassign: ('+=' | '-=' | '*=' | '/=' | '%=' | '&=' | '|=' | '^=' |
			 *             '<<=' | '>>=' | '**=' | '//=')
			 */
			UnifiedBinaryOperatorKind kind;
			switch (node.Value) {
				// Assignment
			case "+=":
				kind = UnifiedBinaryOperatorKind.AddAssign;
				break;
			case "-=":
				kind = UnifiedBinaryOperatorKind.SubtractAssign;
				break;
			case "*=":
				kind = UnifiedBinaryOperatorKind.MultiplyAssign;
				break;
			case "/=":
				kind = UnifiedBinaryOperatorKind.DivideAssign;
				break;
			case "%=":
				kind = UnifiedBinaryOperatorKind.ModuloAssign;
				break;
			case "&=":
				kind = UnifiedBinaryOperatorKind.AndAssign;
				break;
			case "|=":
				kind = UnifiedBinaryOperatorKind.OrAssign;
				break;
			case "^=":
				kind = UnifiedBinaryOperatorKind.ExclusiveOrAssign;
				break;
			case "<<=":
				kind = UnifiedBinaryOperatorKind.LogicalLeftShiftAssign;
				break;
			case ">>=":
				kind = UnifiedBinaryOperatorKind.ArithmeticRightShiftAssign;
				break;
			case "**=":
				kind = UnifiedBinaryOperatorKind.PowerAssign;
				break;
			case "//=":
				kind = UnifiedBinaryOperatorKind.FloorDivideAssign;
				break;
			default:
				throw new InvalidOperationException();
			}
			return UnifiedBinaryOperator.Create(node.Value, kind);
		}

		public static IUnifiedExpression CreatePrint_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "print_stmt");
			/*
			 * print_stmt: 'print' ( [ test (',' test)* [','] ] |
			 *                       '>>' test [ (',' test)+ [','] ] )
			 */
			var second = node.NthElementOrDefault(1);
			var tests = node.Elements("test")
					.Select(CreateTest)
					.ToSmartTupleLiteral();
			if (second.SafeName() == ">>") {
				return UnifiedPrintChevron.Create(tests);
			}
			return UnifiedPrint.Create(tests);
		}

		public static IUnifiedExpression CreateDel_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "del_stmt");
			/*
			 * del_stmt: 'del' exprlist
			 */
			return UnifiedDelete.Create(
					CreateExprlist(node.NthElement(1)).ToSmartTupleLiteral());
		}

		public static IUnifiedExpression CreatePass_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "pass_stmt");
			/*
			 * pass_stmt: 'pass'
			 */
			return UnifiedPass.Create();
		}

		public static IUnifiedExpression CreateFlow_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "flow_stmt");
			/*
			 * flow_stmt: break_stmt | continue_stmt | return_stmt | raise_stmt | yield_stmt
			 */
			var first = node.FirstElement();
			switch (first.Name()) {
			case "break_stmt":
				return CreateBreak_stmt(first);
			case "continue_stmt":
				return CreateContinue_stmt(first);
			case "return_stmt":
				return CreateReturn_stmt(first);
			case "raise_stmt":
				return CreateRaise_stmt(first);
			case "yield_stmt":
				return CreateYield_stmt(first);
			default:
				throw new IndexOutOfRangeException();
			}
		}

		public static IUnifiedExpression CreateBreak_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "break_stmt");
			/*
			 * break_stmt: 'break'
			 */
			return UnifiedBreak.Create();
		}

		public static IUnifiedExpression CreateContinue_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "continue_stmt");
			/*
			 * continue_stmt: 'continue'
			 */
			return UnifiedContinue.Create();
		}

		public static IUnifiedExpression CreateReturn_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "return_stmt");
			/*
			 * return_stmt: 'return' [testlist]
			 */
			var testlist = node.Elements("testlist")
					.Select(CreateTestlist)
					.FirstOrDefault();
			return UnifiedReturn.Create(testlist.ToSmartTupleLiteral());
		}

		public static IUnifiedExpression CreateYield_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "yield_stmt");
			/*
			 * yield_stmt: yield_expr
			 */
			return CreateYield_expr(node.FirstElement());
		}

		public static IUnifiedExpression CreateRaise_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "raise_stmt");
			/*
			 * raise_stmt: 'raise' [test [',' test [',' test]]]
			 */
			// TODO: change to dedicated class ?
			var tests = node.Elements("test")
					.Select(CreateTest)
					.ToList();
			if (tests.Count == 1)
				return UnifiedAssert.Create(tests[0]);
			if (tests.Count == 2)
				return UnifiedAssert.Create(tests[1]);
			return UnifiedAssert.Create(tests[2]);
		}

		public static IEnumerable<UnifiedImport> CreateImport_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_stmt");
			/*
			 * import_stmt: import_name | import_from
			 */
			var first = node.FirstElement();
			return first.Name() == "import_name"
			       		? CreateImport_name(first)
			       		: CreateImport_from(first);
		}

		public static IEnumerable<UnifiedImport> CreateImport_name(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_name");
			/*
			 * import_name: 'import' dotted_as_names
			 */
			return CreateDotted_as_names(node.NthElement(1))
					.Select(
							t => UnifiedImport.Create(null, t.Item1.ToProperty("."), t.Item2, null));
		}

		public static IEnumerable<UnifiedImport> CreateImport_from(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_from");
			/*
			 * import_from: ('from' ('.'* dotted_name | '.'+)
			 *               'import' ('*' | '(' import_as_names ')' | import_as_names))
			 */
			var dotted_nameNode = node.Element("dotted_name");
			// support to relative import
			var dotted_name = dotted_nameNode != null
			                  		? CreateDotted_name(dotted_nameNode)
			                  		: Enumerable.Empty<UnifiedIdentifier>();
			var dotCount = node.ElementsByContent(".").Count();
			var from = Enumerable.Repeat((UnifiedIdentifier)null, dotCount)
					.Concat(dotted_name)
					.ToProperty(".");
			if (node.LastElement().Value == "*")
				yield return UnifiedImport.Create(
						from, UnifiedIdentifier.Create(UnifiedIdentifierKind.Unknown, "*"), null,
						null);
			var results = CreateImport_as_names(node.Element("import_as_names"))
					.Select(t => UnifiedImport.Create(from, t.Item1, t.Item2, null));
			foreach (var result in results) {
				yield return result;
			}
		}

		public static Tuple<UnifiedIdentifier, string> CreateImport_as_name(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_as_name");
			/*
			 * import_as_name: NAME ['as' NAME]
			 */
			var first = node.FirstElement();
			var asNode = first.NextElementOrDefault();
			return Tuple.Create(
					UnifiedIdentifier.Create(UnifiedIdentifierKind.Unknown, first.Value),
					asNode != null ? asNode.NextElement().Value : null);
		}

		public static Tuple<IEnumerable<UnifiedIdentifier>, string>
				CreateDotted_as_name(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dotted_as_name");
			/*
			 * dotted_as_name: dotted_name ['as' NAME]
			 */
			var name = node.Element("NAME");
			return Tuple.Create(
					CreateDotted_name(node.FirstElement()),
					name != null ? name.Value : null);
		}

		public static IEnumerable<Tuple<UnifiedIdentifier, string>>
				CreateImport_as_names(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_as_names");
			/*
			 * import_as_names: import_as_name (',' import_as_name)* [',']
			 */
			return node.Elements().OddIndexElements()
					.Select(CreateImport_as_name);
		}

		public static IEnumerable<Tuple<IEnumerable<UnifiedIdentifier>, string>>
				CreateDotted_as_names(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dotted_as_names");
			/*
			 * dotted_as_names: dotted_as_name (',' dotted_as_name)*
			 */
			return node.Elements().OddIndexElements()
					.Select(CreateDotted_as_name);
		}

		public static IEnumerable<UnifiedIdentifier> CreateDotted_name(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dotted_name");
			/*
			 * dotted_name: NAME ('.' NAME)*
			 */
			return node.Elements().OddIndexElements()
					.Select(
							e => UnifiedIdentifier.Create(UnifiedIdentifierKind.Unknown, e.Value));
		}

		public static IUnifiedExpression CreateGlobal_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "global_stmt");
			/*
			 * global_stmt: 'global' NAME (',' NAME)*
			 */
			return node.Elements("NAME").Select(
					e => UnifiedVariableDefinition.Create(
							modifiers: UnifiedModifier.Create("global").ToCollection(),
							name: e.Value.ToVariableIdentifier())).ToVariableDefinitionList();
		}

		public static IUnifiedExpression CreateExec_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exec_stmt");
			/*
			 * exec_stmt: 'exec' expr ['in' test [',' test]]
			 */
			// TODO: change to dedicated class ?
			var expr = node.Element("expr");
			return UnifiedExec.Create(
					Enumerable.Repeat(CreateExpr(expr), 1)
							.Concat(node.Elements("test").Select(CreateTest))
							.ToSmartTupleLiteral());
		}

		public static IUnifiedExpression CreateAssert_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assert_stmt");
			/*
			 * assert_stmt: 'assert' test [',' test]
			 */

			var tests = node.Elements("test")
					.Select(CreateTest)
					.ToList();
			return tests.Count == 1
			       		? UnifiedAssert.Create(tests[0])
			       		: UnifiedAssert.Create(tests[0], tests[1]);
		}

		public static IUnifiedExpression CreateCompound_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "compound_stmt");
			/*
			 * compound_stmt: if_stmt | while_stmt | for_stmt | try_stmt | with_stmt | funcdef | classdef | decorated
			 */
			var first = node.FirstElement();
			switch (first.Name()) {
			case "if_stmt":
				return CreateIf_stmt(first);
			case "while_stmt":
				return CreateWhile_stmt(first);
			case "for_stmt":
				return CreateFor_stmt(first);
			case "try_stmt":
				return CreateTry_stmt(first);
			case "with_stmt":
				return CreateWith_stmt(first);
			case "funcdef":
				return CreateFuncdef(first);
			case "classdef":
				return CreateClassdef(first);
			case "decorated":
				return CreateDecorated(first);
			default:
				throw new IndexOutOfRangeException();
			}
		}

		public static UnifiedIf CreateIf_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "if_stmt");
			/*
			 * if_stmt: 'if' test ':' suite ('elif' test ':' suite)* ['else' ':' suite]
			 */
			var conditionAndBodies = node.Elements("test")
					.Select(
							n =>
							Tuple.Create(
									CreateTest(n),
									CreateSuite(((n)).NextElement(1))));
			var elseSuiteNode = node.LastElement();
			var elseSuite = elseSuiteNode.PreviousElement(1).Value == "else"
			                		? CreateSuite(elseSuiteNode) : null;
			return UnifiedIf.Create(conditionAndBodies, elseSuite);
		}

		public static IUnifiedExpression CreateWhile_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "while_stmt");
			/*
			 * while_stmt: 'while' test ':' suite ['else' ':' suite]
			 */
			var test = CreateTest(node.Element("test"));
			var suite = CreateSuite(node.Element("suite"));
			var elseSuite = node.HasElementByContent("else")
			                		? CreateSuite(node.LastElement())
			                		: null;
			return UnifiedWhile.Create(test, suite, elseSuite);
		}

		public static IUnifiedExpression CreateFor_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "for_stmt");
			/*
			 * for_stmt: 'for' exprlist 'in' testlist ':' suite ['else' ':' suite]
			 */
			var exprlist = CreateExprlist(node.Element("exprlist"));
			var testlist = CreateTestlist(node.Element("testlist"));
			var suite = CreateSuite(node.Element("suite"));
			var elseSuite = node.HasElementByContent("else")
			                		? CreateSuite(node.LastElement())
			                		: null;
			return UnifiedForeach.Create(
					exprlist.Select(
							e => UnifiedVariableDefinition.Create(name: (UnifiedIdentifier)e))
							.ToVariableDefinitionList(),
					testlist.ToSmartTupleLiteral(),
					suite,
					elseSuite);
		}

		public static IUnifiedExpression CreateTry_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "try_stmt");
			/*
			 * try_stmt: ('try' ':' suite
			 *		((except_clause ':' suite)+
			 *		['else' ':' suite]
			 *		['finally' ':' suite] |
			 *		'finally' ':' suite))
			 */
			var trySuite = CreateSuite(node.Element("suite"));
			var exceptClauseNodes = node.Elements("except_clause");
			var exceptClauseSuites = exceptClauseNodes
					.Select(e => CreateSuite(((e)).NextElement(1)));
			var catches = exceptClauseNodes
					.Select(CreateExcept_clause)
					.Zip(exceptClauseSuites)
					.Select(t => UnifiedCatch.Create(t.Item1.ToCollection(), t.Item2))
					.ToCollection();
			var elseSuiteNode = node.ElementByContent("else")
					.SafeNextElement(1);
			var elseSuite = elseSuiteNode != null
			                		? CreateSuite(elseSuiteNode)
			                		: null;
			var finallySuiteNode = node.ElementByContent("finally")
					.SafeNextElement(1);
			var finallySuite = finallySuiteNode != null
			                   		? CreateSuite(finallySuiteNode)
			                   		: null;
			return UnifiedTry.Create(trySuite, catches, elseSuite, finallySuite);
		}

		public static IUnifiedExpression CreateWith_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "with_stmt");
			/*
			 * with_stmt: 'with' with_item (',' with_item)*  ':' suite
			 *
			 * with file(p1) as f1, file(p2) as f2:
			 *   for line in f:
			 *     print line
			 */
			var matchers = node.Elements("with_item")
					.Select(CreateWith_item)
					.ToCollection();
			var suite = CreateSuite(node.Element("suite"));
			return UnifiedUsing.Create2(matchers, suite);
		}

		public static UnifiedMatcher CreateWith_item(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "with_item");
			/*
			 * with_item: test ['as' expr]
			 */
			var testNode = node.Element("test");
			var test = testNode != null
			           		? CreateTest(testNode)
			           		: null;
			var exprNode = node.Element("expr");
			var expr = exprNode != null
			           		? CreateExpr(exprNode)
			           		: null;
			return UnifiedMatcher.Create(null, null, test, expr);
		}

		public static UnifiedMatcher CreateExcept_clause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "except_clause");
			/*
			 * except_clause: 'except' [test [('as' | ',') test]]
			 */
			var firstTestNode = node.NthElementOrDefault(1);
			var firstTest = firstTestNode != null
			                		? CreateTest(firstTestNode)
			                		: null;
			var lastTestNode = node.NthElementOrDefault(3);
			var lastTest = lastTestNode != null
			               		? CreateTest(lastTestNode)
			               		: null;
			return UnifiedMatcher.Create(null, null, firstTest, lastTest);
		}

		public static UnifiedBlock CreateSuite(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "suite");
			/*
			 * suite: simple_stmt | NEWLINE INDENT stmt+ DEDENT
			 */
			var simpleStmtNode = node.Element("simple_stmt");
			if (simpleStmtNode != null)
				return CreateSimple_stmt(simpleStmtNode).ToBlock();
			return node.Elements("stmt")
					.SelectMany(CreateStmt)
					.ToBlock();
		}

		public static IEnumerable<IUnifiedExpression> CreateTestlist_safe(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist_safe");
			/*
			 * testlist_safe: old_test [(',' old_test)+ [',']]
			 */
			return node.Elements("old_test")
					.Select(CreateOld_test);
		}

		public static IUnifiedExpression CreateOld_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "old_test");
			/*
			 * old_test: or_test | old_lambdef
			 */
			var first = node.FirstElement();
			return first.Name() == "or_test"
			       		? CreateOr_test(first)
			       		: CreateOld_lambdef(first);
		}

		public static IUnifiedExpression CreateOld_lambdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "old_lambdef");
			/*
			 * old_lambdef: 'lambda' [varargslist] ':' old_test
			 */
			var varargslistNode = node.Element("varargslist");
			return UnifiedLambda.Create(
					null, null, null, varargslistNode != null
					            		? CreateVarargslist(varargslistNode)
					            		: null,
					CreateOld_test(node.LastElement()).ToBlock());
		}

		public static IUnifiedExpression CreateTest(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "test");
			/*
			 * test: or_test ['if' or_test 'else' test] | lambdef
			 */
			var first = node.FirstElement();
			if (first.Name() == "lambdef")
				return CreateLambdef(first);

			var last = node.LastElement();
			if (last.Name() != "test")
				return CreateOr_test(first);
			return UnifiedTernaryExpression.Create(
					CreateOr_test(node.NthElement(2)),
					CreateOr_test(first),
					CreateTest(last));
		}

		public static IUnifiedExpression CreateOr_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "or_test");
			/*
			 * or_test: and_test ('or' and_test)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateAnd_test, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateAnd_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_test");
			/*
			 * and_test: not_test ('and' not_test)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateNot_test, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateNot_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "not_test");
			/*
			 * not_test: 'not' not_test | comparison
			 */
			var first = node.FirstElement();
			if (first.Name() == "comparison")
				return CreateComparison(first);
			return ModelFactoryHelper.CreatePrefixUnaryExpression(
					node, CreateNot_test, Sign2PrefixUnaryOperator);
		}

		public static IUnifiedExpression CreateComparison(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comparison");
			/*
			 * comparison: expr (comp_op expr)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateExpr, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateExpr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expr");
			/*
			 * expr: xor_expr ('|' xor_expr)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateXor_expr, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateXor_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "xor_expr");
			/*
			 * xor_expr: and_expr ('^' and_expr)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateAnd_expr, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateAnd_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_expr");
			/*
			 * and_expr: shift_expr ('&' shift_expr)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateShift_expr, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateShift_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shift_expr");
			/*
			 * shift_expr: arith_expr (('<<'|'>>') arith_expr)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateArith_expr, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateArith_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arith_expr");
			/*
			 * arith_expr: term (('+'|'-') term)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateTerm, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateTerm(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "term");
			/*
			 * term: factor (('*'|'/'|'%'|'//') factor)*
			 */
			return ModelFactoryHelper.CreateBinaryExpression(
					node, CreateFactor, Sign2BinaryOperator);
		}

		public static IUnifiedExpression CreateFactor(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "factor");
			/*
			 * factor: ('+'|'-'|'~') factor | power
			 */
			var first = node.FirstElement();
			if (first.Name() == "power")
				return CreatePower(first);
			return ModelFactoryHelper.CreatePrefixUnaryExpression(
					node, CreateFactor, Sign2PrefixUnaryOperator);
		}

		public static IUnifiedExpression CreatePower(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "power");
			/*
			 * power: atom trailer* ['**' factor]
			 */
			var atom = CreateAtom(node.FirstElement());
			var left = node.Elements("trailer")
					.Aggregate(atom, CreateTrailer);
			var lastNode = node.LastElement();
			if (lastNode.Name() != "factor")
				return left;
			return UnifiedBinaryExpression.Create(
					left, UnifiedBinaryOperator.Create("**", UnifiedBinaryOperatorKind.Power),
					CreateFactor(lastNode));
		}

		public static IUnifiedExpression CreateAtom(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "atom");
			/*
			 * atom: ('(' [yield_expr|testlist_comp] ')' |
			 *		'[' [listmaker] ']' |
			 *		'{' [dictorsetmaker] '}' |
			 *		'`' testlist1 '`' |
			 *		NAME | NUMBER | STRING+)
			 */
			var first = node.FirstElement();
			switch (first.Name()) {
			case "NAME":
				return first.Value.ToVariableIdentifier();
			case "NUMBER":
				return Int32.Parse(first.Value).ToLiteral();
			case "STRING":
				return UnifiedStringLiteral.Create(first.Value);
			}

			var second = node.NthElement(1);
			switch (first.Value) {
			case "(":
				if (second.Name() == "yield_expr") {
					return CreateYield_expr(second);
				}
				if (second.Name() == "testlist_comp") {
					return CreateTestlist_comp(second);
				}
				return UnifiedExpressionCollection.Create().ToTupleLiteral();
			case "[":
				if (second.Name() == "listmaker") {
					return CreateListmaker(second);
				}
				return UnifiedExpressionCollection.Create().ToListLiteral();
			case "{":
				if (second.Name() == "dictorsetmaker") {
					return CreateDictorsetmaker(second);
				}
				return UnifiedDictionary.Create();
			case "`":
				return CreateTestlist1(second);
			default:
				throw new IndexOutOfRangeException();
			}
		}

		public static IUnifiedExpression CreateListmaker(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "listmaker");
			/*
			 * listmaker: test ( list_for | (',' test)* [','] )
			 */
			var list_forNode = node.Element("list_for");
			if (list_forNode == null) {
				return node.Elements("test")
						.Select(CreateTest)
						.ToListLiteral();
			}
			// create list comprehension
			return UnifiedListComprehension.Create(
					CreateTest(node.FirstElement()),
					CreateComp_for(list_forNode).ToCollection());
		}

		public static IUnifiedExpression CreateTestlist_comp(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist_comp");
			/*
			 * testlist_comp: test ( comp_for | (',' test)* [','] )
			 */
			var comp_forNode = node.Element("comp_for");
			if (comp_forNode == null) {
				return node.Elements("test")
						.Select(CreateTest)
						.ToTupleLiteral();
			}
			// create generator expression
			return UnifiedIterableComprehension.Create(
					CreateTest(node.FirstElement()),
					CreateComp_for(comp_forNode).ToCollection());
		}

		public static IUnifiedExpression CreateLambdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lambdef");
			/*
			 * lambdef: 'lambda' [varargslist] ':' test
			 */
			var varargslistNode = node.Element("varargslist");
			return UnifiedLambda.Create(
					null, null, null, varargslistNode != null
					            		? CreateVarargslist(varargslistNode)
					            		: null,
					CreateTest(node.LastElement()).ToBlock());
		}

		public static IUnifiedExpression CreateTrailer(
				IUnifiedExpression prefix, XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "trailer");
			/*
			 * trailer: '(' [arglist] ')' | '[' subscriptlist ']' | '.' NAME
			 */
			var second = node.NthElement(1);
			switch (node.FirstElement().Value) {
			case "(":
				return UnifiedCall.Create(prefix, CreateArglist(second));
			case "[":
				return UnifiedIndexer.Create(prefix, CreateSubscriptlist(second));
			case ".":
				return UnifiedProperty.Create(
						prefix,
						UnifiedIdentifier.Create(
								UnifiedIdentifierKind.Unknown, node.LastElement().Value),
						".");
			default:
				throw new IndexOutOfRangeException();
			}
		}

		public static UnifiedArgumentCollection CreateSubscriptlist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "subscriptlist");
			/*
			 * subscriptlist: subscript (',' subscript)* [',']
			 */
			return node.Elements("subscript")
					.Select(CreateSubscript)
					.Select(s => s.ToArgument())
					.ToCollection();
		}

		public static IUnifiedExpression CreateSubscript(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "subscript");
			/*
			 * subscript: '.' '.' '.' | test | [test] ':' [test] [sliceop]
			 */
			if (node.HasElementByContent("."))
				return UnifiedIdentifier.Create(UnifiedIdentifierKind.Variable, "...");
			var colon = node.ElementByContent(":");
			if (colon == null)
				return CreateTest(node.FirstElement());
			var firstTestNode = colon.PreviousElementOrDefault();
			var firstTest = firstTestNode != null
			                		? CreateTest(firstTestNode)
			                		: null;
			var secondTestNode = colon.NextElementOrDefault("test");
			var secondTest = secondTestNode != null
			                 		? CreateTest(secondTestNode)
			                 		: null;
			var lastTestNode = node.Element("sliceop");
			var lastTest = lastTestNode != null
			               		? CreateSliceop(lastTestNode)
			               		: null;
			return UnifiedSlice.Create(firstTest, secondTest, lastTest);
		}

		public static IUnifiedExpression CreateSliceop(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sliceop");
			/*
			 * sliceop: ':' [test]
			 */
			var testNode = node.Element("test");
			return testNode != null
			       		? CreateTest(testNode)
			       		: null;
		}

		public static IEnumerable<IUnifiedExpression> CreateExprlist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exprlist");
			/*
			 * exprlist: expr (',' expr)* [',']
			 */
			return node.Elements().OddIndexElements()
					.Select(CreateExpr);
		}

		public static IEnumerable<IUnifiedExpression> CreateTestlist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist");
			/*
			 * testlist: test (',' test)* [',']
			 */
			return node.Elements().OddIndexElements()
					.Select(CreateTest);
		}

		public static IUnifiedExpression CreateDictorsetmaker(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dictorsetmaker");
			/*
			 * dictorsetmaker: (
			 *					 (test ':' test (comp_for | (',' test ':' test)* [',']))
			 *				   | (test (comp_for | (',' test)* [',']))
			 *				   )
			 */
			var comp_forNode = node.Element("comp_for");
			if (node.NthElement(1).Value == ":") {
				if (comp_forNode == null) {
					return UnifiedDictionary.Create(
							node.Elements("test")
									.Select(CreateTest)
									.Split2()
									.Select(
											keyValue => UnifiedKeyValue.Create(keyValue.Item1, keyValue.Item2))
							);
				}
				// create dctionary
				return UnifiedDictionaryComprehension.Create(
						UnifiedKeyValue.Create(
								CreateTest(node.NthElement(0)),
								CreateTest(node.NthElement(2))),
						CreateComp_for(comp_forNode).ToCollection());
			}
			if (comp_forNode == null) {
				return node.Elements("test")
						.Select(CreateTest)
						.ToSetLiteral();
			}
			// create set
			return UnifiedSetComprehension.Create(
					CreateTest(node.FirstElement()),
					CreateComp_for(comp_forNode).ToCollection());
		}

		public static UnifiedClass CreateClassdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classdef");
			/*
			 * classdef: 'class' NAME ['(' [testlist] ')'] ':' suite
			 */
			var testlistNodes = node.Element("testlist");
			var testlist = testlistNodes != null
			               		? CreateTestlist(testlistNodes)
			               		  		.Select(
			               		  				e =>
			               		  				UnifiedTypeConstrain.Create(
			               		  						UnifiedType.Create(e),
			               		  						UnifiedTypeConstrainKind.ExtendsOrImplements))
			               		  		.ToCollection()
			               		: null;
			return UnifiedClass.Create(
					null, UnifiedModifierCollection.Create(),
					UnifiedIdentifier.Create(
							UnifiedIdentifierKind.Type, node.NthElement(1).Value), null, testlist,
					CreateSuite(node.LastElement()));
		}

		public static UnifiedArgumentCollection CreateArglist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arglist");
			/*
			 * arglist: (argument ',')* (argument [',']
			 *							  |'*' test (',' argument)* [',' '**' test] 
			 *							  |'**' test)
			 */
			return node.Elements()
					.Where(
							e =>
							e.Name() == "argument"
							|| e.Name() == "test")
					.Select(
							e => e.Name() == "argument"
							     		? CreateArgument(e)
							     		: UnifiedArgument.Create(
							     				UnifiedModifier.Create(
							     						e.PreviousElement().Value).
							     						ToCollection(), null, CreateTest(e)))
					.ToCollection();
		}

		public static UnifiedArgument CreateArgument(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "argument");
			/*
			 * argument: test [comp_for] | test '=' test
			 */
			var test = CreateTest(node.FirstElement());
			var second = node.NthElementOrDefault(1);
			if (second == null)
				return UnifiedArgument.Create(null, null, test);
			if (second.Value == "=")
					// TODO: test '=' test => NAME '=' test のように扱っているが大丈夫か？
				return UnifiedArgument.Create(
						null, (UnifiedIdentifier)test, CreateTest(node.LastElement()));
			return UnifiedArgument.Create(
					null, null,
					UnifiedIterableComprehension.Create(
							test,
							CreateComp_for(second).ToCollection()));
		}

		public static IEnumerable<IUnifiedExpression> CreateList_iter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_iter");
			/*
			 * list_iter: list_for | list_if
			 */
			var first = node.FirstElement();
			return first.Name() == "list_for"
			       		? CreateList_for(first)
			       		: CreateList_if(first);
		}

		public static IEnumerable<IUnifiedExpression> CreateList_for(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_for");
			/*
			 * list_for: 'for' exprlist 'in' testlist_safe [list_iter]
			 */
			yield return
					UnifiedForeach.Create(
							CreateExprlist(node.NthElement(1)).ToSmartTupleLiteral(),
							CreateTestlist_safe(node.NthElement(3)).ToSmartTupleLiteral());

			var last = node.LastElement();
			if (last.Name() != "list_iter")
				yield break;
			foreach (var result in CreateList_iter(last))
				yield return result;
		}

		public static IEnumerable<IUnifiedExpression> CreateList_if(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_if");
			/*
			 * list_if: 'if' old_test [list_iter]
			 */
			yield return UnifiedIf.Create(CreateOld_test(node.NthElement(1)));

			var last = node.LastElement();
			if (last.Name() != "list_iter")
				yield break;
			foreach (var result in CreateList_iter(last))
				yield return result;
		}

		public static IEnumerable<IUnifiedExpression> CreateComp_iter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_iter");
			/*
			 * comp_iter: comp_for | comp_if
			 */
			var first = node.FirstElement();
			if (first.Name() == "comp_for")
				return CreateComp_for(first);
			return CreateComp_if(first);
		}

		public static IEnumerable<IUnifiedExpression> CreateComp_for(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_for");
			/*
			 * comp_for: 'for' exprlist 'in' or_test [comp_iter]
			 */
			yield return
					UnifiedForeach.Create(
							CreateExprlist(node.NthElement(1)).ToSmartTupleLiteral(),
							CreateOr_test(node.NthElement(3)));

			var last = node.LastElement();
			if (last.Name() != "comp_iter")
				yield break;
			foreach (var result in CreateComp_iter(last))
				yield return result;
		}

		public static IEnumerable<IUnifiedExpression> CreateComp_if(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_if");
			/*
			 * comp_if: 'if' old_test [comp_iter]
			 */
			yield return UnifiedIf.Create(CreateOld_test(node.NthElement(1)));

			var last = node.LastElement();
			if (last.Name() != "comp_iter")
				yield break;
			foreach (var result in CreateComp_iter(last))
				yield return result;
		}

		public static IUnifiedExpression CreateTestlist1(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist1");
			/*
			 * testlist1: test (',' test)*
			 */

			var exps = node.Elements("test")
					.Select(CreateTest)
					.ToList();
			return UnifiedStringConversion.Create(
					exps.ToSmartTupleLiteral());
		}

		public static IUnifiedElement CreateEncoding_decl(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "encoding_decl");
			/*
			 * encoding_decl: NAME
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateYield_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "yield_expr");
			/*
			 * yield_expr: 'yield' [testlist]
			 */
			if (node.Elements().Count() == 1)
				return
						UnifiedYieldReturn.Create();
			return
					UnifiedYieldReturn.Create(
							CreateTestlist(node.LastElement()).ToSmartTupleLiteral());
		}
	}
}