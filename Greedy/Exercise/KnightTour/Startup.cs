using static KnightTour.Methods;

string? boardSizeInput = Console.ReadLine();

if (boardSizeInput is null) return;

int boardSize = int.Parse(boardSizeInput);

int[,] movesCountBoard = InitializeMovesCountBoard(boardSize);

int[,] knightsTour = KnightsTour(movesCountBoard);

PrintBoard(knightsTour);