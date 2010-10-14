// $ANTLR 3.2 Sep 23, 2009 12:02:23 ANTLRv3.g 2010-08-16 20:42:00

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Antlr.Runtime;
using Antlr.Runtime.Collections;
using OpenCodeProcessorFramework.Languages.Common.Antlr;
using Antlr.Runtime.Tree;

/** ANTLR v3 grammar written in ANTLR v3 with AST construction */
namespace OpenCodeProcessorFramework.Languages.Antlr
{
	public partial class ANTLRv3Parser : Parser
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
		public const int RULE = 7;
		public const int T__82 = 82;
		public const int T__83 = 83;
		public const int ACTION_ESC = 62;
		public const int PARSER_GRAMMAR = 25;
		public const int SRC = 52;
		public const int CHAR_RANGE = 14;
		public const int INT = 47;
		public const int EPSILON = 15;
		public const int T__85 = 85;
		public const int T__84 = 84;
		public const int T__87 = 87;
		public const int T__86 = 86;
		public const int T__89 = 89;
		public const int REWRITE = 40;
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



		public ANTLRv3Parser(ITokenStream input)
			: this(input, new RecognizerSharedState()) {
			}

		public ANTLRv3Parser(ITokenStream input, RecognizerSharedState state)
			: base(input, state) {
			InitializeCyclicDFAs();

             
			}

    protected OpenCodeProcessorFramework.Languages.Common.Antlr.XmlTreeAdaptor adaptor = new OpenCodeProcessorFramework.Languages.Common.Antlr.XmlTreeAdaptor(new List<XElement>(), "TOKEN"); 

   public ITreeAdaptor TreeAdaptor
   {
       get { return this.adaptor; }
       set {
        this.adaptor = (OpenCodeProcessorFramework.Languages.Common.Antlr.XmlTreeAdaptor)value;
        }
   } 

		override public string[] TokenNames {
			get { return ANTLRv3Parser.tokenNames; }
		}

		override public string GrammarFileName {
			get { return "ANTLRv3.g"; }
		}


		int gtype;


		public class grammarDef_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "grammarDef"
		// ANTLRv3.g:83:1: grammarDef : ( DOC_COMMENT )? ( 'lexer' | 'parser' | 'tree' | ) g= 'grammar' id ';' ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ EOF ;
		public ANTLRv3Parser.grammarDef_return grammarDef() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.grammarDef_return retval = new ANTLRv3Parser.grammarDef_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken g = null;
			IToken DOC_COMMENT1 = null;
			IToken string_literal2 = null;
			IToken string_literal3 = null;
			IToken string_literal4 = null;
			IToken char_literal6 = null;
			IToken EOF12 = null;
			ANTLRv3Parser.id_return id5 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.optionsSpec_return optionsSpec7 = default(ANTLRv3Parser.optionsSpec_return);

			ANTLRv3Parser.tokensSpec_return tokensSpec8 = default(ANTLRv3Parser.tokensSpec_return);

			ANTLRv3Parser.attrScope_return attrScope9 = default(ANTLRv3Parser.attrScope_return);

			ANTLRv3Parser.action_return action10 = default(ANTLRv3Parser.action_return);

			ANTLRv3Parser.rule_return rule11 = default(ANTLRv3Parser.rule_return);


			CommonTree g_tree=null;
			CommonTree DOC_COMMENT1_tree=null;
			CommonTree string_literal2_tree=null;
			CommonTree string_literal3_tree=null;
			CommonTree string_literal4_tree=null;
			CommonTree char_literal6_tree=null;
			CommonTree EOF12_tree=null;

