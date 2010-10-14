// $ANTLR 3.2 Sep 23, 2009 12:02:23 NewANTLRv3.g 2010-08-28 18:58:58

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using System.Collections;
using Antlr.Runtime;
using Antlr.Runtime.Collections;
using Antlr.Runtime.Tree;

/** ANTLR v3 grammar written in ANTLR v3 with AST construction */
namespace Ucpf.Grammar.Analyzer.Antlr2
{
	public partial class NewANTLRv3Parser : Parser
	{
		public static readonly string[] tokenNames = new string[] 
		{
			"<invalid>", 
			"<EOR>", 
			"<DOWN>", 
			"<UP>", 
			"DOC_COMMENT", 
			"TOKENS", 
			"TOKEN_REF", 
			"STRING_LITERAL", 
			"CHAR_LITERAL", 
			"ACTION", 
			"OPTIONS", 
			"INT", 
			"ARG_ACTION", 
			"SEMPRED", 
			"RULE_REF", 
			"RANGE", 
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
			"'scope'", 
			"'@'", 
			"'::'", 
			"'*'", 
			"'protected'", 
			"'public'", 
			"'private'", 
			"'fragment'", 
			"'!'", 
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
			"'^'", 
			"'~'", 
			"'^('", 
			"'?'", 
			"'+'", 
			"'.'", 
			"'->'", 
			"'$'"
		};

		public const int T__64 = 64;
		public const int NESTED_ACTION = 27;
		public const int T__65 = 65;
		public const int T__62 = 62;
		public const int T__63 = 63;
		public const int DOUBLE_ANGLE_STRING_LITERAL = 17;
		public const int ESC = 22;
		public const int T__61 = 61;
		public const int EOF = -1;
		public const int T__60 = 60;
		public const int SEMPRED = 13;
		public const int ACTION = 9;
		public const int TOKEN_REF = 6;
		public const int T__55 = 55;
		public const int ML_COMMENT = 20;
		public const int T__56 = 56;
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
		public const int WS_LOOP = 29;
		public const int RANGE = 15;
		public const int TOKENS = 5;
		public const int LITERAL_CHAR = 21;
		public const int ACTION_STRING_LITERAL = 25;
		public const int INT = 11;
		public const int RULE_REF = 14;
		public const int T__31 = 31;
		public const int T__32 = 32;
		public const int WS = 30;
		public const int T__33 = 33;
		public const int T__34 = 34;
		public const int T__35 = 35;
		public const int T__36 = 36;
		public const int CHAR_LITERAL = 8;
		public const int T__37 = 37;
		public const int T__38 = 38;
		public const int T__39 = 39;
		public const int XDIGIT = 23;
		public const int SL_COMMENT = 19;
		public const int OPTIONS = 10;

		// delegates
		// delegators



		public NewANTLRv3Parser(ITokenStream input)
			: this(input, new RecognizerSharedState()) {
			}

		public NewANTLRv3Parser(ITokenStream input, RecognizerSharedState state)
			: base(input, state) {
			InitializeCyclicDFAs();

             
			}
        
		protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

		public ITreeAdaptor TreeAdaptor
		{
			get { return this.adaptor; }
			set {
				this.adaptor = value;
			}
		}

		override public string[] TokenNames {
			get { return NewANTLRv3Parser.tokenNames; }
		}

		override public string GrammarFileName {
			get { return "NewANTLRv3.g"; }
		}


		int gtype;


		public class grammarDef_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "grammarDef"
		// NewANTLRv3.g:42:1: grammarDef : ( DOC_COMMENT )? ( 'lexer' | 'parser' | 'tree' | ) g= 'grammar' id ';' ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ EOF ;
		public NewANTLRv3Parser.grammarDef_return grammarDef() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.grammarDef_return retval = new NewANTLRv3Parser.grammarDef_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken g = null;
			IToken DOC_COMMENT1 = null;
			IToken string_literal2 = null;
			IToken string_literal3 = null;
			IToken string_literal4 = null;
			IToken char_literal6 = null;
			IToken EOF12 = null;
			NewANTLRv3Parser.id_return id5 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.optionsSpec_return optionsSpec7 = default(NewANTLRv3Parser.optionsSpec_return);

			NewANTLRv3Parser.tokensSpec_return tokensSpec8 = default(NewANTLRv3Parser.tokensSpec_return);

			NewANTLRv3Parser.attrScope_return attrScope9 = default(NewANTLRv3Parser.attrScope_return);

			NewANTLRv3Parser.action_return action10 = default(NewANTLRv3Parser.action_return);

			NewANTLRv3Parser.rule_return rule11 = default(NewANTLRv3Parser.rule_return);


			CommonTree g_tree=null;
			CommonTree DOC_COMMENT1_tree=null;
			CommonTree string_literal2_tree=null;
			CommonTree string_literal3_tree=null;
			CommonTree string_literal4_tree=null;
			CommonTree char_literal6_tree=null;
			CommonTree EOF12_tree=null;

