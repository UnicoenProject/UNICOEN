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
using Mocomoco.Xml.Linq;
using Paraiba.Linq;
using Unicoen.Core.Model;

namespace Unicoen.Languages.Python2.ModelFactories {
	public static class PythonModelFactoryHelper {
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

		public static IUnifiedElement CreateEval_input(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "eval_input");
			/*
			 * eval_input: testlist NEWLINE* ENDMARKER
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDecorator(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorator");
			/*
			 * decorator: '@' dotted_name [ '(' [arglist] ')' ] NEWLINE
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDecorators(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorators");
			/*
			 * decorators: decorator+
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateDecorated(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorated");
			/*
			 * decorated: decorators (classdef | funcdef)
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateFuncdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "funcdef");
			/*
			 * funcdef: 'def' NAME parameters ':' suite
			 */
			return UnifiedFunctionDefinition.CreateFunction(
					node.NthElement(1).Value,
					CreateParameters(node.NthElement(2)),
					CreateSuite(node.LastElement())
					);
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
									return UnifiedParameter.Create(null, null, names, null);
								return UnifiedParameter.Create(
										null, null, names, CreateTest(next.NextElement()));
							});
			var ps2 = node.Elements("NAME")
					.Select(
							e =>
							UnifiedParameter.Create(
									UnifiedModifier.Create(e.PreviousElement().Value).ToCollection(),
									null, e.Value));
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
			throw new NotImplementedException(); //TODO: implement
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
			var kind = UnifiedSpecialExpressionKind.Print;
			if (second.SafeName() == ">>") {
				kind = UnifiedSpecialExpressionKind.PrintChevron;
			}
			return UnifiedSpecialExpression.Create(
					kind, node.Elements("test").Select(CreateTest).ToExpressionList());
		}

		public static IUnifiedExpression CreateDel_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "del_stmt");
			/*
			 * del_stmt: 'del' exprlist
			 */
			return UnifiedSpecialExpression.Create(
					UnifiedSpecialExpressionKind.Delete, CreateExprlist(node.NthElement(1)));
		}

		public static IUnifiedExpression CreatePass_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "pass_stmt");
			/*
			 * pass_stmt: 'pass'
			 */
			return UnifiedSpecialExpression.Create(UnifiedSpecialExpressionKind.Pass);
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
			return UnifiedSpecialExpression.Create(UnifiedSpecialExpressionKind.Break);
		}

		public static IUnifiedExpression CreateContinue_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "continue_stmt");
			/*
			 * continue_stmt: 'continue'
			 */
			return UnifiedSpecialExpression.Create(UnifiedSpecialExpressionKind.Continue);
		}

		public static IUnifiedExpression CreateReturn_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "return_stmt");
			/*
			 * return_stmt: 'return' [testlist]
			 */
			var testlist =
					node.Elements("testlist").Select(CreateTestlist).FirstOrDefault();
			return UnifiedSpecialExpression.Create(
					UnifiedSpecialExpressionKind.Return, testlist);
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
			var tests = node.Elements("test").Select(CreateTest).ToExpressionList();
			return UnifiedSpecialExpression.Create(
					UnifiedSpecialExpressionKind.Throw, tests);
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
			var dotted_name = dotted_nameNode != null
			                  		? CreateDotted_name(dotted_nameNode)
			                  		: Enumerable.Empty<UnifiedIdentifier>();
			var dotCount = node.ElementsByContent(".").Count();
			var from = Enumerable.Repeat((UnifiedIdentifier)null, dotCount)
					.Concat(dotted_name)
					.ToProperty(".");
			if (node.LastElement().Value == "*")
				yield return UnifiedImport.Create(
						from, UnifiedIdentifier.CreateUnknown("*"), null, null);
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
					UnifiedIdentifier.CreateUnknown(first.Value),
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
					.Select(e => UnifiedIdentifier.CreateUnknown(e.Value));
		}

		public static IUnifiedExpression CreateGlobal_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "global_stmt");
			/*
			 * global_stmt: 'global' NAME (',' NAME)*
			 */
			return UnifiedSpecialExpression.Create(
					UnifiedSpecialExpressionKind.Global,
					node.Elements("NAME").Select(
							e => UnifiedIdentifier.CreateVariable(e.Value))
							.ToExpressionList());
		}

		public static IUnifiedExpression CreateExec_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exec_stmt");
			/*
			 * exec_stmt: 'exec' expr ['in' test [',' test]]
			 */
			// TODO: change to dedicated class ?
			var expr = node.Element("expr");
			return UnifiedSpecialExpression.Create(
					UnifiedSpecialExpressionKind.Exec,
					Enumerable.Repeat(CreateExpr(expr), 1)
							.Concat(node.Elements("test").Select(CreateTest))
							.ToExpressionList());
		}

		public static IUnifiedExpression CreateAssert_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assert_stmt");
			/*
			 * assert_stmt: 'assert' test [',' test]
			 */
			// TODO: change to dedicated class ?
			return UnifiedSpecialExpression.Create(
					UnifiedSpecialExpressionKind.Assert,
					node.Elements("test").Select(CreateTest)
							.ToExpressionList()
					);
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
					.Select(n => Tuple.Create(CreateTest(n), CreateSuite(n.NextElement(1))));
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
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateFor_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "for_stmt");
			/*
			 * for_stmt: 'for' exprlist 'in' testlist ':' suite ['else' ':' suite]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateTry_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "try_stmt");
			/*
			 * try_stmt: ('try' ':' suite
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateWith_stmt(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "with_stmt");
			/*
			 * with_stmt: 'with' with_item (',' with_item)*  ':' suite
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateWith_item(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "with_item");
			/*
			 * with_item: test ['as' expr]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateExcept_clause(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "except_clause");
			/*
			 * except_clause: 'except' [test [('as' | ',') test]]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static UnifiedBlock CreateSuite(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "suite");
			/*
			 * suite: simple_stmt | NEWLINE INDENT stmt+ DEDENT
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateTestlist_safe(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist_safe");
			/*
			 * testlist_safe: old_test [(',' old_test)+ [',']]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateOld_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "old_test");
			/*
			 * old_test: or_test | old_lambdef
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateOld_lambdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "old_lambdef");
			/*
			 * old_lambdef: 'lambda' [varargslist] ':' old_test
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateTest(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "test");
			/*
			 * test: or_test ['if' or_test 'else' test] | lambdef
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateOr_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "or_test");
			/*
			 * or_test: and_test ('or' and_test)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAnd_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_test");
			/*
			 * and_test: not_test ('and' not_test)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateNot_test(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "not_test");
			/*
			 * not_test: 'not' not_test | comparison
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateComparison(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comparison");
			/*
			 * comparison: expr (comp_op expr)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateComp_op(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_op");
			/*
			 * comp_op: '<'|'>'|'=='|'>='|'<='|'<>'|'!='|'in'|'not' 'in'|'is'|'is' 'not'
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateExpr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expr");
			/*
			 * expr: xor_expr ('|' xor_expr)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateXor_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "xor_expr");
			/*
			 * xor_expr: and_expr ('^' and_expr)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAnd_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_expr");
			/*
			 * and_expr: shift_expr ('&' shift_expr)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateShift_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shift_expr");
			/*
			 * shift_expr: arith_expr (('<<'|'>>') arith_expr)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateArith_expr(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arith_expr");
			/*
			 * arith_expr: term (('+'|'-') term)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateTerm(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "term");
			/*
			 * term: factor (('*'|'/'|'%'|'//') factor)*
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateFactor(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "factor");
			/*
			 * factor: ('+'|'-'|'~') factor | power
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreatePower(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "power");
			/*
			 * power: atom trailer* ['**' factor]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateAtom(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "atom");
			/*
			 * atom: ('(' [yield_expr|testlist_comp] ')' |
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateListmaker(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "listmaker");
			/*
			 * listmaker: test ( list_for | (',' test)* [','] )
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateTestlist_comp(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist_comp");
			/*
			 * testlist_comp: test ( comp_for | (',' test)* [','] )
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateLambdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lambdef");
			/*
			 * lambdef: 'lambda' [varargslist] ':' test
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateTrailer(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "trailer");
			/*
			 * trailer: '(' [arglist] ')' | '[' subscriptlist ']' | '.' NAME
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSubscriptlist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "subscriptlist");
			/*
			 * subscriptlist: subscript (',' subscript)* [',']
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSubscript(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "subscript");
			/*
			 * subscript: '.' '.' '.' | test | [test] ':' [test] [sliceop]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateSliceop(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sliceop");
			/*
			 * sliceop: ':' [test]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateExprlist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exprlist");
			/*
			 * exprlist: expr (',' expr)* [',']
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateTestlist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist");
			/*
			 * testlist: test (',' test)* [',']
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateDictorsetmaker(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dictorsetmaker");
			/*
			 * dictorsetmaker: ( (test ':' test (comp_for | (',' test ':' test)* [','])) |
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedExpression CreateClassdef(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classdef");
			/*
			 * classdef: 'class' NAME ['(' [testlist] ')'] ':' suite
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateArglist(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arglist");
			/*
			 * arglist: (argument ',')* (argument [',']
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateArgument(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "argument");
			/*
			 * argument: test [comp_for] | test '=' test
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateList_iter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_iter");
			/*
			 * list_iter: list_for | list_if
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateList_for(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_for");
			/*
			 * list_for: 'for' exprlist 'in' testlist_safe [list_iter]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateList_if(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_if");
			/*
			 * list_if: 'if' old_test [list_iter]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateComp_iter(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_iter");
			/*
			 * comp_iter: comp_for | comp_if
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateComp_for(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_for");
			/*
			 * comp_for: 'for' exprlist 'in' or_test [comp_iter]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateComp_if(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_if");
			/*
			 * comp_if: 'if' old_test [comp_iter]
			 */
			throw new NotImplementedException(); //TODO: implement
		}

		public static IUnifiedElement CreateTestlist1(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist1");
			/*
			 * testlist1: test (',' test)*
			 */
			throw new NotImplementedException(); //TODO: implement
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
			throw new NotImplementedException(); //TODO: implement
		}
	}
}