			try 
			{
				// ANTLRv3.g:84:5: ( ( DOC_COMMENT )? ( 'lexer' | 'parser' | 'tree' | ) g= 'grammar' id ';' ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ EOF )
				// ANTLRv3.g:84:9: ( DOC_COMMENT )? ( 'lexer' | 'parser' | 'tree' | ) g= 'grammar' id ';' ( optionsSpec )? ( tokensSpec )? ( attrScope )* ( action )* ( rule )+ EOF
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// ANTLRv3.g:84:9: ( DOC_COMMENT )?
					int alt1 = 2;
					int LA1_0 = input.LA(1);

					if ( (LA1_0 == DOC_COMMENT) )
					{
						alt1 = 1;
					}
					switch (alt1) 
					{
					case 1 :
						// ANTLRv3.g:84:9: DOC_COMMENT
					{
						DOC_COMMENT1=(IToken)Match(input,DOC_COMMENT,FOLLOW_DOC_COMMENT_in_grammarDef335); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{DOC_COMMENT1_tree = (CommonTree)adaptor.Create(DOC_COMMENT1, retval);
							adaptor.AddChild(root_0, DOC_COMMENT1_tree);
						}

					}
						break;

					}

					// ANTLRv3.g:85:6: ( 'lexer' | 'parser' | 'tree' | )
					int alt2 = 4;
					switch ( input.LA(1) ) 
					{
					case 65:
					{
						alt2 = 1;
					}
						break;
					case 66:
					{
						alt2 = 2;
					}
						break;
					case 67:
					{
						alt2 = 3;
					}
						break;
					case 68:
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
						// ANTLRv3.g:85:8: 'lexer'
					{
						string_literal2=(IToken)Match(input,65,FOLLOW_65_in_grammarDef345); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal2_tree = (CommonTree)adaptor.Create(string_literal2, retval);
							adaptor.AddChild(root_0, string_literal2_tree);
						}
						if ( (state.backtracking==0) )
						{
							gtype=LEXER_GRAMMAR;
						}

					}
						break;
					case 2 :
						// ANTLRv3.g:86:10: 'parser'
					{
						string_literal3=(IToken)Match(input,66,FOLLOW_66_in_grammarDef363); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal3_tree = (CommonTree)adaptor.Create(string_literal3, retval);
							adaptor.AddChild(root_0, string_literal3_tree);
						}
						if ( (state.backtracking==0) )
						{
							gtype=PARSER_GRAMMAR;
						}

					}
						break;
					case 3 :
						// ANTLRv3.g:87:10: 'tree'
					{
						string_literal4=(IToken)Match(input,67,FOLLOW_67_in_grammarDef379); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal4_tree = (CommonTree)adaptor.Create(string_literal4, retval);
							adaptor.AddChild(root_0, string_literal4_tree);
						}
						if ( (state.backtracking==0) )
						{
							gtype=TREE_GRAMMAR;
						}

					}
						break;
					case 4 :
						// ANTLRv3.g:88:14: 
					{
						if ( (state.backtracking==0) )
						{
							gtype=COMBINED_GRAMMAR;
						}

					}
						break;

					}

					g=(IToken)Match(input,68,FOLLOW_68_in_grammarDef420); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{g_tree = (CommonTree)adaptor.Create(g, retval);
						adaptor.AddChild(root_0, g_tree);
					}
					PushFollow(FOLLOW_id_in_grammarDef422);
					id5 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id5.Tree, id5, retval);
					char_literal6=(IToken)Match(input,69,FOLLOW_69_in_grammarDef424); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal6_tree = (CommonTree)adaptor.Create(char_literal6, retval);
						adaptor.AddChild(root_0, char_literal6_tree);
					}
					// ANTLRv3.g:90:25: ( optionsSpec )?
					int alt3 = 2;
					int LA3_0 = input.LA(1);

					if ( (LA3_0 == OPTIONS) )
					{
						alt3 = 1;
					}
					switch (alt3) 
					{
					case 1 :
						// ANTLRv3.g:90:25: optionsSpec
					{
						PushFollow(FOLLOW_optionsSpec_in_grammarDef426);
						optionsSpec7 = optionsSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, optionsSpec7.Tree, optionsSpec7, retval);

					}
						break;

					}

					// ANTLRv3.g:90:38: ( tokensSpec )?
					int alt4 = 2;
					int LA4_0 = input.LA(1);

					if ( (LA4_0 == TOKENS) )
					{
						alt4 = 1;
					}
					switch (alt4) 
					{
					case 1 :
						// ANTLRv3.g:90:38: tokensSpec
					{
						PushFollow(FOLLOW_tokensSpec_in_grammarDef429);
						tokensSpec8 = tokensSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, tokensSpec8.Tree, tokensSpec8, retval);

					}
						break;

					}

					// ANTLRv3.g:90:50: ( attrScope )*
					do 
					{
						int alt5 = 2;
						int LA5_0 = input.LA(1);

						if ( (LA5_0 == SCOPE) )
						{
							alt5 = 1;
						}


						switch (alt5) 
						{
						case 1 :
							// ANTLRv3.g:90:50: attrScope
						{
							PushFollow(FOLLOW_attrScope_in_grammarDef432);
							attrScope9 = attrScope();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, attrScope9.Tree, attrScope9, retval);

						}
							break;

						default:
							goto loop5;
						}
					} while (true);

					loop5:
					;	// Stops C# compiler whining that label 'loop5' has no statements

					// ANTLRv3.g:90:61: ( action )*
					do 
					{
						int alt6 = 2;
						int LA6_0 = input.LA(1);

						if ( (LA6_0 == 72) )
						{
							alt6 = 1;
						}


						switch (alt6) 
						{
						case 1 :
							// ANTLRv3.g:90:61: action
						{
							PushFollow(FOLLOW_action_in_grammarDef435);
							action10 = action();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, action10.Tree, action10, retval);

						}
							break;

						default:
							goto loop6;
						}
					} while (true);

					loop6:
					;	// Stops C# compiler whining that label 'loop6' has no statements

					// ANTLRv3.g:91:6: ( rule )+
					int cnt7 = 0;
					do 
					{
						int alt7 = 2;
						int LA7_0 = input.LA(1);

						if ( (LA7_0 == DOC_COMMENT || LA7_0 == FRAGMENT || LA7_0 == TOKEN_REF || LA7_0 == RULE_REF || (LA7_0 >= 75 && LA7_0 <= 77)) )
						{
							alt7 = 1;
						}


						switch (alt7) 
						{
						case 1 :
							// ANTLRv3.g:91:6: rule
						{
							PushFollow(FOLLOW_rule_in_grammarDef443);
							rule11 = rule();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rule11.Tree, rule11, retval);

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

					EOF12=(IToken)Match(input,EOF,FOLLOW_EOF_in_grammarDef451); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{EOF12_tree = (CommonTree)adaptor.Create(EOF12, retval);
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

		public class tokensSpec_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "tokensSpec"
		// ANTLRv3.g:95:1: tokensSpec : TOKENS ( tokenSpec )+ '}' ;
		public ANTLRv3Parser.tokensSpec_return tokensSpec() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.tokensSpec_return retval = new ANTLRv3Parser.tokensSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken TOKENS13 = null;
			IToken char_literal15 = null;
			ANTLRv3Parser.tokenSpec_return tokenSpec14 = default(ANTLRv3Parser.tokenSpec_return);


			CommonTree TOKENS13_tree=null;
			CommonTree char_literal15_tree=null;

			try 
			{
				// ANTLRv3.g:96:2: ( TOKENS ( tokenSpec )+ '}' )
				// ANTLRv3.g:96:4: TOKENS ( tokenSpec )+ '}'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					TOKENS13=(IToken)Match(input,TOKENS,FOLLOW_TOKENS_in_tokensSpec465); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{TOKENS13_tree = (CommonTree)adaptor.Create(TOKENS13, retval);
						adaptor.AddChild(root_0, TOKENS13_tree);
					}
					// ANTLRv3.g:96:11: ( tokenSpec )+
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
							// ANTLRv3.g:96:11: tokenSpec
						{
							PushFollow(FOLLOW_tokenSpec_in_tokensSpec467);
							tokenSpec14 = tokenSpec();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, tokenSpec14.Tree, tokenSpec14, retval);

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

					char_literal15=(IToken)Match(input,70,FOLLOW_70_in_tokensSpec470); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal15_tree = (CommonTree)adaptor.Create(char_literal15, retval);
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

		public class tokenSpec_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "tokenSpec"
		// ANTLRv3.g:99:1: tokenSpec : TOKEN_REF ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | ) ';' ;
		public ANTLRv3Parser.tokenSpec_return tokenSpec() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.tokenSpec_return retval = new ANTLRv3Parser.tokenSpec_return();
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
				// ANTLRv3.g:100:2: ( TOKEN_REF ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | ) ';' )
				// ANTLRv3.g:100:4: TOKEN_REF ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | ) ';'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					TOKEN_REF16=(IToken)Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_tokenSpec481); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{TOKEN_REF16_tree = (CommonTree)adaptor.Create(TOKEN_REF16, retval);
						adaptor.AddChild(root_0, TOKEN_REF16_tree);
					}
					// ANTLRv3.g:101:3: ( '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL ) | )
					int alt10 = 2;
					int LA10_0 = input.LA(1);

					if ( (LA10_0 == 71) )
					{
						alt10 = 1;
					}
					else if ( (LA10_0 == 69) )
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
						// ANTLRv3.g:101:5: '=' (lit= STRING_LITERAL | lit= CHAR_LITERAL )
					{
						char_literal17=(IToken)Match(input,71,FOLLOW_71_in_tokenSpec487); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal17_tree = (CommonTree)adaptor.Create(char_literal17, retval);
							adaptor.AddChild(root_0, char_literal17_tree);
						}
						// ANTLRv3.g:101:9: (lit= STRING_LITERAL | lit= CHAR_LITERAL )
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
							// ANTLRv3.g:101:10: lit= STRING_LITERAL
						{
							lit=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_tokenSpec492); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{lit_tree = (CommonTree)adaptor.Create(lit, retval);
								adaptor.AddChild(root_0, lit_tree);
							}

						}
							break;
						case 2 :
							// ANTLRv3.g:101:29: lit= CHAR_LITERAL
						{
							lit=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_tokenSpec496); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{lit_tree = (CommonTree)adaptor.Create(lit, retval);
								adaptor.AddChild(root_0, lit_tree);
							}

						}
							break;

						}


					}
						break;
					case 2 :
						// ANTLRv3.g:103:3: 
					{
					}
						break;

					}

					char_literal18=(IToken)Match(input,69,FOLLOW_69_in_tokenSpec520); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal18_tree = (CommonTree)adaptor.Create(char_literal18, retval);
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

		public class attrScope_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "attrScope"
		// ANTLRv3.g:107:1: attrScope : 'scope' id ACTION ;
		public ANTLRv3Parser.attrScope_return attrScope() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.attrScope_return retval = new ANTLRv3Parser.attrScope_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal19 = null;
			IToken ACTION21 = null;
			ANTLRv3Parser.id_return id20 = default(ANTLRv3Parser.id_return);


			CommonTree string_literal19_tree=null;
			CommonTree ACTION21_tree=null;

			try 
			{
				// ANTLRv3.g:108:2: ( 'scope' id ACTION )
				// ANTLRv3.g:108:4: 'scope' id ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal19=(IToken)Match(input,SCOPE,FOLLOW_SCOPE_in_attrScope531); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal19_tree = (CommonTree)adaptor.Create(string_literal19, retval);
						adaptor.AddChild(root_0, string_literal19_tree);
					}
					PushFollow(FOLLOW_id_in_attrScope533);
					id20 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id20.Tree, id20, retval);
					ACTION21=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_attrScope535); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION21_tree = (CommonTree)adaptor.Create(ACTION21, retval);
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

		public class action_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "action"
		// ANTLRv3.g:111:1: action : '@' ( actionScopeName '::' )? id ACTION ;
		public ANTLRv3Parser.action_return action() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.action_return retval = new ANTLRv3Parser.action_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal22 = null;
			IToken string_literal24 = null;
			IToken ACTION26 = null;
			ANTLRv3Parser.actionScopeName_return actionScopeName23 = default(ANTLRv3Parser.actionScopeName_return);

			ANTLRv3Parser.id_return id25 = default(ANTLRv3Parser.id_return);


			CommonTree char_literal22_tree=null;
			CommonTree string_literal24_tree=null;
			CommonTree ACTION26_tree=null;

			try 
			{
				// ANTLRv3.g:113:2: ( '@' ( actionScopeName '::' )? id ACTION )
				// ANTLRv3.g:113:4: '@' ( actionScopeName '::' )? id ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					char_literal22=(IToken)Match(input,72,FOLLOW_72_in_action548); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal22_tree = (CommonTree)adaptor.Create(char_literal22, retval);
						adaptor.AddChild(root_0, char_literal22_tree);
					}
					// ANTLRv3.g:113:8: ( actionScopeName '::' )?
					int alt11 = 2;
					int LA11_0 = input.LA(1);

					if ( (LA11_0 == TOKEN_REF || LA11_0 == RULE_REF) )
					{
						int LA11_1 = input.LA(2);

						if ( (LA11_1 == 73) )
						{
							alt11 = 1;
						}
					}
					else if ( ((LA11_0 >= 65 && LA11_0 <= 66)) )
					{
						alt11 = 1;
					}
					switch (alt11) 
					{
					case 1 :
						// ANTLRv3.g:113:9: actionScopeName '::'
					{
						PushFollow(FOLLOW_actionScopeName_in_action551);
						actionScopeName23 = actionScopeName();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, actionScopeName23.Tree, actionScopeName23, retval);
						string_literal24=(IToken)Match(input,73,FOLLOW_73_in_action553); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal24_tree = (CommonTree)adaptor.Create(string_literal24, retval);
							adaptor.AddChild(root_0, string_literal24_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_id_in_action557);
					id25 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id25.Tree, id25, retval);
					ACTION26=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_action559); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION26_tree = (CommonTree)adaptor.Create(ACTION26, retval);
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

		public class actionScopeName_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "actionScopeName"
		// ANTLRv3.g:116:1: actionScopeName : ( id | l= 'lexer' | p= 'parser' );
		public ANTLRv3Parser.actionScopeName_return actionScopeName() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.actionScopeName_return retval = new ANTLRv3Parser.actionScopeName_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken l = null;
			IToken p = null;
			ANTLRv3Parser.id_return id27 = default(ANTLRv3Parser.id_return);


			CommonTree l_tree=null;
			CommonTree p_tree=null;

			try 
			{
				// ANTLRv3.g:120:2: ( id | l= 'lexer' | p= 'parser' )
				int alt12 = 3;
				switch ( input.LA(1) ) 
				{
				case TOKEN_REF:
				case RULE_REF:
				{
					alt12 = 1;
				}
					break;
				case 65:
				{
					alt12 = 2;
				}
					break;
				case 66:
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
					// ANTLRv3.g:120:4: id
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_actionScopeName572);
					id27 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id27.Tree, id27, retval);

				}
					break;
				case 2 :
					// ANTLRv3.g:121:4: l= 'lexer'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					l=(IToken)Match(input,65,FOLLOW_65_in_actionScopeName579); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{l_tree = (CommonTree)adaptor.Create(l, retval);
						adaptor.AddChild(root_0, l_tree);
					}

				}
					break;
				case 3 :
					// ANTLRv3.g:122:9: p= 'parser'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					p=(IToken)Match(input,66,FOLLOW_66_in_actionScopeName591); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{p_tree = (CommonTree)adaptor.Create(p, retval);
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

		public class optionsSpec_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "optionsSpec"
		// ANTLRv3.g:125:1: optionsSpec : OPTIONS ( option ';' )+ '}' ;
		public ANTLRv3Parser.optionsSpec_return optionsSpec() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.optionsSpec_return retval = new ANTLRv3Parser.optionsSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken OPTIONS28 = null;
			IToken char_literal30 = null;
			IToken char_literal31 = null;
			ANTLRv3Parser.option_return option29 = default(ANTLRv3Parser.option_return);


			CommonTree OPTIONS28_tree=null;
			CommonTree char_literal30_tree=null;
			CommonTree char_literal31_tree=null;

			try 
			{
				// ANTLRv3.g:126:2: ( OPTIONS ( option ';' )+ '}' )
				// ANTLRv3.g:126:4: OPTIONS ( option ';' )+ '}'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					OPTIONS28=(IToken)Match(input,OPTIONS,FOLLOW_OPTIONS_in_optionsSpec602); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{OPTIONS28_tree = (CommonTree)adaptor.Create(OPTIONS28, retval);
						adaptor.AddChild(root_0, OPTIONS28_tree);
					}
					// ANTLRv3.g:126:12: ( option ';' )+
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
							// ANTLRv3.g:126:13: option ';'
						{
							PushFollow(FOLLOW_option_in_optionsSpec605);
							option29 = option();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, option29.Tree, option29, retval);
							char_literal30=(IToken)Match(input,69,FOLLOW_69_in_optionsSpec607); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal30_tree = (CommonTree)adaptor.Create(char_literal30, retval);
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

					char_literal31=(IToken)Match(input,70,FOLLOW_70_in_optionsSpec611); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal31_tree = (CommonTree)adaptor.Create(char_literal31, retval);
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

		public class option_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "option"
		// ANTLRv3.g:129:1: option : id '=' optionValue ;
		public ANTLRv3Parser.option_return option() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.option_return retval = new ANTLRv3Parser.option_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal33 = null;
			ANTLRv3Parser.id_return id32 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.optionValue_return optionValue34 = default(ANTLRv3Parser.optionValue_return);


			CommonTree char_literal33_tree=null;

			try 
			{
				// ANTLRv3.g:130:5: ( id '=' optionValue )
				// ANTLRv3.g:130:9: id '=' optionValue
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_option627);
					id32 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id32.Tree, id32, retval);
					char_literal33=(IToken)Match(input,71,FOLLOW_71_in_option629); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal33_tree = (CommonTree)adaptor.Create(char_literal33, retval);
						adaptor.AddChild(root_0, char_literal33_tree);
					}
					PushFollow(FOLLOW_optionValue_in_option631);
					optionValue34 = optionValue();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, optionValue34.Tree, optionValue34, retval);

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

		public class optionValue_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "optionValue"
		// ANTLRv3.g:133:1: optionValue : ( id | STRING_LITERAL | CHAR_LITERAL | INT | s= '*' );
		public ANTLRv3Parser.optionValue_return optionValue() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.optionValue_return retval = new ANTLRv3Parser.optionValue_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken s = null;
			IToken STRING_LITERAL36 = null;
			IToken CHAR_LITERAL37 = null;
			IToken INT38 = null;
			ANTLRv3Parser.id_return id35 = default(ANTLRv3Parser.id_return);


			CommonTree s_tree=null;
			CommonTree STRING_LITERAL36_tree=null;
			CommonTree CHAR_LITERAL37_tree=null;
			CommonTree INT38_tree=null;

			try 
			{
				// ANTLRv3.g:134:5: ( id | STRING_LITERAL | CHAR_LITERAL | INT | s= '*' )
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
				case 74:
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
					// ANTLRv3.g:134:9: id
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_optionValue650);
					id35 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id35.Tree, id35, retval);

				}
					break;
				case 2 :
					// ANTLRv3.g:135:9: STRING_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					STRING_LITERAL36=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_optionValue660); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{STRING_LITERAL36_tree = (CommonTree)adaptor.Create(STRING_LITERAL36, retval);
						adaptor.AddChild(root_0, STRING_LITERAL36_tree);
					}

				}
					break;
				case 3 :
					// ANTLRv3.g:136:9: CHAR_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					CHAR_LITERAL37=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_optionValue670); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{CHAR_LITERAL37_tree = (CommonTree)adaptor.Create(CHAR_LITERAL37, retval);
						adaptor.AddChild(root_0, CHAR_LITERAL37_tree);
					}

				}
					break;
				case 4 :
					// ANTLRv3.g:137:9: INT
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					INT38=(IToken)Match(input,INT,FOLLOW_INT_in_optionValue680); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{INT38_tree = (CommonTree)adaptor.Create(INT38, retval);
						adaptor.AddChild(root_0, INT38_tree);
					}

				}
					break;
				case 5 :
					// ANTLRv3.g:138:7: s= '*'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					s=(IToken)Match(input,74,FOLLOW_74_in_optionValue690); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{s_tree = (CommonTree)adaptor.Create(s, retval);
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

		public class rule_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rule"
		// ANTLRv3.g:141:1: rule : ( DOC_COMMENT )? (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )? id ( '!' )? (arg= ARG_ACTION )? ( 'returns' rt= ARG_ACTION )? ( throwsSpec )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* ':' altList ';' ( exceptionGroup )? ;
		public ANTLRv3Parser.rule_return rule() // throws RecognitionException [1]
		{   
			rule_stack.Push(new rule_scope());
			ANTLRv3Parser.rule_return retval = new ANTLRv3Parser.rule_return();
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
			ANTLRv3Parser.id_return id40 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.throwsSpec_return throwsSpec43 = default(ANTLRv3Parser.throwsSpec_return);

			ANTLRv3Parser.optionsSpec_return optionsSpec44 = default(ANTLRv3Parser.optionsSpec_return);

			ANTLRv3Parser.ruleScopeSpec_return ruleScopeSpec45 = default(ANTLRv3Parser.ruleScopeSpec_return);

			ANTLRv3Parser.ruleAction_return ruleAction46 = default(ANTLRv3Parser.ruleAction_return);

			ANTLRv3Parser.altList_return altList48 = default(ANTLRv3Parser.altList_return);

			ANTLRv3Parser.exceptionGroup_return exceptionGroup50 = default(ANTLRv3Parser.exceptionGroup_return);


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
				// ANTLRv3.g:145:2: ( ( DOC_COMMENT )? (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )? id ( '!' )? (arg= ARG_ACTION )? ( 'returns' rt= ARG_ACTION )? ( throwsSpec )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* ':' altList ';' ( exceptionGroup )? )
				// ANTLRv3.g:145:4: ( DOC_COMMENT )? (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )? id ( '!' )? (arg= ARG_ACTION )? ( 'returns' rt= ARG_ACTION )? ( throwsSpec )? ( optionsSpec )? ( ruleScopeSpec )? ( ruleAction )* ':' altList ';' ( exceptionGroup )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// ANTLRv3.g:145:4: ( DOC_COMMENT )?
					int alt15 = 2;
					int LA15_0 = input.LA(1);

					if ( (LA15_0 == DOC_COMMENT) )
					{
						alt15 = 1;
					}
					switch (alt15) 
					{
					case 1 :
						// ANTLRv3.g:145:4: DOC_COMMENT
					{
						DOC_COMMENT39=(IToken)Match(input,DOC_COMMENT,FOLLOW_DOC_COMMENT_in_rule710); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{DOC_COMMENT39_tree = (CommonTree)adaptor.Create(DOC_COMMENT39, retval);
							adaptor.AddChild(root_0, DOC_COMMENT39_tree);
						}

					}
						break;

					}

					// ANTLRv3.g:146:3: (modifier= ( 'protected' | 'public' | 'private' | 'fragment' ) )?
					int alt16 = 2;
					int LA16_0 = input.LA(1);

					if ( (LA16_0 == FRAGMENT || (LA16_0 >= 75 && LA16_0 <= 77)) )
					{
						alt16 = 1;
					}
					switch (alt16) 
					{
					case 1 :
						// ANTLRv3.g:146:5: modifier= ( 'protected' | 'public' | 'private' | 'fragment' )
					{
						modifier = (IToken)input.LT(1);
						if ( input.LA(1) == FRAGMENT || (input.LA(1) >= 75 && input.LA(1) <= 77) ) 
						{
							input.Consume();
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(modifier, retval));
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

					PushFollow(FOLLOW_id_in_rule734);
					id40 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id40.Tree, id40, retval);
					if ( (state.backtracking==0) )
					{
						((rule_scope)rule_stack.Peek()).name =  ((id40 != null) ? input.ToString((IToken)(id40.Start),(IToken)(id40.Stop)) : null);
					}
					// ANTLRv3.g:148:3: ( '!' )?
					int alt17 = 2;
					int LA17_0 = input.LA(1);

					if ( (LA17_0 == BANG) )
					{
						alt17 = 1;
					}
					switch (alt17) 
					{
					case 1 :
						// ANTLRv3.g:148:3: '!'
					{
						char_literal41=(IToken)Match(input,BANG,FOLLOW_BANG_in_rule740); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal41_tree = (CommonTree)adaptor.Create(char_literal41, retval);
							adaptor.AddChild(root_0, char_literal41_tree);
						}

					}
						break;

					}

					// ANTLRv3.g:149:3: (arg= ARG_ACTION )?
					int alt18 = 2;
					int LA18_0 = input.LA(1);

					if ( (LA18_0 == ARG_ACTION) )
					{
						alt18 = 1;
					}
					switch (alt18) 
					{
					case 1 :
						// ANTLRv3.g:149:5: arg= ARG_ACTION
					{
						arg=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rule749); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{arg_tree = (CommonTree)adaptor.Create(arg, retval);
							adaptor.AddChild(root_0, arg_tree);
						}

					}
						break;

					}

					// ANTLRv3.g:150:3: ( 'returns' rt= ARG_ACTION )?
					int alt19 = 2;
					int LA19_0 = input.LA(1);

					if ( (LA19_0 == 78) )
					{
						alt19 = 1;
					}
					switch (alt19) 
					{
					case 1 :
						// ANTLRv3.g:150:5: 'returns' rt= ARG_ACTION
					{
						string_literal42=(IToken)Match(input,78,FOLLOW_78_in_rule758); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal42_tree = (CommonTree)adaptor.Create(string_literal42, retval);
							adaptor.AddChild(root_0, string_literal42_tree);
						}
						rt=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rule762); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{rt_tree = (CommonTree)adaptor.Create(rt, retval);
							adaptor.AddChild(root_0, rt_tree);
						}

					}
						break;

					}

					// ANTLRv3.g:151:3: ( throwsSpec )?
					int alt20 = 2;
					int LA20_0 = input.LA(1);

					if ( (LA20_0 == 80) )
					{
						alt20 = 1;
					}
					switch (alt20) 
					{
					case 1 :
						// ANTLRv3.g:151:3: throwsSpec
					{
						PushFollow(FOLLOW_throwsSpec_in_rule770);
						throwsSpec43 = throwsSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, throwsSpec43.Tree, throwsSpec43, retval);

					}
						break;

					}

					// ANTLRv3.g:151:15: ( optionsSpec )?
					int alt21 = 2;
					int LA21_0 = input.LA(1);

					if ( (LA21_0 == OPTIONS) )
					{
						alt21 = 1;
					}
					switch (alt21) 
					{
					case 1 :
						// ANTLRv3.g:151:15: optionsSpec
					{
						PushFollow(FOLLOW_optionsSpec_in_rule773);
						optionsSpec44 = optionsSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, optionsSpec44.Tree, optionsSpec44, retval);

					}
						break;

					}

					// ANTLRv3.g:151:28: ( ruleScopeSpec )?
					int alt22 = 2;
					int LA22_0 = input.LA(1);

					if ( (LA22_0 == SCOPE) )
					{
						alt22 = 1;
					}
					switch (alt22) 
					{
					case 1 :
						// ANTLRv3.g:151:28: ruleScopeSpec
					{
						PushFollow(FOLLOW_ruleScopeSpec_in_rule776);
						ruleScopeSpec45 = ruleScopeSpec();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ruleScopeSpec45.Tree, ruleScopeSpec45, retval);

					}
						break;

					}

					// ANTLRv3.g:151:43: ( ruleAction )*
					do 
					{
						int alt23 = 2;
						int LA23_0 = input.LA(1);

						if ( (LA23_0 == 72) )
						{
							alt23 = 1;
						}


						switch (alt23) 
						{
						case 1 :
							// ANTLRv3.g:151:43: ruleAction
						{
							PushFollow(FOLLOW_ruleAction_in_rule779);
							ruleAction46 = ruleAction();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ruleAction46.Tree, ruleAction46, retval);

						}
							break;

						default:
							goto loop23;
						}
					} while (true);

					loop23:
					;	// Stops C# compiler whining that label 'loop23' has no statements

					char_literal47=(IToken)Match(input,79,FOLLOW_79_in_rule784); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal47_tree = (CommonTree)adaptor.Create(char_literal47, retval);
						adaptor.AddChild(root_0, char_literal47_tree);
					}
					PushFollow(FOLLOW_altList_in_rule786);
					altList48 = altList();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, altList48.Tree, altList48, retval);
					char_literal49=(IToken)Match(input,69,FOLLOW_69_in_rule788); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal49_tree = (CommonTree)adaptor.Create(char_literal49, retval);
						adaptor.AddChild(root_0, char_literal49_tree);
					}
					// ANTLRv3.g:153:3: ( exceptionGroup )?
					int alt24 = 2;
					int LA24_0 = input.LA(1);

					if ( ((LA24_0 >= 85 && LA24_0 <= 86)) )
					{
						alt24 = 1;
					}
					switch (alt24) 
					{
					case 1 :
						// ANTLRv3.g:153:3: exceptionGroup
					{
						PushFollow(FOLLOW_exceptionGroup_in_rule792);
						exceptionGroup50 = exceptionGroup();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exceptionGroup50.Tree, exceptionGroup50, retval);

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

		public class ruleAction_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ruleAction"
		// ANTLRv3.g:156:1: ruleAction : '@' id ACTION ;
		public ANTLRv3Parser.ruleAction_return ruleAction() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.ruleAction_return retval = new ANTLRv3Parser.ruleAction_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal51 = null;
			IToken ACTION53 = null;
			ANTLRv3Parser.id_return id52 = default(ANTLRv3Parser.id_return);


			CommonTree char_literal51_tree=null;
			CommonTree ACTION53_tree=null;

			try 
			{
				// ANTLRv3.g:158:2: ( '@' id ACTION )
				// ANTLRv3.g:158:4: '@' id ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					char_literal51=(IToken)Match(input,72,FOLLOW_72_in_ruleAction806); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal51_tree = (CommonTree)adaptor.Create(char_literal51, retval);
						adaptor.AddChild(root_0, char_literal51_tree);
					}
					PushFollow(FOLLOW_id_in_ruleAction808);
					id52 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id52.Tree, id52, retval);
					ACTION53=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_ruleAction810); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION53_tree = (CommonTree)adaptor.Create(ACTION53, retval);
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

		public class throwsSpec_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "throwsSpec"
		// ANTLRv3.g:161:1: throwsSpec : 'throws' id ( ',' id )* ;
		public ANTLRv3Parser.throwsSpec_return throwsSpec() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.throwsSpec_return retval = new ANTLRv3Parser.throwsSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal54 = null;
			IToken char_literal56 = null;
			ANTLRv3Parser.id_return id55 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.id_return id57 = default(ANTLRv3Parser.id_return);


			CommonTree string_literal54_tree=null;
			CommonTree char_literal56_tree=null;

			try 
			{
				// ANTLRv3.g:162:2: ( 'throws' id ( ',' id )* )
				// ANTLRv3.g:162:4: 'throws' id ( ',' id )*
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal54=(IToken)Match(input,80,FOLLOW_80_in_throwsSpec821); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal54_tree = (CommonTree)adaptor.Create(string_literal54, retval);
						adaptor.AddChild(root_0, string_literal54_tree);
					}
					PushFollow(FOLLOW_id_in_throwsSpec823);
					id55 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id55.Tree, id55, retval);
					// ANTLRv3.g:162:16: ( ',' id )*
					do 
					{
						int alt25 = 2;
						int LA25_0 = input.LA(1);

						if ( (LA25_0 == 81) )
						{
							alt25 = 1;
						}


						switch (alt25) 
						{
						case 1 :
							// ANTLRv3.g:162:18: ',' id
						{
							char_literal56=(IToken)Match(input,81,FOLLOW_81_in_throwsSpec827); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal56_tree = (CommonTree)adaptor.Create(char_literal56, retval);
								adaptor.AddChild(root_0, char_literal56_tree);
							}
							PushFollow(FOLLOW_id_in_throwsSpec829);
							id57 = id();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id57.Tree, id57, retval);

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

		public class ruleScopeSpec_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ruleScopeSpec"
		// ANTLRv3.g:165:1: ruleScopeSpec : ( 'scope' ACTION | 'scope' id ( ',' id )* ';' | 'scope' ACTION 'scope' id ( ',' id )* ';' );
		public ANTLRv3Parser.ruleScopeSpec_return ruleScopeSpec() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.ruleScopeSpec_return retval = new ANTLRv3Parser.ruleScopeSpec_return();
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
			ANTLRv3Parser.id_return id61 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.id_return id63 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.id_return id68 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.id_return id70 = default(ANTLRv3Parser.id_return);


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
				// ANTLRv3.g:166:2: ( 'scope' ACTION | 'scope' id ( ',' id )* ';' | 'scope' ACTION 'scope' id ( ',' id )* ';' )
				int alt28 = 3;
				int LA28_0 = input.LA(1);

				if ( (LA28_0 == SCOPE) )
				{
					int LA28_1 = input.LA(2);

					if ( (LA28_1 == ACTION) )
					{
						int LA28_2 = input.LA(3);

						if ( (LA28_2 == SCOPE) )
						{
							alt28 = 3;
						}
						else if ( (LA28_2 == 72 || LA28_2 == 79) )
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
					// ANTLRv3.g:166:4: 'scope' ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal58=(IToken)Match(input,SCOPE,FOLLOW_SCOPE_in_ruleScopeSpec843); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal58_tree = (CommonTree)adaptor.Create(string_literal58, retval);
						adaptor.AddChild(root_0, string_literal58_tree);
					}
					ACTION59=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_ruleScopeSpec845); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION59_tree = (CommonTree)adaptor.Create(ACTION59, retval);
						adaptor.AddChild(root_0, ACTION59_tree);
					}

				}
					break;
				case 2 :
					// ANTLRv3.g:167:4: 'scope' id ( ',' id )* ';'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal60=(IToken)Match(input,SCOPE,FOLLOW_SCOPE_in_ruleScopeSpec850); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal60_tree = (CommonTree)adaptor.Create(string_literal60, retval);
						adaptor.AddChild(root_0, string_literal60_tree);
					}
					PushFollow(FOLLOW_id_in_ruleScopeSpec852);
					id61 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id61.Tree, id61, retval);
					// ANTLRv3.g:167:15: ( ',' id )*
					do 
					{
						int alt26 = 2;
						int LA26_0 = input.LA(1);

						if ( (LA26_0 == 81) )
						{
							alt26 = 1;
						}


						switch (alt26) 
						{
						case 1 :
							// ANTLRv3.g:167:16: ',' id
						{
							char_literal62=(IToken)Match(input,81,FOLLOW_81_in_ruleScopeSpec855); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal62_tree = (CommonTree)adaptor.Create(char_literal62, retval);
								adaptor.AddChild(root_0, char_literal62_tree);
							}
							PushFollow(FOLLOW_id_in_ruleScopeSpec857);
							id63 = id();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id63.Tree, id63, retval);

						}
							break;

						default:
							goto loop26;
						}
					} while (true);

					loop26:
					;	// Stops C# compiler whining that label 'loop26' has no statements

					char_literal64=(IToken)Match(input,69,FOLLOW_69_in_ruleScopeSpec861); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal64_tree = (CommonTree)adaptor.Create(char_literal64, retval);
						adaptor.AddChild(root_0, char_literal64_tree);
					}

				}
					break;
				case 3 :
					// ANTLRv3.g:168:4: 'scope' ACTION 'scope' id ( ',' id )* ';'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal65=(IToken)Match(input,SCOPE,FOLLOW_SCOPE_in_ruleScopeSpec866); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal65_tree = (CommonTree)adaptor.Create(string_literal65, retval);
						adaptor.AddChild(root_0, string_literal65_tree);
					}
					ACTION66=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_ruleScopeSpec868); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION66_tree = (CommonTree)adaptor.Create(ACTION66, retval);
						adaptor.AddChild(root_0, ACTION66_tree);
					}
					string_literal67=(IToken)Match(input,SCOPE,FOLLOW_SCOPE_in_ruleScopeSpec872); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal67_tree = (CommonTree)adaptor.Create(string_literal67, retval);
						adaptor.AddChild(root_0, string_literal67_tree);
					}
					PushFollow(FOLLOW_id_in_ruleScopeSpec874);
					id68 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id68.Tree, id68, retval);
					// ANTLRv3.g:169:14: ( ',' id )*
					do 
					{
						int alt27 = 2;
						int LA27_0 = input.LA(1);

						if ( (LA27_0 == 81) )
						{
							alt27 = 1;
						}


						switch (alt27) 
						{
						case 1 :
							// ANTLRv3.g:169:15: ',' id
						{
							char_literal69=(IToken)Match(input,81,FOLLOW_81_in_ruleScopeSpec877); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal69_tree = (CommonTree)adaptor.Create(char_literal69, retval);
								adaptor.AddChild(root_0, char_literal69_tree);
							}
							PushFollow(FOLLOW_id_in_ruleScopeSpec879);
							id70 = id();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id70.Tree, id70, retval);

						}
							break;

						default:
							goto loop27;
						}
					} while (true);

					loop27:
					;	// Stops C# compiler whining that label 'loop27' has no statements

					char_literal71=(IToken)Match(input,69,FOLLOW_69_in_ruleScopeSpec883); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal71_tree = (CommonTree)adaptor.Create(char_literal71, retval);
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

		public class block_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "block"
		// ANTLRv3.g:172:1: block : lp= '(' ( (opts= optionsSpec )? ':' )? a1= alternative rewrite ( '|' a2= alternative rewrite )* rp= ')' ;
		public ANTLRv3Parser.block_return block() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.block_return retval = new ANTLRv3Parser.block_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken rp = null;
			IToken char_literal72 = null;
			IToken char_literal74 = null;
			ANTLRv3Parser.optionsSpec_return opts = default(ANTLRv3Parser.optionsSpec_return);

			ANTLRv3Parser.alternative_return a1 = default(ANTLRv3Parser.alternative_return);

			ANTLRv3Parser.alternative_return a2 = default(ANTLRv3Parser.alternative_return);

			ANTLRv3Parser.rewrite_return rewrite73 = default(ANTLRv3Parser.rewrite_return);

			ANTLRv3Parser.rewrite_return rewrite75 = default(ANTLRv3Parser.rewrite_return);


			CommonTree lp_tree=null;
			CommonTree rp_tree=null;
			CommonTree char_literal72_tree=null;
			CommonTree char_literal74_tree=null;

			try 
			{
				// ANTLRv3.g:173:5: (lp= '(' ( (opts= optionsSpec )? ':' )? a1= alternative rewrite ( '|' a2= alternative rewrite )* rp= ')' )
				// ANTLRv3.g:173:9: lp= '(' ( (opts= optionsSpec )? ':' )? a1= alternative rewrite ( '|' a2= alternative rewrite )* rp= ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					lp=(IToken)Match(input,82,FOLLOW_82_in_block901); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp, retval);
						adaptor.AddChild(root_0, lp_tree);
					}
					// ANTLRv3.g:174:3: ( (opts= optionsSpec )? ':' )?
					int alt30 = 2;
					int LA30_0 = input.LA(1);

					if ( (LA30_0 == OPTIONS || LA30_0 == 79) )
					{
						alt30 = 1;
					}
					switch (alt30) 
					{
					case 1 :
						// ANTLRv3.g:174:5: (opts= optionsSpec )? ':'
					{
						// ANTLRv3.g:174:5: (opts= optionsSpec )?
						int alt29 = 2;
						int LA29_0 = input.LA(1);

						if ( (LA29_0 == OPTIONS) )
						{
							alt29 = 1;
						}
						switch (alt29) 
						{
						case 1 :
							// ANTLRv3.g:174:6: opts= optionsSpec
						{
							PushFollow(FOLLOW_optionsSpec_in_block910);
							opts = optionsSpec();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, opts.Tree, opts, retval);

						}
							break;

						}

						char_literal72=(IToken)Match(input,79,FOLLOW_79_in_block914); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal72_tree = (CommonTree)adaptor.Create(char_literal72, retval);
							adaptor.AddChild(root_0, char_literal72_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_alternative_in_block923);
					a1 = alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a1.Tree, a1, retval);
					PushFollow(FOLLOW_rewrite_in_block925);
					rewrite73 = rewrite();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite73.Tree, rewrite73, retval);
					// ANTLRv3.g:175:26: ( '|' a2= alternative rewrite )*
					do 
					{
						int alt31 = 2;
						int LA31_0 = input.LA(1);

						if ( (LA31_0 == 83) )
						{
							alt31 = 1;
						}


						switch (alt31) 
						{
						case 1 :
							// ANTLRv3.g:175:28: '|' a2= alternative rewrite
						{
							char_literal74=(IToken)Match(input,83,FOLLOW_83_in_block929); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal74_tree = (CommonTree)adaptor.Create(char_literal74, retval);
								adaptor.AddChild(root_0, char_literal74_tree);
							}
							PushFollow(FOLLOW_alternative_in_block933);
							a2 = alternative();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a2.Tree, a2, retval);
							PushFollow(FOLLOW_rewrite_in_block935);
							rewrite75 = rewrite();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite75.Tree, rewrite75, retval);

						}
							break;

						default:
							goto loop31;
						}
					} while (true);

					loop31:
					;	// Stops C# compiler whining that label 'loop31' has no statements

					rp=(IToken)Match(input,84,FOLLOW_84_in_block950); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{rp_tree = (CommonTree)adaptor.Create(rp, retval);
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

		public class altList_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "altList"
		// ANTLRv3.g:179:1: altList : a1= alternative rewrite ( '|' a2= alternative rewrite )* ;
		public ANTLRv3Parser.altList_return altList() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.altList_return retval = new ANTLRv3Parser.altList_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal77 = null;
			ANTLRv3Parser.alternative_return a1 = default(ANTLRv3Parser.alternative_return);

			ANTLRv3Parser.alternative_return a2 = default(ANTLRv3Parser.alternative_return);

			ANTLRv3Parser.rewrite_return rewrite76 = default(ANTLRv3Parser.rewrite_return);

			ANTLRv3Parser.rewrite_return rewrite78 = default(ANTLRv3Parser.rewrite_return);


			CommonTree char_literal77_tree=null;


			// must create root manually as it's used by invoked rules in real antlr tool.
			// leave here to demonstrate use of {...} in rewrite rule
			// it's really BLOCK[firstToken,"BLOCK"]; set line/col to previous ( or : token.
			CommonTree blkRoot = (CommonTree)adaptor.Create(BLOCK,input.LT(-1),"BLOCK");

			try 
			{
				// ANTLRv3.g:186:5: (a1= alternative rewrite ( '|' a2= alternative rewrite )* )
				// ANTLRv3.g:186:9: a1= alternative rewrite ( '|' a2= alternative rewrite )*
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_alternative_in_altList976);
					a1 = alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a1.Tree, a1, retval);
					PushFollow(FOLLOW_rewrite_in_altList978);
					rewrite76 = rewrite();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite76.Tree, rewrite76, retval);
					// ANTLRv3.g:186:32: ( '|' a2= alternative rewrite )*
					do 
					{
						int alt32 = 2;
						int LA32_0 = input.LA(1);

						if ( (LA32_0 == 83) )
						{
							alt32 = 1;
						}


						switch (alt32) 
						{
						case 1 :
							// ANTLRv3.g:186:34: '|' a2= alternative rewrite
						{
							char_literal77=(IToken)Match(input,83,FOLLOW_83_in_altList982); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal77_tree = (CommonTree)adaptor.Create(char_literal77, retval);
								adaptor.AddChild(root_0, char_literal77_tree);
							}
							PushFollow(FOLLOW_alternative_in_altList986);
							a2 = alternative();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, a2.Tree, a2, retval);
							PushFollow(FOLLOW_rewrite_in_altList988);
							rewrite78 = rewrite();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite78.Tree, rewrite78, retval);

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

		public class alternative_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "alternative"
		// ANTLRv3.g:189:1: alternative : ( ( element )+ | );
		public ANTLRv3Parser.alternative_return alternative() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.alternative_return retval = new ANTLRv3Parser.alternative_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			ANTLRv3Parser.element_return element79 = default(ANTLRv3Parser.element_return);




			var firstToken = input.LT(1);
			var prevToken = input.LT(-1); // either : or | I think

			try 
			{
				// ANTLRv3.g:194:5: ( ( element )+ | )
				int alt34 = 2;
				int LA34_0 = input.LA(1);

				if ( (LA34_0 == SEMPRED || LA34_0 == TREE_BEGIN || (LA34_0 >= TOKEN_REF && LA34_0 <= ACTION) || LA34_0 == RULE_REF || LA34_0 == 82 || LA34_0 == 89 || LA34_0 == 92) )
				{
					alt34 = 1;
				}
				else if ( (LA34_0 == REWRITE || LA34_0 == 69 || (LA34_0 >= 83 && LA34_0 <= 84)) )
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
					// ANTLRv3.g:194:9: ( element )+
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// ANTLRv3.g:194:9: ( element )+
					int cnt33 = 0;
					do 
					{
						int alt33 = 2;
						int LA33_0 = input.LA(1);

						if ( (LA33_0 == SEMPRED || LA33_0 == TREE_BEGIN || (LA33_0 >= TOKEN_REF && LA33_0 <= ACTION) || LA33_0 == RULE_REF || LA33_0 == 82 || LA33_0 == 89 || LA33_0 == 92) )
						{
							alt33 = 1;
						}


						switch (alt33) 
						{
						case 1 :
							// ANTLRv3.g:194:9: element
						{
							PushFollow(FOLLOW_element_in_alternative1015);
							element79 = element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, element79.Tree, element79, retval);

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
					// ANTLRv3.g:196:5: 
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

		public class exceptionGroup_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "exceptionGroup"
		// ANTLRv3.g:198:1: exceptionGroup : ( ( exceptionHandler )+ ( finallyClause )? | finallyClause );
		public ANTLRv3Parser.exceptionGroup_return exceptionGroup() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.exceptionGroup_return retval = new ANTLRv3Parser.exceptionGroup_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			ANTLRv3Parser.exceptionHandler_return exceptionHandler80 = default(ANTLRv3Parser.exceptionHandler_return);

			ANTLRv3Parser.finallyClause_return finallyClause81 = default(ANTLRv3Parser.finallyClause_return);

			ANTLRv3Parser.finallyClause_return finallyClause82 = default(ANTLRv3Parser.finallyClause_return);



			try 
			{
				// ANTLRv3.g:199:2: ( ( exceptionHandler )+ ( finallyClause )? | finallyClause )
				int alt37 = 2;
				int LA37_0 = input.LA(1);

				if ( (LA37_0 == 85) )
				{
					alt37 = 1;
				}
				else if ( (LA37_0 == 86) )
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
					// ANTLRv3.g:199:4: ( exceptionHandler )+ ( finallyClause )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// ANTLRv3.g:199:4: ( exceptionHandler )+
					int cnt35 = 0;
					do 
					{
						int alt35 = 2;
						int LA35_0 = input.LA(1);

						if ( (LA35_0 == 85) )
						{
							alt35 = 1;
						}


						switch (alt35) 
						{
						case 1 :
							// ANTLRv3.g:199:6: exceptionHandler
						{
							PushFollow(FOLLOW_exceptionHandler_in_exceptionGroup1041);
							exceptionHandler80 = exceptionHandler();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exceptionHandler80.Tree, exceptionHandler80, retval);

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

					// ANTLRv3.g:199:26: ( finallyClause )?
					int alt36 = 2;
					int LA36_0 = input.LA(1);

					if ( (LA36_0 == 86) )
					{
						alt36 = 1;
					}
					switch (alt36) 
					{
					case 1 :
						// ANTLRv3.g:199:28: finallyClause
					{
						PushFollow(FOLLOW_finallyClause_in_exceptionGroup1048);
						finallyClause81 = finallyClause();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause81.Tree, finallyClause81, retval);

					}
						break;

					}


				}
					break;
				case 2 :
					// ANTLRv3.g:200:4: finallyClause
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_finallyClause_in_exceptionGroup1056);
					finallyClause82 = finallyClause();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause82.Tree, finallyClause82, retval);

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

		public class exceptionHandler_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "exceptionHandler"
		// ANTLRv3.g:203:1: exceptionHandler : 'catch' ARG_ACTION ACTION ;
		public ANTLRv3Parser.exceptionHandler_return exceptionHandler() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.exceptionHandler_return retval = new ANTLRv3Parser.exceptionHandler_return();
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
				// ANTLRv3.g:204:5: ( 'catch' ARG_ACTION ACTION )
				// ANTLRv3.g:204:10: 'catch' ARG_ACTION ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal83=(IToken)Match(input,85,FOLLOW_85_in_exceptionHandler1076); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal83_tree = (CommonTree)adaptor.Create(string_literal83, retval);
						adaptor.AddChild(root_0, string_literal83_tree);
					}
					ARG_ACTION84=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_exceptionHandler1078); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ARG_ACTION84_tree = (CommonTree)adaptor.Create(ARG_ACTION84, retval);
						adaptor.AddChild(root_0, ARG_ACTION84_tree);
					}
					ACTION85=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_exceptionHandler1080); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION85_tree = (CommonTree)adaptor.Create(ACTION85, retval);
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

		public class finallyClause_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "finallyClause"
		// ANTLRv3.g:207:1: finallyClause : 'finally' ACTION ;
		public ANTLRv3Parser.finallyClause_return finallyClause() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.finallyClause_return retval = new ANTLRv3Parser.finallyClause_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal86 = null;
			IToken ACTION87 = null;

			CommonTree string_literal86_tree=null;
			CommonTree ACTION87_tree=null;

			try 
			{
				// ANTLRv3.g:208:5: ( 'finally' ACTION )
				// ANTLRv3.g:208:10: 'finally' ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal86=(IToken)Match(input,86,FOLLOW_86_in_finallyClause1100); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal86_tree = (CommonTree)adaptor.Create(string_literal86, retval);
						adaptor.AddChild(root_0, string_literal86_tree);
					}
					ACTION87=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_finallyClause1102); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION87_tree = (CommonTree)adaptor.Create(ACTION87, retval);
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

		public class element_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "element"
		// ANTLRv3.g:211:1: element : elementNoOptionSpec ;
		public ANTLRv3Parser.element_return element() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.element_return retval = new ANTLRv3Parser.element_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			ANTLRv3Parser.elementNoOptionSpec_return elementNoOptionSpec88 = default(ANTLRv3Parser.elementNoOptionSpec_return);



			try 
			{
				// ANTLRv3.g:212:2: ( elementNoOptionSpec )
				// ANTLRv3.g:212:4: elementNoOptionSpec
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_elementNoOptionSpec_in_element1116);
					elementNoOptionSpec88 = elementNoOptionSpec();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, elementNoOptionSpec88.Tree, elementNoOptionSpec88, retval);

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

		public class elementNoOptionSpec_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "elementNoOptionSpec"
		// ANTLRv3.g:215:1: elementNoOptionSpec : ( id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | ) | id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | ) | atom ( ebnfSuffix | ) | ebnf | ACTION | SEMPRED ( '=>' | ) | treeSpec ( ebnfSuffix | ) );
		public ANTLRv3Parser.elementNoOptionSpec_return elementNoOptionSpec() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.elementNoOptionSpec_return retval = new ANTLRv3Parser.elementNoOptionSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken labelOp = null;
			IToken ACTION98 = null;
			IToken SEMPRED99 = null;
			IToken string_literal100 = null;
			ANTLRv3Parser.id_return id89 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.atom_return atom90 = default(ANTLRv3Parser.atom_return);

			ANTLRv3Parser.ebnfSuffix_return ebnfSuffix91 = default(ANTLRv3Parser.ebnfSuffix_return);

			ANTLRv3Parser.id_return id92 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.block_return block93 = default(ANTLRv3Parser.block_return);

			ANTLRv3Parser.ebnfSuffix_return ebnfSuffix94 = default(ANTLRv3Parser.ebnfSuffix_return);

			ANTLRv3Parser.atom_return atom95 = default(ANTLRv3Parser.atom_return);

			ANTLRv3Parser.ebnfSuffix_return ebnfSuffix96 = default(ANTLRv3Parser.ebnfSuffix_return);

			ANTLRv3Parser.ebnf_return ebnf97 = default(ANTLRv3Parser.ebnf_return);

			ANTLRv3Parser.treeSpec_return treeSpec101 = default(ANTLRv3Parser.treeSpec_return);

			ANTLRv3Parser.ebnfSuffix_return ebnfSuffix102 = default(ANTLRv3Parser.ebnfSuffix_return);


			CommonTree labelOp_tree=null;
			CommonTree ACTION98_tree=null;
			CommonTree SEMPRED99_tree=null;
			CommonTree string_literal100_tree=null;

			try 
			{
				// ANTLRv3.g:216:2: ( id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | ) | id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | ) | atom ( ebnfSuffix | ) | ebnf | ACTION | SEMPRED ( '=>' | ) | treeSpec ( ebnfSuffix | ) )
				int alt45 = 7;
				alt45 = dfa45.Predict(input);
				switch (alt45) 
				{
				case 1 :
					// ANTLRv3.g:216:4: id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_elementNoOptionSpec1127);
					id89 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id89.Tree, id89, retval);
					// ANTLRv3.g:216:7: (labelOp= '=' | labelOp= '+=' )
					int alt38 = 2;
					int LA38_0 = input.LA(1);

					if ( (LA38_0 == 71) )
					{
						alt38 = 1;
					}
					else if ( (LA38_0 == 87) )
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
						// ANTLRv3.g:216:8: labelOp= '='
					{
						labelOp=(IToken)Match(input,71,FOLLOW_71_in_elementNoOptionSpec1132); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp, retval);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;
					case 2 :
						// ANTLRv3.g:216:20: labelOp= '+='
					{
						labelOp=(IToken)Match(input,87,FOLLOW_87_in_elementNoOptionSpec1136); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp, retval);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_atom_in_elementNoOptionSpec1139);
					atom90 = atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, atom90.Tree, atom90, retval);
					// ANTLRv3.g:217:3: ( ebnfSuffix | )
					int alt39 = 2;
					int LA39_0 = input.LA(1);

					if ( (LA39_0 == 74 || (LA39_0 >= 90 && LA39_0 <= 91)) )
					{
						alt39 = 1;
					}
					else if ( (LA39_0 == SEMPRED || LA39_0 == TREE_BEGIN || LA39_0 == REWRITE || (LA39_0 >= TOKEN_REF && LA39_0 <= ACTION) || LA39_0 == RULE_REF || LA39_0 == 69 || (LA39_0 >= 82 && LA39_0 <= 84) || LA39_0 == 89 || LA39_0 == 92) )
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
						// ANTLRv3.g:217:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec1145);
						ebnfSuffix91 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix91.Tree, ebnfSuffix91, retval);

					}
						break;
					case 2 :
						// ANTLRv3.g:219:3: 
					{
					}
						break;

					}


				}
					break;
				case 2 :
					// ANTLRv3.g:220:4: id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_elementNoOptionSpec1161);
					id92 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id92.Tree, id92, retval);
					// ANTLRv3.g:220:7: (labelOp= '=' | labelOp= '+=' )
					int alt40 = 2;
					int LA40_0 = input.LA(1);

					if ( (LA40_0 == 71) )
					{
						alt40 = 1;
					}
					else if ( (LA40_0 == 87) )
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
						// ANTLRv3.g:220:8: labelOp= '='
					{
						labelOp=(IToken)Match(input,71,FOLLOW_71_in_elementNoOptionSpec1166); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp, retval);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;
					case 2 :
						// ANTLRv3.g:220:20: labelOp= '+='
					{
						labelOp=(IToken)Match(input,87,FOLLOW_87_in_elementNoOptionSpec1170); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{labelOp_tree = (CommonTree)adaptor.Create(labelOp, retval);
							adaptor.AddChild(root_0, labelOp_tree);
						}

					}
						break;

					}

					PushFollow(FOLLOW_block_in_elementNoOptionSpec1173);
					block93 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block93.Tree, block93, retval);
					// ANTLRv3.g:221:3: ( ebnfSuffix | )
					int alt41 = 2;
					int LA41_0 = input.LA(1);

					if ( (LA41_0 == 74 || (LA41_0 >= 90 && LA41_0 <= 91)) )
					{
						alt41 = 1;
					}
					else if ( (LA41_0 == SEMPRED || LA41_0 == TREE_BEGIN || LA41_0 == REWRITE || (LA41_0 >= TOKEN_REF && LA41_0 <= ACTION) || LA41_0 == RULE_REF || LA41_0 == 69 || (LA41_0 >= 82 && LA41_0 <= 84) || LA41_0 == 89 || LA41_0 == 92) )
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
						// ANTLRv3.g:221:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec1179);
						ebnfSuffix94 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix94.Tree, ebnfSuffix94, retval);

					}
						break;
					case 2 :
						// ANTLRv3.g:223:3: 
					{
					}
						break;

					}


				}
					break;
				case 3 :
					// ANTLRv3.g:224:4: atom ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_atom_in_elementNoOptionSpec1195);
					atom95 = atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, atom95.Tree, atom95, retval);
					// ANTLRv3.g:225:3: ( ebnfSuffix | )
					int alt42 = 2;
					int LA42_0 = input.LA(1);

					if ( (LA42_0 == 74 || (LA42_0 >= 90 && LA42_0 <= 91)) )
					{
						alt42 = 1;
					}
					else if ( (LA42_0 == SEMPRED || LA42_0 == TREE_BEGIN || LA42_0 == REWRITE || (LA42_0 >= TOKEN_REF && LA42_0 <= ACTION) || LA42_0 == RULE_REF || LA42_0 == 69 || (LA42_0 >= 82 && LA42_0 <= 84) || LA42_0 == 89 || LA42_0 == 92) )
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
						// ANTLRv3.g:225:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec1201);
						ebnfSuffix96 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix96.Tree, ebnfSuffix96, retval);

					}
						break;
					case 2 :
						// ANTLRv3.g:227:3: 
					{
					}
						break;

					}


				}
					break;
				case 4 :
					// ANTLRv3.g:228:4: ebnf
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_ebnf_in_elementNoOptionSpec1217);
					ebnf97 = ebnf();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnf97.Tree, ebnf97, retval);

				}
					break;
				case 5 :
					// ANTLRv3.g:229:6: ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					ACTION98=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_elementNoOptionSpec1224); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION98_tree = (CommonTree)adaptor.Create(ACTION98, retval);
						adaptor.AddChild(root_0, ACTION98_tree);
					}

				}
					break;
				case 6 :
					// ANTLRv3.g:230:6: SEMPRED ( '=>' | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					SEMPRED99=(IToken)Match(input,SEMPRED,FOLLOW_SEMPRED_in_elementNoOptionSpec1231); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{SEMPRED99_tree = (CommonTree)adaptor.Create(SEMPRED99, retval);
						adaptor.AddChild(root_0, SEMPRED99_tree);
					}
					// ANTLRv3.g:230:14: ( '=>' | )
					int alt43 = 2;
					int LA43_0 = input.LA(1);

					if ( (LA43_0 == 88) )
					{
						alt43 = 1;
					}
					else if ( (LA43_0 == SEMPRED || LA43_0 == TREE_BEGIN || LA43_0 == REWRITE || (LA43_0 >= TOKEN_REF && LA43_0 <= ACTION) || LA43_0 == RULE_REF || LA43_0 == 69 || (LA43_0 >= 82 && LA43_0 <= 84) || LA43_0 == 89 || LA43_0 == 92) )
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
						// ANTLRv3.g:230:16: '=>'
					{
						string_literal100=(IToken)Match(input,88,FOLLOW_88_in_elementNoOptionSpec1235); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal100_tree = (CommonTree)adaptor.Create(string_literal100, retval);
							adaptor.AddChild(root_0, string_literal100_tree);
						}

					}
						break;
					case 2 :
						// ANTLRv3.g:230:24: 
					{
					}
						break;

					}


				}
					break;
				case 7 :
					// ANTLRv3.g:231:6: treeSpec ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_treeSpec_in_elementNoOptionSpec1247);
					treeSpec101 = treeSpec();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, treeSpec101.Tree, treeSpec101, retval);
					// ANTLRv3.g:232:3: ( ebnfSuffix | )
					int alt44 = 2;
					int LA44_0 = input.LA(1);

					if ( (LA44_0 == 74 || (LA44_0 >= 90 && LA44_0 <= 91)) )
					{
						alt44 = 1;
					}
					else if ( (LA44_0 == SEMPRED || LA44_0 == TREE_BEGIN || LA44_0 == REWRITE || (LA44_0 >= TOKEN_REF && LA44_0 <= ACTION) || LA44_0 == RULE_REF || LA44_0 == 69 || (LA44_0 >= 82 && LA44_0 <= 84) || LA44_0 == 89 || LA44_0 == 92) )
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
						// ANTLRv3.g:232:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_elementNoOptionSpec1253);
						ebnfSuffix102 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix102.Tree, ebnfSuffix102, retval);

					}
						break;
					case 2 :
						// ANTLRv3.g:234:3: 
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

		public class atom_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "atom"
		// ANTLRv3.g:237:1: atom : ( range ( (op= '^' | op= '!' ) | ) | terminal | notSet ( (op= '^' | op= '!' ) | ) | RULE_REF (arg= ARG_ACTION )? ( (op= '^' | op= '!' ) )? );
		public ANTLRv3Parser.atom_return atom() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.atom_return retval = new ANTLRv3Parser.atom_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken op = null;
			IToken arg = null;
			IToken RULE_REF106 = null;
			ANTLRv3Parser.range_return range103 = default(ANTLRv3Parser.range_return);

			ANTLRv3Parser.terminal_return terminal104 = default(ANTLRv3Parser.terminal_return);

			ANTLRv3Parser.notSet_return notSet105 = default(ANTLRv3Parser.notSet_return);


			CommonTree op_tree=null;
			CommonTree arg_tree=null;
			CommonTree RULE_REF106_tree=null;

			try 
			{
				// ANTLRv3.g:237:5: ( range ( (op= '^' | op= '!' ) | ) | terminal | notSet ( (op= '^' | op= '!' ) | ) | RULE_REF (arg= ARG_ACTION )? ( (op= '^' | op= '!' ) )? )
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
					else if ( (LA53_1 == SEMPRED || (LA53_1 >= TREE_BEGIN && LA53_1 <= REWRITE) || (LA53_1 >= TOKEN_REF && LA53_1 <= ACTION) || LA53_1 == RULE_REF || LA53_1 == 69 || LA53_1 == 74 || (LA53_1 >= 82 && LA53_1 <= 84) || (LA53_1 >= 89 && LA53_1 <= 92)) )
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
				case 92:
				{
					alt53 = 2;
				}
					break;
				case 89:
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
					// ANTLRv3.g:237:9: range ( (op= '^' | op= '!' ) | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_range_in_atom1275);
					range103 = range();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, range103.Tree, range103, retval);
					// ANTLRv3.g:237:15: ( (op= '^' | op= '!' ) | )
					int alt47 = 2;
					int LA47_0 = input.LA(1);

					if ( ((LA47_0 >= ROOT && LA47_0 <= BANG)) )
					{
						alt47 = 1;
					}
					else if ( (LA47_0 == SEMPRED || LA47_0 == TREE_BEGIN || LA47_0 == REWRITE || (LA47_0 >= TOKEN_REF && LA47_0 <= ACTION) || LA47_0 == RULE_REF || LA47_0 == 69 || LA47_0 == 74 || (LA47_0 >= 82 && LA47_0 <= 84) || (LA47_0 >= 89 && LA47_0 <= 92)) )
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
						// ANTLRv3.g:237:17: (op= '^' | op= '!' )
					{
						// ANTLRv3.g:237:17: (op= '^' | op= '!' )
						int alt46 = 2;
						int LA46_0 = input.LA(1);

						if ( (LA46_0 == ROOT) )
						{
							alt46 = 1;
						}
						else if ( (LA46_0 == BANG) )
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
							// ANTLRv3.g:237:18: op= '^'
						{
							op=(IToken)Match(input,ROOT,FOLLOW_ROOT_in_atom1282); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op, retval);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;
						case 2 :
							// ANTLRv3.g:237:25: op= '!'
						{
							op=(IToken)Match(input,BANG,FOLLOW_BANG_in_atom1286); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op, retval);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;

						}


					}
						break;
					case 2 :
						// ANTLRv3.g:237:35: 
					{
					}
						break;

					}


				}
					break;
				case 2 :
					// ANTLRv3.g:238:9: terminal
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_terminal_in_atom1301);
					terminal104 = terminal();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, terminal104.Tree, terminal104, retval);

				}
					break;
				case 3 :
					// ANTLRv3.g:239:7: notSet ( (op= '^' | op= '!' ) | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_notSet_in_atom1309);
					notSet105 = notSet();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, notSet105.Tree, notSet105, retval);
					// ANTLRv3.g:239:14: ( (op= '^' | op= '!' ) | )
					int alt49 = 2;
					int LA49_0 = input.LA(1);

					if ( ((LA49_0 >= ROOT && LA49_0 <= BANG)) )
					{
						alt49 = 1;
					}
					else if ( (LA49_0 == SEMPRED || LA49_0 == TREE_BEGIN || LA49_0 == REWRITE || (LA49_0 >= TOKEN_REF && LA49_0 <= ACTION) || LA49_0 == RULE_REF || LA49_0 == 69 || LA49_0 == 74 || (LA49_0 >= 82 && LA49_0 <= 84) || (LA49_0 >= 89 && LA49_0 <= 92)) )
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
						// ANTLRv3.g:239:16: (op= '^' | op= '!' )
					{
						// ANTLRv3.g:239:16: (op= '^' | op= '!' )
						int alt48 = 2;
						int LA48_0 = input.LA(1);

						if ( (LA48_0 == ROOT) )
						{
							alt48 = 1;
						}
						else if ( (LA48_0 == BANG) )
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
							// ANTLRv3.g:239:17: op= '^'
						{
							op=(IToken)Match(input,ROOT,FOLLOW_ROOT_in_atom1316); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op, retval);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;
						case 2 :
							// ANTLRv3.g:239:24: op= '!'
						{
							op=(IToken)Match(input,BANG,FOLLOW_BANG_in_atom1320); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op, retval);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;

						}


					}
						break;
					case 2 :
						// ANTLRv3.g:239:34: 
					{
					}
						break;

					}


				}
					break;
				case 4 :
					// ANTLRv3.g:240:9: RULE_REF (arg= ARG_ACTION )? ( (op= '^' | op= '!' ) )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					RULE_REF106=(IToken)Match(input,RULE_REF,FOLLOW_RULE_REF_in_atom1335); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{RULE_REF106_tree = (CommonTree)adaptor.Create(RULE_REF106, retval);
						adaptor.AddChild(root_0, RULE_REF106_tree);
					}
					// ANTLRv3.g:240:18: (arg= ARG_ACTION )?
					int alt50 = 2;
					int LA50_0 = input.LA(1);

					if ( (LA50_0 == ARG_ACTION) )
					{
						alt50 = 1;
					}
					switch (alt50) 
					{
					case 1 :
						// ANTLRv3.g:240:20: arg= ARG_ACTION
					{
						arg=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_atom1341); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{arg_tree = (CommonTree)adaptor.Create(arg, retval);
							adaptor.AddChild(root_0, arg_tree);
						}

					}
						break;

					}

					// ANTLRv3.g:240:38: ( (op= '^' | op= '!' ) )?
					int alt52 = 2;
					int LA52_0 = input.LA(1);

					if ( ((LA52_0 >= ROOT && LA52_0 <= BANG)) )
					{
						alt52 = 1;
					}
					switch (alt52) 
					{
					case 1 :
						// ANTLRv3.g:240:40: (op= '^' | op= '!' )
					{
						// ANTLRv3.g:240:40: (op= '^' | op= '!' )
						int alt51 = 2;
						int LA51_0 = input.LA(1);

						if ( (LA51_0 == ROOT) )
						{
							alt51 = 1;
						}
						else if ( (LA51_0 == BANG) )
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
							// ANTLRv3.g:240:41: op= '^'
						{
							op=(IToken)Match(input,ROOT,FOLLOW_ROOT_in_atom1351); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op, retval);
								adaptor.AddChild(root_0, op_tree);
							}

						}
							break;
						case 2 :
							// ANTLRv3.g:240:48: op= '!'
						{
							op=(IToken)Match(input,BANG,FOLLOW_BANG_in_atom1355); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{op_tree = (CommonTree)adaptor.Create(op, retval);
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

		public class notSet_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "notSet"
		// ANTLRv3.g:243:1: notSet : '~' ( notTerminal | block ) ;
		public ANTLRv3Parser.notSet_return notSet() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.notSet_return retval = new ANTLRv3Parser.notSet_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal107 = null;
			ANTLRv3Parser.notTerminal_return notTerminal108 = default(ANTLRv3Parser.notTerminal_return);

			ANTLRv3Parser.block_return block109 = default(ANTLRv3Parser.block_return);


			CommonTree char_literal107_tree=null;

			try 
			{
				// ANTLRv3.g:244:2: ( '~' ( notTerminal | block ) )
				// ANTLRv3.g:244:4: '~' ( notTerminal | block )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					char_literal107=(IToken)Match(input,89,FOLLOW_89_in_notSet1373); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal107_tree = (CommonTree)adaptor.Create(char_literal107, retval);
						adaptor.AddChild(root_0, char_literal107_tree);
					}
					// ANTLRv3.g:245:3: ( notTerminal | block )
					int alt54 = 2;
					int LA54_0 = input.LA(1);

					if ( ((LA54_0 >= TOKEN_REF && LA54_0 <= CHAR_LITERAL)) )
					{
						alt54 = 1;
					}
					else if ( (LA54_0 == 82) )
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
						// ANTLRv3.g:245:5: notTerminal
					{
						PushFollow(FOLLOW_notTerminal_in_notSet1379);
						notTerminal108 = notTerminal();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, notTerminal108.Tree, notTerminal108, retval);

					}
						break;
					case 2 :
						// ANTLRv3.g:246:5: block
					{
						PushFollow(FOLLOW_block_in_notSet1385);
						block109 = block();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block109.Tree, block109, retval);

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

		public class treeSpec_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "treeSpec"
		// ANTLRv3.g:250:1: treeSpec : '^(' element ( element )+ ')' ;
		public ANTLRv3Parser.treeSpec_return treeSpec() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.treeSpec_return retval = new ANTLRv3Parser.treeSpec_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal110 = null;
			IToken char_literal113 = null;
			ANTLRv3Parser.element_return element111 = default(ANTLRv3Parser.element_return);

			ANTLRv3Parser.element_return element112 = default(ANTLRv3Parser.element_return);


			CommonTree string_literal110_tree=null;
			CommonTree char_literal113_tree=null;

			try 
			{
				// ANTLRv3.g:251:2: ( '^(' element ( element )+ ')' )
				// ANTLRv3.g:251:4: '^(' element ( element )+ ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal110=(IToken)Match(input,TREE_BEGIN,FOLLOW_TREE_BEGIN_in_treeSpec1400); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal110_tree = (CommonTree)adaptor.Create(string_literal110, retval);
						adaptor.AddChild(root_0, string_literal110_tree);
					}
					PushFollow(FOLLOW_element_in_treeSpec1402);
					element111 = element();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, element111.Tree, element111, retval);
					// ANTLRv3.g:251:17: ( element )+
					int cnt55 = 0;
					do 
					{
						int alt55 = 2;
						int LA55_0 = input.LA(1);

						if ( (LA55_0 == SEMPRED || LA55_0 == TREE_BEGIN || (LA55_0 >= TOKEN_REF && LA55_0 <= ACTION) || LA55_0 == RULE_REF || LA55_0 == 82 || LA55_0 == 89 || LA55_0 == 92) )
						{
							alt55 = 1;
						}


						switch (alt55) 
						{
						case 1 :
							// ANTLRv3.g:251:19: element
						{
							PushFollow(FOLLOW_element_in_treeSpec1406);
							element112 = element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, element112.Tree, element112, retval);

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

					char_literal113=(IToken)Match(input,84,FOLLOW_84_in_treeSpec1411); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal113_tree = (CommonTree)adaptor.Create(char_literal113, retval);
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

		public class ebnf_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ebnf"
		// ANTLRv3.g:254:1: ebnf : block (op= '?' | op= '*' | op= '+' | '=>' | ) ;
		public ANTLRv3Parser.ebnf_return ebnf() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.ebnf_return retval = new ANTLRv3Parser.ebnf_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken op = null;
			IToken string_literal115 = null;
			ANTLRv3Parser.block_return block114 = default(ANTLRv3Parser.block_return);


			CommonTree op_tree=null;
			CommonTree string_literal115_tree=null;


			var firstToken = input.LT(1);

			try 
			{
				// ANTLRv3.g:263:2: ( block (op= '?' | op= '*' | op= '+' | '=>' | ) )
				// ANTLRv3.g:263:4: block (op= '?' | op= '*' | op= '+' | '=>' | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_block_in_ebnf1434);
					block114 = block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, block114.Tree, block114, retval);
					// ANTLRv3.g:264:3: (op= '?' | op= '*' | op= '+' | '=>' | )
					int alt56 = 5;
					switch ( input.LA(1) ) 
					{
					case 90:
					{
						alt56 = 1;
					}
						break;
					case 74:
					{
						alt56 = 2;
					}
						break;
					case 91:
					{
						alt56 = 3;
					}
						break;
					case 88:
					{
						alt56 = 4;
					}
						break;
					case SEMPRED:
					case TREE_BEGIN:
					case REWRITE:
					case TOKEN_REF:
					case STRING_LITERAL:
					case CHAR_LITERAL:
					case ACTION:
					case RULE_REF:
					case 69:
					case 82:
					case 83:
					case 84:
					case 89:
					case 92:
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
						// ANTLRv3.g:264:5: op= '?'
					{
						op=(IToken)Match(input,90,FOLLOW_90_in_ebnf1442); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{op_tree = (CommonTree)adaptor.Create(op, retval);
							adaptor.AddChild(root_0, op_tree);
						}

					}
						break;
					case 2 :
						// ANTLRv3.g:265:5: op= '*'
					{
						op=(IToken)Match(input,74,FOLLOW_74_in_ebnf1450); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{op_tree = (CommonTree)adaptor.Create(op, retval);
							adaptor.AddChild(root_0, op_tree);
						}

					}
						break;
					case 3 :
						// ANTLRv3.g:266:5: op= '+'
					{
						op=(IToken)Match(input,91,FOLLOW_91_in_ebnf1458); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{op_tree = (CommonTree)adaptor.Create(op, retval);
							adaptor.AddChild(root_0, op_tree);
						}

					}
						break;
					case 4 :
						// ANTLRv3.g:267:7: '=>'
					{
						string_literal115=(IToken)Match(input,88,FOLLOW_88_in_ebnf1466); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{string_literal115_tree = (CommonTree)adaptor.Create(string_literal115, retval);
							adaptor.AddChild(root_0, string_literal115_tree);
						}

					}
						break;
					case 5 :
						// ANTLRv3.g:269:3: 
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

		public class range_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "range"
		// ANTLRv3.g:272:1: range : c1= CHAR_LITERAL RANGE c2= CHAR_LITERAL ;
		public ANTLRv3Parser.range_return range() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.range_return retval = new ANTLRv3Parser.range_return();
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
				// ANTLRv3.g:273:2: (c1= CHAR_LITERAL RANGE c2= CHAR_LITERAL )
				// ANTLRv3.g:273:4: c1= CHAR_LITERAL RANGE c2= CHAR_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					c1=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_range1495); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{c1_tree = (CommonTree)adaptor.Create(c1, retval);
						adaptor.AddChild(root_0, c1_tree);
					}
					RANGE116=(IToken)Match(input,RANGE,FOLLOW_RANGE_in_range1497); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{RANGE116_tree = (CommonTree)adaptor.Create(RANGE116, retval);
						adaptor.AddChild(root_0, RANGE116_tree);
					}
					c2=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_range1501); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{c2_tree = (CommonTree)adaptor.Create(c2, retval);
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

		public class terminal_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "terminal"
		// ANTLRv3.g:276:1: terminal : ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' ) ( '^' | '!' )? ;
		public ANTLRv3Parser.terminal_return terminal() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.terminal_return retval = new ANTLRv3Parser.terminal_return();
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
				// ANTLRv3.g:277:5: ( ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' ) ( '^' | '!' )? )
				// ANTLRv3.g:277:9: ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' ) ( '^' | '!' )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// ANTLRv3.g:277:9: ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION | ) | STRING_LITERAL | '.' )
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
					case 92:
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
						// ANTLRv3.g:277:11: CHAR_LITERAL
					{
						CHAR_LITERAL117=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_terminal1519); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{CHAR_LITERAL117_tree = (CommonTree)adaptor.Create(CHAR_LITERAL117, retval);
							adaptor.AddChild(root_0, CHAR_LITERAL117_tree);
						}

					}
						break;
					case 2 :
						// ANTLRv3.g:279:7: TOKEN_REF ( ARG_ACTION | )
					{
						TOKEN_REF118=(IToken)Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_terminal1534); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{TOKEN_REF118_tree = (CommonTree)adaptor.Create(TOKEN_REF118, retval);
							adaptor.AddChild(root_0, TOKEN_REF118_tree);
						}
						// ANTLRv3.g:280:4: ( ARG_ACTION | )
						int alt57 = 2;
						int LA57_0 = input.LA(1);

						if ( (LA57_0 == ARG_ACTION) )
						{
							alt57 = 1;
						}
						else if ( (LA57_0 == SEMPRED || (LA57_0 >= TREE_BEGIN && LA57_0 <= REWRITE) || (LA57_0 >= TOKEN_REF && LA57_0 <= ACTION) || LA57_0 == RULE_REF || LA57_0 == 69 || LA57_0 == 74 || (LA57_0 >= 82 && LA57_0 <= 84) || (LA57_0 >= 89 && LA57_0 <= 92)) )
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
							// ANTLRv3.g:280:6: ARG_ACTION
						{
							ARG_ACTION119=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_terminal1541); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{ARG_ACTION119_tree = (CommonTree)adaptor.Create(ARG_ACTION119, retval);
								adaptor.AddChild(root_0, ARG_ACTION119_tree);
							}

						}
							break;
						case 2 :
							// ANTLRv3.g:282:4: 
						{
						}
							break;

						}


					}
						break;
					case 3 :
						// ANTLRv3.g:283:7: STRING_LITERAL
					{
						STRING_LITERAL120=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_terminal1562); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{STRING_LITERAL120_tree = (CommonTree)adaptor.Create(STRING_LITERAL120, retval);
							adaptor.AddChild(root_0, STRING_LITERAL120_tree);
						}

					}
						break;
					case 4 :
						// ANTLRv3.g:284:7: '.'
					{
						char_literal121=(IToken)Match(input,92,FOLLOW_92_in_terminal1570); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{char_literal121_tree = (CommonTree)adaptor.Create(char_literal121, retval);
							adaptor.AddChild(root_0, char_literal121_tree);
						}

					}
						break;

					}

					// ANTLRv3.g:286:3: ( '^' | '!' )?
					int alt59 = 2;
					int LA59_0 = input.LA(1);

					if ( ((LA59_0 >= ROOT && LA59_0 <= BANG)) )
					{
						alt59 = 1;
					}
					switch (alt59) 
					{
					case 1 :
						// ANTLRv3.g:
					{
						set122 = (IToken)input.LT(1);
						if ( (input.LA(1) >= ROOT && input.LA(1) <= BANG) ) 
						{
							input.Consume();
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set122, retval));
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

		public class notTerminal_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "notTerminal"
		// ANTLRv3.g:291:1: notTerminal : ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL );
		public ANTLRv3Parser.notTerminal_return notTerminal() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.notTerminal_return retval = new ANTLRv3Parser.notTerminal_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken set123 = null;

			CommonTree set123_tree=null;

			try 
			{
				// ANTLRv3.g:292:2: ( CHAR_LITERAL | TOKEN_REF | STRING_LITERAL )
				// ANTLRv3.g:
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					set123 = (IToken)input.LT(1);
					if ( (input.LA(1) >= TOKEN_REF && input.LA(1) <= CHAR_LITERAL) ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set123, retval));
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

		public class ebnfSuffix_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "ebnfSuffix"
		// ANTLRv3.g:297:1: ebnfSuffix : ( '?' | '*' | '+' );
		public ANTLRv3Parser.ebnfSuffix_return ebnfSuffix() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.ebnfSuffix_return retval = new ANTLRv3Parser.ebnfSuffix_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken set124 = null;

			CommonTree set124_tree=null;


			var op = input.LT(1);

			try 
			{
				// ANTLRv3.g:301:2: ( '?' | '*' | '+' )
				// ANTLRv3.g:
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					set124 = (IToken)input.LT(1);
					if ( input.LA(1) == 74 || (input.LA(1) >= 90 && input.LA(1) <= 91) ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set124, retval));
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

		public class rewrite_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite"
		// ANTLRv3.g:310:1: rewrite : ( (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )* rew2= '->' last= rewrite_alternative | );
		public ANTLRv3Parser.rewrite_return rewrite() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_return retval = new ANTLRv3Parser.rewrite_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken rew2 = null;
			IToken rew = null;
			IToken preds = null;
			IList list_rew = null;
			IList list_preds = null;
			IList list_predicated = null;
			ANTLRv3Parser.rewrite_alternative_return last = default(ANTLRv3Parser.rewrite_alternative_return);

			ANTLRv3Parser.rewrite_alternative_return predicated = default(ANTLRv3Parser.rewrite_alternative_return);
			predicated = null;
			CommonTree rew2_tree=null;
			CommonTree rew_tree=null;
			CommonTree preds_tree=null;


			var firstToken = input.LT(1);

			try 
			{
				// ANTLRv3.g:314:2: ( (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )* rew2= '->' last= rewrite_alternative | )
				int alt61 = 2;
				int LA61_0 = input.LA(1);

				if ( (LA61_0 == REWRITE) )
				{
					alt61 = 1;
				}
				else if ( (LA61_0 == 69 || (LA61_0 >= 83 && LA61_0 <= 84)) )
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
					// ANTLRv3.g:314:4: (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )* rew2= '->' last= rewrite_alternative
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// ANTLRv3.g:314:4: (rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative )*
					do 
					{
						int alt60 = 2;
						int LA60_0 = input.LA(1);

						if ( (LA60_0 == REWRITE) )
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
							// ANTLRv3.g:314:5: rew+= '->' preds+= SEMPRED predicated+= rewrite_alternative
						{
							rew=(IToken)Match(input,REWRITE,FOLLOW_REWRITE_in_rewrite1680); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{rew_tree = (CommonTree)adaptor.Create(rew, retval);
								adaptor.AddChild(root_0, rew_tree);
							}
							if (list_rew == null) list_rew = new ArrayList();
							list_rew.Add(rew);

							preds=(IToken)Match(input,SEMPRED,FOLLOW_SEMPRED_in_rewrite1684); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{preds_tree = (CommonTree)adaptor.Create(preds, retval);
								adaptor.AddChild(root_0, preds_tree);
							}
							if (list_preds == null) list_preds = new ArrayList();
							list_preds.Add(preds);

							PushFollow(FOLLOW_rewrite_alternative_in_rewrite1688);
							predicated = rewrite_alternative();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, predicated.Tree, predicated, retval);
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

					rew2=(IToken)Match(input,REWRITE,FOLLOW_REWRITE_in_rewrite1696); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{rew2_tree = (CommonTree)adaptor.Create(rew2, retval);
						adaptor.AddChild(root_0, rew2_tree);
					}
					PushFollow(FOLLOW_rewrite_alternative_in_rewrite1700);
					last = rewrite_alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, last.Tree, last, retval);

				}
					break;
				case 2 :
					// ANTLRv3.g:317:2: 
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

		public class rewrite_alternative_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_alternative"
		// ANTLRv3.g:319:1: rewrite_alternative options {backtrack=true; } : ( rewrite_template | rewrite_tree_alternative | );
		public ANTLRv3Parser.rewrite_alternative_return rewrite_alternative() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_alternative_return retval = new ANTLRv3Parser.rewrite_alternative_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			ANTLRv3Parser.rewrite_template_return rewrite_template125 = default(ANTLRv3Parser.rewrite_template_return);

			ANTLRv3Parser.rewrite_tree_alternative_return rewrite_tree_alternative126 = default(ANTLRv3Parser.rewrite_tree_alternative_return);



			try 
			{
				// ANTLRv3.g:321:2: ( rewrite_template | rewrite_tree_alternative | )
				int alt62 = 3;
				alt62 = dfa62.Predict(input);
				switch (alt62) 
				{
				case 1 :
					// ANTLRv3.g:321:4: rewrite_template
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_template_in_rewrite_alternative1721);
					rewrite_template125 = rewrite_template();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template125.Tree, rewrite_template125, retval);

				}
					break;
				case 2 :
					// ANTLRv3.g:322:4: rewrite_tree_alternative
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_alternative_in_rewrite_alternative1726);
					rewrite_tree_alternative126 = rewrite_tree_alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_alternative126.Tree, rewrite_tree_alternative126, retval);

				}
					break;
				case 3 :
					// ANTLRv3.g:324:2: 
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

		public class rewrite_tree_block_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_block"
		// ANTLRv3.g:326:1: rewrite_tree_block : lp= '(' rewrite_tree_alternative ')' ;
		public ANTLRv3Parser.rewrite_tree_block_return rewrite_tree_block() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_tree_block_return retval = new ANTLRv3Parser.rewrite_tree_block_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken char_literal128 = null;
			ANTLRv3Parser.rewrite_tree_alternative_return rewrite_tree_alternative127 = default(ANTLRv3Parser.rewrite_tree_alternative_return);


			CommonTree lp_tree=null;
			CommonTree char_literal128_tree=null;

			try 
			{
				// ANTLRv3.g:327:5: (lp= '(' rewrite_tree_alternative ')' )
				// ANTLRv3.g:327:9: lp= '(' rewrite_tree_alternative ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					lp=(IToken)Match(input,82,FOLLOW_82_in_rewrite_tree_block1755); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp, retval);
						adaptor.AddChild(root_0, lp_tree);
					}
					PushFollow(FOLLOW_rewrite_tree_alternative_in_rewrite_tree_block1757);
					rewrite_tree_alternative127 = rewrite_tree_alternative();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_alternative127.Tree, rewrite_tree_alternative127, retval);
					char_literal128=(IToken)Match(input,84,FOLLOW_84_in_rewrite_tree_block1759); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal128_tree = (CommonTree)adaptor.Create(char_literal128, retval);
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

		public class rewrite_tree_alternative_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_alternative"
		// ANTLRv3.g:330:1: rewrite_tree_alternative : ( rewrite_tree_element )+ ;
		public ANTLRv3Parser.rewrite_tree_alternative_return rewrite_tree_alternative() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_tree_alternative_return retval = new ANTLRv3Parser.rewrite_tree_alternative_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			ANTLRv3Parser.rewrite_tree_element_return rewrite_tree_element129 = default(ANTLRv3Parser.rewrite_tree_element_return);



			try 
			{
				// ANTLRv3.g:331:5: ( ( rewrite_tree_element )+ )
				// ANTLRv3.g:331:7: ( rewrite_tree_element )+
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					// ANTLRv3.g:331:7: ( rewrite_tree_element )+
					int cnt63 = 0;
					do 
					{
						int alt63 = 2;
						int LA63_0 = input.LA(1);

						if ( (LA63_0 == TREE_BEGIN || (LA63_0 >= TOKEN_REF && LA63_0 <= ACTION) || LA63_0 == RULE_REF || LA63_0 == 82 || LA63_0 == 93) )
						{
							alt63 = 1;
						}


						switch (alt63) 
						{
						case 1 :
							// ANTLRv3.g:331:7: rewrite_tree_element
						{
							PushFollow(FOLLOW_rewrite_tree_element_in_rewrite_tree_alternative1776);
							rewrite_tree_element129 = rewrite_tree_element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_element129.Tree, rewrite_tree_element129, retval);

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

		public class rewrite_tree_element_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_element"
		// ANTLRv3.g:334:1: rewrite_tree_element : ( rewrite_tree_atom | rewrite_tree_atom ebnfSuffix | rewrite_tree ( ebnfSuffix | ) | rewrite_tree_ebnf );
		public ANTLRv3Parser.rewrite_tree_element_return rewrite_tree_element() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_tree_element_return retval = new ANTLRv3Parser.rewrite_tree_element_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			ANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom130 = default(ANTLRv3Parser.rewrite_tree_atom_return);

			ANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom131 = default(ANTLRv3Parser.rewrite_tree_atom_return);

			ANTLRv3Parser.ebnfSuffix_return ebnfSuffix132 = default(ANTLRv3Parser.ebnfSuffix_return);

			ANTLRv3Parser.rewrite_tree_return rewrite_tree133 = default(ANTLRv3Parser.rewrite_tree_return);

			ANTLRv3Parser.ebnfSuffix_return ebnfSuffix134 = default(ANTLRv3Parser.ebnfSuffix_return);

			ANTLRv3Parser.rewrite_tree_ebnf_return rewrite_tree_ebnf135 = default(ANTLRv3Parser.rewrite_tree_ebnf_return);



			try 
			{
				// ANTLRv3.g:335:2: ( rewrite_tree_atom | rewrite_tree_atom ebnfSuffix | rewrite_tree ( ebnfSuffix | ) | rewrite_tree_ebnf )
				int alt65 = 4;
				alt65 = dfa65.Predict(input);
				switch (alt65) 
				{
				case 1 :
					// ANTLRv3.g:335:4: rewrite_tree_atom
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1791);
					rewrite_tree_atom130 = rewrite_tree_atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_atom130.Tree, rewrite_tree_atom130, retval);

				}
					break;
				case 2 :
					// ANTLRv3.g:336:4: rewrite_tree_atom ebnfSuffix
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1796);
					rewrite_tree_atom131 = rewrite_tree_atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_atom131.Tree, rewrite_tree_atom131, retval);
					PushFollow(FOLLOW_ebnfSuffix_in_rewrite_tree_element1798);
					ebnfSuffix132 = ebnfSuffix();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix132.Tree, ebnfSuffix132, retval);

				}
					break;
				case 3 :
					// ANTLRv3.g:337:6: rewrite_tree ( ebnfSuffix | )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_in_rewrite_tree_element1805);
					rewrite_tree133 = rewrite_tree();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree133.Tree, rewrite_tree133, retval);
					// ANTLRv3.g:338:3: ( ebnfSuffix | )
					int alt64 = 2;
					int LA64_0 = input.LA(1);

					if ( (LA64_0 == 74 || (LA64_0 >= 90 && LA64_0 <= 91)) )
					{
						alt64 = 1;
					}
					else if ( (LA64_0 == EOF || LA64_0 == TREE_BEGIN || LA64_0 == REWRITE || (LA64_0 >= TOKEN_REF && LA64_0 <= ACTION) || LA64_0 == RULE_REF || LA64_0 == 69 || (LA64_0 >= 82 && LA64_0 <= 84) || LA64_0 == 93) )
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
						// ANTLRv3.g:338:5: ebnfSuffix
					{
						PushFollow(FOLLOW_ebnfSuffix_in_rewrite_tree_element1811);
						ebnfSuffix134 = ebnfSuffix();
						state.followingStackPointer--;
						if (state.failed) return retval;
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix134.Tree, ebnfSuffix134, retval);

					}
						break;
					case 2 :
						// ANTLRv3.g:340:3: 
					{
					}
						break;

					}


				}
					break;
				case 4 :
					// ANTLRv3.g:341:6: rewrite_tree_ebnf
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_ebnf_in_rewrite_tree_element1826);
					rewrite_tree_ebnf135 = rewrite_tree_ebnf();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_ebnf135.Tree, rewrite_tree_ebnf135, retval);

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

		public class rewrite_tree_atom_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_atom"
		// ANTLRv3.g:344:1: rewrite_tree_atom : ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION )? | RULE_REF | STRING_LITERAL | d= '$' id | ACTION );
		public ANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_tree_atom_return retval = new ANTLRv3Parser.rewrite_tree_atom_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken d = null;
			IToken CHAR_LITERAL136 = null;
			IToken TOKEN_REF137 = null;
			IToken ARG_ACTION138 = null;
			IToken RULE_REF139 = null;
			IToken STRING_LITERAL140 = null;
			IToken ACTION142 = null;
			ANTLRv3Parser.id_return id141 = default(ANTLRv3Parser.id_return);


			CommonTree d_tree=null;
			CommonTree CHAR_LITERAL136_tree=null;
			CommonTree TOKEN_REF137_tree=null;
			CommonTree ARG_ACTION138_tree=null;
			CommonTree RULE_REF139_tree=null;
			CommonTree STRING_LITERAL140_tree=null;
			CommonTree ACTION142_tree=null;

			try 
			{
				// ANTLRv3.g:345:5: ( CHAR_LITERAL | TOKEN_REF ( ARG_ACTION )? | RULE_REF | STRING_LITERAL | d= '$' id | ACTION )
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
				case 93:
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
					// ANTLRv3.g:345:9: CHAR_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					CHAR_LITERAL136=(IToken)Match(input,CHAR_LITERAL,FOLLOW_CHAR_LITERAL_in_rewrite_tree_atom1842); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{CHAR_LITERAL136_tree = (CommonTree)adaptor.Create(CHAR_LITERAL136, retval);
						adaptor.AddChild(root_0, CHAR_LITERAL136_tree);
					}

				}
					break;
				case 2 :
					// ANTLRv3.g:346:6: TOKEN_REF ( ARG_ACTION )?
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					TOKEN_REF137=(IToken)Match(input,TOKEN_REF,FOLLOW_TOKEN_REF_in_rewrite_tree_atom1849); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{TOKEN_REF137_tree = (CommonTree)adaptor.Create(TOKEN_REF137, retval);
						adaptor.AddChild(root_0, TOKEN_REF137_tree);
					}
					// ANTLRv3.g:346:16: ( ARG_ACTION )?
					int alt66 = 2;
					int LA66_0 = input.LA(1);

					if ( (LA66_0 == ARG_ACTION) )
					{
						alt66 = 1;
					}
					switch (alt66) 
					{
					case 1 :
						// ANTLRv3.g:346:16: ARG_ACTION
					{
						ARG_ACTION138=(IToken)Match(input,ARG_ACTION,FOLLOW_ARG_ACTION_in_rewrite_tree_atom1851); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{ARG_ACTION138_tree = (CommonTree)adaptor.Create(ARG_ACTION138, retval);
							adaptor.AddChild(root_0, ARG_ACTION138_tree);
						}

					}
						break;

					}


				}
					break;
				case 3 :
					// ANTLRv3.g:347:9: RULE_REF
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					RULE_REF139=(IToken)Match(input,RULE_REF,FOLLOW_RULE_REF_in_rewrite_tree_atom1863); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{RULE_REF139_tree = (CommonTree)adaptor.Create(RULE_REF139, retval);
						adaptor.AddChild(root_0, RULE_REF139_tree);
					}

				}
					break;
				case 4 :
					// ANTLRv3.g:348:6: STRING_LITERAL
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					STRING_LITERAL140=(IToken)Match(input,STRING_LITERAL,FOLLOW_STRING_LITERAL_in_rewrite_tree_atom1870); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{STRING_LITERAL140_tree = (CommonTree)adaptor.Create(STRING_LITERAL140, retval);
						adaptor.AddChild(root_0, STRING_LITERAL140_tree);
					}

				}
					break;
				case 5 :
					// ANTLRv3.g:349:6: d= '$' id
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					d=(IToken)Match(input,93,FOLLOW_93_in_rewrite_tree_atom1879); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{d_tree = (CommonTree)adaptor.Create(d, retval);
						adaptor.AddChild(root_0, d_tree);
					}
					PushFollow(FOLLOW_id_in_rewrite_tree_atom1881);
					id141 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id141.Tree, id141, retval);

				}
					break;
				case 6 :
					// ANTLRv3.g:350:4: ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					ACTION142=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_tree_atom1887); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION142_tree = (CommonTree)adaptor.Create(ACTION142, retval);
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

		public class rewrite_tree_ebnf_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree_ebnf"
		// ANTLRv3.g:353:1: rewrite_tree_ebnf : rewrite_tree_block ebnfSuffix ;
		public ANTLRv3Parser.rewrite_tree_ebnf_return rewrite_tree_ebnf() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_tree_ebnf_return retval = new ANTLRv3Parser.rewrite_tree_ebnf_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			ANTLRv3Parser.rewrite_tree_block_return rewrite_tree_block143 = default(ANTLRv3Parser.rewrite_tree_block_return);

			ANTLRv3Parser.ebnfSuffix_return ebnfSuffix144 = default(ANTLRv3Parser.ebnfSuffix_return);




			var firstToken = input.LT(1);

			try 
			{
				// ANTLRv3.g:361:2: ( rewrite_tree_block ebnfSuffix )
				// ANTLRv3.g:361:4: rewrite_tree_block ebnfSuffix
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_tree_block_in_rewrite_tree_ebnf1908);
					rewrite_tree_block143 = rewrite_tree_block();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_block143.Tree, rewrite_tree_block143, retval);
					PushFollow(FOLLOW_ebnfSuffix_in_rewrite_tree_ebnf1910);
					ebnfSuffix144 = ebnfSuffix();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ebnfSuffix144.Tree, ebnfSuffix144, retval);

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

		public class rewrite_tree_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_tree"
		// ANTLRv3.g:364:1: rewrite_tree : '^(' rewrite_tree_atom ( rewrite_tree_element )* ')' ;
		public ANTLRv3Parser.rewrite_tree_return rewrite_tree() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_tree_return retval = new ANTLRv3Parser.rewrite_tree_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken string_literal145 = null;
			IToken char_literal148 = null;
			ANTLRv3Parser.rewrite_tree_atom_return rewrite_tree_atom146 = default(ANTLRv3Parser.rewrite_tree_atom_return);

			ANTLRv3Parser.rewrite_tree_element_return rewrite_tree_element147 = default(ANTLRv3Parser.rewrite_tree_element_return);


			CommonTree string_literal145_tree=null;
			CommonTree char_literal148_tree=null;

			try 
			{
				// ANTLRv3.g:365:2: ( '^(' rewrite_tree_atom ( rewrite_tree_element )* ')' )
				// ANTLRv3.g:365:4: '^(' rewrite_tree_atom ( rewrite_tree_element )* ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					string_literal145=(IToken)Match(input,TREE_BEGIN,FOLLOW_TREE_BEGIN_in_rewrite_tree1922); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{string_literal145_tree = (CommonTree)adaptor.Create(string_literal145, retval);
						adaptor.AddChild(root_0, string_literal145_tree);
					}
					PushFollow(FOLLOW_rewrite_tree_atom_in_rewrite_tree1924);
					rewrite_tree_atom146 = rewrite_tree_atom();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_atom146.Tree, rewrite_tree_atom146, retval);
					// ANTLRv3.g:365:27: ( rewrite_tree_element )*
					do 
					{
						int alt68 = 2;
						int LA68_0 = input.LA(1);

						if ( (LA68_0 == TREE_BEGIN || (LA68_0 >= TOKEN_REF && LA68_0 <= ACTION) || LA68_0 == RULE_REF || LA68_0 == 82 || LA68_0 == 93) )
						{
							alt68 = 1;
						}


						switch (alt68) 
						{
						case 1 :
							// ANTLRv3.g:365:27: rewrite_tree_element
						{
							PushFollow(FOLLOW_rewrite_tree_element_in_rewrite_tree1926);
							rewrite_tree_element147 = rewrite_tree_element();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_tree_element147.Tree, rewrite_tree_element147, retval);

						}
							break;

						default:
							goto loop68;
						}
					} while (true);

					loop68:
					;	// Stops C# compiler whining that label 'loop68' has no statements

					char_literal148=(IToken)Match(input,84,FOLLOW_84_in_rewrite_tree1929); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal148_tree = (CommonTree)adaptor.Create(char_literal148, retval);
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

		public class rewrite_template_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template"
		// ANTLRv3.g:368:1: rewrite_template : ( id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION );
		public ANTLRv3Parser.rewrite_template_return rewrite_template() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_template_return retval = new ANTLRv3Parser.rewrite_template_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken str = null;
			IToken char_literal151 = null;
			IToken ACTION154 = null;
			ANTLRv3Parser.id_return id149 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.rewrite_template_args_return rewrite_template_args150 = default(ANTLRv3Parser.rewrite_template_args_return);

			ANTLRv3Parser.rewrite_template_ref_return rewrite_template_ref152 = default(ANTLRv3Parser.rewrite_template_ref_return);

			ANTLRv3Parser.rewrite_indirect_template_head_return rewrite_indirect_template_head153 = default(ANTLRv3Parser.rewrite_indirect_template_head_return);


			CommonTree lp_tree=null;
			CommonTree str_tree=null;
			CommonTree char_literal151_tree=null;
			CommonTree ACTION154_tree=null;

			try 
			{
				// ANTLRv3.g:380:2: ( id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION )
				int alt70 = 4;
				alt70 = dfa70.Predict(input);
				switch (alt70) 
				{
				case 1 :
					// ANTLRv3.g:381:3: id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL )
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_rewrite_template1947);
					id149 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id149.Tree, id149, retval);
					lp=(IToken)Match(input,82,FOLLOW_82_in_rewrite_template1951); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp, retval);
						adaptor.AddChild(root_0, lp_tree);
					}
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_template1953);
					rewrite_template_args150 = rewrite_template_args();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_args150.Tree, rewrite_template_args150, retval);
					char_literal151=(IToken)Match(input,84,FOLLOW_84_in_rewrite_template1955); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal151_tree = (CommonTree)adaptor.Create(char_literal151, retval);
						adaptor.AddChild(root_0, char_literal151_tree);
					}
					// ANTLRv3.g:382:3: (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL )
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
						// ANTLRv3.g:382:5: str= DOUBLE_QUOTE_STRING_LITERAL
					{
						str=(IToken)Match(input,DOUBLE_QUOTE_STRING_LITERAL,FOLLOW_DOUBLE_QUOTE_STRING_LITERAL_in_rewrite_template1963); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{str_tree = (CommonTree)adaptor.Create(str, retval);
							adaptor.AddChild(root_0, str_tree);
						}

					}
						break;
					case 2 :
						// ANTLRv3.g:382:39: str= DOUBLE_ANGLE_STRING_LITERAL
					{
						str=(IToken)Match(input,DOUBLE_ANGLE_STRING_LITERAL,FOLLOW_DOUBLE_ANGLE_STRING_LITERAL_in_rewrite_template1969); if (state.failed) return retval;
						if ( state.backtracking == 0 )
						{str_tree = (CommonTree)adaptor.Create(str, retval);
							adaptor.AddChild(root_0, str_tree);
						}

					}
						break;

					}


				}
					break;
				case 2 :
					// ANTLRv3.g:385:3: rewrite_template_ref
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_template_ref_in_rewrite_template1980);
					rewrite_template_ref152 = rewrite_template_ref();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_ref152.Tree, rewrite_template_ref152, retval);

				}
					break;
				case 3 :
					// ANTLRv3.g:388:3: rewrite_indirect_template_head
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_indirect_template_head_in_rewrite_template1989);
					rewrite_indirect_template_head153 = rewrite_indirect_template_head();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_indirect_template_head153.Tree, rewrite_indirect_template_head153, retval);

				}
					break;
				case 4 :
					// ANTLRv3.g:391:3: ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					ACTION154=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_template1998); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION154_tree = (CommonTree)adaptor.Create(ACTION154, retval);
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

		public class rewrite_template_ref_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template_ref"
		// ANTLRv3.g:394:1: rewrite_template_ref : id lp= '(' rewrite_template_args ')' ;
		public ANTLRv3Parser.rewrite_template_ref_return rewrite_template_ref() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_template_ref_return retval = new ANTLRv3Parser.rewrite_template_ref_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken char_literal157 = null;
			ANTLRv3Parser.id_return id155 = default(ANTLRv3Parser.id_return);

			ANTLRv3Parser.rewrite_template_args_return rewrite_template_args156 = default(ANTLRv3Parser.rewrite_template_args_return);


			CommonTree lp_tree=null;
			CommonTree char_literal157_tree=null;

			try 
			{
				// ANTLRv3.g:396:2: ( id lp= '(' rewrite_template_args ')' )
				// ANTLRv3.g:396:4: id lp= '(' rewrite_template_args ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_rewrite_template_ref2011);
					id155 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id155.Tree, id155, retval);
					lp=(IToken)Match(input,82,FOLLOW_82_in_rewrite_template_ref2015); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp, retval);
						adaptor.AddChild(root_0, lp_tree);
					}
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_template_ref2017);
					rewrite_template_args156 = rewrite_template_args();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_args156.Tree, rewrite_template_args156, retval);
					char_literal157=(IToken)Match(input,84,FOLLOW_84_in_rewrite_template_ref2019); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal157_tree = (CommonTree)adaptor.Create(char_literal157, retval);
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

		public class rewrite_indirect_template_head_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_indirect_template_head"
		// ANTLRv3.g:399:1: rewrite_indirect_template_head : lp= '(' ACTION ')' '(' rewrite_template_args ')' ;
		public ANTLRv3Parser.rewrite_indirect_template_head_return rewrite_indirect_template_head() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_indirect_template_head_return retval = new ANTLRv3Parser.rewrite_indirect_template_head_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken lp = null;
			IToken ACTION158 = null;
			IToken char_literal159 = null;
			IToken char_literal160 = null;
			IToken char_literal162 = null;
			ANTLRv3Parser.rewrite_template_args_return rewrite_template_args161 = default(ANTLRv3Parser.rewrite_template_args_return);


			CommonTree lp_tree=null;
			CommonTree ACTION158_tree=null;
			CommonTree char_literal159_tree=null;
			CommonTree char_literal160_tree=null;
			CommonTree char_literal162_tree=null;

			try 
			{
				// ANTLRv3.g:401:2: (lp= '(' ACTION ')' '(' rewrite_template_args ')' )
				// ANTLRv3.g:401:4: lp= '(' ACTION ')' '(' rewrite_template_args ')'
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					lp=(IToken)Match(input,82,FOLLOW_82_in_rewrite_indirect_template_head2034); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{lp_tree = (CommonTree)adaptor.Create(lp, retval);
						adaptor.AddChild(root_0, lp_tree);
					}
					ACTION158=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_indirect_template_head2036); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION158_tree = (CommonTree)adaptor.Create(ACTION158, retval);
						adaptor.AddChild(root_0, ACTION158_tree);
					}
					char_literal159=(IToken)Match(input,84,FOLLOW_84_in_rewrite_indirect_template_head2038); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal159_tree = (CommonTree)adaptor.Create(char_literal159, retval);
						adaptor.AddChild(root_0, char_literal159_tree);
					}
					char_literal160=(IToken)Match(input,82,FOLLOW_82_in_rewrite_indirect_template_head2040); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal160_tree = (CommonTree)adaptor.Create(char_literal160, retval);
						adaptor.AddChild(root_0, char_literal160_tree);
					}
					PushFollow(FOLLOW_rewrite_template_args_in_rewrite_indirect_template_head2042);
					rewrite_template_args161 = rewrite_template_args();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_args161.Tree, rewrite_template_args161, retval);
					char_literal162=(IToken)Match(input,84,FOLLOW_84_in_rewrite_indirect_template_head2044); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal162_tree = (CommonTree)adaptor.Create(char_literal162, retval);
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

		public class rewrite_template_args_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template_args"
		// ANTLRv3.g:404:1: rewrite_template_args : ( rewrite_template_arg ( ',' rewrite_template_arg )* | );
		public ANTLRv3Parser.rewrite_template_args_return rewrite_template_args() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_template_args_return retval = new ANTLRv3Parser.rewrite_template_args_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal164 = null;
			ANTLRv3Parser.rewrite_template_arg_return rewrite_template_arg163 = default(ANTLRv3Parser.rewrite_template_arg_return);

			ANTLRv3Parser.rewrite_template_arg_return rewrite_template_arg165 = default(ANTLRv3Parser.rewrite_template_arg_return);


			CommonTree char_literal164_tree=null;

			try 
			{
				// ANTLRv3.g:405:2: ( rewrite_template_arg ( ',' rewrite_template_arg )* | )
				int alt72 = 2;
				int LA72_0 = input.LA(1);

				if ( (LA72_0 == TOKEN_REF || LA72_0 == RULE_REF) )
				{
					alt72 = 1;
				}
				else if ( (LA72_0 == 84) )
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
					// ANTLRv3.g:405:4: rewrite_template_arg ( ',' rewrite_template_arg )*
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_rewrite_template_arg_in_rewrite_template_args2055);
					rewrite_template_arg163 = rewrite_template_arg();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_arg163.Tree, rewrite_template_arg163, retval);
					// ANTLRv3.g:405:25: ( ',' rewrite_template_arg )*
					do 
					{
						int alt71 = 2;
						int LA71_0 = input.LA(1);

						if ( (LA71_0 == 81) )
						{
							alt71 = 1;
						}


						switch (alt71) 
						{
						case 1 :
							// ANTLRv3.g:405:26: ',' rewrite_template_arg
						{
							char_literal164=(IToken)Match(input,81,FOLLOW_81_in_rewrite_template_args2058); if (state.failed) return retval;
							if ( state.backtracking == 0 )
							{char_literal164_tree = (CommonTree)adaptor.Create(char_literal164, retval);
								adaptor.AddChild(root_0, char_literal164_tree);
							}
							PushFollow(FOLLOW_rewrite_template_arg_in_rewrite_template_args2060);
							rewrite_template_arg165 = rewrite_template_arg();
							state.followingStackPointer--;
							if (state.failed) return retval;
							if ( state.backtracking == 0 ) adaptor.AddChild(root_0, rewrite_template_arg165.Tree, rewrite_template_arg165, retval);

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
					// ANTLRv3.g:407:2: 
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

		public class rewrite_template_arg_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "rewrite_template_arg"
		// ANTLRv3.g:409:1: rewrite_template_arg : id '=' ACTION ;
		public ANTLRv3Parser.rewrite_template_arg_return rewrite_template_arg() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.rewrite_template_arg_return retval = new ANTLRv3Parser.rewrite_template_arg_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken char_literal167 = null;
			IToken ACTION168 = null;
			ANTLRv3Parser.id_return id166 = default(ANTLRv3Parser.id_return);


			CommonTree char_literal167_tree=null;
			CommonTree ACTION168_tree=null;

			try 
			{
				// ANTLRv3.g:410:2: ( id '=' ACTION )
				// ANTLRv3.g:410:6: id '=' ACTION
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					PushFollow(FOLLOW_id_in_rewrite_template_arg2078);
					id166 = id();
					state.followingStackPointer--;
					if (state.failed) return retval;
					if ( state.backtracking == 0 ) adaptor.AddChild(root_0, id166.Tree, id166, retval);
					char_literal167=(IToken)Match(input,71,FOLLOW_71_in_rewrite_template_arg2080); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{char_literal167_tree = (CommonTree)adaptor.Create(char_literal167, retval);
						adaptor.AddChild(root_0, char_literal167_tree);
					}
					ACTION168=(IToken)Match(input,ACTION,FOLLOW_ACTION_in_rewrite_template_arg2082); if (state.failed) return retval;
					if ( state.backtracking == 0 )
					{ACTION168_tree = (CommonTree)adaptor.Create(ACTION168, retval);
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

		public class id_return : XParserRuleReturnScope
		{
			private CommonTree tree;
			override public object Tree
			{
				get { return tree; }
				set { tree = (CommonTree) value; }
			}
		};

		// $ANTLR start "id"
		// ANTLRv3.g:413:1: id : ( TOKEN_REF | RULE_REF );
		public ANTLRv3Parser.id_return id() // throws RecognitionException [1]
		{   
			ANTLRv3Parser.id_return retval = new ANTLRv3Parser.id_return();
			retval.Start = input.LT(1);

			CommonTree root_0 = null;

			IToken set169 = null;

			CommonTree set169_tree=null;

			try 
			{
				// ANTLRv3.g:413:4: ( TOKEN_REF | RULE_REF )
				// ANTLRv3.g:
				{
					root_0 = (CommonTree)adaptor.GetNilNode();

					set169 = (IToken)input.LT(1);
					if ( input.LA(1) == TOKEN_REF || input.LA(1) == RULE_REF ) 
					{
						input.Consume();
						if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (CommonTree)adaptor.Create(set169, retval));
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

		// $ANTLR start "synpred1_ANTLRv3"
		public void synpred1_ANTLRv3_fragment() {
			// ANTLRv3.g:321:4: ( rewrite_template )
			// ANTLRv3.g:321:4: rewrite_template
			{
				PushFollow(FOLLOW_rewrite_template_in_synpred1_ANTLRv31721);
				rewrite_template();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred1_ANTLRv3"

		// $ANTLR start "synpred2_ANTLRv3"
		public void synpred2_ANTLRv3_fragment() {
			// ANTLRv3.g:322:4: ( rewrite_tree_alternative )
			// ANTLRv3.g:322:4: rewrite_tree_alternative
			{
				PushFollow(FOLLOW_rewrite_tree_alternative_in_synpred2_ANTLRv31726);
				rewrite_tree_alternative();
				state.followingStackPointer--;
				if (state.failed) return ;

			}
		}
		// $ANTLR end "synpred2_ANTLRv3"

		// Delegated rules

		public bool synpred2_ANTLRv3() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred2_ANTLRv3_fragment(); // can never throw exception
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
		public bool synpred1_ANTLRv3() 
		{
			state.backtracking++;
			int start = input.Mark();
			try 
			{
				synpred1_ANTLRv3_fragment(); // can never throw exception
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
			"\x02\x20\x01\uffff\x01\x20\x04\uffff\x02\x2a\x02\uffff";
		const string DFA45_maxS =
			"\x02\x5c\x01\uffff\x01\x5c\x04\uffff\x02\x5c\x02\uffff";
		const string DFA45_acceptS =
			"\x02\uffff\x01\x03\x01\uffff\x01\x04\x01\x05\x01\x06\x01\x07\x02"+
				"\uffff\x01\x02\x01\x01";
		const string DFA45_specialS =
			"\x0c\uffff}>";
		static readonly string[] DFA45_transitionS = {
			"\x01\x06\x04\uffff\x01\x07\x04\uffff\x01\x01\x02\x02\x01\x05"+
				"\x03\uffff\x01\x03\x20\uffff\x01\x04\x06\uffff\x01\x02\x02\uffff"+
					"\x01\x02",
			"\x01\x02\x04\uffff\x04\x02\x01\uffff\x04\x02\x02\uffff\x02"+
				"\x02\x13\uffff\x01\x02\x01\uffff\x01\x08\x02\uffff\x01\x02\x07"+
					"\uffff\x03\x02\x02\uffff\x01\x09\x01\uffff\x04\x02",
			"",
			"\x01\x02\x04\uffff\x04\x02\x01\uffff\x04\x02\x02\uffff\x02"+
				"\x02\x13\uffff\x01\x02\x01\uffff\x01\x08\x02\uffff\x01\x02\x07"+
					"\uffff\x03\x02\x02\uffff\x01\x09\x01\uffff\x04\x02",
			"",
			"",
			"",
			"",
			"\x03\x0b\x04\uffff\x01\x0b\x20\uffff\x01\x0a\x06\uffff\x01"+
				"\x0b\x02\uffff\x01\x0b",
			"\x03\x0b\x04\uffff\x01\x0b\x20\uffff\x01\x0a\x06\uffff\x01"+
				"\x0b\x02\uffff\x01\x0b",
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
				get { return "215:1: elementNoOptionSpec : ( id (labelOp= '=' | labelOp= '+=' ) atom ( ebnfSuffix | ) | id (labelOp= '=' | labelOp= '+=' ) block ( ebnfSuffix | ) | atom ( ebnfSuffix | ) | ebnf | ACTION | SEMPRED ( '=>' | ) | treeSpec ( ebnfSuffix | ) );"; }
			}

		}

		const string DFA62_eotS =
			"\x0d\uffff";
		const string DFA62_eofS =
			"\x0d\uffff";
		const string DFA62_minS =
			"\x03\x25\x01\x00\x01\uffff\x01\x25\x01\uffff\x02\x25\x01\uffff"+
				"\x02\x25\x01\x4a";
		const string DFA62_maxS =
			"\x03\x5d\x01\x00\x01\uffff\x01\x5d\x01\uffff\x02\x5d\x01\uffff"+
				"\x02\x5d\x01\x5b";
		const string DFA62_acceptS =
			"\x04\uffff\x01\x02\x01\uffff\x01\x03\x02\uffff\x01\x01\x03\uffff";
		const string DFA62_specialS =
			"\x03\uffff\x01\x00\x09\uffff}>";
		static readonly string[] DFA62_transitionS = {
			"\x01\x04\x02\uffff\x01\x06\x01\uffff\x01\x01\x02\x04\x01\x03"+
				"\x03\uffff\x01\x05\x13\uffff\x01\x06\x0c\uffff\x01\x02\x02\x06"+
					"\x08\uffff\x01\x04",
			"\x01\x04\x02\uffff\x01\x04\x01\uffff\x04\x04\x02\uffff\x02"+
				"\x04\x13\uffff\x01\x04\x04\uffff\x01\x04\x07\uffff\x01\x07\x02"+
					"\x04\x05\uffff\x02\x04\x01\uffff\x01\x04",
			"\x01\x04\x04\uffff\x03\x04\x01\x08\x03\uffff\x01\x04\x20\uffff"+
				"\x01\x04\x0a\uffff\x01\x04",
			"\x01\uffff",
			"",
			"\x01\x04\x02\uffff\x01\x04\x01\uffff\x04\x04\x03\uffff\x01"+
				"\x04\x13\uffff\x01\x04\x04\uffff\x01\x04\x07\uffff\x01\x07\x02"+
					"\x04\x05\uffff\x02\x04\x01\uffff\x01\x04",
			"",
			"\x01\x04\x04\uffff\x01\x0a\x03\x04\x03\uffff\x01\x0b\x20\uffff"+
				"\x01\x04\x01\uffff\x01\x09\x08\uffff\x01\x04",
			"\x01\x04\x04\uffff\x04\x04\x03\uffff\x01\x04\x18\uffff\x01"+
				"\x04\x07\uffff\x01\x04\x01\uffff\x01\x0c\x05\uffff\x02\x04\x01"+
					"\uffff\x01\x04",
			"",
			"\x01\x04\x04\uffff\x04\x04\x02\uffff\x02\x04\x15\uffff\x01"+
				"\x09\x02\uffff\x01\x04\x07\uffff\x01\x04\x01\uffff\x01\x04\x05"+
					"\uffff\x02\x04\x01\uffff\x01\x04",
			"\x01\x04\x04\uffff\x04\x04\x03\uffff\x01\x04\x15\uffff\x01"+
				"\x09\x02\uffff\x01\x04\x07\uffff\x01\x04\x01\uffff\x01\x04\x05"+
					"\uffff\x02\x04\x01\uffff\x01\x04",
			"\x01\x04\x07\uffff\x01\x09\x07\uffff\x02\x04"
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
				get { return "319:1: rewrite_alternative options {backtrack=true; } : ( rewrite_template | rewrite_tree_alternative | );"; }
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
				if ( (synpred1_ANTLRv3()) ) { s = 9; }

				else if ( (synpred2_ANTLRv3()) ) { s = 4; }

                   	 
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
			"\x05\x25\x01\x2a\x01\x25\x04\uffff\x02\x25";
		const string DFA65_maxS =
			"\x05\x5d\x01\x31\x01\x5d\x04\uffff\x02\x5d";
		const string DFA65_acceptS =
			"\x07\uffff\x01\x03\x01\x04\x01\x02\x01\x01\x02\uffff";
		const string DFA65_specialS =
			"\x0d\uffff}>";
		static readonly string[] DFA65_transitionS = {
			"\x01\x07\x04\uffff\x01\x02\x01\x04\x01\x01\x01\x06\x03\uffff"+
				"\x01\x03\x20\uffff\x01\x08\x0a\uffff\x01\x05",
			"\x01\x0a\x02\uffff\x01\x0a\x01\uffff\x04\x0a\x03\uffff\x01"+
				"\x0a\x13\uffff\x01\x0a\x04\uffff\x01\x09\x07\uffff\x03\x0a\x05"+
					"\uffff\x02\x09\x01\uffff\x01\x0a",
			"\x01\x0a\x02\uffff\x01\x0a\x01\uffff\x04\x0a\x02\uffff\x01"+
				"\x0b\x01\x0a\x13\uffff\x01\x0a\x04\uffff\x01\x09\x07\uffff\x03"+
					"\x0a\x05\uffff\x02\x09\x01\uffff\x01\x0a",
			"\x01\x0a\x02\uffff\x01\x0a\x01\uffff\x04\x0a\x03\uffff\x01"+
				"\x0a\x13\uffff\x01\x0a\x04\uffff\x01\x09\x07\uffff\x03\x0a\x05"+
					"\uffff\x02\x09\x01\uffff\x01\x0a",
			"\x01\x0a\x02\uffff\x01\x0a\x01\uffff\x04\x0a\x03\uffff\x01"+
				"\x0a\x13\uffff\x01\x0a\x04\uffff\x01\x09\x07\uffff\x03\x0a\x05"+
					"\uffff\x02\x09\x01\uffff\x01\x0a",
			"\x01\x0c\x06\uffff\x01\x0c",
			"\x01\x0a\x02\uffff\x01\x0a\x01\uffff\x04\x0a\x03\uffff\x01"+
				"\x0a\x13\uffff\x01\x0a\x04\uffff\x01\x09\x07\uffff\x03\x0a\x05"+
					"\uffff\x02\x09\x01\uffff\x01\x0a",
			"",
			"",
			"",
			"",
			"\x01\x0a\x02\uffff\x01\x0a\x01\uffff\x04\x0a\x03\uffff\x01"+
				"\x0a\x13\uffff\x01\x0a\x04\uffff\x01\x09\x07\uffff\x03\x0a\x05"+
					"\uffff\x02\x09\x01\uffff\x01\x0a",
			"\x01\x0a\x02\uffff\x01\x0a\x01\uffff\x04\x0a\x03\uffff\x01"+
				"\x0a\x13\uffff\x01\x0a\x04\uffff\x01\x09\x07\uffff\x03\x0a\x05"+
					"\uffff\x02\x09\x01\uffff\x01\x0a"
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
				get { return "334:1: rewrite_tree_element : ( rewrite_tree_atom | rewrite_tree_atom ebnfSuffix | rewrite_tree ( ebnfSuffix | ) | rewrite_tree_ebnf );"; }
			}

		}

		const string DFA70_eotS =
			"\x0f\uffff";
		const string DFA70_eofS =
			"\x06\uffff\x01\x09\x08\uffff";
		const string DFA70_minS =
			"\x01\x2a\x01\x52\x02\uffff\x01\x2a\x01\x47\x01\x28\x01\x2d\x02"+
				"\uffff\x01\x51\x01\x2a\x01\x47\x01\x2d\x01\x51";
		const string DFA70_maxS =
			"\x02\x52\x02\uffff\x01\x54\x01\x47\x01\x54\x01\x2d\x02\uffff\x01"+
				"\x54\x01\x31\x01\x47\x01\x2d\x01\x54";
		const string DFA70_acceptS =
			"\x02\uffff\x01\x03\x01\x04\x04\uffff\x01\x01\x01\x02\x05\uffff";
		const string DFA70_specialS =
			"\x0f\uffff}>";
		static readonly string[] DFA70_transitionS = {
			"\x01\x01\x02\uffff\x01\x03\x03\uffff\x01\x01\x20\uffff\x01"+
				"\x02",
			"\x01\x04",
			"",
			"",
			"\x01\x05\x06\uffff\x01\x05\x22\uffff\x01\x06",
			"\x01\x07",
			"\x01\x09\x09\uffff\x02\x08\x11\uffff\x01\x09\x0d\uffff\x02"+
				"\x09",
			"\x01\x0a",
			"",
			"",
			"\x01\x0b\x02\uffff\x01\x06",
			"\x01\x0c\x06\uffff\x01\x0c",
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
				get { return "368:1: rewrite_template : ( id lp= '(' rewrite_template_args ')' (str= DOUBLE_QUOTE_STRING_LITERAL | str= DOUBLE_ANGLE_STRING_LITERAL ) | rewrite_template_ref | rewrite_indirect_template_head | ACTION );"; }
			}

		}

 

		public static readonly BitSet FOLLOW_DOC_COMMENT_in_grammarDef335 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000000001EUL});
		public static readonly BitSet FOLLOW_65_in_grammarDef345 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
		public static readonly BitSet FOLLOW_66_in_grammarDef363 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
		public static readonly BitSet FOLLOW_67_in_grammarDef379 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
		public static readonly BitSet FOLLOW_68_in_grammarDef420 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_grammarDef422 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000020UL});
		public static readonly BitSet FOLLOW_69_in_grammarDef424 = new BitSet(new ulong[]{0x0002461080000010UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_grammarDef426 = new BitSet(new ulong[]{0x0002461080000010UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_tokensSpec_in_grammarDef429 = new BitSet(new ulong[]{0x0002461080000010UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_attrScope_in_grammarDef432 = new BitSet(new ulong[]{0x0002461080000010UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_action_in_grammarDef435 = new BitSet(new ulong[]{0x0002461080000010UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_rule_in_grammarDef443 = new BitSet(new ulong[]{0x0002461080000010UL,0x0000000000003900UL});
		public static readonly BitSet FOLLOW_EOF_in_grammarDef451 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKENS_in_tokensSpec465 = new BitSet(new ulong[]{0x0000040000000000UL});
		public static readonly BitSet FOLLOW_tokenSpec_in_tokensSpec467 = new BitSet(new ulong[]{0x0000040000000000UL,0x0000000000000040UL});
		public static readonly BitSet FOLLOW_70_in_tokensSpec470 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_tokenSpec481 = new BitSet(new ulong[]{0x0000000000000000UL,0x00000000000000A0UL});
		public static readonly BitSet FOLLOW_71_in_tokenSpec487 = new BitSet(new ulong[]{0x0000180000000000UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_tokenSpec492 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000020UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_tokenSpec496 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000020UL});
		public static readonly BitSet FOLLOW_69_in_tokenSpec520 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SCOPE_in_attrScope531 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_attrScope533 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_attrScope535 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_72_in_action548 = new BitSet(new ulong[]{0x0002040000000000UL,0x0000000000000006UL});
		public static readonly BitSet FOLLOW_actionScopeName_in_action551 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000200UL});
		public static readonly BitSet FOLLOW_73_in_action553 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_action557 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_action559 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_actionScopeName572 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_65_in_actionScopeName579 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_66_in_actionScopeName591 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_OPTIONS_in_optionsSpec602 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_option_in_optionsSpec605 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000020UL});
		public static readonly BitSet FOLLOW_69_in_optionsSpec607 = new BitSet(new ulong[]{0x0002040000000000UL,0x0000000000000040UL});
		public static readonly BitSet FOLLOW_70_in_optionsSpec611 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_option627 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000080UL});
		public static readonly BitSet FOLLOW_71_in_option629 = new BitSet(new ulong[]{0x00029C0000000000UL,0x0000000000000400UL});
		public static readonly BitSet FOLLOW_optionValue_in_option631 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_optionValue650 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_optionValue660 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_optionValue670 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_INT_in_optionValue680 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_74_in_optionValue690 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOC_COMMENT_in_rule710 = new BitSet(new ulong[]{0x0002041000000000UL,0x0000000000003800UL});
		public static readonly BitSet FOLLOW_set_in_rule719 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_rule734 = new BitSet(new ulong[]{0x0001408080000000UL,0x000000000001C100UL});
		public static readonly BitSet FOLLOW_BANG_in_rule740 = new BitSet(new ulong[]{0x0001400080000000UL,0x000000000001C100UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rule749 = new BitSet(new ulong[]{0x0000400080000000UL,0x000000000001C100UL});
		public static readonly BitSet FOLLOW_78_in_rule758 = new BitSet(new ulong[]{0x0001000000000000UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rule762 = new BitSet(new ulong[]{0x0000400080000000UL,0x0000000000018100UL});
		public static readonly BitSet FOLLOW_throwsSpec_in_rule770 = new BitSet(new ulong[]{0x0000400080000000UL,0x0000000000008100UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_rule773 = new BitSet(new ulong[]{0x0000000080000000UL,0x0000000000008100UL});
		public static readonly BitSet FOLLOW_ruleScopeSpec_in_rule776 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008100UL});
		public static readonly BitSet FOLLOW_ruleAction_in_rule779 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008100UL});
		public static readonly BitSet FOLLOW_79_in_rule784 = new BitSet(new ulong[]{0x00023D2100000000UL,0x00000000120C0000UL});
		public static readonly BitSet FOLLOW_altList_in_rule786 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000020UL});
		public static readonly BitSet FOLLOW_69_in_rule788 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000600000UL});
		public static readonly BitSet FOLLOW_exceptionGroup_in_rule792 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_72_in_ruleAction806 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_ruleAction808 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleAction810 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_80_in_throwsSpec821 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_throwsSpec823 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_81_in_throwsSpec827 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_throwsSpec829 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_SCOPE_in_ruleScopeSpec843 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleScopeSpec845 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SCOPE_in_ruleScopeSpec850 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec852 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020020UL});
		public static readonly BitSet FOLLOW_81_in_ruleScopeSpec855 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec857 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020020UL});
		public static readonly BitSet FOLLOW_69_in_ruleScopeSpec861 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SCOPE_in_ruleScopeSpec866 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_ruleScopeSpec868 = new BitSet(new ulong[]{0x0000000080000000UL});
		public static readonly BitSet FOLLOW_SCOPE_in_ruleScopeSpec872 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec874 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020020UL});
		public static readonly BitSet FOLLOW_81_in_ruleScopeSpec877 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_ruleScopeSpec879 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020020UL});
		public static readonly BitSet FOLLOW_69_in_ruleScopeSpec883 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_82_in_block901 = new BitSet(new ulong[]{0x00027D2100000000UL,0x00000000121C8000UL});
		public static readonly BitSet FOLLOW_optionsSpec_in_block910 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
		public static readonly BitSet FOLLOW_79_in_block914 = new BitSet(new ulong[]{0x00023D2100000000UL,0x00000000121C0000UL});
		public static readonly BitSet FOLLOW_alternative_in_block923 = new BitSet(new ulong[]{0x0000010000000000UL,0x0000000000180000UL});
		public static readonly BitSet FOLLOW_rewrite_in_block925 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000180000UL});
		public static readonly BitSet FOLLOW_83_in_block929 = new BitSet(new ulong[]{0x00023D2100000000UL,0x00000000121C0000UL});
		public static readonly BitSet FOLLOW_alternative_in_block933 = new BitSet(new ulong[]{0x0000010000000000UL,0x0000000000180000UL});
		public static readonly BitSet FOLLOW_rewrite_in_block935 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000180000UL});
		public static readonly BitSet FOLLOW_84_in_block950 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_alternative_in_altList976 = new BitSet(new ulong[]{0x0000010000000000UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_rewrite_in_altList978 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_83_in_altList982 = new BitSet(new ulong[]{0x00023D2100000000UL,0x00000000120C0000UL});
		public static readonly BitSet FOLLOW_alternative_in_altList986 = new BitSet(new ulong[]{0x0000010000000000UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_rewrite_in_altList988 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000080000UL});
		public static readonly BitSet FOLLOW_element_in_alternative1015 = new BitSet(new ulong[]{0x00023C2100000002UL,0x0000000012040000UL});
		public static readonly BitSet FOLLOW_exceptionHandler_in_exceptionGroup1041 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000600000UL});
		public static readonly BitSet FOLLOW_finallyClause_in_exceptionGroup1048 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_finallyClause_in_exceptionGroup1056 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_85_in_exceptionHandler1076 = new BitSet(new ulong[]{0x0001000000000000UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_exceptionHandler1078 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_exceptionHandler1080 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_86_in_finallyClause1100 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_finallyClause1102 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_elementNoOptionSpec_in_element1116 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_elementNoOptionSpec1127 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000800080UL});
		public static readonly BitSet FOLLOW_71_in_elementNoOptionSpec1132 = new BitSet(new ulong[]{0x00021C0000000000UL,0x0000000012000000UL});
		public static readonly BitSet FOLLOW_87_in_elementNoOptionSpec1136 = new BitSet(new ulong[]{0x00021C0000000000UL,0x0000000012000000UL});
		public static readonly BitSet FOLLOW_atom_in_elementNoOptionSpec1139 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000C000400UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec1145 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_elementNoOptionSpec1161 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000800080UL});
		public static readonly BitSet FOLLOW_71_in_elementNoOptionSpec1166 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_87_in_elementNoOptionSpec1170 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_block_in_elementNoOptionSpec1173 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000C000400UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec1179 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_atom_in_elementNoOptionSpec1195 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000C000400UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec1201 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ebnf_in_elementNoOptionSpec1217 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_elementNoOptionSpec1224 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_SEMPRED_in_elementNoOptionSpec1231 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000001000000UL});
		public static readonly BitSet FOLLOW_88_in_elementNoOptionSpec1235 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_treeSpec_in_elementNoOptionSpec1247 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000C000400UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_elementNoOptionSpec1253 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_range_in_atom1275 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet FOLLOW_ROOT_in_atom1282 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_BANG_in_atom1286 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_terminal_in_atom1301 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_notSet_in_atom1309 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet FOLLOW_ROOT_in_atom1316 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_BANG_in_atom1320 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_RULE_REF_in_atom1335 = new BitSet(new ulong[]{0x000100C000000002UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_atom1341 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet FOLLOW_ROOT_in_atom1351 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_BANG_in_atom1355 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_89_in_notSet1373 = new BitSet(new ulong[]{0x00001C0000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_notTerminal_in_notSet1379 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_block_in_notSet1385 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TREE_BEGIN_in_treeSpec1400 = new BitSet(new ulong[]{0x00023C2100000000UL,0x0000000012040000UL});
		public static readonly BitSet FOLLOW_element_in_treeSpec1402 = new BitSet(new ulong[]{0x00023C2100000000UL,0x0000000012040000UL});
		public static readonly BitSet FOLLOW_element_in_treeSpec1406 = new BitSet(new ulong[]{0x00023C2100000000UL,0x0000000012140000UL});
		public static readonly BitSet FOLLOW_84_in_treeSpec1411 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_block_in_ebnf1434 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000D000400UL});
		public static readonly BitSet FOLLOW_90_in_ebnf1442 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_74_in_ebnf1450 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_91_in_ebnf1458 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_88_in_ebnf1466 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_range1495 = new BitSet(new ulong[]{0x0000000000002000UL});
		public static readonly BitSet FOLLOW_RANGE_in_range1497 = new BitSet(new ulong[]{0x0000100000000000UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_range1501 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_terminal1519 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_terminal1534 = new BitSet(new ulong[]{0x000100C000000002UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_terminal1541 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_terminal1562 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet FOLLOW_92_in_terminal1570 = new BitSet(new ulong[]{0x000000C000000002UL});
		public static readonly BitSet FOLLOW_set_in_terminal1582 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_notTerminal0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_ebnfSuffix0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_REWRITE_in_rewrite1680 = new BitSet(new ulong[]{0x0000000100000000UL});
		public static readonly BitSet FOLLOW_SEMPRED_in_rewrite1684 = new BitSet(new ulong[]{0x00023D2000000000UL,0x0000000020040000UL});
		public static readonly BitSet FOLLOW_rewrite_alternative_in_rewrite1688 = new BitSet(new ulong[]{0x0000010000000000UL});
		public static readonly BitSet FOLLOW_REWRITE_in_rewrite1696 = new BitSet(new ulong[]{0x00023C2000000000UL,0x0000000020040000UL});
		public static readonly BitSet FOLLOW_rewrite_alternative_in_rewrite1700 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_in_rewrite_alternative1721 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_rewrite_alternative1726 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_82_in_rewrite_tree_block1755 = new BitSet(new ulong[]{0x00023C2000000000UL,0x0000000020040000UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_rewrite_tree_block1757 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_84_in_rewrite_tree_block1759 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_element_in_rewrite_tree_alternative1776 = new BitSet(new ulong[]{0x00023C2000000002UL,0x0000000020040000UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1791 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree_element1796 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000C000400UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_rewrite_tree_element1798 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_in_rewrite_tree_element1805 = new BitSet(new ulong[]{0x0000000000000002UL,0x000000000C000400UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_rewrite_tree_element1811 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_ebnf_in_rewrite_tree_element1826 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_CHAR_LITERAL_in_rewrite_tree_atom1842 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TOKEN_REF_in_rewrite_tree_atom1849 = new BitSet(new ulong[]{0x0001000000000002UL});
		public static readonly BitSet FOLLOW_ARG_ACTION_in_rewrite_tree_atom1851 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_RULE_REF_in_rewrite_tree_atom1863 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_STRING_LITERAL_in_rewrite_tree_atom1870 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_93_in_rewrite_tree_atom1879 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_tree_atom1881 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_tree_atom1887 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_block_in_rewrite_tree_ebnf1908 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000C000400UL});
		public static readonly BitSet FOLLOW_ebnfSuffix_in_rewrite_tree_ebnf1910 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_TREE_BEGIN_in_rewrite_tree1922 = new BitSet(new ulong[]{0x00023C0000000000UL,0x0000000020000000UL});
		public static readonly BitSet FOLLOW_rewrite_tree_atom_in_rewrite_tree1924 = new BitSet(new ulong[]{0x00023C2000000000UL,0x0000000020140000UL});
		public static readonly BitSet FOLLOW_rewrite_tree_element_in_rewrite_tree1926 = new BitSet(new ulong[]{0x00023C2000000000UL,0x0000000020140000UL});
		public static readonly BitSet FOLLOW_84_in_rewrite_tree1929 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_template1947 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_82_in_rewrite_template1951 = new BitSet(new ulong[]{0x0002040000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_template1953 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_84_in_rewrite_template1955 = new BitSet(new ulong[]{0x000C000000000000UL});
		public static readonly BitSet FOLLOW_DOUBLE_QUOTE_STRING_LITERAL_in_rewrite_template1963 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_DOUBLE_ANGLE_STRING_LITERAL_in_rewrite_template1969 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_ref_in_rewrite_template1980 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_indirect_template_head_in_rewrite_template1989 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_template1998 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_template_ref2011 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_82_in_rewrite_template_ref2015 = new BitSet(new ulong[]{0x0002040000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_template_ref2017 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_84_in_rewrite_template_ref2019 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_82_in_rewrite_indirect_template_head2034 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_indirect_template_head2036 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_84_in_rewrite_indirect_template_head2038 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
		public static readonly BitSet FOLLOW_82_in_rewrite_indirect_template_head2040 = new BitSet(new ulong[]{0x0002040000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_rewrite_template_args_in_rewrite_indirect_template_head2042 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
		public static readonly BitSet FOLLOW_84_in_rewrite_indirect_template_head2044 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_arg_in_rewrite_template_args2055 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_81_in_rewrite_template_args2058 = new BitSet(new ulong[]{0x0002040000000000UL});
		public static readonly BitSet FOLLOW_rewrite_template_arg_in_rewrite_template_args2060 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000020000UL});
		public static readonly BitSet FOLLOW_id_in_rewrite_template_arg2078 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000080UL});
		public static readonly BitSet FOLLOW_71_in_rewrite_template_arg2080 = new BitSet(new ulong[]{0x0000200000000000UL});
		public static readonly BitSet FOLLOW_ACTION_in_rewrite_template_arg2082 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_set_in_id0 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_template_in_synpred1_ANTLRv31721 = new BitSet(new ulong[]{0x0000000000000002UL});
		public static readonly BitSet FOLLOW_rewrite_tree_alternative_in_synpred2_ANTLRv31726 = new BitSet(new ulong[]{0x0000000000000002UL});

	}
}
