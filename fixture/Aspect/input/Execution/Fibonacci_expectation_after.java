public class Fibonacci {
	public int fibonacci(int n) {
		if(n < 2) {
			{
				System.out.println("Inserted after.");
			}
			return n;
		}
		else {
			{
				System.out.println("Inserted after.");
			}
			return fibonacci(n - 1) + fibonacci(n - 2);
		}
	}
}