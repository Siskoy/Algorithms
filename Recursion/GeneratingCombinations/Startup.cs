namespace GeneratingCombinations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
    using static Common.Messages;

    public class Startup
    {
        public static void Main()
        {
            int[] array = Console
                .ReadLine()
                ?.Split(new[] { ' ' })
                .Select(int.Parse)
                .ToArray();

            string input = Console.ReadLine() ?? string.Empty;

            if (Validator.IsNumber(input) == false)
            {
                Console.WriteLine(NaNMessage);
                return;
            }

            int setCount = int.Parse(input);

            if (setCount < 0)
            {
                Console.WriteLine(LessThanZeroMessage);
                return;
            }

            GenerateCombinations(array, new int[setCount], 0, 0);
        }

        private static void GenerateCombinations(
            IReadOnlyList<int> set,
            IList<int> vector,
            int index,
            int border)
        {
            if (index >= vector.Count)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < set.Count; i++)
            {
                vector[index] = set[i];
                GenerateCombinations(set, vector, index + 1, i + 1);
            }
        }
    }
}
