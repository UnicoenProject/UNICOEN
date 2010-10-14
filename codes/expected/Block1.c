#include "covman.h"
 int main ( ) {
	int i = 0 ;
	Statement ( 12125 , 0 ) ;
	if ( BranchAndCondition ( 12125 , 16 , i == 0 ) ) {
		Statement ( 12125 , 1 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 2 ) ;
	if ( Branch ( 12125 , 17 , Condition ( 12125 , 13 , i <= 0 ) && ( Condition ( 12125 , 14 , i >= 0 ) || Condition ( 12125 , 15 , i != 0 ) ) ) ) {
		Statement ( 12125 , 3 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 4 ) ;
	switch ( i ) {
		case 0 : Statement ( 12125 , 5 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 6 ) ;
	while ( i != 0 ) {
		Statement ( 12125 , 7 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 8 ) ;
	do {
		Statement ( 12125 , 9 ) ;
		printf ( "test" ) ;
	}
	while ( i != 0 ) ;
	Statement ( 12125 , 10 ) ;
	for ( i = 0 ;
	i < 0 ;
	i ++ ) {
		Statement ( 12125 , 11 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 12 ) ;
	return 0 ;
}
