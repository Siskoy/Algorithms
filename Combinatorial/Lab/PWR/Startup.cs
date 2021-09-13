namespace PWR
{
    using System;
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
                Permute(index + 1);

                for (int i = index + 1; i < elements.Length; i++)
                {
                    Swap(index, i);
                    Permute(index + 1);
                    Swap(index, i);
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
