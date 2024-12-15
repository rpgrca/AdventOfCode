








namespace Day15.Logic;

public class WarehouseWoes
{
    private string _input;

    public int Width { get; private set; }
    public int Height { get; private set; }

    private char[,] _map;
    private char[] _movements;

    public int Count => _movements.Length;

    public (int X, int Y) Position { get; private set; }
    public int SumOfGpsCoordinates { get; private set; }

    public WarehouseWoes(string input, bool wide = false)
    {
        _input = input;
        if (wide)
        {
            WideParse();
        }
        else
        {
            Parse();
        }
    }

    private void Parse()
    {
        var sections = _input.Split("\n\n");
        var lines = sections[0].Split('\n');
        Width = lines[0].Length;
        Height = lines.Length;

        _map = new char[Height, Width];
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
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
                    if (Move(Position.X, Position.Y, -1, 0))
                    {
                        Position = (Position.X - 1, Position.Y);
                    }
                    break;
                case '^':
                    if (Move(Position.X, Position.Y, 0, -1))
                    {
                        Position = (Position.X, Position.Y - 1);
                    }
                    break;
                case '>':
                    if (Move(Position.X, Position.Y, 1, 0))
                    {
                        Position = (Position.X + 1, Position.Y);
                    }
                    break;
                case 'v':
                    if (Move(Position.X, Position.Y, 0, 1))
                    {
                        Position = (Position.X, Position.Y +1);
                    }
                    break;
            }
        }

        CalculateSumOfGpsCoordinates();
    }

    private bool Move(int x, int y, int offsetX, int offsetY)
    {
        var newX = x + offsetX;
        var newY = y + offsetY;

        if (newX < 0 || newX >= Width || newY < 0 || newY >= Height) return false;
        switch (_map[y + offsetY, x + offsetX])
        {
            case 'O':
                if (Move(newX, newY, offsetX, offsetY))
                {
                    _map[newY, newX] = _map[y, x];
                    _map[y, x] = '.';
                    return true;
                }
                break;
            case '.':
                _map[newY, newX] = _map[y, x];
                _map[y, x] = '.';
                return true;
        }

        return false;
    }

    public void CalculateSumOfGpsCoordinates()
    {
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (_map[y, x] == 'O' || _map[y, x] == '[')
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
                if (CanMoveLeft(x, y))
                {
                    MoveBoxesLeft(x - 1, y);
                }
                _map[y, x] = '.';
                break;
        }
    }

    private void WideParse()
    {
        var sections = _input.Split("\n\n");
        var lines = sections[0]
            .Replace("#", "##")
            .Replace("O", "[]")
            .Replace(".", "..")
            .Replace("@", "@.")
            .Split('\n');

        Height = lines.Length;
        Width = lines[0].Length;

        _map = new char[Height, Width];
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
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


}
