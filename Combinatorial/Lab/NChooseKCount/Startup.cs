using System.Numerics;

string? inputN = Console.ReadLine();
string? inputK = Console.ReadLine();

if (inputN is null || inputK is null) return;

if (int.TryParse(inputN, out var n) == false)
{
    throw new ArgumentException("N is not an number!");
}

if (int.TryParse(inputK, out var k) == false)
{
    throw new ArgumentException("K is not an number");
}

BigInteger combinations = Factorial(n) / (Factorial(k) * Factorial(n - k));

Console.WriteLine(combinations);

static BigInteger Factorial(int n)
{
    BigInteger factorial = 1;

    for (int i = 2; i <= n; i++)
    {
        factorial *= i;
    }

    return factorial;
}
