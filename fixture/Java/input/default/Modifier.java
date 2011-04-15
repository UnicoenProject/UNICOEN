public class Modifier {
}

class AccessTest1 {

	// public, protected, ����, private�Ȓl�̒�`
	public int publicValue;
	protected int protectedValue;
	/* ���� */int normalValue;
	private int privateValue;

	public static void main(String[] args) {
	}

	// ���t�@�C���E���N���X����̃A�N�Z�X�e�X�g
	public AccessTest1() {
		this.publicValue = 1;
		this.protectedValue = 2;
		this.normalValue = 3;
		this.privateValue = 4;
	}
}

class AccessTest2 extends AccessTest1 {
	// ���t�@�C���E�T�u�N���X����̃A�N�Z�X�e�X�g
	void AccessTest2() {
		this.publicValue = 1;
		this.protectedValue = 2;
		this.normalValue = 3;
		// this.privateValue = 4; �� �A�N�Z�X�ł��Ȃ�
	}
}

class AccessTest3 {
	// ���t�@�C���E���N���X����̃A�N�Z�X�e�X�g
	void AccessTest3() {
		AccessTest1 o = new AccessTest1();
		o.publicValue = 1;
		o.protectedValue = 2;
		o.normalValue = 3;
		// o.privateValue = 4; �� �A�N�Z�X�ł��Ȃ�
	}
}

class AccessTest4 extends AccessTest1 {

	public static void main(String[] args) {
	}

	// ���t�@�C���E�T�u�N���X����̃A�N�Z�X�e�X�g
	AccessTest4() {
		this.publicValue = 1;
		this.protectedValue = 2;
		// this.normalValue = 3; �� �A�N�Z�X�ł��Ȃ�
		// this.privateValue = 4; �� �A�N�Z�X�ł��Ȃ�
	}
}

class AccessTest5 {
	// ���t�@�C���E���N���X����̃A�N�Z�X�e�X�g
	AccessTest5() {
		AccessTest1 o = new AccessTest1();
		o.publicValue = 1;
		// o.protectedValue = 2; �� �A�N�Z�X�ł��Ȃ�
		// o.normalValue = 3; �� �A�N�Z�X�ł��Ȃ�
		// o.privateValue = 4; �� �A�N�Z�X�ł��Ȃ�
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
