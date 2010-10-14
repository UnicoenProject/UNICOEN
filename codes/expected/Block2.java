public class Block2 {
	public static int method1 ( ) {
		int i= 0 ;
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 14 , i == 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 1 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 2 ) ;
		switch ( i ) {
			case 0 : jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 3 ) ;
			System . out . println ( "test" ) ;
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 4 ) ;
			break ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 5 ) ;
		while ( i != 0 ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 6 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 7 ) ;
		do {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 8 ) ;
			System . out . println ( "test" ) ;
		}
		while ( i != 0 ) ;
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 9 ) ;
		for ( i= 0 ;
		i< 0 ;
		i ++ ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 10 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 11 ) ;
		for ( int j : new int [ ] {
			1 , 2 }
		) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 12 ) ;
			System . out . println ( j ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 13 ) ;
		return 0 ;
	}
}
