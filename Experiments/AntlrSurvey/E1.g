grammar E1;

options{
	output = AST;
	language=CSharp3;
}

prog
@after {
	//Output the position of element
	Console.WriteLine("(" + retval.Start.Line + ", " + retval.Start.StartIndex + ") - (" + retval.Stop.Line + ", " + retval.Stop.StartIndex + ")");			
	//Output next token only when it is comment
	if(input.Get(retval.Stop.TokenIndex + 1).Channel == TokenChannels.Hidden)
		Console.WriteLine(input.Get(retval.Stop.TokenIndex + 1).Text);
}
	: e=expression NEWLINE
		{ Console.WriteLine("result= " + $e.value);}
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