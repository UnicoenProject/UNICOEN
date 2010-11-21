/*
 [The 'BSD licence']
 Copyright (c) 2004 Terence Parr and Loring Craymer
 All rights reserved.

 Redistribution and use in source and binary forms, with or without
 modification, are permitted provided that the following conditions
 are met:
 1. Redistributions of source code must retain the above copyright
    notice, this list of conditions and the following disclaimer.
 2. Redistributions in binary form must reproduce the above copyright
    notice, this list of conditions and the following disclaimer in the
    documentation and/or other materials provided with the distribution.
 3. The name of the author may not be used to endorse or promote products
    derived from this software without specific prior written permission.

 THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

/** Python 2.3.3 Grammar
 *
 *  Terence Parr and Loring Craymer
 *  February 2004
 *
 *  Converted to ANTLR v3 November 2005 by Terence Parr.
 *
 *  This grammar was derived automatically from the Python 2.3.3
 *  parser grammar to get a syntactically correct ANTLR grammar
 *  for Python.  Then Terence hand tweaked it to be semantically
 *  correct; i.e., removed lookahead issues etc...  It is LL(1)
 *  except for the (sometimes optional) trailing commas and semi-colons.
 *  It needs two symbols of lookahead in this case.
 *
 *  Starting with Loring's preliminary lexer for Python, I modified it
 *  to do my version of the whole nasty INDENT/DEDENT issue just so I
 *  could understand the problem better.  This grammar requires
 *  PythonTokenStream.java to work.  Also I used some rules from the
 *  semi-formal grammar on the web for Python (automatically
 *  translated to ANTLR format by an ANTLR grammar, naturally <grin>).
 *  The lexical rules for python are particularly nasty and it took me
 *  a long time to get it 'right'; i.e., think about it in the proper
 *  way.  Resist changing the lexer unless you've used ANTLR a lot. ;)
 *
 *  I (Terence) tested this by running it on the jython-2.1/Lib
 *  directory of 40k lines of Python.
 *  
 */

grammar Python;

options {
    output=AST;
    language=CSharp2;
}

tokens {
    INDENT;
    DEDENT;
}

