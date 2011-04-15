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
		boolean bln = (d == Double.POSITIVE_INFINITY); // bln には true が代入される
		float x = 0;
		boolean b1 = x < Float.NaN;
		boolean bb = x > Float.NaN;
		boolean b3 = x <= Float.NaN;
		boolean b4 = x >= Float.NaN;
		boolean b5 = x == Float.NaN;
		boolean b6 = x != Float.NaN; // x の値によらず全て false が返る
		boolean bln2 = Float.isNaN(x); // float 型変数 x の値が NaN ならば true
		bln = Double.isNaN(d); // double 型変数 y の値が NaN ならば true
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
		System.out.println("算術演算子");
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
		System.out.println("再帰的代入文");
		System.out.println("x=" + x + " y=" + y);
		System.out.print("x+=y:" + (x += y));
		System.out.println("  x=" + x);
		System.out.print("x*=y+10:" + (x *= y + 10));
		System.out.println("  x=" + x);
		System.out.println("	※x=x*(y+10)と解釈される");
		System.out.print("x%=y:" + (x %= y));
		System.out.println("  x=" + x);
	}
}

class TestOperator3 {
	public static void main(String[] args) {
		int x = 10, y = 3, z = 0;
		System.out.println("インクリメント／デクリメント演算子");
		// 後置インクリメント演算子
		x = 10;
		y = 3;
		System.out.println("x=" + x + " y=" + y);
		z = y++ * x;
		System.out.print("1. z=y++*x: ");
		System.out.println("z=" + z + " y=" + y);
		// 前置インクリメント演算子
		x = 10;
		y = 3;
		System.out.println("x=" + x + " y=" + y);
		z = ++y * x;
		System.out.print("2. z=++y*x: ");
		System.out.println("z=" + z + " y=" + y);
	}
}