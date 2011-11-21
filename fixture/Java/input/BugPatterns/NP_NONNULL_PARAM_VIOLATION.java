package src;

import java.util.EnumMap;

public class NP_NONNULL_PARAM_VIOLATION {
	enum Foo {
	    A, B
	}
	public static void main(String[] args) throws Exception {
		EnumMap map = new EnumMap(Foo.class);
		map.get(null);
	}
}
