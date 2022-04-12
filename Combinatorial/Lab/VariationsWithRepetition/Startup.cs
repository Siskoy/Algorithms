string? input = Console.ReadLine();

if (input is null) return;

char[] elements = input.Split(new[] { ' ' }).Select(char.Parse).ToArray();

if (!int.TryParse(Console.ReadLine(), out int variationsLength)) return;

char[] variations = new char[variationsLength];

Variate(0);

void Variate(int index)
{
    if (index == variations.Length)
    {
        Console.WriteLine(string.Join(" ", variations));
    }
    else
    {
        for (int i = 0; i < elements.Length; i++)
        {
            variations[index] = elements[i];
            Variate(index + 1);
        }
    }
}
