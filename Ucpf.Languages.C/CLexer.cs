using Ucpf.Languages.Common.Antlr;
using System.Collections.Generic;
// $ANTLR 3.2 Sep 23, 2009 12:02:23 C.g 2010-12-03 00:00:49

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class CLexer : Lexer {
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
    public const int T__71 = 71;
    public const int WS = 19;
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

    public CLexer() 
    {
		InitializeCyclicDFAs();
    }
    public CLexer(ICharStream input)
		: this(input, null) {
    }
    public CLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "C.g";} 
    }

    // $ANTLR start "T__23"
    public void mT__23() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__23;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:7:7: ( 'typedef' )
            // C.g:7:9: 'typedef'
            {
            	Match("typedef"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__23"

    // $ANTLR start "T__24"
    public void mT__24() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__24;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:8:7: ( ';' )
            // C.g:8:9: ';'
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
    // $ANTLR end "T__24"

    // $ANTLR start "T__25"
    public void mT__25() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__25;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:9:7: ( ',' )
            // C.g:9:9: ','
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
    // $ANTLR end "T__25"

    // $ANTLR start "T__26"
    public void mT__26() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__26;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:10:7: ( '=' )
            // C.g:10:9: '='
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
    // $ANTLR end "T__26"

    // $ANTLR start "T__27"
    public void mT__27() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__27;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:11:7: ( 'extern' )
            // C.g:11:9: 'extern'
            {
            	Match("extern"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__27"

    // $ANTLR start "T__28"
    public void mT__28() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__28;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:12:7: ( 'static' )
            // C.g:12:9: 'static'
            {
            	Match("static"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__28"

    // $ANTLR start "T__29"
    public void mT__29() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__29;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:13:7: ( 'auto' )
            // C.g:13:9: 'auto'
            {
            	Match("auto"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__29"

    // $ANTLR start "T__30"
    public void mT__30() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__30;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:14:7: ( 'register' )
            // C.g:14:9: 'register'
            {
            	Match("register"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__30"

    // $ANTLR start "T__31"
    public void mT__31() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__31;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:15:7: ( 'void' )
            // C.g:15:9: 'void'
            {
            	Match("void"); 


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
            // C.g:16:7: ( 'char' )
            // C.g:16:9: 'char'
            {
            	Match("char"); 


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
            // C.g:17:7: ( 'short' )
            // C.g:17:9: 'short'
            {
            	Match("short"); 


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
            // C.g:18:7: ( 'int' )
            // C.g:18:9: 'int'
            {
            	Match("int"); 


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
            // C.g:19:7: ( 'long' )
            // C.g:19:9: 'long'
            {
            	Match("long"); 


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
            // C.g:20:7: ( 'float' )
            // C.g:20:9: 'float'
            {
            	Match("float"); 


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
            // C.g:21:7: ( 'double' )
            // C.g:21:9: 'double'
            {
            	Match("double"); 


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
            // C.g:22:7: ( 'signed' )
            // C.g:22:9: 'signed'
            {
            	Match("signed"); 


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
            // C.g:23:7: ( 'unsigned' )
            // C.g:23:9: 'unsigned'
            {
            	Match("unsigned"); 


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
            // C.g:24:7: ( '{' )
            // C.g:24:9: '{'
            {
            	Match('{'); 

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
            // C.g:25:7: ( '}' )
            // C.g:25:9: '}'
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
    // $ANTLR end "T__41"

    // $ANTLR start "T__42"
    public void mT__42() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__42;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:26:7: ( 'struct' )
            // C.g:26:9: 'struct'
            {
            	Match("struct"); 


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
            // C.g:27:7: ( 'union' )
            // C.g:27:9: 'union'
            {
            	Match("union"); 


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
            // C.g:28:7: ( ':' )
            // C.g:28:9: ':'
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
    // $ANTLR end "T__44"

    // $ANTLR start "T__45"
    public void mT__45() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__45;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:29:7: ( 'enum' )
            // C.g:29:9: 'enum'
            {
            	Match("enum"); 


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
            // C.g:30:7: ( 'const' )
            // C.g:30:9: 'const'
            {
            	Match("const"); 


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
            // C.g:31:7: ( 'volatile' )
            // C.g:31:9: 'volatile'
            {
            	Match("volatile"); 


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
            // C.g:32:7: ( '(' )
            // C.g:32:9: '('
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
    // $ANTLR end "T__48"

    // $ANTLR start "T__49"
    public void mT__49() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__49;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:33:7: ( ')' )
            // C.g:33:9: ')'
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
    // $ANTLR end "T__49"

    // $ANTLR start "T__50"
    public void mT__50() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__50;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:34:7: ( '[' )
            // C.g:34:9: '['
            {
            	Match('['); 

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
            // C.g:35:7: ( ']' )
            // C.g:35:9: ']'
            {
            	Match(']'); 

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
            // C.g:36:7: ( '*' )
            // C.g:36:9: '*'
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
    // $ANTLR end "T__52"

    // $ANTLR start "T__53"
    public void mT__53() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__53;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:37:7: ( '...' )
            // C.g:37:9: '...'
            {
            	Match("..."); 


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
            // C.g:38:7: ( '+' )
            // C.g:38:9: '+'
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
    // $ANTLR end "T__54"

    // $ANTLR start "T__55"
    public void mT__55() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__55;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:39:7: ( '-' )
            // C.g:39:9: '-'
            {
            	Match('-'); 

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
            // C.g:40:7: ( '/' )
            // C.g:40:9: '/'
            {
            	Match('/'); 

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
            // C.g:41:7: ( '%' )
            // C.g:41:9: '%'
            {
            	Match('%'); 

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
            // C.g:42:7: ( '++' )
            // C.g:42:9: '++'
            {
            	Match("++"); 


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
            // C.g:43:7: ( '--' )
            // C.g:43:9: '--'
            {
            	Match("--"); 


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
            // C.g:44:7: ( 'sizeof' )
            // C.g:44:9: 'sizeof'
            {
            	Match("sizeof"); 


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
            // C.g:45:7: ( '.' )
            // C.g:45:9: '.'
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
    // $ANTLR end "T__61"

    // $ANTLR start "T__62"
    public void mT__62() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__62;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:46:7: ( '->' )
            // C.g:46:9: '->'
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
    // $ANTLR end "T__62"

    // $ANTLR start "T__63"
    public void mT__63() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__63;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:47:7: ( '&' )
            // C.g:47:9: '&'
            {
            	Match('&'); 

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
            // C.g:48:7: ( '~' )
            // C.g:48:9: '~'
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
    // $ANTLR end "T__64"

    // $ANTLR start "T__65"
    public void mT__65() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__65;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:49:7: ( '!' )
            // C.g:49:9: '!'
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
    // $ANTLR end "T__65"

    // $ANTLR start "T__66"
    public void mT__66() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__66;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:50:7: ( '*=' )
            // C.g:50:9: '*='
            {
            	Match("*="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__66"

    // $ANTLR start "T__67"
    public void mT__67() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__67;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:51:7: ( '/=' )
            // C.g:51:9: '/='
            {
            	Match("/="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__67"

    // $ANTLR start "T__68"
    public void mT__68() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__68;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:52:7: ( '%=' )
            // C.g:52:9: '%='
            {
            	Match("%="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__68"

    // $ANTLR start "T__69"
    public void mT__69() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__69;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:53:7: ( '+=' )
            // C.g:53:9: '+='
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
    // $ANTLR end "T__69"

    // $ANTLR start "T__70"
    public void mT__70() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__70;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:54:7: ( '-=' )
            // C.g:54:9: '-='
            {
            	Match("-="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__70"

    // $ANTLR start "T__71"
    public void mT__71() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__71;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:55:7: ( '<<=' )
            // C.g:55:9: '<<='
            {
            	Match("<<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__71"

    // $ANTLR start "T__72"
    public void mT__72() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__72;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:56:7: ( '>>=' )
            // C.g:56:9: '>>='
            {
            	Match(">>="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__72"

    // $ANTLR start "T__73"
    public void mT__73() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__73;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:57:7: ( '&=' )
            // C.g:57:9: '&='
            {
            	Match("&="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__73"

    // $ANTLR start "T__74"
    public void mT__74() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__74;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:58:7: ( '^=' )
            // C.g:58:9: '^='
            {
            	Match("^="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__74"

    // $ANTLR start "T__75"
    public void mT__75() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__75;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:59:7: ( '|=' )
            // C.g:59:9: '|='
            {
            	Match("|="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__75"

    // $ANTLR start "T__76"
    public void mT__76() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__76;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:60:7: ( '?' )
            // C.g:60:9: '?'
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
    // $ANTLR end "T__76"

    // $ANTLR start "T__77"
    public void mT__77() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__77;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:61:7: ( '||' )
            // C.g:61:9: '||'
            {
            	Match("||"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__77"

    // $ANTLR start "T__78"
    public void mT__78() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__78;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:62:7: ( '&&' )
            // C.g:62:9: '&&'
            {
            	Match("&&"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__78"

    // $ANTLR start "T__79"
    public void mT__79() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__79;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:63:7: ( '|' )
            // C.g:63:9: '|'
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
    // $ANTLR end "T__79"

    // $ANTLR start "T__80"
    public void mT__80() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__80;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:64:7: ( '^' )
            // C.g:64:9: '^'
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
    // $ANTLR end "T__80"

    // $ANTLR start "T__81"
    public void mT__81() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__81;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:65:7: ( '==' )
            // C.g:65:9: '=='
            {
            	Match("=="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__81"

    // $ANTLR start "T__82"
    public void mT__82() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__82;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:66:7: ( '!=' )
            // C.g:66:9: '!='
            {
            	Match("!="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__82"

    // $ANTLR start "T__83"
    public void mT__83() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__83;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:67:7: ( '<' )
            // C.g:67:9: '<'
            {
            	Match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__83"

    // $ANTLR start "T__84"
    public void mT__84() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__84;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:68:7: ( '>' )
            // C.g:68:9: '>'
            {
            	Match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__84"

    // $ANTLR start "T__85"
    public void mT__85() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__85;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:69:7: ( '<=' )
            // C.g:69:9: '<='
            {
            	Match("<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__85"

    // $ANTLR start "T__86"
    public void mT__86() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__86;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:70:7: ( '>=' )
            // C.g:70:9: '>='
            {
            	Match(">="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__86"

    // $ANTLR start "T__87"
    public void mT__87() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__87;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:71:7: ( '<<' )
            // C.g:71:9: '<<'
            {
            	Match("<<"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__87"

    // $ANTLR start "T__88"
    public void mT__88() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__88;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:72:7: ( '>>' )
            // C.g:72:9: '>>'
            {
            	Match(">>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__88"

    // $ANTLR start "T__89"
    public void mT__89() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__89;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:73:7: ( 'case' )
            // C.g:73:9: 'case'
            {
            	Match("case"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__89"

    // $ANTLR start "T__90"
    public void mT__90() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__90;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:74:7: ( 'default' )
            // C.g:74:9: 'default'
            {
            	Match("default"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__90"

    // $ANTLR start "T__91"
    public void mT__91() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__91;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:75:7: ( 'if' )
            // C.g:75:9: 'if'
            {
            	Match("if"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__91"

    // $ANTLR start "T__92"
    public void mT__92() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__92;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:76:7: ( 'else' )
            // C.g:76:9: 'else'
            {
            	Match("else"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__92"

    // $ANTLR start "T__93"
    public void mT__93() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__93;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:77:7: ( 'switch' )
            // C.g:77:9: 'switch'
            {
            	Match("switch"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__93"

    // $ANTLR start "T__94"
    public void mT__94() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__94;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:78:7: ( 'while' )
            // C.g:78:9: 'while'
            {
            	Match("while"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__94"

    // $ANTLR start "T__95"
    public void mT__95() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__95;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:79:7: ( 'do' )
            // C.g:79:9: 'do'
            {
            	Match("do"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__95"

    // $ANTLR start "T__96"
    public void mT__96() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__96;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:80:7: ( 'for' )
            // C.g:80:9: 'for'
            {
            	Match("for"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__96"

    // $ANTLR start "T__97"
    public void mT__97() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__97;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:81:7: ( 'goto' )
            // C.g:81:9: 'goto'
            {
            	Match("goto"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__97"

    // $ANTLR start "T__98"
    public void mT__98() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__98;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:82:7: ( 'continue' )
            // C.g:82:9: 'continue'
            {
            	Match("continue"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__98"

    // $ANTLR start "T__99"
    public void mT__99() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__99;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:83:7: ( 'break' )
            // C.g:83:9: 'break'
            {
            	Match("break"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__99"

    // $ANTLR start "T__100"
    public void mT__100() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__100;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:84:8: ( 'return' )
            // C.g:84:10: 'return'
            {
            	Match("return"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__100"

    // $ANTLR start "IDENTIFIER"
    public void mIDENTIFIER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IDENTIFIER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:470:2: ( LETTER ( LETTER | '0' .. '9' )* )
            // C.g:470:4: LETTER ( LETTER | '0' .. '9' )*
            {
            	mLETTER(); 
            	// C.g:470:11: ( LETTER | '0' .. '9' )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == '$' || (LA1_0 >= '0' && LA1_0 <= '9') || (LA1_0 >= 'A' && LA1_0 <= 'Z') || LA1_0 == '_' || (LA1_0 >= 'a' && LA1_0 <= 'z')) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // C.g:
            			    {
            			    	if ( input.LA(1) == '$' || (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
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

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IDENTIFIER"

    // $ANTLR start "LETTER"
    public void mLETTER() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:475:2: ( '$' | 'A' .. 'Z' | 'a' .. 'z' | '_' )
            // C.g:
            {
            	if ( input.LA(1) == '$' || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
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
    // $ANTLR end "LETTER"

    // $ANTLR start "CHARACTER_LITERAL"
    public void mCHARACTER_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CHARACTER_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:482:5: ( '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) ) '\\'' )
            // C.g:482:9: '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) ) '\\''
            {
            	Match('\''); 
            	// C.g:482:14: ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);

            	if ( (LA2_0 == '\\') )
            	{
            	    alt2 = 1;
            	}
            	else if ( ((LA2_0 >= '\u0000' && LA2_0 <= '&') || (LA2_0 >= '(' && LA2_0 <= '[') || (LA2_0 >= ']' && LA2_0 <= '\uFFFF')) )
            	{
            	    alt2 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d2s0 =
            	        new NoViableAltException("", 2, 0, input);

            	    throw nvae_d2s0;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // C.g:482:16: EscapeSequence
            	        {
            	        	mEscapeSequence(); 

            	        }
            	        break;
            	    case 2 :
            	        // C.g:482:33: ~ ( '\\'' | '\\\\' )
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

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CHARACTER_LITERAL"

    // $ANTLR start "STRING_LITERAL"
    public void mSTRING_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STRING_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:486:5: ( '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"' )
            // C.g:486:8: '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"'
            {
            	Match('\"'); 
            	// C.g:486:12: ( EscapeSequence | ~ ( '\\\\' | '\"' ) )*
            	do 
            	{
            	    int alt3 = 3;
            	    int LA3_0 = input.LA(1);

            	    if ( (LA3_0 == '\\') )
            	    {
            	        alt3 = 1;
            	    }
            	    else if ( ((LA3_0 >= '\u0000' && LA3_0 <= '!') || (LA3_0 >= '#' && LA3_0 <= '[') || (LA3_0 >= ']' && LA3_0 <= '\uFFFF')) )
            	    {
            	        alt3 = 2;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // C.g:486:14: EscapeSequence
            			    {
            			    	mEscapeSequence(); 

            			    }
            			    break;
            			case 2 :
            			    // C.g:486:31: ~ ( '\\\\' | '\"' )
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
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements

            	Match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "STRING_LITERAL"

    // $ANTLR start "HEX_LITERAL"
    public void mHEX_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = HEX_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:489:13: ( '0' ( 'x' | 'X' ) ( HexDigit )+ ( IntegerTypeSuffix )? )
            // C.g:489:15: '0' ( 'x' | 'X' ) ( HexDigit )+ ( IntegerTypeSuffix )?
            {
            	Match('0'); 
            	if ( input.LA(1) == 'X' || input.LA(1) == 'x' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// C.g:489:29: ( HexDigit )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '0' && LA4_0 <= '9') || (LA4_0 >= 'A' && LA4_0 <= 'F') || (LA4_0 >= 'a' && LA4_0 <= 'f')) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // C.g:489:29: HexDigit
            			    {
            			    	mHexDigit(); 

            			    }
            			    break;

            			default:
            			    if ( cnt4 >= 1 ) goto loop4;
            		            EarlyExitException eee4 =
            		                new EarlyExitException(4, input);
            		            throw eee4;
            	    }
            	    cnt4++;
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements

            	// C.g:489:39: ( IntegerTypeSuffix )?
            	int alt5 = 2;
            	int LA5_0 = input.LA(1);

            	if ( (LA5_0 == 'L' || LA5_0 == 'U' || LA5_0 == 'l' || LA5_0 == 'u') )
            	{
            	    alt5 = 1;
            	}
            	switch (alt5) 
            	{
            	    case 1 :
            	        // C.g:489:39: IntegerTypeSuffix
            	        {
            	        	mIntegerTypeSuffix(); 

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
    // $ANTLR end "HEX_LITERAL"

    // $ANTLR start "DECIMAL_LITERAL"
    public void mDECIMAL_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DECIMAL_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:491:17: ( ( '0' | '1' .. '9' ( '0' .. '9' )* ) ( IntegerTypeSuffix )? )
            // C.g:491:19: ( '0' | '1' .. '9' ( '0' .. '9' )* ) ( IntegerTypeSuffix )?
            {
            	// C.g:491:19: ( '0' | '1' .. '9' ( '0' .. '9' )* )
            	int alt7 = 2;
            	int LA7_0 = input.LA(1);

            	if ( (LA7_0 == '0') )
            	{
            	    alt7 = 1;
            	}
            	else if ( ((LA7_0 >= '1' && LA7_0 <= '9')) )
            	{
            	    alt7 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d7s0 =
            	        new NoViableAltException("", 7, 0, input);

            	    throw nvae_d7s0;
            	}
            	switch (alt7) 
            	{
            	    case 1 :
            	        // C.g:491:20: '0'
            	        {
            	        	Match('0'); 

            	        }
            	        break;
            	    case 2 :
            	        // C.g:491:26: '1' .. '9' ( '0' .. '9' )*
            	        {
            	        	MatchRange('1','9'); 
            	        	// C.g:491:35: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt6 = 2;
            	        	    int LA6_0 = input.LA(1);

            	        	    if ( ((LA6_0 >= '0' && LA6_0 <= '9')) )
            	        	    {
            	        	        alt6 = 1;
            	        	    }


            	        	    switch (alt6) 
            	        		{
            	        			case 1 :
            	        			    // C.g:491:35: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 

            	        			    }
            	        			    break;

            	        			default:
            	        			    goto loop6;
            	        	    }
            	        	} while (true);

            	        	loop6:
            	        		;	// Stops C# compiler whining that label 'loop6' has no statements


            	        }
            	        break;

            	}

            	// C.g:491:46: ( IntegerTypeSuffix )?
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);

            	if ( (LA8_0 == 'L' || LA8_0 == 'U' || LA8_0 == 'l' || LA8_0 == 'u') )
            	{
            	    alt8 = 1;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // C.g:491:46: IntegerTypeSuffix
            	        {
            	        	mIntegerTypeSuffix(); 

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
    // $ANTLR end "DECIMAL_LITERAL"

    // $ANTLR start "OCTAL_LITERAL"
    public void mOCTAL_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OCTAL_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:493:15: ( '0' ( '0' .. '7' )+ ( IntegerTypeSuffix )? )
            // C.g:493:17: '0' ( '0' .. '7' )+ ( IntegerTypeSuffix )?
            {
            	Match('0'); 
            	// C.g:493:21: ( '0' .. '7' )+
            	int cnt9 = 0;
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( ((LA9_0 >= '0' && LA9_0 <= '7')) )
            	    {
            	        alt9 = 1;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // C.g:493:22: '0' .. '7'
            			    {
            			    	MatchRange('0','7'); 

            			    }
            			    break;

            			default:
            			    if ( cnt9 >= 1 ) goto loop9;
            		            EarlyExitException eee9 =
            		                new EarlyExitException(9, input);
            		            throw eee9;
            	    }
            	    cnt9++;
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	// C.g:493:33: ( IntegerTypeSuffix )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( (LA10_0 == 'L' || LA10_0 == 'U' || LA10_0 == 'l' || LA10_0 == 'u') )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // C.g:493:33: IntegerTypeSuffix
            	        {
            	        	mIntegerTypeSuffix(); 

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
    // $ANTLR end "OCTAL_LITERAL"

    // $ANTLR start "HexDigit"
    public void mHexDigit() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:496:10: ( ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' ) )
            // C.g:496:12: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )
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
    // $ANTLR end "HexDigit"

    // $ANTLR start "IntegerTypeSuffix"
    public void mIntegerTypeSuffix() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:500:2: ( ( 'u' | 'U' )? ( 'l' | 'L' ) | ( 'u' | 'U' ) ( 'l' | 'L' )? )
            int alt13 = 2;
            int LA13_0 = input.LA(1);

            if ( (LA13_0 == 'U' || LA13_0 == 'u') )
            {
                int LA13_1 = input.LA(2);

                if ( (LA13_1 == 'L' || LA13_1 == 'l') )
                {
                    alt13 = 1;
                }
                else 
                {
                    alt13 = 2;}
            }
            else if ( (LA13_0 == 'L' || LA13_0 == 'l') )
            {
                alt13 = 1;
            }
            else 
            {
                NoViableAltException nvae_d13s0 =
                    new NoViableAltException("", 13, 0, input);

                throw nvae_d13s0;
            }
            switch (alt13) 
            {
                case 1 :
                    // C.g:500:4: ( 'u' | 'U' )? ( 'l' | 'L' )
                    {
                    	// C.g:500:4: ( 'u' | 'U' )?
                    	int alt11 = 2;
                    	int LA11_0 = input.LA(1);

                    	if ( (LA11_0 == 'U' || LA11_0 == 'u') )
                    	{
                    	    alt11 = 1;
                    	}
                    	switch (alt11) 
                    	{
                    	    case 1 :
                    	        // C.g:
                    	        {
                    	        	if ( input.LA(1) == 'U' || input.LA(1) == 'u' ) 
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

                    	if ( input.LA(1) == 'L' || input.LA(1) == 'l' ) 
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
                case 2 :
                    // C.g:501:4: ( 'u' | 'U' ) ( 'l' | 'L' )?
                    {
                    	if ( input.LA(1) == 'U' || input.LA(1) == 'u' ) 
                    	{
                    	    input.Consume();

                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    	    Recover(mse);
                    	    throw mse;}

                    	// C.g:501:15: ( 'l' | 'L' )?
                    	int alt12 = 2;
                    	int LA12_0 = input.LA(1);

                    	if ( (LA12_0 == 'L' || LA12_0 == 'l') )
                    	{
                    	    alt12 = 1;
                    	}
                    	switch (alt12) 
                    	{
                    	    case 1 :
                    	        // C.g:
                    	        {
                    	        	if ( input.LA(1) == 'L' || input.LA(1) == 'l' ) 
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
                    break;

            }
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IntegerTypeSuffix"

    // $ANTLR start "FLOATING_POINT_LITERAL"
    public void mFLOATING_POINT_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOATING_POINT_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:505:5: ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )? | '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )? | ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )? | ( '0' .. '9' )+ ( Exponent )? FloatTypeSuffix )
            int alt25 = 4;
            alt25 = dfa25.Predict(input);
            switch (alt25) 
            {
                case 1 :
                    // C.g:505:9: ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )?
                    {
                    	// C.g:505:9: ( '0' .. '9' )+
                    	int cnt14 = 0;
                    	do 
                    	{
                    	    int alt14 = 2;
                    	    int LA14_0 = input.LA(1);

                    	    if ( ((LA14_0 >= '0' && LA14_0 <= '9')) )
                    	    {
                    	        alt14 = 1;
                    	    }


                    	    switch (alt14) 
                    		{
                    			case 1 :
                    			    // C.g:505:10: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt14 >= 1 ) goto loop14;
                    		            EarlyExitException eee14 =
                    		                new EarlyExitException(14, input);
                    		            throw eee14;
                    	    }
                    	    cnt14++;
                    	} while (true);

                    	loop14:
                    		;	// Stops C# compiler whining that label 'loop14' has no statements

                    	Match('.'); 
                    	// C.g:505:25: ( '0' .. '9' )*
                    	do 
                    	{
                    	    int alt15 = 2;
                    	    int LA15_0 = input.LA(1);

                    	    if ( ((LA15_0 >= '0' && LA15_0 <= '9')) )
                    	    {
                    	        alt15 = 1;
                    	    }


                    	    switch (alt15) 
                    		{
                    			case 1 :
                    			    // C.g:505:26: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

                    			    }
                    			    break;

                    			default:
                    			    goto loop15;
                    	    }
                    	} while (true);

                    	loop15:
                    		;	// Stops C# compiler whining that label 'loop15' has no statements

                    	// C.g:505:37: ( Exponent )?
                    	int alt16 = 2;
                    	int LA16_0 = input.LA(1);

                    	if ( (LA16_0 == 'E' || LA16_0 == 'e') )
                    	{
                    	    alt16 = 1;
                    	}
                    	switch (alt16) 
                    	{
                    	    case 1 :
                    	        // C.g:505:37: Exponent
                    	        {
                    	        	mExponent(); 

                    	        }
                    	        break;

                    	}

                    	// C.g:505:47: ( FloatTypeSuffix )?
                    	int alt17 = 2;
                    	int LA17_0 = input.LA(1);

                    	if ( (LA17_0 == 'D' || LA17_0 == 'F' || LA17_0 == 'd' || LA17_0 == 'f') )
                    	{
                    	    alt17 = 1;
                    	}
                    	switch (alt17) 
                    	{
                    	    case 1 :
                    	        // C.g:505:47: FloatTypeSuffix
                    	        {
                    	        	mFloatTypeSuffix(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // C.g:506:9: '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )?
                    {
                    	Match('.'); 
                    	// C.g:506:13: ( '0' .. '9' )+
                    	int cnt18 = 0;
                    	do 
                    	{
                    	    int alt18 = 2;
                    	    int LA18_0 = input.LA(1);

                    	    if ( ((LA18_0 >= '0' && LA18_0 <= '9')) )
                    	    {
                    	        alt18 = 1;
                    	    }


                    	    switch (alt18) 
                    		{
                    			case 1 :
                    			    // C.g:506:14: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

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

                    	// C.g:506:25: ( Exponent )?
                    	int alt19 = 2;
                    	int LA19_0 = input.LA(1);

                    	if ( (LA19_0 == 'E' || LA19_0 == 'e') )
                    	{
                    	    alt19 = 1;
                    	}
                    	switch (alt19) 
                    	{
                    	    case 1 :
                    	        // C.g:506:25: Exponent
                    	        {
                    	        	mExponent(); 

                    	        }
                    	        break;

                    	}

                    	// C.g:506:35: ( FloatTypeSuffix )?
                    	int alt20 = 2;
                    	int LA20_0 = input.LA(1);

                    	if ( (LA20_0 == 'D' || LA20_0 == 'F' || LA20_0 == 'd' || LA20_0 == 'f') )
                    	{
                    	    alt20 = 1;
                    	}
                    	switch (alt20) 
                    	{
                    	    case 1 :
                    	        // C.g:506:35: FloatTypeSuffix
                    	        {
                    	        	mFloatTypeSuffix(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // C.g:507:9: ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )?
                    {
                    	// C.g:507:9: ( '0' .. '9' )+
                    	int cnt21 = 0;
                    	do 
                    	{
                    	    int alt21 = 2;
                    	    int LA21_0 = input.LA(1);

                    	    if ( ((LA21_0 >= '0' && LA21_0 <= '9')) )
                    	    {
                    	        alt21 = 1;
                    	    }


                    	    switch (alt21) 
                    		{
                    			case 1 :
                    			    // C.g:507:10: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt21 >= 1 ) goto loop21;
                    		            EarlyExitException eee21 =
                    		                new EarlyExitException(21, input);
                    		            throw eee21;
                    	    }
                    	    cnt21++;
                    	} while (true);

                    	loop21:
                    		;	// Stops C# compiler whining that label 'loop21' has no statements

                    	mExponent(); 
                    	// C.g:507:30: ( FloatTypeSuffix )?
                    	int alt22 = 2;
                    	int LA22_0 = input.LA(1);

                    	if ( (LA22_0 == 'D' || LA22_0 == 'F' || LA22_0 == 'd' || LA22_0 == 'f') )
                    	{
                    	    alt22 = 1;
                    	}
                    	switch (alt22) 
                    	{
                    	    case 1 :
                    	        // C.g:507:30: FloatTypeSuffix
                    	        {
                    	        	mFloatTypeSuffix(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 4 :
                    // C.g:508:9: ( '0' .. '9' )+ ( Exponent )? FloatTypeSuffix
                    {
                    	// C.g:508:9: ( '0' .. '9' )+
                    	int cnt23 = 0;
                    	do 
                    	{
                    	    int alt23 = 2;
                    	    int LA23_0 = input.LA(1);

                    	    if ( ((LA23_0 >= '0' && LA23_0 <= '9')) )
                    	    {
                    	        alt23 = 1;
                    	    }


                    	    switch (alt23) 
                    		{
                    			case 1 :
                    			    // C.g:508:10: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

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

                    	// C.g:508:21: ( Exponent )?
                    	int alt24 = 2;
                    	int LA24_0 = input.LA(1);

                    	if ( (LA24_0 == 'E' || LA24_0 == 'e') )
                    	{
                    	    alt24 = 1;
                    	}
                    	switch (alt24) 
                    	{
                    	    case 1 :
                    	        // C.g:508:21: Exponent
                    	        {
                    	        	mExponent(); 

                    	        }
                    	        break;

                    	}

                    	mFloatTypeSuffix(); 

                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FLOATING_POINT_LITERAL"

    // $ANTLR start "Exponent"
    public void mExponent() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:512:10: ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )
            // C.g:512:12: ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+
            {
            	if ( input.LA(1) == 'E' || input.LA(1) == 'e' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// C.g:512:22: ( '+' | '-' )?
            	int alt26 = 2;
            	int LA26_0 = input.LA(1);

            	if ( (LA26_0 == '+' || LA26_0 == '-') )
            	{
            	    alt26 = 1;
            	}
            	switch (alt26) 
            	{
            	    case 1 :
            	        // C.g:
            	        {
            	        	if ( input.LA(1) == '+' || input.LA(1) == '-' ) 
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

            	// C.g:512:33: ( '0' .. '9' )+
            	int cnt27 = 0;
            	do 
            	{
            	    int alt27 = 2;
            	    int LA27_0 = input.LA(1);

            	    if ( ((LA27_0 >= '0' && LA27_0 <= '9')) )
            	    {
            	        alt27 = 1;
            	    }


            	    switch (alt27) 
            		{
            			case 1 :
            			    // C.g:512:34: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

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


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Exponent"

    // $ANTLR start "FloatTypeSuffix"
    public void mFloatTypeSuffix() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:515:17: ( ( 'f' | 'F' | 'd' | 'D' ) )
            // C.g:515:19: ( 'f' | 'F' | 'd' | 'D' )
            {
            	if ( input.LA(1) == 'D' || input.LA(1) == 'F' || input.LA(1) == 'd' || input.LA(1) == 'f' ) 
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
    // $ANTLR end "FloatTypeSuffix"

    // $ANTLR start "EscapeSequence"
    public void mEscapeSequence() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:519:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) | OctalEscape )
            int alt28 = 2;
            int LA28_0 = input.LA(1);

            if ( (LA28_0 == '\\') )
            {
                int LA28_1 = input.LA(2);

                if ( (LA28_1 == '\"' || LA28_1 == '\'' || LA28_1 == '\\' || LA28_1 == 'b' || LA28_1 == 'f' || LA28_1 == 'n' || LA28_1 == 'r' || LA28_1 == 't') )
                {
                    alt28 = 1;
                }
                else if ( ((LA28_1 >= '0' && LA28_1 <= '7')) )
                {
                    alt28 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d28s1 =
                        new NoViableAltException("", 28, 1, input);

                    throw nvae_d28s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d28s0 =
                    new NoViableAltException("", 28, 0, input);

                throw nvae_d28s0;
            }
            switch (alt28) 
            {
                case 1 :
                    // C.g:519:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
                    {
                    	Match('\\'); 
                    	if ( input.LA(1) == '\"' || input.LA(1) == '\'' || input.LA(1) == '\\' || input.LA(1) == 'b' || input.LA(1) == 'f' || input.LA(1) == 'n' || input.LA(1) == 'r' || input.LA(1) == 't' ) 
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
                case 2 :
                    // C.g:520:9: OctalEscape
                    {
                    	mOctalEscape(); 

                    }
                    break;

            }
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EscapeSequence"

    // $ANTLR start "OctalEscape"
    public void mOctalEscape() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:525:5: ( '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) )
            int alt29 = 3;
            int LA29_0 = input.LA(1);

            if ( (LA29_0 == '\\') )
            {
                int LA29_1 = input.LA(2);

                if ( ((LA29_1 >= '0' && LA29_1 <= '3')) )
                {
                    int LA29_2 = input.LA(3);

                    if ( ((LA29_2 >= '0' && LA29_2 <= '7')) )
                    {
                        int LA29_5 = input.LA(4);

                        if ( ((LA29_5 >= '0' && LA29_5 <= '7')) )
                        {
                            alt29 = 1;
                        }
                        else 
                        {
                            alt29 = 2;}
                    }
                    else 
                    {
                        alt29 = 3;}
                }
                else if ( ((LA29_1 >= '4' && LA29_1 <= '7')) )
                {
                    int LA29_3 = input.LA(3);

                    if ( ((LA29_3 >= '0' && LA29_3 <= '7')) )
                    {
                        alt29 = 2;
                    }
                    else 
                    {
                        alt29 = 3;}
                }
                else 
                {
                    NoViableAltException nvae_d29s1 =
                        new NoViableAltException("", 29, 1, input);

                    throw nvae_d29s1;
                }
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
                    // C.g:525:9: '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' )
                    {
                    	Match('\\'); 
                    	// C.g:525:14: ( '0' .. '3' )
                    	// C.g:525:15: '0' .. '3'
                    	{
                    		MatchRange('0','3'); 

                    	}

                    	// C.g:525:25: ( '0' .. '7' )
                    	// C.g:525:26: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}

                    	// C.g:525:36: ( '0' .. '7' )
                    	// C.g:525:37: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}


                    }
                    break;
                case 2 :
                    // C.g:526:9: '\\\\' ( '0' .. '7' ) ( '0' .. '7' )
                    {
                    	Match('\\'); 
                    	// C.g:526:14: ( '0' .. '7' )
                    	// C.g:526:15: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}

                    	// C.g:526:25: ( '0' .. '7' )
                    	// C.g:526:26: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}


                    }
                    break;
                case 3 :
                    // C.g:527:9: '\\\\' ( '0' .. '7' )
                    {
                    	Match('\\'); 
                    	// C.g:527:14: ( '0' .. '7' )
                    	// C.g:527:15: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}


                    }
                    break;

            }
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OctalEscape"

    // $ANTLR start "UnicodeEscape"
    public void mUnicodeEscape() // throws RecognitionException [2]
    {
    		try
    		{
            // C.g:532:5: ( '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit )
            // C.g:532:9: '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit
            {
            	Match('\\'); 
            	Match('u'); 
            	mHexDigit(); 
            	mHexDigit(); 
            	mHexDigit(); 
            	mHexDigit(); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "UnicodeEscape"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:535:5: ( ( ' ' | '\\r' | '\\t' | '\\u000C' | '\\n' ) )
            // C.g:535:8: ( ' ' | '\\r' | '\\t' | '\\u000C' | '\\n' )
            {
            	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || (input.LA(1) >= '\f' && input.LA(1) <= '\r') || input.LA(1) == ' ' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

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

    // $ANTLR start "COMMENT"
    public void mCOMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:539:5: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // C.g:539:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// C.g:539:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt30 = 2;
            	    int LA30_0 = input.LA(1);

            	    if ( (LA30_0 == '*') )
            	    {
            	        int LA30_1 = input.LA(2);

            	        if ( (LA30_1 == '/') )
            	        {
            	            alt30 = 2;
            	        }
            	        else if ( ((LA30_1 >= '\u0000' && LA30_1 <= '.') || (LA30_1 >= '0' && LA30_1 <= '\uFFFF')) )
            	        {
            	            alt30 = 1;
            	        }


            	    }
            	    else if ( ((LA30_0 >= '\u0000' && LA30_0 <= ')') || (LA30_0 >= '+' && LA30_0 <= '\uFFFF')) )
            	    {
            	        alt30 = 1;
            	    }


            	    switch (alt30) 
            		{
            			case 1 :
            			    // C.g:539:42: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop30;
            	    }
            	} while (true);

            	loop30:
            		;	// Stops C# compiler whining that label 'loop30' has no statements

            	Match("*/"); 

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMENT"

    // $ANTLR start "LINE_COMMENT"
    public void mLINE_COMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LINE_COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:543:5: ( '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // C.g:543:7: '//' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("//"); 

            	// C.g:543:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt31 = 2;
            	    int LA31_0 = input.LA(1);

            	    if ( ((LA31_0 >= '\u0000' && LA31_0 <= '\t') || (LA31_0 >= '\u000B' && LA31_0 <= '\f') || (LA31_0 >= '\u000E' && LA31_0 <= '\uFFFF')) )
            	    {
            	        alt31 = 1;
            	    }


            	    switch (alt31) 
            		{
            			case 1 :
            			    // C.g:543:12: ~ ( '\\n' | '\\r' )
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
            			    goto loop31;
            	    }
            	} while (true);

            	loop31:
            		;	// Stops C# compiler whining that label 'loop31' has no statements

            	// C.g:543:26: ( '\\r' )?
            	int alt32 = 2;
            	int LA32_0 = input.LA(1);

            	if ( (LA32_0 == '\r') )
            	{
            	    alt32 = 1;
            	}
            	switch (alt32) 
            	{
            	    case 1 :
            	        // C.g:543:26: '\\r'
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
    // $ANTLR end "LINE_COMMENT"

    // $ANTLR start "LINE_COMMAND"
    public void mLINE_COMMAND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LINE_COMMAND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // C.g:548:5: ( '#' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // C.g:548:7: '#' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match('#'); 
            	// C.g:548:11: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt33 = 2;
            	    int LA33_0 = input.LA(1);

            	    if ( ((LA33_0 >= '\u0000' && LA33_0 <= '\t') || (LA33_0 >= '\u000B' && LA33_0 <= '\f') || (LA33_0 >= '\u000E' && LA33_0 <= '\uFFFF')) )
            	    {
            	        alt33 = 1;
            	    }


            	    switch (alt33) 
            		{
            			case 1 :
            			    // C.g:548:11: ~ ( '\\n' | '\\r' )
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
            			    goto loop33;
            	    }
            	} while (true);

            	loop33:
            		;	// Stops C# compiler whining that label 'loop33' has no statements

            	// C.g:548:25: ( '\\r' )?
            	int alt34 = 2;
            	int LA34_0 = input.LA(1);

            	if ( (LA34_0 == '\r') )
            	{
            	    alt34 = 1;
            	}
            	switch (alt34) 
            	{
            	    case 1 :
            	        // C.g:548:25: '\\r'
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
    // $ANTLR end "LINE_COMMAND"

    override public void mTokens() // throws RecognitionException 
    {
        // C.g:1:8: ( T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | T__67 | T__68 | T__69 | T__70 | T__71 | T__72 | T__73 | T__74 | T__75 | T__76 | T__77 | T__78 | T__79 | T__80 | T__81 | T__82 | T__83 | T__84 | T__85 | T__86 | T__87 | T__88 | T__89 | T__90 | T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | IDENTIFIER | CHARACTER_LITERAL | STRING_LITERAL | HEX_LITERAL | DECIMAL_LITERAL | OCTAL_LITERAL | FLOATING_POINT_LITERAL | WS | COMMENT | LINE_COMMENT | LINE_COMMAND )
        int alt35 = 89;
        alt35 = dfa35.Predict(input);
        switch (alt35) 
        {
            case 1 :
                // C.g:1:10: T__23
                {
                	mT__23(); 

                }
                break;
            case 2 :
                // C.g:1:16: T__24
                {
                	mT__24(); 

                }
                break;
            case 3 :
                // C.g:1:22: T__25
                {
                	mT__25(); 

                }
                break;
            case 4 :
                // C.g:1:28: T__26
                {
                	mT__26(); 

                }
                break;
            case 5 :
                // C.g:1:34: T__27
                {
                	mT__27(); 

                }
                break;
            case 6 :
                // C.g:1:40: T__28
                {
                	mT__28(); 

                }
                break;
            case 7 :
                // C.g:1:46: T__29
                {
                	mT__29(); 

                }
                break;
            case 8 :
                // C.g:1:52: T__30
                {
                	mT__30(); 

                }
                break;
            case 9 :
                // C.g:1:58: T__31
                {
                	mT__31(); 

                }
                break;
            case 10 :
                // C.g:1:64: T__32
                {
                	mT__32(); 

                }
                break;
            case 11 :
                // C.g:1:70: T__33
                {
                	mT__33(); 

                }
                break;
            case 12 :
                // C.g:1:76: T__34
                {
                	mT__34(); 

                }
                break;
            case 13 :
                // C.g:1:82: T__35
                {
                	mT__35(); 

                }
                break;
            case 14 :
                // C.g:1:88: T__36
                {
                	mT__36(); 

                }
                break;
            case 15 :
                // C.g:1:94: T__37
                {
                	mT__37(); 

                }
                break;
            case 16 :
                // C.g:1:100: T__38
                {
                	mT__38(); 

                }
                break;
            case 17 :
                // C.g:1:106: T__39
                {
                	mT__39(); 

                }
                break;
            case 18 :
                // C.g:1:112: T__40
                {
                	mT__40(); 

                }
                break;
            case 19 :
                // C.g:1:118: T__41
                {
                	mT__41(); 

                }
                break;
            case 20 :
                // C.g:1:124: T__42
                {
                	mT__42(); 

                }
                break;
            case 21 :
                // C.g:1:130: T__43
                {
                	mT__43(); 

                }
                break;
            case 22 :
                // C.g:1:136: T__44
                {
                	mT__44(); 

                }
                break;
            case 23 :
                // C.g:1:142: T__45
                {
                	mT__45(); 

                }
                break;
            case 24 :
                // C.g:1:148: T__46
                {
                	mT__46(); 

                }
                break;
            case 25 :
                // C.g:1:154: T__47
                {
                	mT__47(); 

                }
                break;
            case 26 :
                // C.g:1:160: T__48
                {
                	mT__48(); 

                }
                break;
            case 27 :
                // C.g:1:166: T__49
                {
                	mT__49(); 

                }
                break;
            case 28 :
                // C.g:1:172: T__50
                {
                	mT__50(); 

                }
                break;
            case 29 :
                // C.g:1:178: T__51
                {
                	mT__51(); 

                }
                break;
            case 30 :
                // C.g:1:184: T__52
                {
                	mT__52(); 

                }
                break;
            case 31 :
                // C.g:1:190: T__53
                {
                	mT__53(); 

                }
                break;
            case 32 :
                // C.g:1:196: T__54
                {
                	mT__54(); 

                }
                break;
            case 33 :
                // C.g:1:202: T__55
                {
                	mT__55(); 

                }
                break;
            case 34 :
                // C.g:1:208: T__56
                {
                	mT__56(); 

                }
                break;
            case 35 :
                // C.g:1:214: T__57
                {
                	mT__57(); 

                }
                break;
            case 36 :
                // C.g:1:220: T__58
                {
                	mT__58(); 

                }
                break;
            case 37 :
                // C.g:1:226: T__59
                {
                	mT__59(); 

                }
                break;
            case 38 :
                // C.g:1:232: T__60
                {
                	mT__60(); 

                }
                break;
            case 39 :
                // C.g:1:238: T__61
                {
                	mT__61(); 

                }
                break;
            case 40 :
                // C.g:1:244: T__62
                {
                	mT__62(); 

                }
                break;
            case 41 :
                // C.g:1:250: T__63
                {
                	mT__63(); 

                }
                break;
            case 42 :
                // C.g:1:256: T__64
                {
                	mT__64(); 

                }
                break;
            case 43 :
                // C.g:1:262: T__65
                {
                	mT__65(); 

                }
                break;
            case 44 :
                // C.g:1:268: T__66
                {
                	mT__66(); 

                }
                break;
            case 45 :
                // C.g:1:274: T__67
                {
                	mT__67(); 

                }
                break;
            case 46 :
                // C.g:1:280: T__68
                {
                	mT__68(); 

                }
                break;
            case 47 :
                // C.g:1:286: T__69
                {
                	mT__69(); 

                }
                break;
            case 48 :
                // C.g:1:292: T__70
                {
                	mT__70(); 

                }
                break;
            case 49 :
                // C.g:1:298: T__71
                {
                	mT__71(); 

                }
                break;
            case 50 :
                // C.g:1:304: T__72
                {
                	mT__72(); 

                }
                break;
            case 51 :
                // C.g:1:310: T__73
                {
                	mT__73(); 

                }
                break;
            case 52 :
                // C.g:1:316: T__74
                {
                	mT__74(); 

                }
                break;
            case 53 :
                // C.g:1:322: T__75
                {
                	mT__75(); 

                }
                break;
            case 54 :
                // C.g:1:328: T__76
                {
                	mT__76(); 

                }
                break;
            case 55 :
                // C.g:1:334: T__77
                {
                	mT__77(); 

                }
                break;
            case 56 :
                // C.g:1:340: T__78
                {
                	mT__78(); 

                }
                break;
            case 57 :
                // C.g:1:346: T__79
                {
                	mT__79(); 

                }
                break;
            case 58 :
                // C.g:1:352: T__80
                {
                	mT__80(); 

                }
                break;
            case 59 :
                // C.g:1:358: T__81
                {
                	mT__81(); 

                }
                break;
            case 60 :
                // C.g:1:364: T__82
                {
                	mT__82(); 

                }
                break;
            case 61 :
                // C.g:1:370: T__83
                {
                	mT__83(); 

                }
                break;
            case 62 :
                // C.g:1:376: T__84
                {
                	mT__84(); 

                }
                break;
            case 63 :
                // C.g:1:382: T__85
                {
                	mT__85(); 

                }
                break;
            case 64 :
                // C.g:1:388: T__86
                {
                	mT__86(); 

                }
                break;
            case 65 :
                // C.g:1:394: T__87
                {
                	mT__87(); 

                }
                break;
            case 66 :
                // C.g:1:400: T__88
                {
                	mT__88(); 

                }
                break;
            case 67 :
                // C.g:1:406: T__89
                {
                	mT__89(); 

                }
                break;
            case 68 :
                // C.g:1:412: T__90
                {
                	mT__90(); 

                }
                break;
            case 69 :
                // C.g:1:418: T__91
                {
                	mT__91(); 

                }
                break;
            case 70 :
                // C.g:1:424: T__92
                {
                	mT__92(); 

                }
                break;
            case 71 :
                // C.g:1:430: T__93
                {
                	mT__93(); 

                }
                break;
            case 72 :
                // C.g:1:436: T__94
                {
                	mT__94(); 

                }
                break;
            case 73 :
                // C.g:1:442: T__95
                {
                	mT__95(); 

                }
                break;
            case 74 :
                // C.g:1:448: T__96
                {
                	mT__96(); 

                }
                break;
            case 75 :
                // C.g:1:454: T__97
                {
                	mT__97(); 

                }
                break;
            case 76 :
                // C.g:1:460: T__98
                {
                	mT__98(); 

                }
                break;
            case 77 :
                // C.g:1:466: T__99
                {
                	mT__99(); 

                }
                break;
            case 78 :
                // C.g:1:472: T__100
                {
                	mT__100(); 

                }
                break;
            case 79 :
                // C.g:1:479: IDENTIFIER
                {
                	mIDENTIFIER(); 

                }
                break;
            case 80 :
                // C.g:1:490: CHARACTER_LITERAL
                {
                	mCHARACTER_LITERAL(); 

                }
                break;
            case 81 :
                // C.g:1:508: STRING_LITERAL
                {
                	mSTRING_LITERAL(); 

                }
                break;
            case 82 :
                // C.g:1:523: HEX_LITERAL
                {
                	mHEX_LITERAL(); 

                }
                break;
            case 83 :
                // C.g:1:535: DECIMAL_LITERAL
                {
                	mDECIMAL_LITERAL(); 

                }
                break;
            case 84 :
                // C.g:1:551: OCTAL_LITERAL
                {
                	mOCTAL_LITERAL(); 

                }
                break;
            case 85 :
                // C.g:1:565: FLOATING_POINT_LITERAL
                {
                	mFLOATING_POINT_LITERAL(); 

                }
                break;
            case 86 :
                // C.g:1:588: WS
                {
                	mWS(); 

                }
                break;
            case 87 :
                // C.g:1:591: COMMENT
                {
                	mCOMMENT(); 

                }
                break;
            case 88 :
                // C.g:1:599: LINE_COMMENT
                {
                	mLINE_COMMENT(); 

                }
                break;
            case 89 :
                // C.g:1:612: LINE_COMMAND
                {
                	mLINE_COMMAND(); 

                }
                break;

        }

    }


    protected DFA25 dfa25;
    protected DFA35 dfa35;
	private void InitializeCyclicDFAs()
	{
	    this.dfa25 = new DFA25(this);
	    this.dfa35 = new DFA35(this);
	}

    const string DFA25_eotS =
        "\x07\uffff\x01\x08\x02\uffff";
    const string DFA25_eofS =
        "\x0a\uffff";
    const string DFA25_minS =
        "\x02\x2e\x02\uffff\x01\x2b\x01\uffff\x02\x30\x02\uffff";
    const string DFA25_maxS =
        "\x01\x39\x01\x66\x02\uffff\x01\x39\x01\uffff\x01\x39\x01\x66\x02"+
        "\uffff";
    const string DFA25_acceptS =
        "\x02\uffff\x01\x02\x01\x01\x01\uffff\x01\x04\x02\uffff\x02\x03";
    const string DFA25_specialS =
        "\x0a\uffff}>";
    static readonly string[] DFA25_transitionS = {
            "\x01\x02\x01\uffff\x0a\x01",
            "\x01\x03\x01\uffff\x0a\x01\x0a\uffff\x01\x05\x01\x04\x01\x05"+
            "\x1d\uffff\x01\x05\x01\x04\x01\x05",
            "",
            "",
            "\x01\x06\x01\uffff\x01\x06\x02\uffff\x0a\x07",
            "",
            "\x0a\x07",
            "\x0a\x07\x0a\uffff\x01\x09\x01\uffff\x01\x09\x1d\uffff\x01"+
            "\x09\x01\uffff\x01\x09",
            "",
            ""
    };

    static readonly short[] DFA25_eot = DFA.UnpackEncodedString(DFA25_eotS);
    static readonly short[] DFA25_eof = DFA.UnpackEncodedString(DFA25_eofS);
    static readonly char[] DFA25_min = DFA.UnpackEncodedStringToUnsignedChars(DFA25_minS);
    static readonly char[] DFA25_max = DFA.UnpackEncodedStringToUnsignedChars(DFA25_maxS);
    static readonly short[] DFA25_accept = DFA.UnpackEncodedString(DFA25_acceptS);
    static readonly short[] DFA25_special = DFA.UnpackEncodedString(DFA25_specialS);
    static readonly short[][] DFA25_transition = DFA.UnpackEncodedStringArray(DFA25_transitionS);

    protected class DFA25 : DFA
    {
        public DFA25(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 25;
            this.eot = DFA25_eot;
            this.eof = DFA25_eof;
            this.min = DFA25_min;
            this.max = DFA25_max;
            this.accept = DFA25_accept;
            this.special = DFA25_special;
            this.transition = DFA25_transition;

        }

        override public string Description
        {
            get { return "504:1: FLOATING_POINT_LITERAL : ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( Exponent )? ( FloatTypeSuffix )? | '.' ( '0' .. '9' )+ ( Exponent )? ( FloatTypeSuffix )? | ( '0' .. '9' )+ Exponent ( FloatTypeSuffix )? | ( '0' .. '9' )+ ( Exponent )? FloatTypeSuffix );"; }
        }

    }

    const string DFA35_eotS =
        "\x01\uffff\x01\x28\x02\uffff\x01\x31\x0b\x28\x07\uffff\x01\x48"+
        "\x01\x4a\x01\x4e\x01\x52\x01\x56\x01\x58\x01\x5b\x01\uffff\x01\x5d"+
        "\x01\x60\x01\x63\x01\x65\x01\x68\x01\uffff\x03\x28\x03\uffff\x02"+
        "\x6e\x02\uffff\x01\x28\x02\uffff\x0e\x28\x01\u0083\x03\x28\x01\u0088"+
        "\x02\x28\x17\uffff\x01\u008d\x02\uffff\x01\u008f\x07\uffff\x03\x28"+
        "\x01\uffff\x01\u0093\x01\uffff\x01\x6e\x12\x28\x01\u00a7\x01\uffff"+
        "\x02\x28\x01\u00aa\x01\x28\x01\uffff\x03\x28\x04\uffff\x03\x28\x01"+
        "\uffff\x02\x28\x01\u00b4\x01\u00b5\x06\x28\x01\u00bc\x02\x28\x01"+
        "\u00bf\x01\x28\x01\u00c1\x02\x28\x01\u00c4\x01\uffff\x01\u00c5\x01"+
        "\x28\x01\uffff\x05\x28\x01\u00cc\x03\x28\x02\uffff\x02\x28\x01\u00d2"+
        "\x03\x28\x01\uffff\x02\x28\x01\uffff\x01\x28\x01\uffff\x01\u00d9"+
        "\x01\x28\x02\uffff\x01\u00db\x03\x28\x01\u00df\x01\u00e0\x01\uffff"+
        "\x01\u00e1\x01\x28\x01\u00e3\x01\u00e4\x01\u00e5\x01\uffff\x01\u00e6"+
        "\x01\u00e7\x01\u00e8\x01\x28\x01\u00ea\x01\x28\x01\uffff\x01\x28"+
        "\x01\uffff\x01\u00ed\x02\x28\x03\uffff\x01\u00f0\x06\uffff\x01\x28"+
        "\x01\uffff\x02\x28\x01\uffff\x01\u00f4\x01\x28\x01\uffff\x01\u00f6"+
        "\x01\u00f7\x01\u00f8\x01\uffff\x01\u00f9\x04\uffff";
    const string DFA35_eofS =
        "\u00fa\uffff";
    const string DFA35_minS =
        "\x01\x09\x01\x79\x02\uffff\x01\x3d\x01\x6c\x01\x68\x01\x75\x01"+
        "\x65\x01\x6f\x01\x61\x01\x66\x01\x6f\x01\x6c\x01\x65\x01\x6e\x07"+
        "\uffff\x01\x3d\x01\x2e\x01\x2b\x01\x2d\x01\x2a\x01\x3d\x01\x26\x01"+
        "\uffff\x01\x3d\x01\x3c\x03\x3d\x01\uffff\x01\x68\x01\x6f\x01\x72"+
        "\x03\uffff\x02\x2e\x02\uffff\x01\x70\x02\uffff\x01\x74\x01\x75\x01"+
        "\x73\x01\x61\x01\x6f\x01\x67\x01\x69\x01\x74\x01\x67\x01\x69\x01"+
        "\x61\x01\x6e\x01\x73\x01\x74\x01\x24\x01\x6e\x01\x6f\x01\x72\x01"+
        "\x24\x01\x66\x01\x69\x17\uffff\x01\x3d\x02\uffff\x01\x3d\x07\uffff"+
        "\x01\x69\x01\x74\x01\x65\x01\uffff\x01\x2e\x01\uffff\x01\x2e\x02"+
        "\x65\x01\x6d\x01\x65\x01\x74\x01\x75\x01\x72\x01\x6e\x01\x65\x01"+
        "\x74\x01\x6f\x01\x69\x01\x75\x01\x64\x01\x61\x01\x72\x01\x73\x01"+
        "\x65\x01\x24\x01\uffff\x01\x67\x01\x61\x01\x24\x01\x62\x01\uffff"+
        "\x01\x61\x01\x69\x01\x6f\x04\uffff\x01\x6c\x01\x6f\x01\x61\x01\uffff"+
        "\x01\x64\x01\x72\x02\x24\x01\x69\x01\x63\x01\x74\x01\x65\x01\x6f"+
        "\x01\x63\x01\x24\x01\x73\x01\x72\x01\x24\x01\x74\x01\x24\x01\x74"+
        "\x01\x69\x01\x24\x01\uffff\x01\x24\x01\x74\x01\uffff\x01\x6c\x01"+
        "\x75\x01\x67\x01\x6e\x01\x65\x01\x24\x01\x6b\x01\x65\x01\x6e\x02"+
        "\uffff\x01\x63\x01\x74\x01\x24\x01\x64\x01\x66\x01\x68\x01\uffff"+
        "\x01\x74\x01\x6e\x01\uffff\x01\x69\x01\uffff\x01\x24\x01\x6e\x02"+
        "\uffff\x01\x24\x01\x65\x01\x6c\x01\x6e\x02\x24\x01\uffff\x01\x24"+
        "\x01\x66\x03\x24\x01\uffff\x03\x24\x01\x65\x01\x24\x01\x6c\x01\uffff"+
        "\x01\x75\x01\uffff\x01\x24\x01\x74\x01\x65\x03\uffff\x01\x24\x06"+
        "\uffff\x01\x72\x01\uffff\x02\x65\x01\uffff\x01\x24\x01\x64\x01\uffff"+
        "\x03\x24\x01\uffff\x01\x24\x04\uffff";
    const string DFA35_maxS =
        "\x01\x7e\x01\x79\x02\uffff\x01\x3d\x01\x78\x01\x77\x01\x75\x01"+
        "\x65\x02\x6f\x01\x6e\x03\x6f\x01\x6e\x07\uffff\x01\x3d\x01\x39\x01"+
        "\x3d\x01\x3e\x03\x3d\x01\uffff\x02\x3d\x01\x3e\x01\x3d\x01\x7c\x01"+
        "\uffff\x01\x68\x01\x6f\x01\x72\x03\uffff\x01\x78\x01\x66\x02\uffff"+
        "\x01\x70\x02\uffff\x01\x74\x01\x75\x01\x73\x01\x72\x01\x6f\x01\x7a"+
        "\x01\x69\x02\x74\x01\x6c\x01\x61\x01\x6e\x01\x73\x01\x74\x01\x7a"+
        "\x01\x6e\x01\x6f\x01\x72\x01\x7a\x01\x66\x01\x73\x17\uffff\x01\x3d"+
        "\x02\uffff\x01\x3d\x07\uffff\x01\x69\x01\x74\x01\x65\x01\uffff\x01"+
        "\x66\x01\uffff\x01\x66\x02\x65\x01\x6d\x01\x65\x01\x74\x01\x75\x01"+
        "\x72\x01\x6e\x01\x65\x01\x74\x01\x6f\x01\x69\x01\x75\x01\x64\x01"+
        "\x61\x01\x72\x01\x74\x01\x65\x01\x7a\x01\uffff\x01\x67\x01\x61\x01"+
        "\x7a\x01\x62\x01\uffff\x01\x61\x01\x69\x01\x6f\x04\uffff\x01\x6c"+
        "\x01\x6f\x01\x61\x01\uffff\x01\x64\x01\x72\x02\x7a\x01\x69\x01\x63"+
        "\x01\x74\x01\x65\x01\x6f\x01\x63\x01\x7a\x01\x73\x01\x72\x01\x7a"+
        "\x01\x74\x01\x7a\x01\x74\x01\x69\x01\x7a\x01\uffff\x01\x7a\x01\x74"+
        "\x01\uffff\x01\x6c\x01\x75\x01\x67\x01\x6e\x01\x65\x01\x7a\x01\x6b"+
        "\x01\x65\x01\x6e\x02\uffff\x01\x63\x01\x74\x01\x7a\x01\x64\x01\x66"+
        "\x01\x68\x01\uffff\x01\x74\x01\x6e\x01\uffff\x01\x69\x01\uffff\x01"+
        "\x7a\x01\x6e\x02\uffff\x01\x7a\x01\x65\x01\x6c\x01\x6e\x02\x7a\x01"+
        "\uffff\x01\x7a\x01\x66\x03\x7a\x01\uffff\x03\x7a\x01\x65\x01\x7a"+
        "\x01\x6c\x01\uffff\x01\x75\x01\uffff\x01\x7a\x01\x74\x01\x65\x03"+
        "\uffff\x01\x7a\x06\uffff\x01\x72\x01\uffff\x02\x65\x01\uffff\x01"+
        "\x7a\x01\x64\x01\uffff\x03\x7a\x01\uffff\x01\x7a\x04\uffff";
    const string DFA35_acceptS =
        "\x02\uffff\x01\x02\x01\x03\x0c\uffff\x01\x12\x01\x13\x01\x16\x01"+
        "\x1a\x01\x1b\x01\x1c\x01\x1d\x07\uffff\x01\x2a\x05\uffff\x01\x36"+
        "\x03\uffff\x01\x4f\x01\x50\x01\x51\x02\uffff\x01\x56\x01\x59\x01"+
        "\uffff\x01\x3b\x01\x04\x15\uffff\x01\x2c\x01\x1e\x01\x1f\x01\x27"+
        "\x01\x55\x01\x24\x01\x2f\x01\x20\x01\x25\x01\x28\x01\x30\x01\x21"+
        "\x01\x2d\x01\x57\x01\x58\x01\x22\x01\x2e\x01\x23\x01\x33\x01\x38"+
        "\x01\x29\x01\x3c\x01\x2b\x01\uffff\x01\x3f\x01\x3d\x01\uffff\x01"+
        "\x40\x01\x3e\x01\x34\x01\x3a\x01\x35\x01\x37\x01\x39\x03\uffff\x01"+
        "\x52\x01\uffff\x01\x53\x14\uffff\x01\x45\x04\uffff\x01\x49\x03\uffff"+
        "\x01\x31\x01\x41\x01\x32\x01\x42\x03\uffff\x01\x54\x13\uffff\x01"+
        "\x0c\x02\uffff\x01\x4a\x09\uffff\x01\x17\x01\x46\x06\uffff\x01\x07"+
        "\x02\uffff\x01\x09\x01\uffff\x01\x0a\x02\uffff\x01\x43\x01\x0d\x06"+
        "\uffff\x01\x4b\x05\uffff\x01\x0b\x06\uffff\x01\x18\x01\uffff\x01"+
        "\x0e\x03\uffff\x01\x15\x01\x48\x01\x4d\x01\uffff\x01\x05\x01\x06"+
        "\x01\x14\x01\x10\x01\x26\x01\x47\x01\uffff\x01\x4e\x02\uffff\x01"+
        "\x0f\x02\uffff\x01\x01\x03\uffff\x01\x44\x01\uffff\x01\x08\x01\x19"+
        "\x01\x4c\x01\x11";
    const string DFA35_specialS =
        "\u00fa\uffff}>";
    static readonly string[] DFA35_transitionS = {
            "\x02\x2d\x01\uffff\x02\x2d\x12\uffff\x01\x2d\x01\x1f\x01\x2a"+
            "\x01\x2e\x01\x28\x01\x1c\x01\x1d\x01\x29\x01\x13\x01\x14\x01"+
            "\x17\x01\x19\x01\x03\x01\x1a\x01\x18\x01\x1b\x01\x2b\x09\x2c"+
            "\x01\x12\x01\x02\x01\x20\x01\x04\x01\x21\x01\x24\x01\uffff\x1a"+
            "\x28\x01\x15\x01\uffff\x01\x16\x01\x22\x01\x28\x01\uffff\x01"+
            "\x07\x01\x27\x01\x0a\x01\x0e\x01\x05\x01\x0d\x01\x26\x01\x28"+
            "\x01\x0b\x02\x28\x01\x0c\x05\x28\x01\x08\x01\x06\x01\x01\x01"+
            "\x0f\x01\x09\x01\x25\x03\x28\x01\x10\x01\x23\x01\x11\x01\x1e",
            "\x01\x2f",
            "",
            "",
            "\x01\x30",
            "\x01\x34\x01\uffff\x01\x33\x09\uffff\x01\x32",
            "\x01\x36\x01\x37\x0a\uffff\x01\x35\x02\uffff\x01\x38",
            "\x01\x39",
            "\x01\x3a",
            "\x01\x3b",
            "\x01\x3e\x06\uffff\x01\x3c\x06\uffff\x01\x3d",
            "\x01\x40\x07\uffff\x01\x3f",
            "\x01\x41",
            "\x01\x42\x02\uffff\x01\x43",
            "\x01\x45\x09\uffff\x01\x44",
            "\x01\x46",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x47",
            "\x01\x49\x01\uffff\x0a\x4b",
            "\x01\x4c\x11\uffff\x01\x4d",
            "\x01\x4f\x0f\uffff\x01\x51\x01\x50",
            "\x01\x54\x04\uffff\x01\x55\x0d\uffff\x01\x53",
            "\x01\x57",
            "\x01\x5a\x16\uffff\x01\x59",
            "",
            "\x01\x5c",
            "\x01\x5e\x01\x5f",
            "\x01\x62\x01\x61",
            "\x01\x64",
            "\x01\x66\x3e\uffff\x01\x67",
            "",
            "\x01\x69",
            "\x01\x6a",
            "\x01\x6b",
            "",
            "",
            "",
            "\x01\x4b\x01\uffff\x08\x6d\x02\x4b\x0a\uffff\x03\x4b\x11\uffff"+
            "\x01\x6c\x0b\uffff\x03\x4b\x11\uffff\x01\x6c",
            "\x01\x4b\x01\uffff\x0a\x6f\x0a\uffff\x03\x4b\x1d\uffff\x03"+
            "\x4b",
            "",
            "",
            "\x01\x70",
            "",
            "",
            "\x01\x71",
            "\x01\x72",
            "\x01\x73",
            "\x01\x74\x10\uffff\x01\x75",
            "\x01\x76",
            "\x01\x77\x12\uffff\x01\x78",
            "\x01\x79",
            "\x01\x7a",
            "\x01\x7b\x0c\uffff\x01\x7c",
            "\x01\x7d\x02\uffff\x01\x7e",
            "\x01\x7f",
            "\x01\u0080",
            "\x01\u0081",
            "\x01\u0082",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u0084",
            "\x01\u0085",
            "\x01\u0086",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x14\x28\x01\u0087\x05\x28",
            "\x01\u0089",
            "\x01\u008b\x09\uffff\x01\u008a",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\u008c",
            "",
            "",
            "\x01\u008e",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\u0090",
            "\x01\u0091",
            "\x01\u0092",
            "",
            "\x01\x4b\x01\uffff\x08\x6d\x02\x4b\x0a\uffff\x03\x4b\x1d\uffff"+
            "\x03\x4b",
            "",
            "\x01\x4b\x01\uffff\x0a\x6f\x0a\uffff\x03\x4b\x1d\uffff\x03"+
            "\x4b",
            "\x01\u0094",
            "\x01\u0095",
            "\x01\u0096",
            "\x01\u0097",
            "\x01\u0098",
            "\x01\u0099",
            "\x01\u009a",
            "\x01\u009b",
            "\x01\u009c",
            "\x01\u009d",
            "\x01\u009e",
            "\x01\u009f",
            "\x01\u00a0",
            "\x01\u00a1",
            "\x01\u00a2",
            "\x01\u00a3",
            "\x01\u00a4\x01\u00a5",
            "\x01\u00a6",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "",
            "\x01\u00a8",
            "\x01\u00a9",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00ab",
            "",
            "\x01\u00ac",
            "\x01\u00ad",
            "\x01\u00ae",
            "",
            "",
            "",
            "",
            "\x01\u00af",
            "\x01\u00b0",
            "\x01\u00b1",
            "",
            "\x01\u00b2",
            "\x01\u00b3",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00b6",
            "\x01\u00b7",
            "\x01\u00b8",
            "\x01\u00b9",
            "\x01\u00ba",
            "\x01\u00bb",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00bd",
            "\x01\u00be",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00c0",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00c2",
            "\x01\u00c3",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00c6",
            "",
            "\x01\u00c7",
            "\x01\u00c8",
            "\x01\u00c9",
            "\x01\u00ca",
            "\x01\u00cb",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00cd",
            "\x01\u00ce",
            "\x01\u00cf",
            "",
            "",
            "\x01\u00d0",
            "\x01\u00d1",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00d3",
            "\x01\u00d4",
            "\x01\u00d5",
            "",
            "\x01\u00d6",
            "\x01\u00d7",
            "",
            "\x01\u00d8",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00da",
            "",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00dc",
            "\x01\u00dd",
            "\x01\u00de",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00e2",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00e9",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00eb",
            "",
            "\x01\u00ec",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00ee",
            "\x01\u00ef",
            "",
            "",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\u00f1",
            "",
            "\x01\u00f2",
            "\x01\u00f3",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\u00f5",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "",
            "\x01\x28\x0b\uffff\x0a\x28\x07\uffff\x1a\x28\x04\uffff\x01"+
            "\x28\x01\uffff\x1a\x28",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA35_eot = DFA.UnpackEncodedString(DFA35_eotS);
    static readonly short[] DFA35_eof = DFA.UnpackEncodedString(DFA35_eofS);
    static readonly char[] DFA35_min = DFA.UnpackEncodedStringToUnsignedChars(DFA35_minS);
    static readonly char[] DFA35_max = DFA.UnpackEncodedStringToUnsignedChars(DFA35_maxS);
    static readonly short[] DFA35_accept = DFA.UnpackEncodedString(DFA35_acceptS);
    static readonly short[] DFA35_special = DFA.UnpackEncodedString(DFA35_specialS);
    static readonly short[][] DFA35_transition = DFA.UnpackEncodedStringArray(DFA35_transitionS);

    protected class DFA35 : DFA
    {
        public DFA35(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 35;
            this.eot = DFA35_eot;
            this.eof = DFA35_eof;
            this.min = DFA35_min;
            this.max = DFA35_max;
            this.accept = DFA35_accept;
            this.special = DFA35_special;
            this.transition = DFA35_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | T__67 | T__68 | T__69 | T__70 | T__71 | T__72 | T__73 | T__74 | T__75 | T__76 | T__77 | T__78 | T__79 | T__80 | T__81 | T__82 | T__83 | T__84 | T__85 | T__86 | T__87 | T__88 | T__89 | T__90 | T__91 | T__92 | T__93 | T__94 | T__95 | T__96 | T__97 | T__98 | T__99 | T__100 | IDENTIFIER | CHARACTER_LITERAL | STRING_LITERAL | HEX_LITERAL | DECIMAL_LITERAL | OCTAL_LITERAL | FLOATING_POINT_LITERAL | WS | COMMENT | LINE_COMMENT | LINE_COMMAND );"; }
        }

    }

 
    
}
