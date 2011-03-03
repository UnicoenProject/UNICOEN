grammar Lua;

options {
	output=AST;
	backtrack=true;
}

tokens {
	NOTHING;	//
	UN_EXP;	// UnaryExpression
	BIN_EXP;	// BinaryExpression
	ASSIGN_OP;	// BinaryOperator
	BLOCK;		// Block
	WHILE;		// While
	DO_WHILE;	// While
	FOR_RANGE;	// ForRange
	FOR_EACH;	// ForEach
	FUNC_DEC;	// FunctionDeclaration
	VAR_DEC;	// VariableDeclaration
	IF;		// IfExpression
	EXP_LIST;	// ExpressionCollection
	RETURN;	// ReturnExpression
	BREAK;		// NreakExpression
	VARIABLE;	// Variable
	TRUE;
	NIL;
	FALSE;
	INTEGER;
	STRING;
	ARRAY;
	CALL;
	PROPERTY;
	ARG_LIST;
	ARG;
	PARAM_LIST;
	PARAM;
	// operators
	ADD;
	SUB;
	MUL;
	DIV;
}

chunk
	: block
		-> block
	;

block
 	: (stat ';'?)* (laststat ';'?)?
 		-> ^(BLOCK stat* laststat?)
 	;

stat	
	: varlist '=' explist
		-> ^(BIN_EXP varlist ASSIGN_OP explist)
	| functioncall
		-> functioncall
	| 'do' block 'end'
		-> block
	| 'while' exp 'do' block 'end'
		-> ^(WHILE exp block)
	| 'repeat' block 'until' exp
		-> ^(DO_WHILE exp block)
	| if_stat
		-> if_stat
	| 'for' NAME '=' start=exp ',' end=exp (',' step=exp)? 'do' block 'end'
		-> ^(FOR_RANGE NAME $start $end $step block)
	| 'for' namelist 'in' explist 'do' block 'end'
		-> ^(FOR_EACH namelist explist block)
	| 'function' funcname '(' parlist ')' block 'end'
		-> ^(FUNC_DEC funcname parlist block)
	| 'local' 'function' NAME '(' parlist ')' block 'end'
		-> ^(FUNC_DEC NAME parlist block)
	| 'local' namelist
		-> ^(VAR_DEC namelist)
	| 'local' namelist '=' explist
		-> ^(VAR_DEC namelist explist)
	;

if_stat
	: 'if' exp 'then' block else_body 'end'
		-> ^(IF exp block else_body)
	;
	
else_body 
	: 'elseif' exp 'then' block else_body
		-> ^(IF exp block else_body)
	| 'else'! block
	| -> NOTHING
	;

laststat
	: 'return' explist?
		-> ^(RETURN explist?)
	| 'break'
		-> ^(BREAK)
	;

funcname
	: NAME ('.' NAME)* (':' NAME)?
	;

var
	: NAME
		-> ^(VARIABLE NAME)
	| prefixexp
		('[' exp ']'
			-> ^(ARRAY prefixexp exp)
		| '.' NAME
			-> ^(PROPERTY prefixexp NAME)
		)
	;

varlist
	: var
		-> var
	| var (',' var)+
		-> ^(EXP_LIST var+)
	;

namelist
	: NAME
		-> ^(VARIABLE NAME)
	| NAME (',' NAME)+
		-> ^(EXP_LIST ^(VARIABLE NAME)+)
	;

explist
	: exp
		-> exp
	| exp (',' exp)*
		-> ^(EXP_LIST exp*)
	;

exp2
	:
	('nil'
		-> NIL
	| 'false'
		-> FALSE
	| 'true'
		-> TRUE
	| number
		-> number
	| string
		-> string
	| '...'
		-> ^(VARIABLE '...')
	| 'function' '(' parlist? ')' block 'end'
		-> ^(FUNC_DEC parlist block)
	| prefixexp
		-> prefixexp
	| tableconstructor
		-> tableconstructor
	| ('-' | 'not' | '#') exp
	)
	;
	
exp	:
	(e1=exp2 -> $e1)
	(binop (e2=exp2)
		-> ^(BIN_EXP $exp binop $e2)
	)*
	;

nameOrExp
	: NAME
		-> ^(VARIABLE NAME)
	| '(' exp ')'
		-> exp
	;

functioncall
	:
	(nameOrExp -> nameOrExp) 
	(
		('[' e2=exp ']'
			-> ^(ARRAY $functioncall $e2)
		| '.' NAME 
			-> ^(PROPERTY $functioncall NAME)
		)*
		args
			-> ^(CALL $functioncall args)
		| ':' NAME args
			-> ^(CALL ^(PROPERTY $functioncall NAME) args)
	)+
	;

prefixexp
	:
	(nameOrExp -> nameOrExp) 
	(
		('[' e2=exp ']'
			-> ^(ARRAY $functioncall $e2)
		| '.' NAME 
			-> ^(PROPERTY $functioncall NAME)
		)*
		args
			-> ^(CALL $functioncall args)
		| ':' NAME args
			-> ^(CALL ^(PROPERTY $functioncall NAME) args)
	)*
	;

args
	: '(' explist? ')'
		-> ^(ARG_LIST explist)
	| tableconstructor
		-> ^(ARG_LIST ^(ARG tableconstructor))
	| string 
		-> ^(ARG_LIST ^(ARG string))
	;

parlist
	: n1=NAME (',' n2=NAME)* (',' n3='...')?
		-> ^(PARAM_LIST ^(PARAM $n1) ^(PARAM $n2)* ^(PARAM $n3)?)
	| n='...'
		-> ^(PARAM_LIST ^(PARAM $n))
	|
		-> ^(PARAM_LIST)
	;

tableconstructor
	: '{' fieldlist? '}'
	;

fieldlist
	: field (fieldsep field)* fieldsep?
	;

field
	: '[' exp ']' '=' exp
	| NAME '=' exp
	| exp
	;

fieldsep
	: ','
	| ';'
	;

binop
	: '+' -> ADD
	| '-' -> SUB
	| '*' -> MUL
	| '/' -> DIV
	| '^' | '%' | '..'
	| '<' | '<=' | '>' | '>=' | '==' | '~=' 
	| 'and' | 'or'
	;

unop
	: '-' | 'not' | '#'
	;
	
number : INT
		-> ^(INTEGER INT)
	| FLOAT
	| EXP
	| HEX

;

string	: NORMALSTRING | CHARSTRING | LONGSTRING;	

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
    :   '--[[' ( options {greedy=false;} : . )* ']]' {skip();}
    ;
    
LINE_COMMENT
    : '--' ~('\n'|'\r')* '\r'? '\n' {skip();}
    ;
    
    
WS  :  (' '|'\t'|'\u000C') {skip();}
    ;
    
NEWLINE	: ('\r')? '\n' {skip();}
	;