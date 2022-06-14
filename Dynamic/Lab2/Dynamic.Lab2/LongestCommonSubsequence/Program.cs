string? firstSequence = Console.ReadLine();
string? secondSequence = Console.ReadLine();

if (firstSequence is null || secondSequence is null) return;

int[,] lcs = new int[firstSequence.Length + 1, secondSequence.Length + 1];

for (int i = 1; i < lcs.GetLength(0); i++)
{
    for (int j = 1; j < lcs.GetLength(1); j++)
    {
        bool areLastCharsEqual = firstSequence[i - 1] == secondSequence[j - 1];

        if (areLastCharsEqual)
        {
            lcs[i, j] = lcs[i - 1, j - 1] + 1;
        }
        else
        {
            lcs[i, j] = Math.Max(lcs[i - 1, j], lcs[i, j - 1]);
        }
    }
}

string sequence = string.Empty;

int row = lcs.GetLength(0) - 1;
int col = lcs.GetLength(1) - 1;

while (row > 0 && col > 0)
{
    if (firstSequence[row - 1] == secondSequence[col - 1])
    {
        sequence += firstSequence[row - 1];
        row--;
        col--;
    }
    else if (lcs[row, col] == lcs[row - 1, col])
    {
        row--;
    }
    else
    {
        col--;
    }
}

Console.WriteLine(sequence.Length);
