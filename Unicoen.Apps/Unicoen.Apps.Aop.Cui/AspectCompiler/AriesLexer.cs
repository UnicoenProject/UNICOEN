// $ANTLR 3.3 Nov 30, 2010 12:50:56 Aries.g 2011-07-14 18:08:44

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3 Nov 30, 2010 12:50:56")]
[System.CLSCompliant(false)]
public partial class AriesLexer : Antlr.Runtime.Lexer
{
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

	public AriesLexer()
	{
		OnCreated();
	}

	public AriesLexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public AriesLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "Aries.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_T__33();
	partial void Leave_T__33();

	// $ANTLR start "T__33"
	[GrammarRule("T__33")]
	private void mT__33()
	{
		Enter_T__33();
		EnterRule("T__33", 1);
		TraceIn("T__33", 1);
		try
		{
			int _type = T__33;
			int _channel = DefaultTokenChannel;
			// Aries.g:7:7: ( 'aspect' )
			DebugEnterAlt(1);
			// Aries.g:7:9: 'aspect'
			{
			DebugLocation(7, 9);
			Match("aspect"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__33", 1);
			LeaveRule("T__33", 1);
			Leave_T__33();
		}
	}
	// $ANTLR end "T__33"

	partial void Enter_T__34();
	partial void Leave_T__34();

	// $ANTLR start "T__34"
	[GrammarRule("T__34")]
	private void mT__34()
	{
		Enter_T__34();
		EnterRule("T__34", 2);
		TraceIn("T__34", 2);
		try
		{
			int _type = T__34;
			int _channel = DefaultTokenChannel;
			// Aries.g:8:7: ( '{' )
			DebugEnterAlt(1);
			// Aries.g:8:9: '{'
			{
			DebugLocation(8, 9);
			Match('{'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__34", 2);
			LeaveRule("T__34", 2);
			Leave_T__34();
		}
	}
	// $ANTLR end "T__34"

	partial void Enter_T__35();
	partial void Leave_T__35();

	// $ANTLR start "T__35"
	[GrammarRule("T__35")]
	private void mT__35()
	{
		Enter_T__35();
		EnterRule("T__35", 3);
		TraceIn("T__35", 3);
		try
		{
			int _type = T__35;
			int _channel = DefaultTokenChannel;
			// Aries.g:9:7: ( '}' )
			DebugEnterAlt(1);
			// Aries.g:9:9: '}'
			{
			DebugLocation(9, 9);
			Match('}'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__35", 3);
			LeaveRule("T__35", 3);
			Leave_T__35();
		}
	}
	// $ANTLR end "T__35"

	partial void Enter_T__36();
	partial void Leave_T__36();

	// $ANTLR start "T__36"
	[GrammarRule("T__36")]
	private void mT__36()
	{
		Enter_T__36();
		EnterRule("T__36", 4);
		TraceIn("T__36", 4);
		try
		{
			int _type = T__36;
			int _channel = DefaultTokenChannel;
			// Aries.g:10:7: ( '}end' )
			DebugEnterAlt(1);
			// Aries.g:10:9: '}end'
			{
			DebugLocation(10, 9);
			Match("}end"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__36", 4);
			LeaveRule("T__36", 4);
			Leave_T__36();
		}
	}
	// $ANTLR end "T__36"

	partial void Enter_T__37();
	partial void Leave_T__37();

	// $ANTLR start "T__37"
	[GrammarRule("T__37")]
	private void mT__37()
	{
		Enter_T__37();
		EnterRule("T__37", 5);
		TraceIn("T__37", 5);
		try
		{
			int _type = T__37;
			int _channel = DefaultTokenChannel;
			// Aries.g:11:7: ( '@' )
			DebugEnterAlt(1);
			// Aries.g:11:9: '@'
			{
			DebugLocation(11, 9);
			Match('@'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__37", 5);
			LeaveRule("T__37", 5);
			Leave_T__37();
		}
	}
	// $ANTLR end "T__37"

	partial void Enter_T__38();
	partial void Leave_T__38();

	// $ANTLR start "T__38"
	[GrammarRule("T__38")]
	private void mT__38()
	{
		Enter_T__38();
		EnterRule("T__38", 6);
		TraceIn("T__38", 6);
		try
		{
			int _type = T__38;
			int _channel = DefaultTokenChannel;
			// Aries.g:12:7: ( 'Java' )
			DebugEnterAlt(1);
			// Aries.g:12:9: 'Java'
			{
			DebugLocation(12, 9);
			Match("Java"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__38", 6);
			LeaveRule("T__38", 6);
			Leave_T__38();
		}
	}
	// $ANTLR end "T__38"

	partial void Enter_T__39();
	partial void Leave_T__39();

	// $ANTLR start "T__39"
	[GrammarRule("T__39")]
	private void mT__39()
	{
		Enter_T__39();
		EnterRule("T__39", 7);
		TraceIn("T__39", 7);
		try
		{
			int _type = T__39;
			int _channel = DefaultTokenChannel;
			// Aries.g:13:7: ( 'JavaScript' )
			DebugEnterAlt(1);
			// Aries.g:13:9: 'JavaScript'
			{
			DebugLocation(13, 9);
			Match("JavaScript"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__39", 7);
			LeaveRule("T__39", 7);
			Leave_T__39();
		}
	}
	// $ANTLR end "T__39"

	partial void Enter_T__40();
	partial void Leave_T__40();

	// $ANTLR start "T__40"
	[GrammarRule("T__40")]
	private void mT__40()
	{
		Enter_T__40();
		EnterRule("T__40", 8);
		TraceIn("T__40", 8);
		try
		{
			int _type = T__40;
			int _channel = DefaultTokenChannel;
			// Aries.g:14:7: ( 'CSharp' )
			DebugEnterAlt(1);
			// Aries.g:14:9: 'CSharp'
			{
			DebugLocation(14, 9);
			Match("CSharp"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__40", 8);
			LeaveRule("T__40", 8);
			Leave_T__40();
		}
	}
	// $ANTLR end "T__40"

	partial void Enter_T__41();
	partial void Leave_T__41();

	// $ANTLR start "T__41"
	[GrammarRule("T__41")]
	private void mT__41()
	{
		Enter_T__41();
		EnterRule("T__41", 9);
		TraceIn("T__41", 9);
		try
		{
			int _type = T__41;
			int _channel = DefaultTokenChannel;
			// Aries.g:15:7: ( 'Ruby' )
			DebugEnterAlt(1);
			// Aries.g:15:9: 'Ruby'
			{
			DebugLocation(15, 9);
			Match("Ruby"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__41", 9);
			LeaveRule("T__41", 9);
			Leave_T__41();
		}
	}
	// $ANTLR end "T__41"

	partial void Enter_T__42();
	partial void Leave_T__42();

	// $ANTLR start "T__42"
	[GrammarRule("T__42")]
	private void mT__42()
	{
		Enter_T__42();
		EnterRule("T__42", 10);
		TraceIn("T__42", 10);
		try
		{
			int _type = T__42;
			int _channel = DefaultTokenChannel;
			// Aries.g:16:7: ( 'Python' )
			DebugEnterAlt(1);
			// Aries.g:16:9: 'Python'
			{
			DebugLocation(16, 9);
			Match("Python"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__42", 10);
			LeaveRule("T__42", 10);
			Leave_T__42();
		}
	}
	// $ANTLR end "T__42"

	partial void Enter_T__43();
	partial void Leave_T__43();

	// $ANTLR start "T__43"
	[GrammarRule("T__43")]
	private void mT__43()
	{
		Enter_T__43();
		EnterRule("T__43", 11);
		TraceIn("T__43", 11);
		try
		{
			int _type = T__43;
			int _channel = DefaultTokenChannel;
			// Aries.g:17:7: ( 'C' )
			DebugEnterAlt(1);
			// Aries.g:17:9: 'C'
			{
			DebugLocation(17, 9);
			Match('C'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__43", 11);
			LeaveRule("T__43", 11);
			Leave_T__43();
		}
	}
	// $ANTLR end "T__43"

	partial void Enter_T__44();
	partial void Leave_T__44();

	// $ANTLR start "T__44"
	[GrammarRule("T__44")]
	private void mT__44()
	{
		Enter_T__44();
		EnterRule("T__44", 12);
		TraceIn("T__44", 12);
		try
		{
			int _type = T__44;
			int _channel = DefaultTokenChannel;
			// Aries.g:18:7: ( ':' )
			DebugEnterAlt(1);
			// Aries.g:18:9: ':'
			{
			DebugLocation(18, 9);
			Match(':'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__44", 12);
			LeaveRule("T__44", 12);
			Leave_T__44();
		}
	}
	// $ANTLR end "T__44"

	partial void Enter_T__45();
	partial void Leave_T__45();

	// $ANTLR start "T__45"
	[GrammarRule("T__45")]
	private void mT__45()
	{
		Enter_T__45();
		EnterRule("T__45", 13);
		TraceIn("T__45", 13);
		try
		{
			int _type = T__45;
			int _channel = DefaultTokenChannel;
			// Aries.g:19:7: ( 'pointcut' )
			DebugEnterAlt(1);
			// Aries.g:19:9: 'pointcut'
			{
			DebugLocation(19, 9);
			Match("pointcut"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__45", 13);
			LeaveRule("T__45", 13);
			Leave_T__45();
		}
	}
	// $ANTLR end "T__45"

	partial void Enter_T__46();
	partial void Leave_T__46();

	// $ANTLR start "T__46"
	[GrammarRule("T__46")]
	private void mT__46()
	{
		Enter_T__46();
		EnterRule("T__46", 14);
		TraceIn("T__46", 14);
		try
		{
			int _type = T__46;
			int _channel = DefaultTokenChannel;
			// Aries.g:20:7: ( ';' )
			DebugEnterAlt(1);
			// Aries.g:20:9: ';'
			{
			DebugLocation(20, 9);
			Match(';'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__46", 14);
			LeaveRule("T__46", 14);
			Leave_T__46();
		}
	}
	// $ANTLR end "T__46"

	partial void Enter_T__47();
	partial void Leave_T__47();

	// $ANTLR start "T__47"
	[GrammarRule("T__47")]
	private void mT__47()
	{
		Enter_T__47();
		EnterRule("T__47", 15);
		TraceIn("T__47", 15);
		try
		{
			int _type = T__47;
			int _channel = DefaultTokenChannel;
			// Aries.g:21:7: ( '(' )
			DebugEnterAlt(1);
			// Aries.g:21:9: '('
			{
			DebugLocation(21, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__47", 15);
			LeaveRule("T__47", 15);
			Leave_T__47();
		}
	}
	// $ANTLR end "T__47"

	partial void Enter_T__48();
	partial void Leave_T__48();

	// $ANTLR start "T__48"
	[GrammarRule("T__48")]
	private void mT__48()
	{
		Enter_T__48();
		EnterRule("T__48", 16);
		TraceIn("T__48", 16);
		try
		{
			int _type = T__48;
			int _channel = DefaultTokenChannel;
			// Aries.g:22:7: ( ')' )
			DebugEnterAlt(1);
			// Aries.g:22:9: ')'
			{
			DebugLocation(22, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__48", 16);
			LeaveRule("T__48", 16);
			Leave_T__48();
		}
	}
	// $ANTLR end "T__48"

	partial void Enter_T__49();
	partial void Leave_T__49();

	// $ANTLR start "T__49"
	[GrammarRule("T__49")]
	private void mT__49()
	{
		Enter_T__49();
		EnterRule("T__49", 17);
		TraceIn("T__49", 17);
		try
		{
			int _type = T__49;
			int _channel = DefaultTokenChannel;
			// Aries.g:23:7: ( '.' )
			DebugEnterAlt(1);
			// Aries.g:23:9: '.'
			{
			DebugLocation(23, 9);
			Match('.'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__49", 17);
			LeaveRule("T__49", 17);
			Leave_T__49();
		}
	}
	// $ANTLR end "T__49"

	partial void Enter_T__50();
	partial void Leave_T__50();

	// $ANTLR start "T__50"
	[GrammarRule("T__50")]
	private void mT__50()
	{
		Enter_T__50();
		EnterRule("T__50", 18);
		TraceIn("T__50", 18);
		try
		{
			int _type = T__50;
			int _channel = DefaultTokenChannel;
			// Aries.g:24:7: ( '=' )
			DebugEnterAlt(1);
			// Aries.g:24:9: '='
			{
			DebugLocation(24, 9);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__50", 18);
			LeaveRule("T__50", 18);
			Leave_T__50();
		}
	}
	// $ANTLR end "T__50"

	partial void Enter_POINTCUT_TYPE_ELEMENT();
	partial void Leave_POINTCUT_TYPE_ELEMENT();

	// $ANTLR start "POINTCUT_TYPE_ELEMENT"
	[GrammarRule("POINTCUT_TYPE_ELEMENT")]
	private void mPOINTCUT_TYPE_ELEMENT()
	{
		Enter_POINTCUT_TYPE_ELEMENT();
		EnterRule("POINTCUT_TYPE_ELEMENT", 19);
		TraceIn("POINTCUT_TYPE_ELEMENT", 19);
		try
		{
			int _type = POINTCUT_TYPE_ELEMENT;
			int _channel = DefaultTokenChannel;
			// Aries.g:117:2: ( 'execution' | 'call' )
			int alt1=2;
			try { DebugEnterDecision(1, decisionCanBacktrack[1]);
			int LA1_0 = input.LA(1);

			if ((LA1_0=='e'))
			{
				alt1=1;
			}
			else if ((LA1_0=='c'))
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
				// Aries.g:117:4: 'execution'
				{
				DebugLocation(117, 4);
				Match("execution"); 


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// Aries.g:117:18: 'call'
				{
				DebugLocation(117, 18);
				Match("call"); 


				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("POINTCUT_TYPE_ELEMENT", 19);
			LeaveRule("POINTCUT_TYPE_ELEMENT", 19);
			Leave_POINTCUT_TYPE_ELEMENT();
		}
	}
	// $ANTLR end "POINTCUT_TYPE_ELEMENT"

	partial void Enter_ADVICE_TYPE_ELEMENT();
	partial void Leave_ADVICE_TYPE_ELEMENT();

	// $ANTLR start "ADVICE_TYPE_ELEMENT"
	[GrammarRule("ADVICE_TYPE_ELEMENT")]
	private void mADVICE_TYPE_ELEMENT()
	{
		Enter_ADVICE_TYPE_ELEMENT();
		EnterRule("ADVICE_TYPE_ELEMENT", 20);
		TraceIn("ADVICE_TYPE_ELEMENT", 20);
		try
		{
			int _type = ADVICE_TYPE_ELEMENT;
			int _channel = DefaultTokenChannel;
			// Aries.g:145:2: ( 'before' | 'after' )
			int alt2=2;
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			int LA2_0 = input.LA(1);

			if ((LA2_0=='b'))
			{
				alt2=1;
			}
			else if ((LA2_0=='a'))
			{
				alt2=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// Aries.g:145:4: 'before'
				{
				DebugLocation(145, 4);
				Match("before"); 


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// Aries.g:145:15: 'after'
				{
				DebugLocation(145, 15);
				Match("after"); 


				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ADVICE_TYPE_ELEMENT", 20);
			LeaveRule("ADVICE_TYPE_ELEMENT", 20);
			Leave_ADVICE_TYPE_ELEMENT();
		}
	}
	// $ANTLR end "ADVICE_TYPE_ELEMENT"

	partial void Enter_IDENTIFIER();
	partial void Leave_IDENTIFIER();

	// $ANTLR start "IDENTIFIER"
	[GrammarRule("IDENTIFIER")]
	private void mIDENTIFIER()
	{
		Enter_IDENTIFIER();
		EnterRule("IDENTIFIER", 21);
		TraceIn("IDENTIFIER", 21);
		try
		{
			int _type = IDENTIFIER;
			int _channel = DefaultTokenChannel;
			// Aries.g:173:2: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' )+ | '*' )
			int alt4=2;
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			int LA4_0 = input.LA(1);

			if (((LA4_0>='A' && LA4_0<='Z')||LA4_0=='_'||(LA4_0>='a' && LA4_0<='z')))
			{
				alt4=1;
			}
			else if ((LA4_0=='*'))
			{
				alt4=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 4, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// Aries.g:173:4: ( 'a' .. 'z' | 'A' .. 'Z' | '_' )+
				{
				DebugLocation(173, 4);
				// Aries.g:173:4: ( 'a' .. 'z' | 'A' .. 'Z' | '_' )+
				int cnt3=0;
				try { DebugEnterSubRule(3);
				while (true)
				{
					int alt3=2;
					try { DebugEnterDecision(3, decisionCanBacktrack[3]);
					int LA3_0 = input.LA(1);

					if (((LA3_0>='A' && LA3_0<='Z')||LA3_0=='_'||(LA3_0>='a' && LA3_0<='z')))
					{
						alt3=1;
					}


					} finally { DebugExitDecision(3); }
					switch (alt3)
					{
					case 1:
						DebugEnterAlt(1);
						// Aries.g:
						{
						DebugLocation(173, 4);
						if ((input.LA(1)>='A' && input.LA(1)<='Z')||input.LA(1)=='_'||(input.LA(1)>='a' && input.LA(1)<='z'))
						{
							input.Consume();

						}
						else
						{
							MismatchedSetException mse = new MismatchedSetException(null,input);
							DebugRecognitionException(mse);
							Recover(mse);
							throw mse;}


						}
						break;

					default:
						if (cnt3 >= 1)
							goto loop3;

						EarlyExitException eee3 = new EarlyExitException( 3, input );
						DebugRecognitionException(eee3);
						throw eee3;
					}
					cnt3++;
				}
				loop3:
					;

				} finally { DebugExitSubRule(3); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// Aries.g:173:31: '*'
				{
				DebugLocation(173, 31);
				Match('*'); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IDENTIFIER", 21);
			LeaveRule("IDENTIFIER", 21);
			Leave_IDENTIFIER();
		}
	}
	// $ANTLR end "IDENTIFIER"

	partial void Enter_STRING();
	partial void Leave_STRING();

	// $ANTLR start "STRING"
	[GrammarRule("STRING")]
	private void mSTRING()
	{
		Enter_STRING();
		EnterRule("STRING", 22);
		TraceIn("STRING", 22);
		try
		{
			int _type = STRING;
			int _channel = DefaultTokenChannel;
			// Aries.g:177:5: ( '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"' )
			DebugEnterAlt(1);
			// Aries.g:177:8: '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"'
			{
			DebugLocation(177, 8);
			Match('\"'); 
			DebugLocation(177, 12);
			// Aries.g:177:12: ( EscapeSequence | ~ ( '\\\\' | '\"' ) )*
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=3;
				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
				int LA5_0 = input.LA(1);

				if ((LA5_0=='\\'))
				{
					alt5=1;
				}
				else if (((LA5_0>='\u0000' && LA5_0<='!')||(LA5_0>='#' && LA5_0<='[')||(LA5_0>=']' && LA5_0<='\uFFFF')))
				{
					alt5=2;
				}


				} finally { DebugExitDecision(5); }
				switch ( alt5 )
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:177:14: EscapeSequence
					{
					DebugLocation(177, 14);
					mEscapeSequence(); 

					}
					break;
				case 2:
					DebugEnterAlt(2);
					// Aries.g:177:31: ~ ( '\\\\' | '\"' )
					{
					DebugLocation(177, 31);
					if ((input.LA(1)>='\u0000' && input.LA(1)<='!')||(input.LA(1)>='#' && input.LA(1)<='[')||(input.LA(1)>=']' && input.LA(1)<='\uFFFF'))
					{
						input.Consume();

					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						Recover(mse);
						throw mse;}


					}
					break;

				default:
					goto loop5;
				}
			}

			loop5:
				;

			} finally { DebugExitSubRule(5); }

			DebugLocation(177, 46);
			Match('\"'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("STRING", 22);
			LeaveRule("STRING", 22);
			Leave_STRING();
		}
	}
	// $ANTLR end "STRING"

	partial void Enter_INTLITERAL();
	partial void Leave_INTLITERAL();

	// $ANTLR start "INTLITERAL"
	[GrammarRule("INTLITERAL")]
	private void mINTLITERAL()
	{
		Enter_INTLITERAL();
		EnterRule("INTLITERAL", 23);
		TraceIn("INTLITERAL", 23);
		try
		{
			int _type = INTLITERAL;
			int _channel = DefaultTokenChannel;
			// Aries.g:181:2: ( ( '1' .. '9' ) ( '0' .. '9' )* )
			DebugEnterAlt(1);
			// Aries.g:181:4: ( '1' .. '9' ) ( '0' .. '9' )*
			{
			DebugLocation(181, 4);
			// Aries.g:181:4: ( '1' .. '9' )
			DebugEnterAlt(1);
			// Aries.g:181:5: '1' .. '9'
			{
			DebugLocation(181, 5);
			MatchRange('1','9'); 

			}

			DebugLocation(181, 15);
			// Aries.g:181:15: ( '0' .. '9' )*
			try { DebugEnterSubRule(6);
			while (true)
			{
				int alt6=2;
				try { DebugEnterDecision(6, decisionCanBacktrack[6]);
				int LA6_0 = input.LA(1);

				if (((LA6_0>='0' && LA6_0<='9')))
				{
					alt6=1;
				}


				} finally { DebugExitDecision(6); }
				switch ( alt6 )
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:181:16: '0' .. '9'
					{
					DebugLocation(181, 16);
					MatchRange('0','9'); 

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

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INTLITERAL", 23);
			LeaveRule("INTLITERAL", 23);
			Leave_INTLITERAL();
		}
	}
	// $ANTLR end "INTLITERAL"

	partial void Enter_EscapeSequence();
	partial void Leave_EscapeSequence();

	// $ANTLR start "EscapeSequence"
	[GrammarRule("EscapeSequence")]
	private void mEscapeSequence()
	{
		Enter_EscapeSequence();
		EnterRule("EscapeSequence", 24);
		TraceIn("EscapeSequence", 24);
		try
		{
			// Aries.g:186:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) )
			DebugEnterAlt(1);
			// Aries.g:186:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
			{
			DebugLocation(186, 9);
			Match('\\'); 
			DebugLocation(186, 14);
			if (input.LA(1)=='\"'||input.LA(1)=='\''||input.LA(1)=='\\'||input.LA(1)=='b'||input.LA(1)=='f'||input.LA(1)=='n'||input.LA(1)=='r'||input.LA(1)=='t')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("EscapeSequence", 24);
			LeaveRule("EscapeSequence", 24);
			Leave_EscapeSequence();
		}
	}
	// $ANTLR end "EscapeSequence"

	partial void Enter_WS();
	partial void Leave_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		Enter_WS();
		EnterRule("WS", 25);
		TraceIn("WS", 25);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// Aries.g:190:2: ( ( ' ' | '\\t' | '\\r' | '\\n' )+ )
			DebugEnterAlt(1);
			// Aries.g:190:4: ( ' ' | '\\t' | '\\r' | '\\n' )+
			{
			DebugLocation(190, 4);
			// Aries.g:190:4: ( ' ' | '\\t' | '\\r' | '\\n' )+
			int cnt7=0;
			try { DebugEnterSubRule(7);
			while (true)
			{
				int alt7=2;
				try { DebugEnterDecision(7, decisionCanBacktrack[7]);
				int LA7_0 = input.LA(1);

				if (((LA7_0>='\t' && LA7_0<='\n')||LA7_0=='\r'||LA7_0==' '))
				{
					alt7=1;
				}


				} finally { DebugExitDecision(7); }
				switch (alt7)
				{
				case 1:
					DebugEnterAlt(1);
					// Aries.g:
					{
					DebugLocation(190, 4);
					if ((input.LA(1)>='\t' && input.LA(1)<='\n')||input.LA(1)=='\r'||input.LA(1)==' ')
					{
						input.Consume();

					}
					else
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						DebugRecognitionException(mse);
						Recover(mse);
						throw mse;}


					}
					break;

				default:
					if (cnt7 >= 1)
						goto loop7;

					EarlyExitException eee7 = new EarlyExitException( 7, input );
					DebugRecognitionException(eee7);
					throw eee7;
				}
				cnt7++;
			}
			loop7:
				;

			} finally { DebugExitSubRule(7); }

			DebugLocation(191, 3);
			 Skip(); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 25);
			LeaveRule("WS", 25);
			Leave_WS();
		}
	}
	// $ANTLR end "WS"

	public override void mTokens()
	{
		// Aries.g:1:8: ( T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | POINTCUT_TYPE_ELEMENT | ADVICE_TYPE_ELEMENT | IDENTIFIER | STRING | INTLITERAL | WS )
		int alt8=24;
		try { DebugEnterDecision(8, decisionCanBacktrack[8]);
		try
		{
			alt8 = dfa8.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(8); }
		switch (alt8)
		{
		case 1:
			DebugEnterAlt(1);
			// Aries.g:1:10: T__33
			{
			DebugLocation(1, 10);
			mT__33(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// Aries.g:1:16: T__34
			{
			DebugLocation(1, 16);
			mT__34(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// Aries.g:1:22: T__35
			{
			DebugLocation(1, 22);
			mT__35(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// Aries.g:1:28: T__36
			{
			DebugLocation(1, 28);
			mT__36(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// Aries.g:1:34: T__37
			{
			DebugLocation(1, 34);
			mT__37(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// Aries.g:1:40: T__38
			{
			DebugLocation(1, 40);
			mT__38(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// Aries.g:1:46: T__39
			{
			DebugLocation(1, 46);
			mT__39(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// Aries.g:1:52: T__40
			{
			DebugLocation(1, 52);
			mT__40(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// Aries.g:1:58: T__41
			{
			DebugLocation(1, 58);
			mT__41(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// Aries.g:1:64: T__42
			{
			DebugLocation(1, 64);
			mT__42(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// Aries.g:1:70: T__43
			{
			DebugLocation(1, 70);
			mT__43(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// Aries.g:1:76: T__44
			{
			DebugLocation(1, 76);
			mT__44(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// Aries.g:1:82: T__45
			{
			DebugLocation(1, 82);
			mT__45(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// Aries.g:1:88: T__46
			{
			DebugLocation(1, 88);
			mT__46(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// Aries.g:1:94: T__47
			{
			DebugLocation(1, 94);
			mT__47(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// Aries.g:1:100: T__48
			{
			DebugLocation(1, 100);
			mT__48(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// Aries.g:1:106: T__49
			{
			DebugLocation(1, 106);
			mT__49(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// Aries.g:1:112: T__50
			{
			DebugLocation(1, 112);
			mT__50(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// Aries.g:1:118: POINTCUT_TYPE_ELEMENT
			{
			DebugLocation(1, 118);
			mPOINTCUT_TYPE_ELEMENT(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// Aries.g:1:140: ADVICE_TYPE_ELEMENT
			{
			DebugLocation(1, 140);
			mADVICE_TYPE_ELEMENT(); 

			}
			break;
		case 21:
			DebugEnterAlt(21);
			// Aries.g:1:160: IDENTIFIER
			{
			DebugLocation(1, 160);
			mIDENTIFIER(); 

			}
			break;
		case 22:
			DebugEnterAlt(22);
			// Aries.g:1:171: STRING
			{
			DebugLocation(1, 171);
			mSTRING(); 

			}
			break;
		case 23:
			DebugEnterAlt(23);
			// Aries.g:1:178: INTLITERAL
			{
			DebugLocation(1, 178);
			mINTLITERAL(); 

			}
			break;
		case 24:
			DebugEnterAlt(24);
			// Aries.g:1:189: WS
			{
			DebugLocation(1, 189);
			mWS(); 

			}
			break;

		}

	}


	#region DFA
	DFA8 dfa8;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa8 = new DFA8(this);
	}

	private class DFA8 : DFA
	{
		private const string DFA8_eotS =
			"\x1\xFFFF\x1\x13\x1\xFFFF\x1\x1A\x1\xFFFF\x1\x13\x1\x1D\x2\x13\x1\xFFFF"+
			"\x1\x13\x5\xFFFF\x3\x13\x4\xFFFF\x2\x13\x2\xFFFF\x2\x13\x1\xFFFF\x12"+
			"\x13\x1\x3B\x1\x13\x1\x3D\x3\x13\x1\x41\x2\x13\x1\x44\x1\x13\x1\xFFFF"+
			"\x1\x13\x1\xFFFF\x3\x13\x1\xFFFF\x1\x13\x1\x4B\x1\xFFFF\x1\x13\x1\x4D"+
			"\x1\x4E\x2\x13\x1\x44\x1\xFFFF\x1\x13\x2\xFFFF\x3\x13\x1\x55\x2\x13\x1"+
			"\xFFFF\x1\x41\x1\x58\x1\xFFFF";
		private const string DFA8_eofS =
			"\x59\xFFFF";
		private const string DFA8_minS =
			"\x1\x9\x1\x66\x1\xFFFF\x1\x65\x1\xFFFF\x1\x61\x1\x41\x1\x75\x1\x79\x1"+
			"\xFFFF\x1\x6F\x5\xFFFF\x1\x78\x1\x61\x1\x65\x4\xFFFF\x1\x70\x1\x74\x2"+
			"\xFFFF\x1\x76\x1\x68\x1\xFFFF\x1\x62\x1\x74\x1\x69\x1\x65\x1\x6C\x1\x66"+
			"\x2\x65\x2\x61\x1\x79\x1\x68\x1\x6E\x1\x63\x1\x6C\x1\x6F\x1\x63\x1\x72"+
			"\x1\x41\x1\x72\x1\x41\x1\x6F\x1\x74\x1\x75\x1\x41\x1\x72\x1\x74\x1\x41"+
			"\x1\x63\x1\xFFFF\x1\x70\x1\xFFFF\x1\x6E\x1\x63\x1\x74\x1\xFFFF\x1\x65"+
			"\x1\x41\x1\xFFFF\x1\x72\x2\x41\x1\x75\x1\x69\x1\x41\x1\xFFFF\x1\x69\x2"+
			"\xFFFF\x1\x74\x1\x6F\x1\x70\x1\x41\x1\x6E\x1\x74\x1\xFFFF\x2\x41\x1\xFFFF";
		private const string DFA8_maxS =
			"\x1\x7D\x1\x73\x1\xFFFF\x1\x65\x1\xFFFF\x1\x61\x1\x7A\x1\x75\x1\x79"+
			"\x1\xFFFF\x1\x6F\x5\xFFFF\x1\x78\x1\x61\x1\x65\x4\xFFFF\x1\x70\x1\x74"+
			"\x2\xFFFF\x1\x76\x1\x68\x1\xFFFF\x1\x62\x1\x74\x1\x69\x1\x65\x1\x6C\x1"+
			"\x66\x2\x65\x2\x61\x1\x79\x1\x68\x1\x6E\x1\x63\x1\x6C\x1\x6F\x1\x63\x1"+
			"\x72\x1\x7A\x1\x72\x1\x7A\x1\x6F\x1\x74\x1\x75\x1\x7A\x1\x72\x1\x74\x1"+
			"\x7A\x1\x63\x1\xFFFF\x1\x70\x1\xFFFF\x1\x6E\x1\x63\x1\x74\x1\xFFFF\x1"+
			"\x65\x1\x7A\x1\xFFFF\x1\x72\x2\x7A\x1\x75\x1\x69\x1\x7A\x1\xFFFF\x1\x69"+
			"\x2\xFFFF\x1\x74\x1\x6F\x1\x70\x1\x7A\x1\x6E\x1\x74\x1\xFFFF\x2\x7A\x1"+
			"\xFFFF";
		private const string DFA8_acceptS =
			"\x2\xFFFF\x1\x2\x1\xFFFF\x1\x5\x4\xFFFF\x1\xC\x1\xFFFF\x1\xE\x1\xF\x1"+
			"\x10\x1\x11\x1\x12\x3\xFFFF\x1\x15\x1\x16\x1\x17\x1\x18\x2\xFFFF\x1\x4"+
			"\x1\x3\x2\xFFFF\x1\xB\x1D\xFFFF\x1\x6\x1\xFFFF\x1\x9\x3\xFFFF\x1\x13"+
			"\x2\xFFFF\x1\x14\x6\xFFFF\x1\x1\x1\xFFFF\x1\x8\x1\xA\x6\xFFFF\x1\xD\x2"+
			"\xFFFF\x1\x7";
		private const string DFA8_specialS =
			"\x59\xFFFF}>";
		private static readonly string[] DFA8_transitionS =
			{
				"\x2\x16\x2\xFFFF\x1\x16\x12\xFFFF\x1\x16\x1\xFFFF\x1\x14\x5\xFFFF\x1"+
				"\xC\x1\xD\x1\x13\x3\xFFFF\x1\xE\x2\xFFFF\x9\x15\x1\x9\x1\xB\x1\xFFFF"+
				"\x1\xF\x2\xFFFF\x1\x4\x2\x13\x1\x6\x6\x13\x1\x5\x5\x13\x1\x8\x1\x13"+
				"\x1\x7\x8\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1\x1\x1\x12\x1\x11\x1\x13\x1"+
				"\x10\xA\x13\x1\xA\xA\x13\x1\x2\x1\xFFFF\x1\x3",
				"\x1\x18\xC\xFFFF\x1\x17",
				"",
				"\x1\x19",
				"",
				"\x1\x1B",
				"\x12\x13\x1\x1C\x7\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x1E",
				"\x1\x1F",
				"",
				"\x1\x20",
				"",
				"",
				"",
				"",
				"",
				"\x1\x21",
				"\x1\x22",
				"\x1\x23",
				"",
				"",
				"",
				"",
				"\x1\x24",
				"\x1\x25",
				"",
				"",
				"\x1\x26",
				"\x1\x27",
				"",
				"\x1\x28",
				"\x1\x29",
				"\x1\x2A",
				"\x1\x2B",
				"\x1\x2C",
				"\x1\x2D",
				"\x1\x2E",
				"\x1\x2F",
				"\x1\x30",
				"\x1\x31",
				"\x1\x32",
				"\x1\x33",
				"\x1\x34",
				"\x1\x35",
				"\x1\x36",
				"\x1\x37",
				"\x1\x38",
				"\x1\x39",
				"\x12\x13\x1\x3A\x7\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x3C",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x3E",
				"\x1\x3F",
				"\x1\x40",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x42",
				"\x1\x43",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x45",
				"",
				"\x1\x46",
				"",
				"\x1\x47",
				"\x1\x48",
				"\x1\x49",
				"",
				"\x1\x4A",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"",
				"\x1\x4C",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x4F",
				"\x1\x50",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"",
				"\x1\x51",
				"",
				"",
				"\x1\x52",
				"\x1\x53",
				"\x1\x54",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1\x56",
				"\x1\x57",
				"",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				"\x1A\x13\x4\xFFFF\x1\x13\x1\xFFFF\x1A\x13",
				""
			};

		private static readonly short[] DFA8_eot = DFA.UnpackEncodedString(DFA8_eotS);
		private static readonly short[] DFA8_eof = DFA.UnpackEncodedString(DFA8_eofS);
		private static readonly char[] DFA8_min = DFA.UnpackEncodedStringToUnsignedChars(DFA8_minS);
		private static readonly char[] DFA8_max = DFA.UnpackEncodedStringToUnsignedChars(DFA8_maxS);
		private static readonly short[] DFA8_accept = DFA.UnpackEncodedString(DFA8_acceptS);
		private static readonly short[] DFA8_special = DFA.UnpackEncodedString(DFA8_specialS);
		private static readonly short[][] DFA8_transition;

		static DFA8()
		{
			int numStates = DFA8_transitionS.Length;
			DFA8_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA8_transition[i] = DFA.UnpackEncodedString(DFA8_transitionS[i]);
			}
		}

		public DFA8( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 8;
			this.eot = DFA8_eot;
			this.eof = DFA8_eof;
			this.min = DFA8_min;
			this.max = DFA8_max;
			this.accept = DFA8_accept;
			this.special = DFA8_special;
			this.transition = DFA8_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | POINTCUT_TYPE_ELEMENT | ADVICE_TYPE_ELEMENT | IDENTIFIER | STRING | INTLITERAL | WS );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

 
	#endregion

}
