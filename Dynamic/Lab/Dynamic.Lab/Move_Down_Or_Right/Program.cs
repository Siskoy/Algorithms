string? inputN = Console.ReadLine();
string? inputM = Console.ReadLine();

if (inputN is null || inputM is null) return;

int n = int.Parse(inputN);
int m = int.Parse(inputM);

int[,] matrix = new int[n, m];

for (int row = 0; row < n; row++)
{
    string? valuesInput = Console.ReadLine();

    if (valuesInput is null) return;

    int[] values = valuesInput.Split(" ").Select(int.Parse).ToArray();

    if (values.Length != m) return;

    for (int col = 0; col < m; col++)
    {
        matrix[row, col] = values[col];
    }
}

for (int row = 1; row < n; row++)
{
    matrix[row, 0] += matrix[row - 1, 0];
}

for (int col = 1; col < m; col++)
{
    matrix[0, col] += matrix[0, col - 1];
}

for (int row = 1; row < n; row++)
{
    for (int col = 1; col < m; col++)
    {
        int leftSum = matrix[row, col - 1];
        int upSum = matrix[row - 1, col];

        matrix[row, col] += Math.Max(upSum, leftSum);
    }
}

PrintResult();

void PrintResult()
{
    List<string> result = new();

    int row = n - 1;
    int col = m - 1;

    int currSum = matrix[row, col];
    result.Add($"[{row}, {col}]");

    while (row > 0 || col > 0)
    {
        if (row - 1 < 0)
        {
            col--;
        }
        else if (col - 1 < 0)
        {
            row--;
        }
        else
        {
            int leftSum = matrix[row, col - 1];
            int upSum = matrix[row - 1, col];

            if (upSum > leftSum)
            {
                row--;
            }
            else
            {
                col--;
            }
        }

        currSum = matrix[row, col];
        result.Add($"[{row}, {col}]");
    }

    result.Reverse();

    Console.WriteLine(string.Join(" ", result));
}
