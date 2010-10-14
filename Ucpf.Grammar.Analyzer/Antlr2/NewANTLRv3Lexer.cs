// $ANTLR 3.2 Sep 23, 2009 12:02:23 NewANTLRv3.g 2010-08-28 18:58:59

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using Antlr.Runtime;

namespace Ucpf.Grammar.Analyzer.Antlr2
{
	public partial class NewANTLRv3Lexer : Lexer {
		public const int T__64 = 64;
		public const int NESTED_ACTION = 27;
		public const int T__65 = 65;
		public const int T__62 = 62;
		public const int T__63 = 63;
		public const int DOUBLE_ANGLE_STRING_LITERAL = 17;
		public const int ESC = 22;
		public const int T__61 = 61;
		public const int T__60 = 60;
		public const int EOF = -1;
		public const int SEMPRED = 13;
		public const int ACTION = 9;
		public const int TOKEN_REF = 6;
		public const int T__55 = 55;
		public const int T__56 = 56;
		public const int ML_COMMENT = 20;
		public const int T__57 = 57;
		public const int T__58 = 58;
		public const int T__51 = 51;
		public const int STRING_LITERAL = 7;
		public const int T__52 = 52;
		public const int T__53 = 53;
		public const int T__54 = 54;
		public const int T__59 = 59;
		public const int ARG_ACTION = 12;
		public const int DOC_COMMENT = 4;
		public const int DOUBLE_QUOTE_STRING_LITERAL = 16;
		public const int NESTED_ARG_ACTION = 24;
		public const int T__50 = 50;
		public const int ACTION_CHAR_LITERAL = 26;
		public const int T__42 = 42;
		public const int T__43 = 43;
		public const int T__40 = 40;
		public const int T__41 = 41;
		public const int T__46 = 46;
		public const int T__47 = 47;
		public const int T__44 = 44;
		public const int ACTION_ESC = 28;
		public const int T__45 = 45;
		public const int T__48 = 48;
		public const int T__49 = 49;
		public const int SRC = 18;
		public const int TOKENS = 5;
		public const int RANGE = 15;
		public const int WS_LOOP = 29;
		public const int LITERAL_CHAR = 21;
		public const int INT = 11;
		public const int ACTION_STRING_LITERAL = 25;
		public const int RULE_REF = 14;
		public const int T__31 = 31;
		public const int T__32 = 32;
		public const int T__33 = 33;
		public const int WS = 30;
		public const int T__34 = 34;
		public const int T__35 = 35;
		public const int CHAR_LITERAL = 8;
		public const int T__36 = 36;
		public const int T__37 = 37;
		public const int T__38 = 38;
		public const int T__39 = 39;
		public const int XDIGIT = 23;
		public const int SL_COMMENT = 19;
		public const int OPTIONS = 10;

		// delegates
		// delegators

		public NewANTLRv3Lexer() 
		{
			InitializeCyclicDFAs();
		}
		public NewANTLRv3Lexer(ICharStream input)
			: this(input, null) {
			}
		public NewANTLRv3Lexer(ICharStream input, RecognizerSharedState state)
			: base(input, state) {
			InitializeCyclicDFAs(); 

			}
    
		override public string GrammarFileName
		{
			get { return "NewANTLRv3.g";} 
		}

