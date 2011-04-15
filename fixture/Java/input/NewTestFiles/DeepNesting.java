class WithDeepNesting{
	boolean toBe;
	WithDeepNesting(boolean b) { toBe = b;}
	class Nested {
		boolean theQuestion;
		class DeeplyNested {
			DeeplyNested(){
				theQuestion = toBe || !toBe;
			}
		}
	}
}