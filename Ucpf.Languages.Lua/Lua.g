/*
 * Lua 5.1 grammar
 * 
 * Changed by Kazunori Sakamoto in order to output AST as XML format on C# December 2009.
 * 
 * Nicolai Mainiero
 * May 2007
 * 
 * This is a Lua (http://www.lua.org) grammar for the version 5.1 for ANTLR 3.
 * I tested it with basic and extended examples and it worked fine. It is also used
 * for LunarEclipse (http://lunareclipse.sf.net) a Lua editor based on Eclipse.
 * 
 * Thanks to Johannes Luber and Gavin Lambert who helped me with some mutually left recursion.
 *  
 */

grammar Lua;

options {
  language=CSharp2;
  backtrack=true;
  output=AST;
}

@header {
using System.Collections.Generic;
using System.Xml.Linq;
}

@members {
private readonly IList<XElement> Elements = new List<XElement>();
public IList<XElement> ElementList { get { return Elements; } }
public string LeaveElementName { get; set; }
}

chunk
@init { const string elementName = "chunk"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: (stat (';')?)* (laststat (';')?)?;

block 
@init { const string elementName = "block"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: chunk;

stat
@init { const string elementName = "stat"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:  varlist1 '=' explist1 | 
	functioncall | 
	'do' block 'end' | 
	'while' exp 'do' block 'end' | 
	'repeat' block 'until' exp | 
	'if' exp 'then' block ('elseif' exp 'then' block)* ('else' block)? 'end' | 
	'for' NAME '=' exp ',' exp (',' exp)? 'do' block 'end' | 
	'for' namelist 'in' explist1 'do' block 'end' | 
	'function' funcname funcbody | 
	'local' 'function' NAME funcbody | 
	'local' namelist ('=' explist1)? ;

laststat
@init { const string elementName = "laststat"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'return' (explist1)? | 'break';

funcname
@init { const string elementName = "funcname"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: NAME ('.' NAME)* (':' NAME)? ;

varlist1
@init { const string elementName = "varlist1"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: var (',' var)*;


namelist
@init { const string elementName = "namelist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: NAME (',' NAME)*;

explist1 
@init { const string elementName = "explist1"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: (exp ',')* exp;

exp 
@init { const string elementName = "exp"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:  ('nil' | 'false' | 'true' | lua_number | lua_string | '...' | function | prefixexp | tableconstructor | unop exp) (binop exp)* ;

var
@init { const string elementName = "var"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: (NAME | '(' exp ')' varSuffix) varSuffix*;

prefixexp
@init { const string elementName = "prefixexp"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: varOrExp nameAndArgs*;

functioncall
@init { const string elementName = "functioncall"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: varOrExp nameAndArgs+;

/*
var :  NAME | prefixexp '[' exp ']' | prefixexp '.' NAME; 

prefixexp : var | functioncall | '(' exp ')';

functioncall :  prefixexp args | prefixexp ':' NAME args ;
*/

varOrExp
@init { const string elementName = "varOrExp"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: var | '(' exp ')';

nameAndArgs
@init { const string elementName = "nameAndArgs"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: (':' NAME)? args;

varSuffix
@init { const string elementName = "varSuffix"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: nameAndArgs* ('[' exp ']' | '.' NAME);

args 
@init { const string elementName = "args"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:  '(' (explist1)? ')' | tableconstructor | lua_string ;

function 
@init { const string elementName = "function"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'function' funcbody;

funcbody 
@init { const string elementName = "funcbody"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '(' (parlist1)? ')' block 'end';

parlist1 
@init { const string elementName = "parlist1"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: namelist (',' '...')? | '...';

tableconstructor 
@init { const string elementName = "tableconstructor"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '{' (fieldlist)? '}';

fieldlist 
@init { const string elementName = "fieldlist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: field (fieldsep field)* (fieldsep)?;

field 
@init { const string elementName = "field"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '[' exp ']' '=' exp | NAME '=' exp | exp;

fieldsep 
@init { const string elementName = "fieldsep"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: ',' | ';';

binop 
@init { const string elementName = "binop"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '+' | '-' | '*' | '/' | '^' | '%' | '..' | 
		 '<' | '<=' | '>' | '>=' | '==' | '~=' | 
		 'and' | 'or';

unop 
@init { const string elementName = "unop"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '-' | 'not' | '#';

lua_number 
@init { const string elementName = "lua_number"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: INT | FLOAT | EXP | HEX;

lua_string	
@init { const string elementName = "lua_string"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: NORMALSTRING | CHARSTRING | LONGSTRING;


// LEXER

NAME	:('a'..'z'|'A'..'Z'|'_')(options{greedy=true;}:	'a'..'z'|'A'..'Z'|'_'|'0'..'9')*
	;

INT	: ('0'..'9')+;

FLOAT 	:INT '.' INT ;

EXP	: (INT| FLOAT) ('E'|'e') ('-')? INT;

HEX	:'0x' ('0'..'9'| 'a'..'f')+ ;

	

NORMALSTRING
    :  '"' ( EscapeSequence | ~('\\'|'"') )* '"' 
    ;

CHARSTRING
   :	'\'' ( EscapeSequence | ~('\''|'\\') )* '\''
   ;

LONGSTRING
	:	'['('=')*'[' ( EscapeSequence | ~('\\'|']') )* ']'('=')*']'
	;

fragment
EscapeSequence
    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
    |   UnicodeEscape
    |   OctalEscape
    ;
    
fragment
OctalEscape
    :   '\\' ('0'..'3') ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7') ('0'..'7')
    |   '\\' ('0'..'7')
    ;
    
fragment
UnicodeEscape
    :   '\\' 'u' HexDigit HexDigit HexDigit HexDigit
    ;
    
fragment
HexDigit : ('0'..'9'|'a'..'f'|'A'..'F') ;


COMMENT
    :   '--[[' ( options {greedy=false;} : . )* ']]' {Skip();}
    ;
    
LINE_COMMENT
    : '--' ~('\n'|'\r')* '\r'? '\n' {Skip();}
    ;
    
    
WS  :  (' '|'\t'|'\u000C') {Skip();}
    ;
    
NEWLINE	: ('\r')? '\n' {Skip();}
	;
