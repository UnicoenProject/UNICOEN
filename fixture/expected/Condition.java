public class Condition1 {
	public static boolean f ( boolean i ) {
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 0 , 0 ) ;
		return ! i ;
	}
	public static void main ( String [ ] args ) {
		boolean a= false , b= false , c= true ;
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 1 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 43 , 2 , a ^ ( b && c ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 2 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 3 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 44 , 2 , a ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 4 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 5 , 0 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 45 , 1 , jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 31 , 2 , a ) && jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 32 , 2 , b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 6 , 0 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 7 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 46 , 1 , jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 33 , 2 , a ) && jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 34 , 2 , b ) || jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 35 , 2 , c ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 8 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 9 , 0 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 47 , 1 , jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 36 , 2 , a ) && ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 37 , 2 , b ) || jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 38 , 2 , c ) ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 10 , 0 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 11 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 48 , 2 , 0< ( ~ 1 | 1 & 1 ^ 1 + 1 - 1 / 1 * 1 ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 12 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 13 , 0 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 49 , 1 , jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 39 , 2 , a ) && jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 40 , 2 , b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 14 , 0 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 15 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 50 , 2 , args [ a ? 0 : 1 ] ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 16 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 17 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 51 , 2 , args [ a ? 0 : 1 ] ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 18 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 19 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 52 , 2 , f ( a ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 20 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 21 , 0 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 53 , 1 , jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 41 , 2 , a ) && jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 42 , 2 , b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 22 , 0 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 23 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 54 , 2 , f ( a && b || c ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 24 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 25 , 0 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 55 , 2 , f ( a && ( b || c ) ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 26 , 0 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 27 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 56 , 2 , f ( 0< ( ~ 1 | 1 & 1 ^ 1 + 1 - 1 / 1 * 1 ) ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 28 , 0 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 29 , 0 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 57 , 2 , f ( a && b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 30 , 0 ) ;
				System . out . println ( "test" ) ;
			}
		}
	}
}
