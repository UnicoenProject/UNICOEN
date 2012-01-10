public class Fibonacci {
	public static int fibonacci(int n)
	{
		if (n < 2) {
			{
				Console.WriteLine("Inserted after.");
			}
			return n;
		}
		else {
			{
				Console.WriteLine("Inserted after.");
			}
			return fibonacci(n - 1) + fibonacci(n - 2);
		}
	}
}

