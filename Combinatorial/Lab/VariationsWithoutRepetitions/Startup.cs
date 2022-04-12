string? elementsInput = Console.ReadLine();

if (elementsInput is null) return;

char[] elements = elementsInput.Split(new[] { ' ' }).Select(char.Parse).ToArray();

if (!int.TryParse(Console.ReadLine(), out int variationsLength)) return;

char[] variations = new char[variationsLength];
bool[] used = new bool[elements.Length];

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
            if (used[i]) continue;

            used[i] = true;

            variations[index] = elements[i];
            Variate(index + 1);

            used[i] = false;
        }
    }
}
