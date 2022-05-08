string? fractionInput = Console.ReadLine();

if (fractionInput is null) return;

string[] fractionParts = fractionInput.Split('/', StringSplitOptions.RemoveEmptyEntries);

if (fractionParts.Length != 2) return;

long numerator = long.Parse(fractionParts[0]);
long denominator = long.Parse(fractionParts[1]);

if (numerator >= denominator)
{
    Console.WriteLine("Error (fraction is equal to or greater than 1)");
    return;
}

HashSet<string> addedFractions = new();

long index = 2;

while (numerator != 0)
{
    long nextNumerator = numerator * index;
    long indexNumerator = denominator;

    long remaining = nextNumerator - indexNumerator;

    if (remaining < 0)
    {
        index++;
        continue;
    }

    numerator = remaining;
    denominator *= index;

    addedFractions.Add($"1/{index}");
    index++;
}

string addedFractionsOutput = string.Join(" + ", addedFractions);

Console.WriteLine($"{fractionInput} = {addedFractionsOutput}");