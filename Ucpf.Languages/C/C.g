/** ANSI C ANTLR v3 grammar

Changed by Kazunori Sakamoto in order to output AST as XML format on C# December 2009.

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
grammar C;
options {
    language=CSharp2;
    backtrack=true;
    memoize=true;
    output=AST;
    k=2;
}

scope Symbols {
	IDictionary types;
}

@header {
using System.Collections.Generic;
using System.Xml.Linq;
}

@members {
private readonly IList<XElement> Elements = new List<XElement>();
public IList<XElement> ElementList { get { return Elements; } }
public string LeaveElementName { get; set; }

bool isTypeName(string name)
{
	for (int i = Symbols_stack.Count-1; i>=0; i--)
	{
		Symbols_scope scope = (Symbols_scope)Symbols_stack[i];
		if ( scope.types.Contains(name) )
		{
			return true;
		}
	}
	return false;
}
}

translation_unit
scope Symbols; // entire file is a scope
@init {
	$Symbols::types = new Hashtable();
	const string elementName = "translation_unit"; var elementsIndex = Elements.Count; Elements.Add(null);
}
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: external_declaration+
	;

/** Either a function definition or any other kind of C decl/def.
 *  The LL(*) analysis algorithm fails to deal with this due to
 *  recursion in the declarator rules.  I'm putting in a
 *  manual predicate here so that we don't backtrack over
 *  the entire function.  Further, you get a better error
 *  as errors within the function itself don't make it fail
 *  to predict that it's a function.  Weird errors previously.
 *  Remember: the goal is to avoid backtrack like the plague
 *  because it makes debugging, actions, and errors harder.
 *
 *  Note that k=1 results in a much smaller predictor for the 
 *  fixed lookahead; k=2 made a few extra thousand lines. ;)
 *  I'll have to optimize that in the future.
 */
