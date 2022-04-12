string? input = Console.ReadLine();

if (input is null) return;

char[] elements = input.Split(new[] { ' ' }).Select(char.Parse).ToArray();

Permute(0);

void Swap(int first, int second)
{
    (elements[second], elements[first]) = (elements[first], elements[second]);
}

void Permute(int index)
{
    if (index == elements.Length)
    {
        Console.WriteLine(string.Join(" ", elements));
    }
    else
    {
        Permute(index + 1);

        for (int i = index + 1; i < elements.Length; i++)
        {
            Swap(index, i);
            Permute(index + 1);
            Swap(index, i);
        }
    }
}
