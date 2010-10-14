// cs.g
//
// CSharp 4.0 Parser
//
// Changed by Kazunori Sakamoto in order to output AST as XML format on C# December 2009.
//
// Andrew Bradnan
// andrew@whirlygigventures.com
// 2009 - initial version
  
grammar cs;


options {
    backtrack=true;
    memoize=true;
    output=AST;
    language=CSharp2;
}

tokens
{
	ASSIGNMENT;
	BLOCK;
	CAST_EXPRESSION;
	CLASS_DECL;
	DELEGATE_DECL;
	ELSE;
	ENUM_DECL;
	EXPRESSION;
	FIELD_DECL;
	IF;
	INTERFACE_DECL;
	INVOCATION_EXPRESSION;
	LOCAL_VARIABLE_DECLARATOR;
    MEMBER_ACCESS;
	METHOD_DECL;
	NAMESPACE_DECL;
	NAMESPACE_OR_TYPE_NAME;
	PREDEFINED_TYPE;
	PROPERTY_DECLARATION;
	QID_PART;
	RETURN_TYPE;
	UNARY_EXPRESSION;
	USING_DIRECTIVE;

	TELEMENT;
	TMEMBER;
	TINVOCATION;
}

@lexer::header {
	using System.Collections.Generic;
	using System.Diagnostics;
	using Debug = System.Diagnostics.Debug;
}

@lexer::members {
	// Preprocessor Data Structures - see lexer section below and PreProcessor.cs
	protected Dictionary<string,string> MacroDefines = new Dictionary<string,string>();	
	protected Stack<bool> Processing = new Stack<bool>();

	// Uggh, lexer rules don't return values, so use a stack to return values.
	protected Stack<bool> Returns = new Stack<bool>();
}

@header
{
	using System.Collections.Generic;
	using System.Text;
	using System.Xml.Linq;
}

@members
{
	private readonly IList<XElement> Elements = new List<XElement>();
	public IList<XElement> ElementList { get { return Elements; } }
	public string LeaveElementName { get; set; }
}

/********************************************************************************************
                          Parser section
*********************************************************************************************/

