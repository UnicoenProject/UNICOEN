package src;

import java.util.EnumMap;

public class NP_NONNULL_PARAM_VIOLATION {
	enum Foo {
	    A, B
	}
	public static void main(String[] args) throws Exception{
		EnumMap<Foo, Integer> map = new EnumMap<Foo, Integer>(Foo.class);
		map.get(null);	//NP_NONNULL_PARAM_VIOLATION	優先度 高
	}
}
