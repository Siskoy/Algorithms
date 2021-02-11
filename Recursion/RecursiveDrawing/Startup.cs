namespace RecursiveDrawing
{
    using System;
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

            int number = int.Parse(input);

            if (number < 0)
            {
                Console.WriteLine(LessThanZeroMessage);
                return;
            }

            int n = int.Parse(input);

            PrintFigure(n);
        }

        private static void PrintFigure(int n)
        {
            if (n == 0)
            {
                return;
            }

            Console.WriteLine(new string('*', n));

            PrintFigure(n - 1);

            Console.WriteLine(new string('#', n));
        }
    }
}