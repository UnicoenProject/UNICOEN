
public class Binary {
	public static void Main(string[] args) {
		System.Console.WriteLine(CalcA() + CalcB());
	}

	public static int CalcA() {
		int a = 1 + 2;
		int b = a - 3;
		int c = b * 4;
		int d = c / 5;
		int f = d % 6;
		int g = f << 7;
		int h = f >> 8;
		int i = h & 9;
		int j = i | 10;
		int k = j ^ 11;
		int m = (++k) + (k++) + (--k) + (k--) + ~k;

		if ((m == 0 && (m != 1)) || (m > 0 && m < 0) || !(m <= 0 && m >= 0))
			return -m;
		else
			return +m;
	}

	public static int CalcB() {
		int a = (1 + 2) * (3 + 4);
		int b = 1 + 2 * 3 + 4;
		int c = 1 * (2 * 3) + 4;
		if (a == b && b == c)
			return 0;
		else
			return 1;
	}

	public int CalcC() {
		int a = 0;
		a += 1;
		a -= 2;
		a *= 3;
		a /= 4;
		a %= 5;
		a <<= 6;
		a >>= 7;
		a &= 8;
		a |= 9;
		a ^= 10;
		return a > 0 ? a : -a;
	}
}

