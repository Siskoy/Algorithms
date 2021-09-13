namespace EightQueenProblem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private const int BoardSize = 8;
        private static readonly char[,] Chessboard = new char[BoardSize, BoardSize];
        private static int solutionsCount;
        private static readonly HashSet<Position> AttackedPositions = new();

        public static void Main()
        {
            InitializeBoard();
            WriteSolutionDelimiter();
            GenerateEightQueenPuzzleSolutions(0);

            Console.WriteLine($"{new string(' ', 6)}Solutions count found: {solutionsCount}");
        }

        private static void InitializeBoard()
        {
            for (int row = 0; row < Chessboard.GetLength(0); row++)
            {
                for (int col = 0; col < Chessboard.GetLength(1); col++)
                {
                    Chessboard[row, col] = '*';
                }
            }
        }

        private static void GenerateEightQueenPuzzleSolutions(int row)
        {
            if (IsSolution(row))
            {
                PrintSolution();
                solutionsCount++;
            }
            else
            {
                for (int col = 0; col < Chessboard.GetLength(1); col++)
                {
                    var position = new Position(row, col);

                    if (CanPlaceQueen(position) == false) continue;

                    MarkPosition(position);
                    GenerateEightQueenPuzzleSolutions(row + 1);
                    UnmarkPosition(position);
                }
            }
        }

        private static bool IsSolution(int row) => row == Chessboard.GetLength(0);

        private static void UnmarkPosition(Position position)
        {
            Chessboard[position.Row, position.Col] = '*';
            AttackedPositions.Remove(position);
        }

        private static void MarkPosition(Position position)
        {
            Chessboard[position.Row, position.Col] = 'Q';
            AttackedPositions.Add(position);
        }

        private static bool CanPlaceQueen(Position position)
             => (IsVerticalAttacked(position.Col) 
              || IsHorizontalAttacked(position.Row) 
              || AreDiagonalsAttacked(position)) == false;

        private static bool AreDiagonalsAttacked(Position position)
            => IsLeftDiagonalAttacked(position) || IsRightDiagonalAttacked(position);

        private static bool IsRightDiagonalAttacked(Position position)
            => AttackedPositions.Any(p => p.Row - p.Col == position.Row - position.Col);

        private static bool IsLeftDiagonalAttacked(Position position) 
            => AttackedPositions.Any(p => p.Row + p.Col == position.Row + position.Col);

        private static bool IsHorizontalAttacked(int row) => AttackedPositions.Any(p => p.Row == row);

        private static bool IsVerticalAttacked(int col) => AttackedPositions.Any(p => p.Col == col);

        private static void PrintSolution()
        {
            for (int row = 0; row < Chessboard.GetLength(0); row++)
            {
                Console.Write(new string(' ', 10));

                for (int col = 0; col < Chessboard.GetLength(1); col++)
                {
                    Console.Write(" " + Chessboard[row, col]);
                }

                Console.WriteLine();
            }

            WriteSolutionDelimiter();
        }

        private static void WriteSolutionDelimiter()
            => Console.WriteLine($"{Environment.NewLine}{new string(' ', 5)}{new string('=', 27)}{Environment.NewLine}");
    }
}
