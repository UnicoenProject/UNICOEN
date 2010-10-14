// $ANTLR 3.2 Sep 23, 2009 12:02:23 ANTLRv3Tree.g 2010-08-16 20:42:03

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using Antlr.Runtime;
using Antlr.Runtime.Tree;

/** ANTLR v3 tree grammar to walk trees created by ANTLRv3.g */
namespace Ucpf.Grammar.Analyzer.Antlr
{
	public partial class ANTLRv3Tree : TreeParser
	{
		public static readonly string[] tokenNames = new string[] 
		{
			"<invalid>", 
			"<EOR>", 
			"<DOWN>", 
			"<UP>", 
			"DOC_COMMENT", 
			"PARSER", 
			"LEXER", 
			"RULE", 
			"BLOCK", 
			"OPTIONAL", 
			"CLOSURE", 
			"POSITIVE_CLOSURE", 
			"SYNPRED", 
			"RANGE", 
			"CHAR_RANGE", 
			"EPSILON", 
			"ALT", 
			"EOR", 
			"EOB", 
			"EOA", 
			"ID", 
			"ARG", 
			"ARGLIST", 
			"RET", 
			"LEXER_GRAMMAR", 
			"PARSER_GRAMMAR", 
			"TREE_GRAMMAR", 
			"COMBINED_GRAMMAR", 
			"INITACTION", 
			"LABEL", 
			"TEMPLATE", 
			"SCOPE", 
			"SEMPRED", 
			"GATED_SEMPRED", 
			"SYN_SEMPRED", 
			"BACKTRACK_SEMPRED", 
			"FRAGMENT", 
			"TREE_BEGIN", 
			"ROOT", 
			"BANG", 
			"REWRITE", 
			"TOKENS", 
			"TOKEN_REF", 
			"STRING_LITERAL", 
			"CHAR_LITERAL", 
			"ACTION", 
			"OPTIONS", 
			"INT", 
			"ARG_ACTION", 
			"RULE_REF", 
			"DOUBLE_QUOTE_STRING_LITERAL", 
			"DOUBLE_ANGLE_STRING_LITERAL", 
			"SRC", 
			"SL_COMMENT", 
			"ML_COMMENT", 
			"LITERAL_CHAR", 
			"ESC", 
			"XDIGIT", 
			"NESTED_ARG_ACTION", 
			"ACTION_STRING_LITERAL", 
			"ACTION_CHAR_LITERAL", 
			"NESTED_ACTION", 
			"ACTION_ESC", 
			"WS_LOOP", 
			"WS", 
			"'lexer'", 
			"'parser'", 
			"'tree'", 
			"'grammar'", 
			"';'", 
			"'}'", 
			"'='", 
			"'@'", 
			"'::'", 
			"'*'", 
			"'protected'", 
			"'public'", 
			"'private'", 
			"'returns'", 
			"':'", 
			"'throws'", 
			"','", 
			"'('", 
			"'|'", 
			"')'", 
			"'catch'", 
			"'finally'", 
			"'+='", 
			"'=>'", 
			"'~'", 
			"'?'", 
			"'+'", 
			"'.'", 
			"'$'"
		};

		public const int BACKTRACK_SEMPRED = 35;
		public const int DOUBLE_ANGLE_STRING_LITERAL = 51;
		public const int LEXER_GRAMMAR = 24;
		public const int EOA = 19;
		public const int ARGLIST = 22;
		public const int EOF = -1;
		public const int SEMPRED = 32;
		public const int ACTION = 45;
		public const int EOB = 18;
		public const int TOKEN_REF = 42;
		public const int T__93 = 93;
		public const int T__91 = 91;
		public const int RET = 23;
		public const int T__92 = 92;
		public const int STRING_LITERAL = 43;
		public const int T__90 = 90;
		public const int ARG = 21;
		public const int EOR = 17;
		public const int ARG_ACTION = 48;
		public const int DOUBLE_QUOTE_STRING_LITERAL = 50;
		public const int NESTED_ARG_ACTION = 58;
		public const int ACTION_CHAR_LITERAL = 60;
		public const int INITACTION = 28;
		public const int T__80 = 80;
		public const int T__81 = 81;
		public const int T__82 = 82;
		public const int RULE = 7;
		public const int ACTION_ESC = 62;
		public const int T__83 = 83;
		public const int PARSER_GRAMMAR = 25;
		public const int SRC = 52;
		public const int INT = 47;
		public const int CHAR_RANGE = 14;
		public const int EPSILON = 15;
		public const int T__85 = 85;
		public const int T__84 = 84;
		public const int T__87 = 87;
		public const int T__86 = 86;
		public const int REWRITE = 40;
		public const int T__89 = 89;
		public const int T__88 = 88;
		public const int WS = 64;
		public const int T__71 = 71;
		public const int T__72 = 72;
		public const int COMBINED_GRAMMAR = 27;
		public const int T__70 = 70;
		public const int LEXER = 6;
		public const int SL_COMMENT = 53;
		public const int TREE_GRAMMAR = 26;
		public const int T__76 = 76;
		public const int CLOSURE = 10;
		public const int T__75 = 75;
		public const int PARSER = 5;
		public const int T__74 = 74;
		public const int T__73 = 73;
		public const int T__79 = 79;
		public const int T__78 = 78;
		public const int T__77 = 77;
		public const int T__68 = 68;
		public const int T__69 = 69;
		public const int T__66 = 66;
		public const int T__67 = 67;
		public const int T__65 = 65;
		public const int NESTED_ACTION = 61;
		public const int ESC = 56;
		public const int FRAGMENT = 36;
		public const int ID = 20;
		public const int TREE_BEGIN = 37;
		public const int ML_COMMENT = 54;
		public const int ALT = 16;
		public const int SCOPE = 31;
		public const int DOC_COMMENT = 4;
		public const int WS_LOOP = 63;
		public const int RANGE = 13;
		public const int TOKENS = 41;
		public const int GATED_SEMPRED = 33;
		public const int LITERAL_CHAR = 55;
		public const int BANG = 39;
		public const int ACTION_STRING_LITERAL = 59;
		public const int ROOT = 38;
		public const int RULE_REF = 49;
		public const int SYNPRED = 12;
		public const int OPTIONAL = 9;
		public const int CHAR_LITERAL = 44;
		public const int LABEL = 29;
		public const int TEMPLATE = 30;
		public const int SYN_SEMPRED = 34;
		public const int XDIGIT = 57;
		public const int BLOCK = 8;
		public const int POSITIVE_CLOSURE = 11;
		public const int OPTIONS = 46;

		// delegates
		// delegators



		public ANTLRv3Tree(ITreeNodeStream input)
			: this(input, new RecognizerSharedState()) {
			}

		public ANTLRv3Tree(ITreeNodeStream input, RecognizerSharedState state)
			: base(input, state) {
			InitializeCyclicDFAs();

             
			}
        

		override public string[] TokenNames {
			get { return ANTLRv3Tree.tokenNames; }
		}

		override public string GrammarFileName {
			get { return "ANTLRv3Tree.g"; }
		}



		// $ANTLR start "grammarDef"
		// ANTLRv3Tree.g:38:1: grammarDef : ^( grammarType ID ( DOC_COMMENT )? ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ ) ;
		public void grammarDef() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:39:5: ( ^( grammarType ID ( DOC_COMMENT )? ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ ) )
				// ANTLRv3Tree.g:39:9: ^( grammarType ID ( DOC_COMMENT )? ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ )
				{
					PushFollow(FOLLOW_grammarType_in_grammarDef52);
					grammarType();
					state.followingStackPointer--;


					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_grammarDef54); 
					// ANTLRv3Tree.g:39:27: ( DOC_COMMENT )?
					int alt1 = 2;
					int LA1_0 = input.LA(1);

					if ( (LA1_0 == DOC_COMMENT) )
					{
						alt1 = 1;
					}
					switch (alt1) 
					{
					case 1 :
						// ANTLRv3Tree.g:39:27: DOC_COMMENT
					{
						Match(input,DOC_COMMENT,FOLLOW_DOC_COMMENT_in_grammarDef56); 

					}
						break;

					}

					// ANTLRv3Tree.g:39:40: ( optionsSpec )?
					int alt2 = 2;
					int LA2_0 = input.LA(1);

					if ( (LA2_0 == OPTIONS) )
					{
						alt2 = 1;
					}
					switch (alt2) 
					{
					case 1 :
						// ANTLRv3Tree.g:39:40: optionsSpec
					{
						PushFollow(FOLLOW_optionsSpec_in_grammarDef59);
						optionsSpec();
						state.followingStackPointer--;


					}
						break;

					}

					// ANTLRv3Tree.g:39:53: ( tokensSpec )?
					int alt3 = 2;
					int LA3_0 = input.LA(1);

					if ( (LA3_0 == TOKENS) )
					{
						alt3 = 1;
					}
					switch (alt3) 
					{
					case 1 :
						// ANTLRv3Tree.g:39:53: tokensSpec
					{
						PushFollow(FOLLOW_tokensSpec_in_grammarDef62);
						tokensSpec();
						state.followingStackPointer--;


					}
						break;

					}

					// ANTLRv3Tree.g:39:65: ( attrScope )*
					do 
					{
						int alt4 = 2;
						int LA4_0 = input.LA(1);

						if ( (LA4_0 == SCOPE) )
						{
							alt4 = 1;
						}


						switch (alt4) 
						{
						case 1 :
							// ANTLRv3Tree.g:39:65: attrScope
						{
							PushFollow(FOLLOW_attrScope_in_grammarDef65);
							attrScope();
							state.followingStackPointer--;


						}
							break;

						default:
							goto loop4;
						}
					} while (true);

					loop4:
					;	// Stops C# compiler whining that label 'loop4' has no statements

					// ANTLRv3Tree.g:39:76: ( action )*
					do 
					{
						int alt5 = 2;
						int LA5_0 = input.LA(1);

						if ( (LA5_0 == 72) )
						{
							alt5 = 1;
						}


						switch (alt5) 
						{
						case 1 :
							// ANTLRv3Tree.g:39:76: action
						{
							PushFollow(FOLLOW_action_in_grammarDef68);
							action();
							state.followingStackPointer--;


						}
							break;

						default:
							goto loop5;
						}
					} while (true);

					loop5:
					;	// Stops C# compiler whining that label 'loop5' has no statements

					// ANTLRv3Tree.g:39:84: ( rule )+
					int cnt6 = 0;
					do 
					{
						int alt6 = 2;
						int LA6_0 = input.LA(1);

						if ( (LA6_0 == RULE) )
						{
							alt6 = 1;
						}


						switch (alt6) 
						{
						case 1 :
							// ANTLRv3Tree.g:39:84: rule
						{
							PushFollow(FOLLOW_rule_in_grammarDef71);
							rule();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt6 >= 1 ) goto loop6;
							EarlyExitException eee6 =
								new EarlyExitException(6, input);
							throw eee6;
						}
						cnt6++;
					} while (true);

					loop6:
					;	// Stops C# compiler whining that label 'loop6' has no statements


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "grammarDef"


