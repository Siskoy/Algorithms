namespace Factorial
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

            int result = Factorial(number);

            Console.WriteLine(result);
        }

        private static int Factorial(int number)
        {
            if (number == 0)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
    }
}
