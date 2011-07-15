// $ANTLR 3.3 Nov 30, 2010 12:50:56 Aries.g 2011-07-14 18:08:43

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class AriesParser : Antlr.Runtime.Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "ASPECT", "ASPECT_BODY", "ELEMENTS", "ELEMENT", "LANGUAGE_DEPEND_BLOCK", "LANGUAGE_DECLARATION", "INTERTYPE_DECLARATION", "POINTCUT_DECLARATION", "ADVICE_DECLARATION", "TARGET_CLASS", "POINTCUT_NAME", "PARAMETERS", "PARAMETER", "PARAMETER_TYPE", "POINTCUT_DECLARATOR", "POINTCUT_TYPE", "TYPE", "IDENTIFIER_WITH_CLASS_NAME", "ADVICE_TYPE", "ADVICE_TARGET", "ADVICE_BODY", "CONTENTS", "IDENTIFIER", "POINTCUT_TYPE_ELEMENT", "ADVICE_TYPE_ELEMENT", "INTLITERAL", "STRING", "WS", "EscapeSequence", "'aspect'", "'{'", "'}'", "'}end'", "'@'", "'Java'", "'JavaScript'", "'CSharp'", "'Ruby'", "'Python'", "'C'", "':'", "'pointcut'", "';'", "'('", "')'", "'.'", "'='"
	};
	public const int EOF=-1;
	public const int T__33=33;
	public const int T__34=34;
	public const int T__35=35;
	public const int T__36=36;
	public const int T__37=37;
	public const int T__38=38;
	public const int T__39=39;
	public const int T__40=40;
	public const int T__41=41;
	public const int T__42=42;
	public const int T__43=43;
	public const int T__44=44;
	public const int T__45=45;
	public const int T__46=46;
	public const int T__47=47;
	public const int T__48=48;
	public const int T__49=49;
	public const int T__50=50;
	public const int ASPECT=4;
	public const int ASPECT_BODY=5;
	public const int ELEMENTS=6;
	public const int ELEMENT=7;
	public const int LANGUAGE_DEPEND_BLOCK=8;
	public const int LANGUAGE_DECLARATION=9;
	public const int INTERTYPE_DECLARATION=10;
	public const int POINTCUT_DECLARATION=11;
	public const int ADVICE_DECLARATION=12;
	public const int TARGET_CLASS=13;
	public const int POINTCUT_NAME=14;
	public const int PARAMETERS=15;
	public const int PARAMETER=16;
	public const int PARAMETER_TYPE=17;
	public const int POINTCUT_DECLARATOR=18;
	public const int POINTCUT_TYPE=19;
	public const int TYPE=20;
	public const int IDENTIFIER_WITH_CLASS_NAME=21;
	public const int ADVICE_TYPE=22;
	public const int ADVICE_TARGET=23;
	public const int ADVICE_BODY=24;
	public const int CONTENTS=25;
	public const int IDENTIFIER=26;
	public const int POINTCUT_TYPE_ELEMENT=27;
	public const int ADVICE_TYPE_ELEMENT=28;
	public const int INTLITERAL=29;
	public const int STRING=30;
	public const int WS=31;
	public const int EscapeSequence=32;

	// delegates
	// delegators

	#if ANTLR_DEBUG
		private static readonly bool[] decisionCanBacktrack =
			new bool[]
			{
				false, // invalid decision
				false, false, false, false, false, false
			};
	#else
		private static readonly bool[] decisionCanBacktrack = new bool[0];
	#endif
	public AriesParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public AriesParser(ITokenStream input, RecognizerSharedState state)
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

	public override string[] TokenNames { get { return AriesParser.tokenNames; } }
	public override string GrammarFileName { get { return "Aries.g"; } }


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	#region Rules
	public class aspect_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_aspect();
	partial void Leave_aspect();

	// $ANTLR start "aspect"
	// Aries.g:33:1: aspect : 'aspect' IDENTIFIER aspectBody -> ^( ASPECT IDENTIFIER aspectBody ) ;
	[GrammarRule("aspect")]
	public AriesParser.aspect_return aspect()
	{
		Enter_aspect();
		EnterRule("aspect", 1);
		TraceIn("aspect", 1);
		AriesParser.aspect_return retval = new AriesParser.aspect_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken string_literal1=null;
		IToken IDENTIFIER2=null;
		AriesParser.aspectBody_return aspectBody3 = default(AriesParser.aspectBody_return);

		object string_literal1_tree=null;
		object IDENTIFIER2_tree=null;
		RewriteRuleITokenStream stream_33=new RewriteRuleITokenStream(adaptor,"token 33");
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");
		RewriteRuleSubtreeStream stream_aspectBody=new RewriteRuleSubtreeStream(adaptor,"rule aspectBody");
		try { DebugEnterRule(GrammarFileName, "aspect");
		DebugLocation(33, 1);
		try
		{
			// Aries.g:34:2: ( 'aspect' IDENTIFIER aspectBody -> ^( ASPECT IDENTIFIER aspectBody ) )
			DebugEnterAlt(1);
			// Aries.g:34:4: 'aspect' IDENTIFIER aspectBody
			{
			DebugLocation(34, 4);
			string_literal1=(IToken)Match(input,33,Follow._33_in_aspect123);  
			stream_33.Add(string_literal1);

			DebugLocation(34, 13);
			IDENTIFIER2=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_aspect125);  
			stream_IDENTIFIER.Add(IDENTIFIER2);

			DebugLocation(34, 24);
			PushFollow(Follow._aspectBody_in_aspect127);
			aspectBody3=aspectBody();
			PopFollow();

			stream_aspectBody.Add(aspectBody3.Tree);


			{
			// AST REWRITE
			// elements: IDENTIFIER, aspectBody
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 35:3: -> ^( ASPECT IDENTIFIER aspectBody )
			{
				DebugLocation(35, 6);
				// Aries.g:35:6: ^( ASPECT IDENTIFIER aspectBody )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(35, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ASPECT, "ASPECT"), root_1);

				DebugLocation(35, 15);
				adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());
				DebugLocation(35, 26);
				adaptor.AddChild(root_1, stream_aspectBody.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("aspect", 1);
			LeaveRule("aspect", 1);
			Leave_aspect();
		}
		DebugLocation(36, 1);
		} finally { DebugExitRule(GrammarFileName, "aspect"); }
		return retval;

	}
	// $ANTLR end "aspect"

	public class aspectBody_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_aspectBody();
	partial void Leave_aspectBody();

	// $ANTLR start "aspectBody"
	// Aries.g:38:1: aspectBody : '{' elements '}' -> ^( ASPECT_BODY elements ) ;
	[GrammarRule("aspectBody")]
	private AriesParser.aspectBody_return aspectBody()
	{
		Enter_aspectBody();
		EnterRule("aspectBody", 2);
		TraceIn("aspectBody", 2);
		AriesParser.aspectBody_return retval = new AriesParser.aspectBody_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal4=null;
		IToken char_literal6=null;
		AriesParser.elements_return elements5 = default(AriesParser.elements_return);

		object char_literal4_tree=null;
		object char_literal6_tree=null;
		RewriteRuleITokenStream stream_35=new RewriteRuleITokenStream(adaptor,"token 35");
		RewriteRuleITokenStream stream_34=new RewriteRuleITokenStream(adaptor,"token 34");
		RewriteRuleSubtreeStream stream_elements=new RewriteRuleSubtreeStream(adaptor,"rule elements");
		try { DebugEnterRule(GrammarFileName, "aspectBody");
		DebugLocation(38, 1);
		try
		{
			// Aries.g:39:2: ( '{' elements '}' -> ^( ASPECT_BODY elements ) )
			DebugEnterAlt(1);
			// Aries.g:39:4: '{' elements '}'
			{
			DebugLocation(39, 4);
			char_literal4=(IToken)Match(input,34,Follow._34_in_aspectBody150);  
			stream_34.Add(char_literal4);

			DebugLocation(39, 8);
			PushFollow(Follow._elements_in_aspectBody152);
			elements5=elements();
			PopFollow();

			stream_elements.Add(elements5.Tree);
			DebugLocation(39, 17);
			char_literal6=(IToken)Match(input,35,Follow._35_in_aspectBody154);  
			stream_35.Add(char_literal6);



			{
			// AST REWRITE
			// elements: elements
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 40:3: -> ^( ASPECT_BODY elements )
			{
				DebugLocation(40, 6);
				// Aries.g:40:6: ^( ASPECT_BODY elements )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(40, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ASPECT_BODY, "ASPECT_BODY"), root_1);

				DebugLocation(40, 20);
				adaptor.AddChild(root_1, stream_elements.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("aspectBody", 2);
			LeaveRule("aspectBody", 2);
			Leave_aspectBody();
		}
		DebugLocation(41, 1);
		} finally { DebugExitRule(GrammarFileName, "aspectBody"); }
		return retval;

	}
	// $ANTLR end "aspectBody"

	public class elements_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_elements();
	partial void Leave_elements();

	// $ANTLR start "elements"
	// Aries.g:43:1: elements : ( element )* -> ^( ELEMENTS ( element )* ) ;
	[GrammarRule("elements")]
	private AriesParser.elements_return elements()
	{
		Enter_elements();
		EnterRule("elements", 3);
		TraceIn("elements", 3);
		AriesParser.elements_return retval = new AriesParser.elements_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		AriesParser.element_return element7 = default(AriesParser.element_return);

		RewriteRuleSubtreeStream stream_element=new RewriteRuleSubtreeStream(adaptor,"rule element");
		try { DebugEnterRule(GrammarFileName, "elements");
		DebugLocation(43, 1);
		try
		{
			// Aries.g:44:2: ( ( element )* -> ^( ELEMENTS ( element )* ) )
			DebugEnterAlt(1);
			// Aries.g:44:4: ( element )*
			{
			DebugLocation(44, 4);
			// Aries.g:44:4: ( element )*
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0==IDENTIFIER||LA1_0==ADVICE_TYPE_ELEMENT||LA1_0==45))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch ( alt1 )
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:44:4: element
					{
					DebugLocation(44, 4);
					PushFollow(Follow._element_in_elements175);
					element7=element();
					PopFollow();

					stream_element.Add(element7.Tree);

					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;

			} finally { DebugExitSubRule(1); }



			{
			// AST REWRITE
			// elements: element
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 45:3: -> ^( ELEMENTS ( element )* )
			{
				DebugLocation(45, 6);
				// Aries.g:45:6: ^( ELEMENTS ( element )* )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(45, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ELEMENTS, "ELEMENTS"), root_1);

				DebugLocation(45, 17);
				// Aries.g:45:17: ( element )*
				while ( stream_element.HasNext )
				{
					DebugLocation(45, 17);
					adaptor.AddChild(root_1, stream_element.NextTree());

				}
				stream_element.Reset();

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("elements", 3);
			LeaveRule("elements", 3);
			Leave_elements();
		}
		DebugLocation(46, 1);
		} finally { DebugExitRule(GrammarFileName, "elements"); }
		return retval;

	}
	// $ANTLR end "elements"

	public class element_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_element();
	partial void Leave_element();

	// $ANTLR start "element"
	// Aries.g:48:1: element : ( intertypeDeclaration -> ^( ELEMENT intertypeDeclaration ) | pointcutDeclaration -> ^( ELEMENT pointcutDeclaration ) | adviceDeclaration -> ^( ELEMENT adviceDeclaration ) );
	[GrammarRule("element")]
	private AriesParser.element_return element()
	{
		Enter_element();
		EnterRule("element", 4);
		TraceIn("element", 4);
		AriesParser.element_return retval = new AriesParser.element_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		AriesParser.intertypeDeclaration_return intertypeDeclaration8 = default(AriesParser.intertypeDeclaration_return);
		AriesParser.pointcutDeclaration_return pointcutDeclaration9 = default(AriesParser.pointcutDeclaration_return);
		AriesParser.adviceDeclaration_return adviceDeclaration10 = default(AriesParser.adviceDeclaration_return);

		RewriteRuleSubtreeStream stream_adviceDeclaration=new RewriteRuleSubtreeStream(adaptor,"rule adviceDeclaration");
		RewriteRuleSubtreeStream stream_intertypeDeclaration=new RewriteRuleSubtreeStream(adaptor,"rule intertypeDeclaration");
		RewriteRuleSubtreeStream stream_pointcutDeclaration=new RewriteRuleSubtreeStream(adaptor,"rule pointcutDeclaration");
		try { DebugEnterRule(GrammarFileName, "element");
		DebugLocation(48, 1);
		try
		{
			// Aries.g:49:2: ( intertypeDeclaration -> ^( ELEMENT intertypeDeclaration ) | pointcutDeclaration -> ^( ELEMENT pointcutDeclaration ) | adviceDeclaration -> ^( ELEMENT adviceDeclaration ) )
			int alt2=3;
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			switch (input.LA(1))
			{
			case IDENTIFIER:
				{
				alt2=1;
				}
				break;
			case 45:
				{
				alt2=2;
				}
				break;
			case ADVICE_TYPE_ELEMENT:
				{
				alt2=3;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// Aries.g:49:4: intertypeDeclaration
				{
				DebugLocation(49, 4);
				PushFollow(Follow._intertypeDeclaration_in_element198);
				intertypeDeclaration8=intertypeDeclaration();
				PopFollow();

				stream_intertypeDeclaration.Add(intertypeDeclaration8.Tree);


				{
				// AST REWRITE
				// elements: intertypeDeclaration
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (object)adaptor.Nil();
				// 50:3: -> ^( ELEMENT intertypeDeclaration )
				{
					DebugLocation(50, 6);
					// Aries.g:50:6: ^( ELEMENT intertypeDeclaration )
					{
					object root_1 = (object)adaptor.Nil();
					DebugLocation(50, 8);
					root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ELEMENT, "ELEMENT"), root_1);

					DebugLocation(50, 16);
					adaptor.AddChild(root_1, stream_intertypeDeclaration.NextTree());

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// Aries.g:51:4: pointcutDeclaration
				{
				DebugLocation(51, 4);
				PushFollow(Follow._pointcutDeclaration_in_element213);
				pointcutDeclaration9=pointcutDeclaration();
				PopFollow();

				stream_pointcutDeclaration.Add(pointcutDeclaration9.Tree);


				{
				// AST REWRITE
				// elements: pointcutDeclaration
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (object)adaptor.Nil();
				// 52:3: -> ^( ELEMENT pointcutDeclaration )
				{
					DebugLocation(52, 6);
					// Aries.g:52:6: ^( ELEMENT pointcutDeclaration )
					{
					object root_1 = (object)adaptor.Nil();
					DebugLocation(52, 8);
					root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ELEMENT, "ELEMENT"), root_1);

					DebugLocation(52, 16);
					adaptor.AddChild(root_1, stream_pointcutDeclaration.NextTree());

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// Aries.g:53:4: adviceDeclaration
				{
				DebugLocation(53, 4);
				PushFollow(Follow._adviceDeclaration_in_element228);
				adviceDeclaration10=adviceDeclaration();
				PopFollow();

				stream_adviceDeclaration.Add(adviceDeclaration10.Tree);


				{
				// AST REWRITE
				// elements: adviceDeclaration
				// token labels: 
				// rule labels: retval
				// token list labels: 
				// rule list labels: 
				// wildcard labels: 
				retval.Tree = root_0;
				RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

				root_0 = (object)adaptor.Nil();
				// 54:3: -> ^( ELEMENT adviceDeclaration )
				{
					DebugLocation(54, 6);
					// Aries.g:54:6: ^( ELEMENT adviceDeclaration )
					{
					object root_1 = (object)adaptor.Nil();
					DebugLocation(54, 8);
					root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ELEMENT, "ELEMENT"), root_1);

					DebugLocation(54, 16);
					adaptor.AddChild(root_1, stream_adviceDeclaration.NextTree());

					adaptor.AddChild(root_0, root_1);
					}

				}

				retval.Tree = root_0;
				}

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
			TraceOut("element", 4);
			LeaveRule("element", 4);
			Leave_element();
		}
		DebugLocation(55, 1);
		} finally { DebugExitRule(GrammarFileName, "element"); }
		return retval;

	}
	// $ANTLR end "element"

	public class languageDependBlock_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_languageDependBlock();
	partial void Leave_languageDependBlock();

	// $ANTLR start "languageDependBlock"
	// Aries.g:57:1: languageDependBlock : languageDeclaration '{' contents '}end' -> ^( LANGUAGE_DEPEND_BLOCK languageDeclaration contents ) ;
	[GrammarRule("languageDependBlock")]
	private AriesParser.languageDependBlock_return languageDependBlock()
	{
		Enter_languageDependBlock();
		EnterRule("languageDependBlock", 5);
		TraceIn("languageDependBlock", 5);
		AriesParser.languageDependBlock_return retval = new AriesParser.languageDependBlock_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal12=null;
		IToken string_literal14=null;
		AriesParser.languageDeclaration_return languageDeclaration11 = default(AriesParser.languageDeclaration_return);
		AriesParser.contents_return contents13 = default(AriesParser.contents_return);

		object char_literal12_tree=null;
		object string_literal14_tree=null;
		RewriteRuleITokenStream stream_36=new RewriteRuleITokenStream(adaptor,"token 36");
		RewriteRuleITokenStream stream_34=new RewriteRuleITokenStream(adaptor,"token 34");
		RewriteRuleSubtreeStream stream_contents=new RewriteRuleSubtreeStream(adaptor,"rule contents");
		RewriteRuleSubtreeStream stream_languageDeclaration=new RewriteRuleSubtreeStream(adaptor,"rule languageDeclaration");
		try { DebugEnterRule(GrammarFileName, "languageDependBlock");
		DebugLocation(57, 1);
		try
		{
			// Aries.g:58:2: ( languageDeclaration '{' contents '}end' -> ^( LANGUAGE_DEPEND_BLOCK languageDeclaration contents ) )
			DebugEnterAlt(1);
			// Aries.g:58:4: languageDeclaration '{' contents '}end'
			{
			DebugLocation(58, 4);
			PushFollow(Follow._languageDeclaration_in_languageDependBlock249);
			languageDeclaration11=languageDeclaration();
			PopFollow();

			stream_languageDeclaration.Add(languageDeclaration11.Tree);
			DebugLocation(58, 24);
			char_literal12=(IToken)Match(input,34,Follow._34_in_languageDependBlock251);  
			stream_34.Add(char_literal12);

			DebugLocation(58, 28);
			PushFollow(Follow._contents_in_languageDependBlock253);
			contents13=contents();
			PopFollow();

			stream_contents.Add(contents13.Tree);
			DebugLocation(58, 37);
			string_literal14=(IToken)Match(input,36,Follow._36_in_languageDependBlock255);  
			stream_36.Add(string_literal14);



			{
			// AST REWRITE
			// elements: contents, languageDeclaration
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 59:3: -> ^( LANGUAGE_DEPEND_BLOCK languageDeclaration contents )
			{
				DebugLocation(59, 6);
				// Aries.g:59:6: ^( LANGUAGE_DEPEND_BLOCK languageDeclaration contents )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(59, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(LANGUAGE_DEPEND_BLOCK, "LANGUAGE_DEPEND_BLOCK"), root_1);

				DebugLocation(59, 30);
				adaptor.AddChild(root_1, stream_languageDeclaration.NextTree());
				DebugLocation(59, 50);
				adaptor.AddChild(root_1, stream_contents.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("languageDependBlock", 5);
			LeaveRule("languageDependBlock", 5);
			Leave_languageDependBlock();
		}
		DebugLocation(60, 1);
		} finally { DebugExitRule(GrammarFileName, "languageDependBlock"); }
		return retval;

	}
	// $ANTLR end "languageDependBlock"

	public class languageDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_languageDeclaration();
	partial void Leave_languageDeclaration();

	// $ANTLR start "languageDeclaration"
	// Aries.g:62:1: languageDeclaration : '@' languageType -> ^( LANGUAGE_DECLARATION languageType ) ;
	[GrammarRule("languageDeclaration")]
	private AriesParser.languageDeclaration_return languageDeclaration()
	{
		Enter_languageDeclaration();
		EnterRule("languageDeclaration", 6);
		TraceIn("languageDeclaration", 6);
		AriesParser.languageDeclaration_return retval = new AriesParser.languageDeclaration_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal15=null;
		AriesParser.languageType_return languageType16 = default(AriesParser.languageType_return);

		object char_literal15_tree=null;
		RewriteRuleITokenStream stream_37=new RewriteRuleITokenStream(adaptor,"token 37");
		RewriteRuleSubtreeStream stream_languageType=new RewriteRuleSubtreeStream(adaptor,"rule languageType");
		try { DebugEnterRule(GrammarFileName, "languageDeclaration");
		DebugLocation(62, 1);
		try
		{
			// Aries.g:63:2: ( '@' languageType -> ^( LANGUAGE_DECLARATION languageType ) )
			DebugEnterAlt(1);
			// Aries.g:63:4: '@' languageType
			{
			DebugLocation(63, 4);
			char_literal15=(IToken)Match(input,37,Follow._37_in_languageDeclaration278);  
			stream_37.Add(char_literal15);

			DebugLocation(63, 8);
			PushFollow(Follow._languageType_in_languageDeclaration280);
			languageType16=languageType();
			PopFollow();

			stream_languageType.Add(languageType16.Tree);


			{
			// AST REWRITE
			// elements: languageType
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 64:3: -> ^( LANGUAGE_DECLARATION languageType )
			{
				DebugLocation(64, 6);
				// Aries.g:64:6: ^( LANGUAGE_DECLARATION languageType )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(64, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(LANGUAGE_DECLARATION, "LANGUAGE_DECLARATION"), root_1);

				DebugLocation(64, 29);
				adaptor.AddChild(root_1, stream_languageType.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("languageDeclaration", 6);
			LeaveRule("languageDeclaration", 6);
			Leave_languageDeclaration();
		}
		DebugLocation(65, 1);
		} finally { DebugExitRule(GrammarFileName, "languageDeclaration"); }
		return retval;

	}
	// $ANTLR end "languageDeclaration"

	public class languageType_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_languageType();
	partial void Leave_languageType();

	// $ANTLR start "languageType"
	// Aries.g:67:1: languageType : ( 'Java' | 'JavaScript' | 'CSharp' | 'Ruby' | 'Python' | 'C' );
	[GrammarRule("languageType")]
	private AriesParser.languageType_return languageType()
	{
		Enter_languageType();
		EnterRule("languageType", 7);
		TraceIn("languageType", 7);
		AriesParser.languageType_return retval = new AriesParser.languageType_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set17=null;

		object set17_tree=null;

		try { DebugEnterRule(GrammarFileName, "languageType");
		DebugLocation(67, 1);
		try
		{
			// Aries.g:68:2: ( 'Java' | 'JavaScript' | 'CSharp' | 'Ruby' | 'Python' | 'C' )
			DebugEnterAlt(1);
			// Aries.g:
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(68, 2);
			set17=(IToken)input.LT(1);
			if ((input.LA(1)>=38 && input.LA(1)<=43))
			{
				input.Consume();
				adaptor.AddChild(root_0, (object)adaptor.Create(set17));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				throw mse;
			}


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
			TraceOut("languageType", 7);
			LeaveRule("languageType", 7);
			Leave_languageType();
		}
		DebugLocation(69, 1);
		} finally { DebugExitRule(GrammarFileName, "languageType"); }
		return retval;

	}
	// $ANTLR end "languageType"

	public class intertypeDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_intertypeDeclaration();
	partial void Leave_intertypeDeclaration();

	// $ANTLR start "intertypeDeclaration"
	// Aries.g:71:1: intertypeDeclaration : targetClass ':' languageDependBlock -> ^( INTERTYPE_DECLARATION targetClass languageDependBlock ) ;
	[GrammarRule("intertypeDeclaration")]
	private AriesParser.intertypeDeclaration_return intertypeDeclaration()
	{
		Enter_intertypeDeclaration();
		EnterRule("intertypeDeclaration", 8);
		TraceIn("intertypeDeclaration", 8);
		AriesParser.intertypeDeclaration_return retval = new AriesParser.intertypeDeclaration_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal19=null;
		AriesParser.targetClass_return targetClass18 = default(AriesParser.targetClass_return);
		AriesParser.languageDependBlock_return languageDependBlock20 = default(AriesParser.languageDependBlock_return);

		object char_literal19_tree=null;
		RewriteRuleITokenStream stream_44=new RewriteRuleITokenStream(adaptor,"token 44");
		RewriteRuleSubtreeStream stream_languageDependBlock=new RewriteRuleSubtreeStream(adaptor,"rule languageDependBlock");
		RewriteRuleSubtreeStream stream_targetClass=new RewriteRuleSubtreeStream(adaptor,"rule targetClass");
		try { DebugEnterRule(GrammarFileName, "intertypeDeclaration");
		DebugLocation(71, 1);
		try
		{
			// Aries.g:72:2: ( targetClass ':' languageDependBlock -> ^( INTERTYPE_DECLARATION targetClass languageDependBlock ) )
			DebugEnterAlt(1);
			// Aries.g:72:4: targetClass ':' languageDependBlock
			{
			DebugLocation(72, 4);
			PushFollow(Follow._targetClass_in_intertypeDeclaration332);
			targetClass18=targetClass();
			PopFollow();

			stream_targetClass.Add(targetClass18.Tree);
			DebugLocation(72, 16);
			char_literal19=(IToken)Match(input,44,Follow._44_in_intertypeDeclaration334);  
			stream_44.Add(char_literal19);

			DebugLocation(72, 20);
			PushFollow(Follow._languageDependBlock_in_intertypeDeclaration336);
			languageDependBlock20=languageDependBlock();
			PopFollow();

			stream_languageDependBlock.Add(languageDependBlock20.Tree);


			{
			// AST REWRITE
			// elements: targetClass, languageDependBlock
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 73:3: -> ^( INTERTYPE_DECLARATION targetClass languageDependBlock )
			{
				DebugLocation(73, 6);
				// Aries.g:73:6: ^( INTERTYPE_DECLARATION targetClass languageDependBlock )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(73, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(INTERTYPE_DECLARATION, "INTERTYPE_DECLARATION"), root_1);

				DebugLocation(73, 30);
				adaptor.AddChild(root_1, stream_targetClass.NextTree());
				DebugLocation(73, 42);
				adaptor.AddChild(root_1, stream_languageDependBlock.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("intertypeDeclaration", 8);
			LeaveRule("intertypeDeclaration", 8);
			Leave_intertypeDeclaration();
		}
		DebugLocation(74, 1);
		} finally { DebugExitRule(GrammarFileName, "intertypeDeclaration"); }
		return retval;

	}
	// $ANTLR end "intertypeDeclaration"

	public class targetClass_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_targetClass();
	partial void Leave_targetClass();

	// $ANTLR start "targetClass"
	// Aries.g:76:1: targetClass : IDENTIFIER -> ^( TARGET_CLASS IDENTIFIER ) ;
	[GrammarRule("targetClass")]
	private AriesParser.targetClass_return targetClass()
	{
		Enter_targetClass();
		EnterRule("targetClass", 9);
		TraceIn("targetClass", 9);
		AriesParser.targetClass_return retval = new AriesParser.targetClass_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER21=null;

		object IDENTIFIER21_tree=null;
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");

		try { DebugEnterRule(GrammarFileName, "targetClass");
		DebugLocation(76, 1);
		try
		{
			// Aries.g:77:2: ( IDENTIFIER -> ^( TARGET_CLASS IDENTIFIER ) )
			DebugEnterAlt(1);
			// Aries.g:77:4: IDENTIFIER
			{
			DebugLocation(77, 4);
			IDENTIFIER21=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_targetClass359);  
			stream_IDENTIFIER.Add(IDENTIFIER21);



			{
			// AST REWRITE
			// elements: IDENTIFIER
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 78:3: -> ^( TARGET_CLASS IDENTIFIER )
			{
				DebugLocation(78, 6);
				// Aries.g:78:6: ^( TARGET_CLASS IDENTIFIER )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(78, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(TARGET_CLASS, "TARGET_CLASS"), root_1);

				DebugLocation(78, 21);
				adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("targetClass", 9);
			LeaveRule("targetClass", 9);
			Leave_targetClass();
		}
		DebugLocation(79, 1);
		} finally { DebugExitRule(GrammarFileName, "targetClass"); }
		return retval;

	}
	// $ANTLR end "targetClass"

	public class pointcutDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_pointcutDeclaration();
	partial void Leave_pointcutDeclaration();

	// $ANTLR start "pointcutDeclaration"
	// Aries.g:81:1: pointcutDeclaration : 'pointcut' pointcutName parameters ':' pointcutDeclarator ';' -> ^( POINTCUT_DECLARATION pointcutName parameters pointcutDeclarator ) ;
	[GrammarRule("pointcutDeclaration")]
	private AriesParser.pointcutDeclaration_return pointcutDeclaration()
	{
		Enter_pointcutDeclaration();
		EnterRule("pointcutDeclaration", 10);
		TraceIn("pointcutDeclaration", 10);
		AriesParser.pointcutDeclaration_return retval = new AriesParser.pointcutDeclaration_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken string_literal22=null;
		IToken char_literal25=null;
		IToken char_literal27=null;
		AriesParser.pointcutName_return pointcutName23 = default(AriesParser.pointcutName_return);
		AriesParser.parameters_return parameters24 = default(AriesParser.parameters_return);
		AriesParser.pointcutDeclarator_return pointcutDeclarator26 = default(AriesParser.pointcutDeclarator_return);

		object string_literal22_tree=null;
		object char_literal25_tree=null;
		object char_literal27_tree=null;
		RewriteRuleITokenStream stream_45=new RewriteRuleITokenStream(adaptor,"token 45");
		RewriteRuleITokenStream stream_44=new RewriteRuleITokenStream(adaptor,"token 44");
		RewriteRuleITokenStream stream_46=new RewriteRuleITokenStream(adaptor,"token 46");
		RewriteRuleSubtreeStream stream_parameters=new RewriteRuleSubtreeStream(adaptor,"rule parameters");
		RewriteRuleSubtreeStream stream_pointcutDeclarator=new RewriteRuleSubtreeStream(adaptor,"rule pointcutDeclarator");
		RewriteRuleSubtreeStream stream_pointcutName=new RewriteRuleSubtreeStream(adaptor,"rule pointcutName");
		try { DebugEnterRule(GrammarFileName, "pointcutDeclaration");
		DebugLocation(81, 1);
		try
		{
			// Aries.g:82:2: ( 'pointcut' pointcutName parameters ':' pointcutDeclarator ';' -> ^( POINTCUT_DECLARATION pointcutName parameters pointcutDeclarator ) )
			DebugEnterAlt(1);
			// Aries.g:82:4: 'pointcut' pointcutName parameters ':' pointcutDeclarator ';'
			{
			DebugLocation(82, 4);
			string_literal22=(IToken)Match(input,45,Follow._45_in_pointcutDeclaration380);  
			stream_45.Add(string_literal22);

			DebugLocation(82, 15);
			PushFollow(Follow._pointcutName_in_pointcutDeclaration382);
			pointcutName23=pointcutName();
			PopFollow();

			stream_pointcutName.Add(pointcutName23.Tree);
			DebugLocation(82, 28);
			PushFollow(Follow._parameters_in_pointcutDeclaration384);
			parameters24=parameters();
			PopFollow();

			stream_parameters.Add(parameters24.Tree);
			DebugLocation(82, 39);
			char_literal25=(IToken)Match(input,44,Follow._44_in_pointcutDeclaration386);  
			stream_44.Add(char_literal25);

			DebugLocation(82, 43);
			PushFollow(Follow._pointcutDeclarator_in_pointcutDeclaration388);
			pointcutDeclarator26=pointcutDeclarator();
			PopFollow();

			stream_pointcutDeclarator.Add(pointcutDeclarator26.Tree);
			DebugLocation(82, 62);
			char_literal27=(IToken)Match(input,46,Follow._46_in_pointcutDeclaration390);  
			stream_46.Add(char_literal27);



			{
			// AST REWRITE
			// elements: parameters, pointcutName, pointcutDeclarator
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 83:3: -> ^( POINTCUT_DECLARATION pointcutName parameters pointcutDeclarator )
			{
				DebugLocation(83, 6);
				// Aries.g:83:6: ^( POINTCUT_DECLARATION pointcutName parameters pointcutDeclarator )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(83, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(POINTCUT_DECLARATION, "POINTCUT_DECLARATION"), root_1);

				DebugLocation(83, 29);
				adaptor.AddChild(root_1, stream_pointcutName.NextTree());
				DebugLocation(83, 42);
				adaptor.AddChild(root_1, stream_parameters.NextTree());
				DebugLocation(83, 53);
				adaptor.AddChild(root_1, stream_pointcutDeclarator.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("pointcutDeclaration", 10);
			LeaveRule("pointcutDeclaration", 10);
			Leave_pointcutDeclaration();
		}
		DebugLocation(84, 1);
		} finally { DebugExitRule(GrammarFileName, "pointcutDeclaration"); }
		return retval;

	}
	// $ANTLR end "pointcutDeclaration"

	public class pointcutName_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_pointcutName();
	partial void Leave_pointcutName();

	// $ANTLR start "pointcutName"
	// Aries.g:86:1: pointcutName : IDENTIFIER -> ^( POINTCUT_NAME IDENTIFIER ) ;
	[GrammarRule("pointcutName")]
	private AriesParser.pointcutName_return pointcutName()
	{
		Enter_pointcutName();
		EnterRule("pointcutName", 11);
		TraceIn("pointcutName", 11);
		AriesParser.pointcutName_return retval = new AriesParser.pointcutName_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER28=null;

		object IDENTIFIER28_tree=null;
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");

		try { DebugEnterRule(GrammarFileName, "pointcutName");
		DebugLocation(86, 1);
		try
		{
			// Aries.g:87:2: ( IDENTIFIER -> ^( POINTCUT_NAME IDENTIFIER ) )
			DebugEnterAlt(1);
			// Aries.g:87:4: IDENTIFIER
			{
			DebugLocation(87, 4);
			IDENTIFIER28=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_pointcutName415);  
			stream_IDENTIFIER.Add(IDENTIFIER28);



			{
			// AST REWRITE
			// elements: IDENTIFIER
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 88:3: -> ^( POINTCUT_NAME IDENTIFIER )
			{
				DebugLocation(88, 6);
				// Aries.g:88:6: ^( POINTCUT_NAME IDENTIFIER )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(88, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(POINTCUT_NAME, "POINTCUT_NAME"), root_1);

				DebugLocation(88, 22);
				adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("pointcutName", 11);
			LeaveRule("pointcutName", 11);
			Leave_pointcutName();
		}
		DebugLocation(89, 1);
		} finally { DebugExitRule(GrammarFileName, "pointcutName"); }
		return retval;

	}
	// $ANTLR end "pointcutName"

	public class parameters_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_parameters();
	partial void Leave_parameters();

	// $ANTLR start "parameters"
	// Aries.g:91:1: parameters : '(' ( parameter )* ')' -> ^( PARAMETERS ( parameter )* ) ;
	[GrammarRule("parameters")]
	private AriesParser.parameters_return parameters()
	{
		Enter_parameters();
		EnterRule("parameters", 12);
		TraceIn("parameters", 12);
		AriesParser.parameters_return retval = new AriesParser.parameters_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal29=null;
		IToken char_literal31=null;
		AriesParser.parameter_return parameter30 = default(AriesParser.parameter_return);

		object char_literal29_tree=null;
		object char_literal31_tree=null;
		RewriteRuleITokenStream stream_48=new RewriteRuleITokenStream(adaptor,"token 48");
		RewriteRuleITokenStream stream_47=new RewriteRuleITokenStream(adaptor,"token 47");
		RewriteRuleSubtreeStream stream_parameter=new RewriteRuleSubtreeStream(adaptor,"rule parameter");
		try { DebugEnterRule(GrammarFileName, "parameters");
		DebugLocation(91, 1);
		try
		{
			// Aries.g:92:2: ( '(' ( parameter )* ')' -> ^( PARAMETERS ( parameter )* ) )
			DebugEnterAlt(1);
			// Aries.g:92:4: '(' ( parameter )* ')'
			{
			DebugLocation(92, 4);
			char_literal29=(IToken)Match(input,47,Follow._47_in_parameters436);  
			stream_47.Add(char_literal29);

			DebugLocation(92, 8);
			// Aries.g:92:8: ( parameter )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0==IDENTIFIER))
				{
					alt3=1;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:92:8: parameter
					{
					DebugLocation(92, 8);
					PushFollow(Follow._parameter_in_parameters438);
					parameter30=parameter();
					PopFollow();

					stream_parameter.Add(parameter30.Tree);

					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }

			DebugLocation(92, 19);
			char_literal31=(IToken)Match(input,48,Follow._48_in_parameters441);  
			stream_48.Add(char_literal31);



			{
			// AST REWRITE
			// elements: parameter
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 93:3: -> ^( PARAMETERS ( parameter )* )
			{
				DebugLocation(93, 6);
				// Aries.g:93:6: ^( PARAMETERS ( parameter )* )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(93, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(PARAMETERS, "PARAMETERS"), root_1);

				DebugLocation(93, 19);
				// Aries.g:93:19: ( parameter )*
				while ( stream_parameter.HasNext )
				{
					DebugLocation(93, 19);
					adaptor.AddChild(root_1, stream_parameter.NextTree());

				}
				stream_parameter.Reset();

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("parameters", 12);
			LeaveRule("parameters", 12);
			Leave_parameters();
		}
		DebugLocation(94, 1);
		} finally { DebugExitRule(GrammarFileName, "parameters"); }
		return retval;

	}
	// $ANTLR end "parameters"

	public class parameter_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_parameter();
	partial void Leave_parameter();

	// $ANTLR start "parameter"
	// Aries.g:96:1: parameter : parameterType IDENTIFIER -> ^( PARAMETER parameterType IDENTIFIER ) ;
	[GrammarRule("parameter")]
	private AriesParser.parameter_return parameter()
	{
		Enter_parameter();
		EnterRule("parameter", 13);
		TraceIn("parameter", 13);
		AriesParser.parameter_return retval = new AriesParser.parameter_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER33=null;
		AriesParser.parameterType_return parameterType32 = default(AriesParser.parameterType_return);

		object IDENTIFIER33_tree=null;
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");
		RewriteRuleSubtreeStream stream_parameterType=new RewriteRuleSubtreeStream(adaptor,"rule parameterType");
		try { DebugEnterRule(GrammarFileName, "parameter");
		DebugLocation(96, 1);
		try
		{
			// Aries.g:97:2: ( parameterType IDENTIFIER -> ^( PARAMETER parameterType IDENTIFIER ) )
			DebugEnterAlt(1);
			// Aries.g:97:4: parameterType IDENTIFIER
			{
			DebugLocation(97, 4);
			PushFollow(Follow._parameterType_in_parameter463);
			parameterType32=parameterType();
			PopFollow();

			stream_parameterType.Add(parameterType32.Tree);
			DebugLocation(97, 18);
			IDENTIFIER33=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_parameter465);  
			stream_IDENTIFIER.Add(IDENTIFIER33);



			{
			// AST REWRITE
			// elements: IDENTIFIER, parameterType
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 98:3: -> ^( PARAMETER parameterType IDENTIFIER )
			{
				DebugLocation(98, 6);
				// Aries.g:98:6: ^( PARAMETER parameterType IDENTIFIER )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(98, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(PARAMETER, "PARAMETER"), root_1);

				DebugLocation(98, 18);
				adaptor.AddChild(root_1, stream_parameterType.NextTree());
				DebugLocation(98, 32);
				adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("parameter", 13);
			LeaveRule("parameter", 13);
			Leave_parameter();
		}
		DebugLocation(99, 1);
		} finally { DebugExitRule(GrammarFileName, "parameter"); }
		return retval;

	}
	// $ANTLR end "parameter"

	public class parameterType_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_parameterType();
	partial void Leave_parameterType();

	// $ANTLR start "parameterType"
	// Aries.g:101:1: parameterType : IDENTIFIER -> ^( PARAMETER_TYPE IDENTIFIER ) ;
	[GrammarRule("parameterType")]
	private AriesParser.parameterType_return parameterType()
	{
		Enter_parameterType();
		EnterRule("parameterType", 14);
		TraceIn("parameterType", 14);
		AriesParser.parameterType_return retval = new AriesParser.parameterType_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER34=null;

		object IDENTIFIER34_tree=null;
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");

		try { DebugEnterRule(GrammarFileName, "parameterType");
		DebugLocation(101, 1);
		try
		{
			// Aries.g:102:2: ( IDENTIFIER -> ^( PARAMETER_TYPE IDENTIFIER ) )
			DebugEnterAlt(1);
			// Aries.g:102:4: IDENTIFIER
			{
			DebugLocation(102, 4);
			IDENTIFIER34=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_parameterType488);  
			stream_IDENTIFIER.Add(IDENTIFIER34);



			{
			// AST REWRITE
			// elements: IDENTIFIER
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 103:3: -> ^( PARAMETER_TYPE IDENTIFIER )
			{
				DebugLocation(103, 6);
				// Aries.g:103:6: ^( PARAMETER_TYPE IDENTIFIER )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(103, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(PARAMETER_TYPE, "PARAMETER_TYPE"), root_1);

				DebugLocation(103, 23);
				adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("parameterType", 14);
			LeaveRule("parameterType", 14);
			Leave_parameterType();
		}
		DebugLocation(104, 1);
		} finally { DebugExitRule(GrammarFileName, "parameterType"); }
		return retval;

	}
	// $ANTLR end "parameterType"

	public class pointcutDeclarator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_pointcutDeclarator();
	partial void Leave_pointcutDeclarator();

	// $ANTLR start "pointcutDeclarator"
	// Aries.g:106:1: pointcutDeclarator : pointcutType '(' type identifierWithClassName arguments ')' -> ^( POINTCUT_DECLARATOR pointcutType type identifierWithClassName arguments ) ;
	[GrammarRule("pointcutDeclarator")]
	private AriesParser.pointcutDeclarator_return pointcutDeclarator()
	{
		Enter_pointcutDeclarator();
		EnterRule("pointcutDeclarator", 15);
		TraceIn("pointcutDeclarator", 15);
		AriesParser.pointcutDeclarator_return retval = new AriesParser.pointcutDeclarator_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal36=null;
		IToken char_literal40=null;
		AriesParser.pointcutType_return pointcutType35 = default(AriesParser.pointcutType_return);
		AriesParser.type_return type37 = default(AriesParser.type_return);
		AriesParser.identifierWithClassName_return identifierWithClassName38 = default(AriesParser.identifierWithClassName_return);
		AriesParser.arguments_return arguments39 = default(AriesParser.arguments_return);

		object char_literal36_tree=null;
		object char_literal40_tree=null;
		RewriteRuleITokenStream stream_48=new RewriteRuleITokenStream(adaptor,"token 48");
		RewriteRuleITokenStream stream_47=new RewriteRuleITokenStream(adaptor,"token 47");
		RewriteRuleSubtreeStream stream_pointcutType=new RewriteRuleSubtreeStream(adaptor,"rule pointcutType");
		RewriteRuleSubtreeStream stream_arguments=new RewriteRuleSubtreeStream(adaptor,"rule arguments");
		RewriteRuleSubtreeStream stream_type=new RewriteRuleSubtreeStream(adaptor,"rule type");
		RewriteRuleSubtreeStream stream_identifierWithClassName=new RewriteRuleSubtreeStream(adaptor,"rule identifierWithClassName");
		try { DebugEnterRule(GrammarFileName, "pointcutDeclarator");
		DebugLocation(106, 1);
		try
		{
			// Aries.g:107:2: ( pointcutType '(' type identifierWithClassName arguments ')' -> ^( POINTCUT_DECLARATOR pointcutType type identifierWithClassName arguments ) )
			DebugEnterAlt(1);
			// Aries.g:107:4: pointcutType '(' type identifierWithClassName arguments ')'
			{
			DebugLocation(107, 4);
			PushFollow(Follow._pointcutType_in_pointcutDeclarator509);
			pointcutType35=pointcutType();
			PopFollow();

			stream_pointcutType.Add(pointcutType35.Tree);
			DebugLocation(107, 17);
			char_literal36=(IToken)Match(input,47,Follow._47_in_pointcutDeclarator511);  
			stream_47.Add(char_literal36);

			DebugLocation(107, 21);
			PushFollow(Follow._type_in_pointcutDeclarator513);
			type37=type();
			PopFollow();

			stream_type.Add(type37.Tree);
			DebugLocation(107, 26);
			PushFollow(Follow._identifierWithClassName_in_pointcutDeclarator515);
			identifierWithClassName38=identifierWithClassName();
			PopFollow();

			stream_identifierWithClassName.Add(identifierWithClassName38.Tree);
			DebugLocation(107, 50);
			PushFollow(Follow._arguments_in_pointcutDeclarator517);
			arguments39=arguments();
			PopFollow();

			stream_arguments.Add(arguments39.Tree);
			DebugLocation(107, 60);
			char_literal40=(IToken)Match(input,48,Follow._48_in_pointcutDeclarator519);  
			stream_48.Add(char_literal40);



			{
			// AST REWRITE
			// elements: type, arguments, identifierWithClassName, pointcutType
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 108:3: -> ^( POINTCUT_DECLARATOR pointcutType type identifierWithClassName arguments )
			{
				DebugLocation(108, 6);
				// Aries.g:108:6: ^( POINTCUT_DECLARATOR pointcutType type identifierWithClassName arguments )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(108, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(POINTCUT_DECLARATOR, "POINTCUT_DECLARATOR"), root_1);

				DebugLocation(108, 28);
				adaptor.AddChild(root_1, stream_pointcutType.NextTree());
				DebugLocation(108, 41);
				adaptor.AddChild(root_1, stream_type.NextTree());
				DebugLocation(108, 46);
				adaptor.AddChild(root_1, stream_identifierWithClassName.NextTree());
				DebugLocation(108, 70);
				adaptor.AddChild(root_1, stream_arguments.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("pointcutDeclarator", 15);
			LeaveRule("pointcutDeclarator", 15);
			Leave_pointcutDeclarator();
		}
		DebugLocation(109, 1);
		} finally { DebugExitRule(GrammarFileName, "pointcutDeclarator"); }
		return retval;

	}
	// $ANTLR end "pointcutDeclarator"

	public class pointcutType_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_pointcutType();
	partial void Leave_pointcutType();

	// $ANTLR start "pointcutType"
	// Aries.g:111:1: pointcutType : POINTCUT_TYPE_ELEMENT -> ^( POINTCUT_TYPE POINTCUT_TYPE_ELEMENT ) ;
	[GrammarRule("pointcutType")]
	private AriesParser.pointcutType_return pointcutType()
	{
		Enter_pointcutType();
		EnterRule("pointcutType", 16);
		TraceIn("pointcutType", 16);
		AriesParser.pointcutType_return retval = new AriesParser.pointcutType_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken POINTCUT_TYPE_ELEMENT41=null;

		object POINTCUT_TYPE_ELEMENT41_tree=null;
		RewriteRuleITokenStream stream_POINTCUT_TYPE_ELEMENT=new RewriteRuleITokenStream(adaptor,"token POINTCUT_TYPE_ELEMENT");

		try { DebugEnterRule(GrammarFileName, "pointcutType");
		DebugLocation(111, 1);
		try
		{
			// Aries.g:112:2: ( POINTCUT_TYPE_ELEMENT -> ^( POINTCUT_TYPE POINTCUT_TYPE_ELEMENT ) )
			DebugEnterAlt(1);
			// Aries.g:112:4: POINTCUT_TYPE_ELEMENT
			{
			DebugLocation(112, 4);
			POINTCUT_TYPE_ELEMENT41=(IToken)Match(input,POINTCUT_TYPE_ELEMENT,Follow._POINTCUT_TYPE_ELEMENT_in_pointcutType546);  
			stream_POINTCUT_TYPE_ELEMENT.Add(POINTCUT_TYPE_ELEMENT41);



			{
			// AST REWRITE
			// elements: POINTCUT_TYPE_ELEMENT
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 113:3: -> ^( POINTCUT_TYPE POINTCUT_TYPE_ELEMENT )
			{
				DebugLocation(113, 6);
				// Aries.g:113:6: ^( POINTCUT_TYPE POINTCUT_TYPE_ELEMENT )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(113, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(POINTCUT_TYPE, "POINTCUT_TYPE"), root_1);

				DebugLocation(113, 22);
				adaptor.AddChild(root_1, stream_POINTCUT_TYPE_ELEMENT.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("pointcutType", 16);
			LeaveRule("pointcutType", 16);
			Leave_pointcutType();
		}
		DebugLocation(114, 1);
		} finally { DebugExitRule(GrammarFileName, "pointcutType"); }
		return retval;

	}
	// $ANTLR end "pointcutType"

	public class type_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_type();
	partial void Leave_type();

	// $ANTLR start "type"
	// Aries.g:120:1: type : IDENTIFIER -> ^( TYPE IDENTIFIER ) ;
	[GrammarRule("type")]
	private AriesParser.type_return type()
	{
		Enter_type();
		EnterRule("type", 17);
		TraceIn("type", 17);
		AriesParser.type_return retval = new AriesParser.type_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER42=null;

		object IDENTIFIER42_tree=null;
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");

		try { DebugEnterRule(GrammarFileName, "type");
		DebugLocation(120, 1);
		try
		{
			// Aries.g:121:2: ( IDENTIFIER -> ^( TYPE IDENTIFIER ) )
			DebugEnterAlt(1);
			// Aries.g:121:4: IDENTIFIER
			{
			DebugLocation(121, 4);
			IDENTIFIER42=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_type582);  
			stream_IDENTIFIER.Add(IDENTIFIER42);



			{
			// AST REWRITE
			// elements: IDENTIFIER
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 122:3: -> ^( TYPE IDENTIFIER )
			{
				DebugLocation(122, 6);
				// Aries.g:122:6: ^( TYPE IDENTIFIER )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(122, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(TYPE, "TYPE"), root_1);

				DebugLocation(122, 13);
				adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("type", 17);
			LeaveRule("type", 17);
			Leave_type();
		}
		DebugLocation(123, 1);
		} finally { DebugExitRule(GrammarFileName, "type"); }
		return retval;

	}
	// $ANTLR end "type"

	public class identifierWithClassName_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_identifierWithClassName();
	partial void Leave_identifierWithClassName();

	// $ANTLR start "identifierWithClassName"
	// Aries.g:125:1: identifierWithClassName : IDENTIFIER ( '.' IDENTIFIER )+ -> ^( IDENTIFIER_WITH_CLASS_NAME ( IDENTIFIER )+ ) ;
	[GrammarRule("identifierWithClassName")]
	private AriesParser.identifierWithClassName_return identifierWithClassName()
	{
		Enter_identifierWithClassName();
		EnterRule("identifierWithClassName", 18);
		TraceIn("identifierWithClassName", 18);
		AriesParser.identifierWithClassName_return retval = new AriesParser.identifierWithClassName_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER43=null;
		IToken char_literal44=null;
		IToken IDENTIFIER45=null;

		object IDENTIFIER43_tree=null;
		object char_literal44_tree=null;
		object IDENTIFIER45_tree=null;
		RewriteRuleITokenStream stream_49=new RewriteRuleITokenStream(adaptor,"token 49");
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");

		try { DebugEnterRule(GrammarFileName, "identifierWithClassName");
		DebugLocation(125, 1);
		try
		{
			// Aries.g:126:2: ( IDENTIFIER ( '.' IDENTIFIER )+ -> ^( IDENTIFIER_WITH_CLASS_NAME ( IDENTIFIER )+ ) )
			DebugEnterAlt(1);
			// Aries.g:126:4: IDENTIFIER ( '.' IDENTIFIER )+
			{
			DebugLocation(126, 4);
			IDENTIFIER43=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_identifierWithClassName603);  
			stream_IDENTIFIER.Add(IDENTIFIER43);

			DebugLocation(126, 15);
			// Aries.g:126:15: ( '.' IDENTIFIER )+
			int cnt4=0;
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, decisionCanBacktrack[4]);
				int LA4_0 = input.LA(1);

				if ((LA4_0==49))
				{
					alt4=1;
				}


				} finally { DebugExitDecision(4); }
				switch (alt4)
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:126:16: '.' IDENTIFIER
					{
					DebugLocation(126, 16);
					char_literal44=(IToken)Match(input,49,Follow._49_in_identifierWithClassName606);  
					stream_49.Add(char_literal44);

					DebugLocation(126, 20);
					IDENTIFIER45=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_identifierWithClassName608);  
					stream_IDENTIFIER.Add(IDENTIFIER45);


					}
					break;

				default:
					if (cnt4 >= 1)
						goto loop4;

					EarlyExitException eee4 = new EarlyExitException( 4, input );
					DebugRecognitionException(eee4);
					throw eee4;
				}
				cnt4++;
			}
			loop4:
				;

			} finally { DebugExitSubRule(4); }



			{
			// AST REWRITE
			// elements: IDENTIFIER
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 127:3: -> ^( IDENTIFIER_WITH_CLASS_NAME ( IDENTIFIER )+ )
			{
				DebugLocation(127, 6);
				// Aries.g:127:6: ^( IDENTIFIER_WITH_CLASS_NAME ( IDENTIFIER )+ )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(127, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(IDENTIFIER_WITH_CLASS_NAME, "IDENTIFIER_WITH_CLASS_NAME"), root_1);

				DebugLocation(127, 35);
				if ( !(stream_IDENTIFIER.HasNext) )
				{
					throw new RewriteEarlyExitException();
				}
				while ( stream_IDENTIFIER.HasNext )
				{
					DebugLocation(127, 35);
					adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());

				}
				stream_IDENTIFIER.Reset();

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("identifierWithClassName", 18);
			LeaveRule("identifierWithClassName", 18);
			Leave_identifierWithClassName();
		}
		DebugLocation(128, 1);
		} finally { DebugExitRule(GrammarFileName, "identifierWithClassName"); }
		return retval;

	}
	// $ANTLR end "identifierWithClassName"

	public class arguments_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_arguments();
	partial void Leave_arguments();

	// $ANTLR start "arguments"
	// Aries.g:130:1: arguments : '(' ')' ;
	[GrammarRule("arguments")]
	private AriesParser.arguments_return arguments()
	{
		Enter_arguments();
		EnterRule("arguments", 19);
		TraceIn("arguments", 19);
		AriesParser.arguments_return retval = new AriesParser.arguments_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal46=null;
		IToken char_literal47=null;

		object char_literal46_tree=null;
		object char_literal47_tree=null;

		try { DebugEnterRule(GrammarFileName, "arguments");
		DebugLocation(130, 1);
		try
		{
			// Aries.g:131:2: ( '(' ')' )
			DebugEnterAlt(1);
			// Aries.g:131:4: '(' ')'
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(131, 4);
			char_literal46=(IToken)Match(input,47,Follow._47_in_arguments632); 
			char_literal46_tree = (object)adaptor.Create(char_literal46);
			adaptor.AddChild(root_0, char_literal46_tree);

			DebugLocation(131, 8);
			char_literal47=(IToken)Match(input,48,Follow._48_in_arguments634); 
			char_literal47_tree = (object)adaptor.Create(char_literal47);
			adaptor.AddChild(root_0, char_literal47_tree);


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
			TraceOut("arguments", 19);
			LeaveRule("arguments", 19);
			Leave_arguments();
		}
		DebugLocation(132, 1);
		} finally { DebugExitRule(GrammarFileName, "arguments"); }
		return retval;

	}
	// $ANTLR end "arguments"

	public class adviceDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_adviceDeclaration();
	partial void Leave_adviceDeclaration();

	// $ANTLR start "adviceDeclaration"
	// Aries.g:134:1: adviceDeclaration : adviceType ':' adviceTarget parameters adviceBody -> ^( ADVICE_DECLARATION adviceType adviceTarget parameters adviceBody ) ;
	[GrammarRule("adviceDeclaration")]
	private AriesParser.adviceDeclaration_return adviceDeclaration()
	{
		Enter_adviceDeclaration();
		EnterRule("adviceDeclaration", 20);
		TraceIn("adviceDeclaration", 20);
		AriesParser.adviceDeclaration_return retval = new AriesParser.adviceDeclaration_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal49=null;
		AriesParser.adviceType_return adviceType48 = default(AriesParser.adviceType_return);
		AriesParser.adviceTarget_return adviceTarget50 = default(AriesParser.adviceTarget_return);
		AriesParser.parameters_return parameters51 = default(AriesParser.parameters_return);
		AriesParser.adviceBody_return adviceBody52 = default(AriesParser.adviceBody_return);

		object char_literal49_tree=null;
		RewriteRuleITokenStream stream_44=new RewriteRuleITokenStream(adaptor,"token 44");
		RewriteRuleSubtreeStream stream_adviceBody=new RewriteRuleSubtreeStream(adaptor,"rule adviceBody");
		RewriteRuleSubtreeStream stream_adviceType=new RewriteRuleSubtreeStream(adaptor,"rule adviceType");
		RewriteRuleSubtreeStream stream_adviceTarget=new RewriteRuleSubtreeStream(adaptor,"rule adviceTarget");
		RewriteRuleSubtreeStream stream_parameters=new RewriteRuleSubtreeStream(adaptor,"rule parameters");
		try { DebugEnterRule(GrammarFileName, "adviceDeclaration");
		DebugLocation(134, 1);
		try
		{
			// Aries.g:135:2: ( adviceType ':' adviceTarget parameters adviceBody -> ^( ADVICE_DECLARATION adviceType adviceTarget parameters adviceBody ) )
			DebugEnterAlt(1);
			// Aries.g:135:4: adviceType ':' adviceTarget parameters adviceBody
			{
			DebugLocation(135, 4);
			PushFollow(Follow._adviceType_in_adviceDeclaration645);
			adviceType48=adviceType();
			PopFollow();

			stream_adviceType.Add(adviceType48.Tree);
			DebugLocation(135, 15);
			char_literal49=(IToken)Match(input,44,Follow._44_in_adviceDeclaration647);  
			stream_44.Add(char_literal49);

			DebugLocation(135, 19);
			PushFollow(Follow._adviceTarget_in_adviceDeclaration649);
			adviceTarget50=adviceTarget();
			PopFollow();

			stream_adviceTarget.Add(adviceTarget50.Tree);
			DebugLocation(135, 32);
			PushFollow(Follow._parameters_in_adviceDeclaration651);
			parameters51=parameters();
			PopFollow();

			stream_parameters.Add(parameters51.Tree);
			DebugLocation(135, 43);
			PushFollow(Follow._adviceBody_in_adviceDeclaration653);
			adviceBody52=adviceBody();
			PopFollow();

			stream_adviceBody.Add(adviceBody52.Tree);


			{
			// AST REWRITE
			// elements: adviceTarget, parameters, adviceType, adviceBody
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 136:3: -> ^( ADVICE_DECLARATION adviceType adviceTarget parameters adviceBody )
			{
				DebugLocation(136, 6);
				// Aries.g:136:6: ^( ADVICE_DECLARATION adviceType adviceTarget parameters adviceBody )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(136, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ADVICE_DECLARATION, "ADVICE_DECLARATION"), root_1);

				DebugLocation(136, 27);
				adaptor.AddChild(root_1, stream_adviceType.NextTree());
				DebugLocation(136, 38);
				adaptor.AddChild(root_1, stream_adviceTarget.NextTree());
				DebugLocation(136, 51);
				adaptor.AddChild(root_1, stream_parameters.NextTree());
				DebugLocation(136, 62);
				adaptor.AddChild(root_1, stream_adviceBody.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("adviceDeclaration", 20);
			LeaveRule("adviceDeclaration", 20);
			Leave_adviceDeclaration();
		}
		DebugLocation(137, 1);
		} finally { DebugExitRule(GrammarFileName, "adviceDeclaration"); }
		return retval;

	}
	// $ANTLR end "adviceDeclaration"

	public class adviceType_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_adviceType();
	partial void Leave_adviceType();

	// $ANTLR start "adviceType"
	// Aries.g:139:1: adviceType : ADVICE_TYPE_ELEMENT -> ^( ADVICE_TYPE ADVICE_TYPE_ELEMENT ) ;
	[GrammarRule("adviceType")]
	private AriesParser.adviceType_return adviceType()
	{
		Enter_adviceType();
		EnterRule("adviceType", 21);
		TraceIn("adviceType", 21);
		AriesParser.adviceType_return retval = new AriesParser.adviceType_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken ADVICE_TYPE_ELEMENT53=null;

		object ADVICE_TYPE_ELEMENT53_tree=null;
		RewriteRuleITokenStream stream_ADVICE_TYPE_ELEMENT=new RewriteRuleITokenStream(adaptor,"token ADVICE_TYPE_ELEMENT");

		try { DebugEnterRule(GrammarFileName, "adviceType");
		DebugLocation(139, 1);
		try
		{
			// Aries.g:140:2: ( ADVICE_TYPE_ELEMENT -> ^( ADVICE_TYPE ADVICE_TYPE_ELEMENT ) )
			DebugEnterAlt(1);
			// Aries.g:140:4: ADVICE_TYPE_ELEMENT
			{
			DebugLocation(140, 4);
			ADVICE_TYPE_ELEMENT53=(IToken)Match(input,ADVICE_TYPE_ELEMENT,Follow._ADVICE_TYPE_ELEMENT_in_adviceType681);  
			stream_ADVICE_TYPE_ELEMENT.Add(ADVICE_TYPE_ELEMENT53);



			{
			// AST REWRITE
			// elements: ADVICE_TYPE_ELEMENT
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 141:3: -> ^( ADVICE_TYPE ADVICE_TYPE_ELEMENT )
			{
				DebugLocation(141, 6);
				// Aries.g:141:6: ^( ADVICE_TYPE ADVICE_TYPE_ELEMENT )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(141, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ADVICE_TYPE, "ADVICE_TYPE"), root_1);

				DebugLocation(141, 20);
				adaptor.AddChild(root_1, stream_ADVICE_TYPE_ELEMENT.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("adviceType", 21);
			LeaveRule("adviceType", 21);
			Leave_adviceType();
		}
		DebugLocation(142, 1);
		} finally { DebugExitRule(GrammarFileName, "adviceType"); }
		return retval;

	}
	// $ANTLR end "adviceType"

	public class adviceTarget_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_adviceTarget();
	partial void Leave_adviceTarget();

	// $ANTLR start "adviceTarget"
	// Aries.g:148:1: adviceTarget : IDENTIFIER -> ^( ADVICE_TARGET IDENTIFIER ) ;
	[GrammarRule("adviceTarget")]
	private AriesParser.adviceTarget_return adviceTarget()
	{
		Enter_adviceTarget();
		EnterRule("adviceTarget", 22);
		TraceIn("adviceTarget", 22);
		AriesParser.adviceTarget_return retval = new AriesParser.adviceTarget_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken IDENTIFIER54=null;

		object IDENTIFIER54_tree=null;
		RewriteRuleITokenStream stream_IDENTIFIER=new RewriteRuleITokenStream(adaptor,"token IDENTIFIER");

		try { DebugEnterRule(GrammarFileName, "adviceTarget");
		DebugLocation(148, 1);
		try
		{
			// Aries.g:149:2: ( IDENTIFIER -> ^( ADVICE_TARGET IDENTIFIER ) )
			DebugEnterAlt(1);
			// Aries.g:149:4: IDENTIFIER
			{
			DebugLocation(149, 4);
			IDENTIFIER54=(IToken)Match(input,IDENTIFIER,Follow._IDENTIFIER_in_adviceTarget717);  
			stream_IDENTIFIER.Add(IDENTIFIER54);



			{
			// AST REWRITE
			// elements: IDENTIFIER
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 150:3: -> ^( ADVICE_TARGET IDENTIFIER )
			{
				DebugLocation(150, 6);
				// Aries.g:150:6: ^( ADVICE_TARGET IDENTIFIER )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(150, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ADVICE_TARGET, "ADVICE_TARGET"), root_1);

				DebugLocation(150, 22);
				adaptor.AddChild(root_1, stream_IDENTIFIER.NextNode());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("adviceTarget", 22);
			LeaveRule("adviceTarget", 22);
			Leave_adviceTarget();
		}
		DebugLocation(151, 1);
		} finally { DebugExitRule(GrammarFileName, "adviceTarget"); }
		return retval;

	}
	// $ANTLR end "adviceTarget"

	public class adviceBody_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_adviceBody();
	partial void Leave_adviceBody();

	// $ANTLR start "adviceBody"
	// Aries.g:153:1: adviceBody : '{' ( languageDependBlock )+ '}' -> ^( ADVICE_BODY ( languageDependBlock )+ ) ;
	[GrammarRule("adviceBody")]
	private AriesParser.adviceBody_return adviceBody()
	{
		Enter_adviceBody();
		EnterRule("adviceBody", 23);
		TraceIn("adviceBody", 23);
		AriesParser.adviceBody_return retval = new AriesParser.adviceBody_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal55=null;
		IToken char_literal57=null;
		AriesParser.languageDependBlock_return languageDependBlock56 = default(AriesParser.languageDependBlock_return);

		object char_literal55_tree=null;
		object char_literal57_tree=null;
		RewriteRuleITokenStream stream_35=new RewriteRuleITokenStream(adaptor,"token 35");
		RewriteRuleITokenStream stream_34=new RewriteRuleITokenStream(adaptor,"token 34");
		RewriteRuleSubtreeStream stream_languageDependBlock=new RewriteRuleSubtreeStream(adaptor,"rule languageDependBlock");
		try { DebugEnterRule(GrammarFileName, "adviceBody");
		DebugLocation(153, 1);
		try
		{
			// Aries.g:154:2: ( '{' ( languageDependBlock )+ '}' -> ^( ADVICE_BODY ( languageDependBlock )+ ) )
			DebugEnterAlt(1);
			// Aries.g:154:4: '{' ( languageDependBlock )+ '}'
			{
			DebugLocation(154, 4);
			char_literal55=(IToken)Match(input,34,Follow._34_in_adviceBody738);  
			stream_34.Add(char_literal55);

			DebugLocation(154, 8);
			// Aries.g:154:8: ( languageDependBlock )+
			int cnt5=0;
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
				int LA5_0 = input.LA(1);

				if ((LA5_0==37))
				{
					alt5=1;
				}


				} finally { DebugExitDecision(5); }
				switch (alt5)
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:154:8: languageDependBlock
					{
					DebugLocation(154, 8);
					PushFollow(Follow._languageDependBlock_in_adviceBody740);
					languageDependBlock56=languageDependBlock();
					PopFollow();

					stream_languageDependBlock.Add(languageDependBlock56.Tree);

					}
					break;

				default:
					if (cnt5 >= 1)
						goto loop5;

					EarlyExitException eee5 = new EarlyExitException( 5, input );
					DebugRecognitionException(eee5);
					throw eee5;
				}
				cnt5++;
			}
			loop5:
				;

			} finally { DebugExitSubRule(5); }

			DebugLocation(154, 29);
			char_literal57=(IToken)Match(input,35,Follow._35_in_adviceBody743);  
			stream_35.Add(char_literal57);



			{
			// AST REWRITE
			// elements: languageDependBlock
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 155:3: -> ^( ADVICE_BODY ( languageDependBlock )+ )
			{
				DebugLocation(155, 6);
				// Aries.g:155:6: ^( ADVICE_BODY ( languageDependBlock )+ )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(155, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(ADVICE_BODY, "ADVICE_BODY"), root_1);

				DebugLocation(155, 20);
				if ( !(stream_languageDependBlock.HasNext) )
				{
					throw new RewriteEarlyExitException();
				}
				while ( stream_languageDependBlock.HasNext )
				{
					DebugLocation(155, 20);
					adaptor.AddChild(root_1, stream_languageDependBlock.NextTree());

				}
				stream_languageDependBlock.Reset();

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("adviceBody", 23);
			LeaveRule("adviceBody", 23);
			Leave_adviceBody();
		}
		DebugLocation(156, 1);
		} finally { DebugExitRule(GrammarFileName, "adviceBody"); }
		return retval;

	}
	// $ANTLR end "adviceBody"

	public class contents_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_contents();
	partial void Leave_contents();

	// $ANTLR start "contents"
	// Aries.g:158:1: contents : content -> ^( CONTENTS content ) ;
	[GrammarRule("contents")]
	private AriesParser.contents_return contents()
	{
		Enter_contents();
		EnterRule("contents", 24);
		TraceIn("contents", 24);
		AriesParser.contents_return retval = new AriesParser.contents_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		AriesParser.content_return content58 = default(AriesParser.content_return);

		RewriteRuleSubtreeStream stream_content=new RewriteRuleSubtreeStream(adaptor,"rule content");
		try { DebugEnterRule(GrammarFileName, "contents");
		DebugLocation(158, 1);
		try
		{
			// Aries.g:159:2: ( content -> ^( CONTENTS content ) )
			DebugEnterAlt(1);
			// Aries.g:159:4: content
			{
			DebugLocation(159, 4);
			PushFollow(Follow._content_in_contents765);
			content58=content();
			PopFollow();

			stream_content.Add(content58.Tree);


			{
			// AST REWRITE
			// elements: content
			// token labels: 
			// rule labels: retval
			// token list labels: 
			// rule list labels: 
			// wildcard labels: 
			retval.Tree = root_0;
			RewriteRuleSubtreeStream stream_retval=new RewriteRuleSubtreeStream(adaptor,"rule retval",retval!=null?retval.Tree:null);

			root_0 = (object)adaptor.Nil();
			// 160:3: -> ^( CONTENTS content )
			{
				DebugLocation(160, 6);
				// Aries.g:160:6: ^( CONTENTS content )
				{
				object root_1 = (object)adaptor.Nil();
				DebugLocation(160, 8);
				root_1 = (object)adaptor.BecomeRoot((object)adaptor.Create(CONTENTS, "CONTENTS"), root_1);

				DebugLocation(160, 17);
				adaptor.AddChild(root_1, stream_content.NextTree());

				adaptor.AddChild(root_0, root_1);
				}

			}

			retval.Tree = root_0;
			}

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
			TraceOut("contents", 24);
			LeaveRule("contents", 24);
			Leave_contents();
		}
		DebugLocation(161, 1);
		} finally { DebugExitRule(GrammarFileName, "contents"); }
		return retval;

	}
	// $ANTLR end "contents"

	public class content_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_content();
	partial void Leave_content();

	// $ANTLR start "content"
	// Aries.g:163:1: content : ( IDENTIFIER | INTLITERAL | STRING | WS | ~ ( '}end' | IDENTIFIER | INTLITERAL | WS ) )* ;
	[GrammarRule("content")]
	private AriesParser.content_return content()
	{
		Enter_content();
		EnterRule("content", 25);
		TraceIn("content", 25);
		AriesParser.content_return retval = new AriesParser.content_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken set59=null;

		object set59_tree=null;

		try { DebugEnterRule(GrammarFileName, "content");
		DebugLocation(163, 1);
		try
		{
			// Aries.g:164:2: ( ( IDENTIFIER | INTLITERAL | STRING | WS | ~ ( '}end' | IDENTIFIER | INTLITERAL | WS ) )* )
			DebugEnterAlt(1);
			// Aries.g:164:4: ( IDENTIFIER | INTLITERAL | STRING | WS | ~ ( '}end' | IDENTIFIER | INTLITERAL | WS ) )*
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(164, 4);
			// Aries.g:164:4: ( IDENTIFIER | INTLITERAL | STRING | WS | ~ ( '}end' | IDENTIFIER | INTLITERAL | WS ) )*
			try { DebugEnterSubRule(6);
			while (true)
			{
				int alt6=2;
				try { DebugEnterDecision(6, decisionCanBacktrack[6]);
				int LA6_0 = input.LA(1);

				if (((LA6_0>=ASPECT && LA6_0<=35)||(LA6_0>=37 && LA6_0<=50)))
				{
					alt6=1;
				}


				} finally { DebugExitDecision(6); }
				switch ( alt6 )
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:
					{
					DebugLocation(164, 4);
					set59=(IToken)input.LT(1);
					if ((input.LA(1)>=ASPECT && input.LA(1)<=35)||(input.LA(1)>=37 && input.LA(1)<=50))
					{
						input.Consume();
						adaptor.AddChild(root_0, (object)adaptor.Create(set59));
						state.errorRecovery=false;
					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						throw mse;
					}


					}
					break;

				default:
					goto loop6;
				}
			}

			loop6:
				;

			} finally { DebugExitSubRule(6); }


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
			TraceOut("content", 25);
			LeaveRule("content", 25);
			Leave_content();
		}
		DebugLocation(165, 1);
		} finally { DebugExitRule(GrammarFileName, "content"); }
		return retval;

	}
	// $ANTLR end "content"

	public class variableInitializer_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>
	{
		private object _tree;
		public object Tree { get { return _tree; } set { _tree = value; } }
	}

	partial void Enter_variableInitializer();
	partial void Leave_variableInitializer();

	// $ANTLR start "variableInitializer"
	// Aries.g:168:1: variableInitializer : '=' INTLITERAL ;
	[GrammarRule("variableInitializer")]
	private AriesParser.variableInitializer_return variableInitializer()
	{
		Enter_variableInitializer();
		EnterRule("variableInitializer", 26);
		TraceIn("variableInitializer", 26);
		AriesParser.variableInitializer_return retval = new AriesParser.variableInitializer_return();
		retval.Start = (IToken)input.LT(1);

		object root_0 = null;

		IToken char_literal60=null;
		IToken INTLITERAL61=null;

		object char_literal60_tree=null;
		object INTLITERAL61_tree=null;

		try { DebugEnterRule(GrammarFileName, "variableInitializer");
		DebugLocation(168, 1);
		try
		{
			// Aries.g:169:2: ( '=' INTLITERAL )
			DebugEnterAlt(1);
			// Aries.g:169:4: '=' INTLITERAL
			{
			root_0 = (object)adaptor.Nil();

			DebugLocation(169, 4);
			char_literal60=(IToken)Match(input,50,Follow._50_in_variableInitializer833); 
			char_literal60_tree = (object)adaptor.Create(char_literal60);
			adaptor.AddChild(root_0, char_literal60_tree);

			DebugLocation(169, 8);
			INTLITERAL61=(IToken)Match(input,INTLITERAL,Follow._INTLITERAL_in_variableInitializer835); 
			INTLITERAL61_tree = (object)adaptor.Create(INTLITERAL61);
			adaptor.AddChild(root_0, INTLITERAL61_tree);


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
			TraceOut("variableInitializer", 26);
			LeaveRule("variableInitializer", 26);
			Leave_variableInitializer();
		}
		DebugLocation(170, 1);
		} finally { DebugExitRule(GrammarFileName, "variableInitializer"); }
		return retval;

	}
	// $ANTLR end "variableInitializer"
	#endregion Rules


	#region Follow sets
	private static class Follow
	{
		public static readonly BitSet _33_in_aspect123 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _IDENTIFIER_in_aspect125 = new BitSet(new ulong[]{0x400000000UL});
		public static readonly BitSet _aspectBody_in_aspect127 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _34_in_aspectBody150 = new BitSet(new ulong[]{0x200814000000UL});
		public static readonly BitSet _elements_in_aspectBody152 = new BitSet(new ulong[]{0x800000000UL});
		public static readonly BitSet _35_in_aspectBody154 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _element_in_elements175 = new BitSet(new ulong[]{0x200014000002UL});
		public static readonly BitSet _intertypeDeclaration_in_element198 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointcutDeclaration_in_element213 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _adviceDeclaration_in_element228 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _languageDeclaration_in_languageDependBlock249 = new BitSet(new ulong[]{0x400000000UL});
		public static readonly BitSet _34_in_languageDependBlock251 = new BitSet(new ulong[]{0x7FFEFFFFFFFF0UL});
		public static readonly BitSet _contents_in_languageDependBlock253 = new BitSet(new ulong[]{0x1000000000UL});
		public static readonly BitSet _36_in_languageDependBlock255 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _37_in_languageDeclaration278 = new BitSet(new ulong[]{0xFC000000000UL});
		public static readonly BitSet _languageType_in_languageDeclaration280 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_languageType0 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _targetClass_in_intertypeDeclaration332 = new BitSet(new ulong[]{0x100000000000UL});
		public static readonly BitSet _44_in_intertypeDeclaration334 = new BitSet(new ulong[]{0x2000000000UL});
		public static readonly BitSet _languageDependBlock_in_intertypeDeclaration336 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_targetClass359 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _45_in_pointcutDeclaration380 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _pointcutName_in_pointcutDeclaration382 = new BitSet(new ulong[]{0x800000000000UL});
		public static readonly BitSet _parameters_in_pointcutDeclaration384 = new BitSet(new ulong[]{0x100000000000UL});
		public static readonly BitSet _44_in_pointcutDeclaration386 = new BitSet(new ulong[]{0x8000000UL});
		public static readonly BitSet _pointcutDeclarator_in_pointcutDeclaration388 = new BitSet(new ulong[]{0x400000000000UL});
		public static readonly BitSet _46_in_pointcutDeclaration390 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_pointcutName415 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _47_in_parameters436 = new BitSet(new ulong[]{0x1000004000000UL});
		public static readonly BitSet _parameter_in_parameters438 = new BitSet(new ulong[]{0x1000004000000UL});
		public static readonly BitSet _48_in_parameters441 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _parameterType_in_parameter463 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _IDENTIFIER_in_parameter465 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_parameterType488 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _pointcutType_in_pointcutDeclarator509 = new BitSet(new ulong[]{0x800000000000UL});
		public static readonly BitSet _47_in_pointcutDeclarator511 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _type_in_pointcutDeclarator513 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _identifierWithClassName_in_pointcutDeclarator515 = new BitSet(new ulong[]{0x800000000000UL});
		public static readonly BitSet _arguments_in_pointcutDeclarator517 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_pointcutDeclarator519 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _POINTCUT_TYPE_ELEMENT_in_pointcutType546 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_type582 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_identifierWithClassName603 = new BitSet(new ulong[]{0x2000000000000UL});
		public static readonly BitSet _49_in_identifierWithClassName606 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _IDENTIFIER_in_identifierWithClassName608 = new BitSet(new ulong[]{0x2000000000002UL});
		public static readonly BitSet _47_in_arguments632 = new BitSet(new ulong[]{0x1000000000000UL});
		public static readonly BitSet _48_in_arguments634 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _adviceType_in_adviceDeclaration645 = new BitSet(new ulong[]{0x100000000000UL});
		public static readonly BitSet _44_in_adviceDeclaration647 = new BitSet(new ulong[]{0x4000000UL});
		public static readonly BitSet _adviceTarget_in_adviceDeclaration649 = new BitSet(new ulong[]{0x800000000000UL});
		public static readonly BitSet _parameters_in_adviceDeclaration651 = new BitSet(new ulong[]{0x400000000UL});
		public static readonly BitSet _adviceBody_in_adviceDeclaration653 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _ADVICE_TYPE_ELEMENT_in_adviceType681 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _IDENTIFIER_in_adviceTarget717 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _34_in_adviceBody738 = new BitSet(new ulong[]{0x2000000000UL});
		public static readonly BitSet _languageDependBlock_in_adviceBody740 = new BitSet(new ulong[]{0x2800000000UL});
		public static readonly BitSet _35_in_adviceBody743 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _content_in_contents765 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_content786 = new BitSet(new ulong[]{0x7FFEFFFFFFFF2UL});
		public static readonly BitSet _50_in_variableInitializer833 = new BitSet(new ulong[]{0x20000000UL});
		public static readonly BitSet _INTLITERAL_in_variableInitializer835 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}
