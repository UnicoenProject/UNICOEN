using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Unicoen.Core.Model;
using Mocomoco.Xml.Linq;

namespace Unicoen.Languages.Python2.ModelFactories
{
	public static class PythonModelFactoryHelper
	{
		public static IUnifiedElement CreateSingle_input(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "single_input");
			return null;
		}

		public static IUnifiedElement CreateFile_input(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "file_input");
			return null;
		}

		public static IUnifiedElement CreateEval_input(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "eval_input");
			return null;
		}

		public static IUnifiedElement CreateDecorator(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorator");
			return null;
		}

		public static IUnifiedElement CreateDecorators(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorators");
			return null;
		}

		public static IUnifiedElement CreateDecorated(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "decorated");
			return null;
		}

		public static IUnifiedElement CreateFuncdef(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "funcdef");
			return null;
		}

		public static IUnifiedElement CreateParameters(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "parameters");
			return null;
		}

		public static IUnifiedElement CreateVarargslist(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "varargslist");
			return null;
		}

		public static IUnifiedElement CreateFpdef(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fpdef");
			return null;
		}

		public static IUnifiedElement CreateFplist(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "fplist");
			return null;
		}

		public static IUnifiedElement CreateStmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "stmt");
			return null;
		}

		public static IUnifiedElement CreateSimple_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "simple_stmt");
			return null;
		}

		public static IUnifiedElement CreateSmall_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "small_stmt");
			return null;
		}

		public static IUnifiedElement CreateExpr_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expr_stmt");
			return null;
		}

		public static IUnifiedElement CreateAugassign(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "augassign");
			return null;
		}

		public static IUnifiedElement CreatePrint_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "print_stmt");
			return null;
		}

		public static IUnifiedElement CreateDel_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "del_stmt");
			return null;
		}

		public static IUnifiedElement CreatePass_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "pass_stmt");
			return null;
		}

		public static IUnifiedElement CreateFlow_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "flow_stmt");
			return null;
		}

		public static IUnifiedElement CreateBreak_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "break_stmt");
			return null;
		}

		public static IUnifiedElement CreateContinue_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "continue_stmt");
			return null;
		}

		public static IUnifiedElement CreateReturn_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "return_stmt");
			return null;
		}

		public static IUnifiedElement CreateYield_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "yield_stmt");
			return null;
		}

		public static IUnifiedElement CreateRaise_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "raise_stmt");
			return null;
		}

		public static IUnifiedElement CreateImport_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_stmt");
			return null;
		}

		public static IUnifiedElement CreateImport_name(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_name");
			return null;
		}

		public static IUnifiedElement CreateImport_from(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_from");
			return null;
		}

		public static IUnifiedElement CreateImport_as_name(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_as_name");
			return null;
		}

		public static IUnifiedElement CreateDotted_as_name(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dotted_as_name");
			return null;
		}

		public static IUnifiedElement CreateImport_as_names(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "import_as_names");
			return null;
		}

		public static IUnifiedElement CreateDotted_as_names(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dotted_as_names");
			return null;
		}

		public static IUnifiedElement CreateDotted_name(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dotted_name");
			return null;
		}

		public static IUnifiedElement CreateGlobal_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "global_stmt");
			return null;
		}

		public static IUnifiedElement CreateExec_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exec_stmt");
			return null;
		}

		public static IUnifiedElement CreateAssert_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "assert_stmt");
			return null;
		}

		public static IUnifiedElement CreateCompound_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "compound_stmt");
			return null;
		}

		public static IUnifiedElement CreateIf_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "if_stmt");
			return null;
		}

		public static IUnifiedElement CreateWhile_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "while_stmt");
			return null;
		}

		public static IUnifiedElement CreateFor_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "for_stmt");
			return null;
		}

		public static IUnifiedElement CreateTry_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "try_stmt");
			return null;
		}

		public static IUnifiedElement CreateWith_stmt(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "with_stmt");
			return null;
		}

		public static IUnifiedElement CreateWith_item(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "with_item");
			return null;
		}

		public static IUnifiedElement CreateExcept_clause(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "except_clause");
			return null;
		}

		public static IUnifiedElement CreateSuite(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "suite");
			return null;
		}

		public static IUnifiedElement CreateTestlist_safe(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist_safe");
			return null;
		}

		public static IUnifiedElement CreateOld_test(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "old_test");
			return null;
		}

		public static IUnifiedElement CreateOld_lambdef(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "old_lambdef");
			return null;
		}

		public static IUnifiedElement CreateTest(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "test");
			return null;
		}

		public static IUnifiedElement CreateOr_test(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "or_test");
			return null;
		}

		public static IUnifiedElement CreateAnd_test(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_test");
			return null;
		}

		public static IUnifiedElement CreateNot_test(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "not_test");
			return null;
		}

		public static IUnifiedElement CreateComparison(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comparison");
			return null;
		}

		public static IUnifiedElement CreateComp_op(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_op");
			return null;
		}

		public static IUnifiedElement CreateExpr(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "expr");
			return null;
		}

		public static IUnifiedElement CreateXor_expr(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "xor_expr");
			return null;
		}

		public static IUnifiedElement CreateAnd_expr(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "and_expr");
			return null;
		}

		public static IUnifiedElement CreateShift_expr(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "shift_expr");
			return null;
		}

		public static IUnifiedElement CreateArith_expr(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arith_expr");
			return null;
		}

		public static IUnifiedElement CreateTerm(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "term");
			return null;
		}

		public static IUnifiedElement CreateFactor(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "factor");
			return null;
		}

		public static IUnifiedElement CreatePower(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "power");
			return null;
		}

		public static IUnifiedElement CreateAtom(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "atom");
			return null;
		}

		public static IUnifiedElement CreateListmaker(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "listmaker");
			return null;
		}

		public static IUnifiedElement CreateTestlist_comp(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist_comp");
			return null;
		}

		public static IUnifiedElement CreateLambdef(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "lambdef");
			return null;
		}

		public static IUnifiedElement CreateTrailer(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "trailer");
			return null;
		}

		public static IUnifiedElement CreateSubscriptlist(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "subscriptlist");
			return null;
		}

		public static IUnifiedElement CreateSubscript(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "subscript");
			return null;
		}

		public static IUnifiedElement CreateSliceop(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sliceop");
			return null;
		}

		public static IUnifiedElement CreateExprlist(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "exprlist");
			return null;
		}

		public static IUnifiedElement CreateTestlist(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist");
			return null;
		}

		public static IUnifiedElement CreateDictorsetmaker(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "dictorsetmaker");
			return null;
		}

		public static IUnifiedElement CreateClassdef(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "classdef");
			return null;
		}

		public static IUnifiedElement CreateArglist(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "arglist");
			return null;
		}

		public static IUnifiedElement CreateArgument(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "argument");
			return null;
		}

		public static IUnifiedElement CreateList_iter(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_iter");
			return null;
		}

		public static IUnifiedElement CreateList_for(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_for");
			return null;
		}

		public static IUnifiedElement CreateList_if(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "list_if");
			return null;
		}

		public static IUnifiedElement CreateComp_iter(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_iter");
			return null;
		}

		public static IUnifiedElement CreateComp_for(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_for");
			return null;
		}

		public static IUnifiedElement CreateComp_if(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "comp_if");
			return null;
		}

		public static IUnifiedElement CreateTestlist1(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "testlist1");
			return null;
		}

		public static IUnifiedElement CreateEncoding_decl(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "encoding_decl");
			return null;
		}

		public static IUnifiedElement CreateYield_expr(XElement node)
		{
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "yield_expr");
			return null;
		}
	}
}
