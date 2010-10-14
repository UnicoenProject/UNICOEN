// $ANTLR 3.2 Sep 23, 2009 12:02:23 Lua.g 2010-03-22 18:27:46

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class LuaLexer : Lexer {
    public const int T__66 = 66;
    public const int T__64 = 64;
    public const int T__29 = 29;
    public const int T__28 = 28;
    public const int T__65 = 65;
    public const int T__27 = 27;
    public const int T__62 = 62;
    public const int T__26 = 26;
    public const int T__63 = 63;
    public const int T__25 = 25;
    public const int T__24 = 24;
    public const int T__23 = 23;
    public const int T__22 = 22;
    public const int T__21 = 21;
    public const int T__20 = 20;
    public const int FLOAT = 6;
    public const int T__61 = 61;
    public const int EOF = -1;
    public const int T__60 = 60;
    public const int HexDigit = 15;
    public const int T__55 = 55;
    public const int T__56 = 56;
    public const int T__57 = 57;
    public const int NAME = 4;
    public const int T__58 = 58;
    public const int T__51 = 51;
    public const int T__52 = 52;
    public const int T__53 = 53;
    public const int T__54 = 54;
    public const int EXP = 7;
    public const int HEX = 8;
    public const int T__59 = 59;
    public const int COMMENT = 16;
    public const int T__50 = 50;
    public const int T__42 = 42;
    public const int T__43 = 43;
    public const int T__40 = 40;
    public const int T__41 = 41;
    public const int T__46 = 46;
    public const int T__47 = 47;
    public const int T__44 = 44;
    public const int T__45 = 45;
    public const int LINE_COMMENT = 17;
    public const int T__48 = 48;
    public const int T__49 = 49;
    public const int INT = 5;
    public const int CHARSTRING = 10;
    public const int LONGSTRING = 11;
    public const int T__30 = 30;
    public const int T__31 = 31;
    public const int NORMALSTRING = 9;
    public const int T__32 = 32;
    public const int T__33 = 33;
    public const int WS = 18;
    public const int T__34 = 34;
    public const int T__35 = 35;
    public const int NEWLINE = 19;
    public const int T__36 = 36;
    public const int T__37 = 37;
    public const int T__38 = 38;
    public const int T__39 = 39;
    public const int UnicodeEscape = 13;
    public const int EscapeSequence = 12;
    public const int OctalEscape = 14;

    // delegates
    // delegators

    public LuaLexer() 
    {
		InitializeCyclicDFAs();
    }
    public LuaLexer(ICharStream input)
		: this(input, null) {
    }
    public LuaLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "Lua.g";} 
    }

    // $ANTLR start "T__20"
    public void mT__20() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__20;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:7:7: ( ';' )
            // Lua.g:7:9: ';'
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
    // $ANTLR end "T__20"

    // $ANTLR start "T__21"
    public void mT__21() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__21;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:8:7: ( '=' )
            // Lua.g:8:9: '='
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
    // $ANTLR end "T__21"

    // $ANTLR start "T__22"
    public void mT__22() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__22;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:9:7: ( 'do' )
            // Lua.g:9:9: 'do'
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
    // $ANTLR end "T__22"

    // $ANTLR start "T__23"
    public void mT__23() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__23;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:10:7: ( 'end' )
            // Lua.g:10:9: 'end'
            {
            	Match("end"); 


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
            // Lua.g:11:7: ( 'while' )
            // Lua.g:11:9: 'while'
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
    // $ANTLR end "T__24"

    // $ANTLR start "T__25"
    public void mT__25() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__25;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:12:7: ( 'repeat' )
            // Lua.g:12:9: 'repeat'
            {
            	Match("repeat"); 


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
            // Lua.g:13:7: ( 'until' )
            // Lua.g:13:9: 'until'
            {
            	Match("until"); 


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
            // Lua.g:14:7: ( 'if' )
            // Lua.g:14:9: 'if'
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
    // $ANTLR end "T__27"

    // $ANTLR start "T__28"
    public void mT__28() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__28;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:15:7: ( 'then' )
            // Lua.g:15:9: 'then'
            {
            	Match("then"); 


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
            // Lua.g:16:7: ( 'elseif' )
            // Lua.g:16:9: 'elseif'
            {
            	Match("elseif"); 


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
            // Lua.g:17:7: ( 'else' )
            // Lua.g:17:9: 'else'
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
    // $ANTLR end "T__30"

    // $ANTLR start "T__31"
    public void mT__31() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__31;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:18:7: ( 'for' )
            // Lua.g:18:9: 'for'
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
    // $ANTLR end "T__31"

    // $ANTLR start "T__32"
    public void mT__32() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__32;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:19:7: ( ',' )
            // Lua.g:19:9: ','
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
    // $ANTLR end "T__32"

    // $ANTLR start "T__33"
    public void mT__33() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__33;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:20:7: ( 'in' )
            // Lua.g:20:9: 'in'
            {
            	Match("in"); 


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
            // Lua.g:21:7: ( 'function' )
            // Lua.g:21:9: 'function'
            {
            	Match("function"); 


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
            // Lua.g:22:7: ( 'local' )
            // Lua.g:22:9: 'local'
            {
            	Match("local"); 


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
            // Lua.g:23:7: ( 'return' )
            // Lua.g:23:9: 'return'
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
    // $ANTLR end "T__36"

    // $ANTLR start "T__37"
    public void mT__37() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__37;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:24:7: ( 'break' )
            // Lua.g:24:9: 'break'
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
    // $ANTLR end "T__37"

    // $ANTLR start "T__38"
    public void mT__38() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__38;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:25:7: ( '.' )
            // Lua.g:25:9: '.'
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
    // $ANTLR end "T__38"

    // $ANTLR start "T__39"
    public void mT__39() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__39;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:26:7: ( ':' )
            // Lua.g:26:9: ':'
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
    // $ANTLR end "T__39"

    // $ANTLR start "T__40"
    public void mT__40() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__40;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:27:7: ( 'nil' )
            // Lua.g:27:9: 'nil'
            {
            	Match("nil"); 


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
            // Lua.g:28:7: ( 'false' )
            // Lua.g:28:9: 'false'
            {
            	Match("false"); 


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
            // Lua.g:29:7: ( 'true' )
            // Lua.g:29:9: 'true'
            {
            	Match("true"); 


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
            // Lua.g:30:7: ( '...' )
            // Lua.g:30:9: '...'
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
    // $ANTLR end "T__43"

    // $ANTLR start "T__44"
    public void mT__44() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__44;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:31:7: ( '(' )
            // Lua.g:31:9: '('
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
    // $ANTLR end "T__44"

    // $ANTLR start "T__45"
    public void mT__45() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__45;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:32:7: ( ')' )
            // Lua.g:32:9: ')'
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
    // $ANTLR end "T__45"

    // $ANTLR start "T__46"
    public void mT__46() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__46;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:33:7: ( '[' )
            // Lua.g:33:9: '['
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
    // $ANTLR end "T__46"

    // $ANTLR start "T__47"
    public void mT__47() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__47;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:34:7: ( ']' )
            // Lua.g:34:9: ']'
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
    // $ANTLR end "T__47"

    // $ANTLR start "T__48"
    public void mT__48() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__48;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:35:7: ( '{' )
            // Lua.g:35:9: '{'
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
    // $ANTLR end "T__48"

    // $ANTLR start "T__49"
    public void mT__49() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__49;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:36:7: ( '}' )
            // Lua.g:36:9: '}'
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
    // $ANTLR end "T__49"

    // $ANTLR start "T__50"
    public void mT__50() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__50;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:37:7: ( '+' )
            // Lua.g:37:9: '+'
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
    // $ANTLR end "T__50"

    // $ANTLR start "T__51"
    public void mT__51() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__51;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:38:7: ( '-' )
            // Lua.g:38:9: '-'
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
    // $ANTLR end "T__51"

    // $ANTLR start "T__52"
    public void mT__52() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__52;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:39:7: ( '*' )
            // Lua.g:39:9: '*'
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
            // Lua.g:40:7: ( '/' )
            // Lua.g:40:9: '/'
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
    // $ANTLR end "T__53"

    // $ANTLR start "T__54"
    public void mT__54() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__54;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:41:7: ( '^' )
            // Lua.g:41:9: '^'
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
    // $ANTLR end "T__54"

    // $ANTLR start "T__55"
    public void mT__55() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__55;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:42:7: ( '%' )
            // Lua.g:42:9: '%'
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
    // $ANTLR end "T__55"

    // $ANTLR start "T__56"
    public void mT__56() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__56;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:43:7: ( '..' )
            // Lua.g:43:9: '..'
            {
            	Match(".."); 


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
            // Lua.g:44:7: ( '<' )
            // Lua.g:44:9: '<'
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
    // $ANTLR end "T__57"

    // $ANTLR start "T__58"
    public void mT__58() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__58;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:45:7: ( '<=' )
            // Lua.g:45:9: '<='
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
    // $ANTLR end "T__58"

    // $ANTLR start "T__59"
    public void mT__59() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__59;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:46:7: ( '>' )
            // Lua.g:46:9: '>'
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
    // $ANTLR end "T__59"

    // $ANTLR start "T__60"
    public void mT__60() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__60;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:47:7: ( '>=' )
            // Lua.g:47:9: '>='
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
    // $ANTLR end "T__60"

    // $ANTLR start "T__61"
    public void mT__61() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__61;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:48:7: ( '==' )
            // Lua.g:48:9: '=='
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
    // $ANTLR end "T__61"

    // $ANTLR start "T__62"
    public void mT__62() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T__62;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:49:7: ( '~=' )
            // Lua.g:49:9: '~='
            {
            	Match("~="); 


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
            // Lua.g:50:7: ( 'and' )
            // Lua.g:50:9: 'and'
            {
            	Match("and"); 


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
            // Lua.g:51:7: ( 'or' )
            // Lua.g:51:9: 'or'
            {
            	Match("or"); 


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
            // Lua.g:52:7: ( 'not' )
            // Lua.g:52:9: 'not'
            {
            	Match("not"); 


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
            // Lua.g:53:7: ( '#' )
            // Lua.g:53:9: '#'
            {
            	Match('#'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T__66"

    // $ANTLR start "NAME"
    public void mNAME() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NAME;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:195:6: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )* )
            // Lua.g:195:7: ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// Lua.g:195:30: ( options {greedy=true; } : 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
            	do 
            	{
            	    int alt1 = 5;
            	    switch ( input.LA(1) ) 
            	    {
            	    case 'a':
            	    case 'b':
            	    case 'c':
            	    case 'd':
            	    case 'e':
            	    case 'f':
            	    case 'g':
            	    case 'h':
            	    case 'i':
            	    case 'j':
            	    case 'k':
            	    case 'l':
            	    case 'm':
            	    case 'n':
            	    case 'o':
            	    case 'p':
            	    case 'q':
            	    case 'r':
            	    case 's':
            	    case 't':
            	    case 'u':
            	    case 'v':
            	    case 'w':
            	    case 'x':
            	    case 'y':
            	    case 'z':
            	    	{
            	        alt1 = 1;
            	        }
            	        break;
            	    case 'A':
            	    case 'B':
            	    case 'C':
            	    case 'D':
            	    case 'E':
            	    case 'F':
            	    case 'G':
            	    case 'H':
            	    case 'I':
            	    case 'J':
            	    case 'K':
            	    case 'L':
            	    case 'M':
            	    case 'N':
            	    case 'O':
            	    case 'P':
            	    case 'Q':
            	    case 'R':
            	    case 'S':
            	    case 'T':
            	    case 'U':
            	    case 'V':
            	    case 'W':
            	    case 'X':
            	    case 'Y':
            	    case 'Z':
            	    	{
            	        alt1 = 2;
            	        }
            	        break;
            	    case '_':
            	    	{
            	        alt1 = 3;
            	        }
            	        break;
            	    case '0':
            	    case '1':
            	    case '2':
            	    case '3':
            	    case '4':
            	    case '5':
            	    case '6':
            	    case '7':
            	    case '8':
            	    case '9':
            	    	{
            	        alt1 = 4;
            	        }
            	        break;

            	    }

            	    switch (alt1) 
            		{
            			case 1 :
            			    // Lua.g:195:54: 'a' .. 'z'
            			    {
            			    	MatchRange('a','z'); 

            			    }
            			    break;
            			case 2 :
            			    // Lua.g:195:63: 'A' .. 'Z'
            			    {
            			    	MatchRange('A','Z'); 

            			    }
            			    break;
            			case 3 :
            			    // Lua.g:195:72: '_'
            			    {
            			    	Match('_'); 

            			    }
            			    break;
            			case 4 :
            			    // Lua.g:195:76: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

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
    // $ANTLR end "NAME"

    // $ANTLR start "INT"
    public void mINT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:198:5: ( ( '0' .. '9' )+ )
            // Lua.g:198:7: ( '0' .. '9' )+
            {
            	// Lua.g:198:7: ( '0' .. '9' )+
            	int cnt2 = 0;
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= '0' && LA2_0 <= '9')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // Lua.g:198:8: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    if ( cnt2 >= 1 ) goto loop2;
            		            EarlyExitException eee2 =
            		                new EarlyExitException(2, input);
            		            throw eee2;
            	    }
            	    cnt2++;
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INT"

    // $ANTLR start "FLOAT"
    public void mFLOAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:200:8: ( INT '.' INT )
            // Lua.g:200:9: INT '.' INT
            {
            	mINT(); 
            	Match('.'); 
            	mINT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FLOAT"

    // $ANTLR start "EXP"
    public void mEXP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EXP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:202:5: ( ( INT | FLOAT ) ( 'E' | 'e' ) ( '-' )? INT )
            // Lua.g:202:7: ( INT | FLOAT ) ( 'E' | 'e' ) ( '-' )? INT
            {
            	// Lua.g:202:7: ( INT | FLOAT )
            	int alt3 = 2;
            	alt3 = dfa3.Predict(input);
            	switch (alt3) 
            	{
            	    case 1 :
            	        // Lua.g:202:8: INT
            	        {
            	        	mINT(); 

            	        }
            	        break;
            	    case 2 :
            	        // Lua.g:202:13: FLOAT
            	        {
            	        	mFLOAT(); 

            	        }
            	        break;

            	}

            	if ( input.LA(1) == 'E' || input.LA(1) == 'e' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// Lua.g:202:30: ( '-' )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);

            	if ( (LA4_0 == '-') )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // Lua.g:202:31: '-'
            	        {
            	        	Match('-'); 

            	        }
            	        break;

            	}

            	mINT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EXP"

    // $ANTLR start "HEX"
    public void mHEX() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = HEX;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:204:5: ( '0x' ( '0' .. '9' | 'a' .. 'f' )+ )
            // Lua.g:204:6: '0x' ( '0' .. '9' | 'a' .. 'f' )+
            {
            	Match("0x"); 

            	// Lua.g:204:11: ( '0' .. '9' | 'a' .. 'f' )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( ((LA5_0 >= '0' && LA5_0 <= '9') || (LA5_0 >= 'a' && LA5_0 <= 'f')) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // Lua.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'a' && input.LA(1) <= 'f') ) 
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
            			    if ( cnt5 >= 1 ) goto loop5;
            		            EarlyExitException eee5 =
            		                new EarlyExitException(5, input);
            		            throw eee5;
            	    }
            	    cnt5++;
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "HEX"

    // $ANTLR start "NORMALSTRING"
    public void mNORMALSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NORMALSTRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:209:5: ( '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"' )
            // Lua.g:209:8: '\"' ( EscapeSequence | ~ ( '\\\\' | '\"' ) )* '\"'
            {
            	Match('\"'); 
            	// Lua.g:209:12: ( EscapeSequence | ~ ( '\\\\' | '\"' ) )*
            	do 
            	{
            	    int alt6 = 3;
            	    int LA6_0 = input.LA(1);

            	    if ( (LA6_0 == '\\') )
            	    {
            	        alt6 = 1;
            	    }
            	    else if ( ((LA6_0 >= '\u0000' && LA6_0 <= '!') || (LA6_0 >= '#' && LA6_0 <= '[') || (LA6_0 >= ']' && LA6_0 <= '\uFFFF')) )
            	    {
            	        alt6 = 2;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // Lua.g:209:14: EscapeSequence
            			    {
            			    	mEscapeSequence(); 

            			    }
            			    break;
            			case 2 :
            			    // Lua.g:209:31: ~ ( '\\\\' | '\"' )
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
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	Match('\"'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NORMALSTRING"

    // $ANTLR start "CHARSTRING"
    public void mCHARSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CHARSTRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:213:4: ( '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )* '\\'' )
            // Lua.g:213:6: '\\'' ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )* '\\''
            {
            	Match('\''); 
            	// Lua.g:213:11: ( EscapeSequence | ~ ( '\\'' | '\\\\' ) )*
            	do 
            	{
            	    int alt7 = 3;
            	    int LA7_0 = input.LA(1);

            	    if ( (LA7_0 == '\\') )
            	    {
            	        alt7 = 1;
            	    }
            	    else if ( ((LA7_0 >= '\u0000' && LA7_0 <= '&') || (LA7_0 >= '(' && LA7_0 <= '[') || (LA7_0 >= ']' && LA7_0 <= '\uFFFF')) )
            	    {
            	        alt7 = 2;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // Lua.g:213:13: EscapeSequence
            			    {
            			    	mEscapeSequence(); 

            			    }
            			    break;
            			case 2 :
            			    // Lua.g:213:30: ~ ( '\\'' | '\\\\' )
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

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	Match('\''); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CHARSTRING"

    // $ANTLR start "LONGSTRING"
    public void mLONGSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LONGSTRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:217:2: ( '[' ( '=' )* '[' ( EscapeSequence | ~ ( '\\\\' | ']' ) )* ']' ( '=' )* ']' )
            // Lua.g:217:4: '[' ( '=' )* '[' ( EscapeSequence | ~ ( '\\\\' | ']' ) )* ']' ( '=' )* ']'
            {
            	Match('['); 
            	// Lua.g:217:7: ( '=' )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);

            	    if ( (LA8_0 == '=') )
            	    {
            	        alt8 = 1;
            	    }


            	    switch (alt8) 
            		{
            			case 1 :
            			    // Lua.g:217:8: '='
            			    {
            			    	Match('='); 

            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements

            	Match('['); 
            	// Lua.g:217:17: ( EscapeSequence | ~ ( '\\\\' | ']' ) )*
            	do 
            	{
            	    int alt9 = 3;
            	    int LA9_0 = input.LA(1);

            	    if ( (LA9_0 == '\\') )
            	    {
            	        alt9 = 1;
            	    }
            	    else if ( ((LA9_0 >= '\u0000' && LA9_0 <= '[') || (LA9_0 >= '^' && LA9_0 <= '\uFFFF')) )
            	    {
            	        alt9 = 2;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // Lua.g:217:19: EscapeSequence
            			    {
            			    	mEscapeSequence(); 

            			    }
            			    break;
            			case 2 :
            			    // Lua.g:217:36: ~ ( '\\\\' | ']' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '[') || (input.LA(1) >= '^' && input.LA(1) <= '\uFFFF') ) 
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
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements

            	Match(']'); 
            	// Lua.g:217:54: ( '=' )*
            	do 
            	{
            	    int alt10 = 2;
            	    int LA10_0 = input.LA(1);

            	    if ( (LA10_0 == '=') )
            	    {
            	        alt10 = 1;
            	    }


            	    switch (alt10) 
            		{
            			case 1 :
            			    // Lua.g:217:55: '='
            			    {
            			    	Match('='); 

            			    }
            			    break;

            			default:
            			    goto loop10;
            	    }
            	} while (true);

            	loop10:
            		;	// Stops C# compiler whining that label 'loop10' has no statements

            	Match(']'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LONGSTRING"

    // $ANTLR start "EscapeSequence"
    public void mEscapeSequence() // throws RecognitionException [2]
    {
    		try
    		{
            // Lua.g:222:5: ( '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' ) | UnicodeEscape | OctalEscape )
            int alt11 = 3;
            int LA11_0 = input.LA(1);

            if ( (LA11_0 == '\\') )
            {
                switch ( input.LA(2) ) 
                {
                case '\"':
                case '\'':
                case '\\':
                case 'b':
                case 'f':
                case 'n':
                case 'r':
                case 't':
                	{
                    alt11 = 1;
                    }
                    break;
                case 'u':
                	{
                    alt11 = 2;
                    }
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                	{
                    alt11 = 3;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d11s1 =
                	        new NoViableAltException("", 11, 1, input);

                	    throw nvae_d11s1;
                }

            }
            else 
            {
                NoViableAltException nvae_d11s0 =
                    new NoViableAltException("", 11, 0, input);

                throw nvae_d11s0;
            }
            switch (alt11) 
            {
                case 1 :
                    // Lua.g:222:9: '\\\\' ( 'b' | 't' | 'n' | 'f' | 'r' | '\\\"' | '\\'' | '\\\\' )
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
                    // Lua.g:223:9: UnicodeEscape
                    {
                    	mUnicodeEscape(); 

                    }
                    break;
                case 3 :
                    // Lua.g:224:9: OctalEscape
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
            // Lua.g:229:5: ( '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) ( '0' .. '7' ) | '\\\\' ( '0' .. '7' ) )
            int alt12 = 3;
            int LA12_0 = input.LA(1);

            if ( (LA12_0 == '\\') )
            {
                int LA12_1 = input.LA(2);

                if ( ((LA12_1 >= '0' && LA12_1 <= '3')) )
                {
                    int LA12_2 = input.LA(3);

                    if ( ((LA12_2 >= '0' && LA12_2 <= '7')) )
                    {
                        int LA12_4 = input.LA(4);

                        if ( ((LA12_4 >= '0' && LA12_4 <= '7')) )
                        {
                            alt12 = 1;
                        }
                        else 
                        {
                            alt12 = 2;}
                    }
                    else 
                    {
                        alt12 = 3;}
                }
                else if ( ((LA12_1 >= '4' && LA12_1 <= '7')) )
                {
                    int LA12_3 = input.LA(3);

                    if ( ((LA12_3 >= '0' && LA12_3 <= '7')) )
                    {
                        alt12 = 2;
                    }
                    else 
                    {
                        alt12 = 3;}
                }
                else 
                {
                    NoViableAltException nvae_d12s1 =
                        new NoViableAltException("", 12, 1, input);

                    throw nvae_d12s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d12s0 =
                    new NoViableAltException("", 12, 0, input);

                throw nvae_d12s0;
            }
            switch (alt12) 
            {
                case 1 :
                    // Lua.g:229:9: '\\\\' ( '0' .. '3' ) ( '0' .. '7' ) ( '0' .. '7' )
                    {
                    	Match('\\'); 
                    	// Lua.g:229:14: ( '0' .. '3' )
                    	// Lua.g:229:15: '0' .. '3'
                    	{
                    		MatchRange('0','3'); 

                    	}

                    	// Lua.g:229:25: ( '0' .. '7' )
                    	// Lua.g:229:26: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}

                    	// Lua.g:229:36: ( '0' .. '7' )
                    	// Lua.g:229:37: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}


                    }
                    break;
                case 2 :
                    // Lua.g:230:9: '\\\\' ( '0' .. '7' ) ( '0' .. '7' )
                    {
                    	Match('\\'); 
                    	// Lua.g:230:14: ( '0' .. '7' )
                    	// Lua.g:230:15: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}

                    	// Lua.g:230:25: ( '0' .. '7' )
                    	// Lua.g:230:26: '0' .. '7'
                    	{
                    		MatchRange('0','7'); 

                    	}


                    }
                    break;
                case 3 :
                    // Lua.g:231:9: '\\\\' ( '0' .. '7' )
                    {
                    	Match('\\'); 
                    	// Lua.g:231:14: ( '0' .. '7' )
                    	// Lua.g:231:15: '0' .. '7'
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
            // Lua.g:236:5: ( '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit )
            // Lua.g:236:9: '\\\\' 'u' HexDigit HexDigit HexDigit HexDigit
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

    // $ANTLR start "HexDigit"
    public void mHexDigit() // throws RecognitionException [2]
    {
    		try
    		{
            // Lua.g:240:10: ( ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' ) )
            // Lua.g:240:12: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )
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

    // $ANTLR start "COMMENT"
    public void mCOMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:244:5: ( '--[[' ( options {greedy=false; } : . )* ']]' )
            // Lua.g:244:9: '--[[' ( options {greedy=false; } : . )* ']]'
            {
            	Match("--[["); 

            	// Lua.g:244:16: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt13 = 2;
            	    int LA13_0 = input.LA(1);

            	    if ( (LA13_0 == ']') )
            	    {
            	        int LA13_1 = input.LA(2);

            	        if ( (LA13_1 == ']') )
            	        {
            	            alt13 = 2;
            	        }
            	        else if ( ((LA13_1 >= '\u0000' && LA13_1 <= '\\') || (LA13_1 >= '^' && LA13_1 <= '\uFFFF')) )
            	        {
            	            alt13 = 1;
            	        }


            	    }
            	    else if ( ((LA13_0 >= '\u0000' && LA13_0 <= '\\') || (LA13_0 >= '^' && LA13_0 <= '\uFFFF')) )
            	    {
            	        alt13 = 1;
            	    }


            	    switch (alt13) 
            		{
            			case 1 :
            			    // Lua.g:244:44: .
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

            	Match("]]"); 

            	Skip();

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
            // Lua.g:248:5: ( '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // Lua.g:248:7: '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("--"); 

            	// Lua.g:248:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt14 = 2;
            	    int LA14_0 = input.LA(1);

            	    if ( ((LA14_0 >= '\u0000' && LA14_0 <= '\t') || (LA14_0 >= '\u000B' && LA14_0 <= '\f') || (LA14_0 >= '\u000E' && LA14_0 <= '\uFFFF')) )
            	    {
            	        alt14 = 1;
            	    }


            	    switch (alt14) 
            		{
            			case 1 :
            			    // Lua.g:248:12: ~ ( '\\n' | '\\r' )
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
            			    goto loop14;
            	    }
            	} while (true);

            	loop14:
            		;	// Stops C# compiler whining that label 'loop14' has no statements

            	// Lua.g:248:26: ( '\\r' )?
            	int alt15 = 2;
            	int LA15_0 = input.LA(1);

            	if ( (LA15_0 == '\r') )
            	{
            	    alt15 = 1;
            	}
            	switch (alt15) 
            	{
            	    case 1 :
            	        // Lua.g:248:26: '\\r'
            	        {
            	        	Match('\r'); 

            	        }
            	        break;

            	}

            	Match('\n'); 
            	Skip();

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LINE_COMMENT"

    // $ANTLR start "WS"
    public void mWS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:252:5: ( ( ' ' | '\\t' | '\\u000C' ) )
            // Lua.g:252:8: ( ' ' | '\\t' | '\\u000C' )
            {
            	if ( input.LA(1) == '\t' || input.LA(1) == '\f' || input.LA(1) == ' ' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	Skip();

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WS"

    // $ANTLR start "NEWLINE"
    public void mNEWLINE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NEWLINE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // Lua.g:255:9: ( ( '\\r' )? '\\n' )
            // Lua.g:255:11: ( '\\r' )? '\\n'
            {
            	// Lua.g:255:11: ( '\\r' )?
            	int alt16 = 2;
            	int LA16_0 = input.LA(1);

            	if ( (LA16_0 == '\r') )
            	{
            	    alt16 = 1;
            	}
            	switch (alt16) 
            	{
            	    case 1 :
            	        // Lua.g:255:12: '\\r'
            	        {
            	        	Match('\r'); 

            	        }
            	        break;

            	}

            	Match('\n'); 
            	Skip();

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NEWLINE"

    override public void mTokens() // throws RecognitionException 
    {
        // Lua.g:1:8: ( T__20 | T__21 | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | NAME | INT | FLOAT | EXP | HEX | NORMALSTRING | CHARSTRING | LONGSTRING | COMMENT | LINE_COMMENT | WS | NEWLINE )
        int alt17 = 59;
        alt17 = dfa17.Predict(input);
        switch (alt17) 
        {
            case 1 :
                // Lua.g:1:10: T__20
                {
                	mT__20(); 

                }
                break;
            case 2 :
                // Lua.g:1:16: T__21
                {
                	mT__21(); 

                }
                break;
            case 3 :
                // Lua.g:1:22: T__22
                {
                	mT__22(); 

                }
                break;
            case 4 :
                // Lua.g:1:28: T__23
                {
                	mT__23(); 

                }
                break;
            case 5 :
                // Lua.g:1:34: T__24
                {
                	mT__24(); 

                }
                break;
            case 6 :
                // Lua.g:1:40: T__25
                {
                	mT__25(); 

                }
                break;
            case 7 :
                // Lua.g:1:46: T__26
                {
                	mT__26(); 

                }
                break;
            case 8 :
                // Lua.g:1:52: T__27
                {
                	mT__27(); 

                }
                break;
            case 9 :
                // Lua.g:1:58: T__28
                {
                	mT__28(); 

                }
                break;
            case 10 :
                // Lua.g:1:64: T__29
                {
                	mT__29(); 

                }
                break;
            case 11 :
                // Lua.g:1:70: T__30
                {
                	mT__30(); 

                }
                break;
            case 12 :
                // Lua.g:1:76: T__31
                {
                	mT__31(); 

                }
                break;
            case 13 :
                // Lua.g:1:82: T__32
                {
                	mT__32(); 

                }
                break;
            case 14 :
                // Lua.g:1:88: T__33
                {
                	mT__33(); 

                }
                break;
            case 15 :
                // Lua.g:1:94: T__34
                {
                	mT__34(); 

                }
                break;
            case 16 :
                // Lua.g:1:100: T__35
                {
                	mT__35(); 

                }
                break;
            case 17 :
                // Lua.g:1:106: T__36
                {
                	mT__36(); 

                }
                break;
            case 18 :
                // Lua.g:1:112: T__37
                {
                	mT__37(); 

                }
                break;
            case 19 :
                // Lua.g:1:118: T__38
                {
                	mT__38(); 

                }
                break;
            case 20 :
                // Lua.g:1:124: T__39
                {
                	mT__39(); 

                }
                break;
            case 21 :
                // Lua.g:1:130: T__40
                {
                	mT__40(); 

                }
                break;
            case 22 :
                // Lua.g:1:136: T__41
                {
                	mT__41(); 

                }
                break;
            case 23 :
                // Lua.g:1:142: T__42
                {
                	mT__42(); 

                }
                break;
            case 24 :
                // Lua.g:1:148: T__43
                {
                	mT__43(); 

                }
                break;
            case 25 :
                // Lua.g:1:154: T__44
                {
                	mT__44(); 

                }
                break;
            case 26 :
                // Lua.g:1:160: T__45
                {
                	mT__45(); 

                }
                break;
            case 27 :
                // Lua.g:1:166: T__46
                {
                	mT__46(); 

                }
                break;
            case 28 :
                // Lua.g:1:172: T__47
                {
                	mT__47(); 

                }
                break;
            case 29 :
                // Lua.g:1:178: T__48
                {
                	mT__48(); 

                }
                break;
            case 30 :
                // Lua.g:1:184: T__49
                {
                	mT__49(); 

                }
                break;
            case 31 :
                // Lua.g:1:190: T__50
                {
                	mT__50(); 

                }
                break;
            case 32 :
                // Lua.g:1:196: T__51
                {
                	mT__51(); 

                }
                break;
            case 33 :
                // Lua.g:1:202: T__52
                {
                	mT__52(); 

                }
                break;
            case 34 :
                // Lua.g:1:208: T__53
                {
                	mT__53(); 

                }
                break;
            case 35 :
                // Lua.g:1:214: T__54
                {
                	mT__54(); 

                }
                break;
            case 36 :
                // Lua.g:1:220: T__55
                {
                	mT__55(); 

                }
                break;
            case 37 :
                // Lua.g:1:226: T__56
                {
                	mT__56(); 

                }
                break;
            case 38 :
                // Lua.g:1:232: T__57
                {
                	mT__57(); 

                }
                break;
            case 39 :
                // Lua.g:1:238: T__58
                {
                	mT__58(); 

                }
                break;
            case 40 :
                // Lua.g:1:244: T__59
                {
                	mT__59(); 

                }
                break;
            case 41 :
                // Lua.g:1:250: T__60
                {
                	mT__60(); 

                }
                break;
            case 42 :
                // Lua.g:1:256: T__61
                {
                	mT__61(); 

                }
                break;
            case 43 :
                // Lua.g:1:262: T__62
                {
                	mT__62(); 

                }
                break;
            case 44 :
                // Lua.g:1:268: T__63
                {
                	mT__63(); 

                }
                break;
            case 45 :
                // Lua.g:1:274: T__64
                {
                	mT__64(); 

                }
                break;
            case 46 :
                // Lua.g:1:280: T__65
                {
                	mT__65(); 

                }
                break;
            case 47 :
                // Lua.g:1:286: T__66
                {
                	mT__66(); 

                }
                break;
            case 48 :
                // Lua.g:1:292: NAME
                {
                	mNAME(); 

                }
                break;
            case 49 :
                // Lua.g:1:297: INT
                {
                	mINT(); 

                }
                break;
            case 50 :
                // Lua.g:1:301: FLOAT
                {
                	mFLOAT(); 

                }
                break;
            case 51 :
                // Lua.g:1:307: EXP
                {
                	mEXP(); 

                }
                break;
            case 52 :
                // Lua.g:1:311: HEX
                {
                	mHEX(); 

                }
                break;
            case 53 :
                // Lua.g:1:315: NORMALSTRING
                {
                	mNORMALSTRING(); 

                }
                break;
            case 54 :
                // Lua.g:1:328: CHARSTRING
                {
                	mCHARSTRING(); 

                }
                break;
            case 55 :
                // Lua.g:1:339: LONGSTRING
                {
                	mLONGSTRING(); 

                }
                break;
            case 56 :
                // Lua.g:1:350: COMMENT
                {
                	mCOMMENT(); 

                }
                break;
            case 57 :
                // Lua.g:1:358: LINE_COMMENT
                {
                	mLINE_COMMENT(); 

                }
                break;
            case 58 :
                // Lua.g:1:371: WS
                {
                	mWS(); 

                }
                break;
            case 59 :
                // Lua.g:1:374: NEWLINE
                {
                	mNEWLINE(); 

                }
                break;

        }

    }


    protected DFA3 dfa3;
    protected DFA17 dfa17;
	private void InitializeCyclicDFAs()
	{
	    this.dfa3 = new DFA3(this);
	    this.dfa17 = new DFA17(this);
	    this.dfa17.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA17_SpecialStateTransition);
	}

    const string DFA3_eotS =
        "\x04\uffff";
    const string DFA3_eofS =
        "\x04\uffff";
    const string DFA3_minS =
        "\x01\x30\x01\x2e\x02\uffff";
    const string DFA3_maxS =
        "\x01\x39\x01\x65\x02\uffff";
    const string DFA3_acceptS =
        "\x02\uffff\x01\x01\x01\x02";
    const string DFA3_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA3_transitionS = {
            "\x0a\x01",
            "\x01\x03\x01\uffff\x0a\x01\x0b\uffff\x01\x02\x1f\uffff\x01"+
            "\x02",
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
            get { return "202:7: ( INT | FLOAT )"; }
        }

    }

    const string DFA17_eotS =
        "\x02\uffff\x01\x2b\x08\x23\x01\uffff\x02\x23\x01\x3c\x01\uffff"+
        "\x01\x23\x02\uffff\x01\x40\x04\uffff\x01\x42\x04\uffff\x01\x44\x01"+
        "\x46\x01\uffff\x02\x23\x02\uffff\x02\x4a\x06\uffff\x01\x4d\x05\x23"+
        "\x01\x54\x01\x55\x07\x23\x01\x5e\x01\uffff\x02\x23\x08\uffff\x01"+
        "\x23\x01\x64\x05\uffff\x01\x66\x05\x23\x02\uffff\x02\x23\x01\x6e"+
        "\x04\x23\x02\uffff\x01\x73\x01\x74\x02\uffff\x01\x76\x01\uffff\x01"+
        "\x77\x01\uffff\x01\x79\x04\x23\x01\x7e\x01\x7f\x01\uffff\x04\x23"+
        "\x05\uffff\x01\x23\x01\uffff\x01\u0089\x02\x23\x01\u008c\x02\uffff"+
        "\x01\x23\x01\u008e\x01\u008f\x01\u0090\x01\uffff\x01\x62\x02\uffff"+
        "\x01\u0093\x01\uffff\x01\u0094\x01\u0095\x01\uffff\x01\x23\x04\uffff"+
        "\x01\u0091\x03\uffff\x01\x23\x01\u0098\x01\uffff";
    const string DFA17_eofS =
        "\u0099\uffff";
    const string DFA17_minS =
        "\x01\x09\x01\uffff\x01\x3d\x01\x6f\x01\x6c\x01\x68\x01\x65\x01"+
        "\x6e\x01\x66\x01\x68\x01\x61\x01\uffff\x01\x6f\x01\x72\x01\x2e\x01"+
        "\uffff\x01\x69\x02\uffff\x01\x3d\x04\uffff\x01\x2d\x04\uffff\x02"+
        "\x3d\x01\uffff\x01\x6e\x01\x72\x02\uffff\x02\x2e\x06\uffff\x01\x30"+
        "\x01\x64\x01\x73\x01\x69\x01\x70\x01\x74\x02\x30\x01\x65\x01\x75"+
        "\x01\x72\x01\x6e\x01\x6c\x01\x63\x01\x65\x01\x2e\x01\uffff\x01\x6c"+
        "\x01\x74\x02\uffff\x01\x00\x05\uffff\x01\x64\x01\x30\x03\uffff\x01"+
        "\x30\x01\uffff\x01\x30\x01\x65\x01\x6c\x01\x65\x01\x75\x01\x69\x02"+
        "\uffff\x01\x6e\x01\x65\x01\x30\x01\x63\x01\x73\x02\x61\x02\uffff"+
        "\x02\x30\x01\x00\x01\uffff\x01\x30\x01\uffff\x01\x30\x01\uffff\x01"+
        "\x30\x01\x65\x01\x61\x01\x72\x01\x6c\x02\x30\x01\uffff\x01\x74\x01"+
        "\x65\x01\x6c\x01\x6b\x02\uffff\x01\x00\x02\uffff\x01\x66\x01\uffff"+
        "\x01\x30\x01\x74\x01\x6e\x01\x30\x02\uffff\x01\x69\x03\x30\x04\x00"+
        "\x01\x30\x01\uffff\x02\x30\x01\uffff\x01\x6f\x04\uffff\x01\x00\x03"+
        "\uffff\x01\x6e\x01\x30\x01\uffff";
    const string DFA17_maxS =
        "\x01\x7e\x01\uffff\x01\x3d\x01\x6f\x01\x6e\x01\x68\x01\x65\x02"+
        "\x6e\x01\x72\x01\x75\x01\uffff\x01\x6f\x01\x72\x01\x2e\x01\uffff"+
        "\x01\x6f\x02\uffff\x01\x5b\x04\uffff\x01\x2d\x04\uffff\x02\x3d\x01"+
        "\uffff\x01\x6e\x01\x72\x02\uffff\x01\x78\x01\x65\x06\uffff\x01\x7a"+
        "\x01\x64\x01\x73\x01\x69\x02\x74\x02\x7a\x01\x65\x01\x75\x01\x72"+
        "\x01\x6e\x01\x6c\x01\x63\x01\x65\x01\x2e\x01\uffff\x01\x6c\x01\x74"+
        "\x02\uffff\x01\uffff\x05\uffff\x01\x64\x01\x7a\x03\uffff\x01\x39"+
        "\x01\uffff\x01\x7a\x01\x65\x01\x6c\x01\x65\x01\x75\x01\x69\x02\uffff"+
        "\x01\x6e\x01\x65\x01\x7a\x01\x63\x01\x73\x02\x61\x02\uffff\x02\x7a"+
        "\x01\uffff\x01\uffff\x01\x7a\x01\uffff\x01\x65\x01\uffff\x01\x7a"+
        "\x01\x65\x01\x61\x01\x72\x01\x6c\x02\x7a\x01\uffff\x01\x74\x01\x65"+
        "\x01\x6c\x01\x6b\x02\uffff\x01\uffff\x02\uffff\x01\x66\x01\uffff"+
        "\x01\x7a\x01\x74\x01\x6e\x01\x7a\x02\uffff\x01\x69\x03\x7a\x04\uffff"+
        "\x01\x7a\x01\uffff\x02\x7a\x01\uffff\x01\x6f\x04\uffff\x01\uffff"+
        "\x03\uffff\x01\x6e\x01\x7a\x01\uffff";
    const string DFA17_acceptS =
        "\x01\uffff\x01\x01\x09\uffff\x01\x0d\x03\uffff\x01\x14\x01\uffff"+
        "\x01\x19\x01\x1a\x01\uffff\x01\x1c\x01\x1d\x01\x1e\x01\x1f\x01\uffff"+
        "\x01\x21\x01\x22\x01\x23\x01\x24\x02\uffff\x01\x2b\x02\uffff\x01"+
        "\x2f\x01\x30\x02\uffff\x01\x35\x01\x36\x01\x3a\x01\x3b\x01\x2a\x01"+
        "\x02\x10\uffff\x01\x13\x02\uffff\x01\x37\x01\x1b\x01\uffff\x01\x20"+
        "\x01\x27\x01\x26\x01\x29\x01\x28\x02\uffff\x01\x34\x01\x31\x01\x33"+
        "\x01\uffff\x01\x03\x06\uffff\x01\x08\x01\x0e\x07\uffff\x01\x18\x01"+
        "\x25\x03\uffff\x01\x39\x01\uffff\x01\x2d\x01\uffff\x01\x04\x07\uffff"+
        "\x01\x0c\x04\uffff\x01\x15\x01\x2e\x01\uffff\x01\x2c\x01\x32\x01"+
        "\uffff\x01\x0b\x04\uffff\x01\x09\x01\x17\x09\uffff\x01\x05\x02\uffff"+
        "\x01\x07\x01\uffff\x01\x16\x01\x10\x01\x12\x01\x38\x01\uffff\x01"+
        "\x0a\x01\x06\x01\x11\x02\uffff\x01\x0f";
    const string DFA17_specialS =
        "\x41\uffff\x01\x01\x1f\uffff\x01\x03\x13\uffff\x01\x06\x0e\uffff"+
        "\x01\x00\x01\x02\x01\x04\x01\x07\x0a\uffff\x01\x05\x06\uffff}>";
    static readonly string[] DFA17_transitionS = {
            "\x01\x28\x01\x29\x01\uffff\x01\x28\x01\x29\x12\uffff\x01\x28"+
            "\x01\uffff\x01\x26\x01\x22\x01\uffff\x01\x1c\x01\uffff\x01\x27"+
            "\x01\x11\x01\x12\x01\x19\x01\x17\x01\x0b\x01\x18\x01\x0e\x01"+
            "\x1a\x01\x24\x09\x25\x01\x0f\x01\x01\x01\x1d\x01\x02\x01\x1e"+
            "\x02\uffff\x1a\x23\x01\x13\x01\uffff\x01\x14\x01\x1b\x01\x23"+
            "\x01\uffff\x01\x20\x01\x0d\x01\x23\x01\x03\x01\x04\x01\x0a\x02"+
            "\x23\x01\x08\x02\x23\x01\x0c\x01\x23\x01\x10\x01\x21\x02\x23"+
            "\x01\x06\x01\x23\x01\x09\x01\x07\x01\x23\x01\x05\x03\x23\x01"+
            "\x15\x01\uffff\x01\x16\x01\x1f",
            "",
            "\x01\x2a",
            "\x01\x2c",
            "\x01\x2e\x01\uffff\x01\x2d",
            "\x01\x2f",
            "\x01\x30",
            "\x01\x31",
            "\x01\x32\x07\uffff\x01\x33",
            "\x01\x34\x09\uffff\x01\x35",
            "\x01\x38\x0d\uffff\x01\x36\x05\uffff\x01\x37",
            "",
            "\x01\x39",
            "\x01\x3a",
            "\x01\x3b",
            "",
            "\x01\x3d\x05\uffff\x01\x3e",
            "",
            "",
            "\x01\x3f\x1d\uffff\x01\x3f",
            "",
            "",
            "",
            "",
            "\x01\x41",
            "",
            "",
            "",
            "",
            "\x01\x43",
            "\x01\x45",
            "",
            "\x01\x47",
            "\x01\x48",
            "",
            "",
            "\x01\x4c\x01\uffff\x0a\x25\x0b\uffff\x01\x4b\x1f\uffff\x01"+
            "\x4b\x12\uffff\x01\x49",
            "\x01\x4c\x01\uffff\x0a\x25\x0b\uffff\x01\x4b\x1f\uffff\x01"+
            "\x4b",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x01\x4e",
            "\x01\x4f",
            "\x01\x50",
            "\x01\x51\x03\uffff\x01\x52",
            "\x01\x53",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x01\x56",
            "\x01\x57",
            "\x01\x58",
            "\x01\x59",
            "\x01\x5a",
            "\x01\x5b",
            "\x01\x5c",
            "\x01\x5d",
            "",
            "\x01\x5f",
            "\x01\x60",
            "",
            "",
            "\x5b\x62\x01\x61\uffa4\x62",
            "",
            "",
            "",
            "",
            "",
            "\x01\x63",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "",
            "",
            "",
            "\x0a\x65",
            "",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x01\x67",
            "\x01\x68",
            "\x01\x69",
            "\x01\x6a",
            "\x01\x6b",
            "",
            "",
            "\x01\x6c",
            "\x01\x6d",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x01\x6f",
            "\x01\x70",
            "\x01\x71",
            "\x01\x72",
            "",
            "",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x5b\x62\x01\x75\uffa4\x62",
            "",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "",
            "\x0a\x65\x0b\uffff\x01\x4b\x1f\uffff\x01\x4b",
            "",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x08"+
            "\x23\x01\x78\x11\x23",
            "\x01\x7a",
            "\x01\x7b",
            "\x01\x7c",
            "\x01\x7d",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "",
            "\x01\u0080",
            "\x01\u0081",
            "\x01\u0082",
            "\x01\u0083",
            "",
            "",
            "\x0a\u0087\x01\u0085\x02\u0087\x01\u0084\x4f\u0087\x01\u0086"+
            "\uffa2\u0087",
            "",
            "",
            "\x01\u0088",
            "",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x01\u008a",
            "\x01\u008b",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "",
            "",
            "\x01\u008d",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x0a\u0091\x01\u0085\ufff5\u0091",
            "\x00\u0091",
            "\x0a\u0087\x01\u0085\x02\u0087\x01\u0084\x4f\u0087\x01\u0092"+
            "\uffa2\u0087",
            "\x0a\u0087\x01\u0085\x02\u0087\x01\u0084\x4f\u0087\x01\u0086"+
            "\uffa2\u0087",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
            "",
            "\x01\u0096",
            "",
            "",
            "",
            "",
            "\x0a\u0087\x01\u0085\x02\u0087\x01\u0084\x4f\u0087\x01\u0092"+
            "\uffa2\u0087",
            "",
            "",
            "",
            "\x01\u0097",
            "\x0a\x23\x07\uffff\x1a\x23\x04\uffff\x01\x23\x01\uffff\x1a"+
            "\x23",
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
            get { return "1:1: Tokens : ( T__20 | T__21 | T__22 | T__23 | T__24 | T__25 | T__26 | T__27 | T__28 | T__29 | T__30 | T__31 | T__32 | T__33 | T__34 | T__35 | T__36 | T__37 | T__38 | T__39 | T__40 | T__41 | T__42 | T__43 | T__44 | T__45 | T__46 | T__47 | T__48 | T__49 | T__50 | T__51 | T__52 | T__53 | T__54 | T__55 | T__56 | T__57 | T__58 | T__59 | T__60 | T__61 | T__62 | T__63 | T__64 | T__65 | T__66 | NAME | INT | FLOAT | EXP | HEX | NORMALSTRING | CHARSTRING | LONGSTRING | COMMENT | LINE_COMMENT | WS | NEWLINE );"; }
        }

    }


    protected internal int DFA17_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA17_132 = input.LA(1);

                   	s = -1;
                   	if ( ((LA17_132 >= '\u0000' && LA17_132 <= '\t') || (LA17_132 >= '\u000B' && LA17_132 <= '\uFFFF')) ) { s = 145; }

                   	else if ( (LA17_132 == '\n') ) { s = 133; }

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA17_65 = input.LA(1);

                   	s = -1;
                   	if ( (LA17_65 == '[') ) { s = 97; }

                   	else if ( ((LA17_65 >= '\u0000' && LA17_65 <= 'Z') || (LA17_65 >= '\\' && LA17_65 <= '\uFFFF')) ) { s = 98; }

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA17_133 = input.LA(1);

                   	s = -1;
                   	if ( ((LA17_133 >= '\u0000' && LA17_133 <= '\uFFFF')) ) { s = 145; }

                   	else s = 98;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA17_97 = input.LA(1);

                   	s = -1;
                   	if ( (LA17_97 == '[') ) { s = 117; }

                   	else if ( ((LA17_97 >= '\u0000' && LA17_97 <= 'Z') || (LA17_97 >= '\\' && LA17_97 <= '\uFFFF')) ) { s = 98; }

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA17_134 = input.LA(1);

                   	s = -1;
                   	if ( (LA17_134 == ']') ) { s = 146; }

                   	else if ( (LA17_134 == '\r') ) { s = 132; }

                   	else if ( (LA17_134 == '\n') ) { s = 133; }

                   	else if ( ((LA17_134 >= '\u0000' && LA17_134 <= '\t') || (LA17_134 >= '\u000B' && LA17_134 <= '\f') || (LA17_134 >= '\u000E' && LA17_134 <= '\\') || (LA17_134 >= '^' && LA17_134 <= '\uFFFF')) ) { s = 135; }

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA17_146 = input.LA(1);

                   	s = -1;
                   	if ( (LA17_146 == ']') ) { s = 146; }

                   	else if ( (LA17_146 == '\r') ) { s = 132; }

                   	else if ( (LA17_146 == '\n') ) { s = 133; }

                   	else if ( ((LA17_146 >= '\u0000' && LA17_146 <= '\t') || (LA17_146 >= '\u000B' && LA17_146 <= '\f') || (LA17_146 >= '\u000E' && LA17_146 <= '\\') || (LA17_146 >= '^' && LA17_146 <= '\uFFFF')) ) { s = 135; }

                   	else s = 145;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA17_117 = input.LA(1);

                   	s = -1;
                   	if ( (LA17_117 == '\r') ) { s = 132; }

                   	else if ( (LA17_117 == '\n') ) { s = 133; }

                   	else if ( (LA17_117 == ']') ) { s = 134; }

                   	else if ( ((LA17_117 >= '\u0000' && LA17_117 <= '\t') || (LA17_117 >= '\u000B' && LA17_117 <= '\f') || (LA17_117 >= '\u000E' && LA17_117 <= '\\') || (LA17_117 >= '^' && LA17_117 <= '\uFFFF')) ) { s = 135; }

                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA17_135 = input.LA(1);

                   	s = -1;
                   	if ( (LA17_135 == ']') ) { s = 134; }

                   	else if ( (LA17_135 == '\r') ) { s = 132; }

                   	else if ( (LA17_135 == '\n') ) { s = 133; }

                   	else if ( ((LA17_135 >= '\u0000' && LA17_135 <= '\t') || (LA17_135 >= '\u000B' && LA17_135 <= '\f') || (LA17_135 >= '\u000E' && LA17_135 <= '\\') || (LA17_135 >= '^' && LA17_135 <= '\uFFFF')) ) { s = 135; }

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae17 =
            new NoViableAltException(dfa.Description, 17, _s, input);
        dfa.Error(nvae17);
        throw nvae17;
    }
 
    
}
