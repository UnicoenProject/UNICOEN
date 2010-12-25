using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ucpf.Languages.Java.CodeModel.Expressions
{
    // function invocation
    class JavaPrimary : JavaExpression
    {
        String FunctionName;
        List<Value> Arguments;
    }
 /**
 * have to use scope here, parameter passing isn't well supported in antlr.
 *
primary 
    :   parExpression            
    |   'this'
        ('.' IDENTIFIER
        )*
        (identifierSuffix
        )?
    |   IDENTIFIER
        ('.' IDENTIFIER
        )*
        (identifierSuffix
        )?
    |   'super'
        superSuffix
    |   literal
    |   creator
    |   primitiveType
        ('[' ']'
        )*
        '.' 'class'
    |   'void' '.' 'class'
    ;
  */
}