///////////////////////////////////////////////////////
compilation_unit
@init { const string elementName = "compilation_unit"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
//	extern_alias_directives?   
	using_directives?  	
	global_attributes?   
	namespace_declaration? 
	namespace_body
	;
namespace_declaration
@init { const string elementName = "namespace_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'namespace'   qualified_identifier   namespace_block   ';'? 
	;
qualified_identifier
@init { const string elementName = "qualified_identifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier ('.' identifier)* ;

qid
@init { const string elementName = "qid"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: // qualified_identifier v2
	qid_start qid_part* ;
qid_start
@init { const string elementName = "qid_start"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier ('::' identifier)? generic_argument_list?
	| 'this'
	| 'base'
	| predefined_type
	| literal ;		// 0.ToString() is legal
qid_part
@init { const string elementName = "qid_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	access_operator   identifier   generic_argument_list?
	;

namespace_block
@init { const string elementName = "namespace_block"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   namespace_body   '}' ;
namespace_body
@init { const string elementName = "namespace_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	extern_alias_directives?   using_directives?   namespace_member_declarations? ;
extern_alias_directives
@init { const string elementName = "extern_alias_directives"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	extern_alias_directive+ ;
extern_alias_directive
@init { const string elementName = "extern_alias_directive"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'extern'   'alias'   identifier  ';' ;
using_directives
@init { const string elementName = "using_directives"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	using_directive+ ;
using_directive
@init { const string elementName = "using_directive"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(using_alias_directive
	| using_namespace_directive)
	;
using_alias_directive
@init { const string elementName = "using_alias_directive"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'using'	  identifier   '='   namespace_or_type_name   ';' ;
using_namespace_directive
@init { const string elementName = "using_namespace_directive"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'using'   namespace_name   ';' ;
namespace_member_declarations
@init { const string elementName = "namespace_member_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	namespace_member_declaration+ ;
namespace_member_declaration
@init { const string elementName = "namespace_member_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	namespace_declaration
	| type_declaration ;
type_declaration
@init { const string elementName = "type_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	class_declaration
	| struct_declaration
	| interface_declaration
	| enum_declaration
	| delegate_declaration ;
qualified_alias_member
@init { const string elementName = "qualified_alias_member"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   '::'   identifier   generic_argument_list? ;

// B.2.1 Basic Concepts
namespace_name
@init { const string elementName = "namespace_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	namespace_or_type_name ;
type_name
@init { const string elementName = "type_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	namespace_or_type_name ;
namespace_or_type_name
@init { const string elementName = "namespace_or_type_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	id1 = identifier   ga1 = generic_argument_list?  ('::' id2 = identifier   ga2 = generic_argument_list?)? ('.'   id3 = identifier   ga3 = generic_argument_list?)*   
//	| qualified_alias_member (the :: part)
    ;
           
// B.2.13 Attributes
global_attributes
@init { const string elementName = "global_attributes"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	global_attribute+ ;
global_attribute
@init { const string elementName = "global_attribute"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'['   global_attribute_target_specifier   attribute_list   ','?   ']' ;
global_attribute_target_specifier
@init { const string elementName = "global_attribute_target_specifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	global_attribute_target   ':' ;
global_attribute_target
@init { const string elementName = "global_attribute_target"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'assembly' | 'module' ;
attributes
@init { const string elementName = "attributes"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attribute_sections ;
attribute_sections
@init { const string elementName = "attribute_sections"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attribute_section+ ;
attribute_section
@init { const string elementName = "attribute_section"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'['   attribute_target_specifier?   attribute_list   ','?   ']' ;
attribute_target_specifier
@init { const string elementName = "attribute_target_specifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attribute_target   ':' ;
attribute_target
@init { const string elementName = "attribute_target"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'field' | 'event' | 'method' | 'param' | 'property' | 'return' | 'type' ;
attribute_list
@init { const string elementName = "attribute_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	a += attribute (',' a += attribute)* 
	; 
attribute
@init { const string elementName = "attribute"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type_name   attribute_arguments? ;
attribute_arguments
@init { const string elementName = "attribute_arguments"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'('   positional_argument_list?  ')' 
	| '('   positional_argument_list   ','   named_argument_list   ')' 
	| '('   named_argument_list   ')' ;
positional_argument_list
@init { const string elementName = "positional_argument_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	pa += positional_argument (',' pa += positional_argument)* 
	;
positional_argument
@init { const string elementName = "positional_argument"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attribute_argument_expression ;
named_argument_list
@init { const string elementName = "named_argument_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	na += named_argument (',' na += named_argument)* 
	;
named_argument
@init { const string elementName = "named_argument"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   '='   attribute_argument_expression ;
attribute_argument_expression
@init { const string elementName = "attribute_argument_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression ;

// B.2.2 Types

/* I'm going to ignore the mostly semantic bnf in the C Sharp spec and just do syntax */
type
@init { const string elementName = "type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(type_name   |   predefined_type)   rank_specifiers   '*'*
	| type_name '*'+
	| type_name '?'
	| type_name
	| predefined_type '*'+
	| predefined_type '?'
	| predefined_type
	| 'void'   '*'+ ;
non_nullable_type
@init { const string elementName = "non_nullable_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(type_name   |   predefined_type)   rank_specifiers   '*'*
	| type_name '*'+
	| type_name
	| predefined_type '*'+
	| predefined_type
	| 'void'   '*'+ ;
type_list
@init { const string elementName = "type_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type (',' type)* ;
class_type
@init { const string elementName = "class_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type;
non_array_type
@init { const string elementName = "non_array_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type;
array_type
@init { const string elementName = "array_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type;
integral_type
@init { const string elementName = "integral_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'sbyte' | 'byte' | 'short' | 'ushort' | 'int' | 'uint' | 'long' | 'ulong' | 'char' ;
unmanaged_type
@init { const string elementName = "unmanaged_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type;
pointer_type
@init { const string elementName = "pointer_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type;
rank_specifiers
@init { const string elementName = "rank_specifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	rank_specifier+ ;        
rank_specifier
@init { const string elementName = "rank_specifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'['   dim_separators?   ']' ;
dim_separators
@init { const string elementName = "dim_separators"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	','+ ;
generic_argument_list
@init { const string elementName = "generic_argument_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'<'   type_arguments   '>' ;
type_arguments
@init { const string elementName = "type_arguments"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	ta += type_argument (',' ta += type_argument)* 
	; 
type_argument
@init { const string elementName = "type_argument"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type ;
type_variable_name
@init { const string elementName = "type_variable_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier ;


// B.2.3 Expressions
expression
@init { const string elementName = "expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	non_assignment_expression
	| assignment ;
unary_expression
@init { const string elementName = "unary_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	cast_expression 			// primary_expression... has parenthesized_expression
	| '+'   unary_expression 
	| '-'   unary_expression 
	| '!'   unary_expression 
	| '~'   unary_expression 
	| '*'   unary_expression
	| pre_increment_expression 
	| pre_decrement_expression 
	| primary_or_array_creation_expression   '++'?   '--'?
	| pointer_indirection_expression
	| addressof_expression ;
pre_increment_expression
@init { const string elementName = "pre_increment_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'++'   unary_expression ;
pre_decrement_expression
@init { const string elementName = "pre_decrement_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'--'   unary_expression ;
pointer_indirection_expression
@init { const string elementName = "pointer_indirection_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'*'   unary_expression ;
addressof_expression
@init { const string elementName = "addressof_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'&'   unary_expression ;
non_assignment_expression
@init { const string elementName = "non_assignment_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	conditional_expression
	| lambda_expression
	| query_expression;
assignment
@init { const string elementName = "assignment"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	unary_expression   assignment_operator   expression
	;
variable_reference
@init { const string elementName = "variable_reference"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression  ;

argument_list
@init { const string elementName = "argument_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	a += argument (',' a += argument)* ;
// 4.0
argument
@init { const string elementName = "argument"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	argument_name   argument_value
	| argument_value;
argument_name
@init { const string elementName = "argument_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   ':';
argument_value
@init { const string elementName = "argument_value"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression 
	| ref_variable_reference 
	| 'out'   variable_reference ;
ref_variable_reference
@init { const string elementName = "ref_variable_reference"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'ref' '('  
		((  namespace_or_type_name   |   predefined_type )   '*'*   rank_specifiers?
		| 'void'   '*'+   rank_specifiers?
		)   ')'   ref_variable_reference
	| 'ref' variable_reference;

primary_or_array_creation_expression
@init { const string elementName = "primary_or_array_creation_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	primary_expression 
	| array_creation_expression ;

texpr
@init { const string elementName = "texpr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	tmember ;

//tinvocation:
//	te1=telement   arguments?   (access_operator   te2=telement   arguments?)*;

tinvocation
@init { const string elementName = "tinvocation"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	tmember   tinvocation_part? ;
tinvocation_part
@init { const string elementName = "tinvocation_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	arguments+   (access_operator!   tinvocation)
	| arguments+   telement_part
	| arguments+ ;
	    
telement
@init { const string elementName = "telement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	tmember   telement_part? ;
telement_part
@init { const string elementName = "telement_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	bracket_expression+   (access_operator   telement)
	| bracket_expression+   tinvocation_part
	| bracket_expression+   ;
	
tmember
@init { const string elementName = "tmember"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   (access_operator   identifier)*   ;
	
primary_expression
@init { const string elementName = "primary_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	primary_expression_start   primary_expression_part*
	| delegate_creation_expression 			// new FooDelegate (int X, string Y)
	| anonymous_object_creation_expression	// new {int X, string Y} 
	| sizeof_expression						// sizeof (struct)
	| checked_expression            		// checked (...
	| unchecked_expression          		// unchecked {...}
	| default_value_expression      		// default
	| anonymous_method_expression			// delegate (int foo) {}
	;
primary_expression_start
@init { const string elementName = "primary_expression_start"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(predefined_type | identifier | literal)   generic_argument_list?
	| 'this'    bracket_expression?
	| 'base'    bracket_expression?
	| identifier   '::'   identifier
	| paren_expression   brackets_or_arguments?
	| object_creation_expression	// new Foo().Member
	| typeof_expression             // typeof(Foo).Name
	;
primary_expression_part
@init { const string elementName = "primary_expression_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	  access_identifier   brackets_or_arguments?
	| brackets_or_arguments ;

element_part
@init { const string elementName = "element_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	access_identifier   bracket_expression+   primary_expression_part? 
	| bracket_expression ;
invocation_part
@init { const string elementName = "invocation_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	access_identifier   arguments   primary_expression_start? 
	| arguments;
	
member_part
@init { const string elementName = "member_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	access_identifier ;
access_identifier
@init { const string elementName = "access_identifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	access_operator   identifier   generic_argument_list? ;
paren_expression
@init { const string elementName = "paren_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'('   expression   ')' ;
brackets_or_arguments
@init { const string elementName = "brackets_or_arguments"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	bracket_expression+   arguments?
	| arguments   bracket_expression* ;
access_operator
@init { const string elementName = "access_operator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'.'  |  '->' ;
arguments
@init { const string elementName = "arguments"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'('   argument_list?   ')' ;
bracket_expression
@init { const string elementName = "bracket_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'['   expression_list?   ']' ;

member_access
@init { const string elementName = "member_access"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   ('.'   primary_or_array_creation_expression)? //  generic_argument_list?
	;
predefined_type
@init { const string elementName = "predefined_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	  'bool'   
	| 'byte'   
	| 'char'   
	| 'decimal' 
	| 'double' 
	| 'float'  
	| 'int'    
	| 'long'   
	| 'object' 
	| 'sbyte'  
	| 'short'  
	| 'string' 
	| 'uint'   
	| 'ulong'  
	| 'ushort' ;

invocation_expression
@init { const string elementName = "invocation_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	access arguments ;
access
@init { const string elementName = "access"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'(' expression ')' (  access		// cast expression
						| access_part)  // paren expression
	| qid_start   access_part? ;
// the recursive part
access_part
@init { const string elementName = "access_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	qid_part access_part?				// member access -- '.'   identifier
	| bracket_expression access_part?				// element access;  use rank_specifiers?	
	| arguments access_part ;           // invocation followed by more invocation
expression_list
@init { const string elementName = "expression_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	e += expression  (',' e += expression)*
	; 
object_creation_expression
@init { const string elementName = "object_creation_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new'   type   
		( '('   argument_list?   ')'   object_or_collection_initializer?  
		  | object_or_collection_initializer )
	;
object_or_collection_initializer
@init { const string elementName = "object_or_collection_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	object_initializer 
	| collection_initializer ;

// object-initializer
//	Rectangle r = new Rectangle {
//		P1 = new Point { X = 0, Y = 1 },
//		P2 = new Point { X = 2, Y = 3 }
//	};
object_initializer
@init { const string elementName = "object_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   member_initializer_list?   '}' 
	| '{'   member_initializer_list   ','   '}' ;
member_initializer_list
@init { const string elementName = "member_initializer_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	mi += member_initializer  (',' mi += member_initializer) 
	; 
member_initializer
@init { const string elementName = "member_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   '='   initializer_value ;
initializer_value
@init { const string elementName = "initializer_value"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression 
	| object_or_collection_initializer ;
collection_initializer
@init { const string elementName = "collection_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   element_initializer_list   ','?   '}' ;
element_initializer_list
@init { const string elementName = "element_initializer_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	ei += element_initializer  (',' ei += element_initializer)*
	; 
element_initializer
@init { const string elementName = "element_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	non_assignment_expression 
	| '{'   expression_list   '}' ;
array_creation_expression
@init { const string elementName = "array_creation_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new'   (non_array_type '['   expression_list   ']'   rank_specifiers?   array_initializer?   (access_operator   primary_expression)*
 	| array_type   array_initializer
	| rank_specifier   array_initializer) ;
delegate_creation_expression
@init { const string elementName = "delegate_creation_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new'   type_name   '('   expression   ')' ;
anonymous_object_creation_expression
@init { const string elementName = "anonymous_object_creation_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new'   anonymous_object_initializer ;
anonymous_object_initializer
@init { const string elementName = "anonymous_object_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   member_declarator_list?   '}' 
	| '{'   member_declarator_list   ','   '}';
member_declarator_list
@init { const string elementName = "member_declarator_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	md += member_declarator  (',' md += member_declarator) 
	; 
member_declarator
@init { const string elementName = "member_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   generic_argument_list?  
	| member_access 
	| identifier   '='   expression ;
sizeof_expression
@init { const string elementName = "sizeof_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'sizeof'   '('   unmanaged_type   ')';
typeof_expression
@init { const string elementName = "typeof_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'typeof'   '('   type   ')' 
	| 'typeof' '('   unbound_type_name   ')' 
	| 'typeof' '(' 'void' ')' ;
// unbound type examples
//foo<bar<X<>>>
//bar::foo<>
//foo1::foo2::foo3<,,>
unbound_type_name
@init { const string elementName = "unbound_type_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: // qualified_identifier v2
	unbound_type_name_start unbound_type_name_part* ;
unbound_type_name_start
@init { const string elementName = "unbound_type_name_start"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier ('::' identifier)? generic_dimension_specifier?;
unbound_type_name_part
@init { const string elementName = "unbound_type_name_part"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'.'   identifier   generic_dimension_specifier? ;
generic_dimension_specifier
@init { const string elementName = "generic_dimension_specifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'<'   commas?   '>' ;
commas
@init { const string elementName = "commas"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	','+ ; 
checked_expression
@init { const string elementName = "checked_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'checked'   '('   expression   ')' ;
unchecked_expression
@init { const string elementName = "unchecked_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'unchecked'   '('   expression   ')' ;
default_value_expression
@init { const string elementName = "default_value_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'default'   '('   type   ')' ;
constant_expression
@init { const string elementName = "constant_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression;
boolean_expression
@init { const string elementName = "boolean_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression;
anonymous_method_expression
@init { const string elementName = "anonymous_method_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'delegate'   explicit_anonymous_function_signature?   block;
explicit_anonymous_function_signature
@init { const string elementName = "explicit_anonymous_function_signature"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'('   explicit_anonymous_function_parameter_list?   ')' ;
explicit_anonymous_function_parameter_list
@init { const string elementName = "explicit_anonymous_function_parameter_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	e += explicit_anonymous_function_parameter   (','   e += explicit_anonymous_function_parameter)*
	;	
explicit_anonymous_function_parameter
@init { const string elementName = "explicit_anonymous_function_parameter"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	anonymous_function_parameter_modifier?   type   identifier;
anonymous_function_parameter_modifier
@init { const string elementName = "anonymous_function_parameter_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'ref' | 'out';
// 4.0
variant_generic_parameter_list
@init { const string elementName = "variant_generic_parameter_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'<'   variant_type_parameters   '>' ;
variant_type_parameters
@init { const string elementName = "variant_type_parameters"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	at += variant_type_variable_name (',' at += variant_type_variable_name)* 
	;
variant_type_variable_name
@init { const string elementName = "variant_type_variable_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   variance_annotation?   type_variable_name ;
variance_annotation
@init { const string elementName = "variance_annotation"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'in' | 'out' ;
	
generic_parameter_list
@init { const string elementName = "generic_parameter_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'<'   type_parameters   '>' ;
type_parameters
@init { const string elementName = "type_parameters"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	at += attributed_type_variable_name (',' at += attributed_type_variable_name)* 
	;
attributed_type_variable_name
@init { const string elementName = "attributed_type_variable_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   type_variable_name ;
cast_expression
@init { const string elementName = "cast_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'('  
		(
		(  namespace_or_type_name |  predefined_type )   '*'+   rank_specifiers?
		| (  namespace_or_type_name |  predefined_type )   '?'   rank_specifiers?
		| (  namespace_or_type_name |  predefined_type )   rank_specifiers?
		| 'void'   '*'*   rank_specifiers?		// for some reason you can cast to (void)
		)
    ')'   bracket_expression* unary_expression 
	;
multiplicative_expression
@init { const string elementName = "multiplicative_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	unary_expression (  ('*'|'/'|'%')   unary_expression)* ;
additive_expression
@init { const string elementName = "additive_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	multiplicative_expression (('+'|'-')   multiplicative_expression)* ;
// >> check needed (no whitespace)
shift_expression
@init { const string elementName = "shift_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	additive_expression (('<<'|'>' '>') additive_expression)* ;
relational_expression
@init { const string elementName = "relational_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	shift_expression 
		(     (('<'|'>'|'<='|'>=')   shift_expression)*
			| (('is'|'as')   non_nullable_type)* 
		) ;
equality_expression
@init { const string elementName = "equality_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	relational_expression
	   (('=='|'!=')   relational_expression)* ;
and_expression
@init { const string elementName = "and_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	equality_expression ('&'   equality_expression)* ;
exclusive_or_expression
@init { const string elementName = "exclusive_or_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	and_expression ('^'   and_expression)* ;
inclusive_or_expression
@init { const string elementName = "inclusive_or_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	exclusive_or_expression   ('|'   exclusive_or_expression)* ;
conditional_and_expression
@init { const string elementName = "conditional_and_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	inclusive_or_expression   ('&&'   inclusive_or_expression)* ;
conditional_or_expression
@init { const string elementName = "conditional_or_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	conditional_and_expression  ('||'   conditional_and_expression)* ;
null_coalescing_expression
@init { const string elementName = "null_coalescing_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	conditional_or_expression   ('??'   null_coalescing_expression)*;
conditional_expression
@init { const string elementName = "conditional_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	null_coalescing_expression   ('?'   expression   ':'   expression)? ;


array_initializer
@init { const string elementName = "array_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   variable_initializer_list?   ','?   '}' ;
variable_initializer_list
@init { const string elementName = "variable_initializer_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	variable_initializer (',' variable_initializer)* ;
// >>= check needed (no whitespace)
assignment_operator
@init { const string elementName = "assignment_operator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'=' | '+=' | '-=' | '*=' | '/=' | '%=' | '&=' | '|=' | '^=' | '<<=' | '>' '>=' ;
lambda_expression
@init { const string elementName = "lambda_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	anonymous_function_signature   '=>'   anonymous_function_body;
anonymous_function_signature
@init { const string elementName = "anonymous_function_signature"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	explicit_anonymous_function_signature 
	| implicit_anonymous_function_signature;
implicit_anonymous_function_signature
@init { const string elementName = "implicit_anonymous_function_signature"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'('   implicit_anonymous_function_parameter_list?   ')'
	| implicit_anonymous_function_parameter_list   (','   implicit_anonymous_function_parameter)?;
implicit_anonymous_function_parameter_list
@init { const string elementName = "implicit_anonymous_function_parameter_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	implicit_anonymous_function_parameter+ ;
implicit_anonymous_function_parameter
@init { const string elementName = "implicit_anonymous_function_parameter"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier;
anonymous_function_body
@init { const string elementName = "anonymous_function_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression
	| block ;

// B.2.12 Delegates
delegate_declaration
@init { const string elementName = "delegate_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   delegate_modifiers?   'delegate'   return_type   identifier  variant_generic_parameter_list?   
		'('   formal_parameter_list?   ')'   type_parameter_constraints_clauses?   ';'
		;
delegate_modifiers
@init { const string elementName = "delegate_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	delegate_modifier (delegate_modifier)* ;
delegate_modifier
@init { const string elementName = "delegate_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'unsafe' ;
query_expression
@init { const string elementName = "query_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	from_clause   query_body ;
from_clause
@init { const string elementName = "from_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'from'   type?   identifier   'in'   expression ;
query_body
@init { const string elementName = "query_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	query_body_clauses?   select_or_group_clause   query_continuation?;
query_continuation
@init { const string elementName = "query_continuation"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'into'   identifier   query_body;
query_body_clauses
@init { const string elementName = "query_body_clauses"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	query_body_clause+ ;
query_body_clause
@init { const string elementName = "query_body_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	from_clause
	| let_clause
	| where_clause
	| join_clause
	| orderby_clause;
join_clause
@init { const string elementName = "join_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'join'   type?   identifier   'in'   expression   'on'   expression   'equals'   expression ('into' identifier)? ;
let_clause
@init { const string elementName = "let_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'let'   identifier   '='   expression;
orderby_clause
@init { const string elementName = "orderby_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'orderby'   ordering_list ;
ordering_list
@init { const string elementName = "ordering_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	ordering+ ;
ordering
@init { const string elementName = "ordering"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression    ordering_direction? ;
ordering_direction
@init { const string elementName = "ordering_direction"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'ascending'
	| 'descending' ;
select_or_group_clause
@init { const string elementName = "select_or_group_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	select_clause
	| group_clause ;
select_clause
@init { const string elementName = "select_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'select'   expression ;
group_clause
@init { const string elementName = "group_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'group'   expression   'by'   expression ;
where_clause
@init { const string elementName = "where_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'where'   boolean_expression ;


// Classes B.2.7
class_declaration
@init { const string elementName = "class_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes? class_modifiers?   'partial'?  'class'  identifier  generic_parameter_list?
		class_base?   type_parameter_constraints_clauses?   class_body   ';'? ;
class_modifiers
@init { const string elementName = "class_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	class_modifier+ ;
class_modifier
@init { const string elementName = "class_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'abstract' | 'sealed' | 'static' | 'unsafe';
class_base
@init { const string elementName = "class_base"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	':'   class_type (',' interface_type_list)?
	| ':'   interface_type_list ;
interface_type_list
@init { const string elementName = "interface_type_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	t += type_name (','   t += type_name)* 
	;
type_parameter_constraints_clauses
@init { const string elementName = "type_parameter_constraints_clauses"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type_parameter_constraints_clause+ ;
type_parameter_constraints_clause
@init { const string elementName = "type_parameter_constraints_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'where'   type_variable_name   ':'   type_parameter_constraint_list ;
type_parameter_constraint_list
@init { const string elementName = "type_parameter_constraint_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(primary_constraint   		','   secondary_constraint_list   ','   constructor_constraint)
	| (primary_constraint   		','   secondary_constraint_list)
	| (primary_constraint   		','   constructor_constraint)
	| (secondary_constraint_list   	','   constructor_constraint)
	| primary_constraint
	| secondary_constraint_list
	| constructor_constraint ;

primary_constraint
@init { const string elementName = "primary_constraint"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	class_type
	| 'class'
	| 'struct' ;
secondary_constraint_list
@init { const string elementName = "secondary_constraint_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	sc += secondary_constraint (',' sc += secondary_constraint)* 
	;
secondary_constraint
@init { const string elementName = "secondary_constraint"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(type_name | type_variable_name) ;
constructor_constraint
@init { const string elementName = "constructor_constraint"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new'   '('   ')' ;
class_body
@init { const string elementName = "class_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   class_member_declarations?   '}' ;
class_member_declarations
@init { const string elementName = "class_member_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	class_member_declaration+ ;
class_member_declaration
@init { const string elementName = "class_member_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	constant_declaration
	| field_declaration
	| method_declaration
	| property_declaration
	| event_declaration
	| indexer_declaration
	| operator_declaration
	| constructor_declaration
	| destructor_declaration
	| static_constructor_declaration
	| type_declaration 
	| class_declaration ;
constant_declaration
@init { const string elementName = "constant_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   constant_modifiers?   'const'   type   constant_declarators   ';' ;
constant_modifiers
@init { const string elementName = "constant_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	constant_modifier+ ;
constant_modifier
@init { const string elementName = "constant_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' ;
field_declaration
@init { const string elementName = "field_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   field_modifiers?   type   variable_declarators   ';'
	;
field_modifiers
@init { const string elementName = "field_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	field_modifier+ ;
field_modifier
@init { const string elementName = "field_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'readonly' | 'volatile' | 'unsafe' ;
variable_declarators
@init { const string elementName = "variable_declarators"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	variable_declarator (',' variable_declarator)* ;
variable_declarator
@init { const string elementName = "variable_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
//	identifier ('='   variable_initializer)? ;
	type_name ('='   variable_initializer)? ;		// eg. event EventHandler IInterface.VariableName;
variable_initializer
@init { const string elementName = "variable_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression	| array_initializer ;
//	| literal ;
method_declarations
@init { const string elementName = "method_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	method_declaration+ ;	
method_declaration
@init { const string elementName = "method_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	method_header   method_body 
	;
method_header
@init { const string elementName = "method_header"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   method_modifiers?   'partial'?   return_type   member_name   generic_parameter_list?
			'('   formal_parameter_list?   ')'   type_parameter_constraints_clauses? ;
method_modifiers
@init { const string elementName = "method_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	method_modifier+ ;
method_modifier
@init { const string elementName = "method_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'virtual' | 'sealed' | 'override'
	| 'abstract' | 'extern' | 'unsafe' ;
return_type
@init { const string elementName = "return_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type
	| 'void' '*'* ;
method_body
@init { const string elementName = "method_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	block ;
formal_parameter_list
@init { const string elementName = "formal_parameter_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	fp += formal_parameter (',' fp += formal_parameter)* 
	;
formal_parameter
@init { const string elementName = "formal_parameter"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	fixed_parameter | parameter_array | '__arglist';	// __arglist is undocumented, see google
fixed_parameters
@init { const string elementName = "fixed_parameters"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	fixed_parameter+ ;
// 4.0
fixed_parameter
@init { const string elementName = "fixed_parameter"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   parameter_modifier?   type   identifier default_argument?;
// 4.0
default_argument
@init { const string elementName = "default_argument"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'=' expression;
parameter_modifier
@init { const string elementName = "parameter_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'ref' | 'out' | 'this' ;
parameter_array
@init { const string elementName = "parameter_array"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'params'?   array_type   identifier ;
property_declaration
@init { const string elementName = "property_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   property_modifiers?   type   member_name   '{'   accessor_declarations   '}'
	;
property_modifiers
@init { const string elementName = "property_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	property_modifier+ ;
property_modifier
@init { const string elementName = "property_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'virtual' | 'sealed' | 'override' | 'abstract' | 'extern' | 'unsafe' ;
member_name
@init { const string elementName = "member_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	qid (generic_parameter_list qid_part)? ;		// IInterface<int>.Method logic added.
accessor_declarations
@init { const string elementName = "accessor_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(get_accessor_declaration   set_accessor_declaration?)
	| (set_accessor_declaration   get_accessor_declaration?) ;
get_accessor_declaration
@init { const string elementName = "get_accessor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   accessor_modifier?   'get'   accessor_body ;
set_accessor_declaration
@init { const string elementName = "set_accessor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   accessor_modifier?   'set'   accessor_body ;
accessor_modifier
@init { const string elementName = "accessor_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	('public' | 'protected' | 'internal' | 'private' | ('protected'   'internal') | ('internal'   'protected'))	;
accessor_body
@init { const string elementName = "accessor_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	block 
	;
event_declaration
@init { const string elementName = "event_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(	attributes?   event_modifiers?   'event'   type   variable_declarators   ';')
	| (	attributes?   event_modifiers?   'event'   type   member_name   '{'   event_accessor_declarations   '}') ;
event_modifiers
@init { const string elementName = "event_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	event_modifier+ ;
event_modifier
@init { const string elementName = "event_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'static' | 'virtual' | 'sealed' | 'override' 
	| 'abstract' | 'extern' | 'unsafe' ;
event_accessor_declarations
@init { const string elementName = "event_accessor_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(add_accessor_declaration   remove_accessor_declaration)
	| (remove_accessor_declaration   add_accessor_declaration) ;
add_accessor_declaration
@init { const string elementName = "add_accessor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'add'   block ;
remove_accessor_declaration
@init { const string elementName = "remove_accessor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'remove'   block ;
indexer_declaration
@init { const string elementName = "indexer_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   indexer_modifiers?   indexer_declarator   '{'   accessor_declarations   '}' ;
indexer_modifiers
@init { const string elementName = "indexer_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	indexer_modifier+ ;
indexer_modifier
@init { const string elementName = "indexer_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'virtual' | 'sealed' | 'override' | 'abstract' | 'extern' | 'unsafe' ;
indexer_declarator
@init { const string elementName = "indexer_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type   (type_name '.')? 'this'   '['   formal_parameter_list   ']' ;
operator_declaration
@init { const string elementName = "operator_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   operator_modifiers   operator_declarator   operator_body ;
operator_modifiers
@init { const string elementName = "operator_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	operator_modifier+ ;
operator_modifier
@init { const string elementName = "operator_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'public' | 'static' | 'extern' | 'unsafe' ;
operator_declarator
@init { const string elementName = "operator_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	unary_operator_declarator
	| binary_operator_declarator
	| conversion_operator_declarator;
unary_operator_declarator
@init { const string elementName = "unary_operator_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type   'operator'   overloadable_unary_operator   '('   type   identifier   ')' ;
overloadable_unary_operator
@init { const string elementName = "overloadable_unary_operator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'+' |  '-' |  '!' |  '~' |  '++' |  '--' |  'true' |  'false' ;
binary_operator_declarator
@init { const string elementName = "binary_operator_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type   'operator'   overloadable_binary_operator   '('   type   identifier   ','   type   identifier   ')' ;
// >> check needed
overloadable_binary_operator
@init { const string elementName = "overloadable_binary_operator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'+' | '-' | '*' | '/' | '%' | '&' | '|' | '^' | '<<' | '>' '>' | '==' | '!=' | '>' | '<' | '>=' | '<=' ; 
conversion_operator_declarator
@init { const string elementName = "conversion_operator_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	('implicit' | 'explicit')  'operator'   type   '('   type   identifier   ')' ;
operator_body
@init { const string elementName = "operator_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	block ;
constructor_declaration
@init { const string elementName = "constructor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   constructor_modifiers?   constructor_declarator   constructor_body ;
constructor_modifiers
@init { const string elementName = "constructor_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	constructor_modifier+ ;
constructor_modifier
@init { const string elementName = "constructor_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'public' | 'protected' | 'internal' | 'private' | 'extern' | 'unsafe' ; 
constructor_declarator
@init { const string elementName = "constructor_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   '('   formal_parameter_list?   ')'   constructor_initializer? ;
constructor_initializer
@init { const string elementName = "constructor_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	':'   ('base' | 'this')   '('   argument_list?   ')' ;
constructor_body
@init { const string elementName = "constructor_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	block ;
static_constructor_declaration
@init { const string elementName = "static_constructor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   static_constructor_modifiers  identifier   '('   ')'  static_constructor_body ;
static_constructor_modifiers
@init { const string elementName = "static_constructor_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	  'extern' 'unsafe' 'static'
	| 'extern' 'static' 'unsafe'?
	| 'unsafe' 'extern' 'static'
	| 'unsafe' 'static' 'extern'?
	| 'static' 'extern' 'unsafe'?
	| 'static' 'unsafe' 'extern'? 
	| 'extern'
	| 'unsafe'
	| 'static';
static_constructor_body
@init { const string elementName = "static_constructor_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	block ;
destructor_declaration
@init { const string elementName = "destructor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   destructor_modifiers?   '~'  identifier   '('   ')'    destructor_body ;
destructor_modifiers
@init { const string elementName = "destructor_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	('extern'? 'unsafe')
	| ('extern' 'unsafe'?) ;
destructor_body
@init { const string elementName = "destructor_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	block ;

///////////////////////////////////////////////////////
struct_declaration
@init { const string elementName = "struct_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   struct_modifiers?   'partial'?   'struct'   identifier   generic_parameter_list?
			struct_interfaces?   type_parameter_constraints_clauses?   struct_body   ';'? ;
struct_modifiers
@init { const string elementName = "struct_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	struct_modifier+ ;
struct_modifier
@init { const string elementName = "struct_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'unsafe' ;
struct_interfaces
@init { const string elementName = "struct_interfaces"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	':'   interface_type_list;
struct_body
@init { const string elementName = "struct_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   struct_member_declarations?   '}';
struct_member_declarations
@init { const string elementName = "struct_member_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	struct_member_declaration+ ;
struct_member_declaration
@init { const string elementName = "struct_member_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	constant_declaration
	| field_declaration
	| method_declaration
	| property_declaration
	| event_declaration
	| indexer_declaration
	| operator_declaration
	| constructor_declaration
	| static_constructor_declaration
	| type_declaration ;

///////////////////////////////////////////////////////
interface_declaration
@init { const string elementName = "interface_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   interface_modifiers?   'partial'?   'interface'   identifier   variant_generic_parameter_list? 
    	interface_base?   type_parameter_constraints_clauses?   interface_body   ';'? 
	;
interface_modifiers
@init { const string elementName = "interface_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	interface_modifier+ ;
interface_modifier
@init { const string elementName = "interface_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' | 'unsafe' ;
interface_base
@init { const string elementName = "interface_base"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
   	':' interface_type_list ;
interface_body
@init { const string elementName = "interface_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   interface_member_declarations?   '}' ;
interface_member_declarations
@init { const string elementName = "interface_member_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	interface_member_declaration+ ;
interface_member_declaration
@init { const string elementName = "interface_member_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	interface_property_declaration 
	| interface_method_declaration 
	| interface_event_declaration 
	| interface_indexer_declaration ;
interface_method_declaration
@init { const string elementName = "interface_method_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'new'?   method_modifiers?  return_type   identifier   generic_parameter_list?
	    '('!   formal_parameter_list?   ')'!   type_parameter_constraints_clauses?   ';' ;
interface_property_declaration
@init { const string elementName = "interface_property_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'new'?   type   identifier   '{'   interface_accessor_declarations   '}' ;
interface_accessor_declarations
@init { const string elementName = "interface_accessor_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	interface_get_accessor_declaration   interface_set_accessor_declaration?
	| interface_set_accessor_declaration   interface_get_accessor_declaration? ;
interface_get_accessor_declaration
@init { const string elementName = "interface_get_accessor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'get'   ';' ;		// no body / modifiers
interface_set_accessor_declaration
@init { const string elementName = "interface_set_accessor_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'set'   ';' ;		// no body / modifiers
interface_event_declaration
@init { const string elementName = "interface_event_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   'new'?   'event'   type   identifier   ';' ; 
interface_indexer_declaration
@init { const string elementName = "interface_indexer_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?    'new'?    type   'this'   '['   formal_parameter_list   ']'   '{'   interface_accessor_declarations   '}' ;

///////////////////////////////////////////////////////

enum_declaration
@init { const string elementName = "enum_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   enum_modifiers?   'enum'   identifier   enum_base?   enum_body   ';'? ;
	
enum_base
@init { const string elementName = "enum_base"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	':'   integral_type ;
enum_body
@init { const string elementName = "enum_body"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{' (enum_member_declarations ','?)?   '}' ;
enum_member_declarations
@init { const string elementName = "enum_member_declarations"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	enum_member_declaration (',' enum_member_declaration)* ;
enum_member_declaration
@init { const string elementName = "enum_member_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	attributes?   identifier   ('='   expression)? ;
enum_modifiers
@init { const string elementName = "enum_modifiers"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	enum_modifier+ ;
enum_modifier
@init { const string elementName = "enum_modifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'new' | 'public' | 'protected' | 'internal' | 'private' ;
///////////////////////////////////////////////////////

statement
@init { const string elementName = "statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	labeled_statement
	| declaration_statement
	| embedded_statement ;
embedded_statement
@init { const string elementName = "embedded_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	block
	| empty_statement
	| expression_statement
	| selection_statement
	| iteration_statement
	| jump_statement
	| try_statement
	| checked_statement
	| unchecked_statement
	| lock_statement
	| using_statement 
	| yield_statement 
	| unsafe_statement
	| fixed_statement;
fixed_statement
@init { const string elementName = "fixed_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'fixed'   '('   pointer_type fixed_pointer_declarators   ')'   embedded_statement ;
fixed_pointer_declarators
@init { const string elementName = "fixed_pointer_declarators"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	fixed_pointer_declarator   (','   fixed_pointer_declarator)* ;
fixed_pointer_declarator
@init { const string elementName = "fixed_pointer_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   '='   fixed_pointer_initializer ;
fixed_pointer_initializer
@init { const string elementName = "fixed_pointer_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'&'   variable_reference   
	| expression;
unsafe_statement
@init { const string elementName = "unsafe_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'unsafe'   block;
block
@init { const string elementName = "block"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	';'
	| '{'   statement_list?   '}' ;
statement_list
@init { const string elementName = "statement_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	statement+ ;
empty_statement
@init { const string elementName = "empty_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	';' ;
labeled_statement
@init { const string elementName = "labeled_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   ':'   statement ;
declaration_statement
@init { const string elementName = "declaration_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(local_variable_declaration 
	| local_constant_declaration) ';' ;
local_variable_declaration
@init { const string elementName = "local_variable_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	local_variable_type   local_variable_declarators ;
local_variable_type
@init { const string elementName = "local_variable_type"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	type
	| 'var' 
	| 'dynamic';
local_variable_declarators
@init { const string elementName = "local_variable_declarators"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	local_variable_declarator (',' local_variable_declarator)* ;
local_variable_declarator
@init { const string elementName = "local_variable_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier ('='   local_variable_initializer)? 
	; 
local_variable_initializer
@init { const string elementName = "local_variable_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression
	| array_initializer 
	| stackalloc_initializer;
stackalloc_initializer
@init { const string elementName = "stackalloc_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'stackalloc'   unmanaged_type   '['   expression   ']' ;
local_constant_declaration
@init { const string elementName = "local_constant_declaration"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'const'   type   constant_declarators ;
constant_declarators
@init { const string elementName = "constant_declarators"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	constant_declarator (',' constant_declarator)* ;
constant_declarator
@init { const string elementName = "constant_declarator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	identifier   ('='   constant_expression)? ;
//	identifier   ('='   literal)? ;
expression_statement
@init { const string elementName = "expression_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	expression   ';' ;
statement_expression
@init { const string elementName = "statement_expression"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	invocation_expression
	| object_creation_expression
	| assignment
	| unary_expression;
selection_statement
@init { const string elementName = "selection_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	if_statement
	| switch_statement ;
if_statement
@init { const string elementName = "if_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'if'   '('   boolean_expression   ')'   embedded_statement   else_statement?
	;
else_statement
@init { const string elementName = "else_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'else'   embedded_statement	
	;
switch_statement
@init { const string elementName = "switch_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'switch'   '('   expression   ')'   switch_block ;
switch_block
@init { const string elementName = "switch_block"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'{'   switch_sections?   '}' ;
switch_sections
@init { const string elementName = "switch_sections"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	switch_section+ ;
switch_section
@init { const string elementName = "switch_section"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	switch_labels   statement_list ;
switch_labels
@init { const string elementName = "switch_labels"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	switch_label+ ;
switch_label
@init { const string elementName = "switch_label"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	('case'   constant_expression   ':')
	| ('default'   ':') ;
iteration_statement
@init { const string elementName = "iteration_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	while_statement
	| do_statement
	| for_statement
	| foreach_statement ;
while_statement
@init { const string elementName = "while_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'while'   '('   boolean_expression   ')'   embedded_statement ;
do_statement
@init { const string elementName = "do_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'do'   embedded_statement   'while'   '('   boolean_expression   ')'   ';' ;
for_statement
@init { const string elementName = "for_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'for'   '('   for_initializer?   ';'   for_condition?   ';'   for_iterator?   ')'   embedded_statement ;
for_initializer
@init { const string elementName = "for_initializer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	local_variable_declaration
	| statement_expression_list ;
for_condition
@init { const string elementName = "for_condition"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	boolean_expression ;
for_iterator
@init { const string elementName = "for_iterator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	statement_expression_list ;
statement_expression_list
@init { const string elementName = "statement_expression_list"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	statement_expression (',' statement_expression)* ;
foreach_statement
@init { const string elementName = "foreach_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'foreach'   '('   local_variable_type   identifier   'in'   expression   ')'   embedded_statement ;
jump_statement
@init { const string elementName = "jump_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	break_statement
	| continue_statement
	| goto_statement
	| return_statement
	| throw_statement ;
break_statement
@init { const string elementName = "break_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'break'   ';' ;
continue_statement
@init { const string elementName = "continue_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'continue'   ';' ;
goto_statement
@init { const string elementName = "goto_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	('goto'   identifier   ';')
	| ('goto'   'case'   constant_expression   ';')
	| ('goto'   'default'   ';') ;
return_statement
@init { const string elementName = "return_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'return'   expression?   ';' ;
throw_statement
@init { const string elementName = "throw_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'throw'   expression?   ';' ;
try_statement
@init { const string elementName = "try_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
      ('try'   block   catch_clauses   finally_clause?)
	| ('try'   block   finally_clause);
catch_clauses
@init { const string elementName = "catch_clauses"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	(specific_catch_clauses   general_catch_clause?)
	| (specific_catch_clauses?   general_catch_clause) ;
specific_catch_clauses
@init { const string elementName = "specific_catch_clauses"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	specific_catch_clause+ ;
specific_catch_clause
@init { const string elementName = "specific_catch_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'catch'   '('   class_type   identifier?   ')'   block ;
general_catch_clause
@init { const string elementName = "general_catch_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'catch'   block ;
finally_clause
@init { const string elementName = "finally_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'finally'   block ;
checked_statement
@init { const string elementName = "checked_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'checked'   block ;
unchecked_statement
@init { const string elementName = "unchecked_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'unchecked'   block ;
lock_statement
@init { const string elementName = "lock_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'lock'   '('  expression   ')'   embedded_statement ;
using_statement
@init { const string elementName = "using_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'using'   '('    resource_acquisition   ')'    embedded_statement ;
resource_acquisition
@init { const string elementName = "resource_acquisition"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	local_variable_declaration
	| expression ;
yield_statement
@init { const string elementName = "yield_statement"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	('yield'   'return'   expression   ';')
	| ('yield'   'break'   ';') ;

identifier
@init { const string elementName = "identifier"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	IDENTIFIER 
	| also_keyword ;

literal
@init { const string elementName = "literal"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	Real_literal
	| NUMBER
	| Hex_number
	| Character_literal
	| STRINGLITERAL
	| Verbatim_string_literal
	| TRUE
	| FALSE
	| NULL 
	;

keyword
@init { const string elementName = "keyword"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'abstract' | 'as' | 'base' | 'bool' | 'break' | 'byte' | 'case' |  'catch' | 'char' | 'checked' | 'class' | 'const' | 'continue' | 'decimal' | 'default' | 'delegate' | 'do' |	'double' | 'else' |	 'enum'  | 'event' | 'explicit' | 'extern' | 'false' | 'finally' | 'fixed' | 'float' | 'for' | 'foreach' | 'goto' | 'if' | 'implicit' | 'in' | 'int' | 'interface' | 'internal' | 'is' | 'lock' | 'long' | 'namespace' | 'new' | 'null' | 'object' | 'operator' | 'out' | 'override' | 'params' | 'private' | 'protected' | 'public' | 'readonly' | 'ref' | 'return' | 'sbyte' | 'sealed' | 'short' | 'sizeof' | 'stackalloc' | 'static' | 'string' | 'struct' | 'switch' | 'this' | 'throw' | 'true' | 'try' | 'typeof' | 'uint' | 'ulong' | 'unchecked' | 'unsafe' | 'ushort' | 'using' |	 'virtual' | 'void' | 'volatile' ;

also_keyword
@init { const string elementName = "also_keyword"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 
	'add' | 'alias' | 'assembly' | 'module' | 'field' | 'event' | 'method' | 'param' | 'property' | 'type' 
	| 'yield' | 'from' | 'into' | 'join' | 'on' | 'where' | 'orderby' | 'group' | 'by' | 'ascending' | 'descending' 
	| 'equals' | 'select' | 'pragma' | 'let' | 'remove' | 'set' | 'var' | '__arglist';
///////////////////////////////////////////////////////
//	Lexar Section
///////////////////////////////////////////////////////

TRUE : 'true';
FALSE: 'false' ;
NULL : 'null' ;
DOT : '.' ;
PTR : '->' ;
MINUS : '-' ;
GT : '>' ;
USING : 'using';
ENUM : 'enum';
GET : 'get';
SET : 'set';
IF: 'if';
ELSE: 'else';
ELIF: 'elif';
ENDIF: 'endif';
DEFINE: 'define';
UNDEF: 'undef';
SEMI: ';';
RPAREN: ')';

WS:
    (' '  |  '\r'  |  '\t'  |  '\n'  ) 
    { Skip(); } ;
fragment
TS:
    (' '  |  '\t'  ) 
    { Skip(); } ;
DOC_LINE_COMMENT
    : 	('///' ~('\n'|'\r')*  ('\r' | '\n')+)
    { Skip(); } ;
LINE_COMMENT
    :	('//' ~('\n'|'\r')*  ('\r' | '\n')+)
    { Skip(); } ;
COMMENT:
   '/*'
   (options {greedy=false;} : . )* 
   '*/'
	{ Skip(); } ;
STRINGLITERAL
	:
	'"' (EscapeSequence | ~('"' | '\\'))* '"' ;
Verbatim_string_literal:
	'@'   '"' Verbatim_string_literal_character* '"' ;
fragment
Verbatim_string_literal_character:
	'"' '"' | ~('"') ;
NUMBER:
	Decimal_digits INTEGER_TYPE_SUFFIX? ;
// For the rare case where 0.ToString() etc is used.
GooBall
@after		
{
	CommonToken int_literal = new CommonToken(NUMBER, $dil.text);
	CommonToken dot = new CommonToken(DOT, ".");
	CommonToken iden = new CommonToken(IDENTIFIER, $s.text);
	
	Emit(int_literal); 
	Emit(dot); 
	Emit(iden); 
	Console.Error.WriteLine("\tFound GooBall {0}", $text); 
}
	:
	dil = Decimal_integer_literal d = '.' s=GooBallIdentifier
	;

fragment GooBallIdentifier
	: IdentifierStart IdentifierPart* ;

//---------------------------------------------------------
Real_literal:
	Decimal_digits   '.'   Decimal_digits   Exponent_part?   Real_type_suffix?
	| '.'   Decimal_digits   Exponent_part?   Real_type_suffix?
	| Decimal_digits   Exponent_part   Real_type_suffix?
	| Decimal_digits   Real_type_suffix ;
Character_literal:
	'\''
    (   EscapeSequence
	// upto 3 multi byte unicode chars
    |   ~( '\\' | '\'' | '\r' | '\n' )        
    |   ~( '\\' | '\'' | '\r' | '\n' ) ~( '\\' | '\'' | '\r' | '\n' )
    |   ~( '\\' | '\'' | '\r' | '\n' ) ~( '\\' | '\'' | '\r' | '\n' ) ~( '\\' | '\'' | '\r' | '\n' )
    )
    '\'' ;
IDENTIFIER:
    IdentifierStart IdentifierPart* ;
Pragma:
	//	ignore everything after the pragma since the escape's in strings etc. are different
	'#' ('pragma' | 'region' | 'endregion' | 'line' | 'warning' | 'error') ~('\n'|'\r')*  ('\r' | '\n')+
    { Skip(); } ;
PREPROCESSOR_DIRECTIVE:
	| PP_CONDITIONAL;
fragment
PP_CONDITIONAL:
	(IF_TOKEN
	| DEFINE_TOKEN
	| ELSE_TOKEN
	| ENDIF_TOKEN 
	| UNDEF_TOKEN)   TS*   (LINE_COMMENT?  |  ('\r' | '\n')+) ;
fragment
IF_TOKEN
	@init { bool process = true; }:
	('#'   TS*  'if'   TS+   ppe = PP_EXPRESSION)
{
    // if our parent is processing check this if
    Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing.  IF_TOKEN");
    if (Processing.Count > 0 && Processing.Peek())
	    Processing.Push(Returns.Pop());
	else
		Processing.Push(false);
} ;
fragment
DEFINE_TOKEN:
	'#'   TS*   'define'   TS+   define = IDENTIFIER
	{
		MacroDefines.Add($define.Text, "");
	} ;
fragment
UNDEF_TOKEN:
	'#'   TS*   'undef'   TS+   define = IDENTIFIER
	{
		if (MacroDefines.ContainsKey($define.Text))
			MacroDefines.Remove($define.Text);
	} ;
fragment
ELSE_TOKEN:
	( '#'   TS*   e = 'else'
	| '#'   TS*   'elif'   TS+   PP_EXPRESSION)
	{
		// We are in an elif
       	if ($e == null)
		{
		    Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing.  ELIF_TOKEN");
			if (Processing.Count > 0 && Processing.Peek() == false)
			{
				Processing.Pop();
				// if our parent was processing, do else logic
			    Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing.  ELIF_TOKEN2");
				if (Processing.Count > 0 && Processing.Peek())
					Processing.Push(Returns.Pop());
				else
					Processing.Push(false);
			}
			else
			{
				Processing.Pop();
				Processing.Push(false);
			}
		}
		else
		{
			// we are in a else
			if (Processing.Count > 0)
			{
				bool bDoElse = !Processing.Pop();

				// if our parent was processing				
			    Debug.Assert(Processing.Count > 0, "Stack underflow preprocessing, ELSE_TOKEN");
				if (Processing.Count > 0 && Processing.Peek())
					Processing.Push(bDoElse);
				else
					Processing.Push(false);
			}
		}
		Skip();
	} ;
fragment
ENDIF_TOKEN:
	'#'   'endif'
	{
		if (Processing.Count > 0)
			Processing.Pop();
		Skip();
	} ;
	
	
	
	
fragment
PP_EXPRESSION:
	PP_OR_EXPRESSION;
fragment
PP_OR_EXPRESSION:
	PP_AND_EXPRESSION   TS*   ('||'   TS*   PP_AND_EXPRESSION   TS* )* ;
fragment
PP_AND_EXPRESSION:
	PP_EQUALITY_EXPRESSION   TS*   ('&&'   TS*   PP_EQUALITY_EXPRESSION   TS* )* ;
fragment
PP_EQUALITY_EXPRESSION:
	PP_UNARY_EXPRESSION   TS*   (('=='| ne = '!=')   TS*   PP_UNARY_EXPRESSION
		{ 
			bool rt1 = Returns.Pop(), rt2 = Returns.Pop();
			Returns.Push(rt1 == rt2 == ($ne == null));
		}
		TS* )*
	;
fragment
PP_UNARY_EXPRESSION:
	pe = PP_PRIMARY_EXPRESSION
	| '!'   TS*   ue = PP_UNARY_EXPRESSION  { Returns.Push(!Returns.Pop()); } 
	;
fragment
PP_PRIMARY_EXPRESSION:
	IDENTIFIER	
	{ 
		Returns.Push(MacroDefines.ContainsKey($IDENTIFIER.Text));
	}
	| '('   PP_EXPRESSION   ')'
	;


	
fragment
IdentifierStart
	:	'@' | '_' | 'A'..'Z' | 'a'..'z' ;
fragment
IdentifierPart
: 'A'..'Z' | 'a'..'z' | '0'..'9' | '_' ;
fragment
EscapeSequence 
    :   '\\' (
                 'b' 
             |   't' 
             |   'n' 
             |   'f' 
             |   'r'
             |   'v'
             |   'a'
             |   '\"' 
             |   '\'' 
             |   '\\'
             |   ('0'..'3') ('0'..'7') ('0'..'7')
             |   ('0'..'7') ('0'..'7') 
             |   ('0'..'7')
             |   'x'   HEX_DIGIT
             |   'x'   HEX_DIGIT   HEX_DIGIT
             |   'x'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT
             |   'x'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             |   'u'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             |   'U'   HEX_DIGIT   HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT  HEX_DIGIT
             ) ;     
fragment
Decimal_integer_literal:
	Decimal_digits   INTEGER_TYPE_SUFFIX? ;
//--------------------------------------------------------
Hex_number:
	'0'('x'|'X')   HEX_DIGITS   INTEGER_TYPE_SUFFIX? ;
fragment
Decimal_digits:
	DECIMAL_DIGIT+ ;
fragment
DECIMAL_DIGIT:
	'0'..'9' ;
fragment
INTEGER_TYPE_SUFFIX:
	'U' | 'u' | 'L' | 'l' | 'UL' | 'Ul' | 'uL' | 'ul' | 'LU' | 'Lu' | 'lU' | 'lu' ;
fragment HEX_DIGITS:
	HEX_DIGIT+ ;
fragment HEX_DIGIT:
	'0'..'9'|'A'..'F'|'a'..'f' ;
fragment
Exponent_part:
	('e'|'E')   Sign?   Decimal_digits;
fragment
Sign:
	'+'|'-' ;
fragment
Real_type_suffix:
	'F' | 'f' | 'D' | 'd' | 'M' | 'm' ;

// Testing rules - so you can just use one file with a list of items
assignment_list:
	(assignment ';')+ ;
field_declarations:
	field_declaration+ ;
property_declaration_list:
	property_declaration+ ;
member_access_list: 
	member_access+ ;
constant_declarations:
	constant_declaration+;
literals:
	literal+ ;
delegate_declaration_list:
	delegate_declaration+ ;
local_variable_declaration_list:
	(local_variable_declaration ';')+ ;
local_variable_initializer_list:
	(local_variable_initializer ';')+ ;
expression_list_test:
	(expression ';')+ ;
unary_expression_list:
	(unary_expression ';')+ ;
invocation_expression_list:
	(invocation_expression ';')+ ;
primary_expression_list:
	(primary_expression ';')+ ;
static_constructor_modifiers_list:
	(static_constructor_modifiers ';')+ ;