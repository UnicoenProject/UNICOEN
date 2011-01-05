using System.Collections.Generic;
// $ANTLR 3.2 Sep 23, 2009 12:02:23 JavaScript.g 2010-12-03 00:05:54

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using Ucpf.Common.Languages.Common.Antlr;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;

using Antlr.Runtime.Tree;

public partial class JavaScriptParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"LT", 
		"Identifier", 
		"StringLiteral", 
		"NumericLiteral", 
		"DoubleStringCharacter", 
		"SingleStringCharacter", 
		"EscapeSequence", 
		"CharacterEscapeSequence", 
		"HexEscapeSequence", 
		"UnicodeEscapeSequence", 
		"SingleEscapeCharacter", 
		"NonEscapeCharacter", 
		"EscapeCharacter", 
		"DecimalDigit", 
		"HexDigit", 
		"DecimalLiteral", 
		"HexIntegerLiteral", 
		"ExponentPart", 
		"IdentifierStart", 
		"IdentifierPart", 
		"UnicodeLetter", 
		"UnicodeDigit", 
		"UnicodeConnectorPunctuation", 
		"UnicodeCombiningMark", 
		"Comment", 
		"LineComment", 
		"WhiteSpace", 
		"'function'", 
		"'('", 
		"','", 
		"')'", 
		"'{'", 
		"'}'", 
		"'var'", 
		"';'", 
		"'='", 
		"'if'", 
		"'else'", 
		"'do'", 
		"'while'", 
		"'for'", 
		"'in'", 
		"'continue'", 
		"'break'", 
		"'return'", 
		"'with'", 
		"':'", 
		"'switch'", 
		"'case'", 
		"'default'", 
		"'throw'", 
		"'try'", 
		"'catch'", 
		"'finally'", 
		"'new'", 
		"'['", 
		"']'", 
		"'.'", 
		"'*='", 
		"'/='", 
		"'%='", 
		"'+='", 
		"'-='", 
		"'<<='", 
		"'>>='", 
		"'>>>='", 
		"'&='", 
		"'^='", 
		"'|='", 
		"'?'", 
		"'||'", 
		"'&&'", 
		"'|'", 
		"'^'", 
		"'&'", 
		"'=='", 
		"'!='", 
		"'==='", 
		"'!=='", 
		"'<'", 
		"'>'", 
		"'<='", 
		"'>='", 
		"'instanceof'", 
		"'<<'", 
		"'>>'", 
		"'>>>'", 
		"'+'", 
		"'-'", 
		"'*'", 
		"'/'", 
		"'%'", 
		"'delete'", 
		"'void'", 
		"'typeof'", 
		"'++'", 
		"'--'", 
		"'~'", 
		"'!'", 
		"'this'", 
		"'null'", 
		"'true'", 
		"'false'"
    };

    public const int LT = 4;
    public const int DecimalDigit = 17;
    public const int EOF = -1;
    public const int Identifier = 5;
    public const int SingleStringCharacter = 9;
    public const int T__93 = 93;
    public const int T__94 = 94;
    public const int T__91 = 91;
    public const int T__92 = 92;
    public const int T__90 = 90;
    public const int Comment = 28;
    public const int SingleEscapeCharacter = 14;
    public const int UnicodeLetter = 24;
    public const int ExponentPart = 21;
    public const int WhiteSpace = 30;
    public const int T__99 = 99;
    public const int T__98 = 98;
    public const int T__97 = 97;
    public const int T__96 = 96;
    public const int UnicodeCombiningMark = 27;
    public const int T__95 = 95;
    public const int UnicodeDigit = 25;
    public const int T__80 = 80;
    public const int T__81 = 81;
    public const int NumericLiteral = 7;
    public const int T__82 = 82;
    public const int T__83 = 83;
    public const int IdentifierStart = 22;
    public const int DoubleStringCharacter = 8;
    public const int T__85 = 85;
    public const int T__84 = 84;
    public const int T__87 = 87;
    public const int T__86 = 86;
    public const int T__89 = 89;
    public const int T__88 = 88;
    public const int T__71 = 71;
    public const int T__72 = 72;
    public const int T__70 = 70;
    public const int CharacterEscapeSequence = 11;
    public const int T__76 = 76;
    public const int T__75 = 75;
    public const int T__74 = 74;
    public const int T__73 = 73;
    public const int EscapeSequence = 10;
    public const int T__79 = 79;
    public const int UnicodeConnectorPunctuation = 26;
    public const int T__78 = 78;
    public const int T__77 = 77;
    public const int T__68 = 68;
    public const int T__69 = 69;
    public const int T__66 = 66;
    public const int T__67 = 67;
    public const int T__64 = 64;
    public const int T__65 = 65;
    public const int T__62 = 62;
    public const int T__63 = 63;
    public const int HexEscapeSequence = 12;
    public const int LineComment = 29;
    public const int T__61 = 61;
    public const int T__60 = 60;
    public const int HexDigit = 18;
    public const int T__55 = 55;
    public const int T__56 = 56;
    public const int T__57 = 57;
    public const int T__58 = 58;
    public const int T__51 = 51;
    public const int T__52 = 52;
    public const int T__53 = 53;
    public const int T__54 = 54;
    public const int T__59 = 59;
    public const int T__103 = 103;
    public const int T__104 = 104;
    public const int T__105 = 105;
    public const int T__106 = 106;
    public const int EscapeCharacter = 16;
    public const int T__50 = 50;
    public const int IdentifierPart = 23;
    public const int T__42 = 42;
    public const int T__43 = 43;
    public const int T__40 = 40;
    public const int T__41 = 41;
    public const int T__46 = 46;
    public const int T__47 = 47;
    public const int T__44 = 44;
    public const int T__45 = 45;
    public const int T__48 = 48;
    public const int T__49 = 49;
    public const int UnicodeEscapeSequence = 13;
    public const int T__102 = 102;
    public const int T__101 = 101;
    public const int T__100 = 100;
    public const int DecimalLiteral = 19;
    public const int StringLiteral = 6;
    public const int T__31 = 31;
    public const int T__32 = 32;
    public const int T__33 = 33;
    public const int T__34 = 34;
    public const int T__35 = 35;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;
    public const int HexIntegerLiteral = 20;
    public const int NonEscapeCharacter = 15;

    // delegates
    // delegators



        public JavaScriptParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public JavaScriptParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();
            this.state.ruleMemo = new Hashtable[380+1];
             
             
        }
        
    protected XmlTreeAdaptor adaptor = new XmlTreeAdaptor();

    public XmlTreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return JavaScriptParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "JavaScript.g"; }
    }


    public class program_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "program"
    // JavaScript.g:16:1: program : ( LT )* sourceElements ( LT )* EOF ;
    public JavaScriptParser.program_return program() // throws RecognitionException [1]
    {   
        JavaScriptParser.program_return retval = new JavaScriptParser.program_return();
        retval.Start = input.LT(1);
        int program_StartIndex = input.Index();
        object root_0 = null;

        IToken LT1 = null;
        IToken LT3 = null;
        IToken EOF4 = null;
        JavaScriptParser.sourceElements_return sourceElements2 = default(JavaScriptParser.sourceElements_return);


        object LT1_tree=null;
        object LT3_tree=null;
        object EOF4_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:17:2: ( ( LT )* sourceElements ( LT )* EOF )
            // JavaScript.g:17:4: ( LT )* sourceElements ( LT )* EOF
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// JavaScript.g:17:6: ( LT )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == LT) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT1=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_program43), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop1;
            	    }
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements

            	PushFollow(FOLLOW_sourceElements_in_program47);
            	sourceElements2 = sourceElements();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElements2.Tree, sourceElements2, retval);
            	// JavaScript.g:17:26: ( LT )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == LT) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT3=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_program49), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	EOF4=(IToken)new XToken((IToken)Match(input,EOF,FOLLOW_EOF_in_program53), "EOF"); if (state.failed) return retval;

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 1, program_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "program"

    public class sourceElements_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sourceElements"
    // JavaScript.g:20:1: sourceElements : sourceElement ( ( LT )* sourceElement )* ;
    public JavaScriptParser.sourceElements_return sourceElements() // throws RecognitionException [1]
    {   
        JavaScriptParser.sourceElements_return retval = new JavaScriptParser.sourceElements_return();
        retval.Start = input.LT(1);
        int sourceElements_StartIndex = input.Index();
        object root_0 = null;

        IToken LT6 = null;
        JavaScriptParser.sourceElement_return sourceElement5 = default(JavaScriptParser.sourceElement_return);

        JavaScriptParser.sourceElement_return sourceElement7 = default(JavaScriptParser.sourceElement_return);


        object LT6_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:21:2: ( sourceElement ( ( LT )* sourceElement )* )
            // JavaScript.g:21:4: sourceElement ( ( LT )* sourceElement )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_sourceElement_in_sourceElements66);
            	sourceElement5 = sourceElement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElement5.Tree, sourceElement5, retval);
            	// JavaScript.g:21:18: ( ( LT )* sourceElement )*
            	do 
            	{
            	    int alt4 = 2;
            	    alt4 = dfa4.Predict(input);
            	    switch (alt4) 
            		{
            			case 1 :
            			    // JavaScript.g:21:19: ( LT )* sourceElement
            			    {
            			    	// JavaScript.g:21:21: ( LT )*
            			    	do 
            			    	{
            			    	    int alt3 = 2;
            			    	    int LA3_0 = input.LA(1);

            			    	    if ( (LA3_0 == LT) )
            			    	    {
            			    	        alt3 = 1;
            			    	    }


            			    	    switch (alt3) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT6=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_sourceElements69), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop3;
            			    	    }
            			    	} while (true);

            			    	loop3:
            			    		;	// Stops C# compiler whining that label 'loop3' has no statements

            			    	PushFollow(FOLLOW_sourceElement_in_sourceElements73);
            			    	sourceElement7 = sourceElement();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElement7.Tree, sourceElement7, retval);

            			    }
            			    break;

            			default:
            			    goto loop4;
            	    }
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 2, sourceElements_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "sourceElements"

    public class sourceElement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sourceElement"
    // JavaScript.g:24:1: sourceElement : ( functionDeclaration | statement );
    public JavaScriptParser.sourceElement_return sourceElement() // throws RecognitionException [1]
    {   
        JavaScriptParser.sourceElement_return retval = new JavaScriptParser.sourceElement_return();
        retval.Start = input.LT(1);
        int sourceElement_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.functionDeclaration_return functionDeclaration8 = default(JavaScriptParser.functionDeclaration_return);

        JavaScriptParser.statement_return statement9 = default(JavaScriptParser.statement_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:25:2: ( functionDeclaration | statement )
            int alt5 = 2;
            alt5 = dfa5.Predict(input);
            switch (alt5) 
            {
                case 1 :
                    // JavaScript.g:25:4: functionDeclaration
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_functionDeclaration_in_sourceElement87);
                    	functionDeclaration8 = functionDeclaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionDeclaration8.Tree, functionDeclaration8, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:26:4: statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_statement_in_sourceElement92);
                    	statement9 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement9.Tree, statement9, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 3, sourceElement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "sourceElement"

    public class functionDeclaration_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functionDeclaration"
    // JavaScript.g:30:1: functionDeclaration : 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody ;
    public JavaScriptParser.functionDeclaration_return functionDeclaration() // throws RecognitionException [1]
    {   
        JavaScriptParser.functionDeclaration_return retval = new JavaScriptParser.functionDeclaration_return();
        retval.Start = input.LT(1);
        int functionDeclaration_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal10 = null;
        IToken LT11 = null;
        IToken Identifier12 = null;
        IToken LT13 = null;
        IToken LT15 = null;
        JavaScriptParser.formalParameterList_return formalParameterList14 = default(JavaScriptParser.formalParameterList_return);

        JavaScriptParser.functionBody_return functionBody16 = default(JavaScriptParser.functionBody_return);


        object string_literal10_tree=null;
        object LT11_tree=null;
        object Identifier12_tree=null;
        object LT13_tree=null;
        object LT15_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:31:2: ( 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody )
            // JavaScript.g:31:4: 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal10=(IToken)Match(input,31,FOLLOW_31_in_functionDeclaration105); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal10_tree = (object)adaptor.Create(string_literal10, retval);
            		adaptor.AddChild(root_0, string_literal10_tree);
            	}
            	// JavaScript.g:31:17: ( LT )*
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);

            	    if ( (LA6_0 == LT) )
            	    {
            	        alt6 = 1;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT11=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionDeclaration107), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	Identifier12=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_functionDeclaration111), "Identifier"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier12_tree = (object)adaptor.Create(Identifier12, retval);
            		adaptor.AddChild(root_0, Identifier12_tree);
            	}
            	// JavaScript.g:31:33: ( LT )*
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( (LA7_0 == LT) )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT13=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionDeclaration113), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	PushFollow(FOLLOW_formalParameterList_in_functionDeclaration117);
            	formalParameterList14 = formalParameterList();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameterList14.Tree, formalParameterList14, retval);
            	// JavaScript.g:31:58: ( LT )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);

            	    if ( (LA8_0 == LT) )
            	    {
            	        alt8 = 1;
            	    }


            	    switch (alt8) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT15=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionDeclaration119), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements

            	PushFollow(FOLLOW_functionBody_in_functionDeclaration123);
            	functionBody16 = functionBody();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionBody16.Tree, functionBody16, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 4, functionDeclaration_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "functionDeclaration"

    public class functionExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functionExpression"
    // JavaScript.g:34:1: functionExpression : 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody ;
    public JavaScriptParser.functionExpression_return functionExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.functionExpression_return retval = new JavaScriptParser.functionExpression_return();
        retval.Start = input.LT(1);
        int functionExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal17 = null;
        IToken LT18 = null;
        IToken Identifier19 = null;
        IToken LT20 = null;
        IToken LT22 = null;
        JavaScriptParser.formalParameterList_return formalParameterList21 = default(JavaScriptParser.formalParameterList_return);

        JavaScriptParser.functionBody_return functionBody23 = default(JavaScriptParser.functionBody_return);


        object string_literal17_tree=null;
        object LT18_tree=null;
        object Identifier19_tree=null;
        object LT20_tree=null;
        object LT22_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 5) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:35:2: ( 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody )
            // JavaScript.g:35:4: 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal17=(IToken)Match(input,31,FOLLOW_31_in_functionExpression135); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal17_tree = (object)adaptor.Create(string_literal17, retval);
            		adaptor.AddChild(root_0, string_literal17_tree);
            	}
            	// JavaScript.g:35:17: ( LT )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( (LA9_0 == LT) )
            	    {
            	        int LA9_2 = input.LA(2);

            	        if ( (synpred9_JavaScript()) )
            	        {
            	            alt9 = 1;
            	        }


            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT18=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionExpression137), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	// JavaScript.g:35:20: ( Identifier )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( (LA10_0 == Identifier) )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: Identifier
            	        {
            	        	Identifier19=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_functionExpression141), "Identifier"); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier19_tree = (object)adaptor.Create(Identifier19, retval);
            	        		adaptor.AddChild(root_0, Identifier19_tree);
            	        	}

            	        }
            	        break;

            	}

            	// JavaScript.g:35:34: ( LT )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);

            	    if ( (LA11_0 == LT) )
            	    {
            	        alt11 = 1;
            	    }


            	    switch (alt11) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT20=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionExpression144), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	PushFollow(FOLLOW_formalParameterList_in_functionExpression148);
            	formalParameterList21 = formalParameterList();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameterList21.Tree, formalParameterList21, retval);
            	// JavaScript.g:35:59: ( LT )*
            	do 
            	{
            	    int alt12 = 2;
            	    int LA12_0 = input.LA(1);

            	    if ( (LA12_0 == LT) )
            	    {
            	        alt12 = 1;
            	    }


            	    switch (alt12) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT22=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionExpression150), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements

            	PushFollow(FOLLOW_functionBody_in_functionExpression154);
            	functionBody23 = functionBody();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionBody23.Tree, functionBody23, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 5, functionExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "functionExpression"

    public class formalParameterList_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "formalParameterList"
    // JavaScript.g:38:1: formalParameterList : '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* ')' ;
    public JavaScriptParser.formalParameterList_return formalParameterList() // throws RecognitionException [1]
    {   
        JavaScriptParser.formalParameterList_return retval = new JavaScriptParser.formalParameterList_return();
        retval.Start = input.LT(1);
        int formalParameterList_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal24 = null;
        IToken LT25 = null;
        IToken Identifier26 = null;
        IToken LT27 = null;
        IToken char_literal28 = null;
        IToken LT29 = null;
        IToken Identifier30 = null;
        IToken LT31 = null;
        IToken char_literal32 = null;

        object char_literal24_tree=null;
        object LT25_tree=null;
        object Identifier26_tree=null;
        object LT27_tree=null;
        object char_literal28_tree=null;
        object LT29_tree=null;
        object Identifier30_tree=null;
        object LT31_tree=null;
        object char_literal32_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 6) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:39:2: ( '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* ')' )
            // JavaScript.g:39:4: '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* ')'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal24=(IToken)Match(input,32,FOLLOW_32_in_formalParameterList166); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal24_tree = (object)adaptor.Create(char_literal24, retval);
            		adaptor.AddChild(root_0, char_literal24_tree);
            	}
            	// JavaScript.g:39:8: ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )?
            	int alt17 = 2;
            	alt17 = dfa17.Predict(input);
            	switch (alt17) 
            	{
            	    case 1 :
            	        // JavaScript.g:39:9: ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )*
            	        {
            	        	// JavaScript.g:39:11: ( LT )*
            	        	do 
            	        	{
            	        	    int alt13 = 2;
            	        	    int LA13_0 = input.LA(1);

            	        	    if ( (LA13_0 == LT) )
            	        	    {
            	        	        alt13 = 1;
            	        	    }


            	        	    switch (alt13) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT25=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList169), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop13;
            	        	    }
            	        	} while (true);

            	        	loop13:
            	        		;	// Stops C# compiler whining that label 'loop13' has no statements

            	        	Identifier26=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_formalParameterList173), "Identifier"); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier26_tree = (object)adaptor.Create(Identifier26, retval);
            	        		adaptor.AddChild(root_0, Identifier26_tree);
            	        	}
            	        	// JavaScript.g:39:25: ( ( LT )* ',' ( LT )* Identifier )*
            	        	do 
            	        	{
            	        	    int alt16 = 2;
            	        	    alt16 = dfa16.Predict(input);
            	        	    switch (alt16) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:39:26: ( LT )* ',' ( LT )* Identifier
            	        			    {
            	        			    	// JavaScript.g:39:28: ( LT )*
            	        			    	do 
            	        			    	{
            	        			    	    int alt14 = 2;
            	        			    	    int LA14_0 = input.LA(1);

            	        			    	    if ( (LA14_0 == LT) )
            	        			    	    {
            	        			    	        alt14 = 1;
            	        			    	    }


            	        			    	    switch (alt14) 
            	        			    		{
            	        			    			case 1 :
            	        			    			    // JavaScript.g:0:0: LT
            	        			    			    {
            	        			    			    	LT27=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList176), "LT"); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop14;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop14:
            	        			    		;	// Stops C# compiler whining that label 'loop14' has no statements

            	        			    	char_literal28=(IToken)Match(input,33,FOLLOW_33_in_formalParameterList180); if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 )
            	        			    	{char_literal28_tree = (object)adaptor.Create(char_literal28, retval);
            	        			    		adaptor.AddChild(root_0, char_literal28_tree);
            	        			    	}
            	        			    	// JavaScript.g:39:37: ( LT )*
            	        			    	do 
            	        			    	{
            	        			    	    int alt15 = 2;
            	        			    	    int LA15_0 = input.LA(1);

            	        			    	    if ( (LA15_0 == LT) )
            	        			    	    {
            	        			    	        alt15 = 1;
            	        			    	    }


            	        			    	    switch (alt15) 
            	        			    		{
            	        			    			case 1 :
            	        			    			    // JavaScript.g:0:0: LT
            	        			    			    {
            	        			    			    	LT29=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList182), "LT"); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop15;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop15:
            	        			    		;	// Stops C# compiler whining that label 'loop15' has no statements

            	        			    	Identifier30=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_formalParameterList186), "Identifier"); if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 )
            	        			    	{Identifier30_tree = (object)adaptor.Create(Identifier30, retval);
            	        			    		adaptor.AddChild(root_0, Identifier30_tree);
            	        			    	}

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop16;
            	        	    }
            	        	} while (true);

            	        	loop16:
            	        		;	// Stops C# compiler whining that label 'loop16' has no statements


            	        }
            	        break;

            	}

            	// JavaScript.g:39:57: ( LT )*
            	do 
            	{
            	    int alt18 = 2;
            	    int LA18_0 = input.LA(1);

            	    if ( (LA18_0 == LT) )
            	    {
            	        alt18 = 1;
            	    }


            	    switch (alt18) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT31=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList192), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop18;
            	    }
            	} while (true);

            	loop18:
            		;	// Stops C# compiler whining that label 'loop18' has no statements

            	char_literal32=(IToken)Match(input,34,FOLLOW_34_in_formalParameterList196); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal32_tree = (object)adaptor.Create(char_literal32, retval);
            		adaptor.AddChild(root_0, char_literal32_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 6, formalParameterList_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "formalParameterList"

    public class functionBody_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functionBody"
    // JavaScript.g:42:1: functionBody : '{' ( LT )* sourceElements ( LT )* '}' ;
    public JavaScriptParser.functionBody_return functionBody() // throws RecognitionException [1]
    {   
        JavaScriptParser.functionBody_return retval = new JavaScriptParser.functionBody_return();
        retval.Start = input.LT(1);
        int functionBody_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal33 = null;
        IToken LT34 = null;
        IToken LT36 = null;
        IToken char_literal37 = null;
        JavaScriptParser.sourceElements_return sourceElements35 = default(JavaScriptParser.sourceElements_return);


        object char_literal33_tree=null;
        object LT34_tree=null;
        object LT36_tree=null;
        object char_literal37_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 7) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:43:2: ( '{' ( LT )* sourceElements ( LT )* '}' )
            // JavaScript.g:43:4: '{' ( LT )* sourceElements ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal33=(IToken)Match(input,35,FOLLOW_35_in_functionBody207); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal33_tree = (object)adaptor.Create(char_literal33, retval);
            		adaptor.AddChild(root_0, char_literal33_tree);
            	}
            	// JavaScript.g:43:10: ( LT )*
            	do 
            	{
            	    int alt19 = 2;
            	    int LA19_0 = input.LA(1);

            	    if ( (LA19_0 == LT) )
            	    {
            	        alt19 = 1;
            	    }


            	    switch (alt19) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT34=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionBody209), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements

            	PushFollow(FOLLOW_sourceElements_in_functionBody213);
            	sourceElements35 = sourceElements();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElements35.Tree, sourceElements35, retval);
            	// JavaScript.g:43:30: ( LT )*
            	do 
            	{
            	    int alt20 = 2;
            	    int LA20_0 = input.LA(1);

            	    if ( (LA20_0 == LT) )
            	    {
            	        alt20 = 1;
            	    }


            	    switch (alt20) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT36=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_functionBody215), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop20;
            	    }
            	} while (true);

            	loop20:
            		;	// Stops C# compiler whining that label 'loop20' has no statements

            	char_literal37=(IToken)Match(input,36,FOLLOW_36_in_functionBody219); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal37_tree = (object)adaptor.Create(char_literal37, retval);
            		adaptor.AddChild(root_0, char_literal37_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 7, functionBody_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "functionBody"

    public class statement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statement"
    // JavaScript.g:47:1: statement : ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );
    public JavaScriptParser.statement_return statement() // throws RecognitionException [1]
    {   
        JavaScriptParser.statement_return retval = new JavaScriptParser.statement_return();
        retval.Start = input.LT(1);
        int statement_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.statementBlock_return statementBlock38 = default(JavaScriptParser.statementBlock_return);

        JavaScriptParser.variableStatement_return variableStatement39 = default(JavaScriptParser.variableStatement_return);

        JavaScriptParser.emptyStatement_return emptyStatement40 = default(JavaScriptParser.emptyStatement_return);

        JavaScriptParser.expressionStatement_return expressionStatement41 = default(JavaScriptParser.expressionStatement_return);

        JavaScriptParser.ifStatement_return ifStatement42 = default(JavaScriptParser.ifStatement_return);

        JavaScriptParser.iterationStatement_return iterationStatement43 = default(JavaScriptParser.iterationStatement_return);

        JavaScriptParser.continueStatement_return continueStatement44 = default(JavaScriptParser.continueStatement_return);

        JavaScriptParser.breakStatement_return breakStatement45 = default(JavaScriptParser.breakStatement_return);

        JavaScriptParser.returnStatement_return returnStatement46 = default(JavaScriptParser.returnStatement_return);

        JavaScriptParser.withStatement_return withStatement47 = default(JavaScriptParser.withStatement_return);

        JavaScriptParser.labelledStatement_return labelledStatement48 = default(JavaScriptParser.labelledStatement_return);

        JavaScriptParser.switchStatement_return switchStatement49 = default(JavaScriptParser.switchStatement_return);

        JavaScriptParser.throwStatement_return throwStatement50 = default(JavaScriptParser.throwStatement_return);

        JavaScriptParser.tryStatement_return tryStatement51 = default(JavaScriptParser.tryStatement_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 8) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:48:2: ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement )
            int alt21 = 14;
            alt21 = dfa21.Predict(input);
            switch (alt21) 
            {
                case 1 :
                    // JavaScript.g:48:4: statementBlock
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_statementBlock_in_statement231);
                    	statementBlock38 = statementBlock();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock38.Tree, statementBlock38, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:49:4: variableStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_variableStatement_in_statement236);
                    	variableStatement39 = variableStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableStatement39.Tree, variableStatement39, retval);

                    }
                    break;
                case 3 :
                    // JavaScript.g:50:4: emptyStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_emptyStatement_in_statement241);
                    	emptyStatement40 = emptyStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, emptyStatement40.Tree, emptyStatement40, retval);

                    }
                    break;
                case 4 :
                    // JavaScript.g:51:4: expressionStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expressionStatement_in_statement246);
                    	expressionStatement41 = expressionStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionStatement41.Tree, expressionStatement41, retval);

                    }
                    break;
                case 5 :
                    // JavaScript.g:52:4: ifStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_ifStatement_in_statement251);
                    	ifStatement42 = ifStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ifStatement42.Tree, ifStatement42, retval);

                    }
                    break;
                case 6 :
                    // JavaScript.g:53:4: iterationStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_iterationStatement_in_statement256);
                    	iterationStatement43 = iterationStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, iterationStatement43.Tree, iterationStatement43, retval);

                    }
                    break;
                case 7 :
                    // JavaScript.g:54:4: continueStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_continueStatement_in_statement261);
                    	continueStatement44 = continueStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, continueStatement44.Tree, continueStatement44, retval);

                    }
                    break;
                case 8 :
                    // JavaScript.g:55:4: breakStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_breakStatement_in_statement266);
                    	breakStatement45 = breakStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, breakStatement45.Tree, breakStatement45, retval);

                    }
                    break;
                case 9 :
                    // JavaScript.g:56:4: returnStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_returnStatement_in_statement271);
                    	returnStatement46 = returnStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, returnStatement46.Tree, returnStatement46, retval);

                    }
                    break;
                case 10 :
                    // JavaScript.g:57:4: withStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_withStatement_in_statement276);
                    	withStatement47 = withStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, withStatement47.Tree, withStatement47, retval);

                    }
                    break;
                case 11 :
                    // JavaScript.g:58:4: labelledStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_labelledStatement_in_statement281);
                    	labelledStatement48 = labelledStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, labelledStatement48.Tree, labelledStatement48, retval);

                    }
                    break;
                case 12 :
                    // JavaScript.g:59:4: switchStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_switchStatement_in_statement286);
                    	switchStatement49 = switchStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, switchStatement49.Tree, switchStatement49, retval);

                    }
                    break;
                case 13 :
                    // JavaScript.g:60:4: throwStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_throwStatement_in_statement291);
                    	throwStatement50 = throwStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, throwStatement50.Tree, throwStatement50, retval);

                    }
                    break;
                case 14 :
                    // JavaScript.g:61:4: tryStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_tryStatement_in_statement296);
                    	tryStatement51 = tryStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, tryStatement51.Tree, tryStatement51, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 8, statement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "statement"

    public class statementBlock_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statementBlock"
    // JavaScript.g:64:1: statementBlock : '{' ( LT )* ( statementList )? ( LT )* '}' ;
    public JavaScriptParser.statementBlock_return statementBlock() // throws RecognitionException [1]
    {   
        JavaScriptParser.statementBlock_return retval = new JavaScriptParser.statementBlock_return();
        retval.Start = input.LT(1);
        int statementBlock_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal52 = null;
        IToken LT53 = null;
        IToken LT55 = null;
        IToken char_literal56 = null;
        JavaScriptParser.statementList_return statementList54 = default(JavaScriptParser.statementList_return);


        object char_literal52_tree=null;
        object LT53_tree=null;
        object LT55_tree=null;
        object char_literal56_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 9) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:65:2: ( '{' ( LT )* ( statementList )? ( LT )* '}' )
            // JavaScript.g:65:4: '{' ( LT )* ( statementList )? ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal52=(IToken)Match(input,35,FOLLOW_35_in_statementBlock308); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal52_tree = (object)adaptor.Create(char_literal52, retval);
            		adaptor.AddChild(root_0, char_literal52_tree);
            	}
            	// JavaScript.g:65:10: ( LT )*
            	do 
            	{
            	    int alt22 = 2;
            	    int LA22_0 = input.LA(1);

            	    if ( (LA22_0 == LT) )
            	    {
            	        int LA22_2 = input.LA(2);

            	        if ( (synpred34_JavaScript()) )
            	        {
            	            alt22 = 1;
            	        }


            	    }


            	    switch (alt22) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT53=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_statementBlock310), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements

            	// JavaScript.g:65:13: ( statementList )?
            	int alt23 = 2;
            	int LA23_0 = input.LA(1);

            	if ( ((LA23_0 >= Identifier && LA23_0 <= NumericLiteral) || (LA23_0 >= 31 && LA23_0 <= 32) || LA23_0 == 35 || (LA23_0 >= 37 && LA23_0 <= 38) || LA23_0 == 40 || (LA23_0 >= 42 && LA23_0 <= 44) || (LA23_0 >= 46 && LA23_0 <= 49) || LA23_0 == 51 || (LA23_0 >= 54 && LA23_0 <= 55) || (LA23_0 >= 58 && LA23_0 <= 59) || (LA23_0 >= 91 && LA23_0 <= 92) || (LA23_0 >= 96 && LA23_0 <= 106)) )
            	{
            	    alt23 = 1;
            	}
            	switch (alt23) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: statementList
            	        {
            	        	PushFollow(FOLLOW_statementList_in_statementBlock314);
            	        	statementList54 = statementList();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList54.Tree, statementList54, retval);

            	        }
            	        break;

            	}

            	// JavaScript.g:65:30: ( LT )*
            	do 
            	{
            	    int alt24 = 2;
            	    int LA24_0 = input.LA(1);

            	    if ( (LA24_0 == LT) )
            	    {
            	        alt24 = 1;
            	    }


            	    switch (alt24) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT55=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_statementBlock317), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop24;
            	    }
            	} while (true);

            	loop24:
            		;	// Stops C# compiler whining that label 'loop24' has no statements

            	char_literal56=(IToken)Match(input,36,FOLLOW_36_in_statementBlock321); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal56_tree = (object)adaptor.Create(char_literal56, retval);
            		adaptor.AddChild(root_0, char_literal56_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 9, statementBlock_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "statementBlock"

    public class statementList_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statementList"
    // JavaScript.g:68:1: statementList : statement ( ( LT )* statement )* ;
    public JavaScriptParser.statementList_return statementList() // throws RecognitionException [1]
    {   
        JavaScriptParser.statementList_return retval = new JavaScriptParser.statementList_return();
        retval.Start = input.LT(1);
        int statementList_StartIndex = input.Index();
        object root_0 = null;

        IToken LT58 = null;
        JavaScriptParser.statement_return statement57 = default(JavaScriptParser.statement_return);

        JavaScriptParser.statement_return statement59 = default(JavaScriptParser.statement_return);


        object LT58_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 10) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:69:2: ( statement ( ( LT )* statement )* )
            // JavaScript.g:69:4: statement ( ( LT )* statement )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_statement_in_statementList333);
            	statement57 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement57.Tree, statement57, retval);
            	// JavaScript.g:69:14: ( ( LT )* statement )*
            	do 
            	{
            	    int alt26 = 2;
            	    alt26 = dfa26.Predict(input);
            	    switch (alt26) 
            		{
            			case 1 :
            			    // JavaScript.g:69:15: ( LT )* statement
            			    {
            			    	// JavaScript.g:69:17: ( LT )*
            			    	do 
            			    	{
            			    	    int alt25 = 2;
            			    	    int LA25_0 = input.LA(1);

            			    	    if ( (LA25_0 == LT) )
            			    	    {
            			    	        alt25 = 1;
            			    	    }


            			    	    switch (alt25) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT58=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_statementList336), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop25;
            			    	    }
            			    	} while (true);

            			    	loop25:
            			    		;	// Stops C# compiler whining that label 'loop25' has no statements

            			    	PushFollow(FOLLOW_statement_in_statementList340);
            			    	statement59 = statement();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement59.Tree, statement59, retval);

            			    }
            			    break;

            			default:
            			    goto loop26;
            	    }
            	} while (true);

            	loop26:
            		;	// Stops C# compiler whining that label 'loop26' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 10, statementList_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "statementList"

    public class variableStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableStatement"
    // JavaScript.g:72:1: variableStatement : 'var' ( LT )* variableDeclarationList ( LT | ';' ) ;
    public JavaScriptParser.variableStatement_return variableStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.variableStatement_return retval = new JavaScriptParser.variableStatement_return();
        retval.Start = input.LT(1);
        int variableStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal60 = null;
        IToken LT61 = null;
        IToken set63 = null;
        JavaScriptParser.variableDeclarationList_return variableDeclarationList62 = default(JavaScriptParser.variableDeclarationList_return);


        object string_literal60_tree=null;
        object LT61_tree=null;
        object set63_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 11) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:73:2: ( 'var' ( LT )* variableDeclarationList ( LT | ';' ) )
            // JavaScript.g:73:4: 'var' ( LT )* variableDeclarationList ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal60=(IToken)Match(input,37,FOLLOW_37_in_variableStatement354); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal60_tree = (object)adaptor.Create(string_literal60, retval);
            		adaptor.AddChild(root_0, string_literal60_tree);
            	}
            	// JavaScript.g:73:12: ( LT )*
            	do 
            	{
            	    int alt27 = 2;
            	    int LA27_0 = input.LA(1);

            	    if ( (LA27_0 == LT) )
            	    {
            	        alt27 = 1;
            	    }


            	    switch (alt27) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT61=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_variableStatement356), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop27;
            	    }
            	} while (true);

            	loop27:
            		;	// Stops C# compiler whining that label 'loop27' has no statements

            	PushFollow(FOLLOW_variableDeclarationList_in_variableStatement360);
            	variableDeclarationList62 = variableDeclarationList();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationList62.Tree, variableDeclarationList62, retval);
            	set63 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set63, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 11, variableStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "variableStatement"

    public class variableDeclarationList_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclarationList"
    // JavaScript.g:76:1: variableDeclarationList : variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )* ;
    public JavaScriptParser.variableDeclarationList_return variableDeclarationList() // throws RecognitionException [1]
    {   
        JavaScriptParser.variableDeclarationList_return retval = new JavaScriptParser.variableDeclarationList_return();
        retval.Start = input.LT(1);
        int variableDeclarationList_StartIndex = input.Index();
        object root_0 = null;

        IToken LT65 = null;
        IToken char_literal66 = null;
        IToken LT67 = null;
        JavaScriptParser.variableDeclaration_return variableDeclaration64 = default(JavaScriptParser.variableDeclaration_return);

        JavaScriptParser.variableDeclaration_return variableDeclaration68 = default(JavaScriptParser.variableDeclaration_return);


        object LT65_tree=null;
        object char_literal66_tree=null;
        object LT67_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 12) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:77:2: ( variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )* )
            // JavaScript.g:77:4: variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_variableDeclaration_in_variableDeclarationList380);
            	variableDeclaration64 = variableDeclaration();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclaration64.Tree, variableDeclaration64, retval);
            	// JavaScript.g:77:24: ( ( LT )* ',' ( LT )* variableDeclaration )*
            	do 
            	{
            	    int alt30 = 2;
            	    alt30 = dfa30.Predict(input);
            	    switch (alt30) 
            		{
            			case 1 :
            			    // JavaScript.g:77:25: ( LT )* ',' ( LT )* variableDeclaration
            			    {
            			    	// JavaScript.g:77:27: ( LT )*
            			    	do 
            			    	{
            			    	    int alt28 = 2;
            			    	    int LA28_0 = input.LA(1);

            			    	    if ( (LA28_0 == LT) )
            			    	    {
            			    	        alt28 = 1;
            			    	    }


            			    	    switch (alt28) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT65=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationList383), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop28;
            			    	    }
            			    	} while (true);

            			    	loop28:
            			    		;	// Stops C# compiler whining that label 'loop28' has no statements

            			    	char_literal66=(IToken)Match(input,33,FOLLOW_33_in_variableDeclarationList387); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal66_tree = (object)adaptor.Create(char_literal66, retval);
            			    		adaptor.AddChild(root_0, char_literal66_tree);
            			    	}
            			    	// JavaScript.g:77:36: ( LT )*
            			    	do 
            			    	{
            			    	    int alt29 = 2;
            			    	    int LA29_0 = input.LA(1);

            			    	    if ( (LA29_0 == LT) )
            			    	    {
            			    	        alt29 = 1;
            			    	    }


            			    	    switch (alt29) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT67=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationList389), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop29;
            			    	    }
            			    	} while (true);

            			    	loop29:
            			    		;	// Stops C# compiler whining that label 'loop29' has no statements

            			    	PushFollow(FOLLOW_variableDeclaration_in_variableDeclarationList393);
            			    	variableDeclaration68 = variableDeclaration();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclaration68.Tree, variableDeclaration68, retval);

            			    }
            			    break;

            			default:
            			    goto loop30;
            	    }
            	} while (true);

            	loop30:
            		;	// Stops C# compiler whining that label 'loop30' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 12, variableDeclarationList_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "variableDeclarationList"

    public class variableDeclarationListNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclarationListNoIn"
    // JavaScript.g:80:1: variableDeclarationListNoIn : variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )* ;
    public JavaScriptParser.variableDeclarationListNoIn_return variableDeclarationListNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.variableDeclarationListNoIn_return retval = new JavaScriptParser.variableDeclarationListNoIn_return();
        retval.Start = input.LT(1);
        int variableDeclarationListNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT70 = null;
        IToken char_literal71 = null;
        IToken LT72 = null;
        JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn69 = default(JavaScriptParser.variableDeclarationNoIn_return);

        JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn73 = default(JavaScriptParser.variableDeclarationNoIn_return);


        object LT70_tree=null;
        object char_literal71_tree=null;
        object LT72_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 13) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:81:2: ( variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )* )
            // JavaScript.g:81:4: variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn407);
            	variableDeclarationNoIn69 = variableDeclarationNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn69.Tree, variableDeclarationNoIn69, retval);
            	// JavaScript.g:81:28: ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*
            	do 
            	{
            	    int alt33 = 2;
            	    alt33 = dfa33.Predict(input);
            	    switch (alt33) 
            		{
            			case 1 :
            			    // JavaScript.g:81:29: ( LT )* ',' ( LT )* variableDeclarationNoIn
            			    {
            			    	// JavaScript.g:81:31: ( LT )*
            			    	do 
            			    	{
            			    	    int alt31 = 2;
            			    	    int LA31_0 = input.LA(1);

            			    	    if ( (LA31_0 == LT) )
            			    	    {
            			    	        alt31 = 1;
            			    	    }


            			    	    switch (alt31) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT70=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationListNoIn410), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop31;
            			    	    }
            			    	} while (true);

            			    	loop31:
            			    		;	// Stops C# compiler whining that label 'loop31' has no statements

            			    	char_literal71=(IToken)Match(input,33,FOLLOW_33_in_variableDeclarationListNoIn414); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal71_tree = (object)adaptor.Create(char_literal71, retval);
            			    		adaptor.AddChild(root_0, char_literal71_tree);
            			    	}
            			    	// JavaScript.g:81:40: ( LT )*
            			    	do 
            			    	{
            			    	    int alt32 = 2;
            			    	    int LA32_0 = input.LA(1);

            			    	    if ( (LA32_0 == LT) )
            			    	    {
            			    	        alt32 = 1;
            			    	    }


            			    	    switch (alt32) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT72=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationListNoIn416), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop32;
            			    	    }
            			    	} while (true);

            			    	loop32:
            			    		;	// Stops C# compiler whining that label 'loop32' has no statements

            			    	PushFollow(FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn420);
            			    	variableDeclarationNoIn73 = variableDeclarationNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn73.Tree, variableDeclarationNoIn73, retval);

            			    }
            			    break;

            			default:
            			    goto loop33;
            	    }
            	} while (true);

            	loop33:
            		;	// Stops C# compiler whining that label 'loop33' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 13, variableDeclarationListNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "variableDeclarationListNoIn"

    public class variableDeclaration_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclaration"
    // JavaScript.g:84:1: variableDeclaration : Identifier ( LT )* ( initialiser )? ;
    public JavaScriptParser.variableDeclaration_return variableDeclaration() // throws RecognitionException [1]
    {   
        JavaScriptParser.variableDeclaration_return retval = new JavaScriptParser.variableDeclaration_return();
        retval.Start = input.LT(1);
        int variableDeclaration_StartIndex = input.Index();
        object root_0 = null;

        IToken Identifier74 = null;
        IToken LT75 = null;
        JavaScriptParser.initialiser_return initialiser76 = default(JavaScriptParser.initialiser_return);


        object Identifier74_tree=null;
        object LT75_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 14) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:85:2: ( Identifier ( LT )* ( initialiser )? )
            // JavaScript.g:85:4: Identifier ( LT )* ( initialiser )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	Identifier74=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_variableDeclaration434), "Identifier"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier74_tree = (object)adaptor.Create(Identifier74, retval);
            		adaptor.AddChild(root_0, Identifier74_tree);
            	}
            	// JavaScript.g:85:17: ( LT )*
            	do 
            	{
            	    int alt34 = 2;
            	    int LA34_0 = input.LA(1);

            	    if ( (LA34_0 == LT) )
            	    {
            	        int LA34_2 = input.LA(2);

            	        if ( (synpred47_JavaScript()) )
            	        {
            	            alt34 = 1;
            	        }


            	    }


            	    switch (alt34) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT75=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_variableDeclaration436), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop34;
            	    }
            	} while (true);

            	loop34:
            		;	// Stops C# compiler whining that label 'loop34' has no statements

            	// JavaScript.g:85:20: ( initialiser )?
            	int alt35 = 2;
            	int LA35_0 = input.LA(1);

            	if ( (LA35_0 == 39) )
            	{
            	    alt35 = 1;
            	}
            	switch (alt35) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: initialiser
            	        {
            	        	PushFollow(FOLLOW_initialiser_in_variableDeclaration440);
            	        	initialiser76 = initialiser();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initialiser76.Tree, initialiser76, retval);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 14, variableDeclaration_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "variableDeclaration"

    public class variableDeclarationNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclarationNoIn"
    // JavaScript.g:88:1: variableDeclarationNoIn : Identifier ( LT )* ( initialiserNoIn )? ;
    public JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.variableDeclarationNoIn_return retval = new JavaScriptParser.variableDeclarationNoIn_return();
        retval.Start = input.LT(1);
        int variableDeclarationNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken Identifier77 = null;
        IToken LT78 = null;
        JavaScriptParser.initialiserNoIn_return initialiserNoIn79 = default(JavaScriptParser.initialiserNoIn_return);


        object Identifier77_tree=null;
        object LT78_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 15) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:89:2: ( Identifier ( LT )* ( initialiserNoIn )? )
            // JavaScript.g:89:4: Identifier ( LT )* ( initialiserNoIn )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	Identifier77=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_variableDeclarationNoIn453), "Identifier"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier77_tree = (object)adaptor.Create(Identifier77, retval);
            		adaptor.AddChild(root_0, Identifier77_tree);
            	}
            	// JavaScript.g:89:17: ( LT )*
            	do 
            	{
            	    int alt36 = 2;
            	    int LA36_0 = input.LA(1);

            	    if ( (LA36_0 == LT) )
            	    {
            	        int LA36_2 = input.LA(2);

            	        if ( (synpred49_JavaScript()) )
            	        {
            	            alt36 = 1;
            	        }


            	    }


            	    switch (alt36) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT78=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationNoIn455), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop36;
            	    }
            	} while (true);

            	loop36:
            		;	// Stops C# compiler whining that label 'loop36' has no statements

            	// JavaScript.g:89:20: ( initialiserNoIn )?
            	int alt37 = 2;
            	int LA37_0 = input.LA(1);

            	if ( (LA37_0 == 39) )
            	{
            	    alt37 = 1;
            	}
            	switch (alt37) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: initialiserNoIn
            	        {
            	        	PushFollow(FOLLOW_initialiserNoIn_in_variableDeclarationNoIn459);
            	        	initialiserNoIn79 = initialiserNoIn();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initialiserNoIn79.Tree, initialiserNoIn79, retval);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 15, variableDeclarationNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "variableDeclarationNoIn"

    public class initialiser_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "initialiser"
    // JavaScript.g:92:1: initialiser : '=' ( LT )* assignmentExpression ;
    public JavaScriptParser.initialiser_return initialiser() // throws RecognitionException [1]
    {   
        JavaScriptParser.initialiser_return retval = new JavaScriptParser.initialiser_return();
        retval.Start = input.LT(1);
        int initialiser_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal80 = null;
        IToken LT81 = null;
        JavaScriptParser.assignmentExpression_return assignmentExpression82 = default(JavaScriptParser.assignmentExpression_return);


        object char_literal80_tree=null;
        object LT81_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 16) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:93:2: ( '=' ( LT )* assignmentExpression )
            // JavaScript.g:93:4: '=' ( LT )* assignmentExpression
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal80=(IToken)Match(input,39,FOLLOW_39_in_initialiser472); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal80_tree = (object)adaptor.Create(char_literal80, retval);
            		adaptor.AddChild(root_0, char_literal80_tree);
            	}
            	// JavaScript.g:93:10: ( LT )*
            	do 
            	{
            	    int alt38 = 2;
            	    int LA38_0 = input.LA(1);

            	    if ( (LA38_0 == LT) )
            	    {
            	        alt38 = 1;
            	    }


            	    switch (alt38) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT81=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_initialiser474), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop38;
            	    }
            	} while (true);

            	loop38:
            		;	// Stops C# compiler whining that label 'loop38' has no statements

            	PushFollow(FOLLOW_assignmentExpression_in_initialiser478);
            	assignmentExpression82 = assignmentExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression82.Tree, assignmentExpression82, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 16, initialiser_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "initialiser"

    public class initialiserNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "initialiserNoIn"
    // JavaScript.g:96:1: initialiserNoIn : '=' ( LT )* assignmentExpressionNoIn ;
    public JavaScriptParser.initialiserNoIn_return initialiserNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.initialiserNoIn_return retval = new JavaScriptParser.initialiserNoIn_return();
        retval.Start = input.LT(1);
        int initialiserNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal83 = null;
        IToken LT84 = null;
        JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn85 = default(JavaScriptParser.assignmentExpressionNoIn_return);


        object char_literal83_tree=null;
        object LT84_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 17) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:97:2: ( '=' ( LT )* assignmentExpressionNoIn )
            // JavaScript.g:97:4: '=' ( LT )* assignmentExpressionNoIn
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal83=(IToken)Match(input,39,FOLLOW_39_in_initialiserNoIn490); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal83_tree = (object)adaptor.Create(char_literal83, retval);
            		adaptor.AddChild(root_0, char_literal83_tree);
            	}
            	// JavaScript.g:97:10: ( LT )*
            	do 
            	{
            	    int alt39 = 2;
            	    int LA39_0 = input.LA(1);

            	    if ( (LA39_0 == LT) )
            	    {
            	        alt39 = 1;
            	    }


            	    switch (alt39) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT84=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_initialiserNoIn492), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop39;
            	    }
            	} while (true);

            	loop39:
            		;	// Stops C# compiler whining that label 'loop39' has no statements

            	PushFollow(FOLLOW_assignmentExpressionNoIn_in_initialiserNoIn496);
            	assignmentExpressionNoIn85 = assignmentExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn85.Tree, assignmentExpressionNoIn85, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 17, initialiserNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "initialiserNoIn"

    public class emptyStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "emptyStatement"
    // JavaScript.g:100:1: emptyStatement : ';' ;
    public JavaScriptParser.emptyStatement_return emptyStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.emptyStatement_return retval = new JavaScriptParser.emptyStatement_return();
        retval.Start = input.LT(1);
        int emptyStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal86 = null;

        object char_literal86_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 18) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:101:2: ( ';' )
            // JavaScript.g:101:4: ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal86=(IToken)Match(input,38,FOLLOW_38_in_emptyStatement508); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal86_tree = (object)adaptor.Create(char_literal86, retval);
            		adaptor.AddChild(root_0, char_literal86_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 18, emptyStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "emptyStatement"

    public class expressionStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expressionStatement"
    // JavaScript.g:104:1: expressionStatement : expression ( LT | ';' ) ;
    public JavaScriptParser.expressionStatement_return expressionStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.expressionStatement_return retval = new JavaScriptParser.expressionStatement_return();
        retval.Start = input.LT(1);
        int expressionStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken set88 = null;
        JavaScriptParser.expression_return expression87 = default(JavaScriptParser.expression_return);


        object set88_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 19) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:105:2: ( expression ( LT | ';' ) )
            // JavaScript.g:105:4: expression ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_expression_in_expressionStatement520);
            	expression87 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression87.Tree, expression87, retval);
            	set88 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set88, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 19, expressionStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "expressionStatement"

    public class ifStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "ifStatement"
    // JavaScript.g:108:1: ifStatement : 'if' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ( ( LT )* 'else' ( LT )* statement )? ;
    public JavaScriptParser.ifStatement_return ifStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.ifStatement_return retval = new JavaScriptParser.ifStatement_return();
        retval.Start = input.LT(1);
        int ifStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal89 = null;
        IToken LT90 = null;
        IToken char_literal91 = null;
        IToken LT92 = null;
        IToken LT94 = null;
        IToken char_literal95 = null;
        IToken LT96 = null;
        IToken LT98 = null;
        IToken string_literal99 = null;
        IToken LT100 = null;
        JavaScriptParser.expression_return expression93 = default(JavaScriptParser.expression_return);

        JavaScriptParser.statement_return statement97 = default(JavaScriptParser.statement_return);

        JavaScriptParser.statement_return statement101 = default(JavaScriptParser.statement_return);


        object string_literal89_tree=null;
        object LT90_tree=null;
        object char_literal91_tree=null;
        object LT92_tree=null;
        object LT94_tree=null;
        object char_literal95_tree=null;
        object LT96_tree=null;
        object LT98_tree=null;
        object string_literal99_tree=null;
        object LT100_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 20) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:109:2: ( 'if' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ( ( LT )* 'else' ( LT )* statement )? )
            // JavaScript.g:109:4: 'if' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ( ( LT )* 'else' ( LT )* statement )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal89=(IToken)Match(input,40,FOLLOW_40_in_ifStatement540); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal89_tree = (object)adaptor.Create(string_literal89, retval);
            		adaptor.AddChild(root_0, string_literal89_tree);
            	}
            	// JavaScript.g:109:11: ( LT )*
            	do 
            	{
            	    int alt40 = 2;
            	    int LA40_0 = input.LA(1);

            	    if ( (LA40_0 == LT) )
            	    {
            	        alt40 = 1;
            	    }


            	    switch (alt40) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT90=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_ifStatement542), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop40;
            	    }
            	} while (true);

            	loop40:
            		;	// Stops C# compiler whining that label 'loop40' has no statements

            	char_literal91=(IToken)Match(input,32,FOLLOW_32_in_ifStatement546); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal91_tree = (object)adaptor.Create(char_literal91, retval);
            		adaptor.AddChild(root_0, char_literal91_tree);
            	}
            	// JavaScript.g:109:20: ( LT )*
            	do 
            	{
            	    int alt41 = 2;
            	    int LA41_0 = input.LA(1);

            	    if ( (LA41_0 == LT) )
            	    {
            	        alt41 = 1;
            	    }


            	    switch (alt41) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT92=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_ifStatement548), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop41;
            	    }
            	} while (true);

            	loop41:
            		;	// Stops C# compiler whining that label 'loop41' has no statements

            	PushFollow(FOLLOW_expression_in_ifStatement552);
            	expression93 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression93.Tree, expression93, retval);
            	// JavaScript.g:109:36: ( LT )*
            	do 
            	{
            	    int alt42 = 2;
            	    int LA42_0 = input.LA(1);

            	    if ( (LA42_0 == LT) )
            	    {
            	        alt42 = 1;
            	    }


            	    switch (alt42) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT94=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_ifStatement554), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop42;
            	    }
            	} while (true);

            	loop42:
            		;	// Stops C# compiler whining that label 'loop42' has no statements

            	char_literal95=(IToken)Match(input,34,FOLLOW_34_in_ifStatement558); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal95_tree = (object)adaptor.Create(char_literal95, retval);
            		adaptor.AddChild(root_0, char_literal95_tree);
            	}
            	// JavaScript.g:109:45: ( LT )*
            	do 
            	{
            	    int alt43 = 2;
            	    int LA43_0 = input.LA(1);

            	    if ( (LA43_0 == LT) )
            	    {
            	        alt43 = 1;
            	    }


            	    switch (alt43) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT96=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_ifStatement560), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop43;
            	    }
            	} while (true);

            	loop43:
            		;	// Stops C# compiler whining that label 'loop43' has no statements

            	PushFollow(FOLLOW_statement_in_ifStatement564);
            	statement97 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement97.Tree, statement97, retval);
            	// JavaScript.g:109:58: ( ( LT )* 'else' ( LT )* statement )?
            	int alt46 = 2;
            	int LA46_0 = input.LA(1);

            	if ( (LA46_0 == LT) )
            	{
            	    int LA46_1 = input.LA(2);

            	    if ( (synpred60_JavaScript()) )
            	    {
            	        alt46 = 1;
            	    }
            	}
            	else if ( (LA46_0 == 41) )
            	{
            	    int LA46_2 = input.LA(2);

            	    if ( (synpred60_JavaScript()) )
            	    {
            	        alt46 = 1;
            	    }
            	}
            	switch (alt46) 
            	{
            	    case 1 :
            	        // JavaScript.g:109:59: ( LT )* 'else' ( LT )* statement
            	        {
            	        	// JavaScript.g:109:61: ( LT )*
            	        	do 
            	        	{
            	        	    int alt44 = 2;
            	        	    int LA44_0 = input.LA(1);

            	        	    if ( (LA44_0 == LT) )
            	        	    {
            	        	        alt44 = 1;
            	        	    }


            	        	    switch (alt44) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT98=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_ifStatement567), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop44;
            	        	    }
            	        	} while (true);

            	        	loop44:
            	        		;	// Stops C# compiler whining that label 'loop44' has no statements

            	        	string_literal99=(IToken)Match(input,41,FOLLOW_41_in_ifStatement571); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{string_literal99_tree = (object)adaptor.Create(string_literal99, retval);
            	        		adaptor.AddChild(root_0, string_literal99_tree);
            	        	}
            	        	// JavaScript.g:109:73: ( LT )*
            	        	do 
            	        	{
            	        	    int alt45 = 2;
            	        	    int LA45_0 = input.LA(1);

            	        	    if ( (LA45_0 == LT) )
            	        	    {
            	        	        alt45 = 1;
            	        	    }


            	        	    switch (alt45) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT100=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_ifStatement573), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop45;
            	        	    }
            	        	} while (true);

            	        	loop45:
            	        		;	// Stops C# compiler whining that label 'loop45' has no statements

            	        	PushFollow(FOLLOW_statement_in_ifStatement577);
            	        	statement101 = statement();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement101.Tree, statement101, retval);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 20, ifStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "ifStatement"

    public class iterationStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "iterationStatement"
    // JavaScript.g:112:1: iterationStatement : ( doWhileStatement | whileStatement | forStatement | forInStatement );
    public JavaScriptParser.iterationStatement_return iterationStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.iterationStatement_return retval = new JavaScriptParser.iterationStatement_return();
        retval.Start = input.LT(1);
        int iterationStatement_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.doWhileStatement_return doWhileStatement102 = default(JavaScriptParser.doWhileStatement_return);

        JavaScriptParser.whileStatement_return whileStatement103 = default(JavaScriptParser.whileStatement_return);

        JavaScriptParser.forStatement_return forStatement104 = default(JavaScriptParser.forStatement_return);

        JavaScriptParser.forInStatement_return forInStatement105 = default(JavaScriptParser.forInStatement_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 21) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:113:2: ( doWhileStatement | whileStatement | forStatement | forInStatement )
            int alt47 = 4;
            switch ( input.LA(1) ) 
            {
            case 42:
            	{
                alt47 = 1;
                }
                break;
            case 43:
            	{
                alt47 = 2;
                }
                break;
            case 44:
            	{
                int LA47_3 = input.LA(2);

                if ( (synpred63_JavaScript()) )
                {
                    alt47 = 3;
                }
                else if ( (true) )
                {
                    alt47 = 4;
                }
                else 
                {
                    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    NoViableAltException nvae_d47s3 =
                        new NoViableAltException("", 47, 3, input);

                    throw nvae_d47s3;
                }
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d47s0 =
            	        new NoViableAltException("", 47, 0, input);

            	    throw nvae_d47s0;
            }

            switch (alt47) 
            {
                case 1 :
                    // JavaScript.g:113:4: doWhileStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_doWhileStatement_in_iterationStatement591);
                    	doWhileStatement102 = doWhileStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, doWhileStatement102.Tree, doWhileStatement102, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:114:4: whileStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_whileStatement_in_iterationStatement596);
                    	whileStatement103 = whileStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, whileStatement103.Tree, whileStatement103, retval);

                    }
                    break;
                case 3 :
                    // JavaScript.g:115:4: forStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_forStatement_in_iterationStatement601);
                    	forStatement104 = forStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forStatement104.Tree, forStatement104, retval);

                    }
                    break;
                case 4 :
                    // JavaScript.g:116:4: forInStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_forInStatement_in_iterationStatement606);
                    	forInStatement105 = forInStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forInStatement105.Tree, forInStatement105, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 21, iterationStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "iterationStatement"

    public class doWhileStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "doWhileStatement"
    // JavaScript.g:119:1: doWhileStatement : 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression ')' ( LT | ';' ) ;
    public JavaScriptParser.doWhileStatement_return doWhileStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.doWhileStatement_return retval = new JavaScriptParser.doWhileStatement_return();
        retval.Start = input.LT(1);
        int doWhileStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal106 = null;
        IToken LT107 = null;
        IToken LT109 = null;
        IToken string_literal110 = null;
        IToken LT111 = null;
        IToken char_literal112 = null;
        IToken char_literal114 = null;
        IToken set115 = null;
        JavaScriptParser.statement_return statement108 = default(JavaScriptParser.statement_return);

        JavaScriptParser.expression_return expression113 = default(JavaScriptParser.expression_return);


        object string_literal106_tree=null;
        object LT107_tree=null;
        object LT109_tree=null;
        object string_literal110_tree=null;
        object LT111_tree=null;
        object char_literal112_tree=null;
        object char_literal114_tree=null;
        object set115_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 22) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:120:2: ( 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression ')' ( LT | ';' ) )
            // JavaScript.g:120:4: 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression ')' ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal106=(IToken)Match(input,42,FOLLOW_42_in_doWhileStatement618); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal106_tree = (object)adaptor.Create(string_literal106, retval);
            		adaptor.AddChild(root_0, string_literal106_tree);
            	}
            	// JavaScript.g:120:11: ( LT )*
            	do 
            	{
            	    int alt48 = 2;
            	    int LA48_0 = input.LA(1);

            	    if ( (LA48_0 == LT) )
            	    {
            	        alt48 = 1;
            	    }


            	    switch (alt48) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT107=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_doWhileStatement620), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop48;
            	    }
            	} while (true);

            	loop48:
            		;	// Stops C# compiler whining that label 'loop48' has no statements

            	PushFollow(FOLLOW_statement_in_doWhileStatement624);
            	statement108 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement108.Tree, statement108, retval);
            	// JavaScript.g:120:26: ( LT )*
            	do 
            	{
            	    int alt49 = 2;
            	    int LA49_0 = input.LA(1);

            	    if ( (LA49_0 == LT) )
            	    {
            	        alt49 = 1;
            	    }


            	    switch (alt49) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT109=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_doWhileStatement626), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop49;
            	    }
            	} while (true);

            	loop49:
            		;	// Stops C# compiler whining that label 'loop49' has no statements

            	string_literal110=(IToken)Match(input,43,FOLLOW_43_in_doWhileStatement630); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal110_tree = (object)adaptor.Create(string_literal110, retval);
            		adaptor.AddChild(root_0, string_literal110_tree);
            	}
            	// JavaScript.g:120:39: ( LT )*
            	do 
            	{
            	    int alt50 = 2;
            	    int LA50_0 = input.LA(1);

            	    if ( (LA50_0 == LT) )
            	    {
            	        alt50 = 1;
            	    }


            	    switch (alt50) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT111=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_doWhileStatement632), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop50;
            	    }
            	} while (true);

            	loop50:
            		;	// Stops C# compiler whining that label 'loop50' has no statements

            	char_literal112=(IToken)Match(input,32,FOLLOW_32_in_doWhileStatement636); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal112_tree = (object)adaptor.Create(char_literal112, retval);
            		adaptor.AddChild(root_0, char_literal112_tree);
            	}
            	PushFollow(FOLLOW_expression_in_doWhileStatement638);
            	expression113 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression113.Tree, expression113, retval);
            	char_literal114=(IToken)Match(input,34,FOLLOW_34_in_doWhileStatement640); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal114_tree = (object)adaptor.Create(char_literal114, retval);
            		adaptor.AddChild(root_0, char_literal114_tree);
            	}
            	set115 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set115, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 22, doWhileStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "doWhileStatement"

    public class whileStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "whileStatement"
    // JavaScript.g:123:1: whileStatement : 'while' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ;
    public JavaScriptParser.whileStatement_return whileStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.whileStatement_return retval = new JavaScriptParser.whileStatement_return();
        retval.Start = input.LT(1);
        int whileStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal116 = null;
        IToken LT117 = null;
        IToken char_literal118 = null;
        IToken LT119 = null;
        IToken LT121 = null;
        IToken char_literal122 = null;
        IToken LT123 = null;
        JavaScriptParser.expression_return expression120 = default(JavaScriptParser.expression_return);

        JavaScriptParser.statement_return statement124 = default(JavaScriptParser.statement_return);


        object string_literal116_tree=null;
        object LT117_tree=null;
        object char_literal118_tree=null;
        object LT119_tree=null;
        object LT121_tree=null;
        object char_literal122_tree=null;
        object LT123_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 23) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:124:2: ( 'while' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement )
            // JavaScript.g:124:4: 'while' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal116=(IToken)Match(input,43,FOLLOW_43_in_whileStatement660); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal116_tree = (object)adaptor.Create(string_literal116, retval);
            		adaptor.AddChild(root_0, string_literal116_tree);
            	}
            	// JavaScript.g:124:14: ( LT )*
            	do 
            	{
            	    int alt51 = 2;
            	    int LA51_0 = input.LA(1);

            	    if ( (LA51_0 == LT) )
            	    {
            	        alt51 = 1;
            	    }


            	    switch (alt51) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT117=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_whileStatement662), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop51;
            	    }
            	} while (true);

            	loop51:
            		;	// Stops C# compiler whining that label 'loop51' has no statements

            	char_literal118=(IToken)Match(input,32,FOLLOW_32_in_whileStatement666); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal118_tree = (object)adaptor.Create(char_literal118, retval);
            		adaptor.AddChild(root_0, char_literal118_tree);
            	}
            	// JavaScript.g:124:23: ( LT )*
            	do 
            	{
            	    int alt52 = 2;
            	    int LA52_0 = input.LA(1);

            	    if ( (LA52_0 == LT) )
            	    {
            	        alt52 = 1;
            	    }


            	    switch (alt52) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT119=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_whileStatement668), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop52;
            	    }
            	} while (true);

            	loop52:
            		;	// Stops C# compiler whining that label 'loop52' has no statements

            	PushFollow(FOLLOW_expression_in_whileStatement672);
            	expression120 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression120.Tree, expression120, retval);
            	// JavaScript.g:124:39: ( LT )*
            	do 
            	{
            	    int alt53 = 2;
            	    int LA53_0 = input.LA(1);

            	    if ( (LA53_0 == LT) )
            	    {
            	        alt53 = 1;
            	    }


            	    switch (alt53) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT121=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_whileStatement674), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop53;
            	    }
            	} while (true);

            	loop53:
            		;	// Stops C# compiler whining that label 'loop53' has no statements

            	char_literal122=(IToken)Match(input,34,FOLLOW_34_in_whileStatement678); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal122_tree = (object)adaptor.Create(char_literal122, retval);
            		adaptor.AddChild(root_0, char_literal122_tree);
            	}
            	// JavaScript.g:124:48: ( LT )*
            	do 
            	{
            	    int alt54 = 2;
            	    int LA54_0 = input.LA(1);

            	    if ( (LA54_0 == LT) )
            	    {
            	        alt54 = 1;
            	    }


            	    switch (alt54) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT123=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_whileStatement680), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop54;
            	    }
            	} while (true);

            	loop54:
            		;	// Stops C# compiler whining that label 'loop54' has no statements

            	PushFollow(FOLLOW_statement_in_whileStatement684);
            	statement124 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement124.Tree, statement124, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 23, whileStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "whileStatement"

    public class forStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forStatement"
    // JavaScript.g:127:1: forStatement : 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ')' ( LT )* statement ;
    public JavaScriptParser.forStatement_return forStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.forStatement_return retval = new JavaScriptParser.forStatement_return();
        retval.Start = input.LT(1);
        int forStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal125 = null;
        IToken LT126 = null;
        IToken char_literal127 = null;
        IToken LT128 = null;
        IToken LT130 = null;
        IToken char_literal131 = null;
        IToken LT132 = null;
        IToken LT134 = null;
        IToken char_literal135 = null;
        IToken LT136 = null;
        IToken LT138 = null;
        IToken char_literal139 = null;
        IToken LT140 = null;
        JavaScriptParser.forStatementInitialiserPart_return forStatementInitialiserPart129 = default(JavaScriptParser.forStatementInitialiserPart_return);

        JavaScriptParser.expression_return expression133 = default(JavaScriptParser.expression_return);

        JavaScriptParser.expression_return expression137 = default(JavaScriptParser.expression_return);

        JavaScriptParser.statement_return statement141 = default(JavaScriptParser.statement_return);


        object string_literal125_tree=null;
        object LT126_tree=null;
        object char_literal127_tree=null;
        object LT128_tree=null;
        object LT130_tree=null;
        object char_literal131_tree=null;
        object LT132_tree=null;
        object LT134_tree=null;
        object char_literal135_tree=null;
        object LT136_tree=null;
        object LT138_tree=null;
        object char_literal139_tree=null;
        object LT140_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 24) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:128:2: ( 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ')' ( LT )* statement )
            // JavaScript.g:128:4: 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal125=(IToken)Match(input,44,FOLLOW_44_in_forStatement696); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal125_tree = (object)adaptor.Create(string_literal125, retval);
            		adaptor.AddChild(root_0, string_literal125_tree);
            	}
            	// JavaScript.g:128:12: ( LT )*
            	do 
            	{
            	    int alt55 = 2;
            	    int LA55_0 = input.LA(1);

            	    if ( (LA55_0 == LT) )
            	    {
            	        alt55 = 1;
            	    }


            	    switch (alt55) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT126=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement698), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop55;
            	    }
            	} while (true);

            	loop55:
            		;	// Stops C# compiler whining that label 'loop55' has no statements

            	char_literal127=(IToken)Match(input,32,FOLLOW_32_in_forStatement702); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal127_tree = (object)adaptor.Create(char_literal127, retval);
            		adaptor.AddChild(root_0, char_literal127_tree);
            	}
            	// JavaScript.g:128:19: ( ( LT )* forStatementInitialiserPart )?
            	int alt57 = 2;
            	alt57 = dfa57.Predict(input);
            	switch (alt57) 
            	{
            	    case 1 :
            	        // JavaScript.g:128:20: ( LT )* forStatementInitialiserPart
            	        {
            	        	// JavaScript.g:128:22: ( LT )*
            	        	do 
            	        	{
            	        	    int alt56 = 2;
            	        	    int LA56_0 = input.LA(1);

            	        	    if ( (LA56_0 == LT) )
            	        	    {
            	        	        alt56 = 1;
            	        	    }


            	        	    switch (alt56) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT128=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement705), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop56;
            	        	    }
            	        	} while (true);

            	        	loop56:
            	        		;	// Stops C# compiler whining that label 'loop56' has no statements

            	        	PushFollow(FOLLOW_forStatementInitialiserPart_in_forStatement709);
            	        	forStatementInitialiserPart129 = forStatementInitialiserPart();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forStatementInitialiserPart129.Tree, forStatementInitialiserPart129, retval);

            	        }
            	        break;

            	}

            	// JavaScript.g:128:57: ( LT )*
            	do 
            	{
            	    int alt58 = 2;
            	    int LA58_0 = input.LA(1);

            	    if ( (LA58_0 == LT) )
            	    {
            	        alt58 = 1;
            	    }


            	    switch (alt58) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT130=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement713), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop58;
            	    }
            	} while (true);

            	loop58:
            		;	// Stops C# compiler whining that label 'loop58' has no statements

            	char_literal131=(IToken)Match(input,38,FOLLOW_38_in_forStatement717); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal131_tree = (object)adaptor.Create(char_literal131, retval);
            		adaptor.AddChild(root_0, char_literal131_tree);
            	}
            	// JavaScript.g:128:64: ( ( LT )* expression )?
            	int alt60 = 2;
            	alt60 = dfa60.Predict(input);
            	switch (alt60) 
            	{
            	    case 1 :
            	        // JavaScript.g:128:65: ( LT )* expression
            	        {
            	        	// JavaScript.g:128:67: ( LT )*
            	        	do 
            	        	{
            	        	    int alt59 = 2;
            	        	    int LA59_0 = input.LA(1);

            	        	    if ( (LA59_0 == LT) )
            	        	    {
            	        	        alt59 = 1;
            	        	    }


            	        	    switch (alt59) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT132=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement720), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop59;
            	        	    }
            	        	} while (true);

            	        	loop59:
            	        		;	// Stops C# compiler whining that label 'loop59' has no statements

            	        	PushFollow(FOLLOW_expression_in_forStatement724);
            	        	expression133 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression133.Tree, expression133, retval);

            	        }
            	        break;

            	}

            	// JavaScript.g:128:85: ( LT )*
            	do 
            	{
            	    int alt61 = 2;
            	    int LA61_0 = input.LA(1);

            	    if ( (LA61_0 == LT) )
            	    {
            	        alt61 = 1;
            	    }


            	    switch (alt61) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT134=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement728), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop61;
            	    }
            	} while (true);

            	loop61:
            		;	// Stops C# compiler whining that label 'loop61' has no statements

            	char_literal135=(IToken)Match(input,38,FOLLOW_38_in_forStatement732); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal135_tree = (object)adaptor.Create(char_literal135, retval);
            		adaptor.AddChild(root_0, char_literal135_tree);
            	}
            	// JavaScript.g:128:92: ( ( LT )* expression )?
            	int alt63 = 2;
            	alt63 = dfa63.Predict(input);
            	switch (alt63) 
            	{
            	    case 1 :
            	        // JavaScript.g:128:93: ( LT )* expression
            	        {
            	        	// JavaScript.g:128:95: ( LT )*
            	        	do 
            	        	{
            	        	    int alt62 = 2;
            	        	    int LA62_0 = input.LA(1);

            	        	    if ( (LA62_0 == LT) )
            	        	    {
            	        	        alt62 = 1;
            	        	    }


            	        	    switch (alt62) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT136=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement735), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop62;
            	        	    }
            	        	} while (true);

            	        	loop62:
            	        		;	// Stops C# compiler whining that label 'loop62' has no statements

            	        	PushFollow(FOLLOW_expression_in_forStatement739);
            	        	expression137 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression137.Tree, expression137, retval);

            	        }
            	        break;

            	}

            	// JavaScript.g:128:113: ( LT )*
            	do 
            	{
            	    int alt64 = 2;
            	    int LA64_0 = input.LA(1);

            	    if ( (LA64_0 == LT) )
            	    {
            	        alt64 = 1;
            	    }


            	    switch (alt64) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT138=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement743), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop64;
            	    }
            	} while (true);

            	loop64:
            		;	// Stops C# compiler whining that label 'loop64' has no statements

            	char_literal139=(IToken)Match(input,34,FOLLOW_34_in_forStatement747); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal139_tree = (object)adaptor.Create(char_literal139, retval);
            		adaptor.AddChild(root_0, char_literal139_tree);
            	}
            	// JavaScript.g:128:122: ( LT )*
            	do 
            	{
            	    int alt65 = 2;
            	    int LA65_0 = input.LA(1);

            	    if ( (LA65_0 == LT) )
            	    {
            	        alt65 = 1;
            	    }


            	    switch (alt65) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT140=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatement749), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop65;
            	    }
            	} while (true);

            	loop65:
            		;	// Stops C# compiler whining that label 'loop65' has no statements

            	PushFollow(FOLLOW_statement_in_forStatement753);
            	statement141 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement141.Tree, statement141, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 24, forStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "forStatement"

    public class forStatementInitialiserPart_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forStatementInitialiserPart"
    // JavaScript.g:131:1: forStatementInitialiserPart : ( expressionNoIn | 'var' ( LT )* variableDeclarationListNoIn );
    public JavaScriptParser.forStatementInitialiserPart_return forStatementInitialiserPart() // throws RecognitionException [1]
    {   
        JavaScriptParser.forStatementInitialiserPart_return retval = new JavaScriptParser.forStatementInitialiserPart_return();
        retval.Start = input.LT(1);
        int forStatementInitialiserPart_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal143 = null;
        IToken LT144 = null;
        JavaScriptParser.expressionNoIn_return expressionNoIn142 = default(JavaScriptParser.expressionNoIn_return);

        JavaScriptParser.variableDeclarationListNoIn_return variableDeclarationListNoIn145 = default(JavaScriptParser.variableDeclarationListNoIn_return);


        object string_literal143_tree=null;
        object LT144_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 25) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:132:2: ( expressionNoIn | 'var' ( LT )* variableDeclarationListNoIn )
            int alt67 = 2;
            int LA67_0 = input.LA(1);

            if ( ((LA67_0 >= Identifier && LA67_0 <= NumericLiteral) || (LA67_0 >= 31 && LA67_0 <= 32) || LA67_0 == 35 || (LA67_0 >= 58 && LA67_0 <= 59) || (LA67_0 >= 91 && LA67_0 <= 92) || (LA67_0 >= 96 && LA67_0 <= 106)) )
            {
                alt67 = 1;
            }
            else if ( (LA67_0 == 37) )
            {
                alt67 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d67s0 =
                    new NoViableAltException("", 67, 0, input);

                throw nvae_d67s0;
            }
            switch (alt67) 
            {
                case 1 :
                    // JavaScript.g:132:4: expressionNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expressionNoIn_in_forStatementInitialiserPart765);
                    	expressionNoIn142 = expressionNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionNoIn142.Tree, expressionNoIn142, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:133:4: 'var' ( LT )* variableDeclarationListNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal143=(IToken)Match(input,37,FOLLOW_37_in_forStatementInitialiserPart770); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal143_tree = (object)adaptor.Create(string_literal143, retval);
                    		adaptor.AddChild(root_0, string_literal143_tree);
                    	}
                    	// JavaScript.g:133:12: ( LT )*
                    	do 
                    	{
                    	    int alt66 = 2;
                    	    int LA66_0 = input.LA(1);

                    	    if ( (LA66_0 == LT) )
                    	    {
                    	        alt66 = 1;
                    	    }


                    	    switch (alt66) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT144=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forStatementInitialiserPart772), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop66;
                    	    }
                    	} while (true);

                    	loop66:
                    		;	// Stops C# compiler whining that label 'loop66' has no statements

                    	PushFollow(FOLLOW_variableDeclarationListNoIn_in_forStatementInitialiserPart776);
                    	variableDeclarationListNoIn145 = variableDeclarationListNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationListNoIn145.Tree, variableDeclarationListNoIn145, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 25, forStatementInitialiserPart_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "forStatementInitialiserPart"

    public class forInStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forInStatement"
    // JavaScript.g:136:1: forInStatement : 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* ')' ( LT )* statement ;
    public JavaScriptParser.forInStatement_return forInStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.forInStatement_return retval = new JavaScriptParser.forInStatement_return();
        retval.Start = input.LT(1);
        int forInStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal146 = null;
        IToken LT147 = null;
        IToken char_literal148 = null;
        IToken LT149 = null;
        IToken LT151 = null;
        IToken string_literal152 = null;
        IToken LT153 = null;
        IToken LT155 = null;
        IToken char_literal156 = null;
        IToken LT157 = null;
        JavaScriptParser.forInStatementInitialiserPart_return forInStatementInitialiserPart150 = default(JavaScriptParser.forInStatementInitialiserPart_return);

        JavaScriptParser.expression_return expression154 = default(JavaScriptParser.expression_return);

        JavaScriptParser.statement_return statement158 = default(JavaScriptParser.statement_return);


        object string_literal146_tree=null;
        object LT147_tree=null;
        object char_literal148_tree=null;
        object LT149_tree=null;
        object LT151_tree=null;
        object string_literal152_tree=null;
        object LT153_tree=null;
        object LT155_tree=null;
        object char_literal156_tree=null;
        object LT157_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 26) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:137:2: ( 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* ')' ( LT )* statement )
            // JavaScript.g:137:4: 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal146=(IToken)Match(input,44,FOLLOW_44_in_forInStatement788); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal146_tree = (object)adaptor.Create(string_literal146, retval);
            		adaptor.AddChild(root_0, string_literal146_tree);
            	}
            	// JavaScript.g:137:12: ( LT )*
            	do 
            	{
            	    int alt68 = 2;
            	    int LA68_0 = input.LA(1);

            	    if ( (LA68_0 == LT) )
            	    {
            	        alt68 = 1;
            	    }


            	    switch (alt68) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT147=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forInStatement790), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop68;
            	    }
            	} while (true);

            	loop68:
            		;	// Stops C# compiler whining that label 'loop68' has no statements

            	char_literal148=(IToken)Match(input,32,FOLLOW_32_in_forInStatement794); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal148_tree = (object)adaptor.Create(char_literal148, retval);
            		adaptor.AddChild(root_0, char_literal148_tree);
            	}
            	// JavaScript.g:137:21: ( LT )*
            	do 
            	{
            	    int alt69 = 2;
            	    int LA69_0 = input.LA(1);

            	    if ( (LA69_0 == LT) )
            	    {
            	        alt69 = 1;
            	    }


            	    switch (alt69) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT149=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forInStatement796), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop69;
            	    }
            	} while (true);

            	loop69:
            		;	// Stops C# compiler whining that label 'loop69' has no statements

            	PushFollow(FOLLOW_forInStatementInitialiserPart_in_forInStatement800);
            	forInStatementInitialiserPart150 = forInStatementInitialiserPart();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forInStatementInitialiserPart150.Tree, forInStatementInitialiserPart150, retval);
            	// JavaScript.g:137:56: ( LT )*
            	do 
            	{
            	    int alt70 = 2;
            	    int LA70_0 = input.LA(1);

            	    if ( (LA70_0 == LT) )
            	    {
            	        alt70 = 1;
            	    }


            	    switch (alt70) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT151=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forInStatement802), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop70;
            	    }
            	} while (true);

            	loop70:
            		;	// Stops C# compiler whining that label 'loop70' has no statements

            	string_literal152=(IToken)Match(input,45,FOLLOW_45_in_forInStatement806); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal152_tree = (object)adaptor.Create(string_literal152, retval);
            		adaptor.AddChild(root_0, string_literal152_tree);
            	}
            	// JavaScript.g:137:66: ( LT )*
            	do 
            	{
            	    int alt71 = 2;
            	    int LA71_0 = input.LA(1);

            	    if ( (LA71_0 == LT) )
            	    {
            	        alt71 = 1;
            	    }


            	    switch (alt71) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT153=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forInStatement808), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop71;
            	    }
            	} while (true);

            	loop71:
            		;	// Stops C# compiler whining that label 'loop71' has no statements

            	PushFollow(FOLLOW_expression_in_forInStatement812);
            	expression154 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression154.Tree, expression154, retval);
            	// JavaScript.g:137:82: ( LT )*
            	do 
            	{
            	    int alt72 = 2;
            	    int LA72_0 = input.LA(1);

            	    if ( (LA72_0 == LT) )
            	    {
            	        alt72 = 1;
            	    }


            	    switch (alt72) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT155=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forInStatement814), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop72;
            	    }
            	} while (true);

            	loop72:
            		;	// Stops C# compiler whining that label 'loop72' has no statements

            	char_literal156=(IToken)Match(input,34,FOLLOW_34_in_forInStatement818); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal156_tree = (object)adaptor.Create(char_literal156, retval);
            		adaptor.AddChild(root_0, char_literal156_tree);
            	}
            	// JavaScript.g:137:91: ( LT )*
            	do 
            	{
            	    int alt73 = 2;
            	    int LA73_0 = input.LA(1);

            	    if ( (LA73_0 == LT) )
            	    {
            	        alt73 = 1;
            	    }


            	    switch (alt73) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT157=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forInStatement820), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop73;
            	    }
            	} while (true);

            	loop73:
            		;	// Stops C# compiler whining that label 'loop73' has no statements

            	PushFollow(FOLLOW_statement_in_forInStatement824);
            	statement158 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement158.Tree, statement158, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 26, forInStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "forInStatement"

    public class forInStatementInitialiserPart_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forInStatementInitialiserPart"
    // JavaScript.g:140:1: forInStatementInitialiserPart : ( leftHandSideExpression | 'var' ( LT )* variableDeclarationNoIn );
    public JavaScriptParser.forInStatementInitialiserPart_return forInStatementInitialiserPart() // throws RecognitionException [1]
    {   
        JavaScriptParser.forInStatementInitialiserPart_return retval = new JavaScriptParser.forInStatementInitialiserPart_return();
        retval.Start = input.LT(1);
        int forInStatementInitialiserPart_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal160 = null;
        IToken LT161 = null;
        JavaScriptParser.leftHandSideExpression_return leftHandSideExpression159 = default(JavaScriptParser.leftHandSideExpression_return);

        JavaScriptParser.variableDeclarationNoIn_return variableDeclarationNoIn162 = default(JavaScriptParser.variableDeclarationNoIn_return);


        object string_literal160_tree=null;
        object LT161_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 27) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:141:2: ( leftHandSideExpression | 'var' ( LT )* variableDeclarationNoIn )
            int alt75 = 2;
            int LA75_0 = input.LA(1);

            if ( ((LA75_0 >= Identifier && LA75_0 <= NumericLiteral) || (LA75_0 >= 31 && LA75_0 <= 32) || LA75_0 == 35 || (LA75_0 >= 58 && LA75_0 <= 59) || (LA75_0 >= 103 && LA75_0 <= 106)) )
            {
                alt75 = 1;
            }
            else if ( (LA75_0 == 37) )
            {
                alt75 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d75s0 =
                    new NoViableAltException("", 75, 0, input);

                throw nvae_d75s0;
            }
            switch (alt75) 
            {
                case 1 :
                    // JavaScript.g:141:4: leftHandSideExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_leftHandSideExpression_in_forInStatementInitialiserPart836);
                    	leftHandSideExpression159 = leftHandSideExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree, leftHandSideExpression159, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:142:4: 'var' ( LT )* variableDeclarationNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal160=(IToken)Match(input,37,FOLLOW_37_in_forInStatementInitialiserPart841); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal160_tree = (object)adaptor.Create(string_literal160, retval);
                    		adaptor.AddChild(root_0, string_literal160_tree);
                    	}
                    	// JavaScript.g:142:12: ( LT )*
                    	do 
                    	{
                    	    int alt74 = 2;
                    	    int LA74_0 = input.LA(1);

                    	    if ( (LA74_0 == LT) )
                    	    {
                    	        alt74 = 1;
                    	    }


                    	    switch (alt74) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT161=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_forInStatementInitialiserPart843), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop74;
                    	    }
                    	} while (true);

                    	loop74:
                    		;	// Stops C# compiler whining that label 'loop74' has no statements

                    	PushFollow(FOLLOW_variableDeclarationNoIn_in_forInStatementInitialiserPart847);
                    	variableDeclarationNoIn162 = variableDeclarationNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn162.Tree, variableDeclarationNoIn162, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 27, forInStatementInitialiserPart_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "forInStatementInitialiserPart"

    public class continueStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "continueStatement"
    // JavaScript.g:145:1: continueStatement : 'continue' ( Identifier )? ( LT | ';' ) ;
    public JavaScriptParser.continueStatement_return continueStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.continueStatement_return retval = new JavaScriptParser.continueStatement_return();
        retval.Start = input.LT(1);
        int continueStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal163 = null;
        IToken Identifier164 = null;
        IToken set165 = null;

        object string_literal163_tree=null;
        object Identifier164_tree=null;
        object set165_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 28) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:146:2: ( 'continue' ( Identifier )? ( LT | ';' ) )
            // JavaScript.g:146:4: 'continue' ( Identifier )? ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal163=(IToken)Match(input,46,FOLLOW_46_in_continueStatement858); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal163_tree = (object)adaptor.Create(string_literal163, retval);
            		adaptor.AddChild(root_0, string_literal163_tree);
            	}
            	// JavaScript.g:146:15: ( Identifier )?
            	int alt76 = 2;
            	int LA76_0 = input.LA(1);

            	if ( (LA76_0 == Identifier) )
            	{
            	    alt76 = 1;
            	}
            	switch (alt76) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: Identifier
            	        {
            	        	Identifier164=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_continueStatement860), "Identifier"); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier164_tree = (object)adaptor.Create(Identifier164, retval);
            	        		adaptor.AddChild(root_0, Identifier164_tree);
            	        	}

            	        }
            	        break;

            	}

            	set165 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set165, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 28, continueStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "continueStatement"

    public class breakStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "breakStatement"
    // JavaScript.g:149:1: breakStatement : 'break' ( Identifier )? ( LT | ';' ) ;
    public JavaScriptParser.breakStatement_return breakStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.breakStatement_return retval = new JavaScriptParser.breakStatement_return();
        retval.Start = input.LT(1);
        int breakStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal166 = null;
        IToken Identifier167 = null;
        IToken set168 = null;

        object string_literal166_tree=null;
        object Identifier167_tree=null;
        object set168_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 29) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:150:2: ( 'break' ( Identifier )? ( LT | ';' ) )
            // JavaScript.g:150:4: 'break' ( Identifier )? ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal166=(IToken)Match(input,47,FOLLOW_47_in_breakStatement880); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal166_tree = (object)adaptor.Create(string_literal166, retval);
            		adaptor.AddChild(root_0, string_literal166_tree);
            	}
            	// JavaScript.g:150:12: ( Identifier )?
            	int alt77 = 2;
            	int LA77_0 = input.LA(1);

            	if ( (LA77_0 == Identifier) )
            	{
            	    alt77 = 1;
            	}
            	switch (alt77) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: Identifier
            	        {
            	        	Identifier167=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_breakStatement882), "Identifier"); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier167_tree = (object)adaptor.Create(Identifier167, retval);
            	        		adaptor.AddChild(root_0, Identifier167_tree);
            	        	}

            	        }
            	        break;

            	}

            	set168 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set168, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 29, breakStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "breakStatement"

    public class returnStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "returnStatement"
    // JavaScript.g:153:1: returnStatement : 'return' ( expression )? ( LT | ';' ) ;
    public JavaScriptParser.returnStatement_return returnStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.returnStatement_return retval = new JavaScriptParser.returnStatement_return();
        retval.Start = input.LT(1);
        int returnStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal169 = null;
        IToken set171 = null;
        JavaScriptParser.expression_return expression170 = default(JavaScriptParser.expression_return);


        object string_literal169_tree=null;
        object set171_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 30) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:154:2: ( 'return' ( expression )? ( LT | ';' ) )
            // JavaScript.g:154:4: 'return' ( expression )? ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal169=(IToken)Match(input,48,FOLLOW_48_in_returnStatement902); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal169_tree = (object)adaptor.Create(string_literal169, retval);
            		adaptor.AddChild(root_0, string_literal169_tree);
            	}
            	// JavaScript.g:154:13: ( expression )?
            	int alt78 = 2;
            	int LA78_0 = input.LA(1);

            	if ( ((LA78_0 >= Identifier && LA78_0 <= NumericLiteral) || (LA78_0 >= 31 && LA78_0 <= 32) || LA78_0 == 35 || (LA78_0 >= 58 && LA78_0 <= 59) || (LA78_0 >= 91 && LA78_0 <= 92) || (LA78_0 >= 96 && LA78_0 <= 106)) )
            	{
            	    alt78 = 1;
            	}
            	switch (alt78) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: expression
            	        {
            	        	PushFollow(FOLLOW_expression_in_returnStatement904);
            	        	expression170 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression170.Tree, expression170, retval);

            	        }
            	        break;

            	}

            	set171 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set171, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 30, returnStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "returnStatement"

    public class withStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "withStatement"
    // JavaScript.g:157:1: withStatement : 'with' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ;
    public JavaScriptParser.withStatement_return withStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.withStatement_return retval = new JavaScriptParser.withStatement_return();
        retval.Start = input.LT(1);
        int withStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal172 = null;
        IToken LT173 = null;
        IToken char_literal174 = null;
        IToken LT175 = null;
        IToken LT177 = null;
        IToken char_literal178 = null;
        IToken LT179 = null;
        JavaScriptParser.expression_return expression176 = default(JavaScriptParser.expression_return);

        JavaScriptParser.statement_return statement180 = default(JavaScriptParser.statement_return);


        object string_literal172_tree=null;
        object LT173_tree=null;
        object char_literal174_tree=null;
        object LT175_tree=null;
        object LT177_tree=null;
        object char_literal178_tree=null;
        object LT179_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 31) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:158:2: ( 'with' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement )
            // JavaScript.g:158:4: 'with' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal172=(IToken)Match(input,49,FOLLOW_49_in_withStatement925); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal172_tree = (object)adaptor.Create(string_literal172, retval);
            		adaptor.AddChild(root_0, string_literal172_tree);
            	}
            	// JavaScript.g:158:13: ( LT )*
            	do 
            	{
            	    int alt79 = 2;
            	    int LA79_0 = input.LA(1);

            	    if ( (LA79_0 == LT) )
            	    {
            	        alt79 = 1;
            	    }


            	    switch (alt79) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT173=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_withStatement927), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop79;
            	    }
            	} while (true);

            	loop79:
            		;	// Stops C# compiler whining that label 'loop79' has no statements

            	char_literal174=(IToken)Match(input,32,FOLLOW_32_in_withStatement931); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal174_tree = (object)adaptor.Create(char_literal174, retval);
            		adaptor.AddChild(root_0, char_literal174_tree);
            	}
            	// JavaScript.g:158:22: ( LT )*
            	do 
            	{
            	    int alt80 = 2;
            	    int LA80_0 = input.LA(1);

            	    if ( (LA80_0 == LT) )
            	    {
            	        alt80 = 1;
            	    }


            	    switch (alt80) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT175=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_withStatement933), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop80;
            	    }
            	} while (true);

            	loop80:
            		;	// Stops C# compiler whining that label 'loop80' has no statements

            	PushFollow(FOLLOW_expression_in_withStatement937);
            	expression176 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression176.Tree, expression176, retval);
            	// JavaScript.g:158:38: ( LT )*
            	do 
            	{
            	    int alt81 = 2;
            	    int LA81_0 = input.LA(1);

            	    if ( (LA81_0 == LT) )
            	    {
            	        alt81 = 1;
            	    }


            	    switch (alt81) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT177=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_withStatement939), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop81;
            	    }
            	} while (true);

            	loop81:
            		;	// Stops C# compiler whining that label 'loop81' has no statements

            	char_literal178=(IToken)Match(input,34,FOLLOW_34_in_withStatement943); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal178_tree = (object)adaptor.Create(char_literal178, retval);
            		adaptor.AddChild(root_0, char_literal178_tree);
            	}
            	// JavaScript.g:158:47: ( LT )*
            	do 
            	{
            	    int alt82 = 2;
            	    int LA82_0 = input.LA(1);

            	    if ( (LA82_0 == LT) )
            	    {
            	        alt82 = 1;
            	    }


            	    switch (alt82) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT179=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_withStatement945), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop82;
            	    }
            	} while (true);

            	loop82:
            		;	// Stops C# compiler whining that label 'loop82' has no statements

            	PushFollow(FOLLOW_statement_in_withStatement949);
            	statement180 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement180.Tree, statement180, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 31, withStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "withStatement"

    public class labelledStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "labelledStatement"
    // JavaScript.g:161:1: labelledStatement : Identifier ( LT )* ':' ( LT )* statement ;
    public JavaScriptParser.labelledStatement_return labelledStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.labelledStatement_return retval = new JavaScriptParser.labelledStatement_return();
        retval.Start = input.LT(1);
        int labelledStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken Identifier181 = null;
        IToken LT182 = null;
        IToken char_literal183 = null;
        IToken LT184 = null;
        JavaScriptParser.statement_return statement185 = default(JavaScriptParser.statement_return);


        object Identifier181_tree=null;
        object LT182_tree=null;
        object char_literal183_tree=null;
        object LT184_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 32) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:162:2: ( Identifier ( LT )* ':' ( LT )* statement )
            // JavaScript.g:162:4: Identifier ( LT )* ':' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	Identifier181=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_labelledStatement960), "Identifier"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier181_tree = (object)adaptor.Create(Identifier181, retval);
            		adaptor.AddChild(root_0, Identifier181_tree);
            	}
            	// JavaScript.g:162:17: ( LT )*
            	do 
            	{
            	    int alt83 = 2;
            	    int LA83_0 = input.LA(1);

            	    if ( (LA83_0 == LT) )
            	    {
            	        alt83 = 1;
            	    }


            	    switch (alt83) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT182=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_labelledStatement962), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop83;
            	    }
            	} while (true);

            	loop83:
            		;	// Stops C# compiler whining that label 'loop83' has no statements

            	char_literal183=(IToken)Match(input,50,FOLLOW_50_in_labelledStatement966); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal183_tree = (object)adaptor.Create(char_literal183, retval);
            		adaptor.AddChild(root_0, char_literal183_tree);
            	}
            	// JavaScript.g:162:26: ( LT )*
            	do 
            	{
            	    int alt84 = 2;
            	    int LA84_0 = input.LA(1);

            	    if ( (LA84_0 == LT) )
            	    {
            	        alt84 = 1;
            	    }


            	    switch (alt84) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT184=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_labelledStatement968), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop84;
            	    }
            	} while (true);

            	loop84:
            		;	// Stops C# compiler whining that label 'loop84' has no statements

            	PushFollow(FOLLOW_statement_in_labelledStatement972);
            	statement185 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement185.Tree, statement185, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 32, labelledStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "labelledStatement"

    public class switchStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "switchStatement"
    // JavaScript.g:165:1: switchStatement : 'switch' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* caseBlock ;
    public JavaScriptParser.switchStatement_return switchStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.switchStatement_return retval = new JavaScriptParser.switchStatement_return();
        retval.Start = input.LT(1);
        int switchStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal186 = null;
        IToken LT187 = null;
        IToken char_literal188 = null;
        IToken LT189 = null;
        IToken LT191 = null;
        IToken char_literal192 = null;
        IToken LT193 = null;
        JavaScriptParser.expression_return expression190 = default(JavaScriptParser.expression_return);

        JavaScriptParser.caseBlock_return caseBlock194 = default(JavaScriptParser.caseBlock_return);


        object string_literal186_tree=null;
        object LT187_tree=null;
        object char_literal188_tree=null;
        object LT189_tree=null;
        object LT191_tree=null;
        object char_literal192_tree=null;
        object LT193_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 33) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:166:2: ( 'switch' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* caseBlock )
            // JavaScript.g:166:4: 'switch' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* caseBlock
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal186=(IToken)Match(input,51,FOLLOW_51_in_switchStatement984); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal186_tree = (object)adaptor.Create(string_literal186, retval);
            		adaptor.AddChild(root_0, string_literal186_tree);
            	}
            	// JavaScript.g:166:15: ( LT )*
            	do 
            	{
            	    int alt85 = 2;
            	    int LA85_0 = input.LA(1);

            	    if ( (LA85_0 == LT) )
            	    {
            	        alt85 = 1;
            	    }


            	    switch (alt85) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT187=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_switchStatement986), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop85;
            	    }
            	} while (true);

            	loop85:
            		;	// Stops C# compiler whining that label 'loop85' has no statements

            	char_literal188=(IToken)Match(input,32,FOLLOW_32_in_switchStatement990); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal188_tree = (object)adaptor.Create(char_literal188, retval);
            		adaptor.AddChild(root_0, char_literal188_tree);
            	}
            	// JavaScript.g:166:24: ( LT )*
            	do 
            	{
            	    int alt86 = 2;
            	    int LA86_0 = input.LA(1);

            	    if ( (LA86_0 == LT) )
            	    {
            	        alt86 = 1;
            	    }


            	    switch (alt86) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT189=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_switchStatement992), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop86;
            	    }
            	} while (true);

            	loop86:
            		;	// Stops C# compiler whining that label 'loop86' has no statements

            	PushFollow(FOLLOW_expression_in_switchStatement996);
            	expression190 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression190.Tree, expression190, retval);
            	// JavaScript.g:166:40: ( LT )*
            	do 
            	{
            	    int alt87 = 2;
            	    int LA87_0 = input.LA(1);

            	    if ( (LA87_0 == LT) )
            	    {
            	        alt87 = 1;
            	    }


            	    switch (alt87) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT191=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_switchStatement998), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop87;
            	    }
            	} while (true);

            	loop87:
            		;	// Stops C# compiler whining that label 'loop87' has no statements

            	char_literal192=(IToken)Match(input,34,FOLLOW_34_in_switchStatement1002); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal192_tree = (object)adaptor.Create(char_literal192, retval);
            		adaptor.AddChild(root_0, char_literal192_tree);
            	}
            	// JavaScript.g:166:49: ( LT )*
            	do 
            	{
            	    int alt88 = 2;
            	    int LA88_0 = input.LA(1);

            	    if ( (LA88_0 == LT) )
            	    {
            	        alt88 = 1;
            	    }


            	    switch (alt88) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT193=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_switchStatement1004), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop88;
            	    }
            	} while (true);

            	loop88:
            		;	// Stops C# compiler whining that label 'loop88' has no statements

            	PushFollow(FOLLOW_caseBlock_in_switchStatement1008);
            	caseBlock194 = caseBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseBlock194.Tree, caseBlock194, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 33, switchStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "switchStatement"

    public class caseBlock_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "caseBlock"
    // JavaScript.g:169:1: caseBlock : '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* '}' ;
    public JavaScriptParser.caseBlock_return caseBlock() // throws RecognitionException [1]
    {   
        JavaScriptParser.caseBlock_return retval = new JavaScriptParser.caseBlock_return();
        retval.Start = input.LT(1);
        int caseBlock_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal195 = null;
        IToken LT196 = null;
        IToken LT198 = null;
        IToken LT200 = null;
        IToken LT202 = null;
        IToken char_literal203 = null;
        JavaScriptParser.caseClause_return caseClause197 = default(JavaScriptParser.caseClause_return);

        JavaScriptParser.defaultClause_return defaultClause199 = default(JavaScriptParser.defaultClause_return);

        JavaScriptParser.caseClause_return caseClause201 = default(JavaScriptParser.caseClause_return);


        object char_literal195_tree=null;
        object LT196_tree=null;
        object LT198_tree=null;
        object LT200_tree=null;
        object LT202_tree=null;
        object char_literal203_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 34) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:170:2: ( '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* '}' )
            // JavaScript.g:170:4: '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal195=(IToken)Match(input,35,FOLLOW_35_in_caseBlock1020); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal195_tree = (object)adaptor.Create(char_literal195, retval);
            		adaptor.AddChild(root_0, char_literal195_tree);
            	}
            	// JavaScript.g:170:8: ( ( LT )* caseClause )*
            	do 
            	{
            	    int alt90 = 2;
            	    alt90 = dfa90.Predict(input);
            	    switch (alt90) 
            		{
            			case 1 :
            			    // JavaScript.g:170:9: ( LT )* caseClause
            			    {
            			    	// JavaScript.g:170:11: ( LT )*
            			    	do 
            			    	{
            			    	    int alt89 = 2;
            			    	    int LA89_0 = input.LA(1);

            			    	    if ( (LA89_0 == LT) )
            			    	    {
            			    	        alt89 = 1;
            			    	    }


            			    	    switch (alt89) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT196=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1023), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop89;
            			    	    }
            			    	} while (true);

            			    	loop89:
            			    		;	// Stops C# compiler whining that label 'loop89' has no statements

            			    	PushFollow(FOLLOW_caseClause_in_caseBlock1027);
            			    	caseClause197 = caseClause();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseClause197.Tree, caseClause197, retval);

            			    }
            			    break;

            			default:
            			    goto loop90;
            	    }
            	} while (true);

            	loop90:
            		;	// Stops C# compiler whining that label 'loop90' has no statements

            	// JavaScript.g:170:27: ( ( LT )* defaultClause ( ( LT )* caseClause )* )?
            	int alt94 = 2;
            	alt94 = dfa94.Predict(input);
            	switch (alt94) 
            	{
            	    case 1 :
            	        // JavaScript.g:170:28: ( LT )* defaultClause ( ( LT )* caseClause )*
            	        {
            	        	// JavaScript.g:170:30: ( LT )*
            	        	do 
            	        	{
            	        	    int alt91 = 2;
            	        	    int LA91_0 = input.LA(1);

            	        	    if ( (LA91_0 == LT) )
            	        	    {
            	        	        alt91 = 1;
            	        	    }


            	        	    switch (alt91) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT198=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1032), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop91;
            	        	    }
            	        	} while (true);

            	        	loop91:
            	        		;	// Stops C# compiler whining that label 'loop91' has no statements

            	        	PushFollow(FOLLOW_defaultClause_in_caseBlock1036);
            	        	defaultClause199 = defaultClause();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, defaultClause199.Tree, defaultClause199, retval);
            	        	// JavaScript.g:170:47: ( ( LT )* caseClause )*
            	        	do 
            	        	{
            	        	    int alt93 = 2;
            	        	    alt93 = dfa93.Predict(input);
            	        	    switch (alt93) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:170:48: ( LT )* caseClause
            	        			    {
            	        			    	// JavaScript.g:170:50: ( LT )*
            	        			    	do 
            	        			    	{
            	        			    	    int alt92 = 2;
            	        			    	    int LA92_0 = input.LA(1);

            	        			    	    if ( (LA92_0 == LT) )
            	        			    	    {
            	        			    	        alt92 = 1;
            	        			    	    }


            	        			    	    switch (alt92) 
            	        			    		{
            	        			    			case 1 :
            	        			    			    // JavaScript.g:0:0: LT
            	        			    			    {
            	        			    			    	LT200=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1039), "LT"); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop92;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop92:
            	        			    		;	// Stops C# compiler whining that label 'loop92' has no statements

            	        			    	PushFollow(FOLLOW_caseClause_in_caseBlock1043);
            	        			    	caseClause201 = caseClause();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseClause201.Tree, caseClause201, retval);

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop93;
            	        	    }
            	        	} while (true);

            	        	loop93:
            	        		;	// Stops C# compiler whining that label 'loop93' has no statements


            	        }
            	        break;

            	}

            	// JavaScript.g:170:70: ( LT )*
            	do 
            	{
            	    int alt95 = 2;
            	    int LA95_0 = input.LA(1);

            	    if ( (LA95_0 == LT) )
            	    {
            	        alt95 = 1;
            	    }


            	    switch (alt95) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT202=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1049), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop95;
            	    }
            	} while (true);

            	loop95:
            		;	// Stops C# compiler whining that label 'loop95' has no statements

            	char_literal203=(IToken)Match(input,36,FOLLOW_36_in_caseBlock1053); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal203_tree = (object)adaptor.Create(char_literal203, retval);
            		adaptor.AddChild(root_0, char_literal203_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 34, caseBlock_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "caseBlock"

    public class caseClause_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "caseClause"
    // JavaScript.g:173:1: caseClause : 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )? ;
    public JavaScriptParser.caseClause_return caseClause() // throws RecognitionException [1]
    {   
        JavaScriptParser.caseClause_return retval = new JavaScriptParser.caseClause_return();
        retval.Start = input.LT(1);
        int caseClause_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal204 = null;
        IToken LT205 = null;
        IToken LT207 = null;
        IToken char_literal208 = null;
        IToken LT209 = null;
        JavaScriptParser.expression_return expression206 = default(JavaScriptParser.expression_return);

        JavaScriptParser.statementList_return statementList210 = default(JavaScriptParser.statementList_return);


        object string_literal204_tree=null;
        object LT205_tree=null;
        object LT207_tree=null;
        object char_literal208_tree=null;
        object LT209_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 35) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:174:2: ( 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )? )
            // JavaScript.g:174:4: 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal204=(IToken)Match(input,52,FOLLOW_52_in_caseClause1064); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal204_tree = (object)adaptor.Create(string_literal204, retval);
            		adaptor.AddChild(root_0, string_literal204_tree);
            	}
            	// JavaScript.g:174:13: ( LT )*
            	do 
            	{
            	    int alt96 = 2;
            	    int LA96_0 = input.LA(1);

            	    if ( (LA96_0 == LT) )
            	    {
            	        alt96 = 1;
            	    }


            	    switch (alt96) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT205=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_caseClause1066), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop96;
            	    }
            	} while (true);

            	loop96:
            		;	// Stops C# compiler whining that label 'loop96' has no statements

            	PushFollow(FOLLOW_expression_in_caseClause1070);
            	expression206 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression206.Tree, expression206, retval);
            	// JavaScript.g:174:29: ( LT )*
            	do 
            	{
            	    int alt97 = 2;
            	    int LA97_0 = input.LA(1);

            	    if ( (LA97_0 == LT) )
            	    {
            	        alt97 = 1;
            	    }


            	    switch (alt97) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT207=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_caseClause1072), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop97;
            	    }
            	} while (true);

            	loop97:
            		;	// Stops C# compiler whining that label 'loop97' has no statements

            	char_literal208=(IToken)Match(input,50,FOLLOW_50_in_caseClause1076); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal208_tree = (object)adaptor.Create(char_literal208, retval);
            		adaptor.AddChild(root_0, char_literal208_tree);
            	}
            	// JavaScript.g:174:38: ( LT )*
            	do 
            	{
            	    int alt98 = 2;
            	    int LA98_0 = input.LA(1);

            	    if ( (LA98_0 == LT) )
            	    {
            	        int LA98_2 = input.LA(2);

            	        if ( (synpred118_JavaScript()) )
            	        {
            	            alt98 = 1;
            	        }


            	    }


            	    switch (alt98) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT209=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_caseClause1078), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop98;
            	    }
            	} while (true);

            	loop98:
            		;	// Stops C# compiler whining that label 'loop98' has no statements

            	// JavaScript.g:174:41: ( statementList )?
            	int alt99 = 2;
            	int LA99_0 = input.LA(1);

            	if ( ((LA99_0 >= Identifier && LA99_0 <= NumericLiteral) || (LA99_0 >= 31 && LA99_0 <= 32) || LA99_0 == 35 || (LA99_0 >= 37 && LA99_0 <= 38) || LA99_0 == 40 || (LA99_0 >= 42 && LA99_0 <= 44) || (LA99_0 >= 46 && LA99_0 <= 49) || LA99_0 == 51 || (LA99_0 >= 54 && LA99_0 <= 55) || (LA99_0 >= 58 && LA99_0 <= 59) || (LA99_0 >= 91 && LA99_0 <= 92) || (LA99_0 >= 96 && LA99_0 <= 106)) )
            	{
            	    alt99 = 1;
            	}
            	switch (alt99) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: statementList
            	        {
            	        	PushFollow(FOLLOW_statementList_in_caseClause1082);
            	        	statementList210 = statementList();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList210.Tree, statementList210, retval);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 35, caseClause_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "caseClause"

    public class defaultClause_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "defaultClause"
    // JavaScript.g:177:1: defaultClause : 'default' ( LT )* ':' ( LT )* ( statementList )? ;
    public JavaScriptParser.defaultClause_return defaultClause() // throws RecognitionException [1]
    {   
        JavaScriptParser.defaultClause_return retval = new JavaScriptParser.defaultClause_return();
        retval.Start = input.LT(1);
        int defaultClause_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal211 = null;
        IToken LT212 = null;
        IToken char_literal213 = null;
        IToken LT214 = null;
        JavaScriptParser.statementList_return statementList215 = default(JavaScriptParser.statementList_return);


        object string_literal211_tree=null;
        object LT212_tree=null;
        object char_literal213_tree=null;
        object LT214_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 36) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:178:2: ( 'default' ( LT )* ':' ( LT )* ( statementList )? )
            // JavaScript.g:178:4: 'default' ( LT )* ':' ( LT )* ( statementList )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal211=(IToken)Match(input,53,FOLLOW_53_in_defaultClause1095); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal211_tree = (object)adaptor.Create(string_literal211, retval);
            		adaptor.AddChild(root_0, string_literal211_tree);
            	}
            	// JavaScript.g:178:16: ( LT )*
            	do 
            	{
            	    int alt100 = 2;
            	    int LA100_0 = input.LA(1);

            	    if ( (LA100_0 == LT) )
            	    {
            	        alt100 = 1;
            	    }


            	    switch (alt100) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT212=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_defaultClause1097), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop100;
            	    }
            	} while (true);

            	loop100:
            		;	// Stops C# compiler whining that label 'loop100' has no statements

            	char_literal213=(IToken)Match(input,50,FOLLOW_50_in_defaultClause1101); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal213_tree = (object)adaptor.Create(char_literal213, retval);
            		adaptor.AddChild(root_0, char_literal213_tree);
            	}
            	// JavaScript.g:178:25: ( LT )*
            	do 
            	{
            	    int alt101 = 2;
            	    int LA101_0 = input.LA(1);

            	    if ( (LA101_0 == LT) )
            	    {
            	        int LA101_2 = input.LA(2);

            	        if ( (synpred121_JavaScript()) )
            	        {
            	            alt101 = 1;
            	        }


            	    }


            	    switch (alt101) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT214=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_defaultClause1103), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop101;
            	    }
            	} while (true);

            	loop101:
            		;	// Stops C# compiler whining that label 'loop101' has no statements

            	// JavaScript.g:178:28: ( statementList )?
            	int alt102 = 2;
            	int LA102_0 = input.LA(1);

            	if ( ((LA102_0 >= Identifier && LA102_0 <= NumericLiteral) || (LA102_0 >= 31 && LA102_0 <= 32) || LA102_0 == 35 || (LA102_0 >= 37 && LA102_0 <= 38) || LA102_0 == 40 || (LA102_0 >= 42 && LA102_0 <= 44) || (LA102_0 >= 46 && LA102_0 <= 49) || LA102_0 == 51 || (LA102_0 >= 54 && LA102_0 <= 55) || (LA102_0 >= 58 && LA102_0 <= 59) || (LA102_0 >= 91 && LA102_0 <= 92) || (LA102_0 >= 96 && LA102_0 <= 106)) )
            	{
            	    alt102 = 1;
            	}
            	switch (alt102) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: statementList
            	        {
            	        	PushFollow(FOLLOW_statementList_in_defaultClause1107);
            	        	statementList215 = statementList();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList215.Tree, statementList215, retval);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 36, defaultClause_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "defaultClause"

    public class throwStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "throwStatement"
    // JavaScript.g:181:1: throwStatement : 'throw' expression ( LT | ';' ) ;
    public JavaScriptParser.throwStatement_return throwStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.throwStatement_return retval = new JavaScriptParser.throwStatement_return();
        retval.Start = input.LT(1);
        int throwStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal216 = null;
        IToken set218 = null;
        JavaScriptParser.expression_return expression217 = default(JavaScriptParser.expression_return);


        object string_literal216_tree=null;
        object set218_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 37) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:182:2: ( 'throw' expression ( LT | ';' ) )
            // JavaScript.g:182:4: 'throw' expression ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal216=(IToken)Match(input,54,FOLLOW_54_in_throwStatement1120); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal216_tree = (object)adaptor.Create(string_literal216, retval);
            		adaptor.AddChild(root_0, string_literal216_tree);
            	}
            	PushFollow(FOLLOW_expression_in_throwStatement1122);
            	expression217 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression217.Tree, expression217, retval);
            	set218 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set218, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 37, throwStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "throwStatement"

    public class tryStatement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "tryStatement"
    // JavaScript.g:185:1: tryStatement : 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? ) ;
    public JavaScriptParser.tryStatement_return tryStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.tryStatement_return retval = new JavaScriptParser.tryStatement_return();
        retval.Start = input.LT(1);
        int tryStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal219 = null;
        IToken LT220 = null;
        IToken LT222 = null;
        IToken LT225 = null;
        JavaScriptParser.statementBlock_return statementBlock221 = default(JavaScriptParser.statementBlock_return);

        JavaScriptParser.finallyClause_return finallyClause223 = default(JavaScriptParser.finallyClause_return);

        JavaScriptParser.catchClause_return catchClause224 = default(JavaScriptParser.catchClause_return);

        JavaScriptParser.finallyClause_return finallyClause226 = default(JavaScriptParser.finallyClause_return);


        object string_literal219_tree=null;
        object LT220_tree=null;
        object LT222_tree=null;
        object LT225_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 38) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:186:2: ( 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? ) )
            // JavaScript.g:186:4: 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal219=(IToken)Match(input,55,FOLLOW_55_in_tryStatement1141); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal219_tree = (object)adaptor.Create(string_literal219, retval);
            		adaptor.AddChild(root_0, string_literal219_tree);
            	}
            	// JavaScript.g:186:12: ( LT )*
            	do 
            	{
            	    int alt103 = 2;
            	    int LA103_0 = input.LA(1);

            	    if ( (LA103_0 == LT) )
            	    {
            	        alt103 = 1;
            	    }


            	    switch (alt103) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT220=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_tryStatement1143), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop103;
            	    }
            	} while (true);

            	loop103:
            		;	// Stops C# compiler whining that label 'loop103' has no statements

            	PushFollow(FOLLOW_statementBlock_in_tryStatement1147);
            	statementBlock221 = statementBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock221.Tree, statementBlock221, retval);
            	// JavaScript.g:186:32: ( LT )*
            	do 
            	{
            	    int alt104 = 2;
            	    int LA104_0 = input.LA(1);

            	    if ( (LA104_0 == LT) )
            	    {
            	        alt104 = 1;
            	    }


            	    switch (alt104) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT222=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_tryStatement1149), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop104;
            	    }
            	} while (true);

            	loop104:
            		;	// Stops C# compiler whining that label 'loop104' has no statements

            	// JavaScript.g:186:35: ( finallyClause | catchClause ( ( LT )* finallyClause )? )
            	int alt107 = 2;
            	int LA107_0 = input.LA(1);

            	if ( (LA107_0 == 57) )
            	{
            	    alt107 = 1;
            	}
            	else if ( (LA107_0 == 56) )
            	{
            	    alt107 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d107s0 =
            	        new NoViableAltException("", 107, 0, input);

            	    throw nvae_d107s0;
            	}
            	switch (alt107) 
            	{
            	    case 1 :
            	        // JavaScript.g:186:36: finallyClause
            	        {
            	        	PushFollow(FOLLOW_finallyClause_in_tryStatement1154);
            	        	finallyClause223 = finallyClause();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause223.Tree, finallyClause223, retval);

            	        }
            	        break;
            	    case 2 :
            	        // JavaScript.g:186:52: catchClause ( ( LT )* finallyClause )?
            	        {
            	        	PushFollow(FOLLOW_catchClause_in_tryStatement1158);
            	        	catchClause224 = catchClause();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, catchClause224.Tree, catchClause224, retval);
            	        	// JavaScript.g:186:64: ( ( LT )* finallyClause )?
            	        	int alt106 = 2;
            	        	alt106 = dfa106.Predict(input);
            	        	switch (alt106) 
            	        	{
            	        	    case 1 :
            	        	        // JavaScript.g:186:65: ( LT )* finallyClause
            	        	        {
            	        	        	// JavaScript.g:186:67: ( LT )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt105 = 2;
            	        	        	    int LA105_0 = input.LA(1);

            	        	        	    if ( (LA105_0 == LT) )
            	        	        	    {
            	        	        	        alt105 = 1;
            	        	        	    }


            	        	        	    switch (alt105) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // JavaScript.g:0:0: LT
            	        	        			    {
            	        	        			    	LT225=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_tryStatement1161), "LT"); if (state.failed) return retval;

            	        	        			    }
            	        	        			    break;

            	        	        			default:
            	        	        			    goto loop105;
            	        	        	    }
            	        	        	} while (true);

            	        	        	loop105:
            	        	        		;	// Stops C# compiler whining that label 'loop105' has no statements

            	        	        	PushFollow(FOLLOW_finallyClause_in_tryStatement1165);
            	        	        	finallyClause226 = finallyClause();
            	        	        	state.followingStackPointer--;
            	        	        	if (state.failed) return retval;
            	        	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause226.Tree, finallyClause226, retval);

            	        	        }
            	        	        break;

            	        	}


            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 38, tryStatement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "tryStatement"

    public class catchClause_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "catchClause"
    // JavaScript.g:189:1: catchClause : 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* ')' ( LT )* statementBlock ;
    public JavaScriptParser.catchClause_return catchClause() // throws RecognitionException [1]
    {   
        JavaScriptParser.catchClause_return retval = new JavaScriptParser.catchClause_return();
        retval.Start = input.LT(1);
        int catchClause_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal227 = null;
        IToken LT228 = null;
        IToken char_literal229 = null;
        IToken LT230 = null;
        IToken Identifier231 = null;
        IToken LT232 = null;
        IToken char_literal233 = null;
        IToken LT234 = null;
        JavaScriptParser.statementBlock_return statementBlock235 = default(JavaScriptParser.statementBlock_return);


        object string_literal227_tree=null;
        object LT228_tree=null;
        object char_literal229_tree=null;
        object LT230_tree=null;
        object Identifier231_tree=null;
        object LT232_tree=null;
        object char_literal233_tree=null;
        object LT234_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 39) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:190:2: ( 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* ')' ( LT )* statementBlock )
            // JavaScript.g:190:4: 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* ')' ( LT )* statementBlock
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal227=(IToken)Match(input,56,FOLLOW_56_in_catchClause1186); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal227_tree = (object)adaptor.Create(string_literal227, retval);
            		adaptor.AddChild(root_0, string_literal227_tree);
            	}
            	// JavaScript.g:190:14: ( LT )*
            	do 
            	{
            	    int alt108 = 2;
            	    int LA108_0 = input.LA(1);

            	    if ( (LA108_0 == LT) )
            	    {
            	        alt108 = 1;
            	    }


            	    switch (alt108) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT228=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_catchClause1188), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop108;
            	    }
            	} while (true);

            	loop108:
            		;	// Stops C# compiler whining that label 'loop108' has no statements

            	char_literal229=(IToken)Match(input,32,FOLLOW_32_in_catchClause1192); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal229_tree = (object)adaptor.Create(char_literal229, retval);
            		adaptor.AddChild(root_0, char_literal229_tree);
            	}
            	// JavaScript.g:190:23: ( LT )*
            	do 
            	{
            	    int alt109 = 2;
            	    int LA109_0 = input.LA(1);

            	    if ( (LA109_0 == LT) )
            	    {
            	        alt109 = 1;
            	    }


            	    switch (alt109) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT230=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_catchClause1194), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop109;
            	    }
            	} while (true);

            	loop109:
            		;	// Stops C# compiler whining that label 'loop109' has no statements

            	Identifier231=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_catchClause1198), "Identifier"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier231_tree = (object)adaptor.Create(Identifier231, retval);
            		adaptor.AddChild(root_0, Identifier231_tree);
            	}
            	// JavaScript.g:190:39: ( LT )*
            	do 
            	{
            	    int alt110 = 2;
            	    int LA110_0 = input.LA(1);

            	    if ( (LA110_0 == LT) )
            	    {
            	        alt110 = 1;
            	    }


            	    switch (alt110) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT232=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_catchClause1200), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop110;
            	    }
            	} while (true);

            	loop110:
            		;	// Stops C# compiler whining that label 'loop110' has no statements

            	char_literal233=(IToken)Match(input,34,FOLLOW_34_in_catchClause1204); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal233_tree = (object)adaptor.Create(char_literal233, retval);
            		adaptor.AddChild(root_0, char_literal233_tree);
            	}
            	// JavaScript.g:190:48: ( LT )*
            	do 
            	{
            	    int alt111 = 2;
            	    int LA111_0 = input.LA(1);

            	    if ( (LA111_0 == LT) )
            	    {
            	        alt111 = 1;
            	    }


            	    switch (alt111) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT234=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_catchClause1206), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop111;
            	    }
            	} while (true);

            	loop111:
            		;	// Stops C# compiler whining that label 'loop111' has no statements

            	PushFollow(FOLLOW_statementBlock_in_catchClause1210);
            	statementBlock235 = statementBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock235.Tree, statementBlock235, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 39, catchClause_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "catchClause"

    public class finallyClause_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "finallyClause"
    // JavaScript.g:193:1: finallyClause : 'finally' ( LT )* statementBlock ;
    public JavaScriptParser.finallyClause_return finallyClause() // throws RecognitionException [1]
    {   
        JavaScriptParser.finallyClause_return retval = new JavaScriptParser.finallyClause_return();
        retval.Start = input.LT(1);
        int finallyClause_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal236 = null;
        IToken LT237 = null;
        JavaScriptParser.statementBlock_return statementBlock238 = default(JavaScriptParser.statementBlock_return);


        object string_literal236_tree=null;
        object LT237_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 40) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:194:2: ( 'finally' ( LT )* statementBlock )
            // JavaScript.g:194:4: 'finally' ( LT )* statementBlock
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal236=(IToken)Match(input,57,FOLLOW_57_in_finallyClause1222); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal236_tree = (object)adaptor.Create(string_literal236, retval);
            		adaptor.AddChild(root_0, string_literal236_tree);
            	}
            	// JavaScript.g:194:16: ( LT )*
            	do 
            	{
            	    int alt112 = 2;
            	    int LA112_0 = input.LA(1);

            	    if ( (LA112_0 == LT) )
            	    {
            	        alt112 = 1;
            	    }


            	    switch (alt112) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT237=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_finallyClause1224), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop112;
            	    }
            	} while (true);

            	loop112:
            		;	// Stops C# compiler whining that label 'loop112' has no statements

            	PushFollow(FOLLOW_statementBlock_in_finallyClause1228);
            	statementBlock238 = statementBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock238.Tree, statementBlock238, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 40, finallyClause_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "finallyClause"

    public class expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expression"
    // JavaScript.g:198:1: expression : assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* ;
    public JavaScriptParser.expression_return expression() // throws RecognitionException [1]
    {   
        JavaScriptParser.expression_return retval = new JavaScriptParser.expression_return();
        retval.Start = input.LT(1);
        int expression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT240 = null;
        IToken char_literal241 = null;
        IToken LT242 = null;
        JavaScriptParser.assignmentExpression_return assignmentExpression239 = default(JavaScriptParser.assignmentExpression_return);

        JavaScriptParser.assignmentExpression_return assignmentExpression243 = default(JavaScriptParser.assignmentExpression_return);


        object LT240_tree=null;
        object char_literal241_tree=null;
        object LT242_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 41) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:199:2: ( assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )
            // JavaScript.g:199:4: assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_assignmentExpression_in_expression1240);
            	assignmentExpression239 = assignmentExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression239.Tree, assignmentExpression239, retval);
            	// JavaScript.g:199:25: ( ( LT )* ',' ( LT )* assignmentExpression )*
            	do 
            	{
            	    int alt115 = 2;
            	    alt115 = dfa115.Predict(input);
            	    switch (alt115) 
            		{
            			case 1 :
            			    // JavaScript.g:199:26: ( LT )* ',' ( LT )* assignmentExpression
            			    {
            			    	// JavaScript.g:199:28: ( LT )*
            			    	do 
            			    	{
            			    	    int alt113 = 2;
            			    	    int LA113_0 = input.LA(1);

            			    	    if ( (LA113_0 == LT) )
            			    	    {
            			    	        alt113 = 1;
            			    	    }


            			    	    switch (alt113) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT240=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_expression1243), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop113;
            			    	    }
            			    	} while (true);

            			    	loop113:
            			    		;	// Stops C# compiler whining that label 'loop113' has no statements

            			    	char_literal241=(IToken)Match(input,33,FOLLOW_33_in_expression1247); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal241_tree = (object)adaptor.Create(char_literal241, retval);
            			    		adaptor.AddChild(root_0, char_literal241_tree);
            			    	}
            			    	// JavaScript.g:199:37: ( LT )*
            			    	do 
            			    	{
            			    	    int alt114 = 2;
            			    	    int LA114_0 = input.LA(1);

            			    	    if ( (LA114_0 == LT) )
            			    	    {
            			    	        alt114 = 1;
            			    	    }


            			    	    switch (alt114) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT242=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_expression1249), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop114;
            			    	    }
            			    	} while (true);

            			    	loop114:
            			    		;	// Stops C# compiler whining that label 'loop114' has no statements

            			    	PushFollow(FOLLOW_assignmentExpression_in_expression1253);
            			    	assignmentExpression243 = assignmentExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression243.Tree, assignmentExpression243, retval);

            			    }
            			    break;

            			default:
            			    goto loop115;
            	    }
            	} while (true);

            	loop115:
            		;	// Stops C# compiler whining that label 'loop115' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 41, expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "expression"

    public class expressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expressionNoIn"
    // JavaScript.g:202:1: expressionNoIn : assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )* ;
    public JavaScriptParser.expressionNoIn_return expressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.expressionNoIn_return retval = new JavaScriptParser.expressionNoIn_return();
        retval.Start = input.LT(1);
        int expressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT245 = null;
        IToken char_literal246 = null;
        IToken LT247 = null;
        JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn244 = default(JavaScriptParser.assignmentExpressionNoIn_return);

        JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn248 = default(JavaScriptParser.assignmentExpressionNoIn_return);


        object LT245_tree=null;
        object char_literal246_tree=null;
        object LT247_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 42) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:203:2: ( assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )* )
            // JavaScript.g:203:4: assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1267);
            	assignmentExpressionNoIn244 = assignmentExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn244.Tree, assignmentExpressionNoIn244, retval);
            	// JavaScript.g:203:29: ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*
            	do 
            	{
            	    int alt118 = 2;
            	    alt118 = dfa118.Predict(input);
            	    switch (alt118) 
            		{
            			case 1 :
            			    // JavaScript.g:203:30: ( LT )* ',' ( LT )* assignmentExpressionNoIn
            			    {
            			    	// JavaScript.g:203:32: ( LT )*
            			    	do 
            			    	{
            			    	    int alt116 = 2;
            			    	    int LA116_0 = input.LA(1);

            			    	    if ( (LA116_0 == LT) )
            			    	    {
            			    	        alt116 = 1;
            			    	    }


            			    	    switch (alt116) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT245=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_expressionNoIn1270), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop116;
            			    	    }
            			    	} while (true);

            			    	loop116:
            			    		;	// Stops C# compiler whining that label 'loop116' has no statements

            			    	char_literal246=(IToken)Match(input,33,FOLLOW_33_in_expressionNoIn1274); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal246_tree = (object)adaptor.Create(char_literal246, retval);
            			    		adaptor.AddChild(root_0, char_literal246_tree);
            			    	}
            			    	// JavaScript.g:203:41: ( LT )*
            			    	do 
            			    	{
            			    	    int alt117 = 2;
            			    	    int LA117_0 = input.LA(1);

            			    	    if ( (LA117_0 == LT) )
            			    	    {
            			    	        alt117 = 1;
            			    	    }


            			    	    switch (alt117) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT247=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_expressionNoIn1276), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop117;
            			    	    }
            			    	} while (true);

            			    	loop117:
            			    		;	// Stops C# compiler whining that label 'loop117' has no statements

            			    	PushFollow(FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1280);
            			    	assignmentExpressionNoIn248 = assignmentExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn248.Tree, assignmentExpressionNoIn248, retval);

            			    }
            			    break;

            			default:
            			    goto loop118;
            	    }
            	} while (true);

            	loop118:
            		;	// Stops C# compiler whining that label 'loop118' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 42, expressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "expressionNoIn"

    public class assignmentExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignmentExpression"
    // JavaScript.g:206:1: assignmentExpression : ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression );
    public JavaScriptParser.assignmentExpression_return assignmentExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.assignmentExpression_return retval = new JavaScriptParser.assignmentExpression_return();
        retval.Start = input.LT(1);
        int assignmentExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT251 = null;
        IToken LT253 = null;
        JavaScriptParser.conditionalExpression_return conditionalExpression249 = default(JavaScriptParser.conditionalExpression_return);

        JavaScriptParser.leftHandSideExpression_return leftHandSideExpression250 = default(JavaScriptParser.leftHandSideExpression_return);

        JavaScriptParser.assignmentOperator_return assignmentOperator252 = default(JavaScriptParser.assignmentOperator_return);

        JavaScriptParser.assignmentExpression_return assignmentExpression254 = default(JavaScriptParser.assignmentExpression_return);


        object LT251_tree=null;
        object LT253_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 43) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:207:2: ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression )
            int alt121 = 2;
            alt121 = dfa121.Predict(input);
            switch (alt121) 
            {
                case 1 :
                    // JavaScript.g:207:4: conditionalExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_conditionalExpression_in_assignmentExpression1294);
                    	conditionalExpression249 = conditionalExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpression249.Tree, conditionalExpression249, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:208:4: leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_leftHandSideExpression_in_assignmentExpression1299);
                    	leftHandSideExpression250 = leftHandSideExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression250.Tree, leftHandSideExpression250, retval);
                    	// JavaScript.g:208:29: ( LT )*
                    	do 
                    	{
                    	    int alt119 = 2;
                    	    int LA119_0 = input.LA(1);

                    	    if ( (LA119_0 == LT) )
                    	    {
                    	        alt119 = 1;
                    	    }


                    	    switch (alt119) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT251=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpression1301), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop119;
                    	    }
                    	} while (true);

                    	loop119:
                    		;	// Stops C# compiler whining that label 'loop119' has no statements

                    	PushFollow(FOLLOW_assignmentOperator_in_assignmentExpression1305);
                    	assignmentOperator252 = assignmentOperator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentOperator252.Tree, assignmentOperator252, retval);
                    	// JavaScript.g:208:53: ( LT )*
                    	do 
                    	{
                    	    int alt120 = 2;
                    	    int LA120_0 = input.LA(1);

                    	    if ( (LA120_0 == LT) )
                    	    {
                    	        alt120 = 1;
                    	    }


                    	    switch (alt120) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT253=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpression1307), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop120;
                    	    }
                    	} while (true);

                    	loop120:
                    		;	// Stops C# compiler whining that label 'loop120' has no statements

                    	PushFollow(FOLLOW_assignmentExpression_in_assignmentExpression1311);
                    	assignmentExpression254 = assignmentExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression254.Tree, assignmentExpression254, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 43, assignmentExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "assignmentExpression"

    public class assignmentExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignmentExpressionNoIn"
    // JavaScript.g:211:1: assignmentExpressionNoIn : ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn );
    public JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.assignmentExpressionNoIn_return retval = new JavaScriptParser.assignmentExpressionNoIn_return();
        retval.Start = input.LT(1);
        int assignmentExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT257 = null;
        IToken LT259 = null;
        JavaScriptParser.conditionalExpressionNoIn_return conditionalExpressionNoIn255 = default(JavaScriptParser.conditionalExpressionNoIn_return);

        JavaScriptParser.leftHandSideExpression_return leftHandSideExpression256 = default(JavaScriptParser.leftHandSideExpression_return);

        JavaScriptParser.assignmentOperator_return assignmentOperator258 = default(JavaScriptParser.assignmentOperator_return);

        JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn260 = default(JavaScriptParser.assignmentExpressionNoIn_return);


        object LT257_tree=null;
        object LT259_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 44) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:212:2: ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn )
            int alt124 = 2;
            alt124 = dfa124.Predict(input);
            switch (alt124) 
            {
                case 1 :
                    // JavaScript.g:212:4: conditionalExpressionNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_conditionalExpressionNoIn_in_assignmentExpressionNoIn1323);
                    	conditionalExpressionNoIn255 = conditionalExpressionNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpressionNoIn255.Tree, conditionalExpressionNoIn255, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:213:4: leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_leftHandSideExpression_in_assignmentExpressionNoIn1328);
                    	leftHandSideExpression256 = leftHandSideExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression256.Tree, leftHandSideExpression256, retval);
                    	// JavaScript.g:213:29: ( LT )*
                    	do 
                    	{
                    	    int alt122 = 2;
                    	    int LA122_0 = input.LA(1);

                    	    if ( (LA122_0 == LT) )
                    	    {
                    	        alt122 = 1;
                    	    }


                    	    switch (alt122) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT257=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpressionNoIn1330), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop122;
                    	    }
                    	} while (true);

                    	loop122:
                    		;	// Stops C# compiler whining that label 'loop122' has no statements

                    	PushFollow(FOLLOW_assignmentOperator_in_assignmentExpressionNoIn1334);
                    	assignmentOperator258 = assignmentOperator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentOperator258.Tree, assignmentOperator258, retval);
                    	// JavaScript.g:213:53: ( LT )*
                    	do 
                    	{
                    	    int alt123 = 2;
                    	    int LA123_0 = input.LA(1);

                    	    if ( (LA123_0 == LT) )
                    	    {
                    	        alt123 = 1;
                    	    }


                    	    switch (alt123) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT259=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpressionNoIn1336), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop123;
                    	    }
                    	} while (true);

                    	loop123:
                    		;	// Stops C# compiler whining that label 'loop123' has no statements

                    	PushFollow(FOLLOW_assignmentExpressionNoIn_in_assignmentExpressionNoIn1340);
                    	assignmentExpressionNoIn260 = assignmentExpressionNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn260.Tree, assignmentExpressionNoIn260, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 44, assignmentExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "assignmentExpressionNoIn"

    public class leftHandSideExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "leftHandSideExpression"
    // JavaScript.g:216:1: leftHandSideExpression : ( callExpression | newExpression );
    public JavaScriptParser.leftHandSideExpression_return leftHandSideExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.leftHandSideExpression_return retval = new JavaScriptParser.leftHandSideExpression_return();
        retval.Start = input.LT(1);
        int leftHandSideExpression_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.callExpression_return callExpression261 = default(JavaScriptParser.callExpression_return);

        JavaScriptParser.newExpression_return newExpression262 = default(JavaScriptParser.newExpression_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 45) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:217:2: ( callExpression | newExpression )
            int alt125 = 2;
            alt125 = dfa125.Predict(input);
            switch (alt125) 
            {
                case 1 :
                    // JavaScript.g:217:4: callExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_callExpression_in_leftHandSideExpression1352);
                    	callExpression261 = callExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, callExpression261.Tree, callExpression261, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:218:4: newExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_newExpression_in_leftHandSideExpression1357);
                    	newExpression262 = newExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, newExpression262.Tree, newExpression262, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 45, leftHandSideExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "leftHandSideExpression"

    public class newExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "newExpression"
    // JavaScript.g:221:1: newExpression : ( memberExpression | 'new' ( LT )* newExpression );
    public JavaScriptParser.newExpression_return newExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.newExpression_return retval = new JavaScriptParser.newExpression_return();
        retval.Start = input.LT(1);
        int newExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal264 = null;
        IToken LT265 = null;
        JavaScriptParser.memberExpression_return memberExpression263 = default(JavaScriptParser.memberExpression_return);

        JavaScriptParser.newExpression_return newExpression266 = default(JavaScriptParser.newExpression_return);


        object string_literal264_tree=null;
        object LT265_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 46) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:222:2: ( memberExpression | 'new' ( LT )* newExpression )
            int alt127 = 2;
            alt127 = dfa127.Predict(input);
            switch (alt127) 
            {
                case 1 :
                    // JavaScript.g:222:4: memberExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_memberExpression_in_newExpression1369);
                    	memberExpression263 = memberExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression263.Tree, memberExpression263, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:223:4: 'new' ( LT )* newExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal264=(IToken)Match(input,58,FOLLOW_58_in_newExpression1374); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal264_tree = (object)adaptor.Create(string_literal264, retval);
                    		adaptor.AddChild(root_0, string_literal264_tree);
                    	}
                    	// JavaScript.g:223:12: ( LT )*
                    	do 
                    	{
                    	    int alt126 = 2;
                    	    int LA126_0 = input.LA(1);

                    	    if ( (LA126_0 == LT) )
                    	    {
                    	        alt126 = 1;
                    	    }


                    	    switch (alt126) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT265=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_newExpression1376), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop126;
                    	    }
                    	} while (true);

                    	loop126:
                    		;	// Stops C# compiler whining that label 'loop126' has no statements

                    	PushFollow(FOLLOW_newExpression_in_newExpression1380);
                    	newExpression266 = newExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, newExpression266.Tree, newExpression266, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 46, newExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "newExpression"

    public class memberExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "memberExpression"
    // JavaScript.g:226:1: memberExpression : ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )* ;
    public JavaScriptParser.memberExpression_return memberExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.memberExpression_return retval = new JavaScriptParser.memberExpression_return();
        retval.Start = input.LT(1);
        int memberExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal269 = null;
        IToken LT270 = null;
        IToken LT272 = null;
        IToken LT274 = null;
        JavaScriptParser.primaryExpression_return primaryExpression267 = default(JavaScriptParser.primaryExpression_return);

        JavaScriptParser.functionExpression_return functionExpression268 = default(JavaScriptParser.functionExpression_return);

        JavaScriptParser.memberExpression_return memberExpression271 = default(JavaScriptParser.memberExpression_return);

        JavaScriptParser.arguments_return arguments273 = default(JavaScriptParser.arguments_return);

        JavaScriptParser.memberExpressionSuffix_return memberExpressionSuffix275 = default(JavaScriptParser.memberExpressionSuffix_return);


        object string_literal269_tree=null;
        object LT270_tree=null;
        object LT272_tree=null;
        object LT274_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 47) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:227:2: ( ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )* )
            // JavaScript.g:227:4: ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// JavaScript.g:227:4: ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments )
            	int alt130 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case Identifier:
            	case StringLiteral:
            	case NumericLiteral:
            	case 32:
            	case 35:
            	case 59:
            	case 103:
            	case 104:
            	case 105:
            	case 106:
            		{
            	    alt130 = 1;
            	    }
            	    break;
            	case 31:
            		{
            	    alt130 = 2;
            	    }
            	    break;
            	case 58:
            		{
            	    alt130 = 3;
            	    }
            	    break;
            		default:
            		    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            		    NoViableAltException nvae_d130s0 =
            		        new NoViableAltException("", 130, 0, input);

            		    throw nvae_d130s0;
            	}

            	switch (alt130) 
            	{
            	    case 1 :
            	        // JavaScript.g:227:5: primaryExpression
            	        {
            	        	PushFollow(FOLLOW_primaryExpression_in_memberExpression1393);
            	        	primaryExpression267 = primaryExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primaryExpression267.Tree, primaryExpression267, retval);

            	        }
            	        break;
            	    case 2 :
            	        // JavaScript.g:227:25: functionExpression
            	        {
            	        	PushFollow(FOLLOW_functionExpression_in_memberExpression1397);
            	        	functionExpression268 = functionExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionExpression268.Tree, functionExpression268, retval);

            	        }
            	        break;
            	    case 3 :
            	        // JavaScript.g:227:46: 'new' ( LT )* memberExpression ( LT )* arguments
            	        {
            	        	string_literal269=(IToken)Match(input,58,FOLLOW_58_in_memberExpression1401); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{string_literal269_tree = (object)adaptor.Create(string_literal269, retval);
            	        		adaptor.AddChild(root_0, string_literal269_tree);
            	        	}
            	        	// JavaScript.g:227:54: ( LT )*
            	        	do 
            	        	{
            	        	    int alt128 = 2;
            	        	    int LA128_0 = input.LA(1);

            	        	    if ( (LA128_0 == LT) )
            	        	    {
            	        	        alt128 = 1;
            	        	    }


            	        	    switch (alt128) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT270=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_memberExpression1403), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop128;
            	        	    }
            	        	} while (true);

            	        	loop128:
            	        		;	// Stops C# compiler whining that label 'loop128' has no statements

            	        	PushFollow(FOLLOW_memberExpression_in_memberExpression1407);
            	        	memberExpression271 = memberExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression271.Tree, memberExpression271, retval);
            	        	// JavaScript.g:227:76: ( LT )*
            	        	do 
            	        	{
            	        	    int alt129 = 2;
            	        	    int LA129_0 = input.LA(1);

            	        	    if ( (LA129_0 == LT) )
            	        	    {
            	        	        alt129 = 1;
            	        	    }


            	        	    switch (alt129) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT272=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_memberExpression1409), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop129;
            	        	    }
            	        	} while (true);

            	        	loop129:
            	        		;	// Stops C# compiler whining that label 'loop129' has no statements

            	        	PushFollow(FOLLOW_arguments_in_memberExpression1413);
            	        	arguments273 = arguments();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments273.Tree, arguments273, retval);

            	        }
            	        break;

            	}

            	// JavaScript.g:227:90: ( ( LT )* memberExpressionSuffix )*
            	do 
            	{
            	    int alt132 = 2;
            	    alt132 = dfa132.Predict(input);
            	    switch (alt132) 
            		{
            			case 1 :
            			    // JavaScript.g:227:91: ( LT )* memberExpressionSuffix
            			    {
            			    	// JavaScript.g:227:93: ( LT )*
            			    	do 
            			    	{
            			    	    int alt131 = 2;
            			    	    int LA131_0 = input.LA(1);

            			    	    if ( (LA131_0 == LT) )
            			    	    {
            			    	        alt131 = 1;
            			    	    }


            			    	    switch (alt131) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT274=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_memberExpression1417), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop131;
            			    	    }
            			    	} while (true);

            			    	loop131:
            			    		;	// Stops C# compiler whining that label 'loop131' has no statements

            			    	PushFollow(FOLLOW_memberExpressionSuffix_in_memberExpression1421);
            			    	memberExpressionSuffix275 = memberExpressionSuffix();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpressionSuffix275.Tree, memberExpressionSuffix275, retval);

            			    }
            			    break;

            			default:
            			    goto loop132;
            	    }
            	} while (true);

            	loop132:
            		;	// Stops C# compiler whining that label 'loop132' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 47, memberExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "memberExpression"

    public class memberExpressionSuffix_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "memberExpressionSuffix"
    // JavaScript.g:230:1: memberExpressionSuffix : ( indexSuffix | propertyReferenceSuffix );
    public JavaScriptParser.memberExpressionSuffix_return memberExpressionSuffix() // throws RecognitionException [1]
    {   
        JavaScriptParser.memberExpressionSuffix_return retval = new JavaScriptParser.memberExpressionSuffix_return();
        retval.Start = input.LT(1);
        int memberExpressionSuffix_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.indexSuffix_return indexSuffix276 = default(JavaScriptParser.indexSuffix_return);

        JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix277 = default(JavaScriptParser.propertyReferenceSuffix_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 48) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:231:2: ( indexSuffix | propertyReferenceSuffix )
            int alt133 = 2;
            int LA133_0 = input.LA(1);

            if ( (LA133_0 == 59) )
            {
                alt133 = 1;
            }
            else if ( (LA133_0 == 61) )
            {
                alt133 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d133s0 =
                    new NoViableAltException("", 133, 0, input);

                throw nvae_d133s0;
            }
            switch (alt133) 
            {
                case 1 :
                    // JavaScript.g:231:4: indexSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_indexSuffix_in_memberExpressionSuffix1435);
                    	indexSuffix276 = indexSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, indexSuffix276.Tree, indexSuffix276, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:232:4: propertyReferenceSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_propertyReferenceSuffix_in_memberExpressionSuffix1440);
                    	propertyReferenceSuffix277 = propertyReferenceSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyReferenceSuffix277.Tree, propertyReferenceSuffix277, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 48, memberExpressionSuffix_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "memberExpressionSuffix"

    public class callExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "callExpression"
    // JavaScript.g:235:1: callExpression : memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )* ;
    public JavaScriptParser.callExpression_return callExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.callExpression_return retval = new JavaScriptParser.callExpression_return();
        retval.Start = input.LT(1);
        int callExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT279 = null;
        IToken LT281 = null;
        JavaScriptParser.memberExpression_return memberExpression278 = default(JavaScriptParser.memberExpression_return);

        JavaScriptParser.arguments_return arguments280 = default(JavaScriptParser.arguments_return);

        JavaScriptParser.callExpressionSuffix_return callExpressionSuffix282 = default(JavaScriptParser.callExpressionSuffix_return);


        object LT279_tree=null;
        object LT281_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 49) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:236:2: ( memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )* )
            // JavaScript.g:236:4: memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_memberExpression_in_callExpression1451);
            	memberExpression278 = memberExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression278.Tree, memberExpression278, retval);
            	// JavaScript.g:236:23: ( LT )*
            	do 
            	{
            	    int alt134 = 2;
            	    int LA134_0 = input.LA(1);

            	    if ( (LA134_0 == LT) )
            	    {
            	        alt134 = 1;
            	    }


            	    switch (alt134) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT279=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_callExpression1453), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop134;
            	    }
            	} while (true);

            	loop134:
            		;	// Stops C# compiler whining that label 'loop134' has no statements

            	PushFollow(FOLLOW_arguments_in_callExpression1457);
            	arguments280 = arguments();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments280.Tree, arguments280, retval);
            	// JavaScript.g:236:36: ( ( LT )* callExpressionSuffix )*
            	do 
            	{
            	    int alt136 = 2;
            	    alt136 = dfa136.Predict(input);
            	    switch (alt136) 
            		{
            			case 1 :
            			    // JavaScript.g:236:37: ( LT )* callExpressionSuffix
            			    {
            			    	// JavaScript.g:236:39: ( LT )*
            			    	do 
            			    	{
            			    	    int alt135 = 2;
            			    	    int LA135_0 = input.LA(1);

            			    	    if ( (LA135_0 == LT) )
            			    	    {
            			    	        alt135 = 1;
            			    	    }


            			    	    switch (alt135) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT281=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_callExpression1460), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop135;
            			    	    }
            			    	} while (true);

            			    	loop135:
            			    		;	// Stops C# compiler whining that label 'loop135' has no statements

            			    	PushFollow(FOLLOW_callExpressionSuffix_in_callExpression1464);
            			    	callExpressionSuffix282 = callExpressionSuffix();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, callExpressionSuffix282.Tree, callExpressionSuffix282, retval);

            			    }
            			    break;

            			default:
            			    goto loop136;
            	    }
            	} while (true);

            	loop136:
            		;	// Stops C# compiler whining that label 'loop136' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 49, callExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "callExpression"

    public class callExpressionSuffix_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "callExpressionSuffix"
    // JavaScript.g:239:1: callExpressionSuffix : ( arguments | indexSuffix | propertyReferenceSuffix );
    public JavaScriptParser.callExpressionSuffix_return callExpressionSuffix() // throws RecognitionException [1]
    {   
        JavaScriptParser.callExpressionSuffix_return retval = new JavaScriptParser.callExpressionSuffix_return();
        retval.Start = input.LT(1);
        int callExpressionSuffix_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.arguments_return arguments283 = default(JavaScriptParser.arguments_return);

        JavaScriptParser.indexSuffix_return indexSuffix284 = default(JavaScriptParser.indexSuffix_return);

        JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix285 = default(JavaScriptParser.propertyReferenceSuffix_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 50) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:240:2: ( arguments | indexSuffix | propertyReferenceSuffix )
            int alt137 = 3;
            switch ( input.LA(1) ) 
            {
            case 32:
            	{
                alt137 = 1;
                }
                break;
            case 59:
            	{
                alt137 = 2;
                }
                break;
            case 61:
            	{
                alt137 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d137s0 =
            	        new NoViableAltException("", 137, 0, input);

            	    throw nvae_d137s0;
            }

            switch (alt137) 
            {
                case 1 :
                    // JavaScript.g:240:4: arguments
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_arguments_in_callExpressionSuffix1478);
                    	arguments283 = arguments();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments283.Tree, arguments283, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:241:4: indexSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_indexSuffix_in_callExpressionSuffix1483);
                    	indexSuffix284 = indexSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, indexSuffix284.Tree, indexSuffix284, retval);

                    }
                    break;
                case 3 :
                    // JavaScript.g:242:4: propertyReferenceSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_propertyReferenceSuffix_in_callExpressionSuffix1488);
                    	propertyReferenceSuffix285 = propertyReferenceSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyReferenceSuffix285.Tree, propertyReferenceSuffix285, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 50, callExpressionSuffix_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "callExpressionSuffix"

    public class arguments_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "arguments"
    // JavaScript.g:245:1: arguments : '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* ')' ;
    public JavaScriptParser.arguments_return arguments() // throws RecognitionException [1]
    {   
        JavaScriptParser.arguments_return retval = new JavaScriptParser.arguments_return();
        retval.Start = input.LT(1);
        int arguments_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal286 = null;
        IToken LT287 = null;
        IToken LT289 = null;
        IToken char_literal290 = null;
        IToken LT291 = null;
        IToken LT293 = null;
        IToken char_literal294 = null;
        JavaScriptParser.assignmentExpression_return assignmentExpression288 = default(JavaScriptParser.assignmentExpression_return);

        JavaScriptParser.assignmentExpression_return assignmentExpression292 = default(JavaScriptParser.assignmentExpression_return);


        object char_literal286_tree=null;
        object LT287_tree=null;
        object LT289_tree=null;
        object char_literal290_tree=null;
        object LT291_tree=null;
        object LT293_tree=null;
        object char_literal294_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 51) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:246:2: ( '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* ')' )
            // JavaScript.g:246:4: '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* ')'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal286=(IToken)Match(input,32,FOLLOW_32_in_arguments1499); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal286_tree = (object)adaptor.Create(char_literal286, retval);
            		adaptor.AddChild(root_0, char_literal286_tree);
            	}
            	// JavaScript.g:246:8: ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )?
            	int alt142 = 2;
            	alt142 = dfa142.Predict(input);
            	switch (alt142) 
            	{
            	    case 1 :
            	        // JavaScript.g:246:9: ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )*
            	        {
            	        	// JavaScript.g:246:11: ( LT )*
            	        	do 
            	        	{
            	        	    int alt138 = 2;
            	        	    int LA138_0 = input.LA(1);

            	        	    if ( (LA138_0 == LT) )
            	        	    {
            	        	        alt138 = 1;
            	        	    }


            	        	    switch (alt138) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT287=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arguments1502), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop138;
            	        	    }
            	        	} while (true);

            	        	loop138:
            	        		;	// Stops C# compiler whining that label 'loop138' has no statements

            	        	PushFollow(FOLLOW_assignmentExpression_in_arguments1506);
            	        	assignmentExpression288 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression288.Tree, assignmentExpression288, retval);
            	        	// JavaScript.g:246:35: ( ( LT )* ',' ( LT )* assignmentExpression )*
            	        	do 
            	        	{
            	        	    int alt141 = 2;
            	        	    alt141 = dfa141.Predict(input);
            	        	    switch (alt141) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:246:36: ( LT )* ',' ( LT )* assignmentExpression
            	        			    {
            	        			    	// JavaScript.g:246:38: ( LT )*
            	        			    	do 
            	        			    	{
            	        			    	    int alt139 = 2;
            	        			    	    int LA139_0 = input.LA(1);

            	        			    	    if ( (LA139_0 == LT) )
            	        			    	    {
            	        			    	        alt139 = 1;
            	        			    	    }


            	        			    	    switch (alt139) 
            	        			    		{
            	        			    			case 1 :
            	        			    			    // JavaScript.g:0:0: LT
            	        			    			    {
            	        			    			    	LT289=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arguments1509), "LT"); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop139;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop139:
            	        			    		;	// Stops C# compiler whining that label 'loop139' has no statements

            	        			    	char_literal290=(IToken)Match(input,33,FOLLOW_33_in_arguments1513); if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 )
            	        			    	{char_literal290_tree = (object)adaptor.Create(char_literal290, retval);
            	        			    		adaptor.AddChild(root_0, char_literal290_tree);
            	        			    	}
            	        			    	// JavaScript.g:246:47: ( LT )*
            	        			    	do 
            	        			    	{
            	        			    	    int alt140 = 2;
            	        			    	    int LA140_0 = input.LA(1);

            	        			    	    if ( (LA140_0 == LT) )
            	        			    	    {
            	        			    	        alt140 = 1;
            	        			    	    }


            	        			    	    switch (alt140) 
            	        			    		{
            	        			    			case 1 :
            	        			    			    // JavaScript.g:0:0: LT
            	        			    			    {
            	        			    			    	LT291=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arguments1515), "LT"); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop140;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop140:
            	        			    		;	// Stops C# compiler whining that label 'loop140' has no statements

            	        			    	PushFollow(FOLLOW_assignmentExpression_in_arguments1519);
            	        			    	assignmentExpression292 = assignmentExpression();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression292.Tree, assignmentExpression292, retval);

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop141;
            	        	    }
            	        	} while (true);

            	        	loop141:
            	        		;	// Stops C# compiler whining that label 'loop141' has no statements


            	        }
            	        break;

            	}

            	// JavaScript.g:246:77: ( LT )*
            	do 
            	{
            	    int alt143 = 2;
            	    int LA143_0 = input.LA(1);

            	    if ( (LA143_0 == LT) )
            	    {
            	        alt143 = 1;
            	    }


            	    switch (alt143) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT293=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arguments1525), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop143;
            	    }
            	} while (true);

            	loop143:
            		;	// Stops C# compiler whining that label 'loop143' has no statements

            	char_literal294=(IToken)Match(input,34,FOLLOW_34_in_arguments1529); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal294_tree = (object)adaptor.Create(char_literal294, retval);
            		adaptor.AddChild(root_0, char_literal294_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 51, arguments_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "arguments"

    public class indexSuffix_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "indexSuffix"
    // JavaScript.g:249:1: indexSuffix : '[' ( LT )* expression ( LT )* ']' ;
    public JavaScriptParser.indexSuffix_return indexSuffix() // throws RecognitionException [1]
    {   
        JavaScriptParser.indexSuffix_return retval = new JavaScriptParser.indexSuffix_return();
        retval.Start = input.LT(1);
        int indexSuffix_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal295 = null;
        IToken LT296 = null;
        IToken LT298 = null;
        IToken char_literal299 = null;
        JavaScriptParser.expression_return expression297 = default(JavaScriptParser.expression_return);


        object char_literal295_tree=null;
        object LT296_tree=null;
        object LT298_tree=null;
        object char_literal299_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 52) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:250:2: ( '[' ( LT )* expression ( LT )* ']' )
            // JavaScript.g:250:4: '[' ( LT )* expression ( LT )* ']'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal295=(IToken)Match(input,59,FOLLOW_59_in_indexSuffix1541); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal295_tree = (object)adaptor.Create(char_literal295, retval);
            		adaptor.AddChild(root_0, char_literal295_tree);
            	}
            	// JavaScript.g:250:10: ( LT )*
            	do 
            	{
            	    int alt144 = 2;
            	    int LA144_0 = input.LA(1);

            	    if ( (LA144_0 == LT) )
            	    {
            	        alt144 = 1;
            	    }


            	    switch (alt144) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT296=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_indexSuffix1543), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop144;
            	    }
            	} while (true);

            	loop144:
            		;	// Stops C# compiler whining that label 'loop144' has no statements

            	PushFollow(FOLLOW_expression_in_indexSuffix1547);
            	expression297 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression297.Tree, expression297, retval);
            	// JavaScript.g:250:26: ( LT )*
            	do 
            	{
            	    int alt145 = 2;
            	    int LA145_0 = input.LA(1);

            	    if ( (LA145_0 == LT) )
            	    {
            	        alt145 = 1;
            	    }


            	    switch (alt145) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT298=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_indexSuffix1549), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop145;
            	    }
            	} while (true);

            	loop145:
            		;	// Stops C# compiler whining that label 'loop145' has no statements

            	char_literal299=(IToken)Match(input,60,FOLLOW_60_in_indexSuffix1553); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal299_tree = (object)adaptor.Create(char_literal299, retval);
            		adaptor.AddChild(root_0, char_literal299_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 52, indexSuffix_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "indexSuffix"

    public class propertyReferenceSuffix_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "propertyReferenceSuffix"
    // JavaScript.g:253:1: propertyReferenceSuffix : '.' ( LT )* Identifier ;
    public JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix() // throws RecognitionException [1]
    {   
        JavaScriptParser.propertyReferenceSuffix_return retval = new JavaScriptParser.propertyReferenceSuffix_return();
        retval.Start = input.LT(1);
        int propertyReferenceSuffix_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal300 = null;
        IToken LT301 = null;
        IToken Identifier302 = null;

        object char_literal300_tree=null;
        object LT301_tree=null;
        object Identifier302_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 53) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:254:2: ( '.' ( LT )* Identifier )
            // JavaScript.g:254:4: '.' ( LT )* Identifier
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal300=(IToken)Match(input,61,FOLLOW_61_in_propertyReferenceSuffix1566); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal300_tree = (object)adaptor.Create(char_literal300, retval);
            		adaptor.AddChild(root_0, char_literal300_tree);
            	}
            	// JavaScript.g:254:10: ( LT )*
            	do 
            	{
            	    int alt146 = 2;
            	    int LA146_0 = input.LA(1);

            	    if ( (LA146_0 == LT) )
            	    {
            	        alt146 = 1;
            	    }


            	    switch (alt146) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT301=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_propertyReferenceSuffix1568), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop146;
            	    }
            	} while (true);

            	loop146:
            		;	// Stops C# compiler whining that label 'loop146' has no statements

            	Identifier302=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_propertyReferenceSuffix1572), "Identifier"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier302_tree = (object)adaptor.Create(Identifier302, retval);
            		adaptor.AddChild(root_0, Identifier302_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 53, propertyReferenceSuffix_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "propertyReferenceSuffix"

    public class assignmentOperator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignmentOperator"
    // JavaScript.g:257:1: assignmentOperator : ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '>>>=' | '&=' | '^=' | '|=' );
    public JavaScriptParser.assignmentOperator_return assignmentOperator() // throws RecognitionException [1]
    {   
        JavaScriptParser.assignmentOperator_return retval = new JavaScriptParser.assignmentOperator_return();
        retval.Start = input.LT(1);
        int assignmentOperator_StartIndex = input.Index();
        object root_0 = null;

        IToken set303 = null;

        object set303_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 54) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:258:2: ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '>>>=' | '&=' | '^=' | '|=' )
            // JavaScript.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set303 = (IToken)input.LT(1);
            	if ( input.LA(1) == 39 || (input.LA(1) >= 62 && input.LA(1) <= 72) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set303, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 54, assignmentOperator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "assignmentOperator"

    public class conditionalExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "conditionalExpression"
    // JavaScript.g:261:1: conditionalExpression : logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )? ;
    public JavaScriptParser.conditionalExpression_return conditionalExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.conditionalExpression_return retval = new JavaScriptParser.conditionalExpression_return();
        retval.Start = input.LT(1);
        int conditionalExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT305 = null;
        IToken char_literal306 = null;
        IToken LT307 = null;
        IToken LT309 = null;
        IToken char_literal310 = null;
        IToken LT311 = null;
        JavaScriptParser.logicalORExpression_return logicalORExpression304 = default(JavaScriptParser.logicalORExpression_return);

        JavaScriptParser.assignmentExpression_return assignmentExpression308 = default(JavaScriptParser.assignmentExpression_return);

        JavaScriptParser.assignmentExpression_return assignmentExpression312 = default(JavaScriptParser.assignmentExpression_return);


        object LT305_tree=null;
        object char_literal306_tree=null;
        object LT307_tree=null;
        object LT309_tree=null;
        object char_literal310_tree=null;
        object LT311_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 55) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:262:2: ( logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )? )
            // JavaScript.g:262:4: logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalORExpression_in_conditionalExpression1639);
            	logicalORExpression304 = logicalORExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalORExpression304.Tree, logicalORExpression304, retval);
            	// JavaScript.g:262:24: ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?
            	int alt151 = 2;
            	alt151 = dfa151.Predict(input);
            	switch (alt151) 
            	{
            	    case 1 :
            	        // JavaScript.g:262:25: ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression
            	        {
            	        	// JavaScript.g:262:27: ( LT )*
            	        	do 
            	        	{
            	        	    int alt147 = 2;
            	        	    int LA147_0 = input.LA(1);

            	        	    if ( (LA147_0 == LT) )
            	        	    {
            	        	        alt147 = 1;
            	        	    }


            	        	    switch (alt147) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT305=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression1642), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop147;
            	        	    }
            	        	} while (true);

            	        	loop147:
            	        		;	// Stops C# compiler whining that label 'loop147' has no statements

            	        	char_literal306=(IToken)Match(input,73,FOLLOW_73_in_conditionalExpression1646); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal306_tree = (object)adaptor.Create(char_literal306, retval);
            	        		adaptor.AddChild(root_0, char_literal306_tree);
            	        	}
            	        	// JavaScript.g:262:36: ( LT )*
            	        	do 
            	        	{
            	        	    int alt148 = 2;
            	        	    int LA148_0 = input.LA(1);

            	        	    if ( (LA148_0 == LT) )
            	        	    {
            	        	        alt148 = 1;
            	        	    }


            	        	    switch (alt148) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT307=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression1648), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop148;
            	        	    }
            	        	} while (true);

            	        	loop148:
            	        		;	// Stops C# compiler whining that label 'loop148' has no statements

            	        	PushFollow(FOLLOW_assignmentExpression_in_conditionalExpression1652);
            	        	assignmentExpression308 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression308.Tree, assignmentExpression308, retval);
            	        	// JavaScript.g:262:62: ( LT )*
            	        	do 
            	        	{
            	        	    int alt149 = 2;
            	        	    int LA149_0 = input.LA(1);

            	        	    if ( (LA149_0 == LT) )
            	        	    {
            	        	        alt149 = 1;
            	        	    }


            	        	    switch (alt149) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT309=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression1654), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop149;
            	        	    }
            	        	} while (true);

            	        	loop149:
            	        		;	// Stops C# compiler whining that label 'loop149' has no statements

            	        	char_literal310=(IToken)Match(input,50,FOLLOW_50_in_conditionalExpression1658); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal310_tree = (object)adaptor.Create(char_literal310, retval);
            	        		adaptor.AddChild(root_0, char_literal310_tree);
            	        	}
            	        	// JavaScript.g:262:71: ( LT )*
            	        	do 
            	        	{
            	        	    int alt150 = 2;
            	        	    int LA150_0 = input.LA(1);

            	        	    if ( (LA150_0 == LT) )
            	        	    {
            	        	        alt150 = 1;
            	        	    }


            	        	    switch (alt150) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT311=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression1660), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop150;
            	        	    }
            	        	} while (true);

            	        	loop150:
            	        		;	// Stops C# compiler whining that label 'loop150' has no statements

            	        	PushFollow(FOLLOW_assignmentExpression_in_conditionalExpression1664);
            	        	assignmentExpression312 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression312.Tree, assignmentExpression312, retval);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 55, conditionalExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "conditionalExpression"

    public class conditionalExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "conditionalExpressionNoIn"
    // JavaScript.g:265:1: conditionalExpressionNoIn : logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )? ;
    public JavaScriptParser.conditionalExpressionNoIn_return conditionalExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.conditionalExpressionNoIn_return retval = new JavaScriptParser.conditionalExpressionNoIn_return();
        retval.Start = input.LT(1);
        int conditionalExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT314 = null;
        IToken char_literal315 = null;
        IToken LT316 = null;
        IToken LT318 = null;
        IToken char_literal319 = null;
        IToken LT320 = null;
        JavaScriptParser.logicalORExpressionNoIn_return logicalORExpressionNoIn313 = default(JavaScriptParser.logicalORExpressionNoIn_return);

        JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn317 = default(JavaScriptParser.assignmentExpressionNoIn_return);

        JavaScriptParser.assignmentExpressionNoIn_return assignmentExpressionNoIn321 = default(JavaScriptParser.assignmentExpressionNoIn_return);


        object LT314_tree=null;
        object char_literal315_tree=null;
        object LT316_tree=null;
        object LT318_tree=null;
        object char_literal319_tree=null;
        object LT320_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 56) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:266:2: ( logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )? )
            // JavaScript.g:266:4: logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalORExpressionNoIn_in_conditionalExpressionNoIn1677);
            	logicalORExpressionNoIn313 = logicalORExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalORExpressionNoIn313.Tree, logicalORExpressionNoIn313, retval);
            	// JavaScript.g:266:28: ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?
            	int alt156 = 2;
            	alt156 = dfa156.Predict(input);
            	switch (alt156) 
            	{
            	    case 1 :
            	        // JavaScript.g:266:29: ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn
            	        {
            	        	// JavaScript.g:266:31: ( LT )*
            	        	do 
            	        	{
            	        	    int alt152 = 2;
            	        	    int LA152_0 = input.LA(1);

            	        	    if ( (LA152_0 == LT) )
            	        	    {
            	        	        alt152 = 1;
            	        	    }


            	        	    switch (alt152) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT314=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn1680), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop152;
            	        	    }
            	        	} while (true);

            	        	loop152:
            	        		;	// Stops C# compiler whining that label 'loop152' has no statements

            	        	char_literal315=(IToken)Match(input,73,FOLLOW_73_in_conditionalExpressionNoIn1684); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal315_tree = (object)adaptor.Create(char_literal315, retval);
            	        		adaptor.AddChild(root_0, char_literal315_tree);
            	        	}
            	        	// JavaScript.g:266:40: ( LT )*
            	        	do 
            	        	{
            	        	    int alt153 = 2;
            	        	    int LA153_0 = input.LA(1);

            	        	    if ( (LA153_0 == LT) )
            	        	    {
            	        	        alt153 = 1;
            	        	    }


            	        	    switch (alt153) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT316=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn1686), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop153;
            	        	    }
            	        	} while (true);

            	        	loop153:
            	        		;	// Stops C# compiler whining that label 'loop153' has no statements

            	        	PushFollow(FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn1690);
            	        	assignmentExpressionNoIn317 = assignmentExpressionNoIn();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn317.Tree, assignmentExpressionNoIn317, retval);
            	        	// JavaScript.g:266:70: ( LT )*
            	        	do 
            	        	{
            	        	    int alt154 = 2;
            	        	    int LA154_0 = input.LA(1);

            	        	    if ( (LA154_0 == LT) )
            	        	    {
            	        	        alt154 = 1;
            	        	    }


            	        	    switch (alt154) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT318=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn1692), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop154;
            	        	    }
            	        	} while (true);

            	        	loop154:
            	        		;	// Stops C# compiler whining that label 'loop154' has no statements

            	        	char_literal319=(IToken)Match(input,50,FOLLOW_50_in_conditionalExpressionNoIn1696); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal319_tree = (object)adaptor.Create(char_literal319, retval);
            	        		adaptor.AddChild(root_0, char_literal319_tree);
            	        	}
            	        	// JavaScript.g:266:79: ( LT )*
            	        	do 
            	        	{
            	        	    int alt155 = 2;
            	        	    int LA155_0 = input.LA(1);

            	        	    if ( (LA155_0 == LT) )
            	        	    {
            	        	        alt155 = 1;
            	        	    }


            	        	    switch (alt155) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:0:0: LT
            	        			    {
            	        			    	LT320=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn1698), "LT"); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop155;
            	        	    }
            	        	} while (true);

            	        	loop155:
            	        		;	// Stops C# compiler whining that label 'loop155' has no statements

            	        	PushFollow(FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn1702);
            	        	assignmentExpressionNoIn321 = assignmentExpressionNoIn();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn321.Tree, assignmentExpressionNoIn321, retval);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 56, conditionalExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "conditionalExpressionNoIn"

    public class logicalORExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalORExpression"
    // JavaScript.g:269:1: logicalORExpression : logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )* ;
    public JavaScriptParser.logicalORExpression_return logicalORExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.logicalORExpression_return retval = new JavaScriptParser.logicalORExpression_return();
        retval.Start = input.LT(1);
        int logicalORExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT323 = null;
        IToken string_literal324 = null;
        IToken LT325 = null;
        JavaScriptParser.logicalANDExpression_return logicalANDExpression322 = default(JavaScriptParser.logicalANDExpression_return);

        JavaScriptParser.logicalANDExpression_return logicalANDExpression326 = default(JavaScriptParser.logicalANDExpression_return);


        object LT323_tree=null;
        object string_literal324_tree=null;
        object LT325_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 57) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:270:2: ( logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )* )
            // JavaScript.g:270:4: logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalANDExpression_in_logicalORExpression1715);
            	logicalANDExpression322 = logicalANDExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpression322.Tree, logicalANDExpression322, retval);
            	// JavaScript.g:270:25: ( ( LT )* '||' ( LT )* logicalANDExpression )*
            	do 
            	{
            	    int alt159 = 2;
            	    alt159 = dfa159.Predict(input);
            	    switch (alt159) 
            		{
            			case 1 :
            			    // JavaScript.g:270:26: ( LT )* '||' ( LT )* logicalANDExpression
            			    {
            			    	// JavaScript.g:270:28: ( LT )*
            			    	do 
            			    	{
            			    	    int alt157 = 2;
            			    	    int LA157_0 = input.LA(1);

            			    	    if ( (LA157_0 == LT) )
            			    	    {
            			    	        alt157 = 1;
            			    	    }


            			    	    switch (alt157) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT323=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpression1718), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop157;
            			    	    }
            			    	} while (true);

            			    	loop157:
            			    		;	// Stops C# compiler whining that label 'loop157' has no statements

            			    	string_literal324=(IToken)Match(input,74,FOLLOW_74_in_logicalORExpression1722); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal324_tree = (object)adaptor.Create(string_literal324, retval);
            			    		adaptor.AddChild(root_0, string_literal324_tree);
            			    	}
            			    	// JavaScript.g:270:38: ( LT )*
            			    	do 
            			    	{
            			    	    int alt158 = 2;
            			    	    int LA158_0 = input.LA(1);

            			    	    if ( (LA158_0 == LT) )
            			    	    {
            			    	        alt158 = 1;
            			    	    }


            			    	    switch (alt158) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT325=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpression1724), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop158;
            			    	    }
            			    	} while (true);

            			    	loop158:
            			    		;	// Stops C# compiler whining that label 'loop158' has no statements

            			    	PushFollow(FOLLOW_logicalANDExpression_in_logicalORExpression1728);
            			    	logicalANDExpression326 = logicalANDExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpression326.Tree, logicalANDExpression326, retval);

            			    }
            			    break;

            			default:
            			    goto loop159;
            	    }
            	} while (true);

            	loop159:
            		;	// Stops C# compiler whining that label 'loop159' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 57, logicalORExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logicalORExpression"

    public class logicalORExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalORExpressionNoIn"
    // JavaScript.g:273:1: logicalORExpressionNoIn : logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )* ;
    public JavaScriptParser.logicalORExpressionNoIn_return logicalORExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.logicalORExpressionNoIn_return retval = new JavaScriptParser.logicalORExpressionNoIn_return();
        retval.Start = input.LT(1);
        int logicalORExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT328 = null;
        IToken string_literal329 = null;
        IToken LT330 = null;
        JavaScriptParser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn327 = default(JavaScriptParser.logicalANDExpressionNoIn_return);

        JavaScriptParser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn331 = default(JavaScriptParser.logicalANDExpressionNoIn_return);


        object LT328_tree=null;
        object string_literal329_tree=null;
        object LT330_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 58) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:274:2: ( logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )* )
            // JavaScript.g:274:4: logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn1742);
            	logicalANDExpressionNoIn327 = logicalANDExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpressionNoIn327.Tree, logicalANDExpressionNoIn327, retval);
            	// JavaScript.g:274:29: ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*
            	do 
            	{
            	    int alt162 = 2;
            	    alt162 = dfa162.Predict(input);
            	    switch (alt162) 
            		{
            			case 1 :
            			    // JavaScript.g:274:30: ( LT )* '||' ( LT )* logicalANDExpressionNoIn
            			    {
            			    	// JavaScript.g:274:32: ( LT )*
            			    	do 
            			    	{
            			    	    int alt160 = 2;
            			    	    int LA160_0 = input.LA(1);

            			    	    if ( (LA160_0 == LT) )
            			    	    {
            			    	        alt160 = 1;
            			    	    }


            			    	    switch (alt160) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT328=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpressionNoIn1745), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop160;
            			    	    }
            			    	} while (true);

            			    	loop160:
            			    		;	// Stops C# compiler whining that label 'loop160' has no statements

            			    	string_literal329=(IToken)Match(input,74,FOLLOW_74_in_logicalORExpressionNoIn1749); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal329_tree = (object)adaptor.Create(string_literal329, retval);
            			    		adaptor.AddChild(root_0, string_literal329_tree);
            			    	}
            			    	// JavaScript.g:274:42: ( LT )*
            			    	do 
            			    	{
            			    	    int alt161 = 2;
            			    	    int LA161_0 = input.LA(1);

            			    	    if ( (LA161_0 == LT) )
            			    	    {
            			    	        alt161 = 1;
            			    	    }


            			    	    switch (alt161) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT330=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpressionNoIn1751), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop161;
            			    	    }
            			    	} while (true);

            			    	loop161:
            			    		;	// Stops C# compiler whining that label 'loop161' has no statements

            			    	PushFollow(FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn1755);
            			    	logicalANDExpressionNoIn331 = logicalANDExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpressionNoIn331.Tree, logicalANDExpressionNoIn331, retval);

            			    }
            			    break;

            			default:
            			    goto loop162;
            	    }
            	} while (true);

            	loop162:
            		;	// Stops C# compiler whining that label 'loop162' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 58, logicalORExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logicalORExpressionNoIn"

    public class logicalANDExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalANDExpression"
    // JavaScript.g:277:1: logicalANDExpression : bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )* ;
    public JavaScriptParser.logicalANDExpression_return logicalANDExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.logicalANDExpression_return retval = new JavaScriptParser.logicalANDExpression_return();
        retval.Start = input.LT(1);
        int logicalANDExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT333 = null;
        IToken string_literal334 = null;
        IToken LT335 = null;
        JavaScriptParser.bitwiseORExpression_return bitwiseORExpression332 = default(JavaScriptParser.bitwiseORExpression_return);

        JavaScriptParser.bitwiseORExpression_return bitwiseORExpression336 = default(JavaScriptParser.bitwiseORExpression_return);


        object LT333_tree=null;
        object string_literal334_tree=null;
        object LT335_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 59) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:278:2: ( bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )* )
            // JavaScript.g:278:4: bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseORExpression_in_logicalANDExpression1769);
            	bitwiseORExpression332 = bitwiseORExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpression332.Tree, bitwiseORExpression332, retval);
            	// JavaScript.g:278:24: ( ( LT )* '&&' ( LT )* bitwiseORExpression )*
            	do 
            	{
            	    int alt165 = 2;
            	    alt165 = dfa165.Predict(input);
            	    switch (alt165) 
            		{
            			case 1 :
            			    // JavaScript.g:278:25: ( LT )* '&&' ( LT )* bitwiseORExpression
            			    {
            			    	// JavaScript.g:278:27: ( LT )*
            			    	do 
            			    	{
            			    	    int alt163 = 2;
            			    	    int LA163_0 = input.LA(1);

            			    	    if ( (LA163_0 == LT) )
            			    	    {
            			    	        alt163 = 1;
            			    	    }


            			    	    switch (alt163) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT333=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpression1772), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop163;
            			    	    }
            			    	} while (true);

            			    	loop163:
            			    		;	// Stops C# compiler whining that label 'loop163' has no statements

            			    	string_literal334=(IToken)Match(input,75,FOLLOW_75_in_logicalANDExpression1776); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal334_tree = (object)adaptor.Create(string_literal334, retval);
            			    		adaptor.AddChild(root_0, string_literal334_tree);
            			    	}
            			    	// JavaScript.g:278:37: ( LT )*
            			    	do 
            			    	{
            			    	    int alt164 = 2;
            			    	    int LA164_0 = input.LA(1);

            			    	    if ( (LA164_0 == LT) )
            			    	    {
            			    	        alt164 = 1;
            			    	    }


            			    	    switch (alt164) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT335=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpression1778), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop164;
            			    	    }
            			    	} while (true);

            			    	loop164:
            			    		;	// Stops C# compiler whining that label 'loop164' has no statements

            			    	PushFollow(FOLLOW_bitwiseORExpression_in_logicalANDExpression1782);
            			    	bitwiseORExpression336 = bitwiseORExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpression336.Tree, bitwiseORExpression336, retval);

            			    }
            			    break;

            			default:
            			    goto loop165;
            	    }
            	} while (true);

            	loop165:
            		;	// Stops C# compiler whining that label 'loop165' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 59, logicalANDExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logicalANDExpression"

    public class logicalANDExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalANDExpressionNoIn"
    // JavaScript.g:281:1: logicalANDExpressionNoIn : bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )* ;
    public JavaScriptParser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.logicalANDExpressionNoIn_return retval = new JavaScriptParser.logicalANDExpressionNoIn_return();
        retval.Start = input.LT(1);
        int logicalANDExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT338 = null;
        IToken string_literal339 = null;
        IToken LT340 = null;
        JavaScriptParser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn337 = default(JavaScriptParser.bitwiseORExpressionNoIn_return);

        JavaScriptParser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn341 = default(JavaScriptParser.bitwiseORExpressionNoIn_return);


        object LT338_tree=null;
        object string_literal339_tree=null;
        object LT340_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 60) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:282:2: ( bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )* )
            // JavaScript.g:282:4: bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1796);
            	bitwiseORExpressionNoIn337 = bitwiseORExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpressionNoIn337.Tree, bitwiseORExpressionNoIn337, retval);
            	// JavaScript.g:282:28: ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*
            	do 
            	{
            	    int alt168 = 2;
            	    alt168 = dfa168.Predict(input);
            	    switch (alt168) 
            		{
            			case 1 :
            			    // JavaScript.g:282:29: ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn
            			    {
            			    	// JavaScript.g:282:31: ( LT )*
            			    	do 
            			    	{
            			    	    int alt166 = 2;
            			    	    int LA166_0 = input.LA(1);

            			    	    if ( (LA166_0 == LT) )
            			    	    {
            			    	        alt166 = 1;
            			    	    }


            			    	    switch (alt166) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT338=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpressionNoIn1799), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop166;
            			    	    }
            			    	} while (true);

            			    	loop166:
            			    		;	// Stops C# compiler whining that label 'loop166' has no statements

            			    	string_literal339=(IToken)Match(input,75,FOLLOW_75_in_logicalANDExpressionNoIn1803); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal339_tree = (object)adaptor.Create(string_literal339, retval);
            			    		adaptor.AddChild(root_0, string_literal339_tree);
            			    	}
            			    	// JavaScript.g:282:41: ( LT )*
            			    	do 
            			    	{
            			    	    int alt167 = 2;
            			    	    int LA167_0 = input.LA(1);

            			    	    if ( (LA167_0 == LT) )
            			    	    {
            			    	        alt167 = 1;
            			    	    }


            			    	    switch (alt167) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT340=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpressionNoIn1805), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop167;
            			    	    }
            			    	} while (true);

            			    	loop167:
            			    		;	// Stops C# compiler whining that label 'loop167' has no statements

            			    	PushFollow(FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1809);
            			    	bitwiseORExpressionNoIn341 = bitwiseORExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpressionNoIn341.Tree, bitwiseORExpressionNoIn341, retval);

            			    }
            			    break;

            			default:
            			    goto loop168;
            	    }
            	} while (true);

            	loop168:
            		;	// Stops C# compiler whining that label 'loop168' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 60, logicalANDExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logicalANDExpressionNoIn"

    public class bitwiseORExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseORExpression"
    // JavaScript.g:285:1: bitwiseORExpression : bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )* ;
    public JavaScriptParser.bitwiseORExpression_return bitwiseORExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.bitwiseORExpression_return retval = new JavaScriptParser.bitwiseORExpression_return();
        retval.Start = input.LT(1);
        int bitwiseORExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT343 = null;
        IToken char_literal344 = null;
        IToken LT345 = null;
        JavaScriptParser.bitwiseXORExpression_return bitwiseXORExpression342 = default(JavaScriptParser.bitwiseXORExpression_return);

        JavaScriptParser.bitwiseXORExpression_return bitwiseXORExpression346 = default(JavaScriptParser.bitwiseXORExpression_return);


        object LT343_tree=null;
        object char_literal344_tree=null;
        object LT345_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 61) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:286:2: ( bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )* )
            // JavaScript.g:286:4: bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseXORExpression_in_bitwiseORExpression1823);
            	bitwiseXORExpression342 = bitwiseXORExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpression342.Tree, bitwiseXORExpression342, retval);
            	// JavaScript.g:286:25: ( ( LT )* '|' ( LT )* bitwiseXORExpression )*
            	do 
            	{
            	    int alt171 = 2;
            	    alt171 = dfa171.Predict(input);
            	    switch (alt171) 
            		{
            			case 1 :
            			    // JavaScript.g:286:26: ( LT )* '|' ( LT )* bitwiseXORExpression
            			    {
            			    	// JavaScript.g:286:28: ( LT )*
            			    	do 
            			    	{
            			    	    int alt169 = 2;
            			    	    int LA169_0 = input.LA(1);

            			    	    if ( (LA169_0 == LT) )
            			    	    {
            			    	        alt169 = 1;
            			    	    }


            			    	    switch (alt169) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT343=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpression1826), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop169;
            			    	    }
            			    	} while (true);

            			    	loop169:
            			    		;	// Stops C# compiler whining that label 'loop169' has no statements

            			    	char_literal344=(IToken)Match(input,76,FOLLOW_76_in_bitwiseORExpression1830); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal344_tree = (object)adaptor.Create(char_literal344, retval);
            			    		adaptor.AddChild(root_0, char_literal344_tree);
            			    	}
            			    	// JavaScript.g:286:37: ( LT )*
            			    	do 
            			    	{
            			    	    int alt170 = 2;
            			    	    int LA170_0 = input.LA(1);

            			    	    if ( (LA170_0 == LT) )
            			    	    {
            			    	        alt170 = 1;
            			    	    }


            			    	    switch (alt170) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT345=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpression1832), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop170;
            			    	    }
            			    	} while (true);

            			    	loop170:
            			    		;	// Stops C# compiler whining that label 'loop170' has no statements

            			    	PushFollow(FOLLOW_bitwiseXORExpression_in_bitwiseORExpression1836);
            			    	bitwiseXORExpression346 = bitwiseXORExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpression346.Tree, bitwiseXORExpression346, retval);

            			    }
            			    break;

            			default:
            			    goto loop171;
            	    }
            	} while (true);

            	loop171:
            		;	// Stops C# compiler whining that label 'loop171' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 61, bitwiseORExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "bitwiseORExpression"

    public class bitwiseORExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseORExpressionNoIn"
    // JavaScript.g:289:1: bitwiseORExpressionNoIn : bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )* ;
    public JavaScriptParser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.bitwiseORExpressionNoIn_return retval = new JavaScriptParser.bitwiseORExpressionNoIn_return();
        retval.Start = input.LT(1);
        int bitwiseORExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT348 = null;
        IToken char_literal349 = null;
        IToken LT350 = null;
        JavaScriptParser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn347 = default(JavaScriptParser.bitwiseXORExpressionNoIn_return);

        JavaScriptParser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn351 = default(JavaScriptParser.bitwiseXORExpressionNoIn_return);


        object LT348_tree=null;
        object char_literal349_tree=null;
        object LT350_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 62) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:290:2: ( bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )* )
            // JavaScript.g:290:4: bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1850);
            	bitwiseXORExpressionNoIn347 = bitwiseXORExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpressionNoIn347.Tree, bitwiseXORExpressionNoIn347, retval);
            	// JavaScript.g:290:29: ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*
            	do 
            	{
            	    int alt174 = 2;
            	    alt174 = dfa174.Predict(input);
            	    switch (alt174) 
            		{
            			case 1 :
            			    // JavaScript.g:290:30: ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn
            			    {
            			    	// JavaScript.g:290:32: ( LT )*
            			    	do 
            			    	{
            			    	    int alt172 = 2;
            			    	    int LA172_0 = input.LA(1);

            			    	    if ( (LA172_0 == LT) )
            			    	    {
            			    	        alt172 = 1;
            			    	    }


            			    	    switch (alt172) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT348=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpressionNoIn1853), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop172;
            			    	    }
            			    	} while (true);

            			    	loop172:
            			    		;	// Stops C# compiler whining that label 'loop172' has no statements

            			    	char_literal349=(IToken)Match(input,76,FOLLOW_76_in_bitwiseORExpressionNoIn1857); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal349_tree = (object)adaptor.Create(char_literal349, retval);
            			    		adaptor.AddChild(root_0, char_literal349_tree);
            			    	}
            			    	// JavaScript.g:290:41: ( LT )*
            			    	do 
            			    	{
            			    	    int alt173 = 2;
            			    	    int LA173_0 = input.LA(1);

            			    	    if ( (LA173_0 == LT) )
            			    	    {
            			    	        alt173 = 1;
            			    	    }


            			    	    switch (alt173) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT350=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpressionNoIn1859), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop173;
            			    	    }
            			    	} while (true);

            			    	loop173:
            			    		;	// Stops C# compiler whining that label 'loop173' has no statements

            			    	PushFollow(FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1863);
            			    	bitwiseXORExpressionNoIn351 = bitwiseXORExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpressionNoIn351.Tree, bitwiseXORExpressionNoIn351, retval);

            			    }
            			    break;

            			default:
            			    goto loop174;
            	    }
            	} while (true);

            	loop174:
            		;	// Stops C# compiler whining that label 'loop174' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 62, bitwiseORExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "bitwiseORExpressionNoIn"

    public class bitwiseXORExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseXORExpression"
    // JavaScript.g:293:1: bitwiseXORExpression : bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )* ;
    public JavaScriptParser.bitwiseXORExpression_return bitwiseXORExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.bitwiseXORExpression_return retval = new JavaScriptParser.bitwiseXORExpression_return();
        retval.Start = input.LT(1);
        int bitwiseXORExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT353 = null;
        IToken char_literal354 = null;
        IToken LT355 = null;
        JavaScriptParser.bitwiseANDExpression_return bitwiseANDExpression352 = default(JavaScriptParser.bitwiseANDExpression_return);

        JavaScriptParser.bitwiseANDExpression_return bitwiseANDExpression356 = default(JavaScriptParser.bitwiseANDExpression_return);


        object LT353_tree=null;
        object char_literal354_tree=null;
        object LT355_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 63) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:294:2: ( bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )* )
            // JavaScript.g:294:4: bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression1877);
            	bitwiseANDExpression352 = bitwiseANDExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpression352.Tree, bitwiseANDExpression352, retval);
            	// JavaScript.g:294:25: ( ( LT )* '^' ( LT )* bitwiseANDExpression )*
            	do 
            	{
            	    int alt177 = 2;
            	    alt177 = dfa177.Predict(input);
            	    switch (alt177) 
            		{
            			case 1 :
            			    // JavaScript.g:294:26: ( LT )* '^' ( LT )* bitwiseANDExpression
            			    {
            			    	// JavaScript.g:294:28: ( LT )*
            			    	do 
            			    	{
            			    	    int alt175 = 2;
            			    	    int LA175_0 = input.LA(1);

            			    	    if ( (LA175_0 == LT) )
            			    	    {
            			    	        alt175 = 1;
            			    	    }


            			    	    switch (alt175) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT353=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpression1880), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop175;
            			    	    }
            			    	} while (true);

            			    	loop175:
            			    		;	// Stops C# compiler whining that label 'loop175' has no statements

            			    	char_literal354=(IToken)Match(input,77,FOLLOW_77_in_bitwiseXORExpression1884); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal354_tree = (object)adaptor.Create(char_literal354, retval);
            			    		adaptor.AddChild(root_0, char_literal354_tree);
            			    	}
            			    	// JavaScript.g:294:37: ( LT )*
            			    	do 
            			    	{
            			    	    int alt176 = 2;
            			    	    int LA176_0 = input.LA(1);

            			    	    if ( (LA176_0 == LT) )
            			    	    {
            			    	        alt176 = 1;
            			    	    }


            			    	    switch (alt176) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT355=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpression1886), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop176;
            			    	    }
            			    	} while (true);

            			    	loop176:
            			    		;	// Stops C# compiler whining that label 'loop176' has no statements

            			    	PushFollow(FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression1890);
            			    	bitwiseANDExpression356 = bitwiseANDExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpression356.Tree, bitwiseANDExpression356, retval);

            			    }
            			    break;

            			default:
            			    goto loop177;
            	    }
            	} while (true);

            	loop177:
            		;	// Stops C# compiler whining that label 'loop177' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 63, bitwiseXORExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "bitwiseXORExpression"

    public class bitwiseXORExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseXORExpressionNoIn"
    // JavaScript.g:297:1: bitwiseXORExpressionNoIn : bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )* ;
    public JavaScriptParser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.bitwiseXORExpressionNoIn_return retval = new JavaScriptParser.bitwiseXORExpressionNoIn_return();
        retval.Start = input.LT(1);
        int bitwiseXORExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT358 = null;
        IToken char_literal359 = null;
        IToken LT360 = null;
        JavaScriptParser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn357 = default(JavaScriptParser.bitwiseANDExpressionNoIn_return);

        JavaScriptParser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn361 = default(JavaScriptParser.bitwiseANDExpressionNoIn_return);


        object LT358_tree=null;
        object char_literal359_tree=null;
        object LT360_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 64) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:298:2: ( bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )* )
            // JavaScript.g:298:4: bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1904);
            	bitwiseANDExpressionNoIn357 = bitwiseANDExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpressionNoIn357.Tree, bitwiseANDExpressionNoIn357, retval);
            	// JavaScript.g:298:29: ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*
            	do 
            	{
            	    int alt180 = 2;
            	    alt180 = dfa180.Predict(input);
            	    switch (alt180) 
            		{
            			case 1 :
            			    // JavaScript.g:298:30: ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn
            			    {
            			    	// JavaScript.g:298:32: ( LT )*
            			    	do 
            			    	{
            			    	    int alt178 = 2;
            			    	    int LA178_0 = input.LA(1);

            			    	    if ( (LA178_0 == LT) )
            			    	    {
            			    	        alt178 = 1;
            			    	    }


            			    	    switch (alt178) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT358=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpressionNoIn1907), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop178;
            			    	    }
            			    	} while (true);

            			    	loop178:
            			    		;	// Stops C# compiler whining that label 'loop178' has no statements

            			    	char_literal359=(IToken)Match(input,77,FOLLOW_77_in_bitwiseXORExpressionNoIn1911); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal359_tree = (object)adaptor.Create(char_literal359, retval);
            			    		adaptor.AddChild(root_0, char_literal359_tree);
            			    	}
            			    	// JavaScript.g:298:41: ( LT )*
            			    	do 
            			    	{
            			    	    int alt179 = 2;
            			    	    int LA179_0 = input.LA(1);

            			    	    if ( (LA179_0 == LT) )
            			    	    {
            			    	        alt179 = 1;
            			    	    }


            			    	    switch (alt179) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT360=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpressionNoIn1913), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop179;
            			    	    }
            			    	} while (true);

            			    	loop179:
            			    		;	// Stops C# compiler whining that label 'loop179' has no statements

            			    	PushFollow(FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1917);
            			    	bitwiseANDExpressionNoIn361 = bitwiseANDExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpressionNoIn361.Tree, bitwiseANDExpressionNoIn361, retval);

            			    }
            			    break;

            			default:
            			    goto loop180;
            	    }
            	} while (true);

            	loop180:
            		;	// Stops C# compiler whining that label 'loop180' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 64, bitwiseXORExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "bitwiseXORExpressionNoIn"

    public class bitwiseANDExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseANDExpression"
    // JavaScript.g:301:1: bitwiseANDExpression : equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )* ;
    public JavaScriptParser.bitwiseANDExpression_return bitwiseANDExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.bitwiseANDExpression_return retval = new JavaScriptParser.bitwiseANDExpression_return();
        retval.Start = input.LT(1);
        int bitwiseANDExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT363 = null;
        IToken char_literal364 = null;
        IToken LT365 = null;
        JavaScriptParser.equalityExpression_return equalityExpression362 = default(JavaScriptParser.equalityExpression_return);

        JavaScriptParser.equalityExpression_return equalityExpression366 = default(JavaScriptParser.equalityExpression_return);


        object LT363_tree=null;
        object char_literal364_tree=null;
        object LT365_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 65) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:302:2: ( equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )* )
            // JavaScript.g:302:4: equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_equalityExpression_in_bitwiseANDExpression1931);
            	equalityExpression362 = equalityExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression362.Tree, equalityExpression362, retval);
            	// JavaScript.g:302:23: ( ( LT )* '&' ( LT )* equalityExpression )*
            	do 
            	{
            	    int alt183 = 2;
            	    alt183 = dfa183.Predict(input);
            	    switch (alt183) 
            		{
            			case 1 :
            			    // JavaScript.g:302:24: ( LT )* '&' ( LT )* equalityExpression
            			    {
            			    	// JavaScript.g:302:26: ( LT )*
            			    	do 
            			    	{
            			    	    int alt181 = 2;
            			    	    int LA181_0 = input.LA(1);

            			    	    if ( (LA181_0 == LT) )
            			    	    {
            			    	        alt181 = 1;
            			    	    }


            			    	    switch (alt181) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT363=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpression1934), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop181;
            			    	    }
            			    	} while (true);

            			    	loop181:
            			    		;	// Stops C# compiler whining that label 'loop181' has no statements

            			    	char_literal364=(IToken)Match(input,78,FOLLOW_78_in_bitwiseANDExpression1938); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal364_tree = (object)adaptor.Create(char_literal364, retval);
            			    		adaptor.AddChild(root_0, char_literal364_tree);
            			    	}
            			    	// JavaScript.g:302:35: ( LT )*
            			    	do 
            			    	{
            			    	    int alt182 = 2;
            			    	    int LA182_0 = input.LA(1);

            			    	    if ( (LA182_0 == LT) )
            			    	    {
            			    	        alt182 = 1;
            			    	    }


            			    	    switch (alt182) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT365=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpression1940), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop182;
            			    	    }
            			    	} while (true);

            			    	loop182:
            			    		;	// Stops C# compiler whining that label 'loop182' has no statements

            			    	PushFollow(FOLLOW_equalityExpression_in_bitwiseANDExpression1944);
            			    	equalityExpression366 = equalityExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression366.Tree, equalityExpression366, retval);

            			    }
            			    break;

            			default:
            			    goto loop183;
            	    }
            	} while (true);

            	loop183:
            		;	// Stops C# compiler whining that label 'loop183' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 65, bitwiseANDExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "bitwiseANDExpression"

    public class bitwiseANDExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseANDExpressionNoIn"
    // JavaScript.g:305:1: bitwiseANDExpressionNoIn : equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )* ;
    public JavaScriptParser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.bitwiseANDExpressionNoIn_return retval = new JavaScriptParser.bitwiseANDExpressionNoIn_return();
        retval.Start = input.LT(1);
        int bitwiseANDExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT368 = null;
        IToken char_literal369 = null;
        IToken LT370 = null;
        JavaScriptParser.equalityExpressionNoIn_return equalityExpressionNoIn367 = default(JavaScriptParser.equalityExpressionNoIn_return);

        JavaScriptParser.equalityExpressionNoIn_return equalityExpressionNoIn371 = default(JavaScriptParser.equalityExpressionNoIn_return);


        object LT368_tree=null;
        object char_literal369_tree=null;
        object LT370_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 66) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:306:2: ( equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )* )
            // JavaScript.g:306:4: equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn1958);
            	equalityExpressionNoIn367 = equalityExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpressionNoIn367.Tree, equalityExpressionNoIn367, retval);
            	// JavaScript.g:306:27: ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*
            	do 
            	{
            	    int alt186 = 2;
            	    alt186 = dfa186.Predict(input);
            	    switch (alt186) 
            		{
            			case 1 :
            			    // JavaScript.g:306:28: ( LT )* '&' ( LT )* equalityExpressionNoIn
            			    {
            			    	// JavaScript.g:306:30: ( LT )*
            			    	do 
            			    	{
            			    	    int alt184 = 2;
            			    	    int LA184_0 = input.LA(1);

            			    	    if ( (LA184_0 == LT) )
            			    	    {
            			    	        alt184 = 1;
            			    	    }


            			    	    switch (alt184) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT368=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpressionNoIn1961), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop184;
            			    	    }
            			    	} while (true);

            			    	loop184:
            			    		;	// Stops C# compiler whining that label 'loop184' has no statements

            			    	char_literal369=(IToken)Match(input,78,FOLLOW_78_in_bitwiseANDExpressionNoIn1965); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal369_tree = (object)adaptor.Create(char_literal369, retval);
            			    		adaptor.AddChild(root_0, char_literal369_tree);
            			    	}
            			    	// JavaScript.g:306:39: ( LT )*
            			    	do 
            			    	{
            			    	    int alt185 = 2;
            			    	    int LA185_0 = input.LA(1);

            			    	    if ( (LA185_0 == LT) )
            			    	    {
            			    	        alt185 = 1;
            			    	    }


            			    	    switch (alt185) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT370=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpressionNoIn1967), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop185;
            			    	    }
            			    	} while (true);

            			    	loop185:
            			    		;	// Stops C# compiler whining that label 'loop185' has no statements

            			    	PushFollow(FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn1971);
            			    	equalityExpressionNoIn371 = equalityExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpressionNoIn371.Tree, equalityExpressionNoIn371, retval);

            			    }
            			    break;

            			default:
            			    goto loop186;
            	    }
            	} while (true);

            	loop186:
            		;	// Stops C# compiler whining that label 'loop186' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 66, bitwiseANDExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "bitwiseANDExpressionNoIn"

    public class equalityExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "equalityExpression"
    // JavaScript.g:309:1: equalityExpression : relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )* ;
    public JavaScriptParser.equalityExpression_return equalityExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.equalityExpression_return retval = new JavaScriptParser.equalityExpression_return();
        retval.Start = input.LT(1);
        int equalityExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT373 = null;
        IToken set374 = null;
        IToken LT375 = null;
        JavaScriptParser.relationalExpression_return relationalExpression372 = default(JavaScriptParser.relationalExpression_return);

        JavaScriptParser.relationalExpression_return relationalExpression376 = default(JavaScriptParser.relationalExpression_return);


        object LT373_tree=null;
        object set374_tree=null;
        object LT375_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 67) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:310:2: ( relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )* )
            // JavaScript.g:310:4: relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_relationalExpression_in_equalityExpression1985);
            	relationalExpression372 = relationalExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpression372.Tree, relationalExpression372, retval);
            	// JavaScript.g:310:25: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*
            	do 
            	{
            	    int alt189 = 2;
            	    alt189 = dfa189.Predict(input);
            	    switch (alt189) 
            		{
            			case 1 :
            			    // JavaScript.g:310:26: ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression
            			    {
            			    	// JavaScript.g:310:28: ( LT )*
            			    	do 
            			    	{
            			    	    int alt187 = 2;
            			    	    int LA187_0 = input.LA(1);

            			    	    if ( (LA187_0 == LT) )
            			    	    {
            			    	        alt187 = 1;
            			    	    }


            			    	    switch (alt187) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT373=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_equalityExpression1988), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop187;
            			    	    }
            			    	} while (true);

            			    	loop187:
            			    		;	// Stops C# compiler whining that label 'loop187' has no statements

            			    	set374 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 79 && input.LA(1) <= 82) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set374, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:310:63: ( LT )*
            			    	do 
            			    	{
            			    	    int alt188 = 2;
            			    	    int LA188_0 = input.LA(1);

            			    	    if ( (LA188_0 == LT) )
            			    	    {
            			    	        alt188 = 1;
            			    	    }


            			    	    switch (alt188) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT375=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_equalityExpression2008), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop188;
            			    	    }
            			    	} while (true);

            			    	loop188:
            			    		;	// Stops C# compiler whining that label 'loop188' has no statements

            			    	PushFollow(FOLLOW_relationalExpression_in_equalityExpression2012);
            			    	relationalExpression376 = relationalExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpression376.Tree, relationalExpression376, retval);

            			    }
            			    break;

            			default:
            			    goto loop189;
            	    }
            	} while (true);

            	loop189:
            		;	// Stops C# compiler whining that label 'loop189' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 67, equalityExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "equalityExpression"

    public class equalityExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "equalityExpressionNoIn"
    // JavaScript.g:313:1: equalityExpressionNoIn : relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )* ;
    public JavaScriptParser.equalityExpressionNoIn_return equalityExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.equalityExpressionNoIn_return retval = new JavaScriptParser.equalityExpressionNoIn_return();
        retval.Start = input.LT(1);
        int equalityExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT378 = null;
        IToken set379 = null;
        IToken LT380 = null;
        JavaScriptParser.relationalExpressionNoIn_return relationalExpressionNoIn377 = default(JavaScriptParser.relationalExpressionNoIn_return);

        JavaScriptParser.relationalExpressionNoIn_return relationalExpressionNoIn381 = default(JavaScriptParser.relationalExpressionNoIn_return);


        object LT378_tree=null;
        object set379_tree=null;
        object LT380_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 68) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:314:2: ( relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )* )
            // JavaScript.g:314:4: relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2025);
            	relationalExpressionNoIn377 = relationalExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpressionNoIn377.Tree, relationalExpressionNoIn377, retval);
            	// JavaScript.g:314:29: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*
            	do 
            	{
            	    int alt192 = 2;
            	    alt192 = dfa192.Predict(input);
            	    switch (alt192) 
            		{
            			case 1 :
            			    // JavaScript.g:314:30: ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn
            			    {
            			    	// JavaScript.g:314:32: ( LT )*
            			    	do 
            			    	{
            			    	    int alt190 = 2;
            			    	    int LA190_0 = input.LA(1);

            			    	    if ( (LA190_0 == LT) )
            			    	    {
            			    	        alt190 = 1;
            			    	    }


            			    	    switch (alt190) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT378=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_equalityExpressionNoIn2028), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop190;
            			    	    }
            			    	} while (true);

            			    	loop190:
            			    		;	// Stops C# compiler whining that label 'loop190' has no statements

            			    	set379 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 79 && input.LA(1) <= 82) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set379, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:314:67: ( LT )*
            			    	do 
            			    	{
            			    	    int alt191 = 2;
            			    	    int LA191_0 = input.LA(1);

            			    	    if ( (LA191_0 == LT) )
            			    	    {
            			    	        alt191 = 1;
            			    	    }


            			    	    switch (alt191) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT380=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_equalityExpressionNoIn2048), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop191;
            			    	    }
            			    	} while (true);

            			    	loop191:
            			    		;	// Stops C# compiler whining that label 'loop191' has no statements

            			    	PushFollow(FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2052);
            			    	relationalExpressionNoIn381 = relationalExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpressionNoIn381.Tree, relationalExpressionNoIn381, retval);

            			    }
            			    break;

            			default:
            			    goto loop192;
            	    }
            	} while (true);

            	loop192:
            		;	// Stops C# compiler whining that label 'loop192' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 68, equalityExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "equalityExpressionNoIn"

    public class relationalExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "relationalExpression"
    // JavaScript.g:317:1: relationalExpression : shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )* ;
    public JavaScriptParser.relationalExpression_return relationalExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.relationalExpression_return retval = new JavaScriptParser.relationalExpression_return();
        retval.Start = input.LT(1);
        int relationalExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT383 = null;
        IToken set384 = null;
        IToken LT385 = null;
        JavaScriptParser.shiftExpression_return shiftExpression382 = default(JavaScriptParser.shiftExpression_return);

        JavaScriptParser.shiftExpression_return shiftExpression386 = default(JavaScriptParser.shiftExpression_return);


        object LT383_tree=null;
        object set384_tree=null;
        object LT385_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 69) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:318:2: ( shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )* )
            // JavaScript.g:318:4: shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_shiftExpression_in_relationalExpression2066);
            	shiftExpression382 = shiftExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression382.Tree, shiftExpression382, retval);
            	// JavaScript.g:318:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*
            	do 
            	{
            	    int alt195 = 2;
            	    alt195 = dfa195.Predict(input);
            	    switch (alt195) 
            		{
            			case 1 :
            			    // JavaScript.g:318:21: ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression
            			    {
            			    	// JavaScript.g:318:23: ( LT )*
            			    	do 
            			    	{
            			    	    int alt193 = 2;
            			    	    int LA193_0 = input.LA(1);

            			    	    if ( (LA193_0 == LT) )
            			    	    {
            			    	        alt193 = 1;
            			    	    }


            			    	    switch (alt193) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT383=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_relationalExpression2069), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop193;
            			    	    }
            			    	} while (true);

            			    	loop193:
            			    		;	// Stops C# compiler whining that label 'loop193' has no statements

            			    	set384 = (IToken)input.LT(1);
            			    	if ( input.LA(1) == 45 || (input.LA(1) >= 83 && input.LA(1) <= 87) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set384, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:318:76: ( LT )*
            			    	do 
            			    	{
            			    	    int alt194 = 2;
            			    	    int LA194_0 = input.LA(1);

            			    	    if ( (LA194_0 == LT) )
            			    	    {
            			    	        alt194 = 1;
            			    	    }


            			    	    switch (alt194) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT385=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_relationalExpression2097), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop194;
            			    	    }
            			    	} while (true);

            			    	loop194:
            			    		;	// Stops C# compiler whining that label 'loop194' has no statements

            			    	PushFollow(FOLLOW_shiftExpression_in_relationalExpression2101);
            			    	shiftExpression386 = shiftExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression386.Tree, shiftExpression386, retval);

            			    }
            			    break;

            			default:
            			    goto loop195;
            	    }
            	} while (true);

            	loop195:
            		;	// Stops C# compiler whining that label 'loop195' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 69, relationalExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "relationalExpression"

    public class relationalExpressionNoIn_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "relationalExpressionNoIn"
    // JavaScript.g:321:1: relationalExpressionNoIn : shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )* ;
    public JavaScriptParser.relationalExpressionNoIn_return relationalExpressionNoIn() // throws RecognitionException [1]
    {   
        JavaScriptParser.relationalExpressionNoIn_return retval = new JavaScriptParser.relationalExpressionNoIn_return();
        retval.Start = input.LT(1);
        int relationalExpressionNoIn_StartIndex = input.Index();
        object root_0 = null;

        IToken LT388 = null;
        IToken set389 = null;
        IToken LT390 = null;
        JavaScriptParser.shiftExpression_return shiftExpression387 = default(JavaScriptParser.shiftExpression_return);

        JavaScriptParser.shiftExpression_return shiftExpression391 = default(JavaScriptParser.shiftExpression_return);


        object LT388_tree=null;
        object set389_tree=null;
        object LT390_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 70) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:322:2: ( shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )* )
            // JavaScript.g:322:4: shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_shiftExpression_in_relationalExpressionNoIn2114);
            	shiftExpression387 = shiftExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression387.Tree, shiftExpression387, retval);
            	// JavaScript.g:322:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*
            	do 
            	{
            	    int alt198 = 2;
            	    alt198 = dfa198.Predict(input);
            	    switch (alt198) 
            		{
            			case 1 :
            			    // JavaScript.g:322:21: ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression
            			    {
            			    	// JavaScript.g:322:23: ( LT )*
            			    	do 
            			    	{
            			    	    int alt196 = 2;
            			    	    int LA196_0 = input.LA(1);

            			    	    if ( (LA196_0 == LT) )
            			    	    {
            			    	        alt196 = 1;
            			    	    }


            			    	    switch (alt196) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT388=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_relationalExpressionNoIn2117), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop196;
            			    	    }
            			    	} while (true);

            			    	loop196:
            			    		;	// Stops C# compiler whining that label 'loop196' has no statements

            			    	set389 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 83 && input.LA(1) <= 87) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set389, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:322:69: ( LT )*
            			    	do 
            			    	{
            			    	    int alt197 = 2;
            			    	    int LA197_0 = input.LA(1);

            			    	    if ( (LA197_0 == LT) )
            			    	    {
            			    	        alt197 = 1;
            			    	    }


            			    	    switch (alt197) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT390=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_relationalExpressionNoIn2141), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop197;
            			    	    }
            			    	} while (true);

            			    	loop197:
            			    		;	// Stops C# compiler whining that label 'loop197' has no statements

            			    	PushFollow(FOLLOW_shiftExpression_in_relationalExpressionNoIn2145);
            			    	shiftExpression391 = shiftExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression391.Tree, shiftExpression391, retval);

            			    }
            			    break;

            			default:
            			    goto loop198;
            	    }
            	} while (true);

            	loop198:
            		;	// Stops C# compiler whining that label 'loop198' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 70, relationalExpressionNoIn_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "relationalExpressionNoIn"

    public class shiftExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "shiftExpression"
    // JavaScript.g:325:1: shiftExpression : additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )* ;
    public JavaScriptParser.shiftExpression_return shiftExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.shiftExpression_return retval = new JavaScriptParser.shiftExpression_return();
        retval.Start = input.LT(1);
        int shiftExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT393 = null;
        IToken set394 = null;
        IToken LT395 = null;
        JavaScriptParser.additiveExpression_return additiveExpression392 = default(JavaScriptParser.additiveExpression_return);

        JavaScriptParser.additiveExpression_return additiveExpression396 = default(JavaScriptParser.additiveExpression_return);


        object LT393_tree=null;
        object set394_tree=null;
        object LT395_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 71) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:326:2: ( additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )* )
            // JavaScript.g:326:4: additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_additiveExpression_in_shiftExpression2158);
            	additiveExpression392 = additiveExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression392.Tree, additiveExpression392, retval);
            	// JavaScript.g:326:23: ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*
            	do 
            	{
            	    int alt201 = 2;
            	    alt201 = dfa201.Predict(input);
            	    switch (alt201) 
            		{
            			case 1 :
            			    // JavaScript.g:326:24: ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression
            			    {
            			    	// JavaScript.g:326:26: ( LT )*
            			    	do 
            			    	{
            			    	    int alt199 = 2;
            			    	    int LA199_0 = input.LA(1);

            			    	    if ( (LA199_0 == LT) )
            			    	    {
            			    	        alt199 = 1;
            			    	    }


            			    	    switch (alt199) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT393=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_shiftExpression2161), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop199;
            			    	    }
            			    	} while (true);

            			    	loop199:
            			    		;	// Stops C# compiler whining that label 'loop199' has no statements

            			    	set394 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 88 && input.LA(1) <= 90) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set394, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:326:53: ( LT )*
            			    	do 
            			    	{
            			    	    int alt200 = 2;
            			    	    int LA200_0 = input.LA(1);

            			    	    if ( (LA200_0 == LT) )
            			    	    {
            			    	        alt200 = 1;
            			    	    }


            			    	    switch (alt200) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT395=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_shiftExpression2177), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop200;
            			    	    }
            			    	} while (true);

            			    	loop200:
            			    		;	// Stops C# compiler whining that label 'loop200' has no statements

            			    	PushFollow(FOLLOW_additiveExpression_in_shiftExpression2181);
            			    	additiveExpression396 = additiveExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression396.Tree, additiveExpression396, retval);

            			    }
            			    break;

            			default:
            			    goto loop201;
            	    }
            	} while (true);

            	loop201:
            		;	// Stops C# compiler whining that label 'loop201' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 71, shiftExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "shiftExpression"

    public class additiveExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "additiveExpression"
    // JavaScript.g:329:1: additiveExpression : multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )* ;
    public JavaScriptParser.additiveExpression_return additiveExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.additiveExpression_return retval = new JavaScriptParser.additiveExpression_return();
        retval.Start = input.LT(1);
        int additiveExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT398 = null;
        IToken set399 = null;
        IToken LT400 = null;
        JavaScriptParser.multiplicativeExpression_return multiplicativeExpression397 = default(JavaScriptParser.multiplicativeExpression_return);

        JavaScriptParser.multiplicativeExpression_return multiplicativeExpression401 = default(JavaScriptParser.multiplicativeExpression_return);


        object LT398_tree=null;
        object set399_tree=null;
        object LT400_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 72) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:330:2: ( multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )* )
            // JavaScript.g:330:4: multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression2194);
            	multiplicativeExpression397 = multiplicativeExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression397.Tree, multiplicativeExpression397, retval);
            	// JavaScript.g:330:29: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*
            	do 
            	{
            	    int alt204 = 2;
            	    alt204 = dfa204.Predict(input);
            	    switch (alt204) 
            		{
            			case 1 :
            			    // JavaScript.g:330:30: ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression
            			    {
            			    	// JavaScript.g:330:32: ( LT )*
            			    	do 
            			    	{
            			    	    int alt202 = 2;
            			    	    int LA202_0 = input.LA(1);

            			    	    if ( (LA202_0 == LT) )
            			    	    {
            			    	        alt202 = 1;
            			    	    }


            			    	    switch (alt202) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT398=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_additiveExpression2197), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop202;
            			    	    }
            			    	} while (true);

            			    	loop202:
            			    		;	// Stops C# compiler whining that label 'loop202' has no statements

            			    	set399 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 91 && input.LA(1) <= 92) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set399, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:330:49: ( LT )*
            			    	do 
            			    	{
            			    	    int alt203 = 2;
            			    	    int LA203_0 = input.LA(1);

            			    	    if ( (LA203_0 == LT) )
            			    	    {
            			    	        alt203 = 1;
            			    	    }


            			    	    switch (alt203) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT400=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_additiveExpression2209), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop203;
            			    	    }
            			    	} while (true);

            			    	loop203:
            			    		;	// Stops C# compiler whining that label 'loop203' has no statements

            			    	PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression2213);
            			    	multiplicativeExpression401 = multiplicativeExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression401.Tree, multiplicativeExpression401, retval);

            			    }
            			    break;

            			default:
            			    goto loop204;
            	    }
            	} while (true);

            	loop204:
            		;	// Stops C# compiler whining that label 'loop204' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 72, additiveExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "additiveExpression"

    public class multiplicativeExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "multiplicativeExpression"
    // JavaScript.g:333:1: multiplicativeExpression : unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )* ;
    public JavaScriptParser.multiplicativeExpression_return multiplicativeExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.multiplicativeExpression_return retval = new JavaScriptParser.multiplicativeExpression_return();
        retval.Start = input.LT(1);
        int multiplicativeExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken LT403 = null;
        IToken set404 = null;
        IToken LT405 = null;
        JavaScriptParser.unaryExpression_return unaryExpression402 = default(JavaScriptParser.unaryExpression_return);

        JavaScriptParser.unaryExpression_return unaryExpression406 = default(JavaScriptParser.unaryExpression_return);


        object LT403_tree=null;
        object set404_tree=null;
        object LT405_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 73) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:334:2: ( unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )* )
            // JavaScript.g:334:4: unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression2226);
            	unaryExpression402 = unaryExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression402.Tree, unaryExpression402, retval);
            	// JavaScript.g:334:20: ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*
            	do 
            	{
            	    int alt207 = 2;
            	    alt207 = dfa207.Predict(input);
            	    switch (alt207) 
            		{
            			case 1 :
            			    // JavaScript.g:334:21: ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression
            			    {
            			    	// JavaScript.g:334:23: ( LT )*
            			    	do 
            			    	{
            			    	    int alt205 = 2;
            			    	    int LA205_0 = input.LA(1);

            			    	    if ( (LA205_0 == LT) )
            			    	    {
            			    	        alt205 = 1;
            			    	    }


            			    	    switch (alt205) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT403=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_multiplicativeExpression2229), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop205;
            			    	    }
            			    	} while (true);

            			    	loop205:
            			    		;	// Stops C# compiler whining that label 'loop205' has no statements

            			    	set404 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 93 && input.LA(1) <= 95) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set404, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:334:46: ( LT )*
            			    	do 
            			    	{
            			    	    int alt206 = 2;
            			    	    int LA206_0 = input.LA(1);

            			    	    if ( (LA206_0 == LT) )
            			    	    {
            			    	        alt206 = 1;
            			    	    }


            			    	    switch (alt206) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT405=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_multiplicativeExpression2245), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop206;
            			    	    }
            			    	} while (true);

            			    	loop206:
            			    		;	// Stops C# compiler whining that label 'loop206' has no statements

            			    	PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression2249);
            			    	unaryExpression406 = unaryExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression406.Tree, unaryExpression406, retval);

            			    }
            			    break;

            			default:
            			    goto loop207;
            	    }
            	} while (true);

            	loop207:
            		;	// Stops C# compiler whining that label 'loop207' has no statements


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 73, multiplicativeExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "multiplicativeExpression"

    public class unaryExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "unaryExpression"
    // JavaScript.g:337:1: unaryExpression : ( postfixExpression | ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression );
    public JavaScriptParser.unaryExpression_return unaryExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.unaryExpression_return retval = new JavaScriptParser.unaryExpression_return();
        retval.Start = input.LT(1);
        int unaryExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken set408 = null;
        JavaScriptParser.postfixExpression_return postfixExpression407 = default(JavaScriptParser.postfixExpression_return);

        JavaScriptParser.unaryExpression_return unaryExpression409 = default(JavaScriptParser.unaryExpression_return);


        object set408_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 74) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:338:2: ( postfixExpression | ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression )
            int alt208 = 2;
            int LA208_0 = input.LA(1);

            if ( ((LA208_0 >= Identifier && LA208_0 <= NumericLiteral) || (LA208_0 >= 31 && LA208_0 <= 32) || LA208_0 == 35 || (LA208_0 >= 58 && LA208_0 <= 59) || (LA208_0 >= 103 && LA208_0 <= 106)) )
            {
                alt208 = 1;
            }
            else if ( ((LA208_0 >= 91 && LA208_0 <= 92) || (LA208_0 >= 96 && LA208_0 <= 102)) )
            {
                alt208 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d208s0 =
                    new NoViableAltException("", 208, 0, input);

                throw nvae_d208s0;
            }
            switch (alt208) 
            {
                case 1 :
                    // JavaScript.g:338:4: postfixExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_postfixExpression_in_unaryExpression2262);
                    	postfixExpression407 = postfixExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, postfixExpression407.Tree, postfixExpression407, retval);

                    }
                    break;
                case 2 :
                    // JavaScript.g:339:4: ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set408 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 91 && input.LA(1) <= 92) || (input.LA(1) >= 96 && input.LA(1) <= 102) ) 
                    	{
                    	    input.Consume();
                    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set408, retval));
                    	    state.errorRecovery = false;state.failed = false;
                    	}
                    	else 
                    	{
                    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	PushFollow(FOLLOW_unaryExpression_in_unaryExpression2303);
                    	unaryExpression409 = unaryExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression409.Tree, unaryExpression409, retval);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 74, unaryExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "unaryExpression"

    public class postfixExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "postfixExpression"
    // JavaScript.g:342:1: postfixExpression : leftHandSideExpression ( '++' | '--' )? ;
    public JavaScriptParser.postfixExpression_return postfixExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.postfixExpression_return retval = new JavaScriptParser.postfixExpression_return();
        retval.Start = input.LT(1);
        int postfixExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken set411 = null;
        JavaScriptParser.leftHandSideExpression_return leftHandSideExpression410 = default(JavaScriptParser.leftHandSideExpression_return);


        object set411_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 75) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:343:2: ( leftHandSideExpression ( '++' | '--' )? )
            // JavaScript.g:343:4: leftHandSideExpression ( '++' | '--' )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_leftHandSideExpression_in_postfixExpression2315);
            	leftHandSideExpression410 = leftHandSideExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression410.Tree, leftHandSideExpression410, retval);
            	// JavaScript.g:343:27: ( '++' | '--' )?
            	int alt209 = 2;
            	int LA209_0 = input.LA(1);

            	if ( ((LA209_0 >= 99 && LA209_0 <= 100)) )
            	{
            	    alt209 = 1;
            	}
            	switch (alt209) 
            	{
            	    case 1 :
            	        // JavaScript.g:
            	        {
            	        	set411 = (IToken)input.LT(1);
            	        	if ( (input.LA(1) >= 99 && input.LA(1) <= 100) ) 
            	        	{
            	        	    input.Consume();
            	        	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set411, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 75, postfixExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "postfixExpression"

    public class primaryExpression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "primaryExpression"
    // JavaScript.g:346:1: primaryExpression : ( 'this' | Identifier | literal | arrayLiteral | objectLiteral | '(' ( LT )* expression ( LT )* ')' );
    public JavaScriptParser.primaryExpression_return primaryExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.primaryExpression_return retval = new JavaScriptParser.primaryExpression_return();
        retval.Start = input.LT(1);
        int primaryExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal412 = null;
        IToken Identifier413 = null;
        IToken char_literal417 = null;
        IToken LT418 = null;
        IToken LT420 = null;
        IToken char_literal421 = null;
        JavaScriptParser.literal_return literal414 = default(JavaScriptParser.literal_return);

        JavaScriptParser.arrayLiteral_return arrayLiteral415 = default(JavaScriptParser.arrayLiteral_return);

        JavaScriptParser.objectLiteral_return objectLiteral416 = default(JavaScriptParser.objectLiteral_return);

        JavaScriptParser.expression_return expression419 = default(JavaScriptParser.expression_return);


        object string_literal412_tree=null;
        object Identifier413_tree=null;
        object char_literal417_tree=null;
        object LT418_tree=null;
        object LT420_tree=null;
        object char_literal421_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 76) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:347:2: ( 'this' | Identifier | literal | arrayLiteral | objectLiteral | '(' ( LT )* expression ( LT )* ')' )
            int alt212 = 6;
            switch ( input.LA(1) ) 
            {
            case 103:
            	{
                alt212 = 1;
                }
                break;
            case Identifier:
            	{
                alt212 = 2;
                }
                break;
            case StringLiteral:
            case NumericLiteral:
            case 104:
            case 105:
            case 106:
            	{
                alt212 = 3;
                }
                break;
            case 59:
            	{
                alt212 = 4;
                }
                break;
            case 35:
            	{
                alt212 = 5;
                }
                break;
            case 32:
            	{
                alt212 = 6;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d212s0 =
            	        new NoViableAltException("", 212, 0, input);

            	    throw nvae_d212s0;
            }

            switch (alt212) 
            {
                case 1 :
                    // JavaScript.g:347:4: 'this'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal412=(IToken)Match(input,103,FOLLOW_103_in_primaryExpression2335); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal412_tree = (object)adaptor.Create(string_literal412, retval);
                    		adaptor.AddChild(root_0, string_literal412_tree);
                    	}

                    }
                    break;
                case 2 :
                    // JavaScript.g:348:4: Identifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	Identifier413=(IToken)new XToken((IToken)Match(input,Identifier,FOLLOW_Identifier_in_primaryExpression2340), "Identifier"); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{Identifier413_tree = (object)adaptor.Create(Identifier413, retval);
                    		adaptor.AddChild(root_0, Identifier413_tree);
                    	}

                    }
                    break;
                case 3 :
                    // JavaScript.g:349:4: literal
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_literal_in_primaryExpression2345);
                    	literal414 = literal();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, literal414.Tree, literal414, retval);

                    }
                    break;
                case 4 :
                    // JavaScript.g:350:4: arrayLiteral
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_arrayLiteral_in_primaryExpression2350);
                    	arrayLiteral415 = arrayLiteral();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arrayLiteral415.Tree, arrayLiteral415, retval);

                    }
                    break;
                case 5 :
                    // JavaScript.g:351:4: objectLiteral
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_objectLiteral_in_primaryExpression2355);
                    	objectLiteral416 = objectLiteral();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, objectLiteral416.Tree, objectLiteral416, retval);

                    }
                    break;
                case 6 :
                    // JavaScript.g:352:4: '(' ( LT )* expression ( LT )* ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal417=(IToken)Match(input,32,FOLLOW_32_in_primaryExpression2360); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal417_tree = (object)adaptor.Create(char_literal417, retval);
                    		adaptor.AddChild(root_0, char_literal417_tree);
                    	}
                    	// JavaScript.g:352:10: ( LT )*
                    	do 
                    	{
                    	    int alt210 = 2;
                    	    int LA210_0 = input.LA(1);

                    	    if ( (LA210_0 == LT) )
                    	    {
                    	        alt210 = 1;
                    	    }


                    	    switch (alt210) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT418=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_primaryExpression2362), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop210;
                    	    }
                    	} while (true);

                    	loop210:
                    		;	// Stops C# compiler whining that label 'loop210' has no statements

                    	PushFollow(FOLLOW_expression_in_primaryExpression2366);
                    	expression419 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression419.Tree, expression419, retval);
                    	// JavaScript.g:352:26: ( LT )*
                    	do 
                    	{
                    	    int alt211 = 2;
                    	    int LA211_0 = input.LA(1);

                    	    if ( (LA211_0 == LT) )
                    	    {
                    	        alt211 = 1;
                    	    }


                    	    switch (alt211) 
                    		{
                    			case 1 :
                    			    // JavaScript.g:0:0: LT
                    			    {
                    			    	LT420=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_primaryExpression2368), "LT"); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop211;
                    	    }
                    	} while (true);

                    	loop211:
                    		;	// Stops C# compiler whining that label 'loop211' has no statements

                    	char_literal421=(IToken)Match(input,34,FOLLOW_34_in_primaryExpression2372); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal421_tree = (object)adaptor.Create(char_literal421, retval);
                    		adaptor.AddChild(root_0, char_literal421_tree);
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 76, primaryExpression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "primaryExpression"

    public class arrayLiteral_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "arrayLiteral"
    // JavaScript.g:356:1: arrayLiteral : '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* ']' ;
    public JavaScriptParser.arrayLiteral_return arrayLiteral() // throws RecognitionException [1]
    {   
        JavaScriptParser.arrayLiteral_return retval = new JavaScriptParser.arrayLiteral_return();
        retval.Start = input.LT(1);
        int arrayLiteral_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal422 = null;
        IToken LT423 = null;
        IToken LT425 = null;
        IToken char_literal426 = null;
        IToken LT427 = null;
        IToken LT429 = null;
        IToken char_literal430 = null;
        JavaScriptParser.assignmentExpression_return assignmentExpression424 = default(JavaScriptParser.assignmentExpression_return);

        JavaScriptParser.assignmentExpression_return assignmentExpression428 = default(JavaScriptParser.assignmentExpression_return);


        object char_literal422_tree=null;
        object LT423_tree=null;
        object LT425_tree=null;
        object char_literal426_tree=null;
        object LT427_tree=null;
        object LT429_tree=null;
        object char_literal430_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 77) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:357:2: ( '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* ']' )
            // JavaScript.g:357:4: '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* ']'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal422=(IToken)Match(input,59,FOLLOW_59_in_arrayLiteral2385); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal422_tree = (object)adaptor.Create(char_literal422, retval);
            		adaptor.AddChild(root_0, char_literal422_tree);
            	}
            	// JavaScript.g:357:10: ( LT )*
            	do 
            	{
            	    int alt213 = 2;
            	    int LA213_0 = input.LA(1);

            	    if ( (LA213_0 == LT) )
            	    {
            	        int LA213_2 = input.LA(2);

            	        if ( (synpred280_JavaScript()) )
            	        {
            	            alt213 = 1;
            	        }


            	    }


            	    switch (alt213) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT423=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral2387), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop213;
            	    }
            	} while (true);

            	loop213:
            		;	// Stops C# compiler whining that label 'loop213' has no statements

            	// JavaScript.g:357:13: ( assignmentExpression )?
            	int alt214 = 2;
            	int LA214_0 = input.LA(1);

            	if ( ((LA214_0 >= Identifier && LA214_0 <= NumericLiteral) || (LA214_0 >= 31 && LA214_0 <= 32) || LA214_0 == 35 || (LA214_0 >= 58 && LA214_0 <= 59) || (LA214_0 >= 91 && LA214_0 <= 92) || (LA214_0 >= 96 && LA214_0 <= 106)) )
            	{
            	    alt214 = 1;
            	}
            	switch (alt214) 
            	{
            	    case 1 :
            	        // JavaScript.g:0:0: assignmentExpression
            	        {
            	        	PushFollow(FOLLOW_assignmentExpression_in_arrayLiteral2391);
            	        	assignmentExpression424 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression424.Tree, assignmentExpression424, retval);

            	        }
            	        break;

            	}

            	// JavaScript.g:357:35: ( ( LT )* ',' ( ( LT )* assignmentExpression )? )*
            	do 
            	{
            	    int alt218 = 2;
            	    alt218 = dfa218.Predict(input);
            	    switch (alt218) 
            		{
            			case 1 :
            			    // JavaScript.g:357:36: ( LT )* ',' ( ( LT )* assignmentExpression )?
            			    {
            			    	// JavaScript.g:357:38: ( LT )*
            			    	do 
            			    	{
            			    	    int alt215 = 2;
            			    	    int LA215_0 = input.LA(1);

            			    	    if ( (LA215_0 == LT) )
            			    	    {
            			    	        alt215 = 1;
            			    	    }


            			    	    switch (alt215) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT425=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral2395), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop215;
            			    	    }
            			    	} while (true);

            			    	loop215:
            			    		;	// Stops C# compiler whining that label 'loop215' has no statements

            			    	char_literal426=(IToken)Match(input,33,FOLLOW_33_in_arrayLiteral2399); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal426_tree = (object)adaptor.Create(char_literal426, retval);
            			    		adaptor.AddChild(root_0, char_literal426_tree);
            			    	}
            			    	// JavaScript.g:357:45: ( ( LT )* assignmentExpression )?
            			    	int alt217 = 2;
            			    	alt217 = dfa217.Predict(input);
            			    	switch (alt217) 
            			    	{
            			    	    case 1 :
            			    	        // JavaScript.g:357:46: ( LT )* assignmentExpression
            			    	        {
            			    	        	// JavaScript.g:357:48: ( LT )*
            			    	        	do 
            			    	        	{
            			    	        	    int alt216 = 2;
            			    	        	    int LA216_0 = input.LA(1);

            			    	        	    if ( (LA216_0 == LT) )
            			    	        	    {
            			    	        	        alt216 = 1;
            			    	        	    }


            			    	        	    switch (alt216) 
            			    	        		{
            			    	        			case 1 :
            			    	        			    // JavaScript.g:0:0: LT
            			    	        			    {
            			    	        			    	LT427=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral2402), "LT"); if (state.failed) return retval;

            			    	        			    }
            			    	        			    break;

            			    	        			default:
            			    	        			    goto loop216;
            			    	        	    }
            			    	        	} while (true);

            			    	        	loop216:
            			    	        		;	// Stops C# compiler whining that label 'loop216' has no statements

            			    	        	PushFollow(FOLLOW_assignmentExpression_in_arrayLiteral2406);
            			    	        	assignmentExpression428 = assignmentExpression();
            			    	        	state.followingStackPointer--;
            			    	        	if (state.failed) return retval;
            			    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression428.Tree, assignmentExpression428, retval);

            			    	        }
            			    	        break;

            			    	}


            			    }
            			    break;

            			default:
            			    goto loop218;
            	    }
            	} while (true);

            	loop218:
            		;	// Stops C# compiler whining that label 'loop218' has no statements

            	// JavaScript.g:357:78: ( LT )*
            	do 
            	{
            	    int alt219 = 2;
            	    int LA219_0 = input.LA(1);

            	    if ( (LA219_0 == LT) )
            	    {
            	        alt219 = 1;
            	    }


            	    switch (alt219) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT429=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral2412), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop219;
            	    }
            	} while (true);

            	loop219:
            		;	// Stops C# compiler whining that label 'loop219' has no statements

            	char_literal430=(IToken)Match(input,60,FOLLOW_60_in_arrayLiteral2416); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal430_tree = (object)adaptor.Create(char_literal430, retval);
            		adaptor.AddChild(root_0, char_literal430_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 77, arrayLiteral_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "arrayLiteral"

    public class objectLiteral_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "objectLiteral"
    // JavaScript.g:361:1: objectLiteral : '{' ( LT )* propertyNameAndValue ( ( LT )* ',' ( LT )* propertyNameAndValue )* ( LT )* '}' ;
    public JavaScriptParser.objectLiteral_return objectLiteral() // throws RecognitionException [1]
    {   
        JavaScriptParser.objectLiteral_return retval = new JavaScriptParser.objectLiteral_return();
        retval.Start = input.LT(1);
        int objectLiteral_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal431 = null;
        IToken LT432 = null;
        IToken LT434 = null;
        IToken char_literal435 = null;
        IToken LT436 = null;
        IToken LT438 = null;
        IToken char_literal439 = null;
        JavaScriptParser.propertyNameAndValue_return propertyNameAndValue433 = default(JavaScriptParser.propertyNameAndValue_return);

        JavaScriptParser.propertyNameAndValue_return propertyNameAndValue437 = default(JavaScriptParser.propertyNameAndValue_return);


        object char_literal431_tree=null;
        object LT432_tree=null;
        object LT434_tree=null;
        object char_literal435_tree=null;
        object LT436_tree=null;
        object LT438_tree=null;
        object char_literal439_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 78) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:362:2: ( '{' ( LT )* propertyNameAndValue ( ( LT )* ',' ( LT )* propertyNameAndValue )* ( LT )* '}' )
            // JavaScript.g:362:4: '{' ( LT )* propertyNameAndValue ( ( LT )* ',' ( LT )* propertyNameAndValue )* ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal431=(IToken)Match(input,35,FOLLOW_35_in_objectLiteral2435); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal431_tree = (object)adaptor.Create(char_literal431, retval);
            		adaptor.AddChild(root_0, char_literal431_tree);
            	}
            	// JavaScript.g:362:10: ( LT )*
            	do 
            	{
            	    int alt220 = 2;
            	    int LA220_0 = input.LA(1);

            	    if ( (LA220_0 == LT) )
            	    {
            	        alt220 = 1;
            	    }


            	    switch (alt220) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT432=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral2437), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop220;
            	    }
            	} while (true);

            	loop220:
            		;	// Stops C# compiler whining that label 'loop220' has no statements

            	PushFollow(FOLLOW_propertyNameAndValue_in_objectLiteral2441);
            	propertyNameAndValue433 = propertyNameAndValue();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyNameAndValue433.Tree, propertyNameAndValue433, retval);
            	// JavaScript.g:362:34: ( ( LT )* ',' ( LT )* propertyNameAndValue )*
            	do 
            	{
            	    int alt223 = 2;
            	    alt223 = dfa223.Predict(input);
            	    switch (alt223) 
            		{
            			case 1 :
            			    // JavaScript.g:362:35: ( LT )* ',' ( LT )* propertyNameAndValue
            			    {
            			    	// JavaScript.g:362:37: ( LT )*
            			    	do 
            			    	{
            			    	    int alt221 = 2;
            			    	    int LA221_0 = input.LA(1);

            			    	    if ( (LA221_0 == LT) )
            			    	    {
            			    	        alt221 = 1;
            			    	    }


            			    	    switch (alt221) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT434=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral2444), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop221;
            			    	    }
            			    	} while (true);

            			    	loop221:
            			    		;	// Stops C# compiler whining that label 'loop221' has no statements

            			    	char_literal435=(IToken)Match(input,33,FOLLOW_33_in_objectLiteral2448); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal435_tree = (object)adaptor.Create(char_literal435, retval);
            			    		adaptor.AddChild(root_0, char_literal435_tree);
            			    	}
            			    	// JavaScript.g:362:46: ( LT )*
            			    	do 
            			    	{
            			    	    int alt222 = 2;
            			    	    int LA222_0 = input.LA(1);

            			    	    if ( (LA222_0 == LT) )
            			    	    {
            			    	        alt222 = 1;
            			    	    }


            			    	    switch (alt222) 
            			    		{
            			    			case 1 :
            			    			    // JavaScript.g:0:0: LT
            			    			    {
            			    			    	LT436=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral2450), "LT"); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop222;
            			    	    }
            			    	} while (true);

            			    	loop222:
            			    		;	// Stops C# compiler whining that label 'loop222' has no statements

            			    	PushFollow(FOLLOW_propertyNameAndValue_in_objectLiteral2454);
            			    	propertyNameAndValue437 = propertyNameAndValue();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyNameAndValue437.Tree, propertyNameAndValue437, retval);

            			    }
            			    break;

            			default:
            			    goto loop223;
            	    }
            	} while (true);

            	loop223:
            		;	// Stops C# compiler whining that label 'loop223' has no statements

            	// JavaScript.g:362:74: ( LT )*
            	do 
            	{
            	    int alt224 = 2;
            	    int LA224_0 = input.LA(1);

            	    if ( (LA224_0 == LT) )
            	    {
            	        alt224 = 1;
            	    }


            	    switch (alt224) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT438=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral2458), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop224;
            	    }
            	} while (true);

            	loop224:
            		;	// Stops C# compiler whining that label 'loop224' has no statements

            	char_literal439=(IToken)Match(input,36,FOLLOW_36_in_objectLiteral2462); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal439_tree = (object)adaptor.Create(char_literal439, retval);
            		adaptor.AddChild(root_0, char_literal439_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 78, objectLiteral_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "objectLiteral"

    public class propertyNameAndValue_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "propertyNameAndValue"
    // JavaScript.g:365:1: propertyNameAndValue : propertyName ( LT )* ':' ( LT )* assignmentExpression ;
    public JavaScriptParser.propertyNameAndValue_return propertyNameAndValue() // throws RecognitionException [1]
    {   
        JavaScriptParser.propertyNameAndValue_return retval = new JavaScriptParser.propertyNameAndValue_return();
        retval.Start = input.LT(1);
        int propertyNameAndValue_StartIndex = input.Index();
        object root_0 = null;

        IToken LT441 = null;
        IToken char_literal442 = null;
        IToken LT443 = null;
        JavaScriptParser.propertyName_return propertyName440 = default(JavaScriptParser.propertyName_return);

        JavaScriptParser.assignmentExpression_return assignmentExpression444 = default(JavaScriptParser.assignmentExpression_return);


        object LT441_tree=null;
        object char_literal442_tree=null;
        object LT443_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 79) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:366:2: ( propertyName ( LT )* ':' ( LT )* assignmentExpression )
            // JavaScript.g:366:4: propertyName ( LT )* ':' ( LT )* assignmentExpression
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_propertyName_in_propertyNameAndValue2474);
            	propertyName440 = propertyName();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyName440.Tree, propertyName440, retval);
            	// JavaScript.g:366:19: ( LT )*
            	do 
            	{
            	    int alt225 = 2;
            	    int LA225_0 = input.LA(1);

            	    if ( (LA225_0 == LT) )
            	    {
            	        alt225 = 1;
            	    }


            	    switch (alt225) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT441=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_propertyNameAndValue2476), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop225;
            	    }
            	} while (true);

            	loop225:
            		;	// Stops C# compiler whining that label 'loop225' has no statements

            	char_literal442=(IToken)Match(input,50,FOLLOW_50_in_propertyNameAndValue2480); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal442_tree = (object)adaptor.Create(char_literal442, retval);
            		adaptor.AddChild(root_0, char_literal442_tree);
            	}
            	// JavaScript.g:366:28: ( LT )*
            	do 
            	{
            	    int alt226 = 2;
            	    int LA226_0 = input.LA(1);

            	    if ( (LA226_0 == LT) )
            	    {
            	        alt226 = 1;
            	    }


            	    switch (alt226) 
            		{
            			case 1 :
            			    // JavaScript.g:0:0: LT
            			    {
            			    	LT443=(IToken)new XToken((IToken)Match(input,LT,FOLLOW_LT_in_propertyNameAndValue2482), "LT"); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop226;
            	    }
            	} while (true);

            	loop226:
            		;	// Stops C# compiler whining that label 'loop226' has no statements

            	PushFollow(FOLLOW_assignmentExpression_in_propertyNameAndValue2486);
            	assignmentExpression444 = assignmentExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression444.Tree, assignmentExpression444, retval);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 79, propertyNameAndValue_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "propertyNameAndValue"

    public class propertyName_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "propertyName"
    // JavaScript.g:369:1: propertyName : ( Identifier | StringLiteral | NumericLiteral );
    public JavaScriptParser.propertyName_return propertyName() // throws RecognitionException [1]
    {   
        JavaScriptParser.propertyName_return retval = new JavaScriptParser.propertyName_return();
        retval.Start = input.LT(1);
        int propertyName_StartIndex = input.Index();
        object root_0 = null;

        IToken set445 = null;

        object set445_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 80) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:370:2: ( Identifier | StringLiteral | NumericLiteral )
            // JavaScript.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set445 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= Identifier && input.LA(1) <= NumericLiteral) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set445, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 80, propertyName_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "propertyName"

    public class literal_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "literal"
    // JavaScript.g:376:1: literal : ( 'null' | 'true' | 'false' | StringLiteral | NumericLiteral );
    public JavaScriptParser.literal_return literal() // throws RecognitionException [1]
    {   
        JavaScriptParser.literal_return retval = new JavaScriptParser.literal_return();
        retval.Start = input.LT(1);
        int literal_StartIndex = input.Index();
        object root_0 = null;

        IToken set446 = null;

        object set446_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 81) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:377:2: ( 'null' | 'true' | 'false' | StringLiteral | NumericLiteral )
            // JavaScript.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set446 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= StringLiteral && input.LA(1) <= NumericLiteral) || (input.LA(1) >= 104 && input.LA(1) <= 106) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set446, retval));
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
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
            if ( state.backtracking > 0 ) 
            {
            	Memoize(input, 81, literal_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "literal"

    // $ANTLR start "synpred5_JavaScript"
    public void synpred5_JavaScript_fragment() {
        // JavaScript.g:25:4: ( functionDeclaration )
        // JavaScript.g:25:4: functionDeclaration
        {
        	PushFollow(FOLLOW_functionDeclaration_in_synpred5_JavaScript87);
        	functionDeclaration();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred5_JavaScript"

    // $ANTLR start "synpred9_JavaScript"
    public void synpred9_JavaScript_fragment() {
        // JavaScript.g:35:15: ( LT )
        // JavaScript.g:35:15: LT
        {
        	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred9_JavaScript137), "LT"); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred9_JavaScript"

    // $ANTLR start "synpred21_JavaScript"
    public void synpred21_JavaScript_fragment() {
        // JavaScript.g:48:4: ( statementBlock )
        // JavaScript.g:48:4: statementBlock
        {
        	PushFollow(FOLLOW_statementBlock_in_synpred21_JavaScript231);
        	statementBlock();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred21_JavaScript"

    // $ANTLR start "synpred24_JavaScript"
    public void synpred24_JavaScript_fragment() {
        // JavaScript.g:51:4: ( expressionStatement )
        // JavaScript.g:51:4: expressionStatement
        {
        	PushFollow(FOLLOW_expressionStatement_in_synpred24_JavaScript246);
        	expressionStatement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred24_JavaScript"

    // $ANTLR start "synpred31_JavaScript"
    public void synpred31_JavaScript_fragment() {
        // JavaScript.g:58:4: ( labelledStatement )
        // JavaScript.g:58:4: labelledStatement
        {
        	PushFollow(FOLLOW_labelledStatement_in_synpred31_JavaScript281);
        	labelledStatement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred31_JavaScript"

    // $ANTLR start "synpred34_JavaScript"
    public void synpred34_JavaScript_fragment() {
        // JavaScript.g:65:8: ( LT )
        // JavaScript.g:65:8: LT
        {
        	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred34_JavaScript310), "LT"); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred34_JavaScript"

    // $ANTLR start "synpred47_JavaScript"
    public void synpred47_JavaScript_fragment() {
        // JavaScript.g:85:15: ( LT )
        // JavaScript.g:85:15: LT
        {
        	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred47_JavaScript436), "LT"); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred47_JavaScript"

    // $ANTLR start "synpred49_JavaScript"
    public void synpred49_JavaScript_fragment() {
        // JavaScript.g:89:15: ( LT )
        // JavaScript.g:89:15: LT
        {
        	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred49_JavaScript455), "LT"); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred49_JavaScript"

    // $ANTLR start "synpred60_JavaScript"
    public void synpred60_JavaScript_fragment() {
        // JavaScript.g:109:59: ( ( LT )* 'else' ( LT )* statement )
        // JavaScript.g:109:59: ( LT )* 'else' ( LT )* statement
        {
        	// JavaScript.g:109:61: ( LT )*
        	do 
        	{
        	    int alt239 = 2;
        	    int LA239_0 = input.LA(1);

        	    if ( (LA239_0 == LT) )
        	    {
        	        alt239 = 1;
        	    }


        	    switch (alt239) 
        		{
        			case 1 :
        			    // JavaScript.g:0:0: LT
        			    {
        			    	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred60_JavaScript567), "LT"); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop239;
        	    }
        	} while (true);

        	loop239:
        		;	// Stops C# compiler whining that label 'loop239' has no statements

        	Match(input,41,FOLLOW_41_in_synpred60_JavaScript571); if (state.failed) return ;
        	// JavaScript.g:109:73: ( LT )*
        	do 
        	{
        	    int alt240 = 2;
        	    int LA240_0 = input.LA(1);

        	    if ( (LA240_0 == LT) )
        	    {
        	        alt240 = 1;
        	    }


        	    switch (alt240) 
        		{
        			case 1 :
        			    // JavaScript.g:0:0: LT
        			    {
        			    	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred60_JavaScript573), "LT"); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop240;
        	    }
        	} while (true);

        	loop240:
        		;	// Stops C# compiler whining that label 'loop240' has no statements

        	PushFollow(FOLLOW_statement_in_synpred60_JavaScript577);
        	statement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred60_JavaScript"

    // $ANTLR start "synpred63_JavaScript"
    public void synpred63_JavaScript_fragment() {
        // JavaScript.g:115:4: ( forStatement )
        // JavaScript.g:115:4: forStatement
        {
        	PushFollow(FOLLOW_forStatement_in_synpred63_JavaScript601);
        	forStatement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred63_JavaScript"

    // $ANTLR start "synpred118_JavaScript"
    public void synpred118_JavaScript_fragment() {
        // JavaScript.g:174:36: ( LT )
        // JavaScript.g:174:36: LT
        {
        	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred118_JavaScript1078), "LT"); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred118_JavaScript"

    // $ANTLR start "synpred121_JavaScript"
    public void synpred121_JavaScript_fragment() {
        // JavaScript.g:178:23: ( LT )
        // JavaScript.g:178:23: LT
        {
        	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred121_JavaScript1103), "LT"); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred121_JavaScript"

    // $ANTLR start "synpred140_JavaScript"
    public void synpred140_JavaScript_fragment() {
        // JavaScript.g:207:4: ( conditionalExpression )
        // JavaScript.g:207:4: conditionalExpression
        {
        	PushFollow(FOLLOW_conditionalExpression_in_synpred140_JavaScript1294);
        	conditionalExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred140_JavaScript"

    // $ANTLR start "synpred143_JavaScript"
    public void synpred143_JavaScript_fragment() {
        // JavaScript.g:212:4: ( conditionalExpressionNoIn )
        // JavaScript.g:212:4: conditionalExpressionNoIn
        {
        	PushFollow(FOLLOW_conditionalExpressionNoIn_in_synpred143_JavaScript1323);
        	conditionalExpressionNoIn();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred143_JavaScript"

    // $ANTLR start "synpred146_JavaScript"
    public void synpred146_JavaScript_fragment() {
        // JavaScript.g:217:4: ( callExpression )
        // JavaScript.g:217:4: callExpression
        {
        	PushFollow(FOLLOW_callExpression_in_synpred146_JavaScript1352);
        	callExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred146_JavaScript"

    // $ANTLR start "synpred147_JavaScript"
    public void synpred147_JavaScript_fragment() {
        // JavaScript.g:222:4: ( memberExpression )
        // JavaScript.g:222:4: memberExpression
        {
        	PushFollow(FOLLOW_memberExpression_in_synpred147_JavaScript1369);
        	memberExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred147_JavaScript"

    // $ANTLR start "synpred154_JavaScript"
    public void synpred154_JavaScript_fragment() {
        // JavaScript.g:227:91: ( ( LT )* memberExpressionSuffix )
        // JavaScript.g:227:91: ( LT )* memberExpressionSuffix
        {
        	// JavaScript.g:227:93: ( LT )*
        	do 
        	{
        	    int alt254 = 2;
        	    int LA254_0 = input.LA(1);

        	    if ( (LA254_0 == LT) )
        	    {
        	        alt254 = 1;
        	    }


        	    switch (alt254) 
        		{
        			case 1 :
        			    // JavaScript.g:0:0: LT
        			    {
        			    	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred154_JavaScript1417), "LT"); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop254;
        	    }
        	} while (true);

        	loop254:
        		;	// Stops C# compiler whining that label 'loop254' has no statements

        	PushFollow(FOLLOW_memberExpressionSuffix_in_synpred154_JavaScript1421);
        	memberExpressionSuffix();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred154_JavaScript"

    // $ANTLR start "synpred158_JavaScript"
    public void synpred158_JavaScript_fragment() {
        // JavaScript.g:236:37: ( ( LT )* callExpressionSuffix )
        // JavaScript.g:236:37: ( LT )* callExpressionSuffix
        {
        	// JavaScript.g:236:39: ( LT )*
        	do 
        	{
        	    int alt255 = 2;
        	    int LA255_0 = input.LA(1);

        	    if ( (LA255_0 == LT) )
        	    {
        	        alt255 = 1;
        	    }


        	    switch (alt255) 
        		{
        			case 1 :
        			    // JavaScript.g:0:0: LT
        			    {
        			    	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred158_JavaScript1460), "LT"); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop255;
        	    }
        	} while (true);

        	loop255:
        		;	// Stops C# compiler whining that label 'loop255' has no statements

        	PushFollow(FOLLOW_callExpressionSuffix_in_synpred158_JavaScript1464);
        	callExpressionSuffix();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred158_JavaScript"

    // $ANTLR start "synpred256_JavaScript"
    public void synpred256_JavaScript_fragment() {
        // JavaScript.g:330:30: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )
        // JavaScript.g:330:30: ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression
        {
        	// JavaScript.g:330:32: ( LT )*
        	do 
        	{
        	    int alt300 = 2;
        	    int LA300_0 = input.LA(1);

        	    if ( (LA300_0 == LT) )
        	    {
        	        alt300 = 1;
        	    }


        	    switch (alt300) 
        		{
        			case 1 :
        			    // JavaScript.g:0:0: LT
        			    {
        			    	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred256_JavaScript2197), "LT"); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop300;
        	    }
        	} while (true);

        	loop300:
        		;	// Stops C# compiler whining that label 'loop300' has no statements

        	if ( (input.LA(1) >= 91 && input.LA(1) <= 92) ) 
        	{
        	    input.Consume();
        	    state.errorRecovery = false;state.failed = false;
        	}
        	else 
        	{
        	    if ( state.backtracking > 0 ) {state.failed = true; return ;}
        	    MismatchedSetException mse = new MismatchedSetException(null,input);
        	    throw mse;
        	}

        	// JavaScript.g:330:49: ( LT )*
        	do 
        	{
        	    int alt301 = 2;
        	    int LA301_0 = input.LA(1);

        	    if ( (LA301_0 == LT) )
        	    {
        	        alt301 = 1;
        	    }


        	    switch (alt301) 
        		{
        			case 1 :
        			    // JavaScript.g:0:0: LT
        			    {
        			    	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred256_JavaScript2209), "LT"); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop301;
        	    }
        	} while (true);

        	loop301:
        		;	// Stops C# compiler whining that label 'loop301' has no statements

        	PushFollow(FOLLOW_multiplicativeExpression_in_synpred256_JavaScript2213);
        	multiplicativeExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred256_JavaScript"

    // $ANTLR start "synpred280_JavaScript"
    public void synpred280_JavaScript_fragment() {
        // JavaScript.g:357:8: ( LT )
        // JavaScript.g:357:8: LT
        {
        	new XToken((IToken)Match(input,LT,FOLLOW_LT_in_synpred280_JavaScript2387), "LT"); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred280_JavaScript"

    // Delegated rules

   	public bool synpred60_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred60_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred121_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred121_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred146_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred146_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred154_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred154_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred34_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred34_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred147_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred147_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred63_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred63_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred47_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred47_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred256_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred256_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred280_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred280_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred118_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred118_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred158_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred158_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred9_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred9_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred21_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred21_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred31_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred31_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred49_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred49_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred24_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred24_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred143_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred143_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred140_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred140_JavaScript_fragment(); // can never throw exception
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
   	public bool synpred5_JavaScript() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred5_JavaScript_fragment(); // can never throw exception
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


   	protected DFA4 dfa4;
   	protected DFA5 dfa5;
   	protected DFA17 dfa17;
   	protected DFA16 dfa16;
   	protected DFA21 dfa21;
   	protected DFA26 dfa26;
   	protected DFA30 dfa30;
   	protected DFA33 dfa33;
   	protected DFA57 dfa57;
   	protected DFA60 dfa60;
   	protected DFA63 dfa63;
   	protected DFA90 dfa90;
   	protected DFA94 dfa94;
   	protected DFA93 dfa93;
   	protected DFA106 dfa106;
   	protected DFA115 dfa115;
   	protected DFA118 dfa118;
   	protected DFA121 dfa121;
   	protected DFA124 dfa124;
   	protected DFA125 dfa125;
   	protected DFA127 dfa127;
   	protected DFA132 dfa132;
   	protected DFA136 dfa136;
   	protected DFA142 dfa142;
   	protected DFA141 dfa141;
   	protected DFA151 dfa151;
   	protected DFA156 dfa156;
   	protected DFA159 dfa159;
   	protected DFA162 dfa162;
   	protected DFA165 dfa165;
   	protected DFA168 dfa168;
   	protected DFA171 dfa171;
   	protected DFA174 dfa174;
   	protected DFA177 dfa177;
   	protected DFA180 dfa180;
   	protected DFA183 dfa183;
   	protected DFA186 dfa186;
   	protected DFA189 dfa189;
   	protected DFA192 dfa192;
   	protected DFA195 dfa195;
   	protected DFA198 dfa198;
   	protected DFA201 dfa201;
   	protected DFA204 dfa204;
   	protected DFA207 dfa207;
   	protected DFA218 dfa218;
   	protected DFA217 dfa217;
   	protected DFA223 dfa223;
	private void InitializeCyclicDFAs()
	{
    	this.dfa4 = new DFA4(this);
    	this.dfa5 = new DFA5(this);
    	this.dfa17 = new DFA17(this);
    	this.dfa16 = new DFA16(this);
    	this.dfa21 = new DFA21(this);
    	this.dfa26 = new DFA26(this);
    	this.dfa30 = new DFA30(this);
    	this.dfa33 = new DFA33(this);
    	this.dfa57 = new DFA57(this);
    	this.dfa60 = new DFA60(this);
    	this.dfa63 = new DFA63(this);
    	this.dfa90 = new DFA90(this);
    	this.dfa94 = new DFA94(this);
    	this.dfa93 = new DFA93(this);
    	this.dfa106 = new DFA106(this);
    	this.dfa115 = new DFA115(this);
    	this.dfa118 = new DFA118(this);
    	this.dfa121 = new DFA121(this);
    	this.dfa124 = new DFA124(this);
    	this.dfa125 = new DFA125(this);
    	this.dfa127 = new DFA127(this);
    	this.dfa132 = new DFA132(this);
    	this.dfa136 = new DFA136(this);
    	this.dfa142 = new DFA142(this);
    	this.dfa141 = new DFA141(this);
    	this.dfa151 = new DFA151(this);
    	this.dfa156 = new DFA156(this);
    	this.dfa159 = new DFA159(this);
    	this.dfa162 = new DFA162(this);
    	this.dfa165 = new DFA165(this);
    	this.dfa168 = new DFA168(this);
    	this.dfa171 = new DFA171(this);
    	this.dfa174 = new DFA174(this);
    	this.dfa177 = new DFA177(this);
    	this.dfa180 = new DFA180(this);
    	this.dfa183 = new DFA183(this);
    	this.dfa186 = new DFA186(this);
    	this.dfa189 = new DFA189(this);
    	this.dfa192 = new DFA192(this);
    	this.dfa195 = new DFA195(this);
    	this.dfa198 = new DFA198(this);
    	this.dfa201 = new DFA201(this);
    	this.dfa204 = new DFA204(this);
    	this.dfa207 = new DFA207(this);
    	this.dfa218 = new DFA218(this);
    	this.dfa217 = new DFA217(this);
    	this.dfa223 = new DFA223(this);
	    this.dfa5.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA5_SpecialStateTransition);
	    this.dfa21.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA21_SpecialStateTransition);
	    this.dfa121.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA121_SpecialStateTransition);
	    this.dfa124.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA124_SpecialStateTransition);
	    this.dfa125.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA125_SpecialStateTransition);
	    this.dfa127.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA127_SpecialStateTransition);
	    this.dfa132.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA132_SpecialStateTransition);
	    this.dfa136.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA136_SpecialStateTransition);
	    this.dfa204.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA204_SpecialStateTransition);
	}

    const string DFA4_eotS =
        "\x04\uffff";
    const string DFA4_eofS =
        "\x02\x02\x02\uffff";
    const string DFA4_minS =
        "\x02\x04\x02\uffff";
    const string DFA4_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA4_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA4_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA4_transitionS = {
            "\x01\x01\x03\x03\x17\uffff\x02\x03\x02\uffff\x01\x03\x01\x02"+
            "\x02\x03\x01\uffff\x01\x03\x01\uffff\x03\x03\x01\uffff\x04\x03"+
            "\x01\uffff\x01\x03\x02\uffff\x02\x03\x02\uffff\x02\x03\x1f\uffff"+
            "\x02\x03\x03\uffff\x0b\x03",
            "\x01\x01\x03\x03\x17\uffff\x02\x03\x02\uffff\x01\x03\x01\x02"+
            "\x02\x03\x01\uffff\x01\x03\x01\uffff\x03\x03\x01\uffff\x04\x03"+
            "\x01\uffff\x01\x03\x02\uffff\x02\x03\x02\uffff\x02\x03\x1f\uffff"+
            "\x02\x03\x03\uffff\x0b\x03",
            "",
            ""
    };

    static readonly short[] DFA4_eot = DFA.UnpackEncodedString(DFA4_eotS);
    static readonly short[] DFA4_eof = DFA.UnpackEncodedString(DFA4_eofS);
    static readonly char[] DFA4_min = DFA.UnpackEncodedStringToUnsignedChars(DFA4_minS);
    static readonly char[] DFA4_max = DFA.UnpackEncodedStringToUnsignedChars(DFA4_maxS);
    static readonly short[] DFA4_accept = DFA.UnpackEncodedString(DFA4_acceptS);
    static readonly short[] DFA4_special = DFA.UnpackEncodedString(DFA4_specialS);
    static readonly short[][] DFA4_transition = DFA.UnpackEncodedStringArray(DFA4_transitionS);

    protected class DFA4 : DFA
    {
        public DFA4(BaseRecognizer recognizer)
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

        override public string Description
        {
            get { return "()* loopback of 21:18: ( ( LT )* sourceElement )*"; }
        }

    }

    const string DFA5_eotS =
        "\x18\uffff";
    const string DFA5_eofS =
        "\x18\uffff";
    const string DFA5_minS =
        "\x01\x05\x01\x00\x16\uffff";
    const string DFA5_maxS =
        "\x01\x6a\x01\x00\x16\uffff";
    const string DFA5_acceptS =
        "\x02\uffff\x01\x02\x14\uffff\x01\x01";
    const string DFA5_specialS =
        "\x01\uffff\x01\x00\x16\uffff}>";
    static readonly string[] DFA5_transitionS = {
            "\x03\x02\x17\uffff\x01\x01\x01\x02\x02\uffff\x01\x02\x01\uffff"+
            "\x02\x02\x01\uffff\x01\x02\x01\uffff\x03\x02\x01\uffff\x04\x02"+
            "\x01\uffff\x01\x02\x02\uffff\x02\x02\x02\uffff\x02\x02\x1f\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "\x01\uffff",
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

    static readonly short[] DFA5_eot = DFA.UnpackEncodedString(DFA5_eotS);
    static readonly short[] DFA5_eof = DFA.UnpackEncodedString(DFA5_eofS);
    static readonly char[] DFA5_min = DFA.UnpackEncodedStringToUnsignedChars(DFA5_minS);
    static readonly char[] DFA5_max = DFA.UnpackEncodedStringToUnsignedChars(DFA5_maxS);
    static readonly short[] DFA5_accept = DFA.UnpackEncodedString(DFA5_acceptS);
    static readonly short[] DFA5_special = DFA.UnpackEncodedString(DFA5_specialS);
    static readonly short[][] DFA5_transition = DFA.UnpackEncodedStringArray(DFA5_transitionS);

    protected class DFA5 : DFA
    {
        public DFA5(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 5;
            this.eot = DFA5_eot;
            this.eof = DFA5_eof;
            this.min = DFA5_min;
            this.max = DFA5_max;
            this.accept = DFA5_accept;
            this.special = DFA5_special;
            this.transition = DFA5_transition;

        }

        override public string Description
        {
            get { return "24:1: sourceElement : ( functionDeclaration | statement );"; }
        }

    }


    protected internal int DFA5_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA5_1 = input.LA(1);

                   	 
                   	int index5_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred5_JavaScript()) ) { s = 23; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index5_1);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae5 =
            new NoViableAltException(dfa.Description, 5, _s, input);
        dfa.Error(nvae5);
        throw nvae5;
    }
    const string DFA17_eotS =
        "\x04\uffff";
    const string DFA17_eofS =
        "\x04\uffff";
    const string DFA17_minS =
        "\x02\x04\x02\uffff";
    const string DFA17_maxS =
        "\x02\x22\x02\uffff";
    const string DFA17_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA17_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA17_transitionS = {
            "\x01\x01\x01\x02\x1c\uffff\x01\x03",
            "\x01\x01\x01\x02\x1c\uffff\x01\x03",
            "",
            ""
    };

    static readonly short[] DFA17_eot = DFA.UnpackEncodedString(DFA17_eotS);
    static readonly short[] DFA17_eof = DFA.UnpackEncodedString(DFA17_eofS);
    static readonly char[] DFA17_min = DFA.UnpackEncodedStringToUnsignedChars(DFA17_minS);
    static readonly char[] DFA17_max = DFA.UnpackEncodedStringToUnsignedChars(DFA17_maxS);
    static readonly short[] DFA17_accept = DFA.UnpackEncodedString(DFA17_acceptS);
    static readonly short[] DFA17_special = DFA.UnpackEncodedString(DFA17_specialS);
    static readonly short[][] DFA17_transition = DFA.UnpackEncodedStringArray(DFA17_transitionS);

    protected class DFA17 : DFA
    {
        public DFA17(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 17;
            this.eot = DFA17_eot;
            this.eof = DFA17_eof;
            this.min = DFA17_min;
            this.max = DFA17_max;
            this.accept = DFA17_accept;
            this.special = DFA17_special;
            this.transition = DFA17_transition;

        }

        override public string Description
        {
            get { return "39:8: ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )?"; }
        }

    }

    const string DFA16_eotS =
        "\x04\uffff";
    const string DFA16_eofS =
        "\x04\uffff";
    const string DFA16_minS =
        "\x02\x04\x02\uffff";
    const string DFA16_maxS =
        "\x02\x22\x02\uffff";
    const string DFA16_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA16_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA16_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x01\x02",
            "\x01\x01\x1c\uffff\x01\x03\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA16_eot = DFA.UnpackEncodedString(DFA16_eotS);
    static readonly short[] DFA16_eof = DFA.UnpackEncodedString(DFA16_eofS);
    static readonly char[] DFA16_min = DFA.UnpackEncodedStringToUnsignedChars(DFA16_minS);
    static readonly char[] DFA16_max = DFA.UnpackEncodedStringToUnsignedChars(DFA16_maxS);
    static readonly short[] DFA16_accept = DFA.UnpackEncodedString(DFA16_acceptS);
    static readonly short[] DFA16_special = DFA.UnpackEncodedString(DFA16_specialS);
    static readonly short[][] DFA16_transition = DFA.UnpackEncodedStringArray(DFA16_transitionS);

    protected class DFA16 : DFA
    {
        public DFA16(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 16;
            this.eot = DFA16_eot;
            this.eof = DFA16_eof;
            this.min = DFA16_min;
            this.max = DFA16_max;
            this.accept = DFA16_accept;
            this.special = DFA16_special;
            this.transition = DFA16_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 39:25: ( ( LT )* ',' ( LT )* Identifier )*"; }
        }

    }

    const string DFA21_eotS =
        "\x19\uffff";
    const string DFA21_eofS =
        "\x19\uffff";
    const string DFA21_minS =
        "\x01\x05\x01\x00\x03\uffff\x01\x00\x13\uffff";
    const string DFA21_maxS =
        "\x01\x6a\x01\x00\x03\uffff\x01\x00\x13\uffff";
    const string DFA21_acceptS =
        "\x02\uffff\x01\x02\x01\x03\x01\x04\x07\uffff\x01\x05\x01\x06\x02"+
        "\uffff\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0c\x01\x0d\x01\x0e\x01"+
        "\x01\x01\x0b";
    const string DFA21_specialS =
        "\x01\uffff\x01\x00\x03\uffff\x01\x01\x13\uffff}>";
    static readonly string[] DFA21_transitionS = {
            "\x01\x05\x02\x04\x17\uffff\x02\x04\x02\uffff\x01\x01\x01\uffff"+
            "\x01\x02\x01\x03\x01\uffff\x01\x0c\x01\uffff\x03\x0d\x01\uffff"+
            "\x01\x10\x01\x11\x01\x12\x01\x13\x01\uffff\x01\x14\x02\uffff"+
            "\x01\x15\x01\x16\x02\uffff\x02\x04\x1f\uffff\x02\x04\x03\uffff"+
            "\x0b\x04",
            "\x01\uffff",
            "",
            "",
            "",
            "\x01\uffff",
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

    static readonly short[] DFA21_eot = DFA.UnpackEncodedString(DFA21_eotS);
    static readonly short[] DFA21_eof = DFA.UnpackEncodedString(DFA21_eofS);
    static readonly char[] DFA21_min = DFA.UnpackEncodedStringToUnsignedChars(DFA21_minS);
    static readonly char[] DFA21_max = DFA.UnpackEncodedStringToUnsignedChars(DFA21_maxS);
    static readonly short[] DFA21_accept = DFA.UnpackEncodedString(DFA21_acceptS);
    static readonly short[] DFA21_special = DFA.UnpackEncodedString(DFA21_specialS);
    static readonly short[][] DFA21_transition = DFA.UnpackEncodedStringArray(DFA21_transitionS);

    protected class DFA21 : DFA
    {
        public DFA21(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 21;
            this.eot = DFA21_eot;
            this.eof = DFA21_eof;
            this.min = DFA21_min;
            this.max = DFA21_max;
            this.accept = DFA21_accept;
            this.special = DFA21_special;
            this.transition = DFA21_transition;

        }

        override public string Description
        {
            get { return "47:1: statement : ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );"; }
        }

    }


    protected internal int DFA21_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA21_1 = input.LA(1);

                   	 
                   	int index21_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred21_JavaScript()) ) { s = 23; }

                   	else if ( (synpred24_JavaScript()) ) { s = 4; }

                   	 
                   	input.Seek(index21_1);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA21_5 = input.LA(1);

                   	 
                   	int index21_5 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred24_JavaScript()) ) { s = 4; }

                   	else if ( (synpred31_JavaScript()) ) { s = 24; }

                   	 
                   	input.Seek(index21_5);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae21 =
            new NoViableAltException(dfa.Description, 21, _s, input);
        dfa.Error(nvae21);
        throw nvae21;
    }
    const string DFA26_eotS =
        "\x04\uffff";
    const string DFA26_eofS =
        "\x01\x02\x03\uffff";
    const string DFA26_minS =
        "\x02\x04\x02\uffff";
    const string DFA26_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA26_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA26_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA26_transitionS = {
            "\x01\x01\x03\x03\x17\uffff\x02\x03\x02\uffff\x01\x03\x01\x02"+
            "\x02\x03\x01\uffff\x01\x03\x01\uffff\x03\x03\x01\uffff\x04\x03"+
            "\x01\uffff\x01\x03\x02\x02\x02\x03\x02\uffff\x02\x03\x1f\uffff"+
            "\x02\x03\x03\uffff\x0b\x03",
            "\x01\x01\x03\x03\x17\uffff\x02\x03\x02\uffff\x01\x03\x01\x02"+
            "\x02\x03\x01\uffff\x01\x03\x01\uffff\x03\x03\x01\uffff\x04\x03"+
            "\x01\uffff\x01\x03\x02\x02\x02\x03\x02\uffff\x02\x03\x1f\uffff"+
            "\x02\x03\x03\uffff\x0b\x03",
            "",
            ""
    };

    static readonly short[] DFA26_eot = DFA.UnpackEncodedString(DFA26_eotS);
    static readonly short[] DFA26_eof = DFA.UnpackEncodedString(DFA26_eofS);
    static readonly char[] DFA26_min = DFA.UnpackEncodedStringToUnsignedChars(DFA26_minS);
    static readonly char[] DFA26_max = DFA.UnpackEncodedStringToUnsignedChars(DFA26_maxS);
    static readonly short[] DFA26_accept = DFA.UnpackEncodedString(DFA26_acceptS);
    static readonly short[] DFA26_special = DFA.UnpackEncodedString(DFA26_specialS);
    static readonly short[][] DFA26_transition = DFA.UnpackEncodedStringArray(DFA26_transitionS);

    protected class DFA26 : DFA
    {
        public DFA26(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 26;
            this.eot = DFA26_eot;
            this.eof = DFA26_eof;
            this.min = DFA26_min;
            this.max = DFA26_max;
            this.accept = DFA26_accept;
            this.special = DFA26_special;
            this.transition = DFA26_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 69:14: ( ( LT )* statement )*"; }
        }

    }

    const string DFA30_eotS =
        "\x05\uffff";
    const string DFA30_eofS =
        "\x01\uffff\x01\x02\x02\uffff\x01\x02";
    const string DFA30_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA30_maxS =
        "\x01\x26\x01\x6a\x02\uffff\x01\x6a";
    const string DFA30_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA30_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA30_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x04\uffff\x01\x02",
            "\x01\x04\x03\x02\x17\uffff\x02\x02\x01\x03\x01\uffff\x04\x02"+
            "\x01\uffff\x05\x02\x01\uffff\x04\x02\x01\uffff\x05\x02\x02\uffff"+
            "\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x02\x02\x01\x03\x01\uffff\x04\x02"+
            "\x01\uffff\x05\x02\x01\uffff\x04\x02\x01\uffff\x05\x02\x02\uffff"+
            "\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02"
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
            get { return "()* loopback of 77:24: ( ( LT )* ',' ( LT )* variableDeclaration )*"; }
        }

    }

    const string DFA33_eotS =
        "\x04\uffff";
    const string DFA33_eofS =
        "\x01\x02\x03\uffff";
    const string DFA33_minS =
        "\x02\x04\x02\uffff";
    const string DFA33_maxS =
        "\x02\x26\x02\uffff";
    const string DFA33_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA33_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA33_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x04\uffff\x01\x02",
            "\x01\x01\x1c\uffff\x01\x03\x04\uffff\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA33_eot = DFA.UnpackEncodedString(DFA33_eotS);
    static readonly short[] DFA33_eof = DFA.UnpackEncodedString(DFA33_eofS);
    static readonly char[] DFA33_min = DFA.UnpackEncodedStringToUnsignedChars(DFA33_minS);
    static readonly char[] DFA33_max = DFA.UnpackEncodedStringToUnsignedChars(DFA33_maxS);
    static readonly short[] DFA33_accept = DFA.UnpackEncodedString(DFA33_acceptS);
    static readonly short[] DFA33_special = DFA.UnpackEncodedString(DFA33_specialS);
    static readonly short[][] DFA33_transition = DFA.UnpackEncodedStringArray(DFA33_transitionS);

    protected class DFA33 : DFA
    {
        public DFA33(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 33;
            this.eot = DFA33_eot;
            this.eof = DFA33_eof;
            this.min = DFA33_min;
            this.max = DFA33_max;
            this.accept = DFA33_accept;
            this.special = DFA33_special;
            this.transition = DFA33_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 81:28: ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*"; }
        }

    }

    const string DFA57_eotS =
        "\x04\uffff";
    const string DFA57_eofS =
        "\x04\uffff";
    const string DFA57_minS =
        "\x02\x04\x02\uffff";
    const string DFA57_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA57_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA57_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA57_transitionS = {
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x02\uffff\x01\x02\x01\uffff"+
            "\x01\x02\x01\x03\x13\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff"+
            "\x0b\x02",
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x02\uffff\x01\x02\x01\uffff"+
            "\x01\x02\x01\x03\x13\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff"+
            "\x0b\x02",
            "",
            ""
    };

    static readonly short[] DFA57_eot = DFA.UnpackEncodedString(DFA57_eotS);
    static readonly short[] DFA57_eof = DFA.UnpackEncodedString(DFA57_eofS);
    static readonly char[] DFA57_min = DFA.UnpackEncodedStringToUnsignedChars(DFA57_minS);
    static readonly char[] DFA57_max = DFA.UnpackEncodedStringToUnsignedChars(DFA57_maxS);
    static readonly short[] DFA57_accept = DFA.UnpackEncodedString(DFA57_acceptS);
    static readonly short[] DFA57_special = DFA.UnpackEncodedString(DFA57_specialS);
    static readonly short[][] DFA57_transition = DFA.UnpackEncodedStringArray(DFA57_transitionS);

    protected class DFA57 : DFA
    {
        public DFA57(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 57;
            this.eot = DFA57_eot;
            this.eof = DFA57_eof;
            this.min = DFA57_min;
            this.max = DFA57_max;
            this.accept = DFA57_accept;
            this.special = DFA57_special;
            this.transition = DFA57_transition;

        }

        override public string Description
        {
            get { return "128:19: ( ( LT )* forStatementInitialiserPart )?"; }
        }

    }

    const string DFA60_eotS =
        "\x04\uffff";
    const string DFA60_eofS =
        "\x04\uffff";
    const string DFA60_minS =
        "\x02\x04\x02\uffff";
    const string DFA60_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA60_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA60_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA60_transitionS = {
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x02\uffff\x01\x02\x02\uffff"+
            "\x01\x03\x13\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02",
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x02\uffff\x01\x02\x02\uffff"+
            "\x01\x03\x13\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02",
            "",
            ""
    };

    static readonly short[] DFA60_eot = DFA.UnpackEncodedString(DFA60_eotS);
    static readonly short[] DFA60_eof = DFA.UnpackEncodedString(DFA60_eofS);
    static readonly char[] DFA60_min = DFA.UnpackEncodedStringToUnsignedChars(DFA60_minS);
    static readonly char[] DFA60_max = DFA.UnpackEncodedStringToUnsignedChars(DFA60_maxS);
    static readonly short[] DFA60_accept = DFA.UnpackEncodedString(DFA60_acceptS);
    static readonly short[] DFA60_special = DFA.UnpackEncodedString(DFA60_specialS);
    static readonly short[][] DFA60_transition = DFA.UnpackEncodedStringArray(DFA60_transitionS);

    protected class DFA60 : DFA
    {
        public DFA60(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 60;
            this.eot = DFA60_eot;
            this.eof = DFA60_eof;
            this.min = DFA60_min;
            this.max = DFA60_max;
            this.accept = DFA60_accept;
            this.special = DFA60_special;
            this.transition = DFA60_transition;

        }

        override public string Description
        {
            get { return "128:64: ( ( LT )* expression )?"; }
        }

    }

    const string DFA63_eotS =
        "\x04\uffff";
    const string DFA63_eofS =
        "\x04\uffff";
    const string DFA63_minS =
        "\x02\x04\x02\uffff";
    const string DFA63_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA63_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA63_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA63_transitionS = {
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x01\uffff\x01\x03\x01\x02"+
            "\x16\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02",
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x01\uffff\x01\x03\x01\x02"+
            "\x16\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02",
            "",
            ""
    };

    static readonly short[] DFA63_eot = DFA.UnpackEncodedString(DFA63_eotS);
    static readonly short[] DFA63_eof = DFA.UnpackEncodedString(DFA63_eofS);
    static readonly char[] DFA63_min = DFA.UnpackEncodedStringToUnsignedChars(DFA63_minS);
    static readonly char[] DFA63_max = DFA.UnpackEncodedStringToUnsignedChars(DFA63_maxS);
    static readonly short[] DFA63_accept = DFA.UnpackEncodedString(DFA63_acceptS);
    static readonly short[] DFA63_special = DFA.UnpackEncodedString(DFA63_specialS);
    static readonly short[][] DFA63_transition = DFA.UnpackEncodedStringArray(DFA63_transitionS);

    protected class DFA63 : DFA
    {
        public DFA63(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 63;
            this.eot = DFA63_eot;
            this.eof = DFA63_eof;
            this.min = DFA63_min;
            this.max = DFA63_max;
            this.accept = DFA63_accept;
            this.special = DFA63_special;
            this.transition = DFA63_transition;

        }

        override public string Description
        {
            get { return "128:92: ( ( LT )* expression )?"; }
        }

    }

    const string DFA90_eotS =
        "\x04\uffff";
    const string DFA90_eofS =
        "\x04\uffff";
    const string DFA90_minS =
        "\x02\x04\x02\uffff";
    const string DFA90_maxS =
        "\x02\x35\x02\uffff";
    const string DFA90_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA90_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA90_transitionS = {
            "\x01\x01\x1f\uffff\x01\x02\x0f\uffff\x01\x03\x01\x02",
            "\x01\x01\x1f\uffff\x01\x02\x0f\uffff\x01\x03\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA90_eot = DFA.UnpackEncodedString(DFA90_eotS);
    static readonly short[] DFA90_eof = DFA.UnpackEncodedString(DFA90_eofS);
    static readonly char[] DFA90_min = DFA.UnpackEncodedStringToUnsignedChars(DFA90_minS);
    static readonly char[] DFA90_max = DFA.UnpackEncodedStringToUnsignedChars(DFA90_maxS);
    static readonly short[] DFA90_accept = DFA.UnpackEncodedString(DFA90_acceptS);
    static readonly short[] DFA90_special = DFA.UnpackEncodedString(DFA90_specialS);
    static readonly short[][] DFA90_transition = DFA.UnpackEncodedStringArray(DFA90_transitionS);

    protected class DFA90 : DFA
    {
        public DFA90(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 90;
            this.eot = DFA90_eot;
            this.eof = DFA90_eof;
            this.min = DFA90_min;
            this.max = DFA90_max;
            this.accept = DFA90_accept;
            this.special = DFA90_special;
            this.transition = DFA90_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 170:8: ( ( LT )* caseClause )*"; }
        }

    }

    const string DFA94_eotS =
        "\x04\uffff";
    const string DFA94_eofS =
        "\x04\uffff";
    const string DFA94_minS =
        "\x02\x04\x02\uffff";
    const string DFA94_maxS =
        "\x02\x35\x02\uffff";
    const string DFA94_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA94_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA94_transitionS = {
            "\x01\x01\x1f\uffff\x01\x03\x10\uffff\x01\x02",
            "\x01\x01\x1f\uffff\x01\x03\x10\uffff\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA94_eot = DFA.UnpackEncodedString(DFA94_eotS);
    static readonly short[] DFA94_eof = DFA.UnpackEncodedString(DFA94_eofS);
    static readonly char[] DFA94_min = DFA.UnpackEncodedStringToUnsignedChars(DFA94_minS);
    static readonly char[] DFA94_max = DFA.UnpackEncodedStringToUnsignedChars(DFA94_maxS);
    static readonly short[] DFA94_accept = DFA.UnpackEncodedString(DFA94_acceptS);
    static readonly short[] DFA94_special = DFA.UnpackEncodedString(DFA94_specialS);
    static readonly short[][] DFA94_transition = DFA.UnpackEncodedStringArray(DFA94_transitionS);

    protected class DFA94 : DFA
    {
        public DFA94(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 94;
            this.eot = DFA94_eot;
            this.eof = DFA94_eof;
            this.min = DFA94_min;
            this.max = DFA94_max;
            this.accept = DFA94_accept;
            this.special = DFA94_special;
            this.transition = DFA94_transition;

        }

        override public string Description
        {
            get { return "170:27: ( ( LT )* defaultClause ( ( LT )* caseClause )* )?"; }
        }

    }

    const string DFA93_eotS =
        "\x04\uffff";
    const string DFA93_eofS =
        "\x04\uffff";
    const string DFA93_minS =
        "\x02\x04\x02\uffff";
    const string DFA93_maxS =
        "\x02\x34\x02\uffff";
    const string DFA93_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA93_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA93_transitionS = {
            "\x01\x01\x1f\uffff\x01\x02\x0f\uffff\x01\x03",
            "\x01\x01\x1f\uffff\x01\x02\x0f\uffff\x01\x03",
            "",
            ""
    };

    static readonly short[] DFA93_eot = DFA.UnpackEncodedString(DFA93_eotS);
    static readonly short[] DFA93_eof = DFA.UnpackEncodedString(DFA93_eofS);
    static readonly char[] DFA93_min = DFA.UnpackEncodedStringToUnsignedChars(DFA93_minS);
    static readonly char[] DFA93_max = DFA.UnpackEncodedStringToUnsignedChars(DFA93_maxS);
    static readonly short[] DFA93_accept = DFA.UnpackEncodedString(DFA93_acceptS);
    static readonly short[] DFA93_special = DFA.UnpackEncodedString(DFA93_specialS);
    static readonly short[][] DFA93_transition = DFA.UnpackEncodedStringArray(DFA93_transitionS);

    protected class DFA93 : DFA
    {
        public DFA93(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 93;
            this.eot = DFA93_eot;
            this.eof = DFA93_eof;
            this.min = DFA93_min;
            this.max = DFA93_max;
            this.accept = DFA93_accept;
            this.special = DFA93_special;
            this.transition = DFA93_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 170:47: ( ( LT )* caseClause )*"; }
        }

    }

    const string DFA106_eotS =
        "\x04\uffff";
    const string DFA106_eofS =
        "\x02\x03\x02\uffff";
    const string DFA106_minS =
        "\x02\x04\x02\uffff";
    const string DFA106_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA106_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA106_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA106_transitionS = {
            "\x01\x01\x03\x03\x17\uffff\x02\x03\x02\uffff\x04\x03\x01\uffff"+
            "\x05\x03\x01\uffff\x04\x03\x01\uffff\x05\x03\x01\uffff\x01\x02"+
            "\x02\x03\x1f\uffff\x02\x03\x03\uffff\x0b\x03",
            "\x01\x01\x03\x03\x17\uffff\x02\x03\x02\uffff\x04\x03\x01\uffff"+
            "\x05\x03\x01\uffff\x04\x03\x01\uffff\x05\x03\x01\uffff\x01\x02"+
            "\x02\x03\x1f\uffff\x02\x03\x03\uffff\x0b\x03",
            "",
            ""
    };

    static readonly short[] DFA106_eot = DFA.UnpackEncodedString(DFA106_eotS);
    static readonly short[] DFA106_eof = DFA.UnpackEncodedString(DFA106_eofS);
    static readonly char[] DFA106_min = DFA.UnpackEncodedStringToUnsignedChars(DFA106_minS);
    static readonly char[] DFA106_max = DFA.UnpackEncodedStringToUnsignedChars(DFA106_maxS);
    static readonly short[] DFA106_accept = DFA.UnpackEncodedString(DFA106_acceptS);
    static readonly short[] DFA106_special = DFA.UnpackEncodedString(DFA106_specialS);
    static readonly short[][] DFA106_transition = DFA.UnpackEncodedStringArray(DFA106_transitionS);

    protected class DFA106 : DFA
    {
        public DFA106(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 106;
            this.eot = DFA106_eot;
            this.eof = DFA106_eof;
            this.min = DFA106_min;
            this.max = DFA106_max;
            this.accept = DFA106_accept;
            this.special = DFA106_special;
            this.transition = DFA106_transition;

        }

        override public string Description
        {
            get { return "186:64: ( ( LT )* finallyClause )?"; }
        }

    }

    const string DFA115_eotS =
        "\x05\uffff";
    const string DFA115_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA115_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA115_maxS =
        "\x01\x3c\x01\x6a\x02\uffff\x01\x6a";
    const string DFA115_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA115_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA115_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x01\x02\x03\uffff\x01\x02\x0b\uffff"+
            "\x01\x02\x09\uffff\x01\x02",
            "\x01\x04\x03\x02\x17\uffff\x02\x02\x01\x03\x05\x02\x01\uffff"+
            "\x05\x02\x01\uffff\x0a\x02\x02\uffff\x03\x02\x1e\uffff\x02\x02"+
            "\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x02\x02\x01\x03\x05\x02\x01\uffff"+
            "\x05\x02\x01\uffff\x0a\x02\x02\uffff\x03\x02\x1e\uffff\x02\x02"+
            "\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA115_eot = DFA.UnpackEncodedString(DFA115_eotS);
    static readonly short[] DFA115_eof = DFA.UnpackEncodedString(DFA115_eofS);
    static readonly char[] DFA115_min = DFA.UnpackEncodedStringToUnsignedChars(DFA115_minS);
    static readonly char[] DFA115_max = DFA.UnpackEncodedStringToUnsignedChars(DFA115_maxS);
    static readonly short[] DFA115_accept = DFA.UnpackEncodedString(DFA115_acceptS);
    static readonly short[] DFA115_special = DFA.UnpackEncodedString(DFA115_specialS);
    static readonly short[][] DFA115_transition = DFA.UnpackEncodedStringArray(DFA115_transitionS);

    protected class DFA115 : DFA
    {
        public DFA115(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 115;
            this.eot = DFA115_eot;
            this.eof = DFA115_eof;
            this.min = DFA115_min;
            this.max = DFA115_max;
            this.accept = DFA115_accept;
            this.special = DFA115_special;
            this.transition = DFA115_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 199:25: ( ( LT )* ',' ( LT )* assignmentExpression )*"; }
        }

    }

    const string DFA118_eotS =
        "\x04\uffff";
    const string DFA118_eofS =
        "\x01\x02\x03\uffff";
    const string DFA118_minS =
        "\x02\x04\x02\uffff";
    const string DFA118_maxS =
        "\x02\x26\x02\uffff";
    const string DFA118_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA118_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA118_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x04\uffff\x01\x02",
            "\x01\x01\x1c\uffff\x01\x03\x04\uffff\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA118_eot = DFA.UnpackEncodedString(DFA118_eotS);
    static readonly short[] DFA118_eof = DFA.UnpackEncodedString(DFA118_eofS);
    static readonly char[] DFA118_min = DFA.UnpackEncodedStringToUnsignedChars(DFA118_minS);
    static readonly char[] DFA118_max = DFA.UnpackEncodedStringToUnsignedChars(DFA118_maxS);
    static readonly short[] DFA118_accept = DFA.UnpackEncodedString(DFA118_acceptS);
    static readonly short[] DFA118_special = DFA.UnpackEncodedString(DFA118_specialS);
    static readonly short[][] DFA118_transition = DFA.UnpackEncodedStringArray(DFA118_transitionS);

    protected class DFA118 : DFA
    {
        public DFA118(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 118;
            this.eot = DFA118_eot;
            this.eof = DFA118_eof;
            this.min = DFA118_min;
            this.max = DFA118_max;
            this.accept = DFA118_accept;
            this.special = DFA118_special;
            this.transition = DFA118_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 203:29: ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*"; }
        }

    }

    const string DFA121_eotS =
        "\x0b\uffff";
    const string DFA121_eofS =
        "\x0b\uffff";
    const string DFA121_minS =
        "\x01\x05\x08\x00\x02\uffff";
    const string DFA121_maxS =
        "\x01\x6a\x08\x00\x02\uffff";
    const string DFA121_acceptS =
        "\x09\uffff\x01\x01\x01\x02";
    const string DFA121_specialS =
        "\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
        "\x06\x01\x07\x02\uffff}>";
    static readonly string[] DFA121_transitionS = {
            "\x01\x02\x02\x03\x17\uffff\x01\x07\x01\x06\x02\uffff\x01\x05"+
            "\x16\uffff\x01\x08\x01\x04\x1f\uffff\x02\x09\x03\uffff\x07\x09"+
            "\x01\x01\x03\x03",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            ""
    };

    static readonly short[] DFA121_eot = DFA.UnpackEncodedString(DFA121_eotS);
    static readonly short[] DFA121_eof = DFA.UnpackEncodedString(DFA121_eofS);
    static readonly char[] DFA121_min = DFA.UnpackEncodedStringToUnsignedChars(DFA121_minS);
    static readonly char[] DFA121_max = DFA.UnpackEncodedStringToUnsignedChars(DFA121_maxS);
    static readonly short[] DFA121_accept = DFA.UnpackEncodedString(DFA121_acceptS);
    static readonly short[] DFA121_special = DFA.UnpackEncodedString(DFA121_specialS);
    static readonly short[][] DFA121_transition = DFA.UnpackEncodedStringArray(DFA121_transitionS);

    protected class DFA121 : DFA
    {
        public DFA121(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 121;
            this.eot = DFA121_eot;
            this.eof = DFA121_eof;
            this.min = DFA121_min;
            this.max = DFA121_max;
            this.accept = DFA121_accept;
            this.special = DFA121_special;
            this.transition = DFA121_transition;

        }

        override public string Description
        {
            get { return "206:1: assignmentExpression : ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression );"; }
        }

    }


    protected internal int DFA121_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA121_1 = input.LA(1);

                   	 
                   	int index121_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_1);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA121_2 = input.LA(1);

                   	 
                   	int index121_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_2);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA121_3 = input.LA(1);

                   	 
                   	int index121_3 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_3);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA121_4 = input.LA(1);

                   	 
                   	int index121_4 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_4);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA121_5 = input.LA(1);

                   	 
                   	int index121_5 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_5);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA121_6 = input.LA(1);

                   	 
                   	int index121_6 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_6);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA121_7 = input.LA(1);

                   	 
                   	int index121_7 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_7);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA121_8 = input.LA(1);

                   	 
                   	int index121_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred140_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index121_8);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae121 =
            new NoViableAltException(dfa.Description, 121, _s, input);
        dfa.Error(nvae121);
        throw nvae121;
    }
    const string DFA124_eotS =
        "\x0b\uffff";
    const string DFA124_eofS =
        "\x0b\uffff";
    const string DFA124_minS =
        "\x01\x05\x08\x00\x02\uffff";
    const string DFA124_maxS =
        "\x01\x6a\x08\x00\x02\uffff";
    const string DFA124_acceptS =
        "\x09\uffff\x01\x01\x01\x02";
    const string DFA124_specialS =
        "\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
        "\x06\x01\x07\x02\uffff}>";
    static readonly string[] DFA124_transitionS = {
            "\x01\x02\x02\x03\x17\uffff\x01\x07\x01\x06\x02\uffff\x01\x05"+
            "\x16\uffff\x01\x08\x01\x04\x1f\uffff\x02\x09\x03\uffff\x07\x09"+
            "\x01\x01\x03\x03",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            ""
    };

    static readonly short[] DFA124_eot = DFA.UnpackEncodedString(DFA124_eotS);
    static readonly short[] DFA124_eof = DFA.UnpackEncodedString(DFA124_eofS);
    static readonly char[] DFA124_min = DFA.UnpackEncodedStringToUnsignedChars(DFA124_minS);
    static readonly char[] DFA124_max = DFA.UnpackEncodedStringToUnsignedChars(DFA124_maxS);
    static readonly short[] DFA124_accept = DFA.UnpackEncodedString(DFA124_acceptS);
    static readonly short[] DFA124_special = DFA.UnpackEncodedString(DFA124_specialS);
    static readonly short[][] DFA124_transition = DFA.UnpackEncodedStringArray(DFA124_transitionS);

    protected class DFA124 : DFA
    {
        public DFA124(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 124;
            this.eot = DFA124_eot;
            this.eof = DFA124_eof;
            this.min = DFA124_min;
            this.max = DFA124_max;
            this.accept = DFA124_accept;
            this.special = DFA124_special;
            this.transition = DFA124_transition;

        }

        override public string Description
        {
            get { return "211:1: assignmentExpressionNoIn : ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn );"; }
        }

    }


    protected internal int DFA124_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA124_1 = input.LA(1);

                   	 
                   	int index124_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_1);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA124_2 = input.LA(1);

                   	 
                   	int index124_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_2);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA124_3 = input.LA(1);

                   	 
                   	int index124_3 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_3);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA124_4 = input.LA(1);

                   	 
                   	int index124_4 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_4);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA124_5 = input.LA(1);

                   	 
                   	int index124_5 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_5);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA124_6 = input.LA(1);

                   	 
                   	int index124_6 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_6);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA124_7 = input.LA(1);

                   	 
                   	int index124_7 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_7);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA124_8 = input.LA(1);

                   	 
                   	int index124_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred143_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index124_8);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae124 =
            new NoViableAltException(dfa.Description, 124, _s, input);
        dfa.Error(nvae124);
        throw nvae124;
    }
    const string DFA125_eotS =
        "\x0b\uffff";
    const string DFA125_eofS =
        "\x0b\uffff";
    const string DFA125_minS =
        "\x01\x05\x08\x00\x02\uffff";
    const string DFA125_maxS =
        "\x01\x6a\x08\x00\x02\uffff";
    const string DFA125_acceptS =
        "\x09\uffff\x01\x01\x01\x02";
    const string DFA125_specialS =
        "\x01\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
        "\x06\x01\x07\x02\uffff}>";
    static readonly string[] DFA125_transitionS = {
            "\x01\x02\x02\x03\x17\uffff\x01\x07\x01\x06\x02\uffff\x01\x05"+
            "\x16\uffff\x01\x08\x01\x04\x2b\uffff\x01\x01\x03\x03",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            ""
    };

    static readonly short[] DFA125_eot = DFA.UnpackEncodedString(DFA125_eotS);
    static readonly short[] DFA125_eof = DFA.UnpackEncodedString(DFA125_eofS);
    static readonly char[] DFA125_min = DFA.UnpackEncodedStringToUnsignedChars(DFA125_minS);
    static readonly char[] DFA125_max = DFA.UnpackEncodedStringToUnsignedChars(DFA125_maxS);
    static readonly short[] DFA125_accept = DFA.UnpackEncodedString(DFA125_acceptS);
    static readonly short[] DFA125_special = DFA.UnpackEncodedString(DFA125_specialS);
    static readonly short[][] DFA125_transition = DFA.UnpackEncodedStringArray(DFA125_transitionS);

    protected class DFA125 : DFA
    {
        public DFA125(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 125;
            this.eot = DFA125_eot;
            this.eof = DFA125_eof;
            this.min = DFA125_min;
            this.max = DFA125_max;
            this.accept = DFA125_accept;
            this.special = DFA125_special;
            this.transition = DFA125_transition;

        }

        override public string Description
        {
            get { return "216:1: leftHandSideExpression : ( callExpression | newExpression );"; }
        }

    }


    protected internal int DFA125_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA125_1 = input.LA(1);

                   	 
                   	int index125_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_1);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA125_2 = input.LA(1);

                   	 
                   	int index125_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_2);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA125_3 = input.LA(1);

                   	 
                   	int index125_3 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_3);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA125_4 = input.LA(1);

                   	 
                   	int index125_4 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_4);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA125_5 = input.LA(1);

                   	 
                   	int index125_5 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_5);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA125_6 = input.LA(1);

                   	 
                   	int index125_6 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_6);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA125_7 = input.LA(1);

                   	 
                   	int index125_7 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_7);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA125_8 = input.LA(1);

                   	 
                   	int index125_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred146_JavaScript()) ) { s = 9; }

                   	else if ( (true) ) { s = 10; }

                   	 
                   	input.Seek(index125_8);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae125 =
            new NoViableAltException(dfa.Description, 125, _s, input);
        dfa.Error(nvae125);
        throw nvae125;
    }
    const string DFA127_eotS =
        "\x0a\uffff";
    const string DFA127_eofS =
        "\x0a\uffff";
    const string DFA127_minS =
        "\x01\x05\x07\uffff\x01\x00\x01\uffff";
    const string DFA127_maxS =
        "\x01\x6a\x07\uffff\x01\x00\x01\uffff";
    const string DFA127_acceptS =
        "\x01\uffff\x01\x01\x07\uffff\x01\x02";
    const string DFA127_specialS =
        "\x08\uffff\x01\x00\x01\uffff}>";
    static readonly string[] DFA127_transitionS = {
            "\x03\x01\x17\uffff\x02\x01\x02\uffff\x01\x01\x16\uffff\x01"+
            "\x08\x01\x01\x2b\uffff\x04\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            ""
    };

    static readonly short[] DFA127_eot = DFA.UnpackEncodedString(DFA127_eotS);
    static readonly short[] DFA127_eof = DFA.UnpackEncodedString(DFA127_eofS);
    static readonly char[] DFA127_min = DFA.UnpackEncodedStringToUnsignedChars(DFA127_minS);
    static readonly char[] DFA127_max = DFA.UnpackEncodedStringToUnsignedChars(DFA127_maxS);
    static readonly short[] DFA127_accept = DFA.UnpackEncodedString(DFA127_acceptS);
    static readonly short[] DFA127_special = DFA.UnpackEncodedString(DFA127_specialS);
    static readonly short[][] DFA127_transition = DFA.UnpackEncodedStringArray(DFA127_transitionS);

    protected class DFA127 : DFA
    {
        public DFA127(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 127;
            this.eot = DFA127_eot;
            this.eof = DFA127_eof;
            this.min = DFA127_min;
            this.max = DFA127_max;
            this.accept = DFA127_accept;
            this.special = DFA127_special;
            this.transition = DFA127_transition;

        }

        override public string Description
        {
            get { return "221:1: newExpression : ( memberExpression | 'new' ( LT )* newExpression );"; }
        }

    }


    protected internal int DFA127_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA127_8 = input.LA(1);

                   	 
                   	int index127_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred147_JavaScript()) ) { s = 1; }

                   	else if ( (true) ) { s = 9; }

                   	 
                   	input.Seek(index127_8);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae127 =
            new NoViableAltException(dfa.Description, 127, _s, input);
        dfa.Error(nvae127);
        throw nvae127;
    }
    const string DFA132_eotS =
        "\x1a\uffff";
    const string DFA132_eofS =
        "\x01\x02\x19\uffff";
    const string DFA132_minS =
        "\x01\x04\x01\x00\x18\uffff";
    const string DFA132_maxS =
        "\x01\x64\x01\x00\x18\uffff";
    const string DFA132_acceptS =
        "\x02\uffff\x01\x02\x15\uffff\x01\x01\x01\uffff";
    const string DFA132_specialS =
        "\x01\uffff\x01\x00\x18\uffff}>";
    static readonly string[] DFA132_transitionS = {
            "\x01\x01\x1b\uffff\x03\x02\x01\uffff\x01\x02\x01\uffff\x02"+
            "\x02\x05\uffff\x01\x02\x04\uffff\x01\x02\x08\uffff\x01\x18\x01"+
            "\x02\x01\x18\x22\x02\x03\uffff\x02\x02",
            "\x01\uffff",
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
            "",
            "",
            ""
    };

    static readonly short[] DFA132_eot = DFA.UnpackEncodedString(DFA132_eotS);
    static readonly short[] DFA132_eof = DFA.UnpackEncodedString(DFA132_eofS);
    static readonly char[] DFA132_min = DFA.UnpackEncodedStringToUnsignedChars(DFA132_minS);
    static readonly char[] DFA132_max = DFA.UnpackEncodedStringToUnsignedChars(DFA132_maxS);
    static readonly short[] DFA132_accept = DFA.UnpackEncodedString(DFA132_acceptS);
    static readonly short[] DFA132_special = DFA.UnpackEncodedString(DFA132_specialS);
    static readonly short[][] DFA132_transition = DFA.UnpackEncodedStringArray(DFA132_transitionS);

    protected class DFA132 : DFA
    {
        public DFA132(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 132;
            this.eot = DFA132_eot;
            this.eof = DFA132_eof;
            this.min = DFA132_min;
            this.max = DFA132_max;
            this.accept = DFA132_accept;
            this.special = DFA132_special;
            this.transition = DFA132_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 227:90: ( ( LT )* memberExpressionSuffix )*"; }
        }

    }


    protected internal int DFA132_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA132_1 = input.LA(1);

                   	 
                   	int index132_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred154_JavaScript()) ) { s = 24; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index132_1);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae132 =
            new NoViableAltException(dfa.Description, 132, _s, input);
        dfa.Error(nvae132);
        throw nvae132;
    }
    const string DFA136_eotS =
        "\x1a\uffff";
    const string DFA136_eofS =
        "\x01\x02\x19\uffff";
    const string DFA136_minS =
        "\x01\x04\x01\x00\x18\uffff";
    const string DFA136_maxS =
        "\x01\x64\x01\x00\x18\uffff";
    const string DFA136_acceptS =
        "\x02\uffff\x01\x02\x14\uffff\x01\x01\x02\uffff";
    const string DFA136_specialS =
        "\x01\uffff\x01\x00\x18\uffff}>";
    static readonly string[] DFA136_transitionS = {
            "\x01\x01\x1b\uffff\x01\x17\x02\x02\x01\uffff\x01\x02\x01\uffff"+
            "\x02\x02\x05\uffff\x01\x02\x04\uffff\x01\x02\x08\uffff\x01\x17"+
            "\x01\x02\x01\x17\x22\x02\x03\uffff\x02\x02",
            "\x01\uffff",
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
            "",
            "",
            ""
    };

    static readonly short[] DFA136_eot = DFA.UnpackEncodedString(DFA136_eotS);
    static readonly short[] DFA136_eof = DFA.UnpackEncodedString(DFA136_eofS);
    static readonly char[] DFA136_min = DFA.UnpackEncodedStringToUnsignedChars(DFA136_minS);
    static readonly char[] DFA136_max = DFA.UnpackEncodedStringToUnsignedChars(DFA136_maxS);
    static readonly short[] DFA136_accept = DFA.UnpackEncodedString(DFA136_acceptS);
    static readonly short[] DFA136_special = DFA.UnpackEncodedString(DFA136_specialS);
    static readonly short[][] DFA136_transition = DFA.UnpackEncodedStringArray(DFA136_transitionS);

    protected class DFA136 : DFA
    {
        public DFA136(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 136;
            this.eot = DFA136_eot;
            this.eof = DFA136_eof;
            this.min = DFA136_min;
            this.max = DFA136_max;
            this.accept = DFA136_accept;
            this.special = DFA136_special;
            this.transition = DFA136_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 236:36: ( ( LT )* callExpressionSuffix )*"; }
        }

    }


    protected internal int DFA136_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA136_1 = input.LA(1);

                   	 
                   	int index136_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred158_JavaScript()) ) { s = 23; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index136_1);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae136 =
            new NoViableAltException(dfa.Description, 136, _s, input);
        dfa.Error(nvae136);
        throw nvae136;
    }
    const string DFA142_eotS =
        "\x04\uffff";
    const string DFA142_eofS =
        "\x04\uffff";
    const string DFA142_minS =
        "\x02\x04\x02\uffff";
    const string DFA142_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA142_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA142_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA142_transitionS = {
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x01\uffff\x01\x03\x01\x02"+
            "\x16\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02",
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x01\uffff\x01\x03\x01\x02"+
            "\x16\uffff\x02\x02\x1f\uffff\x02\x02\x03\uffff\x0b\x02",
            "",
            ""
    };

    static readonly short[] DFA142_eot = DFA.UnpackEncodedString(DFA142_eotS);
    static readonly short[] DFA142_eof = DFA.UnpackEncodedString(DFA142_eofS);
    static readonly char[] DFA142_min = DFA.UnpackEncodedStringToUnsignedChars(DFA142_minS);
    static readonly char[] DFA142_max = DFA.UnpackEncodedStringToUnsignedChars(DFA142_maxS);
    static readonly short[] DFA142_accept = DFA.UnpackEncodedString(DFA142_acceptS);
    static readonly short[] DFA142_special = DFA.UnpackEncodedString(DFA142_specialS);
    static readonly short[][] DFA142_transition = DFA.UnpackEncodedStringArray(DFA142_transitionS);

    protected class DFA142 : DFA
    {
        public DFA142(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 142;
            this.eot = DFA142_eot;
            this.eof = DFA142_eof;
            this.min = DFA142_min;
            this.max = DFA142_max;
            this.accept = DFA142_accept;
            this.special = DFA142_special;
            this.transition = DFA142_transition;

        }

        override public string Description
        {
            get { return "246:8: ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )?"; }
        }

    }

    const string DFA141_eotS =
        "\x04\uffff";
    const string DFA141_eofS =
        "\x04\uffff";
    const string DFA141_minS =
        "\x02\x04\x02\uffff";
    const string DFA141_maxS =
        "\x02\x22\x02\uffff";
    const string DFA141_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA141_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA141_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x01\x02",
            "\x01\x01\x1c\uffff\x01\x03\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA141_eot = DFA.UnpackEncodedString(DFA141_eotS);
    static readonly short[] DFA141_eof = DFA.UnpackEncodedString(DFA141_eofS);
    static readonly char[] DFA141_min = DFA.UnpackEncodedStringToUnsignedChars(DFA141_minS);
    static readonly char[] DFA141_max = DFA.UnpackEncodedStringToUnsignedChars(DFA141_maxS);
    static readonly short[] DFA141_accept = DFA.UnpackEncodedString(DFA141_acceptS);
    static readonly short[] DFA141_special = DFA.UnpackEncodedString(DFA141_specialS);
    static readonly short[][] DFA141_transition = DFA.UnpackEncodedStringArray(DFA141_transitionS);

    protected class DFA141 : DFA
    {
        public DFA141(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 141;
            this.eot = DFA141_eot;
            this.eof = DFA141_eof;
            this.min = DFA141_min;
            this.max = DFA141_max;
            this.accept = DFA141_accept;
            this.special = DFA141_special;
            this.transition = DFA141_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 246:35: ( ( LT )* ',' ( LT )* assignmentExpression )*"; }
        }

    }

    const string DFA151_eotS =
        "\x05\uffff";
    const string DFA151_eofS =
        "\x02\x03\x02\uffff\x01\x03";
    const string DFA151_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA151_maxS =
        "\x01\x49\x01\x6a\x02\uffff\x01\x6a";
    const string DFA151_acceptS =
        "\x02\uffff\x01\x01\x01\x02\x01\uffff";
    const string DFA151_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA151_transitionS = {
            "\x01\x01\x1c\uffff\x02\x03\x01\uffff\x01\x03\x01\uffff\x01"+
            "\x03\x0b\uffff\x01\x03\x09\uffff\x01\x03\x0c\uffff\x01\x02",
            "\x01\x04\x03\x03\x17\uffff\x08\x03\x01\uffff\x05\x03\x01\uffff"+
            "\x0a\x03\x02\uffff\x03\x03\x0c\uffff\x01\x02\x11\uffff\x02\x03"+
            "\x03\uffff\x0b\x03",
            "",
            "",
            "\x01\x04\x03\x03\x17\uffff\x08\x03\x01\uffff\x05\x03\x01\uffff"+
            "\x0a\x03\x02\uffff\x03\x03\x0c\uffff\x01\x02\x11\uffff\x02\x03"+
            "\x03\uffff\x0b\x03"
    };

    static readonly short[] DFA151_eot = DFA.UnpackEncodedString(DFA151_eotS);
    static readonly short[] DFA151_eof = DFA.UnpackEncodedString(DFA151_eofS);
    static readonly char[] DFA151_min = DFA.UnpackEncodedStringToUnsignedChars(DFA151_minS);
    static readonly char[] DFA151_max = DFA.UnpackEncodedStringToUnsignedChars(DFA151_maxS);
    static readonly short[] DFA151_accept = DFA.UnpackEncodedString(DFA151_acceptS);
    static readonly short[] DFA151_special = DFA.UnpackEncodedString(DFA151_specialS);
    static readonly short[][] DFA151_transition = DFA.UnpackEncodedStringArray(DFA151_transitionS);

    protected class DFA151 : DFA
    {
        public DFA151(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 151;
            this.eot = DFA151_eot;
            this.eof = DFA151_eof;
            this.min = DFA151_min;
            this.max = DFA151_max;
            this.accept = DFA151_accept;
            this.special = DFA151_special;
            this.transition = DFA151_transition;

        }

        override public string Description
        {
            get { return "262:24: ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?"; }
        }

    }

    const string DFA156_eotS =
        "\x04\uffff";
    const string DFA156_eofS =
        "\x01\x03\x03\uffff";
    const string DFA156_minS =
        "\x02\x04\x02\uffff";
    const string DFA156_maxS =
        "\x02\x49\x02\uffff";
    const string DFA156_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA156_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA156_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x04\uffff\x01\x03\x06\uffff\x01"+
            "\x03\x04\uffff\x01\x03\x16\uffff\x01\x02",
            "\x01\x01\x1c\uffff\x01\x03\x04\uffff\x01\x03\x06\uffff\x01"+
            "\x03\x04\uffff\x01\x03\x16\uffff\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA156_eot = DFA.UnpackEncodedString(DFA156_eotS);
    static readonly short[] DFA156_eof = DFA.UnpackEncodedString(DFA156_eofS);
    static readonly char[] DFA156_min = DFA.UnpackEncodedStringToUnsignedChars(DFA156_minS);
    static readonly char[] DFA156_max = DFA.UnpackEncodedStringToUnsignedChars(DFA156_maxS);
    static readonly short[] DFA156_accept = DFA.UnpackEncodedString(DFA156_acceptS);
    static readonly short[] DFA156_special = DFA.UnpackEncodedString(DFA156_specialS);
    static readonly short[][] DFA156_transition = DFA.UnpackEncodedStringArray(DFA156_transitionS);

    protected class DFA156 : DFA
    {
        public DFA156(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 156;
            this.eot = DFA156_eot;
            this.eof = DFA156_eof;
            this.min = DFA156_min;
            this.max = DFA156_max;
            this.accept = DFA156_accept;
            this.special = DFA156_special;
            this.transition = DFA156_transition;

        }

        override public string Description
        {
            get { return "266:28: ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?"; }
        }

    }

    const string DFA159_eotS =
        "\x05\uffff";
    const string DFA159_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA159_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA159_maxS =
        "\x01\x4a\x01\x6a\x02\uffff\x01\x6a";
    const string DFA159_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA159_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA159_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x0b\uffff\x01\x02\x09\uffff\x01\x02\x0c\uffff\x01\x02\x01"+
            "\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x01\x02\x01\x03\x10\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x01\x02\x01\x03\x10\uffff"+
            "\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA159_eot = DFA.UnpackEncodedString(DFA159_eotS);
    static readonly short[] DFA159_eof = DFA.UnpackEncodedString(DFA159_eofS);
    static readonly char[] DFA159_min = DFA.UnpackEncodedStringToUnsignedChars(DFA159_minS);
    static readonly char[] DFA159_max = DFA.UnpackEncodedStringToUnsignedChars(DFA159_maxS);
    static readonly short[] DFA159_accept = DFA.UnpackEncodedString(DFA159_acceptS);
    static readonly short[] DFA159_special = DFA.UnpackEncodedString(DFA159_specialS);
    static readonly short[][] DFA159_transition = DFA.UnpackEncodedStringArray(DFA159_transitionS);

    protected class DFA159 : DFA
    {
        public DFA159(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 159;
            this.eot = DFA159_eot;
            this.eof = DFA159_eof;
            this.min = DFA159_min;
            this.max = DFA159_max;
            this.accept = DFA159_accept;
            this.special = DFA159_special;
            this.transition = DFA159_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 270:25: ( ( LT )* '||' ( LT )* logicalANDExpression )*"; }
        }

    }

    const string DFA162_eotS =
        "\x04\uffff";
    const string DFA162_eofS =
        "\x01\x02\x03\uffff";
    const string DFA162_minS =
        "\x02\x04\x02\uffff";
    const string DFA162_maxS =
        "\x02\x4a\x02\uffff";
    const string DFA162_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA162_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA162_transitionS = {
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x01\x02\x01\x03",
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x01\x02\x01\x03",
            "",
            ""
    };

    static readonly short[] DFA162_eot = DFA.UnpackEncodedString(DFA162_eotS);
    static readonly short[] DFA162_eof = DFA.UnpackEncodedString(DFA162_eofS);
    static readonly char[] DFA162_min = DFA.UnpackEncodedStringToUnsignedChars(DFA162_minS);
    static readonly char[] DFA162_max = DFA.UnpackEncodedStringToUnsignedChars(DFA162_maxS);
    static readonly short[] DFA162_accept = DFA.UnpackEncodedString(DFA162_acceptS);
    static readonly short[] DFA162_special = DFA.UnpackEncodedString(DFA162_specialS);
    static readonly short[][] DFA162_transition = DFA.UnpackEncodedStringArray(DFA162_transitionS);

    protected class DFA162 : DFA
    {
        public DFA162(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 162;
            this.eot = DFA162_eot;
            this.eof = DFA162_eof;
            this.min = DFA162_min;
            this.max = DFA162_max;
            this.accept = DFA162_accept;
            this.special = DFA162_special;
            this.transition = DFA162_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 274:29: ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*"; }
        }

    }

    const string DFA165_eotS =
        "\x05\uffff";
    const string DFA165_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA165_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA165_maxS =
        "\x01\x4b\x01\x6a\x02\uffff\x01\x6a";
    const string DFA165_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA165_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA165_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x0b\uffff\x01\x02\x09\uffff\x01\x02\x0c\uffff\x02\x02\x01"+
            "\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x02\x02\x01\x03\x0f\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x02\x02\x01\x03\x0f\uffff"+
            "\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA165_eot = DFA.UnpackEncodedString(DFA165_eotS);
    static readonly short[] DFA165_eof = DFA.UnpackEncodedString(DFA165_eofS);
    static readonly char[] DFA165_min = DFA.UnpackEncodedStringToUnsignedChars(DFA165_minS);
    static readonly char[] DFA165_max = DFA.UnpackEncodedStringToUnsignedChars(DFA165_maxS);
    static readonly short[] DFA165_accept = DFA.UnpackEncodedString(DFA165_acceptS);
    static readonly short[] DFA165_special = DFA.UnpackEncodedString(DFA165_specialS);
    static readonly short[][] DFA165_transition = DFA.UnpackEncodedStringArray(DFA165_transitionS);

    protected class DFA165 : DFA
    {
        public DFA165(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 165;
            this.eot = DFA165_eot;
            this.eof = DFA165_eof;
            this.min = DFA165_min;
            this.max = DFA165_max;
            this.accept = DFA165_accept;
            this.special = DFA165_special;
            this.transition = DFA165_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 278:24: ( ( LT )* '&&' ( LT )* bitwiseORExpression )*"; }
        }

    }

    const string DFA168_eotS =
        "\x04\uffff";
    const string DFA168_eofS =
        "\x01\x02\x03\uffff";
    const string DFA168_minS =
        "\x02\x04\x02\uffff";
    const string DFA168_maxS =
        "\x02\x4b\x02\uffff";
    const string DFA168_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA168_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA168_transitionS = {
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x02\x02\x01\x03",
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x02\x02\x01\x03",
            "",
            ""
    };

    static readonly short[] DFA168_eot = DFA.UnpackEncodedString(DFA168_eotS);
    static readonly short[] DFA168_eof = DFA.UnpackEncodedString(DFA168_eofS);
    static readonly char[] DFA168_min = DFA.UnpackEncodedStringToUnsignedChars(DFA168_minS);
    static readonly char[] DFA168_max = DFA.UnpackEncodedStringToUnsignedChars(DFA168_maxS);
    static readonly short[] DFA168_accept = DFA.UnpackEncodedString(DFA168_acceptS);
    static readonly short[] DFA168_special = DFA.UnpackEncodedString(DFA168_specialS);
    static readonly short[][] DFA168_transition = DFA.UnpackEncodedStringArray(DFA168_transitionS);

    protected class DFA168 : DFA
    {
        public DFA168(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 168;
            this.eot = DFA168_eot;
            this.eof = DFA168_eof;
            this.min = DFA168_min;
            this.max = DFA168_max;
            this.accept = DFA168_accept;
            this.special = DFA168_special;
            this.transition = DFA168_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 282:28: ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*"; }
        }

    }

    const string DFA171_eotS =
        "\x05\uffff";
    const string DFA171_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA171_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA171_maxS =
        "\x01\x4c\x01\x6a\x02\uffff\x01\x6a";
    const string DFA171_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA171_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA171_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x0b\uffff\x01\x02\x09\uffff\x01\x02\x0c\uffff\x03\x02\x01"+
            "\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x03\x02\x01\x03\x0e\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x03\x02\x01\x03\x0e\uffff"+
            "\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA171_eot = DFA.UnpackEncodedString(DFA171_eotS);
    static readonly short[] DFA171_eof = DFA.UnpackEncodedString(DFA171_eofS);
    static readonly char[] DFA171_min = DFA.UnpackEncodedStringToUnsignedChars(DFA171_minS);
    static readonly char[] DFA171_max = DFA.UnpackEncodedStringToUnsignedChars(DFA171_maxS);
    static readonly short[] DFA171_accept = DFA.UnpackEncodedString(DFA171_acceptS);
    static readonly short[] DFA171_special = DFA.UnpackEncodedString(DFA171_specialS);
    static readonly short[][] DFA171_transition = DFA.UnpackEncodedStringArray(DFA171_transitionS);

    protected class DFA171 : DFA
    {
        public DFA171(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 171;
            this.eot = DFA171_eot;
            this.eof = DFA171_eof;
            this.min = DFA171_min;
            this.max = DFA171_max;
            this.accept = DFA171_accept;
            this.special = DFA171_special;
            this.transition = DFA171_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 286:25: ( ( LT )* '|' ( LT )* bitwiseXORExpression )*"; }
        }

    }

    const string DFA174_eotS =
        "\x04\uffff";
    const string DFA174_eofS =
        "\x01\x02\x03\uffff";
    const string DFA174_minS =
        "\x02\x04\x02\uffff";
    const string DFA174_maxS =
        "\x02\x4c\x02\uffff";
    const string DFA174_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA174_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA174_transitionS = {
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x03\x02\x01\x03",
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x03\x02\x01\x03",
            "",
            ""
    };

    static readonly short[] DFA174_eot = DFA.UnpackEncodedString(DFA174_eotS);
    static readonly short[] DFA174_eof = DFA.UnpackEncodedString(DFA174_eofS);
    static readonly char[] DFA174_min = DFA.UnpackEncodedStringToUnsignedChars(DFA174_minS);
    static readonly char[] DFA174_max = DFA.UnpackEncodedStringToUnsignedChars(DFA174_maxS);
    static readonly short[] DFA174_accept = DFA.UnpackEncodedString(DFA174_acceptS);
    static readonly short[] DFA174_special = DFA.UnpackEncodedString(DFA174_specialS);
    static readonly short[][] DFA174_transition = DFA.UnpackEncodedStringArray(DFA174_transitionS);

    protected class DFA174 : DFA
    {
        public DFA174(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 174;
            this.eot = DFA174_eot;
            this.eof = DFA174_eof;
            this.min = DFA174_min;
            this.max = DFA174_max;
            this.accept = DFA174_accept;
            this.special = DFA174_special;
            this.transition = DFA174_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 290:29: ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*"; }
        }

    }

    const string DFA177_eotS =
        "\x05\uffff";
    const string DFA177_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA177_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA177_maxS =
        "\x01\x4d\x01\x6a\x02\uffff\x01\x6a";
    const string DFA177_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA177_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA177_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x0b\uffff\x01\x02\x09\uffff\x01\x02\x0c\uffff\x04\x02\x01"+
            "\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x04\x02\x01\x03\x0d\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x04\x02\x01\x03\x0d\uffff"+
            "\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA177_eot = DFA.UnpackEncodedString(DFA177_eotS);
    static readonly short[] DFA177_eof = DFA.UnpackEncodedString(DFA177_eofS);
    static readonly char[] DFA177_min = DFA.UnpackEncodedStringToUnsignedChars(DFA177_minS);
    static readonly char[] DFA177_max = DFA.UnpackEncodedStringToUnsignedChars(DFA177_maxS);
    static readonly short[] DFA177_accept = DFA.UnpackEncodedString(DFA177_acceptS);
    static readonly short[] DFA177_special = DFA.UnpackEncodedString(DFA177_specialS);
    static readonly short[][] DFA177_transition = DFA.UnpackEncodedStringArray(DFA177_transitionS);

    protected class DFA177 : DFA
    {
        public DFA177(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 177;
            this.eot = DFA177_eot;
            this.eof = DFA177_eof;
            this.min = DFA177_min;
            this.max = DFA177_max;
            this.accept = DFA177_accept;
            this.special = DFA177_special;
            this.transition = DFA177_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 294:25: ( ( LT )* '^' ( LT )* bitwiseANDExpression )*"; }
        }

    }

    const string DFA180_eotS =
        "\x04\uffff";
    const string DFA180_eofS =
        "\x01\x02\x03\uffff";
    const string DFA180_minS =
        "\x02\x04\x02\uffff";
    const string DFA180_maxS =
        "\x02\x4d\x02\uffff";
    const string DFA180_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA180_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA180_transitionS = {
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x04\x02\x01\x03",
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x04\x02\x01\x03",
            "",
            ""
    };

    static readonly short[] DFA180_eot = DFA.UnpackEncodedString(DFA180_eotS);
    static readonly short[] DFA180_eof = DFA.UnpackEncodedString(DFA180_eofS);
    static readonly char[] DFA180_min = DFA.UnpackEncodedStringToUnsignedChars(DFA180_minS);
    static readonly char[] DFA180_max = DFA.UnpackEncodedStringToUnsignedChars(DFA180_maxS);
    static readonly short[] DFA180_accept = DFA.UnpackEncodedString(DFA180_acceptS);
    static readonly short[] DFA180_special = DFA.UnpackEncodedString(DFA180_specialS);
    static readonly short[][] DFA180_transition = DFA.UnpackEncodedStringArray(DFA180_transitionS);

    protected class DFA180 : DFA
    {
        public DFA180(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 180;
            this.eot = DFA180_eot;
            this.eof = DFA180_eof;
            this.min = DFA180_min;
            this.max = DFA180_max;
            this.accept = DFA180_accept;
            this.special = DFA180_special;
            this.transition = DFA180_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 298:29: ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*"; }
        }

    }

    const string DFA183_eotS =
        "\x05\uffff";
    const string DFA183_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA183_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA183_maxS =
        "\x01\x4e\x01\x6a\x02\uffff\x01\x6a";
    const string DFA183_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA183_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA183_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x0b\uffff\x01\x02\x09\uffff\x01\x02\x0c\uffff\x05\x02\x01"+
            "\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x05\x02\x01\x03\x0c\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x05\x02\x01\x03\x0c\uffff"+
            "\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA183_eot = DFA.UnpackEncodedString(DFA183_eotS);
    static readonly short[] DFA183_eof = DFA.UnpackEncodedString(DFA183_eofS);
    static readonly char[] DFA183_min = DFA.UnpackEncodedStringToUnsignedChars(DFA183_minS);
    static readonly char[] DFA183_max = DFA.UnpackEncodedStringToUnsignedChars(DFA183_maxS);
    static readonly short[] DFA183_accept = DFA.UnpackEncodedString(DFA183_acceptS);
    static readonly short[] DFA183_special = DFA.UnpackEncodedString(DFA183_specialS);
    static readonly short[][] DFA183_transition = DFA.UnpackEncodedStringArray(DFA183_transitionS);

    protected class DFA183 : DFA
    {
        public DFA183(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 183;
            this.eot = DFA183_eot;
            this.eof = DFA183_eof;
            this.min = DFA183_min;
            this.max = DFA183_max;
            this.accept = DFA183_accept;
            this.special = DFA183_special;
            this.transition = DFA183_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 302:23: ( ( LT )* '&' ( LT )* equalityExpression )*"; }
        }

    }

    const string DFA186_eotS =
        "\x04\uffff";
    const string DFA186_eofS =
        "\x01\x02\x03\uffff";
    const string DFA186_minS =
        "\x02\x04\x02\uffff";
    const string DFA186_maxS =
        "\x02\x4e\x02\uffff";
    const string DFA186_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA186_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA186_transitionS = {
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x05\x02\x01\x03",
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x05\x02\x01\x03",
            "",
            ""
    };

    static readonly short[] DFA186_eot = DFA.UnpackEncodedString(DFA186_eotS);
    static readonly short[] DFA186_eof = DFA.UnpackEncodedString(DFA186_eofS);
    static readonly char[] DFA186_min = DFA.UnpackEncodedStringToUnsignedChars(DFA186_minS);
    static readonly char[] DFA186_max = DFA.UnpackEncodedStringToUnsignedChars(DFA186_maxS);
    static readonly short[] DFA186_accept = DFA.UnpackEncodedString(DFA186_acceptS);
    static readonly short[] DFA186_special = DFA.UnpackEncodedString(DFA186_specialS);
    static readonly short[][] DFA186_transition = DFA.UnpackEncodedStringArray(DFA186_transitionS);

    protected class DFA186 : DFA
    {
        public DFA186(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 186;
            this.eot = DFA186_eot;
            this.eof = DFA186_eof;
            this.min = DFA186_min;
            this.max = DFA186_max;
            this.accept = DFA186_accept;
            this.special = DFA186_special;
            this.transition = DFA186_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 306:27: ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*"; }
        }

    }

    const string DFA189_eotS =
        "\x05\uffff";
    const string DFA189_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA189_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA189_maxS =
        "\x01\x52\x01\x6a\x02\uffff\x01\x6a";
    const string DFA189_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA189_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA189_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x0b\uffff\x01\x02\x09\uffff\x01\x02\x0c\uffff\x06\x02\x04"+
            "\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x06\x02\x04\x03\x08\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\uffff"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x06\x02\x04\x03\x08\uffff"+
            "\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA189_eot = DFA.UnpackEncodedString(DFA189_eotS);
    static readonly short[] DFA189_eof = DFA.UnpackEncodedString(DFA189_eofS);
    static readonly char[] DFA189_min = DFA.UnpackEncodedStringToUnsignedChars(DFA189_minS);
    static readonly char[] DFA189_max = DFA.UnpackEncodedStringToUnsignedChars(DFA189_maxS);
    static readonly short[] DFA189_accept = DFA.UnpackEncodedString(DFA189_acceptS);
    static readonly short[] DFA189_special = DFA.UnpackEncodedString(DFA189_specialS);
    static readonly short[][] DFA189_transition = DFA.UnpackEncodedStringArray(DFA189_transitionS);

    protected class DFA189 : DFA
    {
        public DFA189(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 189;
            this.eot = DFA189_eot;
            this.eof = DFA189_eof;
            this.min = DFA189_min;
            this.max = DFA189_max;
            this.accept = DFA189_accept;
            this.special = DFA189_special;
            this.transition = DFA189_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 310:25: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*"; }
        }

    }

    const string DFA192_eotS =
        "\x04\uffff";
    const string DFA192_eofS =
        "\x01\x02\x03\uffff";
    const string DFA192_minS =
        "\x02\x04\x02\uffff";
    const string DFA192_maxS =
        "\x02\x52\x02\uffff";
    const string DFA192_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA192_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA192_transitionS = {
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x06\x02\x04\x03",
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x06\x02\x04\x03",
            "",
            ""
    };

    static readonly short[] DFA192_eot = DFA.UnpackEncodedString(DFA192_eotS);
    static readonly short[] DFA192_eof = DFA.UnpackEncodedString(DFA192_eofS);
    static readonly char[] DFA192_min = DFA.UnpackEncodedStringToUnsignedChars(DFA192_minS);
    static readonly char[] DFA192_max = DFA.UnpackEncodedStringToUnsignedChars(DFA192_maxS);
    static readonly short[] DFA192_accept = DFA.UnpackEncodedString(DFA192_acceptS);
    static readonly short[] DFA192_special = DFA.UnpackEncodedString(DFA192_specialS);
    static readonly short[][] DFA192_transition = DFA.UnpackEncodedStringArray(DFA192_transitionS);

    protected class DFA192 : DFA
    {
        public DFA192(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 192;
            this.eot = DFA192_eot;
            this.eof = DFA192_eof;
            this.min = DFA192_min;
            this.max = DFA192_max;
            this.accept = DFA192_accept;
            this.special = DFA192_special;
            this.transition = DFA192_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 314:29: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*"; }
        }

    }

    const string DFA195_eotS =
        "\x05\uffff";
    const string DFA195_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA195_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA195_maxS =
        "\x01\x57\x01\x6a\x02\uffff\x01\x6a";
    const string DFA195_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA195_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA195_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x06\uffff\x01\x03\x04\uffff\x01\x02\x09\uffff\x01\x02\x0c"+
            "\uffff\x0a\x02\x05\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\x03"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x0a\x02\x05\x03\x03\uffff"+
            "\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x05\x02\x01\x03"+
            "\x0a\x02\x02\uffff\x03\x02\x0c\uffff\x0a\x02\x05\x03\x03\uffff"+
            "\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA195_eot = DFA.UnpackEncodedString(DFA195_eotS);
    static readonly short[] DFA195_eof = DFA.UnpackEncodedString(DFA195_eofS);
    static readonly char[] DFA195_min = DFA.UnpackEncodedStringToUnsignedChars(DFA195_minS);
    static readonly char[] DFA195_max = DFA.UnpackEncodedStringToUnsignedChars(DFA195_maxS);
    static readonly short[] DFA195_accept = DFA.UnpackEncodedString(DFA195_acceptS);
    static readonly short[] DFA195_special = DFA.UnpackEncodedString(DFA195_specialS);
    static readonly short[][] DFA195_transition = DFA.UnpackEncodedStringArray(DFA195_transitionS);

    protected class DFA195 : DFA
    {
        public DFA195(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 195;
            this.eot = DFA195_eot;
            this.eof = DFA195_eof;
            this.min = DFA195_min;
            this.max = DFA195_max;
            this.accept = DFA195_accept;
            this.special = DFA195_special;
            this.transition = DFA195_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 318:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*"; }
        }

    }

    const string DFA198_eotS =
        "\x04\uffff";
    const string DFA198_eofS =
        "\x01\x02\x03\uffff";
    const string DFA198_minS =
        "\x02\x04\x02\uffff";
    const string DFA198_maxS =
        "\x02\x57\x02\uffff";
    const string DFA198_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA198_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA198_transitionS = {
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x0a\x02\x05\x03",
            "\x01\x01\x1c\uffff\x01\x02\x04\uffff\x01\x02\x06\uffff\x01"+
            "\x02\x04\uffff\x01\x02\x16\uffff\x0a\x02\x05\x03",
            "",
            ""
    };

    static readonly short[] DFA198_eot = DFA.UnpackEncodedString(DFA198_eotS);
    static readonly short[] DFA198_eof = DFA.UnpackEncodedString(DFA198_eofS);
    static readonly char[] DFA198_min = DFA.UnpackEncodedStringToUnsignedChars(DFA198_minS);
    static readonly char[] DFA198_max = DFA.UnpackEncodedStringToUnsignedChars(DFA198_maxS);
    static readonly short[] DFA198_accept = DFA.UnpackEncodedString(DFA198_acceptS);
    static readonly short[] DFA198_special = DFA.UnpackEncodedString(DFA198_specialS);
    static readonly short[][] DFA198_transition = DFA.UnpackEncodedStringArray(DFA198_transitionS);

    protected class DFA198 : DFA
    {
        public DFA198(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 198;
            this.eot = DFA198_eot;
            this.eof = DFA198_eof;
            this.min = DFA198_min;
            this.max = DFA198_max;
            this.accept = DFA198_accept;
            this.special = DFA198_special;
            this.transition = DFA198_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 322:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*"; }
        }

    }

    const string DFA201_eotS =
        "\x05\uffff";
    const string DFA201_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA201_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA201_maxS =
        "\x01\x5a\x01\x6a\x02\uffff\x01\x6a";
    const string DFA201_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA201_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA201_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x06\uffff\x01\x02\x04\uffff\x01\x02\x09\uffff\x01\x02\x0c"+
            "\uffff\x0f\x02\x03\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x10\x02\x02\uffff"+
            "\x03\x02\x0c\uffff\x0f\x02\x03\x03\x02\x02\x03\uffff\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x10\x02\x02\uffff"+
            "\x03\x02\x0c\uffff\x0f\x02\x03\x03\x02\x02\x03\uffff\x0b\x02"
    };

    static readonly short[] DFA201_eot = DFA.UnpackEncodedString(DFA201_eotS);
    static readonly short[] DFA201_eof = DFA.UnpackEncodedString(DFA201_eofS);
    static readonly char[] DFA201_min = DFA.UnpackEncodedStringToUnsignedChars(DFA201_minS);
    static readonly char[] DFA201_max = DFA.UnpackEncodedStringToUnsignedChars(DFA201_maxS);
    static readonly short[] DFA201_accept = DFA.UnpackEncodedString(DFA201_acceptS);
    static readonly short[] DFA201_special = DFA.UnpackEncodedString(DFA201_specialS);
    static readonly short[][] DFA201_transition = DFA.UnpackEncodedStringArray(DFA201_transitionS);

    protected class DFA201 : DFA
    {
        public DFA201(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 201;
            this.eot = DFA201_eot;
            this.eof = DFA201_eof;
            this.min = DFA201_min;
            this.max = DFA201_max;
            this.accept = DFA201_accept;
            this.special = DFA201_special;
            this.transition = DFA201_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 326:23: ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*"; }
        }

    }

    const string DFA204_eotS =
        "\x14\uffff";
    const string DFA204_eofS =
        "\x01\x02\x13\uffff";
    const string DFA204_minS =
        "\x01\x04\x01\x00\x12\uffff";
    const string DFA204_maxS =
        "\x01\x5c\x01\x00\x12\uffff";
    const string DFA204_acceptS =
        "\x02\uffff\x01\x02\x10\uffff\x01\x01";
    const string DFA204_specialS =
        "\x01\uffff\x01\x00\x12\uffff}>";
    static readonly string[] DFA204_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x06\uffff\x01\x02\x04\uffff\x01\x02\x09\uffff\x01\x02\x0c"+
            "\uffff\x12\x02\x02\x13",
            "\x01\uffff",
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

    static readonly short[] DFA204_eot = DFA.UnpackEncodedString(DFA204_eotS);
    static readonly short[] DFA204_eof = DFA.UnpackEncodedString(DFA204_eofS);
    static readonly char[] DFA204_min = DFA.UnpackEncodedStringToUnsignedChars(DFA204_minS);
    static readonly char[] DFA204_max = DFA.UnpackEncodedStringToUnsignedChars(DFA204_maxS);
    static readonly short[] DFA204_accept = DFA.UnpackEncodedString(DFA204_acceptS);
    static readonly short[] DFA204_special = DFA.UnpackEncodedString(DFA204_specialS);
    static readonly short[][] DFA204_transition = DFA.UnpackEncodedStringArray(DFA204_transitionS);

    protected class DFA204 : DFA
    {
        public DFA204(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 204;
            this.eot = DFA204_eot;
            this.eof = DFA204_eof;
            this.min = DFA204_min;
            this.max = DFA204_max;
            this.accept = DFA204_accept;
            this.special = DFA204_special;
            this.transition = DFA204_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 330:29: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*"; }
        }

    }


    protected internal int DFA204_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA204_1 = input.LA(1);

                   	 
                   	int index204_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred256_JavaScript()) ) { s = 19; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index204_1);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae204 =
            new NoViableAltException(dfa.Description, 204, _s, input);
        dfa.Error(nvae204);
        throw nvae204;
    }
    const string DFA207_eotS =
        "\x05\uffff";
    const string DFA207_eofS =
        "\x02\x02\x02\uffff\x01\x02";
    const string DFA207_minS =
        "\x02\x04\x02\uffff\x01\x04";
    const string DFA207_maxS =
        "\x01\x5f\x01\x6a\x02\uffff\x01\x6a";
    const string DFA207_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff";
    const string DFA207_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA207_transitionS = {
            "\x01\x01\x1c\uffff\x02\x02\x01\uffff\x01\x02\x01\uffff\x01"+
            "\x02\x06\uffff\x01\x02\x04\uffff\x01\x02\x09\uffff\x01\x02\x0c"+
            "\uffff\x14\x02\x03\x03",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x10\x02\x02\uffff"+
            "\x03\x02\x0c\uffff\x14\x02\x03\x03\x0b\x02",
            "",
            "",
            "\x01\x04\x03\x02\x17\uffff\x08\x02\x01\uffff\x10\x02\x02\uffff"+
            "\x03\x02\x0c\uffff\x14\x02\x03\x03\x0b\x02"
    };

    static readonly short[] DFA207_eot = DFA.UnpackEncodedString(DFA207_eotS);
    static readonly short[] DFA207_eof = DFA.UnpackEncodedString(DFA207_eofS);
    static readonly char[] DFA207_min = DFA.UnpackEncodedStringToUnsignedChars(DFA207_minS);
    static readonly char[] DFA207_max = DFA.UnpackEncodedStringToUnsignedChars(DFA207_maxS);
    static readonly short[] DFA207_accept = DFA.UnpackEncodedString(DFA207_acceptS);
    static readonly short[] DFA207_special = DFA.UnpackEncodedString(DFA207_specialS);
    static readonly short[][] DFA207_transition = DFA.UnpackEncodedStringArray(DFA207_transitionS);

    protected class DFA207 : DFA
    {
        public DFA207(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 207;
            this.eot = DFA207_eot;
            this.eof = DFA207_eof;
            this.min = DFA207_min;
            this.max = DFA207_max;
            this.accept = DFA207_accept;
            this.special = DFA207_special;
            this.transition = DFA207_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 334:20: ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*"; }
        }

    }

    const string DFA218_eotS =
        "\x04\uffff";
    const string DFA218_eofS =
        "\x04\uffff";
    const string DFA218_minS =
        "\x02\x04\x02\uffff";
    const string DFA218_maxS =
        "\x02\x3c\x02\uffff";
    const string DFA218_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA218_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA218_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x1a\uffff\x01\x02",
            "\x01\x01\x1c\uffff\x01\x03\x1a\uffff\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA218_eot = DFA.UnpackEncodedString(DFA218_eotS);
    static readonly short[] DFA218_eof = DFA.UnpackEncodedString(DFA218_eofS);
    static readonly char[] DFA218_min = DFA.UnpackEncodedStringToUnsignedChars(DFA218_minS);
    static readonly char[] DFA218_max = DFA.UnpackEncodedStringToUnsignedChars(DFA218_maxS);
    static readonly short[] DFA218_accept = DFA.UnpackEncodedString(DFA218_acceptS);
    static readonly short[] DFA218_special = DFA.UnpackEncodedString(DFA218_specialS);
    static readonly short[][] DFA218_transition = DFA.UnpackEncodedStringArray(DFA218_transitionS);

    protected class DFA218 : DFA
    {
        public DFA218(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 218;
            this.eot = DFA218_eot;
            this.eof = DFA218_eof;
            this.min = DFA218_min;
            this.max = DFA218_max;
            this.accept = DFA218_accept;
            this.special = DFA218_special;
            this.transition = DFA218_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 357:35: ( ( LT )* ',' ( ( LT )* assignmentExpression )? )*"; }
        }

    }

    const string DFA217_eotS =
        "\x04\uffff";
    const string DFA217_eofS =
        "\x04\uffff";
    const string DFA217_minS =
        "\x02\x04\x02\uffff";
    const string DFA217_maxS =
        "\x02\x6a\x02\uffff";
    const string DFA217_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA217_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA217_transitionS = {
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x01\x03\x01\uffff\x01\x02"+
            "\x16\uffff\x02\x02\x01\x03\x1e\uffff\x02\x02\x03\uffff\x0b\x02",
            "\x01\x01\x03\x02\x17\uffff\x02\x02\x01\x03\x01\uffff\x01\x02"+
            "\x16\uffff\x02\x02\x01\x03\x1e\uffff\x02\x02\x03\uffff\x0b\x02",
            "",
            ""
    };

    static readonly short[] DFA217_eot = DFA.UnpackEncodedString(DFA217_eotS);
    static readonly short[] DFA217_eof = DFA.UnpackEncodedString(DFA217_eofS);
    static readonly char[] DFA217_min = DFA.UnpackEncodedStringToUnsignedChars(DFA217_minS);
    static readonly char[] DFA217_max = DFA.UnpackEncodedStringToUnsignedChars(DFA217_maxS);
    static readonly short[] DFA217_accept = DFA.UnpackEncodedString(DFA217_acceptS);
    static readonly short[] DFA217_special = DFA.UnpackEncodedString(DFA217_specialS);
    static readonly short[][] DFA217_transition = DFA.UnpackEncodedStringArray(DFA217_transitionS);

    protected class DFA217 : DFA
    {
        public DFA217(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 217;
            this.eot = DFA217_eot;
            this.eof = DFA217_eof;
            this.min = DFA217_min;
            this.max = DFA217_max;
            this.accept = DFA217_accept;
            this.special = DFA217_special;
            this.transition = DFA217_transition;

        }

        override public string Description
        {
            get { return "357:45: ( ( LT )* assignmentExpression )?"; }
        }

    }

    const string DFA223_eotS =
        "\x04\uffff";
    const string DFA223_eofS =
        "\x04\uffff";
    const string DFA223_minS =
        "\x02\x04\x02\uffff";
    const string DFA223_maxS =
        "\x02\x24\x02\uffff";
    const string DFA223_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA223_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA223_transitionS = {
            "\x01\x01\x1c\uffff\x01\x03\x02\uffff\x01\x02",
            "\x01\x01\x1c\uffff\x01\x03\x02\uffff\x01\x02",
            "",
            ""
    };

    static readonly short[] DFA223_eot = DFA.UnpackEncodedString(DFA223_eotS);
    static readonly short[] DFA223_eof = DFA.UnpackEncodedString(DFA223_eofS);
    static readonly char[] DFA223_min = DFA.UnpackEncodedStringToUnsignedChars(DFA223_minS);
    static readonly char[] DFA223_max = DFA.UnpackEncodedStringToUnsignedChars(DFA223_maxS);
    static readonly short[] DFA223_accept = DFA.UnpackEncodedString(DFA223_acceptS);
    static readonly short[] DFA223_special = DFA.UnpackEncodedString(DFA223_specialS);
    static readonly short[][] DFA223_transition = DFA.UnpackEncodedStringArray(DFA223_transitionS);

    protected class DFA223 : DFA
    {
        public DFA223(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 223;
            this.eot = DFA223_eot;
            this.eof = DFA223_eof;
            this.min = DFA223_min;
            this.max = DFA223_max;
            this.accept = DFA223_accept;
            this.special = DFA223_special;
            this.transition = DFA223_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 362:34: ( ( LT )* ',' ( LT )* propertyNameAndValue )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_LT_in_program43 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_sourceElements_in_program47 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_program49 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_EOF_in_program53 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sourceElement_in_sourceElements66 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_sourceElements69 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_sourceElement_in_sourceElements73 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_functionDeclaration_in_sourceElement87 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statement_in_sourceElement92 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_31_in_functionDeclaration105 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_functionDeclaration107 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_functionDeclaration111 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionDeclaration113 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_formalParameterList_in_functionDeclaration117 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionDeclaration119 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_functionBody_in_functionDeclaration123 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_31_in_functionExpression135 = new BitSet(new ulong[]{0x0000000100000030UL});
    public static readonly BitSet FOLLOW_LT_in_functionExpression137 = new BitSet(new ulong[]{0x0000000100000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_functionExpression141 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionExpression144 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_formalParameterList_in_functionExpression148 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionExpression150 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_functionBody_in_functionExpression154 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_formalParameterList166 = new BitSet(new ulong[]{0x0000000400000030UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList169 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_formalParameterList173 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList176 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_formalParameterList180 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList182 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_formalParameterList186 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList192 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_formalParameterList196 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_functionBody207 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_functionBody209 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_sourceElements_in_functionBody213 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionBody215 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_functionBody219 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statementBlock_in_statement231 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variableStatement_in_statement236 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_emptyStatement_in_statement241 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expressionStatement_in_statement246 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ifStatement_in_statement251 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_iterationStatement_in_statement256 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_continueStatement_in_statement261 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_breakStatement_in_statement266 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_returnStatement_in_statement271 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_withStatement_in_statement276 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_labelledStatement_in_statement281 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_switchStatement_in_statement286 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_throwStatement_in_statement291 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_tryStatement_in_statement296 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_statementBlock308 = new BitSet(new ulong[]{0x0CCBDD79800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_statementBlock310 = new BitSet(new ulong[]{0x0CCBDD79800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statementList_in_statementBlock314 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_statementBlock317 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_statementBlock321 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statement_in_statementList333 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_statementList336 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_statementList340 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_37_in_variableStatement354 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_variableStatement356 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationList_in_variableStatement360 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_variableStatement362 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variableDeclaration_in_variableDeclarationList380 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationList383 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_variableDeclarationList387 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationList389 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclaration_in_variableDeclarationList393 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn407 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationListNoIn410 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_variableDeclarationListNoIn414 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationListNoIn416 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn420 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_Identifier_in_variableDeclaration434 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclaration436 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_initialiser_in_variableDeclaration440 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Identifier_in_variableDeclarationNoIn453 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationNoIn455 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_initialiserNoIn_in_variableDeclarationNoIn459 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_initialiser472 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_initialiser474 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_initialiser478 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_initialiserNoIn490 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_initialiserNoIn492 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_initialiserNoIn496 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_38_in_emptyStatement508 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_expressionStatement520 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_expressionStatement522 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_40_in_ifStatement540 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement542 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_ifStatement546 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement548 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_ifStatement552 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement554 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_ifStatement558 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement560 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_ifStatement564 = new BitSet(new ulong[]{0x0000020000000012UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement567 = new BitSet(new ulong[]{0x0000020000000010UL});
    public static readonly BitSet FOLLOW_41_in_ifStatement571 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement573 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_ifStatement577 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_doWhileStatement_in_iterationStatement591 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_whileStatement_in_iterationStatement596 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forStatement_in_iterationStatement601 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forInStatement_in_iterationStatement606 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_42_in_doWhileStatement618 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_doWhileStatement620 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_doWhileStatement624 = new BitSet(new ulong[]{0x0000080000000010UL});
    public static readonly BitSet FOLLOW_LT_in_doWhileStatement626 = new BitSet(new ulong[]{0x0000080000000010UL});
    public static readonly BitSet FOLLOW_43_in_doWhileStatement630 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_doWhileStatement632 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_doWhileStatement636 = new BitSet(new ulong[]{0x0C000009800000E0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_doWhileStatement638 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_34_in_doWhileStatement640 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_doWhileStatement642 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_43_in_whileStatement660 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement662 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_whileStatement666 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement668 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_whileStatement672 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement674 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_whileStatement678 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement680 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_whileStatement684 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_forStatement696 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement698 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_forStatement702 = new BitSet(new ulong[]{0x0C000069800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement705 = new BitSet(new ulong[]{0x0C000029800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_forStatementInitialiserPart_in_forStatement709 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement713 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_38_in_forStatement717 = new BitSet(new ulong[]{0x0C000049800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement720 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_forStatement724 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement728 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_38_in_forStatement732 = new BitSet(new ulong[]{0x0C00000D800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement735 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_forStatement739 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement743 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_forStatement747 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement749 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_forStatement753 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expressionNoIn_in_forStatementInitialiserPart765 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_37_in_forStatementInitialiserPart770 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_forStatementInitialiserPart772 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationListNoIn_in_forStatementInitialiserPart776 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_forInStatement788 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement790 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_forInStatement794 = new BitSet(new ulong[]{0x0C000029800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement796 = new BitSet(new ulong[]{0x0C000029800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_forInStatementInitialiserPart_in_forInStatement800 = new BitSet(new ulong[]{0x0000200000000010UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement802 = new BitSet(new ulong[]{0x0000200000000010UL});
    public static readonly BitSet FOLLOW_45_in_forInStatement806 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement808 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_forInStatement812 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement814 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_forInStatement818 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement820 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_forInStatement824 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_forInStatementInitialiserPart836 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_37_in_forInStatementInitialiserPart841 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatementInitialiserPart843 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_forInStatementInitialiserPart847 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_46_in_continueStatement858 = new BitSet(new ulong[]{0x0000004000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_continueStatement860 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_continueStatement863 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_47_in_breakStatement880 = new BitSet(new ulong[]{0x0000004000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_breakStatement882 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_breakStatement885 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_returnStatement902 = new BitSet(new ulong[]{0x0C000049800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_returnStatement904 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_returnStatement907 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_49_in_withStatement925 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement927 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_withStatement931 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement933 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_withStatement937 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement939 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_withStatement943 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement945 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_withStatement949 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Identifier_in_labelledStatement960 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_labelledStatement962 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_labelledStatement966 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_labelledStatement968 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_labelledStatement972 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_51_in_switchStatement984 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement986 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_switchStatement990 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement992 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_switchStatement996 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement998 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_switchStatement1002 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement1004 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_caseBlock_in_switchStatement1008 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_caseBlock1020 = new BitSet(new ulong[]{0x0030001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1023 = new BitSet(new ulong[]{0x0010000000000010UL});
    public static readonly BitSet FOLLOW_caseClause_in_caseBlock1027 = new BitSet(new ulong[]{0x0030001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1032 = new BitSet(new ulong[]{0x0020000000000010UL});
    public static readonly BitSet FOLLOW_defaultClause_in_caseBlock1036 = new BitSet(new ulong[]{0x0010001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1039 = new BitSet(new ulong[]{0x0010000000000010UL});
    public static readonly BitSet FOLLOW_caseClause_in_caseBlock1043 = new BitSet(new ulong[]{0x0010001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1049 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_caseBlock1053 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_caseClause1064 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_caseClause1066 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_caseClause1070 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseClause1072 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_caseClause1076 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_caseClause1078 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statementList_in_caseClause1082 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_53_in_defaultClause1095 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_defaultClause1097 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_defaultClause1101 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_defaultClause1103 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statementList_in_defaultClause1107 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_54_in_throwStatement1120 = new BitSet(new ulong[]{0x0C000009800000E0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_throwStatement1122 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_throwStatement1124 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_55_in_tryStatement1141 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_tryStatement1143 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_statementBlock_in_tryStatement1147 = new BitSet(new ulong[]{0x0300000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_tryStatement1149 = new BitSet(new ulong[]{0x0300000000000010UL});
    public static readonly BitSet FOLLOW_finallyClause_in_tryStatement1154 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_catchClause_in_tryStatement1158 = new BitSet(new ulong[]{0x0200000000000012UL});
    public static readonly BitSet FOLLOW_LT_in_tryStatement1161 = new BitSet(new ulong[]{0x0200000000000010UL});
    public static readonly BitSet FOLLOW_finallyClause_in_tryStatement1165 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_56_in_catchClause1186 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1188 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_catchClause1192 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1194 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_catchClause1198 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1200 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_catchClause1204 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1206 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_statementBlock_in_catchClause1210 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_57_in_finallyClause1222 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_finallyClause1224 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_statementBlock_in_finallyClause1228 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_expression1240 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_expression1243 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_expression1247 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_expression1249 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_expression1253 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1267 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_expressionNoIn1270 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_expressionNoIn1274 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_expressionNoIn1276 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1280 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_assignmentExpression1294 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_assignmentExpression1299 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpression1301 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_assignmentOperator_in_assignmentExpression1305 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpression1307 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_assignmentExpression1311 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalExpressionNoIn_in_assignmentExpressionNoIn1323 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_assignmentExpressionNoIn1328 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpressionNoIn1330 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_assignmentOperator_in_assignmentExpressionNoIn1334 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpressionNoIn1336 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_assignmentExpressionNoIn1340 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_callExpression_in_leftHandSideExpression1352 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_newExpression_in_leftHandSideExpression1357 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_memberExpression_in_newExpression1369 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_58_in_newExpression1374 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_LT_in_newExpression1376 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_newExpression_in_newExpression1380 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_primaryExpression_in_memberExpression1393 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_functionExpression_in_memberExpression1397 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_58_in_memberExpression1401 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_LT_in_memberExpression1403 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_memberExpression_in_memberExpression1407 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_memberExpression1409 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_arguments_in_memberExpression1413 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_LT_in_memberExpression1417 = new BitSet(new ulong[]{0x2800000000000010UL});
    public static readonly BitSet FOLLOW_memberExpressionSuffix_in_memberExpression1421 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_indexSuffix_in_memberExpressionSuffix1435 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_propertyReferenceSuffix_in_memberExpressionSuffix1440 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_memberExpression_in_callExpression1451 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_callExpression1453 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_arguments_in_callExpression1457 = new BitSet(new ulong[]{0x2800000100000012UL});
    public static readonly BitSet FOLLOW_LT_in_callExpression1460 = new BitSet(new ulong[]{0x2800000100000010UL});
    public static readonly BitSet FOLLOW_callExpressionSuffix_in_callExpression1464 = new BitSet(new ulong[]{0x2800000100000012UL});
    public static readonly BitSet FOLLOW_arguments_in_callExpressionSuffix1478 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_indexSuffix_in_callExpressionSuffix1483 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_propertyReferenceSuffix_in_callExpressionSuffix1488 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_arguments1499 = new BitSet(new ulong[]{0x0C00000D800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arguments1502 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arguments1506 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_arguments1509 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_arguments1513 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arguments1515 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arguments1519 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_arguments1525 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_arguments1529 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_59_in_indexSuffix1541 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_indexSuffix1543 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_indexSuffix1547 = new BitSet(new ulong[]{0x1000000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_indexSuffix1549 = new BitSet(new ulong[]{0x1000000000000010UL});
    public static readonly BitSet FOLLOW_60_in_indexSuffix1553 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_61_in_propertyReferenceSuffix1566 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_propertyReferenceSuffix1568 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_propertyReferenceSuffix1572 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_assignmentOperator0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalORExpression_in_conditionalExpression1639 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression1642 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_conditionalExpression1646 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression1648 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_conditionalExpression1652 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression1654 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_conditionalExpression1658 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression1660 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_conditionalExpression1664 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalORExpressionNoIn_in_conditionalExpressionNoIn1677 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn1680 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_conditionalExpressionNoIn1684 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn1686 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn1690 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn1692 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_conditionalExpressionNoIn1696 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn1698 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn1702 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalANDExpression_in_logicalORExpression1715 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpression1718 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_logicalORExpression1722 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpression1724 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_logicalANDExpression_in_logicalORExpression1728 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn1742 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpressionNoIn1745 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_logicalORExpressionNoIn1749 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpressionNoIn1751 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn1755 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_bitwiseORExpression_in_logicalANDExpression1769 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpression1772 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_logicalANDExpression1776 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpression1778 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseORExpression_in_logicalANDExpression1782 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1796 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpressionNoIn1799 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_logicalANDExpressionNoIn1803 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpressionNoIn1805 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn1809 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpression_in_bitwiseORExpression1823 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpression1826 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitwiseORExpression1830 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpression1832 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpression_in_bitwiseORExpression1836 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1850 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpressionNoIn1853 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitwiseORExpressionNoIn1857 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpressionNoIn1859 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn1863 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression1877 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpression1880 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitwiseXORExpression1884 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpression1886 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression1890 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1904 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpressionNoIn1907 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitwiseXORExpressionNoIn1911 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpressionNoIn1913 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn1917 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseANDExpression1931 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpression1934 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_78_in_bitwiseANDExpression1938 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpression1940 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseANDExpression1944 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn1958 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpressionNoIn1961 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_78_in_bitwiseANDExpressionNoIn1965 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpressionNoIn1967 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn1971 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression1985 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpression1988 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_set_in_equalityExpression1992 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpression2008 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression2012 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2025 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpressionNoIn2028 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_set_in_equalityExpressionNoIn2032 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpressionNoIn2048 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2052 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression2066 = new BitSet(new ulong[]{0x0000200000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpression2069 = new BitSet(new ulong[]{0x0000200000000010UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_set_in_relationalExpression2073 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpression2097 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression2101 = new BitSet(new ulong[]{0x0000200000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpressionNoIn2114 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpressionNoIn2117 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_set_in_relationalExpressionNoIn2121 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpressionNoIn2141 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpressionNoIn2145 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression2158 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000007000000UL});
    public static readonly BitSet FOLLOW_LT_in_shiftExpression2161 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000007000000UL});
    public static readonly BitSet FOLLOW_set_in_shiftExpression2165 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_shiftExpression2177 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression2181 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000007000000UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression2194 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_LT_in_additiveExpression2197 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_set_in_additiveExpression2201 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_additiveExpression2209 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression2213 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression2226 = new BitSet(new ulong[]{0x0000000000000012UL,0x00000000E0000000UL});
    public static readonly BitSet FOLLOW_LT_in_multiplicativeExpression2229 = new BitSet(new ulong[]{0x0000000000000010UL,0x00000000E0000000UL});
    public static readonly BitSet FOLLOW_set_in_multiplicativeExpression2233 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_multiplicativeExpression2245 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression2249 = new BitSet(new ulong[]{0x0000000000000012UL,0x00000000E0000000UL});
    public static readonly BitSet FOLLOW_postfixExpression_in_unaryExpression2262 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_unaryExpression2267 = new BitSet(new ulong[]{0x0C000009800000E0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression2303 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_postfixExpression2315 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001800000000UL});
    public static readonly BitSet FOLLOW_set_in_postfixExpression2317 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_103_in_primaryExpression2335 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Identifier_in_primaryExpression2340 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_literal_in_primaryExpression2345 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_arrayLiteral_in_primaryExpression2350 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_objectLiteral_in_primaryExpression2355 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_primaryExpression2360 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_primaryExpression2362 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_primaryExpression2366 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_primaryExpression2368 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_primaryExpression2372 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_59_in_arrayLiteral2385 = new BitSet(new ulong[]{0x1C00000B800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral2387 = new BitSet(new ulong[]{0x1C00000B800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arrayLiteral2391 = new BitSet(new ulong[]{0x1000000200000010UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral2395 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_arrayLiteral2399 = new BitSet(new ulong[]{0x1C00000B800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral2402 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arrayLiteral2406 = new BitSet(new ulong[]{0x1000000200000010UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral2412 = new BitSet(new ulong[]{0x1000000000000010UL});
    public static readonly BitSet FOLLOW_60_in_arrayLiteral2416 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_objectLiteral2435 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral2437 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_propertyNameAndValue_in_objectLiteral2441 = new BitSet(new ulong[]{0x0000001200000010UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral2444 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_objectLiteral2448 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral2450 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_propertyNameAndValue_in_objectLiteral2454 = new BitSet(new ulong[]{0x0000001200000010UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral2458 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_objectLiteral2462 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_propertyName_in_propertyNameAndValue2474 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_propertyNameAndValue2476 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_propertyNameAndValue2480 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_propertyNameAndValue2482 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_propertyNameAndValue2486 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_propertyName0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_literal0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_functionDeclaration_in_synpred5_JavaScript87 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred9_JavaScript137 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statementBlock_in_synpred21_JavaScript231 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expressionStatement_in_synpred24_JavaScript246 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_labelledStatement_in_synpred31_JavaScript281 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred34_JavaScript310 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred47_JavaScript436 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred49_JavaScript455 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred60_JavaScript567 = new BitSet(new ulong[]{0x0000020000000010UL});
    public static readonly BitSet FOLLOW_41_in_synpred60_JavaScript571 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_synpred60_JavaScript573 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_synpred60_JavaScript577 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forStatement_in_synpred63_JavaScript601 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred118_JavaScript1078 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred121_JavaScript1103 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_synpred140_JavaScript1294 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalExpressionNoIn_in_synpred143_JavaScript1323 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_callExpression_in_synpred146_JavaScript1352 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_memberExpression_in_synpred147_JavaScript1369 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred154_JavaScript1417 = new BitSet(new ulong[]{0x2800000000000010UL});
    public static readonly BitSet FOLLOW_memberExpressionSuffix_in_synpred154_JavaScript1421 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred158_JavaScript1460 = new BitSet(new ulong[]{0x2800000100000010UL});
    public static readonly BitSet FOLLOW_callExpressionSuffix_in_synpred158_JavaScript1464 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred256_JavaScript2197 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_set_in_synpred256_JavaScript2201 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_synpred256_JavaScript2209 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_synpred256_JavaScript2213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred280_JavaScript2387 = new BitSet(new ulong[]{0x0000000000000002UL});

}
