using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.Java.CodeModel
{
    public class JavaStatement
    {
    }

    /*
statement 
    :   block
            
    |   ('assert'
        )
        expression (':' expression)? ';'
    |   'assert'  expression (':' expression)? ';'            
    |   'if' parExpression statement ('else' statement)?          
    |   forstatement
    |   'while' parExpression statement
    |   'do' statement 'while' parExpression ';'
    |   trystatement
    |   'switch' parExpression '{' switchBlockStatementGroups '}'
    |   'synchronized' parExpression block
    |   'return' (expression )? ';'
    |   'throw' expression ';'
    |   'break'
            (IDENTIFIER
            )? ';'
    |   'continue'
            (IDENTIFIER
            )? ';'
    |   expression  ';'     
    |   IDENTIFIER ':' statement
    |   ';'

    ;
     * */
}
