public class Block1 {
	int method1 ( ) {
		int i= 0 ;
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 0 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 24 , 2 , i<= 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 1 , 0 ) ;
			System . out . println ( "0" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 2 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 25 , 2 , i == 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 3 , 0 ) ;
			System . out . println ( "0" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 4 , 0 ) ;
			System . out . println ( "else" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 5 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 26 , 2 , i == 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 6 , 0 ) ;
			System . out . println ( "0" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 7 , 0 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 27 , 2 , i == 1 ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 8 , 0 ) ;
				System . out . println ( "1" ) ;
			}
			else {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 9 , 0 ) ;
				if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 28 , 2 , i == 2 ) ) {
					jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 10 , 0 ) ;
					System . out . println ( "2" ) ;
				}
				else {
					jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 11 , 0 ) ;
					System . out . println ( "else" ) ;
				}
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 12 , 0 ) ;
		switch ( i ) {
			case 0 : jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 13 , 0 ) ;
			System . out . println ( "test" ) ;
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 14 , 0 ) ;
			break ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 15 , 0 ) ;
		test : while ( i != 0 ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 16 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 17 , 0 ) ;
		do {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 18 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		while ( i != 0 ) ;
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 19 , 0 ) ;
		for ( i= 0 ;
		i< 0 ;
		i ++ ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 20 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 21 , 0 ) ;
		for ( int j : new int [ ] {
			1 , 2 }
		) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 22 , 0 ) ;
			System . out . println ( j ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 23 , 0 ) ;
		return 0 ;
	}
}
