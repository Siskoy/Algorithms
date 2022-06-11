namespace KnightTour
{
    public class Methods
    {
        public static void PrintBoard(int[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(board[row, col].ToString().PadLeft(3) + " ");
                }

                Console.WriteLine();
            }
        }

        public static int[,] InitializeMovesCountBoard(int boardSize)
        {
            int[,] movesCountBoard = new int[boardSize, boardSize];

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    var possibleMoves = GetKnightMoves(row, col, boardSize);

                    foreach (var move in possibleMoves)
                    {
                        movesCountBoard[move[0], move[1]]++;
                    }
                }
            }

            return movesCountBoard;
        }

        public static int[,] KnightsTour(int[,] movesCountBoard)
        {
            int boardSize = movesCountBoard.GetLength(0);

            bool[,] visited = new bool[boardSize, boardSize];
            int[,] board = new int[boardSize, boardSize];

            int step = 1;

            board[0, 0] = step;
            visited[0, 0] = true;

            int row = 0;
            int col = 0;

            while (true)
            {
                var possibleMoves = GetKnightMoves(row, col, boardSize)
                    .Where(x => visited[x[0], x[1]] == false);

                foreach (var possibleMove in possibleMoves)
                {
                    movesCountBoard[possibleMove[0], possibleMove[1]]--;
                }

                var move = possibleMoves
                    .OrderBy(x => movesCountBoard[x[0], x[1]])
                    .FirstOrDefault();

                if (move is null) break;

                row = move[0];
                col = move[1];

                board[row, col] = ++step;
                visited[row, col] = true;
            }

            return board;
        }

        private static IEnumerable<int[]> GetKnightMoves(int row, int col, int boardSize)
        {
            List<int[]> knightMoves = new();

            // Right down
            int rightDownRow = row + 1;
            int rightDownCol = col + 2;

            if (rightDownRow < boardSize && rightDownCol < boardSize)
                knightMoves.Add(new int[] { rightDownRow, rightDownCol });

            // Right up
            int rightUpRow = row - 1;
            int rightUpCol = col + 2;

            if (rightUpRow > -1 && rightUpCol < boardSize)
                knightMoves.Add(new int[] { rightUpRow, rightUpCol });

            // Left down
            int leftDownRow = row + 1;
            int leftDownCol = col - 2;

            if (leftDownRow < boardSize && leftDownCol > -1)
                knightMoves.Add(new int[] { leftDownRow, leftDownCol });

            // Left up
            int leftUpRow = row - 1;
            int leftUpCol = col - 2;

            if (leftUpRow > -1 && leftUpCol > -1)
                knightMoves.Add(new int[] { leftUpRow, leftUpCol });

            // Down right
            int downRightRow = row + 2;
            int downRightCol = col + 1;

            if (downRightRow < boardSize && downRightCol < boardSize)
                knightMoves.Add(new int[] { downRightRow, downRightCol });

            // Down left
            int downLeftRow = row + 2;
            int downLeftCol = col - 1;

            if (downLeftRow < boardSize && downLeftCol > -1)
                knightMoves.Add(new int[] { downLeftRow, downLeftCol });

            // Up right
            int upRightRow = row - 2;
            int upRightCol = col + 1;

            if (upRightRow > -1 && upRightCol < boardSize)
                knightMoves.Add(new int[] { upRightRow, upRightCol });

            // Up left
            int upLeftRow = row - 2;
            int upLeftCol = col - 1;

            if (upLeftRow > -1 && upLeftCol > -1)
                knightMoves.Add(new int[] { upLeftRow, upLeftCol });

            return knightMoves;
        }
    }
}
