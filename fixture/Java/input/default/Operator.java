public class Operator {
	public void method() {
		int a = 10000;
		int b = 1000000;
		int c;
		c = a / b * b;
		c = a * b / b;
		long a2 = 10000;
		long b2 = 1000000;
		long c2 = a * b / b;
		double d = 1.0 / 0;
		boolean bln = (d == Double.POSITIVE_INFINITY); // bln �ɂ� true ����������
		float x = 0;
		boolean b1 = x < Float.NaN;
		boolean bb = x > Float.NaN;
		boolean b3 = x <= Float.NaN;
		boolean b4 = x >= Float.NaN;
		boolean b5 = x == Float.NaN;
		boolean b6 = x != Float.NaN; // x �̒l�ɂ�炸�S�� false ���Ԃ�
		boolean bln2 = Float.isNaN(x); // float �^�ϐ� x �̒l�� NaN �Ȃ�� true
		bln = Double.isNaN(d); // double �^�ϐ� y �̒l�� NaN �Ȃ�� true
	}

	public void m2() {
		boolean a = false;
		boolean b = true;
		System.out.println(a & b);
		System.out.println(a | b);
		System.out.println(a && b);
		System.out.println(a || b);
		System.out.println(a ^ b);
		System.out.println(!a);
		System.out.println((3 < 0) & (10 != 10));
		System.out.println((3 < 0) | (10 != 10));
		System.out.println((3 < 0) ^ (10 != 10));
		System.out.println(!(3 < 0));
		a = a ? a : b;
	}

	public void m3() {
		int a = 0;
		a = a << 3;
		a = a >> 4;
		a = a >>> 5;
		int x = 10;
		int y = 100;
		int z = ++y * x;
		z = y++ * x;
		y = y + 10;
		y += 10;
		y = y - 10;
		y -= 10;
		y = y * 10;
		y *= 10;
		y = y / 10;
		y /= 10;
		y = y % 10;
		y %= 10;
		boolean b = "" instanceof String;
	}
}

class TestOperator {
	public static void main(String[] args) {
		int x = 10, y = 3, z = 0;
		System.out.println("�Z�p���Z�q");
		System.out.println("x=" + x + " y=" + y);
		System.out.println("x+y: " + (x + y));
		System.out.println("x-y: " + (x - y));
		System.out.println("x*y: " + (x * y));
		System.out.println("x/y: " + (x / y));
		System.out.println("x%y: " + (x % y));
	}
}

class TestOperator2 {
	public static void main(String[] args) {
		int x = 10, y = 3, z = 0;
		System.out.println("�ċA�I�����");
		System.out.println("x=" + x + " y=" + y);
		System.out.print("x+=y:" + (x += y));
		System.out.println("  x=" + x);
		System.out.print("x*=y+10:" + (x *= y + 10));
		System.out.println("  x=" + x);
		System.out.println("	��x=x*(y+10)�Ɖ��߂����");
		System.out.print("x%=y:" + (x %= y));
		System.out.println("  x=" + x);
	}
}

class TestOperator3 {
	public static void main(String[] args) {
		int x = 10, y = 3, z = 0;
		System.out.println("�C���N�������g�^�f�N�������g���Z�q");
		// ��u�C���N�������g���Z�q
		x = 10;
		y = 3;
		System.out.println("x=" + x + " y=" + y);
		z = y++ * x;
		System.out.print("1. z=y++*x: ");
		System.out.println("z=" + z + " y=" + y);
		// �O�u�C���N�������g���Z�q
		x = 10;
		y = 3;
		System.out.println("x=" + x + " y=" + y);
		z = ++y * x;
		System.out.print("2. z=++y*x: ");
		System.out.println("z=" + z + " y=" + y);
	}
}