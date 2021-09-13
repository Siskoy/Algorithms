namespace EightQueenProblem
{
    public readonly struct Position
    {
        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public readonly int Row;

        public readonly int Col;
    }
}
