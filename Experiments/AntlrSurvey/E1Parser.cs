// $ANTLR 3.3 Nov 30, 2010 12:50:56 E1.g 2011-11-09 11:44:22

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class E1Parser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "NEWLINE", "IDENTIFIER", "CONSTANT", "LINE_COMMENT", "WS", "'+'", "'-'", "'*'", "'/'", "'^'", "'('", "')'"
	};
	public const int EOF=-1;
	public const int T__9=9;
	public const int T__10=10;
	public const int T__11=11;
	public const int T__12=12;
	public const int T__13=13;
	public const int T__14=14;
	public const int T__15=15;
	public const int NEWLINE=4;
	public const int IDENTIFIER=5;
	public const int CONSTANT=6;
	public const int LINE_COMMENT=7;
	public const int WS=8;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public E1Parser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public E1Parser(ITokenStream input, RecognizerSharedState state)
		: base(input, state)
	{
		ITreeAdaptor treeAdaptor = null;
		CreateTreeAdaptor(ref treeAdaptor);
		TreeAdaptor = treeAdaptor ?? new CommonTreeAdaptor();

		OnCreated();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void CreateTreeAdaptor(ref ITreeAdaptor adaptor);

	private ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return E1Parser.tokenNames; } }
	public override string GrammarFileName { get { return "E1.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class prog_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_prog();
	partial void Leave_prog();

	// $ANTLR start "prog"
	// E1.g:8:1: prog : (e= expression NEWLINE | NEWLINE );
	[GrammarRule("prog")]
	private E1Parser.prog_return prog()
	{
		Enter_prog();
		EnterRule("prog", 1);
		TraceIn("prog", 1);
		E1Parser.prog_return retval = new E1Parser.prog_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken NEWLINE1=null;
		IToken NEWLINE2=null;
		E1Parser.expression_return e = default(E1Parser.expression_return);

		object NEWLINE1_tree=null;
		object NEWLINE2_tree=null;

		try { DebugEnterRule(GrammarFileName, "prog");
		DebugLocation(8, 1);
		try
		{
			// E1.g:9:2: (e= expression NEWLINE | NEWLINE )
			int alt1=2;
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			int LA1_0 = input.LA(1);

			if (((LA1_0>=IDENTIFIER && LA1_0<=CONSTANT)||LA1_0==14))
			{
				alt1=1;
			}
			else if ((LA1_0==NEWLINE))
			{
				alt1=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 1, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(1); }
			switch (alt1)
			{
			case 1:
				DebugEnterAlt(1);
				// E1.g:9:4: e= expression NEWLINE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(9, 5);
				PushFollow(Follow._expression_in_prog32);
				e=expression();
				PopFollow();

				adaptor.AddChild(root_0, e.Tree);
				DebugLocation(9, 17);
				NEWLINE1=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_prog34); 
				NEWLINE1_tree = (object)adaptor.Create(NEWLINE1);
				adaptor.AddChild(root_0, NEWLINE1_tree);

				DebugLocation(10, 3);
				 Console.WriteLine((e!=null?e.value:default(int)));

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// E1.g:11:4: NEWLINE
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(11, 4);
				NEWLINE2=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_prog43); 
				NEWLINE2_tree = (object)adaptor.Create(NEWLINE2);
				adaptor.AddChild(root_0, NEWLINE2_tree);


				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("prog", 1);
			LeaveRule("prog", 1);
			Leave_prog();
		}
		DebugLocation(12, 1);
		} finally { DebugExitRule(GrammarFileName, "prog"); }
		return retval;

	}
	// $ANTLR end "prog"

	public class expression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public int value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_expression();
	partial void Leave_expression();

	// $ANTLR start "expression"
	// E1.g:13:1: expression returns [int value] : e= product ( '+' e= product | '-' e= product )* ;
	[GrammarRule("expression")]
	private E1Parser.expression_return expression()
	{
		Enter_expression();
		EnterRule("expression", 2);
		TraceIn("expression", 2);
		E1Parser.expression_return retval = new E1Parser.expression_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal3=null;
		IToken char_literal4=null;
		E1Parser.product_return e = default(E1Parser.product_return);

		object char_literal3_tree=null;
		object char_literal4_tree=null;

		try { DebugEnterRule(GrammarFileName, "expression");
		DebugLocation(13, 1);
		try
		{
			// E1.g:14:2: (e= product ( '+' e= product | '-' e= product )* )
			DebugEnterAlt(1);
			// E1.g:14:4: e= product ( '+' e= product | '-' e= product )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(14, 5);
			PushFollow(Follow._product_in_expression59);
			e=product();
			PopFollow();

			adaptor.AddChild(root_0, e.Tree);
			DebugLocation(15, 3);
			retval.value = (e!=null?e.value:default(int));
			DebugLocation(16, 2);
			// E1.g:16:2: ( '+' e= product | '-' e= product )*
			try { DebugEnterSubRule(2);
			while (true)
			{
				int alt2=3;
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if ((LA2_0==9))
				{
					alt2=1;
				}
				else if ((LA2_0==10))
				{
					alt2=2;
				}


				} finally { DebugExitDecision(2); }
				switch ( alt2 )
				{
				case 1:
					DebugEnterAlt(1);
					// E1.g:16:4: '+' e= product
					{
					DebugLocation(16, 4);
					char_literal3=(IToken)Match(input,9,Follow._9_in_expression69); 
					char_literal3_tree = (object)adaptor.Create(char_literal3);
					adaptor.AddChild(root_0, char_literal3_tree);

					DebugLocation(16, 9);
					PushFollow(Follow._product_in_expression73);
					e=product();
					PopFollow();

					adaptor.AddChild(root_0, e.Tree);
					DebugLocation(17, 3);
					retval.value += (e!=null?e.value:default(int));

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// E1.g:18:4: '-' e= product
					{
					DebugLocation(18, 4);
					char_literal4=(IToken)Match(input,10,Follow._10_in_expression83); 
					char_literal4_tree = (object)adaptor.Create(char_literal4);
					adaptor.AddChild(root_0, char_literal4_tree);

					DebugLocation(18, 9);
					PushFollow(Follow._product_in_expression87);
					e=product();
					PopFollow();

					adaptor.AddChild(root_0, e.Tree);
					DebugLocation(19, 3);
					retval.value -= (e!=null?e.value:default(int));

					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;

			} finally { DebugExitSubRule(2); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("expression", 2);
			LeaveRule("expression", 2);
			Leave_expression();
		}
		DebugLocation(21, 1);
		} finally { DebugExitRule(GrammarFileName, "expression"); }
		return retval;

	}
	// $ANTLR end "expression"

	public class product_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public int value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_product();
	partial void Leave_product();

	// $ANTLR start "product"
	// E1.g:22:1: product returns [int value] : e= power ( '*' e= power | '/' e= power )* ;
	[GrammarRule("product")]
	private E1Parser.product_return product()
	{
		Enter_product();
		EnterRule("product", 3);
		TraceIn("product", 3);
		E1Parser.product_return retval = new E1Parser.product_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal5=null;
		IToken char_literal6=null;
		E1Parser.power_return e = default(E1Parser.power_return);

		object char_literal5_tree=null;
		object char_literal6_tree=null;

		try { DebugEnterRule(GrammarFileName, "product");
		DebugLocation(22, 1);
		try
		{
			// E1.g:23:2: (e= power ( '*' e= power | '/' e= power )* )
			DebugEnterAlt(1);
			// E1.g:23:4: e= power ( '*' e= power | '/' e= power )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(23, 5);
			PushFollow(Follow._power_in_product111);
			e=power();
			PopFollow();

			adaptor.AddChild(root_0, e.Tree);
			DebugLocation(24, 3);
			retval.value = (e!=null?e.value:default(int));
			DebugLocation(25, 2);
			// E1.g:25:2: ( '*' e= power | '/' e= power )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=3;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0==11))
				{
					alt3=1;
				}
				else if ((LA3_0==12))
				{
					alt3=2;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// E1.g:25:4: '*' e= power
					{
					DebugLocation(25, 4);
					char_literal5=(IToken)Match(input,11,Follow._11_in_product122); 
					char_literal5_tree = (object)adaptor.Create(char_literal5);
					adaptor.AddChild(root_0, char_literal5_tree);

					DebugLocation(25, 9);
					PushFollow(Follow._power_in_product126);
					e=power();
					PopFollow();

					adaptor.AddChild(root_0, e.Tree);
					DebugLocation(26, 3);
					retval.value *= (e!=null?e.value:default(int));

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// E1.g:27:4: '/' e= power
					{
					DebugLocation(27, 4);
					char_literal6=(IToken)Match(input,12,Follow._12_in_product136); 
					char_literal6_tree = (object)adaptor.Create(char_literal6);
					adaptor.AddChild(root_0, char_literal6_tree);

					DebugLocation(27, 9);
					PushFollow(Follow._power_in_product140);
					e=power();
					PopFollow();

					adaptor.AddChild(root_0, e.Tree);
					DebugLocation(28, 3);
					retval.value /= (e!=null?e.value:default(int));

					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("product", 3);
			LeaveRule("product", 3);
			Leave_product();
		}
		DebugLocation(30, 1);
		} finally { DebugExitRule(GrammarFileName, "product"); }
		return retval;

	}
	// $ANTLR end "product"

	public class power_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public int value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_power();
	partial void Leave_power();

	// $ANTLR start "power"
	// E1.g:31:1: power returns [int value] : b= factor ( '^' e= power )? ;
	[GrammarRule("power")]
	private E1Parser.power_return power()
	{
		Enter_power();
		EnterRule("power", 4);
		TraceIn("power", 4);
		E1Parser.power_return retval = new E1Parser.power_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal7=null;
		E1Parser.factor_return b = default(E1Parser.factor_return);
		E1Parser.power_return e = default(E1Parser.power_return);

		object char_literal7_tree=null;

		try { DebugEnterRule(GrammarFileName, "power");
		DebugLocation(31, 1);
		try
		{
			// E1.g:32:2: (b= factor ( '^' e= power )? )
			DebugEnterAlt(1);
			// E1.g:32:4: b= factor ( '^' e= power )?
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(32, 5);
			PushFollow(Follow._factor_in_power164);
			b=factor();
			PopFollow();

			adaptor.AddChild(root_0, b.Tree);
			DebugLocation(33, 3);
			 retval.value = (b!=null?b.value:default(int));
			DebugLocation(34, 2);
			// E1.g:34:2: ( '^' e= power )?
			int alt4=2;
			try { DebugEnterSubRule(4);
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			int LA4_0 = input.LA(1);

			if ((LA4_0==13))
			{
				alt4=1;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// E1.g:34:4: '^' e= power
				{
				DebugLocation(34, 4);
				char_literal7=(IToken)Match(input,13,Follow._13_in_power174); 
				char_literal7_tree = (object)adaptor.Create(char_literal7);
				adaptor.AddChild(root_0, char_literal7_tree);

				DebugLocation(34, 9);
				PushFollow(Follow._power_in_power178);
				e=power();
				PopFollow();

				adaptor.AddChild(root_0, e.Tree);
				DebugLocation(35, 3);
				 double v = Math.Pow((b!=null?b.value:default(int)), (e!=null?e.value:default(int)));
						  retval.value = (int)v;
						

				}
				break;

			}
			} finally { DebugExitSubRule(4); }


			}

			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("power", 4);
			LeaveRule("power", 4);
			Leave_power();
		}
		DebugLocation(39, 1);
		} finally { DebugExitRule(GrammarFileName, "power"); }
		return retval;

	}
	// $ANTLR end "power"

	public class factor_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		public int value;
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_factor();
	partial void Leave_factor();

	// $ANTLR start "factor"
	// E1.g:40:1: factor returns [int value] : ( IDENTIFIER | CONSTANT | '(' expression ')' );
	[GrammarRule("factor")]
	private E1Parser.factor_return factor()
	{
		Enter_factor();
		EnterRule("factor", 5);
		TraceIn("factor", 5);
		E1Parser.factor_return retval = new E1Parser.factor_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER8=null;
		IToken CONSTANT9=null;
		IToken char_literal10=null;
		IToken char_literal12=null;
		E1Parser.expression_return expression11 = default(E1Parser.expression_return);

		object IDENTIFIER8_tree=null;
		object CONSTANT9_tree=null;
		object char_literal10_tree=null;
		object char_literal12_tree=null;

		try { DebugEnterRule(GrammarFileName, "factor");
		DebugLocation(40, 1);
		try
		{
			// E1.g:41:2: ( IDENTIFIER | CONSTANT | '(' expression ')' )
			int alt5=3;
			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
			switch (input.LA(1))
			{
			case IDENTIFIER:
				{
				alt5=1;
				}
				break;
			case CONSTANT:
				{
				alt5=2;
				}
				break;
			case 14:
				{
				alt5=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 5, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// E1.g:41:4: IDENTIFIER
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(41, 4);
				IDENTIFIER8=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_factor203); 
				IDENTIFIER8_tree = (object)adaptor.Create(IDENTIFIER8);
				adaptor.AddChild(root_0, IDENTIFIER8_tree);

				DebugLocation(42, 3);
				retval.value = 0;
						Console.WriteLine((IDENTIFIER8!=null?IDENTIFIER8.Text:null));

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// E1.g:44:4: CONSTANT
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(44, 4);
				CONSTANT9=(IToken)Match(input,CONSTANT,Follow._CONSTANT_in_factor212); 
				CONSTANT9_tree = (object)adaptor.Create(CONSTANT9);
				adaptor.AddChild(root_0, CONSTANT9_tree);

				DebugLocation(45, 3);
				retval.value = int.Parse((CONSTANT9!=null?CONSTANT9.Text:null));

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// E1.g:46:4: '(' expression ')'
				{
				root_0 = (object)adaptor.Nil();

				DebugLocation(46, 4);
				char_literal10=(IToken)Match(input,14,Follow._14_in_factor221); 
				char_literal10_tree = (object)adaptor.Create(char_literal10);
				adaptor.AddChild(root_0, char_literal10_tree);

				DebugLocation(46, 8);
				PushFollow(Follow._expression_in_factor223);
				expression11=expression();
				PopFollow();

				adaptor.AddChild(root_0, expression11.Tree);
				DebugLocation(46, 19);
				char_literal12=(IToken)Match(input,15,Follow._15_in_factor225); 
				char_literal12_tree = (object)adaptor.Create(char_literal12);
				adaptor.AddChild(root_0, char_literal12_tree);

				DebugLocation(47, 3);
				retval.value = (expression11!=null?expression11.value:default(int));

				}
				break;

			}
			retval.Stop = (IToken)input.LT(-1);

			retval.Tree = (object)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.Tree, retval.Start, retval.Stop);

		}
		catch (RecognitionException re)
		{
			ReportError(re);
			Recover(input,re);
		retval.Tree = (object)adaptor.ErrorNode(input, retval.Start, input.LT(-1), re);

		}
		finally
		{
			TraceOut("factor", 5);
			LeaveRule("factor", 5);
			Leave_factor();
		}
		DebugLocation(48, 1);
		} finally { DebugExitRule(GrammarFileName, "factor"); }
		return retval;

	}
	// $ANTLR end "factor"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _expression_in_prog32 = new BitSet(new ulong[]{0x10UL});
		public static readonly BitSet _NEWLINE_in_prog34 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NEWLINE_in_prog43 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _product_in_expression59 = new BitSet(new ulong[]{0x602UL});
		public static readonly BitSet _9_in_expression69 = new BitSet(new ulong[]{0x4060UL});
		public static readonly BitSet _product_in_expression73 = new BitSet(new ulong[]{0x602UL});
		public static readonly BitSet _10_in_expression83 = new BitSet(new ulong[]{0x4060UL});
		public static readonly BitSet _product_in_expression87 = new BitSet(new ulong[]{0x602UL});
		public static readonly BitSet _power_in_product111 = new BitSet(new ulong[]{0x1802UL});
		public static readonly BitSet _11_in_product122 = new BitSet(new ulong[]{0x4060UL});
		public static readonly BitSet _power_in_product126 = new BitSet(new ulong[]{0x1802UL});
		public static readonly BitSet _12_in_product136 = new BitSet(new ulong[]{0x4060UL});
		public static readonly BitSet _power_in_product140 = new BitSet(new ulong[]{0x1802UL});
		public static readonly BitSet _factor_in_power164 = new BitSet(new ulong[]{0x2002UL});
		public static readonly BitSet _13_in_power174 = new BitSet(new ulong[]{0x4060UL});
		public static readonly BitSet _power_in_power178 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_factor203 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _CONSTANT_in_factor212 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _14_in_factor221 = new BitSet(new ulong[]{0x4060UL});
		public static readonly BitSet _expression_in_factor223 = new BitSet(new ulong[]{0x8000UL});
		public static readonly BitSet _15_in_factor225 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}
