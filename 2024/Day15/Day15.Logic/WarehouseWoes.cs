







namespace Day15.Logic;

public class WarehouseWoes
{
    private string _input;

    public int Size { get; private set; }

    private char[,] _map;
    private char[] _movements;

    public int Count => _movements.Length;

    public (int X, int Y) Position { get; private set; }
    public int SumOfGpsCoordinates { get; private set; }

    public WarehouseWoes(string input)
    {
        _input = input;
        Parse();
    }

    private void Parse()
    {
        var sections = _input.Split("\n\n");
        var lines = sections[0].Split('\n');
        Size = lines.Length;

        _map = new char[Size, Size];
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                switch (lines[y][x])
                {
                    case '@':
                        Position = (x, y);
                        _map[y, x] = '.';
                        break;

                    default:
                        _map[y, x] = lines[y][x];
                        break;
                }
            }
        }

        _movements = string.Concat(sections[1].Split('\n')).ToCharArray();
    }

    public void Execute()
    {
        foreach (var movement in _movements)
        {
            switch (movement)
            {
                case '<':
                    if (CanMoveLeft(Position.X, Position.Y))
                    {
                        MoveBoxesLeft(Position.X, Position.Y);
                        Position = (Position.X - 1, Position.Y);
                    }
                    break;
                case '^':
                    if (_map[Position.Y-1, Position.X] == '.')
                    {
                        Position = (Position.X, Position.Y - 1);
                    }
                    break;
                case '>':
                    if (_map[Position.Y, Position.X+1] == '.')
                    {
                        Position = (Position.X + 1, Position.Y);
                    }
                    break;
                case 'V':
                    if (_map[Position.Y+1, Position.X] == '.')
                    {
                        Position = (Position.X, Position.Y +1);
                    }
                    break;
            }
        }

        CalculateSumOfGpsCoordinates();
    }

    private void CalculateSumOfGpsCoordinates()
    {
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_map[y, x] == 'O')
                {
                    SumOfGpsCoordinates += 100 * y + x;
                }
            }
        }
    }

    private bool CanMoveLeft(int x, int y)
    {
        switch (_map[y, x - 1])
        {
            case '.': return true;
            case 'O': return CanMoveLeft(x - 1, y);
            default: return false;
        }
    }

    private void MoveBoxesLeft(int x, int y)
    {
        switch (_map[y, x - 1])
        {
            case '.':
                _map[y, x - 1] = 'O';
                _map[y, x] = '.';
                break;

            case 'O':
                MoveBoxesLeft(x - 1, y);
                break;
        }
    }
}
