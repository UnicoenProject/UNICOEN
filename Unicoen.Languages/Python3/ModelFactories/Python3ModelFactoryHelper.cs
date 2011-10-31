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
using Paraiba.Linq;
using Unicoen.Model;
using Unicoen.Processor;
using Paraiba.Linq;
using Paraiba.Xml.Linq;

// ReSharper disable InvocationIsSkipped
// ReSharper disable InconsistentNaming

namespace Unicoen.Languages.Python3.ModelFactories {
	public static class Python3ModelFactoryHelper {
		public static Dictionary<string, UnifiedBinaryOperator> Sign2BinaryOperator;

		public static Dictionary<string, UnifiedUnaryOperator>
				Sign2PrefixUnaryOperator;

		static Python3ModelFactoryHelper() {
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
			Contract.Requires(
					node.Name() == "file_input" || node.Name() == "encoding_decl");
			/*
			 * file_input: (NEWLINE | stmt)* ENDMARKER
			 */
			// TODO: エンコーディングの取得
			if (node.Name() == "encoding_decl")
				node = node.Element("file_input");
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
			return
					UnifiedAnnotation.Create(
							CreateDotted_name(node.NthElement(1)).ToProperty("."), arglist
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
			}
			var funcDef = CreateFuncdef(second);
			funcDef.Annotations = decorators;
			return funcDef;
		}

