#include "covman.h"
 int main ( ) {
	int i = 0 ;
	Statement ( 12125 , 0 ) ;
	if ( BranchAndCondition ( 12125 , 11 , i == 0 ) ) {
		Statement ( 12125 , 1 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 2 ) ;
	switch ( i ) {
		case 0 : Statement ( 12125 , 3 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 4 ) ;
	while ( i != 0 ) {
		Statement ( 12125 , 5 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 6 ) ;
	do {
		Statement ( 12125 , 7 ) ;
		printf ( "test" ) ;
	}
	while ( i != 0 ) ;
	Statement ( 12125 , 8 ) ;
	for ( i = 0 ;
	i < 0 ;
	i ++ ) {
		Statement ( 12125 , 9 ) ;
		printf ( "test" ) ;
	}
	Statement ( 12125 , 10 ) ;
	return 0 ;
}
