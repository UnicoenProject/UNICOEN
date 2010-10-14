public class Condition1 {
	public static boolean f ( boolean i ) {
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 0 ) ;
		return ! i ;
	}
	public static void main ( String [ ] args ) {
		boolean a= false , b= false , c= true ;
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 1 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 43 , a ^ ( b && c ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 2 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 3 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 44 , a ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 4 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 5 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . Branch ( 12125 , 45 , jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 31 , a ) && jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 32 , b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 6 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 7 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . Branch ( 12125 , 46 , jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 33 , a ) && jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 34 , b ) || jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 35 , c ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 8 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 9 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . Branch ( 12125 , 47 , jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 36 , a ) && ( jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 37 , b ) || jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 38 , c ) ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 10 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 11 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 48 , 0< ( ~ 1 | 1 & 1 ^ 1 + 1 - 1 / 1 * 1 ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 12 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 13 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . Branch ( 12125 , 49 , jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 39 , a ) && jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 40 , b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 14 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 15 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 50 , args [ a ? 0 : 1 ] ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 16 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 17 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 51 , args [ a ? 0 : 1 ] ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 18 ) ;
			System . out . println ( "test" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 19 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 52 , f ( a ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 20 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 21 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . Branch ( 12125 , 53 , jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 41 , a ) && jp . ac . waseda . cs . washi . CoverageManager . Condition ( 12125 , 42 , b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 22 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 23 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 54 , f ( a && b || c ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 24 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 25 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 55 , f ( a && ( b || c ) ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 26 ) ;
				System . out . println ( "test" ) ;
			}
		}
		jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 27 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 56 , f ( 0< ( ~ 1 | 1 & 1 ^ 1 + 1 - 1 / 1 * 1 ) ) ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 28 ) ;
			System . out . println ( "test" ) ;
		}
		else {
			jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 29 ) ;
			if ( jp . ac . waseda . cs . washi . CoverageManager . BranchAndCondition ( 12125 , 57 , f ( a && b ) ) ) {
				jp . ac . waseda . cs . washi . CoverageManager . Statement ( 12125 , 30 ) ;
				System . out . println ( "test" ) ;
			}
		}
	}
}
