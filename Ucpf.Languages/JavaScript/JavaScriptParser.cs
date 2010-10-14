// $ANTLR 3.2 Sep 23, 2009 12:02:23 JavaScript.g 2010-03-22 18:27:06

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


	using System.Collections.Generic;
	using System.Text;
	using System.Xml.Linq;


using System;
using Antlr.Runtime;
	using OpenCodeProcessorFramework.Languages.Common.Antlr;
	using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;

using Antlr.Runtime.Tree;

public partial class JavaScriptParser : Parser, IXParser
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
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
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


    	private readonly IList<XElement> Elements = new List<XElement>();
    	public IList<XElement> ElementList { get { return Elements; } }
    	public string LeaveElementName { get; set; }


    public class program_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "program"
    // JavaScript.g:30:1: program : ( LT )* sourceElements ( LT )* EOF ;
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

         const string elementName = "program"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:33:2: ( ( LT )* sourceElements ( LT )* EOF )
            // JavaScript.g:33:4: ( LT )* sourceElements ( LT )* EOF
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// JavaScript.g:33:6: ( LT )*
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
            			    	LT1=(IToken)Match(input,LT,FOLLOW_LT_in_program65); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop1;
            	    }
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements

            	PushFollow(FOLLOW_sourceElements_in_program69);
            	sourceElements2 = sourceElements();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElements2.Tree);
            	// JavaScript.g:33:26: ( LT )*
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
            			    	LT3=(IToken)Match(input,LT,FOLLOW_LT_in_program71); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	EOF4=(IToken)Match(input,EOF,FOLLOW_EOF_in_program75); if (state.failed) return retval;

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class sourceElements_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sourceElements"
    // JavaScript.g:36:1: sourceElements : sourceElement ( ( LT )* sourceElement )* ;
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

         const string elementName = "sourceElements"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:39:2: ( sourceElement ( ( LT )* sourceElement )* )
            // JavaScript.g:39:4: sourceElement ( ( LT )* sourceElement )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_sourceElement_in_sourceElements98);
            	sourceElement5 = sourceElement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElement5.Tree);
            	// JavaScript.g:39:18: ( ( LT )* sourceElement )*
            	do 
            	{
            	    int alt4 = 2;
            	    alt4 = dfa4.Predict(input);
            	    switch (alt4) 
            		{
            			case 1 :
            			    // JavaScript.g:39:19: ( LT )* sourceElement
            			    {
            			    	// JavaScript.g:39:21: ( LT )*
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
            			    			    	LT6=(IToken)Match(input,LT,FOLLOW_LT_in_sourceElements101); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop3;
            			    	    }
            			    	} while (true);

            			    	loop3:
            			    		;	// Stops C# compiler whining that label 'loop3' has no statements

            			    	PushFollow(FOLLOW_sourceElement_in_sourceElements105);
            			    	sourceElement7 = sourceElement();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElement7.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class sourceElement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sourceElement"
    // JavaScript.g:42:1: sourceElement : ( functionDeclaration | statement );
    public JavaScriptParser.sourceElement_return sourceElement() // throws RecognitionException [1]
    {   
        JavaScriptParser.sourceElement_return retval = new JavaScriptParser.sourceElement_return();
        retval.Start = input.LT(1);
        int sourceElement_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.functionDeclaration_return functionDeclaration8 = default(JavaScriptParser.functionDeclaration_return);

        JavaScriptParser.statement_return statement9 = default(JavaScriptParser.statement_return);



         const string elementName = "sourceElement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:45:2: ( functionDeclaration | statement )
            int alt5 = 2;
            alt5 = dfa5.Predict(input);
            switch (alt5) 
            {
                case 1 :
                    // JavaScript.g:45:4: functionDeclaration
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_functionDeclaration_in_sourceElement129);
                    	functionDeclaration8 = functionDeclaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionDeclaration8.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:46:4: statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_statement_in_sourceElement134);
                    	statement9 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement9.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class functionDeclaration_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functionDeclaration"
    // JavaScript.g:50:1: functionDeclaration : 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody ;
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

         const string elementName = "functionDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:53:2: ( 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody )
            // JavaScript.g:53:4: 'function' ( LT )* Identifier ( LT )* formalParameterList ( LT )* functionBody
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal10=(IToken)Match(input,31,FOLLOW_31_in_functionDeclaration157); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal10_tree = (object)adaptor.Create(string_literal10);
            		adaptor.AddChild(root_0, string_literal10_tree);
            	}
            	// JavaScript.g:53:17: ( LT )*
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
            			    	LT11=(IToken)Match(input,LT,FOLLOW_LT_in_functionDeclaration159); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	Identifier12=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_functionDeclaration163); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier12_tree = (object)adaptor.Create(Identifier12);
            		adaptor.AddChild(root_0, Identifier12_tree);
            	}
            	// JavaScript.g:53:33: ( LT )*
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
            			    	LT13=(IToken)Match(input,LT,FOLLOW_LT_in_functionDeclaration165); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	PushFollow(FOLLOW_formalParameterList_in_functionDeclaration169);
            	formalParameterList14 = formalParameterList();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameterList14.Tree);
            	// JavaScript.g:53:58: ( LT )*
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
            			    	LT15=(IToken)Match(input,LT,FOLLOW_LT_in_functionDeclaration171); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements

            	PushFollow(FOLLOW_functionBody_in_functionDeclaration175);
            	functionBody16 = functionBody();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionBody16.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class functionExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functionExpression"
    // JavaScript.g:56:1: functionExpression : 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody ;
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

         const string elementName = "functionExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 5) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:59:2: ( 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody )
            // JavaScript.g:59:4: 'function' ( LT )* ( Identifier )? ( LT )* formalParameterList ( LT )* functionBody
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal17=(IToken)Match(input,31,FOLLOW_31_in_functionExpression197); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal17_tree = (object)adaptor.Create(string_literal17);
            		adaptor.AddChild(root_0, string_literal17_tree);
            	}
            	// JavaScript.g:59:17: ( LT )*
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
            			    	LT18=(IToken)Match(input,LT,FOLLOW_LT_in_functionExpression199); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	// JavaScript.g:59:20: ( Identifier )?
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
            	        	Identifier19=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_functionExpression203); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier19_tree = (object)adaptor.Create(Identifier19);
            	        		adaptor.AddChild(root_0, Identifier19_tree);
            	        	}

            	        }
            	        break;

            	}

            	// JavaScript.g:59:34: ( LT )*
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
            			    	LT20=(IToken)Match(input,LT,FOLLOW_LT_in_functionExpression206); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	PushFollow(FOLLOW_formalParameterList_in_functionExpression210);
            	formalParameterList21 = formalParameterList();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, formalParameterList21.Tree);
            	// JavaScript.g:59:59: ( LT )*
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
            			    	LT22=(IToken)Match(input,LT,FOLLOW_LT_in_functionExpression212); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements

            	PushFollow(FOLLOW_functionBody_in_functionExpression216);
            	functionBody23 = functionBody();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionBody23.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class formalParameterList_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "formalParameterList"
    // JavaScript.g:62:1: formalParameterList : '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* ')' ;
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

         const string elementName = "formalParameterList"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 6) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:65:2: ( '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* ')' )
            // JavaScript.g:65:4: '(' ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )? ( LT )* ')'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal24=(IToken)Match(input,32,FOLLOW_32_in_formalParameterList238); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal24_tree = (object)adaptor.Create(char_literal24);
            		adaptor.AddChild(root_0, char_literal24_tree);
            	}
            	// JavaScript.g:65:8: ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )?
            	int alt17 = 2;
            	alt17 = dfa17.Predict(input);
            	switch (alt17) 
            	{
            	    case 1 :
            	        // JavaScript.g:65:9: ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )*
            	        {
            	        	// JavaScript.g:65:11: ( LT )*
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
            	        			    	LT25=(IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList241); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop13;
            	        	    }
            	        	} while (true);

            	        	loop13:
            	        		;	// Stops C# compiler whining that label 'loop13' has no statements

            	        	Identifier26=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_formalParameterList245); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier26_tree = (object)adaptor.Create(Identifier26);
            	        		adaptor.AddChild(root_0, Identifier26_tree);
            	        	}
            	        	// JavaScript.g:65:25: ( ( LT )* ',' ( LT )* Identifier )*
            	        	do 
            	        	{
            	        	    int alt16 = 2;
            	        	    alt16 = dfa16.Predict(input);
            	        	    switch (alt16) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:65:26: ( LT )* ',' ( LT )* Identifier
            	        			    {
            	        			    	// JavaScript.g:65:28: ( LT )*
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
            	        			    			    	LT27=(IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList248); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop14;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop14:
            	        			    		;	// Stops C# compiler whining that label 'loop14' has no statements

            	        			    	char_literal28=(IToken)Match(input,33,FOLLOW_33_in_formalParameterList252); if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 )
            	        			    	{char_literal28_tree = (object)adaptor.Create(char_literal28);
            	        			    		adaptor.AddChild(root_0, char_literal28_tree);
            	        			    	}
            	        			    	// JavaScript.g:65:37: ( LT )*
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
            	        			    			    	LT29=(IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList254); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop15;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop15:
            	        			    		;	// Stops C# compiler whining that label 'loop15' has no statements

            	        			    	Identifier30=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_formalParameterList258); if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 )
            	        			    	{Identifier30_tree = (object)adaptor.Create(Identifier30);
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

            	// JavaScript.g:65:57: ( LT )*
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
            			    	LT31=(IToken)Match(input,LT,FOLLOW_LT_in_formalParameterList264); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop18;
            	    }
            	} while (true);

            	loop18:
            		;	// Stops C# compiler whining that label 'loop18' has no statements

            	char_literal32=(IToken)Match(input,34,FOLLOW_34_in_formalParameterList268); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal32_tree = (object)adaptor.Create(char_literal32);
            		adaptor.AddChild(root_0, char_literal32_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class functionBody_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "functionBody"
    // JavaScript.g:68:1: functionBody : '{' ( LT )* sourceElements ( LT )* '}' ;
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

         const string elementName = "functionBody"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 7) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:71:2: ( '{' ( LT )* sourceElements ( LT )* '}' )
            // JavaScript.g:71:4: '{' ( LT )* sourceElements ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal33=(IToken)Match(input,35,FOLLOW_35_in_functionBody289); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal33_tree = (object)adaptor.Create(char_literal33);
            		adaptor.AddChild(root_0, char_literal33_tree);
            	}
            	// JavaScript.g:71:10: ( LT )*
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
            			    	LT34=(IToken)Match(input,LT,FOLLOW_LT_in_functionBody291); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements

            	PushFollow(FOLLOW_sourceElements_in_functionBody295);
            	sourceElements35 = sourceElements();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, sourceElements35.Tree);
            	// JavaScript.g:71:30: ( LT )*
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
            			    	LT36=(IToken)Match(input,LT,FOLLOW_LT_in_functionBody297); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop20;
            	    }
            	} while (true);

            	loop20:
            		;	// Stops C# compiler whining that label 'loop20' has no statements

            	char_literal37=(IToken)Match(input,36,FOLLOW_36_in_functionBody301); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal37_tree = (object)adaptor.Create(char_literal37);
            		adaptor.AddChild(root_0, char_literal37_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class statement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statement"
    // JavaScript.g:75:1: statement : ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );
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



         const string elementName = "statement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 8) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:78:2: ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement )
            int alt21 = 14;
            alt21 = dfa21.Predict(input);
            switch (alt21) 
            {
                case 1 :
                    // JavaScript.g:78:4: statementBlock
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_statementBlock_in_statement323);
                    	statementBlock38 = statementBlock();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock38.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:79:4: variableStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_variableStatement_in_statement328);
                    	variableStatement39 = variableStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableStatement39.Tree);

                    }
                    break;
                case 3 :
                    // JavaScript.g:80:4: emptyStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_emptyStatement_in_statement333);
                    	emptyStatement40 = emptyStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, emptyStatement40.Tree);

                    }
                    break;
                case 4 :
                    // JavaScript.g:81:4: expressionStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expressionStatement_in_statement338);
                    	expressionStatement41 = expressionStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionStatement41.Tree);

                    }
                    break;
                case 5 :
                    // JavaScript.g:82:4: ifStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_ifStatement_in_statement343);
                    	ifStatement42 = ifStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, ifStatement42.Tree);

                    }
                    break;
                case 6 :
                    // JavaScript.g:83:4: iterationStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_iterationStatement_in_statement348);
                    	iterationStatement43 = iterationStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, iterationStatement43.Tree);

                    }
                    break;
                case 7 :
                    // JavaScript.g:84:4: continueStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_continueStatement_in_statement353);
                    	continueStatement44 = continueStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, continueStatement44.Tree);

                    }
                    break;
                case 8 :
                    // JavaScript.g:85:4: breakStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_breakStatement_in_statement358);
                    	breakStatement45 = breakStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, breakStatement45.Tree);

                    }
                    break;
                case 9 :
                    // JavaScript.g:86:4: returnStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_returnStatement_in_statement363);
                    	returnStatement46 = returnStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, returnStatement46.Tree);

                    }
                    break;
                case 10 :
                    // JavaScript.g:87:4: withStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_withStatement_in_statement368);
                    	withStatement47 = withStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, withStatement47.Tree);

                    }
                    break;
                case 11 :
                    // JavaScript.g:88:4: labelledStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_labelledStatement_in_statement373);
                    	labelledStatement48 = labelledStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, labelledStatement48.Tree);

                    }
                    break;
                case 12 :
                    // JavaScript.g:89:4: switchStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_switchStatement_in_statement378);
                    	switchStatement49 = switchStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, switchStatement49.Tree);

                    }
                    break;
                case 13 :
                    // JavaScript.g:90:4: throwStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_throwStatement_in_statement383);
                    	throwStatement50 = throwStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, throwStatement50.Tree);

                    }
                    break;
                case 14 :
                    // JavaScript.g:91:4: tryStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_tryStatement_in_statement388);
                    	tryStatement51 = tryStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, tryStatement51.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class statementBlock_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statementBlock"
    // JavaScript.g:94:1: statementBlock : '{' ( LT )* ( statementList )? ( LT )* '}' ;
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

         const string elementName = "statementBlock"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 9) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:97:2: ( '{' ( LT )* ( statementList )? ( LT )* '}' )
            // JavaScript.g:97:4: '{' ( LT )* ( statementList )? ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal52=(IToken)Match(input,35,FOLLOW_35_in_statementBlock410); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal52_tree = (object)adaptor.Create(char_literal52);
            		adaptor.AddChild(root_0, char_literal52_tree);
            	}
            	// JavaScript.g:97:10: ( LT )*
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
            			    	LT53=(IToken)Match(input,LT,FOLLOW_LT_in_statementBlock412); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop22;
            	    }
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements

            	// JavaScript.g:97:13: ( statementList )?
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
            	        	PushFollow(FOLLOW_statementList_in_statementBlock416);
            	        	statementList54 = statementList();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList54.Tree);

            	        }
            	        break;

            	}

            	// JavaScript.g:97:30: ( LT )*
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
            			    	LT55=(IToken)Match(input,LT,FOLLOW_LT_in_statementBlock419); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop24;
            	    }
            	} while (true);

            	loop24:
            		;	// Stops C# compiler whining that label 'loop24' has no statements

            	char_literal56=(IToken)Match(input,36,FOLLOW_36_in_statementBlock423); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal56_tree = (object)adaptor.Create(char_literal56);
            		adaptor.AddChild(root_0, char_literal56_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class statementList_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statementList"
    // JavaScript.g:100:1: statementList : statement ( ( LT )* statement )* ;
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

         const string elementName = "statementList"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 10) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:103:2: ( statement ( ( LT )* statement )* )
            // JavaScript.g:103:4: statement ( ( LT )* statement )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_statement_in_statementList445);
            	statement57 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement57.Tree);
            	// JavaScript.g:103:14: ( ( LT )* statement )*
            	do 
            	{
            	    int alt26 = 2;
            	    alt26 = dfa26.Predict(input);
            	    switch (alt26) 
            		{
            			case 1 :
            			    // JavaScript.g:103:15: ( LT )* statement
            			    {
            			    	// JavaScript.g:103:17: ( LT )*
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
            			    			    	LT58=(IToken)Match(input,LT,FOLLOW_LT_in_statementList448); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop25;
            			    	    }
            			    	} while (true);

            			    	loop25:
            			    		;	// Stops C# compiler whining that label 'loop25' has no statements

            			    	PushFollow(FOLLOW_statement_in_statementList452);
            			    	statement59 = statement();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement59.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class variableStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableStatement"
    // JavaScript.g:106:1: variableStatement : 'var' ( LT )* variableDeclarationList ( LT | ';' ) ;
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

         const string elementName = "variableStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 11) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:109:2: ( 'var' ( LT )* variableDeclarationList ( LT | ';' ) )
            // JavaScript.g:109:4: 'var' ( LT )* variableDeclarationList ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal60=(IToken)Match(input,37,FOLLOW_37_in_variableStatement476); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal60_tree = (object)adaptor.Create(string_literal60);
            		adaptor.AddChild(root_0, string_literal60_tree);
            	}
            	// JavaScript.g:109:12: ( LT )*
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
            			    	LT61=(IToken)Match(input,LT,FOLLOW_LT_in_variableStatement478); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop27;
            	    }
            	} while (true);

            	loop27:
            		;	// Stops C# compiler whining that label 'loop27' has no statements

            	PushFollow(FOLLOW_variableDeclarationList_in_variableStatement482);
            	variableDeclarationList62 = variableDeclarationList();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationList62.Tree);
            	set63 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set63));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class variableDeclarationList_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclarationList"
    // JavaScript.g:112:1: variableDeclarationList : variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )* ;
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

         const string elementName = "variableDeclarationList"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 12) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:115:2: ( variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )* )
            // JavaScript.g:115:4: variableDeclaration ( ( LT )* ',' ( LT )* variableDeclaration )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_variableDeclaration_in_variableDeclarationList512);
            	variableDeclaration64 = variableDeclaration();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclaration64.Tree);
            	// JavaScript.g:115:24: ( ( LT )* ',' ( LT )* variableDeclaration )*
            	do 
            	{
            	    int alt30 = 2;
            	    alt30 = dfa30.Predict(input);
            	    switch (alt30) 
            		{
            			case 1 :
            			    // JavaScript.g:115:25: ( LT )* ',' ( LT )* variableDeclaration
            			    {
            			    	// JavaScript.g:115:27: ( LT )*
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
            			    			    	LT65=(IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationList515); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop28;
            			    	    }
            			    	} while (true);

            			    	loop28:
            			    		;	// Stops C# compiler whining that label 'loop28' has no statements

            			    	char_literal66=(IToken)Match(input,33,FOLLOW_33_in_variableDeclarationList519); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal66_tree = (object)adaptor.Create(char_literal66);
            			    		adaptor.AddChild(root_0, char_literal66_tree);
            			    	}
            			    	// JavaScript.g:115:36: ( LT )*
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
            			    			    	LT67=(IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationList521); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop29;
            			    	    }
            			    	} while (true);

            			    	loop29:
            			    		;	// Stops C# compiler whining that label 'loop29' has no statements

            			    	PushFollow(FOLLOW_variableDeclaration_in_variableDeclarationList525);
            			    	variableDeclaration68 = variableDeclaration();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclaration68.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class variableDeclarationListNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclarationListNoIn"
    // JavaScript.g:118:1: variableDeclarationListNoIn : variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )* ;
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

         const string elementName = "variableDeclarationListNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 13) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:121:2: ( variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )* )
            // JavaScript.g:121:4: variableDeclarationNoIn ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn549);
            	variableDeclarationNoIn69 = variableDeclarationNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn69.Tree);
            	// JavaScript.g:121:28: ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*
            	do 
            	{
            	    int alt33 = 2;
            	    alt33 = dfa33.Predict(input);
            	    switch (alt33) 
            		{
            			case 1 :
            			    // JavaScript.g:121:29: ( LT )* ',' ( LT )* variableDeclarationNoIn
            			    {
            			    	// JavaScript.g:121:31: ( LT )*
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
            			    			    	LT70=(IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationListNoIn552); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop31;
            			    	    }
            			    	} while (true);

            			    	loop31:
            			    		;	// Stops C# compiler whining that label 'loop31' has no statements

            			    	char_literal71=(IToken)Match(input,33,FOLLOW_33_in_variableDeclarationListNoIn556); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal71_tree = (object)adaptor.Create(char_literal71);
            			    		adaptor.AddChild(root_0, char_literal71_tree);
            			    	}
            			    	// JavaScript.g:121:40: ( LT )*
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
            			    			    	LT72=(IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationListNoIn558); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop32;
            			    	    }
            			    	} while (true);

            			    	loop32:
            			    		;	// Stops C# compiler whining that label 'loop32' has no statements

            			    	PushFollow(FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn562);
            			    	variableDeclarationNoIn73 = variableDeclarationNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn73.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class variableDeclaration_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclaration"
    // JavaScript.g:124:1: variableDeclaration : Identifier ( LT )* ( initialiser )? ;
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

         const string elementName = "variableDeclaration"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 14) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:127:2: ( Identifier ( LT )* ( initialiser )? )
            // JavaScript.g:127:4: Identifier ( LT )* ( initialiser )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	Identifier74=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_variableDeclaration586); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier74_tree = (object)adaptor.Create(Identifier74);
            		adaptor.AddChild(root_0, Identifier74_tree);
            	}
            	// JavaScript.g:127:17: ( LT )*
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
            			    	LT75=(IToken)Match(input,LT,FOLLOW_LT_in_variableDeclaration588); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop34;
            	    }
            	} while (true);

            	loop34:
            		;	// Stops C# compiler whining that label 'loop34' has no statements

            	// JavaScript.g:127:20: ( initialiser )?
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
            	        	PushFollow(FOLLOW_initialiser_in_variableDeclaration592);
            	        	initialiser76 = initialiser();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initialiser76.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class variableDeclarationNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "variableDeclarationNoIn"
    // JavaScript.g:130:1: variableDeclarationNoIn : Identifier ( LT )* ( initialiserNoIn )? ;
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

         const string elementName = "variableDeclarationNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 15) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:133:2: ( Identifier ( LT )* ( initialiserNoIn )? )
            // JavaScript.g:133:4: Identifier ( LT )* ( initialiserNoIn )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	Identifier77=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_variableDeclarationNoIn615); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier77_tree = (object)adaptor.Create(Identifier77);
            		adaptor.AddChild(root_0, Identifier77_tree);
            	}
            	// JavaScript.g:133:17: ( LT )*
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
            			    	LT78=(IToken)Match(input,LT,FOLLOW_LT_in_variableDeclarationNoIn617); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop36;
            	    }
            	} while (true);

            	loop36:
            		;	// Stops C# compiler whining that label 'loop36' has no statements

            	// JavaScript.g:133:20: ( initialiserNoIn )?
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
            	        	PushFollow(FOLLOW_initialiserNoIn_in_variableDeclarationNoIn621);
            	        	initialiserNoIn79 = initialiserNoIn();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initialiserNoIn79.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class initialiser_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "initialiser"
    // JavaScript.g:136:1: initialiser : '=' ( LT )* assignmentExpression ;
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

         const string elementName = "initialiser"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 16) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:139:2: ( '=' ( LT )* assignmentExpression )
            // JavaScript.g:139:4: '=' ( LT )* assignmentExpression
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal80=(IToken)Match(input,39,FOLLOW_39_in_initialiser644); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal80_tree = (object)adaptor.Create(char_literal80);
            		adaptor.AddChild(root_0, char_literal80_tree);
            	}
            	// JavaScript.g:139:10: ( LT )*
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
            			    	LT81=(IToken)Match(input,LT,FOLLOW_LT_in_initialiser646); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop38;
            	    }
            	} while (true);

            	loop38:
            		;	// Stops C# compiler whining that label 'loop38' has no statements

            	PushFollow(FOLLOW_assignmentExpression_in_initialiser650);
            	assignmentExpression82 = assignmentExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression82.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class initialiserNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "initialiserNoIn"
    // JavaScript.g:142:1: initialiserNoIn : '=' ( LT )* assignmentExpressionNoIn ;
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

         const string elementName = "initialiserNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 17) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:145:2: ( '=' ( LT )* assignmentExpressionNoIn )
            // JavaScript.g:145:4: '=' ( LT )* assignmentExpressionNoIn
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal83=(IToken)Match(input,39,FOLLOW_39_in_initialiserNoIn672); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal83_tree = (object)adaptor.Create(char_literal83);
            		adaptor.AddChild(root_0, char_literal83_tree);
            	}
            	// JavaScript.g:145:10: ( LT )*
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
            			    	LT84=(IToken)Match(input,LT,FOLLOW_LT_in_initialiserNoIn674); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop39;
            	    }
            	} while (true);

            	loop39:
            		;	// Stops C# compiler whining that label 'loop39' has no statements

            	PushFollow(FOLLOW_assignmentExpressionNoIn_in_initialiserNoIn678);
            	assignmentExpressionNoIn85 = assignmentExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn85.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class emptyStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "emptyStatement"
    // JavaScript.g:148:1: emptyStatement : ';' ;
    public JavaScriptParser.emptyStatement_return emptyStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.emptyStatement_return retval = new JavaScriptParser.emptyStatement_return();
        retval.Start = input.LT(1);
        int emptyStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal86 = null;

        object char_literal86_tree=null;

         const string elementName = "emptyStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 18) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:151:2: ( ';' )
            // JavaScript.g:151:4: ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal86=(IToken)Match(input,38,FOLLOW_38_in_emptyStatement700); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal86_tree = (object)adaptor.Create(char_literal86);
            		adaptor.AddChild(root_0, char_literal86_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class expressionStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expressionStatement"
    // JavaScript.g:154:1: expressionStatement : expression ( LT | ';' ) ;
    public JavaScriptParser.expressionStatement_return expressionStatement() // throws RecognitionException [1]
    {   
        JavaScriptParser.expressionStatement_return retval = new JavaScriptParser.expressionStatement_return();
        retval.Start = input.LT(1);
        int expressionStatement_StartIndex = input.Index();
        object root_0 = null;

        IToken set88 = null;
        JavaScriptParser.expression_return expression87 = default(JavaScriptParser.expression_return);


        object set88_tree=null;

         const string elementName = "expressionStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 19) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:157:2: ( expression ( LT | ';' ) )
            // JavaScript.g:157:4: expression ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_expression_in_expressionStatement722);
            	expression87 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression87.Tree);
            	set88 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set88));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class ifStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "ifStatement"
    // JavaScript.g:160:1: ifStatement : 'if' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ( ( LT )* 'else' ( LT )* statement )? ;
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

         const string elementName = "ifStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 20) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:163:2: ( 'if' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ( ( LT )* 'else' ( LT )* statement )? )
            // JavaScript.g:163:4: 'if' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ( ( LT )* 'else' ( LT )* statement )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal89=(IToken)Match(input,40,FOLLOW_40_in_ifStatement752); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal89_tree = (object)adaptor.Create(string_literal89);
            		adaptor.AddChild(root_0, string_literal89_tree);
            	}
            	// JavaScript.g:163:11: ( LT )*
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
            			    	LT90=(IToken)Match(input,LT,FOLLOW_LT_in_ifStatement754); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop40;
            	    }
            	} while (true);

            	loop40:
            		;	// Stops C# compiler whining that label 'loop40' has no statements

            	char_literal91=(IToken)Match(input,32,FOLLOW_32_in_ifStatement758); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal91_tree = (object)adaptor.Create(char_literal91);
            		adaptor.AddChild(root_0, char_literal91_tree);
            	}
            	// JavaScript.g:163:20: ( LT )*
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
            			    	LT92=(IToken)Match(input,LT,FOLLOW_LT_in_ifStatement760); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop41;
            	    }
            	} while (true);

            	loop41:
            		;	// Stops C# compiler whining that label 'loop41' has no statements

            	PushFollow(FOLLOW_expression_in_ifStatement764);
            	expression93 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression93.Tree);
            	// JavaScript.g:163:36: ( LT )*
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
            			    	LT94=(IToken)Match(input,LT,FOLLOW_LT_in_ifStatement766); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop42;
            	    }
            	} while (true);

            	loop42:
            		;	// Stops C# compiler whining that label 'loop42' has no statements

            	char_literal95=(IToken)Match(input,34,FOLLOW_34_in_ifStatement770); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal95_tree = (object)adaptor.Create(char_literal95);
            		adaptor.AddChild(root_0, char_literal95_tree);
            	}
            	// JavaScript.g:163:45: ( LT )*
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
            			    	LT96=(IToken)Match(input,LT,FOLLOW_LT_in_ifStatement772); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop43;
            	    }
            	} while (true);

            	loop43:
            		;	// Stops C# compiler whining that label 'loop43' has no statements

            	PushFollow(FOLLOW_statement_in_ifStatement776);
            	statement97 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement97.Tree);
            	// JavaScript.g:163:58: ( ( LT )* 'else' ( LT )* statement )?
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
            	        // JavaScript.g:163:59: ( LT )* 'else' ( LT )* statement
            	        {
            	        	// JavaScript.g:163:61: ( LT )*
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
            	        			    	LT98=(IToken)Match(input,LT,FOLLOW_LT_in_ifStatement779); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop44;
            	        	    }
            	        	} while (true);

            	        	loop44:
            	        		;	// Stops C# compiler whining that label 'loop44' has no statements

            	        	string_literal99=(IToken)Match(input,41,FOLLOW_41_in_ifStatement783); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{string_literal99_tree = (object)adaptor.Create(string_literal99);
            	        		adaptor.AddChild(root_0, string_literal99_tree);
            	        	}
            	        	// JavaScript.g:163:73: ( LT )*
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
            	        			    	LT100=(IToken)Match(input,LT,FOLLOW_LT_in_ifStatement785); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop45;
            	        	    }
            	        	} while (true);

            	        	loop45:
            	        		;	// Stops C# compiler whining that label 'loop45' has no statements

            	        	PushFollow(FOLLOW_statement_in_ifStatement789);
            	        	statement101 = statement();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement101.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class iterationStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "iterationStatement"
    // JavaScript.g:166:1: iterationStatement : ( doWhileStatement | whileStatement | forStatement | forInStatement );
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



         const string elementName = "iterationStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 21) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:169:2: ( doWhileStatement | whileStatement | forStatement | forInStatement )
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
                    // JavaScript.g:169:4: doWhileStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_doWhileStatement_in_iterationStatement813);
                    	doWhileStatement102 = doWhileStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, doWhileStatement102.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:170:4: whileStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_whileStatement_in_iterationStatement818);
                    	whileStatement103 = whileStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, whileStatement103.Tree);

                    }
                    break;
                case 3 :
                    // JavaScript.g:171:4: forStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_forStatement_in_iterationStatement823);
                    	forStatement104 = forStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forStatement104.Tree);

                    }
                    break;
                case 4 :
                    // JavaScript.g:172:4: forInStatement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_forInStatement_in_iterationStatement828);
                    	forInStatement105 = forInStatement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forInStatement105.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class doWhileStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "doWhileStatement"
    // JavaScript.g:175:1: doWhileStatement : 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression ')' ( LT | ';' ) ;
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

         const string elementName = "doWhileStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 22) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:178:2: ( 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression ')' ( LT | ';' ) )
            // JavaScript.g:178:4: 'do' ( LT )* statement ( LT )* 'while' ( LT )* '(' expression ')' ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal106=(IToken)Match(input,42,FOLLOW_42_in_doWhileStatement850); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal106_tree = (object)adaptor.Create(string_literal106);
            		adaptor.AddChild(root_0, string_literal106_tree);
            	}
            	// JavaScript.g:178:11: ( LT )*
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
            			    	LT107=(IToken)Match(input,LT,FOLLOW_LT_in_doWhileStatement852); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop48;
            	    }
            	} while (true);

            	loop48:
            		;	// Stops C# compiler whining that label 'loop48' has no statements

            	PushFollow(FOLLOW_statement_in_doWhileStatement856);
            	statement108 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement108.Tree);
            	// JavaScript.g:178:26: ( LT )*
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
            			    	LT109=(IToken)Match(input,LT,FOLLOW_LT_in_doWhileStatement858); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop49;
            	    }
            	} while (true);

            	loop49:
            		;	// Stops C# compiler whining that label 'loop49' has no statements

            	string_literal110=(IToken)Match(input,43,FOLLOW_43_in_doWhileStatement862); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal110_tree = (object)adaptor.Create(string_literal110);
            		adaptor.AddChild(root_0, string_literal110_tree);
            	}
            	// JavaScript.g:178:39: ( LT )*
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
            			    	LT111=(IToken)Match(input,LT,FOLLOW_LT_in_doWhileStatement864); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop50;
            	    }
            	} while (true);

            	loop50:
            		;	// Stops C# compiler whining that label 'loop50' has no statements

            	char_literal112=(IToken)Match(input,32,FOLLOW_32_in_doWhileStatement868); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal112_tree = (object)adaptor.Create(char_literal112);
            		adaptor.AddChild(root_0, char_literal112_tree);
            	}
            	PushFollow(FOLLOW_expression_in_doWhileStatement870);
            	expression113 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression113.Tree);
            	char_literal114=(IToken)Match(input,34,FOLLOW_34_in_doWhileStatement872); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal114_tree = (object)adaptor.Create(char_literal114);
            		adaptor.AddChild(root_0, char_literal114_tree);
            	}
            	set115 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set115));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class whileStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "whileStatement"
    // JavaScript.g:181:1: whileStatement : 'while' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ;
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

         const string elementName = "whileStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 23) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:184:2: ( 'while' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement )
            // JavaScript.g:184:4: 'while' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal116=(IToken)Match(input,43,FOLLOW_43_in_whileStatement902); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal116_tree = (object)adaptor.Create(string_literal116);
            		adaptor.AddChild(root_0, string_literal116_tree);
            	}
            	// JavaScript.g:184:14: ( LT )*
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
            			    	LT117=(IToken)Match(input,LT,FOLLOW_LT_in_whileStatement904); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop51;
            	    }
            	} while (true);

            	loop51:
            		;	// Stops C# compiler whining that label 'loop51' has no statements

            	char_literal118=(IToken)Match(input,32,FOLLOW_32_in_whileStatement908); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal118_tree = (object)adaptor.Create(char_literal118);
            		adaptor.AddChild(root_0, char_literal118_tree);
            	}
            	// JavaScript.g:184:23: ( LT )*
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
            			    	LT119=(IToken)Match(input,LT,FOLLOW_LT_in_whileStatement910); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop52;
            	    }
            	} while (true);

            	loop52:
            		;	// Stops C# compiler whining that label 'loop52' has no statements

            	PushFollow(FOLLOW_expression_in_whileStatement914);
            	expression120 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression120.Tree);
            	// JavaScript.g:184:39: ( LT )*
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
            			    	LT121=(IToken)Match(input,LT,FOLLOW_LT_in_whileStatement916); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop53;
            	    }
            	} while (true);

            	loop53:
            		;	// Stops C# compiler whining that label 'loop53' has no statements

            	char_literal122=(IToken)Match(input,34,FOLLOW_34_in_whileStatement920); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal122_tree = (object)adaptor.Create(char_literal122);
            		adaptor.AddChild(root_0, char_literal122_tree);
            	}
            	// JavaScript.g:184:48: ( LT )*
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
            			    	LT123=(IToken)Match(input,LT,FOLLOW_LT_in_whileStatement922); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop54;
            	    }
            	} while (true);

            	loop54:
            		;	// Stops C# compiler whining that label 'loop54' has no statements

            	PushFollow(FOLLOW_statement_in_whileStatement926);
            	statement124 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement124.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class forStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forStatement"
    // JavaScript.g:187:1: forStatement : 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ')' ( LT )* statement ;
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

         const string elementName = "forStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 24) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:190:2: ( 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ')' ( LT )* statement )
            // JavaScript.g:190:4: 'for' ( LT )* '(' ( ( LT )* forStatementInitialiserPart )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ';' ( ( LT )* expression )? ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal125=(IToken)Match(input,44,FOLLOW_44_in_forStatement948); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal125_tree = (object)adaptor.Create(string_literal125);
            		adaptor.AddChild(root_0, string_literal125_tree);
            	}
            	// JavaScript.g:190:12: ( LT )*
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
            			    	LT126=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement950); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop55;
            	    }
            	} while (true);

            	loop55:
            		;	// Stops C# compiler whining that label 'loop55' has no statements

            	char_literal127=(IToken)Match(input,32,FOLLOW_32_in_forStatement954); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal127_tree = (object)adaptor.Create(char_literal127);
            		adaptor.AddChild(root_0, char_literal127_tree);
            	}
            	// JavaScript.g:190:19: ( ( LT )* forStatementInitialiserPart )?
            	int alt57 = 2;
            	alt57 = dfa57.Predict(input);
            	switch (alt57) 
            	{
            	    case 1 :
            	        // JavaScript.g:190:20: ( LT )* forStatementInitialiserPart
            	        {
            	        	// JavaScript.g:190:22: ( LT )*
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
            	        			    	LT128=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement957); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop56;
            	        	    }
            	        	} while (true);

            	        	loop56:
            	        		;	// Stops C# compiler whining that label 'loop56' has no statements

            	        	PushFollow(FOLLOW_forStatementInitialiserPart_in_forStatement961);
            	        	forStatementInitialiserPart129 = forStatementInitialiserPart();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forStatementInitialiserPart129.Tree);

            	        }
            	        break;

            	}

            	// JavaScript.g:190:57: ( LT )*
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
            			    	LT130=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement965); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop58;
            	    }
            	} while (true);

            	loop58:
            		;	// Stops C# compiler whining that label 'loop58' has no statements

            	char_literal131=(IToken)Match(input,38,FOLLOW_38_in_forStatement969); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal131_tree = (object)adaptor.Create(char_literal131);
            		adaptor.AddChild(root_0, char_literal131_tree);
            	}
            	// JavaScript.g:190:64: ( ( LT )* expression )?
            	int alt60 = 2;
            	alt60 = dfa60.Predict(input);
            	switch (alt60) 
            	{
            	    case 1 :
            	        // JavaScript.g:190:65: ( LT )* expression
            	        {
            	        	// JavaScript.g:190:67: ( LT )*
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
            	        			    	LT132=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement972); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop59;
            	        	    }
            	        	} while (true);

            	        	loop59:
            	        		;	// Stops C# compiler whining that label 'loop59' has no statements

            	        	PushFollow(FOLLOW_expression_in_forStatement976);
            	        	expression133 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression133.Tree);

            	        }
            	        break;

            	}

            	// JavaScript.g:190:85: ( LT )*
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
            			    	LT134=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement980); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop61;
            	    }
            	} while (true);

            	loop61:
            		;	// Stops C# compiler whining that label 'loop61' has no statements

            	char_literal135=(IToken)Match(input,38,FOLLOW_38_in_forStatement984); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal135_tree = (object)adaptor.Create(char_literal135);
            		adaptor.AddChild(root_0, char_literal135_tree);
            	}
            	// JavaScript.g:190:92: ( ( LT )* expression )?
            	int alt63 = 2;
            	alt63 = dfa63.Predict(input);
            	switch (alt63) 
            	{
            	    case 1 :
            	        // JavaScript.g:190:93: ( LT )* expression
            	        {
            	        	// JavaScript.g:190:95: ( LT )*
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
            	        			    	LT136=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement987); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop62;
            	        	    }
            	        	} while (true);

            	        	loop62:
            	        		;	// Stops C# compiler whining that label 'loop62' has no statements

            	        	PushFollow(FOLLOW_expression_in_forStatement991);
            	        	expression137 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression137.Tree);

            	        }
            	        break;

            	}

            	// JavaScript.g:190:113: ( LT )*
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
            			    	LT138=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement995); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop64;
            	    }
            	} while (true);

            	loop64:
            		;	// Stops C# compiler whining that label 'loop64' has no statements

            	char_literal139=(IToken)Match(input,34,FOLLOW_34_in_forStatement999); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal139_tree = (object)adaptor.Create(char_literal139);
            		adaptor.AddChild(root_0, char_literal139_tree);
            	}
            	// JavaScript.g:190:122: ( LT )*
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
            			    	LT140=(IToken)Match(input,LT,FOLLOW_LT_in_forStatement1001); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop65;
            	    }
            	} while (true);

            	loop65:
            		;	// Stops C# compiler whining that label 'loop65' has no statements

            	PushFollow(FOLLOW_statement_in_forStatement1005);
            	statement141 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement141.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class forStatementInitialiserPart_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forStatementInitialiserPart"
    // JavaScript.g:193:1: forStatementInitialiserPart : ( expressionNoIn | 'var' ( LT )* variableDeclarationListNoIn );
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

         const string elementName = "forStatementInitialiserPart"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 25) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:196:2: ( expressionNoIn | 'var' ( LT )* variableDeclarationListNoIn )
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
                    // JavaScript.g:196:4: expressionNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expressionNoIn_in_forStatementInitialiserPart1027);
                    	expressionNoIn142 = expressionNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expressionNoIn142.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:197:4: 'var' ( LT )* variableDeclarationListNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal143=(IToken)Match(input,37,FOLLOW_37_in_forStatementInitialiserPart1032); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal143_tree = (object)adaptor.Create(string_literal143);
                    		adaptor.AddChild(root_0, string_literal143_tree);
                    	}
                    	// JavaScript.g:197:12: ( LT )*
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
                    			    	LT144=(IToken)Match(input,LT,FOLLOW_LT_in_forStatementInitialiserPart1034); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop66;
                    	    }
                    	} while (true);

                    	loop66:
                    		;	// Stops C# compiler whining that label 'loop66' has no statements

                    	PushFollow(FOLLOW_variableDeclarationListNoIn_in_forStatementInitialiserPart1038);
                    	variableDeclarationListNoIn145 = variableDeclarationListNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationListNoIn145.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class forInStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forInStatement"
    // JavaScript.g:200:1: forInStatement : 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* ')' ( LT )* statement ;
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

         const string elementName = "forInStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 26) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:203:2: ( 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* ')' ( LT )* statement )
            // JavaScript.g:203:4: 'for' ( LT )* '(' ( LT )* forInStatementInitialiserPart ( LT )* 'in' ( LT )* expression ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal146=(IToken)Match(input,44,FOLLOW_44_in_forInStatement1060); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal146_tree = (object)adaptor.Create(string_literal146);
            		adaptor.AddChild(root_0, string_literal146_tree);
            	}
            	// JavaScript.g:203:12: ( LT )*
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
            			    	LT147=(IToken)Match(input,LT,FOLLOW_LT_in_forInStatement1062); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop68;
            	    }
            	} while (true);

            	loop68:
            		;	// Stops C# compiler whining that label 'loop68' has no statements

            	char_literal148=(IToken)Match(input,32,FOLLOW_32_in_forInStatement1066); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal148_tree = (object)adaptor.Create(char_literal148);
            		adaptor.AddChild(root_0, char_literal148_tree);
            	}
            	// JavaScript.g:203:21: ( LT )*
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
            			    	LT149=(IToken)Match(input,LT,FOLLOW_LT_in_forInStatement1068); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop69;
            	    }
            	} while (true);

            	loop69:
            		;	// Stops C# compiler whining that label 'loop69' has no statements

            	PushFollow(FOLLOW_forInStatementInitialiserPart_in_forInStatement1072);
            	forInStatementInitialiserPart150 = forInStatementInitialiserPart();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, forInStatementInitialiserPart150.Tree);
            	// JavaScript.g:203:56: ( LT )*
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
            			    	LT151=(IToken)Match(input,LT,FOLLOW_LT_in_forInStatement1074); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop70;
            	    }
            	} while (true);

            	loop70:
            		;	// Stops C# compiler whining that label 'loop70' has no statements

            	string_literal152=(IToken)Match(input,45,FOLLOW_45_in_forInStatement1078); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal152_tree = (object)adaptor.Create(string_literal152);
            		adaptor.AddChild(root_0, string_literal152_tree);
            	}
            	// JavaScript.g:203:66: ( LT )*
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
            			    	LT153=(IToken)Match(input,LT,FOLLOW_LT_in_forInStatement1080); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop71;
            	    }
            	} while (true);

            	loop71:
            		;	// Stops C# compiler whining that label 'loop71' has no statements

            	PushFollow(FOLLOW_expression_in_forInStatement1084);
            	expression154 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression154.Tree);
            	// JavaScript.g:203:82: ( LT )*
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
            			    	LT155=(IToken)Match(input,LT,FOLLOW_LT_in_forInStatement1086); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop72;
            	    }
            	} while (true);

            	loop72:
            		;	// Stops C# compiler whining that label 'loop72' has no statements

            	char_literal156=(IToken)Match(input,34,FOLLOW_34_in_forInStatement1090); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal156_tree = (object)adaptor.Create(char_literal156);
            		adaptor.AddChild(root_0, char_literal156_tree);
            	}
            	// JavaScript.g:203:91: ( LT )*
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
            			    	LT157=(IToken)Match(input,LT,FOLLOW_LT_in_forInStatement1092); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop73;
            	    }
            	} while (true);

            	loop73:
            		;	// Stops C# compiler whining that label 'loop73' has no statements

            	PushFollow(FOLLOW_statement_in_forInStatement1096);
            	statement158 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement158.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class forInStatementInitialiserPart_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "forInStatementInitialiserPart"
    // JavaScript.g:206:1: forInStatementInitialiserPart : ( leftHandSideExpression | 'var' ( LT )* variableDeclarationNoIn );
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

         const string elementName = "forInStatementInitialiserPart"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 27) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:209:2: ( leftHandSideExpression | 'var' ( LT )* variableDeclarationNoIn )
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
                    // JavaScript.g:209:4: leftHandSideExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_leftHandSideExpression_in_forInStatementInitialiserPart1118);
                    	leftHandSideExpression159 = leftHandSideExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression159.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:210:4: 'var' ( LT )* variableDeclarationNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal160=(IToken)Match(input,37,FOLLOW_37_in_forInStatementInitialiserPart1123); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal160_tree = (object)adaptor.Create(string_literal160);
                    		adaptor.AddChild(root_0, string_literal160_tree);
                    	}
                    	// JavaScript.g:210:12: ( LT )*
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
                    			    	LT161=(IToken)Match(input,LT,FOLLOW_LT_in_forInStatementInitialiserPart1125); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop74;
                    	    }
                    	} while (true);

                    	loop74:
                    		;	// Stops C# compiler whining that label 'loop74' has no statements

                    	PushFollow(FOLLOW_variableDeclarationNoIn_in_forInStatementInitialiserPart1129);
                    	variableDeclarationNoIn162 = variableDeclarationNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, variableDeclarationNoIn162.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class continueStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "continueStatement"
    // JavaScript.g:213:1: continueStatement : 'continue' ( Identifier )? ( LT | ';' ) ;
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

         const string elementName = "continueStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 28) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:216:2: ( 'continue' ( Identifier )? ( LT | ';' ) )
            // JavaScript.g:216:4: 'continue' ( Identifier )? ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal163=(IToken)Match(input,46,FOLLOW_46_in_continueStatement1150); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal163_tree = (object)adaptor.Create(string_literal163);
            		adaptor.AddChild(root_0, string_literal163_tree);
            	}
            	// JavaScript.g:216:15: ( Identifier )?
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
            	        	Identifier164=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_continueStatement1152); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier164_tree = (object)adaptor.Create(Identifier164);
            	        		adaptor.AddChild(root_0, Identifier164_tree);
            	        	}

            	        }
            	        break;

            	}

            	set165 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set165));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class breakStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "breakStatement"
    // JavaScript.g:219:1: breakStatement : 'break' ( Identifier )? ( LT | ';' ) ;
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

         const string elementName = "breakStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 29) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:222:2: ( 'break' ( Identifier )? ( LT | ';' ) )
            // JavaScript.g:222:4: 'break' ( Identifier )? ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal166=(IToken)Match(input,47,FOLLOW_47_in_breakStatement1182); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal166_tree = (object)adaptor.Create(string_literal166);
            		adaptor.AddChild(root_0, string_literal166_tree);
            	}
            	// JavaScript.g:222:12: ( Identifier )?
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
            	        	Identifier167=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_breakStatement1184); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{Identifier167_tree = (object)adaptor.Create(Identifier167);
            	        		adaptor.AddChild(root_0, Identifier167_tree);
            	        	}

            	        }
            	        break;

            	}

            	set168 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set168));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class returnStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "returnStatement"
    // JavaScript.g:225:1: returnStatement : 'return' ( expression )? ( LT | ';' ) ;
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

         const string elementName = "returnStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 30) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:228:2: ( 'return' ( expression )? ( LT | ';' ) )
            // JavaScript.g:228:4: 'return' ( expression )? ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal169=(IToken)Match(input,48,FOLLOW_48_in_returnStatement1214); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal169_tree = (object)adaptor.Create(string_literal169);
            		adaptor.AddChild(root_0, string_literal169_tree);
            	}
            	// JavaScript.g:228:13: ( expression )?
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
            	        	PushFollow(FOLLOW_expression_in_returnStatement1216);
            	        	expression170 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression170.Tree);

            	        }
            	        break;

            	}

            	set171 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set171));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class withStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "withStatement"
    // JavaScript.g:231:1: withStatement : 'with' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement ;
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

         const string elementName = "withStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 31) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:234:2: ( 'with' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement )
            // JavaScript.g:234:4: 'with' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal172=(IToken)Match(input,49,FOLLOW_49_in_withStatement1247); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal172_tree = (object)adaptor.Create(string_literal172);
            		adaptor.AddChild(root_0, string_literal172_tree);
            	}
            	// JavaScript.g:234:13: ( LT )*
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
            			    	LT173=(IToken)Match(input,LT,FOLLOW_LT_in_withStatement1249); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop79;
            	    }
            	} while (true);

            	loop79:
            		;	// Stops C# compiler whining that label 'loop79' has no statements

            	char_literal174=(IToken)Match(input,32,FOLLOW_32_in_withStatement1253); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal174_tree = (object)adaptor.Create(char_literal174);
            		adaptor.AddChild(root_0, char_literal174_tree);
            	}
            	// JavaScript.g:234:22: ( LT )*
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
            			    	LT175=(IToken)Match(input,LT,FOLLOW_LT_in_withStatement1255); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop80;
            	    }
            	} while (true);

            	loop80:
            		;	// Stops C# compiler whining that label 'loop80' has no statements

            	PushFollow(FOLLOW_expression_in_withStatement1259);
            	expression176 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression176.Tree);
            	// JavaScript.g:234:38: ( LT )*
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
            			    	LT177=(IToken)Match(input,LT,FOLLOW_LT_in_withStatement1261); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop81;
            	    }
            	} while (true);

            	loop81:
            		;	// Stops C# compiler whining that label 'loop81' has no statements

            	char_literal178=(IToken)Match(input,34,FOLLOW_34_in_withStatement1265); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal178_tree = (object)adaptor.Create(char_literal178);
            		adaptor.AddChild(root_0, char_literal178_tree);
            	}
            	// JavaScript.g:234:47: ( LT )*
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
            			    	LT179=(IToken)Match(input,LT,FOLLOW_LT_in_withStatement1267); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop82;
            	    }
            	} while (true);

            	loop82:
            		;	// Stops C# compiler whining that label 'loop82' has no statements

            	PushFollow(FOLLOW_statement_in_withStatement1271);
            	statement180 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement180.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class labelledStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "labelledStatement"
    // JavaScript.g:237:1: labelledStatement : Identifier ( LT )* ':' ( LT )* statement ;
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

         const string elementName = "labelledStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 32) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:240:2: ( Identifier ( LT )* ':' ( LT )* statement )
            // JavaScript.g:240:4: Identifier ( LT )* ':' ( LT )* statement
            {
            	root_0 = (object)adaptor.GetNilNode();

            	Identifier181=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_labelledStatement1292); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier181_tree = (object)adaptor.Create(Identifier181);
            		adaptor.AddChild(root_0, Identifier181_tree);
            	}
            	// JavaScript.g:240:17: ( LT )*
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
            			    	LT182=(IToken)Match(input,LT,FOLLOW_LT_in_labelledStatement1294); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop83;
            	    }
            	} while (true);

            	loop83:
            		;	// Stops C# compiler whining that label 'loop83' has no statements

            	char_literal183=(IToken)Match(input,50,FOLLOW_50_in_labelledStatement1298); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal183_tree = (object)adaptor.Create(char_literal183);
            		adaptor.AddChild(root_0, char_literal183_tree);
            	}
            	// JavaScript.g:240:26: ( LT )*
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
            			    	LT184=(IToken)Match(input,LT,FOLLOW_LT_in_labelledStatement1300); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop84;
            	    }
            	} while (true);

            	loop84:
            		;	// Stops C# compiler whining that label 'loop84' has no statements

            	PushFollow(FOLLOW_statement_in_labelledStatement1304);
            	statement185 = statement();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement185.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class switchStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "switchStatement"
    // JavaScript.g:243:1: switchStatement : 'switch' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* caseBlock ;
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

         const string elementName = "switchStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 33) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:246:2: ( 'switch' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* caseBlock )
            // JavaScript.g:246:4: 'switch' ( LT )* '(' ( LT )* expression ( LT )* ')' ( LT )* caseBlock
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal186=(IToken)Match(input,51,FOLLOW_51_in_switchStatement1326); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal186_tree = (object)adaptor.Create(string_literal186);
            		adaptor.AddChild(root_0, string_literal186_tree);
            	}
            	// JavaScript.g:246:15: ( LT )*
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
            			    	LT187=(IToken)Match(input,LT,FOLLOW_LT_in_switchStatement1328); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop85;
            	    }
            	} while (true);

            	loop85:
            		;	// Stops C# compiler whining that label 'loop85' has no statements

            	char_literal188=(IToken)Match(input,32,FOLLOW_32_in_switchStatement1332); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal188_tree = (object)adaptor.Create(char_literal188);
            		adaptor.AddChild(root_0, char_literal188_tree);
            	}
            	// JavaScript.g:246:24: ( LT )*
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
            			    	LT189=(IToken)Match(input,LT,FOLLOW_LT_in_switchStatement1334); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop86;
            	    }
            	} while (true);

            	loop86:
            		;	// Stops C# compiler whining that label 'loop86' has no statements

            	PushFollow(FOLLOW_expression_in_switchStatement1338);
            	expression190 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression190.Tree);
            	// JavaScript.g:246:40: ( LT )*
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
            			    	LT191=(IToken)Match(input,LT,FOLLOW_LT_in_switchStatement1340); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop87;
            	    }
            	} while (true);

            	loop87:
            		;	// Stops C# compiler whining that label 'loop87' has no statements

            	char_literal192=(IToken)Match(input,34,FOLLOW_34_in_switchStatement1344); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal192_tree = (object)adaptor.Create(char_literal192);
            		adaptor.AddChild(root_0, char_literal192_tree);
            	}
            	// JavaScript.g:246:49: ( LT )*
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
            			    	LT193=(IToken)Match(input,LT,FOLLOW_LT_in_switchStatement1346); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop88;
            	    }
            	} while (true);

            	loop88:
            		;	// Stops C# compiler whining that label 'loop88' has no statements

            	PushFollow(FOLLOW_caseBlock_in_switchStatement1350);
            	caseBlock194 = caseBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseBlock194.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class caseBlock_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "caseBlock"
    // JavaScript.g:249:1: caseBlock : '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* '}' ;
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

         const string elementName = "caseBlock"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 34) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:252:2: ( '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* '}' )
            // JavaScript.g:252:4: '{' ( ( LT )* caseClause )* ( ( LT )* defaultClause ( ( LT )* caseClause )* )? ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal195=(IToken)Match(input,35,FOLLOW_35_in_caseBlock1372); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal195_tree = (object)adaptor.Create(char_literal195);
            		adaptor.AddChild(root_0, char_literal195_tree);
            	}
            	// JavaScript.g:252:8: ( ( LT )* caseClause )*
            	do 
            	{
            	    int alt90 = 2;
            	    alt90 = dfa90.Predict(input);
            	    switch (alt90) 
            		{
            			case 1 :
            			    // JavaScript.g:252:9: ( LT )* caseClause
            			    {
            			    	// JavaScript.g:252:11: ( LT )*
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
            			    			    	LT196=(IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1375); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop89;
            			    	    }
            			    	} while (true);

            			    	loop89:
            			    		;	// Stops C# compiler whining that label 'loop89' has no statements

            			    	PushFollow(FOLLOW_caseClause_in_caseBlock1379);
            			    	caseClause197 = caseClause();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseClause197.Tree);

            			    }
            			    break;

            			default:
            			    goto loop90;
            	    }
            	} while (true);

            	loop90:
            		;	// Stops C# compiler whining that label 'loop90' has no statements

            	// JavaScript.g:252:27: ( ( LT )* defaultClause ( ( LT )* caseClause )* )?
            	int alt94 = 2;
            	alt94 = dfa94.Predict(input);
            	switch (alt94) 
            	{
            	    case 1 :
            	        // JavaScript.g:252:28: ( LT )* defaultClause ( ( LT )* caseClause )*
            	        {
            	        	// JavaScript.g:252:30: ( LT )*
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
            	        			    	LT198=(IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1384); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop91;
            	        	    }
            	        	} while (true);

            	        	loop91:
            	        		;	// Stops C# compiler whining that label 'loop91' has no statements

            	        	PushFollow(FOLLOW_defaultClause_in_caseBlock1388);
            	        	defaultClause199 = defaultClause();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, defaultClause199.Tree);
            	        	// JavaScript.g:252:47: ( ( LT )* caseClause )*
            	        	do 
            	        	{
            	        	    int alt93 = 2;
            	        	    alt93 = dfa93.Predict(input);
            	        	    switch (alt93) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:252:48: ( LT )* caseClause
            	        			    {
            	        			    	// JavaScript.g:252:50: ( LT )*
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
            	        			    			    	LT200=(IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1391); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop92;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop92:
            	        			    		;	// Stops C# compiler whining that label 'loop92' has no statements

            	        			    	PushFollow(FOLLOW_caseClause_in_caseBlock1395);
            	        			    	caseClause201 = caseClause();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, caseClause201.Tree);

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

            	// JavaScript.g:252:70: ( LT )*
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
            			    	LT202=(IToken)Match(input,LT,FOLLOW_LT_in_caseBlock1401); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop95;
            	    }
            	} while (true);

            	loop95:
            		;	// Stops C# compiler whining that label 'loop95' has no statements

            	char_literal203=(IToken)Match(input,36,FOLLOW_36_in_caseBlock1405); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal203_tree = (object)adaptor.Create(char_literal203);
            		adaptor.AddChild(root_0, char_literal203_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class caseClause_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "caseClause"
    // JavaScript.g:255:1: caseClause : 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )? ;
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

         const string elementName = "caseClause"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 35) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:258:2: ( 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )? )
            // JavaScript.g:258:4: 'case' ( LT )* expression ( LT )* ':' ( LT )* ( statementList )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal204=(IToken)Match(input,52,FOLLOW_52_in_caseClause1426); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal204_tree = (object)adaptor.Create(string_literal204);
            		adaptor.AddChild(root_0, string_literal204_tree);
            	}
            	// JavaScript.g:258:13: ( LT )*
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
            			    	LT205=(IToken)Match(input,LT,FOLLOW_LT_in_caseClause1428); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop96;
            	    }
            	} while (true);

            	loop96:
            		;	// Stops C# compiler whining that label 'loop96' has no statements

            	PushFollow(FOLLOW_expression_in_caseClause1432);
            	expression206 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression206.Tree);
            	// JavaScript.g:258:29: ( LT )*
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
            			    	LT207=(IToken)Match(input,LT,FOLLOW_LT_in_caseClause1434); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop97;
            	    }
            	} while (true);

            	loop97:
            		;	// Stops C# compiler whining that label 'loop97' has no statements

            	char_literal208=(IToken)Match(input,50,FOLLOW_50_in_caseClause1438); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal208_tree = (object)adaptor.Create(char_literal208);
            		adaptor.AddChild(root_0, char_literal208_tree);
            	}
            	// JavaScript.g:258:38: ( LT )*
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
            			    	LT209=(IToken)Match(input,LT,FOLLOW_LT_in_caseClause1440); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop98;
            	    }
            	} while (true);

            	loop98:
            		;	// Stops C# compiler whining that label 'loop98' has no statements

            	// JavaScript.g:258:41: ( statementList )?
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
            	        	PushFollow(FOLLOW_statementList_in_caseClause1444);
            	        	statementList210 = statementList();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList210.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class defaultClause_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "defaultClause"
    // JavaScript.g:261:1: defaultClause : 'default' ( LT )* ':' ( LT )* ( statementList )? ;
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

         const string elementName = "defaultClause"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 36) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:264:2: ( 'default' ( LT )* ':' ( LT )* ( statementList )? )
            // JavaScript.g:264:4: 'default' ( LT )* ':' ( LT )* ( statementList )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal211=(IToken)Match(input,53,FOLLOW_53_in_defaultClause1467); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal211_tree = (object)adaptor.Create(string_literal211);
            		adaptor.AddChild(root_0, string_literal211_tree);
            	}
            	// JavaScript.g:264:16: ( LT )*
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
            			    	LT212=(IToken)Match(input,LT,FOLLOW_LT_in_defaultClause1469); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop100;
            	    }
            	} while (true);

            	loop100:
            		;	// Stops C# compiler whining that label 'loop100' has no statements

            	char_literal213=(IToken)Match(input,50,FOLLOW_50_in_defaultClause1473); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal213_tree = (object)adaptor.Create(char_literal213);
            		adaptor.AddChild(root_0, char_literal213_tree);
            	}
            	// JavaScript.g:264:25: ( LT )*
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
            			    	LT214=(IToken)Match(input,LT,FOLLOW_LT_in_defaultClause1475); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop101;
            	    }
            	} while (true);

            	loop101:
            		;	// Stops C# compiler whining that label 'loop101' has no statements

            	// JavaScript.g:264:28: ( statementList )?
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
            	        	PushFollow(FOLLOW_statementList_in_defaultClause1479);
            	        	statementList215 = statementList();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementList215.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class throwStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "throwStatement"
    // JavaScript.g:267:1: throwStatement : 'throw' expression ( LT | ';' ) ;
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

         const string elementName = "throwStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 37) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:270:2: ( 'throw' expression ( LT | ';' ) )
            // JavaScript.g:270:4: 'throw' expression ( LT | ';' )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal216=(IToken)Match(input,54,FOLLOW_54_in_throwStatement1502); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal216_tree = (object)adaptor.Create(string_literal216);
            		adaptor.AddChild(root_0, string_literal216_tree);
            	}
            	PushFollow(FOLLOW_expression_in_throwStatement1504);
            	expression217 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression217.Tree);
            	set218 = (IToken)input.LT(1);
            	if ( input.LA(1) == LT || input.LA(1) == 38 ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set218));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class tryStatement_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "tryStatement"
    // JavaScript.g:273:1: tryStatement : 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? ) ;
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

         const string elementName = "tryStatement"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 38) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:276:2: ( 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? ) )
            // JavaScript.g:276:4: 'try' ( LT )* statementBlock ( LT )* ( finallyClause | catchClause ( ( LT )* finallyClause )? )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal219=(IToken)Match(input,55,FOLLOW_55_in_tryStatement1533); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal219_tree = (object)adaptor.Create(string_literal219);
            		adaptor.AddChild(root_0, string_literal219_tree);
            	}
            	// JavaScript.g:276:12: ( LT )*
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
            			    	LT220=(IToken)Match(input,LT,FOLLOW_LT_in_tryStatement1535); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop103;
            	    }
            	} while (true);

            	loop103:
            		;	// Stops C# compiler whining that label 'loop103' has no statements

            	PushFollow(FOLLOW_statementBlock_in_tryStatement1539);
            	statementBlock221 = statementBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock221.Tree);
            	// JavaScript.g:276:32: ( LT )*
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
            			    	LT222=(IToken)Match(input,LT,FOLLOW_LT_in_tryStatement1541); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop104;
            	    }
            	} while (true);

            	loop104:
            		;	// Stops C# compiler whining that label 'loop104' has no statements

            	// JavaScript.g:276:35: ( finallyClause | catchClause ( ( LT )* finallyClause )? )
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
            	        // JavaScript.g:276:36: finallyClause
            	        {
            	        	PushFollow(FOLLOW_finallyClause_in_tryStatement1546);
            	        	finallyClause223 = finallyClause();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause223.Tree);

            	        }
            	        break;
            	    case 2 :
            	        // JavaScript.g:276:52: catchClause ( ( LT )* finallyClause )?
            	        {
            	        	PushFollow(FOLLOW_catchClause_in_tryStatement1550);
            	        	catchClause224 = catchClause();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, catchClause224.Tree);
            	        	// JavaScript.g:276:64: ( ( LT )* finallyClause )?
            	        	int alt106 = 2;
            	        	alt106 = dfa106.Predict(input);
            	        	switch (alt106) 
            	        	{
            	        	    case 1 :
            	        	        // JavaScript.g:276:65: ( LT )* finallyClause
            	        	        {
            	        	        	// JavaScript.g:276:67: ( LT )*
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
            	        	        			    	LT225=(IToken)Match(input,LT,FOLLOW_LT_in_tryStatement1553); if (state.failed) return retval;

            	        	        			    }
            	        	        			    break;

            	        	        			default:
            	        	        			    goto loop105;
            	        	        	    }
            	        	        	} while (true);

            	        	        	loop105:
            	        	        		;	// Stops C# compiler whining that label 'loop105' has no statements

            	        	        	PushFollow(FOLLOW_finallyClause_in_tryStatement1557);
            	        	        	finallyClause226 = finallyClause();
            	        	        	state.followingStackPointer--;
            	        	        	if (state.failed) return retval;
            	        	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, finallyClause226.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class catchClause_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "catchClause"
    // JavaScript.g:279:1: catchClause : 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* ')' ( LT )* statementBlock ;
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

         const string elementName = "catchClause"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 39) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:282:2: ( 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* ')' ( LT )* statementBlock )
            // JavaScript.g:282:4: 'catch' ( LT )* '(' ( LT )* Identifier ( LT )* ')' ( LT )* statementBlock
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal227=(IToken)Match(input,56,FOLLOW_56_in_catchClause1588); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal227_tree = (object)adaptor.Create(string_literal227);
            		adaptor.AddChild(root_0, string_literal227_tree);
            	}
            	// JavaScript.g:282:14: ( LT )*
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
            			    	LT228=(IToken)Match(input,LT,FOLLOW_LT_in_catchClause1590); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop108;
            	    }
            	} while (true);

            	loop108:
            		;	// Stops C# compiler whining that label 'loop108' has no statements

            	char_literal229=(IToken)Match(input,32,FOLLOW_32_in_catchClause1594); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal229_tree = (object)adaptor.Create(char_literal229);
            		adaptor.AddChild(root_0, char_literal229_tree);
            	}
            	// JavaScript.g:282:23: ( LT )*
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
            			    	LT230=(IToken)Match(input,LT,FOLLOW_LT_in_catchClause1596); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop109;
            	    }
            	} while (true);

            	loop109:
            		;	// Stops C# compiler whining that label 'loop109' has no statements

            	Identifier231=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_catchClause1600); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier231_tree = (object)adaptor.Create(Identifier231);
            		adaptor.AddChild(root_0, Identifier231_tree);
            	}
            	// JavaScript.g:282:39: ( LT )*
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
            			    	LT232=(IToken)Match(input,LT,FOLLOW_LT_in_catchClause1602); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop110;
            	    }
            	} while (true);

            	loop110:
            		;	// Stops C# compiler whining that label 'loop110' has no statements

            	char_literal233=(IToken)Match(input,34,FOLLOW_34_in_catchClause1606); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal233_tree = (object)adaptor.Create(char_literal233);
            		adaptor.AddChild(root_0, char_literal233_tree);
            	}
            	// JavaScript.g:282:48: ( LT )*
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
            			    	LT234=(IToken)Match(input,LT,FOLLOW_LT_in_catchClause1608); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop111;
            	    }
            	} while (true);

            	loop111:
            		;	// Stops C# compiler whining that label 'loop111' has no statements

            	PushFollow(FOLLOW_statementBlock_in_catchClause1612);
            	statementBlock235 = statementBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock235.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class finallyClause_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "finallyClause"
    // JavaScript.g:285:1: finallyClause : 'finally' ( LT )* statementBlock ;
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

         const string elementName = "finallyClause"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 40) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:288:2: ( 'finally' ( LT )* statementBlock )
            // JavaScript.g:288:4: 'finally' ( LT )* statementBlock
            {
            	root_0 = (object)adaptor.GetNilNode();

            	string_literal236=(IToken)Match(input,57,FOLLOW_57_in_finallyClause1634); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{string_literal236_tree = (object)adaptor.Create(string_literal236);
            		adaptor.AddChild(root_0, string_literal236_tree);
            	}
            	// JavaScript.g:288:16: ( LT )*
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
            			    	LT237=(IToken)Match(input,LT,FOLLOW_LT_in_finallyClause1636); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop112;
            	    }
            	} while (true);

            	loop112:
            		;	// Stops C# compiler whining that label 'loop112' has no statements

            	PushFollow(FOLLOW_statementBlock_in_finallyClause1640);
            	statementBlock238 = statementBlock();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statementBlock238.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class expression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expression"
    // JavaScript.g:292:1: expression : assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* ;
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

         const string elementName = "expression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 41) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:295:2: ( assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )
            // JavaScript.g:295:4: assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_assignmentExpression_in_expression1662);
            	assignmentExpression239 = assignmentExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression239.Tree);
            	// JavaScript.g:295:25: ( ( LT )* ',' ( LT )* assignmentExpression )*
            	do 
            	{
            	    int alt115 = 2;
            	    alt115 = dfa115.Predict(input);
            	    switch (alt115) 
            		{
            			case 1 :
            			    // JavaScript.g:295:26: ( LT )* ',' ( LT )* assignmentExpression
            			    {
            			    	// JavaScript.g:295:28: ( LT )*
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
            			    			    	LT240=(IToken)Match(input,LT,FOLLOW_LT_in_expression1665); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop113;
            			    	    }
            			    	} while (true);

            			    	loop113:
            			    		;	// Stops C# compiler whining that label 'loop113' has no statements

            			    	char_literal241=(IToken)Match(input,33,FOLLOW_33_in_expression1669); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal241_tree = (object)adaptor.Create(char_literal241);
            			    		adaptor.AddChild(root_0, char_literal241_tree);
            			    	}
            			    	// JavaScript.g:295:37: ( LT )*
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
            			    			    	LT242=(IToken)Match(input,LT,FOLLOW_LT_in_expression1671); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop114;
            			    	    }
            			    	} while (true);

            			    	loop114:
            			    		;	// Stops C# compiler whining that label 'loop114' has no statements

            			    	PushFollow(FOLLOW_assignmentExpression_in_expression1675);
            			    	assignmentExpression243 = assignmentExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression243.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class expressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expressionNoIn"
    // JavaScript.g:298:1: expressionNoIn : assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )* ;
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

         const string elementName = "expressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 42) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:301:2: ( assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )* )
            // JavaScript.g:301:4: assignmentExpressionNoIn ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1699);
            	assignmentExpressionNoIn244 = assignmentExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn244.Tree);
            	// JavaScript.g:301:29: ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*
            	do 
            	{
            	    int alt118 = 2;
            	    alt118 = dfa118.Predict(input);
            	    switch (alt118) 
            		{
            			case 1 :
            			    // JavaScript.g:301:30: ( LT )* ',' ( LT )* assignmentExpressionNoIn
            			    {
            			    	// JavaScript.g:301:32: ( LT )*
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
            			    			    	LT245=(IToken)Match(input,LT,FOLLOW_LT_in_expressionNoIn1702); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop116;
            			    	    }
            			    	} while (true);

            			    	loop116:
            			    		;	// Stops C# compiler whining that label 'loop116' has no statements

            			    	char_literal246=(IToken)Match(input,33,FOLLOW_33_in_expressionNoIn1706); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal246_tree = (object)adaptor.Create(char_literal246);
            			    		adaptor.AddChild(root_0, char_literal246_tree);
            			    	}
            			    	// JavaScript.g:301:41: ( LT )*
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
            			    			    	LT247=(IToken)Match(input,LT,FOLLOW_LT_in_expressionNoIn1708); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop117;
            			    	    }
            			    	} while (true);

            			    	loop117:
            			    		;	// Stops C# compiler whining that label 'loop117' has no statements

            			    	PushFollow(FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1712);
            			    	assignmentExpressionNoIn248 = assignmentExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn248.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class assignmentExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignmentExpression"
    // JavaScript.g:304:1: assignmentExpression : ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression );
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

         const string elementName = "assignmentExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 43) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:307:2: ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression )
            int alt121 = 2;
            alt121 = dfa121.Predict(input);
            switch (alt121) 
            {
                case 1 :
                    // JavaScript.g:307:4: conditionalExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_conditionalExpression_in_assignmentExpression1736);
                    	conditionalExpression249 = conditionalExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpression249.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:308:4: leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_leftHandSideExpression_in_assignmentExpression1741);
                    	leftHandSideExpression250 = leftHandSideExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression250.Tree);
                    	// JavaScript.g:308:29: ( LT )*
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
                    			    	LT251=(IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpression1743); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop119;
                    	    }
                    	} while (true);

                    	loop119:
                    		;	// Stops C# compiler whining that label 'loop119' has no statements

                    	PushFollow(FOLLOW_assignmentOperator_in_assignmentExpression1747);
                    	assignmentOperator252 = assignmentOperator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentOperator252.Tree);
                    	// JavaScript.g:308:53: ( LT )*
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
                    			    	LT253=(IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpression1749); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop120;
                    	    }
                    	} while (true);

                    	loop120:
                    		;	// Stops C# compiler whining that label 'loop120' has no statements

                    	PushFollow(FOLLOW_assignmentExpression_in_assignmentExpression1753);
                    	assignmentExpression254 = assignmentExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression254.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class assignmentExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignmentExpressionNoIn"
    // JavaScript.g:311:1: assignmentExpressionNoIn : ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn );
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

         const string elementName = "assignmentExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 44) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:314:2: ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn )
            int alt124 = 2;
            alt124 = dfa124.Predict(input);
            switch (alt124) 
            {
                case 1 :
                    // JavaScript.g:314:4: conditionalExpressionNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_conditionalExpressionNoIn_in_assignmentExpressionNoIn1775);
                    	conditionalExpressionNoIn255 = conditionalExpressionNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditionalExpressionNoIn255.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:315:4: leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_leftHandSideExpression_in_assignmentExpressionNoIn1780);
                    	leftHandSideExpression256 = leftHandSideExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression256.Tree);
                    	// JavaScript.g:315:29: ( LT )*
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
                    			    	LT257=(IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpressionNoIn1782); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop122;
                    	    }
                    	} while (true);

                    	loop122:
                    		;	// Stops C# compiler whining that label 'loop122' has no statements

                    	PushFollow(FOLLOW_assignmentOperator_in_assignmentExpressionNoIn1786);
                    	assignmentOperator258 = assignmentOperator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentOperator258.Tree);
                    	// JavaScript.g:315:53: ( LT )*
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
                    			    	LT259=(IToken)Match(input,LT,FOLLOW_LT_in_assignmentExpressionNoIn1788); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop123;
                    	    }
                    	} while (true);

                    	loop123:
                    		;	// Stops C# compiler whining that label 'loop123' has no statements

                    	PushFollow(FOLLOW_assignmentExpressionNoIn_in_assignmentExpressionNoIn1792);
                    	assignmentExpressionNoIn260 = assignmentExpressionNoIn();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn260.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class leftHandSideExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "leftHandSideExpression"
    // JavaScript.g:318:1: leftHandSideExpression : ( callExpression | newExpression );
    public JavaScriptParser.leftHandSideExpression_return leftHandSideExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.leftHandSideExpression_return retval = new JavaScriptParser.leftHandSideExpression_return();
        retval.Start = input.LT(1);
        int leftHandSideExpression_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.callExpression_return callExpression261 = default(JavaScriptParser.callExpression_return);

        JavaScriptParser.newExpression_return newExpression262 = default(JavaScriptParser.newExpression_return);



         const string elementName = "leftHandSideExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 45) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:321:2: ( callExpression | newExpression )
            int alt125 = 2;
            alt125 = dfa125.Predict(input);
            switch (alt125) 
            {
                case 1 :
                    // JavaScript.g:321:4: callExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_callExpression_in_leftHandSideExpression1814);
                    	callExpression261 = callExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, callExpression261.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:322:4: newExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_newExpression_in_leftHandSideExpression1819);
                    	newExpression262 = newExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, newExpression262.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class newExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "newExpression"
    // JavaScript.g:325:1: newExpression : ( memberExpression | 'new' ( LT )* newExpression );
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

         const string elementName = "newExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 46) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:328:2: ( memberExpression | 'new' ( LT )* newExpression )
            int alt127 = 2;
            alt127 = dfa127.Predict(input);
            switch (alt127) 
            {
                case 1 :
                    // JavaScript.g:328:4: memberExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_memberExpression_in_newExpression1841);
                    	memberExpression263 = memberExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression263.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:329:4: 'new' ( LT )* newExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal264=(IToken)Match(input,58,FOLLOW_58_in_newExpression1846); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal264_tree = (object)adaptor.Create(string_literal264);
                    		adaptor.AddChild(root_0, string_literal264_tree);
                    	}
                    	// JavaScript.g:329:12: ( LT )*
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
                    			    	LT265=(IToken)Match(input,LT,FOLLOW_LT_in_newExpression1848); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop126;
                    	    }
                    	} while (true);

                    	loop126:
                    		;	// Stops C# compiler whining that label 'loop126' has no statements

                    	PushFollow(FOLLOW_newExpression_in_newExpression1852);
                    	newExpression266 = newExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, newExpression266.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class memberExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "memberExpression"
    // JavaScript.g:332:1: memberExpression : ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )* ;
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

         const string elementName = "memberExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 47) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:335:2: ( ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )* )
            // JavaScript.g:335:4: ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments ) ( ( LT )* memberExpressionSuffix )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// JavaScript.g:335:4: ( primaryExpression | functionExpression | 'new' ( LT )* memberExpression ( LT )* arguments )
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
            	        // JavaScript.g:335:5: primaryExpression
            	        {
            	        	PushFollow(FOLLOW_primaryExpression_in_memberExpression1875);
            	        	primaryExpression267 = primaryExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primaryExpression267.Tree);

            	        }
            	        break;
            	    case 2 :
            	        // JavaScript.g:335:25: functionExpression
            	        {
            	        	PushFollow(FOLLOW_functionExpression_in_memberExpression1879);
            	        	functionExpression268 = functionExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, functionExpression268.Tree);

            	        }
            	        break;
            	    case 3 :
            	        // JavaScript.g:335:46: 'new' ( LT )* memberExpression ( LT )* arguments
            	        {
            	        	string_literal269=(IToken)Match(input,58,FOLLOW_58_in_memberExpression1883); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{string_literal269_tree = (object)adaptor.Create(string_literal269);
            	        		adaptor.AddChild(root_0, string_literal269_tree);
            	        	}
            	        	// JavaScript.g:335:54: ( LT )*
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
            	        			    	LT270=(IToken)Match(input,LT,FOLLOW_LT_in_memberExpression1885); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop128;
            	        	    }
            	        	} while (true);

            	        	loop128:
            	        		;	// Stops C# compiler whining that label 'loop128' has no statements

            	        	PushFollow(FOLLOW_memberExpression_in_memberExpression1889);
            	        	memberExpression271 = memberExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression271.Tree);
            	        	// JavaScript.g:335:76: ( LT )*
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
            	        			    	LT272=(IToken)Match(input,LT,FOLLOW_LT_in_memberExpression1891); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop129;
            	        	    }
            	        	} while (true);

            	        	loop129:
            	        		;	// Stops C# compiler whining that label 'loop129' has no statements

            	        	PushFollow(FOLLOW_arguments_in_memberExpression1895);
            	        	arguments273 = arguments();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments273.Tree);

            	        }
            	        break;

            	}

            	// JavaScript.g:335:90: ( ( LT )* memberExpressionSuffix )*
            	do 
            	{
            	    int alt132 = 2;
            	    alt132 = dfa132.Predict(input);
            	    switch (alt132) 
            		{
            			case 1 :
            			    // JavaScript.g:335:91: ( LT )* memberExpressionSuffix
            			    {
            			    	// JavaScript.g:335:93: ( LT )*
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
            			    			    	LT274=(IToken)Match(input,LT,FOLLOW_LT_in_memberExpression1899); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop131;
            			    	    }
            			    	} while (true);

            			    	loop131:
            			    		;	// Stops C# compiler whining that label 'loop131' has no statements

            			    	PushFollow(FOLLOW_memberExpressionSuffix_in_memberExpression1903);
            			    	memberExpressionSuffix275 = memberExpressionSuffix();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpressionSuffix275.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class memberExpressionSuffix_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "memberExpressionSuffix"
    // JavaScript.g:338:1: memberExpressionSuffix : ( indexSuffix | propertyReferenceSuffix );
    public JavaScriptParser.memberExpressionSuffix_return memberExpressionSuffix() // throws RecognitionException [1]
    {   
        JavaScriptParser.memberExpressionSuffix_return retval = new JavaScriptParser.memberExpressionSuffix_return();
        retval.Start = input.LT(1);
        int memberExpressionSuffix_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.indexSuffix_return indexSuffix276 = default(JavaScriptParser.indexSuffix_return);

        JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix277 = default(JavaScriptParser.propertyReferenceSuffix_return);



         const string elementName = "memberExpressionSuffix"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 48) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:341:2: ( indexSuffix | propertyReferenceSuffix )
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
                    // JavaScript.g:341:4: indexSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_indexSuffix_in_memberExpressionSuffix1927);
                    	indexSuffix276 = indexSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, indexSuffix276.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:342:4: propertyReferenceSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_propertyReferenceSuffix_in_memberExpressionSuffix1932);
                    	propertyReferenceSuffix277 = propertyReferenceSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyReferenceSuffix277.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class callExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "callExpression"
    // JavaScript.g:345:1: callExpression : memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )* ;
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

         const string elementName = "callExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 49) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:348:2: ( memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )* )
            // JavaScript.g:348:4: memberExpression ( LT )* arguments ( ( LT )* callExpressionSuffix )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_memberExpression_in_callExpression1953);
            	memberExpression278 = memberExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, memberExpression278.Tree);
            	// JavaScript.g:348:23: ( LT )*
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
            			    	LT279=(IToken)Match(input,LT,FOLLOW_LT_in_callExpression1955); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop134;
            	    }
            	} while (true);

            	loop134:
            		;	// Stops C# compiler whining that label 'loop134' has no statements

            	PushFollow(FOLLOW_arguments_in_callExpression1959);
            	arguments280 = arguments();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments280.Tree);
            	// JavaScript.g:348:36: ( ( LT )* callExpressionSuffix )*
            	do 
            	{
            	    int alt136 = 2;
            	    alt136 = dfa136.Predict(input);
            	    switch (alt136) 
            		{
            			case 1 :
            			    // JavaScript.g:348:37: ( LT )* callExpressionSuffix
            			    {
            			    	// JavaScript.g:348:39: ( LT )*
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
            			    			    	LT281=(IToken)Match(input,LT,FOLLOW_LT_in_callExpression1962); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop135;
            			    	    }
            			    	} while (true);

            			    	loop135:
            			    		;	// Stops C# compiler whining that label 'loop135' has no statements

            			    	PushFollow(FOLLOW_callExpressionSuffix_in_callExpression1966);
            			    	callExpressionSuffix282 = callExpressionSuffix();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, callExpressionSuffix282.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class callExpressionSuffix_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "callExpressionSuffix"
    // JavaScript.g:351:1: callExpressionSuffix : ( arguments | indexSuffix | propertyReferenceSuffix );
    public JavaScriptParser.callExpressionSuffix_return callExpressionSuffix() // throws RecognitionException [1]
    {   
        JavaScriptParser.callExpressionSuffix_return retval = new JavaScriptParser.callExpressionSuffix_return();
        retval.Start = input.LT(1);
        int callExpressionSuffix_StartIndex = input.Index();
        object root_0 = null;

        JavaScriptParser.arguments_return arguments283 = default(JavaScriptParser.arguments_return);

        JavaScriptParser.indexSuffix_return indexSuffix284 = default(JavaScriptParser.indexSuffix_return);

        JavaScriptParser.propertyReferenceSuffix_return propertyReferenceSuffix285 = default(JavaScriptParser.propertyReferenceSuffix_return);



         const string elementName = "callExpressionSuffix"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 50) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:354:2: ( arguments | indexSuffix | propertyReferenceSuffix )
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
                    // JavaScript.g:354:4: arguments
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_arguments_in_callExpressionSuffix1990);
                    	arguments283 = arguments();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arguments283.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:355:4: indexSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_indexSuffix_in_callExpressionSuffix1995);
                    	indexSuffix284 = indexSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, indexSuffix284.Tree);

                    }
                    break;
                case 3 :
                    // JavaScript.g:356:4: propertyReferenceSuffix
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_propertyReferenceSuffix_in_callExpressionSuffix2000);
                    	propertyReferenceSuffix285 = propertyReferenceSuffix();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyReferenceSuffix285.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class arguments_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "arguments"
    // JavaScript.g:359:1: arguments : '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* ')' ;
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

         const string elementName = "arguments"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 51) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:362:2: ( '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* ')' )
            // JavaScript.g:362:4: '(' ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )? ( LT )* ')'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal286=(IToken)Match(input,32,FOLLOW_32_in_arguments2021); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal286_tree = (object)adaptor.Create(char_literal286);
            		adaptor.AddChild(root_0, char_literal286_tree);
            	}
            	// JavaScript.g:362:8: ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )?
            	int alt142 = 2;
            	alt142 = dfa142.Predict(input);
            	switch (alt142) 
            	{
            	    case 1 :
            	        // JavaScript.g:362:9: ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )*
            	        {
            	        	// JavaScript.g:362:11: ( LT )*
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
            	        			    	LT287=(IToken)Match(input,LT,FOLLOW_LT_in_arguments2024); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop138;
            	        	    }
            	        	} while (true);

            	        	loop138:
            	        		;	// Stops C# compiler whining that label 'loop138' has no statements

            	        	PushFollow(FOLLOW_assignmentExpression_in_arguments2028);
            	        	assignmentExpression288 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression288.Tree);
            	        	// JavaScript.g:362:35: ( ( LT )* ',' ( LT )* assignmentExpression )*
            	        	do 
            	        	{
            	        	    int alt141 = 2;
            	        	    alt141 = dfa141.Predict(input);
            	        	    switch (alt141) 
            	        		{
            	        			case 1 :
            	        			    // JavaScript.g:362:36: ( LT )* ',' ( LT )* assignmentExpression
            	        			    {
            	        			    	// JavaScript.g:362:38: ( LT )*
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
            	        			    			    	LT289=(IToken)Match(input,LT,FOLLOW_LT_in_arguments2031); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop139;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop139:
            	        			    		;	// Stops C# compiler whining that label 'loop139' has no statements

            	        			    	char_literal290=(IToken)Match(input,33,FOLLOW_33_in_arguments2035); if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 )
            	        			    	{char_literal290_tree = (object)adaptor.Create(char_literal290);
            	        			    		adaptor.AddChild(root_0, char_literal290_tree);
            	        			    	}
            	        			    	// JavaScript.g:362:47: ( LT )*
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
            	        			    			    	LT291=(IToken)Match(input,LT,FOLLOW_LT_in_arguments2037); if (state.failed) return retval;

            	        			    			    }
            	        			    			    break;

            	        			    			default:
            	        			    			    goto loop140;
            	        			    	    }
            	        			    	} while (true);

            	        			    	loop140:
            	        			    		;	// Stops C# compiler whining that label 'loop140' has no statements

            	        			    	PushFollow(FOLLOW_assignmentExpression_in_arguments2041);
            	        			    	assignmentExpression292 = assignmentExpression();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression292.Tree);

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

            	// JavaScript.g:362:77: ( LT )*
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
            			    	LT293=(IToken)Match(input,LT,FOLLOW_LT_in_arguments2047); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop143;
            	    }
            	} while (true);

            	loop143:
            		;	// Stops C# compiler whining that label 'loop143' has no statements

            	char_literal294=(IToken)Match(input,34,FOLLOW_34_in_arguments2051); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal294_tree = (object)adaptor.Create(char_literal294);
            		adaptor.AddChild(root_0, char_literal294_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class indexSuffix_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "indexSuffix"
    // JavaScript.g:365:1: indexSuffix : '[' ( LT )* expression ( LT )* ']' ;
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

         const string elementName = "indexSuffix"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 52) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:368:2: ( '[' ( LT )* expression ( LT )* ']' )
            // JavaScript.g:368:4: '[' ( LT )* expression ( LT )* ']'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal295=(IToken)Match(input,59,FOLLOW_59_in_indexSuffix2073); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal295_tree = (object)adaptor.Create(char_literal295);
            		adaptor.AddChild(root_0, char_literal295_tree);
            	}
            	// JavaScript.g:368:10: ( LT )*
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
            			    	LT296=(IToken)Match(input,LT,FOLLOW_LT_in_indexSuffix2075); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop144;
            	    }
            	} while (true);

            	loop144:
            		;	// Stops C# compiler whining that label 'loop144' has no statements

            	PushFollow(FOLLOW_expression_in_indexSuffix2079);
            	expression297 = expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression297.Tree);
            	// JavaScript.g:368:26: ( LT )*
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
            			    	LT298=(IToken)Match(input,LT,FOLLOW_LT_in_indexSuffix2081); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop145;
            	    }
            	} while (true);

            	loop145:
            		;	// Stops C# compiler whining that label 'loop145' has no statements

            	char_literal299=(IToken)Match(input,60,FOLLOW_60_in_indexSuffix2085); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal299_tree = (object)adaptor.Create(char_literal299);
            		adaptor.AddChild(root_0, char_literal299_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class propertyReferenceSuffix_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "propertyReferenceSuffix"
    // JavaScript.g:371:1: propertyReferenceSuffix : '.' ( LT )* Identifier ;
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

         const string elementName = "propertyReferenceSuffix"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 53) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:374:2: ( '.' ( LT )* Identifier )
            // JavaScript.g:374:4: '.' ( LT )* Identifier
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal300=(IToken)Match(input,61,FOLLOW_61_in_propertyReferenceSuffix2108); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal300_tree = (object)adaptor.Create(char_literal300);
            		adaptor.AddChild(root_0, char_literal300_tree);
            	}
            	// JavaScript.g:374:10: ( LT )*
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
            			    	LT301=(IToken)Match(input,LT,FOLLOW_LT_in_propertyReferenceSuffix2110); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop146;
            	    }
            	} while (true);

            	loop146:
            		;	// Stops C# compiler whining that label 'loop146' has no statements

            	Identifier302=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_propertyReferenceSuffix2114); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{Identifier302_tree = (object)adaptor.Create(Identifier302);
            		adaptor.AddChild(root_0, Identifier302_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class assignmentOperator_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignmentOperator"
    // JavaScript.g:377:1: assignmentOperator : ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '>>>=' | '&=' | '^=' | '|=' );
    public JavaScriptParser.assignmentOperator_return assignmentOperator() // throws RecognitionException [1]
    {   
        JavaScriptParser.assignmentOperator_return retval = new JavaScriptParser.assignmentOperator_return();
        retval.Start = input.LT(1);
        int assignmentOperator_StartIndex = input.Index();
        object root_0 = null;

        IToken set303 = null;

        object set303_tree=null;

         const string elementName = "assignmentOperator"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 54) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:380:2: ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '>>>=' | '&=' | '^=' | '|=' )
            // JavaScript.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set303 = (IToken)input.LT(1);
            	if ( input.LA(1) == 39 || (input.LA(1) >= 62 && input.LA(1) <= 72) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set303));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class conditionalExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "conditionalExpression"
    // JavaScript.g:383:1: conditionalExpression : logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )? ;
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

         const string elementName = "conditionalExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 55) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:386:2: ( logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )? )
            // JavaScript.g:386:4: logicalORExpression ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalORExpression_in_conditionalExpression2201);
            	logicalORExpression304 = logicalORExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalORExpression304.Tree);
            	// JavaScript.g:386:24: ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?
            	int alt151 = 2;
            	alt151 = dfa151.Predict(input);
            	switch (alt151) 
            	{
            	    case 1 :
            	        // JavaScript.g:386:25: ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression
            	        {
            	        	// JavaScript.g:386:27: ( LT )*
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
            	        			    	LT305=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression2204); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop147;
            	        	    }
            	        	} while (true);

            	        	loop147:
            	        		;	// Stops C# compiler whining that label 'loop147' has no statements

            	        	char_literal306=(IToken)Match(input,73,FOLLOW_73_in_conditionalExpression2208); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal306_tree = (object)adaptor.Create(char_literal306);
            	        		adaptor.AddChild(root_0, char_literal306_tree);
            	        	}
            	        	// JavaScript.g:386:36: ( LT )*
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
            	        			    	LT307=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression2210); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop148;
            	        	    }
            	        	} while (true);

            	        	loop148:
            	        		;	// Stops C# compiler whining that label 'loop148' has no statements

            	        	PushFollow(FOLLOW_assignmentExpression_in_conditionalExpression2214);
            	        	assignmentExpression308 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression308.Tree);
            	        	// JavaScript.g:386:62: ( LT )*
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
            	        			    	LT309=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression2216); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop149;
            	        	    }
            	        	} while (true);

            	        	loop149:
            	        		;	// Stops C# compiler whining that label 'loop149' has no statements

            	        	char_literal310=(IToken)Match(input,50,FOLLOW_50_in_conditionalExpression2220); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal310_tree = (object)adaptor.Create(char_literal310);
            	        		adaptor.AddChild(root_0, char_literal310_tree);
            	        	}
            	        	// JavaScript.g:386:71: ( LT )*
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
            	        			    	LT311=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpression2222); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop150;
            	        	    }
            	        	} while (true);

            	        	loop150:
            	        		;	// Stops C# compiler whining that label 'loop150' has no statements

            	        	PushFollow(FOLLOW_assignmentExpression_in_conditionalExpression2226);
            	        	assignmentExpression312 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression312.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class conditionalExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "conditionalExpressionNoIn"
    // JavaScript.g:389:1: conditionalExpressionNoIn : logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )? ;
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

         const string elementName = "conditionalExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 56) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:392:2: ( logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )? )
            // JavaScript.g:392:4: logicalORExpressionNoIn ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalORExpressionNoIn_in_conditionalExpressionNoIn2249);
            	logicalORExpressionNoIn313 = logicalORExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalORExpressionNoIn313.Tree);
            	// JavaScript.g:392:28: ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?
            	int alt156 = 2;
            	alt156 = dfa156.Predict(input);
            	switch (alt156) 
            	{
            	    case 1 :
            	        // JavaScript.g:392:29: ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn
            	        {
            	        	// JavaScript.g:392:31: ( LT )*
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
            	        			    	LT314=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn2252); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop152;
            	        	    }
            	        	} while (true);

            	        	loop152:
            	        		;	// Stops C# compiler whining that label 'loop152' has no statements

            	        	char_literal315=(IToken)Match(input,73,FOLLOW_73_in_conditionalExpressionNoIn2256); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal315_tree = (object)adaptor.Create(char_literal315);
            	        		adaptor.AddChild(root_0, char_literal315_tree);
            	        	}
            	        	// JavaScript.g:392:40: ( LT )*
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
            	        			    	LT316=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn2258); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop153;
            	        	    }
            	        	} while (true);

            	        	loop153:
            	        		;	// Stops C# compiler whining that label 'loop153' has no statements

            	        	PushFollow(FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn2262);
            	        	assignmentExpressionNoIn317 = assignmentExpressionNoIn();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn317.Tree);
            	        	// JavaScript.g:392:70: ( LT )*
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
            	        			    	LT318=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn2264); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop154;
            	        	    }
            	        	} while (true);

            	        	loop154:
            	        		;	// Stops C# compiler whining that label 'loop154' has no statements

            	        	char_literal319=(IToken)Match(input,50,FOLLOW_50_in_conditionalExpressionNoIn2268); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal319_tree = (object)adaptor.Create(char_literal319);
            	        		adaptor.AddChild(root_0, char_literal319_tree);
            	        	}
            	        	// JavaScript.g:392:79: ( LT )*
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
            	        			    	LT320=(IToken)Match(input,LT,FOLLOW_LT_in_conditionalExpressionNoIn2270); if (state.failed) return retval;

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop155;
            	        	    }
            	        	} while (true);

            	        	loop155:
            	        		;	// Stops C# compiler whining that label 'loop155' has no statements

            	        	PushFollow(FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn2274);
            	        	assignmentExpressionNoIn321 = assignmentExpressionNoIn();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpressionNoIn321.Tree);

            	        }
            	        break;

            	}


            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class logicalORExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalORExpression"
    // JavaScript.g:395:1: logicalORExpression : logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )* ;
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

         const string elementName = "logicalORExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 57) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:398:2: ( logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )* )
            // JavaScript.g:398:4: logicalANDExpression ( ( LT )* '||' ( LT )* logicalANDExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalANDExpression_in_logicalORExpression2297);
            	logicalANDExpression322 = logicalANDExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpression322.Tree);
            	// JavaScript.g:398:25: ( ( LT )* '||' ( LT )* logicalANDExpression )*
            	do 
            	{
            	    int alt159 = 2;
            	    alt159 = dfa159.Predict(input);
            	    switch (alt159) 
            		{
            			case 1 :
            			    // JavaScript.g:398:26: ( LT )* '||' ( LT )* logicalANDExpression
            			    {
            			    	// JavaScript.g:398:28: ( LT )*
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
            			    			    	LT323=(IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpression2300); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop157;
            			    	    }
            			    	} while (true);

            			    	loop157:
            			    		;	// Stops C# compiler whining that label 'loop157' has no statements

            			    	string_literal324=(IToken)Match(input,74,FOLLOW_74_in_logicalORExpression2304); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal324_tree = (object)adaptor.Create(string_literal324);
            			    		adaptor.AddChild(root_0, string_literal324_tree);
            			    	}
            			    	// JavaScript.g:398:38: ( LT )*
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
            			    			    	LT325=(IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpression2306); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop158;
            			    	    }
            			    	} while (true);

            			    	loop158:
            			    		;	// Stops C# compiler whining that label 'loop158' has no statements

            			    	PushFollow(FOLLOW_logicalANDExpression_in_logicalORExpression2310);
            			    	logicalANDExpression326 = logicalANDExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpression326.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class logicalORExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalORExpressionNoIn"
    // JavaScript.g:401:1: logicalORExpressionNoIn : logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )* ;
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

         const string elementName = "logicalORExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 58) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:404:2: ( logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )* )
            // JavaScript.g:404:4: logicalANDExpressionNoIn ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn2334);
            	logicalANDExpressionNoIn327 = logicalANDExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpressionNoIn327.Tree);
            	// JavaScript.g:404:29: ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*
            	do 
            	{
            	    int alt162 = 2;
            	    alt162 = dfa162.Predict(input);
            	    switch (alt162) 
            		{
            			case 1 :
            			    // JavaScript.g:404:30: ( LT )* '||' ( LT )* logicalANDExpressionNoIn
            			    {
            			    	// JavaScript.g:404:32: ( LT )*
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
            			    			    	LT328=(IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpressionNoIn2337); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop160;
            			    	    }
            			    	} while (true);

            			    	loop160:
            			    		;	// Stops C# compiler whining that label 'loop160' has no statements

            			    	string_literal329=(IToken)Match(input,74,FOLLOW_74_in_logicalORExpressionNoIn2341); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal329_tree = (object)adaptor.Create(string_literal329);
            			    		adaptor.AddChild(root_0, string_literal329_tree);
            			    	}
            			    	// JavaScript.g:404:42: ( LT )*
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
            			    			    	LT330=(IToken)Match(input,LT,FOLLOW_LT_in_logicalORExpressionNoIn2343); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop161;
            			    	    }
            			    	} while (true);

            			    	loop161:
            			    		;	// Stops C# compiler whining that label 'loop161' has no statements

            			    	PushFollow(FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn2347);
            			    	logicalANDExpressionNoIn331 = logicalANDExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logicalANDExpressionNoIn331.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class logicalANDExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalANDExpression"
    // JavaScript.g:407:1: logicalANDExpression : bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )* ;
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

         const string elementName = "logicalANDExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 59) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:410:2: ( bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )* )
            // JavaScript.g:410:4: bitwiseORExpression ( ( LT )* '&&' ( LT )* bitwiseORExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseORExpression_in_logicalANDExpression2371);
            	bitwiseORExpression332 = bitwiseORExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpression332.Tree);
            	// JavaScript.g:410:24: ( ( LT )* '&&' ( LT )* bitwiseORExpression )*
            	do 
            	{
            	    int alt165 = 2;
            	    alt165 = dfa165.Predict(input);
            	    switch (alt165) 
            		{
            			case 1 :
            			    // JavaScript.g:410:25: ( LT )* '&&' ( LT )* bitwiseORExpression
            			    {
            			    	// JavaScript.g:410:27: ( LT )*
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
            			    			    	LT333=(IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpression2374); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop163;
            			    	    }
            			    	} while (true);

            			    	loop163:
            			    		;	// Stops C# compiler whining that label 'loop163' has no statements

            			    	string_literal334=(IToken)Match(input,75,FOLLOW_75_in_logicalANDExpression2378); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal334_tree = (object)adaptor.Create(string_literal334);
            			    		adaptor.AddChild(root_0, string_literal334_tree);
            			    	}
            			    	// JavaScript.g:410:37: ( LT )*
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
            			    			    	LT335=(IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpression2380); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop164;
            			    	    }
            			    	} while (true);

            			    	loop164:
            			    		;	// Stops C# compiler whining that label 'loop164' has no statements

            			    	PushFollow(FOLLOW_bitwiseORExpression_in_logicalANDExpression2384);
            			    	bitwiseORExpression336 = bitwiseORExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpression336.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class logicalANDExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logicalANDExpressionNoIn"
    // JavaScript.g:413:1: logicalANDExpressionNoIn : bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )* ;
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

         const string elementName = "logicalANDExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 60) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:416:2: ( bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )* )
            // JavaScript.g:416:4: bitwiseORExpressionNoIn ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn2408);
            	bitwiseORExpressionNoIn337 = bitwiseORExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpressionNoIn337.Tree);
            	// JavaScript.g:416:28: ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*
            	do 
            	{
            	    int alt168 = 2;
            	    alt168 = dfa168.Predict(input);
            	    switch (alt168) 
            		{
            			case 1 :
            			    // JavaScript.g:416:29: ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn
            			    {
            			    	// JavaScript.g:416:31: ( LT )*
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
            			    			    	LT338=(IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpressionNoIn2411); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop166;
            			    	    }
            			    	} while (true);

            			    	loop166:
            			    		;	// Stops C# compiler whining that label 'loop166' has no statements

            			    	string_literal339=(IToken)Match(input,75,FOLLOW_75_in_logicalANDExpressionNoIn2415); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal339_tree = (object)adaptor.Create(string_literal339);
            			    		adaptor.AddChild(root_0, string_literal339_tree);
            			    	}
            			    	// JavaScript.g:416:41: ( LT )*
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
            			    			    	LT340=(IToken)Match(input,LT,FOLLOW_LT_in_logicalANDExpressionNoIn2417); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop167;
            			    	    }
            			    	} while (true);

            			    	loop167:
            			    		;	// Stops C# compiler whining that label 'loop167' has no statements

            			    	PushFollow(FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn2421);
            			    	bitwiseORExpressionNoIn341 = bitwiseORExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseORExpressionNoIn341.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class bitwiseORExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseORExpression"
    // JavaScript.g:419:1: bitwiseORExpression : bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )* ;
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

         const string elementName = "bitwiseORExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 61) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:422:2: ( bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )* )
            // JavaScript.g:422:4: bitwiseXORExpression ( ( LT )* '|' ( LT )* bitwiseXORExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseXORExpression_in_bitwiseORExpression2445);
            	bitwiseXORExpression342 = bitwiseXORExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpression342.Tree);
            	// JavaScript.g:422:25: ( ( LT )* '|' ( LT )* bitwiseXORExpression )*
            	do 
            	{
            	    int alt171 = 2;
            	    alt171 = dfa171.Predict(input);
            	    switch (alt171) 
            		{
            			case 1 :
            			    // JavaScript.g:422:26: ( LT )* '|' ( LT )* bitwiseXORExpression
            			    {
            			    	// JavaScript.g:422:28: ( LT )*
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
            			    			    	LT343=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpression2448); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop169;
            			    	    }
            			    	} while (true);

            			    	loop169:
            			    		;	// Stops C# compiler whining that label 'loop169' has no statements

            			    	char_literal344=(IToken)Match(input,76,FOLLOW_76_in_bitwiseORExpression2452); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal344_tree = (object)adaptor.Create(char_literal344);
            			    		adaptor.AddChild(root_0, char_literal344_tree);
            			    	}
            			    	// JavaScript.g:422:37: ( LT )*
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
            			    			    	LT345=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpression2454); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop170;
            			    	    }
            			    	} while (true);

            			    	loop170:
            			    		;	// Stops C# compiler whining that label 'loop170' has no statements

            			    	PushFollow(FOLLOW_bitwiseXORExpression_in_bitwiseORExpression2458);
            			    	bitwiseXORExpression346 = bitwiseXORExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpression346.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class bitwiseORExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseORExpressionNoIn"
    // JavaScript.g:425:1: bitwiseORExpressionNoIn : bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )* ;
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

         const string elementName = "bitwiseORExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 62) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:428:2: ( bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )* )
            // JavaScript.g:428:4: bitwiseXORExpressionNoIn ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn2482);
            	bitwiseXORExpressionNoIn347 = bitwiseXORExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpressionNoIn347.Tree);
            	// JavaScript.g:428:29: ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*
            	do 
            	{
            	    int alt174 = 2;
            	    alt174 = dfa174.Predict(input);
            	    switch (alt174) 
            		{
            			case 1 :
            			    // JavaScript.g:428:30: ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn
            			    {
            			    	// JavaScript.g:428:32: ( LT )*
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
            			    			    	LT348=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpressionNoIn2485); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop172;
            			    	    }
            			    	} while (true);

            			    	loop172:
            			    		;	// Stops C# compiler whining that label 'loop172' has no statements

            			    	char_literal349=(IToken)Match(input,76,FOLLOW_76_in_bitwiseORExpressionNoIn2489); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal349_tree = (object)adaptor.Create(char_literal349);
            			    		adaptor.AddChild(root_0, char_literal349_tree);
            			    	}
            			    	// JavaScript.g:428:41: ( LT )*
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
            			    			    	LT350=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseORExpressionNoIn2491); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop173;
            			    	    }
            			    	} while (true);

            			    	loop173:
            			    		;	// Stops C# compiler whining that label 'loop173' has no statements

            			    	PushFollow(FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn2495);
            			    	bitwiseXORExpressionNoIn351 = bitwiseXORExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseXORExpressionNoIn351.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class bitwiseXORExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseXORExpression"
    // JavaScript.g:431:1: bitwiseXORExpression : bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )* ;
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

         const string elementName = "bitwiseXORExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 63) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:434:2: ( bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )* )
            // JavaScript.g:434:4: bitwiseANDExpression ( ( LT )* '^' ( LT )* bitwiseANDExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression2519);
            	bitwiseANDExpression352 = bitwiseANDExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpression352.Tree);
            	// JavaScript.g:434:25: ( ( LT )* '^' ( LT )* bitwiseANDExpression )*
            	do 
            	{
            	    int alt177 = 2;
            	    alt177 = dfa177.Predict(input);
            	    switch (alt177) 
            		{
            			case 1 :
            			    // JavaScript.g:434:26: ( LT )* '^' ( LT )* bitwiseANDExpression
            			    {
            			    	// JavaScript.g:434:28: ( LT )*
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
            			    			    	LT353=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpression2522); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop175;
            			    	    }
            			    	} while (true);

            			    	loop175:
            			    		;	// Stops C# compiler whining that label 'loop175' has no statements

            			    	char_literal354=(IToken)Match(input,77,FOLLOW_77_in_bitwiseXORExpression2526); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal354_tree = (object)adaptor.Create(char_literal354);
            			    		adaptor.AddChild(root_0, char_literal354_tree);
            			    	}
            			    	// JavaScript.g:434:37: ( LT )*
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
            			    			    	LT355=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpression2528); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop176;
            			    	    }
            			    	} while (true);

            			    	loop176:
            			    		;	// Stops C# compiler whining that label 'loop176' has no statements

            			    	PushFollow(FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression2532);
            			    	bitwiseANDExpression356 = bitwiseANDExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpression356.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class bitwiseXORExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseXORExpressionNoIn"
    // JavaScript.g:437:1: bitwiseXORExpressionNoIn : bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )* ;
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

         const string elementName = "bitwiseXORExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 64) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:440:2: ( bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )* )
            // JavaScript.g:440:4: bitwiseANDExpressionNoIn ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn2556);
            	bitwiseANDExpressionNoIn357 = bitwiseANDExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpressionNoIn357.Tree);
            	// JavaScript.g:440:29: ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*
            	do 
            	{
            	    int alt180 = 2;
            	    alt180 = dfa180.Predict(input);
            	    switch (alt180) 
            		{
            			case 1 :
            			    // JavaScript.g:440:30: ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn
            			    {
            			    	// JavaScript.g:440:32: ( LT )*
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
            			    			    	LT358=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpressionNoIn2559); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop178;
            			    	    }
            			    	} while (true);

            			    	loop178:
            			    		;	// Stops C# compiler whining that label 'loop178' has no statements

            			    	char_literal359=(IToken)Match(input,77,FOLLOW_77_in_bitwiseXORExpressionNoIn2563); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal359_tree = (object)adaptor.Create(char_literal359);
            			    		adaptor.AddChild(root_0, char_literal359_tree);
            			    	}
            			    	// JavaScript.g:440:41: ( LT )*
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
            			    			    	LT360=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseXORExpressionNoIn2565); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop179;
            			    	    }
            			    	} while (true);

            			    	loop179:
            			    		;	// Stops C# compiler whining that label 'loop179' has no statements

            			    	PushFollow(FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn2569);
            			    	bitwiseANDExpressionNoIn361 = bitwiseANDExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, bitwiseANDExpressionNoIn361.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class bitwiseANDExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseANDExpression"
    // JavaScript.g:443:1: bitwiseANDExpression : equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )* ;
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

         const string elementName = "bitwiseANDExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 65) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:446:2: ( equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )* )
            // JavaScript.g:446:4: equalityExpression ( ( LT )* '&' ( LT )* equalityExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_equalityExpression_in_bitwiseANDExpression2593);
            	equalityExpression362 = equalityExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression362.Tree);
            	// JavaScript.g:446:23: ( ( LT )* '&' ( LT )* equalityExpression )*
            	do 
            	{
            	    int alt183 = 2;
            	    alt183 = dfa183.Predict(input);
            	    switch (alt183) 
            		{
            			case 1 :
            			    // JavaScript.g:446:24: ( LT )* '&' ( LT )* equalityExpression
            			    {
            			    	// JavaScript.g:446:26: ( LT )*
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
            			    			    	LT363=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpression2596); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop181;
            			    	    }
            			    	} while (true);

            			    	loop181:
            			    		;	// Stops C# compiler whining that label 'loop181' has no statements

            			    	char_literal364=(IToken)Match(input,78,FOLLOW_78_in_bitwiseANDExpression2600); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal364_tree = (object)adaptor.Create(char_literal364);
            			    		adaptor.AddChild(root_0, char_literal364_tree);
            			    	}
            			    	// JavaScript.g:446:35: ( LT )*
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
            			    			    	LT365=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpression2602); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop182;
            			    	    }
            			    	} while (true);

            			    	loop182:
            			    		;	// Stops C# compiler whining that label 'loop182' has no statements

            			    	PushFollow(FOLLOW_equalityExpression_in_bitwiseANDExpression2606);
            			    	equalityExpression366 = equalityExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpression366.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class bitwiseANDExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "bitwiseANDExpressionNoIn"
    // JavaScript.g:449:1: bitwiseANDExpressionNoIn : equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )* ;
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

         const string elementName = "bitwiseANDExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 66) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:452:2: ( equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )* )
            // JavaScript.g:452:4: equalityExpressionNoIn ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2630);
            	equalityExpressionNoIn367 = equalityExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpressionNoIn367.Tree);
            	// JavaScript.g:452:27: ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*
            	do 
            	{
            	    int alt186 = 2;
            	    alt186 = dfa186.Predict(input);
            	    switch (alt186) 
            		{
            			case 1 :
            			    // JavaScript.g:452:28: ( LT )* '&' ( LT )* equalityExpressionNoIn
            			    {
            			    	// JavaScript.g:452:30: ( LT )*
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
            			    			    	LT368=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpressionNoIn2633); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop184;
            			    	    }
            			    	} while (true);

            			    	loop184:
            			    		;	// Stops C# compiler whining that label 'loop184' has no statements

            			    	char_literal369=(IToken)Match(input,78,FOLLOW_78_in_bitwiseANDExpressionNoIn2637); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal369_tree = (object)adaptor.Create(char_literal369);
            			    		adaptor.AddChild(root_0, char_literal369_tree);
            			    	}
            			    	// JavaScript.g:452:39: ( LT )*
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
            			    			    	LT370=(IToken)Match(input,LT,FOLLOW_LT_in_bitwiseANDExpressionNoIn2639); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop185;
            			    	    }
            			    	} while (true);

            			    	loop185:
            			    		;	// Stops C# compiler whining that label 'loop185' has no statements

            			    	PushFollow(FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2643);
            			    	equalityExpressionNoIn371 = equalityExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equalityExpressionNoIn371.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class equalityExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "equalityExpression"
    // JavaScript.g:455:1: equalityExpression : relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )* ;
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

         const string elementName = "equalityExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 67) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:458:2: ( relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )* )
            // JavaScript.g:458:4: relationalExpression ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_relationalExpression_in_equalityExpression2667);
            	relationalExpression372 = relationalExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpression372.Tree);
            	// JavaScript.g:458:25: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*
            	do 
            	{
            	    int alt189 = 2;
            	    alt189 = dfa189.Predict(input);
            	    switch (alt189) 
            		{
            			case 1 :
            			    // JavaScript.g:458:26: ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression
            			    {
            			    	// JavaScript.g:458:28: ( LT )*
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
            			    			    	LT373=(IToken)Match(input,LT,FOLLOW_LT_in_equalityExpression2670); if (state.failed) return retval;

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
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set374));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:458:63: ( LT )*
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
            			    			    	LT375=(IToken)Match(input,LT,FOLLOW_LT_in_equalityExpression2690); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop188;
            			    	    }
            			    	} while (true);

            			    	loop188:
            			    		;	// Stops C# compiler whining that label 'loop188' has no statements

            			    	PushFollow(FOLLOW_relationalExpression_in_equalityExpression2694);
            			    	relationalExpression376 = relationalExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpression376.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class equalityExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "equalityExpressionNoIn"
    // JavaScript.g:461:1: equalityExpressionNoIn : relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )* ;
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

         const string elementName = "equalityExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 68) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:464:2: ( relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )* )
            // JavaScript.g:464:4: relationalExpressionNoIn ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2717);
            	relationalExpressionNoIn377 = relationalExpressionNoIn();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpressionNoIn377.Tree);
            	// JavaScript.g:464:29: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*
            	do 
            	{
            	    int alt192 = 2;
            	    alt192 = dfa192.Predict(input);
            	    switch (alt192) 
            		{
            			case 1 :
            			    // JavaScript.g:464:30: ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn
            			    {
            			    	// JavaScript.g:464:32: ( LT )*
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
            			    			    	LT378=(IToken)Match(input,LT,FOLLOW_LT_in_equalityExpressionNoIn2720); if (state.failed) return retval;

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
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set379));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:464:67: ( LT )*
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
            			    			    	LT380=(IToken)Match(input,LT,FOLLOW_LT_in_equalityExpressionNoIn2740); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop191;
            			    	    }
            			    	} while (true);

            			    	loop191:
            			    		;	// Stops C# compiler whining that label 'loop191' has no statements

            			    	PushFollow(FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2744);
            			    	relationalExpressionNoIn381 = relationalExpressionNoIn();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relationalExpressionNoIn381.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class relationalExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "relationalExpression"
    // JavaScript.g:467:1: relationalExpression : shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )* ;
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

         const string elementName = "relationalExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 69) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:470:2: ( shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )* )
            // JavaScript.g:470:4: shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_shiftExpression_in_relationalExpression2768);
            	shiftExpression382 = shiftExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression382.Tree);
            	// JavaScript.g:470:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*
            	do 
            	{
            	    int alt195 = 2;
            	    alt195 = dfa195.Predict(input);
            	    switch (alt195) 
            		{
            			case 1 :
            			    // JavaScript.g:470:21: ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression
            			    {
            			    	// JavaScript.g:470:23: ( LT )*
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
            			    			    	LT383=(IToken)Match(input,LT,FOLLOW_LT_in_relationalExpression2771); if (state.failed) return retval;

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
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set384));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:470:76: ( LT )*
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
            			    			    	LT385=(IToken)Match(input,LT,FOLLOW_LT_in_relationalExpression2799); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop194;
            			    	    }
            			    	} while (true);

            			    	loop194:
            			    		;	// Stops C# compiler whining that label 'loop194' has no statements

            			    	PushFollow(FOLLOW_shiftExpression_in_relationalExpression2803);
            			    	shiftExpression386 = shiftExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression386.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class relationalExpressionNoIn_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "relationalExpressionNoIn"
    // JavaScript.g:473:1: relationalExpressionNoIn : shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )* ;
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

         const string elementName = "relationalExpressionNoIn"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 70) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:476:2: ( shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )* )
            // JavaScript.g:476:4: shiftExpression ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_shiftExpression_in_relationalExpressionNoIn2826);
            	shiftExpression387 = shiftExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression387.Tree);
            	// JavaScript.g:476:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*
            	do 
            	{
            	    int alt198 = 2;
            	    alt198 = dfa198.Predict(input);
            	    switch (alt198) 
            		{
            			case 1 :
            			    // JavaScript.g:476:21: ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression
            			    {
            			    	// JavaScript.g:476:23: ( LT )*
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
            			    			    	LT388=(IToken)Match(input,LT,FOLLOW_LT_in_relationalExpressionNoIn2829); if (state.failed) return retval;

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
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set389));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:476:69: ( LT )*
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
            			    			    	LT390=(IToken)Match(input,LT,FOLLOW_LT_in_relationalExpressionNoIn2853); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop197;
            			    	    }
            			    	} while (true);

            			    	loop197:
            			    		;	// Stops C# compiler whining that label 'loop197' has no statements

            			    	PushFollow(FOLLOW_shiftExpression_in_relationalExpressionNoIn2857);
            			    	shiftExpression391 = shiftExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shiftExpression391.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class shiftExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "shiftExpression"
    // JavaScript.g:479:1: shiftExpression : additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )* ;
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

         const string elementName = "shiftExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 71) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:482:2: ( additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )* )
            // JavaScript.g:482:4: additiveExpression ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_additiveExpression_in_shiftExpression2880);
            	additiveExpression392 = additiveExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression392.Tree);
            	// JavaScript.g:482:23: ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*
            	do 
            	{
            	    int alt201 = 2;
            	    alt201 = dfa201.Predict(input);
            	    switch (alt201) 
            		{
            			case 1 :
            			    // JavaScript.g:482:24: ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression
            			    {
            			    	// JavaScript.g:482:26: ( LT )*
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
            			    			    	LT393=(IToken)Match(input,LT,FOLLOW_LT_in_shiftExpression2883); if (state.failed) return retval;

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
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set394));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:482:53: ( LT )*
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
            			    			    	LT395=(IToken)Match(input,LT,FOLLOW_LT_in_shiftExpression2899); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop200;
            			    	    }
            			    	} while (true);

            			    	loop200:
            			    		;	// Stops C# compiler whining that label 'loop200' has no statements

            			    	PushFollow(FOLLOW_additiveExpression_in_shiftExpression2903);
            			    	additiveExpression396 = additiveExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additiveExpression396.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class additiveExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "additiveExpression"
    // JavaScript.g:485:1: additiveExpression : multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )* ;
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

         const string elementName = "additiveExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 72) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:488:2: ( multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )* )
            // JavaScript.g:488:4: multiplicativeExpression ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression2926);
            	multiplicativeExpression397 = multiplicativeExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression397.Tree);
            	// JavaScript.g:488:29: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*
            	do 
            	{
            	    int alt204 = 2;
            	    alt204 = dfa204.Predict(input);
            	    switch (alt204) 
            		{
            			case 1 :
            			    // JavaScript.g:488:30: ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression
            			    {
            			    	// JavaScript.g:488:32: ( LT )*
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
            			    			    	LT398=(IToken)Match(input,LT,FOLLOW_LT_in_additiveExpression2929); if (state.failed) return retval;

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
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set399));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:488:49: ( LT )*
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
            			    			    	LT400=(IToken)Match(input,LT,FOLLOW_LT_in_additiveExpression2941); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop203;
            			    	    }
            			    	} while (true);

            			    	loop203:
            			    		;	// Stops C# compiler whining that label 'loop203' has no statements

            			    	PushFollow(FOLLOW_multiplicativeExpression_in_additiveExpression2945);
            			    	multiplicativeExpression401 = multiplicativeExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicativeExpression401.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class multiplicativeExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "multiplicativeExpression"
    // JavaScript.g:491:1: multiplicativeExpression : unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )* ;
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

         const string elementName = "multiplicativeExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 73) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:494:2: ( unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )* )
            // JavaScript.g:494:4: unaryExpression ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression2968);
            	unaryExpression402 = unaryExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression402.Tree);
            	// JavaScript.g:494:20: ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*
            	do 
            	{
            	    int alt207 = 2;
            	    alt207 = dfa207.Predict(input);
            	    switch (alt207) 
            		{
            			case 1 :
            			    // JavaScript.g:494:21: ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression
            			    {
            			    	// JavaScript.g:494:23: ( LT )*
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
            			    			    	LT403=(IToken)Match(input,LT,FOLLOW_LT_in_multiplicativeExpression2971); if (state.failed) return retval;

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
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set404));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	// JavaScript.g:494:46: ( LT )*
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
            			    			    	LT405=(IToken)Match(input,LT,FOLLOW_LT_in_multiplicativeExpression2987); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop206;
            			    	    }
            			    	} while (true);

            			    	loop206:
            			    		;	// Stops C# compiler whining that label 'loop206' has no statements

            			    	PushFollow(FOLLOW_unaryExpression_in_multiplicativeExpression2991);
            			    	unaryExpression406 = unaryExpression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression406.Tree);

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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class unaryExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "unaryExpression"
    // JavaScript.g:497:1: unaryExpression : ( postfixExpression | ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression );
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

         const string elementName = "unaryExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 74) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:500:2: ( postfixExpression | ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression )
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
                    // JavaScript.g:500:4: postfixExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_postfixExpression_in_unaryExpression3014);
                    	postfixExpression407 = postfixExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, postfixExpression407.Tree);

                    }
                    break;
                case 2 :
                    // JavaScript.g:501:4: ( 'delete' | 'void' | 'typeof' | '++' | '--' | '+' | '-' | '~' | '!' ) unaryExpression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	set408 = (IToken)input.LT(1);
                    	if ( (input.LA(1) >= 91 && input.LA(1) <= 92) || (input.LA(1) >= 96 && input.LA(1) <= 102) ) 
                    	{
                    	    input.Consume();
                    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set408));
                    	    state.errorRecovery = false;state.failed = false;
                    	}
                    	else 
                    	{
                    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    throw mse;
                    	}

                    	PushFollow(FOLLOW_unaryExpression_in_unaryExpression3055);
                    	unaryExpression409 = unaryExpression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unaryExpression409.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class postfixExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "postfixExpression"
    // JavaScript.g:504:1: postfixExpression : leftHandSideExpression ( '++' | '--' )? ;
    public JavaScriptParser.postfixExpression_return postfixExpression() // throws RecognitionException [1]
    {   
        JavaScriptParser.postfixExpression_return retval = new JavaScriptParser.postfixExpression_return();
        retval.Start = input.LT(1);
        int postfixExpression_StartIndex = input.Index();
        object root_0 = null;

        IToken set411 = null;
        JavaScriptParser.leftHandSideExpression_return leftHandSideExpression410 = default(JavaScriptParser.leftHandSideExpression_return);


        object set411_tree=null;

         const string elementName = "postfixExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 75) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:507:2: ( leftHandSideExpression ( '++' | '--' )? )
            // JavaScript.g:507:4: leftHandSideExpression ( '++' | '--' )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_leftHandSideExpression_in_postfixExpression3077);
            	leftHandSideExpression410 = leftHandSideExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, leftHandSideExpression410.Tree);
            	// JavaScript.g:507:27: ( '++' | '--' )?
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
            	        	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set411));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class primaryExpression_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "primaryExpression"
    // JavaScript.g:510:1: primaryExpression : ( 'this' | Identifier | literal | arrayLiteral | objectLiteral | '(' ( LT )* expression ( LT )* ')' );
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

         const string elementName = "primaryExpression"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 76) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:513:2: ( 'this' | Identifier | literal | arrayLiteral | objectLiteral | '(' ( LT )* expression ( LT )* ')' )
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
                    // JavaScript.g:513:4: 'this'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal412=(IToken)Match(input,103,FOLLOW_103_in_primaryExpression3107); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal412_tree = (object)adaptor.Create(string_literal412);
                    		adaptor.AddChild(root_0, string_literal412_tree);
                    	}

                    }
                    break;
                case 2 :
                    // JavaScript.g:514:4: Identifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	Identifier413=(IToken)Match(input,Identifier,FOLLOW_Identifier_in_primaryExpression3112); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{Identifier413_tree = (object)adaptor.Create(Identifier413);
                    		adaptor.AddChild(root_0, Identifier413_tree);
                    	}

                    }
                    break;
                case 3 :
                    // JavaScript.g:515:4: literal
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_literal_in_primaryExpression3117);
                    	literal414 = literal();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, literal414.Tree);

                    }
                    break;
                case 4 :
                    // JavaScript.g:516:4: arrayLiteral
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_arrayLiteral_in_primaryExpression3122);
                    	arrayLiteral415 = arrayLiteral();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, arrayLiteral415.Tree);

                    }
                    break;
                case 5 :
                    // JavaScript.g:517:4: objectLiteral
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_objectLiteral_in_primaryExpression3127);
                    	objectLiteral416 = objectLiteral();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, objectLiteral416.Tree);

                    }
                    break;
                case 6 :
                    // JavaScript.g:518:4: '(' ( LT )* expression ( LT )* ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal417=(IToken)Match(input,32,FOLLOW_32_in_primaryExpression3132); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal417_tree = (object)adaptor.Create(char_literal417);
                    		adaptor.AddChild(root_0, char_literal417_tree);
                    	}
                    	// JavaScript.g:518:10: ( LT )*
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
                    			    	LT418=(IToken)Match(input,LT,FOLLOW_LT_in_primaryExpression3134); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop210;
                    	    }
                    	} while (true);

                    	loop210:
                    		;	// Stops C# compiler whining that label 'loop210' has no statements

                    	PushFollow(FOLLOW_expression_in_primaryExpression3138);
                    	expression419 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression419.Tree);
                    	// JavaScript.g:518:26: ( LT )*
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
                    			    	LT420=(IToken)Match(input,LT,FOLLOW_LT_in_primaryExpression3140); if (state.failed) return retval;

                    			    }
                    			    break;

                    			default:
                    			    goto loop211;
                    	    }
                    	} while (true);

                    	loop211:
                    		;	// Stops C# compiler whining that label 'loop211' has no statements

                    	char_literal421=(IToken)Match(input,34,FOLLOW_34_in_primaryExpression3144); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal421_tree = (object)adaptor.Create(char_literal421);
                    		adaptor.AddChild(root_0, char_literal421_tree);
                    	}

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class arrayLiteral_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "arrayLiteral"
    // JavaScript.g:522:1: arrayLiteral : '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* ']' ;
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

         const string elementName = "arrayLiteral"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 77) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:525:2: ( '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* ']' )
            // JavaScript.g:525:4: '[' ( LT )* ( assignmentExpression )? ( ( LT )* ',' ( ( LT )* assignmentExpression )? )* ( LT )* ']'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal422=(IToken)Match(input,59,FOLLOW_59_in_arrayLiteral3167); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal422_tree = (object)adaptor.Create(char_literal422);
            		adaptor.AddChild(root_0, char_literal422_tree);
            	}
            	// JavaScript.g:525:10: ( LT )*
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
            			    	LT423=(IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral3169); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop213;
            	    }
            	} while (true);

            	loop213:
            		;	// Stops C# compiler whining that label 'loop213' has no statements

            	// JavaScript.g:525:13: ( assignmentExpression )?
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
            	        	PushFollow(FOLLOW_assignmentExpression_in_arrayLiteral3173);
            	        	assignmentExpression424 = assignmentExpression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression424.Tree);

            	        }
            	        break;

            	}

            	// JavaScript.g:525:35: ( ( LT )* ',' ( ( LT )* assignmentExpression )? )*
            	do 
            	{
            	    int alt218 = 2;
            	    alt218 = dfa218.Predict(input);
            	    switch (alt218) 
            		{
            			case 1 :
            			    // JavaScript.g:525:36: ( LT )* ',' ( ( LT )* assignmentExpression )?
            			    {
            			    	// JavaScript.g:525:38: ( LT )*
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
            			    			    	LT425=(IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral3177); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop215;
            			    	    }
            			    	} while (true);

            			    	loop215:
            			    		;	// Stops C# compiler whining that label 'loop215' has no statements

            			    	char_literal426=(IToken)Match(input,33,FOLLOW_33_in_arrayLiteral3181); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal426_tree = (object)adaptor.Create(char_literal426);
            			    		adaptor.AddChild(root_0, char_literal426_tree);
            			    	}
            			    	// JavaScript.g:525:45: ( ( LT )* assignmentExpression )?
            			    	int alt217 = 2;
            			    	alt217 = dfa217.Predict(input);
            			    	switch (alt217) 
            			    	{
            			    	    case 1 :
            			    	        // JavaScript.g:525:46: ( LT )* assignmentExpression
            			    	        {
            			    	        	// JavaScript.g:525:48: ( LT )*
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
            			    	        			    	LT427=(IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral3184); if (state.failed) return retval;

            			    	        			    }
            			    	        			    break;

            			    	        			default:
            			    	        			    goto loop216;
            			    	        	    }
            			    	        	} while (true);

            			    	        	loop216:
            			    	        		;	// Stops C# compiler whining that label 'loop216' has no statements

            			    	        	PushFollow(FOLLOW_assignmentExpression_in_arrayLiteral3188);
            			    	        	assignmentExpression428 = assignmentExpression();
            			    	        	state.followingStackPointer--;
            			    	        	if (state.failed) return retval;
            			    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression428.Tree);

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

            	// JavaScript.g:525:78: ( LT )*
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
            			    	LT429=(IToken)Match(input,LT,FOLLOW_LT_in_arrayLiteral3194); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop219;
            	    }
            	} while (true);

            	loop219:
            		;	// Stops C# compiler whining that label 'loop219' has no statements

            	char_literal430=(IToken)Match(input,60,FOLLOW_60_in_arrayLiteral3198); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal430_tree = (object)adaptor.Create(char_literal430);
            		adaptor.AddChild(root_0, char_literal430_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class objectLiteral_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "objectLiteral"
    // JavaScript.g:529:1: objectLiteral : '{' ( LT )* propertyNameAndValue ( ( LT )* ',' ( LT )* propertyNameAndValue )* ( LT )* '}' ;
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

         const string elementName = "objectLiteral"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 78) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:532:2: ( '{' ( LT )* propertyNameAndValue ( ( LT )* ',' ( LT )* propertyNameAndValue )* ( LT )* '}' )
            // JavaScript.g:532:4: '{' ( LT )* propertyNameAndValue ( ( LT )* ',' ( LT )* propertyNameAndValue )* ( LT )* '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal431=(IToken)Match(input,35,FOLLOW_35_in_objectLiteral3227); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal431_tree = (object)adaptor.Create(char_literal431);
            		adaptor.AddChild(root_0, char_literal431_tree);
            	}
            	// JavaScript.g:532:10: ( LT )*
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
            			    	LT432=(IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral3229); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop220;
            	    }
            	} while (true);

            	loop220:
            		;	// Stops C# compiler whining that label 'loop220' has no statements

            	PushFollow(FOLLOW_propertyNameAndValue_in_objectLiteral3233);
            	propertyNameAndValue433 = propertyNameAndValue();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyNameAndValue433.Tree);
            	// JavaScript.g:532:34: ( ( LT )* ',' ( LT )* propertyNameAndValue )*
            	do 
            	{
            	    int alt223 = 2;
            	    alt223 = dfa223.Predict(input);
            	    switch (alt223) 
            		{
            			case 1 :
            			    // JavaScript.g:532:35: ( LT )* ',' ( LT )* propertyNameAndValue
            			    {
            			    	// JavaScript.g:532:37: ( LT )*
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
            			    			    	LT434=(IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral3236); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop221;
            			    	    }
            			    	} while (true);

            			    	loop221:
            			    		;	// Stops C# compiler whining that label 'loop221' has no statements

            			    	char_literal435=(IToken)Match(input,33,FOLLOW_33_in_objectLiteral3240); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal435_tree = (object)adaptor.Create(char_literal435);
            			    		adaptor.AddChild(root_0, char_literal435_tree);
            			    	}
            			    	// JavaScript.g:532:46: ( LT )*
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
            			    			    	LT436=(IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral3242); if (state.failed) return retval;

            			    			    }
            			    			    break;

            			    			default:
            			    			    goto loop222;
            			    	    }
            			    	} while (true);

            			    	loop222:
            			    		;	// Stops C# compiler whining that label 'loop222' has no statements

            			    	PushFollow(FOLLOW_propertyNameAndValue_in_objectLiteral3246);
            			    	propertyNameAndValue437 = propertyNameAndValue();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyNameAndValue437.Tree);

            			    }
            			    break;

            			default:
            			    goto loop223;
            	    }
            	} while (true);

            	loop223:
            		;	// Stops C# compiler whining that label 'loop223' has no statements

            	// JavaScript.g:532:74: ( LT )*
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
            			    	LT438=(IToken)Match(input,LT,FOLLOW_LT_in_objectLiteral3250); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop224;
            	    }
            	} while (true);

            	loop224:
            		;	// Stops C# compiler whining that label 'loop224' has no statements

            	char_literal439=(IToken)Match(input,36,FOLLOW_36_in_objectLiteral3254); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal439_tree = (object)adaptor.Create(char_literal439);
            		adaptor.AddChild(root_0, char_literal439_tree);
            	}

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class propertyNameAndValue_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "propertyNameAndValue"
    // JavaScript.g:535:1: propertyNameAndValue : propertyName ( LT )* ':' ( LT )* assignmentExpression ;
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

         const string elementName = "propertyNameAndValue"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 79) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:538:2: ( propertyName ( LT )* ':' ( LT )* assignmentExpression )
            // JavaScript.g:538:4: propertyName ( LT )* ':' ( LT )* assignmentExpression
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_propertyName_in_propertyNameAndValue3276);
            	propertyName440 = propertyName();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, propertyName440.Tree);
            	// JavaScript.g:538:19: ( LT )*
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
            			    	LT441=(IToken)Match(input,LT,FOLLOW_LT_in_propertyNameAndValue3278); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop225;
            	    }
            	} while (true);

            	loop225:
            		;	// Stops C# compiler whining that label 'loop225' has no statements

            	char_literal442=(IToken)Match(input,50,FOLLOW_50_in_propertyNameAndValue3282); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal442_tree = (object)adaptor.Create(char_literal442);
            		adaptor.AddChild(root_0, char_literal442_tree);
            	}
            	// JavaScript.g:538:28: ( LT )*
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
            			    	LT443=(IToken)Match(input,LT,FOLLOW_LT_in_propertyNameAndValue3284); if (state.failed) return retval;

            			    }
            			    break;

            			default:
            			    goto loop226;
            	    }
            	} while (true);

            	loop226:
            		;	// Stops C# compiler whining that label 'loop226' has no statements

            	PushFollow(FOLLOW_assignmentExpression_in_propertyNameAndValue3288);
            	assignmentExpression444 = assignmentExpression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignmentExpression444.Tree);

            }

            retval.Stop = input.LT(-1);

            if ( (state.backtracking==0) )
            {	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);}
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class propertyName_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "propertyName"
    // JavaScript.g:541:1: propertyName : ( Identifier | StringLiteral | NumericLiteral );
    public JavaScriptParser.propertyName_return propertyName() // throws RecognitionException [1]
    {   
        JavaScriptParser.propertyName_return retval = new JavaScriptParser.propertyName_return();
        retval.Start = input.LT(1);
        int propertyName_StartIndex = input.Index();
        object root_0 = null;

        IToken set445 = null;

        object set445_tree=null;

         const string elementName = "propertyName"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 80) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:544:2: ( Identifier | StringLiteral | NumericLiteral )
            // JavaScript.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set445 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= Identifier && input.LA(1) <= NumericLiteral) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set445));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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

    public class literal_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "literal"
    // JavaScript.g:550:1: literal : ( 'null' | 'true' | 'false' | StringLiteral | NumericLiteral );
    public JavaScriptParser.literal_return literal() // throws RecognitionException [1]
    {   
        JavaScriptParser.literal_return retval = new JavaScriptParser.literal_return();
        retval.Start = input.LT(1);
        int literal_StartIndex = input.Index();
        object root_0 = null;

        IToken set446 = null;

        object set446_tree=null;

         const string elementName = "literal"; var elementsIndex = Elements.Count; Elements.Add(null); 
        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 81) ) 
    	    {
    	    	return retval; 
    	    }
            // JavaScript.g:553:2: ( 'null' | 'true' | 'false' | StringLiteral | NumericLiteral )
            // JavaScript.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set446 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= StringLiteral && input.LA(1) <= NumericLiteral) || (input.LA(1) >= 104 && input.LA(1) <= 106) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set446));
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
            if ( (state.backtracking==0) )
            {
               Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); 
            }
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
        // JavaScript.g:45:4: ( functionDeclaration )
        // JavaScript.g:45:4: functionDeclaration
        {
        	PushFollow(FOLLOW_functionDeclaration_in_synpred5_JavaScript129);
        	functionDeclaration();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred5_JavaScript"

    // $ANTLR start "synpred9_JavaScript"
    public void synpred9_JavaScript_fragment() {
        // JavaScript.g:59:15: ( LT )
        // JavaScript.g:59:15: LT
        {
        	Match(input,LT,FOLLOW_LT_in_synpred9_JavaScript199); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred9_JavaScript"

    // $ANTLR start "synpred21_JavaScript"
    public void synpred21_JavaScript_fragment() {
        // JavaScript.g:78:4: ( statementBlock )
        // JavaScript.g:78:4: statementBlock
        {
        	PushFollow(FOLLOW_statementBlock_in_synpred21_JavaScript323);
        	statementBlock();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred21_JavaScript"

    // $ANTLR start "synpred24_JavaScript"
    public void synpred24_JavaScript_fragment() {
        // JavaScript.g:81:4: ( expressionStatement )
        // JavaScript.g:81:4: expressionStatement
        {
        	PushFollow(FOLLOW_expressionStatement_in_synpred24_JavaScript338);
        	expressionStatement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred24_JavaScript"

    // $ANTLR start "synpred31_JavaScript"
    public void synpred31_JavaScript_fragment() {
        // JavaScript.g:88:4: ( labelledStatement )
        // JavaScript.g:88:4: labelledStatement
        {
        	PushFollow(FOLLOW_labelledStatement_in_synpred31_JavaScript373);
        	labelledStatement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred31_JavaScript"

    // $ANTLR start "synpred34_JavaScript"
    public void synpred34_JavaScript_fragment() {
        // JavaScript.g:97:8: ( LT )
        // JavaScript.g:97:8: LT
        {
        	Match(input,LT,FOLLOW_LT_in_synpred34_JavaScript412); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred34_JavaScript"

    // $ANTLR start "synpred47_JavaScript"
    public void synpred47_JavaScript_fragment() {
        // JavaScript.g:127:15: ( LT )
        // JavaScript.g:127:15: LT
        {
        	Match(input,LT,FOLLOW_LT_in_synpred47_JavaScript588); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred47_JavaScript"

    // $ANTLR start "synpred49_JavaScript"
    public void synpred49_JavaScript_fragment() {
        // JavaScript.g:133:15: ( LT )
        // JavaScript.g:133:15: LT
        {
        	Match(input,LT,FOLLOW_LT_in_synpred49_JavaScript617); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred49_JavaScript"

    // $ANTLR start "synpred60_JavaScript"
    public void synpred60_JavaScript_fragment() {
        // JavaScript.g:163:59: ( ( LT )* 'else' ( LT )* statement )
        // JavaScript.g:163:59: ( LT )* 'else' ( LT )* statement
        {
        	// JavaScript.g:163:61: ( LT )*
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
        			    	Match(input,LT,FOLLOW_LT_in_synpred60_JavaScript779); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop239;
        	    }
        	} while (true);

        	loop239:
        		;	// Stops C# compiler whining that label 'loop239' has no statements

        	Match(input,41,FOLLOW_41_in_synpred60_JavaScript783); if (state.failed) return ;
        	// JavaScript.g:163:73: ( LT )*
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
        			    	Match(input,LT,FOLLOW_LT_in_synpred60_JavaScript785); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop240;
        	    }
        	} while (true);

        	loop240:
        		;	// Stops C# compiler whining that label 'loop240' has no statements

        	PushFollow(FOLLOW_statement_in_synpred60_JavaScript789);
        	statement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred60_JavaScript"

    // $ANTLR start "synpred63_JavaScript"
    public void synpred63_JavaScript_fragment() {
        // JavaScript.g:171:4: ( forStatement )
        // JavaScript.g:171:4: forStatement
        {
        	PushFollow(FOLLOW_forStatement_in_synpred63_JavaScript823);
        	forStatement();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred63_JavaScript"

    // $ANTLR start "synpred118_JavaScript"
    public void synpred118_JavaScript_fragment() {
        // JavaScript.g:258:36: ( LT )
        // JavaScript.g:258:36: LT
        {
        	Match(input,LT,FOLLOW_LT_in_synpred118_JavaScript1440); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred118_JavaScript"

    // $ANTLR start "synpred121_JavaScript"
    public void synpred121_JavaScript_fragment() {
        // JavaScript.g:264:23: ( LT )
        // JavaScript.g:264:23: LT
        {
        	Match(input,LT,FOLLOW_LT_in_synpred121_JavaScript1475); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred121_JavaScript"

    // $ANTLR start "synpred140_JavaScript"
    public void synpred140_JavaScript_fragment() {
        // JavaScript.g:307:4: ( conditionalExpression )
        // JavaScript.g:307:4: conditionalExpression
        {
        	PushFollow(FOLLOW_conditionalExpression_in_synpred140_JavaScript1736);
        	conditionalExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred140_JavaScript"

    // $ANTLR start "synpred143_JavaScript"
    public void synpred143_JavaScript_fragment() {
        // JavaScript.g:314:4: ( conditionalExpressionNoIn )
        // JavaScript.g:314:4: conditionalExpressionNoIn
        {
        	PushFollow(FOLLOW_conditionalExpressionNoIn_in_synpred143_JavaScript1775);
        	conditionalExpressionNoIn();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred143_JavaScript"

    // $ANTLR start "synpred146_JavaScript"
    public void synpred146_JavaScript_fragment() {
        // JavaScript.g:321:4: ( callExpression )
        // JavaScript.g:321:4: callExpression
        {
        	PushFollow(FOLLOW_callExpression_in_synpred146_JavaScript1814);
        	callExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred146_JavaScript"

    // $ANTLR start "synpred147_JavaScript"
    public void synpred147_JavaScript_fragment() {
        // JavaScript.g:328:4: ( memberExpression )
        // JavaScript.g:328:4: memberExpression
        {
        	PushFollow(FOLLOW_memberExpression_in_synpred147_JavaScript1841);
        	memberExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred147_JavaScript"

    // $ANTLR start "synpred154_JavaScript"
    public void synpred154_JavaScript_fragment() {
        // JavaScript.g:335:91: ( ( LT )* memberExpressionSuffix )
        // JavaScript.g:335:91: ( LT )* memberExpressionSuffix
        {
        	// JavaScript.g:335:93: ( LT )*
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
        			    	Match(input,LT,FOLLOW_LT_in_synpred154_JavaScript1899); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop254;
        	    }
        	} while (true);

        	loop254:
        		;	// Stops C# compiler whining that label 'loop254' has no statements

        	PushFollow(FOLLOW_memberExpressionSuffix_in_synpred154_JavaScript1903);
        	memberExpressionSuffix();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred154_JavaScript"

    // $ANTLR start "synpred158_JavaScript"
    public void synpred158_JavaScript_fragment() {
        // JavaScript.g:348:37: ( ( LT )* callExpressionSuffix )
        // JavaScript.g:348:37: ( LT )* callExpressionSuffix
        {
        	// JavaScript.g:348:39: ( LT )*
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
        			    	Match(input,LT,FOLLOW_LT_in_synpred158_JavaScript1962); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop255;
        	    }
        	} while (true);

        	loop255:
        		;	// Stops C# compiler whining that label 'loop255' has no statements

        	PushFollow(FOLLOW_callExpressionSuffix_in_synpred158_JavaScript1966);
        	callExpressionSuffix();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred158_JavaScript"

    // $ANTLR start "synpred256_JavaScript"
    public void synpred256_JavaScript_fragment() {
        // JavaScript.g:488:30: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )
        // JavaScript.g:488:30: ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression
        {
        	// JavaScript.g:488:32: ( LT )*
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
        			    	Match(input,LT,FOLLOW_LT_in_synpred256_JavaScript2929); if (state.failed) return ;

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

        	// JavaScript.g:488:49: ( LT )*
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
        			    	Match(input,LT,FOLLOW_LT_in_synpred256_JavaScript2941); if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop301;
        	    }
        	} while (true);

        	loop301:
        		;	// Stops C# compiler whining that label 'loop301' has no statements

        	PushFollow(FOLLOW_multiplicativeExpression_in_synpred256_JavaScript2945);
        	multiplicativeExpression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred256_JavaScript"

    // $ANTLR start "synpred280_JavaScript"
    public void synpred280_JavaScript_fragment() {
        // JavaScript.g:525:8: ( LT )
        // JavaScript.g:525:8: LT
        {
        	Match(input,LT,FOLLOW_LT_in_synpred280_JavaScript3169); if (state.failed) return ;

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
            get { return "()* loopback of 39:18: ( ( LT )* sourceElement )*"; }
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
            get { return "42:1: sourceElement : ( functionDeclaration | statement );"; }
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
            get { return "65:8: ( ( LT )* Identifier ( ( LT )* ',' ( LT )* Identifier )* )?"; }
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
            get { return "()* loopback of 65:25: ( ( LT )* ',' ( LT )* Identifier )*"; }
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
            get { return "75:1: statement : ( statementBlock | variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );"; }
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
            get { return "()* loopback of 103:14: ( ( LT )* statement )*"; }
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
            get { return "()* loopback of 115:24: ( ( LT )* ',' ( LT )* variableDeclaration )*"; }
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
            get { return "()* loopback of 121:28: ( ( LT )* ',' ( LT )* variableDeclarationNoIn )*"; }
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
            get { return "190:19: ( ( LT )* forStatementInitialiserPart )?"; }
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
            get { return "190:64: ( ( LT )* expression )?"; }
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
            get { return "190:92: ( ( LT )* expression )?"; }
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
            get { return "()* loopback of 252:8: ( ( LT )* caseClause )*"; }
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
            get { return "252:27: ( ( LT )* defaultClause ( ( LT )* caseClause )* )?"; }
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
            get { return "()* loopback of 252:47: ( ( LT )* caseClause )*"; }
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
            get { return "276:64: ( ( LT )* finallyClause )?"; }
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
            get { return "()* loopback of 295:25: ( ( LT )* ',' ( LT )* assignmentExpression )*"; }
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
            get { return "()* loopback of 301:29: ( ( LT )* ',' ( LT )* assignmentExpressionNoIn )*"; }
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
            get { return "304:1: assignmentExpression : ( conditionalExpression | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpression );"; }
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
            get { return "311:1: assignmentExpressionNoIn : ( conditionalExpressionNoIn | leftHandSideExpression ( LT )* assignmentOperator ( LT )* assignmentExpressionNoIn );"; }
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
            get { return "318:1: leftHandSideExpression : ( callExpression | newExpression );"; }
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
            get { return "325:1: newExpression : ( memberExpression | 'new' ( LT )* newExpression );"; }
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
            get { return "()* loopback of 335:90: ( ( LT )* memberExpressionSuffix )*"; }
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
            get { return "()* loopback of 348:36: ( ( LT )* callExpressionSuffix )*"; }
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
            get { return "362:8: ( ( LT )* assignmentExpression ( ( LT )* ',' ( LT )* assignmentExpression )* )?"; }
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
            get { return "()* loopback of 362:35: ( ( LT )* ',' ( LT )* assignmentExpression )*"; }
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
            get { return "386:24: ( ( LT )* '?' ( LT )* assignmentExpression ( LT )* ':' ( LT )* assignmentExpression )?"; }
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
            get { return "392:28: ( ( LT )* '?' ( LT )* assignmentExpressionNoIn ( LT )* ':' ( LT )* assignmentExpressionNoIn )?"; }
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
            get { return "()* loopback of 398:25: ( ( LT )* '||' ( LT )* logicalANDExpression )*"; }
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
            get { return "()* loopback of 404:29: ( ( LT )* '||' ( LT )* logicalANDExpressionNoIn )*"; }
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
            get { return "()* loopback of 410:24: ( ( LT )* '&&' ( LT )* bitwiseORExpression )*"; }
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
            get { return "()* loopback of 416:28: ( ( LT )* '&&' ( LT )* bitwiseORExpressionNoIn )*"; }
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
            get { return "()* loopback of 422:25: ( ( LT )* '|' ( LT )* bitwiseXORExpression )*"; }
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
            get { return "()* loopback of 428:29: ( ( LT )* '|' ( LT )* bitwiseXORExpressionNoIn )*"; }
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
            get { return "()* loopback of 434:25: ( ( LT )* '^' ( LT )* bitwiseANDExpression )*"; }
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
            get { return "()* loopback of 440:29: ( ( LT )* '^' ( LT )* bitwiseANDExpressionNoIn )*"; }
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
            get { return "()* loopback of 446:23: ( ( LT )* '&' ( LT )* equalityExpression )*"; }
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
            get { return "()* loopback of 452:27: ( ( LT )* '&' ( LT )* equalityExpressionNoIn )*"; }
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
            get { return "()* loopback of 458:25: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpression )*"; }
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
            get { return "()* loopback of 464:29: ( ( LT )* ( '==' | '!=' | '===' | '!==' ) ( LT )* relationalExpressionNoIn )*"; }
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
            get { return "()* loopback of 470:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' | 'in' ) ( LT )* shiftExpression )*"; }
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
            get { return "()* loopback of 476:20: ( ( LT )* ( '<' | '>' | '<=' | '>=' | 'instanceof' ) ( LT )* shiftExpression )*"; }
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
            get { return "()* loopback of 482:23: ( ( LT )* ( '<<' | '>>' | '>>>' ) ( LT )* additiveExpression )*"; }
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
            get { return "()* loopback of 488:29: ( ( LT )* ( '+' | '-' ) ( LT )* multiplicativeExpression )*"; }
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
            get { return "()* loopback of 494:20: ( ( LT )* ( '*' | '/' | '%' ) ( LT )* unaryExpression )*"; }
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
            get { return "()* loopback of 525:35: ( ( LT )* ',' ( ( LT )* assignmentExpression )? )*"; }
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
            get { return "525:45: ( ( LT )* assignmentExpression )?"; }
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
            get { return "()* loopback of 532:34: ( ( LT )* ',' ( LT )* propertyNameAndValue )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_LT_in_program65 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_sourceElements_in_program69 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_program71 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_EOF_in_program75 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sourceElement_in_sourceElements98 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_sourceElements101 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_sourceElement_in_sourceElements105 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_functionDeclaration_in_sourceElement129 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statement_in_sourceElement134 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_31_in_functionDeclaration157 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_functionDeclaration159 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_functionDeclaration163 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionDeclaration165 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_formalParameterList_in_functionDeclaration169 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionDeclaration171 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_functionBody_in_functionDeclaration175 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_31_in_functionExpression197 = new BitSet(new ulong[]{0x0000000100000030UL});
    public static readonly BitSet FOLLOW_LT_in_functionExpression199 = new BitSet(new ulong[]{0x0000000100000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_functionExpression203 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionExpression206 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_formalParameterList_in_functionExpression210 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionExpression212 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_functionBody_in_functionExpression216 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_formalParameterList238 = new BitSet(new ulong[]{0x0000000400000030UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList241 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_formalParameterList245 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList248 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_formalParameterList252 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList254 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_formalParameterList258 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_formalParameterList264 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_formalParameterList268 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_functionBody289 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_functionBody291 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_sourceElements_in_functionBody295 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_functionBody297 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_functionBody301 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statementBlock_in_statement323 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variableStatement_in_statement328 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_emptyStatement_in_statement333 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expressionStatement_in_statement338 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ifStatement_in_statement343 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_iterationStatement_in_statement348 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_continueStatement_in_statement353 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_breakStatement_in_statement358 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_returnStatement_in_statement363 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_withStatement_in_statement368 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_labelledStatement_in_statement373 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_switchStatement_in_statement378 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_throwStatement_in_statement383 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_tryStatement_in_statement388 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_statementBlock410 = new BitSet(new ulong[]{0x0CCBDD79800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_statementBlock412 = new BitSet(new ulong[]{0x0CCBDD79800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statementList_in_statementBlock416 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_statementBlock419 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_statementBlock423 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statement_in_statementList445 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_statementList448 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_statementList452 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_37_in_variableStatement476 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_variableStatement478 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationList_in_variableStatement482 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_variableStatement484 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_variableDeclaration_in_variableDeclarationList512 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationList515 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_variableDeclarationList519 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationList521 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclaration_in_variableDeclarationList525 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn549 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationListNoIn552 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_variableDeclarationListNoIn556 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationListNoIn558 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_variableDeclarationListNoIn562 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_Identifier_in_variableDeclaration586 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclaration588 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_initialiser_in_variableDeclaration592 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Identifier_in_variableDeclarationNoIn615 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_LT_in_variableDeclarationNoIn617 = new BitSet(new ulong[]{0x0000008000000012UL});
    public static readonly BitSet FOLLOW_initialiserNoIn_in_variableDeclarationNoIn621 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_initialiser644 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_initialiser646 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_initialiser650 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_initialiserNoIn672 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_initialiserNoIn674 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_initialiserNoIn678 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_38_in_emptyStatement700 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_expressionStatement722 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_expressionStatement724 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_40_in_ifStatement752 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement754 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_ifStatement758 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement760 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_ifStatement764 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement766 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_ifStatement770 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement772 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_ifStatement776 = new BitSet(new ulong[]{0x0000020000000012UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement779 = new BitSet(new ulong[]{0x0000020000000010UL});
    public static readonly BitSet FOLLOW_41_in_ifStatement783 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_ifStatement785 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_ifStatement789 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_doWhileStatement_in_iterationStatement813 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_whileStatement_in_iterationStatement818 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forStatement_in_iterationStatement823 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forInStatement_in_iterationStatement828 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_42_in_doWhileStatement850 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_doWhileStatement852 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_doWhileStatement856 = new BitSet(new ulong[]{0x0000080000000010UL});
    public static readonly BitSet FOLLOW_LT_in_doWhileStatement858 = new BitSet(new ulong[]{0x0000080000000010UL});
    public static readonly BitSet FOLLOW_43_in_doWhileStatement862 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_doWhileStatement864 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_doWhileStatement868 = new BitSet(new ulong[]{0x0C000009800000E0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_doWhileStatement870 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_34_in_doWhileStatement872 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_doWhileStatement874 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_43_in_whileStatement902 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement904 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_whileStatement908 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement910 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_whileStatement914 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement916 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_whileStatement920 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_whileStatement922 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_whileStatement926 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_forStatement948 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement950 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_forStatement954 = new BitSet(new ulong[]{0x0C000069800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement957 = new BitSet(new ulong[]{0x0C000029800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_forStatementInitialiserPart_in_forStatement961 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement965 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_38_in_forStatement969 = new BitSet(new ulong[]{0x0C000049800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement972 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_forStatement976 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement980 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_38_in_forStatement984 = new BitSet(new ulong[]{0x0C00000D800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement987 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_forStatement991 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement995 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_forStatement999 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forStatement1001 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_forStatement1005 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expressionNoIn_in_forStatementInitialiserPart1027 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_37_in_forStatementInitialiserPart1032 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_forStatementInitialiserPart1034 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationListNoIn_in_forStatementInitialiserPart1038 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_forInStatement1060 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement1062 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_forInStatement1066 = new BitSet(new ulong[]{0x0C000029800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement1068 = new BitSet(new ulong[]{0x0C000029800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_forInStatementInitialiserPart_in_forInStatement1072 = new BitSet(new ulong[]{0x0000200000000010UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement1074 = new BitSet(new ulong[]{0x0000200000000010UL});
    public static readonly BitSet FOLLOW_45_in_forInStatement1078 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement1080 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_forInStatement1084 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement1086 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_forInStatement1090 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatement1092 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_forInStatement1096 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_forInStatementInitialiserPart1118 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_37_in_forInStatementInitialiserPart1123 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_forInStatementInitialiserPart1125 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_variableDeclarationNoIn_in_forInStatementInitialiserPart1129 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_46_in_continueStatement1150 = new BitSet(new ulong[]{0x0000004000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_continueStatement1152 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_continueStatement1155 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_47_in_breakStatement1182 = new BitSet(new ulong[]{0x0000004000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_breakStatement1184 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_breakStatement1187 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_returnStatement1214 = new BitSet(new ulong[]{0x0C000049800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_returnStatement1216 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_returnStatement1219 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_49_in_withStatement1247 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement1249 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_withStatement1253 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement1255 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_withStatement1259 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement1261 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_withStatement1265 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_withStatement1267 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_withStatement1271 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Identifier_in_labelledStatement1292 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_labelledStatement1294 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_labelledStatement1298 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_labelledStatement1300 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_labelledStatement1304 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_51_in_switchStatement1326 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement1328 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_switchStatement1332 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement1334 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_switchStatement1338 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement1340 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_switchStatement1344 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_switchStatement1346 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_caseBlock_in_switchStatement1350 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_caseBlock1372 = new BitSet(new ulong[]{0x0030001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1375 = new BitSet(new ulong[]{0x0010000000000010UL});
    public static readonly BitSet FOLLOW_caseClause_in_caseBlock1379 = new BitSet(new ulong[]{0x0030001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1384 = new BitSet(new ulong[]{0x0020000000000010UL});
    public static readonly BitSet FOLLOW_defaultClause_in_caseBlock1388 = new BitSet(new ulong[]{0x0010001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1391 = new BitSet(new ulong[]{0x0010000000000010UL});
    public static readonly BitSet FOLLOW_caseClause_in_caseBlock1395 = new BitSet(new ulong[]{0x0010001000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseBlock1401 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_caseBlock1405 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_caseClause1426 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_caseClause1428 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_caseClause1432 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_caseClause1434 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_caseClause1438 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_caseClause1440 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statementList_in_caseClause1444 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_53_in_defaultClause1467 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_defaultClause1469 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_defaultClause1473 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_defaultClause1475 = new BitSet(new ulong[]{0x0CCBDD69800000F2UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statementList_in_defaultClause1479 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_54_in_throwStatement1502 = new BitSet(new ulong[]{0x0C000009800000E0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_throwStatement1504 = new BitSet(new ulong[]{0x0000004000000010UL});
    public static readonly BitSet FOLLOW_set_in_throwStatement1506 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_55_in_tryStatement1533 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_tryStatement1535 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_statementBlock_in_tryStatement1539 = new BitSet(new ulong[]{0x0300000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_tryStatement1541 = new BitSet(new ulong[]{0x0300000000000010UL});
    public static readonly BitSet FOLLOW_finallyClause_in_tryStatement1546 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_catchClause_in_tryStatement1550 = new BitSet(new ulong[]{0x0200000000000012UL});
    public static readonly BitSet FOLLOW_LT_in_tryStatement1553 = new BitSet(new ulong[]{0x0200000000000010UL});
    public static readonly BitSet FOLLOW_finallyClause_in_tryStatement1557 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_56_in_catchClause1588 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1590 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_32_in_catchClause1594 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1596 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_catchClause1600 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1602 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_catchClause1606 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_catchClause1608 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_statementBlock_in_catchClause1612 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_57_in_finallyClause1634 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_LT_in_finallyClause1636 = new BitSet(new ulong[]{0x0000000800000010UL});
    public static readonly BitSet FOLLOW_statementBlock_in_finallyClause1640 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_expression1662 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_expression1665 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_expression1669 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_expression1671 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_expression1675 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1699 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_LT_in_expressionNoIn1702 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_expressionNoIn1706 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_expressionNoIn1708 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_expressionNoIn1712 = new BitSet(new ulong[]{0x0000000200000012UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_assignmentExpression1736 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_assignmentExpression1741 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpression1743 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_assignmentOperator_in_assignmentExpression1747 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpression1749 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_assignmentExpression1753 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalExpressionNoIn_in_assignmentExpressionNoIn1775 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_assignmentExpressionNoIn1780 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpressionNoIn1782 = new BitSet(new ulong[]{0xC000008000000010UL,0x00000000000001FFUL});
    public static readonly BitSet FOLLOW_assignmentOperator_in_assignmentExpressionNoIn1786 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_assignmentExpressionNoIn1788 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_assignmentExpressionNoIn1792 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_callExpression_in_leftHandSideExpression1814 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_newExpression_in_leftHandSideExpression1819 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_memberExpression_in_newExpression1841 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_58_in_newExpression1846 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_LT_in_newExpression1848 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_newExpression_in_newExpression1852 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_primaryExpression_in_memberExpression1875 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_functionExpression_in_memberExpression1879 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_58_in_memberExpression1883 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_LT_in_memberExpression1885 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x0000078000000000UL});
    public static readonly BitSet FOLLOW_memberExpression_in_memberExpression1889 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_memberExpression1891 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_arguments_in_memberExpression1895 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_LT_in_memberExpression1899 = new BitSet(new ulong[]{0x2800000000000010UL});
    public static readonly BitSet FOLLOW_memberExpressionSuffix_in_memberExpression1903 = new BitSet(new ulong[]{0x2800000000000012UL});
    public static readonly BitSet FOLLOW_indexSuffix_in_memberExpressionSuffix1927 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_propertyReferenceSuffix_in_memberExpressionSuffix1932 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_memberExpression_in_callExpression1953 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_LT_in_callExpression1955 = new BitSet(new ulong[]{0x0000000100000010UL});
    public static readonly BitSet FOLLOW_arguments_in_callExpression1959 = new BitSet(new ulong[]{0x2800000100000012UL});
    public static readonly BitSet FOLLOW_LT_in_callExpression1962 = new BitSet(new ulong[]{0x2800000100000010UL});
    public static readonly BitSet FOLLOW_callExpressionSuffix_in_callExpression1966 = new BitSet(new ulong[]{0x2800000100000012UL});
    public static readonly BitSet FOLLOW_arguments_in_callExpressionSuffix1990 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_indexSuffix_in_callExpressionSuffix1995 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_propertyReferenceSuffix_in_callExpressionSuffix2000 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_arguments2021 = new BitSet(new ulong[]{0x0C00000D800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arguments2024 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arguments2028 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_arguments2031 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_arguments2035 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arguments2037 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arguments2041 = new BitSet(new ulong[]{0x0000000600000010UL});
    public static readonly BitSet FOLLOW_LT_in_arguments2047 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_arguments2051 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_59_in_indexSuffix2073 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_indexSuffix2075 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_indexSuffix2079 = new BitSet(new ulong[]{0x1000000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_indexSuffix2081 = new BitSet(new ulong[]{0x1000000000000010UL});
    public static readonly BitSet FOLLOW_60_in_indexSuffix2085 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_61_in_propertyReferenceSuffix2108 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_LT_in_propertyReferenceSuffix2110 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_Identifier_in_propertyReferenceSuffix2114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_assignmentOperator0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalORExpression_in_conditionalExpression2201 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression2204 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_conditionalExpression2208 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression2210 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_conditionalExpression2214 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression2216 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_conditionalExpression2220 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpression2222 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_conditionalExpression2226 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalORExpressionNoIn_in_conditionalExpressionNoIn2249 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn2252 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_conditionalExpressionNoIn2256 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn2258 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn2262 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn2264 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_conditionalExpressionNoIn2268 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_conditionalExpressionNoIn2270 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpressionNoIn_in_conditionalExpressionNoIn2274 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logicalANDExpression_in_logicalORExpression2297 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpression2300 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_logicalORExpression2304 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpression2306 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_logicalANDExpression_in_logicalORExpression2310 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn2334 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpressionNoIn2337 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_logicalORExpressionNoIn2341 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalORExpressionNoIn2343 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_logicalANDExpressionNoIn_in_logicalORExpressionNoIn2347 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_bitwiseORExpression_in_logicalANDExpression2371 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpression2374 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_logicalANDExpression2378 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpression2380 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseORExpression_in_logicalANDExpression2384 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn2408 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpressionNoIn2411 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_logicalANDExpressionNoIn2415 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_logicalANDExpressionNoIn2417 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn2421 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpression_in_bitwiseORExpression2445 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpression2448 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitwiseORExpression2452 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpression2454 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpression_in_bitwiseORExpression2458 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn2482 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpressionNoIn2485 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitwiseORExpressionNoIn2489 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseORExpressionNoIn2491 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn2495 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression2519 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpression2522 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitwiseXORExpression2526 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpression2528 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpression_in_bitwiseXORExpression2532 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn2556 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpressionNoIn2559 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitwiseXORExpressionNoIn2563 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseXORExpressionNoIn2565 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn2569 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseANDExpression2593 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpression2596 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_78_in_bitwiseANDExpression2600 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpression2602 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_equalityExpression_in_bitwiseANDExpression2606 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2630 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpressionNoIn2633 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_78_in_bitwiseANDExpressionNoIn2637 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_bitwiseANDExpressionNoIn2639 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_equalityExpressionNoIn_in_bitwiseANDExpressionNoIn2643 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression2667 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpression2670 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_set_in_equalityExpression2674 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpression2690 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_relationalExpression_in_equalityExpression2694 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2717 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpressionNoIn2720 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_set_in_equalityExpressionNoIn2724 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_equalityExpressionNoIn2740 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_relationalExpressionNoIn_in_equalityExpressionNoIn2744 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000078000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression2768 = new BitSet(new ulong[]{0x0000200000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpression2771 = new BitSet(new ulong[]{0x0000200000000010UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_set_in_relationalExpression2775 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpression2799 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpression2803 = new BitSet(new ulong[]{0x0000200000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpressionNoIn2826 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpressionNoIn2829 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_set_in_relationalExpressionNoIn2833 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_relationalExpressionNoIn2853 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_shiftExpression_in_relationalExpressionNoIn2857 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000000F80000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression2880 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000007000000UL});
    public static readonly BitSet FOLLOW_LT_in_shiftExpression2883 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000007000000UL});
    public static readonly BitSet FOLLOW_set_in_shiftExpression2887 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_shiftExpression2899 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_additiveExpression_in_shiftExpression2903 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000007000000UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression2926 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_LT_in_additiveExpression2929 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_set_in_additiveExpression2933 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_additiveExpression2941 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_additiveExpression2945 = new BitSet(new ulong[]{0x0000000000000012UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression2968 = new BitSet(new ulong[]{0x0000000000000012UL,0x00000000E0000000UL});
    public static readonly BitSet FOLLOW_LT_in_multiplicativeExpression2971 = new BitSet(new ulong[]{0x0000000000000010UL,0x00000000E0000000UL});
    public static readonly BitSet FOLLOW_set_in_multiplicativeExpression2975 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_multiplicativeExpression2987 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_multiplicativeExpression2991 = new BitSet(new ulong[]{0x0000000000000012UL,0x00000000E0000000UL});
    public static readonly BitSet FOLLOW_postfixExpression_in_unaryExpression3014 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_unaryExpression3019 = new BitSet(new ulong[]{0x0C000009800000E0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_unaryExpression_in_unaryExpression3055 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_leftHandSideExpression_in_postfixExpression3077 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000001800000000UL});
    public static readonly BitSet FOLLOW_set_in_postfixExpression3079 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_103_in_primaryExpression3107 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Identifier_in_primaryExpression3112 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_literal_in_primaryExpression3117 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_arrayLiteral_in_primaryExpression3122 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_objectLiteral_in_primaryExpression3127 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_primaryExpression3132 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_primaryExpression3134 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_expression_in_primaryExpression3138 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_LT_in_primaryExpression3140 = new BitSet(new ulong[]{0x0000000400000010UL});
    public static readonly BitSet FOLLOW_34_in_primaryExpression3144 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_59_in_arrayLiteral3167 = new BitSet(new ulong[]{0x1C00000B800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral3169 = new BitSet(new ulong[]{0x1C00000B800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arrayLiteral3173 = new BitSet(new ulong[]{0x1000000200000010UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral3177 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_arrayLiteral3181 = new BitSet(new ulong[]{0x1C00000B800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral3184 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_arrayLiteral3188 = new BitSet(new ulong[]{0x1000000200000010UL});
    public static readonly BitSet FOLLOW_LT_in_arrayLiteral3194 = new BitSet(new ulong[]{0x1000000000000010UL});
    public static readonly BitSet FOLLOW_60_in_arrayLiteral3198 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_objectLiteral3227 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral3229 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_propertyNameAndValue_in_objectLiteral3233 = new BitSet(new ulong[]{0x0000001200000010UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral3236 = new BitSet(new ulong[]{0x0000000200000010UL});
    public static readonly BitSet FOLLOW_33_in_objectLiteral3240 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral3242 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_propertyNameAndValue_in_objectLiteral3246 = new BitSet(new ulong[]{0x0000001200000010UL});
    public static readonly BitSet FOLLOW_LT_in_objectLiteral3250 = new BitSet(new ulong[]{0x0000001000000010UL});
    public static readonly BitSet FOLLOW_36_in_objectLiteral3254 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_propertyName_in_propertyNameAndValue3276 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_LT_in_propertyNameAndValue3278 = new BitSet(new ulong[]{0x0004000000000010UL});
    public static readonly BitSet FOLLOW_50_in_propertyNameAndValue3282 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_propertyNameAndValue3284 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_assignmentExpression_in_propertyNameAndValue3288 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_propertyName0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_literal0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_functionDeclaration_in_synpred5_JavaScript129 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred9_JavaScript199 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statementBlock_in_synpred21_JavaScript323 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expressionStatement_in_synpred24_JavaScript338 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_labelledStatement_in_synpred31_JavaScript373 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred34_JavaScript412 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred47_JavaScript588 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred49_JavaScript617 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred60_JavaScript779 = new BitSet(new ulong[]{0x0000020000000010UL});
    public static readonly BitSet FOLLOW_41_in_synpred60_JavaScript783 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_synpred60_JavaScript785 = new BitSet(new ulong[]{0x0CCBDD69800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_statement_in_synpred60_JavaScript789 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_forStatement_in_synpred63_JavaScript823 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred118_JavaScript1440 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred121_JavaScript1475 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalExpression_in_synpred140_JavaScript1736 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditionalExpressionNoIn_in_synpred143_JavaScript1775 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_callExpression_in_synpred146_JavaScript1814 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_memberExpression_in_synpred147_JavaScript1841 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred154_JavaScript1899 = new BitSet(new ulong[]{0x2800000000000010UL});
    public static readonly BitSet FOLLOW_memberExpressionSuffix_in_synpred154_JavaScript1903 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred158_JavaScript1962 = new BitSet(new ulong[]{0x2800000100000010UL});
    public static readonly BitSet FOLLOW_callExpressionSuffix_in_synpred158_JavaScript1966 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred256_JavaScript2929 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000018000000UL});
    public static readonly BitSet FOLLOW_set_in_synpred256_JavaScript2933 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_LT_in_synpred256_JavaScript2941 = new BitSet(new ulong[]{0x0C000009800000F0UL,0x000007FF18000000UL});
    public static readonly BitSet FOLLOW_multiplicativeExpression_in_synpred256_JavaScript2945 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_synpred280_JavaScript3169 = new BitSet(new ulong[]{0x0000000000000002UL});

}
