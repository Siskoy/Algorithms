string? input = Console.ReadLine();

if (input is null) return;

int[] sequence = input.Split(' ').Select(int.Parse).ToArray();
int[] lis = new int[sequence.Length];
int[] steps = new int[sequence.Length];

lis[0] = 1;
steps[0] = -1;

for (int i = 1; i < sequence.Length; i++)
{
    steps[i] = -1;

    var solution = 0;

    for (int j = 0; j < i; j++)
    {
        int prevSolution = lis[j];

        if (sequence[i] > sequence[j]
            && solution < prevSolution)
        {
            solution = prevSolution;
            steps[i] = j;
        }
    }

    lis[i] = solution + 1;
}

int maxValue = lis.Max();
int maxIndex = Array.IndexOf(lis, maxValue);

List<int> result = new(maxValue);   

int currentIndex = maxIndex;

while (currentIndex != -1)
{
    var number = sequence[currentIndex];

    result.Add(number);

    currentIndex = steps[currentIndex];
}

result.Reverse();

Console.WriteLine(string.Join(" ", result));