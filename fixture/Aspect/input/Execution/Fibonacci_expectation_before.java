public class Fibonacci {
	public int fibonacci(int n) {
		{
			System.out.println("Inserted before.");
		}
		if(n < 2) {
			return n;
		}
		else {
			return fibonacci(n - 1) + fibonacci(n - 2);
		}
	}
}