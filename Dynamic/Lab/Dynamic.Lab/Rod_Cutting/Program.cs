string? ropeInput = Console.ReadLine();
string? ropeLengthInput = Console.ReadLine();

if (ropeInput is null || ropeLengthInput is null) return;

int[] rope = ropeInput.Split(" ").Select(int.Parse).ToArray();
int ropeLength = int.Parse(ropeLengthInput);

int[] bestPrice = new int[ropeLength + 1];
int[] bestCombo = new int[ropeLength + 1];

for (int i = 1; i <= ropeLength; i++)
{
    int currentBest = bestPrice[i];

    for (int j = 1; j <= i; j++)
    {
        currentBest = Math.Max(currentBest, rope[j] + bestPrice[i - j]);

        if (currentBest > bestPrice[i])
        {
            bestPrice[i] = currentBest;
            bestCombo[i] = j;
        }
    }
}

Console.WriteLine(bestPrice[ropeLength]);

while (ropeLength  - bestCombo[ropeLength] != 0)
{
    Console.Write(bestCombo[ropeLength] + " ");

    ropeLength -= bestCombo[ropeLength];
}

Console.WriteLine(bestCombo[ropeLength]);
