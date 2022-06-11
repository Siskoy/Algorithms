using System;
using System.Collections.Generic;
using System.Linq;

namespace Snakes
{
    public class Program
    {
        private static char[] snake;
        private static HashSet<string> usedSnakes;
        private static HashSet<string> visitedCells;
        private static HashSet<string> result;

        public static void Main(string[] args)
        {
            string snakeLengthInput = Console.ReadLine();

            if (snakeLengthInput == null) return;

            int snakeLength = int.Parse(snakeLengthInput);

            snake = new char[snakeLength];
            usedSnakes = new HashSet<string>();
            visitedCells = new HashSet<string>();
            result = new HashSet<string>();

            snake[0] = 'S';

            visitedCells.Add("0-0");

            Generate(1, 0, 1, 'R');

            foreach (var snake in result)
            {
                Console.WriteLine(snake);
            }

            Console.WriteLine($"Snakes count = {result.Count}");
        }

        static void Generate(int index, int row, int col, char direction)
        {
            if (index >= snake.Length)
            {
                MarkSnake();
                return;
            }

            var cell = $"{row}-{col}";

            if (visitedCells.Contains(cell) == false)
            {
                snake[index] = direction;

                visitedCells.Add(cell);

                Generate(index + 1, row, col + 1, 'R');
                Generate(index + 1, row + 1, col, 'D');
                Generate(index + 1, row, col - 1, 'L');
                Generate(index + 1, row - 1, col, 'U');

                visitedCells.Remove(cell);
            }
        }

        static void MarkSnake()
        {
            var normalSnake = new string(snake);

            if (usedSnakes.Contains(normalSnake)) return;

            result.Add(normalSnake);

            var flippedSnake = Flip(normalSnake);
            var reversedSnake = Reverse(normalSnake);
            var flippedReversedSnake = Reverse(flippedSnake);

            for (int i = 0; i < 4; i++)
            {
                usedSnakes.Add(normalSnake);
                normalSnake = Rotate(normalSnake);

                usedSnakes.Add(flippedSnake);
                flippedSnake = Rotate(flippedSnake);

                usedSnakes.Add(reversedSnake);
                reversedSnake = Rotate(reversedSnake);

                usedSnakes.Add(flippedReversedSnake);
                flippedReversedSnake = Rotate(flippedReversedSnake);
            }
        }

        static string Flip(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'D': newSnake[i] = 'U'; break;
                    case 'U': newSnake[i] = 'D'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }

        static string Reverse(string snake)
        {
            var newSnake = new char[snake.Length];

            newSnake[0] = 'S';

            for (int i = 1; i < snake.Length; i++)
            {
                newSnake[snake.Length - i] = snake[i];
            }

            return new string(newSnake);
        }

        static string Rotate(string snake)
        {
            var newSnake = new char[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                switch (snake[i])
                {
                    case 'R': newSnake[i] = 'D'; break;
                    case 'D': newSnake[i] = 'L'; break;
                    case 'L': newSnake[i] = 'U'; break;
                    case 'U': newSnake[i] = 'R'; break;
                    default: newSnake[i] = snake[i]; break;
                }
            }

            return new string(newSnake);
        }
    }
}