external_declaration
options {k=1;}
@init { const string elementName = "external_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: ( declaration_specifiers? declarator declaration* '{' )=> function_definition
	| declaration
	;

function_definition
scope Symbols; // put parameters and locals into same scope for now
@init {
  $Symbols::types = new Hashtable();
  const string elementName = "function_definition"; var elementsIndex = Elements.Count; Elements.Add(null);
}
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:	declaration_specifiers? declarator
		(	declaration+ compound_statement	// K&R style
		|	compound_statement				// ANSI style
		)
	;

declaration
scope {
  bool isTypedef;
}
@init {
  $declaration::isTypedef = false;
  const string elementName = "declaration"; var elementsIndex = Elements.Count; Elements.Add(null);
}
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'typedef' declaration_specifiers? {$declaration::isTypedef=true;}
	  init_declarator_list ';' // special case, looking for typedef	
	| declaration_specifiers init_declarator_list? ';'
	;

declaration_specifiers
@init { const string elementName = "declaration_specifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:   (   storage_class_specifier
		|   type_specifier
        |   type_qualifier
        )+
	;

init_declarator_list
@init { const string elementName = "init_declarator_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: init_declarator (',' init_declarator)*
	;

init_declarator
@init { const string elementName = "init_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: declarator ('=' initializer)?
	;

storage_class_specifier
@init { const string elementName = "storage_class_specifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'extern'
	| 'static'
	| 'auto'
	| 'register'
	;

type_specifier
@init { const string elementName = "type_specifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'void'
	| 'char'
	| 'short'
	| 'int'
	| 'long'
	| 'float'
	| 'double'
	| 'signed'
	| 'unsigned'
	| struct_or_union_specifier
	| enum_specifier
	| type_id
	;

type_id
@init { const string elementName = "type_id"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
    :   {isTypeName(input.LT(1).Text)}? IDENTIFIER
    ;

struct_or_union_specifier
options {k=3;}
scope Symbols; // structs are scopes
@init {
  $Symbols::types = new Hashtable();
  const string elementName = "struct_or_union_specifier"; var elementsIndex = Elements.Count; Elements.Add(null);
}
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: struct_or_union IDENTIFIER? '{' struct_declaration_list '}'
	| struct_or_union IDENTIFIER
	;

struct_or_union
@init { const string elementName = "struct_or_union"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'struct'
	| 'union'
	;

struct_declaration_list
@init { const string elementName = "struct_declaration_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: struct_declaration+
	;

struct_declaration
@init { const string elementName = "struct_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: specifier_qualifier_list struct_declarator_list ';'
	;

specifier_qualifier_list
@init { const string elementName = "specifier_qualifier_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: ( type_qualifier | type_specifier )+
	;

struct_declarator_list
@init { const string elementName = "struct_declarator_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: struct_declarator (',' struct_declarator)*
	;

struct_declarator
@init { const string elementName = "struct_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: declarator (':' constant_expression)?
	| ':' constant_expression
	;

enum_specifier
options {k=3;}
@init { const string elementName = "enum_specifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'enum' '{' enumerator_list '}'
	| 'enum' IDENTIFIER '{' enumerator_list '}'
	| 'enum' IDENTIFIER
	;

enumerator_list
@init { const string elementName = "enumerator_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: enumerator (',' enumerator)*
	;

enumerator
@init { const string elementName = "enumerator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: IDENTIFIER ('=' constant_expression)?
	;

type_qualifier
@init { const string elementName = "type_qualifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'const'
	| 'volatile'
	;

declarator
@init { const string elementName = "declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: pointer? direct_declarator
	| pointer
	;

direct_declarator
@init { const string elementName = "direct_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:   (	IDENTIFIER
			{
			if ($declaration.Count > 0 && $declaration::isTypedef) {
				$Symbols::types[$IDENTIFIER.Text] = $IDENTIFIER.Text;
			}
			}
		|	'(' declarator ')'
		)
        declarator_suffix*
	;

declarator_suffix
@init { const string elementName = "declarator_suffix"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:   '[' constant_expression ']'
    |   '[' ']'
    |   '(' parameter_type_list ')'
    |   '(' identifier_list ')'
    |   '(' ')'
	;

pointer
@init { const string elementName = "pointer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '*' type_qualifier+ pointer?
	| '*' pointer
	| '*'
	;

parameter_type_list
@init { const string elementName = "parameter_type_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: parameter_list (',' '...')?
	;

parameter_list
@init { const string elementName = "parameter_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: parameter_declaration (',' parameter_declaration)*
	;

parameter_declaration
@init { const string elementName = "parameter_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: declaration_specifiers (declarator|abstract_declarator)*
	;

identifier_list
@init { const string elementName = "identifier_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: IDENTIFIER (',' IDENTIFIER)*
	;

type_name
@init { const string elementName = "type_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: specifier_qualifier_list abstract_declarator?
	;

abstract_declarator
@init { const string elementName = "abstract_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: pointer direct_abstract_declarator?
	| direct_abstract_declarator
	;

direct_abstract_declarator
@init { const string elementName = "direct_abstract_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:	( '(' abstract_declarator ')' | abstract_declarator_suffix ) abstract_declarator_suffix*
	;

abstract_declarator_suffix
@init { const string elementName = "abstract_declarator_suffix"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:	'[' ']'
	|	'[' constant_expression ']'
	|	'(' ')'
	|	'(' parameter_type_list ')'
	;
	
initializer
@init { const string elementName = "initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: assignment_expression
	| '{' initializer_list ','? '}'
	;

initializer_list
@init { const string elementName = "initializer_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: initializer (',' initializer)*
	;

// E x p r e s s i o n s

argument_expression_list
@init { const string elementName = "argument_expression_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:   assignment_expression (',' assignment_expression)*
	;

additive_expression
@init { const string elementName = "additive_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: (multiplicative_expression) ('+' multiplicative_expression | '-' multiplicative_expression)*
	;

multiplicative_expression
@init { const string elementName = "multiplicative_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: (cast_expression) ('*' cast_expression | '/' cast_expression | '%' cast_expression)*
	;

cast_expression
@init { const string elementName = "cast_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '(' type_name ')' cast_expression
	| unary_expression
	;

unary_expression
@init { const string elementName = "unary_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: postfix_expression
	| '++' unary_expression
	| '--' unary_expression
	| unary_operator cast_expression
	| 'sizeof' unary_expression
	| 'sizeof' '(' type_name ')'
	;

postfix_expression
@init { const string elementName = "postfix_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:   primary_expression
        (   '[' expression ']'
        |   '(' ')'
        |   '(' argument_expression_list ')'
        |   '.' IDENTIFIER
        |   '->' IDENTIFIER
        |   '++'
        |   '--'
        )*
	;

unary_operator
@init { const string elementName = "unary_operator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '&'
	| '*'
	| '+'
	| '-'
	| '~'
	| '!'
	;

primary_expression
@init { const string elementName = "primary_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: IDENTIFIER
	| constant
	| '(' expression ')'
	;

constant
@init { const string elementName = "constant"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
    :   HEX_LITERAL
    |   OCTAL_LITERAL
    |   DECIMAL_LITERAL
    |	CHARACTER_LITERAL
	|	STRING_LITERAL
    |   FLOATING_POINT_LITERAL
    ;

/////

expression
@init { const string elementName = "expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: assignment_expression (',' assignment_expression)*
	;

constant_expression
@init { const string elementName = "constant_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: conditional_expression
	;

assignment_expression
@init { const string elementName = "assignment_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: lvalue assignment_operator assignment_expression
	| conditional_expression
	;
	
lvalue
@init { const string elementName = "lvalue"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	:	unary_expression
	;

assignment_operator
@init { const string elementName = "assignment_operator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '='
	| '*='
	| '/='
	| '%='
	| '+='
	| '-='
	| '<<='
	| '>>='
	| '&='
	| '^='
	| '|='
	;

conditional_expression
@init { const string elementName = "conditional_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: logical_or_expression ('?' expression ':' conditional_expression)?
	;

logical_or_expression
@init { const string elementName = "logical_or_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: logical_and_expression ('||' logical_and_expression)*
	;

logical_and_expression
@init { const string elementName = "logical_and_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: inclusive_or_expression ('&&' inclusive_or_expression)*
	;

inclusive_or_expression
@init { const string elementName = "inclusive_or_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: exclusive_or_expression ('|' exclusive_or_expression)*
	;

exclusive_or_expression
@init { const string elementName = "exclusive_or_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: and_expression ('^' and_expression)*
	;

and_expression
@init { const string elementName = "and_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: equality_expression ('&' equality_expression)*
	;
equality_expression
@init { const string elementName = "equality_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: relational_expression (('=='|'!=') relational_expression)*
	;

relational_expression
@init { const string elementName = "relational_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: shift_expression (('<'|'>'|'<='|'>=') shift_expression)*
	;

shift_expression
@init { const string elementName = "shift_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: additive_expression (('<<'|'>>') additive_expression)*
	;

// S t a t e m e n t s

statement
@init { const string elementName = "statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: labeled_statement
	| compound_statement
	| expression_statement
	| selection_statement
	| iteration_statement
	| jump_statement
	;

labeled_statement
@init { const string elementName = "labeled_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: IDENTIFIER ':' statement
	| 'case' constant_expression ':' statement
	| 'default' ':' statement
	;

compound_statement
scope Symbols; // blocks have a scope of symbols
@init {
  $Symbols::types = new Hashtable();
  const string elementName = "compound_statement"; var elementsIndex = Elements.Count; Elements.Add(null);
}
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: '{' declaration* statement_list? '}'
	;

statement_list
@init { const string elementName = "statement_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: statement+
	;

expression_statement
@init { const string elementName = "expression_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: ';'
	| expression ';'
	;

selection_statement
@init { const string elementName = "selection_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'if' '(' expression ')' statement (options {k=1; backtrack=false;}:'else' statement)?
	| 'switch' '(' expression ')' statement
	;

iteration_statement
@init { const string elementName = "iteration_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'while' '(' expression ')' statement
	| 'do' statement 'while' '(' expression ')' ';'
	| 'for' '(' expression_statement expression_statement expression? ')' statement
	;

jump_statement
@init { const string elementName = "jump_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
	: 'goto' IDENTIFIER ';'
	| 'continue' ';'
	| 'break' ';'
	| 'return' ';'
	| 'return' expression ';'
	;

IDENTIFIER
	:	LETTER (LETTER|'0'..'9')*
	;
	
fragment
LETTER
	:	'$'
	|	'A'..'Z'
	|	'a'..'z'
	|	'_'
	;

CHARACTER_LITERAL
    :   '\'' ( EscapeSequence | ~('\''|'\\') ) '\''
    ;

STRING_LITERAL
    :  '"' ( EscapeSequence | ~('\\'|'"') )* '"'
    ;

HEX_LITERAL : '0' ('x'|'X') HexDigit+ IntegerTypeSuffix? ;

DECIMAL_LITERAL : ('0' | '1'..'9' '0'..'9'*) IntegerTypeSuffix? ;

OCTAL_LITERAL : '0' ('0'..'7')+ IntegerTypeSuffix? ;

fragment
HexDigit : ('0'..'9'|'a'..'f'|'A'..'F') ;

fragment
IntegerTypeSuffix
	:	('u'|'U')? ('l'|'L')
	|	('u'|'U')  ('l'|'L')?
	;

FLOATING_POINT_LITERAL
    :   ('0'..'9')+ '.' ('0'..'9')* Exponent? FloatTypeSuffix?
    |   '.' ('0'..'9')+ Exponent? FloatTypeSuffix?
    |   ('0'..'9')+ Exponent FloatTypeSuffix?
    |   ('0'..'9')+ Exponent? FloatTypeSuffix
	;

fragment
Exponent : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;

fragment
FloatTypeSuffix : ('f'|'F'|'d'|'D') ;

fragment
EscapeSequence
    :   '\\' ('b'|'t'|'n'|'f'|'r'|'\"'|'\''|'\\')
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

WS  :  (' '|'\r'|'\t'|'\u000C'|'\n') {$channel=HIDDEN;}
    ;

COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

LINE_COMMENT
    : '//' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    ;

// ignore #line info for now
LINE_COMMAND 
    : '#' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    ;
