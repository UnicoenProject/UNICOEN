// $ANTLR 3.3 Nov 30, 2010 12:50:56 E1.g 2011-11-09 11:44:22

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
public partial class E1Lexer : Antlr.Runtime.Lexer
{
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

	public E1Lexer()
	{
		OnCreated();
	}

	public E1Lexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public E1Lexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "E1.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_T__9();
	partial void Leave_T__9();

	// $ANTLR start "T__9"
	[GrammarRule("T__9")]
	private void mT__9()
	{
		Enter_T__9();
		EnterRule("T__9", 1);
		TraceIn("T__9", 1);
		try
		{
			int _type = T__9;
			int _channel = DefaultTokenChannel;
			// E1.g:7:6: ( '+' )
			DebugEnterAlt(1);
			// E1.g:7:8: '+'
			{
			DebugLocation(7, 8);
			Match('+'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__9", 1);
			LeaveRule("T__9", 1);
			Leave_T__9();
		}
	}
	// $ANTLR end "T__9"

	partial void Enter_T__10();
	partial void Leave_T__10();

	// $ANTLR start "T__10"
	[GrammarRule("T__10")]
	private void mT__10()
	{
		Enter_T__10();
		EnterRule("T__10", 2);
		TraceIn("T__10", 2);
		try
		{
			int _type = T__10;
			int _channel = DefaultTokenChannel;
			// E1.g:8:7: ( '-' )
			DebugEnterAlt(1);
			// E1.g:8:9: '-'
			{
			DebugLocation(8, 9);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__10", 2);
			LeaveRule("T__10", 2);
			Leave_T__10();
		}
	}
	// $ANTLR end "T__10"

	partial void Enter_T__11();
	partial void Leave_T__11();

	// $ANTLR start "T__11"
	[GrammarRule("T__11")]
	private void mT__11()
	{
		Enter_T__11();
		EnterRule("T__11", 3);
		TraceIn("T__11", 3);
		try
		{
			int _type = T__11;
			int _channel = DefaultTokenChannel;
			// E1.g:9:7: ( '*' )
			DebugEnterAlt(1);
			// E1.g:9:9: '*'
			{
			DebugLocation(9, 9);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__11", 3);
			LeaveRule("T__11", 3);
			Leave_T__11();
		}
	}
	// $ANTLR end "T__11"

	partial void Enter_T__12();
	partial void Leave_T__12();

	// $ANTLR start "T__12"
	[GrammarRule("T__12")]
	private void mT__12()
	{
		Enter_T__12();
		EnterRule("T__12", 4);
		TraceIn("T__12", 4);
		try
		{
			int _type = T__12;
			int _channel = DefaultTokenChannel;
			// E1.g:10:7: ( '/' )
			DebugEnterAlt(1);
			// E1.g:10:9: '/'
			{
			DebugLocation(10, 9);
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__12", 4);
			LeaveRule("T__12", 4);
			Leave_T__12();
		}
	}
	// $ANTLR end "T__12"

	partial void Enter_T__13();
	partial void Leave_T__13();

	// $ANTLR start "T__13"
	[GrammarRule("T__13")]
	private void mT__13()
	{
		Enter_T__13();
		EnterRule("T__13", 5);
		TraceIn("T__13", 5);
		try
		{
			int _type = T__13;
			int _channel = DefaultTokenChannel;
			// E1.g:11:7: ( '^' )
			DebugEnterAlt(1);
			// E1.g:11:9: '^'
			{
			DebugLocation(11, 9);
			Match('^'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__13", 5);
			LeaveRule("T__13", 5);
			Leave_T__13();
		}
	}
	// $ANTLR end "T__13"

	partial void Enter_T__14();
	partial void Leave_T__14();

	// $ANTLR start "T__14"
	[GrammarRule("T__14")]
	private void mT__14()
	{
		Enter_T__14();
		EnterRule("T__14", 6);
		TraceIn("T__14", 6);
		try
		{
			int _type = T__14;
			int _channel = DefaultTokenChannel;
			// E1.g:12:7: ( '(' )
			DebugEnterAlt(1);
			// E1.g:12:9: '('
			{
			DebugLocation(12, 9);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__14", 6);
			LeaveRule("T__14", 6);
			Leave_T__14();
		}
	}
	// $ANTLR end "T__14"

	partial void Enter_T__15();
	partial void Leave_T__15();

	// $ANTLR start "T__15"
	[GrammarRule("T__15")]
	private void mT__15()
	{
		Enter_T__15();
		EnterRule("T__15", 7);
		TraceIn("T__15", 7);
		try
		{
			int _type = T__15;
			int _channel = DefaultTokenChannel;
			// E1.g:13:7: ( ')' )
			DebugEnterAlt(1);
			// E1.g:13:9: ')'
			{
			DebugLocation(13, 9);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("T__15", 7);
			LeaveRule("T__15", 7);
			Leave_T__15();
		}
	}
	// $ANTLR end "T__15"

	partial void Enter_LINE_COMMENT();
	partial void Leave_LINE_COMMENT();

	// $ANTLR start "LINE_COMMENT"
	[GrammarRule("LINE_COMMENT")]
	private void mLINE_COMMENT()
	{
		Enter_LINE_COMMENT();
		EnterRule("LINE_COMMENT", 8);
		TraceIn("LINE_COMMENT", 8);
		try
		{
			int _type = LINE_COMMENT;
			int _channel = DefaultTokenChannel;
			// E1.g:51:5: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r\\n' | '\\r' | '\\n' ) | '//' (~ ( '\\n' | '\\r' ) )* )
			int alt4=2;
			try { DebugEnterDecision(4, decisionCanBacktrack[4]);
			try
			{
				alt4 = dfa4.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(4); }
			switch (alt4)
			{
			case 1:
				DebugEnterAlt(1);
				// E1.g:51:9: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r\\n' | '\\r' | '\\n' )
				{
				DebugLocation(51, 9);
				Match("//"); 

				DebugLocation(51, 14);
				// E1.g:51:14: (~ ( '\\n' | '\\r' ) )*
				try { DebugEnterSubRule(1);
				while (true)
				{
					int alt1=2;
					try { DebugEnterDecision(1, decisionCanBacktrack[1]);
					int LA1_0 = input.LA(1);

					if (((LA1_0>='\u0000' && LA1_0<='\t')||(LA1_0>='\u000B' && LA1_0<='\f')||(LA1_0>='\u000E' && LA1_0<='\uFFFF')))
					{
						alt1=1;
					}


					} finally { DebugExitDecision(1); }
					switch ( alt1 )
					{
					case 1:
						DebugEnterAlt(1);
						// E1.g:51:14: ~ ( '\\n' | '\\r' )
						{
						DebugLocation(51, 14);
						if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='\uFFFF'))
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
						goto loop1;
					}
				}

				loop1:
					;

				} finally { DebugExitSubRule(1); }

				DebugLocation(51, 29);
				// E1.g:51:29: ( '\\r\\n' | '\\r' | '\\n' )
				int alt2=3;
				try { DebugEnterSubRule(2);
				try { DebugEnterDecision(2, decisionCanBacktrack[2]);
				int LA2_0 = input.LA(1);

				if ((LA2_0=='\r'))
				{
					int LA2_1 = input.LA(2);

					if ((LA2_1=='\n'))
					{
						alt2=1;
					}
					else
					{
						alt2=2;}
				}
				else if ((LA2_0=='\n'))
				{
					alt2=3;
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
					// E1.g:51:30: '\\r\\n'
					{
					DebugLocation(51, 30);
					Match("\r\n"); 


					}
					break;
				case 2:
					DebugEnterAlt(2);
					// E1.g:51:39: '\\r'
					{
					DebugLocation(51, 39);
					Match('\r'); 

					}
					break;
				case 3:
					DebugEnterAlt(3);
					// E1.g:51:46: '\\n'
					{
					DebugLocation(51, 46);
					Match('\n'); 

					}
					break;

				}
				} finally { DebugExitSubRule(2); }

				DebugLocation(52, 13);

				_channel=Hidden;
				            

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// E1.g:55:9: '//' (~ ( '\\n' | '\\r' ) )*
				{
				DebugLocation(55, 9);
				Match("//"); 

				DebugLocation(55, 14);
				// E1.g:55:14: (~ ( '\\n' | '\\r' ) )*
				try { DebugEnterSubRule(3);
				while (true)
				{
					int alt3=2;
					try { DebugEnterDecision(3, decisionCanBacktrack[3]);
					int LA3_0 = input.LA(1);

					if (((LA3_0>='\u0000' && LA3_0<='\t')||(LA3_0>='\u000B' && LA3_0<='\f')||(LA3_0>='\u000E' && LA3_0<='\uFFFF')))
					{
						alt3=1;
					}


					} finally { DebugExitDecision(3); }
					switch ( alt3 )
					{
					case 1:
						DebugEnterAlt(1);
						// E1.g:55:14: ~ ( '\\n' | '\\r' )
						{
						DebugLocation(55, 14);
						if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='\uFFFF'))
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
						goto loop3;
					}
				}

				loop3:
					;

				} finally { DebugExitSubRule(3); }

				DebugLocation(56, 13);

				_channel=Hidden;
				            

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LINE_COMMENT", 8);
			LeaveRule("LINE_COMMENT", 8);
			Leave_LINE_COMMENT();
		}
	}
	// $ANTLR end "LINE_COMMENT"

	partial void Enter_IDENTIFIER();
	partial void Leave_IDENTIFIER();

	// $ANTLR start "IDENTIFIER"
	[GrammarRule("IDENTIFIER")]
	private void mIDENTIFIER()
	{
		Enter_IDENTIFIER();
		EnterRule("IDENTIFIER", 9);
		TraceIn("IDENTIFIER", 9);
		try
		{
			int _type = IDENTIFIER;
			int _channel = DefaultTokenChannel;
			// E1.g:61:12: ( ( 'a' .. 'z' | 'A' .. 'Z' )+ )
			DebugEnterAlt(1);
			// E1.g:61:16: ( 'a' .. 'z' | 'A' .. 'Z' )+
			{
			DebugLocation(61, 16);
			// E1.g:61:16: ( 'a' .. 'z' | 'A' .. 'Z' )+
			int cnt5=0;
			try { DebugEnterSubRule(5);
			while (true)
			{
				int alt5=2;
				try { DebugEnterDecision(5, decisionCanBacktrack[5]);
				int LA5_0 = input.LA(1);

				if (((LA5_0>='A' && LA5_0<='Z')||(LA5_0>='a' && LA5_0<='z')))
				{
					alt5=1;
				}


				} finally { DebugExitDecision(5); }
				switch (alt5)
				{
				case 1:
					DebugEnterAlt(1);
					// E1.g:
					{
					DebugLocation(61, 16);
					if ((input.LA(1)>='A' && input.LA(1)<='Z')||(input.LA(1)>='a' && input.LA(1)<='z'))
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


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IDENTIFIER", 9);
			LeaveRule("IDENTIFIER", 9);
			Leave_IDENTIFIER();
		}
	}
	// $ANTLR end "IDENTIFIER"

	partial void Enter_CONSTANT();
	partial void Leave_CONSTANT();

	// $ANTLR start "CONSTANT"
	[GrammarRule("CONSTANT")]
	private void mCONSTANT()
	{
		Enter_CONSTANT();
		EnterRule("CONSTANT", 10);
		TraceIn("CONSTANT", 10);
		try
		{
			int _type = CONSTANT;
			int _channel = DefaultTokenChannel;
			// E1.g:62:10: ( ( '0' .. '9' )+ )
			DebugEnterAlt(1);
			// E1.g:62:14: ( '0' .. '9' )+
			{
			DebugLocation(62, 14);
			// E1.g:62:14: ( '0' .. '9' )+
			int cnt6=0;
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
				switch (alt6)
				{
				case 1:
					DebugEnterAlt(1);
					// E1.g:62:14: '0' .. '9'
					{
					DebugLocation(62, 14);
					MatchRange('0','9'); 

					}
					break;

				default:
					if (cnt6 >= 1)
						goto loop6;

					EarlyExitException eee6 = new EarlyExitException( 6, input );
					DebugRecognitionException(eee6);
					throw eee6;
				}
				cnt6++;
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
			TraceOut("CONSTANT", 10);
			LeaveRule("CONSTANT", 10);
			Leave_CONSTANT();
		}
	}
	// $ANTLR end "CONSTANT"

	partial void Enter_NEWLINE();
	partial void Leave_NEWLINE();

	// $ANTLR start "NEWLINE"
	[GrammarRule("NEWLINE")]
	private void mNEWLINE()
	{
		Enter_NEWLINE();
		EnterRule("NEWLINE", 11);
		TraceIn("NEWLINE", 11);
		try
		{
			int _type = NEWLINE;
			int _channel = DefaultTokenChannel;
			// E1.g:63:10: ( ( '\\r' )? '\\n' )
			DebugEnterAlt(1);
			// E1.g:63:14: ( '\\r' )? '\\n'
			{
			DebugLocation(63, 14);
			// E1.g:63:14: ( '\\r' )?
			int alt7=2;
			try { DebugEnterSubRule(7);
			try { DebugEnterDecision(7, decisionCanBacktrack[7]);
			int LA7_0 = input.LA(1);

			if ((LA7_0=='\r'))
			{
				alt7=1;
			}
			} finally { DebugExitDecision(7); }
			switch (alt7)
			{
			case 1:
				DebugEnterAlt(1);
				// E1.g:63:14: '\\r'
				{
				DebugLocation(63, 14);
				Match('\r'); 

				}
				break;

			}
			} finally { DebugExitSubRule(7); }

			DebugLocation(63, 20);
			Match('\n'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NEWLINE", 11);
			LeaveRule("NEWLINE", 11);
			Leave_NEWLINE();
		}
	}
	// $ANTLR end "NEWLINE"

	partial void Enter_WS();
	partial void Leave_WS();

	// $ANTLR start "WS"
	[GrammarRule("WS")]
	private void mWS()
	{
		Enter_WS();
		EnterRule("WS", 12);
		TraceIn("WS", 12);
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// E1.g:64:6: ( ( ' ' | '\\t' )+ )
			DebugEnterAlt(1);
			// E1.g:64:10: ( ' ' | '\\t' )+
			{
			DebugLocation(64, 10);
			// E1.g:64:10: ( ' ' | '\\t' )+
			int cnt8=0;
			try { DebugEnterSubRule(8);
			while (true)
			{
				int alt8=2;
				try { DebugEnterDecision(8, decisionCanBacktrack[8]);
				int LA8_0 = input.LA(1);

				if ((LA8_0=='\t'||LA8_0==' '))
				{
					alt8=1;
				}


				} finally { DebugExitDecision(8); }
				switch (alt8)
				{
				case 1:
					DebugEnterAlt(1);
					// E1.g:
					{
					DebugLocation(64, 10);
					if (input.LA(1)=='\t'||input.LA(1)==' ')
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
					if (cnt8 >= 1)
						goto loop8;

					EarlyExitException eee8 = new EarlyExitException( 8, input );
					DebugRecognitionException(eee8);
					throw eee8;
				}
				cnt8++;
			}
			loop8:
				;

			} finally { DebugExitSubRule(8); }

			DebugLocation(64, 22);
			Skip();

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WS", 12);
			LeaveRule("WS", 12);
			Leave_WS();
		}
	}
	// $ANTLR end "WS"

	public override void mTokens()
	{
		// E1.g:1:8: ( T__9 | T__10 | T__11 | T__12 | T__13 | T__14 | T__15 | LINE_COMMENT | IDENTIFIER | CONSTANT | NEWLINE | WS )
		int alt9=12;
		try { DebugEnterDecision(9, decisionCanBacktrack[9]);
		try
		{
			alt9 = dfa9.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(9); }
		switch (alt9)
		{
		case 1:
			DebugEnterAlt(1);
			// E1.g:1:10: T__9
			{
			DebugLocation(1, 10);
			mT__9(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// E1.g:1:15: T__10
			{
			DebugLocation(1, 15);
			mT__10(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// E1.g:1:21: T__11
			{
			DebugLocation(1, 21);
			mT__11(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// E1.g:1:27: T__12
			{
			DebugLocation(1, 27);
			mT__12(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// E1.g:1:33: T__13
			{
			DebugLocation(1, 33);
			mT__13(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// E1.g:1:39: T__14
			{
			DebugLocation(1, 39);
			mT__14(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// E1.g:1:45: T__15
			{
			DebugLocation(1, 45);
			mT__15(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// E1.g:1:51: LINE_COMMENT
			{
			DebugLocation(1, 51);
			mLINE_COMMENT(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// E1.g:1:64: IDENTIFIER
			{
			DebugLocation(1, 64);
			mIDENTIFIER(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// E1.g:1:75: CONSTANT
			{
			DebugLocation(1, 75);
			mCONSTANT(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// E1.g:1:84: NEWLINE
			{
			DebugLocation(1, 84);
			mNEWLINE(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// E1.g:1:92: WS
			{
			DebugLocation(1, 92);
			mWS(); 

			}
			break;

		}

	}


	#region DFA
	DFA4 dfa4;
	DFA9 dfa9;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa4 = new DFA4(this, SpecialStateTransition4);
		dfa9 = new DFA9(this);
	}

	private class DFA4 : DFA
	{
		private const string DFA4_eotS =
			"\x2\xFFFF\x2\x5\x2\xFFFF";
		private const string DFA4_eofS =
			"\x6\xFFFF";
		private const string DFA4_minS =
			"\x2\x2F\x2\x0\x2\xFFFF";
		private const string DFA4_maxS =
			"\x2\x2F\x2\xFFFF\x2\xFFFF";
		private const string DFA4_acceptS =
			"\x4\xFFFF\x1\x1\x1\x2";
		private const string DFA4_specialS =
			"\x2\xFFFF\x1\x1\x1\x0\x2\xFFFF}>";
		private static readonly string[] DFA4_transitionS =
			{
				"\x1\x1",
				"\x1\x2",
				"\xA\x3\x1\x4\x2\x3\x1\x4\xFFF2\x3",
				"\xA\x3\x1\x4\x2\x3\x1\x4\xFFF2\x3",
				"",
				""
			};

		private static readonly short[] DFA4_eot = DFA.UnpackEncodedString(DFA4_eotS);
		private static readonly short[] DFA4_eof = DFA.UnpackEncodedString(DFA4_eofS);
		private static readonly char[] DFA4_min = DFA.UnpackEncodedStringToUnsignedChars(DFA4_minS);
		private static readonly char[] DFA4_max = DFA.UnpackEncodedStringToUnsignedChars(DFA4_maxS);
		private static readonly short[] DFA4_accept = DFA.UnpackEncodedString(DFA4_acceptS);
		private static readonly short[] DFA4_special = DFA.UnpackEncodedString(DFA4_specialS);
		private static readonly short[][] DFA4_transition;

		static DFA4()
		{
			int numStates = DFA4_transitionS.Length;
			DFA4_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA4_transition[i] = DFA.UnpackEncodedString(DFA4_transitionS[i]);
			}
		}

		public DFA4( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 4;
			this.eot = DFA4_eot;
			this.eof = DFA4_eof;
			this.min = DFA4_min;
			this.max = DFA4_max;
			this.accept = DFA4_accept;
			this.special = DFA4_special;
			this.transition = DFA4_transition;
		}

		public override string Description { get { return "50:1: LINE_COMMENT : ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r\\n' | '\\r' | '\\n' ) | '//' (~ ( '\\n' | '\\r' ) )* );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition4(DFA dfa, int s, IIntStream _input)
	{
		IIntStream input = _input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA4_3 = input.LA(1);

				s = -1;
				if ( (LA4_3=='\n'||LA4_3=='\r') ) {s = 4;}

				else if ( ((LA4_3>='\u0000' && LA4_3<='\t')||(LA4_3>='\u000B' && LA4_3<='\f')||(LA4_3>='\u000E' && LA4_3<='\uFFFF')) ) {s = 3;}

				else s = 5;

				if ( s>=0 ) return s;
				break;
			case 1:
				int LA4_2 = input.LA(1);

				s = -1;
				if ( ((LA4_2>='\u0000' && LA4_2<='\t')||(LA4_2>='\u000B' && LA4_2<='\f')||(LA4_2>='\u000E' && LA4_2<='\uFFFF')) ) {s = 3;}

				else if ( (LA4_2=='\n'||LA4_2=='\r') ) {s = 4;}

				else s = 5;

				if ( s>=0 ) return s;
				break;
		}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 4, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
	private class DFA9 : DFA
	{
		private const string DFA9_eotS =
			"\x4\xFFFF\x1\xD\x9\xFFFF";
		private const string DFA9_eofS =
			"\xE\xFFFF";
		private const string DFA9_minS =
			"\x1\x9\x3\xFFFF\x1\x2F\x9\xFFFF";
		private const string DFA9_maxS =
			"\x1\x7A\x3\xFFFF\x1\x2F\x9\xFFFF";
		private const string DFA9_acceptS =
			"\x1\xFFFF\x1\x1\x1\x2\x1\x3\x1\xFFFF\x1\x5\x1\x6\x1\x7\x1\x9\x1\xA\x1"+
			"\xB\x1\xC\x1\x8\x1\x4";
		private const string DFA9_specialS =
			"\xE\xFFFF}>";
		private static readonly string[] DFA9_transitionS =
			{
				"\x1\xB\x1\xA\x2\xFFFF\x1\xA\x12\xFFFF\x1\xB\x7\xFFFF\x1\x6\x1\x7\x1"+
				"\x3\x1\x1\x1\xFFFF\x1\x2\x1\xFFFF\x1\x4\xA\x9\x7\xFFFF\x1A\x8\x3\xFFFF"+
				"\x1\x5\x2\xFFFF\x1A\x8",
				"",
				"",
				"",
				"\x1\xC",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				""
			};

		private static readonly short[] DFA9_eot = DFA.UnpackEncodedString(DFA9_eotS);
		private static readonly short[] DFA9_eof = DFA.UnpackEncodedString(DFA9_eofS);
		private static readonly char[] DFA9_min = DFA.UnpackEncodedStringToUnsignedChars(DFA9_minS);
		private static readonly char[] DFA9_max = DFA.UnpackEncodedStringToUnsignedChars(DFA9_maxS);
		private static readonly short[] DFA9_accept = DFA.UnpackEncodedString(DFA9_acceptS);
		private static readonly short[] DFA9_special = DFA.UnpackEncodedString(DFA9_specialS);
		private static readonly short[][] DFA9_transition;

		static DFA9()
		{
			int numStates = DFA9_transitionS.Length;
			DFA9_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA9_transition[i] = DFA.UnpackEncodedString(DFA9_transitionS[i]);
			}
		}

		public DFA9( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 9;
			this.eot = DFA9_eot;
			this.eof = DFA9_eof;
			this.min = DFA9_min;
			this.max = DFA9_max;
			this.accept = DFA9_accept;
			this.special = DFA9_special;
			this.transition = DFA9_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( T__9 | T__10 | T__11 | T__12 | T__13 | T__14 | T__15 | LINE_COMMENT | IDENTIFIER | CONSTANT | NEWLINE | WS );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

 
	#endregion

}
