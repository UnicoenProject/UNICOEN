def fibonacci(n)
  if (n < 2)
    return n
  else
    fibonacci(n - 1) + fibonacci(n - 2)
  end
end
