public class Simple {
	int method1 ( ) {
		int i= 0 ;
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 0 , 0 ) ;
		if ( jp . ac . waseda . cs . washi . CoverageManager . WritePredicate ( 12125 , 4 , 2 , i == 0 ) ) {
			jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 1 , 0 ) ;
			System . out . println ( "0" ) ;
		}
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 2 , 0 ) ;
		System . out . println ( "0" ) ;
		jp . ac . waseda . cs . washi . CoverageManager . WriteStatement ( 12125 , 3 , 0 ) ;
		return 0 ;
	}
}
