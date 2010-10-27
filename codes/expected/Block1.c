#include "covman.h"
 int main ( ) {
	int i = 0 ;
	WriteStatement ( 12125 , 0 , 0 ) ;
	if ( WritePredicate ( 12125 , 16 , 2 , i == 0 ) ) {
		WriteStatement ( 12125 , 1 , 0 ) ;
		printf ( "test" ) ;
	}
	WriteStatement ( 12125 , 2 , 0 ) ;
	if ( WritePredicate ( 12125 , 17 , 1 , WritePredicate ( 12125 , 13 , 2 , i <= 0 ) && ( WritePredicate ( 12125 , 14 , 2 , i >= 0 ) || WritePredicate ( 12125 , 15 , 2 , i != 0 ) ) ) ) {
		WriteStatement ( 12125 , 3 , 0 ) ;
		printf ( "test" ) ;
	}
	WriteStatement ( 12125 , 4 , 0 ) ;
	switch ( i ) {
		case 0 : WriteStatement ( 12125 , 5 , 0 ) ;
		printf ( "test" ) ;
	}
	WriteStatement ( 12125 , 6 , 0 ) ;
	while ( i != 0 ) {
		WriteStatement ( 12125 , 7 , 0 ) ;
		printf ( "test" ) ;
	}
	WriteStatement ( 12125 , 8 , 0 ) ;
	do {
		WriteStatement ( 12125 , 9 , 0 ) ;
		printf ( "test" ) ;
	}
	while ( i != 0 ) ;
	WriteStatement ( 12125 , 10 , 0 ) ;
	for ( i = 0 ;
	i < 0 ;
	i ++ ) {
		WriteStatement ( 12125 , 11 , 0 ) ;
		printf ( "test" ) ;
	}
	WriteStatement ( 12125 , 12 , 0 ) ;
	return 0 ;
}
