string? input = Console.ReadLine();

if (input is null) return;

char[] elements = input.Split(new[] { ' ' }).Select(char.Parse).ToArray();

if (!int.TryParse(Console.ReadLine(), out int combinationsLength)) return;

char[] combinations = new char[combinationsLength];

Combine(0, 0);

void Combine(int index, int start)
{
    if (index == combinations.Length)
    {
        Console.WriteLine(string.Join(" ", combinations));
    }
    else
    {
        for (int i = start; i < elements.Length; i++)
        {
            combinations[index] = elements[i];
            Combine(index + 1, i);
        }
    }
}
