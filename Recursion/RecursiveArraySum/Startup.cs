namespace RecursiveArraySum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            int[] array = Console
                .ReadLine()
                ?.Split(' ')
                .Select(int.Parse)
                .ToArray();

            int sum = Sum(array, 0);

            Console.WriteLine(sum);
        }

        private static int Sum(IReadOnlyList<int> array, int index)
        {
            if (index + 1 == array.Count)
            {
                return array[index];
            }

            return array[index] + Sum(array, index + 1);
        }
    }
}
