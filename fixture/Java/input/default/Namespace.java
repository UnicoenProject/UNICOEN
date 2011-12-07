package pkg.subpkg.subsubpkg.subsubsubpkg;

class Cls{
	class Inner{
		public int inner;
	}
	
	// instance field
	public int a;				// pkg(package).Cls(class).a(field, instance)
	// class field
	public static int b;			// pkg(package).Cls(class).b(field, static)
	
	public void method(){		// pkg(package).Cls(class).method(function, instance)
		int a = 0;				// pkg(package).Cls(class).method(function, instance).a
		return a;
	}
	
	public void method2(){
		for(int i = 0; i < N; i++){
			method();
		}
	}
}
