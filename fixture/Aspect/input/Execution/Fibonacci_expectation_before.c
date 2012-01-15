int fibonacci(int n) {
	{
		printf("Inserted before.");
	}
	if (n < 2) {
		return n;
	}
	else {
		return fibonacci(n - 1) + fibonacci(n - 2);
	}
}
