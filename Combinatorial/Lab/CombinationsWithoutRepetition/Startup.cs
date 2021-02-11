namespace CombinationsWithoutRepetition
{
    using System;
    using System.Linq;

    public class Startup
    {
        private static char[] elements;
        private static char[] combinations;

        private static void Combine(int index, int start)
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

        public static void Main()
        {
            elements = Console.ReadLine()?.Split(new[] { ' ' }).Select(char.Parse).ToArray();

            if (elements is null) return;

            if (!int.TryParse(Console.ReadLine(), out int combinationsLength)) return;

            combinations = new char[combinationsLength];

            Combine(0, 0);
        }
    }
}