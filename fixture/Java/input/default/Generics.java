class A<T1> {
	class C<T3> {
		protected int a;
		public <T4> C(T4 t) {
		}
		public <T4> void b() {
			A<T1> a = A.this;
		}
	}
	public A(int i) {
		Class c1 = C.class;
		Class c2 = A.class;
		Class c3 = A.C.class;
	}
	public <T2> void method(T2 t1) {
		System.out.println(t1);
		this.<Integer>method(1);
	}
}
class B<T1> extends A<T1> {
	public B(int i) {
		super(i);
	}

	public void m() {
		super.<Integer>method(1);
		A<Integer> a = new A<Integer>(1);
		a.new C<Integer>(1);
		new A<Integer>(1).new C<Integer>(1);
		new A<Integer>(1).new <Integer> C<Integer>(1);
	}
}

class G<T1> extends A<T1>.C<T1> {

	public G() {
		new A<T1>(1).super(null);
	}

	class D<T3> {
		public void d() {
			int a = G.super.a;
		}
	}

	public void m() {
		super.<Integer>b();
		A<Integer> a = new A<Integer>(1);
		a.new C<Integer>(1);
		new A<Integer>(1).new C<Integer>(1);
	}
}