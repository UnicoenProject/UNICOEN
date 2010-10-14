#include "covman.h"
 int main ( ) {
	int i = 0 ;
	Statement ( 12125 , 0 ) ;
	if ( BranchAndCondition ( 12125 , 16 , i == 0 ) ) {
		Statement ( 12125 , 1 ) ;
		;
	}
	Statement ( 12125 , 2 ) ;
	switch ( i ) {
		Statement ( 12125 , 3 ) ;
		;
	}
	Statement ( 12125 , 4 ) ;
	while ( i != 0 ) {
		Statement ( 12125 , 5 ) ;
		;
	}
	Statement ( 12125 , 6 ) ;
	do {
		Statement ( 12125 , 7 ) ;
		;
	}
	while ( i != 0 ) ;
	Statement ( 12125 , 8 ) ;
	for ( i = 0 ;
	i < 0 ;
	i ++ ) {
		Statement ( 12125 , 9 ) ;
		;
	}
	Statement ( 12125 , 10 ) ;
	if ( BranchAndCondition ( 12125 , 17 , i == 0 ) ) {
	}
	Statement ( 12125 , 11 ) ;
	switch ( i ) {
	}
	Statement ( 12125 , 12 ) ;
	while ( i != 0 ) {
	}
	Statement ( 12125 , 13 ) ;
	do {
	}
	while ( i != 0 ) ;
	Statement ( 12125 , 14 ) ;
	for ( i = 0 ;
	i < 0 ;
	i ++ ) {
	}
	Statement ( 12125 , 15 ) ;
	return 0 ;
}
