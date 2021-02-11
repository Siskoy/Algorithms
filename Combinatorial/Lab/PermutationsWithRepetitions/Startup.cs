namespace PermutationsWithRepetitions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static char[] elements;

        private static void Swap(int first, int second)
        {
            char temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

        private static void Permute(int index)
        {
            if (index == elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                var swapped = new HashSet<char>();

                for (int i = index; i < elements.Length; i++)
                {
                    if (swapped.Contains(elements[i])) continue;

                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);

                    swapped.Add(elements[i]);
                }
            }
        }

        public static void Main()
        {
            elements = Console.ReadLine()?.Split(new[] { ' ' }).Select(char.Parse).ToArray();

            if (elements is null) return;

            Permute(0);
        }
    }
}