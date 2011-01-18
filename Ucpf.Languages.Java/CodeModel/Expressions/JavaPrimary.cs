using System;
using System.Collections.Generic;

namespace Ucpf.Languages.Java.CodeModel.Expressions {
	// function invocation
	internal class JavaPrimary : JavaExpression {
		private List<Value> Arguments;
		private String FunctionName;
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