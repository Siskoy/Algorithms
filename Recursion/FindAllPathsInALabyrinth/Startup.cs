namespace FindAllPathsInALabyrinth
{
    using System;
    using System.Collections.Generic;
    using Common;
    using static Common.Messages;

    public class Startup
    {
        private static char[][] labyrinth;
        private static readonly List<char> Directions = new();

        public static void Main()
        {
            ReadLabyrinth();
            FindAllPaths(0, 0, 'S');
        }

        private static void ReadLabyrinth()
        {
            string input = Console.ReadLine() ?? string.Empty;

            if (Validator.IsNumber(input) == false)
            {
                Console.WriteLine(NaNMessage);
                return;
            }

            int rowsLength = int.Parse(input);

            if (rowsLength < 0)
            {
                Console.WriteLine(LessThanZeroMessage);
                return;
            }

            labyrinth = new char[rowsLength][];

            for (int row = 0; row < rowsLength; row++)
            {
                labyrinth[row] = Console.ReadLine()?.ToCharArray();
            }
        }

        private static void FindAllPaths(int row, int col, char direction)
        {
            if (!IsInBounds(row, col))
            {
                return;
            }

            Directions.Add(direction);

            if (IsExit(row, col))
            {
                PrintSolution();
            }
            else if (IsPassable(row, col))
            {
                labyrinth[row][col] = 'x';

                FindAllPaths(row + 1, col, 'D');
                FindAllPaths(row - 1, col, 'U');
                FindAllPaths(row, col + 1, 'R');
                FindAllPaths(row, col - 1, 'L');

                labyrinth[row][col] = '-';
            }

            Directions.RemoveAt(Directions.Count - 1);
        }

        private static void PrintSolution() => Console.WriteLine(string.Join(string.Empty, Directions).TrimStart('S'));

        private static bool IsPassable(int row, int col) => labyrinth[row][col] == '-';

        private static bool IsExit(int row, int col) => labyrinth[row][col] == 'e';

        private static bool IsInBounds(int row, int col)
            => row < labyrinth.Length
            && row >= 0
            && col < labyrinth[row].Length
            && col >= 0;
    }
}
