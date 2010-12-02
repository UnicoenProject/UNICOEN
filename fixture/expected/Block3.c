#include "covman.h"
 int main ( ) {
	int i = 0 ;
	WriteStatement ( 12125 , 0 , 0 ) ;
	if ( WritePredicate ( 12125 , 16 , 2 , i == 0 ) ) {
		WriteStatement ( 12125 , 1 , 0 ) ;
		;
	}
	WriteStatement ( 12125 , 2 , 0 ) ;
	switch ( i ) {
		WriteStatement ( 12125 , 3 , 0 ) ;
		;
	}
	WriteStatement ( 12125 , 4 , 0 ) ;
	while ( i != 0 ) {
		WriteStatement ( 12125 , 5 , 0 ) ;
		;
	}
	WriteStatement ( 12125 , 6 , 0 ) ;
	do {
		WriteStatement ( 12125 , 7 , 0 ) ;
		;
	}
	while ( i != 0 ) ;
	WriteStatement ( 12125 , 8 , 0 ) ;
	for ( i = 0 ;
	i < 0 ;
	i ++ ) {
		WriteStatement ( 12125 , 9 , 0 ) ;
		;
	}
	WriteStatement ( 12125 , 10 , 0 ) ;
	if ( WritePredicate ( 12125 , 17 , 2 , i == 0 ) ) {
	}
	WriteStatement ( 12125 , 11 , 0 ) ;
	switch ( i ) {
	}
	WriteStatement ( 12125 , 12 , 0 ) ;
	while ( i != 0 ) {
	}
	WriteStatement ( 12125 , 13 , 0 ) ;
	do {
	}
	while ( i != 0 ) ;
	WriteStatement ( 12125 , 14 , 0 ) ;
	for ( i = 0 ;
	i < 0 ;
	i ++ ) {
	}
	WriteStatement ( 12125 , 15 , 0 ) ;
	return 0 ;
}
