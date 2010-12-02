using Ucpf.Languages.Common.Antlr;
using System.Collections.Generic;
// $ANTLR 3.2 Sep 23, 2009 12:02:23 C.g 2010-12-03 00:00:48

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;

using Antlr.Runtime.Tree;

/** ANSI C ANTLR v3 grammar

Translated from Jutta Degener's 1995 ANSI C yacc grammar by Terence Parr
July 2006.  The lexical rules were taken from the Java grammar.

Jutta says: "In 1985, Jeff Lee published his Yacc grammar (which
is accompanied by a matching Lex specification) for the April 30, 1985 draft
version of the ANSI C standard.  Tom Stockfisch reposted it to net.sources in
1987; that original, as mentioned in the answer to question 17.25 of the
comp.lang.c FAQ, can be ftp'ed from ftp.uu.net,
   file usenet/net.sources/ansi.c.grammar.Z.
I intend to keep this version as close to the current C Standard grammar as
possible; please let me know if you discover discrepancies. Jutta Degener, 1995"

Generally speaking, you need symbol table info to parse C; typedefs
define types and then IDENTIFIERS are either types or plain IDs.  I'm doing
the min necessary here tracking only type names.  This is a good example
of the global scope (called Symbols).  Every rule that declares its usage
of Symbols pushes a new copy on the stack effectively creating a new
symbol scope.  Also note rule declaration declares a rule scope that
lets any invoked rule see isTypedef boolean.  It's much easier than
passing that info down as parameters.  Very clean.  Rule
direct_declarator can then easily determine whether the IDENTIFIER
should be declared as a type name.

I have only tested this on a single file, though it is 3500 lines.

This grammar requires ANTLR v3.0.1 or higher.

Terence Parr
July 2006
*/
public partial class CParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"IDENTIFIER", 
		"HEX_LITERAL", 
		"OCTAL_LITERAL", 
		"DECIMAL_LITERAL", 
		"CHARACTER_LITERAL", 
		"STRING_LITERAL", 
		"FLOATING_POINT_LITERAL", 
		"LETTER", 
		"EscapeSequence", 
		"HexDigit", 
		"IntegerTypeSuffix", 
		"Exponent", 
		"FloatTypeSuffix", 
		"OctalEscape", 
		"UnicodeEscape", 
		"WS", 
		"COMMENT", 
		"LINE_COMMENT", 
		"LINE_COMMAND", 
		"'typedef'", 
		"';'", 
		"','", 
		"'='", 
		"'extern'", 
		"'static'", 
		"'auto'", 
		"'register'", 
		"'void'", 
		"'char'", 
		"'short'", 
		"'int'", 
		"'long'", 
		"'float'", 
		"'double'", 
		"'signed'", 
		"'unsigned'", 
		"'{'", 
		"'}'", 
		"'struct'", 
		"'union'", 
		"':'", 
		"'enum'", 
		"'const'", 
		"'volatile'", 
		"'('", 
		"')'", 
		"'['", 
		"']'", 
		"'*'", 
		"'...'", 
		"'+'", 
		"'-'", 
		"'/'", 
		"'%'", 
		"'++'", 
		"'--'", 
		"'sizeof'", 
		"'.'", 
		"'->'", 
		"'&'", 
		"'~'", 
		"'!'", 
		"'*='", 
		"'/='", 
		"'%='", 
		"'+='", 
		"'-='", 
		"'<<='", 
		"'>>='", 
		"'&='", 
		"'^='", 
		"'|='", 
		"'?'", 
		"'||'", 
		"'&&'", 
		"'|'", 
		"'^'", 
		"'=='", 
		"'!='", 
		"'<'", 
		"'>'", 
		"'<='", 
		"'>='", 
		"'<<'", 
		"'>>'", 
		"'case'", 
		"'default'", 
		"'if'", 
		"'else'", 
		"'switch'", 
		"'while'", 
		"'do'", 
		"'for'", 
		"'goto'", 
		"'continue'", 
		"'break'", 
		"'return'"
    };

    public const int T__29 = 29;
    public const int T__28 = 28;
    public const int T__27 = 27;
    public const int T__26 = 26;
    public const int FloatTypeSuffix = 16;
    public const int T__25 = 25;
    public const int T__24 = 24;
    public const int T__23 = 23;
    public const int LETTER = 11;
    public const int EOF = -1;
    public const int T__93 = 93;
    public const int T__94 = 94;
    public const int T__91 = 91;
    public const int T__92 = 92;
    public const int STRING_LITERAL = 9;
    public const int T__90 = 90;
    public const int FLOATING_POINT_LITERAL = 10;
    public const int COMMENT = 20;
    public const int T__99 = 99;
    public const int T__98 = 98;
    public const int T__97 = 97;
    public const int T__96 = 96;
    public const int T__95 = 95;
    public const int T__80 = 80;
    public const int T__81 = 81;
    public const int T__82 = 82;
    public const int T__83 = 83;
    public const int LINE_COMMENT = 21;
    public const int IntegerTypeSuffix = 14;
    public const int CHARACTER_LITERAL = 8;
    public const int T__85 = 85;
    public const int T__84 = 84;
    public const int T__87 = 87;
    public const int T__86 = 86;
    public const int T__89 = 89;
    public const int T__88 = 88;
    public const int WS = 19;
    public const int T__71 = 71;
    public const int T__72 = 72;
    public const int T__70 = 70;
    public const int LINE_COMMAND = 22;
    public const int T__76 = 76;
    public const int T__75 = 75;
    public const int T__74 = 74;
    public const int T__73 = 73;
    public const int DECIMAL_LITERAL = 7;
    public const int EscapeSequence = 12;
    public const int T__79 = 79;
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
    public const int Exponent = 15;
    public const int T__61 = 61;
    public const int T__60 = 60;
    public const int HexDigit = 13;
    public const int T__55 = 55;
    public const int T__56 = 56;
    public const int T__57 = 57;
    public const int T__58 = 58;
    public const int T__51 = 51;
    public const int T__52 = 52;
    public const int T__53 = 53;
    public const int T__54 = 54;
    public const int IDENTIFIER = 4;
    public const int T__59 = 59;
    public const int HEX_LITERAL = 5;
    public const int T__50 = 50;
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
    public const int OCTAL_LITERAL = 6;
    public const int T__100 = 100;
    public const int T__30 = 30;
    public const int T__31 = 31;
    public const int T__32 = 32;
    public const int T__33 = 33;
    public const int T__34 = 34;
    public const int T__35 = 35;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;
    public const int UnicodeEscape = 18;
    public const int OctalEscape = 17;

    // delegates
    // delegators

    protected class Symbols_scope 
    {
        protected internal Set types;
    }
    protected Stack Symbols_stack = new Stack();



        public CParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public CParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();
            this.state.ruleMemo = new Hashtable[213+1];
             
             
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
		get { return CParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "C.g"; }
    }


    	boolean isTypeName(String name) {
    		for (int i = Symbols_stack.size()-1; i>=0; i--) {
    			Symbols_scope scope = (Symbols_scope)Symbols_stack.get(i);
    			if ( scope.types.contains(name) ) {
    				return true;
    			}
    		}
    		return false;
    	}


    public class translation_unit_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "translation_unit"
    // C.g:58:1: translation_unit : ( external_declaration )+ ;
    public CParser.translation_unit_return translation_unit() // throws RecognitionException [1]
    {   
        Symbols_stack.Push(new Symbols_scope());

        CParser.translation_unit_return retval = new CParser.translation_unit_return();
        retval.Start = input.LT(1);
        int translation_unit_StartIndex = input.Index();
        object root_0 = null;

        CParser.external_declaration_return external_declaration1 = default(CParser.external_declaration_return);




          ((Symbols_scope)Symbols_stack.Peek()).types =  new HashSet();

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:63:2: ( ( external_declaration )+ )
            // C.g:63:4: ( external_declaration )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:63:4: ( external_declaration )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    alt1 = dfa1.Predict(input);
            	    switch (alt1) 
            		{
            			case 1 :
            			    // C.g:0:0: external_declaration
            			    {
            			    	PushFollow(FOLLOW_external_declaration_in_translation_unit86);
            			    	external_declaration1 = external_declaration();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, external_declaration1.Tree, external_declaration1, retval);

            			    }
            			    break;

            			default:
            			    if ( cnt1 >= 1 ) goto loop1;
            			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


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
            	Memoize(input, 1, translation_unit_StartIndex); 
            }
            Symbols_stack.Pop();

        }
        return retval;
    }
    // $ANTLR end "translation_unit"

    public class external_declaration_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "external_declaration"
    // C.g:66:1: external_declaration options {k=1; } : ( ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition | declaration );
    public CParser.external_declaration_return external_declaration() // throws RecognitionException [1]
    {   
        CParser.external_declaration_return retval = new CParser.external_declaration_return();
        retval.Start = input.LT(1);
        int external_declaration_StartIndex = input.Index();
        object root_0 = null;

        CParser.function_definition_return function_definition2 = default(CParser.function_definition_return);

        CParser.declaration_return declaration3 = default(CParser.declaration_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:82:2: ( ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition | declaration )
            int alt2 = 2;
            alt2 = dfa2.Predict(input);
            switch (alt2) 
            {
                case 1 :
                    // C.g:82:4: ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_function_definition_in_external_declaration122);
                    	function_definition2 = function_definition();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, function_definition2.Tree, function_definition2, retval);

                    }
                    break;
                case 2 :
                    // C.g:83:4: declaration
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_declaration_in_external_declaration127);
                    	declaration3 = declaration();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration3.Tree, declaration3, retval);

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
            	Memoize(input, 2, external_declaration_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "external_declaration"

    public class function_definition_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "function_definition"
    // C.g:86:1: function_definition : ( declaration_specifiers )? declarator ( ( declaration )+ compound_statement | compound_statement ) ;
    public CParser.function_definition_return function_definition() // throws RecognitionException [1]
    {   
        Symbols_stack.Push(new Symbols_scope());

        CParser.function_definition_return retval = new CParser.function_definition_return();
        retval.Start = input.LT(1);
        int function_definition_StartIndex = input.Index();
        object root_0 = null;

        CParser.declaration_specifiers_return declaration_specifiers4 = default(CParser.declaration_specifiers_return);

        CParser.declarator_return declarator5 = default(CParser.declarator_return);

        CParser.declaration_return declaration6 = default(CParser.declaration_return);

        CParser.compound_statement_return compound_statement7 = default(CParser.compound_statement_return);

        CParser.compound_statement_return compound_statement8 = default(CParser.compound_statement_return);




          ((Symbols_scope)Symbols_stack.Peek()).types =  new HashSet();

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:91:2: ( ( declaration_specifiers )? declarator ( ( declaration )+ compound_statement | compound_statement ) )
            // C.g:91:4: ( declaration_specifiers )? declarator ( ( declaration )+ compound_statement | compound_statement )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:91:4: ( declaration_specifiers )?
            	int alt3 = 2;
            	alt3 = dfa3.Predict(input);
            	switch (alt3) 
            	{
            	    case 1 :
            	        // C.g:0:0: declaration_specifiers
            	        {
            	        	PushFollow(FOLLOW_declaration_specifiers_in_function_definition149);
            	        	declaration_specifiers4 = declaration_specifiers();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers4.Tree, declaration_specifiers4, retval);

            	        }
            	        break;

            	}

            	PushFollow(FOLLOW_declarator_in_function_definition152);
            	declarator5 = declarator();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator5.Tree, declarator5, retval);
            	// C.g:92:3: ( ( declaration )+ compound_statement | compound_statement )
            	int alt5 = 2;
            	alt5 = dfa5.Predict(input);
            	switch (alt5) 
            	{
            	    case 1 :
            	        // C.g:92:5: ( declaration )+ compound_statement
            	        {
            	        	// C.g:92:5: ( declaration )+
            	        	int cnt4 = 0;
            	        	do 
            	        	{
            	        	    int alt4 = 2;
            	        	    alt4 = dfa4.Predict(input);
            	        	    switch (alt4) 
            	        		{
            	        			case 1 :
            	        			    // C.g:0:0: declaration
            	        			    {
            	        			    	PushFollow(FOLLOW_declaration_in_function_definition158);
            	        			    	declaration6 = declaration();
            	        			    	state.followingStackPointer--;
            	        			    	if (state.failed) return retval;
            	        			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration6.Tree, declaration6, retval);

            	        			    }
            	        			    break;

            	        			default:
            	        			    if ( cnt4 >= 1 ) goto loop4;
            	        			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	        		            EarlyExitException eee4 =
            	        		                new EarlyExitException(4, input);
            	        		            throw eee4;
            	        	    }
            	        	    cnt4++;
            	        	} while (true);

            	        	loop4:
            	        		;	// Stops C# compiler whining that label 'loop4' has no statements

            	        	PushFollow(FOLLOW_compound_statement_in_function_definition161);
            	        	compound_statement7 = compound_statement();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, compound_statement7.Tree, compound_statement7, retval);

            	        }
            	        break;
            	    case 2 :
            	        // C.g:93:5: compound_statement
            	        {
            	        	PushFollow(FOLLOW_compound_statement_in_function_definition168);
            	        	compound_statement8 = compound_statement();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, compound_statement8.Tree, compound_statement8, retval);

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
            	Memoize(input, 3, function_definition_StartIndex); 
            }
            Symbols_stack.Pop();

        }
        return retval;
    }
    // $ANTLR end "function_definition"

    protected class declaration_scope 
    {
        protected internal boolean isTypedef;
    }
    protected Stack declaration_stack = new Stack();

    public class declaration_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "declaration"
    // C.g:97:1: declaration : ( 'typedef' ( declaration_specifiers )? init_declarator_list ';' | declaration_specifiers ( init_declarator_list )? ';' );
    public CParser.declaration_return declaration() // throws RecognitionException [1]
    {   
        declaration_stack.Push(new declaration_scope());
        CParser.declaration_return retval = new CParser.declaration_return();
        retval.Start = input.LT(1);
        int declaration_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal9 = null;
        IToken char_literal12 = null;
        IToken char_literal15 = null;
        CParser.declaration_specifiers_return declaration_specifiers10 = default(CParser.declaration_specifiers_return);

        CParser.init_declarator_list_return init_declarator_list11 = default(CParser.init_declarator_list_return);

        CParser.declaration_specifiers_return declaration_specifiers13 = default(CParser.declaration_specifiers_return);

        CParser.init_declarator_list_return init_declarator_list14 = default(CParser.init_declarator_list_return);


        object string_literal9_tree=null;
        object char_literal12_tree=null;
        object char_literal15_tree=null;


          ((declaration_scope)declaration_stack.Peek()).isTypedef =  false;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:104:2: ( 'typedef' ( declaration_specifiers )? init_declarator_list ';' | declaration_specifiers ( init_declarator_list )? ';' )
            int alt8 = 2;
            alt8 = dfa8.Predict(input);
            switch (alt8) 
            {
                case 1 :
                    // C.g:104:4: 'typedef' ( declaration_specifiers )? init_declarator_list ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal9=(IToken)Match(input,23,FOLLOW_23_in_declaration196); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal9_tree = (object)adaptor.Create(string_literal9, retval);
                    		adaptor.AddChild(root_0, string_literal9_tree);
                    	}
                    	// C.g:104:14: ( declaration_specifiers )?
                    	int alt6 = 2;
                    	alt6 = dfa6.Predict(input);
                    	switch (alt6) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: declaration_specifiers
                    	        {
                    	        	PushFollow(FOLLOW_declaration_specifiers_in_declaration198);
                    	        	declaration_specifiers10 = declaration_specifiers();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers10.Tree, declaration_specifiers10, retval);

                    	        }
                    	        break;

                    	}

                    	if ( (state.backtracking==0) )
                    	{
                    	  ((declaration_scope)declaration_stack.Peek()).isTypedef = true;
                    	}
                    	PushFollow(FOLLOW_init_declarator_list_in_declaration206);
                    	init_declarator_list11 = init_declarator_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator_list11.Tree, init_declarator_list11, retval);
                    	char_literal12=(IToken)Match(input,24,FOLLOW_24_in_declaration208); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal12_tree = (object)adaptor.Create(char_literal12, retval);
                    		adaptor.AddChild(root_0, char_literal12_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:106:4: declaration_specifiers ( init_declarator_list )? ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_declaration_specifiers_in_declaration214);
                    	declaration_specifiers13 = declaration_specifiers();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers13.Tree, declaration_specifiers13, retval);
                    	// C.g:106:27: ( init_declarator_list )?
                    	int alt7 = 2;
                    	int LA7_0 = input.LA(1);

                    	if ( (LA7_0 == IDENTIFIER || LA7_0 == 48 || LA7_0 == 52) )
                    	{
                    	    alt7 = 1;
                    	}
                    	switch (alt7) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: init_declarator_list
                    	        {
                    	        	PushFollow(FOLLOW_init_declarator_list_in_declaration216);
                    	        	init_declarator_list14 = init_declarator_list();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator_list14.Tree, init_declarator_list14, retval);

                    	        }
                    	        break;

                    	}

                    	char_literal15=(IToken)Match(input,24,FOLLOW_24_in_declaration219); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal15_tree = (object)adaptor.Create(char_literal15, retval);
                    		adaptor.AddChild(root_0, char_literal15_tree);
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
            	Memoize(input, 4, declaration_StartIndex); 
            }
            declaration_stack.Pop();
        }
        return retval;
    }
    // $ANTLR end "declaration"

    public class declaration_specifiers_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "declaration_specifiers"
    // C.g:109:1: declaration_specifiers : ( storage_class_specifier | type_specifier | type_qualifier )+ ;
    public CParser.declaration_specifiers_return declaration_specifiers() // throws RecognitionException [1]
    {   
        CParser.declaration_specifiers_return retval = new CParser.declaration_specifiers_return();
        retval.Start = input.LT(1);
        int declaration_specifiers_StartIndex = input.Index();
        object root_0 = null;

        CParser.storage_class_specifier_return storage_class_specifier16 = default(CParser.storage_class_specifier_return);

        CParser.type_specifier_return type_specifier17 = default(CParser.type_specifier_return);

        CParser.type_qualifier_return type_qualifier18 = default(CParser.type_qualifier_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 5) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:110:2: ( ( storage_class_specifier | type_specifier | type_qualifier )+ )
            // C.g:110:6: ( storage_class_specifier | type_specifier | type_qualifier )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:110:6: ( storage_class_specifier | type_specifier | type_qualifier )+
            	int cnt9 = 0;
            	do 
            	{
            	    int alt9 = 4;
            	    alt9 = dfa9.Predict(input);
            	    switch (alt9) 
            		{
            			case 1 :
            			    // C.g:110:10: storage_class_specifier
            			    {
            			    	PushFollow(FOLLOW_storage_class_specifier_in_declaration_specifiers236);
            			    	storage_class_specifier16 = storage_class_specifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, storage_class_specifier16.Tree, storage_class_specifier16, retval);

            			    }
            			    break;
            			case 2 :
            			    // C.g:111:7: type_specifier
            			    {
            			    	PushFollow(FOLLOW_type_specifier_in_declaration_specifiers244);
            			    	type_specifier17 = type_specifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_specifier17.Tree, type_specifier17, retval);

            			    }
            			    break;
            			case 3 :
            			    // C.g:112:13: type_qualifier
            			    {
            			    	PushFollow(FOLLOW_type_qualifier_in_declaration_specifiers258);
            			    	type_qualifier18 = type_qualifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_qualifier18.Tree, type_qualifier18, retval);

            			    }
            			    break;

            			default:
            			    if ( cnt9 >= 1 ) goto loop9;
            			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            		            EarlyExitException eee9 =
            		                new EarlyExitException(9, input);
            		            throw eee9;
            	    }
            	    cnt9++;
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements


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
            	Memoize(input, 5, declaration_specifiers_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "declaration_specifiers"

    public class init_declarator_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "init_declarator_list"
    // C.g:116:1: init_declarator_list : init_declarator ( ',' init_declarator )* ;
    public CParser.init_declarator_list_return init_declarator_list() // throws RecognitionException [1]
    {   
        CParser.init_declarator_list_return retval = new CParser.init_declarator_list_return();
        retval.Start = input.LT(1);
        int init_declarator_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal20 = null;
        CParser.init_declarator_return init_declarator19 = default(CParser.init_declarator_return);

        CParser.init_declarator_return init_declarator21 = default(CParser.init_declarator_return);


        object char_literal20_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 6) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:117:2: ( init_declarator ( ',' init_declarator )* )
            // C.g:117:4: init_declarator ( ',' init_declarator )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_init_declarator_in_init_declarator_list280);
            	init_declarator19 = init_declarator();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator19.Tree, init_declarator19, retval);
            	// C.g:117:20: ( ',' init_declarator )*
            	do 
            	{
            	    int alt10 = 2;
            	    int LA10_0 = input.LA(1);

            	    if ( (LA10_0 == 25) )
            	    {
            	        alt10 = 1;
            	    }


            	    switch (alt10) 
            		{
            			case 1 :
            			    // C.g:117:21: ',' init_declarator
            			    {
            			    	char_literal20=(IToken)Match(input,25,FOLLOW_25_in_init_declarator_list283); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal20_tree = (object)adaptor.Create(char_literal20, retval);
            			    		adaptor.AddChild(root_0, char_literal20_tree);
            			    	}
            			    	PushFollow(FOLLOW_init_declarator_in_init_declarator_list285);
            			    	init_declarator21 = init_declarator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, init_declarator21.Tree, init_declarator21, retval);

            			    }
            			    break;

            			default:
            			    goto loop10;
            	    }
            	} while (true);

            	loop10:
            		;	// Stops C# compiler whining that label 'loop10' has no statements


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
            	Memoize(input, 6, init_declarator_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "init_declarator_list"

    public class init_declarator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "init_declarator"
    // C.g:120:1: init_declarator : declarator ( '=' initializer )? ;
    public CParser.init_declarator_return init_declarator() // throws RecognitionException [1]
    {   
        CParser.init_declarator_return retval = new CParser.init_declarator_return();
        retval.Start = input.LT(1);
        int init_declarator_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal23 = null;
        CParser.declarator_return declarator22 = default(CParser.declarator_return);

        CParser.initializer_return initializer24 = default(CParser.initializer_return);


        object char_literal23_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 7) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:121:2: ( declarator ( '=' initializer )? )
            // C.g:121:4: declarator ( '=' initializer )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_declarator_in_init_declarator298);
            	declarator22 = declarator();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator22.Tree, declarator22, retval);
            	// C.g:121:15: ( '=' initializer )?
            	int alt11 = 2;
            	int LA11_0 = input.LA(1);

            	if ( (LA11_0 == 26) )
            	{
            	    alt11 = 1;
            	}
            	switch (alt11) 
            	{
            	    case 1 :
            	        // C.g:121:16: '=' initializer
            	        {
            	        	char_literal23=(IToken)Match(input,26,FOLLOW_26_in_init_declarator301); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal23_tree = (object)adaptor.Create(char_literal23, retval);
            	        		adaptor.AddChild(root_0, char_literal23_tree);
            	        	}
            	        	PushFollow(FOLLOW_initializer_in_init_declarator303);
            	        	initializer24 = initializer();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer24.Tree, initializer24, retval);

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
            	Memoize(input, 7, init_declarator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "init_declarator"

    public class storage_class_specifier_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "storage_class_specifier"
    // C.g:124:1: storage_class_specifier : ( 'extern' | 'static' | 'auto' | 'register' );
    public CParser.storage_class_specifier_return storage_class_specifier() // throws RecognitionException [1]
    {   
        CParser.storage_class_specifier_return retval = new CParser.storage_class_specifier_return();
        retval.Start = input.LT(1);
        int storage_class_specifier_StartIndex = input.Index();
        object root_0 = null;

        IToken set25 = null;

        object set25_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 8) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:125:2: ( 'extern' | 'static' | 'auto' | 'register' )
            // C.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set25 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 27 && input.LA(1) <= 30) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set25, retval));
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
            	Memoize(input, 8, storage_class_specifier_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "storage_class_specifier"

    public class type_specifier_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "type_specifier"
    // C.g:131:1: type_specifier : ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | struct_or_union_specifier | enum_specifier | type_id );
    public CParser.type_specifier_return type_specifier() // throws RecognitionException [1]
    {   
        CParser.type_specifier_return retval = new CParser.type_specifier_return();
        retval.Start = input.LT(1);
        int type_specifier_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal26 = null;
        IToken string_literal27 = null;
        IToken string_literal28 = null;
        IToken string_literal29 = null;
        IToken string_literal30 = null;
        IToken string_literal31 = null;
        IToken string_literal32 = null;
        IToken string_literal33 = null;
        IToken string_literal34 = null;
        CParser.struct_or_union_specifier_return struct_or_union_specifier35 = default(CParser.struct_or_union_specifier_return);

        CParser.enum_specifier_return enum_specifier36 = default(CParser.enum_specifier_return);

        CParser.type_id_return type_id37 = default(CParser.type_id_return);


        object string_literal26_tree=null;
        object string_literal27_tree=null;
        object string_literal28_tree=null;
        object string_literal29_tree=null;
        object string_literal30_tree=null;
        object string_literal31_tree=null;
        object string_literal32_tree=null;
        object string_literal33_tree=null;
        object string_literal34_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 9) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:132:2: ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | struct_or_union_specifier | enum_specifier | type_id )
            int alt12 = 12;
            alt12 = dfa12.Predict(input);
            switch (alt12) 
            {
                case 1 :
                    // C.g:132:4: 'void'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal26=(IToken)Match(input,31,FOLLOW_31_in_type_specifier342); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal26_tree = (object)adaptor.Create(string_literal26, retval);
                    		adaptor.AddChild(root_0, string_literal26_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:133:4: 'char'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal27=(IToken)Match(input,32,FOLLOW_32_in_type_specifier347); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal27_tree = (object)adaptor.Create(string_literal27, retval);
                    		adaptor.AddChild(root_0, string_literal27_tree);
                    	}

                    }
                    break;
                case 3 :
                    // C.g:134:4: 'short'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal28=(IToken)Match(input,33,FOLLOW_33_in_type_specifier352); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal28_tree = (object)adaptor.Create(string_literal28, retval);
                    		adaptor.AddChild(root_0, string_literal28_tree);
                    	}

                    }
                    break;
                case 4 :
                    // C.g:135:4: 'int'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal29=(IToken)Match(input,34,FOLLOW_34_in_type_specifier357); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal29_tree = (object)adaptor.Create(string_literal29, retval);
                    		adaptor.AddChild(root_0, string_literal29_tree);
                    	}

                    }
                    break;
                case 5 :
                    // C.g:136:4: 'long'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal30=(IToken)Match(input,35,FOLLOW_35_in_type_specifier362); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal30_tree = (object)adaptor.Create(string_literal30, retval);
                    		adaptor.AddChild(root_0, string_literal30_tree);
                    	}

                    }
                    break;
                case 6 :
                    // C.g:137:4: 'float'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal31=(IToken)Match(input,36,FOLLOW_36_in_type_specifier367); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal31_tree = (object)adaptor.Create(string_literal31, retval);
                    		adaptor.AddChild(root_0, string_literal31_tree);
                    	}

                    }
                    break;
                case 7 :
                    // C.g:138:4: 'double'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal32=(IToken)Match(input,37,FOLLOW_37_in_type_specifier372); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal32_tree = (object)adaptor.Create(string_literal32, retval);
                    		adaptor.AddChild(root_0, string_literal32_tree);
                    	}

                    }
                    break;
                case 8 :
                    // C.g:139:4: 'signed'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal33=(IToken)Match(input,38,FOLLOW_38_in_type_specifier377); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal33_tree = (object)adaptor.Create(string_literal33, retval);
                    		adaptor.AddChild(root_0, string_literal33_tree);
                    	}

                    }
                    break;
                case 9 :
                    // C.g:140:4: 'unsigned'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal34=(IToken)Match(input,39,FOLLOW_39_in_type_specifier382); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal34_tree = (object)adaptor.Create(string_literal34, retval);
                    		adaptor.AddChild(root_0, string_literal34_tree);
                    	}

                    }
                    break;
                case 10 :
                    // C.g:141:4: struct_or_union_specifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_struct_or_union_specifier_in_type_specifier387);
                    	struct_or_union_specifier35 = struct_or_union_specifier();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_or_union_specifier35.Tree, struct_or_union_specifier35, retval);

                    }
                    break;
                case 11 :
                    // C.g:142:4: enum_specifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_enum_specifier_in_type_specifier392);
                    	enum_specifier36 = enum_specifier();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enum_specifier36.Tree, enum_specifier36, retval);

                    }
                    break;
                case 12 :
                    // C.g:143:4: type_id
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_type_id_in_type_specifier397);
                    	type_id37 = type_id();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_id37.Tree, type_id37, retval);

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
            	Memoize(input, 9, type_specifier_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "type_specifier"

    public class type_id_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "type_id"
    // C.g:146:1: type_id : {...}? IDENTIFIER ;
    public CParser.type_id_return type_id() // throws RecognitionException [1]
    {   
        CParser.type_id_return retval = new CParser.type_id_return();
        retval.Start = input.LT(1);
        int type_id_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENTIFIER38 = null;

        object IDENTIFIER38_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 10) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:147:5: ({...}? IDENTIFIER )
            // C.g:147:9: {...}? IDENTIFIER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	if ( !((isTypeName(input.LT(1).getText()))) ) 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    throw new FailedPredicateException(input, "type_id", "isTypeName(input.LT(1).getText())");
            	}
            	IDENTIFIER38=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_type_id415), "IDENTIFIER"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{IDENTIFIER38_tree = (object)adaptor.Create(IDENTIFIER38, retval);
            		adaptor.AddChild(root_0, IDENTIFIER38_tree);
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
            	Memoize(input, 10, type_id_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "type_id"

    public class struct_or_union_specifier_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "struct_or_union_specifier"
    // C.g:151:1: struct_or_union_specifier options {k=3; } : ( struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}' | struct_or_union IDENTIFIER );
    public CParser.struct_or_union_specifier_return struct_or_union_specifier() // throws RecognitionException [1]
    {   
        Symbols_stack.Push(new Symbols_scope());

        CParser.struct_or_union_specifier_return retval = new CParser.struct_or_union_specifier_return();
        retval.Start = input.LT(1);
        int struct_or_union_specifier_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENTIFIER40 = null;
        IToken char_literal41 = null;
        IToken char_literal43 = null;
        IToken IDENTIFIER45 = null;
        CParser.struct_or_union_return struct_or_union39 = default(CParser.struct_or_union_return);

        CParser.struct_declaration_list_return struct_declaration_list42 = default(CParser.struct_declaration_list_return);

        CParser.struct_or_union_return struct_or_union44 = default(CParser.struct_or_union_return);


        object IDENTIFIER40_tree=null;
        object char_literal41_tree=null;
        object char_literal43_tree=null;
        object IDENTIFIER45_tree=null;


          ((Symbols_scope)Symbols_stack.Peek()).types =  new HashSet();

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 11) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:157:2: ( struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}' | struct_or_union IDENTIFIER )
            int alt14 = 2;
            alt14 = dfa14.Predict(input);
            switch (alt14) 
            {
                case 1 :
                    // C.g:157:4: struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_struct_or_union_in_struct_or_union_specifier448);
                    	struct_or_union39 = struct_or_union();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_or_union39.Tree, struct_or_union39, retval);
                    	// C.g:157:20: ( IDENTIFIER )?
                    	int alt13 = 2;
                    	int LA13_0 = input.LA(1);

                    	if ( (LA13_0 == IDENTIFIER) )
                    	{
                    	    alt13 = 1;
                    	}
                    	switch (alt13) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: IDENTIFIER
                    	        {
                    	        	IDENTIFIER40=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_struct_or_union_specifier450), "IDENTIFIER"); if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 )
                    	        	{IDENTIFIER40_tree = (object)adaptor.Create(IDENTIFIER40, retval);
                    	        		adaptor.AddChild(root_0, IDENTIFIER40_tree);
                    	        	}

                    	        }
                    	        break;

                    	}

                    	char_literal41=(IToken)Match(input,40,FOLLOW_40_in_struct_or_union_specifier453); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal41_tree = (object)adaptor.Create(char_literal41, retval);
                    		adaptor.AddChild(root_0, char_literal41_tree);
                    	}
                    	PushFollow(FOLLOW_struct_declaration_list_in_struct_or_union_specifier455);
                    	struct_declaration_list42 = struct_declaration_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declaration_list42.Tree, struct_declaration_list42, retval);
                    	char_literal43=(IToken)Match(input,41,FOLLOW_41_in_struct_or_union_specifier457); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal43_tree = (object)adaptor.Create(char_literal43, retval);
                    		adaptor.AddChild(root_0, char_literal43_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:158:4: struct_or_union IDENTIFIER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_struct_or_union_in_struct_or_union_specifier462);
                    	struct_or_union44 = struct_or_union();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_or_union44.Tree, struct_or_union44, retval);
                    	IDENTIFIER45=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_struct_or_union_specifier464), "IDENTIFIER"); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENTIFIER45_tree = (object)adaptor.Create(IDENTIFIER45, retval);
                    		adaptor.AddChild(root_0, IDENTIFIER45_tree);
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
            	Memoize(input, 11, struct_or_union_specifier_StartIndex); 
            }
            Symbols_stack.Pop();

        }
        return retval;
    }
    // $ANTLR end "struct_or_union_specifier"

    public class struct_or_union_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "struct_or_union"
    // C.g:161:1: struct_or_union : ( 'struct' | 'union' );
    public CParser.struct_or_union_return struct_or_union() // throws RecognitionException [1]
    {   
        CParser.struct_or_union_return retval = new CParser.struct_or_union_return();
        retval.Start = input.LT(1);
        int struct_or_union_StartIndex = input.Index();
        object root_0 = null;

        IToken set46 = null;

        object set46_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 12) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:162:2: ( 'struct' | 'union' )
            // C.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set46 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 42 && input.LA(1) <= 43) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set46, retval));
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
            	Memoize(input, 12, struct_or_union_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "struct_or_union"

    public class struct_declaration_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "struct_declaration_list"
    // C.g:166:1: struct_declaration_list : ( struct_declaration )+ ;
    public CParser.struct_declaration_list_return struct_declaration_list() // throws RecognitionException [1]
    {   
        CParser.struct_declaration_list_return retval = new CParser.struct_declaration_list_return();
        retval.Start = input.LT(1);
        int struct_declaration_list_StartIndex = input.Index();
        object root_0 = null;

        CParser.struct_declaration_return struct_declaration47 = default(CParser.struct_declaration_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 13) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:167:2: ( ( struct_declaration )+ )
            // C.g:167:4: ( struct_declaration )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:167:4: ( struct_declaration )+
            	int cnt15 = 0;
            	do 
            	{
            	    int alt15 = 2;
            	    alt15 = dfa15.Predict(input);
            	    switch (alt15) 
            		{
            			case 1 :
            			    // C.g:0:0: struct_declaration
            			    {
            			    	PushFollow(FOLLOW_struct_declaration_in_struct_declaration_list491);
            			    	struct_declaration47 = struct_declaration();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declaration47.Tree, struct_declaration47, retval);

            			    }
            			    break;

            			default:
            			    if ( cnt15 >= 1 ) goto loop15;
            			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            		            EarlyExitException eee15 =
            		                new EarlyExitException(15, input);
            		            throw eee15;
            	    }
            	    cnt15++;
            	} while (true);

            	loop15:
            		;	// Stops C# compiler whining that label 'loop15' has no statements


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
            	Memoize(input, 13, struct_declaration_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "struct_declaration_list"

    public class struct_declaration_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "struct_declaration"
    // C.g:170:1: struct_declaration : specifier_qualifier_list struct_declarator_list ';' ;
    public CParser.struct_declaration_return struct_declaration() // throws RecognitionException [1]
    {   
        CParser.struct_declaration_return retval = new CParser.struct_declaration_return();
        retval.Start = input.LT(1);
        int struct_declaration_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal50 = null;
        CParser.specifier_qualifier_list_return specifier_qualifier_list48 = default(CParser.specifier_qualifier_list_return);

        CParser.struct_declarator_list_return struct_declarator_list49 = default(CParser.struct_declarator_list_return);


        object char_literal50_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 14) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:171:2: ( specifier_qualifier_list struct_declarator_list ';' )
            // C.g:171:4: specifier_qualifier_list struct_declarator_list ';'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_specifier_qualifier_list_in_struct_declaration503);
            	specifier_qualifier_list48 = specifier_qualifier_list();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, specifier_qualifier_list48.Tree, specifier_qualifier_list48, retval);
            	PushFollow(FOLLOW_struct_declarator_list_in_struct_declaration505);
            	struct_declarator_list49 = struct_declarator_list();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declarator_list49.Tree, struct_declarator_list49, retval);
            	char_literal50=(IToken)Match(input,24,FOLLOW_24_in_struct_declaration507); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal50_tree = (object)adaptor.Create(char_literal50, retval);
            		adaptor.AddChild(root_0, char_literal50_tree);
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
            	Memoize(input, 14, struct_declaration_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "struct_declaration"

    public class specifier_qualifier_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "specifier_qualifier_list"
    // C.g:174:1: specifier_qualifier_list : ( type_qualifier | type_specifier )+ ;
    public CParser.specifier_qualifier_list_return specifier_qualifier_list() // throws RecognitionException [1]
    {   
        CParser.specifier_qualifier_list_return retval = new CParser.specifier_qualifier_list_return();
        retval.Start = input.LT(1);
        int specifier_qualifier_list_StartIndex = input.Index();
        object root_0 = null;

        CParser.type_qualifier_return type_qualifier51 = default(CParser.type_qualifier_return);

        CParser.type_specifier_return type_specifier52 = default(CParser.type_specifier_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 15) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:175:2: ( ( type_qualifier | type_specifier )+ )
            // C.g:175:4: ( type_qualifier | type_specifier )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:175:4: ( type_qualifier | type_specifier )+
            	int cnt16 = 0;
            	do 
            	{
            	    int alt16 = 3;
            	    alt16 = dfa16.Predict(input);
            	    switch (alt16) 
            		{
            			case 1 :
            			    // C.g:175:6: type_qualifier
            			    {
            			    	PushFollow(FOLLOW_type_qualifier_in_specifier_qualifier_list520);
            			    	type_qualifier51 = type_qualifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_qualifier51.Tree, type_qualifier51, retval);

            			    }
            			    break;
            			case 2 :
            			    // C.g:175:23: type_specifier
            			    {
            			    	PushFollow(FOLLOW_type_specifier_in_specifier_qualifier_list524);
            			    	type_specifier52 = type_specifier();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_specifier52.Tree, type_specifier52, retval);

            			    }
            			    break;

            			default:
            			    if ( cnt16 >= 1 ) goto loop16;
            			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            		            EarlyExitException eee16 =
            		                new EarlyExitException(16, input);
            		            throw eee16;
            	    }
            	    cnt16++;
            	} while (true);

            	loop16:
            		;	// Stops C# compiler whining that label 'loop16' has no statements


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
            	Memoize(input, 15, specifier_qualifier_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "specifier_qualifier_list"

    public class struct_declarator_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "struct_declarator_list"
    // C.g:178:1: struct_declarator_list : struct_declarator ( ',' struct_declarator )* ;
    public CParser.struct_declarator_list_return struct_declarator_list() // throws RecognitionException [1]
    {   
        CParser.struct_declarator_list_return retval = new CParser.struct_declarator_list_return();
        retval.Start = input.LT(1);
        int struct_declarator_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal54 = null;
        CParser.struct_declarator_return struct_declarator53 = default(CParser.struct_declarator_return);

        CParser.struct_declarator_return struct_declarator55 = default(CParser.struct_declarator_return);


        object char_literal54_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 16) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:179:2: ( struct_declarator ( ',' struct_declarator )* )
            // C.g:179:4: struct_declarator ( ',' struct_declarator )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_struct_declarator_in_struct_declarator_list538);
            	struct_declarator53 = struct_declarator();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declarator53.Tree, struct_declarator53, retval);
            	// C.g:179:22: ( ',' struct_declarator )*
            	do 
            	{
            	    int alt17 = 2;
            	    int LA17_0 = input.LA(1);

            	    if ( (LA17_0 == 25) )
            	    {
            	        alt17 = 1;
            	    }


            	    switch (alt17) 
            		{
            			case 1 :
            			    // C.g:179:23: ',' struct_declarator
            			    {
            			    	char_literal54=(IToken)Match(input,25,FOLLOW_25_in_struct_declarator_list541); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal54_tree = (object)adaptor.Create(char_literal54, retval);
            			    		adaptor.AddChild(root_0, char_literal54_tree);
            			    	}
            			    	PushFollow(FOLLOW_struct_declarator_in_struct_declarator_list543);
            			    	struct_declarator55 = struct_declarator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, struct_declarator55.Tree, struct_declarator55, retval);

            			    }
            			    break;

            			default:
            			    goto loop17;
            	    }
            	} while (true);

            	loop17:
            		;	// Stops C# compiler whining that label 'loop17' has no statements


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
            	Memoize(input, 16, struct_declarator_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "struct_declarator_list"

    public class struct_declarator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "struct_declarator"
    // C.g:182:1: struct_declarator : ( declarator ( ':' constant_expression )? | ':' constant_expression );
    public CParser.struct_declarator_return struct_declarator() // throws RecognitionException [1]
    {   
        CParser.struct_declarator_return retval = new CParser.struct_declarator_return();
        retval.Start = input.LT(1);
        int struct_declarator_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal57 = null;
        IToken char_literal59 = null;
        CParser.declarator_return declarator56 = default(CParser.declarator_return);

        CParser.constant_expression_return constant_expression58 = default(CParser.constant_expression_return);

        CParser.constant_expression_return constant_expression60 = default(CParser.constant_expression_return);


        object char_literal57_tree=null;
        object char_literal59_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 17) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:183:2: ( declarator ( ':' constant_expression )? | ':' constant_expression )
            int alt19 = 2;
            int LA19_0 = input.LA(1);

            if ( (LA19_0 == IDENTIFIER || LA19_0 == 48 || LA19_0 == 52) )
            {
                alt19 = 1;
            }
            else if ( (LA19_0 == 44) )
            {
                alt19 = 2;
            }
            else 
            {
                if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                NoViableAltException nvae_d19s0 =
                    new NoViableAltException("", 19, 0, input);

                throw nvae_d19s0;
            }
            switch (alt19) 
            {
                case 1 :
                    // C.g:183:4: declarator ( ':' constant_expression )?
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_declarator_in_struct_declarator556);
                    	declarator56 = declarator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator56.Tree, declarator56, retval);
                    	// C.g:183:15: ( ':' constant_expression )?
                    	int alt18 = 2;
                    	int LA18_0 = input.LA(1);

                    	if ( (LA18_0 == 44) )
                    	{
                    	    alt18 = 1;
                    	}
                    	switch (alt18) 
                    	{
                    	    case 1 :
                    	        // C.g:183:16: ':' constant_expression
                    	        {
                    	        	char_literal57=(IToken)Match(input,44,FOLLOW_44_in_struct_declarator559); if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 )
                    	        	{char_literal57_tree = (object)adaptor.Create(char_literal57, retval);
                    	        		adaptor.AddChild(root_0, char_literal57_tree);
                    	        	}
                    	        	PushFollow(FOLLOW_constant_expression_in_struct_declarator561);
                    	        	constant_expression58 = constant_expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression58.Tree, constant_expression58, retval);

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // C.g:184:4: ':' constant_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal59=(IToken)Match(input,44,FOLLOW_44_in_struct_declarator568); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal59_tree = (object)adaptor.Create(char_literal59, retval);
                    		adaptor.AddChild(root_0, char_literal59_tree);
                    	}
                    	PushFollow(FOLLOW_constant_expression_in_struct_declarator570);
                    	constant_expression60 = constant_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression60.Tree, constant_expression60, retval);

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
            	Memoize(input, 17, struct_declarator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "struct_declarator"

    public class enum_specifier_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "enum_specifier"
    // C.g:187:1: enum_specifier options {k=3; } : ( 'enum' '{' enumerator_list '}' | 'enum' IDENTIFIER '{' enumerator_list '}' | 'enum' IDENTIFIER );
    public CParser.enum_specifier_return enum_specifier() // throws RecognitionException [1]
    {   
        CParser.enum_specifier_return retval = new CParser.enum_specifier_return();
        retval.Start = input.LT(1);
        int enum_specifier_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal61 = null;
        IToken char_literal62 = null;
        IToken char_literal64 = null;
        IToken string_literal65 = null;
        IToken IDENTIFIER66 = null;
        IToken char_literal67 = null;
        IToken char_literal69 = null;
        IToken string_literal70 = null;
        IToken IDENTIFIER71 = null;
        CParser.enumerator_list_return enumerator_list63 = default(CParser.enumerator_list_return);

        CParser.enumerator_list_return enumerator_list68 = default(CParser.enumerator_list_return);


        object string_literal61_tree=null;
        object char_literal62_tree=null;
        object char_literal64_tree=null;
        object string_literal65_tree=null;
        object IDENTIFIER66_tree=null;
        object char_literal67_tree=null;
        object char_literal69_tree=null;
        object string_literal70_tree=null;
        object IDENTIFIER71_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 18) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:189:2: ( 'enum' '{' enumerator_list '}' | 'enum' IDENTIFIER '{' enumerator_list '}' | 'enum' IDENTIFIER )
            int alt20 = 3;
            alt20 = dfa20.Predict(input);
            switch (alt20) 
            {
                case 1 :
                    // C.g:189:4: 'enum' '{' enumerator_list '}'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal61=(IToken)Match(input,45,FOLLOW_45_in_enum_specifier588); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal61_tree = (object)adaptor.Create(string_literal61, retval);
                    		adaptor.AddChild(root_0, string_literal61_tree);
                    	}
                    	char_literal62=(IToken)Match(input,40,FOLLOW_40_in_enum_specifier590); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal62_tree = (object)adaptor.Create(char_literal62, retval);
                    		adaptor.AddChild(root_0, char_literal62_tree);
                    	}
                    	PushFollow(FOLLOW_enumerator_list_in_enum_specifier592);
                    	enumerator_list63 = enumerator_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator_list63.Tree, enumerator_list63, retval);
                    	char_literal64=(IToken)Match(input,41,FOLLOW_41_in_enum_specifier594); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal64_tree = (object)adaptor.Create(char_literal64, retval);
                    		adaptor.AddChild(root_0, char_literal64_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:190:4: 'enum' IDENTIFIER '{' enumerator_list '}'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal65=(IToken)Match(input,45,FOLLOW_45_in_enum_specifier599); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal65_tree = (object)adaptor.Create(string_literal65, retval);
                    		adaptor.AddChild(root_0, string_literal65_tree);
                    	}
                    	IDENTIFIER66=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_specifier601), "IDENTIFIER"); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENTIFIER66_tree = (object)adaptor.Create(IDENTIFIER66, retval);
                    		adaptor.AddChild(root_0, IDENTIFIER66_tree);
                    	}
                    	char_literal67=(IToken)Match(input,40,FOLLOW_40_in_enum_specifier603); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal67_tree = (object)adaptor.Create(char_literal67, retval);
                    		adaptor.AddChild(root_0, char_literal67_tree);
                    	}
                    	PushFollow(FOLLOW_enumerator_list_in_enum_specifier605);
                    	enumerator_list68 = enumerator_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator_list68.Tree, enumerator_list68, retval);
                    	char_literal69=(IToken)Match(input,41,FOLLOW_41_in_enum_specifier607); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal69_tree = (object)adaptor.Create(char_literal69, retval);
                    		adaptor.AddChild(root_0, char_literal69_tree);
                    	}

                    }
                    break;
                case 3 :
                    // C.g:191:4: 'enum' IDENTIFIER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal70=(IToken)Match(input,45,FOLLOW_45_in_enum_specifier612); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal70_tree = (object)adaptor.Create(string_literal70, retval);
                    		adaptor.AddChild(root_0, string_literal70_tree);
                    	}
                    	IDENTIFIER71=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enum_specifier614), "IDENTIFIER"); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENTIFIER71_tree = (object)adaptor.Create(IDENTIFIER71, retval);
                    		adaptor.AddChild(root_0, IDENTIFIER71_tree);
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
            	Memoize(input, 18, enum_specifier_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "enum_specifier"

    public class enumerator_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "enumerator_list"
    // C.g:194:1: enumerator_list : enumerator ( ',' enumerator )* ;
    public CParser.enumerator_list_return enumerator_list() // throws RecognitionException [1]
    {   
        CParser.enumerator_list_return retval = new CParser.enumerator_list_return();
        retval.Start = input.LT(1);
        int enumerator_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal73 = null;
        CParser.enumerator_return enumerator72 = default(CParser.enumerator_return);

        CParser.enumerator_return enumerator74 = default(CParser.enumerator_return);


        object char_literal73_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 19) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:195:2: ( enumerator ( ',' enumerator )* )
            // C.g:195:4: enumerator ( ',' enumerator )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_enumerator_in_enumerator_list625);
            	enumerator72 = enumerator();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator72.Tree, enumerator72, retval);
            	// C.g:195:15: ( ',' enumerator )*
            	do 
            	{
            	    int alt21 = 2;
            	    int LA21_0 = input.LA(1);

            	    if ( (LA21_0 == 25) )
            	    {
            	        alt21 = 1;
            	    }


            	    switch (alt21) 
            		{
            			case 1 :
            			    // C.g:195:16: ',' enumerator
            			    {
            			    	char_literal73=(IToken)Match(input,25,FOLLOW_25_in_enumerator_list628); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal73_tree = (object)adaptor.Create(char_literal73, retval);
            			    		adaptor.AddChild(root_0, char_literal73_tree);
            			    	}
            			    	PushFollow(FOLLOW_enumerator_in_enumerator_list630);
            			    	enumerator74 = enumerator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, enumerator74.Tree, enumerator74, retval);

            			    }
            			    break;

            			default:
            			    goto loop21;
            	    }
            	} while (true);

            	loop21:
            		;	// Stops C# compiler whining that label 'loop21' has no statements


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
            	Memoize(input, 19, enumerator_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "enumerator_list"

    public class enumerator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "enumerator"
    // C.g:198:1: enumerator : IDENTIFIER ( '=' constant_expression )? ;
    public CParser.enumerator_return enumerator() // throws RecognitionException [1]
    {   
        CParser.enumerator_return retval = new CParser.enumerator_return();
        retval.Start = input.LT(1);
        int enumerator_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENTIFIER75 = null;
        IToken char_literal76 = null;
        CParser.constant_expression_return constant_expression77 = default(CParser.constant_expression_return);


        object IDENTIFIER75_tree=null;
        object char_literal76_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 20) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:199:2: ( IDENTIFIER ( '=' constant_expression )? )
            // C.g:199:4: IDENTIFIER ( '=' constant_expression )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	IDENTIFIER75=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_enumerator643), "IDENTIFIER"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{IDENTIFIER75_tree = (object)adaptor.Create(IDENTIFIER75, retval);
            		adaptor.AddChild(root_0, IDENTIFIER75_tree);
            	}
            	// C.g:199:15: ( '=' constant_expression )?
            	int alt22 = 2;
            	int LA22_0 = input.LA(1);

            	if ( (LA22_0 == 26) )
            	{
            	    alt22 = 1;
            	}
            	switch (alt22) 
            	{
            	    case 1 :
            	        // C.g:199:16: '=' constant_expression
            	        {
            	        	char_literal76=(IToken)Match(input,26,FOLLOW_26_in_enumerator646); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal76_tree = (object)adaptor.Create(char_literal76, retval);
            	        		adaptor.AddChild(root_0, char_literal76_tree);
            	        	}
            	        	PushFollow(FOLLOW_constant_expression_in_enumerator648);
            	        	constant_expression77 = constant_expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression77.Tree, constant_expression77, retval);

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
            	Memoize(input, 20, enumerator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "enumerator"

    public class type_qualifier_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "type_qualifier"
    // C.g:202:1: type_qualifier : ( 'const' | 'volatile' );
    public CParser.type_qualifier_return type_qualifier() // throws RecognitionException [1]
    {   
        CParser.type_qualifier_return retval = new CParser.type_qualifier_return();
        retval.Start = input.LT(1);
        int type_qualifier_StartIndex = input.Index();
        object root_0 = null;

        IToken set78 = null;

        object set78_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 21) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:203:2: ( 'const' | 'volatile' )
            // C.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set78 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= 46 && input.LA(1) <= 47) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set78, retval));
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
            	Memoize(input, 21, type_qualifier_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "type_qualifier"

    public class declarator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "declarator"
    // C.g:207:1: declarator : ( ( pointer )? direct_declarator | pointer );
    public CParser.declarator_return declarator() // throws RecognitionException [1]
    {   
        CParser.declarator_return retval = new CParser.declarator_return();
        retval.Start = input.LT(1);
        int declarator_StartIndex = input.Index();
        object root_0 = null;

        CParser.pointer_return pointer79 = default(CParser.pointer_return);

        CParser.direct_declarator_return direct_declarator80 = default(CParser.direct_declarator_return);

        CParser.pointer_return pointer81 = default(CParser.pointer_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 22) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:208:2: ( ( pointer )? direct_declarator | pointer )
            int alt24 = 2;
            alt24 = dfa24.Predict(input);
            switch (alt24) 
            {
                case 1 :
                    // C.g:208:4: ( pointer )? direct_declarator
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// C.g:208:4: ( pointer )?
                    	int alt23 = 2;
                    	int LA23_0 = input.LA(1);

                    	if ( (LA23_0 == 52) )
                    	{
                    	    alt23 = 1;
                    	}
                    	switch (alt23) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: pointer
                    	        {
                    	        	PushFollow(FOLLOW_pointer_in_declarator677);
                    	        	pointer79 = pointer();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer79.Tree, pointer79, retval);

                    	        }
                    	        break;

                    	}

                    	PushFollow(FOLLOW_direct_declarator_in_declarator680);
                    	direct_declarator80 = direct_declarator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, direct_declarator80.Tree, direct_declarator80, retval);

                    }
                    break;
                case 2 :
                    // C.g:209:4: pointer
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_pointer_in_declarator685);
                    	pointer81 = pointer();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer81.Tree, pointer81, retval);

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
            	Memoize(input, 22, declarator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "declarator"

    public class direct_declarator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "direct_declarator"
    // C.g:212:1: direct_declarator : ( IDENTIFIER | '(' declarator ')' ) ( declarator_suffix )* ;
    public CParser.direct_declarator_return direct_declarator() // throws RecognitionException [1]
    {   
        CParser.direct_declarator_return retval = new CParser.direct_declarator_return();
        retval.Start = input.LT(1);
        int direct_declarator_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENTIFIER82 = null;
        IToken char_literal83 = null;
        IToken char_literal85 = null;
        CParser.declarator_return declarator84 = default(CParser.declarator_return);

        CParser.declarator_suffix_return declarator_suffix86 = default(CParser.declarator_suffix_return);


        object IDENTIFIER82_tree=null;
        object char_literal83_tree=null;
        object char_literal85_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 23) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:213:2: ( ( IDENTIFIER | '(' declarator ')' ) ( declarator_suffix )* )
            // C.g:213:6: ( IDENTIFIER | '(' declarator ')' ) ( declarator_suffix )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:213:6: ( IDENTIFIER | '(' declarator ')' )
            	int alt25 = 2;
            	int LA25_0 = input.LA(1);

            	if ( (LA25_0 == IDENTIFIER) )
            	{
            	    alt25 = 1;
            	}
            	else if ( (LA25_0 == 48) )
            	{
            	    alt25 = 2;
            	}
            	else 
            	{
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d25s0 =
            	        new NoViableAltException("", 25, 0, input);

            	    throw nvae_d25s0;
            	}
            	switch (alt25) 
            	{
            	    case 1 :
            	        // C.g:213:8: IDENTIFIER
            	        {
            	        	IDENTIFIER82=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_direct_declarator700), "IDENTIFIER"); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{IDENTIFIER82_tree = (object)adaptor.Create(IDENTIFIER82, retval);
            	        		adaptor.AddChild(root_0, IDENTIFIER82_tree);
            	        	}
            	        	if ( (state.backtracking==0) )
            	        	{

            	        	  			if (declaration_stack.size()>0&&((declaration_scope)declaration_stack.Peek()).isTypedef) {
            	        	  				((Symbols_scope)Symbols_stack.Peek()).types.add(((IDENTIFIER82 != null) ? IDENTIFIER82.Text : null));
            	        	  				
            	        	  			}
            	        	  			
            	        	}

            	        }
            	        break;
            	    case 2 :
            	        // C.g:220:5: '(' declarator ')'
            	        {
            	        	char_literal83=(IToken)Match(input,48,FOLLOW_48_in_direct_declarator711); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal83_tree = (object)adaptor.Create(char_literal83, retval);
            	        		adaptor.AddChild(root_0, char_literal83_tree);
            	        	}
            	        	PushFollow(FOLLOW_declarator_in_direct_declarator713);
            	        	declarator84 = declarator();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator84.Tree, declarator84, retval);
            	        	char_literal85=(IToken)Match(input,49,FOLLOW_49_in_direct_declarator715); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal85_tree = (object)adaptor.Create(char_literal85, retval);
            	        		adaptor.AddChild(root_0, char_literal85_tree);
            	        	}

            	        }
            	        break;

            	}

            	// C.g:222:9: ( declarator_suffix )*
            	do 
            	{
            	    int alt26 = 2;
            	    alt26 = dfa26.Predict(input);
            	    switch (alt26) 
            		{
            			case 1 :
            			    // C.g:0:0: declarator_suffix
            			    {
            			    	PushFollow(FOLLOW_declarator_suffix_in_direct_declarator729);
            			    	declarator_suffix86 = declarator_suffix();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator_suffix86.Tree, declarator_suffix86, retval);

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
            	Memoize(input, 23, direct_declarator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "direct_declarator"

    public class declarator_suffix_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "declarator_suffix"
    // C.g:225:1: declarator_suffix : ( '[' constant_expression ']' | '[' ']' | '(' parameter_type_list ')' | '(' identifier_list ')' | '(' ')' );
    public CParser.declarator_suffix_return declarator_suffix() // throws RecognitionException [1]
    {   
        CParser.declarator_suffix_return retval = new CParser.declarator_suffix_return();
        retval.Start = input.LT(1);
        int declarator_suffix_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal87 = null;
        IToken char_literal89 = null;
        IToken char_literal90 = null;
        IToken char_literal91 = null;
        IToken char_literal92 = null;
        IToken char_literal94 = null;
        IToken char_literal95 = null;
        IToken char_literal97 = null;
        IToken char_literal98 = null;
        IToken char_literal99 = null;
        CParser.constant_expression_return constant_expression88 = default(CParser.constant_expression_return);

        CParser.parameter_type_list_return parameter_type_list93 = default(CParser.parameter_type_list_return);

        CParser.identifier_list_return identifier_list96 = default(CParser.identifier_list_return);


        object char_literal87_tree=null;
        object char_literal89_tree=null;
        object char_literal90_tree=null;
        object char_literal91_tree=null;
        object char_literal92_tree=null;
        object char_literal94_tree=null;
        object char_literal95_tree=null;
        object char_literal97_tree=null;
        object char_literal98_tree=null;
        object char_literal99_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 24) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:226:2: ( '[' constant_expression ']' | '[' ']' | '(' parameter_type_list ')' | '(' identifier_list ')' | '(' ')' )
            int alt27 = 5;
            alt27 = dfa27.Predict(input);
            switch (alt27) 
            {
                case 1 :
                    // C.g:226:6: '[' constant_expression ']'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal87=(IToken)Match(input,50,FOLLOW_50_in_declarator_suffix743); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal87_tree = (object)adaptor.Create(char_literal87, retval);
                    		adaptor.AddChild(root_0, char_literal87_tree);
                    	}
                    	PushFollow(FOLLOW_constant_expression_in_declarator_suffix745);
                    	constant_expression88 = constant_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression88.Tree, constant_expression88, retval);
                    	char_literal89=(IToken)Match(input,51,FOLLOW_51_in_declarator_suffix747); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal89_tree = (object)adaptor.Create(char_literal89, retval);
                    		adaptor.AddChild(root_0, char_literal89_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:227:9: '[' ']'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal90=(IToken)Match(input,50,FOLLOW_50_in_declarator_suffix757); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal90_tree = (object)adaptor.Create(char_literal90, retval);
                    		adaptor.AddChild(root_0, char_literal90_tree);
                    	}
                    	char_literal91=(IToken)Match(input,51,FOLLOW_51_in_declarator_suffix759); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal91_tree = (object)adaptor.Create(char_literal91, retval);
                    		adaptor.AddChild(root_0, char_literal91_tree);
                    	}

                    }
                    break;
                case 3 :
                    // C.g:228:9: '(' parameter_type_list ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal92=(IToken)Match(input,48,FOLLOW_48_in_declarator_suffix769); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal92_tree = (object)adaptor.Create(char_literal92, retval);
                    		adaptor.AddChild(root_0, char_literal92_tree);
                    	}
                    	PushFollow(FOLLOW_parameter_type_list_in_declarator_suffix771);
                    	parameter_type_list93 = parameter_type_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_type_list93.Tree, parameter_type_list93, retval);
                    	char_literal94=(IToken)Match(input,49,FOLLOW_49_in_declarator_suffix773); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal94_tree = (object)adaptor.Create(char_literal94, retval);
                    		adaptor.AddChild(root_0, char_literal94_tree);
                    	}

                    }
                    break;
                case 4 :
                    // C.g:229:9: '(' identifier_list ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal95=(IToken)Match(input,48,FOLLOW_48_in_declarator_suffix783); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal95_tree = (object)adaptor.Create(char_literal95, retval);
                    		adaptor.AddChild(root_0, char_literal95_tree);
                    	}
                    	PushFollow(FOLLOW_identifier_list_in_declarator_suffix785);
                    	identifier_list96 = identifier_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, identifier_list96.Tree, identifier_list96, retval);
                    	char_literal97=(IToken)Match(input,49,FOLLOW_49_in_declarator_suffix787); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal97_tree = (object)adaptor.Create(char_literal97, retval);
                    		adaptor.AddChild(root_0, char_literal97_tree);
                    	}

                    }
                    break;
                case 5 :
                    // C.g:230:9: '(' ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal98=(IToken)Match(input,48,FOLLOW_48_in_declarator_suffix797); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal98_tree = (object)adaptor.Create(char_literal98, retval);
                    		adaptor.AddChild(root_0, char_literal98_tree);
                    	}
                    	char_literal99=(IToken)Match(input,49,FOLLOW_49_in_declarator_suffix799); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal99_tree = (object)adaptor.Create(char_literal99, retval);
                    		adaptor.AddChild(root_0, char_literal99_tree);
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
            	Memoize(input, 24, declarator_suffix_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "declarator_suffix"

    public class pointer_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "pointer"
    // C.g:233:1: pointer : ( '*' ( type_qualifier )+ ( pointer )? | '*' pointer | '*' );
    public CParser.pointer_return pointer() // throws RecognitionException [1]
    {   
        CParser.pointer_return retval = new CParser.pointer_return();
        retval.Start = input.LT(1);
        int pointer_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal100 = null;
        IToken char_literal103 = null;
        IToken char_literal105 = null;
        CParser.type_qualifier_return type_qualifier101 = default(CParser.type_qualifier_return);

        CParser.pointer_return pointer102 = default(CParser.pointer_return);

        CParser.pointer_return pointer104 = default(CParser.pointer_return);


        object char_literal100_tree=null;
        object char_literal103_tree=null;
        object char_literal105_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 25) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:234:2: ( '*' ( type_qualifier )+ ( pointer )? | '*' pointer | '*' )
            int alt30 = 3;
            alt30 = dfa30.Predict(input);
            switch (alt30) 
            {
                case 1 :
                    // C.g:234:4: '*' ( type_qualifier )+ ( pointer )?
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal100=(IToken)Match(input,52,FOLLOW_52_in_pointer810); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal100_tree = (object)adaptor.Create(char_literal100, retval);
                    		adaptor.AddChild(root_0, char_literal100_tree);
                    	}
                    	// C.g:234:8: ( type_qualifier )+
                    	int cnt28 = 0;
                    	do 
                    	{
                    	    int alt28 = 2;
                    	    alt28 = dfa28.Predict(input);
                    	    switch (alt28) 
                    		{
                    			case 1 :
                    			    // C.g:0:0: type_qualifier
                    			    {
                    			    	PushFollow(FOLLOW_type_qualifier_in_pointer812);
                    			    	type_qualifier101 = type_qualifier();
                    			    	state.followingStackPointer--;
                    			    	if (state.failed) return retval;
                    			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_qualifier101.Tree, type_qualifier101, retval);

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt28 >= 1 ) goto loop28;
                    			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
                    		            EarlyExitException eee28 =
                    		                new EarlyExitException(28, input);
                    		            throw eee28;
                    	    }
                    	    cnt28++;
                    	} while (true);

                    	loop28:
                    		;	// Stops C# compiler whining that label 'loop28' has no statements

                    	// C.g:234:24: ( pointer )?
                    	int alt29 = 2;
                    	alt29 = dfa29.Predict(input);
                    	switch (alt29) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: pointer
                    	        {
                    	        	PushFollow(FOLLOW_pointer_in_pointer815);
                    	        	pointer102 = pointer();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer102.Tree, pointer102, retval);

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // C.g:235:4: '*' pointer
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal103=(IToken)Match(input,52,FOLLOW_52_in_pointer821); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal103_tree = (object)adaptor.Create(char_literal103, retval);
                    		adaptor.AddChild(root_0, char_literal103_tree);
                    	}
                    	PushFollow(FOLLOW_pointer_in_pointer823);
                    	pointer104 = pointer();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer104.Tree, pointer104, retval);

                    }
                    break;
                case 3 :
                    // C.g:236:4: '*'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal105=(IToken)Match(input,52,FOLLOW_52_in_pointer828); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal105_tree = (object)adaptor.Create(char_literal105, retval);
                    		adaptor.AddChild(root_0, char_literal105_tree);
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
            	Memoize(input, 25, pointer_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "pointer"

    public class parameter_type_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "parameter_type_list"
    // C.g:239:1: parameter_type_list : parameter_list ( ',' '...' )? ;
    public CParser.parameter_type_list_return parameter_type_list() // throws RecognitionException [1]
    {   
        CParser.parameter_type_list_return retval = new CParser.parameter_type_list_return();
        retval.Start = input.LT(1);
        int parameter_type_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal107 = null;
        IToken string_literal108 = null;
        CParser.parameter_list_return parameter_list106 = default(CParser.parameter_list_return);


        object char_literal107_tree=null;
        object string_literal108_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 26) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:240:2: ( parameter_list ( ',' '...' )? )
            // C.g:240:4: parameter_list ( ',' '...' )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_parameter_list_in_parameter_type_list839);
            	parameter_list106 = parameter_list();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_list106.Tree, parameter_list106, retval);
            	// C.g:240:19: ( ',' '...' )?
            	int alt31 = 2;
            	int LA31_0 = input.LA(1);

            	if ( (LA31_0 == 25) )
            	{
            	    alt31 = 1;
            	}
            	switch (alt31) 
            	{
            	    case 1 :
            	        // C.g:240:20: ',' '...'
            	        {
            	        	char_literal107=(IToken)Match(input,25,FOLLOW_25_in_parameter_type_list842); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal107_tree = (object)adaptor.Create(char_literal107, retval);
            	        		adaptor.AddChild(root_0, char_literal107_tree);
            	        	}
            	        	string_literal108=(IToken)Match(input,53,FOLLOW_53_in_parameter_type_list844); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{string_literal108_tree = (object)adaptor.Create(string_literal108, retval);
            	        		adaptor.AddChild(root_0, string_literal108_tree);
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
            	Memoize(input, 26, parameter_type_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "parameter_type_list"

    public class parameter_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "parameter_list"
    // C.g:243:1: parameter_list : parameter_declaration ( ',' parameter_declaration )* ;
    public CParser.parameter_list_return parameter_list() // throws RecognitionException [1]
    {   
        CParser.parameter_list_return retval = new CParser.parameter_list_return();
        retval.Start = input.LT(1);
        int parameter_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal110 = null;
        CParser.parameter_declaration_return parameter_declaration109 = default(CParser.parameter_declaration_return);

        CParser.parameter_declaration_return parameter_declaration111 = default(CParser.parameter_declaration_return);


        object char_literal110_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 27) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:244:2: ( parameter_declaration ( ',' parameter_declaration )* )
            // C.g:244:4: parameter_declaration ( ',' parameter_declaration )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_parameter_declaration_in_parameter_list857);
            	parameter_declaration109 = parameter_declaration();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_declaration109.Tree, parameter_declaration109, retval);
            	// C.g:244:26: ( ',' parameter_declaration )*
            	do 
            	{
            	    int alt32 = 2;
            	    alt32 = dfa32.Predict(input);
            	    switch (alt32) 
            		{
            			case 1 :
            			    // C.g:244:27: ',' parameter_declaration
            			    {
            			    	char_literal110=(IToken)Match(input,25,FOLLOW_25_in_parameter_list860); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal110_tree = (object)adaptor.Create(char_literal110, retval);
            			    		adaptor.AddChild(root_0, char_literal110_tree);
            			    	}
            			    	PushFollow(FOLLOW_parameter_declaration_in_parameter_list862);
            			    	parameter_declaration111 = parameter_declaration();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_declaration111.Tree, parameter_declaration111, retval);

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
            	Memoize(input, 27, parameter_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "parameter_list"

    public class parameter_declaration_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "parameter_declaration"
    // C.g:247:1: parameter_declaration : declaration_specifiers ( declarator | abstract_declarator )* ;
    public CParser.parameter_declaration_return parameter_declaration() // throws RecognitionException [1]
    {   
        CParser.parameter_declaration_return retval = new CParser.parameter_declaration_return();
        retval.Start = input.LT(1);
        int parameter_declaration_StartIndex = input.Index();
        object root_0 = null;

        CParser.declaration_specifiers_return declaration_specifiers112 = default(CParser.declaration_specifiers_return);

        CParser.declarator_return declarator113 = default(CParser.declarator_return);

        CParser.abstract_declarator_return abstract_declarator114 = default(CParser.abstract_declarator_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 28) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:248:2: ( declaration_specifiers ( declarator | abstract_declarator )* )
            // C.g:248:4: declaration_specifiers ( declarator | abstract_declarator )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_declaration_specifiers_in_parameter_declaration875);
            	declaration_specifiers112 = declaration_specifiers();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration_specifiers112.Tree, declaration_specifiers112, retval);
            	// C.g:248:27: ( declarator | abstract_declarator )*
            	do 
            	{
            	    int alt33 = 3;
            	    alt33 = dfa33.Predict(input);
            	    switch (alt33) 
            		{
            			case 1 :
            			    // C.g:248:28: declarator
            			    {
            			    	PushFollow(FOLLOW_declarator_in_parameter_declaration878);
            			    	declarator113 = declarator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declarator113.Tree, declarator113, retval);

            			    }
            			    break;
            			case 2 :
            			    // C.g:248:39: abstract_declarator
            			    {
            			    	PushFollow(FOLLOW_abstract_declarator_in_parameter_declaration880);
            			    	abstract_declarator114 = abstract_declarator();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator114.Tree, abstract_declarator114, retval);

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
            	Memoize(input, 28, parameter_declaration_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "parameter_declaration"

    public class identifier_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "identifier_list"
    // C.g:251:1: identifier_list : IDENTIFIER ( ',' IDENTIFIER )* ;
    public CParser.identifier_list_return identifier_list() // throws RecognitionException [1]
    {   
        CParser.identifier_list_return retval = new CParser.identifier_list_return();
        retval.Start = input.LT(1);
        int identifier_list_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENTIFIER115 = null;
        IToken char_literal116 = null;
        IToken IDENTIFIER117 = null;

        object IDENTIFIER115_tree=null;
        object char_literal116_tree=null;
        object IDENTIFIER117_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 29) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:252:2: ( IDENTIFIER ( ',' IDENTIFIER )* )
            // C.g:252:4: IDENTIFIER ( ',' IDENTIFIER )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	IDENTIFIER115=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_identifier_list893), "IDENTIFIER"); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{IDENTIFIER115_tree = (object)adaptor.Create(IDENTIFIER115, retval);
            		adaptor.AddChild(root_0, IDENTIFIER115_tree);
            	}
            	// C.g:252:15: ( ',' IDENTIFIER )*
            	do 
            	{
            	    int alt34 = 2;
            	    int LA34_0 = input.LA(1);

            	    if ( (LA34_0 == 25) )
            	    {
            	        alt34 = 1;
            	    }


            	    switch (alt34) 
            		{
            			case 1 :
            			    // C.g:252:16: ',' IDENTIFIER
            			    {
            			    	char_literal116=(IToken)Match(input,25,FOLLOW_25_in_identifier_list896); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal116_tree = (object)adaptor.Create(char_literal116, retval);
            			    		adaptor.AddChild(root_0, char_literal116_tree);
            			    	}
            			    	IDENTIFIER117=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_identifier_list898), "IDENTIFIER"); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{IDENTIFIER117_tree = (object)adaptor.Create(IDENTIFIER117, retval);
            			    		adaptor.AddChild(root_0, IDENTIFIER117_tree);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop34;
            	    }
            	} while (true);

            	loop34:
            		;	// Stops C# compiler whining that label 'loop34' has no statements


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
            	Memoize(input, 29, identifier_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "identifier_list"

    public class type_name_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "type_name"
    // C.g:255:1: type_name : specifier_qualifier_list ( abstract_declarator )? ;
    public CParser.type_name_return type_name() // throws RecognitionException [1]
    {   
        CParser.type_name_return retval = new CParser.type_name_return();
        retval.Start = input.LT(1);
        int type_name_StartIndex = input.Index();
        object root_0 = null;

        CParser.specifier_qualifier_list_return specifier_qualifier_list118 = default(CParser.specifier_qualifier_list_return);

        CParser.abstract_declarator_return abstract_declarator119 = default(CParser.abstract_declarator_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 30) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:256:2: ( specifier_qualifier_list ( abstract_declarator )? )
            // C.g:256:4: specifier_qualifier_list ( abstract_declarator )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_specifier_qualifier_list_in_type_name911);
            	specifier_qualifier_list118 = specifier_qualifier_list();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, specifier_qualifier_list118.Tree, specifier_qualifier_list118, retval);
            	// C.g:256:29: ( abstract_declarator )?
            	int alt35 = 2;
            	int LA35_0 = input.LA(1);

            	if ( (LA35_0 == 48 || LA35_0 == 50 || LA35_0 == 52) )
            	{
            	    alt35 = 1;
            	}
            	switch (alt35) 
            	{
            	    case 1 :
            	        // C.g:0:0: abstract_declarator
            	        {
            	        	PushFollow(FOLLOW_abstract_declarator_in_type_name913);
            	        	abstract_declarator119 = abstract_declarator();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator119.Tree, abstract_declarator119, retval);

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
            	Memoize(input, 30, type_name_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "type_name"

    public class abstract_declarator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "abstract_declarator"
    // C.g:259:1: abstract_declarator : ( pointer ( direct_abstract_declarator )? | direct_abstract_declarator );
    public CParser.abstract_declarator_return abstract_declarator() // throws RecognitionException [1]
    {   
        CParser.abstract_declarator_return retval = new CParser.abstract_declarator_return();
        retval.Start = input.LT(1);
        int abstract_declarator_StartIndex = input.Index();
        object root_0 = null;

        CParser.pointer_return pointer120 = default(CParser.pointer_return);

        CParser.direct_abstract_declarator_return direct_abstract_declarator121 = default(CParser.direct_abstract_declarator_return);

        CParser.direct_abstract_declarator_return direct_abstract_declarator122 = default(CParser.direct_abstract_declarator_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 31) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:260:2: ( pointer ( direct_abstract_declarator )? | direct_abstract_declarator )
            int alt37 = 2;
            int LA37_0 = input.LA(1);

            if ( (LA37_0 == 52) )
            {
                alt37 = 1;
            }
            else if ( (LA37_0 == 48 || LA37_0 == 50) )
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
                    // C.g:260:4: pointer ( direct_abstract_declarator )?
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_pointer_in_abstract_declarator925);
                    	pointer120 = pointer();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, pointer120.Tree, pointer120, retval);
                    	// C.g:260:12: ( direct_abstract_declarator )?
                    	int alt36 = 2;
                    	alt36 = dfa36.Predict(input);
                    	switch (alt36) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: direct_abstract_declarator
                    	        {
                    	        	PushFollow(FOLLOW_direct_abstract_declarator_in_abstract_declarator927);
                    	        	direct_abstract_declarator121 = direct_abstract_declarator();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, direct_abstract_declarator121.Tree, direct_abstract_declarator121, retval);

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // C.g:261:4: direct_abstract_declarator
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_direct_abstract_declarator_in_abstract_declarator933);
                    	direct_abstract_declarator122 = direct_abstract_declarator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, direct_abstract_declarator122.Tree, direct_abstract_declarator122, retval);

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
            	Memoize(input, 31, abstract_declarator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "abstract_declarator"

    public class direct_abstract_declarator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "direct_abstract_declarator"
    // C.g:264:1: direct_abstract_declarator : ( '(' abstract_declarator ')' | abstract_declarator_suffix ) ( abstract_declarator_suffix )* ;
    public CParser.direct_abstract_declarator_return direct_abstract_declarator() // throws RecognitionException [1]
    {   
        CParser.direct_abstract_declarator_return retval = new CParser.direct_abstract_declarator_return();
        retval.Start = input.LT(1);
        int direct_abstract_declarator_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal123 = null;
        IToken char_literal125 = null;
        CParser.abstract_declarator_return abstract_declarator124 = default(CParser.abstract_declarator_return);

        CParser.abstract_declarator_suffix_return abstract_declarator_suffix126 = default(CParser.abstract_declarator_suffix_return);

        CParser.abstract_declarator_suffix_return abstract_declarator_suffix127 = default(CParser.abstract_declarator_suffix_return);


        object char_literal123_tree=null;
        object char_literal125_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 32) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:265:2: ( ( '(' abstract_declarator ')' | abstract_declarator_suffix ) ( abstract_declarator_suffix )* )
            // C.g:265:4: ( '(' abstract_declarator ')' | abstract_declarator_suffix ) ( abstract_declarator_suffix )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:265:4: ( '(' abstract_declarator ')' | abstract_declarator_suffix )
            	int alt38 = 2;
            	alt38 = dfa38.Predict(input);
            	switch (alt38) 
            	{
            	    case 1 :
            	        // C.g:265:6: '(' abstract_declarator ')'
            	        {
            	        	char_literal123=(IToken)Match(input,48,FOLLOW_48_in_direct_abstract_declarator946); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal123_tree = (object)adaptor.Create(char_literal123, retval);
            	        		adaptor.AddChild(root_0, char_literal123_tree);
            	        	}
            	        	PushFollow(FOLLOW_abstract_declarator_in_direct_abstract_declarator948);
            	        	abstract_declarator124 = abstract_declarator();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator124.Tree, abstract_declarator124, retval);
            	        	char_literal125=(IToken)Match(input,49,FOLLOW_49_in_direct_abstract_declarator950); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal125_tree = (object)adaptor.Create(char_literal125, retval);
            	        		adaptor.AddChild(root_0, char_literal125_tree);
            	        	}

            	        }
            	        break;
            	    case 2 :
            	        // C.g:265:36: abstract_declarator_suffix
            	        {
            	        	PushFollow(FOLLOW_abstract_declarator_suffix_in_direct_abstract_declarator954);
            	        	abstract_declarator_suffix126 = abstract_declarator_suffix();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator_suffix126.Tree, abstract_declarator_suffix126, retval);

            	        }
            	        break;

            	}

            	// C.g:265:65: ( abstract_declarator_suffix )*
            	do 
            	{
            	    int alt39 = 2;
            	    alt39 = dfa39.Predict(input);
            	    switch (alt39) 
            		{
            			case 1 :
            			    // C.g:0:0: abstract_declarator_suffix
            			    {
            			    	PushFollow(FOLLOW_abstract_declarator_suffix_in_direct_abstract_declarator958);
            			    	abstract_declarator_suffix127 = abstract_declarator_suffix();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, abstract_declarator_suffix127.Tree, abstract_declarator_suffix127, retval);

            			    }
            			    break;

            			default:
            			    goto loop39;
            	    }
            	} while (true);

            	loop39:
            		;	// Stops C# compiler whining that label 'loop39' has no statements


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
            	Memoize(input, 32, direct_abstract_declarator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "direct_abstract_declarator"

    public class abstract_declarator_suffix_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "abstract_declarator_suffix"
    // C.g:268:1: abstract_declarator_suffix : ( '[' ']' | '[' constant_expression ']' | '(' ')' | '(' parameter_type_list ')' );
    public CParser.abstract_declarator_suffix_return abstract_declarator_suffix() // throws RecognitionException [1]
    {   
        CParser.abstract_declarator_suffix_return retval = new CParser.abstract_declarator_suffix_return();
        retval.Start = input.LT(1);
        int abstract_declarator_suffix_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal128 = null;
        IToken char_literal129 = null;
        IToken char_literal130 = null;
        IToken char_literal132 = null;
        IToken char_literal133 = null;
        IToken char_literal134 = null;
        IToken char_literal135 = null;
        IToken char_literal137 = null;
        CParser.constant_expression_return constant_expression131 = default(CParser.constant_expression_return);

        CParser.parameter_type_list_return parameter_type_list136 = default(CParser.parameter_type_list_return);


        object char_literal128_tree=null;
        object char_literal129_tree=null;
        object char_literal130_tree=null;
        object char_literal132_tree=null;
        object char_literal133_tree=null;
        object char_literal134_tree=null;
        object char_literal135_tree=null;
        object char_literal137_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 33) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:269:2: ( '[' ']' | '[' constant_expression ']' | '(' ')' | '(' parameter_type_list ')' )
            int alt40 = 4;
            alt40 = dfa40.Predict(input);
            switch (alt40) 
            {
                case 1 :
                    // C.g:269:4: '[' ']'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal128=(IToken)Match(input,50,FOLLOW_50_in_abstract_declarator_suffix970); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal128_tree = (object)adaptor.Create(char_literal128, retval);
                    		adaptor.AddChild(root_0, char_literal128_tree);
                    	}
                    	char_literal129=(IToken)Match(input,51,FOLLOW_51_in_abstract_declarator_suffix972); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal129_tree = (object)adaptor.Create(char_literal129, retval);
                    		adaptor.AddChild(root_0, char_literal129_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:270:4: '[' constant_expression ']'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal130=(IToken)Match(input,50,FOLLOW_50_in_abstract_declarator_suffix977); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal130_tree = (object)adaptor.Create(char_literal130, retval);
                    		adaptor.AddChild(root_0, char_literal130_tree);
                    	}
                    	PushFollow(FOLLOW_constant_expression_in_abstract_declarator_suffix979);
                    	constant_expression131 = constant_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression131.Tree, constant_expression131, retval);
                    	char_literal132=(IToken)Match(input,51,FOLLOW_51_in_abstract_declarator_suffix981); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal132_tree = (object)adaptor.Create(char_literal132, retval);
                    		adaptor.AddChild(root_0, char_literal132_tree);
                    	}

                    }
                    break;
                case 3 :
                    // C.g:271:4: '(' ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal133=(IToken)Match(input,48,FOLLOW_48_in_abstract_declarator_suffix986); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal133_tree = (object)adaptor.Create(char_literal133, retval);
                    		adaptor.AddChild(root_0, char_literal133_tree);
                    	}
                    	char_literal134=(IToken)Match(input,49,FOLLOW_49_in_abstract_declarator_suffix988); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal134_tree = (object)adaptor.Create(char_literal134, retval);
                    		adaptor.AddChild(root_0, char_literal134_tree);
                    	}

                    }
                    break;
                case 4 :
                    // C.g:272:4: '(' parameter_type_list ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal135=(IToken)Match(input,48,FOLLOW_48_in_abstract_declarator_suffix993); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal135_tree = (object)adaptor.Create(char_literal135, retval);
                    		adaptor.AddChild(root_0, char_literal135_tree);
                    	}
                    	PushFollow(FOLLOW_parameter_type_list_in_abstract_declarator_suffix995);
                    	parameter_type_list136 = parameter_type_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, parameter_type_list136.Tree, parameter_type_list136, retval);
                    	char_literal137=(IToken)Match(input,49,FOLLOW_49_in_abstract_declarator_suffix997); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal137_tree = (object)adaptor.Create(char_literal137, retval);
                    		adaptor.AddChild(root_0, char_literal137_tree);
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
            	Memoize(input, 33, abstract_declarator_suffix_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "abstract_declarator_suffix"

    public class initializer_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "initializer"
    // C.g:275:1: initializer : ( assignment_expression | '{' initializer_list ( ',' )? '}' );
    public CParser.initializer_return initializer() // throws RecognitionException [1]
    {   
        CParser.initializer_return retval = new CParser.initializer_return();
        retval.Start = input.LT(1);
        int initializer_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal139 = null;
        IToken char_literal141 = null;
        IToken char_literal142 = null;
        CParser.assignment_expression_return assignment_expression138 = default(CParser.assignment_expression_return);

        CParser.initializer_list_return initializer_list140 = default(CParser.initializer_list_return);


        object char_literal139_tree=null;
        object char_literal141_tree=null;
        object char_literal142_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 34) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:276:2: ( assignment_expression | '{' initializer_list ( ',' )? '}' )
            int alt42 = 2;
            int LA42_0 = input.LA(1);

            if ( ((LA42_0 >= IDENTIFIER && LA42_0 <= FLOATING_POINT_LITERAL) || LA42_0 == 48 || LA42_0 == 52 || (LA42_0 >= 54 && LA42_0 <= 55) || (LA42_0 >= 58 && LA42_0 <= 60) || (LA42_0 >= 63 && LA42_0 <= 65)) )
            {
                alt42 = 1;
            }
            else if ( (LA42_0 == 40) )
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
                    // C.g:276:4: assignment_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_assignment_expression_in_initializer1009);
                    	assignment_expression138 = assignment_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression138.Tree, assignment_expression138, retval);

                    }
                    break;
                case 2 :
                    // C.g:277:4: '{' initializer_list ( ',' )? '}'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal139=(IToken)Match(input,40,FOLLOW_40_in_initializer1014); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal139_tree = (object)adaptor.Create(char_literal139, retval);
                    		adaptor.AddChild(root_0, char_literal139_tree);
                    	}
                    	PushFollow(FOLLOW_initializer_list_in_initializer1016);
                    	initializer_list140 = initializer_list();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer_list140.Tree, initializer_list140, retval);
                    	// C.g:277:25: ( ',' )?
                    	int alt41 = 2;
                    	int LA41_0 = input.LA(1);

                    	if ( (LA41_0 == 25) )
                    	{
                    	    alt41 = 1;
                    	}
                    	switch (alt41) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: ','
                    	        {
                    	        	char_literal141=(IToken)Match(input,25,FOLLOW_25_in_initializer1018); if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 )
                    	        	{char_literal141_tree = (object)adaptor.Create(char_literal141, retval);
                    	        		adaptor.AddChild(root_0, char_literal141_tree);
                    	        	}

                    	        }
                    	        break;

                    	}

                    	char_literal142=(IToken)Match(input,41,FOLLOW_41_in_initializer1021); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal142_tree = (object)adaptor.Create(char_literal142, retval);
                    		adaptor.AddChild(root_0, char_literal142_tree);
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
            	Memoize(input, 34, initializer_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "initializer"

    public class initializer_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "initializer_list"
    // C.g:280:1: initializer_list : initializer ( ',' initializer )* ;
    public CParser.initializer_list_return initializer_list() // throws RecognitionException [1]
    {   
        CParser.initializer_list_return retval = new CParser.initializer_list_return();
        retval.Start = input.LT(1);
        int initializer_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal144 = null;
        CParser.initializer_return initializer143 = default(CParser.initializer_return);

        CParser.initializer_return initializer145 = default(CParser.initializer_return);


        object char_literal144_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 35) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:281:2: ( initializer ( ',' initializer )* )
            // C.g:281:4: initializer ( ',' initializer )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_initializer_in_initializer_list1032);
            	initializer143 = initializer();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer143.Tree, initializer143, retval);
            	// C.g:281:16: ( ',' initializer )*
            	do 
            	{
            	    int alt43 = 2;
            	    alt43 = dfa43.Predict(input);
            	    switch (alt43) 
            		{
            			case 1 :
            			    // C.g:281:17: ',' initializer
            			    {
            			    	char_literal144=(IToken)Match(input,25,FOLLOW_25_in_initializer_list1035); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal144_tree = (object)adaptor.Create(char_literal144, retval);
            			    		adaptor.AddChild(root_0, char_literal144_tree);
            			    	}
            			    	PushFollow(FOLLOW_initializer_in_initializer_list1037);
            			    	initializer145 = initializer();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, initializer145.Tree, initializer145, retval);

            			    }
            			    break;

            			default:
            			    goto loop43;
            	    }
            	} while (true);

            	loop43:
            		;	// Stops C# compiler whining that label 'loop43' has no statements


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
            	Memoize(input, 35, initializer_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "initializer_list"

    public class argument_expression_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "argument_expression_list"
    // C.g:286:1: argument_expression_list : assignment_expression ( ',' assignment_expression )* ;
    public CParser.argument_expression_list_return argument_expression_list() // throws RecognitionException [1]
    {   
        CParser.argument_expression_list_return retval = new CParser.argument_expression_list_return();
        retval.Start = input.LT(1);
        int argument_expression_list_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal147 = null;
        CParser.assignment_expression_return assignment_expression146 = default(CParser.assignment_expression_return);

        CParser.assignment_expression_return assignment_expression148 = default(CParser.assignment_expression_return);


        object char_literal147_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 36) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:287:2: ( assignment_expression ( ',' assignment_expression )* )
            // C.g:287:6: assignment_expression ( ',' assignment_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_assignment_expression_in_argument_expression_list1054);
            	assignment_expression146 = assignment_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression146.Tree, assignment_expression146, retval);
            	// C.g:287:28: ( ',' assignment_expression )*
            	do 
            	{
            	    int alt44 = 2;
            	    int LA44_0 = input.LA(1);

            	    if ( (LA44_0 == 25) )
            	    {
            	        alt44 = 1;
            	    }


            	    switch (alt44) 
            		{
            			case 1 :
            			    // C.g:287:29: ',' assignment_expression
            			    {
            			    	char_literal147=(IToken)Match(input,25,FOLLOW_25_in_argument_expression_list1057); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal147_tree = (object)adaptor.Create(char_literal147, retval);
            			    		adaptor.AddChild(root_0, char_literal147_tree);
            			    	}
            			    	PushFollow(FOLLOW_assignment_expression_in_argument_expression_list1059);
            			    	assignment_expression148 = assignment_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression148.Tree, assignment_expression148, retval);

            			    }
            			    break;

            			default:
            			    goto loop44;
            	    }
            	} while (true);

            	loop44:
            		;	// Stops C# compiler whining that label 'loop44' has no statements


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
            	Memoize(input, 36, argument_expression_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "argument_expression_list"

    public class additive_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "additive_expression"
    // C.g:290:1: additive_expression : ( multiplicative_expression ) ( '+' multiplicative_expression | '-' multiplicative_expression )* ;
    public CParser.additive_expression_return additive_expression() // throws RecognitionException [1]
    {   
        CParser.additive_expression_return retval = new CParser.additive_expression_return();
        retval.Start = input.LT(1);
        int additive_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal150 = null;
        IToken char_literal152 = null;
        CParser.multiplicative_expression_return multiplicative_expression149 = default(CParser.multiplicative_expression_return);

        CParser.multiplicative_expression_return multiplicative_expression151 = default(CParser.multiplicative_expression_return);

        CParser.multiplicative_expression_return multiplicative_expression153 = default(CParser.multiplicative_expression_return);


        object char_literal150_tree=null;
        object char_literal152_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 37) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:291:2: ( ( multiplicative_expression ) ( '+' multiplicative_expression | '-' multiplicative_expression )* )
            // C.g:291:4: ( multiplicative_expression ) ( '+' multiplicative_expression | '-' multiplicative_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:291:4: ( multiplicative_expression )
            	// C.g:291:5: multiplicative_expression
            	{
            		PushFollow(FOLLOW_multiplicative_expression_in_additive_expression1073);
            		multiplicative_expression149 = multiplicative_expression();
            		state.followingStackPointer--;
            		if (state.failed) return retval;
            		if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicative_expression149.Tree, multiplicative_expression149, retval);

            	}

            	// C.g:291:32: ( '+' multiplicative_expression | '-' multiplicative_expression )*
            	do 
            	{
            	    int alt45 = 3;
            	    alt45 = dfa45.Predict(input);
            	    switch (alt45) 
            		{
            			case 1 :
            			    // C.g:291:33: '+' multiplicative_expression
            			    {
            			    	char_literal150=(IToken)Match(input,54,FOLLOW_54_in_additive_expression1077); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal150_tree = (object)adaptor.Create(char_literal150, retval);
            			    		adaptor.AddChild(root_0, char_literal150_tree);
            			    	}
            			    	PushFollow(FOLLOW_multiplicative_expression_in_additive_expression1079);
            			    	multiplicative_expression151 = multiplicative_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicative_expression151.Tree, multiplicative_expression151, retval);

            			    }
            			    break;
            			case 2 :
            			    // C.g:291:65: '-' multiplicative_expression
            			    {
            			    	char_literal152=(IToken)Match(input,55,FOLLOW_55_in_additive_expression1083); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal152_tree = (object)adaptor.Create(char_literal152, retval);
            			    		adaptor.AddChild(root_0, char_literal152_tree);
            			    	}
            			    	PushFollow(FOLLOW_multiplicative_expression_in_additive_expression1085);
            			    	multiplicative_expression153 = multiplicative_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, multiplicative_expression153.Tree, multiplicative_expression153, retval);

            			    }
            			    break;

            			default:
            			    goto loop45;
            	    }
            	} while (true);

            	loop45:
            		;	// Stops C# compiler whining that label 'loop45' has no statements


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
            	Memoize(input, 37, additive_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "additive_expression"

    public class multiplicative_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "multiplicative_expression"
    // C.g:294:1: multiplicative_expression : ( cast_expression ) ( '*' cast_expression | '/' cast_expression | '%' cast_expression )* ;
    public CParser.multiplicative_expression_return multiplicative_expression() // throws RecognitionException [1]
    {   
        CParser.multiplicative_expression_return retval = new CParser.multiplicative_expression_return();
        retval.Start = input.LT(1);
        int multiplicative_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal155 = null;
        IToken char_literal157 = null;
        IToken char_literal159 = null;
        CParser.cast_expression_return cast_expression154 = default(CParser.cast_expression_return);

        CParser.cast_expression_return cast_expression156 = default(CParser.cast_expression_return);

        CParser.cast_expression_return cast_expression158 = default(CParser.cast_expression_return);

        CParser.cast_expression_return cast_expression160 = default(CParser.cast_expression_return);


        object char_literal155_tree=null;
        object char_literal157_tree=null;
        object char_literal159_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 38) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:295:2: ( ( cast_expression ) ( '*' cast_expression | '/' cast_expression | '%' cast_expression )* )
            // C.g:295:4: ( cast_expression ) ( '*' cast_expression | '/' cast_expression | '%' cast_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:295:4: ( cast_expression )
            	// C.g:295:5: cast_expression
            	{
            		PushFollow(FOLLOW_cast_expression_in_multiplicative_expression1099);
            		cast_expression154 = cast_expression();
            		state.followingStackPointer--;
            		if (state.failed) return retval;
            		if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression154.Tree, cast_expression154, retval);

            	}

            	// C.g:295:22: ( '*' cast_expression | '/' cast_expression | '%' cast_expression )*
            	do 
            	{
            	    int alt46 = 4;
            	    alt46 = dfa46.Predict(input);
            	    switch (alt46) 
            		{
            			case 1 :
            			    // C.g:295:23: '*' cast_expression
            			    {
            			    	char_literal155=(IToken)Match(input,52,FOLLOW_52_in_multiplicative_expression1103); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal155_tree = (object)adaptor.Create(char_literal155, retval);
            			    		adaptor.AddChild(root_0, char_literal155_tree);
            			    	}
            			    	PushFollow(FOLLOW_cast_expression_in_multiplicative_expression1105);
            			    	cast_expression156 = cast_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression156.Tree, cast_expression156, retval);

            			    }
            			    break;
            			case 2 :
            			    // C.g:295:45: '/' cast_expression
            			    {
            			    	char_literal157=(IToken)Match(input,56,FOLLOW_56_in_multiplicative_expression1109); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal157_tree = (object)adaptor.Create(char_literal157, retval);
            			    		adaptor.AddChild(root_0, char_literal157_tree);
            			    	}
            			    	PushFollow(FOLLOW_cast_expression_in_multiplicative_expression1111);
            			    	cast_expression158 = cast_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression158.Tree, cast_expression158, retval);

            			    }
            			    break;
            			case 3 :
            			    // C.g:295:67: '%' cast_expression
            			    {
            			    	char_literal159=(IToken)Match(input,57,FOLLOW_57_in_multiplicative_expression1115); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal159_tree = (object)adaptor.Create(char_literal159, retval);
            			    		adaptor.AddChild(root_0, char_literal159_tree);
            			    	}
            			    	PushFollow(FOLLOW_cast_expression_in_multiplicative_expression1117);
            			    	cast_expression160 = cast_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression160.Tree, cast_expression160, retval);

            			    }
            			    break;

            			default:
            			    goto loop46;
            	    }
            	} while (true);

            	loop46:
            		;	// Stops C# compiler whining that label 'loop46' has no statements


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
            	Memoize(input, 38, multiplicative_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "multiplicative_expression"

    public class cast_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "cast_expression"
    // C.g:298:1: cast_expression : ( '(' type_name ')' cast_expression | unary_expression );
    public CParser.cast_expression_return cast_expression() // throws RecognitionException [1]
    {   
        CParser.cast_expression_return retval = new CParser.cast_expression_return();
        retval.Start = input.LT(1);
        int cast_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal161 = null;
        IToken char_literal163 = null;
        CParser.type_name_return type_name162 = default(CParser.type_name_return);

        CParser.cast_expression_return cast_expression164 = default(CParser.cast_expression_return);

        CParser.unary_expression_return unary_expression165 = default(CParser.unary_expression_return);


        object char_literal161_tree=null;
        object char_literal163_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 39) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:299:2: ( '(' type_name ')' cast_expression | unary_expression )
            int alt47 = 2;
            alt47 = dfa47.Predict(input);
            switch (alt47) 
            {
                case 1 :
                    // C.g:299:4: '(' type_name ')' cast_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal161=(IToken)Match(input,48,FOLLOW_48_in_cast_expression1130); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal161_tree = (object)adaptor.Create(char_literal161, retval);
                    		adaptor.AddChild(root_0, char_literal161_tree);
                    	}
                    	PushFollow(FOLLOW_type_name_in_cast_expression1132);
                    	type_name162 = type_name();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_name162.Tree, type_name162, retval);
                    	char_literal163=(IToken)Match(input,49,FOLLOW_49_in_cast_expression1134); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal163_tree = (object)adaptor.Create(char_literal163, retval);
                    		adaptor.AddChild(root_0, char_literal163_tree);
                    	}
                    	PushFollow(FOLLOW_cast_expression_in_cast_expression1136);
                    	cast_expression164 = cast_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression164.Tree, cast_expression164, retval);

                    }
                    break;
                case 2 :
                    // C.g:300:4: unary_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_unary_expression_in_cast_expression1141);
                    	unary_expression165 = unary_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression165.Tree, unary_expression165, retval);

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
            	Memoize(input, 39, cast_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "cast_expression"

    public class unary_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "unary_expression"
    // C.g:303:1: unary_expression : ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' unary_expression | 'sizeof' '(' type_name ')' );
    public CParser.unary_expression_return unary_expression() // throws RecognitionException [1]
    {   
        CParser.unary_expression_return retval = new CParser.unary_expression_return();
        retval.Start = input.LT(1);
        int unary_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal167 = null;
        IToken string_literal169 = null;
        IToken string_literal173 = null;
        IToken string_literal175 = null;
        IToken char_literal176 = null;
        IToken char_literal178 = null;
        CParser.postfix_expression_return postfix_expression166 = default(CParser.postfix_expression_return);

        CParser.unary_expression_return unary_expression168 = default(CParser.unary_expression_return);

        CParser.unary_expression_return unary_expression170 = default(CParser.unary_expression_return);

        CParser.unary_operator_return unary_operator171 = default(CParser.unary_operator_return);

        CParser.cast_expression_return cast_expression172 = default(CParser.cast_expression_return);

        CParser.unary_expression_return unary_expression174 = default(CParser.unary_expression_return);

        CParser.type_name_return type_name177 = default(CParser.type_name_return);


        object string_literal167_tree=null;
        object string_literal169_tree=null;
        object string_literal173_tree=null;
        object string_literal175_tree=null;
        object char_literal176_tree=null;
        object char_literal178_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 40) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:304:2: ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' unary_expression | 'sizeof' '(' type_name ')' )
            int alt48 = 6;
            alt48 = dfa48.Predict(input);
            switch (alt48) 
            {
                case 1 :
                    // C.g:304:4: postfix_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_postfix_expression_in_unary_expression1152);
                    	postfix_expression166 = postfix_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, postfix_expression166.Tree, postfix_expression166, retval);

                    }
                    break;
                case 2 :
                    // C.g:305:4: '++' unary_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal167=(IToken)Match(input,58,FOLLOW_58_in_unary_expression1157); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal167_tree = (object)adaptor.Create(string_literal167, retval);
                    		adaptor.AddChild(root_0, string_literal167_tree);
                    	}
                    	PushFollow(FOLLOW_unary_expression_in_unary_expression1159);
                    	unary_expression168 = unary_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression168.Tree, unary_expression168, retval);

                    }
                    break;
                case 3 :
                    // C.g:306:4: '--' unary_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal169=(IToken)Match(input,59,FOLLOW_59_in_unary_expression1164); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal169_tree = (object)adaptor.Create(string_literal169, retval);
                    		adaptor.AddChild(root_0, string_literal169_tree);
                    	}
                    	PushFollow(FOLLOW_unary_expression_in_unary_expression1166);
                    	unary_expression170 = unary_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression170.Tree, unary_expression170, retval);

                    }
                    break;
                case 4 :
                    // C.g:307:4: unary_operator cast_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_unary_operator_in_unary_expression1171);
                    	unary_operator171 = unary_operator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_operator171.Tree, unary_operator171, retval);
                    	PushFollow(FOLLOW_cast_expression_in_unary_expression1173);
                    	cast_expression172 = cast_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, cast_expression172.Tree, cast_expression172, retval);

                    }
                    break;
                case 5 :
                    // C.g:308:4: 'sizeof' unary_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal173=(IToken)Match(input,60,FOLLOW_60_in_unary_expression1178); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal173_tree = (object)adaptor.Create(string_literal173, retval);
                    		adaptor.AddChild(root_0, string_literal173_tree);
                    	}
                    	PushFollow(FOLLOW_unary_expression_in_unary_expression1180);
                    	unary_expression174 = unary_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression174.Tree, unary_expression174, retval);

                    }
                    break;
                case 6 :
                    // C.g:309:4: 'sizeof' '(' type_name ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal175=(IToken)Match(input,60,FOLLOW_60_in_unary_expression1185); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal175_tree = (object)adaptor.Create(string_literal175, retval);
                    		adaptor.AddChild(root_0, string_literal175_tree);
                    	}
                    	char_literal176=(IToken)Match(input,48,FOLLOW_48_in_unary_expression1187); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal176_tree = (object)adaptor.Create(char_literal176, retval);
                    		adaptor.AddChild(root_0, char_literal176_tree);
                    	}
                    	PushFollow(FOLLOW_type_name_in_unary_expression1189);
                    	type_name177 = type_name();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, type_name177.Tree, type_name177, retval);
                    	char_literal178=(IToken)Match(input,49,FOLLOW_49_in_unary_expression1191); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal178_tree = (object)adaptor.Create(char_literal178, retval);
                    		adaptor.AddChild(root_0, char_literal178_tree);
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
            	Memoize(input, 40, unary_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "unary_expression"

    public class postfix_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "postfix_expression"
    // C.g:312:1: postfix_expression : primary_expression ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )* ;
    public CParser.postfix_expression_return postfix_expression() // throws RecognitionException [1]
    {   
        CParser.postfix_expression_return retval = new CParser.postfix_expression_return();
        retval.Start = input.LT(1);
        int postfix_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal180 = null;
        IToken char_literal182 = null;
        IToken char_literal183 = null;
        IToken char_literal184 = null;
        IToken char_literal185 = null;
        IToken char_literal187 = null;
        IToken char_literal188 = null;
        IToken IDENTIFIER189 = null;
        IToken string_literal190 = null;
        IToken IDENTIFIER191 = null;
        IToken string_literal192 = null;
        IToken string_literal193 = null;
        CParser.primary_expression_return primary_expression179 = default(CParser.primary_expression_return);

        CParser.expression_return expression181 = default(CParser.expression_return);

        CParser.argument_expression_list_return argument_expression_list186 = default(CParser.argument_expression_list_return);


        object char_literal180_tree=null;
        object char_literal182_tree=null;
        object char_literal183_tree=null;
        object char_literal184_tree=null;
        object char_literal185_tree=null;
        object char_literal187_tree=null;
        object char_literal188_tree=null;
        object IDENTIFIER189_tree=null;
        object string_literal190_tree=null;
        object IDENTIFIER191_tree=null;
        object string_literal192_tree=null;
        object string_literal193_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 41) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:313:2: ( primary_expression ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )* )
            // C.g:313:6: primary_expression ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_primary_expression_in_postfix_expression1204);
            	primary_expression179 = primary_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, primary_expression179.Tree, primary_expression179, retval);
            	// C.g:314:9: ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )*
            	do 
            	{
            	    int alt49 = 8;
            	    alt49 = dfa49.Predict(input);
            	    switch (alt49) 
            		{
            			case 1 :
            			    // C.g:314:13: '[' expression ']'
            			    {
            			    	char_literal180=(IToken)Match(input,50,FOLLOW_50_in_postfix_expression1218); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal180_tree = (object)adaptor.Create(char_literal180, retval);
            			    		adaptor.AddChild(root_0, char_literal180_tree);
            			    	}
            			    	PushFollow(FOLLOW_expression_in_postfix_expression1220);
            			    	expression181 = expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression181.Tree, expression181, retval);
            			    	char_literal182=(IToken)Match(input,51,FOLLOW_51_in_postfix_expression1222); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal182_tree = (object)adaptor.Create(char_literal182, retval);
            			    		adaptor.AddChild(root_0, char_literal182_tree);
            			    	}

            			    }
            			    break;
            			case 2 :
            			    // C.g:315:13: '(' ')'
            			    {
            			    	char_literal183=(IToken)Match(input,48,FOLLOW_48_in_postfix_expression1236); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal183_tree = (object)adaptor.Create(char_literal183, retval);
            			    		adaptor.AddChild(root_0, char_literal183_tree);
            			    	}
            			    	char_literal184=(IToken)Match(input,49,FOLLOW_49_in_postfix_expression1238); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal184_tree = (object)adaptor.Create(char_literal184, retval);
            			    		adaptor.AddChild(root_0, char_literal184_tree);
            			    	}

            			    }
            			    break;
            			case 3 :
            			    // C.g:316:13: '(' argument_expression_list ')'
            			    {
            			    	char_literal185=(IToken)Match(input,48,FOLLOW_48_in_postfix_expression1252); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal185_tree = (object)adaptor.Create(char_literal185, retval);
            			    		adaptor.AddChild(root_0, char_literal185_tree);
            			    	}
            			    	PushFollow(FOLLOW_argument_expression_list_in_postfix_expression1254);
            			    	argument_expression_list186 = argument_expression_list();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, argument_expression_list186.Tree, argument_expression_list186, retval);
            			    	char_literal187=(IToken)Match(input,49,FOLLOW_49_in_postfix_expression1256); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal187_tree = (object)adaptor.Create(char_literal187, retval);
            			    		adaptor.AddChild(root_0, char_literal187_tree);
            			    	}

            			    }
            			    break;
            			case 4 :
            			    // C.g:317:13: '.' IDENTIFIER
            			    {
            			    	char_literal188=(IToken)Match(input,61,FOLLOW_61_in_postfix_expression1270); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal188_tree = (object)adaptor.Create(char_literal188, retval);
            			    		adaptor.AddChild(root_0, char_literal188_tree);
            			    	}
            			    	IDENTIFIER189=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_postfix_expression1272), "IDENTIFIER"); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{IDENTIFIER189_tree = (object)adaptor.Create(IDENTIFIER189, retval);
            			    		adaptor.AddChild(root_0, IDENTIFIER189_tree);
            			    	}

            			    }
            			    break;
            			case 5 :
            			    // C.g:318:13: '->' IDENTIFIER
            			    {
            			    	string_literal190=(IToken)Match(input,62,FOLLOW_62_in_postfix_expression1286); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal190_tree = (object)adaptor.Create(string_literal190, retval);
            			    		adaptor.AddChild(root_0, string_literal190_tree);
            			    	}
            			    	IDENTIFIER191=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_postfix_expression1288), "IDENTIFIER"); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{IDENTIFIER191_tree = (object)adaptor.Create(IDENTIFIER191, retval);
            			    		adaptor.AddChild(root_0, IDENTIFIER191_tree);
            			    	}

            			    }
            			    break;
            			case 6 :
            			    // C.g:319:13: '++'
            			    {
            			    	string_literal192=(IToken)Match(input,58,FOLLOW_58_in_postfix_expression1302); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal192_tree = (object)adaptor.Create(string_literal192, retval);
            			    		adaptor.AddChild(root_0, string_literal192_tree);
            			    	}

            			    }
            			    break;
            			case 7 :
            			    // C.g:320:13: '--'
            			    {
            			    	string_literal193=(IToken)Match(input,59,FOLLOW_59_in_postfix_expression1316); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal193_tree = (object)adaptor.Create(string_literal193, retval);
            			    		adaptor.AddChild(root_0, string_literal193_tree);
            			    	}

            			    }
            			    break;

            			default:
            			    goto loop49;
            	    }
            	} while (true);

            	loop49:
            		;	// Stops C# compiler whining that label 'loop49' has no statements


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
            	Memoize(input, 41, postfix_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "postfix_expression"

    public class unary_operator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "unary_operator"
    // C.g:324:1: unary_operator : ( '&' | '*' | '+' | '-' | '~' | '!' );
    public CParser.unary_operator_return unary_operator() // throws RecognitionException [1]
    {   
        CParser.unary_operator_return retval = new CParser.unary_operator_return();
        retval.Start = input.LT(1);
        int unary_operator_StartIndex = input.Index();
        object root_0 = null;

        IToken set194 = null;

        object set194_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 42) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:325:2: ( '&' | '*' | '+' | '-' | '~' | '!' )
            // C.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set194 = (IToken)input.LT(1);
            	if ( input.LA(1) == 52 || (input.LA(1) >= 54 && input.LA(1) <= 55) || (input.LA(1) >= 63 && input.LA(1) <= 65) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set194, retval));
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
            	Memoize(input, 42, unary_operator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "unary_operator"

    public class primary_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "primary_expression"
    // C.g:333:1: primary_expression : ( IDENTIFIER | constant | '(' expression ')' );
    public CParser.primary_expression_return primary_expression() // throws RecognitionException [1]
    {   
        CParser.primary_expression_return retval = new CParser.primary_expression_return();
        retval.Start = input.LT(1);
        int primary_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENTIFIER195 = null;
        IToken char_literal197 = null;
        IToken char_literal199 = null;
        CParser.constant_return constant196 = default(CParser.constant_return);

        CParser.expression_return expression198 = default(CParser.expression_return);


        object IDENTIFIER195_tree=null;
        object char_literal197_tree=null;
        object char_literal199_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 43) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:334:2: ( IDENTIFIER | constant | '(' expression ')' )
            int alt50 = 3;
            switch ( input.LA(1) ) 
            {
            case IDENTIFIER:
            	{
                alt50 = 1;
                }
                break;
            case HEX_LITERAL:
            case OCTAL_LITERAL:
            case DECIMAL_LITERAL:
            case CHARACTER_LITERAL:
            case STRING_LITERAL:
            case FLOATING_POINT_LITERAL:
            	{
                alt50 = 2;
                }
                break;
            case 48:
            	{
                alt50 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d50s0 =
            	        new NoViableAltException("", 50, 0, input);

            	    throw nvae_d50s0;
            }

            switch (alt50) 
            {
                case 1 :
                    // C.g:334:4: IDENTIFIER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	IDENTIFIER195=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_primary_expression1374), "IDENTIFIER"); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENTIFIER195_tree = (object)adaptor.Create(IDENTIFIER195, retval);
                    		adaptor.AddChild(root_0, IDENTIFIER195_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:335:4: constant
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_constant_in_primary_expression1379);
                    	constant196 = constant();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant196.Tree, constant196, retval);

                    }
                    break;
                case 3 :
                    // C.g:336:4: '(' expression ')'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal197=(IToken)Match(input,48,FOLLOW_48_in_primary_expression1384); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal197_tree = (object)adaptor.Create(char_literal197, retval);
                    		adaptor.AddChild(root_0, char_literal197_tree);
                    	}
                    	PushFollow(FOLLOW_expression_in_primary_expression1386);
                    	expression198 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression198.Tree, expression198, retval);
                    	char_literal199=(IToken)Match(input,49,FOLLOW_49_in_primary_expression1388); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal199_tree = (object)adaptor.Create(char_literal199, retval);
                    		adaptor.AddChild(root_0, char_literal199_tree);
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
            	Memoize(input, 43, primary_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "primary_expression"

    public class constant_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "constant"
    // C.g:339:1: constant : ( HEX_LITERAL | OCTAL_LITERAL | DECIMAL_LITERAL | CHARACTER_LITERAL | STRING_LITERAL | FLOATING_POINT_LITERAL );
    public CParser.constant_return constant() // throws RecognitionException [1]
    {   
        CParser.constant_return retval = new CParser.constant_return();
        retval.Start = input.LT(1);
        int constant_StartIndex = input.Index();
        object root_0 = null;

        IToken set200 = null;

        object set200_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 44) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:340:5: ( HEX_LITERAL | OCTAL_LITERAL | DECIMAL_LITERAL | CHARACTER_LITERAL | STRING_LITERAL | FLOATING_POINT_LITERAL )
            // C.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set200 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= HEX_LITERAL && input.LA(1) <= FLOATING_POINT_LITERAL) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set200, retval));
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
            	Memoize(input, 44, constant_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "constant"

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
    // C.g:350:1: expression : assignment_expression ( ',' assignment_expression )* ;
    public CParser.expression_return expression() // throws RecognitionException [1]
    {   
        CParser.expression_return retval = new CParser.expression_return();
        retval.Start = input.LT(1);
        int expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal202 = null;
        CParser.assignment_expression_return assignment_expression201 = default(CParser.assignment_expression_return);

        CParser.assignment_expression_return assignment_expression203 = default(CParser.assignment_expression_return);


        object char_literal202_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 45) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:351:2: ( assignment_expression ( ',' assignment_expression )* )
            // C.g:351:4: assignment_expression ( ',' assignment_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_assignment_expression_in_expression1463);
            	assignment_expression201 = assignment_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression201.Tree, assignment_expression201, retval);
            	// C.g:351:26: ( ',' assignment_expression )*
            	do 
            	{
            	    int alt51 = 2;
            	    int LA51_0 = input.LA(1);

            	    if ( (LA51_0 == 25) )
            	    {
            	        alt51 = 1;
            	    }


            	    switch (alt51) 
            		{
            			case 1 :
            			    // C.g:351:27: ',' assignment_expression
            			    {
            			    	char_literal202=(IToken)Match(input,25,FOLLOW_25_in_expression1466); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal202_tree = (object)adaptor.Create(char_literal202, retval);
            			    		adaptor.AddChild(root_0, char_literal202_tree);
            			    	}
            			    	PushFollow(FOLLOW_assignment_expression_in_expression1468);
            			    	assignment_expression203 = assignment_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression203.Tree, assignment_expression203, retval);

            			    }
            			    break;

            			default:
            			    goto loop51;
            	    }
            	} while (true);

            	loop51:
            		;	// Stops C# compiler whining that label 'loop51' has no statements


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
            	Memoize(input, 45, expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "expression"

    public class constant_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "constant_expression"
    // C.g:354:1: constant_expression : conditional_expression ;
    public CParser.constant_expression_return constant_expression() // throws RecognitionException [1]
    {   
        CParser.constant_expression_return retval = new CParser.constant_expression_return();
        retval.Start = input.LT(1);
        int constant_expression_StartIndex = input.Index();
        object root_0 = null;

        CParser.conditional_expression_return conditional_expression204 = default(CParser.conditional_expression_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 46) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:355:2: ( conditional_expression )
            // C.g:355:4: conditional_expression
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_conditional_expression_in_constant_expression1481);
            	conditional_expression204 = conditional_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditional_expression204.Tree, conditional_expression204, retval);

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
            	Memoize(input, 46, constant_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "constant_expression"

    public class assignment_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignment_expression"
    // C.g:358:1: assignment_expression : ( lvalue assignment_operator assignment_expression | conditional_expression );
    public CParser.assignment_expression_return assignment_expression() // throws RecognitionException [1]
    {   
        CParser.assignment_expression_return retval = new CParser.assignment_expression_return();
        retval.Start = input.LT(1);
        int assignment_expression_StartIndex = input.Index();
        object root_0 = null;

        CParser.lvalue_return lvalue205 = default(CParser.lvalue_return);

        CParser.assignment_operator_return assignment_operator206 = default(CParser.assignment_operator_return);

        CParser.assignment_expression_return assignment_expression207 = default(CParser.assignment_expression_return);

        CParser.conditional_expression_return conditional_expression208 = default(CParser.conditional_expression_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 47) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:359:2: ( lvalue assignment_operator assignment_expression | conditional_expression )
            int alt52 = 2;
            alt52 = dfa52.Predict(input);
            switch (alt52) 
            {
                case 1 :
                    // C.g:359:4: lvalue assignment_operator assignment_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_lvalue_in_assignment_expression1492);
                    	lvalue205 = lvalue();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, lvalue205.Tree, lvalue205, retval);
                    	PushFollow(FOLLOW_assignment_operator_in_assignment_expression1494);
                    	assignment_operator206 = assignment_operator();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_operator206.Tree, assignment_operator206, retval);
                    	PushFollow(FOLLOW_assignment_expression_in_assignment_expression1496);
                    	assignment_expression207 = assignment_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, assignment_expression207.Tree, assignment_expression207, retval);

                    }
                    break;
                case 2 :
                    // C.g:360:4: conditional_expression
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_conditional_expression_in_assignment_expression1501);
                    	conditional_expression208 = conditional_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditional_expression208.Tree, conditional_expression208, retval);

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
            	Memoize(input, 47, assignment_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "assignment_expression"

    public class lvalue_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "lvalue"
    // C.g:363:1: lvalue : unary_expression ;
    public CParser.lvalue_return lvalue() // throws RecognitionException [1]
    {   
        CParser.lvalue_return retval = new CParser.lvalue_return();
        retval.Start = input.LT(1);
        int lvalue_StartIndex = input.Index();
        object root_0 = null;

        CParser.unary_expression_return unary_expression209 = default(CParser.unary_expression_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 48) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:364:2: ( unary_expression )
            // C.g:364:4: unary_expression
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_unary_expression_in_lvalue1513);
            	unary_expression209 = unary_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, unary_expression209.Tree, unary_expression209, retval);

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
            	Memoize(input, 48, lvalue_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "lvalue"

    public class assignment_operator_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "assignment_operator"
    // C.g:367:1: assignment_operator : ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '&=' | '^=' | '|=' );
    public CParser.assignment_operator_return assignment_operator() // throws RecognitionException [1]
    {   
        CParser.assignment_operator_return retval = new CParser.assignment_operator_return();
        retval.Start = input.LT(1);
        int assignment_operator_StartIndex = input.Index();
        object root_0 = null;

        IToken set210 = null;

        object set210_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 49) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:368:2: ( '=' | '*=' | '/=' | '%=' | '+=' | '-=' | '<<=' | '>>=' | '&=' | '^=' | '|=' )
            // C.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set210 = (IToken)input.LT(1);
            	if ( input.LA(1) == 26 || (input.LA(1) >= 66 && input.LA(1) <= 75) ) 
            	{
            	    input.Consume();
            	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set210, retval));
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
            	Memoize(input, 49, assignment_operator_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "assignment_operator"

    public class conditional_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "conditional_expression"
    // C.g:381:1: conditional_expression : logical_or_expression ( '?' expression ':' conditional_expression )? ;
    public CParser.conditional_expression_return conditional_expression() // throws RecognitionException [1]
    {   
        CParser.conditional_expression_return retval = new CParser.conditional_expression_return();
        retval.Start = input.LT(1);
        int conditional_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal212 = null;
        IToken char_literal214 = null;
        CParser.logical_or_expression_return logical_or_expression211 = default(CParser.logical_or_expression_return);

        CParser.expression_return expression213 = default(CParser.expression_return);

        CParser.conditional_expression_return conditional_expression215 = default(CParser.conditional_expression_return);


        object char_literal212_tree=null;
        object char_literal214_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 50) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:382:2: ( logical_or_expression ( '?' expression ':' conditional_expression )? )
            // C.g:382:4: logical_or_expression ( '?' expression ':' conditional_expression )?
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logical_or_expression_in_conditional_expression1585);
            	logical_or_expression211 = logical_or_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logical_or_expression211.Tree, logical_or_expression211, retval);
            	// C.g:382:26: ( '?' expression ':' conditional_expression )?
            	int alt53 = 2;
            	int LA53_0 = input.LA(1);

            	if ( (LA53_0 == 76) )
            	{
            	    alt53 = 1;
            	}
            	switch (alt53) 
            	{
            	    case 1 :
            	        // C.g:382:27: '?' expression ':' conditional_expression
            	        {
            	        	char_literal212=(IToken)Match(input,76,FOLLOW_76_in_conditional_expression1588); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal212_tree = (object)adaptor.Create(char_literal212, retval);
            	        		adaptor.AddChild(root_0, char_literal212_tree);
            	        	}
            	        	PushFollow(FOLLOW_expression_in_conditional_expression1590);
            	        	expression213 = expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression213.Tree, expression213, retval);
            	        	char_literal214=(IToken)Match(input,44,FOLLOW_44_in_conditional_expression1592); if (state.failed) return retval;
            	        	if ( state.backtracking == 0 )
            	        	{char_literal214_tree = (object)adaptor.Create(char_literal214, retval);
            	        		adaptor.AddChild(root_0, char_literal214_tree);
            	        	}
            	        	PushFollow(FOLLOW_conditional_expression_in_conditional_expression1594);
            	        	conditional_expression215 = conditional_expression();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, conditional_expression215.Tree, conditional_expression215, retval);

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
            	Memoize(input, 50, conditional_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "conditional_expression"

    public class logical_or_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logical_or_expression"
    // C.g:385:1: logical_or_expression : logical_and_expression ( '||' logical_and_expression )* ;
    public CParser.logical_or_expression_return logical_or_expression() // throws RecognitionException [1]
    {   
        CParser.logical_or_expression_return retval = new CParser.logical_or_expression_return();
        retval.Start = input.LT(1);
        int logical_or_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal217 = null;
        CParser.logical_and_expression_return logical_and_expression216 = default(CParser.logical_and_expression_return);

        CParser.logical_and_expression_return logical_and_expression218 = default(CParser.logical_and_expression_return);


        object string_literal217_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 51) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:386:2: ( logical_and_expression ( '||' logical_and_expression )* )
            // C.g:386:4: logical_and_expression ( '||' logical_and_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_logical_and_expression_in_logical_or_expression1607);
            	logical_and_expression216 = logical_and_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logical_and_expression216.Tree, logical_and_expression216, retval);
            	// C.g:386:27: ( '||' logical_and_expression )*
            	do 
            	{
            	    int alt54 = 2;
            	    alt54 = dfa54.Predict(input);
            	    switch (alt54) 
            		{
            			case 1 :
            			    // C.g:386:28: '||' logical_and_expression
            			    {
            			    	string_literal217=(IToken)Match(input,77,FOLLOW_77_in_logical_or_expression1610); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal217_tree = (object)adaptor.Create(string_literal217, retval);
            			    		adaptor.AddChild(root_0, string_literal217_tree);
            			    	}
            			    	PushFollow(FOLLOW_logical_and_expression_in_logical_or_expression1612);
            			    	logical_and_expression218 = logical_and_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, logical_and_expression218.Tree, logical_and_expression218, retval);

            			    }
            			    break;

            			default:
            			    goto loop54;
            	    }
            	} while (true);

            	loop54:
            		;	// Stops C# compiler whining that label 'loop54' has no statements


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
            	Memoize(input, 51, logical_or_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logical_or_expression"

    public class logical_and_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "logical_and_expression"
    // C.g:389:1: logical_and_expression : inclusive_or_expression ( '&&' inclusive_or_expression )* ;
    public CParser.logical_and_expression_return logical_and_expression() // throws RecognitionException [1]
    {   
        CParser.logical_and_expression_return retval = new CParser.logical_and_expression_return();
        retval.Start = input.LT(1);
        int logical_and_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal220 = null;
        CParser.inclusive_or_expression_return inclusive_or_expression219 = default(CParser.inclusive_or_expression_return);

        CParser.inclusive_or_expression_return inclusive_or_expression221 = default(CParser.inclusive_or_expression_return);


        object string_literal220_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 52) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:390:2: ( inclusive_or_expression ( '&&' inclusive_or_expression )* )
            // C.g:390:4: inclusive_or_expression ( '&&' inclusive_or_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_inclusive_or_expression_in_logical_and_expression1625);
            	inclusive_or_expression219 = inclusive_or_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, inclusive_or_expression219.Tree, inclusive_or_expression219, retval);
            	// C.g:390:28: ( '&&' inclusive_or_expression )*
            	do 
            	{
            	    int alt55 = 2;
            	    alt55 = dfa55.Predict(input);
            	    switch (alt55) 
            		{
            			case 1 :
            			    // C.g:390:29: '&&' inclusive_or_expression
            			    {
            			    	string_literal220=(IToken)Match(input,78,FOLLOW_78_in_logical_and_expression1628); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{string_literal220_tree = (object)adaptor.Create(string_literal220, retval);
            			    		adaptor.AddChild(root_0, string_literal220_tree);
            			    	}
            			    	PushFollow(FOLLOW_inclusive_or_expression_in_logical_and_expression1630);
            			    	inclusive_or_expression221 = inclusive_or_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, inclusive_or_expression221.Tree, inclusive_or_expression221, retval);

            			    }
            			    break;

            			default:
            			    goto loop55;
            	    }
            	} while (true);

            	loop55:
            		;	// Stops C# compiler whining that label 'loop55' has no statements


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
            	Memoize(input, 52, logical_and_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "logical_and_expression"

    public class inclusive_or_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "inclusive_or_expression"
    // C.g:393:1: inclusive_or_expression : exclusive_or_expression ( '|' exclusive_or_expression )* ;
    public CParser.inclusive_or_expression_return inclusive_or_expression() // throws RecognitionException [1]
    {   
        CParser.inclusive_or_expression_return retval = new CParser.inclusive_or_expression_return();
        retval.Start = input.LT(1);
        int inclusive_or_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal223 = null;
        CParser.exclusive_or_expression_return exclusive_or_expression222 = default(CParser.exclusive_or_expression_return);

        CParser.exclusive_or_expression_return exclusive_or_expression224 = default(CParser.exclusive_or_expression_return);


        object char_literal223_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 53) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:394:2: ( exclusive_or_expression ( '|' exclusive_or_expression )* )
            // C.g:394:4: exclusive_or_expression ( '|' exclusive_or_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_exclusive_or_expression_in_inclusive_or_expression1643);
            	exclusive_or_expression222 = exclusive_or_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exclusive_or_expression222.Tree, exclusive_or_expression222, retval);
            	// C.g:394:28: ( '|' exclusive_or_expression )*
            	do 
            	{
            	    int alt56 = 2;
            	    alt56 = dfa56.Predict(input);
            	    switch (alt56) 
            		{
            			case 1 :
            			    // C.g:394:29: '|' exclusive_or_expression
            			    {
            			    	char_literal223=(IToken)Match(input,79,FOLLOW_79_in_inclusive_or_expression1646); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal223_tree = (object)adaptor.Create(char_literal223, retval);
            			    		adaptor.AddChild(root_0, char_literal223_tree);
            			    	}
            			    	PushFollow(FOLLOW_exclusive_or_expression_in_inclusive_or_expression1648);
            			    	exclusive_or_expression224 = exclusive_or_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, exclusive_or_expression224.Tree, exclusive_or_expression224, retval);

            			    }
            			    break;

            			default:
            			    goto loop56;
            	    }
            	} while (true);

            	loop56:
            		;	// Stops C# compiler whining that label 'loop56' has no statements


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
            	Memoize(input, 53, inclusive_or_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "inclusive_or_expression"

    public class exclusive_or_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "exclusive_or_expression"
    // C.g:397:1: exclusive_or_expression : and_expression ( '^' and_expression )* ;
    public CParser.exclusive_or_expression_return exclusive_or_expression() // throws RecognitionException [1]
    {   
        CParser.exclusive_or_expression_return retval = new CParser.exclusive_or_expression_return();
        retval.Start = input.LT(1);
        int exclusive_or_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal226 = null;
        CParser.and_expression_return and_expression225 = default(CParser.and_expression_return);

        CParser.and_expression_return and_expression227 = default(CParser.and_expression_return);


        object char_literal226_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 54) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:398:2: ( and_expression ( '^' and_expression )* )
            // C.g:398:4: and_expression ( '^' and_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_and_expression_in_exclusive_or_expression1661);
            	and_expression225 = and_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, and_expression225.Tree, and_expression225, retval);
            	// C.g:398:19: ( '^' and_expression )*
            	do 
            	{
            	    int alt57 = 2;
            	    alt57 = dfa57.Predict(input);
            	    switch (alt57) 
            		{
            			case 1 :
            			    // C.g:398:20: '^' and_expression
            			    {
            			    	char_literal226=(IToken)Match(input,80,FOLLOW_80_in_exclusive_or_expression1664); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal226_tree = (object)adaptor.Create(char_literal226, retval);
            			    		adaptor.AddChild(root_0, char_literal226_tree);
            			    	}
            			    	PushFollow(FOLLOW_and_expression_in_exclusive_or_expression1666);
            			    	and_expression227 = and_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, and_expression227.Tree, and_expression227, retval);

            			    }
            			    break;

            			default:
            			    goto loop57;
            	    }
            	} while (true);

            	loop57:
            		;	// Stops C# compiler whining that label 'loop57' has no statements


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
            	Memoize(input, 54, exclusive_or_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "exclusive_or_expression"

    public class and_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "and_expression"
    // C.g:401:1: and_expression : equality_expression ( '&' equality_expression )* ;
    public CParser.and_expression_return and_expression() // throws RecognitionException [1]
    {   
        CParser.and_expression_return retval = new CParser.and_expression_return();
        retval.Start = input.LT(1);
        int and_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal229 = null;
        CParser.equality_expression_return equality_expression228 = default(CParser.equality_expression_return);

        CParser.equality_expression_return equality_expression230 = default(CParser.equality_expression_return);


        object char_literal229_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 55) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:402:2: ( equality_expression ( '&' equality_expression )* )
            // C.g:402:4: equality_expression ( '&' equality_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_equality_expression_in_and_expression1679);
            	equality_expression228 = equality_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equality_expression228.Tree, equality_expression228, retval);
            	// C.g:402:24: ( '&' equality_expression )*
            	do 
            	{
            	    int alt58 = 2;
            	    alt58 = dfa58.Predict(input);
            	    switch (alt58) 
            		{
            			case 1 :
            			    // C.g:402:25: '&' equality_expression
            			    {
            			    	char_literal229=(IToken)Match(input,63,FOLLOW_63_in_and_expression1682); if (state.failed) return retval;
            			    	if ( state.backtracking == 0 )
            			    	{char_literal229_tree = (object)adaptor.Create(char_literal229, retval);
            			    		adaptor.AddChild(root_0, char_literal229_tree);
            			    	}
            			    	PushFollow(FOLLOW_equality_expression_in_and_expression1684);
            			    	equality_expression230 = equality_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, equality_expression230.Tree, equality_expression230, retval);

            			    }
            			    break;

            			default:
            			    goto loop58;
            	    }
            	} while (true);

            	loop58:
            		;	// Stops C# compiler whining that label 'loop58' has no statements


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
            	Memoize(input, 55, and_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "and_expression"

    public class equality_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "equality_expression"
    // C.g:404:1: equality_expression : relational_expression ( ( '==' | '!=' ) relational_expression )* ;
    public CParser.equality_expression_return equality_expression() // throws RecognitionException [1]
    {   
        CParser.equality_expression_return retval = new CParser.equality_expression_return();
        retval.Start = input.LT(1);
        int equality_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken set232 = null;
        CParser.relational_expression_return relational_expression231 = default(CParser.relational_expression_return);

        CParser.relational_expression_return relational_expression233 = default(CParser.relational_expression_return);


        object set232_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 56) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:405:2: ( relational_expression ( ( '==' | '!=' ) relational_expression )* )
            // C.g:405:4: relational_expression ( ( '==' | '!=' ) relational_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_relational_expression_in_equality_expression1696);
            	relational_expression231 = relational_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relational_expression231.Tree, relational_expression231, retval);
            	// C.g:405:26: ( ( '==' | '!=' ) relational_expression )*
            	do 
            	{
            	    int alt59 = 2;
            	    alt59 = dfa59.Predict(input);
            	    switch (alt59) 
            		{
            			case 1 :
            			    // C.g:405:27: ( '==' | '!=' ) relational_expression
            			    {
            			    	set232 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 81 && input.LA(1) <= 82) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set232, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_relational_expression_in_equality_expression1705);
            			    	relational_expression233 = relational_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, relational_expression233.Tree, relational_expression233, retval);

            			    }
            			    break;

            			default:
            			    goto loop59;
            	    }
            	} while (true);

            	loop59:
            		;	// Stops C# compiler whining that label 'loop59' has no statements


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
            	Memoize(input, 56, equality_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "equality_expression"

    public class relational_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "relational_expression"
    // C.g:408:1: relational_expression : shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )* ;
    public CParser.relational_expression_return relational_expression() // throws RecognitionException [1]
    {   
        CParser.relational_expression_return retval = new CParser.relational_expression_return();
        retval.Start = input.LT(1);
        int relational_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken set235 = null;
        CParser.shift_expression_return shift_expression234 = default(CParser.shift_expression_return);

        CParser.shift_expression_return shift_expression236 = default(CParser.shift_expression_return);


        object set235_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 57) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:409:2: ( shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )* )
            // C.g:409:4: shift_expression ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_shift_expression_in_relational_expression1718);
            	shift_expression234 = shift_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shift_expression234.Tree, shift_expression234, retval);
            	// C.g:409:21: ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*
            	do 
            	{
            	    int alt60 = 2;
            	    alt60 = dfa60.Predict(input);
            	    switch (alt60) 
            		{
            			case 1 :
            			    // C.g:409:22: ( '<' | '>' | '<=' | '>=' ) shift_expression
            			    {
            			    	set235 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 83 && input.LA(1) <= 86) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set235, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_shift_expression_in_relational_expression1731);
            			    	shift_expression236 = shift_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, shift_expression236.Tree, shift_expression236, retval);

            			    }
            			    break;

            			default:
            			    goto loop60;
            	    }
            	} while (true);

            	loop60:
            		;	// Stops C# compiler whining that label 'loop60' has no statements


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
            	Memoize(input, 57, relational_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "relational_expression"

    public class shift_expression_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "shift_expression"
    // C.g:412:1: shift_expression : additive_expression ( ( '<<' | '>>' ) additive_expression )* ;
    public CParser.shift_expression_return shift_expression() // throws RecognitionException [1]
    {   
        CParser.shift_expression_return retval = new CParser.shift_expression_return();
        retval.Start = input.LT(1);
        int shift_expression_StartIndex = input.Index();
        object root_0 = null;

        IToken set238 = null;
        CParser.additive_expression_return additive_expression237 = default(CParser.additive_expression_return);

        CParser.additive_expression_return additive_expression239 = default(CParser.additive_expression_return);


        object set238_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 58) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:413:2: ( additive_expression ( ( '<<' | '>>' ) additive_expression )* )
            // C.g:413:4: additive_expression ( ( '<<' | '>>' ) additive_expression )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_additive_expression_in_shift_expression1744);
            	additive_expression237 = additive_expression();
            	state.followingStackPointer--;
            	if (state.failed) return retval;
            	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additive_expression237.Tree, additive_expression237, retval);
            	// C.g:413:24: ( ( '<<' | '>>' ) additive_expression )*
            	do 
            	{
            	    int alt61 = 2;
            	    alt61 = dfa61.Predict(input);
            	    switch (alt61) 
            		{
            			case 1 :
            			    // C.g:413:25: ( '<<' | '>>' ) additive_expression
            			    {
            			    	set238 = (IToken)input.LT(1);
            			    	if ( (input.LA(1) >= 87 && input.LA(1) <= 88) ) 
            			    	{
            			    	    input.Consume();
            			    	    if ( state.backtracking == 0 ) adaptor.AddChild(root_0, (object)adaptor.Create(set238, retval));
            			    	    state.errorRecovery = false;state.failed = false;
            			    	}
            			    	else 
            			    	{
            			    	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    throw mse;
            			    	}

            			    	PushFollow(FOLLOW_additive_expression_in_shift_expression1753);
            			    	additive_expression239 = additive_expression();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, additive_expression239.Tree, additive_expression239, retval);

            			    }
            			    break;

            			default:
            			    goto loop61;
            	    }
            	} while (true);

            	loop61:
            		;	// Stops C# compiler whining that label 'loop61' has no statements


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
            	Memoize(input, 58, shift_expression_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "shift_expression"

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
    // C.g:418:1: statement : ( labeled_statement | compound_statement | expression_statement | selection_statement | iteration_statement | jump_statement );
    public CParser.statement_return statement() // throws RecognitionException [1]
    {   
        CParser.statement_return retval = new CParser.statement_return();
        retval.Start = input.LT(1);
        int statement_StartIndex = input.Index();
        object root_0 = null;

        CParser.labeled_statement_return labeled_statement240 = default(CParser.labeled_statement_return);

        CParser.compound_statement_return compound_statement241 = default(CParser.compound_statement_return);

        CParser.expression_statement_return expression_statement242 = default(CParser.expression_statement_return);

        CParser.selection_statement_return selection_statement243 = default(CParser.selection_statement_return);

        CParser.iteration_statement_return iteration_statement244 = default(CParser.iteration_statement_return);

        CParser.jump_statement_return jump_statement245 = default(CParser.jump_statement_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 59) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:419:2: ( labeled_statement | compound_statement | expression_statement | selection_statement | iteration_statement | jump_statement )
            int alt62 = 6;
            alt62 = dfa62.Predict(input);
            switch (alt62) 
            {
                case 1 :
                    // C.g:419:4: labeled_statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_labeled_statement_in_statement1768);
                    	labeled_statement240 = labeled_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, labeled_statement240.Tree, labeled_statement240, retval);

                    }
                    break;
                case 2 :
                    // C.g:420:4: compound_statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_compound_statement_in_statement1773);
                    	compound_statement241 = compound_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, compound_statement241.Tree, compound_statement241, retval);

                    }
                    break;
                case 3 :
                    // C.g:421:4: expression_statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expression_statement_in_statement1778);
                    	expression_statement242 = expression_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression_statement242.Tree, expression_statement242, retval);

                    }
                    break;
                case 4 :
                    // C.g:422:4: selection_statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_selection_statement_in_statement1783);
                    	selection_statement243 = selection_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, selection_statement243.Tree, selection_statement243, retval);

                    }
                    break;
                case 5 :
                    // C.g:423:4: iteration_statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_iteration_statement_in_statement1788);
                    	iteration_statement244 = iteration_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, iteration_statement244.Tree, iteration_statement244, retval);

                    }
                    break;
                case 6 :
                    // C.g:424:4: jump_statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_jump_statement_in_statement1793);
                    	jump_statement245 = jump_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, jump_statement245.Tree, jump_statement245, retval);

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
            	Memoize(input, 59, statement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "statement"

    public class labeled_statement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "labeled_statement"
    // C.g:427:1: labeled_statement : ( IDENTIFIER ':' statement | 'case' constant_expression ':' statement | 'default' ':' statement );
    public CParser.labeled_statement_return labeled_statement() // throws RecognitionException [1]
    {   
        CParser.labeled_statement_return retval = new CParser.labeled_statement_return();
        retval.Start = input.LT(1);
        int labeled_statement_StartIndex = input.Index();
        object root_0 = null;

        IToken IDENTIFIER246 = null;
        IToken char_literal247 = null;
        IToken string_literal249 = null;
        IToken char_literal251 = null;
        IToken string_literal253 = null;
        IToken char_literal254 = null;
        CParser.statement_return statement248 = default(CParser.statement_return);

        CParser.constant_expression_return constant_expression250 = default(CParser.constant_expression_return);

        CParser.statement_return statement252 = default(CParser.statement_return);

        CParser.statement_return statement255 = default(CParser.statement_return);


        object IDENTIFIER246_tree=null;
        object char_literal247_tree=null;
        object string_literal249_tree=null;
        object char_literal251_tree=null;
        object string_literal253_tree=null;
        object char_literal254_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 60) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:428:2: ( IDENTIFIER ':' statement | 'case' constant_expression ':' statement | 'default' ':' statement )
            int alt63 = 3;
            switch ( input.LA(1) ) 
            {
            case IDENTIFIER:
            	{
                alt63 = 1;
                }
                break;
            case 89:
            	{
                alt63 = 2;
                }
                break;
            case 90:
            	{
                alt63 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d63s0 =
            	        new NoViableAltException("", 63, 0, input);

            	    throw nvae_d63s0;
            }

            switch (alt63) 
            {
                case 1 :
                    // C.g:428:4: IDENTIFIER ':' statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	IDENTIFIER246=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_labeled_statement1804), "IDENTIFIER"); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENTIFIER246_tree = (object)adaptor.Create(IDENTIFIER246, retval);
                    		adaptor.AddChild(root_0, IDENTIFIER246_tree);
                    	}
                    	char_literal247=(IToken)Match(input,44,FOLLOW_44_in_labeled_statement1806); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal247_tree = (object)adaptor.Create(char_literal247, retval);
                    		adaptor.AddChild(root_0, char_literal247_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_labeled_statement1808);
                    	statement248 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement248.Tree, statement248, retval);

                    }
                    break;
                case 2 :
                    // C.g:429:4: 'case' constant_expression ':' statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal249=(IToken)Match(input,89,FOLLOW_89_in_labeled_statement1813); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal249_tree = (object)adaptor.Create(string_literal249, retval);
                    		adaptor.AddChild(root_0, string_literal249_tree);
                    	}
                    	PushFollow(FOLLOW_constant_expression_in_labeled_statement1815);
                    	constant_expression250 = constant_expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, constant_expression250.Tree, constant_expression250, retval);
                    	char_literal251=(IToken)Match(input,44,FOLLOW_44_in_labeled_statement1817); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal251_tree = (object)adaptor.Create(char_literal251, retval);
                    		adaptor.AddChild(root_0, char_literal251_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_labeled_statement1819);
                    	statement252 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement252.Tree, statement252, retval);

                    }
                    break;
                case 3 :
                    // C.g:430:4: 'default' ':' statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal253=(IToken)Match(input,90,FOLLOW_90_in_labeled_statement1824); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal253_tree = (object)adaptor.Create(string_literal253, retval);
                    		adaptor.AddChild(root_0, string_literal253_tree);
                    	}
                    	char_literal254=(IToken)Match(input,44,FOLLOW_44_in_labeled_statement1826); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal254_tree = (object)adaptor.Create(char_literal254, retval);
                    		adaptor.AddChild(root_0, char_literal254_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_labeled_statement1828);
                    	statement255 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement255.Tree, statement255, retval);

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
            	Memoize(input, 60, labeled_statement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "labeled_statement"

    public class compound_statement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "compound_statement"
    // C.g:433:1: compound_statement : '{' ( declaration )* ( statement_list )? '}' ;
    public CParser.compound_statement_return compound_statement() // throws RecognitionException [1]
    {   
        Symbols_stack.Push(new Symbols_scope());

        CParser.compound_statement_return retval = new CParser.compound_statement_return();
        retval.Start = input.LT(1);
        int compound_statement_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal256 = null;
        IToken char_literal259 = null;
        CParser.declaration_return declaration257 = default(CParser.declaration_return);

        CParser.statement_list_return statement_list258 = default(CParser.statement_list_return);


        object char_literal256_tree=null;
        object char_literal259_tree=null;


          ((Symbols_scope)Symbols_stack.Peek()).types =  new HashSet();

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 61) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:438:2: ( '{' ( declaration )* ( statement_list )? '}' )
            // C.g:438:4: '{' ( declaration )* ( statement_list )? '}'
            {
            	root_0 = (object)adaptor.GetNilNode();

            	char_literal256=(IToken)Match(input,40,FOLLOW_40_in_compound_statement1850); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal256_tree = (object)adaptor.Create(char_literal256, retval);
            		adaptor.AddChild(root_0, char_literal256_tree);
            	}
            	// C.g:438:8: ( declaration )*
            	do 
            	{
            	    int alt64 = 2;
            	    alt64 = dfa64.Predict(input);
            	    switch (alt64) 
            		{
            			case 1 :
            			    // C.g:0:0: declaration
            			    {
            			    	PushFollow(FOLLOW_declaration_in_compound_statement1852);
            			    	declaration257 = declaration();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, declaration257.Tree, declaration257, retval);

            			    }
            			    break;

            			default:
            			    goto loop64;
            	    }
            	} while (true);

            	loop64:
            		;	// Stops C# compiler whining that label 'loop64' has no statements

            	// C.g:438:21: ( statement_list )?
            	int alt65 = 2;
            	alt65 = dfa65.Predict(input);
            	switch (alt65) 
            	{
            	    case 1 :
            	        // C.g:0:0: statement_list
            	        {
            	        	PushFollow(FOLLOW_statement_list_in_compound_statement1855);
            	        	statement_list258 = statement_list();
            	        	state.followingStackPointer--;
            	        	if (state.failed) return retval;
            	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement_list258.Tree, statement_list258, retval);

            	        }
            	        break;

            	}

            	char_literal259=(IToken)Match(input,41,FOLLOW_41_in_compound_statement1858); if (state.failed) return retval;
            	if ( state.backtracking == 0 )
            	{char_literal259_tree = (object)adaptor.Create(char_literal259, retval);
            		adaptor.AddChild(root_0, char_literal259_tree);
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
            	Memoize(input, 61, compound_statement_StartIndex); 
            }
            Symbols_stack.Pop();

        }
        return retval;
    }
    // $ANTLR end "compound_statement"

    public class statement_list_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "statement_list"
    // C.g:441:1: statement_list : ( statement )+ ;
    public CParser.statement_list_return statement_list() // throws RecognitionException [1]
    {   
        CParser.statement_list_return retval = new CParser.statement_list_return();
        retval.Start = input.LT(1);
        int statement_list_StartIndex = input.Index();
        object root_0 = null;

        CParser.statement_return statement260 = default(CParser.statement_return);



        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 62) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:442:2: ( ( statement )+ )
            // C.g:442:4: ( statement )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// C.g:442:4: ( statement )+
            	int cnt66 = 0;
            	do 
            	{
            	    int alt66 = 2;
            	    alt66 = dfa66.Predict(input);
            	    switch (alt66) 
            		{
            			case 1 :
            			    // C.g:0:0: statement
            			    {
            			    	PushFollow(FOLLOW_statement_in_statement_list1869);
            			    	statement260 = statement();
            			    	state.followingStackPointer--;
            			    	if (state.failed) return retval;
            			    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement260.Tree, statement260, retval);

            			    }
            			    break;

            			default:
            			    if ( cnt66 >= 1 ) goto loop66;
            			    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            		            EarlyExitException eee66 =
            		                new EarlyExitException(66, input);
            		            throw eee66;
            	    }
            	    cnt66++;
            	} while (true);

            	loop66:
            		;	// Stops C# compiler whining that label 'loop66' has no statements


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
            	Memoize(input, 62, statement_list_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "statement_list"

    public class expression_statement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expression_statement"
    // C.g:445:1: expression_statement : ( ';' | expression ';' );
    public CParser.expression_statement_return expression_statement() // throws RecognitionException [1]
    {   
        CParser.expression_statement_return retval = new CParser.expression_statement_return();
        retval.Start = input.LT(1);
        int expression_statement_StartIndex = input.Index();
        object root_0 = null;

        IToken char_literal261 = null;
        IToken char_literal263 = null;
        CParser.expression_return expression262 = default(CParser.expression_return);


        object char_literal261_tree=null;
        object char_literal263_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 63) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:446:2: ( ';' | expression ';' )
            int alt67 = 2;
            int LA67_0 = input.LA(1);

            if ( (LA67_0 == 24) )
            {
                alt67 = 1;
            }
            else if ( ((LA67_0 >= IDENTIFIER && LA67_0 <= FLOATING_POINT_LITERAL) || LA67_0 == 48 || LA67_0 == 52 || (LA67_0 >= 54 && LA67_0 <= 55) || (LA67_0 >= 58 && LA67_0 <= 60) || (LA67_0 >= 63 && LA67_0 <= 65)) )
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
                    // C.g:446:4: ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	char_literal261=(IToken)Match(input,24,FOLLOW_24_in_expression_statement1881); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal261_tree = (object)adaptor.Create(char_literal261, retval);
                    		adaptor.AddChild(root_0, char_literal261_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:447:4: expression ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_expression_in_expression_statement1886);
                    	expression262 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression262.Tree, expression262, retval);
                    	char_literal263=(IToken)Match(input,24,FOLLOW_24_in_expression_statement1888); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal263_tree = (object)adaptor.Create(char_literal263, retval);
                    		adaptor.AddChild(root_0, char_literal263_tree);
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
            	Memoize(input, 63, expression_statement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "expression_statement"

    public class selection_statement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "selection_statement"
    // C.g:450:1: selection_statement : ( 'if' '(' expression ')' statement ( options {k=1; backtrack=false; } : 'else' statement )? | 'switch' '(' expression ')' statement );
    public CParser.selection_statement_return selection_statement() // throws RecognitionException [1]
    {   
        CParser.selection_statement_return retval = new CParser.selection_statement_return();
        retval.Start = input.LT(1);
        int selection_statement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal264 = null;
        IToken char_literal265 = null;
        IToken char_literal267 = null;
        IToken string_literal269 = null;
        IToken string_literal271 = null;
        IToken char_literal272 = null;
        IToken char_literal274 = null;
        CParser.expression_return expression266 = default(CParser.expression_return);

        CParser.statement_return statement268 = default(CParser.statement_return);

        CParser.statement_return statement270 = default(CParser.statement_return);

        CParser.expression_return expression273 = default(CParser.expression_return);

        CParser.statement_return statement275 = default(CParser.statement_return);


        object string_literal264_tree=null;
        object char_literal265_tree=null;
        object char_literal267_tree=null;
        object string_literal269_tree=null;
        object string_literal271_tree=null;
        object char_literal272_tree=null;
        object char_literal274_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 64) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:451:2: ( 'if' '(' expression ')' statement ( options {k=1; backtrack=false; } : 'else' statement )? | 'switch' '(' expression ')' statement )
            int alt69 = 2;
            int LA69_0 = input.LA(1);

            if ( (LA69_0 == 91) )
            {
                alt69 = 1;
            }
            else if ( (LA69_0 == 93) )
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
                    // C.g:451:4: 'if' '(' expression ')' statement ( options {k=1; backtrack=false; } : 'else' statement )?
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal264=(IToken)Match(input,91,FOLLOW_91_in_selection_statement1899); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal264_tree = (object)adaptor.Create(string_literal264, retval);
                    		adaptor.AddChild(root_0, string_literal264_tree);
                    	}
                    	char_literal265=(IToken)Match(input,48,FOLLOW_48_in_selection_statement1901); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal265_tree = (object)adaptor.Create(char_literal265, retval);
                    		adaptor.AddChild(root_0, char_literal265_tree);
                    	}
                    	PushFollow(FOLLOW_expression_in_selection_statement1903);
                    	expression266 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression266.Tree, expression266, retval);
                    	char_literal267=(IToken)Match(input,49,FOLLOW_49_in_selection_statement1905); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal267_tree = (object)adaptor.Create(char_literal267, retval);
                    		adaptor.AddChild(root_0, char_literal267_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_selection_statement1907);
                    	statement268 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement268.Tree, statement268, retval);
                    	// C.g:451:38: ( options {k=1; backtrack=false; } : 'else' statement )?
                    	int alt68 = 2;
                    	int LA68_0 = input.LA(1);

                    	if ( (LA68_0 == 92) )
                    	{
                    	    int LA68_2 = input.LA(2);

                    	    if ( (true) )
                    	    {
                    	        alt68 = 1;
                    	    }
                    	}
                    	switch (alt68) 
                    	{
                    	    case 1 :
                    	        // C.g:451:71: 'else' statement
                    	        {
                    	        	string_literal269=(IToken)Match(input,92,FOLLOW_92_in_selection_statement1922); if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 )
                    	        	{string_literal269_tree = (object)adaptor.Create(string_literal269, retval);
                    	        		adaptor.AddChild(root_0, string_literal269_tree);
                    	        	}
                    	        	PushFollow(FOLLOW_statement_in_selection_statement1924);
                    	        	statement270 = statement();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement270.Tree, statement270, retval);

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // C.g:452:4: 'switch' '(' expression ')' statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal271=(IToken)Match(input,93,FOLLOW_93_in_selection_statement1931); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal271_tree = (object)adaptor.Create(string_literal271, retval);
                    		adaptor.AddChild(root_0, string_literal271_tree);
                    	}
                    	char_literal272=(IToken)Match(input,48,FOLLOW_48_in_selection_statement1933); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal272_tree = (object)adaptor.Create(char_literal272, retval);
                    		adaptor.AddChild(root_0, char_literal272_tree);
                    	}
                    	PushFollow(FOLLOW_expression_in_selection_statement1935);
                    	expression273 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression273.Tree, expression273, retval);
                    	char_literal274=(IToken)Match(input,49,FOLLOW_49_in_selection_statement1937); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal274_tree = (object)adaptor.Create(char_literal274, retval);
                    		adaptor.AddChild(root_0, char_literal274_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_selection_statement1939);
                    	statement275 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement275.Tree, statement275, retval);

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
            	Memoize(input, 64, selection_statement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "selection_statement"

    public class iteration_statement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "iteration_statement"
    // C.g:455:1: iteration_statement : ( 'while' '(' expression ')' statement | 'do' statement 'while' '(' expression ')' ';' | 'for' '(' expression_statement expression_statement ( expression )? ')' statement );
    public CParser.iteration_statement_return iteration_statement() // throws RecognitionException [1]
    {   
        CParser.iteration_statement_return retval = new CParser.iteration_statement_return();
        retval.Start = input.LT(1);
        int iteration_statement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal276 = null;
        IToken char_literal277 = null;
        IToken char_literal279 = null;
        IToken string_literal281 = null;
        IToken string_literal283 = null;
        IToken char_literal284 = null;
        IToken char_literal286 = null;
        IToken char_literal287 = null;
        IToken string_literal288 = null;
        IToken char_literal289 = null;
        IToken char_literal293 = null;
        CParser.expression_return expression278 = default(CParser.expression_return);

        CParser.statement_return statement280 = default(CParser.statement_return);

        CParser.statement_return statement282 = default(CParser.statement_return);

        CParser.expression_return expression285 = default(CParser.expression_return);

        CParser.expression_statement_return expression_statement290 = default(CParser.expression_statement_return);

        CParser.expression_statement_return expression_statement291 = default(CParser.expression_statement_return);

        CParser.expression_return expression292 = default(CParser.expression_return);

        CParser.statement_return statement294 = default(CParser.statement_return);


        object string_literal276_tree=null;
        object char_literal277_tree=null;
        object char_literal279_tree=null;
        object string_literal281_tree=null;
        object string_literal283_tree=null;
        object char_literal284_tree=null;
        object char_literal286_tree=null;
        object char_literal287_tree=null;
        object string_literal288_tree=null;
        object char_literal289_tree=null;
        object char_literal293_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 65) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:456:2: ( 'while' '(' expression ')' statement | 'do' statement 'while' '(' expression ')' ';' | 'for' '(' expression_statement expression_statement ( expression )? ')' statement )
            int alt71 = 3;
            switch ( input.LA(1) ) 
            {
            case 94:
            	{
                alt71 = 1;
                }
                break;
            case 95:
            	{
                alt71 = 2;
                }
                break;
            case 96:
            	{
                alt71 = 3;
                }
                break;
            	default:
            	    if ( state.backtracking > 0 ) {state.failed = true; return retval;}
            	    NoViableAltException nvae_d71s0 =
            	        new NoViableAltException("", 71, 0, input);

            	    throw nvae_d71s0;
            }

            switch (alt71) 
            {
                case 1 :
                    // C.g:456:4: 'while' '(' expression ')' statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal276=(IToken)Match(input,94,FOLLOW_94_in_iteration_statement1950); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal276_tree = (object)adaptor.Create(string_literal276, retval);
                    		adaptor.AddChild(root_0, string_literal276_tree);
                    	}
                    	char_literal277=(IToken)Match(input,48,FOLLOW_48_in_iteration_statement1952); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal277_tree = (object)adaptor.Create(char_literal277, retval);
                    		adaptor.AddChild(root_0, char_literal277_tree);
                    	}
                    	PushFollow(FOLLOW_expression_in_iteration_statement1954);
                    	expression278 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression278.Tree, expression278, retval);
                    	char_literal279=(IToken)Match(input,49,FOLLOW_49_in_iteration_statement1956); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal279_tree = (object)adaptor.Create(char_literal279, retval);
                    		adaptor.AddChild(root_0, char_literal279_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_iteration_statement1958);
                    	statement280 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement280.Tree, statement280, retval);

                    }
                    break;
                case 2 :
                    // C.g:457:4: 'do' statement 'while' '(' expression ')' ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal281=(IToken)Match(input,95,FOLLOW_95_in_iteration_statement1963); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal281_tree = (object)adaptor.Create(string_literal281, retval);
                    		adaptor.AddChild(root_0, string_literal281_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_iteration_statement1965);
                    	statement282 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement282.Tree, statement282, retval);
                    	string_literal283=(IToken)Match(input,94,FOLLOW_94_in_iteration_statement1967); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal283_tree = (object)adaptor.Create(string_literal283, retval);
                    		adaptor.AddChild(root_0, string_literal283_tree);
                    	}
                    	char_literal284=(IToken)Match(input,48,FOLLOW_48_in_iteration_statement1969); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal284_tree = (object)adaptor.Create(char_literal284, retval);
                    		adaptor.AddChild(root_0, char_literal284_tree);
                    	}
                    	PushFollow(FOLLOW_expression_in_iteration_statement1971);
                    	expression285 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression285.Tree, expression285, retval);
                    	char_literal286=(IToken)Match(input,49,FOLLOW_49_in_iteration_statement1973); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal286_tree = (object)adaptor.Create(char_literal286, retval);
                    		adaptor.AddChild(root_0, char_literal286_tree);
                    	}
                    	char_literal287=(IToken)Match(input,24,FOLLOW_24_in_iteration_statement1975); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal287_tree = (object)adaptor.Create(char_literal287, retval);
                    		adaptor.AddChild(root_0, char_literal287_tree);
                    	}

                    }
                    break;
                case 3 :
                    // C.g:458:4: 'for' '(' expression_statement expression_statement ( expression )? ')' statement
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal288=(IToken)Match(input,96,FOLLOW_96_in_iteration_statement1980); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal288_tree = (object)adaptor.Create(string_literal288, retval);
                    		adaptor.AddChild(root_0, string_literal288_tree);
                    	}
                    	char_literal289=(IToken)Match(input,48,FOLLOW_48_in_iteration_statement1982); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal289_tree = (object)adaptor.Create(char_literal289, retval);
                    		adaptor.AddChild(root_0, char_literal289_tree);
                    	}
                    	PushFollow(FOLLOW_expression_statement_in_iteration_statement1984);
                    	expression_statement290 = expression_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression_statement290.Tree, expression_statement290, retval);
                    	PushFollow(FOLLOW_expression_statement_in_iteration_statement1986);
                    	expression_statement291 = expression_statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression_statement291.Tree, expression_statement291, retval);
                    	// C.g:458:56: ( expression )?
                    	int alt70 = 2;
                    	int LA70_0 = input.LA(1);

                    	if ( ((LA70_0 >= IDENTIFIER && LA70_0 <= FLOATING_POINT_LITERAL) || LA70_0 == 48 || LA70_0 == 52 || (LA70_0 >= 54 && LA70_0 <= 55) || (LA70_0 >= 58 && LA70_0 <= 60) || (LA70_0 >= 63 && LA70_0 <= 65)) )
                    	{
                    	    alt70 = 1;
                    	}
                    	switch (alt70) 
                    	{
                    	    case 1 :
                    	        // C.g:0:0: expression
                    	        {
                    	        	PushFollow(FOLLOW_expression_in_iteration_statement1988);
                    	        	expression292 = expression();
                    	        	state.followingStackPointer--;
                    	        	if (state.failed) return retval;
                    	        	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression292.Tree, expression292, retval);

                    	        }
                    	        break;

                    	}

                    	char_literal293=(IToken)Match(input,49,FOLLOW_49_in_iteration_statement1991); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal293_tree = (object)adaptor.Create(char_literal293, retval);
                    		adaptor.AddChild(root_0, char_literal293_tree);
                    	}
                    	PushFollow(FOLLOW_statement_in_iteration_statement1993);
                    	statement294 = statement();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, statement294.Tree, statement294, retval);

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
            	Memoize(input, 65, iteration_statement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "iteration_statement"

    public class jump_statement_return : XParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "jump_statement"
    // C.g:461:1: jump_statement : ( 'goto' IDENTIFIER ';' | 'continue' ';' | 'break' ';' | 'return' ';' | 'return' expression ';' );
    public CParser.jump_statement_return jump_statement() // throws RecognitionException [1]
    {   
        CParser.jump_statement_return retval = new CParser.jump_statement_return();
        retval.Start = input.LT(1);
        int jump_statement_StartIndex = input.Index();
        object root_0 = null;

        IToken string_literal295 = null;
        IToken IDENTIFIER296 = null;
        IToken char_literal297 = null;
        IToken string_literal298 = null;
        IToken char_literal299 = null;
        IToken string_literal300 = null;
        IToken char_literal301 = null;
        IToken string_literal302 = null;
        IToken char_literal303 = null;
        IToken string_literal304 = null;
        IToken char_literal306 = null;
        CParser.expression_return expression305 = default(CParser.expression_return);


        object string_literal295_tree=null;
        object IDENTIFIER296_tree=null;
        object char_literal297_tree=null;
        object string_literal298_tree=null;
        object char_literal299_tree=null;
        object string_literal300_tree=null;
        object char_literal301_tree=null;
        object string_literal302_tree=null;
        object char_literal303_tree=null;
        object string_literal304_tree=null;
        object char_literal306_tree=null;

        try 
    	{
    	    if ( (state.backtracking > 0) && AlreadyParsedRule(input, 66) ) 
    	    {
    	    	return retval; 
    	    }
            // C.g:462:2: ( 'goto' IDENTIFIER ';' | 'continue' ';' | 'break' ';' | 'return' ';' | 'return' expression ';' )
            int alt72 = 5;
            alt72 = dfa72.Predict(input);
            switch (alt72) 
            {
                case 1 :
                    // C.g:462:4: 'goto' IDENTIFIER ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal295=(IToken)Match(input,97,FOLLOW_97_in_jump_statement2004); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal295_tree = (object)adaptor.Create(string_literal295, retval);
                    		adaptor.AddChild(root_0, string_literal295_tree);
                    	}
                    	IDENTIFIER296=(IToken)new XToken((IToken)Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_jump_statement2006), "IDENTIFIER"); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{IDENTIFIER296_tree = (object)adaptor.Create(IDENTIFIER296, retval);
                    		adaptor.AddChild(root_0, IDENTIFIER296_tree);
                    	}
                    	char_literal297=(IToken)Match(input,24,FOLLOW_24_in_jump_statement2008); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal297_tree = (object)adaptor.Create(char_literal297, retval);
                    		adaptor.AddChild(root_0, char_literal297_tree);
                    	}

                    }
                    break;
                case 2 :
                    // C.g:463:4: 'continue' ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal298=(IToken)Match(input,98,FOLLOW_98_in_jump_statement2013); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal298_tree = (object)adaptor.Create(string_literal298, retval);
                    		adaptor.AddChild(root_0, string_literal298_tree);
                    	}
                    	char_literal299=(IToken)Match(input,24,FOLLOW_24_in_jump_statement2015); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal299_tree = (object)adaptor.Create(char_literal299, retval);
                    		adaptor.AddChild(root_0, char_literal299_tree);
                    	}

                    }
                    break;
                case 3 :
                    // C.g:464:4: 'break' ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal300=(IToken)Match(input,99,FOLLOW_99_in_jump_statement2020); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal300_tree = (object)adaptor.Create(string_literal300, retval);
                    		adaptor.AddChild(root_0, string_literal300_tree);
                    	}
                    	char_literal301=(IToken)Match(input,24,FOLLOW_24_in_jump_statement2022); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal301_tree = (object)adaptor.Create(char_literal301, retval);
                    		adaptor.AddChild(root_0, char_literal301_tree);
                    	}

                    }
                    break;
                case 4 :
                    // C.g:465:4: 'return' ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal302=(IToken)Match(input,100,FOLLOW_100_in_jump_statement2027); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal302_tree = (object)adaptor.Create(string_literal302, retval);
                    		adaptor.AddChild(root_0, string_literal302_tree);
                    	}
                    	char_literal303=(IToken)Match(input,24,FOLLOW_24_in_jump_statement2029); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal303_tree = (object)adaptor.Create(char_literal303, retval);
                    		adaptor.AddChild(root_0, char_literal303_tree);
                    	}

                    }
                    break;
                case 5 :
                    // C.g:466:4: 'return' expression ';'
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	string_literal304=(IToken)Match(input,100,FOLLOW_100_in_jump_statement2034); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{string_literal304_tree = (object)adaptor.Create(string_literal304, retval);
                    		adaptor.AddChild(root_0, string_literal304_tree);
                    	}
                    	PushFollow(FOLLOW_expression_in_jump_statement2036);
                    	expression305 = expression();
                    	state.followingStackPointer--;
                    	if (state.failed) return retval;
                    	if ( state.backtracking == 0 ) adaptor.AddChild(root_0, expression305.Tree, expression305, retval);
                    	char_literal306=(IToken)Match(input,24,FOLLOW_24_in_jump_statement2038); if (state.failed) return retval;
                    	if ( state.backtracking == 0 )
                    	{char_literal306_tree = (object)adaptor.Create(char_literal306, retval);
                    		adaptor.AddChild(root_0, char_literal306_tree);
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
            	Memoize(input, 66, jump_statement_StartIndex); 
            }
        }
        return retval;
    }
    // $ANTLR end "jump_statement"

    // $ANTLR start "synpred2_C"
    public void synpred2_C_fragment() {
        // C.g:82:6: ( declaration_specifiers )
        // C.g:82:6: declaration_specifiers
        {
        	PushFollow(FOLLOW_declaration_specifiers_in_synpred2_C109);
        	declaration_specifiers();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred2_C"

    // $ANTLR start "synpred4_C"
    public void synpred4_C_fragment() {
        // C.g:82:4: ( ( declaration_specifiers )? declarator ( declaration )* '{' )
        // C.g:82:6: ( declaration_specifiers )? declarator ( declaration )* '{'
        {
        	// C.g:82:6: ( declaration_specifiers )?
        	int alt73 = 2;
        	alt73 = dfa73.Predict(input);
        	switch (alt73) 
        	{
        	    case 1 :
        	        // C.g:0:0: declaration_specifiers
        	        {
        	        	PushFollow(FOLLOW_declaration_specifiers_in_synpred4_C109);
        	        	declaration_specifiers();
        	        	state.followingStackPointer--;
        	        	if (state.failed) return ;

        	        }
        	        break;

        	}

        	PushFollow(FOLLOW_declarator_in_synpred4_C112);
        	declarator();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	// C.g:82:41: ( declaration )*
        	do 
        	{
        	    int alt74 = 2;
        	    alt74 = dfa74.Predict(input);
        	    switch (alt74) 
        		{
        			case 1 :
        			    // C.g:0:0: declaration
        			    {
        			    	PushFollow(FOLLOW_declaration_in_synpred4_C114);
        			    	declaration();
        			    	state.followingStackPointer--;
        			    	if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    goto loop74;
        	    }
        	} while (true);

        	loop74:
        		;	// Stops C# compiler whining that label 'loop74' has no statements

        	Match(input,40,FOLLOW_40_in_synpred4_C117); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred4_C"

    // $ANTLR start "synpred5_C"
    public void synpred5_C_fragment() {
        // C.g:91:4: ( declaration_specifiers )
        // C.g:91:4: declaration_specifiers
        {
        	PushFollow(FOLLOW_declaration_specifiers_in_synpred5_C149);
        	declaration_specifiers();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred5_C"

    // $ANTLR start "synpred8_C"
    public void synpred8_C_fragment() {
        // C.g:104:14: ( declaration_specifiers )
        // C.g:104:14: declaration_specifiers
        {
        	PushFollow(FOLLOW_declaration_specifiers_in_synpred8_C198);
        	declaration_specifiers();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred8_C"

    // $ANTLR start "synpred12_C"
    public void synpred12_C_fragment() {
        // C.g:111:7: ( type_specifier )
        // C.g:111:7: type_specifier
        {
        	PushFollow(FOLLOW_type_specifier_in_synpred12_C244);
        	type_specifier();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred12_C"

    // $ANTLR start "synpred35_C"
    public void synpred35_C_fragment() {
        // C.g:175:23: ( type_specifier )
        // C.g:175:23: type_specifier
        {
        	PushFollow(FOLLOW_type_specifier_in_synpred35_C524);
        	type_specifier();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred35_C"

    // $ANTLR start "synpred45_C"
    public void synpred45_C_fragment() {
        // C.g:208:4: ( ( pointer )? direct_declarator )
        // C.g:208:4: ( pointer )? direct_declarator
        {
        	// C.g:208:4: ( pointer )?
        	int alt79 = 2;
        	int LA79_0 = input.LA(1);

        	if ( (LA79_0 == 52) )
        	{
        	    alt79 = 1;
        	}
        	switch (alt79) 
        	{
        	    case 1 :
        	        // C.g:0:0: pointer
        	        {
        	        	PushFollow(FOLLOW_pointer_in_synpred45_C677);
        	        	pointer();
        	        	state.followingStackPointer--;
        	        	if (state.failed) return ;

        	        }
        	        break;

        	}

        	PushFollow(FOLLOW_direct_declarator_in_synpred45_C680);
        	direct_declarator();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred45_C"

    // $ANTLR start "synpred47_C"
    public void synpred47_C_fragment() {
        // C.g:222:9: ( declarator_suffix )
        // C.g:222:9: declarator_suffix
        {
        	PushFollow(FOLLOW_declarator_suffix_in_synpred47_C729);
        	declarator_suffix();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred47_C"

    // $ANTLR start "synpred50_C"
    public void synpred50_C_fragment() {
        // C.g:228:9: ( '(' parameter_type_list ')' )
        // C.g:228:9: '(' parameter_type_list ')'
        {
        	Match(input,48,FOLLOW_48_in_synpred50_C769); if (state.failed) return ;
        	PushFollow(FOLLOW_parameter_type_list_in_synpred50_C771);
        	parameter_type_list();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	Match(input,49,FOLLOW_49_in_synpred50_C773); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred50_C"

    // $ANTLR start "synpred51_C"
    public void synpred51_C_fragment() {
        // C.g:229:9: ( '(' identifier_list ')' )
        // C.g:229:9: '(' identifier_list ')'
        {
        	Match(input,48,FOLLOW_48_in_synpred51_C783); if (state.failed) return ;
        	PushFollow(FOLLOW_identifier_list_in_synpred51_C785);
        	identifier_list();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	Match(input,49,FOLLOW_49_in_synpred51_C787); if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred51_C"

    // $ANTLR start "synpred52_C"
    public void synpred52_C_fragment() {
        // C.g:234:8: ( type_qualifier )
        // C.g:234:8: type_qualifier
        {
        	PushFollow(FOLLOW_type_qualifier_in_synpred52_C812);
        	type_qualifier();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred52_C"

    // $ANTLR start "synpred53_C"
    public void synpred53_C_fragment() {
        // C.g:234:24: ( pointer )
        // C.g:234:24: pointer
        {
        	PushFollow(FOLLOW_pointer_in_synpred53_C815);
        	pointer();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred53_C"

    // $ANTLR start "synpred54_C"
    public void synpred54_C_fragment() {
        // C.g:234:4: ( '*' ( type_qualifier )+ ( pointer )? )
        // C.g:234:4: '*' ( type_qualifier )+ ( pointer )?
        {
        	Match(input,52,FOLLOW_52_in_synpred54_C810); if (state.failed) return ;
        	// C.g:234:8: ( type_qualifier )+
        	int cnt80 = 0;
        	do 
        	{
        	    int alt80 = 2;
        	    int LA80_0 = input.LA(1);

        	    if ( ((LA80_0 >= 46 && LA80_0 <= 47)) )
        	    {
        	        alt80 = 1;
        	    }


        	    switch (alt80) 
        		{
        			case 1 :
        			    // C.g:0:0: type_qualifier
        			    {
        			    	PushFollow(FOLLOW_type_qualifier_in_synpred54_C812);
        			    	type_qualifier();
        			    	state.followingStackPointer--;
        			    	if (state.failed) return ;

        			    }
        			    break;

        			default:
        			    if ( cnt80 >= 1 ) goto loop80;
        			    if ( state.backtracking > 0 ) {state.failed = true; return ;}
        		            EarlyExitException eee80 =
        		                new EarlyExitException(80, input);
        		            throw eee80;
        	    }
        	    cnt80++;
        	} while (true);

        	loop80:
        		;	// Stops C# compiler whining that label 'loop80' has no statements

        	// C.g:234:24: ( pointer )?
        	int alt81 = 2;
        	int LA81_0 = input.LA(1);

        	if ( (LA81_0 == 52) )
        	{
        	    alt81 = 1;
        	}
        	switch (alt81) 
        	{
        	    case 1 :
        	        // C.g:0:0: pointer
        	        {
        	        	PushFollow(FOLLOW_pointer_in_synpred54_C815);
        	        	pointer();
        	        	state.followingStackPointer--;
        	        	if (state.failed) return ;

        	        }
        	        break;

        	}


        }
    }
    // $ANTLR end "synpred54_C"

    // $ANTLR start "synpred55_C"
    public void synpred55_C_fragment() {
        // C.g:235:4: ( '*' pointer )
        // C.g:235:4: '*' pointer
        {
        	Match(input,52,FOLLOW_52_in_synpred55_C821); if (state.failed) return ;
        	PushFollow(FOLLOW_pointer_in_synpred55_C823);
        	pointer();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred55_C"

    // $ANTLR start "synpred58_C"
    public void synpred58_C_fragment() {
        // C.g:248:28: ( declarator )
        // C.g:248:28: declarator
        {
        	PushFollow(FOLLOW_declarator_in_synpred58_C878);
        	declarator();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred58_C"

    // $ANTLR start "synpred59_C"
    public void synpred59_C_fragment() {
        // C.g:248:39: ( abstract_declarator )
        // C.g:248:39: abstract_declarator
        {
        	PushFollow(FOLLOW_abstract_declarator_in_synpred59_C880);
        	abstract_declarator();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred59_C"

    // $ANTLR start "synpred62_C"
    public void synpred62_C_fragment() {
        // C.g:260:12: ( direct_abstract_declarator )
        // C.g:260:12: direct_abstract_declarator
        {
        	PushFollow(FOLLOW_direct_abstract_declarator_in_synpred62_C927);
        	direct_abstract_declarator();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred62_C"

    // $ANTLR start "synpred65_C"
    public void synpred65_C_fragment() {
        // C.g:265:65: ( abstract_declarator_suffix )
        // C.g:265:65: abstract_declarator_suffix
        {
        	PushFollow(FOLLOW_abstract_declarator_suffix_in_synpred65_C958);
        	abstract_declarator_suffix();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred65_C"

    // $ANTLR start "synpred78_C"
    public void synpred78_C_fragment() {
        // C.g:299:4: ( '(' type_name ')' cast_expression )
        // C.g:299:4: '(' type_name ')' cast_expression
        {
        	Match(input,48,FOLLOW_48_in_synpred78_C1130); if (state.failed) return ;
        	PushFollow(FOLLOW_type_name_in_synpred78_C1132);
        	type_name();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	Match(input,49,FOLLOW_49_in_synpred78_C1134); if (state.failed) return ;
        	PushFollow(FOLLOW_cast_expression_in_synpred78_C1136);
        	cast_expression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred78_C"

    // $ANTLR start "synpred83_C"
    public void synpred83_C_fragment() {
        // C.g:308:4: ( 'sizeof' unary_expression )
        // C.g:308:4: 'sizeof' unary_expression
        {
        	Match(input,60,FOLLOW_60_in_synpred83_C1178); if (state.failed) return ;
        	PushFollow(FOLLOW_unary_expression_in_synpred83_C1180);
        	unary_expression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred83_C"

    // $ANTLR start "synpred104_C"
    public void synpred104_C_fragment() {
        // C.g:359:4: ( lvalue assignment_operator assignment_expression )
        // C.g:359:4: lvalue assignment_operator assignment_expression
        {
        	PushFollow(FOLLOW_lvalue_in_synpred104_C1492);
        	lvalue();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	PushFollow(FOLLOW_assignment_operator_in_synpred104_C1494);
        	assignment_operator();
        	state.followingStackPointer--;
        	if (state.failed) return ;
        	PushFollow(FOLLOW_assignment_expression_in_synpred104_C1496);
        	assignment_expression();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred104_C"

    // $ANTLR start "synpred136_C"
    public void synpred136_C_fragment() {
        // C.g:438:8: ( declaration )
        // C.g:438:8: declaration
        {
        	PushFollow(FOLLOW_declaration_in_synpred136_C1852);
        	declaration();
        	state.followingStackPointer--;
        	if (state.failed) return ;

        }
    }
    // $ANTLR end "synpred136_C"

    // Delegated rules

   	public bool synpred65_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred65_C_fragment(); // can never throw exception
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
   	public bool synpred47_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred47_C_fragment(); // can never throw exception
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
   	public bool synpred2_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred2_C_fragment(); // can never throw exception
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
   	public bool synpred136_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred136_C_fragment(); // can never throw exception
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
   	public bool synpred50_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred50_C_fragment(); // can never throw exception
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
   	public bool synpred62_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred62_C_fragment(); // can never throw exception
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
   	public bool synpred5_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred5_C_fragment(); // can never throw exception
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
   	public bool synpred35_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred35_C_fragment(); // can never throw exception
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
   	public bool synpred104_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred104_C_fragment(); // can never throw exception
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
   	public bool synpred55_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred55_C_fragment(); // can never throw exception
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
   	public bool synpred45_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred45_C_fragment(); // can never throw exception
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
   	public bool synpred51_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred51_C_fragment(); // can never throw exception
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
   	public bool synpred54_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred54_C_fragment(); // can never throw exception
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
   	public bool synpred78_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred78_C_fragment(); // can never throw exception
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
   	public bool synpred12_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred12_C_fragment(); // can never throw exception
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
   	public bool synpred59_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred59_C_fragment(); // can never throw exception
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
   	public bool synpred58_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred58_C_fragment(); // can never throw exception
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
   	public bool synpred52_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred52_C_fragment(); // can never throw exception
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
   	public bool synpred4_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred4_C_fragment(); // can never throw exception
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
   	public bool synpred8_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred8_C_fragment(); // can never throw exception
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
   	public bool synpred83_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred83_C_fragment(); // can never throw exception
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
   	public bool synpred53_C() 
   	{
   	    state.backtracking++;
   	    int start = input.Mark();
   	    try 
   	    {
   	        synpred53_C_fragment(); // can never throw exception
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


   	protected DFA1 dfa1;
   	protected DFA2 dfa2;
   	protected DFA3 dfa3;
   	protected DFA5 dfa5;
   	protected DFA4 dfa4;
   	protected DFA8 dfa8;
   	protected DFA6 dfa6;
   	protected DFA9 dfa9;
   	protected DFA12 dfa12;
   	protected DFA14 dfa14;
   	protected DFA15 dfa15;
   	protected DFA16 dfa16;
   	protected DFA20 dfa20;
   	protected DFA24 dfa24;
   	protected DFA26 dfa26;
   	protected DFA27 dfa27;
   	protected DFA30 dfa30;
   	protected DFA28 dfa28;
   	protected DFA29 dfa29;
   	protected DFA32 dfa32;
   	protected DFA33 dfa33;
   	protected DFA36 dfa36;
   	protected DFA38 dfa38;
   	protected DFA39 dfa39;
   	protected DFA40 dfa40;
   	protected DFA43 dfa43;
   	protected DFA45 dfa45;
   	protected DFA46 dfa46;
   	protected DFA47 dfa47;
   	protected DFA48 dfa48;
   	protected DFA49 dfa49;
   	protected DFA52 dfa52;
   	protected DFA54 dfa54;
   	protected DFA55 dfa55;
   	protected DFA56 dfa56;
   	protected DFA57 dfa57;
   	protected DFA58 dfa58;
   	protected DFA59 dfa59;
   	protected DFA60 dfa60;
   	protected DFA61 dfa61;
   	protected DFA62 dfa62;
   	protected DFA64 dfa64;
   	protected DFA65 dfa65;
   	protected DFA66 dfa66;
   	protected DFA72 dfa72;
   	protected DFA73 dfa73;
   	protected DFA74 dfa74;
	private void InitializeCyclicDFAs()
	{
    	this.dfa1 = new DFA1(this);
    	this.dfa2 = new DFA2(this);
    	this.dfa3 = new DFA3(this);
    	this.dfa5 = new DFA5(this);
    	this.dfa4 = new DFA4(this);
    	this.dfa8 = new DFA8(this);
    	this.dfa6 = new DFA6(this);
    	this.dfa9 = new DFA9(this);
    	this.dfa12 = new DFA12(this);
    	this.dfa14 = new DFA14(this);
    	this.dfa15 = new DFA15(this);
    	this.dfa16 = new DFA16(this);
    	this.dfa20 = new DFA20(this);
    	this.dfa24 = new DFA24(this);
    	this.dfa26 = new DFA26(this);
    	this.dfa27 = new DFA27(this);
    	this.dfa30 = new DFA30(this);
    	this.dfa28 = new DFA28(this);
    	this.dfa29 = new DFA29(this);
    	this.dfa32 = new DFA32(this);
    	this.dfa33 = new DFA33(this);
    	this.dfa36 = new DFA36(this);
    	this.dfa38 = new DFA38(this);
    	this.dfa39 = new DFA39(this);
    	this.dfa40 = new DFA40(this);
    	this.dfa43 = new DFA43(this);
    	this.dfa45 = new DFA45(this);
    	this.dfa46 = new DFA46(this);
    	this.dfa47 = new DFA47(this);
    	this.dfa48 = new DFA48(this);
    	this.dfa49 = new DFA49(this);
    	this.dfa52 = new DFA52(this);
    	this.dfa54 = new DFA54(this);
    	this.dfa55 = new DFA55(this);
    	this.dfa56 = new DFA56(this);
    	this.dfa57 = new DFA57(this);
    	this.dfa58 = new DFA58(this);
    	this.dfa59 = new DFA59(this);
    	this.dfa60 = new DFA60(this);
    	this.dfa61 = new DFA61(this);
    	this.dfa62 = new DFA62(this);
    	this.dfa64 = new DFA64(this);
    	this.dfa65 = new DFA65(this);
    	this.dfa66 = new DFA66(this);
    	this.dfa72 = new DFA72(this);
    	this.dfa73 = new DFA73(this);
    	this.dfa74 = new DFA74(this);
	    this.dfa2.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA2_SpecialStateTransition);
	    this.dfa3.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA3_SpecialStateTransition);
	    this.dfa6.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA6_SpecialStateTransition);
	    this.dfa9.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA9_SpecialStateTransition);
	    this.dfa16.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA16_SpecialStateTransition);
	    this.dfa24.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA24_SpecialStateTransition);
	    this.dfa26.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA26_SpecialStateTransition);
	    this.dfa27.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA27_SpecialStateTransition);
	    this.dfa30.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA30_SpecialStateTransition);
	    this.dfa28.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA28_SpecialStateTransition);
	    this.dfa29.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA29_SpecialStateTransition);
	    this.dfa33.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA33_SpecialStateTransition);
	    this.dfa36.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA36_SpecialStateTransition);
	    this.dfa39.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA39_SpecialStateTransition);
	    this.dfa47.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA47_SpecialStateTransition);
	    this.dfa48.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA48_SpecialStateTransition);
	    this.dfa52.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA52_SpecialStateTransition);
	    this.dfa64.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA64_SpecialStateTransition);
	    this.dfa73.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA73_SpecialStateTransition);
	}

    const string DFA1_eotS =
        "\x13\uffff";
    const string DFA1_eofS =
        "\x01\x01\x12\uffff";
    const string DFA1_minS =
        "\x01\x04\x12\uffff";
    const string DFA1_maxS =
        "\x01\x34\x12\uffff";
    const string DFA1_acceptS =
        "\x01\uffff\x01\x02\x01\x01\x10\uffff";
    const string DFA1_specialS =
        "\x13\uffff}>";
    static readonly string[] DFA1_transitionS = {
            "\x01\x02\x12\uffff\x01\x02\x03\uffff\x0d\x02\x02\uffff\x02"+
            "\x02\x01\uffff\x04\x02\x03\uffff\x01\x02",
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

    static readonly short[] DFA1_eot = DFA.UnpackEncodedString(DFA1_eotS);
    static readonly short[] DFA1_eof = DFA.UnpackEncodedString(DFA1_eofS);
    static readonly char[] DFA1_min = DFA.UnpackEncodedStringToUnsignedChars(DFA1_minS);
    static readonly char[] DFA1_max = DFA.UnpackEncodedStringToUnsignedChars(DFA1_maxS);
    static readonly short[] DFA1_accept = DFA.UnpackEncodedString(DFA1_acceptS);
    static readonly short[] DFA1_special = DFA.UnpackEncodedString(DFA1_specialS);
    static readonly short[][] DFA1_transition = DFA.UnpackEncodedStringArray(DFA1_transitionS);

    protected class DFA1 : DFA
    {
        public DFA1(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 1;
            this.eot = DFA1_eot;
            this.eof = DFA1_eof;
            this.min = DFA1_min;
            this.max = DFA1_max;
            this.accept = DFA1_accept;
            this.special = DFA1_special;
            this.transition = DFA1_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 63:4: ( external_declaration )+"; }
        }

    }

    const string DFA2_eotS =
        "\x12\uffff";
    const string DFA2_eofS =
        "\x12\uffff";
    const string DFA2_minS =
        "\x01\x04\x0e\x00\x03\uffff";
    const string DFA2_maxS =
        "\x01\x34\x0e\x00\x03\uffff";
    const string DFA2_acceptS =
        "\x0f\uffff\x02\x01\x01\x02";
    const string DFA2_specialS =
        "\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07"+
        "\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x03\uffff}>";
    static readonly string[] DFA2_transitionS = {
            "\x01\x0d\x12\uffff\x01\x11\x03\uffff\x04\x01\x01\x02\x01\x03"+
            "\x01\x04\x01\x05\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x02"+
            "\uffff\x02\x0b\x01\uffff\x01\x0c\x02\x0e\x01\x10\x03\uffff\x01"+
            "\x0f",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            "",
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
            get { return "66:1: external_declaration options {k=1; } : ( ( ( declaration_specifiers )? declarator ( declaration )* '{' )=> function_definition | declaration );"; }
        }

    }


    protected internal int DFA2_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA2_0 = input.LA(1);

                   	 
                   	int index2_0 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((LA2_0 >= 27 && LA2_0 <= 30)) ) { s = 1; }

                   	else if ( (LA2_0 == 31) ) { s = 2; }

                   	else if ( (LA2_0 == 32) ) { s = 3; }

                   	else if ( (LA2_0 == 33) ) { s = 4; }

                   	else if ( (LA2_0 == 34) ) { s = 5; }

                   	else if ( (LA2_0 == 35) ) { s = 6; }

                   	else if ( (LA2_0 == 36) ) { s = 7; }

                   	else if ( (LA2_0 == 37) ) { s = 8; }

                   	else if ( (LA2_0 == 38) ) { s = 9; }

                   	else if ( (LA2_0 == 39) ) { s = 10; }

                   	else if ( ((LA2_0 >= 42 && LA2_0 <= 43)) ) { s = 11; }

                   	else if ( (LA2_0 == 45) ) { s = 12; }

                   	else if ( (LA2_0 == IDENTIFIER) ) { s = 13; }

                   	else if ( ((LA2_0 >= 46 && LA2_0 <= 47)) ) { s = 14; }

                   	else if ( (LA2_0 == 52) && (synpred4_C()) ) { s = 15; }

                   	else if ( (LA2_0 == 48) && (synpred4_C()) ) { s = 16; }

                   	else if ( (LA2_0 == 23) ) { s = 17; }

                   	 
                   	input.Seek(index2_0);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA2_1 = input.LA(1);

                   	 
                   	int index2_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_1);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA2_2 = input.LA(1);

                   	 
                   	int index2_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_2);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA2_3 = input.LA(1);

                   	 
                   	int index2_3 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_3);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA2_4 = input.LA(1);

                   	 
                   	int index2_4 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_4);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA2_5 = input.LA(1);

                   	 
                   	int index2_5 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_5);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA2_6 = input.LA(1);

                   	 
                   	int index2_6 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_6);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA2_7 = input.LA(1);

                   	 
                   	int index2_7 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_7);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA2_8 = input.LA(1);

                   	 
                   	int index2_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_8);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA2_9 = input.LA(1);

                   	 
                   	int index2_9 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_9);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA2_10 = input.LA(1);

                   	 
                   	int index2_10 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_10);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA2_11 = input.LA(1);

                   	 
                   	int index2_11 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_11);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA2_12 = input.LA(1);

                   	 
                   	int index2_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_12);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA2_13 = input.LA(1);

                   	 
                   	int index2_13 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (((synpred4_C() && (isTypeName(input.LT(1).getText())))|| synpred4_C())) ) { s = 16; }

                   	else if ( ((isTypeName(input.LT(1).getText()))) ) { s = 17; }

                   	 
                   	input.Seek(index2_13);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA2_14 = input.LA(1);

                   	 
                   	int index2_14 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred4_C()) ) { s = 16; }

                   	else if ( (true) ) { s = 17; }

                   	 
                   	input.Seek(index2_14);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae2 =
            new NoViableAltException(dfa.Description, 2, _s, input);
        dfa.Error(nvae2);
        throw nvae2;
    }
    const string DFA3_eotS =
        "\x24\uffff";
    const string DFA3_eofS =
        "\x24\uffff";
    const string DFA3_minS =
        "\x01\x04\x0c\uffff\x01\x04\x04\uffff\x01\x00\x01\uffff\x0e\x00"+
        "\x02\uffff";
    const string DFA3_maxS =
        "\x01\x34\x0c\uffff\x01\x34\x04\uffff\x01\x00\x01\uffff\x0e\x00"+
        "\x02\uffff";
    const string DFA3_acceptS =
        "\x01\uffff\x01\x01\x0d\uffff\x01\x02\x14\uffff";
    const string DFA3_specialS =
        "\x12\uffff\x01\x00\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01"+
        "\x05\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01"+
        "\x0d\x01\x0e\x02\uffff}>";
    static readonly string[] DFA3_transitionS = {
            "\x01\x0d\x16\uffff\x0d\x01\x02\uffff\x02\x01\x01\uffff\x03"+
            "\x01\x01\x0f\x03\uffff\x01\x0f",
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
            "\x01\x20\x12\uffff\x01\x0f\x03\uffff\x04\x14\x01\x15\x01\x16"+
            "\x01\x17\x01\x18\x01\x19\x01\x1a\x01\x1b\x01\x1c\x01\x1d\x01"+
            "\x0f\x01\uffff\x02\x1e\x01\uffff\x01\x1f\x02\x21\x01\x12\x01"+
            "\uffff\x01\x0f\x01\uffff\x01\x01",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
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

    static readonly short[] DFA3_eot = DFA.UnpackEncodedString(DFA3_eotS);
    static readonly short[] DFA3_eof = DFA.UnpackEncodedString(DFA3_eofS);
    static readonly char[] DFA3_min = DFA.UnpackEncodedStringToUnsignedChars(DFA3_minS);
    static readonly char[] DFA3_max = DFA.UnpackEncodedStringToUnsignedChars(DFA3_maxS);
    static readonly short[] DFA3_accept = DFA.UnpackEncodedString(DFA3_acceptS);
    static readonly short[] DFA3_special = DFA.UnpackEncodedString(DFA3_specialS);
    static readonly short[][] DFA3_transition = DFA.UnpackEncodedStringArray(DFA3_transitionS);

    protected class DFA3 : DFA
    {
        public DFA3(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 3;
            this.eot = DFA3_eot;
            this.eof = DFA3_eof;
            this.min = DFA3_min;
            this.max = DFA3_max;
            this.accept = DFA3_accept;
            this.special = DFA3_special;
            this.transition = DFA3_transition;

        }

        override public string Description
        {
            get { return "91:4: ( declaration_specifiers )?"; }
        }

    }


    protected internal int DFA3_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA3_18 = input.LA(1);

                   	 
                   	int index3_18 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_18);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA3_20 = input.LA(1);

                   	 
                   	int index3_20 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_20);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA3_21 = input.LA(1);

                   	 
                   	int index3_21 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_21);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA3_22 = input.LA(1);

                   	 
                   	int index3_22 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_22);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA3_23 = input.LA(1);

                   	 
                   	int index3_23 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_23);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA3_24 = input.LA(1);

                   	 
                   	int index3_24 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_24);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA3_25 = input.LA(1);

                   	 
                   	int index3_25 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_25);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA3_26 = input.LA(1);

                   	 
                   	int index3_26 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_26);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA3_27 = input.LA(1);

                   	 
                   	int index3_27 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_27);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA3_28 = input.LA(1);

                   	 
                   	int index3_28 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_28);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA3_29 = input.LA(1);

                   	 
                   	int index3_29 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_29);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA3_30 = input.LA(1);

                   	 
                   	int index3_30 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_30);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA3_31 = input.LA(1);

                   	 
                   	int index3_31 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_31);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA3_32 = input.LA(1);

                   	 
                   	int index3_32 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_32);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA3_33 = input.LA(1);

                   	 
                   	int index3_33 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred5_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index3_33);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae3 =
            new NoViableAltException(dfa.Description, 3, _s, input);
        dfa.Error(nvae3);
        throw nvae3;
    }
    const string DFA5_eotS =
        "\x11\uffff";
    const string DFA5_eofS =
        "\x11\uffff";
    const string DFA5_minS =
        "\x01\x04\x10\uffff";
    const string DFA5_maxS =
        "\x01\x2f\x10\uffff";
    const string DFA5_acceptS =
        "\x01\uffff\x01\x01\x0e\uffff\x01\x02";
    const string DFA5_specialS =
        "\x11\uffff}>";
    static readonly string[] DFA5_transitionS = {
            "\x01\x01\x12\uffff\x01\x01\x03\uffff\x0d\x01\x01\x10\x01\uffff"+
            "\x02\x01\x01\uffff\x03\x01",
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
            get { return "92:3: ( ( declaration )+ compound_statement | compound_statement )"; }
        }

    }

    const string DFA4_eotS =
        "\x11\uffff";
    const string DFA4_eofS =
        "\x11\uffff";
    const string DFA4_minS =
        "\x01\x04\x10\uffff";
    const string DFA4_maxS =
        "\x01\x2f\x10\uffff";
    const string DFA4_acceptS =
        "\x01\uffff\x01\x02\x01\x01\x0e\uffff";
    const string DFA4_specialS =
        "\x11\uffff}>";
    static readonly string[] DFA4_transitionS = {
            "\x01\x02\x12\uffff\x01\x02\x03\uffff\x0d\x02\x01\x01\x01\uffff"+
            "\x02\x02\x01\uffff\x03\x02",
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
            get { return "()+ loopback of 92:5: ( declaration )+"; }
        }

    }

    const string DFA8_eotS =
        "\x10\uffff";
    const string DFA8_eofS =
        "\x10\uffff";
    const string DFA8_minS =
        "\x01\x04\x0f\uffff";
    const string DFA8_maxS =
        "\x01\x2f\x0f\uffff";
    const string DFA8_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x0d\uffff";
    const string DFA8_specialS =
        "\x10\uffff}>";
    static readonly string[] DFA8_transitionS = {
            "\x01\x02\x12\uffff\x01\x01\x03\uffff\x0d\x02\x02\uffff\x02"+
            "\x02\x01\uffff\x03\x02",
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

    static readonly short[] DFA8_eot = DFA.UnpackEncodedString(DFA8_eotS);
    static readonly short[] DFA8_eof = DFA.UnpackEncodedString(DFA8_eofS);
    static readonly char[] DFA8_min = DFA.UnpackEncodedStringToUnsignedChars(DFA8_minS);
    static readonly char[] DFA8_max = DFA.UnpackEncodedStringToUnsignedChars(DFA8_maxS);
    static readonly short[] DFA8_accept = DFA.UnpackEncodedString(DFA8_acceptS);
    static readonly short[] DFA8_special = DFA.UnpackEncodedString(DFA8_specialS);
    static readonly short[][] DFA8_transition = DFA.UnpackEncodedStringArray(DFA8_transitionS);

    protected class DFA8 : DFA
    {
        public DFA8(BaseRecognizer recognizer)
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

        override public string Description
        {
            get { return "97:1: declaration : ( 'typedef' ( declaration_specifiers )? init_declarator_list ';' | declaration_specifiers ( init_declarator_list )? ';' );"; }
        }

    }

    const string DFA6_eotS =
        "\x25\uffff";
    const string DFA6_eofS =
        "\x25\uffff";
    const string DFA6_minS =
        "\x01\x04\x0c\uffff\x01\x04\x05\uffff\x01\x00\x11\uffff";
    const string DFA6_maxS =
        "\x01\x34\x0c\uffff\x01\x34\x05\uffff\x01\x00\x11\uffff";
    const string DFA6_acceptS =
        "\x01\uffff\x01\x01\x0d\uffff\x01\x02\x15\uffff";
    const string DFA6_specialS =
        "\x13\uffff\x01\x00\x11\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x0d\x16\uffff\x0d\x01\x02\uffff\x02\x01\x01\uffff\x03"+
            "\x01\x01\x0f\x03\uffff\x01\x0f",
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
            "\x01\x01\x13\uffff\x03\x0f\x0d\x01\x02\uffff\x02\x01\x01\uffff"+
            "\x03\x01\x01\x13\x01\uffff\x01\x0f\x01\uffff\x01\x01",
            "",
            "",
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
            ""
    };

    static readonly short[] DFA6_eot = DFA.UnpackEncodedString(DFA6_eotS);
    static readonly short[] DFA6_eof = DFA.UnpackEncodedString(DFA6_eofS);
    static readonly char[] DFA6_min = DFA.UnpackEncodedStringToUnsignedChars(DFA6_minS);
    static readonly char[] DFA6_max = DFA.UnpackEncodedStringToUnsignedChars(DFA6_maxS);
    static readonly short[] DFA6_accept = DFA.UnpackEncodedString(DFA6_acceptS);
    static readonly short[] DFA6_special = DFA.UnpackEncodedString(DFA6_specialS);
    static readonly short[][] DFA6_transition = DFA.UnpackEncodedStringArray(DFA6_transitionS);

    protected class DFA6 : DFA
    {
        public DFA6(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 6;
            this.eot = DFA6_eot;
            this.eof = DFA6_eof;
            this.min = DFA6_min;
            this.max = DFA6_max;
            this.accept = DFA6_accept;
            this.special = DFA6_special;
            this.transition = DFA6_transition;

        }

        override public string Description
        {
            get { return "104:14: ( declaration_specifiers )?"; }
        }

    }


    protected internal int DFA6_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA6_19 = input.LA(1);

                   	 
                   	int index6_19 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred8_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index6_19);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae6 =
            new NoViableAltException(dfa.Description, 6, _s, input);
        dfa.Error(nvae6);
        throw nvae6;
    }
    const string DFA9_eotS =
        "\x2e\uffff";
    const string DFA9_eofS =
        "\x01\x01\x2d\uffff";
    const string DFA9_minS =
        "\x01\x04\x01\uffff\x01\x00\x2b\uffff";
    const string DFA9_maxS =
        "\x01\x34\x01\uffff\x01\x00\x2b\uffff";
    const string DFA9_acceptS =
        "\x01\uffff\x01\x04\x07\uffff\x01\x01\x01\x02\x0a\uffff\x01\x03"+
        "\x18\uffff";
    const string DFA9_specialS =
        "\x02\uffff\x01\x00\x2b\uffff}>";
    static readonly string[] DFA9_transitionS = {
            "\x01\x02\x13\uffff\x02\x01\x01\uffff\x04\x09\x09\x0a\x02\uffff"+
            "\x02\x0a\x01\uffff\x01\x0a\x02\x15\x03\x01\x01\uffff\x01\x01",
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
            get { return "()+ loopback of 110:6: ( storage_class_specifier | type_specifier | type_qualifier )+"; }
        }

    }


    protected internal int DFA9_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA9_2 = input.LA(1);

                   	 
                   	int index9_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred12_C() && (isTypeName(input.LT(1).getText())))) ) { s = 10; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index9_2);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae9 =
            new NoViableAltException(dfa.Description, 9, _s, input);
        dfa.Error(nvae9);
        throw nvae9;
    }
    const string DFA12_eotS =
        "\x0d\uffff";
    const string DFA12_eofS =
        "\x0d\uffff";
    const string DFA12_minS =
        "\x01\x04\x0c\uffff";
    const string DFA12_maxS =
        "\x01\x2d\x0c\uffff";
    const string DFA12_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c";
    const string DFA12_specialS =
        "\x0d\uffff}>";
    static readonly string[] DFA12_transitionS = {
            "\x01\x0c\x1a\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05"+
            "\x01\x06\x01\x07\x01\x08\x01\x09\x02\uffff\x02\x0a\x01\uffff"+
            "\x01\x0b",
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

    static readonly short[] DFA12_eot = DFA.UnpackEncodedString(DFA12_eotS);
    static readonly short[] DFA12_eof = DFA.UnpackEncodedString(DFA12_eofS);
    static readonly char[] DFA12_min = DFA.UnpackEncodedStringToUnsignedChars(DFA12_minS);
    static readonly char[] DFA12_max = DFA.UnpackEncodedStringToUnsignedChars(DFA12_maxS);
    static readonly short[] DFA12_accept = DFA.UnpackEncodedString(DFA12_acceptS);
    static readonly short[] DFA12_special = DFA.UnpackEncodedString(DFA12_specialS);
    static readonly short[][] DFA12_transition = DFA.UnpackEncodedStringArray(DFA12_transitionS);

    protected class DFA12 : DFA
    {
        public DFA12(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 12;
            this.eot = DFA12_eot;
            this.eof = DFA12_eof;
            this.min = DFA12_min;
            this.max = DFA12_max;
            this.accept = DFA12_accept;
            this.special = DFA12_special;
            this.transition = DFA12_transition;

        }

        override public string Description
        {
            get { return "131:1: type_specifier : ( 'void' | 'char' | 'short' | 'int' | 'long' | 'float' | 'double' | 'signed' | 'unsigned' | struct_or_union_specifier | enum_specifier | type_id );"; }
        }

    }

    const string DFA14_eotS =
        "\x1b\uffff";
    const string DFA14_eofS =
        "\x02\uffff\x01\x05\x18\uffff";
    const string DFA14_minS =
        "\x01\x2a\x02\x04\x18\uffff";
    const string DFA14_maxS =
        "\x01\x2b\x01\x28\x01\x34\x18\uffff";
    const string DFA14_acceptS =
        "\x03\uffff\x01\x01\x01\uffff\x01\x02\x15\uffff";
    const string DFA14_specialS =
        "\x1b\uffff}>";
    static readonly string[] DFA14_transitionS = {
            "\x02\x01",
            "\x01\x02\x23\uffff\x01\x03",
            "\x01\x05\x13\uffff\x02\x05\x01\uffff\x0d\x05\x01\x03\x01\uffff"+
            "\x09\x05\x01\uffff\x01\x05",
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

    static readonly short[] DFA14_eot = DFA.UnpackEncodedString(DFA14_eotS);
    static readonly short[] DFA14_eof = DFA.UnpackEncodedString(DFA14_eofS);
    static readonly char[] DFA14_min = DFA.UnpackEncodedStringToUnsignedChars(DFA14_minS);
    static readonly char[] DFA14_max = DFA.UnpackEncodedStringToUnsignedChars(DFA14_maxS);
    static readonly short[] DFA14_accept = DFA.UnpackEncodedString(DFA14_acceptS);
    static readonly short[] DFA14_special = DFA.UnpackEncodedString(DFA14_specialS);
    static readonly short[][] DFA14_transition = DFA.UnpackEncodedStringArray(DFA14_transitionS);

    protected class DFA14 : DFA
    {
        public DFA14(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 14;
            this.eot = DFA14_eot;
            this.eof = DFA14_eof;
            this.min = DFA14_min;
            this.max = DFA14_max;
            this.accept = DFA14_accept;
            this.special = DFA14_special;
            this.transition = DFA14_transition;

        }

        override public string Description
        {
            get { return "151:1: struct_or_union_specifier options {k=3; } : ( struct_or_union ( IDENTIFIER )? '{' struct_declaration_list '}' | struct_or_union IDENTIFIER );"; }
        }

    }

    const string DFA15_eotS =
        "\x0f\uffff";
    const string DFA15_eofS =
        "\x0f\uffff";
    const string DFA15_minS =
        "\x01\x04\x0e\uffff";
    const string DFA15_maxS =
        "\x01\x2f\x0e\uffff";
    const string DFA15_acceptS =
        "\x01\uffff\x01\x02\x01\x01\x0c\uffff";
    const string DFA15_specialS =
        "\x0f\uffff}>";
    static readonly string[] DFA15_transitionS = {
            "\x01\x02\x1a\uffff\x09\x02\x01\uffff\x01\x01\x02\x02\x01\uffff"+
            "\x03\x02",
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

    static readonly short[] DFA15_eot = DFA.UnpackEncodedString(DFA15_eotS);
    static readonly short[] DFA15_eof = DFA.UnpackEncodedString(DFA15_eofS);
    static readonly char[] DFA15_min = DFA.UnpackEncodedStringToUnsignedChars(DFA15_minS);
    static readonly char[] DFA15_max = DFA.UnpackEncodedStringToUnsignedChars(DFA15_maxS);
    static readonly short[] DFA15_accept = DFA.UnpackEncodedString(DFA15_acceptS);
    static readonly short[] DFA15_special = DFA.UnpackEncodedString(DFA15_specialS);
    static readonly short[][] DFA15_transition = DFA.UnpackEncodedStringArray(DFA15_transitionS);

    protected class DFA15 : DFA
    {
        public DFA15(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 15;
            this.eot = DFA15_eot;
            this.eof = DFA15_eof;
            this.min = DFA15_min;
            this.max = DFA15_max;
            this.accept = DFA15_accept;
            this.special = DFA15_special;
            this.transition = DFA15_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 167:4: ( struct_declaration )+"; }
        }

    }

    const string DFA16_eotS =
        "\x27\uffff";
    const string DFA16_eofS =
        "\x27\uffff";
    const string DFA16_minS =
        "\x01\x04\x01\uffff\x01\x04\x12\uffff\x03\x00\x0f\uffff";
    const string DFA16_maxS =
        "\x01\x34\x01\uffff\x01\x34\x12\uffff\x03\x00\x0f\uffff";
    const string DFA16_acceptS =
        "\x01\uffff\x01\x03\x05\uffff\x01\x01\x01\x02\x1e\uffff";
    const string DFA16_specialS =
        "\x15\uffff\x01\x00\x01\x01\x01\x02\x0f\uffff}>";
    static readonly string[] DFA16_transitionS = {
            "\x01\x02\x1a\uffff\x09\x08\x02\uffff\x02\x08\x01\x01\x01\x08"+
            "\x02\x07\x03\x01\x01\uffff\x01\x01",
            "",
            "\x01\x08\x13\uffff\x02\x01\x05\uffff\x09\x08\x02\uffff\x02"+
            "\x08\x01\x16\x03\x08\x01\x15\x01\x08\x01\x17\x01\uffff\x01\x08",
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
            "\x01\uffff",
            "\x01\uffff",
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
            get { return "()+ loopback of 175:4: ( type_qualifier | type_specifier )+"; }
        }

    }


    protected internal int DFA16_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA16_21 = input.LA(1);

                   	 
                   	int index16_21 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred35_C() && (isTypeName(input.LT(1).getText())))) ) { s = 8; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index16_21);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA16_22 = input.LA(1);

                   	 
                   	int index16_22 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred35_C() && (isTypeName(input.LT(1).getText())))) ) { s = 8; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index16_22);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA16_23 = input.LA(1);

                   	 
                   	int index16_23 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred35_C() && (isTypeName(input.LT(1).getText())))) ) { s = 8; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index16_23);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae16 =
            new NoViableAltException(dfa.Description, 16, _s, input);
        dfa.Error(nvae16);
        throw nvae16;
    }
    const string DFA20_eotS =
        "\x1b\uffff";
    const string DFA20_eofS =
        "\x03\uffff\x01\x05\x17\uffff";
    const string DFA20_minS =
        "\x01\x2d\x01\x04\x01\uffff\x01\x04\x17\uffff";
    const string DFA20_maxS =
        "\x01\x2d\x01\x28\x01\uffff\x01\x34\x17\uffff";
    const string DFA20_acceptS =
        "\x02\uffff\x01\x01\x01\uffff\x01\x02\x01\x03\x15\uffff";
    const string DFA20_specialS =
        "\x1b\uffff}>";
    static readonly string[] DFA20_transitionS = {
            "\x01\x01",
            "\x01\x03\x23\uffff\x01\x02",
            "",
            "\x01\x05\x13\uffff\x02\x05\x01\uffff\x0d\x05\x01\x04\x01\uffff"+
            "\x09\x05\x01\uffff\x01\x05",
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

    static readonly short[] DFA20_eot = DFA.UnpackEncodedString(DFA20_eotS);
    static readonly short[] DFA20_eof = DFA.UnpackEncodedString(DFA20_eofS);
    static readonly char[] DFA20_min = DFA.UnpackEncodedStringToUnsignedChars(DFA20_minS);
    static readonly char[] DFA20_max = DFA.UnpackEncodedStringToUnsignedChars(DFA20_maxS);
    static readonly short[] DFA20_accept = DFA.UnpackEncodedString(DFA20_acceptS);
    static readonly short[] DFA20_special = DFA.UnpackEncodedString(DFA20_specialS);
    static readonly short[][] DFA20_transition = DFA.UnpackEncodedStringArray(DFA20_transitionS);

    protected class DFA20 : DFA
    {
        public DFA20(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 20;
            this.eot = DFA20_eot;
            this.eof = DFA20_eof;
            this.min = DFA20_min;
            this.max = DFA20_max;
            this.accept = DFA20_accept;
            this.special = DFA20_special;
            this.transition = DFA20_transition;

        }

        override public string Description
        {
            get { return "187:1: enum_specifier options {k=3; } : ( 'enum' '{' enumerator_list '}' | 'enum' IDENTIFIER '{' enumerator_list '}' | 'enum' IDENTIFIER );"; }
        }

    }

    const string DFA24_eotS =
        "\x1e\uffff";
    const string DFA24_eofS =
        "\x1e\uffff";
    const string DFA24_minS =
        "\x01\x04\x01\x00\x1c\uffff";
    const string DFA24_maxS =
        "\x01\x34\x01\x00\x1c\uffff";
    const string DFA24_acceptS =
        "\x02\uffff\x01\x01\x1a\uffff\x01\x02";
    const string DFA24_specialS =
        "\x01\uffff\x01\x00\x1c\uffff}>";
    static readonly string[] DFA24_transitionS = {
            "\x01\x02\x2b\uffff\x01\x02\x03\uffff\x01\x01",
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
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA24_eot = DFA.UnpackEncodedString(DFA24_eotS);
    static readonly short[] DFA24_eof = DFA.UnpackEncodedString(DFA24_eofS);
    static readonly char[] DFA24_min = DFA.UnpackEncodedStringToUnsignedChars(DFA24_minS);
    static readonly char[] DFA24_max = DFA.UnpackEncodedStringToUnsignedChars(DFA24_maxS);
    static readonly short[] DFA24_accept = DFA.UnpackEncodedString(DFA24_acceptS);
    static readonly short[] DFA24_special = DFA.UnpackEncodedString(DFA24_specialS);
    static readonly short[][] DFA24_transition = DFA.UnpackEncodedStringArray(DFA24_transitionS);

    protected class DFA24 : DFA
    {
        public DFA24(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 24;
            this.eot = DFA24_eot;
            this.eof = DFA24_eof;
            this.min = DFA24_min;
            this.max = DFA24_max;
            this.accept = DFA24_accept;
            this.special = DFA24_special;
            this.transition = DFA24_transition;

        }

        override public string Description
        {
            get { return "207:1: declarator : ( ( pointer )? direct_declarator | pointer );"; }
        }

    }


    protected internal int DFA24_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA24_1 = input.LA(1);

                   	 
                   	int index24_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred45_C()) ) { s = 2; }

                   	else if ( (true) ) { s = 29; }

                   	 
                   	input.Seek(index24_1);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae24 =
            new NoViableAltException(dfa.Description, 24, _s, input);
        dfa.Error(nvae24);
        throw nvae24;
    }
    const string DFA26_eotS =
        "\x35\uffff";
    const string DFA26_eofS =
        "\x01\x01\x34\uffff";
    const string DFA26_minS =
        "\x01\x04\x17\uffff\x02\x04\x0f\x00\x03\uffff\x08\x00\x01\uffff";
    const string DFA26_maxS =
        "\x01\x34\x17\uffff\x01\x34\x01\x41\x0f\x00\x03\uffff\x08\x00\x01"+
        "\uffff";
    const string DFA26_acceptS =
        "\x01\uffff\x01\x02\x32\uffff\x01\x01";
    const string DFA26_specialS =
        "\x1a\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
        "\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01"+
        "\x0e\x03\uffff\x01\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01"+
        "\x15\x01\x16\x01\uffff}>";
    static readonly string[] DFA26_transitionS = {
            "\x01\x01\x12\uffff\x12\x01\x01\uffff\x06\x01\x01\x18\x01\x01"+
            "\x01\x19\x01\uffff\x01\x01",
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
            "\x01\x27\x16\uffff\x04\x1b\x01\x1c\x01\x1d\x01\x1e\x01\x1f"+
            "\x01\x20\x01\x21\x01\x22\x01\x23\x01\x24\x02\uffff\x02\x25\x01"+
            "\uffff\x01\x26\x02\x28\x01\x01\x01\x1a\x01\x01\x01\uffff\x01"+
            "\x01",
            "\x01\x2e\x06\x2f\x25\uffff\x01\x2d\x02\uffff\x01\x2c\x01\x32"+
            "\x01\uffff\x02\x32\x02\uffff\x01\x30\x01\x31\x01\x33\x02\uffff"+
            "\x03\x32",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
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
            get { return "()* loopback of 222:9: ( declarator_suffix )*"; }
        }

    }


    protected internal int DFA26_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA26_26 = input.LA(1);

                   	 
                   	int index26_26 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_26);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA26_27 = input.LA(1);

                   	 
                   	int index26_27 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_27);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA26_28 = input.LA(1);

                   	 
                   	int index26_28 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_28);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA26_29 = input.LA(1);

                   	 
                   	int index26_29 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_29);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA26_30 = input.LA(1);

                   	 
                   	int index26_30 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_30);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA26_31 = input.LA(1);

                   	 
                   	int index26_31 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_31);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA26_32 = input.LA(1);

                   	 
                   	int index26_32 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_32);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA26_33 = input.LA(1);

                   	 
                   	int index26_33 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_33);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA26_34 = input.LA(1);

                   	 
                   	int index26_34 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_34);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA26_35 = input.LA(1);

                   	 
                   	int index26_35 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_35);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA26_36 = input.LA(1);

                   	 
                   	int index26_36 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_36);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA26_37 = input.LA(1);

                   	 
                   	int index26_37 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_37);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA26_38 = input.LA(1);

                   	 
                   	int index26_38 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_38);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA26_39 = input.LA(1);

                   	 
                   	int index26_39 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_39);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA26_40 = input.LA(1);

                   	 
                   	int index26_40 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_40);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 15 : 
                   	int LA26_44 = input.LA(1);

                   	 
                   	int index26_44 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_44);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 16 : 
                   	int LA26_45 = input.LA(1);

                   	 
                   	int index26_45 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_45);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 17 : 
                   	int LA26_46 = input.LA(1);

                   	 
                   	int index26_46 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_46);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 18 : 
                   	int LA26_47 = input.LA(1);

                   	 
                   	int index26_47 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_47);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 19 : 
                   	int LA26_48 = input.LA(1);

                   	 
                   	int index26_48 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_48);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 20 : 
                   	int LA26_49 = input.LA(1);

                   	 
                   	int index26_49 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_49);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 21 : 
                   	int LA26_50 = input.LA(1);

                   	 
                   	int index26_50 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_50);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 22 : 
                   	int LA26_51 = input.LA(1);

                   	 
                   	int index26_51 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred47_C()) ) { s = 52; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index26_51);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae26 =
            new NoViableAltException(dfa.Description, 26, _s, input);
        dfa.Error(nvae26);
        throw nvae26;
    }
    const string DFA27_eotS =
        "\x1b\uffff";
    const string DFA27_eofS =
        "\x1b\uffff";
    const string DFA27_minS =
        "\x01\x30\x02\x04\x15\uffff\x01\x00\x02\uffff";
    const string DFA27_maxS =
        "\x01\x32\x01\x41\x01\x31\x15\uffff\x01\x00\x02\uffff";
    const string DFA27_acceptS =
        "\x03\uffff\x01\x02\x01\x01\x06\uffff\x01\x05\x01\x03\x0d\uffff"+
        "\x01\x04";
    const string DFA27_specialS =
        "\x18\uffff\x01\x00\x02\uffff}>";
    static readonly string[] DFA27_transitionS = {
            "\x01\x02\x01\uffff\x01\x01",
            "\x07\x04\x25\uffff\x01\x04\x02\uffff\x01\x03\x01\x04\x01\uffff"+
            "\x02\x04\x02\uffff\x03\x04\x02\uffff\x03\x04",
            "\x01\x18\x16\uffff\x0d\x0c\x02\uffff\x02\x0c\x01\uffff\x03"+
            "\x0c\x01\uffff\x01\x0b",
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
            "\x01\uffff",
            "",
            ""
    };

    static readonly short[] DFA27_eot = DFA.UnpackEncodedString(DFA27_eotS);
    static readonly short[] DFA27_eof = DFA.UnpackEncodedString(DFA27_eofS);
    static readonly char[] DFA27_min = DFA.UnpackEncodedStringToUnsignedChars(DFA27_minS);
    static readonly char[] DFA27_max = DFA.UnpackEncodedStringToUnsignedChars(DFA27_maxS);
    static readonly short[] DFA27_accept = DFA.UnpackEncodedString(DFA27_acceptS);
    static readonly short[] DFA27_special = DFA.UnpackEncodedString(DFA27_specialS);
    static readonly short[][] DFA27_transition = DFA.UnpackEncodedStringArray(DFA27_transitionS);

    protected class DFA27 : DFA
    {
        public DFA27(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 27;
            this.eot = DFA27_eot;
            this.eof = DFA27_eof;
            this.min = DFA27_min;
            this.max = DFA27_max;
            this.accept = DFA27_accept;
            this.special = DFA27_special;
            this.transition = DFA27_transition;

        }

        override public string Description
        {
            get { return "225:1: declarator_suffix : ( '[' constant_expression ']' | '[' ']' | '(' parameter_type_list ')' | '(' identifier_list ')' | '(' ')' );"; }
        }

    }


    protected internal int DFA27_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA27_24 = input.LA(1);

                   	 
                   	int index27_24 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred50_C()) ) { s = 12; }

                   	else if ( (synpred51_C()) ) { s = 26; }

                   	 
                   	input.Seek(index27_24);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae27 =
            new NoViableAltException(dfa.Description, 27, _s, input);
        dfa.Error(nvae27);
        throw nvae27;
    }
    const string DFA30_eotS =
        "\x1d\uffff";
    const string DFA30_eofS =
        "\x01\uffff\x01\x03\x1b\uffff";
    const string DFA30_minS =
        "\x01\x34\x01\x04\x01\x00\x0f\uffff\x01\x00\x0a\uffff";
    const string DFA30_maxS =
        "\x02\x34\x01\x00\x0f\uffff\x01\x00\x0a\uffff";
    const string DFA30_acceptS =
        "\x03\uffff\x01\x03\x17\uffff\x01\x02\x01\x01";
    const string DFA30_specialS =
        "\x02\uffff\x01\x00\x0f\uffff\x01\x01\x0a\uffff}>";
    static readonly string[] DFA30_transitionS = {
            "\x01\x01",
            "\x01\x03\x12\uffff\x12\x03\x01\uffff\x04\x03\x02\x12\x03\x03"+
            "\x01\uffff\x01\x02",
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
            get { return "233:1: pointer : ( '*' ( type_qualifier )+ ( pointer )? | '*' pointer | '*' );"; }
        }

    }


    protected internal int DFA30_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA30_2 = input.LA(1);

                   	 
                   	int index30_2 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred55_C()) ) { s = 27; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index30_2);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA30_18 = input.LA(1);

                   	 
                   	int index30_18 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred54_C()) ) { s = 28; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index30_18);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae30 =
            new NoViableAltException(dfa.Description, 30, _s, input);
        dfa.Error(nvae30);
        throw nvae30;
    }
    const string DFA28_eotS =
        "\x34\uffff";
    const string DFA28_eofS =
        "\x01\x01\x33\uffff";
    const string DFA28_minS =
        "\x01\x04\x10\uffff\x01\x00\x22\uffff";
    const string DFA28_maxS =
        "\x01\x34\x10\uffff\x01\x00\x22\uffff";
    const string DFA28_acceptS =
        "\x01\uffff\x01\x02\x31\uffff\x01\x01";
    const string DFA28_specialS =
        "\x11\uffff\x01\x00\x22\uffff}>";
    static readonly string[] DFA28_transitionS = {
            "\x01\x01\x12\uffff\x12\x01\x01\uffff\x04\x01\x02\x11\x03\x01"+
            "\x01\uffff\x01\x01",
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

    static readonly short[] DFA28_eot = DFA.UnpackEncodedString(DFA28_eotS);
    static readonly short[] DFA28_eof = DFA.UnpackEncodedString(DFA28_eofS);
    static readonly char[] DFA28_min = DFA.UnpackEncodedStringToUnsignedChars(DFA28_minS);
    static readonly char[] DFA28_max = DFA.UnpackEncodedStringToUnsignedChars(DFA28_maxS);
    static readonly short[] DFA28_accept = DFA.UnpackEncodedString(DFA28_acceptS);
    static readonly short[] DFA28_special = DFA.UnpackEncodedString(DFA28_specialS);
    static readonly short[][] DFA28_transition = DFA.UnpackEncodedStringArray(DFA28_transitionS);

    protected class DFA28 : DFA
    {
        public DFA28(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 28;
            this.eot = DFA28_eot;
            this.eof = DFA28_eof;
            this.min = DFA28_min;
            this.max = DFA28_max;
            this.accept = DFA28_accept;
            this.special = DFA28_special;
            this.transition = DFA28_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 234:8: ( type_qualifier )+"; }
        }

    }


    protected internal int DFA28_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA28_17 = input.LA(1);

                   	 
                   	int index28_17 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred52_C()) ) { s = 51; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index28_17);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae28 =
            new NoViableAltException(dfa.Description, 28, _s, input);
        dfa.Error(nvae28);
        throw nvae28;
    }
    const string DFA29_eotS =
        "\x34\uffff";
    const string DFA29_eofS =
        "\x01\x02\x33\uffff";
    const string DFA29_minS =
        "\x01\x04\x01\x00\x32\uffff";
    const string DFA29_maxS =
        "\x01\x34\x01\x00\x32\uffff";
    const string DFA29_acceptS =
        "\x02\uffff\x01\x02\x30\uffff\x01\x01";
    const string DFA29_specialS =
        "\x01\uffff\x01\x00\x32\uffff}>";
    static readonly string[] DFA29_transitionS = {
            "\x01\x02\x12\uffff\x12\x02\x01\uffff\x09\x02\x01\uffff\x01"+
            "\x01",
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
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA29_eot = DFA.UnpackEncodedString(DFA29_eotS);
    static readonly short[] DFA29_eof = DFA.UnpackEncodedString(DFA29_eofS);
    static readonly char[] DFA29_min = DFA.UnpackEncodedStringToUnsignedChars(DFA29_minS);
    static readonly char[] DFA29_max = DFA.UnpackEncodedStringToUnsignedChars(DFA29_maxS);
    static readonly short[] DFA29_accept = DFA.UnpackEncodedString(DFA29_acceptS);
    static readonly short[] DFA29_special = DFA.UnpackEncodedString(DFA29_specialS);
    static readonly short[][] DFA29_transition = DFA.UnpackEncodedStringArray(DFA29_transitionS);

    protected class DFA29 : DFA
    {
        public DFA29(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 29;
            this.eot = DFA29_eot;
            this.eof = DFA29_eof;
            this.min = DFA29_min;
            this.max = DFA29_max;
            this.accept = DFA29_accept;
            this.special = DFA29_special;
            this.transition = DFA29_transition;

        }

        override public string Description
        {
            get { return "234:24: ( pointer )?"; }
        }

    }


    protected internal int DFA29_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA29_1 = input.LA(1);

                   	 
                   	int index29_1 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred53_C()) ) { s = 51; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index29_1);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae29 =
            new NoViableAltException(dfa.Description, 29, _s, input);
        dfa.Error(nvae29);
        throw nvae29;
    }
    const string DFA32_eotS =
        "\x12\uffff";
    const string DFA32_eofS =
        "\x12\uffff";
    const string DFA32_minS =
        "\x01\x19\x01\x04\x10\uffff";
    const string DFA32_maxS =
        "\x01\x31\x01\x35\x10\uffff";
    const string DFA32_acceptS =
        "\x02\uffff\x01\x02\x01\uffff\x01\x01\x0d\uffff";
    const string DFA32_specialS =
        "\x12\uffff}>";
    static readonly string[] DFA32_transitionS = {
            "\x01\x01\x17\uffff\x01\x02",
            "\x01\x04\x16\uffff\x0d\x04\x02\uffff\x02\x04\x01\uffff\x03"+
            "\x04\x05\uffff\x01\x02",
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

    static readonly short[] DFA32_eot = DFA.UnpackEncodedString(DFA32_eotS);
    static readonly short[] DFA32_eof = DFA.UnpackEncodedString(DFA32_eofS);
    static readonly char[] DFA32_min = DFA.UnpackEncodedStringToUnsignedChars(DFA32_minS);
    static readonly char[] DFA32_max = DFA.UnpackEncodedStringToUnsignedChars(DFA32_maxS);
    static readonly short[] DFA32_accept = DFA.UnpackEncodedString(DFA32_acceptS);
    static readonly short[] DFA32_special = DFA.UnpackEncodedString(DFA32_specialS);
    static readonly short[][] DFA32_transition = DFA.UnpackEncodedStringArray(DFA32_transitionS);

    protected class DFA32 : DFA
    {
        public DFA32(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 32;
            this.eot = DFA32_eot;
            this.eof = DFA32_eof;
            this.min = DFA32_min;
            this.max = DFA32_max;
            this.accept = DFA32_accept;
            this.special = DFA32_special;
            this.transition = DFA32_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 244:26: ( ',' parameter_declaration )*"; }
        }

    }

    const string DFA33_eotS =
        "\x22\uffff";
    const string DFA33_eofS =
        "\x01\x01\x21\uffff";
    const string DFA33_minS =
        "\x01\x04\x03\uffff\x01\x00\x01\uffff\x01\x04\x0a\uffff\x02\x00"+
        "\x01\uffff\x01\x00\x0d\uffff";
    const string DFA33_maxS =
        "\x01\x34\x03\uffff\x01\x00\x01\uffff\x01\x34\x0a\uffff\x02\x00"+
        "\x01\uffff\x01\x00\x0d\uffff";
    const string DFA33_acceptS =
        "\x01\uffff\x01\x03\x03\uffff\x01\x01\x01\uffff\x01\x02\x1a\uffff";
    const string DFA33_specialS =
        "\x04\uffff\x01\x00\x0c\uffff\x01\x01\x01\x02\x01\uffff\x01\x03"+
        "\x0d\uffff}>";
    static readonly string[] DFA33_transitionS = {
            "\x01\x05\x14\uffff\x01\x01\x16\uffff\x01\x06\x01\x01\x01\x07"+
            "\x01\uffff\x01\x04",
            "",
            "",
            "",
            "\x01\uffff",
            "",
            "\x01\x14\x16\uffff\x0d\x07\x02\uffff\x02\x07\x01\uffff\x03"+
            "\x07\x01\x12\x02\x07\x01\uffff\x01\x11",
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
            "\x01\uffff",
            "\x01\uffff",
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
            get { return "()* loopback of 248:27: ( declarator | abstract_declarator )*"; }
        }

    }


    protected internal int DFA33_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA33_4 = input.LA(1);

                   	 
                   	int index33_4 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred58_C()) ) { s = 5; }

                   	else if ( (synpred59_C()) ) { s = 7; }

                   	 
                   	input.Seek(index33_4);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA33_17 = input.LA(1);

                   	 
                   	int index33_17 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred58_C()) ) { s = 5; }

                   	else if ( (synpred59_C()) ) { s = 7; }

                   	 
                   	input.Seek(index33_17);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA33_18 = input.LA(1);

                   	 
                   	int index33_18 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred58_C()) ) { s = 5; }

                   	else if ( (synpred59_C()) ) { s = 7; }

                   	 
                   	input.Seek(index33_18);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA33_20 = input.LA(1);

                   	 
                   	int index33_20 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred58_C()) ) { s = 5; }

                   	else if ( (synpred59_C()) ) { s = 7; }

                   	 
                   	input.Seek(index33_20);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae33 =
            new NoViableAltException(dfa.Description, 33, _s, input);
        dfa.Error(nvae33);
        throw nvae33;
    }
    const string DFA36_eotS =
        "\x23\uffff";
    const string DFA36_eofS =
        "\x01\x03\x22\uffff";
    const string DFA36_minS =
        "\x03\x04\x05\uffff\x1a\x00\x01\uffff";
    const string DFA36_maxS =
        "\x02\x34\x01\x41\x05\uffff\x1a\x00\x01\uffff";
    const string DFA36_acceptS =
        "\x03\uffff\x01\x02\x1e\uffff\x01\x01";
    const string DFA36_specialS =
        "\x08\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
        "\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01"+
        "\x0e\x01\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01"+
        "\x16\x01\x17\x01\x18\x01\x19\x01\uffff}>";
    static readonly string[] DFA36_transitionS = {
            "\x01\x03\x14\uffff\x01\x03\x16\uffff\x01\x01\x01\x03\x01\x02"+
            "\x01\uffff\x01\x03",
            "\x01\x0c\x16\uffff\x04\x0d\x01\x0e\x01\x0f\x01\x10\x01\x11"+
            "\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x02\uffff\x02\x17\x01"+
            "\uffff\x01\x18\x02\x19\x01\x0a\x01\x08\x01\x0b\x01\uffff\x01"+
            "\x09",
            "\x01\x1c\x06\x1d\x25\uffff\x01\x1b\x02\uffff\x01\x1a\x01\x20"+
            "\x01\uffff\x02\x20\x02\uffff\x01\x1e\x01\x1f\x01\x21\x02\uffff"+
            "\x03\x20",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            ""
    };

    static readonly short[] DFA36_eot = DFA.UnpackEncodedString(DFA36_eotS);
    static readonly short[] DFA36_eof = DFA.UnpackEncodedString(DFA36_eofS);
    static readonly char[] DFA36_min = DFA.UnpackEncodedStringToUnsignedChars(DFA36_minS);
    static readonly char[] DFA36_max = DFA.UnpackEncodedStringToUnsignedChars(DFA36_maxS);
    static readonly short[] DFA36_accept = DFA.UnpackEncodedString(DFA36_acceptS);
    static readonly short[] DFA36_special = DFA.UnpackEncodedString(DFA36_specialS);
    static readonly short[][] DFA36_transition = DFA.UnpackEncodedStringArray(DFA36_transitionS);

    protected class DFA36 : DFA
    {
        public DFA36(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 36;
            this.eot = DFA36_eot;
            this.eof = DFA36_eof;
            this.min = DFA36_min;
            this.max = DFA36_max;
            this.accept = DFA36_accept;
            this.special = DFA36_special;
            this.transition = DFA36_transition;

        }

        override public string Description
        {
            get { return "260:12: ( direct_abstract_declarator )?"; }
        }

    }


    protected internal int DFA36_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA36_8 = input.LA(1);

                   	 
                   	int index36_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_8);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA36_9 = input.LA(1);

                   	 
                   	int index36_9 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_9);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA36_10 = input.LA(1);

                   	 
                   	int index36_10 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_10);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA36_11 = input.LA(1);

                   	 
                   	int index36_11 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_11);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA36_12 = input.LA(1);

                   	 
                   	int index36_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_12);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA36_13 = input.LA(1);

                   	 
                   	int index36_13 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_13);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA36_14 = input.LA(1);

                   	 
                   	int index36_14 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_14);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA36_15 = input.LA(1);

                   	 
                   	int index36_15 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_15);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA36_16 = input.LA(1);

                   	 
                   	int index36_16 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_16);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA36_17 = input.LA(1);

                   	 
                   	int index36_17 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_17);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA36_18 = input.LA(1);

                   	 
                   	int index36_18 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_18);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA36_19 = input.LA(1);

                   	 
                   	int index36_19 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_19);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA36_20 = input.LA(1);

                   	 
                   	int index36_20 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_20);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA36_21 = input.LA(1);

                   	 
                   	int index36_21 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_21);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA36_22 = input.LA(1);

                   	 
                   	int index36_22 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_22);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 15 : 
                   	int LA36_23 = input.LA(1);

                   	 
                   	int index36_23 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_23);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 16 : 
                   	int LA36_24 = input.LA(1);

                   	 
                   	int index36_24 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_24);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 17 : 
                   	int LA36_25 = input.LA(1);

                   	 
                   	int index36_25 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_25);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 18 : 
                   	int LA36_26 = input.LA(1);

                   	 
                   	int index36_26 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_26);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 19 : 
                   	int LA36_27 = input.LA(1);

                   	 
                   	int index36_27 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_27);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 20 : 
                   	int LA36_28 = input.LA(1);

                   	 
                   	int index36_28 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_28);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 21 : 
                   	int LA36_29 = input.LA(1);

                   	 
                   	int index36_29 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_29);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 22 : 
                   	int LA36_30 = input.LA(1);

                   	 
                   	int index36_30 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_30);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 23 : 
                   	int LA36_31 = input.LA(1);

                   	 
                   	int index36_31 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_31);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 24 : 
                   	int LA36_32 = input.LA(1);

                   	 
                   	int index36_32 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_32);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 25 : 
                   	int LA36_33 = input.LA(1);

                   	 
                   	int index36_33 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred62_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 3; }

                   	 
                   	input.Seek(index36_33);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae36 =
            new NoViableAltException(dfa.Description, 36, _s, input);
        dfa.Error(nvae36);
        throw nvae36;
    }
    const string DFA38_eotS =
        "\x15\uffff";
    const string DFA38_eofS =
        "\x15\uffff";
    const string DFA38_minS =
        "\x01\x30\x01\x04\x13\uffff";
    const string DFA38_maxS =
        "\x01\x32\x01\x34\x13\uffff";
    const string DFA38_acceptS =
        "\x02\uffff\x01\x02\x01\uffff\x01\x01\x10\uffff";
    const string DFA38_specialS =
        "\x15\uffff}>";
    static readonly string[] DFA38_transitionS = {
            "\x01\x01\x01\uffff\x01\x02",
            "\x01\x02\x16\uffff\x0d\x02\x02\uffff\x02\x02\x01\uffff\x03"+
            "\x02\x01\x04\x01\x02\x01\x04\x01\uffff\x01\x04",
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

    static readonly short[] DFA38_eot = DFA.UnpackEncodedString(DFA38_eotS);
    static readonly short[] DFA38_eof = DFA.UnpackEncodedString(DFA38_eofS);
    static readonly char[] DFA38_min = DFA.UnpackEncodedStringToUnsignedChars(DFA38_minS);
    static readonly char[] DFA38_max = DFA.UnpackEncodedStringToUnsignedChars(DFA38_maxS);
    static readonly short[] DFA38_accept = DFA.UnpackEncodedString(DFA38_acceptS);
    static readonly short[] DFA38_special = DFA.UnpackEncodedString(DFA38_specialS);
    static readonly short[][] DFA38_transition = DFA.UnpackEncodedStringArray(DFA38_transitionS);

    protected class DFA38 : DFA
    {
        public DFA38(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 38;
            this.eot = DFA38_eot;
            this.eof = DFA38_eof;
            this.min = DFA38_min;
            this.max = DFA38_max;
            this.accept = DFA38_accept;
            this.special = DFA38_special;
            this.transition = DFA38_transition;

        }

        override public string Description
        {
            get { return "265:4: ( '(' abstract_declarator ')' | abstract_declarator_suffix )"; }
        }

    }

    const string DFA39_eotS =
        "\x23\uffff";
    const string DFA39_eofS =
        "\x01\x01\x22\uffff";
    const string DFA39_minS =
        "\x01\x04\x05\uffff\x02\x04\x01\x00\x03\uffff\x16\x00\x01\uffff";
    const string DFA39_maxS =
        "\x01\x34\x05\uffff\x01\x34\x01\x41\x01\x00\x03\uffff\x16\x00\x01"+
        "\uffff";
    const string DFA39_acceptS =
        "\x01\uffff\x01\x02\x20\uffff\x01\x01";
    const string DFA39_specialS =
        "\x08\uffff\x01\x00\x03\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01"+
        "\x05\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01"+
        "\x0d\x01\x0e\x01\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01"+
        "\x15\x01\x16\x01\uffff}>";
    static readonly string[] DFA39_transitionS = {
            "\x01\x01\x14\uffff\x01\x01\x16\uffff\x01\x06\x01\x01\x01\x07"+
            "\x01\uffff\x01\x01",
            "",
            "",
            "",
            "",
            "",
            "\x01\x18\x16\uffff\x04\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x10"+
            "\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x02\uffff\x02\x16\x01"+
            "\uffff\x01\x17\x02\x19\x01\x01\x01\x08\x01\x01\x01\uffff\x01"+
            "\x01",
            "\x01\x1c\x06\x1d\x25\uffff\x01\x1b\x02\uffff\x01\x1a\x01\x20"+
            "\x01\uffff\x02\x20\x02\uffff\x01\x1e\x01\x1f\x01\x21\x02\uffff"+
            "\x03\x20",
            "\x01\uffff",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            ""
    };

    static readonly short[] DFA39_eot = DFA.UnpackEncodedString(DFA39_eotS);
    static readonly short[] DFA39_eof = DFA.UnpackEncodedString(DFA39_eofS);
    static readonly char[] DFA39_min = DFA.UnpackEncodedStringToUnsignedChars(DFA39_minS);
    static readonly char[] DFA39_max = DFA.UnpackEncodedStringToUnsignedChars(DFA39_maxS);
    static readonly short[] DFA39_accept = DFA.UnpackEncodedString(DFA39_acceptS);
    static readonly short[] DFA39_special = DFA.UnpackEncodedString(DFA39_specialS);
    static readonly short[][] DFA39_transition = DFA.UnpackEncodedStringArray(DFA39_transitionS);

    protected class DFA39 : DFA
    {
        public DFA39(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 39;
            this.eot = DFA39_eot;
            this.eof = DFA39_eof;
            this.min = DFA39_min;
            this.max = DFA39_max;
            this.accept = DFA39_accept;
            this.special = DFA39_special;
            this.transition = DFA39_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 265:65: ( abstract_declarator_suffix )*"; }
        }

    }


    protected internal int DFA39_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA39_8 = input.LA(1);

                   	 
                   	int index39_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_8);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA39_12 = input.LA(1);

                   	 
                   	int index39_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_12);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA39_13 = input.LA(1);

                   	 
                   	int index39_13 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_13);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA39_14 = input.LA(1);

                   	 
                   	int index39_14 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_14);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA39_15 = input.LA(1);

                   	 
                   	int index39_15 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_15);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA39_16 = input.LA(1);

                   	 
                   	int index39_16 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_16);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA39_17 = input.LA(1);

                   	 
                   	int index39_17 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_17);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA39_18 = input.LA(1);

                   	 
                   	int index39_18 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_18);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA39_19 = input.LA(1);

                   	 
                   	int index39_19 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_19);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA39_20 = input.LA(1);

                   	 
                   	int index39_20 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_20);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA39_21 = input.LA(1);

                   	 
                   	int index39_21 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_21);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA39_22 = input.LA(1);

                   	 
                   	int index39_22 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_22);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA39_23 = input.LA(1);

                   	 
                   	int index39_23 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_23);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA39_24 = input.LA(1);

                   	 
                   	int index39_24 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_24);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA39_25 = input.LA(1);

                   	 
                   	int index39_25 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_25);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 15 : 
                   	int LA39_26 = input.LA(1);

                   	 
                   	int index39_26 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_26);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 16 : 
                   	int LA39_27 = input.LA(1);

                   	 
                   	int index39_27 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_27);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 17 : 
                   	int LA39_28 = input.LA(1);

                   	 
                   	int index39_28 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_28);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 18 : 
                   	int LA39_29 = input.LA(1);

                   	 
                   	int index39_29 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_29);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 19 : 
                   	int LA39_30 = input.LA(1);

                   	 
                   	int index39_30 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_30);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 20 : 
                   	int LA39_31 = input.LA(1);

                   	 
                   	int index39_31 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_31);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 21 : 
                   	int LA39_32 = input.LA(1);

                   	 
                   	int index39_32 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_32);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 22 : 
                   	int LA39_33 = input.LA(1);

                   	 
                   	int index39_33 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred65_C()) ) { s = 34; }

                   	else if ( (true) ) { s = 1; }

                   	 
                   	input.Seek(index39_33);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae39 =
            new NoViableAltException(dfa.Description, 39, _s, input);
        dfa.Error(nvae39);
        throw nvae39;
    }
    const string DFA40_eotS =
        "\x1a\uffff";
    const string DFA40_eofS =
        "\x1a\uffff";
    const string DFA40_minS =
        "\x01\x30\x02\x04\x17\uffff";
    const string DFA40_maxS =
        "\x01\x32\x01\x41\x01\x31\x17\uffff";
    const string DFA40_acceptS =
        "\x03\uffff\x01\x01\x01\x02\x06\uffff\x01\x03\x01\x04\x0d\uffff";
    const string DFA40_specialS =
        "\x1a\uffff}>";
    static readonly string[] DFA40_transitionS = {
            "\x01\x02\x01\uffff\x01\x01",
            "\x07\x04\x25\uffff\x01\x04\x02\uffff\x01\x03\x01\x04\x01\uffff"+
            "\x02\x04\x02\uffff\x03\x04\x02\uffff\x03\x04",
            "\x01\x0c\x16\uffff\x0d\x0c\x02\uffff\x02\x0c\x01\uffff\x03"+
            "\x0c\x01\uffff\x01\x0b",
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

    static readonly short[] DFA40_eot = DFA.UnpackEncodedString(DFA40_eotS);
    static readonly short[] DFA40_eof = DFA.UnpackEncodedString(DFA40_eofS);
    static readonly char[] DFA40_min = DFA.UnpackEncodedStringToUnsignedChars(DFA40_minS);
    static readonly char[] DFA40_max = DFA.UnpackEncodedStringToUnsignedChars(DFA40_maxS);
    static readonly short[] DFA40_accept = DFA.UnpackEncodedString(DFA40_acceptS);
    static readonly short[] DFA40_special = DFA.UnpackEncodedString(DFA40_specialS);
    static readonly short[][] DFA40_transition = DFA.UnpackEncodedStringArray(DFA40_transitionS);

    protected class DFA40 : DFA
    {
        public DFA40(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 40;
            this.eot = DFA40_eot;
            this.eof = DFA40_eof;
            this.min = DFA40_min;
            this.max = DFA40_max;
            this.accept = DFA40_accept;
            this.special = DFA40_special;
            this.transition = DFA40_transition;

        }

        override public string Description
        {
            get { return "268:1: abstract_declarator_suffix : ( '[' ']' | '[' constant_expression ']' | '(' ')' | '(' parameter_type_list ')' );"; }
        }

    }

    const string DFA43_eotS =
        "\x0c\uffff";
    const string DFA43_eofS =
        "\x0c\uffff";
    const string DFA43_minS =
        "\x01\x19\x01\x04\x0a\uffff";
    const string DFA43_maxS =
        "\x01\x29\x01\x41\x0a\uffff";
    const string DFA43_acceptS =
        "\x02\uffff\x01\x02\x01\uffff\x01\x01\x07\uffff";
    const string DFA43_specialS =
        "\x0c\uffff}>";
    static readonly string[] DFA43_transitionS = {
            "\x01\x01\x0f\uffff\x01\x02",
            "\x07\x04\x1d\uffff\x01\x04\x01\x02\x06\uffff\x01\x04\x03\uffff"+
            "\x01\x04\x01\uffff\x02\x04\x02\uffff\x03\x04\x02\uffff\x03\x04",
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
            get { return "()* loopback of 281:16: ( ',' initializer )*"; }
        }

    }

    const string DFA45_eotS =
        "\x13\uffff";
    const string DFA45_eofS =
        "\x01\x01\x12\uffff";
    const string DFA45_minS =
        "\x01\x18\x12\uffff";
    const string DFA45_maxS =
        "\x01\x58\x12\uffff";
    const string DFA45_acceptS =
        "\x01\uffff\x01\x03\x0f\uffff\x01\x01\x01\x02";
    const string DFA45_specialS =
        "\x13\uffff}>";
    static readonly string[] DFA45_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x02\uffff\x01\x11\x01\x12\x07\uffff\x01"+
            "\x01\x0c\uffff\x0d\x01",
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
            get { return "()* loopback of 291:32: ( '+' multiplicative_expression | '-' multiplicative_expression )*"; }
        }

    }

    const string DFA46_eotS =
        "\x16\uffff";
    const string DFA46_eofS =
        "\x01\x01\x15\uffff";
    const string DFA46_minS =
        "\x01\x18\x15\uffff";
    const string DFA46_maxS =
        "\x01\x58\x15\uffff";
    const string DFA46_acceptS =
        "\x01\uffff\x01\x04\x11\uffff\x01\x01\x01\x02\x01\x03";
    const string DFA46_specialS =
        "\x16\uffff}>";
    static readonly string[] DFA46_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x01\x13\x01\uffff\x02\x01\x01\x14\x01"+
            "\x15\x05\uffff\x01\x01\x0c\uffff\x0d\x01",
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

    static readonly short[] DFA46_eot = DFA.UnpackEncodedString(DFA46_eotS);
    static readonly short[] DFA46_eof = DFA.UnpackEncodedString(DFA46_eofS);
    static readonly char[] DFA46_min = DFA.UnpackEncodedStringToUnsignedChars(DFA46_minS);
    static readonly char[] DFA46_max = DFA.UnpackEncodedStringToUnsignedChars(DFA46_maxS);
    static readonly short[] DFA46_accept = DFA.UnpackEncodedString(DFA46_acceptS);
    static readonly short[] DFA46_special = DFA.UnpackEncodedString(DFA46_specialS);
    static readonly short[][] DFA46_transition = DFA.UnpackEncodedStringArray(DFA46_transitionS);

    protected class DFA46 : DFA
    {
        public DFA46(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 46;
            this.eot = DFA46_eot;
            this.eof = DFA46_eof;
            this.min = DFA46_min;
            this.max = DFA46_max;
            this.accept = DFA46_accept;
            this.special = DFA46_special;
            this.transition = DFA46_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 295:22: ( '*' cast_expression | '/' cast_expression | '%' cast_expression )*"; }
        }

    }

    const string DFA47_eotS =
        "\x1b\uffff";
    const string DFA47_eofS =
        "\x1b\uffff";
    const string DFA47_minS =
        "\x02\x04\x12\uffff\x01\x00\x06\uffff";
    const string DFA47_maxS =
        "\x02\x41\x12\uffff\x01\x00\x06\uffff";
    const string DFA47_acceptS =
        "\x02\uffff\x01\x02\x05\uffff\x01\x01\x12\uffff";
    const string DFA47_specialS =
        "\x14\uffff\x01\x00\x06\uffff}>";
    static readonly string[] DFA47_transitionS = {
            "\x07\x02\x25\uffff\x01\x01\x03\uffff\x01\x02\x01\uffff\x02"+
            "\x02\x02\uffff\x03\x02\x02\uffff\x03\x02",
            "\x01\x14\x06\x02\x14\uffff\x09\x08\x02\uffff\x02\x08\x01\uffff"+
            "\x03\x08\x01\x02\x03\uffff\x01\x02\x01\uffff\x02\x02\x02\uffff"+
            "\x03\x02\x02\uffff\x03\x02",
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
            "\x01\uffff",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA47_eot = DFA.UnpackEncodedString(DFA47_eotS);
    static readonly short[] DFA47_eof = DFA.UnpackEncodedString(DFA47_eofS);
    static readonly char[] DFA47_min = DFA.UnpackEncodedStringToUnsignedChars(DFA47_minS);
    static readonly char[] DFA47_max = DFA.UnpackEncodedStringToUnsignedChars(DFA47_maxS);
    static readonly short[] DFA47_accept = DFA.UnpackEncodedString(DFA47_acceptS);
    static readonly short[] DFA47_special = DFA.UnpackEncodedString(DFA47_specialS);
    static readonly short[][] DFA47_transition = DFA.UnpackEncodedStringArray(DFA47_transitionS);

    protected class DFA47 : DFA
    {
        public DFA47(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 47;
            this.eot = DFA47_eot;
            this.eof = DFA47_eof;
            this.min = DFA47_min;
            this.max = DFA47_max;
            this.accept = DFA47_accept;
            this.special = DFA47_special;
            this.transition = DFA47_transition;

        }

        override public string Description
        {
            get { return "298:1: cast_expression : ( '(' type_name ')' cast_expression | unary_expression );"; }
        }

    }


    protected internal int DFA47_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA47_20 = input.LA(1);

                   	 
                   	int index47_20 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred78_C()) ) { s = 8; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index47_20);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae47 =
            new NoViableAltException(dfa.Description, 47, _s, input);
        dfa.Error(nvae47);
        throw nvae47;
    }
    const string DFA48_eotS =
        "\x10\uffff";
    const string DFA48_eofS =
        "\x10\uffff";
    const string DFA48_minS =
        "\x01\x04\x06\uffff\x01\x04\x01\x00\x07\uffff";
    const string DFA48_maxS =
        "\x01\x41\x06\uffff\x01\x41\x01\x00\x07\uffff";
    const string DFA48_acceptS =
        "\x01\uffff\x01\x01\x02\uffff\x01\x02\x01\x03\x01\x04\x02\uffff"+
        "\x01\x05\x05\uffff\x01\x06";
    const string DFA48_specialS =
        "\x08\uffff\x01\x00\x07\uffff}>";
    static readonly string[] DFA48_transitionS = {
            "\x07\x01\x25\uffff\x01\x01\x03\uffff\x01\x06\x01\uffff\x02"+
            "\x06\x02\uffff\x01\x04\x01\x05\x01\x07\x02\uffff\x03\x06",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x07\x09\x25\uffff\x01\x08\x03\uffff\x01\x09\x01\uffff\x02"+
            "\x09\x02\uffff\x03\x09\x02\uffff\x03\x09",
            "\x01\uffff",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA48_eot = DFA.UnpackEncodedString(DFA48_eotS);
    static readonly short[] DFA48_eof = DFA.UnpackEncodedString(DFA48_eofS);
    static readonly char[] DFA48_min = DFA.UnpackEncodedStringToUnsignedChars(DFA48_minS);
    static readonly char[] DFA48_max = DFA.UnpackEncodedStringToUnsignedChars(DFA48_maxS);
    static readonly short[] DFA48_accept = DFA.UnpackEncodedString(DFA48_acceptS);
    static readonly short[] DFA48_special = DFA.UnpackEncodedString(DFA48_specialS);
    static readonly short[][] DFA48_transition = DFA.UnpackEncodedStringArray(DFA48_transitionS);

    protected class DFA48 : DFA
    {
        public DFA48(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 48;
            this.eot = DFA48_eot;
            this.eof = DFA48_eof;
            this.min = DFA48_min;
            this.max = DFA48_max;
            this.accept = DFA48_accept;
            this.special = DFA48_special;
            this.transition = DFA48_transition;

        }

        override public string Description
        {
            get { return "303:1: unary_expression : ( postfix_expression | '++' unary_expression | '--' unary_expression | unary_operator cast_expression | 'sizeof' unary_expression | 'sizeof' '(' type_name ')' );"; }
        }

    }


    protected internal int DFA48_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA48_8 = input.LA(1);

                   	 
                   	int index48_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred83_C()) ) { s = 9; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index48_8);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae48 =
            new NoViableAltException(dfa.Description, 48, _s, input);
        dfa.Error(nvae48);
        throw nvae48;
    }
    const string DFA49_eotS =
        "\x25\uffff";
    const string DFA49_eofS =
        "\x01\x01\x24\uffff";
    const string DFA49_minS =
        "\x01\x18\x17\uffff\x01\x04\x0c\uffff";
    const string DFA49_maxS =
        "\x01\x58\x17\uffff\x01\x41\x0c\uffff";
    const string DFA49_acceptS =
        "\x01\uffff\x01\x08\x15\uffff\x01\x01\x01\uffff\x01\x04\x01\x05"+
        "\x01\x06\x01\x07\x01\x02\x01\x03\x06\uffff";
    const string DFA49_specialS =
        "\x25\uffff}>";
    static readonly string[] DFA49_transitionS = {
            "\x03\x01\x0e\uffff\x01\x01\x02\uffff\x01\x01\x03\uffff\x01"+
            "\x18\x01\x01\x01\x17\x02\x01\x01\uffff\x04\x01\x01\x1b\x01\x1c"+
            "\x01\uffff\x01\x19\x01\x1a\x01\x01\x02\uffff\x17\x01",
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
            "\x07\x1e\x25\uffff\x01\x1e\x01\x1d\x02\uffff\x01\x1e\x01\uffff"+
            "\x02\x1e\x02\uffff\x03\x1e\x02\uffff\x03\x1e",
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

    static readonly short[] DFA49_eot = DFA.UnpackEncodedString(DFA49_eotS);
    static readonly short[] DFA49_eof = DFA.UnpackEncodedString(DFA49_eofS);
    static readonly char[] DFA49_min = DFA.UnpackEncodedStringToUnsignedChars(DFA49_minS);
    static readonly char[] DFA49_max = DFA.UnpackEncodedStringToUnsignedChars(DFA49_maxS);
    static readonly short[] DFA49_accept = DFA.UnpackEncodedString(DFA49_acceptS);
    static readonly short[] DFA49_special = DFA.UnpackEncodedString(DFA49_specialS);
    static readonly short[][] DFA49_transition = DFA.UnpackEncodedStringArray(DFA49_transitionS);

    protected class DFA49 : DFA
    {
        public DFA49(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 49;
            this.eot = DFA49_eot;
            this.eof = DFA49_eof;
            this.min = DFA49_min;
            this.max = DFA49_max;
            this.accept = DFA49_accept;
            this.special = DFA49_special;
            this.transition = DFA49_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 314:9: ( '[' expression ']' | '(' ')' | '(' argument_expression_list ')' | '.' IDENTIFIER | '->' IDENTIFIER | '++' | '--' )*"; }
        }

    }

    const string DFA52_eotS =
        "\x6f\uffff";
    const string DFA52_eofS =
        "\x01\uffff\x02\x0f\x6c\uffff";
    const string DFA52_minS =
        "\x01\x04\x02\x18\x05\x04\x06\x00\x16\uffff\x06\x00\x16\uffff\x07"+
        "\x00\x0c\uffff\x1c\x00";
    const string DFA52_maxS =
        "\x01\x41\x02\x58\x05\x41\x06\x00\x16\uffff\x06\x00\x16\uffff\x07"+
        "\x00\x0c\uffff\x1c\x00";
    const string DFA52_acceptS =
        "\x0e\uffff\x01\x01\x01\x02\x5f\uffff";
    const string DFA52_specialS =
        "\x08\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x16"+
        "\uffff\x01\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x16\uffff"+
        "\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x10\x01\x11\x01\x12\x0c\uffff"+
        "\x01\x13\x01\x14\x01\x15\x01\x16\x01\x17\x01\x18\x01\x19\x01\x1a"+
        "\x01\x1b\x01\x1c\x01\x1d\x01\x1e\x01\x1f\x01\x20\x01\x21\x01\x22"+
        "\x01\x23\x01\x24\x01\x25\x01\x26\x01\x27\x01\x28\x01\x29\x01\x2a"+
        "\x01\x2b\x01\x2c\x01\x2d\x01\x2e}>";
    static readonly string[] DFA52_transitionS = {
            "\x01\x01\x06\x02\x25\uffff\x01\x03\x03\uffff\x01\x06\x01\uffff"+
            "\x02\x06\x02\uffff\x01\x04\x01\x05\x01\x07\x02\uffff\x03\x06",
            "\x02\x0f\x01\x0e\x0e\uffff\x01\x0f\x02\uffff\x01\x0f\x03\uffff"+
            "\x01\x09\x01\x0f\x01\x08\x02\x0f\x01\uffff\x04\x0f\x01\x0c\x01"+
            "\x0d\x01\uffff\x01\x0a\x01\x0b\x01\x0f\x02\uffff\x0a\x0e\x0d"+
            "\x0f",
            "\x02\x0f\x01\x0e\x0e\uffff\x01\x0f\x02\uffff\x01\x0f\x03\uffff"+
            "\x01\x25\x01\x0f\x01\x24\x02\x0f\x01\uffff\x04\x0f\x01\x28\x01"+
            "\x29\x01\uffff\x01\x26\x01\x27\x01\x0f\x02\uffff\x0a\x0e\x0d"+
            "\x0f",
            "\x01\x40\x06\x41\x14\uffff\x09\x0f\x02\uffff\x02\x0f\x01\uffff"+
            "\x03\x0f\x01\x42\x03\uffff\x01\x45\x01\uffff\x02\x45\x02\uffff"+
            "\x01\x43\x01\x44\x01\x46\x02\uffff\x03\x45",
            "\x01\x53\x06\x54\x25\uffff\x01\x55\x03\uffff\x01\x58\x01\uffff"+
            "\x02\x58\x02\uffff\x01\x56\x01\x57\x01\x59\x02\uffff\x03\x58",
            "\x01\x5a\x06\x5b\x25\uffff\x01\x5c\x03\uffff\x01\x5f\x01\uffff"+
            "\x02\x5f\x02\uffff\x01\x5d\x01\x5e\x01\x60\x02\uffff\x03\x5f",
            "\x01\x62\x06\x63\x25\uffff\x01\x61\x03\uffff\x01\x66\x01\uffff"+
            "\x02\x66\x02\uffff\x01\x64\x01\x65\x01\x67\x02\uffff\x03\x66",
            "\x01\x69\x06\x6a\x25\uffff\x01\x68\x03\uffff\x01\x6d\x01\uffff"+
            "\x02\x6d\x02\uffff\x01\x6b\x01\x6c\x01\x6e\x02\uffff\x03\x6d",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
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
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
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
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
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
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff"
    };

    static readonly short[] DFA52_eot = DFA.UnpackEncodedString(DFA52_eotS);
    static readonly short[] DFA52_eof = DFA.UnpackEncodedString(DFA52_eofS);
    static readonly char[] DFA52_min = DFA.UnpackEncodedStringToUnsignedChars(DFA52_minS);
    static readonly char[] DFA52_max = DFA.UnpackEncodedStringToUnsignedChars(DFA52_maxS);
    static readonly short[] DFA52_accept = DFA.UnpackEncodedString(DFA52_acceptS);
    static readonly short[] DFA52_special = DFA.UnpackEncodedString(DFA52_specialS);
    static readonly short[][] DFA52_transition = DFA.UnpackEncodedStringArray(DFA52_transitionS);

    protected class DFA52 : DFA
    {
        public DFA52(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 52;
            this.eot = DFA52_eot;
            this.eof = DFA52_eof;
            this.min = DFA52_min;
            this.max = DFA52_max;
            this.accept = DFA52_accept;
            this.special = DFA52_special;
            this.transition = DFA52_transition;

        }

        override public string Description
        {
            get { return "358:1: assignment_expression : ( lvalue assignment_operator assignment_expression | conditional_expression );"; }
        }

    }


    protected internal int DFA52_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA52_8 = input.LA(1);

                   	 
                   	int index52_8 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_8);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA52_9 = input.LA(1);

                   	 
                   	int index52_9 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_9);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA52_10 = input.LA(1);

                   	 
                   	int index52_10 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_10);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA52_11 = input.LA(1);

                   	 
                   	int index52_11 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_11);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA52_12 = input.LA(1);

                   	 
                   	int index52_12 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_12);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA52_13 = input.LA(1);

                   	 
                   	int index52_13 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_13);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA52_36 = input.LA(1);

                   	 
                   	int index52_36 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_36);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA52_37 = input.LA(1);

                   	 
                   	int index52_37 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_37);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA52_38 = input.LA(1);

                   	 
                   	int index52_38 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_38);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA52_39 = input.LA(1);

                   	 
                   	int index52_39 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_39);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA52_40 = input.LA(1);

                   	 
                   	int index52_40 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_40);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA52_41 = input.LA(1);

                   	 
                   	int index52_41 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_41);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA52_64 = input.LA(1);

                   	 
                   	int index52_64 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_64);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA52_65 = input.LA(1);

                   	 
                   	int index52_65 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_65);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA52_66 = input.LA(1);

                   	 
                   	int index52_66 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_66);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 15 : 
                   	int LA52_67 = input.LA(1);

                   	 
                   	int index52_67 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_67);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 16 : 
                   	int LA52_68 = input.LA(1);

                   	 
                   	int index52_68 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_68);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 17 : 
                   	int LA52_69 = input.LA(1);

                   	 
                   	int index52_69 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_69);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 18 : 
                   	int LA52_70 = input.LA(1);

                   	 
                   	int index52_70 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_70);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 19 : 
                   	int LA52_83 = input.LA(1);

                   	 
                   	int index52_83 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_83);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 20 : 
                   	int LA52_84 = input.LA(1);

                   	 
                   	int index52_84 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_84);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 21 : 
                   	int LA52_85 = input.LA(1);

                   	 
                   	int index52_85 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_85);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 22 : 
                   	int LA52_86 = input.LA(1);

                   	 
                   	int index52_86 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_86);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 23 : 
                   	int LA52_87 = input.LA(1);

                   	 
                   	int index52_87 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_87);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 24 : 
                   	int LA52_88 = input.LA(1);

                   	 
                   	int index52_88 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_88);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 25 : 
                   	int LA52_89 = input.LA(1);

                   	 
                   	int index52_89 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_89);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 26 : 
                   	int LA52_90 = input.LA(1);

                   	 
                   	int index52_90 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_90);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 27 : 
                   	int LA52_91 = input.LA(1);

                   	 
                   	int index52_91 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_91);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 28 : 
                   	int LA52_92 = input.LA(1);

                   	 
                   	int index52_92 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_92);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 29 : 
                   	int LA52_93 = input.LA(1);

                   	 
                   	int index52_93 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_93);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 30 : 
                   	int LA52_94 = input.LA(1);

                   	 
                   	int index52_94 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_94);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 31 : 
                   	int LA52_95 = input.LA(1);

                   	 
                   	int index52_95 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_95);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 32 : 
                   	int LA52_96 = input.LA(1);

                   	 
                   	int index52_96 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_96);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 33 : 
                   	int LA52_97 = input.LA(1);

                   	 
                   	int index52_97 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_97);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 34 : 
                   	int LA52_98 = input.LA(1);

                   	 
                   	int index52_98 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_98);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 35 : 
                   	int LA52_99 = input.LA(1);

                   	 
                   	int index52_99 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_99);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 36 : 
                   	int LA52_100 = input.LA(1);

                   	 
                   	int index52_100 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_100);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 37 : 
                   	int LA52_101 = input.LA(1);

                   	 
                   	int index52_101 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_101);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 38 : 
                   	int LA52_102 = input.LA(1);

                   	 
                   	int index52_102 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_102);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 39 : 
                   	int LA52_103 = input.LA(1);

                   	 
                   	int index52_103 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_103);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 40 : 
                   	int LA52_104 = input.LA(1);

                   	 
                   	int index52_104 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_104);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 41 : 
                   	int LA52_105 = input.LA(1);

                   	 
                   	int index52_105 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_105);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 42 : 
                   	int LA52_106 = input.LA(1);

                   	 
                   	int index52_106 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_106);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 43 : 
                   	int LA52_107 = input.LA(1);

                   	 
                   	int index52_107 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_107);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 44 : 
                   	int LA52_108 = input.LA(1);

                   	 
                   	int index52_108 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_108);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 45 : 
                   	int LA52_109 = input.LA(1);

                   	 
                   	int index52_109 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_109);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 46 : 
                   	int LA52_110 = input.LA(1);

                   	 
                   	int index52_110 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( (synpred104_C()) ) { s = 14; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index52_110);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae52 =
            new NoViableAltException(dfa.Description, 52, _s, input);
        dfa.Error(nvae52);
        throw nvae52;
    }
    const string DFA54_eotS =
        "\x0a\uffff";
    const string DFA54_eofS =
        "\x01\x01\x09\uffff";
    const string DFA54_minS =
        "\x01\x18\x09\uffff";
    const string DFA54_maxS =
        "\x01\x4d\x09\uffff";
    const string DFA54_acceptS =
        "\x01\uffff\x01\x02\x07\uffff\x01\x01";
    const string DFA54_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA54_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x18\uffff\x01\x01\x01\x09",
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

    static readonly short[] DFA54_eot = DFA.UnpackEncodedString(DFA54_eotS);
    static readonly short[] DFA54_eof = DFA.UnpackEncodedString(DFA54_eofS);
    static readonly char[] DFA54_min = DFA.UnpackEncodedStringToUnsignedChars(DFA54_minS);
    static readonly char[] DFA54_max = DFA.UnpackEncodedStringToUnsignedChars(DFA54_maxS);
    static readonly short[] DFA54_accept = DFA.UnpackEncodedString(DFA54_acceptS);
    static readonly short[] DFA54_special = DFA.UnpackEncodedString(DFA54_specialS);
    static readonly short[][] DFA54_transition = DFA.UnpackEncodedStringArray(DFA54_transitionS);

    protected class DFA54 : DFA
    {
        public DFA54(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 54;
            this.eot = DFA54_eot;
            this.eof = DFA54_eof;
            this.min = DFA54_min;
            this.max = DFA54_max;
            this.accept = DFA54_accept;
            this.special = DFA54_special;
            this.transition = DFA54_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 386:27: ( '||' logical_and_expression )*"; }
        }

    }

    const string DFA55_eotS =
        "\x0b\uffff";
    const string DFA55_eofS =
        "\x01\x01\x0a\uffff";
    const string DFA55_minS =
        "\x01\x18\x0a\uffff";
    const string DFA55_maxS =
        "\x01\x4e\x0a\uffff";
    const string DFA55_acceptS =
        "\x01\uffff\x01\x02\x08\uffff\x01\x01";
    const string DFA55_specialS =
        "\x0b\uffff}>";
    static readonly string[] DFA55_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x18\uffff\x02\x01\x01\x0a",
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

    static readonly short[] DFA55_eot = DFA.UnpackEncodedString(DFA55_eotS);
    static readonly short[] DFA55_eof = DFA.UnpackEncodedString(DFA55_eofS);
    static readonly char[] DFA55_min = DFA.UnpackEncodedStringToUnsignedChars(DFA55_minS);
    static readonly char[] DFA55_max = DFA.UnpackEncodedStringToUnsignedChars(DFA55_maxS);
    static readonly short[] DFA55_accept = DFA.UnpackEncodedString(DFA55_acceptS);
    static readonly short[] DFA55_special = DFA.UnpackEncodedString(DFA55_specialS);
    static readonly short[][] DFA55_transition = DFA.UnpackEncodedStringArray(DFA55_transitionS);

    protected class DFA55 : DFA
    {
        public DFA55(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 55;
            this.eot = DFA55_eot;
            this.eof = DFA55_eof;
            this.min = DFA55_min;
            this.max = DFA55_max;
            this.accept = DFA55_accept;
            this.special = DFA55_special;
            this.transition = DFA55_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 390:28: ( '&&' inclusive_or_expression )*"; }
        }

    }

    const string DFA56_eotS =
        "\x0c\uffff";
    const string DFA56_eofS =
        "\x01\x01\x0b\uffff";
    const string DFA56_minS =
        "\x01\x18\x0b\uffff";
    const string DFA56_maxS =
        "\x01\x4f\x0b\uffff";
    const string DFA56_acceptS =
        "\x01\uffff\x01\x02\x09\uffff\x01\x01";
    const string DFA56_specialS =
        "\x0c\uffff}>";
    static readonly string[] DFA56_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x18\uffff\x03\x01\x01\x0b",
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

    static readonly short[] DFA56_eot = DFA.UnpackEncodedString(DFA56_eotS);
    static readonly short[] DFA56_eof = DFA.UnpackEncodedString(DFA56_eofS);
    static readonly char[] DFA56_min = DFA.UnpackEncodedStringToUnsignedChars(DFA56_minS);
    static readonly char[] DFA56_max = DFA.UnpackEncodedStringToUnsignedChars(DFA56_maxS);
    static readonly short[] DFA56_accept = DFA.UnpackEncodedString(DFA56_acceptS);
    static readonly short[] DFA56_special = DFA.UnpackEncodedString(DFA56_specialS);
    static readonly short[][] DFA56_transition = DFA.UnpackEncodedStringArray(DFA56_transitionS);

    protected class DFA56 : DFA
    {
        public DFA56(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 56;
            this.eot = DFA56_eot;
            this.eof = DFA56_eof;
            this.min = DFA56_min;
            this.max = DFA56_max;
            this.accept = DFA56_accept;
            this.special = DFA56_special;
            this.transition = DFA56_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 394:28: ( '|' exclusive_or_expression )*"; }
        }

    }

    const string DFA57_eotS =
        "\x0d\uffff";
    const string DFA57_eofS =
        "\x01\x01\x0c\uffff";
    const string DFA57_minS =
        "\x01\x18\x0c\uffff";
    const string DFA57_maxS =
        "\x01\x50\x0c\uffff";
    const string DFA57_acceptS =
        "\x01\uffff\x01\x02\x0a\uffff\x01\x01";
    const string DFA57_specialS =
        "\x0d\uffff}>";
    static readonly string[] DFA57_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x18\uffff\x04\x01\x01\x0c",
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
            get { return "()* loopback of 398:19: ( '^' and_expression )*"; }
        }

    }

    const string DFA58_eotS =
        "\x0e\uffff";
    const string DFA58_eofS =
        "\x01\x01\x0d\uffff";
    const string DFA58_minS =
        "\x01\x18\x0d\uffff";
    const string DFA58_maxS =
        "\x01\x50\x0d\uffff";
    const string DFA58_acceptS =
        "\x01\uffff\x01\x02\x0b\uffff\x01\x01";
    const string DFA58_specialS =
        "\x0e\uffff}>";
    static readonly string[] DFA58_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x0b\uffff\x01\x0d\x0c\uffff\x05\x01",
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

    static readonly short[] DFA58_eot = DFA.UnpackEncodedString(DFA58_eotS);
    static readonly short[] DFA58_eof = DFA.UnpackEncodedString(DFA58_eofS);
    static readonly char[] DFA58_min = DFA.UnpackEncodedStringToUnsignedChars(DFA58_minS);
    static readonly char[] DFA58_max = DFA.UnpackEncodedStringToUnsignedChars(DFA58_maxS);
    static readonly short[] DFA58_accept = DFA.UnpackEncodedString(DFA58_acceptS);
    static readonly short[] DFA58_special = DFA.UnpackEncodedString(DFA58_specialS);
    static readonly short[][] DFA58_transition = DFA.UnpackEncodedStringArray(DFA58_transitionS);

    protected class DFA58 : DFA
    {
        public DFA58(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 58;
            this.eot = DFA58_eot;
            this.eof = DFA58_eof;
            this.min = DFA58_min;
            this.max = DFA58_max;
            this.accept = DFA58_accept;
            this.special = DFA58_special;
            this.transition = DFA58_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 402:24: ( '&' equality_expression )*"; }
        }

    }

    const string DFA59_eotS =
        "\x0f\uffff";
    const string DFA59_eofS =
        "\x01\x01\x0e\uffff";
    const string DFA59_minS =
        "\x01\x18\x0e\uffff";
    const string DFA59_maxS =
        "\x01\x52\x0e\uffff";
    const string DFA59_acceptS =
        "\x01\uffff\x01\x02\x0c\uffff\x01\x01";
    const string DFA59_specialS =
        "\x0f\uffff}>";
    static readonly string[] DFA59_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x0b\uffff\x01\x01\x0c\uffff\x05\x01\x02"+
            "\x0e",
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

    static readonly short[] DFA59_eot = DFA.UnpackEncodedString(DFA59_eotS);
    static readonly short[] DFA59_eof = DFA.UnpackEncodedString(DFA59_eofS);
    static readonly char[] DFA59_min = DFA.UnpackEncodedStringToUnsignedChars(DFA59_minS);
    static readonly char[] DFA59_max = DFA.UnpackEncodedStringToUnsignedChars(DFA59_maxS);
    static readonly short[] DFA59_accept = DFA.UnpackEncodedString(DFA59_acceptS);
    static readonly short[] DFA59_special = DFA.UnpackEncodedString(DFA59_specialS);
    static readonly short[][] DFA59_transition = DFA.UnpackEncodedStringArray(DFA59_transitionS);

    protected class DFA59 : DFA
    {
        public DFA59(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 59;
            this.eot = DFA59_eot;
            this.eof = DFA59_eof;
            this.min = DFA59_min;
            this.max = DFA59_max;
            this.accept = DFA59_accept;
            this.special = DFA59_special;
            this.transition = DFA59_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 405:26: ( ( '==' | '!=' ) relational_expression )*"; }
        }

    }

    const string DFA60_eotS =
        "\x10\uffff";
    const string DFA60_eofS =
        "\x01\x01\x0f\uffff";
    const string DFA60_minS =
        "\x01\x18\x0f\uffff";
    const string DFA60_maxS =
        "\x01\x56\x0f\uffff";
    const string DFA60_acceptS =
        "\x01\uffff\x01\x02\x0d\uffff\x01\x01";
    const string DFA60_specialS =
        "\x10\uffff}>";
    static readonly string[] DFA60_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x0b\uffff\x01\x01\x0c\uffff\x07\x01\x04"+
            "\x0f",
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
            get { return "()* loopback of 409:21: ( ( '<' | '>' | '<=' | '>=' ) shift_expression )*"; }
        }

    }

    const string DFA61_eotS =
        "\x11\uffff";
    const string DFA61_eofS =
        "\x01\x01\x10\uffff";
    const string DFA61_minS =
        "\x01\x18\x10\uffff";
    const string DFA61_maxS =
        "\x01\x58\x10\uffff";
    const string DFA61_acceptS =
        "\x01\uffff\x01\x02\x0e\uffff\x01\x01";
    const string DFA61_specialS =
        "\x11\uffff}>";
    static readonly string[] DFA61_transitionS = {
            "\x02\x01\x0f\uffff\x01\x01\x02\uffff\x01\x01\x04\uffff\x01"+
            "\x01\x01\uffff\x01\x01\x0b\uffff\x01\x01\x0c\uffff\x0b\x01\x02"+
            "\x10",
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

    static readonly short[] DFA61_eot = DFA.UnpackEncodedString(DFA61_eotS);
    static readonly short[] DFA61_eof = DFA.UnpackEncodedString(DFA61_eofS);
    static readonly char[] DFA61_min = DFA.UnpackEncodedStringToUnsignedChars(DFA61_minS);
    static readonly char[] DFA61_max = DFA.UnpackEncodedStringToUnsignedChars(DFA61_maxS);
    static readonly short[] DFA61_accept = DFA.UnpackEncodedString(DFA61_acceptS);
    static readonly short[] DFA61_special = DFA.UnpackEncodedString(DFA61_specialS);
    static readonly short[][] DFA61_transition = DFA.UnpackEncodedStringArray(DFA61_transitionS);

    protected class DFA61 : DFA
    {
        public DFA61(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 61;
            this.eot = DFA61_eot;
            this.eof = DFA61_eof;
            this.min = DFA61_min;
            this.max = DFA61_max;
            this.accept = DFA61_accept;
            this.special = DFA61_special;
            this.transition = DFA61_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 413:24: ( ( '<<' | '>>' ) additive_expression )*"; }
        }

    }

    const string DFA62_eotS =
        "\x2d\uffff";
    const string DFA62_eofS =
        "\x2d\uffff";
    const string DFA62_minS =
        "\x01\x04\x01\x18\x2b\uffff";
    const string DFA62_maxS =
        "\x01\x64\x01\x58\x2b\uffff";
    const string DFA62_acceptS =
        "\x02\uffff\x01\x01\x01\uffff\x01\x02\x01\x03\x06\uffff\x01\x04"+
        "\x01\uffff\x01\x05\x02\uffff\x01\x06\x1b\uffff";
    const string DFA62_specialS =
        "\x2d\uffff}>";
    static readonly string[] DFA62_transitionS = {
            "\x01\x01\x06\x05\x0d\uffff\x01\x05\x0f\uffff\x01\x04\x07\uffff"+
            "\x01\x05\x03\uffff\x01\x05\x01\uffff\x02\x05\x02\uffff\x03\x05"+
            "\x02\uffff\x03\x05\x17\uffff\x02\x02\x01\x0c\x01\uffff\x01\x0c"+
            "\x03\x0e\x04\x11",
            "\x03\x05\x11\uffff\x01\x02\x03\uffff\x01\x05\x01\uffff\x01"+
            "\x05\x01\uffff\x01\x05\x01\uffff\x06\x05\x01\uffff\x03\x05\x02"+
            "\uffff\x17\x05",
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
            get { return "418:1: statement : ( labeled_statement | compound_statement | expression_statement | selection_statement | iteration_statement | jump_statement );"; }
        }

    }

    const string DFA64_eotS =
        "\x4a\uffff";
    const string DFA64_eofS =
        "\x4a\uffff";
    const string DFA64_minS =
        "\x02\x04\x24\uffff\x01\x00\x05\uffff\x01\x00\x01\uffff\x01\x00"+
        "\x1b\uffff";
    const string DFA64_maxS =
        "\x01\x64\x01\x58\x24\uffff\x01\x00\x05\uffff\x01\x00\x01\uffff"+
        "\x01\x00\x1b\uffff";
    const string DFA64_acceptS =
        "\x02\uffff\x01\x02\x13\uffff\x01\x01\x33\uffff";
    const string DFA64_specialS =
        "\x26\uffff\x01\x00\x05\uffff\x01\x01\x01\uffff\x01\x02\x1b\uffff}>";
    static readonly string[] DFA64_transitionS = {
            "\x01\x01\x06\x02\x0c\uffff\x01\x16\x01\x02\x02\uffff\x0d\x16"+
            "\x02\x02\x02\x16\x01\uffff\x03\x16\x01\x02\x03\uffff\x01\x02"+
            "\x01\uffff\x02\x02\x02\uffff\x03\x02\x02\uffff\x03\x02\x17\uffff"+
            "\x03\x02\x01\uffff\x08\x02",
            "\x01\x16\x13\uffff\x01\x2e\x02\x02\x0d\x16\x02\uffff\x02\x16"+
            "\x01\x02\x03\x16\x01\x26\x01\uffff\x01\x02\x01\uffff\x01\x2c"+
            "\x01\uffff\x06\x02\x01\uffff\x03\x02\x02\uffff\x17\x02",
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
            "\x01\uffff",
            "",
            "",
            "",
            "",
            "",
            "\x01\uffff",
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

    static readonly short[] DFA64_eot = DFA.UnpackEncodedString(DFA64_eotS);
    static readonly short[] DFA64_eof = DFA.UnpackEncodedString(DFA64_eofS);
    static readonly char[] DFA64_min = DFA.UnpackEncodedStringToUnsignedChars(DFA64_minS);
    static readonly char[] DFA64_max = DFA.UnpackEncodedStringToUnsignedChars(DFA64_maxS);
    static readonly short[] DFA64_accept = DFA.UnpackEncodedString(DFA64_acceptS);
    static readonly short[] DFA64_special = DFA.UnpackEncodedString(DFA64_specialS);
    static readonly short[][] DFA64_transition = DFA.UnpackEncodedStringArray(DFA64_transitionS);

    protected class DFA64 : DFA
    {
        public DFA64(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 64;
            this.eot = DFA64_eot;
            this.eof = DFA64_eof;
            this.min = DFA64_min;
            this.max = DFA64_max;
            this.accept = DFA64_accept;
            this.special = DFA64_special;
            this.transition = DFA64_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 438:8: ( declaration )*"; }
        }

    }


    protected internal int DFA64_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA64_38 = input.LA(1);

                   	 
                   	int index64_38 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred136_C() && (isTypeName(input.LT(1).getText())))) ) { s = 22; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index64_38);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA64_44 = input.LA(1);

                   	 
                   	int index64_44 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred136_C() && (isTypeName(input.LT(1).getText())))) ) { s = 22; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index64_44);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA64_46 = input.LA(1);

                   	 
                   	int index64_46 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred136_C() && (isTypeName(input.LT(1).getText())))) ) { s = 22; }

                   	else if ( (true) ) { s = 2; }

                   	 
                   	input.Seek(index64_46);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae64 =
            new NoViableAltException(dfa.Description, 64, _s, input);
        dfa.Error(nvae64);
        throw nvae64;
    }
    const string DFA65_eotS =
        "\x16\uffff";
    const string DFA65_eofS =
        "\x16\uffff";
    const string DFA65_minS =
        "\x01\x04\x15\uffff";
    const string DFA65_maxS =
        "\x01\x64\x15\uffff";
    const string DFA65_acceptS =
        "\x01\uffff\x01\x01\x13\uffff\x01\x02";
    const string DFA65_specialS =
        "\x16\uffff}>";
    static readonly string[] DFA65_transitionS = {
            "\x07\x01\x0d\uffff\x01\x01\x0f\uffff\x01\x01\x01\x15\x06\uffff"+
            "\x01\x01\x03\uffff\x01\x01\x01\uffff\x02\x01\x02\uffff\x03\x01"+
            "\x02\uffff\x03\x01\x17\uffff\x03\x01\x01\uffff\x08\x01",
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
            get { return "438:21: ( statement_list )?"; }
        }

    }

    const string DFA66_eotS =
        "\x17\uffff";
    const string DFA66_eofS =
        "\x01\x01\x16\uffff";
    const string DFA66_minS =
        "\x01\x04\x16\uffff";
    const string DFA66_maxS =
        "\x01\x64\x16\uffff";
    const string DFA66_acceptS =
        "\x01\uffff\x01\x02\x01\uffff\x01\x01\x13\uffff";
    const string DFA66_specialS =
        "\x17\uffff}>";
    static readonly string[] DFA66_transitionS = {
            "\x07\x03\x0d\uffff\x01\x03\x0f\uffff\x01\x03\x01\x01\x06\uffff"+
            "\x01\x03\x03\uffff\x01\x03\x01\uffff\x02\x03\x02\uffff\x03\x03"+
            "\x02\uffff\x03\x03\x17\uffff\x03\x03\x01\uffff\x08\x03",
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

    static readonly short[] DFA66_eot = DFA.UnpackEncodedString(DFA66_eotS);
    static readonly short[] DFA66_eof = DFA.UnpackEncodedString(DFA66_eofS);
    static readonly char[] DFA66_min = DFA.UnpackEncodedStringToUnsignedChars(DFA66_minS);
    static readonly char[] DFA66_max = DFA.UnpackEncodedStringToUnsignedChars(DFA66_maxS);
    static readonly short[] DFA66_accept = DFA.UnpackEncodedString(DFA66_acceptS);
    static readonly short[] DFA66_special = DFA.UnpackEncodedString(DFA66_specialS);
    static readonly short[][] DFA66_transition = DFA.UnpackEncodedStringArray(DFA66_transitionS);

    protected class DFA66 : DFA
    {
        public DFA66(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 66;
            this.eot = DFA66_eot;
            this.eof = DFA66_eof;
            this.min = DFA66_min;
            this.max = DFA66_max;
            this.accept = DFA66_accept;
            this.special = DFA66_special;
            this.transition = DFA66_transition;

        }

        override public string Description
        {
            get { return "()+ loopback of 442:4: ( statement )+"; }
        }

    }

    const string DFA72_eotS =
        "\x0d\uffff";
    const string DFA72_eofS =
        "\x0d\uffff";
    const string DFA72_minS =
        "\x01\x61\x03\uffff\x01\x04\x08\uffff";
    const string DFA72_maxS =
        "\x01\x64\x03\uffff\x01\x41\x08\uffff";
    const string DFA72_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\uffff\x01\x04\x01\x05\x06"+
        "\uffff";
    const string DFA72_specialS =
        "\x0d\uffff}>";
    static readonly string[] DFA72_transitionS = {
            "\x01\x01\x01\x02\x01\x03\x01\x04",
            "",
            "",
            "",
            "\x07\x06\x0d\uffff\x01\x05\x17\uffff\x01\x06\x03\uffff\x01"+
            "\x06\x01\uffff\x02\x06\x02\uffff\x03\x06\x02\uffff\x03\x06",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA72_eot = DFA.UnpackEncodedString(DFA72_eotS);
    static readonly short[] DFA72_eof = DFA.UnpackEncodedString(DFA72_eofS);
    static readonly char[] DFA72_min = DFA.UnpackEncodedStringToUnsignedChars(DFA72_minS);
    static readonly char[] DFA72_max = DFA.UnpackEncodedStringToUnsignedChars(DFA72_maxS);
    static readonly short[] DFA72_accept = DFA.UnpackEncodedString(DFA72_acceptS);
    static readonly short[] DFA72_special = DFA.UnpackEncodedString(DFA72_specialS);
    static readonly short[][] DFA72_transition = DFA.UnpackEncodedStringArray(DFA72_transitionS);

    protected class DFA72 : DFA
    {
        public DFA72(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 72;
            this.eot = DFA72_eot;
            this.eof = DFA72_eof;
            this.min = DFA72_min;
            this.max = DFA72_max;
            this.accept = DFA72_accept;
            this.special = DFA72_special;
            this.transition = DFA72_transition;

        }

        override public string Description
        {
            get { return "461:1: jump_statement : ( 'goto' IDENTIFIER ';' | 'continue' ';' | 'break' ';' | 'return' ';' | 'return' expression ';' );"; }
        }

    }

    const string DFA73_eotS =
        "\x24\uffff";
    const string DFA73_eofS =
        "\x24\uffff";
    const string DFA73_minS =
        "\x01\x04\x0c\uffff\x01\x04\x04\uffff\x0f\x00\x03\uffff";
    const string DFA73_maxS =
        "\x01\x34\x0c\uffff\x01\x34\x04\uffff\x0f\x00\x03\uffff";
    const string DFA73_acceptS =
        "\x01\uffff\x01\x01\x0d\uffff\x01\x02\x14\uffff";
    const string DFA73_specialS =
        "\x12\uffff\x01\x00\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01"+
        "\x06\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01"+
        "\x0e\x03\uffff}>";
    static readonly string[] DFA73_transitionS = {
            "\x01\x0d\x16\uffff\x0d\x01\x02\uffff\x02\x01\x01\uffff\x03"+
            "\x01\x01\x0f\x03\uffff\x01\x0f",
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
            "\x01\x12\x12\uffff\x01\x0f\x03\uffff\x04\x14\x01\x15\x01\x16"+
            "\x01\x17\x01\x18\x01\x19\x01\x1a\x01\x1b\x01\x1c\x01\x1d\x01"+
            "\x0f\x01\uffff\x02\x1e\x01\uffff\x01\x1f\x02\x20\x01\x13\x01"+
            "\uffff\x01\x0f\x01\uffff\x01\x01",
            "",
            "",
            "",
            "",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "\x01\uffff",
            "",
            "",
            ""
    };

    static readonly short[] DFA73_eot = DFA.UnpackEncodedString(DFA73_eotS);
    static readonly short[] DFA73_eof = DFA.UnpackEncodedString(DFA73_eofS);
    static readonly char[] DFA73_min = DFA.UnpackEncodedStringToUnsignedChars(DFA73_minS);
    static readonly char[] DFA73_max = DFA.UnpackEncodedStringToUnsignedChars(DFA73_maxS);
    static readonly short[] DFA73_accept = DFA.UnpackEncodedString(DFA73_acceptS);
    static readonly short[] DFA73_special = DFA.UnpackEncodedString(DFA73_specialS);
    static readonly short[][] DFA73_transition = DFA.UnpackEncodedStringArray(DFA73_transitionS);

    protected class DFA73 : DFA
    {
        public DFA73(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 73;
            this.eot = DFA73_eot;
            this.eof = DFA73_eof;
            this.min = DFA73_min;
            this.max = DFA73_max;
            this.accept = DFA73_accept;
            this.special = DFA73_special;
            this.transition = DFA73_transition;

        }

        override public string Description
        {
            get { return "82:6: ( declaration_specifiers )?"; }
        }

    }


    protected internal int DFA73_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            ITokenStream input = (ITokenStream)_input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA73_18 = input.LA(1);

                   	 
                   	int index73_18 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_18);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA73_19 = input.LA(1);

                   	 
                   	int index73_19 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_19);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA73_20 = input.LA(1);

                   	 
                   	int index73_20 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_20);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA73_21 = input.LA(1);

                   	 
                   	int index73_21 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_21);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA73_22 = input.LA(1);

                   	 
                   	int index73_22 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_22);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA73_23 = input.LA(1);

                   	 
                   	int index73_23 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_23);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA73_24 = input.LA(1);

                   	 
                   	int index73_24 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_24);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA73_25 = input.LA(1);

                   	 
                   	int index73_25 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_25);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA73_26 = input.LA(1);

                   	 
                   	int index73_26 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_26);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA73_27 = input.LA(1);

                   	 
                   	int index73_27 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_27);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA73_28 = input.LA(1);

                   	 
                   	int index73_28 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_28);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA73_29 = input.LA(1);

                   	 
                   	int index73_29 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_29);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA73_30 = input.LA(1);

                   	 
                   	int index73_30 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_30);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA73_31 = input.LA(1);

                   	 
                   	int index73_31 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_31);
                   	if ( s >= 0 ) return s;
                   	break;
               	case 14 : 
                   	int LA73_32 = input.LA(1);

                   	 
                   	int index73_32 = input.Index();
                   	input.Rewind();
                   	s = -1;
                   	if ( ((synpred2_C() && (isTypeName(input.LT(1).getText())))) ) { s = 1; }

                   	else if ( (true) ) { s = 15; }

                   	 
                   	input.Seek(index73_32);
                   	if ( s >= 0 ) return s;
                   	break;
        }
        if (state.backtracking > 0) {state.failed = true; return -1;}
        NoViableAltException nvae73 =
            new NoViableAltException(dfa.Description, 73, _s, input);
        dfa.Error(nvae73);
        throw nvae73;
    }
    const string DFA74_eotS =
        "\x11\uffff";
    const string DFA74_eofS =
        "\x11\uffff";
    const string DFA74_minS =
        "\x01\x04\x10\uffff";
    const string DFA74_maxS =
        "\x01\x2f\x10\uffff";
    const string DFA74_acceptS =
        "\x01\uffff\x01\x02\x01\x01\x0e\uffff";
    const string DFA74_specialS =
        "\x11\uffff}>";
    static readonly string[] DFA74_transitionS = {
            "\x01\x02\x12\uffff\x01\x02\x03\uffff\x0d\x02\x01\x01\x01\uffff"+
            "\x02\x02\x01\uffff\x03\x02",
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

    static readonly short[] DFA74_eot = DFA.UnpackEncodedString(DFA74_eotS);
    static readonly short[] DFA74_eof = DFA.UnpackEncodedString(DFA74_eofS);
    static readonly char[] DFA74_min = DFA.UnpackEncodedStringToUnsignedChars(DFA74_minS);
    static readonly char[] DFA74_max = DFA.UnpackEncodedStringToUnsignedChars(DFA74_maxS);
    static readonly short[] DFA74_accept = DFA.UnpackEncodedString(DFA74_acceptS);
    static readonly short[] DFA74_special = DFA.UnpackEncodedString(DFA74_specialS);
    static readonly short[][] DFA74_transition = DFA.UnpackEncodedStringArray(DFA74_transitionS);

    protected class DFA74 : DFA
    {
        public DFA74(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 74;
            this.eot = DFA74_eot;
            this.eof = DFA74_eof;
            this.min = DFA74_min;
            this.max = DFA74_max;
            this.accept = DFA74_accept;
            this.special = DFA74_special;
            this.transition = DFA74_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 82:41: ( declaration )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_external_declaration_in_translation_unit86 = new BitSet(new ulong[]{0x0011ECFFF8800012UL});
    public static readonly BitSet FOLLOW_function_definition_in_external_declaration122 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_in_external_declaration127 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_function_definition149 = new BitSet(new ulong[]{0x0011ECFFF8000010UL});
    public static readonly BitSet FOLLOW_declarator_in_function_definition152 = new BitSet(new ulong[]{0x0011EDFFF8800010UL});
    public static readonly BitSet FOLLOW_declaration_in_function_definition158 = new BitSet(new ulong[]{0x0011EDFFF8800010UL});
    public static readonly BitSet FOLLOW_compound_statement_in_function_definition161 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_compound_statement_in_function_definition168 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_23_in_declaration196 = new BitSet(new ulong[]{0x0011ECFFF8000010UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_declaration198 = new BitSet(new ulong[]{0x0011ECFFF8000010UL});
    public static readonly BitSet FOLLOW_init_declarator_list_in_declaration206 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_declaration208 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_declaration214 = new BitSet(new ulong[]{0x0011ECFFF9000010UL});
    public static readonly BitSet FOLLOW_init_declarator_list_in_declaration216 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_declaration219 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_storage_class_specifier_in_declaration_specifiers236 = new BitSet(new ulong[]{0x0000ECFFF8000012UL});
    public static readonly BitSet FOLLOW_type_specifier_in_declaration_specifiers244 = new BitSet(new ulong[]{0x0000ECFFF8000012UL});
    public static readonly BitSet FOLLOW_type_qualifier_in_declaration_specifiers258 = new BitSet(new ulong[]{0x0000ECFFF8000012UL});
    public static readonly BitSet FOLLOW_init_declarator_in_init_declarator_list280 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_init_declarator_list283 = new BitSet(new ulong[]{0x0011ECFFF8000010UL});
    public static readonly BitSet FOLLOW_init_declarator_in_init_declarator_list285 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_declarator_in_init_declarator298 = new BitSet(new ulong[]{0x0000000004000002UL});
    public static readonly BitSet FOLLOW_26_in_init_declarator301 = new BitSet(new ulong[]{0x9CD10100000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_initializer_in_init_declarator303 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_storage_class_specifier0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_31_in_type_specifier342 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_type_specifier347 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_33_in_type_specifier352 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_34_in_type_specifier357 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_35_in_type_specifier362 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_36_in_type_specifier367 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_37_in_type_specifier372 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_38_in_type_specifier377 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_type_specifier382 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_or_union_specifier_in_type_specifier387 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enum_specifier_in_type_specifier392 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_id_in_type_specifier397 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_type_id415 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_or_union_in_struct_or_union_specifier448 = new BitSet(new ulong[]{0x0000010000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_struct_or_union_specifier450 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_40_in_struct_or_union_specifier453 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_struct_declaration_list_in_struct_or_union_specifier455 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_struct_or_union_specifier457 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_or_union_in_struct_or_union_specifier462 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_struct_or_union_specifier464 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_struct_or_union0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_struct_declaration_in_struct_declaration_list491 = new BitSet(new ulong[]{0x0000ECFFF8000012UL});
    public static readonly BitSet FOLLOW_specifier_qualifier_list_in_struct_declaration503 = new BitSet(new ulong[]{0x0011FCFFF8000010UL});
    public static readonly BitSet FOLLOW_struct_declarator_list_in_struct_declaration505 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_struct_declaration507 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_qualifier_in_specifier_qualifier_list520 = new BitSet(new ulong[]{0x0000ECFFF8000012UL});
    public static readonly BitSet FOLLOW_type_specifier_in_specifier_qualifier_list524 = new BitSet(new ulong[]{0x0000ECFFF8000012UL});
    public static readonly BitSet FOLLOW_struct_declarator_in_struct_declarator_list538 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_struct_declarator_list541 = new BitSet(new ulong[]{0x0011FCFFF8000010UL});
    public static readonly BitSet FOLLOW_struct_declarator_in_struct_declarator_list543 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_declarator_in_struct_declarator556 = new BitSet(new ulong[]{0x0000100000000002UL});
    public static readonly BitSet FOLLOW_44_in_struct_declarator559 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_constant_expression_in_struct_declarator561 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_struct_declarator568 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_constant_expression_in_struct_declarator570 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_45_in_enum_specifier588 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_40_in_enum_specifier590 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_enumerator_list_in_enum_specifier592 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_enum_specifier594 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_45_in_enum_specifier599 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_specifier601 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_40_in_enum_specifier603 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_enumerator_list_in_enum_specifier605 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_enum_specifier607 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_45_in_enum_specifier612 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enum_specifier614 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enumerator_in_enumerator_list625 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_enumerator_list628 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_enumerator_in_enumerator_list630 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_enumerator643 = new BitSet(new ulong[]{0x0000000004000002UL});
    public static readonly BitSet FOLLOW_26_in_enumerator646 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_constant_expression_in_enumerator648 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_type_qualifier0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pointer_in_declarator677 = new BitSet(new ulong[]{0x0011000000000010UL});
    public static readonly BitSet FOLLOW_direct_declarator_in_declarator680 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pointer_in_declarator685 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_direct_declarator700 = new BitSet(new ulong[]{0x0005000000000002UL});
    public static readonly BitSet FOLLOW_48_in_direct_declarator711 = new BitSet(new ulong[]{0x0011ECFFF8000010UL});
    public static readonly BitSet FOLLOW_declarator_in_direct_declarator713 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_direct_declarator715 = new BitSet(new ulong[]{0x0005000000000002UL});
    public static readonly BitSet FOLLOW_declarator_suffix_in_direct_declarator729 = new BitSet(new ulong[]{0x0005000000000002UL});
    public static readonly BitSet FOLLOW_50_in_declarator_suffix743 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_constant_expression_in_declarator_suffix745 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_51_in_declarator_suffix747 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_50_in_declarator_suffix757 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_51_in_declarator_suffix759 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_declarator_suffix769 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_parameter_type_list_in_declarator_suffix771 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_declarator_suffix773 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_declarator_suffix783 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_identifier_list_in_declarator_suffix785 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_declarator_suffix787 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_declarator_suffix797 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_declarator_suffix799 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_pointer810 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_type_qualifier_in_pointer812 = new BitSet(new ulong[]{0x0010ECFFF8000012UL});
    public static readonly BitSet FOLLOW_pointer_in_pointer815 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_pointer821 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_pointer_in_pointer823 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_pointer828 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_parameter_list_in_parameter_type_list839 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_parameter_type_list842 = new BitSet(new ulong[]{0x0020000000000000UL});
    public static readonly BitSet FOLLOW_53_in_parameter_type_list844 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_parameter_declaration_in_parameter_list857 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_parameter_list860 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_parameter_declaration_in_parameter_list862 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_parameter_declaration875 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_declarator_in_parameter_declaration878 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_abstract_declarator_in_parameter_declaration880 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_identifier_list893 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_identifier_list896 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_identifier_list898 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_specifier_qualifier_list_in_type_name911 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_abstract_declarator_in_type_name913 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pointer_in_abstract_declarator925 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_direct_abstract_declarator_in_abstract_declarator927 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_direct_abstract_declarator_in_abstract_declarator933 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_direct_abstract_declarator946 = new BitSet(new ulong[]{0x0015ECFFF8000010UL});
    public static readonly BitSet FOLLOW_abstract_declarator_in_direct_abstract_declarator948 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_direct_abstract_declarator950 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_abstract_declarator_suffix_in_direct_abstract_declarator954 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_abstract_declarator_suffix_in_direct_abstract_declarator958 = new BitSet(new ulong[]{0x0015ECFFF8000012UL});
    public static readonly BitSet FOLLOW_50_in_abstract_declarator_suffix970 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_51_in_abstract_declarator_suffix972 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_50_in_abstract_declarator_suffix977 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_constant_expression_in_abstract_declarator_suffix979 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_51_in_abstract_declarator_suffix981 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_abstract_declarator_suffix986 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_abstract_declarator_suffix988 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_abstract_declarator_suffix993 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_parameter_type_list_in_abstract_declarator_suffix995 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_abstract_declarator_suffix997 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_assignment_expression_in_initializer1009 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_40_in_initializer1014 = new BitSet(new ulong[]{0x9CD10100000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_initializer_list_in_initializer1016 = new BitSet(new ulong[]{0x0000020002000000UL});
    public static readonly BitSet FOLLOW_25_in_initializer1018 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_initializer1021 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_initializer_in_initializer_list1032 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_initializer_list1035 = new BitSet(new ulong[]{0x9CD10100000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_initializer_in_initializer_list1037 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_assignment_expression_in_argument_expression_list1054 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_argument_expression_list1057 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_assignment_expression_in_argument_expression_list1059 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_multiplicative_expression_in_additive_expression1073 = new BitSet(new ulong[]{0x00C0000000000002UL});
    public static readonly BitSet FOLLOW_54_in_additive_expression1077 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_multiplicative_expression_in_additive_expression1079 = new BitSet(new ulong[]{0x00C0000000000002UL});
    public static readonly BitSet FOLLOW_55_in_additive_expression1083 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_multiplicative_expression_in_additive_expression1085 = new BitSet(new ulong[]{0x00C0000000000002UL});
    public static readonly BitSet FOLLOW_cast_expression_in_multiplicative_expression1099 = new BitSet(new ulong[]{0x0310000000000002UL});
    public static readonly BitSet FOLLOW_52_in_multiplicative_expression1103 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_cast_expression_in_multiplicative_expression1105 = new BitSet(new ulong[]{0x0310000000000002UL});
    public static readonly BitSet FOLLOW_56_in_multiplicative_expression1109 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_cast_expression_in_multiplicative_expression1111 = new BitSet(new ulong[]{0x0310000000000002UL});
    public static readonly BitSet FOLLOW_57_in_multiplicative_expression1115 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_cast_expression_in_multiplicative_expression1117 = new BitSet(new ulong[]{0x0310000000000002UL});
    public static readonly BitSet FOLLOW_48_in_cast_expression1130 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_type_name_in_cast_expression1132 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_cast_expression1134 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_cast_expression_in_cast_expression1136 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_cast_expression1141 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_postfix_expression_in_unary_expression1152 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_58_in_unary_expression1157 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_unary_expression_in_unary_expression1159 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_59_in_unary_expression1164 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_unary_expression_in_unary_expression1166 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_operator_in_unary_expression1171 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_cast_expression_in_unary_expression1173 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_60_in_unary_expression1178 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_unary_expression_in_unary_expression1180 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_60_in_unary_expression1185 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_unary_expression1187 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_type_name_in_unary_expression1189 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_unary_expression1191 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_primary_expression_in_postfix_expression1204 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_50_in_postfix_expression1218 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_postfix_expression1220 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_51_in_postfix_expression1222 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_48_in_postfix_expression1236 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_postfix_expression1238 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_48_in_postfix_expression1252 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_argument_expression_list_in_postfix_expression1254 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_postfix_expression1256 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_61_in_postfix_expression1270 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_postfix_expression1272 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_62_in_postfix_expression1286 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_postfix_expression1288 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_58_in_postfix_expression1302 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_59_in_postfix_expression1316 = new BitSet(new ulong[]{0x6C05000000000002UL});
    public static readonly BitSet FOLLOW_set_in_unary_operator0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_primary_expression1374 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_constant_in_primary_expression1379 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_primary_expression1384 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_primary_expression1386 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_primary_expression1388 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_constant0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_assignment_expression_in_expression1463 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_25_in_expression1466 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_assignment_expression_in_expression1468 = new BitSet(new ulong[]{0x0000000002000002UL});
    public static readonly BitSet FOLLOW_conditional_expression_in_constant_expression1481 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_lvalue_in_assignment_expression1492 = new BitSet(new ulong[]{0x0000000004000000UL,0x0000000000000FFCUL});
    public static readonly BitSet FOLLOW_assignment_operator_in_assignment_expression1494 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_assignment_expression_in_assignment_expression1496 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_conditional_expression_in_assignment_expression1501 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_unary_expression_in_lvalue1513 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_assignment_operator0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logical_or_expression_in_conditional_expression1585 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_conditional_expression1588 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_conditional_expression1590 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_conditional_expression1592 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_conditional_expression_in_conditional_expression1594 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_logical_and_expression_in_logical_or_expression1607 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_logical_or_expression1610 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_logical_and_expression_in_logical_or_expression1612 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_inclusive_or_expression_in_logical_and_expression1625 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_78_in_logical_and_expression1628 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_inclusive_or_expression_in_logical_and_expression1630 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_exclusive_or_expression_in_inclusive_or_expression1643 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_inclusive_or_expression1646 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_exclusive_or_expression_in_inclusive_or_expression1648 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_and_expression_in_exclusive_or_expression1661 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_80_in_exclusive_or_expression1664 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_and_expression_in_exclusive_or_expression1666 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_equality_expression_in_and_expression1679 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_63_in_and_expression1682 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_equality_expression_in_and_expression1684 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_relational_expression_in_equality_expression1696 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000060000UL});
    public static readonly BitSet FOLLOW_set_in_equality_expression1699 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_relational_expression_in_equality_expression1705 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000060000UL});
    public static readonly BitSet FOLLOW_shift_expression_in_relational_expression1718 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000780000UL});
    public static readonly BitSet FOLLOW_set_in_relational_expression1721 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_shift_expression_in_relational_expression1731 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000780000UL});
    public static readonly BitSet FOLLOW_additive_expression_in_shift_expression1744 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000001800000UL});
    public static readonly BitSet FOLLOW_set_in_shift_expression1747 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_additive_expression_in_shift_expression1753 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000001800000UL});
    public static readonly BitSet FOLLOW_labeled_statement_in_statement1768 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_compound_statement_in_statement1773 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_statement_in_statement1778 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_selection_statement_in_statement1783 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_iteration_statement_in_statement1788 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_jump_statement_in_statement1793 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_labeled_statement1804 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_labeled_statement1806 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_labeled_statement1808 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_89_in_labeled_statement1813 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_constant_expression_in_labeled_statement1815 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_labeled_statement1817 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_labeled_statement1819 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_90_in_labeled_statement1824 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_labeled_statement1826 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_labeled_statement1828 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_40_in_compound_statement1850 = new BitSet(new ulong[]{0x9CD1EFFFF98007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_declaration_in_compound_statement1852 = new BitSet(new ulong[]{0x9CD1EFFFF98007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_list_in_compound_statement1855 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_41_in_compound_statement1858 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_statement_in_statement_list1869 = new BitSet(new ulong[]{0x9CD10100010007F2UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_24_in_expression_statement1881 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_expression_in_expression_statement1886 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_expression_statement1888 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_91_in_selection_statement1899 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_selection_statement1901 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_selection_statement1903 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_selection_statement1905 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_selection_statement1907 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000010000000UL});
    public static readonly BitSet FOLLOW_92_in_selection_statement1922 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_selection_statement1924 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_93_in_selection_statement1931 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_selection_statement1933 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_selection_statement1935 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_selection_statement1937 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_selection_statement1939 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_94_in_iteration_statement1950 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_iteration_statement1952 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_iteration_statement1954 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_iteration_statement1956 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_iteration_statement1958 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_95_in_iteration_statement1963 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_iteration_statement1965 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000040000000UL});
    public static readonly BitSet FOLLOW_94_in_iteration_statement1967 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_iteration_statement1969 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_iteration_statement1971 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_iteration_statement1973 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_iteration_statement1975 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_96_in_iteration_statement1980 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_iteration_statement1982 = new BitSet(new ulong[]{0x9CD10000010007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_statement_in_iteration_statement1984 = new BitSet(new ulong[]{0x9CD10000010007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_statement_in_iteration_statement1986 = new BitSet(new ulong[]{0x9CD30000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_iteration_statement1988 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_iteration_statement1991 = new BitSet(new ulong[]{0x9CD10100010007F0UL,0x0000001FEE000003UL});
    public static readonly BitSet FOLLOW_statement_in_iteration_statement1993 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_97_in_jump_statement2004 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_jump_statement2006 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_jump_statement2008 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_98_in_jump_statement2013 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_jump_statement2015 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_99_in_jump_statement2020 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_jump_statement2022 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_100_in_jump_statement2027 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_jump_statement2029 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_100_in_jump_statement2034 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_expression_in_jump_statement2036 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_jump_statement2038 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_synpred2_C109 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_synpred4_C109 = new BitSet(new ulong[]{0x0011ECFFF8000010UL});
    public static readonly BitSet FOLLOW_declarator_in_synpred4_C112 = new BitSet(new ulong[]{0x0011EDFFF8800010UL});
    public static readonly BitSet FOLLOW_declaration_in_synpred4_C114 = new BitSet(new ulong[]{0x0011EDFFF8800010UL});
    public static readonly BitSet FOLLOW_40_in_synpred4_C117 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_synpred5_C149 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_specifiers_in_synpred8_C198 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_specifier_in_synpred12_C244 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_specifier_in_synpred35_C524 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pointer_in_synpred45_C677 = new BitSet(new ulong[]{0x0011000000000010UL});
    public static readonly BitSet FOLLOW_direct_declarator_in_synpred45_C680 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declarator_suffix_in_synpred47_C729 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_synpred50_C769 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_parameter_type_list_in_synpred50_C771 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_synpred50_C773 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_synpred51_C783 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_identifier_list_in_synpred51_C785 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_synpred51_C787 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_qualifier_in_synpred52_C812 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_pointer_in_synpred53_C815 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_synpred54_C810 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_type_qualifier_in_synpred54_C812 = new BitSet(new ulong[]{0x0010ECFFF8000012UL});
    public static readonly BitSet FOLLOW_pointer_in_synpred54_C815 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_52_in_synpred55_C821 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_pointer_in_synpred55_C823 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declarator_in_synpred58_C878 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_abstract_declarator_in_synpred59_C880 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_direct_abstract_declarator_in_synpred62_C927 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_abstract_declarator_suffix_in_synpred65_C958 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_synpred78_C1130 = new BitSet(new ulong[]{0x0000ECFFF8000010UL});
    public static readonly BitSet FOLLOW_type_name_in_synpred78_C1132 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_synpred78_C1134 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_cast_expression_in_synpred78_C1136 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_60_in_synpred83_C1178 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_unary_expression_in_synpred83_C1180 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_lvalue_in_synpred104_C1492 = new BitSet(new ulong[]{0x0000000004000000UL,0x0000000000000FFCUL});
    public static readonly BitSet FOLLOW_assignment_operator_in_synpred104_C1494 = new BitSet(new ulong[]{0x9CD10000000007F0UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_assignment_expression_in_synpred104_C1496 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_declaration_in_synpred136_C1852 = new BitSet(new ulong[]{0x0000000000000002UL});

}