		// $ANTLR start "T__31"
		public void mT__31() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__31;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:7:7: ( 'lexer' )
				// NewANTLRv3.g:7:9: 'lexer'
				{
					Match("lexer"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__31"

		// $ANTLR start "T__32"
		public void mT__32() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__32;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:8:7: ( 'parser' )
				// NewANTLRv3.g:8:9: 'parser'
				{
					Match("parser"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__32"

		// $ANTLR start "T__33"
		public void mT__33() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__33;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:9:7: ( 'tree' )
				// NewANTLRv3.g:9:9: 'tree'
				{
					Match("tree"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__33"

		// $ANTLR start "T__34"
		public void mT__34() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__34;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:10:7: ( 'grammar' )
				// NewANTLRv3.g:10:9: 'grammar'
				{
					Match("grammar"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__34"

		// $ANTLR start "T__35"
		public void mT__35() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__35;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:11:7: ( ';' )
				// NewANTLRv3.g:11:9: ';'
				{
					Match(';'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__35"

		// $ANTLR start "T__36"
		public void mT__36() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__36;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:12:7: ( '}' )
				// NewANTLRv3.g:12:9: '}'
				{
					Match('}'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__36"

		// $ANTLR start "T__37"
		public void mT__37() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__37;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:13:7: ( '=' )
				// NewANTLRv3.g:13:9: '='
				{
					Match('='); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__37"

		// $ANTLR start "T__38"
		public void mT__38() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__38;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:14:7: ( 'scope' )
				// NewANTLRv3.g:14:9: 'scope'
				{
					Match("scope"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__38"

		// $ANTLR start "T__39"
		public void mT__39() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__39;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:15:7: ( '@' )
				// NewANTLRv3.g:15:9: '@'
				{
					Match('@'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__39"

		// $ANTLR start "T__40"
		public void mT__40() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__40;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:16:7: ( '::' )
				// NewANTLRv3.g:16:9: '::'
				{
					Match("::"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__40"

		// $ANTLR start "T__41"
		public void mT__41() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__41;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:17:7: ( '*' )
				// NewANTLRv3.g:17:9: '*'
				{
					Match('*'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__41"

		// $ANTLR start "T__42"
		public void mT__42() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__42;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:18:7: ( 'protected' )
				// NewANTLRv3.g:18:9: 'protected'
				{
					Match("protected"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__42"

		// $ANTLR start "T__43"
		public void mT__43() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__43;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:19:7: ( 'public' )
				// NewANTLRv3.g:19:9: 'public'
				{
					Match("public"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__43"

		// $ANTLR start "T__44"
		public void mT__44() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__44;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:20:7: ( 'private' )
				// NewANTLRv3.g:20:9: 'private'
				{
					Match("private"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__44"

		// $ANTLR start "T__45"
		public void mT__45() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__45;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:21:7: ( 'fragment' )
				// NewANTLRv3.g:21:9: 'fragment'
				{
					Match("fragment"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__45"

		// $ANTLR start "T__46"
		public void mT__46() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__46;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:22:7: ( '!' )
				// NewANTLRv3.g:22:9: '!'
				{
					Match('!'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__46"

		// $ANTLR start "T__47"
		public void mT__47() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__47;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:23:7: ( 'returns' )
				// NewANTLRv3.g:23:9: 'returns'
				{
					Match("returns"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__47"

		// $ANTLR start "T__48"
		public void mT__48() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__48;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:24:7: ( ':' )
				// NewANTLRv3.g:24:9: ':'
				{
					Match(':'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__48"

		// $ANTLR start "T__49"
		public void mT__49() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__49;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:25:7: ( 'throws' )
				// NewANTLRv3.g:25:9: 'throws'
				{
					Match("throws"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__49"

		// $ANTLR start "T__50"
		public void mT__50() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__50;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:26:7: ( ',' )
				// NewANTLRv3.g:26:9: ','
				{
					Match(','); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__50"

		// $ANTLR start "T__51"
		public void mT__51() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__51;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:27:7: ( '(' )
				// NewANTLRv3.g:27:9: '('
				{
					Match('('); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__51"

		// $ANTLR start "T__52"
		public void mT__52() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__52;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:28:7: ( '|' )
				// NewANTLRv3.g:28:9: '|'
				{
					Match('|'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__52"

		// $ANTLR start "T__53"
		public void mT__53() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__53;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:29:7: ( ')' )
				// NewANTLRv3.g:29:9: ')'
				{
					Match(')'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__53"

		// $ANTLR start "T__54"
		public void mT__54() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__54;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:30:7: ( 'catch' )
				// NewANTLRv3.g:30:9: 'catch'
				{
					Match("catch"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__54"

		// $ANTLR start "T__55"
		public void mT__55() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__55;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:31:7: ( 'finally' )
				// NewANTLRv3.g:31:9: 'finally'
				{
					Match("finally"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__55"

		// $ANTLR start "T__56"
		public void mT__56() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__56;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:32:7: ( '+=' )
				// NewANTLRv3.g:32:9: '+='
				{
					Match("+="); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__56"

		// $ANTLR start "T__57"
		public void mT__57() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__57;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:33:7: ( '=>' )
				// NewANTLRv3.g:33:9: '=>'
				{
					Match("=>"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__57"

		// $ANTLR start "T__58"
		public void mT__58() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__58;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:34:7: ( '^' )
				// NewANTLRv3.g:34:9: '^'
				{
					Match('^'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__58"

		// $ANTLR start "T__59"
		public void mT__59() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__59;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:35:7: ( '~' )
				// NewANTLRv3.g:35:9: '~'
				{
					Match('~'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__59"

		// $ANTLR start "T__60"
		public void mT__60() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__60;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:36:7: ( '^(' )
				// NewANTLRv3.g:36:9: '^('
				{
					Match("^("); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__60"

		// $ANTLR start "T__61"
		public void mT__61() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__61;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:37:7: ( '?' )
				// NewANTLRv3.g:37:9: '?'
				{
					Match('?'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__61"

		// $ANTLR start "T__62"
		public void mT__62() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__62;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:38:7: ( '+' )
				// NewANTLRv3.g:38:9: '+'
				{
					Match('+'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__62"

		// $ANTLR start "T__63"
		public void mT__63() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__63;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:39:7: ( '.' )
				// NewANTLRv3.g:39:9: '.'
				{
					Match('.'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__63"

		// $ANTLR start "T__64"
		public void mT__64() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__64;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:40:7: ( '->' )
				// NewANTLRv3.g:40:9: '->'
				{
					Match("->"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__64"

		// $ANTLR start "T__65"
		public void mT__65() // throws RecognitionException [2]
		{
			try
			{
				int _type = T__65;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:41:7: ( '$' )
				// NewANTLRv3.g:41:9: '$'
				{
					Match('$'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "T__65"

		// $ANTLR start "SL_COMMENT"
		public void mSL_COMMENT() // throws RecognitionException [2]
		{
			try
			{
				int _type = SL_COMMENT;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:378:3: ( '//' ( ' $ANTLR ' SRC | (~ ( '\\r' | '\\n' ) )* ) ( '\\r' )? '\\n' )
				// NewANTLRv3.g:378:5: '//' ( ' $ANTLR ' SRC | (~ ( '\\r' | '\\n' ) )* ) ( '\\r' )? '\\n'
				{
					Match("//"); 

					// NewANTLRv3.g:379:5: ( ' $ANTLR ' SRC | (~ ( '\\r' | '\\n' ) )* )
					int alt2 = 2;
					alt2 = dfa2.Predict(input);
					switch (alt2) 
					{
					case 1 :
						// NewANTLRv3.g:379:7: ' $ANTLR ' SRC
					{
						Match(" $ANTLR "); 

						mSRC(); 

					}
						break;
					case 2 :
						// NewANTLRv3.g:380:6: (~ ( '\\r' | '\\n' ) )*
					{
						// NewANTLRv3.g:380:6: (~ ( '\\r' | '\\n' ) )*
						do 
						{
							int alt1 = 2;
							int LA1_0 = input.LA(1);

							if ( ((LA1_0 >= '\u0000' && LA1_0 <= '\t') || (LA1_0 >= '\u000B' && LA1_0 <= '\f') || (LA1_0 >= '\u000E' && LA1_0 <= '\uFFFF')) )
							{
								alt1 = 1;
							}


							switch (alt1) 
							{
							case 1 :
								// NewANTLRv3.g:380:6: ~ ( '\\r' | '\\n' )
							{
								if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFF') ) 
								{
									input.Consume();

								}
								else 
								{
									MismatchedSetException mse = new MismatchedSetException(null,input);
									Recover(mse);
									throw mse;}


							}
								break;

							default:
								goto loop1;
							}
						} while (true);

						loop1:
						;	// Stops C# compiler whining that label 'loop1' has no statements


					}
						break;

					}

					// NewANTLRv3.g:382:3: ( '\\r' )?
					int alt3 = 2;
					int LA3_0 = input.LA(1);

					if ( (LA3_0 == '\r') )
					{
						alt3 = 1;
					}
					switch (alt3) 
					{
					case 1 :
						// NewANTLRv3.g:382:3: '\\r'
					{
						Match('\r'); 

					}
						break;

					}

					Match('\n'); 
					_channel=HIDDEN;

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "SL_COMMENT"

		// $ANTLR start "ML_COMMENT"
		public void mML_COMMENT() // throws RecognitionException [2]
		{
			try
			{
				int _type = ML_COMMENT;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:387:2: ( '/*' ( . )* '*/' )
				// NewANTLRv3.g:387:4: '/*' ( . )* '*/'
				{
					Match("/*"); 

					if (input.LA(1)=='*') _type=DOC_COMMENT; else _channel=HIDDEN;
					// NewANTLRv3.g:387:74: ( . )*
					do 
					{
						int alt4 = 2;
						int LA4_0 = input.LA(1);

						if ( (LA4_0 == '*') )
						{
							int LA4_1 = input.LA(2);

							if ( (LA4_1 == '/') )
							{
								alt4 = 2;
							}
							else if ( ((LA4_1 >= '\u0000' && LA4_1 <= '.') || (LA4_1 >= '0' && LA4_1 <= '\uFFFF')) )
							{
								alt4 = 1;
							}


						}
						else if ( ((LA4_0 >= '\u0000' && LA4_0 <= ')') || (LA4_0 >= '+' && LA4_0 <= '\uFFFF')) )
						{
							alt4 = 1;
						}


						switch (alt4) 
						{
						case 1 :
							// NewANTLRv3.g:387:74: .
						{
							MatchAny(); 

						}
							break;

						default:
							goto loop4;
						}
					} while (true);

					loop4:
					;	// Stops C# compiler whining that label 'loop4' has no statements

					Match("*/"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "ML_COMMENT"

		// $ANTLR start "CHAR_LITERAL"
		public void mCHAR_LITERAL() // throws RecognitionException [2]
		{
			try
			{
				int _type = CHAR_LITERAL;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:391:2: ( '\\'' LITERAL_CHAR '\\'' )
				// NewANTLRv3.g:391:4: '\\'' LITERAL_CHAR '\\''
				{
					Match('\''); 
					mLITERAL_CHAR(); 
					Match('\''); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "CHAR_LITERAL"

		// $ANTLR start "STRING_LITERAL"
		public void mSTRING_LITERAL() // throws RecognitionException [2]
		{
			try
			{
				int _type = STRING_LITERAL;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:395:2: ( '\\'' LITERAL_CHAR ( LITERAL_CHAR )* '\\'' )
				// NewANTLRv3.g:395:4: '\\'' LITERAL_CHAR ( LITERAL_CHAR )* '\\''
				{
					Match('\''); 
					mLITERAL_CHAR(); 
					// NewANTLRv3.g:395:22: ( LITERAL_CHAR )*
					do 
					{
						int alt5 = 2;
						int LA5_0 = input.LA(1);

						if ( ((LA5_0 >= '\u0000' && LA5_0 <= '&') || (LA5_0 >= '(' && LA5_0 <= '\uFFFF')) )
						{
							alt5 = 1;
						}


						switch (alt5) 
						{
						case 1 :
							// NewANTLRv3.g:395:22: LITERAL_CHAR
						{
							mLITERAL_CHAR(); 

						}
							break;

						default:
							goto loop5;
						}
					} while (true);

					loop5:
					;	// Stops C# compiler whining that label 'loop5' has no statements

					Match('\''); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "STRING_LITERAL"

		// $ANTLR start "LITERAL_CHAR"
		public void mLITERAL_CHAR() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:400:2: ( ESC | ~ ( '\\'' | '\\\\' ) )
				int alt6 = 2;
				int LA6_0 = input.LA(1);

				if ( (LA6_0 == '\\') )
				{
					alt6 = 1;
				}
				else if ( ((LA6_0 >= '\u0000' && LA6_0 <= '&') || (LA6_0 >= '(' && LA6_0 <= '[') || (LA6_0 >= ']' && LA6_0 <= '\uFFFF')) )
				{
					alt6 = 2;
				}
				else 
				{
					NoViableAltException nvae_d6s0 =
						new NoViableAltException("", 6, 0, input);

					throw nvae_d6s0;
				}
				switch (alt6) 
				{
				case 1 :
					// NewANTLRv3.g:400:4: ESC
				{
					mESC(); 

				}
					break;
				case 2 :
					// NewANTLRv3.g:401:4: ~ ( '\\'' | '\\\\' )
				{
					if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
					{
						input.Consume();

					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						Recover(mse);
						throw mse;}


				}
					break;

				}
			}
			finally 
			{
			}
		}
		// $ANTLR end "LITERAL_CHAR"

		// $ANTLR start "DOUBLE_QUOTE_STRING_LITERAL"
		public void mDOUBLE_QUOTE_STRING_LITERAL() // throws RecognitionException [2]
		{
			try
			{
				int _type = DOUBLE_QUOTE_STRING_LITERAL;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:405:2: ( '\"' ( ESC | ~ ( '\\\\' | '\"' ) )* '\"' )
				// NewANTLRv3.g:405:4: '\"' ( ESC | ~ ( '\\\\' | '\"' ) )* '\"'
				{
					Match('\"'); 
					// NewANTLRv3.g:405:8: ( ESC | ~ ( '\\\\' | '\"' ) )*
					do 
					{
						int alt7 = 3;
						int LA7_0 = input.LA(1);

						if ( (LA7_0 == '\\') )
						{
							alt7 = 1;
						}
						else if ( ((LA7_0 >= '\u0000' && LA7_0 <= '!') || (LA7_0 >= '#' && LA7_0 <= '[') || (LA7_0 >= ']' && LA7_0 <= '\uFFFF')) )
						{
							alt7 = 2;
						}


						switch (alt7) 
						{
						case 1 :
							// NewANTLRv3.g:405:9: ESC
						{
							mESC(); 

						}
							break;
						case 2 :
							// NewANTLRv3.g:405:15: ~ ( '\\\\' | '\"' )
						{
							if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
							{
								input.Consume();

							}
							else 
							{
								MismatchedSetException mse = new MismatchedSetException(null,input);
								Recover(mse);
								throw mse;}


						}
							break;

						default:
							goto loop7;
						}
					} while (true);

					loop7:
					;	// Stops C# compiler whining that label 'loop7' has no statements

					Match('\"'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "DOUBLE_QUOTE_STRING_LITERAL"

		// $ANTLR start "DOUBLE_ANGLE_STRING_LITERAL"
		public void mDOUBLE_ANGLE_STRING_LITERAL() // throws RecognitionException [2]
		{
			try
			{
				int _type = DOUBLE_ANGLE_STRING_LITERAL;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:409:2: ( '<<' ( . )* '>>' )
				// NewANTLRv3.g:409:4: '<<' ( . )* '>>'
				{
					Match("<<"); 

					// NewANTLRv3.g:409:9: ( . )*
					do 
					{
						int alt8 = 2;
						int LA8_0 = input.LA(1);

						if ( (LA8_0 == '>') )
						{
							int LA8_1 = input.LA(2);

							if ( (LA8_1 == '>') )
							{
								alt8 = 2;
							}
							else if ( ((LA8_1 >= '\u0000' && LA8_1 <= '=') || (LA8_1 >= '?' && LA8_1 <= '\uFFFF')) )
							{
								alt8 = 1;
							}


						}
						else if ( ((LA8_0 >= '\u0000' && LA8_0 <= '=') || (LA8_0 >= '?' && LA8_0 <= '\uFFFF')) )
						{
							alt8 = 1;
						}


						switch (alt8) 
						{
						case 1 :
							// NewANTLRv3.g:409:9: .
						{
							MatchAny(); 

						}
							break;

						default:
							goto loop8;
						}
					} while (true);

					loop8:
					;	// Stops C# compiler whining that label 'loop8' has no statements

					Match(">>"); 


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "DOUBLE_ANGLE_STRING_LITERAL"

		// $ANTLR start "ESC"
		public void mESC() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:413:5: ( '\\\\' ( 'n' | 'r' | 't' | 'b' | 'f' | '\"' | '\\'' | '\\\\' | '>' | 'u' XDIGIT XDIGIT XDIGIT XDIGIT | . ) )
				// NewANTLRv3.g:413:7: '\\\\' ( 'n' | 'r' | 't' | 'b' | 'f' | '\"' | '\\'' | '\\\\' | '>' | 'u' XDIGIT XDIGIT XDIGIT XDIGIT | . )
				{
					Match('\\'); 
					// NewANTLRv3.g:414:3: ( 'n' | 'r' | 't' | 'b' | 'f' | '\"' | '\\'' | '\\\\' | '>' | 'u' XDIGIT XDIGIT XDIGIT XDIGIT | . )
					int alt9 = 11;
					alt9 = dfa9.Predict(input);
					switch (alt9) 
					{
					case 1 :
						// NewANTLRv3.g:414:5: 'n'
					{
						Match('n'); 

					}
						break;
					case 2 :
						// NewANTLRv3.g:415:5: 'r'
					{
						Match('r'); 

					}
						break;
					case 3 :
						// NewANTLRv3.g:416:5: 't'
					{
						Match('t'); 

					}
						break;
					case 4 :
						// NewANTLRv3.g:417:5: 'b'
					{
						Match('b'); 

					}
						break;
					case 5 :
						// NewANTLRv3.g:418:5: 'f'
					{
						Match('f'); 

					}
						break;
					case 6 :
						// NewANTLRv3.g:419:5: '\"'
					{
						Match('\"'); 

					}
						break;
					case 7 :
						// NewANTLRv3.g:420:5: '\\''
					{
						Match('\''); 

					}
						break;
					case 8 :
						// NewANTLRv3.g:421:5: '\\\\'
					{
						Match('\\'); 

					}
						break;
					case 9 :
						// NewANTLRv3.g:422:5: '>'
					{
						Match('>'); 

					}
						break;
					case 10 :
						// NewANTLRv3.g:423:5: 'u' XDIGIT XDIGIT XDIGIT XDIGIT
					{
						Match('u'); 
						mXDIGIT(); 
						mXDIGIT(); 
						mXDIGIT(); 
						mXDIGIT(); 

					}
						break;
					case 11 :
						// NewANTLRv3.g:424:5: .
					{
						MatchAny(); 

					}
						break;

					}


				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "ESC"

		// $ANTLR start "XDIGIT"
		public void mXDIGIT() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:429:8: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )
				// NewANTLRv3.g:
				{
					if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'F') || (input.LA(1) >= 'a' && input.LA(1) <= 'f') ) 
					{
						input.Consume();

					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						Recover(mse);
						throw mse;}


				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "XDIGIT"

		// $ANTLR start "INT"
		public void mINT() // throws RecognitionException [2]
		{
			try
			{
				int _type = INT;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:435:5: ( ( '0' .. '9' )+ )
				// NewANTLRv3.g:435:7: ( '0' .. '9' )+
				{
					// NewANTLRv3.g:435:7: ( '0' .. '9' )+
					int cnt10 = 0;
					do 
					{
						int alt10 = 2;
						int LA10_0 = input.LA(1);

						if ( ((LA10_0 >= '0' && LA10_0 <= '9')) )
						{
							alt10 = 1;
						}


						switch (alt10) 
						{
						case 1 :
							// NewANTLRv3.g:435:7: '0' .. '9'
						{
							MatchRange('0','9'); 

						}
							break;

						default:
							if ( cnt10 >= 1 ) goto loop10;
							EarlyExitException eee10 =
								new EarlyExitException(10, input);
							throw eee10;
						}
						cnt10++;
					} while (true);

					loop10:
					;	// Stops C# compiler whining that label 'loop10' has no statements


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "INT"

		// $ANTLR start "ARG_ACTION"
		public void mARG_ACTION() // throws RecognitionException [2]
		{
			try
			{
				int _type = ARG_ACTION;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:439:2: ( NESTED_ARG_ACTION )
				// NewANTLRv3.g:439:4: NESTED_ARG_ACTION
				{
					mNESTED_ARG_ACTION(); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "ARG_ACTION"

		// $ANTLR start "NESTED_ARG_ACTION"
		public void mNESTED_ARG_ACTION() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:443:19: ( '[' ( options {greedy=false; k=1; } : NESTED_ARG_ACTION | ACTION_STRING_LITERAL | ACTION_CHAR_LITERAL | . )* ']' )
				// NewANTLRv3.g:444:2: '[' ( options {greedy=false; k=1; } : NESTED_ARG_ACTION | ACTION_STRING_LITERAL | ACTION_CHAR_LITERAL | . )* ']'
				{
					Match('['); 
					// NewANTLRv3.g:445:2: ( options {greedy=false; k=1; } : NESTED_ARG_ACTION | ACTION_STRING_LITERAL | ACTION_CHAR_LITERAL | . )*
					do 
					{
						int alt11 = 5;
						int LA11_0 = input.LA(1);

						if ( (LA11_0 == ']') )
						{
							alt11 = 5;
						}
						else if ( (LA11_0 == '[') )
						{
							alt11 = 1;
						}
						else if ( (LA11_0 == '\"') )
						{
							alt11 = 2;
						}
						else if ( (LA11_0 == '\'') )
						{
							alt11 = 3;
						}
						else if ( ((LA11_0 >= '\u0000' && LA11_0 <= '!') || (LA11_0 >= '#' && LA11_0 <= '&') || (LA11_0 >= '(' && LA11_0 <= 'Z') || LA11_0 == '\\' || (LA11_0 >= '^' && LA11_0 <= '\uFFFF')) )
						{
							alt11 = 4;
						}


						switch (alt11) 
						{
						case 1 :
							// NewANTLRv3.g:446:4: NESTED_ARG_ACTION
						{
							mNESTED_ARG_ACTION(); 

						}
							break;
						case 2 :
							// NewANTLRv3.g:447:4: ACTION_STRING_LITERAL
						{
							mACTION_STRING_LITERAL(); 

						}
							break;
						case 3 :
							// NewANTLRv3.g:448:4: ACTION_CHAR_LITERAL
						{
							mACTION_CHAR_LITERAL(); 

						}
							break;
						case 4 :
							// NewANTLRv3.g:449:4: .
						{
							MatchAny(); 

						}
							break;

						default:
							goto loop11;
						}
					} while (true);

					loop11:
					;	// Stops C# compiler whining that label 'loop11' has no statements

					Match(']'); 
					Text = Text.Substring(1, Text.Length-1);

				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "NESTED_ARG_ACTION"

		// $ANTLR start "ACTION"
		public void mACTION() // throws RecognitionException [2]
		{
			try
			{
				int _type = ACTION;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:456:2: ( NESTED_ACTION ( '?' )? )
				// NewANTLRv3.g:456:4: NESTED_ACTION ( '?' )?
				{
					mNESTED_ACTION(); 
					// NewANTLRv3.g:456:18: ( '?' )?
					int alt12 = 2;
					int LA12_0 = input.LA(1);

					if ( (LA12_0 == '?') )
					{
						alt12 = 1;
					}
					switch (alt12) 
					{
					case 1 :
						// NewANTLRv3.g:456:20: '?'
					{
						Match('?'); 
						_type = SEMPRED;

					}
						break;

					}


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "ACTION"

		// $ANTLR start "NESTED_ACTION"
		public void mNESTED_ACTION() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:460:15: ( '{' ( options {greedy=false; k=2; } : NESTED_ACTION | SL_COMMENT | ML_COMMENT | ACTION_STRING_LITERAL | ACTION_CHAR_LITERAL | . )* '}' )
				// NewANTLRv3.g:461:2: '{' ( options {greedy=false; k=2; } : NESTED_ACTION | SL_COMMENT | ML_COMMENT | ACTION_STRING_LITERAL | ACTION_CHAR_LITERAL | . )* '}'
				{
					Match('{'); 
					// NewANTLRv3.g:462:2: ( options {greedy=false; k=2; } : NESTED_ACTION | SL_COMMENT | ML_COMMENT | ACTION_STRING_LITERAL | ACTION_CHAR_LITERAL | . )*
					do 
					{
						int alt13 = 7;
						alt13 = dfa13.Predict(input);
						switch (alt13) 
						{
						case 1 :
							// NewANTLRv3.g:463:4: NESTED_ACTION
						{
							mNESTED_ACTION(); 

						}
							break;
						case 2 :
							// NewANTLRv3.g:464:4: SL_COMMENT
						{
							mSL_COMMENT(); 

						}
							break;
						case 3 :
							// NewANTLRv3.g:465:4: ML_COMMENT
						{
							mML_COMMENT(); 

						}
							break;
						case 4 :
							// NewANTLRv3.g:466:4: ACTION_STRING_LITERAL
						{
							mACTION_STRING_LITERAL(); 

						}
							break;
						case 5 :
							// NewANTLRv3.g:467:4: ACTION_CHAR_LITERAL
						{
							mACTION_CHAR_LITERAL(); 

						}
							break;
						case 6 :
							// NewANTLRv3.g:468:4: .
						{
							MatchAny(); 

						}
							break;

						default:
							goto loop13;
						}
					} while (true);

					loop13:
					;	// Stops C# compiler whining that label 'loop13' has no statements

					Match('}'); 

				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "NESTED_ACTION"

		// $ANTLR start "ACTION_CHAR_LITERAL"
		public void mACTION_CHAR_LITERAL() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:475:2: ( '\\'' ( ACTION_ESC | ~ ( '\\\\' | '\\'' ) ) '\\'' )
				// NewANTLRv3.g:475:4: '\\'' ( ACTION_ESC | ~ ( '\\\\' | '\\'' ) ) '\\''
				{
					Match('\''); 
					// NewANTLRv3.g:475:9: ( ACTION_ESC | ~ ( '\\\\' | '\\'' ) )
					int alt14 = 2;
					int LA14_0 = input.LA(1);

					if ( (LA14_0 == '\\') )
					{
						alt14 = 1;
					}
					else if ( ((LA14_0 >= '\u0000' && LA14_0 <= '&') || (LA14_0 >= '(' && LA14_0 <= '[') || (LA14_0 >= ']' && LA14_0 <= '\uFFFF')) )
					{
						alt14 = 2;
					}
					else 
					{
						NoViableAltException nvae_d14s0 =
							new NoViableAltException("", 14, 0, input);

						throw nvae_d14s0;
					}
					switch (alt14) 
					{
					case 1 :
						// NewANTLRv3.g:475:10: ACTION_ESC
					{
						mACTION_ESC(); 

					}
						break;
					case 2 :
						// NewANTLRv3.g:475:21: ~ ( '\\\\' | '\\'' )
					{
						if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
						{
							input.Consume();

						}
						else 
						{
							MismatchedSetException mse = new MismatchedSetException(null,input);
							Recover(mse);
							throw mse;}


					}
						break;

					}

					Match('\''); 

				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "ACTION_CHAR_LITERAL"

		// $ANTLR start "ACTION_STRING_LITERAL"
		public void mACTION_STRING_LITERAL() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:480:2: ( '\"' ( ACTION_ESC | ~ ( '\\\\' | '\"' ) )* '\"' )
				// NewANTLRv3.g:480:4: '\"' ( ACTION_ESC | ~ ( '\\\\' | '\"' ) )* '\"'
				{
					Match('\"'); 
					// NewANTLRv3.g:480:8: ( ACTION_ESC | ~ ( '\\\\' | '\"' ) )*
					do 
					{
						int alt15 = 3;
						int LA15_0 = input.LA(1);

						if ( (LA15_0 == '\\') )
						{
							alt15 = 1;
						}
						else if ( ((LA15_0 >= '\u0000' && LA15_0 <= '!') || (LA15_0 >= '#' && LA15_0 <= '[') || (LA15_0 >= ']' && LA15_0 <= '\uFFFF')) )
						{
							alt15 = 2;
						}


						switch (alt15) 
						{
						case 1 :
							// NewANTLRv3.g:480:9: ACTION_ESC
						{
							mACTION_ESC(); 

						}
							break;
						case 2 :
							// NewANTLRv3.g:480:20: ~ ( '\\\\' | '\"' )
						{
							if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '[') || (input.LA(1) >= ']' && input.LA(1) <= '\uFFFF') ) 
							{
								input.Consume();

							}
							else 
							{
								MismatchedSetException mse = new MismatchedSetException(null,input);
								Recover(mse);
								throw mse;}


						}
							break;

						default:
							goto loop15;
						}
					} while (true);

					loop15:
					;	// Stops C# compiler whining that label 'loop15' has no statements

					Match('\"'); 

				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "ACTION_STRING_LITERAL"

		// $ANTLR start "ACTION_ESC"
		public void mACTION_ESC() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:485:2: ( '\\\\\\'' | '\\\\' '\"' | '\\\\' ~ ( '\\'' | '\"' ) )
				int alt16 = 3;
				int LA16_0 = input.LA(1);

				if ( (LA16_0 == '\\') )
				{
					int LA16_1 = input.LA(2);

					if ( (LA16_1 == '\'') )
					{
						alt16 = 1;
					}
					else if ( (LA16_1 == '\"') )
					{
						alt16 = 2;
					}
					else if ( ((LA16_1 >= '\u0000' && LA16_1 <= '!') || (LA16_1 >= '#' && LA16_1 <= '&') || (LA16_1 >= '(' && LA16_1 <= '\uFFFF')) )
					{
						alt16 = 3;
					}
					else 
					{
						NoViableAltException nvae_d16s1 =
							new NoViableAltException("", 16, 1, input);

						throw nvae_d16s1;
					}
				}
				else 
				{
					NoViableAltException nvae_d16s0 =
						new NoViableAltException("", 16, 0, input);

					throw nvae_d16s0;
				}
				switch (alt16) 
				{
				case 1 :
					// NewANTLRv3.g:485:4: '\\\\\\''
				{
					Match("\\'"); 


				}
					break;
				case 2 :
					// NewANTLRv3.g:486:4: '\\\\' '\"'
				{
					Match('\\'); 
					Match('\"'); 

				}
					break;
				case 3 :
					// NewANTLRv3.g:487:4: '\\\\' ~ ( '\\'' | '\"' )
				{
					Match('\\'); 
					if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '\uFFFF') ) 
					{
						input.Consume();

					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						Recover(mse);
						throw mse;}


				}
					break;

				}
			}
			finally 
			{
			}
		}
		// $ANTLR end "ACTION_ESC"

		// $ANTLR start "TOKEN_REF"
		public void mTOKEN_REF() // throws RecognitionException [2]
		{
			try
			{
				int _type = TOKEN_REF;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:491:2: ( 'A' .. 'Z' ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
				// NewANTLRv3.g:491:4: 'A' .. 'Z' ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
				{
					MatchRange('A','Z'); 
					// NewANTLRv3.g:491:13: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
					do 
					{
						int alt17 = 2;
						int LA17_0 = input.LA(1);

						if ( ((LA17_0 >= '0' && LA17_0 <= '9') || (LA17_0 >= 'A' && LA17_0 <= 'Z') || LA17_0 == '_' || (LA17_0 >= 'a' && LA17_0 <= 'z')) )
						{
							alt17 = 1;
						}


						switch (alt17) 
						{
						case 1 :
							// NewANTLRv3.g:
						{
							if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
							{
								input.Consume();

							}
							else 
							{
								MismatchedSetException mse = new MismatchedSetException(null,input);
								Recover(mse);
								throw mse;}


						}
							break;

						default:
							goto loop17;
						}
					} while (true);

					loop17:
					;	// Stops C# compiler whining that label 'loop17' has no statements


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "TOKEN_REF"

		// $ANTLR start "RULE_REF"
		public void mRULE_REF() // throws RecognitionException [2]
		{
			try
			{
				int _type = RULE_REF;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:495:2: ( 'a' .. 'z' ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
				// NewANTLRv3.g:495:4: 'a' .. 'z' ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
				{
					MatchRange('a','z'); 
					// NewANTLRv3.g:495:13: ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
					do 
					{
						int alt18 = 2;
						int LA18_0 = input.LA(1);

						if ( ((LA18_0 >= '0' && LA18_0 <= '9') || (LA18_0 >= 'A' && LA18_0 <= 'Z') || LA18_0 == '_' || (LA18_0 >= 'a' && LA18_0 <= 'z')) )
						{
							alt18 = 1;
						}


						switch (alt18) 
						{
						case 1 :
							// NewANTLRv3.g:
						{
							if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
							{
								input.Consume();

							}
							else 
							{
								MismatchedSetException mse = new MismatchedSetException(null,input);
								Recover(mse);
								throw mse;}


						}
							break;

						default:
							goto loop18;
						}
					} while (true);

					loop18:
					;	// Stops C# compiler whining that label 'loop18' has no statements


				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "RULE_REF"

		// $ANTLR start "OPTIONS"
		public void mOPTIONS() // throws RecognitionException [2]
		{
			try
			{
				int _type = OPTIONS;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:502:2: ( 'options' WS_LOOP '{' )
				// NewANTLRv3.g:502:4: 'options' WS_LOOP '{'
				{
					Match("options"); 

					mWS_LOOP(); 
					Match('{'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "OPTIONS"

		// $ANTLR start "TOKENS"
		public void mTOKENS() // throws RecognitionException [2]
		{
			try
			{
				int _type = TOKENS;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:506:2: ( 'tokens' WS_LOOP '{' )
				// NewANTLRv3.g:506:4: 'tokens' WS_LOOP '{'
				{
					Match("tokens"); 

					mWS_LOOP(); 
					Match('{'); 

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "TOKENS"

		// $ANTLR start "SRC"
		public void mSRC() // throws RecognitionException [2]
		{
			try
			{
				IToken file = null;
				IToken line = null;

				// NewANTLRv3.g:514:5: ( 'src' ' ' file= ACTION_STRING_LITERAL ' ' line= INT )
				// NewANTLRv3.g:514:7: 'src' ' ' file= ACTION_STRING_LITERAL ' ' line= INT
				{
					Match("src"); 

					Match(' '); 
					int fileStart980 = CharIndex;
					mACTION_STRING_LITERAL(); 
					file = new CommonToken(input, Token.INVALID_TOKEN_TYPE, Token.DEFAULT_CHANNEL, fileStart980, CharIndex-1);
					Match(' '); 
					int lineStart986 = CharIndex;
					mINT(); 
					line = new CommonToken(input, Token.INVALID_TOKEN_TYPE, Token.DEFAULT_CHANNEL, lineStart986, CharIndex-1);

				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "SRC"

		// $ANTLR start "WS"
		public void mWS() // throws RecognitionException [2]
		{
			try
			{
				int _type = WS;
				int _channel = DEFAULT_TOKEN_CHANNEL;
				// NewANTLRv3.g:517:4: ( ( ' ' | '\\t' | ( '\\r' )? '\\n' )+ )
				// NewANTLRv3.g:517:6: ( ' ' | '\\t' | ( '\\r' )? '\\n' )+
				{
					// NewANTLRv3.g:517:6: ( ' ' | '\\t' | ( '\\r' )? '\\n' )+
					int cnt20 = 0;
					do 
					{
						int alt20 = 4;
						switch ( input.LA(1) ) 
						{
						case ' ':
						{
							alt20 = 1;
						}
							break;
						case '\t':
						{
							alt20 = 2;
						}
							break;
						case '\n':
						case '\r':
						{
							alt20 = 3;
						}
							break;

						}

						switch (alt20) 
						{
						case 1 :
							// NewANTLRv3.g:517:8: ' '
						{
							Match(' '); 

						}
							break;
						case 2 :
							// NewANTLRv3.g:518:5: '\\t'
						{
							Match('\t'); 

						}
							break;
						case 3 :
							// NewANTLRv3.g:519:5: ( '\\r' )? '\\n'
						{
							// NewANTLRv3.g:519:5: ( '\\r' )?
							int alt19 = 2;
							int LA19_0 = input.LA(1);

							if ( (LA19_0 == '\r') )
							{
								alt19 = 1;
							}
							switch (alt19) 
							{
							case 1 :
								// NewANTLRv3.g:519:5: '\\r'
							{
								Match('\r'); 

							}
								break;

							}

							Match('\n'); 

						}
							break;

						default:
							if ( cnt20 >= 1 ) goto loop20;
							EarlyExitException eee20 =
								new EarlyExitException(20, input);
							throw eee20;
						}
						cnt20++;
					} while (true);

					loop20:
					;	// Stops C# compiler whining that label 'loop20' has no statements

					_channel=HIDDEN;

				}

				state.type = _type;
				state.channel = _channel;
			}
			finally 
			{
			}
		}
		// $ANTLR end "WS"

		// $ANTLR start "WS_LOOP"
		public void mWS_LOOP() // throws RecognitionException [2]
		{
			try
			{
				// NewANTLRv3.g:526:2: ( ( WS | SL_COMMENT | ML_COMMENT )* )
				// NewANTLRv3.g:526:4: ( WS | SL_COMMENT | ML_COMMENT )*
				{
					// NewANTLRv3.g:526:4: ( WS | SL_COMMENT | ML_COMMENT )*
					do 
					{
						int alt21 = 4;
						int LA21_0 = input.LA(1);

						if ( ((LA21_0 >= '\t' && LA21_0 <= '\n') || LA21_0 == '\r' || LA21_0 == ' ') )
						{
							alt21 = 1;
						}
						else if ( (LA21_0 == '/') )
						{
							int LA21_3 = input.LA(2);

							if ( (LA21_3 == '/') )
							{
								alt21 = 2;
							}
							else if ( (LA21_3 == '*') )
							{
								alt21 = 3;
							}


						}


						switch (alt21) 
						{
						case 1 :
							// NewANTLRv3.g:526:6: WS
						{
							mWS(); 

						}
							break;
						case 2 :
							// NewANTLRv3.g:527:5: SL_COMMENT
						{
							mSL_COMMENT(); 

						}
							break;
						case 3 :
							// NewANTLRv3.g:528:5: ML_COMMENT
						{
							mML_COMMENT(); 

						}
							break;

						default:
							goto loop21;
						}
					} while (true);

					loop21:
					;	// Stops C# compiler whining that label 'loop21' has no statements


				}

			}
			finally 
			{
			}
		}
		// $ANTLR end "WS_LOOP"

		override public void mTokens() // throws RecognitionException 
		{
			// NewANTLRv3.g:1:8: ( T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | SL_COMMENT | ML_COMMENT | CHAR_LITERAL | STRING_LITERAL | DOUBLE_QUOTE_STRING_LITERAL | DOUBLE_ANGLE_STRING_LITERAL | INT | ARG_ACTION | ACTION | TOKEN_REF | RULE_REF | OPTIONS | TOKENS | WS )
			int alt22 = 49;
			alt22 = dfa22.Predict(input);
			switch (alt22) 
			{
			case 1 :
				// NewANTLRv3.g:1:10: T__31
			{
				mT__31(); 

			}
				break;
			case 2 :
				// NewANTLRv3.g:1:16: T__32
			{
				mT__32(); 

			}
				break;
			case 3 :
				// NewANTLRv3.g:1:22: T__33
			{
				mT__33(); 

			}
				break;
			case 4 :
				// NewANTLRv3.g:1:28: T__34
			{
				mT__34(); 

			}
				break;
			case 5 :
				// NewANTLRv3.g:1:34: T__35
			{
				mT__35(); 

			}
				break;
			case 6 :
				// NewANTLRv3.g:1:40: T__36
			{
				mT__36(); 

			}
				break;
			case 7 :
				// NewANTLRv3.g:1:46: T__37
			{
				mT__37(); 

			}
				break;
			case 8 :
				// NewANTLRv3.g:1:52: T__38
			{
				mT__38(); 

			}
				break;
			case 9 :
				// NewANTLRv3.g:1:58: T__39
			{
				mT__39(); 

			}
				break;
			case 10 :
				// NewANTLRv3.g:1:64: T__40
			{
				mT__40(); 

			}
				break;
			case 11 :
				// NewANTLRv3.g:1:70: T__41
			{
				mT__41(); 

			}
				break;
			case 12 :
				// NewANTLRv3.g:1:76: T__42
			{
				mT__42(); 

			}
				break;
			case 13 :
				// NewANTLRv3.g:1:82: T__43
			{
				mT__43(); 

			}
				break;
			case 14 :
				// NewANTLRv3.g:1:88: T__44
			{
				mT__44(); 

			}
				break;
			case 15 :
				// NewANTLRv3.g:1:94: T__45
			{
				mT__45(); 

			}
				break;
			case 16 :
				// NewANTLRv3.g:1:100: T__46
			{
				mT__46(); 

			}
				break;
			case 17 :
				// NewANTLRv3.g:1:106: T__47
			{
				mT__47(); 

			}
				break;
			case 18 :
				// NewANTLRv3.g:1:112: T__48
			{
				mT__48(); 

			}
				break;
			case 19 :
				// NewANTLRv3.g:1:118: T__49
			{
				mT__49(); 

			}
				break;
			case 20 :
				// NewANTLRv3.g:1:124: T__50
			{
				mT__50(); 

			}
				break;
			case 21 :
				// NewANTLRv3.g:1:130: T__51
			{
				mT__51(); 

			}
				break;
			case 22 :
				// NewANTLRv3.g:1:136: T__52
			{
				mT__52(); 

			}
				break;
			case 23 :
				// NewANTLRv3.g:1:142: T__53
			{
				mT__53(); 

			}
				break;
			case 24 :
				// NewANTLRv3.g:1:148: T__54
			{
				mT__54(); 

			}
				break;
			case 25 :
				// NewANTLRv3.g:1:154: T__55
			{
				mT__55(); 

			}
				break;
			case 26 :
				// NewANTLRv3.g:1:160: T__56
			{
				mT__56(); 

			}
				break;
			case 27 :
				// NewANTLRv3.g:1:166: T__57
			{
				mT__57(); 

			}
				break;
			case 28 :
				// NewANTLRv3.g:1:172: T__58
			{
				mT__58(); 

			}
				break;
			case 29 :
				// NewANTLRv3.g:1:178: T__59
			{
				mT__59(); 

			}
				break;
			case 30 :
				// NewANTLRv3.g:1:184: T__60
			{
				mT__60(); 

			}
				break;
			case 31 :
				// NewANTLRv3.g:1:190: T__61
			{
				mT__61(); 

			}
				break;
			case 32 :
				// NewANTLRv3.g:1:196: T__62
			{
				mT__62(); 

			}
				break;
			case 33 :
				// NewANTLRv3.g:1:202: T__63
			{
				mT__63(); 

			}
				break;
			case 34 :
				// NewANTLRv3.g:1:208: T__64
			{
				mT__64(); 

			}
				break;
			case 35 :
				// NewANTLRv3.g:1:214: T__65
			{
				mT__65(); 

			}
				break;
			case 36 :
				// NewANTLRv3.g:1:220: SL_COMMENT
			{
				mSL_COMMENT(); 

			}
				break;
			case 37 :
				// NewANTLRv3.g:1:231: ML_COMMENT
			{
				mML_COMMENT(); 

			}
				break;
			case 38 :
				// NewANTLRv3.g:1:242: CHAR_LITERAL
			{
				mCHAR_LITERAL(); 

			}
				break;
			case 39 :
				// NewANTLRv3.g:1:255: STRING_LITERAL
			{
				mSTRING_LITERAL(); 

			}
				break;
			case 40 :
				// NewANTLRv3.g:1:270: DOUBLE_QUOTE_STRING_LITERAL
			{
				mDOUBLE_QUOTE_STRING_LITERAL(); 

			}
				break;
			case 41 :
				// NewANTLRv3.g:1:298: DOUBLE_ANGLE_STRING_LITERAL
			{
				mDOUBLE_ANGLE_STRING_LITERAL(); 

			}
				break;
			case 42 :
				// NewANTLRv3.g:1:326: INT
			{
				mINT(); 

			}
				break;
			case 43 :
				// NewANTLRv3.g:1:330: ARG_ACTION
			{
				mARG_ACTION(); 

			}
				break;
			case 44 :
				// NewANTLRv3.g:1:341: ACTION
			{
				mACTION(); 

			}
				break;
			case 45 :
				// NewANTLRv3.g:1:348: TOKEN_REF
			{
				mTOKEN_REF(); 

			}
				break;
			case 46 :
				// NewANTLRv3.g:1:358: RULE_REF
			{
				mRULE_REF(); 

			}
				break;
			case 47 :
				// NewANTLRv3.g:1:367: OPTIONS
			{
				mOPTIONS(); 

			}
				break;
			case 48 :
				// NewANTLRv3.g:1:375: TOKENS
			{
				mTOKENS(); 

			}
				break;
			case 49 :
				// NewANTLRv3.g:1:382: WS
			{
				mWS(); 

			}
				break;

			}

		}


		protected DFA2 dfa2;
		protected DFA9 dfa9;
		protected DFA13 dfa13;
		protected DFA22 dfa22;
		private void InitializeCyclicDFAs()
		{
			this.dfa2 = new DFA2(this);
			this.dfa9 = new DFA9(this);
			this.dfa13 = new DFA13(this);
			this.dfa22 = new DFA22(this);
			this.dfa2.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA2_SpecialStateTransition);
			this.dfa9.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA9_SpecialStateTransition);
			this.dfa13.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA13_SpecialStateTransition);
			this.dfa22.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA22_SpecialStateTransition);
		}

		const string DFA2_eotS =
			"\x12\uffff\x01\x02\x04\uffff\x01\x02\x04\uffff";
		const string DFA2_eofS =
			"\x1c\uffff";
		const string DFA2_minS =
			"\x02\x00\x01\uffff\x16\x00\x01\uffff\x01\x00\x01\uffff";
		const string DFA2_maxS =
			"\x02\uffff\x01\uffff\x16\uffff\x01\uffff\x01\uffff\x01\uffff";
		const string DFA2_acceptS =
			"\x02\uffff\x01\x02\x16\uffff\x01\x01\x01\uffff\x01\x01";
		const string DFA2_specialS =
			"\x01\x11\x01\x00\x01\uffff\x01\x01\x01\x02\x01\x04\x01\x05\x01"+
				"\x06\x01\x08\x01\x14\x01\x0f\x01\x0d\x01\x0c\x01\x18\x01\x13\x01"+
					"\x0b\x01\x17\x01\x09\x01\x0e\x01\x12\x01\x03\x01\x10\x01\x07\x01"+
						"\x16\x01\x0a\x01\uffff\x01\x15\x01\uffff}>";
		static readonly string[] DFA2_transitionS = {
			"\x20\x02\x01\x01\uffdf\x02",
			"\x24\x02\x01\x03\uffdb\x02",
			"",
			"\x41\x02\x01\x04\uffbe\x02",
			"\x4e\x02\x01\x05\uffb1\x02",
			"\x54\x02\x01\x06\uffab\x02",
			"\x4c\x02\x01\x07\uffb3\x02",
			"\x52\x02\x01\x08\uffad\x02",
			"\x20\x02\x01\x09\uffdf\x02",
			"\x73\x02\x01\x0a\uff8c\x02",
			"\x72\x02\x01\x0b\uff8d\x02",
			"\x63\x02\x01\x0c\uff9c\x02",
			"\x20\x02\x01\x0d\uffdf\x02",
			"\x22\x02\x01\x0e\uffdd\x02",
			"\x0a\x13\x01\x12\x02\x13\x01\x10\x14\x13\x01\x11\x39\x13\x01"+
				"\x0f\uffa3\x13",
			"\x0a\x18\x01\x17\x02\x18\x01\x16\x14\x18\x01\x15\x04\x18\x01"+
				"\x14\uffd8\x18",
			"\x0a\x19\x01\x12\ufff5\x19",
			"\x20\x02\x01\x1a\uffdf\x02",
			"\x00\x19",
			"\x0a\x13\x01\x12\x02\x13\x01\x10\x14\x13\x01\x11\x39\x13\x01"+
				"\x0f\uffa3\x13",
			"\x0a\x13\x01\x12\x02\x13\x01\x10\x14\x13\x01\x11\x39\x13\x01"+
				"\x0f\uffa3\x13",
			"\x0a\x13\x01\x12\x02\x13\x01\x10\x14\x13\x01\x11\x39\x13\x01"+
				"\x0f\uffa3\x13",
			"\x0a\x19\x01\x12\ufff5\x19",
			"\x00\x19",
			"\x0a\x13\x01\x12\x02\x13\x01\x10\x14\x13\x01\x11\x39\x13\x01"+
				"\x0f\uffa3\x13",
			"",
			"\x30\x02\x0a\x1b\uffc6\x02",
			""
		};

		static readonly short[] DFA2_eot = DFA.UnpackEncodedString(DFA2_eotS);
		static readonly short[] DFA2_eof = DFA.UnpackEncodedString(DFA2_eofS);
		static readonly char[] DFA2_min = DFA.UnpackEncodedStringToUnsignedChars(DFA2_minS);
		static readonly char[] DFA2_max = DFA.UnpackEncodedStringToUnsignedChars(DFA2_maxS);
		static readonly short[] DFA2_accept = DFA.UnpackEncodedString(DFA2_acceptS);
		static readonly short[] DFA2_special = DFA.UnpackEncodedString(DFA2_specialS);
		static readonly short[][] DFA2_transition = DFA.UnpackEncodedStringArray(DFA2_transitionS);

		protected class DFA2 : DFA
		{
			public DFA2(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 2;
				this.eot = DFA2_eot;
				this.eof = DFA2_eof;
				this.min = DFA2_min;
				this.max = DFA2_max;
				this.accept = DFA2_accept;
				this.special = DFA2_special;
				this.transition = DFA2_transition;

			}

			override public string Description
			{
				get { return "379:5: ( ' $ANTLR ' SRC | (~ ( '\\r' | '\\n' ) )* )"; }
			}

		}


		protected internal int DFA2_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			IIntStream input = _input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA2_1 = input.LA(1);

				s = -1;
				if ( (LA2_1 == '$') ) { s = 3; }

				else if ( ((LA2_1 >= '\u0000' && LA2_1 <= '#') || (LA2_1 >= '%' && LA2_1 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA2_3 = input.LA(1);

				s = -1;
				if ( (LA2_3 == 'A') ) { s = 4; }

				else if ( ((LA2_3 >= '\u0000' && LA2_3 <= '@') || (LA2_3 >= 'B' && LA2_3 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA2_4 = input.LA(1);

				s = -1;
				if ( (LA2_4 == 'N') ) { s = 5; }

				else if ( ((LA2_4 >= '\u0000' && LA2_4 <= 'M') || (LA2_4 >= 'O' && LA2_4 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA2_20 = input.LA(1);

				s = -1;
				if ( (LA2_20 == '\"') ) { s = 17; }

				else if ( (LA2_20 == '\\') ) { s = 15; }

				else if ( (LA2_20 == '\r') ) { s = 16; }

				else if ( (LA2_20 == '\n') ) { s = 18; }

				else if ( ((LA2_20 >= '\u0000' && LA2_20 <= '\t') || (LA2_20 >= '\u000B' && LA2_20 <= '\f') || (LA2_20 >= '\u000E' && LA2_20 <= '!') || (LA2_20 >= '#' && LA2_20 <= '[') || (LA2_20 >= ']' && LA2_20 <= '\uFFFF')) ) { s = 19; }

				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA2_5 = input.LA(1);

				s = -1;
				if ( (LA2_5 == 'T') ) { s = 6; }

				else if ( ((LA2_5 >= '\u0000' && LA2_5 <= 'S') || (LA2_5 >= 'U' && LA2_5 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA2_6 = input.LA(1);

				s = -1;
				if ( (LA2_6 == 'L') ) { s = 7; }

				else if ( ((LA2_6 >= '\u0000' && LA2_6 <= 'K') || (LA2_6 >= 'M' && LA2_6 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA2_7 = input.LA(1);

				s = -1;
				if ( (LA2_7 == 'R') ) { s = 8; }

				else if ( ((LA2_7 >= '\u0000' && LA2_7 <= 'Q') || (LA2_7 >= 'S' && LA2_7 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA2_22 = input.LA(1);

				s = -1;
				if ( (LA2_22 == '\n') ) { s = 18; }

				else if ( ((LA2_22 >= '\u0000' && LA2_22 <= '\t') || (LA2_22 >= '\u000B' && LA2_22 <= '\uFFFF')) ) { s = 25; }

				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA2_8 = input.LA(1);

				s = -1;
				if ( (LA2_8 == ' ') ) { s = 9; }

				else if ( ((LA2_8 >= '\u0000' && LA2_8 <= '\u001F') || (LA2_8 >= '!' && LA2_8 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA2_17 = input.LA(1);

				s = -1;
				if ( (LA2_17 == ' ') ) { s = 26; }

				else if ( ((LA2_17 >= '\u0000' && LA2_17 <= '\u001F') || (LA2_17 >= '!' && LA2_17 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA2_24 = input.LA(1);

				s = -1;
				if ( (LA2_24 == '\"') ) { s = 17; }

				else if ( (LA2_24 == '\\') ) { s = 15; }

				else if ( (LA2_24 == '\r') ) { s = 16; }

				else if ( (LA2_24 == '\n') ) { s = 18; }

				else if ( ((LA2_24 >= '\u0000' && LA2_24 <= '\t') || (LA2_24 >= '\u000B' && LA2_24 <= '\f') || (LA2_24 >= '\u000E' && LA2_24 <= '!') || (LA2_24 >= '#' && LA2_24 <= '[') || (LA2_24 >= ']' && LA2_24 <= '\uFFFF')) ) { s = 19; }

				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA2_15 = input.LA(1);

				s = -1;
				if ( (LA2_15 == '\'') ) { s = 20; }

				else if ( (LA2_15 == '\"') ) { s = 21; }

				else if ( (LA2_15 == '\r') ) { s = 22; }

				else if ( (LA2_15 == '\n') ) { s = 23; }

				else if ( ((LA2_15 >= '\u0000' && LA2_15 <= '\t') || (LA2_15 >= '\u000B' && LA2_15 <= '\f') || (LA2_15 >= '\u000E' && LA2_15 <= '!') || (LA2_15 >= '#' && LA2_15 <= '&') || (LA2_15 >= '(' && LA2_15 <= '\uFFFF')) ) { s = 24; }

				if ( s >= 0 ) return s;
				break;
			case 12 : 
				int LA2_12 = input.LA(1);

				s = -1;
				if ( (LA2_12 == ' ') ) { s = 13; }

				else if ( ((LA2_12 >= '\u0000' && LA2_12 <= '\u001F') || (LA2_12 >= '!' && LA2_12 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 13 : 
				int LA2_11 = input.LA(1);

				s = -1;
				if ( (LA2_11 == 'c') ) { s = 12; }

				else if ( ((LA2_11 >= '\u0000' && LA2_11 <= 'b') || (LA2_11 >= 'd' && LA2_11 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 14 : 
				int LA2_18 = input.LA(1);

				s = -1;
				if ( ((LA2_18 >= '\u0000' && LA2_18 <= '\uFFFF')) ) { s = 25; }

				else s = 2;

				if ( s >= 0 ) return s;
				break;
			case 15 : 
				int LA2_10 = input.LA(1);

				s = -1;
				if ( (LA2_10 == 'r') ) { s = 11; }

				else if ( ((LA2_10 >= '\u0000' && LA2_10 <= 'q') || (LA2_10 >= 's' && LA2_10 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 16 : 
				int LA2_21 = input.LA(1);

				s = -1;
				if ( (LA2_21 == '\"') ) { s = 17; }

				else if ( (LA2_21 == '\\') ) { s = 15; }

				else if ( (LA2_21 == '\r') ) { s = 16; }

				else if ( (LA2_21 == '\n') ) { s = 18; }

				else if ( ((LA2_21 >= '\u0000' && LA2_21 <= '\t') || (LA2_21 >= '\u000B' && LA2_21 <= '\f') || (LA2_21 >= '\u000E' && LA2_21 <= '!') || (LA2_21 >= '#' && LA2_21 <= '[') || (LA2_21 >= ']' && LA2_21 <= '\uFFFF')) ) { s = 19; }

				if ( s >= 0 ) return s;
				break;
			case 17 : 
				int LA2_0 = input.LA(1);

				s = -1;
				if ( (LA2_0 == ' ') ) { s = 1; }

				else if ( ((LA2_0 >= '\u0000' && LA2_0 <= '\u001F') || (LA2_0 >= '!' && LA2_0 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 18 : 
				int LA2_19 = input.LA(1);

				s = -1;
				if ( (LA2_19 == '\"') ) { s = 17; }

				else if ( (LA2_19 == '\\') ) { s = 15; }

				else if ( (LA2_19 == '\r') ) { s = 16; }

				else if ( (LA2_19 == '\n') ) { s = 18; }

				else if ( ((LA2_19 >= '\u0000' && LA2_19 <= '\t') || (LA2_19 >= '\u000B' && LA2_19 <= '\f') || (LA2_19 >= '\u000E' && LA2_19 <= '!') || (LA2_19 >= '#' && LA2_19 <= '[') || (LA2_19 >= ']' && LA2_19 <= '\uFFFF')) ) { s = 19; }

				if ( s >= 0 ) return s;
				break;
			case 19 : 
				int LA2_14 = input.LA(1);

				s = -1;
				if ( (LA2_14 == '\\') ) { s = 15; }

				else if ( (LA2_14 == '\r') ) { s = 16; }

				else if ( (LA2_14 == '\"') ) { s = 17; }

				else if ( (LA2_14 == '\n') ) { s = 18; }

				else if ( ((LA2_14 >= '\u0000' && LA2_14 <= '\t') || (LA2_14 >= '\u000B' && LA2_14 <= '\f') || (LA2_14 >= '\u000E' && LA2_14 <= '!') || (LA2_14 >= '#' && LA2_14 <= '[') || (LA2_14 >= ']' && LA2_14 <= '\uFFFF')) ) { s = 19; }

				if ( s >= 0 ) return s;
				break;
			case 20 : 
				int LA2_9 = input.LA(1);

				s = -1;
				if ( (LA2_9 == 's') ) { s = 10; }

				else if ( ((LA2_9 >= '\u0000' && LA2_9 <= 'r') || (LA2_9 >= 't' && LA2_9 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 21 : 
				int LA2_26 = input.LA(1);

				s = -1;
				if ( ((LA2_26 >= '0' && LA2_26 <= '9')) ) { s = 27; }

				else if ( ((LA2_26 >= '\u0000' && LA2_26 <= '/') || (LA2_26 >= ':' && LA2_26 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			case 22 : 
				int LA2_23 = input.LA(1);

				s = -1;
				if ( ((LA2_23 >= '\u0000' && LA2_23 <= '\uFFFF')) ) { s = 25; }

				else s = 2;

				if ( s >= 0 ) return s;
				break;
			case 23 : 
				int LA2_16 = input.LA(1);

				s = -1;
				if ( (LA2_16 == '\n') ) { s = 18; }

				else if ( ((LA2_16 >= '\u0000' && LA2_16 <= '\t') || (LA2_16 >= '\u000B' && LA2_16 <= '\uFFFF')) ) { s = 25; }

				if ( s >= 0 ) return s;
				break;
			case 24 : 
				int LA2_13 = input.LA(1);

				s = -1;
				if ( (LA2_13 == '\"') ) { s = 14; }

				else if ( ((LA2_13 >= '\u0000' && LA2_13 <= '!') || (LA2_13 >= '#' && LA2_13 <= '\uFFFF')) ) { s = 2; }

				if ( s >= 0 ) return s;
				break;
			}
			NoViableAltException nvae2 =
				new NoViableAltException(dfa.Description, 2, _s, input);
			dfa.Error(nvae2);
			throw nvae2;
		}
		const string DFA9_eotS =
			"\x0a\uffff\x01\x0b\x02\uffff";
		const string DFA9_eofS =
			"\x0d\uffff";
		const string DFA9_minS =
			"\x01\x00\x09\uffff\x01\x30\x02\uffff";
		const string DFA9_maxS =
			"\x01\uffff\x09\uffff\x01\x66\x02\uffff";
		const string DFA9_acceptS =
			"\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
				"\x07\x01\x08\x01\x09\x01\uffff\x01\x0b\x01\x0a";
		const string DFA9_specialS =
			"\x01\x00\x0c\uffff}>";
		static readonly string[] DFA9_transitionS = {
			"\x22\x0b\x01\x06\x04\x0b\x01\x07\x16\x0b\x01\x09\x1d\x0b\x01"+
				"\x08\x05\x0b\x01\x04\x03\x0b\x01\x05\x07\x0b\x01\x01\x03\x0b"+
					"\x01\x02\x01\x0b\x01\x03\x01\x0a\uff8a\x0b",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"\x0a\x0c\x07\uffff\x06\x0c\x1a\uffff\x06\x0c",
			"",
			""
		};

		static readonly short[] DFA9_eot = DFA.UnpackEncodedString(DFA9_eotS);
		static readonly short[] DFA9_eof = DFA.UnpackEncodedString(DFA9_eofS);
		static readonly char[] DFA9_min = DFA.UnpackEncodedStringToUnsignedChars(DFA9_minS);
		static readonly char[] DFA9_max = DFA.UnpackEncodedStringToUnsignedChars(DFA9_maxS);
		static readonly short[] DFA9_accept = DFA.UnpackEncodedString(DFA9_acceptS);
		static readonly short[] DFA9_special = DFA.UnpackEncodedString(DFA9_specialS);
		static readonly short[][] DFA9_transition = DFA.UnpackEncodedStringArray(DFA9_transitionS);

		protected class DFA9 : DFA
		{
			public DFA9(BaseRecognizer recognizer)
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

			override public string Description
			{
				get { return "414:3: ( 'n' | 'r' | 't' | 'b' | 'f' | '\"' | '\\'' | '\\\\' | '>' | 'u' XDIGIT XDIGIT XDIGIT XDIGIT | . )"; }
			}

		}


		protected internal int DFA9_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			IIntStream input = _input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA9_0 = input.LA(1);

				s = -1;
				if ( (LA9_0 == 'n') ) { s = 1; }

				else if ( (LA9_0 == 'r') ) { s = 2; }

				else if ( (LA9_0 == 't') ) { s = 3; }

				else if ( (LA9_0 == 'b') ) { s = 4; }

				else if ( (LA9_0 == 'f') ) { s = 5; }

				else if ( (LA9_0 == '\"') ) { s = 6; }

				else if ( (LA9_0 == '\'') ) { s = 7; }

				else if ( (LA9_0 == '\\') ) { s = 8; }

				else if ( (LA9_0 == '>') ) { s = 9; }

				else if ( (LA9_0 == 'u') ) { s = 10; }

				else if ( ((LA9_0 >= '\u0000' && LA9_0 <= '!') || (LA9_0 >= '#' && LA9_0 <= '&') || (LA9_0 >= '(' && LA9_0 <= '=') || (LA9_0 >= '?' && LA9_0 <= '[') || (LA9_0 >= ']' && LA9_0 <= 'a') || (LA9_0 >= 'c' && LA9_0 <= 'e') || (LA9_0 >= 'g' && LA9_0 <= 'm') || (LA9_0 >= 'o' && LA9_0 <= 'q') || LA9_0 == 's' || (LA9_0 >= 'v' && LA9_0 <= '\uFFFF')) ) { s = 11; }

				if ( s >= 0 ) return s;
				break;
			}
			NoViableAltException nvae9 =
				new NoViableAltException(dfa.Description, 9, _s, input);
			dfa.Error(nvae9);
			throw nvae9;
		}
		const string DFA13_eotS =
			"\x1c\uffff";
		const string DFA13_eofS =
			"\x1c\uffff";
		const string DFA13_minS =
			"\x01\x00\x02\uffff\x03\x00\x16\uffff";
		const string DFA13_maxS =
			"\x01\uffff\x02\uffff\x03\uffff\x16\uffff";
		const string DFA13_acceptS =
			"\x01\uffff\x01\x07\x01\x01\x03\uffff\x01\x06\x01\x02\x01\x03\x05"+
				"\uffff\x07\x04\x04\x05\x01\uffff\x02\x05";
		const string DFA13_specialS =
			"\x01\x00\x02\uffff\x01\x01\x01\x02\x01\x03\x16\uffff}>";
		static readonly string[] DFA13_transitionS = {
			"\x22\x06\x01\x04\x04\x06\x01\x05\x07\x06\x01\x03\x4b\x06\x01"+
				"\x02\x01\x06\x01\x01\uff82\x06",
			"",
			"",
			"\x2a\x06\x01\x08\x04\x06\x01\x07\uffd0\x06",
			"\x22\x14\x01\x11\x04\x14\x01\x12\x07\x14\x01\x10\x2c\x14\x01"+
				"\x13\x1e\x14\x01\x0f\x01\x14\x01\x0e\uff82\x14",
			"\x22\x1b\x01\x18\x04\x1b\x01\x06\x07\x1b\x01\x17\x2c\x1b\x01"+
				"\x1a\x1e\x1b\x01\x16\x01\x1b\x01\x15\uff82\x1b",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
			"",
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

		static readonly short[] DFA13_eot = DFA.UnpackEncodedString(DFA13_eotS);
		static readonly short[] DFA13_eof = DFA.UnpackEncodedString(DFA13_eofS);
		static readonly char[] DFA13_min = DFA.UnpackEncodedStringToUnsignedChars(DFA13_minS);
		static readonly char[] DFA13_max = DFA.UnpackEncodedStringToUnsignedChars(DFA13_maxS);
		static readonly short[] DFA13_accept = DFA.UnpackEncodedString(DFA13_acceptS);
		static readonly short[] DFA13_special = DFA.UnpackEncodedString(DFA13_specialS);
		static readonly short[][] DFA13_transition = DFA.UnpackEncodedStringArray(DFA13_transitionS);

		protected class DFA13 : DFA
		{
			public DFA13(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 13;
				this.eot = DFA13_eot;
				this.eof = DFA13_eof;
				this.min = DFA13_min;
				this.max = DFA13_max;
				this.accept = DFA13_accept;
				this.special = DFA13_special;
				this.transition = DFA13_transition;

			}

			override public string Description
			{
				get { return "()* loopback of 462:2: ( options {greedy=false; k=2; } : NESTED_ACTION | SL_COMMENT | ML_COMMENT | ACTION_STRING_LITERAL | ACTION_CHAR_LITERAL | . )*"; }
			}

		}


		protected internal int DFA13_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			IIntStream input = _input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA13_0 = input.LA(1);

				s = -1;
				if ( (LA13_0 == '}') ) { s = 1; }

				else if ( (LA13_0 == '{') ) { s = 2; }

				else if ( (LA13_0 == '/') ) { s = 3; }

				else if ( (LA13_0 == '\"') ) { s = 4; }

				else if ( (LA13_0 == '\'') ) { s = 5; }

				else if ( ((LA13_0 >= '\u0000' && LA13_0 <= '!') || (LA13_0 >= '#' && LA13_0 <= '&') || (LA13_0 >= '(' && LA13_0 <= '.') || (LA13_0 >= '0' && LA13_0 <= 'z') || LA13_0 == '|' || (LA13_0 >= '~' && LA13_0 <= '\uFFFF')) ) { s = 6; }

				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA13_3 = input.LA(1);

				s = -1;
				if ( (LA13_3 == '/') ) { s = 7; }

				else if ( (LA13_3 == '*') ) { s = 8; }

				else if ( ((LA13_3 >= '\u0000' && LA13_3 <= ')') || (LA13_3 >= '+' && LA13_3 <= '.') || (LA13_3 >= '0' && LA13_3 <= '\uFFFF')) ) { s = 6; }

				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA13_4 = input.LA(1);

				s = -1;
				if ( (LA13_4 == '}') ) { s = 14; }

				else if ( (LA13_4 == '{') ) { s = 15; }

				else if ( (LA13_4 == '/') ) { s = 16; }

				else if ( (LA13_4 == '\"') ) { s = 17; }

				else if ( (LA13_4 == '\'') ) { s = 18; }

				else if ( (LA13_4 == '\\') ) { s = 19; }

				else if ( ((LA13_4 >= '\u0000' && LA13_4 <= '!') || (LA13_4 >= '#' && LA13_4 <= '&') || (LA13_4 >= '(' && LA13_4 <= '.') || (LA13_4 >= '0' && LA13_4 <= '[') || (LA13_4 >= ']' && LA13_4 <= 'z') || LA13_4 == '|' || (LA13_4 >= '~' && LA13_4 <= '\uFFFF')) ) { s = 20; }

				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA13_5 = input.LA(1);

				s = -1;
				if ( (LA13_5 == '}') ) { s = 21; }

				else if ( (LA13_5 == '{') ) { s = 22; }

				else if ( (LA13_5 == '/') ) { s = 23; }

				else if ( (LA13_5 == '\"') ) { s = 24; }

				else if ( (LA13_5 == '\'') ) { s = 6; }

				else if ( (LA13_5 == '\\') ) { s = 26; }

				else if ( ((LA13_5 >= '\u0000' && LA13_5 <= '!') || (LA13_5 >= '#' && LA13_5 <= '&') || (LA13_5 >= '(' && LA13_5 <= '.') || (LA13_5 >= '0' && LA13_5 <= '[') || (LA13_5 >= ']' && LA13_5 <= 'z') || LA13_5 == '|' || (LA13_5 >= '~' && LA13_5 <= '\uFFFF')) ) { s = 27; }

				if ( s >= 0 ) return s;
				break;
			}
			NoViableAltException nvae13 =
				new NoViableAltException(dfa.Description, 13, _s, input);
			dfa.Error(nvae13);
			throw nvae13;
		}
		const string DFA22_eotS =
			"\x01\uffff\x04\x24\x02\uffff\x01\x2f\x01\x24\x01\uffff\x01\x32"+
				"\x01\uffff\x01\x24\x01\uffff\x01\x24\x04\uffff\x01\x24\x01\x38\x01"+
					"\x3a\x0d\uffff\x01\x24\x02\uffff\x08\x24\x02\uffff\x01\x24\x02\uffff"+
						"\x04\x24\x08\uffff\x0f\x24\x0d\uffff\x06\x24\x01\x72\x08\x24\x02"+
							"\uffff\x01\x24\x01\x7d\x04\x24\x01\uffff\x03\x24\x01\u0085\x03\x24"+
								"\x01\u0089\x01\uffff\x01\x24\x01\uffff\x01\u008c\x02\x24\x01\u008f"+
									"\x01\u0090\x02\x24\x01\uffff\x03\x24\x02\uffff\x01\x24\x01\uffff"+
										"\x01\x24\x01\u0099\x03\uffff\x01\u009a\x01\x24\x01\u009c\x01\u009d"+
											"\x01\uffff\x02\x24\x02\uffff\x01\u00a0\x03\uffff\x01\u00a1\x02\uffff";
		const string DFA22_eofS =
			"\u00a2\uffff";
		const string DFA22_minS =
			"\x01\x09\x01\x65\x01\x61\x01\x68\x01\x72\x02\uffff\x01\x3e\x01"+
				"\x63\x01\uffff\x01\x3a\x01\uffff\x01\x69\x01\uffff\x01\x65\x04\uffff"+
					"\x01\x61\x01\x3d\x01\x28\x05\uffff\x01\x2a\x01\x00\x06\uffff\x01"+
						"\x70\x02\uffff\x01\x78\x01\x72\x01\x69\x01\x62\x01\x65\x01\x72\x01"+
							"\x6b\x01\x61\x02\uffff\x01\x6f\x02\uffff\x01\x61\x01\x6e\x02\x74"+
								"\x06\uffff\x02\x00\x01\x74\x01\x65\x01\x73\x01\x74\x01\x76\x01\x6c"+
									"\x01\x65\x01\x6f\x01\x65\x01\x6d\x01\x70\x01\x67\x01\x61\x01\x75"+
										"\x01\x63\x0b\x00\x02\uffff\x01\x69\x01\x72\x02\x65\x01\x61\x01\x69"+
											"\x01\x30\x01\x77\x01\x6e\x01\x6d\x01\x65\x01\x6d\x01\x6c\x01\x72"+
												"\x01\x68\x01\x00\x01\uffff\x01\x6f\x01\x30\x01\x72\x01\x63\x01\x74"+
													"\x01\x63\x01\uffff\x02\x73\x01\x61\x01\x30\x01\x65\x01\x6c\x01\x6e"+
														"\x01\x30\x01\x00\x01\x6e\x01\uffff\x01\x30\x01\x74\x01\x65\x02\x30"+
															"\x01\x09\x01\x72\x01\uffff\x01\x6e\x01\x79\x01\x73\x01\uffff\x01"+
																"\x00\x01\x73\x01\uffff\x01\x65\x01\x30\x03\uffff\x01\x30\x01\x74"+
																	"\x02\x30\x01\x00\x01\x09\x01\x64\x02\uffff\x01\x30\x03\uffff\x01"+
																		"\x30\x02\uffff";
		const string DFA22_maxS =
			"\x01\x7e\x01\x65\x01\x75\x02\x72\x02\uffff\x01\x3e\x01\x63\x01"+
				"\uffff\x01\x3a\x01\uffff\x01\x72\x01\uffff\x01\x65\x04\uffff\x01"+
					"\x61\x01\x3d\x01\x28\x05\uffff\x01\x2f\x01\uffff\x06\uffff\x01\x70"+
						"\x02\uffff\x01\x78\x01\x72\x01\x6f\x01\x62\x01\x65\x01\x72\x01\x6b"+
							"\x01\x61\x02\uffff\x01\x6f\x02\uffff\x01\x61\x01\x6e\x02\x74\x06"+
								"\uffff\x02\uffff\x01\x74\x01\x65\x01\x73\x01\x74\x01\x76\x01\x6c"+
									"\x01\x65\x01\x6f\x01\x65\x01\x6d\x01\x70\x01\x67\x01\x61\x01\x75"+
										"\x01\x63\x0b\uffff\x02\uffff\x01\x69\x01\x72\x02\x65\x01\x61\x01"+
											"\x69\x01\x7a\x01\x77\x01\x6e\x01\x6d\x01\x65\x01\x6d\x01\x6c\x01"+
												"\x72\x01\x68\x01\uffff\x01\uffff\x01\x6f\x01\x7a\x01\x72\x01\x63"+
													"\x01\x74\x01\x63\x01\uffff\x02\x73\x01\x61\x01\x7a\x01\x65\x01\x6c"+
														"\x01\x6e\x01\x7a\x01\uffff\x01\x6e\x01\uffff\x01\x7a\x01\x74\x01"+
															"\x65\x02\x7a\x01\x7b\x01\x72\x01\uffff\x01\x6e\x01\x79\x01\x73\x01"+
																"\uffff\x01\uffff\x01\x73\x01\uffff\x01\x65\x01\x7a\x03\uffff\x01"+
																	"\x7a\x01\x74\x02\x7a\x01\uffff\x01\x7b\x01\x64\x02\uffff\x01\x7a"+
																		"\x03\uffff\x01\x7a\x02\uffff";
		const string DFA22_acceptS =
			"\x05\uffff\x01\x05\x01\x06\x02\uffff\x01\x09\x01\uffff\x01\x0b"+
				"\x01\uffff\x01\x10\x01\uffff\x01\x14\x01\x15\x01\x16\x01\x17\x03"+
					"\uffff\x01\x1d\x01\x1f\x01\x21\x01\x22\x01\x23\x02\uffff\x01\x28"+
						"\x01\x29\x01\x2a\x01\x2b\x01\x2c\x01\x2d\x01\uffff\x01\x2e\x01\x31"+
							"\x08\uffff\x01\x1b\x01\x07\x01\uffff\x01\x0a\x01\x12\x04\uffff\x01"+
								"\x1a\x01\x20\x01\x1e\x01\x1c\x01\x24\x01\x25\x1c\uffff\x01\x27\x01"+
									"\x26\x10\uffff\x01\x26\x06\uffff\x01\x03\x0a\uffff\x01\x01\x07\uffff"+
										"\x01\x08\x03\uffff\x01\x18\x02\uffff\x01\x02\x02\uffff\x01\x0d\x01"+
											"\x13\x01\x30\x07\uffff\x01\x0e\x01\x04\x01\uffff\x01\x19\x01\x11"+
												"\x01\x2f\x01\uffff\x01\x0f\x01\x0c";
		const string DFA22_specialS =
			"\x1c\uffff\x01\x06\x20\uffff\x01\x05\x01\x10\x0f\uffff\x01\x08"+
				"\x01\x07\x01\x0a\x01\x09\x01\x0c\x01\x0b\x01\x0e\x01\x0d\x01\x0f"+
					"\x01\x03\x01\x11\x11\uffff\x01\x00\x10\uffff\x01\x02\x0e\uffff\x01"+
						"\x01\x0b\uffff\x01\x04\x0b\uffff}>";
		static readonly string[] DFA22_transitionS = {
			"\x02\x25\x02\uffff\x01\x25\x12\uffff\x01\x25\x01\x0d\x01\x1d"+
				"\x01\uffff\x01\x1a\x02\uffff\x01\x1c\x01\x10\x01\x12\x01\x0b"+
					"\x01\x14\x01\x0f\x01\x19\x01\x18\x01\x1b\x0a\x1f\x01\x0a\x01"+
						"\x05\x01\x1e\x01\x07\x01\uffff\x01\x17\x01\x09\x1a\x22\x01\x20"+
							"\x02\uffff\x01\x15\x02\uffff\x02\x24\x01\x13\x02\x24\x01\x0c"+
								"\x01\x04\x04\x24\x01\x01\x02\x24\x01\x23\x01\x02\x01\x24\x01"+
									"\x0e\x01\x08\x01\x03\x06\x24\x01\x21\x01\x11\x01\x06\x01\x16",
			"\x01\x26",
			"\x01\x27\x10\uffff\x01\x28\x02\uffff\x01\x29",
			"\x01\x2b\x06\uffff\x01\x2c\x02\uffff\x01\x2a",
			"\x01\x2d",
			"",
			"",
			"\x01\x2e",
			"\x01\x30",
			"",
			"\x01\x31",
			"",
			"\x01\x34\x08\uffff\x01\x33",
			"",
			"\x01\x35",
			"",
			"",
			"",
			"",
			"\x01\x36",
			"\x01\x37",
			"\x01\x39",
			"",
			"",
			"",
			"",
			"",
			"\x01\x3c\x04\uffff\x01\x3b",
			"\x27\x3e\x01\uffff\x34\x3e\x01\x3d\uffa3\x3e",
			"",
			"",
			"",
			"",
			"",
			"",
			"\x01\x3f",
			"",
			"",
			"\x01\x40",
			"\x01\x41",
			"\x01\x43\x05\uffff\x01\x42",
			"\x01\x44",
			"\x01\x45",
			"\x01\x46",
			"\x01\x47",
			"\x01\x48",
			"",
			"",
			"\x01\x49",
			"",
			"",
			"\x01\x4a",
			"\x01\x4b",
			"\x01\x4c",
			"\x01\x4d",
			"",
			"",
			"",
			"",
			"",
			"",
			"\x22\x58\x01\x53\x04\x58\x01\x54\x16\x58\x01\x56\x1d\x58\x01"+
				"\x55\x05\x58\x01\x51\x03\x58\x01\x52\x07\x58\x01\x4e\x03\x58"+
					"\x01\x4f\x01\x58\x01\x50\x01\x57\uff8a\x58",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x01\x5b",
			"\x01\x5c",
			"\x01\x5d",
			"\x01\x5e",
			"\x01\x5f",
			"\x01\x60",
			"\x01\x61",
			"\x01\x62",
			"\x01\x63",
			"\x01\x64",
			"\x01\x65",
			"\x01\x66",
			"\x01\x67",
			"\x01\x68",
			"\x01\x69",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x27\x59\x01\x5a\x08\x59\x0a\x6a\x07\x59\x06\x6a\x1a\x59\x06"+
				"\x6a\uff99\x59",
			"\x27\x59\x01\x5a\uffd8\x59",
			"",
			"",
			"\x01\x6c",
			"\x01\x6d",
			"\x01\x6e",
			"\x01\x6f",
			"\x01\x70",
			"\x01\x71",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x01\x73",
			"\x01\x74",
			"\x01\x75",
			"\x01\x76",
			"\x01\x77",
			"\x01\x78",
			"\x01\x79",
			"\x01\x7a",
			"\x30\x59\x0a\x7b\x07\x59\x06\x7b\x1a\x59\x06\x7b\uff99\x59",
			"",
			"\x01\x7c",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x01\x7e",
			"\x01\x7f",
			"\x01\u0080",
			"\x01\u0081",
			"",
			"\x01\u0082",
			"\x01\u0083",
			"\x01\u0084",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x01\u0086",
			"\x01\u0087",
			"\x01\u0088",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x30\x59\x0a\u008a\x07\x59\x06\u008a\x1a\x59\x06\u008a\uff99"+
				"\x59",
			"\x01\u008b",
			"",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x01\u008d",
			"\x01\u008e",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x02\u0091\x02\uffff\x01\u0091\x12\uffff\x01\u0091\x0e\uffff"+
				"\x01\u0091\x4b\uffff\x01\u0091",
			"\x01\u0092",
			"",
			"\x01\u0093",
			"\x01\u0094",
			"\x01\u0095",
			"",
			"\x30\x59\x0a\u0096\x07\x59\x06\u0096\x1a\x59\x06\u0096\uff99"+
				"\x59",
			"\x01\u0097",
			"",
			"\x01\u0098",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"",
			"",
			"",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x01\u009b",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"\x27\x59\x01\x5a\uffd8\x59",
			"\x02\u009e\x02\uffff\x01\u009e\x12\uffff\x01\u009e\x0e\uffff"+
				"\x01\u009e\x4b\uffff\x01\u009e",
			"\x01\u009f",
			"",
			"",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"",
			"",
			"",
			"\x0a\x24\x07\uffff\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a"+
				"\x24",
			"",
			""
		};

		static readonly short[] DFA22_eot = DFA.UnpackEncodedString(DFA22_eotS);
		static readonly short[] DFA22_eof = DFA.UnpackEncodedString(DFA22_eofS);
		static readonly char[] DFA22_min = DFA.UnpackEncodedStringToUnsignedChars(DFA22_minS);
		static readonly char[] DFA22_max = DFA.UnpackEncodedStringToUnsignedChars(DFA22_maxS);
		static readonly short[] DFA22_accept = DFA.UnpackEncodedString(DFA22_acceptS);
		static readonly short[] DFA22_special = DFA.UnpackEncodedString(DFA22_specialS);
		static readonly short[][] DFA22_transition = DFA.UnpackEncodedStringArray(DFA22_transitionS);

		protected class DFA22 : DFA
		{
			public DFA22(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 22;
				this.eot = DFA22_eot;
				this.eof = DFA22_eof;
				this.min = DFA22_min;
				this.max = DFA22_max;
				this.accept = DFA22_accept;
				this.special = DFA22_special;
				this.transition = DFA22_transition;

			}

			override public string Description
			{
				get { return "1:1: Tokens : ( T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | SL_COMMENT | ML_COMMENT | CHAR_LITERAL | STRING_LITERAL | DOUBLE_QUOTE_STRING_LITERAL | DOUBLE_ANGLE_STRING_LITERAL | INT | ARG_ACTION | ACTION | TOKEN_REF | RULE_REF | OPTIONS | TOKENS | WS );"; }
			}

		}


		protected internal int DFA22_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			IIntStream input = _input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA22_106 = input.LA(1);

				s = -1;
				if ( ((LA22_106 >= '0' && LA22_106 <= '9') || (LA22_106 >= 'A' && LA22_106 <= 'F') || (LA22_106 >= 'a' && LA22_106 <= 'f')) ) { s = 123; }

				else if ( ((LA22_106 >= '\u0000' && LA22_106 <= '/') || (LA22_106 >= ':' && LA22_106 <= '@') || (LA22_106 >= 'G' && LA22_106 <= '`') || (LA22_106 >= 'g' && LA22_106 <= '\uFFFF')) ) { s = 89; }

				if ( s >= 0 ) return s;
				break;
			case 1 : 
				int LA22_138 = input.LA(1);

				s = -1;
				if ( ((LA22_138 >= '0' && LA22_138 <= '9') || (LA22_138 >= 'A' && LA22_138 <= 'F') || (LA22_138 >= 'a' && LA22_138 <= 'f')) ) { s = 150; }

				else if ( ((LA22_138 >= '\u0000' && LA22_138 <= '/') || (LA22_138 >= ':' && LA22_138 <= '@') || (LA22_138 >= 'G' && LA22_138 <= '`') || (LA22_138 >= 'g' && LA22_138 <= '\uFFFF')) ) { s = 89; }

				if ( s >= 0 ) return s;
				break;
			case 2 : 
				int LA22_123 = input.LA(1);

				s = -1;
				if ( ((LA22_123 >= '0' && LA22_123 <= '9') || (LA22_123 >= 'A' && LA22_123 <= 'F') || (LA22_123 >= 'a' && LA22_123 <= 'f')) ) { s = 138; }

				else if ( ((LA22_123 >= '\u0000' && LA22_123 <= '/') || (LA22_123 >= ':' && LA22_123 <= '@') || (LA22_123 >= 'G' && LA22_123 <= '`') || (LA22_123 >= 'g' && LA22_123 <= '\uFFFF')) ) { s = 89; }

				if ( s >= 0 ) return s;
				break;
			case 3 : 
				int LA22_87 = input.LA(1);

				s = -1;
				if ( ((LA22_87 >= '\u0000' && LA22_87 <= '&') || (LA22_87 >= '(' && LA22_87 <= '/') || (LA22_87 >= ':' && LA22_87 <= '@') || (LA22_87 >= 'G' && LA22_87 <= '`') || (LA22_87 >= 'g' && LA22_87 <= '\uFFFF')) ) { s = 89; }

				else if ( ((LA22_87 >= '0' && LA22_87 <= '9') || (LA22_87 >= 'A' && LA22_87 <= 'F') || (LA22_87 >= 'a' && LA22_87 <= 'f')) ) { s = 106; }

				else if ( (LA22_87 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 4 : 
				int LA22_150 = input.LA(1);

				s = -1;
				if ( (LA22_150 == '\'') ) { s = 90; }

				else if ( ((LA22_150 >= '\u0000' && LA22_150 <= '&') || (LA22_150 >= '(' && LA22_150 <= '\uFFFF')) ) { s = 89; }

				if ( s >= 0 ) return s;
				break;
			case 5 : 
				int LA22_61 = input.LA(1);

				s = -1;
				if ( (LA22_61 == 'n') ) { s = 78; }

				else if ( (LA22_61 == 'r') ) { s = 79; }

				else if ( (LA22_61 == 't') ) { s = 80; }

				else if ( (LA22_61 == 'b') ) { s = 81; }

				else if ( (LA22_61 == 'f') ) { s = 82; }

				else if ( (LA22_61 == '\"') ) { s = 83; }

				else if ( (LA22_61 == '\'') ) { s = 84; }

				else if ( (LA22_61 == '\\') ) { s = 85; }

				else if ( (LA22_61 == '>') ) { s = 86; }

				else if ( (LA22_61 == 'u') ) { s = 87; }

				else if ( ((LA22_61 >= '\u0000' && LA22_61 <= '!') || (LA22_61 >= '#' && LA22_61 <= '&') || (LA22_61 >= '(' && LA22_61 <= '=') || (LA22_61 >= '?' && LA22_61 <= '[') || (LA22_61 >= ']' && LA22_61 <= 'a') || (LA22_61 >= 'c' && LA22_61 <= 'e') || (LA22_61 >= 'g' && LA22_61 <= 'm') || (LA22_61 >= 'o' && LA22_61 <= 'q') || LA22_61 == 's' || (LA22_61 >= 'v' && LA22_61 <= '\uFFFF')) ) { s = 88; }

				if ( s >= 0 ) return s;
				break;
			case 6 : 
				int LA22_28 = input.LA(1);

				s = -1;
				if ( (LA22_28 == '\\') ) { s = 61; }

				else if ( ((LA22_28 >= '\u0000' && LA22_28 <= '&') || (LA22_28 >= '(' && LA22_28 <= '[') || (LA22_28 >= ']' && LA22_28 <= '\uFFFF')) ) { s = 62; }

				if ( s >= 0 ) return s;
				break;
			case 7 : 
				int LA22_79 = input.LA(1);

				s = -1;
				if ( ((LA22_79 >= '\u0000' && LA22_79 <= '&') || (LA22_79 >= '(' && LA22_79 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_79 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 8 : 
				int LA22_78 = input.LA(1);

				s = -1;
				if ( ((LA22_78 >= '\u0000' && LA22_78 <= '&') || (LA22_78 >= '(' && LA22_78 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_78 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 9 : 
				int LA22_81 = input.LA(1);

				s = -1;
				if ( ((LA22_81 >= '\u0000' && LA22_81 <= '&') || (LA22_81 >= '(' && LA22_81 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_81 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 10 : 
				int LA22_80 = input.LA(1);

				s = -1;
				if ( ((LA22_80 >= '\u0000' && LA22_80 <= '&') || (LA22_80 >= '(' && LA22_80 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_80 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 11 : 
				int LA22_83 = input.LA(1);

				s = -1;
				if ( ((LA22_83 >= '\u0000' && LA22_83 <= '&') || (LA22_83 >= '(' && LA22_83 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_83 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 12 : 
				int LA22_82 = input.LA(1);

				s = -1;
				if ( (LA22_82 == '\'') ) { s = 90; }

				else if ( ((LA22_82 >= '\u0000' && LA22_82 <= '&') || (LA22_82 >= '(' && LA22_82 <= '\uFFFF')) ) { s = 89; }

				if ( s >= 0 ) return s;
				break;
			case 13 : 
				int LA22_85 = input.LA(1);

				s = -1;
				if ( ((LA22_85 >= '\u0000' && LA22_85 <= '&') || (LA22_85 >= '(' && LA22_85 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_85 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 14 : 
				int LA22_84 = input.LA(1);

				s = -1;
				if ( ((LA22_84 >= '\u0000' && LA22_84 <= '&') || (LA22_84 >= '(' && LA22_84 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_84 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 15 : 
				int LA22_86 = input.LA(1);

				s = -1;
				if ( ((LA22_86 >= '\u0000' && LA22_86 <= '&') || (LA22_86 >= '(' && LA22_86 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_86 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 16 : 
				int LA22_62 = input.LA(1);

				s = -1;
				if ( ((LA22_62 >= '\u0000' && LA22_62 <= '&') || (LA22_62 >= '(' && LA22_62 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_62 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			case 17 : 
				int LA22_88 = input.LA(1);

				s = -1;
				if ( ((LA22_88 >= '\u0000' && LA22_88 <= '&') || (LA22_88 >= '(' && LA22_88 <= '\uFFFF')) ) { s = 89; }

				else if ( (LA22_88 == '\'') ) { s = 90; }

				if ( s >= 0 ) return s;
				break;
			}
			NoViableAltException nvae22 =
				new NoViableAltException(dfa.Description, 22, _s, input);
			dfa.Error(nvae22);
			throw nvae22;
		}
 
    
	}
}
