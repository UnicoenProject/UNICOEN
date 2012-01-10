public class Fibonacci {
	public static int fibonacci(int n) {
		{
			Console.WriteLine("Inserted before.");
		}
		if (n < 2) {
			return n;
		}
		else {
			return fibonacci(n - 1) + fibonacci(n - 2);
		}
	}
}

