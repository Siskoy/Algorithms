using System.Text.Json;

string? snakeLengthInput = Console.ReadLine();

if (snakeLengthInput is null) return;

int snakeLength = int.Parse(snakeLengthInput);

List<char> snake = new(snakeLength);
HashSet<Position> currentPositions = new(snakeLength);
HashSet<string> usedPositions = new();
int snakeCount = 0;

snake.Add('S');
currentPositions.Add(new Position());

Position startPosition = new(0, 1);

snake.Add('R');
currentPositions.Add(startPosition);

Generate(startPosition);

Console.WriteLine($"Snakes count = {snakeCount}");

void Generate(Position position)
{
    if (currentPositions.Count == snakeLength)
    {
        if (IsValid())
        {
            Console.WriteLine(string.Join("", snake));
            snakeCount++;
        }

        return;
    }

    if (TryMoveRight(position, out Position nextPosition))
    {
        Generate(nextPosition);
        Clear(nextPosition);
    }
    if (TryMoveDown(position, out nextPosition))
    {
        Generate(nextPosition);
        Clear(nextPosition);
    }
    if (TryMoveLeft(position, out nextPosition))
    {
        Generate(nextPosition);
        Clear(nextPosition);
    }
    if (TryMoveUp(position, out nextPosition))
    {
        Generate(nextPosition);
        Clear(nextPosition);
    }
}

bool TryMoveRight(Position position, out Position nextPosition)
{
    Position tempPosition = new(position.X + 1, position.Y);

    if (currentPositions.Contains(tempPosition))
    {
        nextPosition = default;
        return false;
    }

    snake.Add('R');
    currentPositions.Add(tempPosition);
    nextPosition = tempPosition;

    return true;
}

bool TryMoveDown(Position position, out Position nextPosition)
{
    Position tempPosition = new(position.X, position.Y - 1);

    if (currentPositions.Contains(tempPosition))
    {
        nextPosition = default;
        return false;
    }

    snake.Add('D');
    currentPositions.Add(tempPosition);
    nextPosition = tempPosition;

    return true;
}

bool TryMoveLeft(Position position, out Position nextPosition)
{
    Position tempPosition = new(position.X - 1, position.Y);

    if (currentPositions.Contains(tempPosition))
    {
        nextPosition = default;
        return false;
    }

    snake.Add('L');
    currentPositions.Add(tempPosition);
    nextPosition = tempPosition;

    return true;
}

bool TryMoveUp(Position position, out Position nextPosition)
{
    Position tempPosition = new(position.X, position.Y + 1);

    if (currentPositions.Contains(tempPosition))
    {
        nextPosition = default;
        return false;
    }

    snake.Add('U');
    currentPositions.Add(tempPosition);
    nextPosition = tempPosition;

    return true;
}

bool IsValid()
{
    if (usedPositions.Contains(SnakeToString(currentPositions))) return false;

    var normalSnake = currentPositions.ToArray();
    var flippedSnake = Flip(normalSnake);
    var reversedSnake = Reverse(normalSnake);
    var flippedReversedSnake = Reverse(flippedSnake);

    for (int i = 0; i < 4; i++)
    {
        usedPositions.Add(SnakeToString(normalSnake));
        normalSnake = Rotate(normalSnake);

        usedPositions.Add(SnakeToString(flippedSnake));
        flippedSnake = Rotate(flippedSnake);

        usedPositions.Add(SnakeToString(reversedSnake));
        reversedSnake = Rotate(reversedSnake);

        usedPositions.Add(SnakeToString(flippedReversedSnake));
        flippedReversedSnake = Rotate(flippedReversedSnake);
    }

    return true;
}

Position[] Flip(Position[] snake)
{
    Position[] result = new Position[snake.Length];

    result[0] = snake[0];

    for (int i = 1; i < snake.Length; i++)
    {
        var position = snake[i];
        var prevPosition = snake[i - 1];

        if (position.Y > prevPosition.Y)
        {
            result[i] = new Position(result[i - 1].X, result[i - 1].Y - 1);
        }
        else if (position.Y < prevPosition.Y)
        {
            result[i] = new Position(result[i - 1].X, result[i - 1].Y + 1);
        }
        else
        {
            result[i] = new Position(position.X, result[i - 1].Y);
        }
    }

    return result;
}

Position[] Reverse(Position[] snake)
{
    Position[] result = new Position[snake.Length];

    result[0] = snake[0];

    for (int i = 1; i < snake.Length; i++)
    {
        var position = snake[^i];
        var prevPosition = snake[snake.Length - i - 1];

        if (position.X > prevPosition.X)
        {
            result[i] = new Position(result[i - 1].X + 1, result[i - 1].Y);
        }
        else if (position.X < prevPosition.X)
        {
            result[i] = new Position(result[i - 1].X - 1, result[i - 1].Y);
        }
        else if (position.Y > prevPosition.Y)
        {
            result[i] = new Position(result[i - 1].X, result[i - 1].Y + 1);
        }
        else if (position.Y < prevPosition.Y)
        {
            result[i] = new Position(result[i - 1].X, result[i - 1].Y - 1);
        }
    }

    return result;
}

Position[] Rotate(Position[] snake)
{
    Position[] result = new Position[snake.Length];

    for (int i = 0; i < snake.Length; i++)
    {
        var position = snake[i];

        if (position.X >= 0 && position.Y <= 0)
        {
            result[i] = new Position(Math.Abs(position.Y), position.X);
        }
        else if (position.X >= 0 && position.Y >= 0)
        {
            result[i] = new Position(-position.Y, position.X);
        }
        else if (position.X <= 0 && position.Y >= 0)
        {
            result[i] = new Position(-position.Y, position.X);
        }
        else if (position.X <= 0 && position.Y <= 0)
        {
            result[i] = new Position(Math.Abs(position.Y), position.X);
        }
    }

    return result;
}

void Clear(Position position)
{
    currentPositions.Remove(position);
    snake.RemoveAt(snake.Count - 1);
}

string SnakeToString(IEnumerable<Position> snake) => JsonSerializer.Serialize(snake);

struct Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; init; }

    public int Y { get; init; }
}
