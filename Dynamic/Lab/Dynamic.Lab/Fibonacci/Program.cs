string? input = Console.ReadLine();

if (string.IsNullOrWhiteSpace(input)) return;

int n = int.Parse(input);

long[] found = new long[n + 1];

long result = Fibonacci(n);

Console.WriteLine(result);

long Fibonacci(int n)
{
    if (found[n] != default) return found[n];

    if (n == 0 || n == 1) return n;

    long result = Fibonacci(n - 1) + Fibonacci(n - 2);

    found[n] = result;

    return result;
}
