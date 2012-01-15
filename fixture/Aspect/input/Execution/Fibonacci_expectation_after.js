function fibonacci(n) {
	if (n < 2) {
		{
			Console.log("Inserted after.");
		}
		return n;
	}
	else {
		{
			Console.log("Inserted after.");
		}
		return fibonacci(n - 1) + fibonacci(n - 2);
	}
}
