grammar Aries;

options{
	output = AST;
	language=CSharp3;
}

tokens{
	ASPECT;
	ASPECT_BODY;
	ELEMENTS;
	ELEMENT;
	LANGUAGE_DEPEND_BLOCK;
	LANGUAGE_DECLARATION;
	INTERTYPE_DECLARATION;
	POINTCUT_DECLARATION;
	ADVICE_DECLARATION;
	TARGET_CLASS;
	POINTCUT_NAME;
	PARAMETERS;
	PARAMETER;
	PARAMETER_TYPE;
	POINTCUT_DECLARATOR;
	POINTCUT_TYPE;
	TYPE;
	IDENTIFIER_WITH_CLASS_NAME;
	ADVICE_TYPE;
	ADVICE_TARGET;
	ADVICE_BODY;
	CONTENTS;
}

aspect
	: 'aspect' IDENTIFIER aspectBody
		-> ^(ASPECT IDENTIFIER aspectBody)
	;

aspectBody
	: '{' elements '}'
		-> ^(ASPECT_BODY elements)
	;

elements
	: element*
		-> ^(ELEMENTS element*)
	;

element
	: intertypeDeclaration
		-> ^(ELEMENT intertypeDeclaration)
	| pointcutDeclaration
		-> ^(ELEMENT pointcutDeclaration)
	| adviceDeclaration
		-> ^(ELEMENT adviceDeclaration)
	;

languageDependBlock
	: languageDeclaration '{' contents '}end'
		-> ^(LANGUAGE_DEPEND_BLOCK languageDeclaration contents)
	;

languageDeclaration
	: '@' languageType
		-> ^(LANGUAGE_DECLARATION languageType)
	;

languageType
	: 'Java' | 'JavaScript' | 'CSharp' | 'Ruby' | 'Python' | 'C'
	;

intertypeDeclaration
	: targetClass ':' languageDependBlock
		-> ^(INTERTYPE_DECLARATION targetClass languageDependBlock)
	;

targetClass
	: IDENTIFIER
		-> ^(TARGET_CLASS IDENTIFIER)
	;

pointcutDeclaration
	: 'pointcut' pointcutName parameters ':' pointcutDeclarator ';'
		-> ^(POINTCUT_DECLARATION pointcutName parameters pointcutDeclarator)
	;

pointcutName
	: IDENTIFIER
		-> ^(POINTCUT_NAME IDENTIFIER)
	;

parameters
	: '(' parameter* ')'
		-> ^(PARAMETERS parameter*)
	;

parameter
	: parameterType IDENTIFIER
		-> ^(PARAMETER parameterType IDENTIFIER)
	;

parameterType
	: IDENTIFIER
		-> ^(PARAMETER_TYPE IDENTIFIER)
	;

pointcutDeclarator
	: pointcutType '(' type identifierWithClassName arguments ')'
		-> ^(POINTCUT_DECLARATOR pointcutType type identifierWithClassName arguments)
	;

pointcutType
	: POINTCUT_TYPE_ELEMENT
		-> ^(POINTCUT_TYPE POINTCUT_TYPE_ELEMENT)
	;

POINTCUT_TYPE_ELEMENT
	: 'execution' | 'call'
	;

type
	: IDENTIFIER
		-> ^(TYPE IDENTIFIER)
	;

identifierWithClassName
	: IDENTIFIER ('.' IDENTIFIER)+
		-> ^(IDENTIFIER_WITH_CLASS_NAME IDENTIFIER+)
	;

arguments
	: '(' ')'
	;

adviceDeclaration
	: adviceType ':' adviceTarget parameters adviceBody 
		-> ^(ADVICE_DECLARATION adviceType adviceTarget parameters adviceBody)
	;

adviceType
	: ADVICE_TYPE_ELEMENT
		-> ^(ADVICE_TYPE ADVICE_TYPE_ELEMENT)
	;

ADVICE_TYPE_ELEMENT
	: 'before' | 'after'
	;

adviceTarget
	: IDENTIFIER
		-> ^(ADVICE_TARGET IDENTIFIER)
	;

adviceBody
	: '{' languageDependBlock+ '}'
		-> ^(ADVICE_BODY languageDependBlock+)
	;

contents
	: content
		-> ^(CONTENTS content)
	;

content
	: (IDENTIFIER | INTLITERAL | STRING | WS | ~('}end' | IDENTIFIER | INTLITERAL | WS))*
	;
	
//TODO survey
variableInitializer
	: '=' INTLITERAL
	;

IDENTIFIER
	: ('a'..'z'|'A'..'Z'|'_')+ | '*' 
	;

STRING
    :  '"' ( EscapeSequence | ~('\\'|'"') )* '"' 
    ;

INTLITERAL
	: ('1'..'9') ('0'..'9')*
	;

fragment
EscapeSequence
    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
    ;

WS
	: (' '|'\t'|'\r'|'\n')+ 
		{ Skip(); }
	;