		public static UnifiedFunctionDefinition CreateFuncdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "funcdef");
			/*
             * funcdef: 'def' NAME parameters ['->' test] ':' suite
             */
			var annotationSignNode = node.Elements().First(e => e.Value == "->");
			var annotationExpression = annotationSignNode != null
			                           		? CreateTest(annotationSignNode)
			                           		: null;
			return UnifiedFunctionDefinition.Create(
					null, UnifiedModifierCollection.Create(), null, null,
					UnifiedVariableIdentifier.Create(node.NthElement(1).Value),
					CreateParameters(node.NthElement(2)),
					null,
					CreateSuite(node.LastElement()),
					annotationExpression);
		}

		public static UnifiedParameterCollection CreateParameters(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameters");
			/*
             * parameters: '(' [typedargslist] ')'
             */
			var varargslist = node.Element("typedargslist");
			return varargslist != null
			       		? CreateTypedargslist(varargslist)
			       		: UnifiedParameterCollection.Create();
		}

		public static UnifiedParameterCollection CreateTypedargslist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "typedargslist");
			/*
             * typedargslist: 
			 *		(tfpdef ['=' test] (',' tfpdef ['=' test])*
			 *			[',' ['*' [tfpdef] (',' tfpdef ['=' test])* [',' '**' tfpdef] | '**' tfpdef]]
			 *		|         '*' [tfpdef] (',' tfpdef ['=' test])* [',' '**' tfpdef] | '**' tfpdef)
             */
			return node.Elements("tfpdef")
					.Select(
							e => {
								var tfpdef = CreateTfpdef(e);
								var prev = e.PreviousElementOrDefault();
								if (prev == null || prev.Value == ",") {
									var next = e.NextElementOrDefault();
									if (next != null && next.Value == "=") {
										tfpdef.DefaultValue = CreateTest(next.NextElement());
									}
								} else {
									tfpdef.Modifiers = prev.Value == "*"
									                   		? UnifiedModifier.Create("*").ToCollection()
									                   		: UnifiedModifier.Create("**").ToCollection();
								}
								return tfpdef;
							})
					.ToCollection();
		}

		public static UnifiedParameter CreateTfpdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "tfpdef");
			/*
             * tfpdef: NAME [':' test]
             */
			var ret = UnifiedParameter.Create(
					null, null, null, UnifiedVariableIdentifier.Create(node.FirstElement().Value).ToCollection());
			if (node.Elements().Count() > 1) {
				ret.AnnotationExpression = CreateTest(node.LastElement());
			}
			return ret;
		}

		public static UnifiedParameterCollection CreateVarargslist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "varargslist");
			/*
			 * varargslist:
			 *		(vfpdef ['=' test] (',' vfpdef ['=' test])*
			 *			[',' ['*' [vfpdef] (',' vfpdef ['=' test])* [',' '**' vfpdef] | '**' vfpdef]]
			 *		|		  '*' [vfpdef] (',' vfpdef ['=' test])* [',' '**' vfpdef] | '**' vfpdef)
			 */
			return node.Elements("vfpdef")
					.Select(
							e => {
								var vfpdef = CreateVfpdef(e);
								var prev = e.PreviousElementOrDefault();
								if (prev == null || prev.Value == ",") {
									var next = e.NextElementOrDefault();
									if (next != null && next.Value == "=") {
										vfpdef.DefaultValue = CreateTest(next.NextElement());
									}
								} else {
									vfpdef.Modifiers = prev.Value == "*"
									                   		? UnifiedModifier.Create("*").ToCollection()
									                   		: UnifiedModifier.Create("**").ToCollection();
								}
								return vfpdef;
							})
					.ToCollection();
		}

        public static UnifiedParameter CreateVfpdef(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "vfpdef");
            /*
             * vfpdef: NAME
             */
        	return UnifiedVariableIdentifier.Create(node.Value).ToParameter();
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
			 * small_stmt: (expr_stmt | del_stmt | pass_stmt | flow_stmt |
			 *              import_stmt | global_stmt | nonlocal_stmt | assert_stmt)
			 */
			var first = node.FirstElement();
			switch (first.Name()) {
			case "expr_stmt":
				yield return CreateExpr_stmt(first);
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
			case "nonlocal_stmt":
				yield return CreateNonlocal_stmt(first);
				break;
			case "assert_stmt":
				yield return CreateAssert_stmt(first);
				break;
			default:
				throw new IndexOutOfRangeException();
			}
		}

		private static IUnifiedExpression CreateNonlocal_stmt(XElement first) {
			throw new NotImplementedException();
		}

		public static IUnifiedExpression CreateExpr_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expr_stmt");
			/*
			 * expr_stmt: testlist_star_expr (augassign (yield_expr|testlist) |
			 *								  ('=' (yield_expr|testlist_star_expr))*)
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

        public static IUnifiedElement CreateTestlist_star_expr(XElement node) {
            Contract.Requires(node != null);
            Contract.Requires(node.Name() == "testlist_star_expr");
            /*
             * testlist_star_expr: (test|star_expr) (',' (test|star_expr))* [',']
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
			var testlistNode = node.Element("testlist");
			return testlistNode != null
			       		? UnifiedReturn.Create(
			       				CreateTestlist(testlistNode).ToSmartTupleLiteral())
			       		: UnifiedReturn.Create();
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
			if (tests.Count == 0)
				return UnifiedThrow.Create();
			if (tests.Count == 1)
				return UnifiedThrow.Create(tests[0]);
			if (tests.Count == 2)
				return UnifiedThrow.Create(tests[0], tests[1]);
			return UnifiedThrow.Create(tests[0], tests[1], tests[2]);
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
							t => UnifiedImport.Create(t.Item1.ToProperty("."), t.Item2));
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
			var name = Enumerable.Repeat((UnifiedIdentifier)null, dotCount)
					.Concat(dotted_name)
					.ToProperty(".");
			if (node.LastElement().Value == "*") {
				yield return
						UnifiedImport.Create(UnifiedVariableIdentifier.Create("*"), null, name);
				yield break;
			}
			var results = CreateImport_as_names(node.Element("import_as_names"))
					.Select(t => UnifiedImport.Create(name.DeepCopy(), t.Item2, t.Item1));
			foreach (var result in results) {
				yield return result;
			}
		}

		public static Tuple<UnifiedVariableIdentifier, string> CreateImport_as_name(
				XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_as_name");
			/*
			 * import_as_name: NAME ['as' NAME]
			 */
			var first = node.FirstElement();
			var asNode = first.NextElementOrDefault();
			return Tuple.Create(
					UnifiedVariableIdentifier.Create(first.Value),
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

		public static IEnumerable<Tuple<UnifiedVariableIdentifier, string>>
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
							e => UnifiedVariableIdentifier.Create(e.Value));
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
					exprlist.SelectMany(e => e.DescendantsAndSelf<UnifiedIdentifier>())
							.Select(e => UnifiedVariableDefinition.Create(name: e.DeepCopy()))
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
			var exceptClauseNodes = node.Elements("except_clause").ToList();
			var exceptClauseSuites = exceptClauseNodes
					.Select(e => CreateSuite(((e)).NextElement(1)));
			var catches = exceptClauseNodes
					.Select(CreateExcept_clause)
					.Zip(exceptClauseSuites)
					.Select(
							t => UnifiedCatch.Create(
									UnifiedType.Create(t.Item1.Item1).ToCollection(),
									t.Item1.Item2,
									t.Item2))
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
			var withItems = node.Elements("with_item")
					.Select(CreateWith_item)
					.ToCollection();
			var suite = CreateSuite(node.Element("suite"));
			return UnifiedUsing.Create(withItems, suite);
		}

		public static IUnifiedExpression CreateWith_item(XElement node) {
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
			return UnifiedBinaryExpression.Create(
					expr,
					UnifiedBinaryOperator.Create("=", UnifiedBinaryOperatorKind.Assign),
					test);
		}

		public static Tuple<IUnifiedExpression, IUnifiedExpression>
				CreateExcept_clause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "except_clause");
			/*
			 * except_clause: 'except' [test [('as' | ',') test]]
			 */
			var firstTestNode = node.NthElementOrDefault(1);
			var type = firstTestNode != null
			           		? CreateTest(firstTestNode)
			           		: null;
			var lastTestNode = node.NthElementOrDefault(3);
			var assign = lastTestNode != null
			             		? CreateTest(lastTestNode)
			             		: null;
			return Tuple.Create(type, assign);
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
					null, varargslistNode != null
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

		private static bool CheckDoulbeParse(string str, double d) {
			try {
				return double.Parse(str) == d;
			} catch {
				return true;
			}
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
			var value = first.Value.ToLower();
			switch (first.Name()) {
			case "NAME":
				return value.ToVariableIdentifier();
			case "NUMBER":
				var isLong = value.EndsWith("l");
				if (isLong)
					value = value.Substring(0, value.Length - 1);
				if (value.StartsWith("0x"))
					return UnifiedIntegerLiteral.CreateBigInteger(
							LiteralFuzzyParser.ParseHexicalBigInteger(value.Substring(2)));
				if (value.StartsWith("0o"))
					return UnifiedIntegerLiteral.CreateBigInteger(
							LiteralFuzzyParser.ParseOcatleBigInteger(value.Substring(2)));
				if (value.EndsWith("j"))
					return UnifiedFractionLiteral.Create(
							double.Parse(value.Substring(0, value.Length - 1)),
							UnifiedFractionLiteralKind.Imaginary);
				if (value.Contains(".") || value.Contains("e")) {
					//TODO: より正確なパース
					double d;
					try {
						d = double.Parse(value);
					} catch (OverflowException) {
						var str = value.Split('e');
						d = !str[1].StartsWith("-")
						    		? !str[0].StartsWith("-")
						    		  		? double.PositiveInfinity
						    		  		: double.NegativeInfinity
						    		: 0.0;
					}
					return d.ToLiteral();
				}
				return UnifiedIntegerLiteral.CreateBigInteger(
						LiteralFuzzyParser.ParseBigInteger(value));
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
				return UnifiedTupleLiteral.Create();
			case "[":
				if (second.Name() == "listmaker") {
					return CreateListmaker(second);
				}
				return UnifiedListLiteral.Create();
			case "{":
				if (second.Name() == "dictorsetmaker") {
					return CreateDictorsetmaker(second);
				}
				return UnifiedMapLiteral.Create();
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
					CreateList_for(list_forNode).ToCollection());
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
					null, varargslistNode != null
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
			switch (node.FirstElement().Value) {
			case "(":
				var arglistNode = node.Element("arglist");
				return arglistNode != null
				       		? UnifiedCall.Create(prefix, CreateArglist(arglistNode))
				       		: UnifiedCall.Create(prefix, UnifiedArgumentCollection.Create());
			case "[":
				var second = node.NthElement(1);
				return UnifiedIndexer.Create(prefix, CreateSubscriptlist(second));
			case ".":
				return UnifiedProperty.Create(
						".", prefix, UnifiedVariableIdentifier.Create(node.LastElement().Value));
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
				return UnifiedVariableIdentifier.Create("...");
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
					return UnifiedMapLiteral.Create(
							node.Elements("test")
									.Select(CreateTest)
									.Split2()
									.Select(
											keyValue => UnifiedKeyValue.Create(keyValue.Item1, keyValue.Item2))
							);
				}
				// create dctionary
				return UnifiedMapComprehension.Create(
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

		public static UnifiedClassDefinition CreateClassdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classdef");
			/*
			 * classdef: 'class' NAME ['(' [testlist] ')'] ':' suite
			 */
			var testlistNodes = node.Element("testlist");
			var testlist = testlistNodes != null
			               		? CreateTestlist(testlistNodes)
			               		  		.Select(UnifiedType.Create)
			               		  		.Select(UnifiedExtendConstrain.Create)
			               		  		.ToCollection()
			               		: null;
			return UnifiedClassDefinition.Create(
					null, UnifiedModifierCollection.Create(),
					UnifiedVariableIdentifier.Create(node.NthElement(1).Value), null, testlist,
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
							     				CreateTest(e), null, UnifiedModifier.Create(
							     						e.PreviousElement().Value).
							     				                     		ToCollection()))
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
				return UnifiedArgument.Create(test, null, null);
			if (second.Value == "=")
					// TODO: test '=' test => NAME '=' test のように扱っているが大丈夫か？
				return UnifiedArgument.Create(
						CreateTest(node.LastElement()), (UnifiedIdentifier)test, null);
			return UnifiedArgument.Create(
					UnifiedIterableComprehension.Create(
							test,
							CreateComp_for(second).ToCollection()), null, null);
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