namespace VariationsWithoutRepetitions
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static char[] elements;
        private static char[] variations;
        private static bool[] used;

        private static void Variate(int index)
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

        public static void Main()
        {
            elements = Console.ReadLine()?.Split(new[] { ' ' }).Select(char.Parse).ToArray();

            if (elements is null) return;

            if (!int.TryParse(Console.ReadLine(), out int variationsLength)) return;

            variations = new char[variationsLength];
            used = new bool[elements.Length];

            Variate(0);
        }
    }
}
