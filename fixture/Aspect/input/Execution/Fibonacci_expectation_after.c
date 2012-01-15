int fibonacci(int n) {
	if (n < 2) {
		{
			printf("Inserted after.");
		}
		return n;
	}
	else {
		{
			printf("Inserted after.");
		}
		return fibonacci(n - 1) + fibonacci(n - 2);
	}
}
