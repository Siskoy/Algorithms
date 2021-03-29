namespace Generating0Or1Vectors
{
    using System;
    using System.Collections.Generic;
    using Common;
    using static Common.Messages;

    public class Startup
    {
        public static void Main()
        {
            string input = Console.ReadLine() ?? string.Empty;

            if (Validator.IsNumber(input) == false)
            {
                Console.WriteLine(NaNMessage);
                return;
            }

            int index = int.Parse(input);

            if (index < 0)
            {
                Console.WriteLine(LessThanZeroMessage);
                return;
            }

            GenerateVectors(new int[index], 0);
        }

        private static void GenerateVectors(IList<int> vector, int index)
        {
            if (index > vector.Count - 1)
            {
                Console.WriteLine(string.Join("", vector));
                return;
            }

            for (int j = 0; j <= 1; j++)
            {
                vector[index] = j;
                GenerateVectors(vector, index + 1);
            }
        }
    }
}