@lexer::members {
/** Handles context-sensitive lexing of implicit line joining such as
 *  the case where newline is ignored in cases like this:
 *  a = [3,
 *       4]
 */
int implicitLineJoiningLevel = 0;
int startPos=-1;
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


single_input
@init { const string elementName = "single_input"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: NEWLINE
             | simple_stmt
             | compound_stmt NEWLINE
             ;

file_input
@init { const string elementName = "file_input"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: (NEWLINE | stmt)*
           ;

eval_input
@init { const string elementName = "eval_input"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: (NEWLINE)* testlist (NEWLINE)*
           ;

decorators
@init { const string elementName = "decorators"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: decorator+
          ;

decorator
@init { const string elementName = "decorator"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: AT dotted_attr (LPAREN arglist? RPAREN)? NEWLINE
         ;

dotted_attr
@init { const string elementName = "dotted_attr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
    : NAME (DOT NAME)*
    ;

funcdef
@init { const string elementName = "funcdef"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: decorators? 'def' NAME parameters COLON suite
        ;

parameters
@init { const string elementName = "parameters"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: LPAREN (varargslist)? RPAREN
           ;

varargslist
@init { const string elementName = "varargslist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: defparameter (options {greedy=true;}:COMMA defparameter)*
              (COMMA
                  ( STAR NAME (COMMA DOUBLESTAR NAME)?
                  | DOUBLESTAR NAME
                  )?
              )?
            | STAR NAME (COMMA DOUBLESTAR NAME)?
            | DOUBLESTAR NAME
            ;

defparameter
@init { const string elementName = "defparameter"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: fpdef (ASSIGN test)?
             ;

fpdef
@init { const string elementName = "fpdef"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: NAME
      | LPAREN fplist RPAREN
      ;

fplist
@init { const string elementName = "fplist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: fpdef (options {greedy=true;}:COMMA fpdef)* (COMMA)?
       ;

stmt
@init { const string elementName = "stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: simple_stmt
     | compound_stmt
     ;

simple_stmt
@init { const string elementName = "simple_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: small_stmt (options {greedy=true;}:SEMI small_stmt)* (SEMI)? NEWLINE
            ;

small_stmt
@init { const string elementName = "small_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: expr_stmt
           | print_stmt
           | del_stmt
           | pass_stmt
           | flow_stmt
           | import_stmt
           | global_stmt
           | exec_stmt
           | assert_stmt
           ;

expr_stmt
@init { const string elementName = "expr_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: testlist
            ( augassign yield_expr
            | augassign testlist
            | assigns
            )?
          ;

assigns
@init { const string elementName = "assigns"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
    : assign_testlist+
    | assign_yield+
    ;

assign_testlist
@init { const string elementName = "assign_testlist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
       : ASSIGN testlist
       ;

assign_yield
@init { const string elementName = "assign_yield"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
    : ASSIGN yield_expr
    ;

augassign
@init { const string elementName = "augassign"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: PLUSEQUAL
          | MINUSEQUAL
          | STAREQUAL
          | SLASHEQUAL
          | PERCENTEQUAL
          | AMPEREQUAL
          | VBAREQUAL
          | CIRCUMFLEXEQUAL
          | LEFTSHIFTEQUAL
          | RIGHTSHIFTEQUAL
          | DOUBLESTAREQUAL
          | DOUBLESLASHEQUAL
          ;

print_stmt
@init { const string elementName = "print_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'print' (printlist | RIGHTSHIFT printlist)?
           ;

printlist returns [bool newline]
    : test (options {k=2;}: COMMA test)* (COMMA)?
    ;


del_stmt
@init { const string elementName = "del_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'del' exprlist
         ;

pass_stmt
@init { const string elementName = "pass_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'pass'
          ;

flow_stmt
@init { const string elementName = "flow_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: break_stmt
          | continue_stmt
          | return_stmt
          | raise_stmt
          | yield_stmt
          ;

break_stmt
@init { const string elementName = "break_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'break'
           ;

continue_stmt
@init { const string elementName = "continue_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'continue'
              ;

return_stmt
@init { const string elementName = "return_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'return' (testlist)?
            ;

yield_stmt
@init { const string elementName = "yield_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: yield_expr
           ;

raise_stmt
@init { const string elementName = "raise_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'raise' (test (COMMA test (COMMA test)?)?)?
          ;

import_stmt
@init { const string elementName = "import_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: import_name
            | import_from
            ;

import_name
@init { const string elementName = "import_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'import' dotted_as_names
            ;

import_from
@init { const string elementName = "import_from"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'from' (DOT* dotted_name | DOT+) 'import'
              (STAR
              | import_as_names
              | LPAREN import_as_names RPAREN
              )
           ;

import_as_names
@init { const string elementName = "import_as_names"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: import_as_name (COMMA import_as_name)* (COMMA)?
                ;

import_as_name
@init { const string elementName = "import_as_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: NAME ('as' NAME)?
               ;

dotted_as_name
@init { const string elementName = "dotted_as_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: dotted_name ('as' NAME)?
               ;

dotted_as_names
@init { const string elementName = "dotted_as_names"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: dotted_as_name (COMMA dotted_as_name)*
                ;
dotted_name
@init { const string elementName = "dotted_name"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: NAME (DOT NAME)*
            ;

global_stmt
@init { const string elementName = "global_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'global' NAME (COMMA NAME)*
            ;

exec_stmt
@init { const string elementName = "exec_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'exec' expr ('in' test (COMMA test)?)?
          ;

assert_stmt
@init { const string elementName = "assert_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'assert' test (COMMA test)?
            ;

compound_stmt
@init { const string elementName = "compound_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: if_stmt
              | while_stmt
              | for_stmt
              | try_stmt
              | with_stmt
              | funcdef
              | classdef
              ;

if_stmt
@init { const string elementName = "if_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'if' test COLON suite elif_clause*  ('else' COLON suite)?
       ;

elif_clause
@init { const string elementName = "elif_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'elif' test COLON suite
            ;

while_stmt
@init { const string elementName = "while_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'while' test COLON suite ('else' COLON suite)?
           ;

for_stmt
@init { const string elementName = "for_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'for' exprlist 'in' testlist COLON suite ('else' COLON suite)?
         ;

try_stmt
@init { const string elementName = "try_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'try' COLON suite
           ( except_clause+ ('else' COLON suite)? ('finally' COLON suite)?
           | 'finally' COLON suite
           )
         ;

with_stmt
@init { const string elementName = "with_stmt"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'with' test (with_var)? COLON suite
         ;

with_var
@init { const string elementName = "with_var"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: ('as' | NAME) expr
        ;

except_clause
@init { const string elementName = "except_clause"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'except' (test (COMMA test)?)? COLON suite
              ;

suite
@init { const string elementName = "suite"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: simple_stmt
      | NEWLINE INDENT (stmt)+ DEDENT
      ;

test
@init { const string elementName = "test"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: or_test
    ( ('if' or_test 'else') => 'if' or_test 'else' test)?
    | lambdef
    ;

or_test
@init { const string elementName = "or_test"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: and_test (OR and_test)*
        ;

and_test
@init { const string elementName = "and_test"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: not_test (AND not_test)*
         ;

not_test
@init { const string elementName = "not_test"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: NOT not_test
         | comparison
         ;

comparison
@init { const string elementName = "comparison"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: expr (comp_op expr)*
          ;

comp_op
@init { const string elementName = "comp_op"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: LESS
        | GREATER
        | EQUAL
        | GREATEREQUAL
        | LESSEQUAL
        | ALT_NOTEQUAL
        | NOTEQUAL
        | 'in'
        | NOT 'in'
        | 'is'
        | 'is' NOT
        ;

expr
@init { const string elementName = "expr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: xor_expr (VBAR xor_expr)*
     ;

xor_expr
@init { const string elementName = "xor_expr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: and_expr (CIRCUMFLEX and_expr)*
         ;

and_expr
@init { const string elementName = "and_expr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: shift_expr (AMPER shift_expr)*
         ;

shift_expr
@init { const string elementName = "shift_expr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: arith_expr ((LEFTSHIFT|RIGHTSHIFT) arith_expr)*
           ;

arith_expr
@init { const string elementName = "arith_expr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: term ((PLUS|MINUS) term)*
          ;

term
@init { const string elementName = "term"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: factor ((STAR | SLASH | PERCENT | DOUBLESLASH ) factor)*
     ;

factor
@init { const string elementName = "factor"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: PLUS factor
       | MINUS factor
       | TILDE factor
       | power
       ;

power
@init { const string elementName = "power"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: atom (trailer)* (options {greedy=true;}:DOUBLESTAR factor)?
      ;

atom
@init { const string elementName = "atom"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: LPAREN 
       ( yield_expr
       | testlist_gexp
       )?
       RPAREN
     | LBRACK (listmaker)? RBRACK
     | LCURLY (dictmaker)? RCURLY
     | BACKQUOTE testlist BACKQUOTE
     | NAME
     | INT
     | LONGINT
     | FLOAT
     | COMPLEX
     | (STRING)+
     ;

listmaker
@init { const string elementName = "listmaker"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: test 
            ( list_for
            | (options {greedy=true;}:COMMA test)*
            ) (COMMA)?
          ;

testlist_gexp
@init { const string elementName = "testlist_gexp"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
    : test ( (options {k=2;}: COMMA test)* (COMMA)?
           | gen_for
           )
           
    ;

lambdef
@init { const string elementName = "lambdef"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'lambda' (varargslist)? COLON test
       ;

trailer
@init { const string elementName = "trailer"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: LPAREN (arglist)? RPAREN
        | LBRACK subscriptlist RBRACK
        | DOT NAME
        ;

subscriptlist
@init { const string elementName = "subscriptlist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: subscript (options {greedy=true;}:COMMA subscript)* (COMMA)?
              ;

subscript
@init { const string elementName = "subscript"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: DOT DOT DOT
          | test (COLON (test)? (sliceop)?)?
          | COLON (test)? (sliceop)?
          ;

sliceop
@init { const string elementName = "sliceop"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: COLON (test)?
        ;

exprlist
@init { const string elementName = "exprlist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: expr (options {k=2;}: COMMA expr)* (COMMA)?
         ;

testlist
@init { const string elementName = "testlist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
    : test (options {k=2;}: COMMA test)* (COMMA)?
    ;

dictmaker
@init { const string elementName = "dictmaker"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: test COLON test (options {k=2;}:COMMA test COLON test)* (COMMA)?
          ;

classdef
@init { const string elementName = "classdef"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'class' NAME (LPAREN testlist? RPAREN)? COLON suite
        ;

arglist
@init { const string elementName = "arglist"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: argument (COMMA argument)*
          ( COMMA
            ( STAR test (COMMA DOUBLESTAR test)?
            | DOUBLESTAR test
            )?
          )?
        |   STAR test (COMMA DOUBLESTAR test)?
        |   DOUBLESTAR test
        ;

argument
@init { const string elementName = "argument"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: test ( (ASSIGN test) | gen_for)?
         ;

list_iter
@init { const string elementName = "list_iter"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: list_for
          | list_if
          ;

list_for
@init { const string elementName = "list_for"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'for' exprlist 'in' testlist (list_iter)?
         ;

list_if
@init { const string elementName = "list_if"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'if' test (list_iter)?
        ;

gen_iter
@init { const string elementName = "gen_iter"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: gen_for
        | gen_if
        ;

gen_for
@init { const string elementName = "gen_for"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'for' exprlist 'in' or_test gen_iter?
       ;

gen_if
@init { const string elementName = "gen_if"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'if' test gen_iter?
      ;

yield_expr
@init { const string elementName = "yield_expr"; var elementsIndex = Elements.Count; Elements.Add(null); }
@after { Elements[elementsIndex] = new XElement(elementName); Elements.Add(new XElement(LeaveElementName)); }
: 'yield' testlist?
           ;

LPAREN    : '(' {implicitLineJoiningLevel++;} ;

RPAREN    : ')' {implicitLineJoiningLevel--;} ;

LBRACK    : '[' {implicitLineJoiningLevel++;} ;

RBRACK    : ']' {implicitLineJoiningLevel--;} ;

COLON     : ':' ;

COMMA    : ',' ;

SEMI    : ';' ;

PLUS    : '+' ;

MINUS    : '-' ;

STAR    : '*' ;

SLASH    : '/' ;

VBAR    : '|' ;

AMPER    : '&' ;

LESS    : '<' ;

GREATER    : '>' ;

ASSIGN    : '=' ;

PERCENT    : '%' ;

BACKQUOTE    : '`' ;

LCURLY    : '{' {implicitLineJoiningLevel++;} ;

RCURLY    : '}' {implicitLineJoiningLevel--;} ;

CIRCUMFLEX    : '^' ;

TILDE    : '~' ;

EQUAL    : '==' ;

NOTEQUAL    : '!=' ;

ALT_NOTEQUAL: '<>' ;

LESSEQUAL    : '<=' ;

LEFTSHIFT    : '<<' ;

GREATEREQUAL    : '>=' ;

RIGHTSHIFT    : '>>' ;

PLUSEQUAL    : '+=' ;

MINUSEQUAL    : '-=' ;

DOUBLESTAR    : '**' ;

STAREQUAL    : '*=' ;

DOUBLESLASH    : '//' ;

SLASHEQUAL    : '/=' ;

VBAREQUAL    : '|=' ;

PERCENTEQUAL    : '%=' ;

AMPEREQUAL    : '&=' ;

CIRCUMFLEXEQUAL    : '^=' ;

LEFTSHIFTEQUAL    : '<<=' ;

RIGHTSHIFTEQUAL    : '>>=' ;

DOUBLESTAREQUAL    : '**=' ;

DOUBLESLASHEQUAL    : '//=' ;

DOT : '.' ;

AT : '@' ;

AND : 'and' ;

OR : 'or' ;

NOT : 'not' ;

FLOAT
    :   '.' DIGITS (Exponent)?
    |   DIGITS '.' Exponent
    |   DIGITS ('.' (DIGITS (Exponent)?)? | Exponent)
    ;

LONGINT
    :   INT ('l'|'L')
    ;

fragment
Exponent
    :    ('e' | 'E') ( '+' | '-' )? DIGITS
    ;

INT :   // Hex
        '0' ('x' | 'X') ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )+
    |   // Octal
        '0' DIGITS*
    |   '1'..'9' DIGITS*
    ;

COMPLEX
    :   INT ('j'|'J')
    |   FLOAT ('j'|'J')
    ;

fragment
DIGITS : ( '0' .. '9' )+ ;

NAME:    ( 'a' .. 'z' | 'A' .. 'Z' | '_')
        ( 'a' .. 'z' | 'A' .. 'Z' | '_' | '0' .. '9' )*
    ;

/** Match various string types.  Note that greedy=false implies '''
 *  should make us exit loop not continue.
 */
STRING
    :   ('r'|'u'|'ur')?
        (   '\'\'\'' (options {greedy=false;}:TRIAPOS)* '\'\'\''
        |   '"""' (options {greedy=false;}:TRIQUOTE)* '"""'
        |   '"' (ESC|~('\\'|'\n'|'"'))* '"'
        |   '\'' (ESC|~('\\'|'\n'|'\''))* '\''
        )
    ;

/** the two '"'? cause a warning -- is there a way to avoid that? */
fragment
TRIQUOTE
    : '"'? '"'? (ESC|~('\\'|'"'))+
    ;

/** the two '\''? cause a warning -- is there a way to avoid that? */
fragment
TRIAPOS
    : '\''? '\''? (ESC|~('\\'|'\''))+
    ;

fragment
ESC
    :    '\\' .
    ;

/** Consume a newline and any whitespace at start of next line
 *  unless the next line contains only white space, in that case
 *  emit a newline.
 */
CONTINUED_LINE
    :    '\\' ('\r')? '\n' (' '|'\t')*  { $channel=HIDDEN; }
         ( nl=NEWLINE {Emit(new ClassicToken(NEWLINE,nl.Text));}
         |
         )
    ;

/** Treat a sequence of blank lines as a single blank line.  If
 *  nested within a (..), {..}, or [..], then ignore newlines.
 *  If the first newline starts in column one, they are to be ignored.
 *
 *  Frank Wierzbicki added: Also ignore FORMFEEDS (\u000C).
 */
NEWLINE
    :   (('\u000C')?('\r')? '\n' )+
        {if ( startPos==0 || implicitLineJoiningLevel>0 )
            $channel=HIDDEN;
        }
    ;

WS  :    {startPos>0}?=> (' '|'\t'|'\u000C')+ {$channel=HIDDEN;}
    ;
    
/** Grab everything before a real symbol.  Then if newline, kill it
 *  as this is a blank line.  If whitespace followed by comment, kill it
 *  as it's a comment on a line by itself.
 *
 *  Ignore leading whitespace when nested in [..], (..), {..}.
 */
LEADING_WS
@init {
    int spaces = 0;
}
    :   {startPos==0}?=>
        (   {implicitLineJoiningLevel>0}? ( ' ' | '\t' )+ {$channel=HIDDEN;}
           |    (     ' '  { spaces++; }
            |    '\t' { spaces += 8; spaces -= (spaces \% 8); }
               )+
            {
            // make a string of n spaces where n is column number - 1
            char[] indentation = new char[spaces];
            for (int i=0; i<spaces; i++) {
                indentation[i] = ' ';
            }
            String s = new String(indentation);
            Emit(new ClassicToken(LEADING_WS,new String(indentation)));
            }
            // kill trailing newline if present and then ignore
            ( ('\r')? '\n' {if (state.token!=null) state.token.Channel = HIDDEN; else $channel=HIDDEN;})*
           // {token.setChannel(99); }
        )
    ;

/** Comments not on line by themselves are turned into newlines.

    b = a # end of line comment

    or

    a = [1, # weird
         2]

    This rule is invoked directly by nextToken when the comment is in
    first column or when comment is on end of nonwhitespace line.

    Only match \n here if we didn't start on left edge; let NEWLINE return that.
    Kill if newlines if we live on a line by ourselves
    
    Consume any leading whitespace if it starts on left edge.
 */
COMMENT
@init {
    $channel=HIDDEN;
}
    :    {startPos==0}?=> (' '|'\t')* '#' (~'\n')* '\n'+
    |    {startPos>0}?=> '#' (~'\n')* // let NEWLINE handle \n unless char pos==0 for '#'
    ;

