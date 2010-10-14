public class Block1 {
	int method1 ( ) {
		int i= 0 ;
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 24 , i<= 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 1 ) ;
			System . out . println ( "0" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 2 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 25 , i == 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 3 ) ;
			System . out . println ( "0" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 4 ) ;
			System . out . println ( "else" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 5 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 26 , i == 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 6 ) ;
			System . out . println ( "0" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 7 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 27 , i == 1 ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 8 ) ;
				System . out . println ( "1" ) ;
			}
			else {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 9 ) ;
				if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 28 , i == 2 ) ) {
					jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 10 ) ;
					System . out . println ( "2" ) ;
				}
				else {
					jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 11 ) ;
					System . out . println ( "else" ) ;
				}
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 12 ) ;
		switch ( i ) {
			case 0 : jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 13 ) ;
			System . out . println ( "test" ) ;
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 14 ) ;
			break ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 15 ) ;
		test : while ( i != 0 ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 16 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 17 ) ;
		do {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 18 ) ;
			System . out . println ( "test" ) ;
		}
		while ( i != 0 ) ;
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 19 ) ;
		for ( i= 0 ;
		i< 0 ;
		i ++ ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 20 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 21 ) ;
		for ( int j : new int [ ] {
			1 , 2 }
		) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 22 ) ;
			System . out . println ( j ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 23 ) ;
		return 0 ;
	}
}