			try 
			{
				// NewANTLRv3.g:43:5: ( ( DOC_COMMENT )? ( 'lexer' | 'parser' | 'tree' | ) g= 'grammar' id ';' ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ EOF )
				// NewANTLRv3.g:43:9: ( DOC_COMMENT )? ( 'lexer' | 'parser' | 'tree' | ) g= 'grammar' id ';' ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ EOF
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// NewANTLRv3.g:43:9: ( DOC_COMMENT )?
					int alt1 = 2;
					int LA1_0 = input.LA(1);

					if ( (LA1_0 == DOC_COMMENT) )
					{
						alt1 = 1;
					}
					switch (alt1) 
					{
					case 1 :
						// NewANTLRv3.g:43:9: DOC_COMMENT
					{
						DOC_COMMENT1=(IToken)Match(input,DOC_COMMENT,FOLLOW_DOC_COMMENT_in_grammarDef50); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{DOC_COMMENT1_tree = (CommonTree)adaptor.Create(DOC_COMMENT1);
							adaptor.AddChild(root_0, DOC_COMMENT1_tree);
						}

					}
						break;

					}

					// NewANTLRv3.g:44:6: ( 'lexer' | 'parser' | 'tree' | )
					int alt2 = 4;
					switch ( input.LA(1) ) 
					{
					case 31:
					{
						alt2 = 1;
					}
						break;
					case 32:
					{
						alt2 = 2;
					}
						break;
					case 33:
					{
						alt2 = 3;
					}
						break;
					case 34:
					{
						alt2 = 4;
					}
						break;
					default:
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d2s0 =
							new NoViableAltException("", 2, 0, input);

						throw nvae_d2s0;
					}

					switch (alt2) 
					{
					case 1 :
						// NewANTLRv3.g:44:8: 'lexer'
					{
						string_literal2=(IToken)Match(input,31,FOLLOW_31_in_grammarDef60); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal2_tree = (CommonTree)adaptor.Create(string_literal2);
							adaptor.AddChild(root_0, string_literal2_tree);
						}
						if ( (state.backtracking==0) )
						{
						}

					}
						break;
					case 2 :
						// NewANTLRv3.g:45:10: 'parser'
					{
						string_literal3=(IToken)Match(input,32,FOLLOW_32_in_grammarDef78); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal3_tree = (CommonTree)adaptor.Create(string_literal3);
							adaptor.AddChild(root_0, string_literal3_tree);
						}
						if ( (state.backtracking==0) )
						{
						}

					}
						break;
					case 3 :
						// NewANTLRv3.g:46:10: 'tree'
					{
						string_literal4=(IToken)Match(input,33,FOLLOW_33_in_grammarDef94); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal4_tree = (CommonTree)adaptor.Create(string_literal4);
							adaptor.AddChild(root_0, string_literal4_tree);
						}
						if ( (state.backtracking==0) )
						{
						}

					}
						break;
					case 4 :
						// NewANTLRv3.g:47:14: 
					{
						if ( (state.backtracking==0) )
						{
						}

					}
						break;

					}

					g=(IToken)Match(input,34,FOLLOW_34_in_grammarDef135); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{g_tree = (CommonTree)adaptor.Create(g);
						adaptor.AddChild(root_0, g_tree);
					}
					PushFollow(FOLLOW_id_in_grammarDef137);
					id5 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id5.Tree);
					char_literal6=(IToken)Match(input,35,FOLLOW_35_in_grammarDef139); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal6_tree = (CommonTree)adaptor.Create(char_literal6);
						adaptor.AddChild(root_0, char_literal6_tree);
					}
					// NewANTLRv3.g:49:25: ( optionsSpec )?
					int alt3 = 2;
					int LA3_0 = input.LA(1);

					if ( (LA3_0 == OPTIONS) )
					{
						alt3 = 1;
					}
					switch (alt3) 
					{
					case 1 :
						// NewANTLRv3.g:49:25: optionsSpec
					{
						PushFollow(FOLLOW_optionsSpec_in_grammarDef141);
						optionsSpec7 = optionsSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, optionsSpec7.Tree);

					}
						break;

					}

					// NewANTLRv3.g:49:38: ( tokensSpec )?
					int alt4 = 2;
					int LA4_0 = input.LA(1);

					if ( (LA4_0 == TOKENS) )
					{
						alt4 = 1;
					}
					switch (alt4) 
					{
					case 1 :
						// NewANTLRv3.g:49:38: tokensSpec
					{
						PushFollow(FOLLOW_tokensSpec_in_grammarDef144);
						tokensSpec8 = tokensSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, tokensSpec8.Tree);

					}
						break;

					}

					// NewANTLRv3.g:49:50: ( attrScope )*
					do 
					{
						int alt5 = 2;
						int LA5_0 = input.LA(1);

						if ( (LA5_0 == 38) )
						{
							alt5 = 1;
						}


						switch (alt5) 
						{
						case 1 :
							// NewANTLRv3.g:49:50: attrScope
						{
							PushFollow(FOLLOW_attrScope_in_grammarDef147);
							attrScope9 = attrScope();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, attrScope9.Tree);

						}
							break;

						default:
							goto loop5;
						}
					} while (true);

					loop5:
					;	// Stops C# compiler whining that label 'loop5' has no statements

					// NewANTLRv3.g:49:61: ( action )*
					do 
					{
						int alt6 = 2;
						int LA6_0 = input.LA(1);

						if ( (LA6_0 == 39) )
						{
							alt6 = 1;
						}


						switch (alt6) 
						{
						case 1 :
							// NewANTLRv3.g:49:61: action
						{
							PushFollow(FOLLOW_action_in_grammarDef150);
							action10 = action();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, action10.Tree);

						}
							break;

						default:
							goto loop6;
						}
					} while (true);

					loop6:
					;	// Stops C# compiler whining that label 'loop6' has no statements

					// NewANTLRv3.g:50:6: ( rule )+
					int cnt7 = 0;
					do 
					{
						int alt7 = 2;
						int LA7_0 = input.LA(1);

						if ( (LA7_0 == DOC_COMMENT || LA7_0 == TOKEN_REF || LA7_0 == RULE_REF || (LA7_0 >= 42 && LA7_0 <= 45)) )
						{
							alt7 = 1;
						}


						switch (alt7) 
						{
						case 1 :
							// NewANTLRv3.g:50:6: rule
						{
							PushFollow(FOLLOW_rule_in_grammarDef158);
							rule11 = rule();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rule11.Tree);

						}
							break;

						default:
							if ( cnt7 >= 1 ) goto loop7;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee7 =
								new EarlyExitException(7, input);
							throw eee7;
						}
						cnt7++;
					} while (true);

					loop7:
					;	// Stops C# compiler whining that label 'loop7' has no statements

					EOF12=(IToken)Match(input,EOF,FOLLOW_EOF_in_grammarDef166); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{EOF12_tree = (CommonTree)adaptor.Create(EOF12);
						adaptor.AddChild(root_0, EOF12_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "grammarDef"

		public class tokensSpec_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "tokensSpec"
		// NewANTLRv3.g:54:1: tokensSpec : TOKENS ( tokenSpec )+ '}' ;
		public NewANTLRv3Parser.tokensSpec_return tokensSpec() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.tokensSpec_return retval = new NewANTLRv3Parser.tokensSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken TOKENS13 = null;
			IToken char_literal15 = null;
			NewANTLRv3Parser.tokenSpec_return tokenSpec14 = default(NewANTLRv3Parser.tokenSpec_return);


			CommonTree TOKENS13_tree=null;
			CommonTree char_literal15_tree=null;

			try 
			{
				// NewANTLRv3.g:55:2: ( TOKENS ( tokenSpec )+ '}' )
				// NewANTLRv3.g:55:4: TOKENS ( tokenSpec )+ '}'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					TOKENS13=(IToken)Match(input,TOKENS,FOLLOW_TOKENS_in_tokensSpec180); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{TOKENS13_tree = (CommonTree)adaptor.Create(TOKENS13);
						adaptor.AddChild(root_0, TOKENS13_tree);
					}
					// NewANTLRv3.g:55:11: ( tokenSpec )+
					int cnt8 = 0;
					do 
					{
						int alt8 = 2;
						int LA8_0 = input.LA(1);

						if ( (LA8_0 == TOKEN_REF) )
						{
							alt8 = 1;
						}


						switch (alt8) 
						{
						case 1 :
							// NewANTLRv3.g:55:11: tokenSpec
						{
							PushFollow(FOLLOW_tokenSpec_in_tokensSpec182);
							tokenSpec14 = tokenSpec();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, tokenSpec14.Tree);

						}
							break;

						default:
							if ( cnt8 >= 1 ) goto loop8;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee8 =
								new EarlyExitException(8, input);
							throw eee8;
						}
						cnt8++;
					} while (true);

					loop8:
					;	// Stops C# compiler whining that label 'loop8' has no statements

					char_literal15=(IToken)Match(input,36,FOLLOW_36_in_tokensSpec185); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal15_tree = (CommonTree)adaptor.Create(char_literal15);
						adaptor.AddChild(root_0, char_literal15_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "tokensSpec"

		public class tokenSpec_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "tokenSpec"
		// NewANTLRv3.g:58:1: tokenSpec : TOKEN_REF ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | ) ';' ;
		public NewANTLRv3Parser.tokenSpec_return tokenSpec() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.tokenSpec_return retval = new NewANTLRv3Parser.tokenSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lit = null;
			IToken TOKEN_REF16 = null;
			IToken char_literal17 = null;
			IToken char_literal18 = null;

			CommonTree lit_tree=null;
			CommonTree TOKEN_REF16_tree=null;
			CommonTree char_literal17_tree=null;
			CommonTree char_literal18_tree=null;

			try 
			{
				// NewANTLRv3.g:59:2: ( TOKEN_REF ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | ) ';' )
				// NewANTLRv3.g:59:4: TOKEN_REF ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | ) ';'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					TOKEN_REF16=(IToken)Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_tokenSpec196); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{TOKEN_REF16_tree = (CommonTree)adaptor.Create(TOKEN_REF16);
						adaptor.AddChild(root_0, TOKEN_REF16_tree);
					}
					// NewANTLRv3.g:60:3: ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | )
					int alt10 = 2;
					int LA10_0 = input.LA(1);

					if ( (LA10_0 == 37) )
					{
						alt10 = 1;
					}
					else if ( (LA10_0 == 35) )
					{
						alt10 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d10s0 =
							new NoViableAltException("", 10, 0, input);

						throw nvae_d10s0;
					}
					switch (alt10) 
					{
					case 1 :
						// NewANTLRv3.g:60:5: '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL )
					{
						char_literal17=(IToken)Match(input,37,FOLLOW_37_in_tokenSpec202); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal17_tree = (CommonTree)adaptor.Create(char_literal17);
							adaptor.AddChild(root_0, char_literal17_tree);
						}
						// NewANTLRv3.g:60:9: (lit= STRING_LITERAL | lit= CHAR_LITERAL )
						int alt9 = 2;
						int LA9_0 = input.LA(1);

						if ( (LA9_0 == STRING_LITERAL) )
						{
							alt9 = 1;
						}
						else if ( (LA9_0 == CHAR_LITERAL) )
						{
							alt9 = 2;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d9s0 =
								new NoViableAltException("", 9, 0, input);

							throw nvae_d9s0;
						}
						switch (alt9) 
						{
						case 1 :
							// NewANTLRv3.g:60:10: lit= STRING_LITERAL
						{
							lit=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_tokenSpec207); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{lit_tree = (CommonTree)adaptor.Create(lit);
								adaptor.AddChild(root_0, lit_tree);
							}

						}
							break;
						case 2 :
							// NewANTLRv3.g:60:29: lit= CHAR_LITERAL
						{
							lit=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_tokenSpec211); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{lit_tree = (CommonTree)adaptor.Create(lit);
								adaptor.AddChild(root_0, lit_tree);
							}

						}
							break;

						}


					}
						break;
					case 2 :
						// NewANTLRv3.g:62:3: 
					{
					}
						break;

					}

					char_literal18=(IToken)Match(input,35,FOLLOW_35_in_tokenSpec224); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal18_tree = (CommonTree)adaptor.Create(char_literal18);
						adaptor.AddChild(root_0, char_literal18_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "tokenSpec"

		public class attrScope_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "attrScope"
		// NewANTLRv3.g:66:1: attrScope : 'scope' id ACTION ;
		public NewANTLRv3Parser.attrScope_return attrScope() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.attrScope_return retval = new NewANTLRv3Parser.attrScope_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal19 = null;
			IToken ACTION21 = null;
			NewANTLRv3Parser.id_return id20 = default(NewANTLRv3Parser.id_return);


			CommonTree string_literal19_tree=null;
			CommonTree ACTION21_tree=null;

			try 
			{
				// NewANTLRv3.g:67:2: ( 'scope' id ACTION )
				// NewANTLRv3.g:67:4: 'scope' id ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal19=(IToken)Match(input,38,FOLLOW_38_in_attrScope235); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal19_tree = (CommonTree)adaptor.Create(string_literal19);
						adaptor.AddChild(root_0, string_literal19_tree);
					}
					PushFollow(FOLLOW_id_in_attrScope237);
					id20 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id20.Tree);
					ACTION21=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_attrScope239); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION21_tree = (CommonTree)adaptor.Create(ACTION21);
						adaptor.AddChild(root_0, ACTION21_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "attrScope"

		public class action_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "action"
		// NewANTLRv3.g:70:1: action : '@' ( actionScopeName '::' )? id ACTION ;
		public NewANTLRv3Parser.action_return action() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.action_return retval = new NewANTLRv3Parser.action_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal22 = null;
			IToken string_literal24 = null;
			IToken ACTION26 = null;
			NewANTLRv3Parser.actionScopeName_return actionScopeName23 = default(NewANTLRv3Parser.actionScopeName_return);

			NewANTLRv3Parser.id_return id25 = default(NewANTLRv3Parser.id_return);


			CommonTree char_literal22_tree=null;
			CommonTree string_literal24_tree=null;
			CommonTree ACTION26_tree=null;

			try 
			{
				// NewANTLRv3.g:72:2: ( '@' ( actionScopeName '::' )? id ACTION )
				// NewANTLRv3.g:72:4: '@' ( actionScopeName '::' )? id ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					char_literal22=(IToken)Match(input,39,FOLLOW_39_in_action252); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal22_tree = (CommonTree)adaptor.Create(char_literal22);
						adaptor.AddChild(root_0, char_literal22_tree);
					}
					// NewANTLRv3.g:72:8: ( actionScopeName '::' )?
					int alt11 = 2;
					int LA11_0 = input.LA(1);

					if ( (LA11_0 == TOKEN_REF || LA11_0 == RULE_REF) )
					{
						int LA11_1 = input.LA(2);

						if ( (LA11_1 == 40) )
						{
							alt11 = 1;
						}
					}
					else if ( ((LA11_0 >= 31 && LA11_0 <= 32)) )
					{
						alt11 = 1;
					}
					switch (alt11) 
					{
					case 1 :
						// NewANTLRv3.g:72:9: actionScopeName '::'
					{
						PushFollow(FOLLOW_actionScopeName_in_action255);
						actionScopeName23 = actionScopeName();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, actionScopeName23.Tree);
						string_literal24=(IToken)Match(input,40,FOLLOW_40_in_action257); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal24_tree = (CommonTree)adaptor.Create(string_literal24);
							adaptor.AddChild(root_0, string_literal24_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_id_in_action261);
					id25 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id25.Tree);
					ACTION26=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_action263); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION26_tree = (CommonTree)adaptor.Create(ACTION26);
						adaptor.AddChild(root_0, ACTION26_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "action"

		public class actionScopeName_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "actionScopeName"
		// NewANTLRv3.g:75:1: actionScopeName : ( id | l= 'lexer' | p= 'parser' );
		public NewANTLRv3Parser.actionScopeName_return actionScopeName() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.actionScopeName_return retval = new NewANTLRv3Parser.actionScopeName_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken l = null;
			IToken p = null;
			NewANTLRv3Parser.id_return id27 = default(NewANTLRv3Parser.id_return);


			CommonTree l_tree=null;
			CommonTree p_tree=null;

			try 
			{
				// NewANTLRv3.g:79:2: ( id | l= 'lexer' | p= 'parser' )
				int alt12 = 3;
				switch ( input.LA(1) ) 
				{
				case TOKEN_REF:
				case RULE_REF:
				{
					alt12 = 1;
				}
					break;
				case 31:
				{
					alt12 = 2;
				}
					break;
				case 32:
				{
					alt12 = 3;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d12s0 =
						new NoViableAltException("", 12, 0, input);

					throw nvae_d12s0;
				}

				switch (alt12) 
				{
				case 1 :
					// NewANTLRv3.g:79:4: id
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_actionScopeName276);
					id27 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id27.Tree);

				}
					break;
				case 2 :
					// NewANTLRv3.g:80:4: l= 'lexer'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					l=(IToken)Match(input,31,FOLLOW_31_in_actionScopeName283); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{l_tree = (CommonTree)adaptor.Create(l);
						adaptor.AddChild(root_0, l_tree);
					}

				}
					break;
				case 3 :
					// NewANTLRv3.g:81:9: p= 'parser'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					p=(IToken)Match(input,32,FOLLOW_32_in_actionScopeName295); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{p_tree = (CommonTree)adaptor.Create(p);
						adaptor.AddChild(root_0, p_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "actionScopeName"

		public class optionsSpec_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "optionsSpec"
		// NewANTLRv3.g:84:1: optionsSpec : OPTIONS ( option ';' )+ '}' ;
		public NewANTLRv3Parser.optionsSpec_return optionsSpec() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.optionsSpec_return retval = new NewANTLRv3Parser.optionsSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken OPTIONS28 = null;
			IToken char_literal30 = null;
			IToken char_literal31 = null;
			NewANTLRv3Parser.option_return option29 = default(NewANTLRv3Parser.option_return);


			CommonTree OPTIONS28_tree=null;
			CommonTree char_literal30_tree=null;
			CommonTree char_literal31_tree=null;

			try 
			{
				// NewANTLRv3.g:85:2: ( OPTIONS ( option ';' )+ '}' )
				// NewANTLRv3.g:85:4: OPTIONS ( option ';' )+ '}'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					OPTIONS28=(IToken)Match(input,OPTIONS,FOLLOW_OPTIONS_in_optionsSpec306); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{OPTIONS28_tree = (CommonTree)adaptor.Create(OPTIONS28);
						adaptor.AddChild(root_0, OPTIONS28_tree);
					}
					// NewANTLRv3.g:85:12: ( option ';' )+
					int cnt13 = 0;
					do 
					{
						int alt13 = 2;
						int LA13_0 = input.LA(1);

						if ( (LA13_0 == TOKEN_REF || LA13_0 == RULE_REF) )
						{
							alt13 = 1;
						}


						switch (alt13) 
						{
						case 1 :
							// NewANTLRv3.g:85:13: option ';'
						{
							PushFollow(FOLLOW_option_in_optionsSpec309);
							option29 = option();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, option29.Tree);
							char_literal30=(IToken)Match(input,35,FOLLOW_35_in_optionsSpec311); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal30_tree = (CommonTree)adaptor.Create(char_literal30);
								adaptor.AddChild(root_0, char_literal30_tree);
							}

						}
							break;

						default:
							if ( cnt13 >= 1 ) goto loop13;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee13 =
								new EarlyExitException(13, input);
							throw eee13;
						}
						cnt13++;
					} while (true);

					loop13:
					;	// Stops C# compiler whining that label 'loop13' has no statements

					char_literal31=(IToken)Match(input,36,FOLLOW_36_in_optionsSpec315); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal31_tree = (CommonTree)adaptor.Create(char_literal31);
						adaptor.AddChild(root_0, char_literal31_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "optionsSpec"

		public class option_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "option"
		// NewANTLRv3.g:88:1: option : id '=' optionValue ;
		public NewANTLRv3Parser.option_return option() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.option_return retval = new NewANTLRv3Parser.option_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal33 = null;
			NewANTLRv3Parser.id_return id32 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.optionValue_return optionValue34 = default(NewANTLRv3Parser.optionValue_return);


			CommonTree char_literal33_tree=null;

			try 
			{
				// NewANTLRv3.g:89:5: ( id '=' optionValue )
				// NewANTLRv3.g:89:9: id '=' optionValue
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_option331);
					id32 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id32.Tree);
					char_literal33=(IToken)Match(input,37,FOLLOW_37_in_option333); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal33_tree = (CommonTree)adaptor.Create(char_literal33);
						adaptor.AddChild(root_0, char_literal33_tree);
					}
					PushFollow(FOLLOW_optionValue_in_option335);
					optionValue34 = optionValue();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, optionValue34.Tree);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "option"

		public class optionValue_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "optionValue"
		// NewANTLRv3.g:92:1: optionValue : ( id | STRING_LITERAL | CHAR_LITERAL | INT | s= '*' );
		public NewANTLRv3Parser.optionValue_return optionValue() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.optionValue_return retval = new NewANTLRv3Parser.optionValue_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken s = null;
			IToken STRING_LITERAL36 = null;
			IToken CHAR_LITERAL37 = null;
			IToken INT38 = null;
			NewANTLRv3Parser.id_return id35 = default(NewANTLRv3Parser.id_return);


			CommonTree s_tree=null;
			CommonTree STRING_LITERAL36_tree=null;
			CommonTree CHAR_LITERAL37_tree=null;
			CommonTree INT38_tree=null;

			try 
			{
				// NewANTLRv3.g:93:5: ( id | STRING_LITERAL | CHAR_LITERAL | INT | s= '*' )
				int alt14 = 5;
				switch ( input.LA(1) ) 
				{
				case TOKEN_REF:
				case RULE_REF:
				{
					alt14 = 1;
				}
					break;
				case STRING_LITERAL:
				{
					alt14 = 2;
				}
					break;
				case CHAR_LITERAL:
				{
					alt14 = 3;
				}
					break;
				case INT:
				{
					alt14 = 4;
				}
					break;
				case 41:
				{
					alt14 = 5;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d14s0 =
						new NoViableAltException("", 14, 0, input);

					throw nvae_d14s0;
				}

				switch (alt14) 
				{
				case 1 :
					// NewANTLRv3.g:93:9: id
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_optionValue354);
					id35 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id35.Tree);

				}
					break;
				case 2 :
					// NewANTLRv3.g:94:9: STRING_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					STRING_LITERAL36=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_optionValue364); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{STRING_LITERAL36_tree = (CommonTree)adaptor.Create(STRING_LITERAL36);
						adaptor.AddChild(root_0, STRING_LITERAL36_tree);
					}

				}
					break;
				case 3 :
					// NewANTLRv3.g:95:9: CHAR_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					CHAR_LITERAL37=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_optionValue374); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{CHAR_LITERAL37_tree = (CommonTree)adaptor.Create(CHAR_LITERAL37);
						adaptor.AddChild(root_0, CHAR_LITERAL37_tree);
					}

				}
					break;
				case 4 :
					// NewANTLRv3.g:96:9: INT
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					INT38=(IToken)Match(input,INT,FOLLOW_INT_in_optionValue384); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{INT38_tree = (CommonTree)adaptor.Create(INT38);
						adaptor.AddChild(root_0, INT38_tree);
					}

				}
					break;
				case 5 :
					// NewANTLRv3.g:97:7: s= '*'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					s=(IToken)Match(input,41,FOLLOW_41_in_optionValue394); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{s_tree = (CommonTree)adaptor.Create(s);
						adaptor.AddChild(root_0, s_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "optionValue"

		protected class rule_scope 
		{
			protected internal String name;
		}
		protected StackList rule_stack = new StackList();

		public class rule_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rule"
		// NewANTLRv3.g:100:1: rule : ( DOC_COMMENT )? (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )? id ( '!' )? (arg= ARG_ACTION )? ( 'returns' rt= ARG_ACTION )? ( throwsSpec )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* ':' altList ';' ( exceptionGroup )? ;
		public NewANTLRv3Parser.rule_return rule() // throws RecognitionException [1]
		{   
			rule_stack.Push(new rule_scope());
			NewANTLRv3Parser.rule_return retval = new NewANTLRv3Parser.rule_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken modifier = null;
			IToken arg = null;
			IToken rt = null;
			IToken DOC_COMMENT39 = null;
			IToken char_literal41 = null;
			IToken string_literal42 = null;
			IToken char_literal47 = null;
			IToken char_literal49 = null;
			NewANTLRv3Parser.id_return id40 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.throwsSpec_return throwsSpec43 = default(NewANTLRv3Parser.throwsSpec_return);

			NewANTLRv3Parser.optionsSpec_return optionsSpec44 = default(NewANTLRv3Parser.optionsSpec_return);

			NewANTLRv3Parser.ruleScopeSpec_return ruleScopeSpec45 = default(NewANTLRv3Parser.ruleScopeSpec_return);

			NewANTLRv3Parser.ruleAction_return ruleAction46 = default(NewANTLRv3Parser.ruleAction_return);

			NewANTLRv3Parser.altList_return altList48 = default(NewANTLRv3Parser.altList_return);

			NewANTLRv3Parser.exceptionGroup_return exceptionGroup50 = default(NewANTLRv3Parser.exceptionGroup_return);


			CommonTree modifier_tree=null;
			CommonTree arg_tree=null;
			CommonTree rt_tree=null;
			CommonTree DOC_COMMENT39_tree=null;
			CommonTree char_literal41_tree=null;
			CommonTree string_literal42_tree=null;
			CommonTree char_literal47_tree=null;
			CommonTree char_literal49_tree=null;

			try 
			{
				// NewANTLRv3.g:104:2: ( ( DOC_COMMENT )? (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )? id ( '!' )? (arg= ARG_ACTION )? ( 'returns' rt= ARG_ACTION )? ( throwsSpec )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* ':' altList ';' ( exceptionGroup )? )
				// NewANTLRv3.g:104:4: ( DOC_COMMENT )? (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )? id ( '!' )? (arg= ARG_ACTION )? ( 'returns' rt= ARG_ACTION )? ( throwsSpec )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* ':' altList ';' ( exceptionGroup )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// NewANTLRv3.g:104:4: ( DOC_COMMENT )?
					int alt15 = 2;
					int LA15_0 = input.LA(1);

					if ( (LA15_0 == DOC_COMMENT) )
					{
						alt15 = 1;
					}
					switch (alt15) 
					{
					case 1 :
						// NewANTLRv3.g:104:4: DOC_COMMENT
					{
						DOC_COMMENT39=(IToken)Match(input,DOC_COMMENT,FOLLOW_DOC_COMMENT_in_rule412); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{DOC_COMMENT39_tree = (CommonTree)adaptor.Create(DOC_COMMENT39);
							adaptor.AddChild(root_0, DOC_COMMENT39_tree);
						}

					}
						break;

					}

					// NewANTLRv3.g:105:3: (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )?
					int alt16 = 2;
					int LA16_0 = input.LA(1);

					if ( ((LA16_0 >= 42 && LA16_0 <= 45)) )
					{
						alt16 = 1;
					}
					switch (alt16) 
					{
					case 1 :
						// NewANTLRv3.g:105:5: modifier= ( 'protected' | 'public' | 'private' | 'fragment' )
					{
						modifier = (IToken)input.LT(1);
						if ( (input.LA(1) >= 42 && input.LA(1) <= 45) ) 
						{
							input.Consume();
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(modifier));
							state.errorRecovery = false;state.failed = false;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							MismatchedSetException mse = new MismatchedSetException(null,input);
							throw mse;
						}


					}
						break;

					}

					PushFollow(FOLLOW_id_in_rule436);
					id40 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id40.Tree);
					if ( (state.backtracking==0) )
					{
						((rule_scope)rule_stack.Peek()).name =  ((id40 != null) ? input.ToString((IToken)(id40.Start),(IToken)(id40.Stop)) : null);
					}
					// NewANTLRv3.g:107:3: ( '!' )?
					int alt17 = 2;
					int LA17_0 = input.LA(1);

					if ( (LA17_0 == 46) )
					{
						alt17 = 1;
					}
					switch (alt17) 
					{
					case 1 :
						// NewANTLRv3.g:107:3: '!'
					{
						char_literal41=(IToken)Match(input,46,FOLLOW_46_in_rule442); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal41_tree = (CommonTree)adaptor.Create(char_literal41);
							adaptor.AddChild(root_0, char_literal41_tree);
						}

					}
						break;

					}

					// NewANTLRv3.g:108:3: (arg= ARG_ACTION )?
					int alt18 = 2;
					int LA18_0 = input.LA(1);

					if ( (LA18_0 == ARG_ACTION) )
					{
						alt18 = 1;
					}
					switch (alt18) 
					{
					case 1 :
						// NewANTLRv3.g:108:5: arg= ARG_ACTION
					{
						arg=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rule451); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{arg_tree = (CommonTree)adaptor.Create(arg);
							adaptor.AddChild(root_0, arg_tree);
						}

					}
						break;

					}

					// NewANTLRv3.g:109:3: ( 'returns' rt= ARG_ACTION )?
					int alt19 = 2;
					int LA19_0 = input.LA(1);

					if ( (LA19_0 == 47) )
					{
						alt19 = 1;
					}
					switch (alt19) 
					{
					case 1 :
						// NewANTLRv3.g:109:5: 'returns' rt= ARG_ACTION
					{
						string_literal42=(IToken)Match(input,47,FOLLOW_47_in_rule460); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal42_tree = (CommonTree)adaptor.Create(string_literal42);
							adaptor.AddChild(root_0, string_literal42_tree);
						}
						rt=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rule464); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{rt_tree = (CommonTree)adaptor.Create(rt);
							adaptor.AddChild(root_0, rt_tree);
						}

					}
						break;

					}

					// NewANTLRv3.g:110:3: ( throwsSpec )?
					int alt20 = 2;
					int LA20_0 = input.LA(1);

					if ( (LA20_0 == 49) )
					{
						alt20 = 1;
					}
					switch (alt20) 
					{
					case 1 :
						// NewANTLRv3.g:110:3: throwsSpec
					{
						PushFollow(FOLLOW_throwsSpec_in_rule472);
						throwsSpec43 = throwsSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, throwsSpec43.Tree);

					}
						break;

					}

					// NewANTLRv3.g:110:15: ( optionsSpec )?
					int alt21 = 2;
					int LA21_0 = input.LA(1);

					if ( (LA21_0 == OPTIONS) )
					{
						alt21 = 1;
					}
					switch (alt21) 
					{
					case 1 :
						// NewANTLRv3.g:110:15: optionsSpec
					{
						PushFollow(FOLLOW_optionsSpec_in_rule475);
						optionsSpec44 = optionsSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, optionsSpec44.Tree);

					}
						break;

					}

					// NewANTLRv3.g:110:28: ( ruleScopeSpec )?
					int alt22 = 2;
					int LA22_0 = input.LA(1);

					if ( (LA22_0 == 38) )
					{
						alt22 = 1;
					}
					switch (alt22) 
					{
					case 1 :
						// NewANTLRv3.g:110:28: ruleScopeSpec
					{
						PushFollow(FOLLOW_ruleScopeSpec_in_rule478);
						ruleScopeSpec45 = ruleScopeSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ruleScopeSpec45.Tree);

					}
						break;

					}

					// NewANTLRv3.g:110:43: ( ruleAction )*
					do 
					{
						int alt23 = 2;
						int LA23_0 = input.LA(1);

						if ( (LA23_0 == 39) )
						{
							alt23 = 1;
						}


						switch (alt23) 
						{
						case 1 :
							// NewANTLRv3.g:110:43: ruleAction
						{
							PushFollow(FOLLOW_ruleAction_in_rule481);
							ruleAction46 = ruleAction();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ruleAction46.Tree);

						}
							break;

						default:
							goto loop23;
						}
					} while (true);

					loop23:
					;	// Stops C# compiler whining that label 'loop23' has no statements

					char_literal47=(IToken)Match(input,48,FOLLOW_48_in_rule486); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal47_tree = (CommonTree)adaptor.Create(char_literal47);
						adaptor.AddChild(root_0, char_literal47_tree);
					}
					PushFollow(FOLLOW_altList_in_rule488);
					altList48 = altList();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, altList48.Tree);
					char_literal49=(IToken)Match(input,35,FOLLOW_35_in_rule490); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal49_tree = (CommonTree)adaptor.Create(char_literal49);
						adaptor.AddChild(root_0, char_literal49_tree);
					}
					// NewANTLRv3.g:112:3: ( exceptionGroup )?
					int alt24 = 2;
					int LA24_0 = input.LA(1);

					if ( ((LA24_0 >= 54 && LA24_0 <= 55)) )
					{
						alt24 = 1;
					}
					switch (alt24) 
					{
					case 1 :
						// NewANTLRv3.g:112:3: exceptionGroup
					{
						PushFollow(FOLLOW_exceptionGroup_in_rule494);
						exceptionGroup50 = exceptionGroup();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exceptionGroup50.Tree);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
				rule_stack.Pop();
			}
			return retval;
		}
		// $ANTLR end "rule"

		public class ruleAction_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ruleAction"
		// NewANTLRv3.g:115:1: ruleAction : '@' id ACTION ;
		public NewANTLRv3Parser.ruleAction_return ruleAction() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.ruleAction_return retval = new NewANTLRv3Parser.ruleAction_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal51 = null;
			IToken ACTION53 = null;
			NewANTLRv3Parser.id_return id52 = default(NewANTLRv3Parser.id_return);


			CommonTree char_literal51_tree=null;
			CommonTree ACTION53_tree=null;

			try 
			{
				// NewANTLRv3.g:117:2: ( '@' id ACTION )
				// NewANTLRv3.g:117:4: '@' id ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					char_literal51=(IToken)Match(input,39,FOLLOW_39_in_ruleAction508); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal51_tree = (CommonTree)adaptor.Create(char_literal51);
						adaptor.AddChild(root_0, char_literal51_tree);
					}
					PushFollow(FOLLOW_id_in_ruleAction510);
					id52 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id52.Tree);
					ACTION53=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_ruleAction512); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION53_tree = (CommonTree)adaptor.Create(ACTION53);
						adaptor.AddChild(root_0, ACTION53_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "ruleAction"

		public class throwsSpec_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "throwsSpec"
		// NewANTLRv3.g:120:1: throwsSpec : 'throws' id ( ',' id )* ;
		public NewANTLRv3Parser.throwsSpec_return throwsSpec() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.throwsSpec_return retval = new NewANTLRv3Parser.throwsSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal54 = null;
			IToken char_literal56 = null;
			NewANTLRv3Parser.id_return id55 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.id_return id57 = default(NewANTLRv3Parser.id_return);


			CommonTree string_literal54_tree=null;
			CommonTree char_literal56_tree=null;

			try 
			{
				// NewANTLRv3.g:121:2: ( 'throws' id ( ',' id )* )
				// NewANTLRv3.g:121:4: 'throws' id ( ',' id )*
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal54=(IToken)Match(input,49,FOLLOW_49_in_throwsSpec523); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal54_tree = (CommonTree)adaptor.Create(string_literal54);
						adaptor.AddChild(root_0, string_literal54_tree);
					}
					PushFollow(FOLLOW_id_in_throwsSpec525);
					id55 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id55.Tree);
					// NewANTLRv3.g:121:16: ( ',' id )*
					do 
					{
						int alt25 = 2;
						int LA25_0 = input.LA(1);

						if ( (LA25_0 == 50) )
						{
							alt25 = 1;
						}


						switch (alt25) 
						{
						case 1 :
							// NewANTLRv3.g:121:18: ',' id
						{
							char_literal56=(IToken)Match(input,50,FOLLOW_50_in_throwsSpec529); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal56_tree = (CommonTree)adaptor.Create(char_literal56);
								adaptor.AddChild(root_0, char_literal56_tree);
							}
							PushFollow(FOLLOW_id_in_throwsSpec531);
							id57 = id();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id57.Tree);

						}
							break;

						default:
							goto loop25;
						}
					} while (true);

					loop25:
					;	// Stops C# compiler whining that label 'loop25' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "throwsSpec"

		public class ruleScopeSpec_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ruleScopeSpec"
		// NewANTLRv3.g:124:1: ruleScopeSpec : ( 'scope' ACTION | 'scope' id ( ',' id )* ';' | 'scope' ACTION 'scope' id ( ',' id )* ';' );
		public NewANTLRv3Parser.ruleScopeSpec_return ruleScopeSpec() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.ruleScopeSpec_return retval = new NewANTLRv3Parser.ruleScopeSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal58 = null;
			IToken ACTION59 = null;
			IToken string_literal60 = null;
			IToken char_literal62 = null;
			IToken char_literal64 = null;
			IToken string_literal65 = null;
			IToken ACTION66 = null;
			IToken string_literal67 = null;
			IToken char_literal69 = null;
			IToken char_literal71 = null;
			NewANTLRv3Parser.id_return id61 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.id_return id63 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.id_return id68 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.id_return id70 = default(NewANTLRv3Parser.id_return);


			CommonTree string_literal58_tree=null;
			CommonTree ACTION59_tree=null;
			CommonTree string_literal60_tree=null;
			CommonTree char_literal62_tree=null;
			CommonTree char_literal64_tree=null;
			CommonTree string_literal65_tree=null;
			CommonTree ACTION66_tree=null;
			CommonTree string_literal67_tree=null;
			CommonTree char_literal69_tree=null;
			CommonTree char_literal71_tree=null;

			try 
			{
				// NewANTLRv3.g:125:2: ( 'scope' ACTION | 'scope' id ( ',' id )* ';' | 'scope' ACTION 'scope' id ( ',' id )* ';' )
				int alt28 = 3;
				int LA28_0 = input.LA(1);

				if ( (LA28_0 == 38) )
				{
					int LA28_1 = input.LA(2);

					if ( (LA28_1 == ACTION) )
					{
						int LA28_2 = input.LA(3);

						if ( (LA28_2 == 38) )
						{
							alt28 = 3;
						}
						else if ( (LA28_2 == 39 || LA28_2 == 48) )
						{
							alt28 = 1;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d28s2 =
								new NoViableAltException("", 28, 2, input);

							throw nvae_d28s2;
						}
					}
					else if ( (LA28_1 == TOKEN_REF || LA28_1 == RULE_REF) )
					{
						alt28 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d28s1 =
							new NoViableAltException("", 28, 1, input);

						throw nvae_d28s1;
					}
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d28s0 =
						new NoViableAltException("", 28, 0, input);

					throw nvae_d28s0;
				}
				switch (alt28) 
				{
				case 1 :
					// NewANTLRv3.g:125:4: 'scope' ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal58=(IToken)Match(input,38,FOLLOW_38_in_ruleScopeSpec545); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal58_tree = (CommonTree)adaptor.Create(string_literal58);
						adaptor.AddChild(root_0, string_literal58_tree);
					}
					ACTION59=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_ruleScopeSpec547); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION59_tree = (CommonTree)adaptor.Create(ACTION59);
						adaptor.AddChild(root_0, ACTION59_tree);
					}

				}
					break;
				case 2 :
					// NewANTLRv3.g:126:4: 'scope' id ( ',' id )* ';'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal60=(IToken)Match(input,38,FOLLOW_38_in_ruleScopeSpec552); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal60_tree = (CommonTree)adaptor.Create(string_literal60);
						adaptor.AddChild(root_0, string_literal60_tree);
					}
					PushFollow(FOLLOW_id_in_ruleScopeSpec554);
					id61 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id61.Tree);
					// NewANTLRv3.g:126:15: ( ',' id )*
					do 
					{
						int alt26 = 2;
						int LA26_0 = input.LA(1);

						if ( (LA26_0 == 50) )
						{
							alt26 = 1;
						}


						switch (alt26) 
						{
						case 1 :
							// NewANTLRv3.g:126:16: ',' id
						{
							char_literal62=(IToken)Match(input,50,FOLLOW_50_in_ruleScopeSpec557); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal62_tree = (CommonTree)adaptor.Create(char_literal62);
								adaptor.AddChild(root_0, char_literal62_tree);
							}
							PushFollow(FOLLOW_id_in_ruleScopeSpec559);
							id63 = id();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id63.Tree);

						}
							break;

						default:
							goto loop26;
						}
					} while (true);

					loop26:
					;	// Stops C# compiler whining that label 'loop26' has no statements

					char_literal64=(IToken)Match(input,35,FOLLOW_35_in_ruleScopeSpec563); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal64_tree = (CommonTree)adaptor.Create(char_literal64);
						adaptor.AddChild(root_0, char_literal64_tree);
					}

				}
					break;
				case 3 :
					// NewANTLRv3.g:127:4: 'scope' ACTION 'scope' id ( ',' id )* ';'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal65=(IToken)Match(input,38,FOLLOW_38_in_ruleScopeSpec568); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal65_tree = (CommonTree)adaptor.Create(string_literal65);
						adaptor.AddChild(root_0, string_literal65_tree);
					}
					ACTION66=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_ruleScopeSpec570); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION66_tree = (CommonTree)adaptor.Create(ACTION66);
						adaptor.AddChild(root_0, ACTION66_tree);
					}
					string_literal67=(IToken)Match(input,38,FOLLOW_38_in_ruleScopeSpec574); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal67_tree = (CommonTree)adaptor.Create(string_literal67);
						adaptor.AddChild(root_0, string_literal67_tree);
					}
					PushFollow(FOLLOW_id_in_ruleScopeSpec576);
					id68 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id68.Tree);
					// NewANTLRv3.g:128:14: ( ',' id )*
					do 
					{
						int alt27 = 2;
						int LA27_0 = input.LA(1);

						if ( (LA27_0 == 50) )
						{
							alt27 = 1;
						}


						switch (alt27) 
						{
						case 1 :
							// NewANTLRv3.g:128:15: ',' id
						{
							char_literal69=(IToken)Match(input,50,FOLLOW_50_in_ruleScopeSpec579); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal69_tree = (CommonTree)adaptor.Create(char_literal69);
								adaptor.AddChild(root_0, char_literal69_tree);
							}
							PushFollow(FOLLOW_id_in_ruleScopeSpec581);
							id70 = id();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id70.Tree);

						}
							break;

						default:
							goto loop27;
						}
					} while (true);

					loop27:
					;	// Stops C# compiler whining that label 'loop27' has no statements

					char_literal71=(IToken)Match(input,35,FOLLOW_35_in_ruleScopeSpec585); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal71_tree = (CommonTree)adaptor.Create(char_literal71);
						adaptor.AddChild(root_0, char_literal71_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "ruleScopeSpec"

		public class block_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "block"
		// NewANTLRv3.g:131:1: block : lp= '(' ( (opts= optionsSpec )? ':' )? a1= alternative rewrite ( '|' a2= alternative rewrite )* rp= ')' ;
		public NewANTLRv3Parser.block_return block() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.block_return retval = new NewANTLRv3Parser.block_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken rp = null;
			IToken char_literal72 = null;
			IToken char_literal74 = null;
			NewANTLRv3Parser.optionsSpec_return opts = default(NewANTLRv3Parser.optionsSpec_return);

			NewANTLRv3Parser.alternative_return a1 = default(NewANTLRv3Parser.alternative_return);

			NewANTLRv3Parser.alternative_return a2 = default(NewANTLRv3Parser.alternative_return);

			NewANTLRv3Parser.rewrite_return rewrite73 = default(NewANTLRv3Parser.rewrite_return);

			NewANTLRv3Parser.rewrite_return rewrite75 = default(NewANTLRv3Parser.rewrite_return);


			CommonTree lp_tree=null;
			CommonTree rp_tree=null;
			CommonTree char_literal72_tree=null;
			CommonTree char_literal74_tree=null;

			try 
			{
				// NewANTLRv3.g:132:5: (lp= '(' ( (opts= optionsSpec )? ':' )? a1= alternative rewrite ( '|' a2= alternative rewrite )* rp= ')' )
				// NewANTLRv3.g:132:9: lp= '(' ( (opts= optionsSpec )? ':' )? a1= alternative rewrite ( '|' a2= alternative rewrite )* rp= ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					lp=(IToken)Match(input,51,FOLLOW_51_in_block603); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp);
						adaptor.AddChild(root_0, lp_tree);
					}
					// NewANTLRv3.g:133:3: ( (opts= optionsSpec )? ':' )?
					int alt30 = 2;
					int LA30_0 = input.LA(1);

					if ( (LA30_0 == OPTIONS || LA30_0 == 48) )
					{
						alt30 = 1;
					}
					switch (alt30) 
					{
					case 1 :
						// NewANTLRv3.g:133:5: (opts= optionsSpec )? ':'
					{
						// NewANTLRv3.g:133:5: (opts= optionsSpec )?
						int alt29 = 2;
						int LA29_0 = input.LA(1);

						if ( (LA29_0 == OPTIONS) )
						{
							alt29 = 1;
						}
						switch (alt29) 
						{
						case 1 :
							// NewANTLRv3.g:133:6: opts= optionsSpec
						{
							PushFollow(FOLLOW_optionsSpec_in_block612);
							opts = optionsSpec();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, opts.Tree);

						}
							break;

						}

						char_literal72=(IToken)Match(input,48,FOLLOW_48_in_block616); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal72_tree = (CommonTree)adaptor.Create(char_literal72);
							adaptor.AddChild(root_0, char_literal72_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_alternative_in_block625);
					a1 = alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a1.Tree);
					PushFollow(FOLLOW_rewrite_in_block627);
					rewrite73 = rewrite();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite73.Tree);
					// NewANTLRv3.g:134:26: ( '|' a2= alternative rewrite )*
					do 
					{
						int alt31 = 2;
						int LA31_0 = input.LA(1);

						if ( (LA31_0 == 52) )
						{
							alt31 = 1;
						}


						switch (alt31) 
						{
						case 1 :
							// NewANTLRv3.g:134:28: '|' a2= alternative rewrite
						{
							char_literal74=(IToken)Match(input,52,FOLLOW_52_in_block631); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal74_tree = (CommonTree)adaptor.Create(char_literal74);
								adaptor.AddChild(root_0, char_literal74_tree);
							}
							PushFollow(FOLLOW_alternative_in_block635);
							a2 = alternative();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a2.Tree);
							PushFollow(FOLLOW_rewrite_in_block637);
							rewrite75 = rewrite();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite75.Tree);

						}
							break;

						default:
							goto loop31;
						}
					} while (true);

					loop31:
					;	// Stops C# compiler whining that label 'loop31' has no statements

					rp=(IToken)Match(input,53,FOLLOW_53_in_block652); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{rp_tree = (CommonTree)adaptor.Create(rp);
						adaptor.AddChild(root_0, rp_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "block"

		public class altList_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "altList"
		// NewANTLRv3.g:138:1: altList : a1= alternative rewrite ( '|' a2= alternative rewrite )* ;
		public NewANTLRv3Parser.altList_return altList() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.altList_return retval = new NewANTLRv3Parser.altList_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal77 = null;
			NewANTLRv3Parser.alternative_return a1 = default(NewANTLRv3Parser.alternative_return);

			NewANTLRv3Parser.alternative_return a2 = default(NewANTLRv3Parser.alternative_return);

			NewANTLRv3Parser.rewrite_return rewrite76 = default(NewANTLRv3Parser.rewrite_return);

			NewANTLRv3Parser.rewrite_return rewrite78 = default(NewANTLRv3Parser.rewrite_return);


			CommonTree char_literal77_tree=null;



			try 
			{
				// NewANTLRv3.g:145:5: (a1= alternative rewrite ( '|' a2= alternative rewrite )* )
				// NewANTLRv3.g:145:9: a1= alternative rewrite ( '|' a2= alternative rewrite )*
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_alternative_in_altList678);
					a1 = alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a1.Tree);
					PushFollow(FOLLOW_rewrite_in_altList680);
					rewrite76 = rewrite();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite76.Tree);
					// NewANTLRv3.g:145:32: ( '|' a2= alternative rewrite )*
					do 
					{
						int alt32 = 2;
						int LA32_0 = input.LA(1);

						if ( (LA32_0 == 52) )
						{
							alt32 = 1;
						}


						switch (alt32) 
						{
						case 1 :
							// NewANTLRv3.g:145:34: '|' a2= alternative rewrite
						{
							char_literal77=(IToken)Match(input,52,FOLLOW_52_in_altList684); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal77_tree = (CommonTree)adaptor.Create(char_literal77);
								adaptor.AddChild(root_0, char_literal77_tree);
							}
							PushFollow(FOLLOW_alternative_in_altList688);
							a2 = alternative();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a2.Tree);
							PushFollow(FOLLOW_rewrite_in_altList690);
							rewrite78 = rewrite();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite78.Tree);

						}
							break;

						default:
							goto loop32;
						}
					} while (true);

					loop32:
					;	// Stops C# compiler whining that label 'loop32' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "altList"

		public class alternative_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "alternative"
		// NewANTLRv3.g:148:1: alternative : ( ( element )+ | );
		public NewANTLRv3Parser.alternative_return alternative() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.alternative_return retval = new NewANTLRv3Parser.alternative_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			NewANTLRv3Parser.element_return element79 = default(NewANTLRv3Parser.element_return);




			IToken firstToken = input.LT(1);
			IToken prevToken = input.LT(-1); // either : or | I think

			try 
			{
				// NewANTLRv3.g:153:5: ( ( element )+ | )
				int alt34 = 2;
				int LA34_0 = input.LA(1);

				if ( ((LA34_0 >= TOKEN_REF && LA34_0 <= ACTION) || (LA34_0 >= SEMPRED && LA34_0 <= RULE_REF) || LA34_0 == 51 || (LA34_0 >= 59 && LA34_0 <= 60) || LA34_0 == 63) )
				{
					alt34 = 1;
				}
				else if ( (LA34_0 == 35 || (LA34_0 >= 52 && LA34_0 <= 53) || LA34_0 == 64) )
				{
					alt34 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d34s0 =
						new NoViableAltException("", 34, 0, input);

					throw nvae_d34s0;
				}
				switch (alt34) 
				{
				case 1 :
					// NewANTLRv3.g:153:9: ( element )+
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// NewANTLRv3.g:153:9: ( element )+
					int cnt33 = 0;
					do 
					{
						int alt33 = 2;
						int LA33_0 = input.LA(1);

						if ( ((LA33_0 >= TOKEN_REF && LA33_0 <= ACTION) || (LA33_0 >= SEMPRED && LA33_0 <= RULE_REF) || LA33_0 == 51 || (LA33_0 >= 59 && LA33_0 <= 60) || LA33_0 == 63) )
						{
							alt33 = 1;
						}


						switch (alt33) 
						{
						case 1 :
							// NewANTLRv3.g:153:9: element
						{
							PushFollow(FOLLOW_element_in_alternative717);
							element79 = element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, element79.Tree);

						}
							break;

						default:
							if ( cnt33 >= 1 ) goto loop33;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee33 =
								new EarlyExitException(33, input);
							throw eee33;
						}
						cnt33++;
					} while (true);

					loop33:
					;	// Stops C# compiler whining that label 'loop33' has no statements


				}
					break;
				case 2 :
					// NewANTLRv3.g:155:5: 
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "alternative"

		public class exceptionGroup_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "exceptionGroup"
		// NewANTLRv3.g:157:1: exceptionGroup : ( ( exceptionHandler )+ ( finallyClause )? | finallyClause );
		public NewANTLRv3Parser.exceptionGroup_return exceptionGroup() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.exceptionGroup_return retval = new NewANTLRv3Parser.exceptionGroup_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			NewANTLRv3Parser.exceptionHandler_return exceptionHandler80 = default(NewANTLRv3Parser.exceptionHandler_return);

			NewANTLRv3Parser.finallyClause_return finallyClause81 = default(NewANTLRv3Parser.finallyClause_return);

			NewANTLRv3Parser.finallyClause_return finallyClause82 = default(NewANTLRv3Parser.finallyClause_return);



			try 
			{
				// NewANTLRv3.g:158:2: ( ( exceptionHandler )+ ( finallyClause )? | finallyClause )
				int alt37 = 2;
				int LA37_0 = input.LA(1);

				if ( (LA37_0 == 54) )
				{
					alt37 = 1;
				}
				else if ( (LA37_0 == 55) )
				{
					alt37 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d37s0 =
						new NoViableAltException("", 37, 0, input);

					throw nvae_d37s0;
				}
				switch (alt37) 
				{
				case 1 :
					// NewANTLRv3.g:158:4: ( exceptionHandler )+ ( finallyClause )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// NewANTLRv3.g:158:4: ( exceptionHandler )+
					int cnt35 = 0;
					do 
					{
						int alt35 = 2;
						int LA35_0 = input.LA(1);

						if ( (LA35_0 == 54) )
						{
							alt35 = 1;
						}


						switch (alt35) 
						{
						case 1 :
							// NewANTLRv3.g:158:6: exceptionHandler
						{
							PushFollow(FOLLOW_exceptionHandler_in_exceptionGroup740);
							exceptionHandler80 = exceptionHandler();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exceptionHandler80.Tree);

						}
							break;

						default:
							if ( cnt35 >= 1 ) goto loop35;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee35 =
								new EarlyExitException(35, input);
							throw eee35;
						}
						cnt35++;
					} while (true);

					loop35:
					;	// Stops C# compiler whining that label 'loop35' has no statements

					// NewANTLRv3.g:158:26: ( finallyClause )?
					int alt36 = 2;
					int LA36_0 = input.LA(1);

					if ( (LA36_0 == 55) )
					{
						alt36 = 1;
					}
					switch (alt36) 
					{
					case 1 :
						// NewANTLRv3.g:158:28: finallyClause
					{
						PushFollow(FOLLOW_finallyClause_in_exceptionGroup747);
						finallyClause81 = finallyClause();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause81.Tree);

					}
						break;

					}


				}
					break;
				case 2 :
					// NewANTLRv3.g:159:4: finallyClause
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_finallyClause_in_exceptionGroup755);
					finallyClause82 = finallyClause();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause82.Tree);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "exceptionGroup"

		public class exceptionHandler_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "exceptionHandler"
		// NewANTLRv3.g:162:1: exceptionHandler : 'catch' ARG_ACTION ACTION ;
		public NewANTLRv3Parser.exceptionHandler_return exceptionHandler() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.exceptionHandler_return retval = new NewANTLRv3Parser.exceptionHandler_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal83 = null;
			IToken ARG_ACTION84 = null;
			IToken ACTION85 = null;

			CommonTree string_literal83_tree=null;
			CommonTree ARG_ACTION84_tree=null;
			CommonTree ACTION85_tree=null;

			try 
			{
				// NewANTLRv3.g:163:5: ( 'catch' ARG_ACTION ACTION )
				// NewANTLRv3.g:163:10: 'catch' ARG_ACTION ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal83=(IToken)Match(input,54,FOLLOW_54_in_exceptionHandler775); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal83_tree = (CommonTree)adaptor.Create(string_literal83);
						adaptor.AddChild(root_0, string_literal83_tree);
					}
					ARG_ACTION84=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_exceptionHandler777); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ARG_ACTION84_tree = (CommonTree)adaptor.Create(ARG_ACTION84);
						adaptor.AddChild(root_0, ARG_ACTION84_tree);
					}
					ACTION85=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_exceptionHandler779); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION85_tree = (CommonTree)adaptor.Create(ACTION85);
						adaptor.AddChild(root_0, ACTION85_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "exceptionHandler"

		public class finallyClause_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "finallyClause"
		// NewANTLRv3.g:166:1: finallyClause : 'finally' ACTION ;
		public NewANTLRv3Parser.finallyClause_return finallyClause() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.finallyClause_return retval = new NewANTLRv3Parser.finallyClause_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal86 = null;
			IToken ACTION87 = null;

			CommonTree string_literal86_tree=null;
			CommonTree ACTION87_tree=null;

			try 
			{
				// NewANTLRv3.g:167:5: ( 'finally' ACTION )
				// NewANTLRv3.g:167:10: 'finally' ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal86=(IToken)Match(input,55,FOLLOW_55_in_finallyClause799); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal86_tree = (CommonTree)adaptor.Create(string_literal86);
						adaptor.AddChild(root_0, string_literal86_tree);
					}
					ACTION87=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_finallyClause801); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION87_tree = (CommonTree)adaptor.Create(ACTION87);
						adaptor.AddChild(root_0, ACTION87_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "finallyClause"

		public class element_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "element"
		// NewANTLRv3.g:170:1: element : elementNoOptionSpec ;
		public NewANTLRv3Parser.element_return element() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.element_return retval = new NewANTLRv3Parser.element_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			NewANTLRv3Parser.elementNoOptionSpec_return elementNoOptionSpec88 = default(NewANTLRv3Parser.elementNoOptionSpec_return);



			try 
			{
				// NewANTLRv3.g:171:2: ( elementNoOptionSpec )
				// NewANTLRv3.g:171:4: elementNoOptionSpec
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_elementNoOptionSpec_in_element815);
					elementNoOptionSpec88 = elementNoOptionSpec();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementNoOptionSpec88.Tree);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "element"

		public class elementNoOptionSpec_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "elementNoOptionSpec"
		// NewANTLRv3.g:174:1: elementNoOptionSpec : ( id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | ) | id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | ) | atom ( ebnfSuffix | ) | ebnf | ACTION | SEMPRED ( '=>' | ) | treeSpec ( ebnfSuffix | ) );
		public NewANTLRv3Parser.elementNoOptionSpec_return elementNoOptionSpec() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.elementNoOptionSpec_return retval = new NewANTLRv3Parser.elementNoOptionSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken labelOp = null;
			IToken ACTION98 = null;
			IToken SEMPRED99 = null;
			IToken string_literal100 = null;
			NewANTLRv3Parser.id_return id89 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.atom_return atom90 = default(NewANTLRv3Parser.atom_return);

			NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix91 = default(NewANTLRv3Parser.ebnfSuffix_return);

			NewANTLRv3Parser.id_return id92 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.block_return block93 = default(NewANTLRv3Parser.block_return);

			NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix94 = default(NewANTLRv3Parser.ebnfSuffix_return);

			NewANTLRv3Parser.atom_return atom95 = default(NewANTLRv3Parser.atom_return);

			NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix96 = default(NewANTLRv3Parser.ebnfSuffix_return);

			NewANTLRv3Parser.ebnf_return ebnf97 = default(NewANTLRv3Parser.ebnf_return);

			NewANTLRv3Parser.treeSpec_return treeSpec101 = default(NewANTLRv3Parser.treeSpec_return);

			NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix102 = default(NewANTLRv3Parser.ebnfSuffix_return);


			CommonTree labelOp_tree=null;
			CommonTree ACTION98_tree=null;
			CommonTree SEMPRED99_tree=null;
			CommonTree string_literal100_tree=null;

			try 
			{
				// NewANTLRv3.g:175:2: ( id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | ) | id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | ) | atom ( ebnfSuffix | ) | ebnf | ACTION | SEMPRED ( '=>' | ) | treeSpec ( ebnfSuffix | ) )
				int alt45 = 7;
				alt45 = dfa45.Predict(input);
				switch (alt45) 
				{
				case 1 :
					// NewANTLRv3.g:175:4: id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_elementNoOptionSpec826);
					id89 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id89.Tree);
					// NewANTLRv3.g:175:7: (labelOp= '=' | labelOp= '+=' )
					int alt38 = 2;
					int LA38_0 = input.LA(1);

					if ( (LA38_0 == 37) )
					{
						alt38 = 1;
					}
					else if ( (LA38_0 == 56) )
					{
						alt38 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d38s0 =
							new NoViableAltException("", 38, 0, input);

						throw nvae_d38s0;
					}
					switch (alt38) 
					{
					case 1 :
						// NewANTLRv3.g:175:8: labelOp= '='
					{
						labelOp=(IToken)Match(input,37,FOLLOW_37_in_elementNoOptionSpec831); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;
					case 2 :
						// NewANTLRv3.g:175:20: labelOp= '+='
					{
						labelOp=(IToken)Match(input,56,FOLLOW_56_in_elementNoOptionSpec835); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_atom_in_elementNoOptionSpec838);
					atom90 = atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, atom90.Tree);
					// NewANTLRv3.g:176:3: ( ebnfSuffix | )
					int alt39 = 2;
					int LA39_0 = input.LA(1);

					if ( (LA39_0 == 41 || (LA39_0 >= 61 && LA39_0 <= 62)) )
					{
						alt39 = 1;
					}
					else if ( ((LA39_0 >= TOKEN_REF && LA39_0 <= ACTION) || (LA39_0 >= SEMPRED && LA39_0 <= RULE_REF) || LA39_0 == 35 || (LA39_0 >= 51 && LA39_0 <= 53) || (LA39_0 >= 59 && LA39_0 <= 60) || (LA39_0 >= 63 && LA39_0 <= 64)) )
					{
						alt39 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d39s0 =
							new NoViableAltException("", 39, 0, input);

						throw nvae_d39s0;
					}
					switch (alt39) 
					{
					case 1 :
						// NewANTLRv3.g:176:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec844);
						ebnfSuffix91 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix91.Tree);

					}
						break;
					case 2 :
						// NewANTLRv3.g:178:3: 
					{
					}
						break;

					}


				}
					break;
				case 2 :
					// NewANTLRv3.g:179:4: id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_elementNoOptionSpec857);
					id92 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id92.Tree);
					// NewANTLRv3.g:179:7: (labelOp= '=' | labelOp= '+=' )
					int alt40 = 2;
					int LA40_0 = input.LA(1);

					if ( (LA40_0 == 37) )
					{
						alt40 = 1;
					}
					else if ( (LA40_0 == 56) )
					{
						alt40 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d40s0 =
							new NoViableAltException("", 40, 0, input);

						throw nvae_d40s0;
					}
					switch (alt40) 
					{
					case 1 :
						// NewANTLRv3.g:179:8: labelOp= '='
					{
						labelOp=(IToken)Match(input,37,FOLLOW_37_in_elementNoOptionSpec862); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;
					case 2 :
						// NewANTLRv3.g:179:20: labelOp= '+='
					{
						labelOp=(IToken)Match(input,56,FOLLOW_56_in_elementNoOptionSpec866); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_block_in_elementNoOptionSpec869);
					block93 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block93.Tree);
					// NewANTLRv3.g:180:3: ( ebnfSuffix | )
					int alt41 = 2;
					int LA41_0 = input.LA(1);

					if ( (LA41_0 == 41 || (LA41_0 >= 61 && LA41_0 <= 62)) )
					{
						alt41 = 1;
					}
					else if ( ((LA41_0 >= TOKEN_REF && LA41_0 <= ACTION) || (LA41_0 >= SEMPRED && LA41_0 <= RULE_REF) || LA41_0 == 35 || (LA41_0 >= 51 && LA41_0 <= 53) || (LA41_0 >= 59 && LA41_0 <= 60) || (LA41_0 >= 63 && LA41_0 <= 64)) )
					{
						alt41 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d41s0 =
							new NoViableAltException("", 41, 0, input);

						throw nvae_d41s0;
					}
					switch (alt41) 
					{
					case 1 :
						// NewANTLRv3.g:180:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec875);
						ebnfSuffix94 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix94.Tree);

					}
						break;
					case 2 :
						// NewANTLRv3.g:182:3: 
					{
					}
						break;

					}


				}
					break;
				case 3 :
					// NewANTLRv3.g:183:4: atom ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_atom_in_elementNoOptionSpec888);
					atom95 = atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, atom95.Tree);
					// NewANTLRv3.g:184:3: ( ebnfSuffix | )
					int alt42 = 2;
					int LA42_0 = input.LA(1);

					if ( (LA42_0 == 41 || (LA42_0 >= 61 && LA42_0 <= 62)) )
					{
						alt42 = 1;
					}
					else if ( ((LA42_0 >= TOKEN_REF && LA42_0 <= ACTION) || (LA42_0 >= SEMPRED && LA42_0 <= RULE_REF) || LA42_0 == 35 || (LA42_0 >= 51 && LA42_0 <= 53) || (LA42_0 >= 59 && LA42_0 <= 60) || (LA42_0 >= 63 && LA42_0 <= 64)) )
					{
						alt42 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d42s0 =
							new NoViableAltException("", 42, 0, input);

						throw nvae_d42s0;
					}
					switch (alt42) 
					{
					case 1 :
						// NewANTLRv3.g:184:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec894);
						ebnfSuffix96 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix96.Tree);

					}
						break;
					case 2 :
						// NewANTLRv3.g:186:3: 
					{
					}
						break;

					}


				}
					break;
				case 4 :
					// NewANTLRv3.g:187:4: ebnf
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_ebnf_in_elementNoOptionSpec907);
					ebnf97 = ebnf();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnf97.Tree);

				}
					break;
				case 5 :
					// NewANTLRv3.g:188:6: ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					ACTION98=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_elementNoOptionSpec914); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION98_tree = (CommonTree)adaptor.Create(ACTION98);
						adaptor.AddChild(root_0, ACTION98_tree);
					}

				}
					break;
				case 6 :
					// NewANTLRv3.g:189:6: SEMPRED ( '=>' | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					SEMPRED99=(IToken)Match(input,SEMPRED,FOLLOW_SEMPRED_in_elementNoOptionSpec921); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{SEMPRED99_tree = (CommonTree)adaptor.Create(SEMPRED99);
						adaptor.AddChild(root_0, SEMPRED99_tree);
					}
					// NewANTLRv3.g:189:14: ( '=>' | )
					int alt43 = 2;
					int LA43_0 = input.LA(1);

					if ( (LA43_0 == 57) )
					{
						alt43 = 1;
					}
					else if ( ((LA43_0 >= TOKEN_REF && LA43_0 <= ACTION) || (LA43_0 >= SEMPRED && LA43_0 <= RULE_REF) || LA43_0 == 35 || (LA43_0 >= 51 && LA43_0 <= 53) || (LA43_0 >= 59 && LA43_0 <= 60) || (LA43_0 >= 63 && LA43_0 <= 64)) )
					{
						alt43 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d43s0 =
							new NoViableAltException("", 43, 0, input);

						throw nvae_d43s0;
					}
					switch (alt43) 
					{
					case 1 :
						// NewANTLRv3.g:189:16: '=>'
					{
						string_literal100=(IToken)Match(input,57,FOLLOW_57_in_elementNoOptionSpec925); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal100_tree = (CommonTree)adaptor.Create(string_literal100);
							adaptor.AddChild(root_0, string_literal100_tree);
						}

					}
						break;
					case 2 :
						// NewANTLRv3.g:189:23: 
					{
					}
						break;

					}


				}
					break;
				case 7 :
					// NewANTLRv3.g:190:6: treeSpec ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_treeSpec_in_elementNoOptionSpec936);
					treeSpec101 = treeSpec();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, treeSpec101.Tree);
					// NewANTLRv3.g:191:3: ( ebnfSuffix | )
					int alt44 = 2;
					int LA44_0 = input.LA(1);

					if ( (LA44_0 == 41 || (LA44_0 >= 61 && LA44_0 <= 62)) )
					{
						alt44 = 1;
					}
					else if ( ((LA44_0 >= TOKEN_REF && LA44_0 <= ACTION) || (LA44_0 >= SEMPRED && LA44_0 <= RULE_REF) || LA44_0 == 35 || (LA44_0 >= 51 && LA44_0 <= 53) || (LA44_0 >= 59 && LA44_0 <= 60) || (LA44_0 >= 63 && LA44_0 <= 64)) )
					{
						alt44 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d44s0 =
							new NoViableAltException("", 44, 0, input);

						throw nvae_d44s0;
					}
					switch (alt44) 
					{
					case 1 :
						// NewANTLRv3.g:191:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec942);
						ebnfSuffix102 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix102.Tree);

					}
						break;
					case 2 :
						// NewANTLRv3.g:193:3: 
					{
					}
						break;

					}


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "elementNoOptionSpec"

		public class atom_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "atom"
		// NewANTLRv3.g:196:1: atom : ( range ( (op= '^' | op= '!' ) | ) | terminal | notSet ( (op= '^' | op= '!' ) | ) | RULE_REF (arg= ARG_ACTION )? ( (op= '^' | op= '!' ) )? );
		public NewANTLRv3Parser.atom_return atom() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.atom_return retval = new NewANTLRv3Parser.atom_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken op = null;
			IToken arg = null;
			IToken RULE_REF106 = null;
			NewANTLRv3Parser.range_return range103 = default(NewANTLRv3Parser.range_return);

			NewANTLRv3Parser.terminal_return terminal104 = default(NewANTLRv3Parser.terminal_return);

			NewANTLRv3Parser.notSet_return notSet105 = default(NewANTLRv3Parser.notSet_return);


			CommonTree op_tree=null;
			CommonTree arg_tree=null;
			CommonTree RULE_REF106_tree=null;

			try 
			{
				// NewANTLRv3.g:196:5: ( range ( (op= '^' | op= '!' ) | ) | terminal | notSet ( (op= '^' | op= '!' ) | ) | RULE_REF (arg= ARG_ACTION )? ( (op= '^' | op= '!' ) )? )
				int alt53 = 4;
				switch ( input.LA(1) ) 
				{
				case CHAR_LITERAL:
				{
					int LA53_1 = input.LA(2);

					if ( (LA53_1 == RANGE) )
					{
						alt53 = 1;
					}
					else if ( ((LA53_1 >= TOKEN_REF && LA53_1 <= ACTION) || (LA53_1 >= SEMPRED && LA53_1 <= RULE_REF) || LA53_1 == 35 || LA53_1 == 41 || LA53_1 == 46 || (LA53_1 >= 51 && LA53_1 <= 53) || (LA53_1 >= 58 && LA53_1 <= 64)) )
					{
						alt53 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d53s1 =
							new NoViableAltException("", 53, 1, input);

						throw nvae_d53s1;
					}
				}
					break;
				case TOKEN_REF:
				case STRING_LITERAL:
				case 63:
				{
					alt53 = 2;
				}
					break;
				case 59:
				{
					alt53 = 3;
				}
					break;
				case RULE_REF:
				{
					alt53 = 4;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d53s0 =
						new NoViableAltException("", 53, 0, input);

					throw nvae_d53s0;
				}

				switch (alt53) 
				{
				case 1 :
					// NewANTLRv3.g:196:9: range ( (op= '^' | op= '!' ) | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_range_in_atom961);
					range103 = range();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, range103.Tree);
					// NewANTLRv3.g:196:15: ( (op= '^' | op= '!' ) | )
					int alt47 = 2;
					int LA47_0 = input.LA(1);

					if ( (LA47_0 == 46 || LA47_0 == 58) )
					{
						alt47 = 1;
					}
					else if ( ((LA47_0 >= TOKEN_REF && LA47_0 <= ACTION) || (LA47_0 >= SEMPRED && LA47_0 <= RULE_REF) || LA47_0 == 35 || LA47_0 == 41 || (LA47_0 >= 51 && LA47_0 <= 53) || (LA47_0 >= 59 && LA47_0 <= 64)) )
					{
						alt47 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d47s0 =
							new NoViableAltException("", 47, 0, input);

						throw nvae_d47s0;
					}
					switch (alt47) 
					{
					case 1 :
						// NewANTLRv3.g:196:17: (op= '^' | op= '!' )
					{
						// NewANTLRv3.g:196:17: (op= '^' | op= '!' )
						int alt46 = 2;
						int LA46_0 = input.LA(1);

						if ( (LA46_0 == 58) )
						{
							alt46 = 1;
						}
						else if ( (LA46_0 == 46) )
						{
							alt46 = 2;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d46s0 =
								new NoViableAltException("", 46, 0, input);

							throw nvae_d46s0;
						}
						switch (alt46) 
						{
						case 1 :
							// NewANTLRv3.g:196:18: op= '^'
						{
							op=(IToken)Match(input,58,FOLLOW_58_in_atom968); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;
						case 2 :
							// NewANTLRv3.g:196:25: op= '!'
						{
							op=(IToken)Match(input,46,FOLLOW_46_in_atom972); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;

						}


					}
						break;
					case 2 :
						// NewANTLRv3.g:196:35: 
					{
					}
						break;

					}


				}
					break;
				case 2 :
					// NewANTLRv3.g:197:9: terminal
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_terminal_in_atom987);
					terminal104 = terminal();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, terminal104.Tree);

				}
					break;
				case 3 :
					// NewANTLRv3.g:198:7: notSet ( (op= '^' | op= '!' ) | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_notSet_in_atom995);
					notSet105 = notSet();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, notSet105.Tree);
					// NewANTLRv3.g:198:14: ( (op= '^' | op= '!' ) | )
					int alt49 = 2;
					int LA49_0 = input.LA(1);

					if ( (LA49_0 == 46 || LA49_0 == 58) )
					{
						alt49 = 1;
					}
					else if ( ((LA49_0 >= TOKEN_REF && LA49_0 <= ACTION) || (LA49_0 >= SEMPRED && LA49_0 <= RULE_REF) || LA49_0 == 35 || LA49_0 == 41 || (LA49_0 >= 51 && LA49_0 <= 53) || (LA49_0 >= 59 && LA49_0 <= 64)) )
					{
						alt49 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d49s0 =
							new NoViableAltException("", 49, 0, input);

						throw nvae_d49s0;
					}
					switch (alt49) 
					{
					case 1 :
						// NewANTLRv3.g:198:16: (op= '^' | op= '!' )
					{
						// NewANTLRv3.g:198:16: (op= '^' | op= '!' )
						int alt48 = 2;
						int LA48_0 = input.LA(1);

						if ( (LA48_0 == 58) )
						{
							alt48 = 1;
						}
						else if ( (LA48_0 == 46) )
						{
							alt48 = 2;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d48s0 =
								new NoViableAltException("", 48, 0, input);

							throw nvae_d48s0;
						}
						switch (alt48) 
						{
						case 1 :
							// NewANTLRv3.g:198:17: op= '^'
						{
							op=(IToken)Match(input,58,FOLLOW_58_in_atom1002); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;
						case 2 :
							// NewANTLRv3.g:198:24: op= '!'
						{
							op=(IToken)Match(input,46,FOLLOW_46_in_atom1006); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;

						}


					}
						break;
					case 2 :
						// NewANTLRv3.g:198:34: 
					{
					}
						break;

					}


				}
					break;
				case 4 :
					// NewANTLRv3.g:199:9: RULE_REF (arg= ARG_ACTION )? ( (op= '^' | op= '!' ) )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					RULE_REF106=(IToken)Match(input,RULE_REF,FOLLOW_RULE_REF_in_atom1021); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{RULE_REF106_tree = (CommonTree)adaptor.Create(RULE_REF106);
						adaptor.AddChild(root_0, RULE_REF106_tree);
					}
					// NewANTLRv3.g:199:18: (arg= ARG_ACTION )?
					int alt50 = 2;
					int LA50_0 = input.LA(1);

					if ( (LA50_0 == ARG_ACTION) )
					{
						alt50 = 1;
					}
					switch (alt50) 
					{
					case 1 :
						// NewANTLRv3.g:199:20: arg= ARG_ACTION
					{
						arg=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_atom1027); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{arg_tree = (CommonTree)adaptor.Create(arg);
							adaptor.AddChild(root_0, arg_tree);
						}

					}
						break;

					}

					// NewANTLRv3.g:199:38: ( (op= '^' | op= '!' ) )?
					int alt52 = 2;
					int LA52_0 = input.LA(1);

					if ( (LA52_0 == 46 || LA52_0 == 58) )
					{
						alt52 = 1;
					}
					switch (alt52) 
					{
					case 1 :
						// NewANTLRv3.g:199:40: (op= '^' | op= '!' )
					{
						// NewANTLRv3.g:199:40: (op= '^' | op= '!' )
						int alt51 = 2;
						int LA51_0 = input.LA(1);

						if ( (LA51_0 == 58) )
						{
							alt51 = 1;
						}
						else if ( (LA51_0 == 46) )
						{
							alt51 = 2;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d51s0 =
								new NoViableAltException("", 51, 0, input);

							throw nvae_d51s0;
						}
						switch (alt51) 
						{
						case 1 :
							// NewANTLRv3.g:199:41: op= '^'
						{
							op=(IToken)Match(input,58,FOLLOW_58_in_atom1037); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;
						case 2 :
							// NewANTLRv3.g:199:48: op= '!'
						{
							op=(IToken)Match(input,46,FOLLOW_46_in_atom1041); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;

						}


					}
						break;

					}


				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "atom"

		public class notSet_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "notSet"
		// NewANTLRv3.g:202:1: notSet : '~' ( notTerminal | block ) ;
		public NewANTLRv3Parser.notSet_return notSet() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.notSet_return retval = new NewANTLRv3Parser.notSet_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal107 = null;
			NewANTLRv3Parser.notTerminal_return notTerminal108 = default(NewANTLRv3Parser.notTerminal_return);

			NewANTLRv3Parser.block_return block109 = default(NewANTLRv3Parser.block_return);


			CommonTree char_literal107_tree=null;

			try 
			{
				// NewANTLRv3.g:203:2: ( '~' ( notTerminal | block ) )
				// NewANTLRv3.g:203:4: '~' ( notTerminal | block )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					char_literal107=(IToken)Match(input,59,FOLLOW_59_in_notSet1059); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal107_tree = (CommonTree)adaptor.Create(char_literal107);
						adaptor.AddChild(root_0, char_literal107_tree);
					}
					// NewANTLRv3.g:204:3: ( notTerminal | block )
					int alt54 = 2;
					int LA54_0 = input.LA(1);

					if ( ((LA54_0 >= TOKEN_REF && LA54_0 <= CHAR_LITERAL)) )
					{
						alt54 = 1;
					}
					else if ( (LA54_0 == 51) )
					{
						alt54 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d54s0 =
							new NoViableAltException("", 54, 0, input);

						throw nvae_d54s0;
					}
					switch (alt54) 
					{
					case 1 :
						// NewANTLRv3.g:204:5: notTerminal
					{
						PushFollow(FOLLOW_notTerminal_in_notSet1065);
						notTerminal108 = notTerminal();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, notTerminal108.Tree);

					}
						break;
					case 2 :
						// NewANTLRv3.g:205:5: block
					{
						PushFollow(FOLLOW_block_in_notSet1071);
						block109 = block();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block109.Tree);

					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "notSet"

		public class treeSpec_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "treeSpec"
		// NewANTLRv3.g:209:1: treeSpec : '^(' element ( element )+ ')' ;
		public NewANTLRv3Parser.treeSpec_return treeSpec() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.treeSpec_return retval = new NewANTLRv3Parser.treeSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal110 = null;
			IToken char_literal113 = null;
			NewANTLRv3Parser.element_return element111 = default(NewANTLRv3Parser.element_return);

			NewANTLRv3Parser.element_return element112 = default(NewANTLRv3Parser.element_return);


			CommonTree string_literal110_tree=null;
			CommonTree char_literal113_tree=null;

			try 
			{
				// NewANTLRv3.g:210:2: ( '^(' element ( element )+ ')' )
				// NewANTLRv3.g:210:4: '^(' element ( element )+ ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal110=(IToken)Match(input,60,FOLLOW_60_in_treeSpec1086); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal110_tree = (CommonTree)adaptor.Create(string_literal110);
						adaptor.AddChild(root_0, string_literal110_tree);
					}
					PushFollow(FOLLOW_element_in_treeSpec1088);
					element111 = element();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, element111.Tree);
					// NewANTLRv3.g:210:17: ( element )+
					int cnt55 = 0;
					do 
					{
						int alt55 = 2;
						int LA55_0 = input.LA(1);

						if ( ((LA55_0 >= TOKEN_REF && LA55_0 <= ACTION) || (LA55_0 >= SEMPRED && LA55_0 <= RULE_REF) || LA55_0 == 51 || (LA55_0 >= 59 && LA55_0 <= 60) || LA55_0 == 63) )
						{
							alt55 = 1;
						}


						switch (alt55) 
						{
						case 1 :
							// NewANTLRv3.g:210:19: element
						{
							PushFollow(FOLLOW_element_in_treeSpec1092);
							element112 = element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, element112.Tree);

						}
							break;

						default:
							if ( cnt55 >= 1 ) goto loop55;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee55 =
								new EarlyExitException(55, input);
							throw eee55;
						}
						cnt55++;
					} while (true);

					loop55:
					;	// Stops C# compiler whining that label 'loop55' has no statements

					char_literal113=(IToken)Match(input,53,FOLLOW_53_in_treeSpec1097); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal113_tree = (CommonTree)adaptor.Create(char_literal113);
						adaptor.AddChild(root_0, char_literal113_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "treeSpec"

		public class ebnf_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ebnf"
		// NewANTLRv3.g:213:1: ebnf : block (op= '?' | op= '*' | op= '+' | '=>' | ) ;
		public NewANTLRv3Parser.ebnf_return ebnf() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.ebnf_return retval = new NewANTLRv3Parser.ebnf_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken op = null;
			IToken string_literal115 = null;
			NewANTLRv3Parser.block_return block114 = default(NewANTLRv3Parser.block_return);


			CommonTree op_tree=null;
			CommonTree string_literal115_tree=null;


			IToken firstToken = input.LT(1);

			try 
			{
				// NewANTLRv3.g:222:2: ( block (op= '?' | op= '*' | op= '+' | '=>' | ) )
				// NewANTLRv3.g:222:4: block (op= '?' | op= '*' | op= '+' | '=>' | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_block_in_ebnf1120);
					block114 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block114.Tree);
					// NewANTLRv3.g:223:3: (op= '?' | op= '*' | op= '+' | '=>' | )
					int alt56 = 5;
					switch ( input.LA(1) ) 
					{
					case 61:
					{
						alt56 = 1;
					}
						break;
					case 41:
					{
						alt56 = 2;
					}
						break;
					case 62:
					{
						alt56 = 3;
					}
						break;
					case 57:
					{
						alt56 = 4;
					}
						break;
					case TOKEN_REF:
					case STRING_LITERAL:
					case CHAR_LITERAL:
					case ACTION:
					case SEMPRED:
					case RULE_REF:
					case 35:
					case 51:
					case 52:
					case 53:
					case 59:
					case 60:
					case 63:
					case 64:
					{
						alt56 = 5;
					}
						break;
					default:
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d56s0 =
							new NoViableAltException("", 56, 0, input);

						throw nvae_d56s0;
					}

					switch (alt56) 
					{
					case 1 :
						// NewANTLRv3.g:223:5: op= '?'
					{
						op=(IToken)Match(input,61,FOLLOW_61_in_ebnf1128); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{op_tree = (CommonTree)adaptor.Create(op);
							adaptor.AddChild(root_0, op_tree);
						}

					}
						break;
					case 2 :
						// NewANTLRv3.g:224:5: op= '*'
					{
						op=(IToken)Match(input,41,FOLLOW_41_in_ebnf1136); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{op_tree = (CommonTree)adaptor.Create(op);
							adaptor.AddChild(root_0, op_tree);
						}

					}
						break;
					case 3 :
						// NewANTLRv3.g:225:5: op= '+'
					{
						op=(IToken)Match(input,62,FOLLOW_62_in_ebnf1144); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{op_tree = (CommonTree)adaptor.Create(op);
							adaptor.AddChild(root_0, op_tree);
						}

					}
						break;
					case 4 :
						// NewANTLRv3.g:226:7: '=>'
					{
						string_literal115=(IToken)Match(input,57,FOLLOW_57_in_ebnf1152); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal115_tree = (CommonTree)adaptor.Create(string_literal115);
							adaptor.AddChild(root_0, string_literal115_tree);
						}

					}
						break;
					case 5 :
						// NewANTLRv3.g:228:3: 
					{
					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{

					((CommonTree)retval.Tree).Token.Line = firstToken.Line;
					((CommonTree)retval.Tree).Token.CharPositionInLine = firstToken.CharPositionInLine;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "ebnf"

		public class range_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "range"
		// NewANTLRv3.g:231:1: range : c1= CHAR_LITERAL RANGE c2= CHAR_LITERAL ;
		public NewANTLRv3Parser.range_return range() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.range_return retval = new NewANTLRv3Parser.range_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken c1 = null;
			IToken c2 = null;
			IToken RANGE116 = null;

			CommonTree c1_tree=null;
			CommonTree c2_tree=null;
			CommonTree RANGE116_tree=null;

			try 
			{
				// NewANTLRv3.g:232:2: (c1= CHAR_LITERAL RANGE c2= CHAR_LITERAL )
				// NewANTLRv3.g:232:4: c1= CHAR_LITERAL RANGE c2= CHAR_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					c1=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_range1181); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{c1_tree = (CommonTree)adaptor.Create(c1);
						adaptor.AddChild(root_0, c1_tree);
					}
					RANGE116=(IToken)Match(input,RANGE,FOLLOW_RANGE_in_range1183); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{RANGE116_tree = (CommonTree)adaptor.Create(RANGE116);
						adaptor.AddChild(root_0, RANGE116_tree);
					}
					c2=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_range1187); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{c2_tree = (CommonTree)adaptor.Create(c2);
						adaptor.AddChild(root_0, c2_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "range"

		public class terminal_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "terminal"
		// NewANTLRv3.g:235:1: terminal : ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' ) ( '^' | '!' )? ;
		public NewANTLRv3Parser.terminal_return terminal() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.terminal_return retval = new NewANTLRv3Parser.terminal_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken CHAR_LITERAL117 = null;
			IToken TOKEN_REF118 = null;
			IToken ARG_ACTION119 = null;
			IToken STRING_LITERAL120 = null;
			IToken char_literal121 = null;
			IToken set122 = null;

			CommonTree CHAR_LITERAL117_tree=null;
			CommonTree TOKEN_REF118_tree=null;
			CommonTree ARG_ACTION119_tree=null;
			CommonTree STRING_LITERAL120_tree=null;
			CommonTree char_literal121_tree=null;
			CommonTree set122_tree=null;

			try 
			{
				// NewANTLRv3.g:236:5: ( ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' ) ( '^' | '!' )? )
				// NewANTLRv3.g:236:9: ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' ) ( '^' | '!' )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// NewANTLRv3.g:236:9: ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' )
					int alt58 = 4;
					switch ( input.LA(1) ) 
					{
					case CHAR_LITERAL:
					{
						alt58 = 1;
					}
						break;
					case TOKEN_REF:
					{
						alt58 = 2;
					}
						break;
					case STRING_LITERAL:
					{
						alt58 = 3;
					}
						break;
					case 63:
					{
						alt58 = 4;
					}
						break;
					default:
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d58s0 =
							new NoViableAltException("", 58, 0, input);

						throw nvae_d58s0;
					}

					switch (alt58) 
					{
					case 1 :
						// NewANTLRv3.g:236:11: CHAR_LITERAL
					{
						CHAR_LITERAL117=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_terminal1205); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{CHAR_LITERAL117_tree = (CommonTree)adaptor.Create(CHAR_LITERAL117);
							adaptor.AddChild(root_0, CHAR_LITERAL117_tree);
						}

					}
						break;
					case 2 :
						// NewANTLRv3.g:238:7: TOKEN_REF ( ARG_ACTION | )
					{
						TOKEN_REF118=(IToken)Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_terminal1220); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{TOKEN_REF118_tree = (CommonTree)adaptor.Create(TOKEN_REF118);
							adaptor.AddChild(root_0, TOKEN_REF118_tree);
						}
						// NewANTLRv3.g:239:4: ( ARG_ACTION | )
						int alt57 = 2;
						int LA57_0 = input.LA(1);

						if ( (LA57_0 == ARG_ACTION) )
						{
							alt57 = 1;
						}
						else if ( ((LA57_0 >= TOKEN_REF && LA57_0 <= ACTION) || (LA57_0 >= SEMPRED && LA57_0 <= RULE_REF) || LA57_0 == 35 || LA57_0 == 41 || LA57_0 == 46 || (LA57_0 >= 51 && LA57_0 <= 53) || (LA57_0 >= 58 && LA57_0 <= 64)) )
						{
							alt57 = 2;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							NoViableAltException nvae_d57s0 =
								new NoViableAltException("", 57, 0, input);

							throw nvae_d57s0;
						}
						switch (alt57) 
						{
						case 1 :
							// NewANTLRv3.g:239:6: ARG_ACTION
						{
							ARG_ACTION119=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_terminal1227); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{ARG_ACTION119_tree = (CommonTree)adaptor.Create(ARG_ACTION119);
								adaptor.AddChild(root_0, ARG_ACTION119_tree);
							}

						}
							break;
						case 2 :
							// NewANTLRv3.g:241:4: 
						{
						}
							break;

						}


					}
						break;
					case 3 :
						// NewANTLRv3.g:242:7: STRING_LITERAL
					{
						STRING_LITERAL120=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_terminal1245); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{STRING_LITERAL120_tree = (CommonTree)adaptor.Create(STRING_LITERAL120);
							adaptor.AddChild(root_0, STRING_LITERAL120_tree);
						}

					}
						break;
					case 4 :
						// NewANTLRv3.g:243:7: '.'
					{
						char_literal121=(IToken)Match(input,63,FOLLOW_63_in_terminal1253); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal121_tree = (CommonTree)adaptor.Create(char_literal121);
							adaptor.AddChild(root_0, char_literal121_tree);
						}

					}
						break;

					}

					// NewANTLRv3.g:245:3: ( '^' | '!' )?
					int alt59 = 2;
					int LA59_0 = input.LA(1);

					if ( (LA59_0 == 46 || LA59_0 == 58) )
					{
						alt59 = 1;
					}
					switch (alt59) 
					{
					case 1 :
						// NewANTLRv3.g:
					{
						set122 = (IToken)input.LT(1);
						if ( input.LA(1) == 46 || input.LA(1) == 58 ) 
						{
							input.Consume();
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set122));
							state.errorRecovery = false;state.failed = false;
						}
						else 
						{
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							MismatchedSetException mse = new MismatchedSetException(null,input);
							throw mse;
						}


					}
						break;

					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "terminal"

		public class notTerminal_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "notTerminal"
		// NewANTLRv3.g:250:1: notTerminal : ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL );
		public NewANTLRv3Parser.notTerminal_return notTerminal() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.notTerminal_return retval = new NewANTLRv3Parser.notTerminal_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken set123 = null;

			CommonTree set123_tree=null;

			try 
			{
				// NewANTLRv3.g:251:2: ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL )
				// NewANTLRv3.g:
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					set123 = (IToken)input.LT(1);
					if ( (input.LA(1) >= TOKEN_REF && input.LA(1) <= CHAR_LITERAL) ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set123));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "notTerminal"

		public class ebnfSuffix_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ebnfSuffix"
		// NewANTLRv3.g:256:1: ebnfSuffix : ( '?' | '*' | '+' );
		public NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.ebnfSuffix_return retval = new NewANTLRv3Parser.ebnfSuffix_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken set124 = null;

			CommonTree set124_tree=null;


			IToken op = input.LT(1);

			try 
			{
				// NewANTLRv3.g:260:2: ( '?' | '*' | '+' )
				// NewANTLRv3.g:
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					set124 = (IToken)input.LT(1);
					if ( input.LA(1) == 41 || (input.LA(1) >= 61 && input.LA(1) <= 62) ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set124));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "ebnfSuffix"

		public class rewrite_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite"
		// NewANTLRv3.g:269:1: rewrite : ( (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )* rew2= '->' last= rewrite_alternative | );
		public NewANTLRv3Parser.rewrite_return rewrite() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_return retval = new NewANTLRv3Parser.rewrite_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken rew2 = null;
			IToken rew = null;
			IToken preds = null;
			IList list_rew = null;
			IList list_preds = null;
			IList list_predicated = null;
			NewANTLRv3Parser.rewrite_alternative_return last = default(NewANTLRv3Parser.rewrite_alternative_return);

			NewANTLRv3Parser.rewrite_alternative_return predicated = default(NewANTLRv3Parser.rewrite_alternative_return);
			predicated = null;
			CommonTree rew2_tree=null;
			CommonTree rew_tree=null;
			CommonTree preds_tree=null;


			IToken firstToken = input.LT(1);

			try 
			{
				// NewANTLRv3.g:273:2: ( (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )* rew2= '->' last= rewrite_alternative | )
				int alt61 = 2;
				int LA61_0 = input.LA(1);

				if ( (LA61_0 == 64) )
				{
					alt61 = 1;
				}
				else if ( (LA61_0 == 35 || (LA61_0 >= 52 && LA61_0 <= 53)) )
				{
					alt61 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d61s0 =
						new NoViableAltException("", 61, 0, input);

					throw nvae_d61s0;
				}
				switch (alt61) 
				{
				case 1 :
					// NewANTLRv3.g:273:4: (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )* rew2= '->' last= rewrite_alternative
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// NewANTLRv3.g:273:4: (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )*
					do 
					{
						int alt60 = 2;
						int LA60_0 = input.LA(1);

						if ( (LA60_0 == 64) )
						{
							int LA60_1 = input.LA(2);

							if ( (LA60_1 == SEMPRED) )
							{
								alt60 = 1;
							}


						}


						switch (alt60) 
						{
						case 1 :
							// NewANTLRv3.g:273:5: rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative
						{
							rew=(IToken)Match(input,64,FOLLOW_64_in_rewrite1354); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{rew_tree = (CommonTree)adaptor.Create(rew);
								adaptor.AddChild(root_0, rew_tree);
							}
							if (list_rew == null) list_rew = new ArrayList();
							list_rew.Add(rew);

							preds=(IToken)Match(input,SEMPRED,FOLLOW_SEMPRED_in_rewrite1358); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{preds_tree = (CommonTree)adaptor.Create(preds);
								adaptor.AddChild(root_0, preds_tree);
							}
							if (list_preds == null) list_preds = new ArrayList();
							list_preds.Add(preds);

							PushFollow(FOLLOW_rewrite_alternative_in_rewrite1362);
							predicated = rewrite_alternative();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, predicated.Tree);
							if (list_predicated == null) list_predicated = new ArrayList();
							list_predicated.Add(predicated.Tree);


						}
							break;

						default:
							goto loop60;
						}
					} while (true);

					loop60:
					;	// Stops C# compiler whining that label 'loop60' has no statements

					rew2=(IToken)Match(input,64,FOLLOW_64_in_rewrite1370); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{rew2_tree = (CommonTree)adaptor.Create(rew2);
						adaptor.AddChild(root_0, rew2_tree);
					}
					PushFollow(FOLLOW_rewrite_alternative_in_rewrite1374);
					last = rewrite_alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, last.Tree);

				}
					break;
				case 2 :
					// NewANTLRv3.g:276:2: 
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite"

		public class rewrite_alternative_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_alternative"
		// NewANTLRv3.g:278:1: rewrite_alternative options {backtrack=true; } : ( rewrite_template | rewrite_tree_alternative | );
		public NewANTLRv3Parser.rewrite_alternative_return rewrite_alternative() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_alternative_return retval = new NewANTLRv3Parser.rewrite_alternative_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			NewANTLRv3Parser.rewrite_template_return rewrite_template125 = default(NewANTLRv3Parser.rewrite_template_return);

			NewANTLRv3Parser.rewrite_tree_alternative_return rewrite_tree_alternative126 = default(NewANTLRv3Parser.rewrite_tree_alternative_return);



			try 
			{
				// NewANTLRv3.g:280:2: ( rewrite_template | rewrite_tree_alternative | )
				int alt62 = 3;
				alt62 = dfa62.Predict(input);
				switch (alt62) 
				{
				case 1 :
					// NewANTLRv3.g:280:4: rewrite_template
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_template_in_rewrite_alternative1395);
					rewrite_template125 = rewrite_template();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template125.Tree);

				}
					break;
				case 2 :
					// NewANTLRv3.g:281:4: rewrite_tree_alternative
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_alternative_in_rewrite_alternative1400);
					rewrite_tree_alternative126 = rewrite_tree_alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_alternative126.Tree);

				}
					break;
				case 3 :
					// NewANTLRv3.g:283:2: 
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_alternative"

		public class rewrite_tree_block_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_block"
		// NewANTLRv3.g:285:1: rewrite_tree_block : lp= '(' rewrite_tree_alternative ')' ;
		public NewANTLRv3Parser.rewrite_tree_block_return rewrite_tree_block() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_tree_block_return retval = new NewANTLRv3Parser.rewrite_tree_block_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken char_literal128 = null;
			NewANTLRv3Parser.rewrite_tree_alternative_return rewrite_tree_alternative127 = default(NewANTLRv3Parser.rewrite_tree_alternative_return);


			CommonTree lp_tree=null;
			CommonTree char_literal128_tree=null;

			try 
			{
				// NewANTLRv3.g:286:5: (lp= '(' rewrite_tree_alternative ')' )
				// NewANTLRv3.g:286:9: lp= '(' rewrite_tree_alternative ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					lp=(IToken)Match(input,51,FOLLOW_51_in_rewrite_tree_block1429); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp);
						adaptor.AddChild(root_0, lp_tree);
					}
					PushFollow(FOLLOW_rewrite_tree_alternative_in_rewrite_tree_block1431);
					rewrite_tree_alternative127 = rewrite_tree_alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_alternative127.Tree);
					char_literal128=(IToken)Match(input,53,FOLLOW_53_in_rewrite_tree_block1433); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal128_tree = (CommonTree)adaptor.Create(char_literal128);
						adaptor.AddChild(root_0, char_literal128_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_tree_block"

		public class rewrite_tree_alternative_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_alternative"
		// NewANTLRv3.g:289:1: rewrite_tree_alternative : ( rewrite_tree_element )+ ;
		public NewANTLRv3Parser.rewrite_tree_alternative_return rewrite_tree_alternative() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_tree_alternative_return retval = new NewANTLRv3Parser.rewrite_tree_alternative_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			NewANTLRv3Parser.rewrite_tree_element_return rewrite_tree_element129 = default(NewANTLRv3Parser.rewrite_tree_element_return);



			try 
			{
				// NewANTLRv3.g:290:5: ( ( rewrite_tree_element )+ )
				// NewANTLRv3.g:290:7: ( rewrite_tree_element )+
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// NewANTLRv3.g:290:7: ( rewrite_tree_element )+
					int cnt63 = 0;
					do 
					{
						int alt63 = 2;
						int LA63_0 = input.LA(1);

						if ( ((LA63_0 >= TOKEN_REF && LA63_0 <= ACTION) || LA63_0 == RULE_REF || LA63_0 == 51 || LA63_0 == 60 || LA63_0 == 65) )
						{
							alt63 = 1;
						}


						switch (alt63) 
						{
						case 1 :
							// NewANTLRv3.g:290:7: rewrite_tree_element
						{
							PushFollow(FOLLOW_rewrite_tree_element_in_rewrite_tree_alternative1450);
							rewrite_tree_element129 = rewrite_tree_element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_element129.Tree);

						}
							break;

						default:
							if ( cnt63 >= 1 ) goto loop63;
							if ( state.backtracking > 0 ) {state.failed = true; return retval;}
							EarlyExitException eee63 =
								new EarlyExitException(63, input);
							throw eee63;
						}
						cnt63++;
					} while (true);

					loop63:
					;	// Stops C# compiler whining that label 'loop63' has no statements


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_tree_alternative"

		public class rewrite_tree_element_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_element"
		// NewANTLRv3.g:293:1: rewrite_tree_element : ( rewrite_tree_atom | rewrite_tree_atom ebnfSuffix | rewrite_tree ( ebnfSuffix | ) | rewrite_tree_ebnf );
		public NewANTLRv3Parser.rewrite_tree_element_return rewrite_tree_element() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_tree_element_return retval = new NewANTLRv3Parser.rewrite_tree_element_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			NewANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom130 = default(NewANTLRv3Parser.rewrite_tree_atom_return);

			NewANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom131 = default(NewANTLRv3Parser.rewrite_tree_atom_return);

			NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix132 = default(NewANTLRv3Parser.ebnfSuffix_return);

			NewANTLRv3Parser.rewrite_tree_return rewrite_tree133 = default(NewANTLRv3Parser.rewrite_tree_return);

			NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix134 = default(NewANTLRv3Parser.ebnfSuffix_return);

			NewANTLRv3Parser.rewrite_tree_ebnf_return rewrite_tree_ebnf135 = default(NewANTLRv3Parser.rewrite_tree_ebnf_return);



			try 
			{
				// NewANTLRv3.g:294:2: ( rewrite_tree_atom | rewrite_tree_atom ebnfSuffix | rewrite_tree ( ebnfSuffix | ) | rewrite_tree_ebnf )
				int alt65 = 4;
				alt65 = dfa65.Predict(input);
				switch (alt65) 
				{
				case 1 :
					// NewANTLRv3.g:294:4: rewrite_tree_atom
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1465);
					rewrite_tree_atom130 = rewrite_tree_atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_atom130.Tree);

				}
					break;
				case 2 :
					// NewANTLRv3.g:295:4: rewrite_tree_atom ebnfSuffix
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1470);
					rewrite_tree_atom131 = rewrite_tree_atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_atom131.Tree);
					PushFollow(FOLLOW_ebnfSuffix_in_rewrite_tree_element1472);
					ebnfSuffix132 = ebnfSuffix();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix132.Tree);

				}
					break;
				case 3 :
					// NewANTLRv3.g:296:6: rewrite_tree ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_in_rewrite_tree_element1479);
					rewrite_tree133 = rewrite_tree();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree133.Tree);
					// NewANTLRv3.g:297:3: ( ebnfSuffix | )
					int alt64 = 2;
					int LA64_0 = input.LA(1);

					if ( (LA64_0 == 41 || (LA64_0 >= 61 && LA64_0 <= 62)) )
					{
						alt64 = 1;
					}
					else if ( (LA64_0 == EOF || (LA64_0 >= TOKEN_REF && LA64_0 <= ACTION) || LA64_0 == RULE_REF || LA64_0 == 35 || (LA64_0 >= 51 && LA64_0 <= 53) || LA64_0 == 60 || (LA64_0 >= 64 && LA64_0 <= 65)) )
					{
						alt64 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d64s0 =
							new NoViableAltException("", 64, 0, input);

						throw nvae_d64s0;
					}
					switch (alt64) 
					{
					case 1 :
						// NewANTLRv3.g:297:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_rewrite_tree_element1485);
						ebnfSuffix134 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix134.Tree);

					}
						break;
					case 2 :
						// NewANTLRv3.g:299:3: 
					{
					}
						break;

					}


				}
					break;
				case 4 :
					// NewANTLRv3.g:300:6: rewrite_tree_ebnf
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_ebnf_in_rewrite_tree_element1500);
					rewrite_tree_ebnf135 = rewrite_tree_ebnf();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_ebnf135.Tree);

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_tree_element"

		public class rewrite_tree_atom_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_atom"
		// NewANTLRv3.g:303:1: rewrite_tree_atom : ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION )? | RULE_REF | STRING_LITERAL | d= '$' id | ACTION );
		public NewANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_tree_atom_return retval = new NewANTLRv3Parser.rewrite_tree_atom_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken d = null;
			IToken CHAR_LITERAL136 = null;
			IToken TOKEN_REF137 = null;
			IToken ARG_ACTION138 = null;
			IToken RULE_REF139 = null;
			IToken STRING_LITERAL140 = null;
			IToken ACTION142 = null;
			NewANTLRv3Parser.id_return id141 = default(NewANTLRv3Parser.id_return);


			CommonTree d_tree=null;
			CommonTree CHAR_LITERAL136_tree=null;
			CommonTree TOKEN_REF137_tree=null;
			CommonTree ARG_ACTION138_tree=null;
			CommonTree RULE_REF139_tree=null;
			CommonTree STRING_LITERAL140_tree=null;
			CommonTree ACTION142_tree=null;

			try 
			{
				// NewANTLRv3.g:304:5: ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION )? | RULE_REF | STRING_LITERAL | d= '$' id | ACTION )
				int alt67 = 6;
				switch ( input.LA(1) ) 
				{
				case CHAR_LITERAL:
				{
					alt67 = 1;
				}
					break;
				case TOKEN_REF:
				{
					alt67 = 2;
				}
					break;
				case RULE_REF:
				{
					alt67 = 3;
				}
					break;
				case STRING_LITERAL:
				{
					alt67 = 4;
				}
					break;
				case 65:
				{
					alt67 = 5;
				}
					break;
				case ACTION:
				{
					alt67 = 6;
				}
					break;
				default:
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d67s0 =
						new NoViableAltException("", 67, 0, input);

					throw nvae_d67s0;
				}

				switch (alt67) 
				{
				case 1 :
					// NewANTLRv3.g:304:9: CHAR_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					CHAR_LITERAL136=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_rewrite_tree_atom1516); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{CHAR_LITERAL136_tree = (CommonTree)adaptor.Create(CHAR_LITERAL136);
						adaptor.AddChild(root_0, CHAR_LITERAL136_tree);
					}

				}
					break;
				case 2 :
					// NewANTLRv3.g:305:6: TOKEN_REF ( ARG_ACTION )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					TOKEN_REF137=(IToken)Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_rewrite_tree_atom1523); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{TOKEN_REF137_tree = (CommonTree)adaptor.Create(TOKEN_REF137);
						adaptor.AddChild(root_0, TOKEN_REF137_tree);
					}
					// NewANTLRv3.g:305:16: ( ARG_ACTION )?
					int alt66 = 2;
					int LA66_0 = input.LA(1);

					if ( (LA66_0 == ARG_ACTION) )
					{
						alt66 = 1;
					}
					switch (alt66) 
					{
					case 1 :
						// NewANTLRv3.g:305:16: ARG_ACTION
					{
						ARG_ACTION138=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rewrite_tree_atom1525); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{ARG_ACTION138_tree = (CommonTree)adaptor.Create(ARG_ACTION138);
							adaptor.AddChild(root_0, ARG_ACTION138_tree);
						}

					}
						break;

					}


				}
					break;
				case 3 :
					// NewANTLRv3.g:306:9: RULE_REF
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					RULE_REF139=(IToken)Match(input,RULE_REF,FOLLOW_RULE_REF_in_rewrite_tree_atom1536); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{RULE_REF139_tree = (CommonTree)adaptor.Create(RULE_REF139);
						adaptor.AddChild(root_0, RULE_REF139_tree);
					}

				}
					break;
				case 4 :
					// NewANTLRv3.g:307:6: STRING_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					STRING_LITERAL140=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_rewrite_tree_atom1543); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{STRING_LITERAL140_tree = (CommonTree)adaptor.Create(STRING_LITERAL140);
						adaptor.AddChild(root_0, STRING_LITERAL140_tree);
					}

				}
					break;
				case 5 :
					// NewANTLRv3.g:308:6: d= '$' id
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					d=(IToken)Match(input,65,FOLLOW_65_in_rewrite_tree_atom1552); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{d_tree = (CommonTree)adaptor.Create(d);
						adaptor.AddChild(root_0, d_tree);
					}
					PushFollow(FOLLOW_id_in_rewrite_tree_atom1554);
					id141 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id141.Tree);

				}
					break;
				case 6 :
					// NewANTLRv3.g:309:4: ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					ACTION142=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_tree_atom1559); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION142_tree = (CommonTree)adaptor.Create(ACTION142);
						adaptor.AddChild(root_0, ACTION142_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_tree_atom"

		public class rewrite_tree_ebnf_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_ebnf"
		// NewANTLRv3.g:312:1: rewrite_tree_ebnf : rewrite_tree_block ebnfSuffix ;
		public NewANTLRv3Parser.rewrite_tree_ebnf_return rewrite_tree_ebnf() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_tree_ebnf_return retval = new NewANTLRv3Parser.rewrite_tree_ebnf_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			NewANTLRv3Parser.rewrite_tree_block_return rewrite_tree_block143 = default(NewANTLRv3Parser.rewrite_tree_block_return);

			NewANTLRv3Parser.ebnfSuffix_return ebnfSuffix144 = default(NewANTLRv3Parser.ebnfSuffix_return);




			IToken firstToken = input.LT(1);

			try 
			{
				// NewANTLRv3.g:320:2: ( rewrite_tree_block ebnfSuffix )
				// NewANTLRv3.g:320:4: rewrite_tree_block ebnfSuffix
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_block_in_rewrite_tree_ebnf1580);
					rewrite_tree_block143 = rewrite_tree_block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_block143.Tree);
					PushFollow(FOLLOW_ebnfSuffix_in_rewrite_tree_ebnf1582);
					ebnfSuffix144 = ebnfSuffix();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix144.Tree);

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
				if ( (state.backtracking==0) )
				{

					((CommonTree)retval.Tree).Token.Line = firstToken.Line;
					((CommonTree)retval.Tree).Token.CharPositionInLine = firstToken.CharPositionInLine;

				}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_tree_ebnf"

		public class rewrite_tree_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree"
		// NewANTLRv3.g:323:1: rewrite_tree : '^(' rewrite_tree_atom ( rewrite_tree_element )* ')' ;
		public NewANTLRv3Parser.rewrite_tree_return rewrite_tree() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_tree_return retval = new NewANTLRv3Parser.rewrite_tree_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal145 = null;
			IToken char_literal148 = null;
			NewANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom146 = default(NewANTLRv3Parser.rewrite_tree_atom_return);

			NewANTLRv3Parser.rewrite_tree_element_return rewrite_tree_element147 = default(NewANTLRv3Parser.rewrite_tree_element_return);


			CommonTree string_literal145_tree=null;
			CommonTree char_literal148_tree=null;

			try 
			{
				// NewANTLRv3.g:324:2: ( '^(' rewrite_tree_atom ( rewrite_tree_element )* ')' )
				// NewANTLRv3.g:324:4: '^(' rewrite_tree_atom ( rewrite_tree_element )* ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal145=(IToken)Match(input,60,FOLLOW_60_in_rewrite_tree1594); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal145_tree = (CommonTree)adaptor.Create(string_literal145);
						adaptor.AddChild(root_0, string_literal145_tree);
					}
					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree1596);
					rewrite_tree_atom146 = rewrite_tree_atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_atom146.Tree);
					// NewANTLRv3.g:324:27: ( rewrite_tree_element )*
					do 
					{
						int alt68 = 2;
						int LA68_0 = input.LA(1);

						if ( ((LA68_0 >= TOKEN_REF && LA68_0 <= ACTION) || LA68_0 == RULE_REF || LA68_0 == 51 || LA68_0 == 60 || LA68_0 == 65) )
						{
							alt68 = 1;
						}


						switch (alt68) 
						{
						case 1 :
							// NewANTLRv3.g:324:27: rewrite_tree_element
						{
							PushFollow(FOLLOW_rewrite_tree_element_in_rewrite_tree1598);
							rewrite_tree_element147 = rewrite_tree_element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_element147.Tree);

						}
							break;

						default:
							goto loop68;
						}
					} while (true);

					loop68:
					;	// Stops C# compiler whining that label 'loop68' has no statements

					char_literal148=(IToken)Match(input,53,FOLLOW_53_in_rewrite_tree1601); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal148_tree = (CommonTree)adaptor.Create(char_literal148);
						adaptor.AddChild(root_0, char_literal148_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_tree"

		public class rewrite_template_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template"
		// NewANTLRv3.g:327:1: rewrite_template : ( id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION );
		public NewANTLRv3Parser.rewrite_template_return rewrite_template() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_template_return retval = new NewANTLRv3Parser.rewrite_template_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken str = null;
			IToken char_literal151 = null;
			IToken ACTION154 = null;
			NewANTLRv3Parser.id_return id149 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.rewrite_template_args_return rewrite_template_args150 = default(NewANTLRv3Parser.rewrite_template_args_return);

			NewANTLRv3Parser.rewrite_template_ref_return rewrite_template_ref152 = default(NewANTLRv3Parser.rewrite_template_ref_return);

			NewANTLRv3Parser.rewrite_indirect_template_head_return rewrite_indirect_template_head153 = default(NewANTLRv3Parser.rewrite_indirect_template_head_return);


			CommonTree lp_tree=null;
			CommonTree str_tree=null;
			CommonTree char_literal151_tree=null;
			CommonTree ACTION154_tree=null;

			try 
			{
				// NewANTLRv3.g:339:2: ( id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION )
				int alt70 = 4;
				alt70 = dfa70.Predict(input);
				switch (alt70) 
				{
				case 1 :
					// NewANTLRv3.g:340:3: id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_rewrite_template1619);
					id149 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id149.Tree);
					lp=(IToken)Match(input,51,FOLLOW_51_in_rewrite_template1623); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp);
						adaptor.AddChild(root_0, lp_tree);
					}
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_template1625);
					rewrite_template_args150 = rewrite_template_args();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_args150.Tree);
					char_literal151=(IToken)Match(input,53,FOLLOW_53_in_rewrite_template1627); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal151_tree = (CommonTree)adaptor.Create(char_literal151);
						adaptor.AddChild(root_0, char_literal151_tree);
					}
					// NewANTLRv3.g:341:3: (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL )
					int alt69 = 2;
					int LA69_0 = input.LA(1);

					if ( (LA69_0 == DOUBLE_QUOTE_STRING_LITERAL) )
					{
						alt69 = 1;
					}
					else if ( (LA69_0 == DOUBLE_ANGLE_STRING_LITERAL) )
					{
						alt69 = 2;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						NoViableAltException nvae_d69s0 =
							new NoViableAltException("", 69, 0, input);

						throw nvae_d69s0;
					}
					switch (alt69) 
					{
					case 1 :
						// NewANTLRv3.g:341:5: str= DOUBLE_QUOTE_STRING_LITERAL
					{
						str=(IToken)Match(input,DOUBLE_QUOTE_STRING_LITERAL,FOLLOW_DOUBLE_QUOTE_STRING_LITERAL_in_rewrite_template1635); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{str_tree = (CommonTree)adaptor.Create(str);
							adaptor.AddChild(root_0, str_tree);
						}

					}
						break;
					case 2 :
						// NewANTLRv3.g:341:39: str= DOUBLE_ANGLE_STRING_LITERAL
					{
						str=(IToken)Match(input,DOUBLE_ANGLE_STRING_LITERAL,FOLLOW_DOUBLE_ANGLE_STRING_LITERAL_in_rewrite_template1641); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{str_tree = (CommonTree)adaptor.Create(str);
							adaptor.AddChild(root_0, str_tree);
						}

					}
						break;

					}


				}
					break;
				case 2 :
					// NewANTLRv3.g:343:3: rewrite_template_ref
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_template_ref_in_rewrite_template1651);
					rewrite_template_ref152 = rewrite_template_ref();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_ref152.Tree);

				}
					break;
				case 3 :
					// NewANTLRv3.g:346:3: rewrite_indirect_template_head
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_indirect_template_head_in_rewrite_template1660);
					rewrite_indirect_template_head153 = rewrite_indirect_template_head();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_indirect_template_head153.Tree);

				}
					break;
				case 4 :
					// NewANTLRv3.g:349:3: ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					ACTION154=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_template1669); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION154_tree = (CommonTree)adaptor.Create(ACTION154);
						adaptor.AddChild(root_0, ACTION154_tree);
					}

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_template"

		public class rewrite_template_ref_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template_ref"
		// NewANTLRv3.g:352:1: rewrite_template_ref : id lp= '(' rewrite_template_args ')' ;
		public NewANTLRv3Parser.rewrite_template_ref_return rewrite_template_ref() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_template_ref_return retval = new NewANTLRv3Parser.rewrite_template_ref_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken char_literal157 = null;
			NewANTLRv3Parser.id_return id155 = default(NewANTLRv3Parser.id_return);

			NewANTLRv3Parser.rewrite_template_args_return rewrite_template_args156 = default(NewANTLRv3Parser.rewrite_template_args_return);


			CommonTree lp_tree=null;
			CommonTree char_literal157_tree=null;

			try 
			{
				// NewANTLRv3.g:354:2: ( id lp= '(' rewrite_template_args ')' )
				// NewANTLRv3.g:354:4: id lp= '(' rewrite_template_args ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_rewrite_template_ref1682);
					id155 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id155.Tree);
					lp=(IToken)Match(input,51,FOLLOW_51_in_rewrite_template_ref1686); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp);
						adaptor.AddChild(root_0, lp_tree);
					}
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_template_ref1688);
					rewrite_template_args156 = rewrite_template_args();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_args156.Tree);
					char_literal157=(IToken)Match(input,53,FOLLOW_53_in_rewrite_template_ref1690); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal157_tree = (CommonTree)adaptor.Create(char_literal157);
						adaptor.AddChild(root_0, char_literal157_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_template_ref"

		public class rewrite_indirect_template_head_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_indirect_template_head"
		// NewANTLRv3.g:357:1: rewrite_indirect_template_head : lp= '(' ACTION ')' '(' rewrite_template_args ')' ;
		public NewANTLRv3Parser.rewrite_indirect_template_head_return rewrite_indirect_template_head() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_indirect_template_head_return retval = new NewANTLRv3Parser.rewrite_indirect_template_head_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken ACTION158 = null;
			IToken char_literal159 = null;
			IToken char_literal160 = null;
			IToken char_literal162 = null;
			NewANTLRv3Parser.rewrite_template_args_return rewrite_template_args161 = default(NewANTLRv3Parser.rewrite_template_args_return);


			CommonTree lp_tree=null;
			CommonTree ACTION158_tree=null;
			CommonTree char_literal159_tree=null;
			CommonTree char_literal160_tree=null;
			CommonTree char_literal162_tree=null;

			try 
			{
				// NewANTLRv3.g:359:2: (lp= '(' ACTION ')' '(' rewrite_template_args ')' )
				// NewANTLRv3.g:359:4: lp= '(' ACTION ')' '(' rewrite_template_args ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					lp=(IToken)Match(input,51,FOLLOW_51_in_rewrite_indirect_template_head1705); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp);
						adaptor.AddChild(root_0, lp_tree);
					}
					ACTION158=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_indirect_template_head1707); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION158_tree = (CommonTree)adaptor.Create(ACTION158);
						adaptor.AddChild(root_0, ACTION158_tree);
					}
					char_literal159=(IToken)Match(input,53,FOLLOW_53_in_rewrite_indirect_template_head1709); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal159_tree = (CommonTree)adaptor.Create(char_literal159);
						adaptor.AddChild(root_0, char_literal159_tree);
					}
					char_literal160=(IToken)Match(input,51,FOLLOW_51_in_rewrite_indirect_template_head1711); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal160_tree = (CommonTree)adaptor.Create(char_literal160);
						adaptor.AddChild(root_0, char_literal160_tree);
					}
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_indirect_template_head1713);
					rewrite_template_args161 = rewrite_template_args();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_args161.Tree);
					char_literal162=(IToken)Match(input,53,FOLLOW_53_in_rewrite_indirect_template_head1715); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal162_tree = (CommonTree)adaptor.Create(char_literal162);
						adaptor.AddChild(root_0, char_literal162_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_indirect_template_head"

		public class rewrite_template_args_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template_args"
		// NewANTLRv3.g:362:1: rewrite_template_args : ( rewrite_template_arg ( ',' rewrite_template_arg )* | );
		public NewANTLRv3Parser.rewrite_template_args_return rewrite_template_args() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_template_args_return retval = new NewANTLRv3Parser.rewrite_template_args_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal164 = null;
			NewANTLRv3Parser.rewrite_template_arg_return rewrite_template_arg163 = default(NewANTLRv3Parser.rewrite_template_arg_return);

			NewANTLRv3Parser.rewrite_template_arg_return rewrite_template_arg165 = default(NewANTLRv3Parser.rewrite_template_arg_return);


			CommonTree char_literal164_tree=null;

			try 
			{
				// NewANTLRv3.g:363:2: ( rewrite_template_arg ( ',' rewrite_template_arg )* | )
				int alt72 = 2;
				int LA72_0 = input.LA(1);

				if ( (LA72_0 == TOKEN_REF || LA72_0 == RULE_REF) )
				{
					alt72 = 1;
				}
				else if ( (LA72_0 == 53) )
				{
					alt72 = 2;
				}
				else 
				{
					if ( state.backtracking > 0 ) {state.failed = true; return retval;}
					NoViableAltException nvae_d72s0 =
						new NoViableAltException("", 72, 0, input);

					throw nvae_d72s0;
				}
				switch (alt72) 
				{
				case 1 :
					// NewANTLRv3.g:363:4: rewrite_template_arg ( ',' rewrite_template_arg )*
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_template_arg_in_rewrite_template_args1726);
					rewrite_template_arg163 = rewrite_template_arg();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_arg163.Tree);
					// NewANTLRv3.g:363:25: ( ',' rewrite_template_arg )*
					do 
					{
						int alt71 = 2;
						int LA71_0 = input.LA(1);

						if ( (LA71_0 == 50) )
						{
							alt71 = 1;
						}


						switch (alt71) 
						{
						case 1 :
							// NewANTLRv3.g:363:26: ',' rewrite_template_arg
						{
							char_literal164=(IToken)Match(input,50,FOLLOW_50_in_rewrite_template_args1729); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal164_tree = (CommonTree)adaptor.Create(char_literal164);
								adaptor.AddChild(root_0, char_literal164_tree);
							}
							PushFollow(FOLLOW_rewrite_template_arg_in_rewrite_template_args1731);
							rewrite_template_arg165 = rewrite_template_arg();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_arg165.Tree);

						}
							break;

						default:
							goto loop71;
						}
					} while (true);

					loop71:
					;	// Stops C# compiler whining that label 'loop71' has no statements


				}
					break;
				case 2 :
					// NewANTLRv3.g:365:2: 
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

				}
					break;

				}
				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_template_args"

		public class rewrite_template_arg_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template_arg"
		// NewANTLRv3.g:367:1: rewrite_template_arg : id '=' ACTION ;
		public NewANTLRv3Parser.rewrite_template_arg_return rewrite_template_arg() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.rewrite_template_arg_return retval = new NewANTLRv3Parser.rewrite_template_arg_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal167 = null;
			IToken ACTION168 = null;
			NewANTLRv3Parser.id_return id166 = default(NewANTLRv3Parser.id_return);


			CommonTree char_literal167_tree=null;
			CommonTree ACTION168_tree=null;

			try 
			{
				// NewANTLRv3.g:368:2: ( id '=' ACTION )
				// NewANTLRv3.g:368:6: id '=' ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_rewrite_template_arg1749);
					id166 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id166.Tree);
					char_literal167=(IToken)Match(input,37,FOLLOW_37_in_rewrite_template_arg1751); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal167_tree = (CommonTree)adaptor.Create(char_literal167);
						adaptor.AddChild(root_0, char_literal167_tree);
					}
					ACTION168=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_template_arg1753); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION168_tree = (CommonTree)adaptor.Create(ACTION168);
						adaptor.AddChild(root_0, ACTION168_tree);
					}

				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "rewrite_template_arg"

		public class id_return : ParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "id"
		// NewANTLRv3.g:371:1: id : ( TOKEN_REF | RULE_REF );
		public NewANTLRv3Parser.id_return id() // throws RecognitionException [1]
		{   
			NewANTLRv3Parser.id_return retval = new NewANTLRv3Parser.id_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken set169 = null;

			CommonTree set169_tree=null;

			try 
			{
				// NewANTLRv3.g:371:4: ( TOKEN_REF | RULE_REF )
				// NewANTLRv3.g:
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					set169 = (IToken)input.LT(1);
					if ( input.LA(1) == TOKEN_REF || input.LA(1) == RULE_REF ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set169));
						state.errorRecovery = false;state.failed = false;
					}
					else 
					{
						if ( state.backtracking > 0 ) {state.failed = true; return retval;}
						MismatchedSetException mse = new MismatchedSetException(null,input);
						throw mse;
					}


				}

				retval.Stop = input.LT(-1);

				if ( (state.backtracking==0) )
				{	retval.Tree = (CommonTree)adaptor.RulePostProcessing(root_0);
					adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
			}
			catch (RecognitionException re) 
			{
				ReportError(re);
				Recover(input,re);
				// Conversion of the second argument necessary, but harmless
				retval.Tree = (CommonTree)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

			}
			finally 
			{
			}
			return retval;
		}
		// $ANTLR end "id"

		// $ANTLR start "synpred1_NewANTLRv3"
		public void synpred1_NewANTLRv3_fragment() {
			// NewANTLRv3.g:280:4: ( rewrite_template )
			// NewANTLRv3.g:280:4: rewrite_template
			{
				PushFollow(FOLLOW_rewrite_template_in_synpred1_NewANTLRv31395);
				rewrite_template();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred1_NewANTLRv3"

		// $ANTLR start "synpred2_NewANTLRv3"
		public void synpred2_NewANTLRv3_fragment() {
			// NewANTLRv3.g:281:4: ( rewrite_tree_alternative )
			// NewANTLRv3.g:281:4: rewrite_tree_alternative
			{
				PushFollow(FOLLOW_rewrite_tree_alternative_in_synpred2_NewANTLRv31400);
				rewrite_tree_alternative();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred2_NewANTLRv3"

		// Delegated rules

		public bool synpred1_NewANTLRv3() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred1_NewANTLRv3_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}
		public bool synpred2_NewANTLRv3() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred2_NewANTLRv3_fragment(); // can never throw exception
			}
			catch (RecognitionException re) 
			{
				Console.Error.WriteLine("impossible: "+re);
			}
			bool success = !state.failed;
			input.Rewind(start);
			state.backtracking--;
			state.failed = false;
			return success;
		}


		protected DFA45 dfa45;
		protected DFA62 dfa62;
		protected DFA65 dfa65;
		protected DFA70 dfa70;
		private void InitializeCyclicDFAs()
		{
			this.dfa45 = new DFA45(this);
			this.dfa62 = new DFA62(this);
			this.dfa65 = new DFA65(this);
			this.dfa70 = new DFA70(this);
			this.dfa62.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA62_SpecialStateTransition);
		}

		const string DFA45_eotS =
			"\x0c\uffff";
		const string DFA45_eofS =
			"\x0c\uffff";
		const string DFA45_minS =
			"\x02\x06\x01\uffff\x01\x06\x04\uffff\x02\x06\x02\uffff";
		const string DFA45_maxS =
			"\x01\x3f\x01\x40\x01\uffff\x01\x40\x04\uffff\x02\x3f\x02\uffff";
		const string DFA45_acceptS =
			"\x02\uffff\x01\x03\x01\uffff\x01\x04\x01\x05\x01\x06\x01\x07\x02"+
				"\uffff\x01\x02\x01\x01";
		const string DFA45_specialS =
			"\x0c\uffff}>";
		static readonly string[] DFA45_transitionS = {
			"\x01\x01\x02\x02\x01\x05\x03\uffff\x01\x06\x01\x03\x24\uffff"+
				"\x01\x04\x07\uffff\x01\x02\x01\x07\x02\uffff\x01\x02",
			"\x04\x02\x02\uffff\x03\x02\x14\uffff\x01\x02\x01\uffff\x01"+
				"\x08\x03\uffff\x01\x02\x04\uffff\x01\x02\x04\uffff\x03\x02\x02"+
					"\uffff\x01\x09\x01\uffff\x07\x02",
			"",
			"\x04\x02\x02\uffff\x03\x02\x14\uffff\x01\x02\x01\uffff\x01"+
				"\x08\x03\uffff\x01\x02\x04\uffff\x01\x02\x04\uffff\x03\x02\x02"+
					"\uffff\x01\x09\x01\uffff\x07\x02",
			"",
			"",
			"",
			"",
			"\x03\x0b\x05\uffff\x01\x0b\x24\uffff\x01\x0a\x07\uffff\x01"+
				"\x0b\x03\uffff\x01\x0b",
			"\x03\x0b\x05\uffff\x01\x0b\x24\uffff\x01\x0a\x07\uffff\x01"+
				"\x0b\x03\uffff\x01\x0b",
			"",
			""
		};

		static readonly short[] DFA45_eot = DFA.UnpackEncodedString(DFA45_eotS);
		static readonly short[] DFA45_eof = DFA.UnpackEncodedString(DFA45_eofS);
		static readonly char[] DFA45_min = DFA.UnpackEncodedStringToUnsignedChars(DFA45_minS);
		static readonly char[] DFA45_max = DFA.UnpackEncodedStringToUnsignedChars(DFA45_maxS);
		static readonly short[] DFA45_accept = DFA.UnpackEncodedString(DFA45_acceptS);
		static readonly short[] DFA45_special = DFA.UnpackEncodedString(DFA45_specialS);
		static readonly short[][] DFA45_transition = DFA.UnpackEncodedStringArray(DFA45_transitionS);

		protected class DFA45 : DFA
		{
			public DFA45(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 45;
				this.eot = DFA45_eot;
				this.eof = DFA45_eof;
				this.min = DFA45_min;
				this.max = DFA45_max;
				this.accept = DFA45_accept;
				this.special = DFA45_special;
				this.transition = DFA45_transition;

			}

			override public string Description
			{
				get { return "174:1: elementNoOptionSpec : ( id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | ) | id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | ) | atom ( ebnfSuffix | ) | ebnf | ACTION | SEMPRED ( '=>' | ) | treeSpec ( ebnfSuffix | ) );"; }
			}

		}

		const string DFA62_eotS =
			"\x0d\uffff";
		const string DFA62_eofS =
			"\x0d\uffff";
		const string DFA62_minS =
			"\x03\x06\x01\x00\x01\uffff\x01\x06\x01\uffff\x02\x06\x01\uffff"+
				"\x02\x06\x01\x29";
		const string DFA62_maxS =
			"\x03\x41\x01\x00\x01\uffff\x01\x41\x01\uffff\x02\x41\x01\uffff"+
				"\x02\x41\x01\x3e";
		const string DFA62_acceptS =
			"\x04\uffff\x01\x02\x01\uffff\x01\x03\x02\uffff\x01\x01\x03\uffff";
		const string DFA62_specialS =
			"\x03\uffff\x01\x00\x09\uffff}>";
		static readonly string[] DFA62_transitionS = {
			"\x01\x01\x02\x04\x01\x03\x04\uffff\x01\x05\x14\uffff\x01\x06"+
				"\x0f\uffff\x01\x02\x02\x06\x06\uffff\x01\x04\x03\uffff\x01\x06"+
					"\x01\x04",
			"\x04\x04\x02\uffff\x01\x04\x01\uffff\x01\x04\x14\uffff\x01"+
				"\x04\x05\uffff\x01\x04\x09\uffff\x01\x07\x02\x04\x06\uffff\x03"+
					"\x04\x01\uffff\x02\x04",
			"\x03\x04\x01\x08\x04\uffff\x01\x04\x24\uffff\x01\x04\x08\uffff"+
				"\x01\x04\x04\uffff\x01\x04",
			"\x01\uffff",
			"",
			"\x04\x04\x04\uffff\x01\x04\x14\uffff\x01\x04\x05\uffff\x01"+
				"\x04\x09\uffff\x01\x07\x02\x04\x06\uffff\x03\x04\x01\uffff\x02"+
					"\x04",
			"",
			"\x01\x0a\x03\x04\x04\uffff\x01\x0b\x24\uffff\x01\x04\x01\uffff"+
				"\x01\x09\x06\uffff\x01\x04\x04\uffff\x01\x04",
			"\x04\x04\x04\uffff\x01\x04\x1a\uffff\x01\x04\x09\uffff\x01"+
				"\x04\x01\uffff\x01\x0c\x06\uffff\x03\x04\x02\uffff\x01\x04",
			"",
			"\x04\x04\x02\uffff\x01\x04\x01\uffff\x01\x04\x16\uffff\x01"+
				"\x09\x03\uffff\x01\x04\x09\uffff\x01\x04\x01\uffff\x01\x04\x06"+
					"\uffff\x03\x04\x02\uffff\x01\x04",
			"\x04\x04\x04\uffff\x01\x04\x16\uffff\x01\x09\x03\uffff\x01"+
				"\x04\x09\uffff\x01\x04\x01\uffff\x01\x04\x06\uffff\x03\x04\x02"+
					"\uffff\x01\x04",
			"\x01\x04\x09\uffff\x01\x09\x09\uffff\x02\x04"
		};

		static readonly short[] DFA62_eot = DFA.UnpackEncodedString(DFA62_eotS);
		static readonly short[] DFA62_eof = DFA.UnpackEncodedString(DFA62_eofS);
		static readonly char[] DFA62_min = DFA.UnpackEncodedStringToUnsignedChars(DFA62_minS);
		static readonly char[] DFA62_max = DFA.UnpackEncodedStringToUnsignedChars(DFA62_maxS);
		static readonly short[] DFA62_accept = DFA.UnpackEncodedString(DFA62_acceptS);
		static readonly short[] DFA62_special = DFA.UnpackEncodedString(DFA62_specialS);
		static readonly short[][] DFA62_transition = DFA.UnpackEncodedStringArray(DFA62_transitionS);

		protected class DFA62 : DFA
		{
			public DFA62(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 62;
				this.eot = DFA62_eot;
				this.eof = DFA62_eof;
				this.min = DFA62_min;
				this.max = DFA62_max;
				this.accept = DFA62_accept;
				this.special = DFA62_special;
				this.transition = DFA62_transition;

			}

			override public string Description
			{
				get { return "278:1: rewrite_alternative options {backtrack=true; } : ( rewrite_template | rewrite_tree_alternative | );"; }
			}

		}


		protected internal int DFA62_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
		{
			ITokenStream input = (ITokenStream)_input;
			int _s = s;
			switch ( s )
			{
			case 0 : 
				int LA62_3 = input.LA(1);

                   	 
				int index62_3 = input.Index();
				input.Rewind();
				s = -1;
				if ( (synpred1_NewANTLRv3()) ) { s = 9; }

				else if ( (synpred2_NewANTLRv3()) ) { s = 4; }

                   	 
				input.Seek(index62_3);
				if ( s >= 0 ) return s;
				break;
			}
			if (state.backtracking > 0) {state.failed = true; return -1;}
			NoViableAltException nvae62 =
				new NoViableAltException(dfa.Description, 62, _s, input);
			dfa.Error(nvae62);
			throw nvae62;
		}
		const string DFA65_eotS =
			"\x0d\uffff";
		const string DFA65_eofS =
			"\x01\uffff\x04\x0a\x01\uffff\x01\x0a\x04\uffff\x02\x0a";
		const string DFA65_minS =
			"\x07\x06\x04\uffff\x02\x06";
		const string DFA65_maxS =
			"\x05\x41\x01\x0e\x01\x41\x04\uffff\x02\x41";
		const string DFA65_acceptS =
			"\x07\uffff\x01\x03\x01\x04\x01\x02\x01\x01\x02\uffff";
		const string DFA65_specialS =
			"\x0d\uffff}>";
		static readonly string[] DFA65_transitionS = {
			"\x01\x02\x01\x04\x01\x01\x01\x06\x04\uffff\x01\x03\x24\uffff"+
				"\x01\x08\x08\uffff\x01\x07\x04\uffff\x01\x05",
			"\x04\x0a\x04\uffff\x01\x0a\x14\uffff\x01\x0a\x05\uffff\x01"+
				"\x09\x09\uffff\x03\x0a\x06\uffff\x01\x0a\x02\x09\x01\uffff\x02"+
					"\x0a",
			"\x04\x0a\x02\uffff\x01\x0b\x01\uffff\x01\x0a\x14\uffff\x01"+
				"\x0a\x05\uffff\x01\x09\x09\uffff\x03\x0a\x06\uffff\x01\x0a\x02"+
					"\x09\x01\uffff\x02\x0a",
			"\x04\x0a\x04\uffff\x01\x0a\x14\uffff\x01\x0a\x05\uffff\x01"+
				"\x09\x09\uffff\x03\x0a\x06\uffff\x01\x0a\x02\x09\x01\uffff\x02"+
					"\x0a",
			"\x04\x0a\x04\uffff\x01\x0a\x14\uffff\x01\x0a\x05\uffff\x01"+
				"\x09\x09\uffff\x03\x0a\x06\uffff\x01\x0a\x02\x09\x01\uffff\x02"+
					"\x0a",
			"\x01\x0c\x07\uffff\x01\x0c",
			"\x04\x0a\x04\uffff\x01\x0a\x14\uffff\x01\x0a\x05\uffff\x01"+
				"\x09\x09\uffff\x03\x0a\x06\uffff\x01\x0a\x02\x09\x01\uffff\x02"+
					"\x0a",
			"",
			"",
			"",
			"",
			"\x04\x0a\x04\uffff\x01\x0a\x14\uffff\x01\x0a\x05\uffff\x01"+
				"\x09\x09\uffff\x03\x0a\x06\uffff\x01\x0a\x02\x09\x01\uffff\x02"+
					"\x0a",
			"\x04\x0a\x04\uffff\x01\x0a\x14\uffff\x01\x0a\x05\uffff\x01"+
				"\x09\x09\uffff\x03\x0a\x06\uffff\x01\x0a\x02\x09\x01\uffff\x02"+
					"\x0a"
		};

		static readonly short[] DFA65_eot = DFA.UnpackEncodedString(DFA65_eotS);
		static readonly short[] DFA65_eof = DFA.UnpackEncodedString(DFA65_eofS);
		static readonly char[] DFA65_min = DFA.UnpackEncodedStringToUnsignedChars(DFA65_minS);
		static readonly char[] DFA65_max = DFA.UnpackEncodedStringToUnsignedChars(DFA65_maxS);
		static readonly short[] DFA65_accept = DFA.UnpackEncodedString(DFA65_acceptS);
		static readonly short[] DFA65_special = DFA.UnpackEncodedString(DFA65_specialS);
		static readonly short[][] DFA65_transition = DFA.UnpackEncodedStringArray(DFA65_transitionS);

		protected class DFA65 : DFA
		{
			public DFA65(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 65;
				this.eot = DFA65_eot;
				this.eof = DFA65_eof;
				this.min = DFA65_min;
				this.max = DFA65_max;
				this.accept = DFA65_accept;
				this.special = DFA65_special;
				this.transition = DFA65_transition;

			}

			override public string Description
			{
				get { return "293:1: rewrite_tree_element : ( rewrite_tree_atom | rewrite_tree_atom ebnfSuffix | rewrite_tree ( ebnfSuffix | ) | rewrite_tree_ebnf );"; }
			}

		}

		const string DFA70_eotS =
			"\x0f\uffff";
		const string DFA70_eofS =
			"\x06\uffff\x01\x09\x08\uffff";
		const string DFA70_minS =
			"\x01\x06\x01\x33\x02\uffff\x01\x06\x01\x25\x01\x10\x01\x09\x02"+
				"\uffff\x01\x32\x01\x06\x01\x25\x01\x09\x01\x32";
		const string DFA70_maxS =
			"\x02\x33\x02\uffff\x01\x35\x01\x25\x01\x40\x01\x09\x02\uffff\x01"+
				"\x35\x01\x0e\x01\x25\x01\x09\x01\x35";
		const string DFA70_acceptS =
			"\x02\uffff\x01\x03\x01\x04\x04\uffff\x01\x01\x01\x02\x05\uffff";
		const string DFA70_specialS =
			"\x0f\uffff}>";
		static readonly string[] DFA70_transitionS = {
			"\x01\x01\x02\uffff\x01\x03\x04\uffff\x01\x01\x24\uffff\x01"+
				"\x02",
			"\x01\x04",
			"",
			"",
			"\x01\x05\x07\uffff\x01\x05\x26\uffff\x01\x06",
			"\x01\x07",
			"\x02\x08\x11\uffff\x01\x09\x10\uffff\x02\x09\x0a\uffff\x01"+
				"\x09",
			"\x01\x0a",
			"",
			"",
			"\x01\x0b\x02\uffff\x01\x06",
			"\x01\x0c\x07\uffff\x01\x0c",
			"\x01\x0d",
			"\x01\x0e",
			"\x01\x0b\x02\uffff\x01\x06"
		};

		static readonly short[] DFA70_eot = DFA.UnpackEncodedString(DFA70_eotS);
		static readonly short[] DFA70_eof = DFA.UnpackEncodedString(DFA70_eofS);
		static readonly char[] DFA70_min = DFA.UnpackEncodedStringToUnsignedChars(DFA70_minS);
		static readonly char[] DFA70_max = DFA.UnpackEncodedStringToUnsignedChars(DFA70_maxS);
		static readonly short[] DFA70_accept = DFA.UnpackEncodedString(DFA70_acceptS);
		static readonly short[] DFA70_special = DFA.UnpackEncodedString(DFA70_specialS);
		static readonly short[][] DFA70_transition = DFA.UnpackEncodedStringArray(DFA70_transitionS);

		protected class DFA70 : DFA
		{
			public DFA70(BaseRecognizer recognizer)
			{
				this.recognizer = recognizer;
				this.decisionNumber = 70;
				this.eot = DFA70_eot;
				this.eof = DFA70_eof;
				this.min = DFA70_min;
				this.max = DFA70_max;
				this.accept = DFA70_accept;
				this.special = DFA70_special;
				this.transition = DFA70_transition;

			}

			override public string Description
			{
				get { return "327:1: rewrite_template : ( id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION );"; }
			}

		}

 

		public static readonly BitSet FOLLOW_DOC_COMMENT_in_grammarDef50 = new BitSet(new ulong[]{0x0000000780000000UL});
		public static readonly BitSet FOLLOW_31_in_grammarDef60 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_32_in_grammarDef78 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_33_in_grammarDef94 = new BitSet(new ulong[]{0x0000000400000000UL});
		public static readonly BitSet FOLLOW_34_in_grammarDef135 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_grammarDef137 = new BitSet(new ulong[]{0x0000000800000000UL});
		public static readonly BitSet FOLLOW_35_in_grammarDef139 = new BitSet(new ulong[]{0x00003CC000004470UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_grammarDef141 = new BitSet(new ulong[]{0x00003CC000004470UL});
		public static readonly BitSet FOLLOW_tokensSpec_in_grammarDef144 = new BitSet(new ulong[]{0x00003CC000004470UL});
		public static readonly BitSet FOLLOW_attrScope_in_grammarDef147 = new BitSet(new ulong[]{0x00003CC000004470UL});
		public static readonly BitSet FOLLOW_action_in_grammarDef150 = new BitSet(new ulong[]{0x00003CC000004470UL});
		public static readonly BitSet FOLLOW_rule_in_grammarDef158 = new BitSet(new ulong[]{0x00003CC000004470UL});
		public static readonly BitSet FOLLOW_EOF_in_grammarDef166 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKENS_in_tokensSpec180 = new BitSet(new ulong[]{0x0000000000000040UL});
		public static readonly BitSet FOLLOW_tokenSpec_in_tokensSpec182 = new BitSet(new ulong[]{0x0000001000000040UL});
		public static readonly BitSet FOLLOW_36_in_tokensSpec185 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_tokenSpec196 = new BitSet(new ulong[]{0x0000002800000000UL});
		public static readonly BitSet FOLLOW_37_in_tokenSpec202 = new BitSet(new ulong[]{0x0000000000000180UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_tokenSpec207 = new BitSet(new ulong[]{0x0000000800000000UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_tokenSpec211 = new BitSet(new ulong[]{0x0000000800000000UL});
		public static readonly BitSet FOLLOW_35_in_tokenSpec224 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_38_in_attrScope235 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_attrScope237 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_attrScope239 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_39_in_action252 = new BitSet(new ulong[]{0x0000000180004040UL});
		public static readonly BitSet FOLLOW_actionScopeName_in_action255 = new BitSet(new ulong[]{0x0000010000000000UL});
		public static readonly BitSet FOLLOW_40_in_action257 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_action261 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_action263 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_actionScopeName276 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_31_in_actionScopeName283 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_32_in_actionScopeName295 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_OPTIONS_in_optionsSpec306 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_option_in_optionsSpec309 = new BitSet(new ulong[]{0x0000000800000000UL});
		public static readonly BitSet FOLLOW_35_in_optionsSpec311 = new BitSet(new ulong[]{0x0000001000004040UL});
		public static readonly BitSet FOLLOW_36_in_optionsSpec315 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_option331 = new BitSet(new ulong[]{0x0000002000000000UL});
		public static readonly BitSet FOLLOW_37_in_option333 = new BitSet(new ulong[]{0x00000200000049C0UL});
		public static readonly BitSet FOLLOW_optionValue_in_option335 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_optionValue354 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_optionValue364 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_optionValue374 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_INT_in_optionValue384 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_41_in_optionValue394 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOC_COMMENT_in_rule412 = new BitSet(new ulong[]{0x00003C0000004040UL});
		public static readonly BitSet FOLLOW_set_in_rule421 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_rule436 = new BitSet(new ulong[]{0x0003C0C000001400UL});
		public static readonly BitSet FOLLOW_46_in_rule442 = new BitSet(new ulong[]{0x000380C000001400UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rule451 = new BitSet(new ulong[]{0x000380C000000400UL});
		public static readonly BitSet FOLLOW_47_in_rule460 = new BitSet(new ulong[]{0x0000000000001000UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rule464 = new BitSet(new ulong[]{0x000300C000000400UL});
		public static readonly BitSet FOLLOW_throwsSpec_in_rule472 = new BitSet(new ulong[]{0x000100C000000400UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_rule475 = new BitSet(new ulong[]{0x000100C000000000UL});
		public static readonly BitSet FOLLOW_ruleScopeSpec_in_rule478 = new BitSet(new ulong[]{0x0001008000000000UL});
		public static readonly BitSet FOLLOW_ruleAction_in_rule481 = new BitSet(new ulong[]{0x0001008000000000UL});
		public static readonly BitSet FOLLOW_48_in_rule486 = new BitSet(new ulong[]{0x98180000000063C0UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_altList_in_rule488 = new BitSet(new ulong[]{0x0000000800000000UL});
		public static readonly BitSet FOLLOW_35_in_rule490 = new BitSet(new ulong[]{0x00C0000000000002UL});
		public static readonly BitSet FOLLOW_exceptionGroup_in_rule494 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_39_in_ruleAction508 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_ruleAction510 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleAction512 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_49_in_throwsSpec523 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_throwsSpec525 = new BitSet(new ulong[]{0x0004000000000002UL});
		public static readonly BitSet FOLLOW_50_in_throwsSpec529 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_throwsSpec531 = new BitSet(new ulong[]{0x0004000000000002UL});
		public static readonly BitSet FOLLOW_38_in_ruleScopeSpec545 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleScopeSpec547 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_38_in_ruleScopeSpec552 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec554 = new BitSet(new ulong[]{0x0004000800000000UL});
		public static readonly BitSet FOLLOW_50_in_ruleScopeSpec557 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec559 = new BitSet(new ulong[]{0x0004000800000000UL});
		public static readonly BitSet FOLLOW_35_in_ruleScopeSpec563 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_38_in_ruleScopeSpec568 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleScopeSpec570 = new BitSet(new ulong[]{0x0000004000000000UL});
		public static readonly BitSet FOLLOW_38_in_ruleScopeSpec574 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec576 = new BitSet(new ulong[]{0x0004000800000000UL});
		public static readonly BitSet FOLLOW_50_in_ruleScopeSpec579 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec581 = new BitSet(new ulong[]{0x0004000800000000UL});
		public static readonly BitSet FOLLOW_35_in_ruleScopeSpec585 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_51_in_block603 = new BitSet(new ulong[]{0x98390000000067C0UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_block612 = new BitSet(new ulong[]{0x0001000000000000UL});
		public static readonly BitSet FOLLOW_48_in_block616 = new BitSet(new ulong[]{0x98380000000063C0UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_alternative_in_block625 = new BitSet(new ulong[]{0x0030000000000000UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_rewrite_in_block627 = new BitSet(new ulong[]{0x0030000000000000UL});
		public static readonly BitSet FOLLOW_52_in_block631 = new BitSet(new ulong[]{0x98380000000063C0UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_alternative_in_block635 = new BitSet(new ulong[]{0x0030000000000000UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_rewrite_in_block637 = new BitSet(new ulong[]{0x0030000000000000UL});
		public static readonly BitSet FOLLOW_53_in_block652 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_alternative_in_altList678 = new BitSet(new ulong[]{0x0010000000000000UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_rewrite_in_altList680 = new BitSet(new ulong[]{0x0010000000000002UL});
		public static readonly BitSet FOLLOW_52_in_altList684 = new BitSet(new ulong[]{0x98180000000063C0UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_alternative_in_altList688 = new BitSet(new ulong[]{0x0010000000000000UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_rewrite_in_altList690 = new BitSet(new ulong[]{0x0010000000000002UL});
		public static readonly BitSet FOLLOW_element_in_alternative717 = new BitSet(new ulong[]{0x98080000000063C2UL});
		public static readonly BitSet FOLLOW_exceptionHandler_in_exceptionGroup740 = new BitSet(new ulong[]{0x00C0000000000002UL});
		public static readonly BitSet FOLLOW_finallyClause_in_exceptionGroup747 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_finallyClause_in_exceptionGroup755 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_54_in_exceptionHandler775 = new BitSet(new ulong[]{0x0000000000001000UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_exceptionHandler777 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_exceptionHandler779 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_55_in_finallyClause799 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_finallyClause801 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_elementNoOptionSpec_in_element815 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_elementNoOptionSpec826 = new BitSet(new ulong[]{0x0100002000000000UL});
		public static readonly BitSet FOLLOW_37_in_elementNoOptionSpec831 = new BitSet(new ulong[]{0x88000000000041C0UL});
		public static readonly BitSet FOLLOW_56_in_elementNoOptionSpec835 = new BitSet(new ulong[]{0x88000000000041C0UL});
		public static readonly BitSet FOLLOW_atom_in_elementNoOptionSpec838 = new BitSet(new ulong[]{0x6000020000000002UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec844 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_elementNoOptionSpec857 = new BitSet(new ulong[]{0x0100002000000000UL});
		public static readonly BitSet FOLLOW_37_in_elementNoOptionSpec862 = new BitSet(new ulong[]{0x0008000000000000UL});
		public static readonly BitSet FOLLOW_56_in_elementNoOptionSpec866 = new BitSet(new ulong[]{0x0008000000000000UL});
		public static readonly BitSet FOLLOW_block_in_elementNoOptionSpec869 = new BitSet(new ulong[]{0x6000020000000002UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec875 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_atom_in_elementNoOptionSpec888 = new BitSet(new ulong[]{0x6000020000000002UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec894 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ebnf_in_elementNoOptionSpec907 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_elementNoOptionSpec914 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMPRED_in_elementNoOptionSpec921 = new BitSet(new ulong[]{0x0200000000000002UL});
		public static readonly BitSet FOLLOW_57_in_elementNoOptionSpec925 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_treeSpec_in_elementNoOptionSpec936 = new BitSet(new ulong[]{0x6000020000000002UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec942 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_range_in_atom961 = new BitSet(new ulong[]{0x0400400000000002UL});
		public static readonly BitSet FOLLOW_58_in_atom968 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_46_in_atom972 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_terminal_in_atom987 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_notSet_in_atom995 = new BitSet(new ulong[]{0x0400400000000002UL});
		public static readonly BitSet FOLLOW_58_in_atom1002 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_46_in_atom1006 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_RULE_REF_in_atom1021 = new BitSet(new ulong[]{0x0400400000001002UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_atom1027 = new BitSet(new ulong[]{0x0400400000000002UL});
		public static readonly BitSet FOLLOW_58_in_atom1037 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_46_in_atom1041 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_59_in_notSet1059 = new BitSet(new ulong[]{0x00080000000001C0UL});
		public static readonly BitSet FOLLOW_notTerminal_in_notSet1065 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_block_in_notSet1071 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_60_in_treeSpec1086 = new BitSet(new ulong[]{0x98080000000063C0UL});
		public static readonly BitSet FOLLOW_element_in_treeSpec1088 = new BitSet(new ulong[]{0x98080000000063C0UL});
		public static readonly BitSet FOLLOW_element_in_treeSpec1092 = new BitSet(new ulong[]{0x98280000000063C0UL});
		public static readonly BitSet FOLLOW_53_in_treeSpec1097 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_block_in_ebnf1120 = new BitSet(new ulong[]{0x6200020000000002UL});
		public static readonly BitSet FOLLOW_61_in_ebnf1128 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_41_in_ebnf1136 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_62_in_ebnf1144 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_57_in_ebnf1152 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_range1181 = new BitSet(new ulong[]{0x0000000000008000UL});
		public static readonly BitSet FOLLOW_RANGE_in_range1183 = new BitSet(new ulong[]{0x0000000000000100UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_range1187 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_terminal1205 = new BitSet(new ulong[]{0x0400400000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_terminal1220 = new BitSet(new ulong[]{0x0400400000001002UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_terminal1227 = new BitSet(new ulong[]{0x0400400000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_terminal1245 = new BitSet(new ulong[]{0x0400400000000002UL});
		public static readonly BitSet FOLLOW_63_in_terminal1253 = new BitSet(new ulong[]{0x0400400000000002UL});
		public static readonly BitSet FOLLOW_set_in_terminal1262 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_notTerminal0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_ebnfSuffix0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_64_in_rewrite1354 = new BitSet(new ulong[]{0x0000000000002000UL});
		public static readonly BitSet FOLLOW_SEMPRED_in_rewrite1358 = new BitSet(new ulong[]{0x10080000000043C0UL,0x0000000000000003UL});
		public static readonly BitSet FOLLOW_rewrite_alternative_in_rewrite1362 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
		public static readonly BitSet FOLLOW_64_in_rewrite1370 = new BitSet(new ulong[]{0x10080000000043C0UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_alternative_in_rewrite1374 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_in_rewrite_alternative1395 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_rewrite_alternative1400 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_51_in_rewrite_tree_block1429 = new BitSet(new ulong[]{0x10080000000043C0UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_rewrite_tree_block1431 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_53_in_rewrite_tree_block1433 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_element_in_rewrite_tree_alternative1450 = new BitSet(new ulong[]{0x10080000000043C2UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1465 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1470 = new BitSet(new ulong[]{0x6000020000000000UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_rewrite_tree_element1472 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_in_rewrite_tree_element1479 = new BitSet(new ulong[]{0x6000020000000002UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_rewrite_tree_element1485 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_ebnf_in_rewrite_tree_element1500 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_rewrite_tree_atom1516 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_rewrite_tree_atom1523 = new BitSet(new ulong[]{0x0000000000001002UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rewrite_tree_atom1525 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_RULE_REF_in_rewrite_tree_atom1536 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_rewrite_tree_atom1543 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_65_in_rewrite_tree_atom1552 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_tree_atom1554 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_tree_atom1559 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_block_in_rewrite_tree_ebnf1580 = new BitSet(new ulong[]{0x6000020000000000UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_rewrite_tree_ebnf1582 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_60_in_rewrite_tree1594 = new BitSet(new ulong[]{0x00000000000043C0UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree1596 = new BitSet(new ulong[]{0x10280000000043C0UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_element_in_rewrite_tree1598 = new BitSet(new ulong[]{0x10280000000043C0UL,0x0000000000000002UL});
		public static readonly BitSet FOLLOW_53_in_rewrite_tree1601 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_template1619 = new BitSet(new ulong[]{0x0008000000000000UL});
		public static readonly BitSet FOLLOW_51_in_rewrite_template1623 = new BitSet(new ulong[]{0x0020000000004040UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_template1625 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_53_in_rewrite_template1627 = new BitSet(new ulong[]{0x0000000000030000UL});
		public static readonly BitSet FOLLOW_DOUBLE_QUOTE_STRING_LITERAL_in_rewrite_template1635 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOUBLE_ANGLE_STRING_LITERAL_in_rewrite_template1641 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_ref_in_rewrite_template1651 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_indirect_template_head_in_rewrite_template1660 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_template1669 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_template_ref1682 = new BitSet(new ulong[]{0x0008000000000000UL});
		public static readonly BitSet FOLLOW_51_in_rewrite_template_ref1686 = new BitSet(new ulong[]{0x0020000000004040UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_template_ref1688 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_53_in_rewrite_template_ref1690 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_51_in_rewrite_indirect_template_head1705 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_indirect_template_head1707 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_53_in_rewrite_indirect_template_head1709 = new BitSet(new ulong[]{0x0008000000000000UL});
		public static readonly BitSet FOLLOW_51_in_rewrite_indirect_template_head1711 = new BitSet(new ulong[]{0x0020000000004040UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_indirect_template_head1713 = new BitSet(new ulong[]{0x0020000000000000UL});
		public static readonly BitSet FOLLOW_53_in_rewrite_indirect_template_head1715 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_arg_in_rewrite_template_args1726 = new BitSet(new ulong[]{0x0004000000000002UL});
		public static readonly BitSet FOLLOW_50_in_rewrite_template_args1729 = new BitSet(new ulong[]{0x0000000000004040UL});
		public static readonly BitSet FOLLOW_rewrite_template_arg_in_rewrite_template_args1731 = new BitSet(new ulong[]{0x0004000000000002UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_template_arg1749 = new BitSet(new ulong[]{0x0000002000000000UL});
		public static readonly BitSet FOLLOW_37_in_rewrite_template_arg1751 = new BitSet(new ulong[]{0x0000000000000200UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_template_arg1753 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_id0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_in_synpred1_NewANTLRv31395 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_synpred2_NewANTLRv31400 = new BitSet(new ulong[]{0x0000000000000002UL});

	}
}
