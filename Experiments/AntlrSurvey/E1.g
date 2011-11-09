grammar E1;

options{
	output = AST;
	language=CSharp3;
}

prog
	: e=expression NEWLINE
		{ Console.WriteLine($e.value);}
	| NEWLINE
	;
expression returns [int value]
	: e=product 
		{$value = $e.value;}
	( '+' e=product 
		{$value += $e.value;}
	| '-' e=product
		{$value -= $e.value;}
	)*
	;
product returns [int value]
	: e=power 
		{$value = $e.value;} 
	( '*' e=power 
		{$value *= $e.value;}
	| '/' e=power
		{$value /= $e.value;}
	)*
	;
power returns [int value]
	: b=factor 
		{ $value = $b.value;}
	( '^' e=power
		{ double v = Math.Pow($b.value, $e.value);
		  $value = (int)v;
		}		 
	)?
	;
factor returns [int value]
	: IDENTIFIER
		{$value = 0;
		Console.WriteLine($IDENTIFIER.text);}
	| CONSTANT
		{$value = int.Parse($CONSTANT.text);}
	| '(' expression ')'
		{$value = $expression.value;}
	;

LINE_COMMENT
    :   '//' ~('\n'|'\r')*  ('\r\n' | '\r' | '\n') 
            {
$channel=HIDDEN;
            }
    |   '//' ~('\n'|'\r')*     // a line comment could appear at the end of the file without CR/LF
            {
$channel=HIDDEN;
            }
    ;

IDENTIFIER	:   ('a'..'z'|'A'..'Z')+ ;
CONSTANT	:   '0'..'9'+ ;
NEWLINE		:   '\r'? '\n' ;
WS			:   (' '|'\t')+ {Skip();} ;