public class Modifier {
}

class AccessTest1 {

	// public, protected, 無し, privateな値の定義
	public int publicValue;
	protected int protectedValue;
	/* 無し */int normalValue;
	private int privateValue;

	public static void main(String[] args) {
	}

	// 自ファイル・自クラスからのアクセステスト
	public AccessTest1() {
		this.publicValue = 1;
		this.protectedValue = 2;
		this.normalValue = 3;
		this.privateValue = 4;
	}
}

class AccessTest2 extends AccessTest1 {
	// 自ファイル・サブクラスからのアクセステスト
	void AccessTest2() {
		this.publicValue = 1;
		this.protectedValue = 2;
		this.normalValue = 3;
		// this.privateValue = 4; ← アクセスできない
	}
}

class AccessTest3 {
	// 自ファイル・他クラスからのアクセステスト
	void AccessTest3() {
		AccessTest1 o = new AccessTest1();
		o.publicValue = 1;
		o.protectedValue = 2;
		o.normalValue = 3;
		// o.privateValue = 4; ← アクセスできない
	}
}

class AccessTest4 extends AccessTest1 {

	public static void main(String[] args) {
	}

	// 他ファイル・サブクラスからのアクセステスト
	AccessTest4() {
		this.publicValue = 1;
		this.protectedValue = 2;
		// this.normalValue = 3; ← アクセスできない
		// this.privateValue = 4; ← アクセスできない
	}
}

class AccessTest5 {
	// 他ファイル・他クラスからのアクセステスト
	AccessTest5() {
		AccessTest1 o = new AccessTest1();
		o.publicValue = 1;
		// o.protectedValue = 2; ← アクセスできない
		// o.normalValue = 3; ← アクセスできない
		// o.privateValue = 4; ← アクセスできない
	}

	public native void testFunction(int a);

	synchronized void s1() {
	}

	void m2() {
		synchronized (this) {
		}
	}

	transient String tmp;
	volatile int nCount;

	strictfp class AA {
		double x, y;
	}

	public static void main(String[] args) {
	}

	public static final double PI = 3.14159265358979323846;

	public static double sin(double a) {
		return -0.1;
	}

	public static class ClassB {
		final int method(int a) {
			return -2;
		}

		public static final double PI = 3.141592653589793238;
	}

	abstract class A1 {
		abstract void testFunction(int a);
	}

	abstract interface I1 {
		abstract void testFunction(int a);
	}
}