		// $ANTLR start "grammarType"
		// ANTLRv3Tree.g:42:1: grammarType : ( LEXER_GRAMMAR | PARSER_GRAMMAR | TREE_GRAMMAR | COMBINED_GRAMMAR );
		public void grammarType() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:43:2: ( LEXER_GRAMMAR | PARSER_GRAMMAR | TREE_GRAMMAR | COMBINED_GRAMMAR )
				// ANTLRv3Tree.g:
				{
					if ( (input.LA(1) >= LEXER_GRAMMAR && input.LA(1) <= COMBINED_GRAMMAR) ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "grammarType"


		// $ANTLR start "tokensSpec"
		// ANTLRv3Tree.g:49:1: tokensSpec : ^( TOKENS ( tokenSpec )+ ) ;
		public void tokensSpec() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:50:2: ( ^( TOKENS ( tokenSpec )+ ) )
				// ANTLRv3Tree.g:50:4: ^( TOKENS ( tokenSpec )+ )
				{
					Match(input,TOKENS,FOLLOW_TOKENS_in_tokensSpec127); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:50:13: ( tokenSpec )+
					int cnt7 = 0;
					do 
					{
						int alt7 = 2;
						int LA7_0 = input.LA(1);

						if ( (LA7_0 == TOKEN_REF || LA7_0 == 71) )
						{
							alt7 = 1;
						}


						switch (alt7) 
						{
						case 1 :
							// ANTLRv3Tree.g:50:13: tokenSpec
						{
							PushFollow(FOLLOW_tokenSpec_in_tokensSpec129);
							tokenSpec();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt7 >= 1 ) goto loop7;
							EarlyExitException eee7 =
								new EarlyExitException(7, input);
							throw eee7;
						}
						cnt7++;
					} while (true);

					loop7:
					;	// Stops C# compiler whining that label 'loop7' has no statements


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "tokensSpec"


		// $ANTLR start "tokenSpec"
		// ANTLRv3Tree.g:53:1: tokenSpec : ( ^( '=' TOKEN_REF STRING_LITERAL ) | ^( '=' TOKEN_REF CHAR_LITERAL ) | TOKEN_REF );
		public void tokenSpec() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:54:2: ( ^( '=' TOKEN_REF STRING_LITERAL ) | ^( '=' TOKEN_REF CHAR_LITERAL ) | TOKEN_REF )
				int alt8 = 3;
				int LA8_0 = input.LA(1);

				if ( (LA8_0 == 71) )
				{
					int LA8_1 = input.LA(2);

					if ( (LA8_1 == DOWN) )
					{
						int LA8_3 = input.LA(3);

						if ( (LA8_3 == TOKEN_REF) )
						{
							int LA8_4 = input.LA(4);

							if ( (LA8_4 == STRING_LITERAL) )
							{
								alt8 = 1;
							}
							else if ( (LA8_4 == CHAR_LITERAL) )
							{
								alt8 = 2;
							}
							else 
							{
								NoViableAltException nvae_d8s4 =
									new NoViableAltException("", 8, 4, input);

								throw nvae_d8s4;
							}
						}
						else 
						{
							NoViableAltException nvae_d8s3 =
								new NoViableAltException("", 8, 3, input);

							throw nvae_d8s3;
						}
					}
					else 
					{
						NoViableAltException nvae_d8s1 =
							new NoViableAltException("", 8, 1, input);

						throw nvae_d8s1;
					}
				}
				else if ( (LA8_0 == TOKEN_REF) )
				{
					alt8 = 3;
				}
				else 
				{
					NoViableAltException nvae_d8s0 =
						new NoViableAltException("", 8, 0, input);

					throw nvae_d8s0;
				}
				switch (alt8) 
				{
				case 1 :
					// ANTLRv3Tree.g:54:4: ^( '=' TOKEN_REF STRING_LITERAL )
				{
					Match(input,71,FOLLOW_71_in_tokenSpec143); 

					Match(input, Token.DOWN, null); 
					Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_tokenSpec145); 
					Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_tokenSpec147); 

					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:55:4: ^( '=' TOKEN_REF CHAR_LITERAL )
				{
					Match(input,71,FOLLOW_71_in_tokenSpec154); 

					Match(input, Token.DOWN, null); 
					Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_tokenSpec156); 
					Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_tokenSpec158); 

					Match(input, Token.UP, null); 

				}
					break;
				case 3 :
					// ANTLRv3Tree.g:56:4: TOKEN_REF
				{
					Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_tokenSpec164); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "tokenSpec"


		// $ANTLR start "attrScope"
		// ANTLRv3Tree.g:59:1: attrScope : ^( 'scope' ID ACTION ) ;
		public void attrScope() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:60:2: ( ^( 'scope' ID ACTION ) )
				// ANTLRv3Tree.g:60:4: ^( 'scope' ID ACTION )
				{
					Match(input,SCOPE,FOLLOW_SCOPE_in_attrScope176); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_attrScope178); 
					Match(input,ACTION,FOLLOW_ACTION_in_attrScope180); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "attrScope"


		// $ANTLR start "action"
		// ANTLRv3Tree.g:63:1: action : ( ^( '@' ID ID ACTION ) | ^( '@' ID ACTION ) );
		public void action() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:64:2: ( ^( '@' ID ID ACTION ) | ^( '@' ID ACTION ) )
				int alt9 = 2;
				int LA9_0 = input.LA(1);

				if ( (LA9_0 == 72) )
				{
					int LA9_1 = input.LA(2);

					if ( (LA9_1 == DOWN) )
					{
						int LA9_2 = input.LA(3);

						if ( (LA9_2 == ID) )
						{
							int LA9_3 = input.LA(4);

							if ( (LA9_3 == ID) )
							{
								alt9 = 1;
							}
							else if ( (LA9_3 == ACTION) )
							{
								alt9 = 2;
							}
							else 
							{
								NoViableAltException nvae_d9s3 =
									new NoViableAltException("", 9, 3, input);

								throw nvae_d9s3;
							}
						}
						else 
						{
							NoViableAltException nvae_d9s2 =
								new NoViableAltException("", 9, 2, input);

							throw nvae_d9s2;
						}
					}
					else 
					{
						NoViableAltException nvae_d9s1 =
							new NoViableAltException("", 9, 1, input);

						throw nvae_d9s1;
					}
				}
				else 
				{
					NoViableAltException nvae_d9s0 =
						new NoViableAltException("", 9, 0, input);

					throw nvae_d9s0;
				}
				switch (alt9) 
				{
				case 1 :
					// ANTLRv3Tree.g:64:4: ^( '@' ID ID ACTION )
				{
					Match(input,72,FOLLOW_72_in_action193); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_action195); 
					Match(input,ID,FOLLOW_ID_in_action197); 
					Match(input,ACTION,FOLLOW_ACTION_in_action199); 

					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:65:4: ^( '@' ID ACTION )
				{
					Match(input,72,FOLLOW_72_in_action206); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_action208); 
					Match(input,ACTION,FOLLOW_ACTION_in_action210); 

					Match(input, Token.UP, null); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "action"


		// $ANTLR start "optionsSpec"
		// ANTLRv3Tree.g:68:1: optionsSpec : ^( OPTIONS ( option )+ ) ;
		public void optionsSpec() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:69:2: ( ^( OPTIONS ( option )+ ) )
				// ANTLRv3Tree.g:69:4: ^( OPTIONS ( option )+ )
				{
					Match(input,OPTIONS,FOLLOW_OPTIONS_in_optionsSpec223); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:69:14: ( option )+
					int cnt10 = 0;
					do 
					{
						int alt10 = 2;
						int LA10_0 = input.LA(1);

						if ( (LA10_0 == 71) )
						{
							alt10 = 1;
						}


						switch (alt10) 
						{
						case 1 :
							// ANTLRv3Tree.g:69:14: option
						{
							PushFollow(FOLLOW_option_in_optionsSpec225);
							option();
							state.followingStackPointer--;


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


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "optionsSpec"


		// $ANTLR start "option"
		// ANTLRv3Tree.g:72:1: option : ^( '=' ID optionValue ) ;
		public void option() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:73:5: ( ^( '=' ID optionValue ) )
				// ANTLRv3Tree.g:73:9: ^( '=' ID optionValue )
				{
					Match(input,71,FOLLOW_71_in_option244); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_option246); 
					PushFollow(FOLLOW_optionValue_in_option248);
					optionValue();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "option"


		// $ANTLR start "optionValue"
		// ANTLRv3Tree.g:76:1: optionValue : ( ID | STRING_LITERAL | CHAR_LITERAL | INT );
		public void optionValue() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:77:5: ( ID | STRING_LITERAL | CHAR_LITERAL | INT )
				// ANTLRv3Tree.g:
				{
					if ( input.LA(1) == ID || (input.LA(1) >= STRING_LITERAL && input.LA(1) <= CHAR_LITERAL) || input.LA(1) == INT ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "optionValue"


		// $ANTLR start "rule"
		// ANTLRv3Tree.g:83:1: rule : ^( RULE ID ( modifier )? ( ^( ARG ARG_ACTION ) )? ( ^( RET ARG_ACTION ) )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* altList ( exceptionGroup )? EOR ) ;
		public void rule() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:84:2: ( ^( RULE ID ( modifier )? ( ^( ARG ARG_ACTION ) )? ( ^( RET ARG_ACTION ) )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* altList ( exceptionGroup )? EOR ) )
				// ANTLRv3Tree.g:84:4: ^( RULE ID ( modifier )? ( ^( ARG ARG_ACTION ) )? ( ^( RET ARG_ACTION ) )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* altList ( exceptionGroup )? EOR )
				{
					Match(input,RULE,FOLLOW_RULE_in_rule314); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_rule316); 
					// ANTLRv3Tree.g:84:15: ( modifier )?
					int alt11 = 2;
					int LA11_0 = input.LA(1);

					if ( (LA11_0 == FRAGMENT || (LA11_0 >= 75 && LA11_0 <= 77)) )
					{
						alt11 = 1;
					}
					switch (alt11) 
					{
					case 1 :
						// ANTLRv3Tree.g:84:15: modifier
					{
						PushFollow(FOLLOW_modifier_in_rule318);
						modifier();
						state.followingStackPointer--;


					}
						break;

					}

					// ANTLRv3Tree.g:84:25: ( ^( ARG ARG_ACTION ) )?
					int alt12 = 2;
					int LA12_0 = input.LA(1);

					if ( (LA12_0 == ARG) )
					{
						alt12 = 1;
					}
					switch (alt12) 
					{
					case 1 :
						// ANTLRv3Tree.g:84:26: ^( ARG ARG_ACTION )
					{
						Match(input,ARG,FOLLOW_ARG_in_rule323); 

						Match(input, Token.DOWN, null); 
						Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rule325); 

						Match(input, Token.UP, null); 

					}
						break;

					}

					// ANTLRv3Tree.g:84:46: ( ^( RET ARG_ACTION ) )?
					int alt13 = 2;
					int LA13_0 = input.LA(1);

					if ( (LA13_0 == RET) )
					{
						alt13 = 1;
					}
					switch (alt13) 
					{
					case 1 :
						// ANTLRv3Tree.g:84:47: ^( RET ARG_ACTION )
					{
						Match(input,RET,FOLLOW_RET_in_rule332); 

						Match(input, Token.DOWN, null); 
						Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rule334); 

						Match(input, Token.UP, null); 

					}
						break;

					}

					// ANTLRv3Tree.g:85:9: ( optionsSpec )?
					int alt14 = 2;
					int LA14_0 = input.LA(1);

					if ( (LA14_0 == OPTIONS) )
					{
						alt14 = 1;
					}
					switch (alt14) 
					{
					case 1 :
						// ANTLRv3Tree.g:85:9: optionsSpec
					{
						PushFollow(FOLLOW_optionsSpec_in_rule347);
						optionsSpec();
						state.followingStackPointer--;


					}
						break;

					}

					// ANTLRv3Tree.g:85:22: ( ruleScopeSpec )?
					int alt15 = 2;
					int LA15_0 = input.LA(1);

					if ( (LA15_0 == SCOPE) )
					{
						alt15 = 1;
					}
					switch (alt15) 
					{
					case 1 :
						// ANTLRv3Tree.g:85:22: ruleScopeSpec
					{
						PushFollow(FOLLOW_ruleScopeSpec_in_rule350);
						ruleScopeSpec();
						state.followingStackPointer--;


					}
						break;

					}

					// ANTLRv3Tree.g:85:37: ( ruleAction )*
					do 
					{
						int alt16 = 2;
						int LA16_0 = input.LA(1);

						if ( (LA16_0 == 72) )
						{
							alt16 = 1;
						}


						switch (alt16) 
						{
						case 1 :
							// ANTLRv3Tree.g:85:37: ruleAction
						{
							PushFollow(FOLLOW_ruleAction_in_rule353);
							ruleAction();
							state.followingStackPointer--;


						}
							break;

						default:
							goto loop16;
						}
					} while (true);

					loop16:
					;	// Stops C# compiler whining that label 'loop16' has no statements

					PushFollow(FOLLOW_altList_in_rule364);
					altList();
					state.followingStackPointer--;

					// ANTLRv3Tree.g:87:9: ( exceptionGroup )?
					int alt17 = 2;
					int LA17_0 = input.LA(1);

					if ( ((LA17_0 >= 85 && LA17_0 <= 86)) )
					{
						alt17 = 1;
					}
					switch (alt17) 
					{
					case 1 :
						// ANTLRv3Tree.g:87:9: exceptionGroup
					{
						PushFollow(FOLLOW_exceptionGroup_in_rule374);
						exceptionGroup();
						state.followingStackPointer--;


					}
						break;

					}

					Match(input,EOR,FOLLOW_EOR_in_rule377); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rule"


		// $ANTLR start "modifier"
		// ANTLRv3Tree.g:91:1: modifier : ( 'protected' | 'public' | 'private' | 'fragment' );
		public void modifier() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:92:2: ( 'protected' | 'public' | 'private' | 'fragment' )
				// ANTLRv3Tree.g:
				{
					if ( input.LA(1) == FRAGMENT || (input.LA(1) >= 75 && input.LA(1) <= 77) ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "modifier"


		// $ANTLR start "ruleAction"
		// ANTLRv3Tree.g:95:1: ruleAction : ^( '@' ID ACTION ) ;
		public void ruleAction() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:97:2: ( ^( '@' ID ACTION ) )
				// ANTLRv3Tree.g:97:4: ^( '@' ID ACTION )
				{
					Match(input,72,FOLLOW_72_in_ruleAction416); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_ruleAction418); 
					Match(input,ACTION,FOLLOW_ACTION_in_ruleAction420); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "ruleAction"


		// $ANTLR start "throwsSpec"
		// ANTLRv3Tree.g:100:1: throwsSpec : ^( 'throws' ( ID )+ ) ;
		public void throwsSpec() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:101:2: ( ^( 'throws' ( ID )+ ) )
				// ANTLRv3Tree.g:101:4: ^( 'throws' ( ID )+ )
				{
					Match(input,80,FOLLOW_80_in_throwsSpec433); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:101:15: ( ID )+
					int cnt18 = 0;
					do 
					{
						int alt18 = 2;
						int LA18_0 = input.LA(1);

						if ( (LA18_0 == ID) )
						{
							alt18 = 1;
						}


						switch (alt18) 
						{
						case 1 :
							// ANTLRv3Tree.g:101:15: ID
						{
							Match(input,ID,FOLLOW_ID_in_throwsSpec435); 

						}
							break;

						default:
							if ( cnt18 >= 1 ) goto loop18;
							EarlyExitException eee18 =
								new EarlyExitException(18, input);
							throw eee18;
						}
						cnt18++;
					} while (true);

					loop18:
					;	// Stops C# compiler whining that label 'loop18' has no statements


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "throwsSpec"


		// $ANTLR start "ruleScopeSpec"
		// ANTLRv3Tree.g:104:1: ruleScopeSpec : ( ^( 'scope' ACTION ) | ^( 'scope' ACTION ( ID )+ ) | ^( 'scope' ( ID )+ ) );
		public void ruleScopeSpec() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:105:2: ( ^( 'scope' ACTION ) | ^( 'scope' ACTION ( ID )+ ) | ^( 'scope' ( ID )+ ) )
				int alt21 = 3;
				int LA21_0 = input.LA(1);

				if ( (LA21_0 == SCOPE) )
				{
					int LA21_1 = input.LA(2);

					if ( (LA21_1 == DOWN) )
					{
						int LA21_2 = input.LA(3);

						if ( (LA21_2 == ACTION) )
						{
							int LA21_3 = input.LA(4);

							if ( (LA21_3 == UP) )
							{
								alt21 = 1;
							}
							else if ( (LA21_3 == ID) )
							{
								alt21 = 2;
							}
							else 
							{
								NoViableAltException nvae_d21s3 =
									new NoViableAltException("", 21, 3, input);

								throw nvae_d21s3;
							}
						}
						else if ( (LA21_2 == ID) )
						{
							alt21 = 3;
						}
						else 
						{
							NoViableAltException nvae_d21s2 =
								new NoViableAltException("", 21, 2, input);

							throw nvae_d21s2;
						}
					}
					else 
					{
						NoViableAltException nvae_d21s1 =
							new NoViableAltException("", 21, 1, input);

						throw nvae_d21s1;
					}
				}
				else 
				{
					NoViableAltException nvae_d21s0 =
						new NoViableAltException("", 21, 0, input);

					throw nvae_d21s0;
				}
				switch (alt21) 
				{
				case 1 :
					// ANTLRv3Tree.g:105:4: ^( 'scope' ACTION )
				{
					Match(input,SCOPE,FOLLOW_SCOPE_in_ruleScopeSpec449); 

					Match(input, Token.DOWN, null); 
					Match(input,ACTION,FOLLOW_ACTION_in_ruleScopeSpec451); 

					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:106:4: ^( 'scope' ACTION ( ID )+ )
				{
					Match(input,SCOPE,FOLLOW_SCOPE_in_ruleScopeSpec458); 

					Match(input, Token.DOWN, null); 
					Match(input,ACTION,FOLLOW_ACTION_in_ruleScopeSpec460); 
					// ANTLRv3Tree.g:106:21: ( ID )+
					int cnt19 = 0;
					do 
					{
						int alt19 = 2;
						int LA19_0 = input.LA(1);

						if ( (LA19_0 == ID) )
						{
							alt19 = 1;
						}


						switch (alt19) 
						{
						case 1 :
							// ANTLRv3Tree.g:106:21: ID
						{
							Match(input,ID,FOLLOW_ID_in_ruleScopeSpec462); 

						}
							break;

						default:
							if ( cnt19 >= 1 ) goto loop19;
							EarlyExitException eee19 =
								new EarlyExitException(19, input);
							throw eee19;
						}
						cnt19++;
					} while (true);

					loop19:
					;	// Stops C# compiler whining that label 'loop19' has no statements


					Match(input, Token.UP, null); 

				}
					break;
				case 3 :
					// ANTLRv3Tree.g:107:4: ^( 'scope' ( ID )+ )
				{
					Match(input,SCOPE,FOLLOW_SCOPE_in_ruleScopeSpec470); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:107:14: ( ID )+
					int cnt20 = 0;
					do 
					{
						int alt20 = 2;
						int LA20_0 = input.LA(1);

						if ( (LA20_0 == ID) )
						{
							alt20 = 1;
						}


						switch (alt20) 
						{
						case 1 :
							// ANTLRv3Tree.g:107:14: ID
						{
							Match(input,ID,FOLLOW_ID_in_ruleScopeSpec472); 

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


					Match(input, Token.UP, null); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "ruleScopeSpec"


		// $ANTLR start "block"
		// ANTLRv3Tree.g:110:1: block : ^( BLOCK ( optionsSpec )? ( alternative rewrite )+ EOB ) ;
		public void block() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:111:5: ( ^( BLOCK ( optionsSpec )? ( alternative rewrite )+ EOB ) )
				// ANTLRv3Tree.g:111:9: ^( BLOCK ( optionsSpec )? ( alternative rewrite )+ EOB )
				{
					Match(input,BLOCK,FOLLOW_BLOCK_in_block492); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:111:18: ( optionsSpec )?
					int alt22 = 2;
					int LA22_0 = input.LA(1);

					if ( (LA22_0 == OPTIONS) )
					{
						alt22 = 1;
					}
					switch (alt22) 
					{
					case 1 :
						// ANTLRv3Tree.g:111:18: optionsSpec
					{
						PushFollow(FOLLOW_optionsSpec_in_block494);
						optionsSpec();
						state.followingStackPointer--;


					}
						break;

					}

					// ANTLRv3Tree.g:111:31: ( alternative rewrite )+
					int cnt23 = 0;
					do 
					{
						int alt23 = 2;
						int LA23_0 = input.LA(1);

						if ( (LA23_0 == ALT) )
						{
							alt23 = 1;
						}


						switch (alt23) 
						{
						case 1 :
							// ANTLRv3Tree.g:111:32: alternative rewrite
						{
							PushFollow(FOLLOW_alternative_in_block498);
							alternative();
							state.followingStackPointer--;

							PushFollow(FOLLOW_rewrite_in_block500);
							rewrite();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt23 >= 1 ) goto loop23;
							EarlyExitException eee23 =
								new EarlyExitException(23, input);
							throw eee23;
						}
						cnt23++;
					} while (true);

					loop23:
					;	// Stops C# compiler whining that label 'loop23' has no statements

					Match(input,EOB,FOLLOW_EOB_in_block504); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "block"


		// $ANTLR start "altList"
		// ANTLRv3Tree.g:114:1: altList : ^( BLOCK ( alternative rewrite )+ EOB ) ;
		public void altList() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:115:5: ( ^( BLOCK ( alternative rewrite )+ EOB ) )
				// ANTLRv3Tree.g:115:9: ^( BLOCK ( alternative rewrite )+ EOB )
				{
					Match(input,BLOCK,FOLLOW_BLOCK_in_altList527); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:115:18: ( alternative rewrite )+
					int cnt24 = 0;
					do 
					{
						int alt24 = 2;
						int LA24_0 = input.LA(1);

						if ( (LA24_0 == ALT) )
						{
							alt24 = 1;
						}


						switch (alt24) 
						{
						case 1 :
							// ANTLRv3Tree.g:115:19: alternative rewrite
						{
							PushFollow(FOLLOW_alternative_in_altList530);
							alternative();
							state.followingStackPointer--;

							PushFollow(FOLLOW_rewrite_in_altList532);
							rewrite();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt24 >= 1 ) goto loop24;
							EarlyExitException eee24 =
								new EarlyExitException(24, input);
							throw eee24;
						}
						cnt24++;
					} while (true);

					loop24:
					;	// Stops C# compiler whining that label 'loop24' has no statements

					Match(input,EOB,FOLLOW_EOB_in_altList536); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "altList"


		// $ANTLR start "alternative"
		// ANTLRv3Tree.g:118:1: alternative : ( ^( ALT ( element )+ EOA ) | ^( ALT EPSILON EOA ) );
		public void alternative() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:119:5: ( ^( ALT ( element )+ EOA ) | ^( ALT EPSILON EOA ) )
				int alt26 = 2;
				int LA26_0 = input.LA(1);

				if ( (LA26_0 == ALT) )
				{
					int LA26_1 = input.LA(2);

					if ( (LA26_1 == DOWN) )
					{
						int LA26_2 = input.LA(3);

						if ( (LA26_2 == EPSILON) )
						{
							alt26 = 2;
						}
						else if ( ((LA26_2 >= BLOCK && LA26_2 <= SYNPRED) || LA26_2 == CHAR_RANGE || (LA26_2 >= SEMPRED && LA26_2 <= SYN_SEMPRED) || (LA26_2 >= TREE_BEGIN && LA26_2 <= BANG) || (LA26_2 >= TOKEN_REF && LA26_2 <= ACTION) || LA26_2 == RULE_REF || LA26_2 == 71 || LA26_2 == 87 || LA26_2 == 89 || LA26_2 == 92) )
						{
							alt26 = 1;
						}
						else 
						{
							NoViableAltException nvae_d26s2 =
								new NoViableAltException("", 26, 2, input);

							throw nvae_d26s2;
						}
					}
					else 
					{
						NoViableAltException nvae_d26s1 =
							new NoViableAltException("", 26, 1, input);

						throw nvae_d26s1;
					}
				}
				else 
				{
					NoViableAltException nvae_d26s0 =
						new NoViableAltException("", 26, 0, input);

					throw nvae_d26s0;
				}
				switch (alt26) 
				{
				case 1 :
					// ANTLRv3Tree.g:119:9: ^( ALT ( element )+ EOA )
				{
					Match(input,ALT,FOLLOW_ALT_in_alternative558); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:119:15: ( element )+
					int cnt25 = 0;
					do 
					{
						int alt25 = 2;
						int LA25_0 = input.LA(1);

						if ( ((LA25_0 >= BLOCK && LA25_0 <= SYNPRED) || LA25_0 == CHAR_RANGE || (LA25_0 >= SEMPRED && LA25_0 <= SYN_SEMPRED) || (LA25_0 >= TREE_BEGIN && LA25_0 <= BANG) || (LA25_0 >= TOKEN_REF && LA25_0 <= ACTION) || LA25_0 == RULE_REF || LA25_0 == 71 || LA25_0 == 87 || LA25_0 == 89 || LA25_0 == 92) )
						{
							alt25 = 1;
						}


						switch (alt25) 
						{
						case 1 :
							// ANTLRv3Tree.g:119:15: element
						{
							PushFollow(FOLLOW_element_in_alternative560);
							element();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt25 >= 1 ) goto loop25;
							EarlyExitException eee25 =
								new EarlyExitException(25, input);
							throw eee25;
						}
						cnt25++;
					} while (true);

					loop25:
					;	// Stops C# compiler whining that label 'loop25' has no statements

					Match(input,EOA,FOLLOW_EOA_in_alternative563); 

					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:120:9: ^( ALT EPSILON EOA )
				{
					Match(input,ALT,FOLLOW_ALT_in_alternative575); 

					Match(input, Token.DOWN, null); 
					Match(input,EPSILON,FOLLOW_EPSILON_in_alternative577); 
					Match(input,EOA,FOLLOW_EOA_in_alternative579); 

					Match(input, Token.UP, null); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "alternative"


		// $ANTLR start "exceptionGroup"
		// ANTLRv3Tree.g:123:1: exceptionGroup : ( ( exceptionHandler )+ ( finallyClause )? | finallyClause );
		public void exceptionGroup() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:124:2: ( ( exceptionHandler )+ ( finallyClause )? | finallyClause )
				int alt29 = 2;
				int LA29_0 = input.LA(1);

				if ( (LA29_0 == 85) )
				{
					alt29 = 1;
				}
				else if ( (LA29_0 == 86) )
				{
					alt29 = 2;
				}
				else 
				{
					NoViableAltException nvae_d29s0 =
						new NoViableAltException("", 29, 0, input);

					throw nvae_d29s0;
				}
				switch (alt29) 
				{
				case 1 :
					// ANTLRv3Tree.g:124:4: ( exceptionHandler )+ ( finallyClause )?
				{
					// ANTLRv3Tree.g:124:4: ( exceptionHandler )+
					int cnt27 = 0;
					do 
					{
						int alt27 = 2;
						int LA27_0 = input.LA(1);

						if ( (LA27_0 == 85) )
						{
							alt27 = 1;
						}


						switch (alt27) 
						{
						case 1 :
							// ANTLRv3Tree.g:124:4: exceptionHandler
						{
							PushFollow(FOLLOW_exceptionHandler_in_exceptionGroup594);
							exceptionHandler();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt27 >= 1 ) goto loop27;
							EarlyExitException eee27 =
								new EarlyExitException(27, input);
							throw eee27;
						}
						cnt27++;
					} while (true);

					loop27:
					;	// Stops C# compiler whining that label 'loop27' has no statements

					// ANTLRv3Tree.g:124:22: ( finallyClause )?
					int alt28 = 2;
					int LA28_0 = input.LA(1);

					if ( (LA28_0 == 86) )
					{
						alt28 = 1;
					}
					switch (alt28) 
					{
					case 1 :
						// ANTLRv3Tree.g:124:22: finallyClause
					{
						PushFollow(FOLLOW_finallyClause_in_exceptionGroup597);
						finallyClause();
						state.followingStackPointer--;


					}
						break;

					}


				}
					break;
				case 2 :
					// ANTLRv3Tree.g:125:4: finallyClause
				{
					PushFollow(FOLLOW_finallyClause_in_exceptionGroup603);
					finallyClause();
					state.followingStackPointer--;


				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "exceptionGroup"


		// $ANTLR start "exceptionHandler"
		// ANTLRv3Tree.g:128:1: exceptionHandler : ^( 'catch' ARG_ACTION ACTION ) ;
		public void exceptionHandler() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:129:5: ( ^( 'catch' ARG_ACTION ACTION ) )
				// ANTLRv3Tree.g:129:10: ^( 'catch' ARG_ACTION ACTION )
				{
					Match(input,85,FOLLOW_85_in_exceptionHandler624); 

					Match(input, Token.DOWN, null); 
					Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_exceptionHandler626); 
					Match(input,ACTION,FOLLOW_ACTION_in_exceptionHandler628); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "exceptionHandler"


		// $ANTLR start "finallyClause"
		// ANTLRv3Tree.g:132:1: finallyClause : ^( 'finally' ACTION ) ;
		public void finallyClause() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:133:5: ( ^( 'finally' ACTION ) )
				// ANTLRv3Tree.g:133:10: ^( 'finally' ACTION )
				{
					Match(input,86,FOLLOW_86_in_finallyClause650); 

					Match(input, Token.DOWN, null); 
					Match(input,ACTION,FOLLOW_ACTION_in_finallyClause652); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "finallyClause"


		// $ANTLR start "element"
		// ANTLRv3Tree.g:136:1: element : elementNoOptionSpec ;
		public void element() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:137:2: ( elementNoOptionSpec )
				// ANTLRv3Tree.g:137:4: elementNoOptionSpec
				{
					PushFollow(FOLLOW_elementNoOptionSpec_in_element667);
					elementNoOptionSpec();
					state.followingStackPointer--;


				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "element"


		// $ANTLR start "elementNoOptionSpec"
		// ANTLRv3Tree.g:140:1: elementNoOptionSpec : ( ^( ( '=' | '+=' ) ID block ) | ^( ( '=' | '+=' ) ID atom ) | atom | ebnf | ACTION | SEMPRED | GATED_SEMPRED | treeSpec );
		public void elementNoOptionSpec() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:141:2: ( ^( ( '=' | '+=' ) ID block ) | ^( ( '=' | '+=' ) ID atom ) | atom | ebnf | ACTION | SEMPRED | GATED_SEMPRED | treeSpec )
				int alt30 = 8;
				alt30 = dfa30.Predict(input);
				switch (alt30) 
				{
				case 1 :
					// ANTLRv3Tree.g:141:4: ^( ( '=' | '+=' ) ID block )
				{
					if ( input.LA(1) == 71 || input.LA(1) == 87 ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_elementNoOptionSpec685); 
					PushFollow(FOLLOW_block_in_elementNoOptionSpec687);
					block();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:142:4: ^( ( '=' | '+=' ) ID atom )
				{
					if ( input.LA(1) == 71 || input.LA(1) == 87 ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_elementNoOptionSpec700); 
					PushFollow(FOLLOW_atom_in_elementNoOptionSpec702);
					atom();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;
				case 3 :
					// ANTLRv3Tree.g:143:4: atom
				{
					PushFollow(FOLLOW_atom_in_elementNoOptionSpec708);
					atom();
					state.followingStackPointer--;


				}
					break;
				case 4 :
					// ANTLRv3Tree.g:144:4: ebnf
				{
					PushFollow(FOLLOW_ebnf_in_elementNoOptionSpec713);
					ebnf();
					state.followingStackPointer--;


				}
					break;
				case 5 :
					// ANTLRv3Tree.g:145:6: ACTION
				{
					Match(input,ACTION,FOLLOW_ACTION_in_elementNoOptionSpec720); 

				}
					break;
				case 6 :
					// ANTLRv3Tree.g:146:6: SEMPRED
				{
					Match(input,SEMPRED,FOLLOW_SEMPRED_in_elementNoOptionSpec727); 

				}
					break;
				case 7 :
					// ANTLRv3Tree.g:147:4: GATED_SEMPRED
				{
					Match(input,GATED_SEMPRED,FOLLOW_GATED_SEMPRED_in_elementNoOptionSpec732); 

				}
					break;
				case 8 :
					// ANTLRv3Tree.g:148:6: treeSpec
				{
					PushFollow(FOLLOW_treeSpec_in_elementNoOptionSpec739);
					treeSpec();
					state.followingStackPointer--;


				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "elementNoOptionSpec"


		// $ANTLR start "atom"
		// ANTLRv3Tree.g:151:1: atom : ( ^( ( '^' | '!' ) atom ) | range | notSet | ^( RULE_REF ARG_ACTION ) | RULE_REF | terminal );
		public void atom() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:151:5: ( ^( ( '^' | '!' ) atom ) | range | notSet | ^( RULE_REF ARG_ACTION ) | RULE_REF | terminal )
				int alt31 = 6;
				switch ( input.LA(1) ) 
				{
				case ROOT:
				case BANG:
				{
					alt31 = 1;
				}
					break;
				case CHAR_RANGE:
				{
					alt31 = 2;
				}
					break;
				case 89:
				{
					alt31 = 3;
				}
					break;
				case RULE_REF:
				{
					int LA31_4 = input.LA(2);

					if ( (LA31_4 == DOWN) )
					{
						alt31 = 4;
					}
					else if ( (LA31_4 == UP || (LA31_4 >= BLOCK && LA31_4 <= SYNPRED) || LA31_4 == CHAR_RANGE || LA31_4 == EOA || (LA31_4 >= SEMPRED && LA31_4 <= SYN_SEMPRED) || (LA31_4 >= TREE_BEGIN && LA31_4 <= BANG) || (LA31_4 >= TOKEN_REF && LA31_4 <= ACTION) || LA31_4 == RULE_REF || LA31_4 == 71 || LA31_4 == 87 || LA31_4 == 89 || LA31_4 == 92) )
					{
						alt31 = 5;
					}
					else 
					{
						NoViableAltException nvae_d31s4 =
							new NoViableAltException("", 31, 4, input);

						throw nvae_d31s4;
					}
				}
					break;
				case TOKEN_REF:
				case STRING_LITERAL:
				case CHAR_LITERAL:
				case 92:
				{
					alt31 = 6;
				}
					break;
				default:
					NoViableAltException nvae_d31s0 =
						new NoViableAltException("", 31, 0, input);

					throw nvae_d31s0;
				}

				switch (alt31) 
				{
				case 1 :
					// ANTLRv3Tree.g:151:9: ^( ( '^' | '!' ) atom )
				{
					if ( (input.LA(1) >= ROOT && input.LA(1) <= BANG) ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_atom_in_atom757);
					atom();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:152:4: range
				{
					PushFollow(FOLLOW_range_in_atom763);
					range();
					state.followingStackPointer--;


				}
					break;
				case 3 :
					// ANTLRv3Tree.g:153:4: notSet
				{
					PushFollow(FOLLOW_notSet_in_atom768);
					notSet();
					state.followingStackPointer--;


				}
					break;
				case 4 :
					// ANTLRv3Tree.g:154:7: ^( RULE_REF ARG_ACTION )
				{
					Match(input,RULE_REF,FOLLOW_RULE_REF_in_atom777); 

					Match(input, Token.DOWN, null); 
					Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_atom779); 

					Match(input, Token.UP, null); 

				}
					break;
				case 5 :
					// ANTLRv3Tree.g:155:7: RULE_REF
				{
					Match(input,RULE_REF,FOLLOW_RULE_REF_in_atom788); 

				}
					break;
				case 6 :
					// ANTLRv3Tree.g:156:9: terminal
				{
					PushFollow(FOLLOW_terminal_in_atom798);
					terminal();
					state.followingStackPointer--;


				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "atom"


		// $ANTLR start "notSet"
		// ANTLRv3Tree.g:159:1: notSet : ( ^( '~' notTerminal ) | ^( '~' block ) );
		public void notSet() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:160:2: ( ^( '~' notTerminal ) | ^( '~' block ) )
				int alt32 = 2;
				int LA32_0 = input.LA(1);

				if ( (LA32_0 == 89) )
				{
					int LA32_1 = input.LA(2);

					if ( (LA32_1 == DOWN) )
					{
						int LA32_2 = input.LA(3);

						if ( (LA32_2 == BLOCK) )
						{
							alt32 = 2;
						}
						else if ( ((LA32_2 >= TOKEN_REF && LA32_2 <= CHAR_LITERAL)) )
						{
							alt32 = 1;
						}
						else 
						{
							NoViableAltException nvae_d32s2 =
								new NoViableAltException("", 32, 2, input);

							throw nvae_d32s2;
						}
					}
					else 
					{
						NoViableAltException nvae_d32s1 =
							new NoViableAltException("", 32, 1, input);

						throw nvae_d32s1;
					}
				}
				else 
				{
					NoViableAltException nvae_d32s0 =
						new NoViableAltException("", 32, 0, input);

					throw nvae_d32s0;
				}
				switch (alt32) 
				{
				case 1 :
					// ANTLRv3Tree.g:160:4: ^( '~' notTerminal )
				{
					Match(input,89,FOLLOW_89_in_notSet813); 

					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_notTerminal_in_notSet815);
					notTerminal();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:161:4: ^( '~' block )
				{
					Match(input,89,FOLLOW_89_in_notSet822); 

					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_block_in_notSet824);
					block();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "notSet"


		// $ANTLR start "treeSpec"
		// ANTLRv3Tree.g:164:1: treeSpec : ^( TREE_BEGIN ( element )+ ) ;
		public void treeSpec() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:165:2: ( ^( TREE_BEGIN ( element )+ ) )
				// ANTLRv3Tree.g:165:4: ^( TREE_BEGIN ( element )+ )
				{
					Match(input,TREE_BEGIN,FOLLOW_TREE_BEGIN_in_treeSpec837); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:165:17: ( element )+
					int cnt33 = 0;
					do 
					{
						int alt33 = 2;
						int LA33_0 = input.LA(1);

						if ( ((LA33_0 >= BLOCK && LA33_0 <= SYNPRED) || LA33_0 == CHAR_RANGE || (LA33_0 >= SEMPRED && LA33_0 <= SYN_SEMPRED) || (LA33_0 >= TREE_BEGIN && LA33_0 <= BANG) || (LA33_0 >= TOKEN_REF && LA33_0 <= ACTION) || LA33_0 == RULE_REF || LA33_0 == 71 || LA33_0 == 87 || LA33_0 == 89 || LA33_0 == 92) )
						{
							alt33 = 1;
						}


						switch (alt33) 
						{
						case 1 :
							// ANTLRv3Tree.g:165:17: element
						{
							PushFollow(FOLLOW_element_in_treeSpec839);
							element();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt33 >= 1 ) goto loop33;
							EarlyExitException eee33 =
								new EarlyExitException(33, input);
							throw eee33;
						}
						cnt33++;
					} while (true);

					loop33:
					;	// Stops C# compiler whining that label 'loop33' has no statements


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "treeSpec"


		// $ANTLR start "ebnf"
		// ANTLRv3Tree.g:168:1: ebnf : ( ^( SYNPRED block ) | SYN_SEMPRED | ^( ebnfSuffix block ) | block );
		public void ebnf() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:170:2: ( ^( SYNPRED block ) | SYN_SEMPRED | ^( ebnfSuffix block ) | block )
				int alt34 = 4;
				switch ( input.LA(1) ) 
				{
				case SYNPRED:
				{
					alt34 = 1;
				}
					break;
				case SYN_SEMPRED:
				{
					alt34 = 2;
				}
					break;
				case OPTIONAL:
				case CLOSURE:
				case POSITIVE_CLOSURE:
				{
					alt34 = 3;
				}
					break;
				case BLOCK:
				{
					alt34 = 4;
				}
					break;
				default:
					NoViableAltException nvae_d34s0 =
						new NoViableAltException("", 34, 0, input);

					throw nvae_d34s0;
				}

				switch (alt34) 
				{
				case 1 :
					// ANTLRv3Tree.g:170:4: ^( SYNPRED block )
				{
					Match(input,SYNPRED,FOLLOW_SYNPRED_in_ebnf855); 

					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_block_in_ebnf857);
					block();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:171:4: SYN_SEMPRED
				{
					Match(input,SYN_SEMPRED,FOLLOW_SYN_SEMPRED_in_ebnf863); 

				}
					break;
				case 3 :
					// ANTLRv3Tree.g:172:4: ^( ebnfSuffix block )
				{
					PushFollow(FOLLOW_ebnfSuffix_in_ebnf869);
					ebnfSuffix();
					state.followingStackPointer--;


					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_block_in_ebnf871);
					block();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;
				case 4 :
					// ANTLRv3Tree.g:173:4: block
				{
					PushFollow(FOLLOW_block_in_ebnf877);
					block();
					state.followingStackPointer--;


				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "ebnf"


		// $ANTLR start "range"
		// ANTLRv3Tree.g:176:1: range : ^( CHAR_RANGE CHAR_LITERAL CHAR_LITERAL ) ;
		public void range() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:177:2: ( ^( CHAR_RANGE CHAR_LITERAL CHAR_LITERAL ) )
				// ANTLRv3Tree.g:177:4: ^( CHAR_RANGE CHAR_LITERAL CHAR_LITERAL )
				{
					Match(input,CHAR_RANGE,FOLLOW_CHAR_RANGE_in_range889); 

					Match(input, Token.DOWN, null); 
					Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_range891); 
					Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_range893); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "range"


		// $ANTLR start "terminal"
		// ANTLRv3Tree.g:180:1: terminal : ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL | ^( TOKEN_REF ARG_ACTION ) | '.' );
		public void terminal() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:181:5: ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL | ^( TOKEN_REF ARG_ACTION ) | '.' )
				int alt35 = 5;
				switch ( input.LA(1) ) 
				{
				case CHAR_LITERAL:
				{
					alt35 = 1;
				}
					break;
				case TOKEN_REF:
				{
					int LA35_2 = input.LA(2);

					if ( (LA35_2 == DOWN) )
					{
						alt35 = 4;
					}
					else if ( (LA35_2 == UP || (LA35_2 >= BLOCK && LA35_2 <= SYNPRED) || LA35_2 == CHAR_RANGE || LA35_2 == EOA || (LA35_2 >= SEMPRED && LA35_2 <= SYN_SEMPRED) || (LA35_2 >= TREE_BEGIN && LA35_2 <= BANG) || (LA35_2 >= TOKEN_REF && LA35_2 <= ACTION) || LA35_2 == RULE_REF || LA35_2 == 71 || LA35_2 == 87 || LA35_2 == 89 || LA35_2 == 92) )
					{
						alt35 = 2;
					}
					else 
					{
						NoViableAltException nvae_d35s2 =
							new NoViableAltException("", 35, 2, input);

						throw nvae_d35s2;
					}
				}
					break;
				case STRING_LITERAL:
				{
					alt35 = 3;
				}
					break;
				case 92:
				{
					alt35 = 5;
				}
					break;
				default:
					NoViableAltException nvae_d35s0 =
						new NoViableAltException("", 35, 0, input);

					throw nvae_d35s0;
				}

				switch (alt35) 
				{
				case 1 :
					// ANTLRv3Tree.g:181:9: CHAR_LITERAL
				{
					Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_terminal910); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:182:7: TOKEN_REF
				{
					Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_terminal918); 

				}
					break;
				case 3 :
					// ANTLRv3Tree.g:183:7: STRING_LITERAL
				{
					Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_terminal926); 

				}
					break;
				case 4 :
					// ANTLRv3Tree.g:184:7: ^( TOKEN_REF ARG_ACTION )
				{
					Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_terminal935); 

					Match(input, Token.DOWN, null); 
					Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_terminal937); 

					Match(input, Token.UP, null); 

				}
					break;
				case 5 :
					// ANTLRv3Tree.g:185:7: '.'
				{
					Match(input,92,FOLLOW_92_in_terminal946); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "terminal"


		// $ANTLR start "notTerminal"
		// ANTLRv3Tree.g:188:1: notTerminal : ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL );
		public void notTerminal() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:189:2: ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL )
				// ANTLRv3Tree.g:
				{
					if ( (input.LA(1) >= TOKEN_REF && input.LA(1) <= CHAR_LITERAL) ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "notTerminal"


		// $ANTLR start "ebnfSuffix"
		// ANTLRv3Tree.g:194:1: ebnfSuffix : ( OPTIONAL | CLOSURE | POSITIVE_CLOSURE );
		public void ebnfSuffix() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:195:2: ( OPTIONAL | CLOSURE | POSITIVE_CLOSURE )
				// ANTLRv3Tree.g:
				{
					if ( (input.LA(1) >= OPTIONAL && input.LA(1) <= POSITIVE_CLOSURE) ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "ebnfSuffix"


		// $ANTLR start "rewrite"
		// ANTLRv3Tree.g:202:1: rewrite : ( ( ^( '->' SEMPRED rewrite_alternative ) )* ^( '->' rewrite_alternative ) | );
		public void rewrite() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:203:2: ( ( ^( '->' SEMPRED rewrite_alternative ) )* ^( '->' rewrite_alternative ) | )
				int alt37 = 2;
				int LA37_0 = input.LA(1);

				if ( (LA37_0 == REWRITE) )
				{
					alt37 = 1;
				}
				else if ( (LA37_0 == ALT || LA37_0 == EOB) )
				{
					alt37 = 2;
				}
				else 
				{
					NoViableAltException nvae_d37s0 =
						new NoViableAltException("", 37, 0, input);

					throw nvae_d37s0;
				}
				switch (alt37) 
				{
				case 1 :
					// ANTLRv3Tree.g:203:4: ( ^( '->' SEMPRED rewrite_alternative ) )* ^( '->' rewrite_alternative )
				{
					// ANTLRv3Tree.g:203:4: ( ^( '->' SEMPRED rewrite_alternative ) )*
					do 
					{
						int alt36 = 2;
						int LA36_0 = input.LA(1);

						if ( (LA36_0 == REWRITE) )
						{
							int LA36_1 = input.LA(2);

							if ( (LA36_1 == DOWN) )
							{
								int LA36_2 = input.LA(3);

								if ( (LA36_2 == SEMPRED) )
								{
									alt36 = 1;
								}


							}


						}


						switch (alt36) 
						{
						case 1 :
							// ANTLRv3Tree.g:203:5: ^( '->' SEMPRED rewrite_alternative )
						{
							Match(input,REWRITE,FOLLOW_REWRITE_in_rewrite1012); 

							Match(input, Token.DOWN, null); 
							Match(input,SEMPRED,FOLLOW_SEMPRED_in_rewrite1014); 
							PushFollow(FOLLOW_rewrite_alternative_in_rewrite1016);
							rewrite_alternative();
							state.followingStackPointer--;


							Match(input, Token.UP, null); 

						}
							break;

						default:
							goto loop36;
						}
					} while (true);

					loop36:
					;	// Stops C# compiler whining that label 'loop36' has no statements

					Match(input,REWRITE,FOLLOW_REWRITE_in_rewrite1022); 

					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_rewrite_alternative_in_rewrite1024);
					rewrite_alternative();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:205:2: 
				{
				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite"


		// $ANTLR start "rewrite_alternative"
		// ANTLRv3Tree.g:207:1: rewrite_alternative : ( rewrite_template | rewrite_tree_alternative | ^( ALT EPSILON EOA ) );
		public void rewrite_alternative() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:208:2: ( rewrite_template | rewrite_tree_alternative | ^( ALT EPSILON EOA ) )
				int alt38 = 3;
				int LA38_0 = input.LA(1);

				if ( (LA38_0 == TEMPLATE || LA38_0 == ACTION) )
				{
					alt38 = 1;
				}
				else if ( (LA38_0 == ALT) )
				{
					int LA38_2 = input.LA(2);

					if ( (LA38_2 == DOWN) )
					{
						int LA38_3 = input.LA(3);

						if ( (LA38_3 == EPSILON) )
						{
							alt38 = 3;
						}
						else if ( ((LA38_3 >= BLOCK && LA38_3 <= POSITIVE_CLOSURE) || LA38_3 == LABEL || LA38_3 == TREE_BEGIN || (LA38_3 >= TOKEN_REF && LA38_3 <= ACTION) || LA38_3 == RULE_REF) )
						{
							alt38 = 2;
						}
						else 
						{
							NoViableAltException nvae_d38s3 =
								new NoViableAltException("", 38, 3, input);

							throw nvae_d38s3;
						}
					}
					else 
					{
						NoViableAltException nvae_d38s2 =
							new NoViableAltException("", 38, 2, input);

						throw nvae_d38s2;
					}
				}
				else 
				{
					NoViableAltException nvae_d38s0 =
						new NoViableAltException("", 38, 0, input);

					throw nvae_d38s0;
				}
				switch (alt38) 
				{
				case 1 :
					// ANTLRv3Tree.g:208:4: rewrite_template
				{
					PushFollow(FOLLOW_rewrite_template_in_rewrite_alternative1039);
					rewrite_template();
					state.followingStackPointer--;


				}
					break;
				case 2 :
					// ANTLRv3Tree.g:209:4: rewrite_tree_alternative
				{
					PushFollow(FOLLOW_rewrite_tree_alternative_in_rewrite_alternative1044);
					rewrite_tree_alternative();
					state.followingStackPointer--;


				}
					break;
				case 3 :
					// ANTLRv3Tree.g:210:9: ^( ALT EPSILON EOA )
				{
					Match(input,ALT,FOLLOW_ALT_in_rewrite_alternative1055); 

					Match(input, Token.DOWN, null); 
					Match(input,EPSILON,FOLLOW_EPSILON_in_rewrite_alternative1057); 
					Match(input,EOA,FOLLOW_EOA_in_rewrite_alternative1059); 

					Match(input, Token.UP, null); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_alternative"


		// $ANTLR start "rewrite_tree_block"
		// ANTLRv3Tree.g:213:1: rewrite_tree_block : ^( BLOCK rewrite_tree_alternative EOB ) ;
		public void rewrite_tree_block() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:214:5: ( ^( BLOCK rewrite_tree_alternative EOB ) )
				// ANTLRv3Tree.g:214:9: ^( BLOCK rewrite_tree_alternative EOB )
				{
					Match(input,BLOCK,FOLLOW_BLOCK_in_rewrite_tree_block1078); 

					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_rewrite_tree_alternative_in_rewrite_tree_block1080);
					rewrite_tree_alternative();
					state.followingStackPointer--;

					Match(input,EOB,FOLLOW_EOB_in_rewrite_tree_block1082); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_tree_block"


		// $ANTLR start "rewrite_tree_alternative"
		// ANTLRv3Tree.g:217:1: rewrite_tree_alternative : ^( ALT ( rewrite_tree_element )+ EOA ) ;
		public void rewrite_tree_alternative() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:218:5: ( ^( ALT ( rewrite_tree_element )+ EOA ) )
				// ANTLRv3Tree.g:218:7: ^( ALT ( rewrite_tree_element )+ EOA )
				{
					Match(input,ALT,FOLLOW_ALT_in_rewrite_tree_alternative1101); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:218:13: ( rewrite_tree_element )+
					int cnt39 = 0;
					do 
					{
						int alt39 = 2;
						int LA39_0 = input.LA(1);

						if ( ((LA39_0 >= BLOCK && LA39_0 <= POSITIVE_CLOSURE) || LA39_0 == LABEL || LA39_0 == TREE_BEGIN || (LA39_0 >= TOKEN_REF && LA39_0 <= ACTION) || LA39_0 == RULE_REF) )
						{
							alt39 = 1;
						}


						switch (alt39) 
						{
						case 1 :
							// ANTLRv3Tree.g:218:13: rewrite_tree_element
						{
							PushFollow(FOLLOW_rewrite_tree_element_in_rewrite_tree_alternative1103);
							rewrite_tree_element();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt39 >= 1 ) goto loop39;
							EarlyExitException eee39 =
								new EarlyExitException(39, input);
							throw eee39;
						}
						cnt39++;
					} while (true);

					loop39:
					;	// Stops C# compiler whining that label 'loop39' has no statements

					Match(input,EOA,FOLLOW_EOA_in_rewrite_tree_alternative1106); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_tree_alternative"


		// $ANTLR start "rewrite_tree_element"
		// ANTLRv3Tree.g:221:1: rewrite_tree_element : ( rewrite_tree_atom | rewrite_tree | rewrite_tree_block | rewrite_tree_ebnf );
		public void rewrite_tree_element() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:222:2: ( rewrite_tree_atom | rewrite_tree | rewrite_tree_block | rewrite_tree_ebnf )
				int alt40 = 4;
				switch ( input.LA(1) ) 
				{
				case LABEL:
				case TOKEN_REF:
				case STRING_LITERAL:
				case CHAR_LITERAL:
				case ACTION:
				case RULE_REF:
				{
					alt40 = 1;
				}
					break;
				case TREE_BEGIN:
				{
					alt40 = 2;
				}
					break;
				case BLOCK:
				{
					alt40 = 3;
				}
					break;
				case OPTIONAL:
				case CLOSURE:
				case POSITIVE_CLOSURE:
				{
					alt40 = 4;
				}
					break;
				default:
					NoViableAltException nvae_d40s0 =
						new NoViableAltException("", 40, 0, input);

					throw nvae_d40s0;
				}

				switch (alt40) 
				{
				case 1 :
					// ANTLRv3Tree.g:222:4: rewrite_tree_atom
				{
					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1121);
					rewrite_tree_atom();
					state.followingStackPointer--;


				}
					break;
				case 2 :
					// ANTLRv3Tree.g:223:4: rewrite_tree
				{
					PushFollow(FOLLOW_rewrite_tree_in_rewrite_tree_element1126);
					rewrite_tree();
					state.followingStackPointer--;


				}
					break;
				case 3 :
					// ANTLRv3Tree.g:224:6: rewrite_tree_block
				{
					PushFollow(FOLLOW_rewrite_tree_block_in_rewrite_tree_element1133);
					rewrite_tree_block();
					state.followingStackPointer--;


				}
					break;
				case 4 :
					// ANTLRv3Tree.g:225:6: rewrite_tree_ebnf
				{
					PushFollow(FOLLOW_rewrite_tree_ebnf_in_rewrite_tree_element1140);
					rewrite_tree_ebnf();
					state.followingStackPointer--;


				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_tree_element"


		// $ANTLR start "rewrite_tree_atom"
		// ANTLRv3Tree.g:228:1: rewrite_tree_atom : ( CHAR_LITERAL | TOKEN_REF | ^( TOKEN_REF ARG_ACTION ) | RULE_REF | STRING_LITERAL | LABEL | ACTION );
		public void rewrite_tree_atom() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:229:5: ( CHAR_LITERAL | TOKEN_REF | ^( TOKEN_REF ARG_ACTION ) | RULE_REF | STRING_LITERAL | LABEL | ACTION )
				int alt41 = 7;
				switch ( input.LA(1) ) 
				{
				case CHAR_LITERAL:
				{
					alt41 = 1;
				}
					break;
				case TOKEN_REF:
				{
					int LA41_2 = input.LA(2);

					if ( (LA41_2 == DOWN) )
					{
						alt41 = 3;
					}
					else if ( (LA41_2 == UP || (LA41_2 >= BLOCK && LA41_2 <= POSITIVE_CLOSURE) || LA41_2 == EOA || LA41_2 == LABEL || LA41_2 == TREE_BEGIN || (LA41_2 >= TOKEN_REF && LA41_2 <= ACTION) || LA41_2 == RULE_REF) )
					{
						alt41 = 2;
					}
					else 
					{
						NoViableAltException nvae_d41s2 =
							new NoViableAltException("", 41, 2, input);

						throw nvae_d41s2;
					}
				}
					break;
				case RULE_REF:
				{
					alt41 = 4;
				}
					break;
				case STRING_LITERAL:
				{
					alt41 = 5;
				}
					break;
				case LABEL:
				{
					alt41 = 6;
				}
					break;
				case ACTION:
				{
					alt41 = 7;
				}
					break;
				default:
					NoViableAltException nvae_d41s0 =
						new NoViableAltException("", 41, 0, input);

					throw nvae_d41s0;
				}

				switch (alt41) 
				{
				case 1 :
					// ANTLRv3Tree.g:229:9: CHAR_LITERAL
				{
					Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_rewrite_tree_atom1156); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:230:6: TOKEN_REF
				{
					Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_rewrite_tree_atom1163); 

				}
					break;
				case 3 :
					// ANTLRv3Tree.g:231:6: ^( TOKEN_REF ARG_ACTION )
				{
					Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_rewrite_tree_atom1171); 

					Match(input, Token.DOWN, null); 
					Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rewrite_tree_atom1173); 

					Match(input, Token.UP, null); 

				}
					break;
				case 4 :
					// ANTLRv3Tree.g:232:9: RULE_REF
				{
					Match(input,RULE_REF,FOLLOW_RULE_REF_in_rewrite_tree_atom1185); 

				}
					break;
				case 5 :
					// ANTLRv3Tree.g:233:6: STRING_LITERAL
				{
					Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_rewrite_tree_atom1192); 

				}
					break;
				case 6 :
					// ANTLRv3Tree.g:234:6: LABEL
				{
					Match(input,LABEL,FOLLOW_LABEL_in_rewrite_tree_atom1199); 

				}
					break;
				case 7 :
					// ANTLRv3Tree.g:235:4: ACTION
				{
					Match(input,ACTION,FOLLOW_ACTION_in_rewrite_tree_atom1204); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_tree_atom"


		// $ANTLR start "rewrite_tree_ebnf"
		// ANTLRv3Tree.g:238:1: rewrite_tree_ebnf : ^( ebnfSuffix rewrite_tree_block ) ;
		public void rewrite_tree_ebnf() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:239:2: ( ^( ebnfSuffix rewrite_tree_block ) )
				// ANTLRv3Tree.g:239:4: ^( ebnfSuffix rewrite_tree_block )
				{
					PushFollow(FOLLOW_ebnfSuffix_in_rewrite_tree_ebnf1216);
					ebnfSuffix();
					state.followingStackPointer--;


					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_rewrite_tree_block_in_rewrite_tree_ebnf1218);
					rewrite_tree_block();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_tree_ebnf"


		// $ANTLR start "rewrite_tree"
		// ANTLRv3Tree.g:242:1: rewrite_tree : ^( TREE_BEGIN rewrite_tree_atom ( rewrite_tree_element )* ) ;
		public void rewrite_tree() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:243:2: ( ^( TREE_BEGIN rewrite_tree_atom ( rewrite_tree_element )* ) )
				// ANTLRv3Tree.g:243:4: ^( TREE_BEGIN rewrite_tree_atom ( rewrite_tree_element )* )
				{
					Match(input,TREE_BEGIN,FOLLOW_TREE_BEGIN_in_rewrite_tree1232); 

					Match(input, Token.DOWN, null); 
					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree1234);
					rewrite_tree_atom();
					state.followingStackPointer--;

					// ANTLRv3Tree.g:243:35: ( rewrite_tree_element )*
					do 
					{
						int alt42 = 2;
						int LA42_0 = input.LA(1);

						if ( ((LA42_0 >= BLOCK && LA42_0 <= POSITIVE_CLOSURE) || LA42_0 == LABEL || LA42_0 == TREE_BEGIN || (LA42_0 >= TOKEN_REF && LA42_0 <= ACTION) || LA42_0 == RULE_REF) )
						{
							alt42 = 1;
						}


						switch (alt42) 
						{
						case 1 :
							// ANTLRv3Tree.g:243:35: rewrite_tree_element
						{
							PushFollow(FOLLOW_rewrite_tree_element_in_rewrite_tree1236);
							rewrite_tree_element();
							state.followingStackPointer--;


						}
							break;

						default:
							goto loop42;
						}
					} while (true);

					loop42:
					;	// Stops C# compiler whining that label 'loop42' has no statements


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_tree"


		// $ANTLR start "rewrite_template"
		// ANTLRv3Tree.g:246:1: rewrite_template : ( ^( TEMPLATE ID rewrite_template_args ( DOUBLE_QUOTE_STRING_LITERAL | DOUBLE_ANGLE_STRING_LITERAL ) ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION );
		public void rewrite_template() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:247:2: ( ^( TEMPLATE ID rewrite_template_args ( DOUBLE_QUOTE_STRING_LITERAL | DOUBLE_ANGLE_STRING_LITERAL ) ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION )
				int alt43 = 4;
				alt43 = dfa43.Predict(input);
				switch (alt43) 
				{
				case 1 :
					// ANTLRv3Tree.g:247:6: ^( TEMPLATE ID rewrite_template_args ( DOUBLE_QUOTE_STRING_LITERAL | DOUBLE_ANGLE_STRING_LITERAL ) )
				{
					Match(input,TEMPLATE,FOLLOW_TEMPLATE_in_rewrite_template1254); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_rewrite_template1256); 
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_template1258);
					rewrite_template_args();
					state.followingStackPointer--;

					if ( (input.LA(1) >= DOUBLE_QUOTE_STRING_LITERAL && input.LA(1) <= DOUBLE_ANGLE_STRING_LITERAL) ) 
					{
						input.Consume();
						state.errorRecovery = false;
					}
					else 
					{
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:250:4: rewrite_template_ref
				{
					PushFollow(FOLLOW_rewrite_template_ref_in_rewrite_template1281);
					rewrite_template_ref();
					state.followingStackPointer--;


				}
					break;
				case 3 :
					// ANTLRv3Tree.g:251:4: rewrite_indirect_template_head
				{
					PushFollow(FOLLOW_rewrite_indirect_template_head_in_rewrite_template1286);
					rewrite_indirect_template_head();
					state.followingStackPointer--;


				}
					break;
				case 4 :
					// ANTLRv3Tree.g:252:4: ACTION
				{
					Match(input,ACTION,FOLLOW_ACTION_in_rewrite_template1291); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_template"


		// $ANTLR start "rewrite_template_ref"
		// ANTLRv3Tree.g:255:1: rewrite_template_ref : ^( TEMPLATE ID rewrite_template_args ) ;
		public void rewrite_template_ref() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:257:2: ( ^( TEMPLATE ID rewrite_template_args ) )
				// ANTLRv3Tree.g:257:4: ^( TEMPLATE ID rewrite_template_args )
				{
					Match(input,TEMPLATE,FOLLOW_TEMPLATE_in_rewrite_template_ref1305); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_rewrite_template_ref1307); 
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_template_ref1309);
					rewrite_template_args();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_template_ref"


		// $ANTLR start "rewrite_indirect_template_head"
		// ANTLRv3Tree.g:260:1: rewrite_indirect_template_head : ^( TEMPLATE ACTION rewrite_template_args ) ;
		public void rewrite_indirect_template_head() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:262:2: ( ^( TEMPLATE ACTION rewrite_template_args ) )
				// ANTLRv3Tree.g:262:4: ^( TEMPLATE ACTION rewrite_template_args )
				{
					Match(input,TEMPLATE,FOLLOW_TEMPLATE_in_rewrite_indirect_template_head1324); 

					Match(input, Token.DOWN, null); 
					Match(input,ACTION,FOLLOW_ACTION_in_rewrite_indirect_template_head1326); 
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_indirect_template_head1328);
					rewrite_template_args();
					state.followingStackPointer--;


					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_indirect_template_head"


		// $ANTLR start "rewrite_template_args"
		// ANTLRv3Tree.g:265:1: rewrite_template_args : ( ^( ARGLIST ( rewrite_template_arg )+ ) | ARGLIST );
		public void rewrite_template_args() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:266:2: ( ^( ARGLIST ( rewrite_template_arg )+ ) | ARGLIST )
				int alt45 = 2;
				int LA45_0 = input.LA(1);

				if ( (LA45_0 == ARGLIST) )
				{
					int LA45_1 = input.LA(2);

					if ( (LA45_1 == DOWN) )
					{
						alt45 = 1;
					}
					else if ( (LA45_1 == UP || (LA45_1 >= DOUBLE_QUOTE_STRING_LITERAL && LA45_1 <= DOUBLE_ANGLE_STRING_LITERAL)) )
					{
						alt45 = 2;
					}
					else 
					{
						NoViableAltException nvae_d45s1 =
							new NoViableAltException("", 45, 1, input);

						throw nvae_d45s1;
					}
				}
				else 
				{
					NoViableAltException nvae_d45s0 =
						new NoViableAltException("", 45, 0, input);

					throw nvae_d45s0;
				}
				switch (alt45) 
				{
				case 1 :
					// ANTLRv3Tree.g:266:4: ^( ARGLIST ( rewrite_template_arg )+ )
				{
					Match(input,ARGLIST,FOLLOW_ARGLIST_in_rewrite_template_args1341); 

					Match(input, Token.DOWN, null); 
					// ANTLRv3Tree.g:266:14: ( rewrite_template_arg )+
					int cnt44 = 0;
					do 
					{
						int alt44 = 2;
						int LA44_0 = input.LA(1);

						if ( (LA44_0 == ARG) )
						{
							alt44 = 1;
						}


						switch (alt44) 
						{
						case 1 :
							// ANTLRv3Tree.g:266:14: rewrite_template_arg
						{
							PushFollow(FOLLOW_rewrite_template_arg_in_rewrite_template_args1343);
							rewrite_template_arg();
							state.followingStackPointer--;


						}
							break;

						default:
							if ( cnt44 >= 1 ) goto loop44;
							EarlyExitException eee44 =
								new EarlyExitException(44, input);
							throw eee44;
						}
						cnt44++;
					} while (true);

					loop44:
					;	// Stops C# compiler whining that label 'loop44' has no statements


					Match(input, Token.UP, null); 

				}
					break;
				case 2 :
					// ANTLRv3Tree.g:267:4: ARGLIST
				{
					Match(input,ARGLIST,FOLLOW_ARGLIST_in_rewrite_template_args1350); 

				}
					break;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_template_args"


		// $ANTLR start "rewrite_template_arg"
		// ANTLRv3Tree.g:270:1: rewrite_template_arg : ^( ARG ID ACTION ) ;
		public void rewrite_template_arg() // throws RecognitionException [1]
		{   
			try 
			{
				// ANTLRv3Tree.g:271:2: ( ^( ARG ID ACTION ) )
				// ANTLRv3Tree.g:271:6: ^( ARG ID ACTION )
				{
					Match(input,ARG,FOLLOW_ARG_in_rewrite_template_arg1364); 

					Match(input, Token.DOWN, null); 
					Match(input,ID,FOLLOW_ID_in_rewrite_template_arg1366); 
					Match(input,ACTION,FOLLOW_ACTION_in_rewrite_template_arg1368); 

					Match(input, Token.UP, null); 

				}

			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
			}
			finally 
			{
			}
			return ;
		}
		// $ANTLR end "rewrite_template_arg"

		// Delegated rules


		protected DFA30 dfa30;
		protected DFA43 dfa43;
		private void InitializeCyclicDFAs()
		{
			this.dfa30 = new DFA30(this);
			this.dfa43 = new DFA43(this);
		}

		const string DFA30_eotS =
			"\x0c\uffff";
		const string DFA30_eofS =
			"\x0c\uffff";
		const string DFA30_minS =
			"\x01\x08\x01\x02\x06\uffff\x01\x14\x01\x08\x02\uffff";
		const string DFA30_maxS =
			"\x01\x5c\x01\x02\x06\uffff\x01\x14\x01\x5c\x02\uffff";
		const string DFA30_acceptS =
			"\x02\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01\x08\x02"+
				"\uffff\x01\x02\x01\x01";
		const string DFA30_specialS =
			"\x0c\uffff}>";
		static readonly string[] DFA30_transitionS = {
			"\x05\x03\x01\uffff\x01\x02\x11\uffff\x01\x05\x01\x06\x01\x03"+
				"\x02\uffff\x01\x07\x02\x02\x02\uffff\x03\x02\x01\x04\x03\uffff"+
					"\x01\x02\x15\uffff\x01\x01\x0f\uffff\x01\x01\x01\uffff\x01\x02"+
						"\x02\uffff\x01\x02",
			"\x01\x08",
			"",
			"",
			"",
			"",
			"",
			"",
			"\x01\x09",
			"\x01\x0b\x05\uffff\x01\x0a\x17\uffff\x02\x0a\x02\uffff\x03"+
				"\x0a\x04\uffff\x01\x0a\x27\uffff\x01\x0a\x02\uffff\x01\x0a",
			"",
			""
		};

		static readonly short[] DFA30_eot = DFA.UnpackEncodedString(DFA30_eotS);
		static readonly short[] DFA30_eof = DFA.UnpackEncodedString(DFA30_eofS);
		static readonly char[] DFA30_min = DFA.UnpackEncodedStringToUnsignedChars(DFA30_minS);
		static readonly char[] DFA30_max = DFA.UnpackEncodedStringToUnsignedChars(DFA30_maxS);
		static readonly short[] DFA30_accept = DFA.UnpackEncodedString(DFA30_acceptS);
		static readonly short[] DFA30_special = DFA.UnpackEncodedString(DFA30_specialS);
		static readonly short[][] DFA30_transition = DFA.UnpackEncodedStringArray(DFA30_transitionS);

		protected class DFA30 : DFA
		{
			public DFA30(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 30;
				this.eot = DFA30_eot;
				this.eof = DFA30_eof;
				this.min = DFA30_min;
				this.max = DFA30_max;
				this.accept = DFA30_accept;
				this.special = DFA30_special;
				this.transition = DFA30_transition;

			}

			override public string Description
			{
				get { return "140:1: elementNoOptionSpec : ( ^( ( '=' | '+=' ) ID block ) | ^( ( '=' | '+=' ) ID atom ) | atom | ebnf | ACTION | SEMPRED | GATED_SEMPRED | treeSpec );"; }
			}

		}

		const string DFA43_eotS =
			"\x10\uffff";
		const string DFA43_eofS =
			"\x10\uffff";
		const string DFA43_minS =
			"\x01\x1e\x01\x02\x01\uffff\x01\x14\x01\x16\x01\uffff\x01\x02\x01"+
				"\x15\x02\uffff\x01\x02\x01\x14\x01\x2d\x03\x03";
		const string DFA43_maxS =
			"\x01\x2d\x01\x02\x01\uffff\x01\x2d\x01\x16\x01\uffff\x01\x33\x01"+
				"\x15\x02\uffff\x01\x02\x01\x14\x01\x2d\x01\x03\x01\x15\x01\x33";
		const string DFA43_acceptS =
			"\x02\uffff\x01\x04\x02\uffff\x01\x03\x02\uffff\x01\x02\x01\x01"+
				"\x06\uffff";
		const string DFA43_specialS =
			"\x10\uffff}>";
		static readonly string[] DFA43_transitionS = {
			"\x01\x01\x0e\uffff\x01\x02",
			"\x01\x03",
			"",
			"\x01\x04\x18\uffff\x01\x05",
			"\x01\x06",
			"",
			"\x01\x07\x01\x08\x2e\uffff\x02\x09",
			"\x01\x0a",
			"",
			"",
			"\x01\x0b",
			"\x01\x0c",
			"\x01\x0d",
			"\x01\x0e",
			"\x01\x0f\x11\uffff\x01\x0a",
			"\x01\x08\x2e\uffff\x02\x09"
		};

		static readonly short[] DFA43_eot = DFA.UnpackEncodedString(DFA43_eotS);
		static readonly short[] DFA43_eof = DFA.UnpackEncodedString(DFA43_eofS);
		static readonly char[] DFA43_min = DFA.UnpackEncodedStringToUnsignedChars(DFA43_minS);
		static readonly char[] DFA43_max = DFA.UnpackEncodedStringToUnsignedChars(DFA43_maxS);
		static readonly short[] DFA43_accept = DFA.UnpackEncodedString(DFA43_acceptS);
		static readonly short[] DFA43_special = DFA.UnpackEncodedString(DFA43_specialS);
		static readonly short[][] DFA43_transition = DFA.UnpackEncodedStringArray(DFA43_transitionS);

		protected class DFA43 : DFA
		{
			public DFA43(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 43;
				this.eot = DFA43_eot;
				this.eof = DFA43_eof;
				this.min = DFA43_min;
				this.max = DFA43_max;
				this.accept = DFA43_accept;
				this.special = DFA43_special;
				this.transition = DFA43_transition;

			}

			override public string Description
			{
				get { return "246:1: rewrite_template : ( ^( TEMPLATE ID rewrite_template_args ( DOUBLE_QUOTE_STRING_LITERAL | DOUBLE_ANGLE_STRING_LITERAL ) ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION );"; }
			}

		}

 

		public static readonly BitSet FOLLOW_grammarType_in_grammarDef52 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_grammarDef54 = new BitSet(new ulong[]{0x0000420080000090UL,0x0000000000000100UL});
		public static readonly BitSet FOLLOW_DOC_COMMENT_in_grammarDef56 = new BitSet(new ulong[]{0x0000420080000090UL,0x0000000000000100UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_grammarDef59 = new BitSet(new ulong[]{0x0000420080000090UL,0x0000000000000100UL});
		public static readonly BitSet FOLLOW_tokensSpec_in_grammarDef62 = new BitSet(new ulong[]{0x0000420080000090UL,0x0000000000000100UL});
		public static readonly BitSet FOLLOW_attrScope_in_grammarDef65 = new BitSet(new ulong[]{0x0000420080000090UL,0x0000000000000100UL});
		public static readonly BitSet FOLLOW_action_in_grammarDef68 = new BitSet(new ulong[]{0x0000420080000090UL,0x0000000000000100UL});
		public static readonly BitSet FOLLOW_rule_in_grammarDef71 = new BitSet(new ulong[]{0x0000420080000098UL,0x0000000000000100UL});
		public static readonly BitSet FOLLOW_set_in_grammarType0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKENS_in_tokensSpec127 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_tokenSpec_in_tokensSpec129 = new BitSet(new ulong[]{0x0000040000000008UL,0x0000000000000080UL});
		public static readonly BitSet FOLLOW_71_in_tokenSpec143 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_tokenSpec145 = new BitSet(new ulong[]{0x0000080000000000UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_tokenSpec147 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_71_in_tokenSpec154 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_tokenSpec156 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_tokenSpec158 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_tokenSpec164 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SCOPE_in_attrScope176 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_attrScope178 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_attrScope180 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_72_in_action193 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_action195 = new BitSet(new ulong[]{0x0000000000100000UL});
		public static readonly BitSet FOLLOW_ID_in_action197 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_action199 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_72_in_action206 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_action208 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_action210 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_OPTIONS_in_optionsSpec223 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_option_in_optionsSpec225 = new BitSet(new ulong[]{0x0000000000000008UL,0x0000000000000080UL});
		public static readonly BitSet FOLLOW_71_in_option244 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_option246 = new BitSet(new ulong[]{0x0000980000100000UL});
		public static readonly BitSet FOLLOW_optionValue_in_option248 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_set_in_optionValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_RULE_in_rule314 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_rule316 = new BitSet(new ulong[]{0x0000401080A00100UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_modifier_in_rule318 = new BitSet(new ulong[]{0x0000401080A00100UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_ARG_in_rule323 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rule325 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_RET_in_rule332 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rule334 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_rule347 = new BitSet(new ulong[]{0x0000401080A00100UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_ruleScopeSpec_in_rule350 = new BitSet(new ulong[]{0x0000401080A00100UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_ruleAction_in_rule353 = new BitSet(new ulong[]{0x0000401080A00100UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_altList_in_rule364 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000600000UL});
		public static readonly BitSet FOLLOW_exceptionGroup_in_rule374 = new BitSet(new ulong[]{0x0000000000020000UL});
		public static readonly BitSet FOLLOW_EOR_in_rule377 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_set_in_modifier0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_72_in_ruleAction416 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_ruleAction418 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleAction420 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_80_in_throwsSpec433 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_throwsSpec435 = new BitSet(new ulong[]{0x0000000000100008UL});
		public static readonly BitSet FOLLOW_SCOPE_in_ruleScopeSpec449 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleScopeSpec451 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_SCOPE_in_ruleScopeSpec458 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleScopeSpec460 = new BitSet(new ulong[]{0x0000000000100000UL});
		public static readonly BitSet FOLLOW_ID_in_ruleScopeSpec462 = new BitSet(new ulong[]{0x0000000000100008UL});
		public static readonly BitSet FOLLOW_SCOPE_in_ruleScopeSpec470 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_ruleScopeSpec472 = new BitSet(new ulong[]{0x0000000000100008UL});
		public static readonly BitSet FOLLOW_BLOCK_in_block492 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_block494 = new BitSet(new ulong[]{0x0000000000010000UL});
		public static readonly BitSet FOLLOW_alternative_in_block498 = new BitSet(new ulong[]{0x0000010000050000UL});
		public static readonly BitSet FOLLOW_rewrite_in_block500 = new BitSet(new ulong[]{0x0000000000050000UL});
		public static readonly BitSet FOLLOW_EOB_in_block504 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_BLOCK_in_altList527 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_alternative_in_altList530 = new BitSet(new ulong[]{0x0000010000050000UL});
		public static readonly BitSet FOLLOW_rewrite_in_altList532 = new BitSet(new ulong[]{0x0000000000050000UL});
		public static readonly BitSet FOLLOW_EOB_in_altList536 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_ALT_in_alternative558 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_element_in_alternative560 = new BitSet(new ulong[]{0x00023CE700085F00UL,0x0000000012800080UL});
		public static readonly BitSet FOLLOW_EOA_in_alternative563 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_ALT_in_alternative575 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_EPSILON_in_alternative577 = new BitSet(new ulong[]{0x0000000000080000UL});
		public static readonly BitSet FOLLOW_EOA_in_alternative579 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_exceptionHandler_in_exceptionGroup594 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000600000UL});
		public static readonly BitSet FOLLOW_finallyClause_in_exceptionGroup597 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_finallyClause_in_exceptionGroup603 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_85_in_exceptionHandler624 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_exceptionHandler626 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_exceptionHandler628 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_86_in_finallyClause650 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ACTION_in_finallyClause652 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_elementNoOptionSpec_in_element667 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_elementNoOptionSpec679 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_elementNoOptionSpec685 = new BitSet(new ulong[]{0x0000000400001F00UL});
		public static readonly BitSet FOLLOW_block_in_elementNoOptionSpec687 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_set_in_elementNoOptionSpec694 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_elementNoOptionSpec700 = new BitSet(new ulong[]{0x00021CC000004000UL,0x0000000012000000UL});
		public static readonly BitSet FOLLOW_atom_in_elementNoOptionSpec702 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_atom_in_elementNoOptionSpec708 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ebnf_in_elementNoOptionSpec713 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_elementNoOptionSpec720 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMPRED_in_elementNoOptionSpec727 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_GATED_SEMPRED_in_elementNoOptionSpec732 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_treeSpec_in_elementNoOptionSpec739 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_atom751 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_atom_in_atom757 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_range_in_atom763 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_notSet_in_atom768 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_RULE_REF_in_atom777 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_atom779 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_RULE_REF_in_atom788 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_terminal_in_atom798 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_89_in_notSet813 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_notTerminal_in_notSet815 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_89_in_notSet822 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_block_in_notSet824 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_TREE_BEGIN_in_treeSpec837 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_element_in_treeSpec839 = new BitSet(new ulong[]{0x00023CE700085F08UL,0x0000000012800080UL});
		public static readonly BitSet FOLLOW_SYNPRED_in_ebnf855 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_block_in_ebnf857 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_SYN_SEMPRED_in_ebnf863 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_ebnf869 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_block_in_ebnf871 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_block_in_ebnf877 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_RANGE_in_range889 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_range891 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_range893 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_terminal910 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_terminal918 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_terminal926 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_terminal935 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_terminal937 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_92_in_terminal946 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_notTerminal0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_ebnfSuffix0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_REWRITE_in_rewrite1012 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_SEMPRED_in_rewrite1014 = new BitSet(new ulong[]{0x0000200040010000UL});
		public static readonly BitSet FOLLOW_rewrite_alternative_in_rewrite1016 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_REWRITE_in_rewrite1022 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_rewrite_alternative_in_rewrite1024 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_rewrite_template_in_rewrite_alternative1039 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_rewrite_alternative1044 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ALT_in_rewrite_alternative1055 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_EPSILON_in_rewrite_alternative1057 = new BitSet(new ulong[]{0x0000000000080000UL});
		public static readonly BitSet FOLLOW_EOA_in_rewrite_alternative1059 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_BLOCK_in_rewrite_tree_block1078 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_rewrite_tree_block1080 = new BitSet(new ulong[]{0x0000000000040000UL});
		public static readonly BitSet FOLLOW_EOB_in_rewrite_tree_block1082 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_ALT_in_rewrite_tree_alternative1101 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_rewrite_tree_element_in_rewrite_tree_alternative1103 = new BitSet(new ulong[]{0x00023C2020080F00UL});
		public static readonly BitSet FOLLOW_EOA_in_rewrite_tree_alternative1106 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1121 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_in_rewrite_tree_element1126 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_block_in_rewrite_tree_element1133 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_ebnf_in_rewrite_tree_element1140 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_rewrite_tree_atom1156 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_rewrite_tree_atom1163 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_rewrite_tree_atom1171 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rewrite_tree_atom1173 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_RULE_REF_in_rewrite_tree_atom1185 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_rewrite_tree_atom1192 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_LABEL_in_rewrite_tree_atom1199 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_tree_atom1204 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_rewrite_tree_ebnf1216 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_rewrite_tree_block_in_rewrite_tree_ebnf1218 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_TREE_BEGIN_in_rewrite_tree1232 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree1234 = new BitSet(new ulong[]{0x00023C2020080F08UL});
		public static readonly BitSet FOLLOW_rewrite_tree_element_in_rewrite_tree1236 = new BitSet(new ulong[]{0x00023C2020080F08UL});
		public static readonly BitSet FOLLOW_TEMPLATE_in_rewrite_template1254 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_rewrite_template1256 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_template1258 = new BitSet(new ulong[]{0x000C000000000000UL});
		public static readonly BitSet FOLLOW_set_in_rewrite_template1265 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_rewrite_template_ref_in_rewrite_template1281 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_indirect_template_head_in_rewrite_template1286 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_template1291 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TEMPLATE_in_rewrite_template_ref1305 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_rewrite_template_ref1307 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_template_ref1309 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_TEMPLATE_in_rewrite_indirect_template_head1324 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_indirect_template_head1326 = new BitSet(new ulong[]{0x0000000000400000UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_indirect_template_head1328 = new BitSet(new ulong[]{0x0000000000000008UL});
		public static readonly BitSet FOLLOW_ARGLIST_in_rewrite_template_args1341 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_rewrite_template_arg_in_rewrite_template_args1343 = new BitSet(new ulong[]{0x0000000000200008UL});
		public static readonly BitSet FOLLOW_ARGLIST_in_rewrite_template_args1350 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ARG_in_rewrite_template_arg1364 = new BitSet(new ulong[]{0x0000000000000004UL});
		public static readonly BitSet FOLLOW_ID_in_rewrite_template_arg1366 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_template_arg1368 = new BitSet(new ulong[]{0x0000000000000008UL});

	}
}
