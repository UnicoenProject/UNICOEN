import CoverageOutput
CoverageOutput . WriteStatement ( 12125 , 0 , 0 ) ; i = 0
if CoverageOutput . WritePredicate ( 12125 , 7 , 2 , i == 0 ) : CoverageOutput . WriteStatement ( 12125 , 1 , 0 ) ; print ( "test" )
while i != 0 : CoverageOutput . WriteStatement ( 12125 , 2 , 0 ) ; print ( "test" )
for x in [ 0 ] : CoverageOutput . WriteStatement ( 12125 , 3 , 0 ) ; print ( "test" )
if CoverageOutput . WritePredicate ( 12125 , 8 , 2 , i == 0 ) :
	CoverageOutput . WriteStatement ( 12125 , 4 , 0 ) ; print ( "test" )
while i != 0 :
	CoverageOutput . WriteStatement ( 12125 , 5 , 0 ) ; print ( "test" )
for x in [ 0 ] :
	CoverageOutput . WriteStatement ( 12125 , 6 , 0 ) ; print ( "test" )

