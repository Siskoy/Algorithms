namespace VariationsWithRepetition
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static char[] elements;
        private static char[] variations;

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
                    variations[index] = elements[i];
                    Variate(index + 1);
                }
            }
        }

        public static void Main()
        {
            elements = Console.ReadLine()?.Split(new[] { ' ' }).Select(char.Parse).ToArray();

            if (elements is null) return;

            if (!int.TryParse(Console.ReadLine(), out int variationsLength)) return;

            variations = new char[variationsLength];

            Variate(0);
        }
    }
}