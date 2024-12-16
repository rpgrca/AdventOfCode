namespace Day15.Logic;

public class WarehouseWoes
{
    private readonly string _input;
    private readonly bool _wide;

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
        _wide = wide;
        if (_wide)
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
        if (! _wide)
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
        }
        else
        {
            foreach (var movement in _movements)
            {
                switch (movement)
                {
                    case '<':
                        if (MoveRobotHorizontally(Position.X, Position.Y, -1, 0))
                        {
                            Position = (Position.X - 1, Position.Y);
                        }
                        break;
                    case '^':
                        if (MoveRobotVertically(Position.X, Position.Y, 0, -1))
                        {
                            Position = (Position.X, Position.Y - 1);
                        }
                        break;
                    case '>':
                        if (MoveRobotHorizontally(Position.X, Position.Y, 1, 0))
                        {
                            Position = (Position.X + 1, Position.Y);
                        }
                        break;

                    case 'v':
                        if (MoveRobotVertically(Position.X, Position.Y, 0, 1))
                        {
                            Position = (Position.X, Position.Y + 1);
                        }
                        break;
                }
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

    private bool MoveRobotVertically(int x, int y, int offsetX, int offsetY)
    {
        var newX = x + offsetX;
        var newY = y + offsetY;

        if (newX < 0 || newX >= Width || newY < 0 || newY >= Height) return false;
        switch (_map[newY, x])
        {
            case '[':
                if (CanMoveBoxVertically(newX, newY, offsetX, offsetY) && CanMoveBoxVertically(newX + 1, newY, offsetX, offsetY))
                {
                    MoveBoxVertically(newX, newY, newX + 1, newY, offsetX, offsetY);
                    return true;
                }
                break;

            case ']':
                if (CanMoveBoxVertically(newX - 1, newY, offsetX, offsetY) && CanMoveBoxVertically(newX, newY, offsetX, offsetY))
                {
                    MoveBoxVertically(newX - 1, newY, newX, newY, offsetX, offsetY);
                    return true;
                }
                break;

            case '.':
                return true;
        }

        return false;
    }

    private void MoveBoxVertically(int x1, int y1, int x2, int y2, int offsetX, int offsetY)
    {
        if (!(_map[y1, x1] == '[' && _map[y2, x2] == ']'))
        {
            return;
        }

        var newX1 = x1;
        var newY1 = y1 + offsetY;
        var newX2 = x2;
        var newY2 = y2 + offsetY;

        if (_map[newY1, newX1] == '.' && _map[newY2, newX2] == '.')
        {
            _map[newY1, newX1] = _map[y1, x1];
            _map[newY2, newX2] = _map[y2, x2];
            _map[y1, x1] = '.';
            _map[y2, x2] = '.';
            return;
        }

        if (_map[newY1, newX1] == '[') // _map[newY2, newX2] must be ']'
        {
            MoveBoxVertically(newX1, newY1, newX2, newY2, offsetX, offsetY);
            _map[newY1, newX1] = _map[y1, x1];
            _map[newY2, newX2] = _map[y2, x2];
            _map[y1, x1] = '.';
            _map[y2, x2] = '.';
            return;
        }

        if (_map[newY1, newX1] == ']' && _map[newY1, newX1-1] == '[')
        {
            MoveBoxVertically(newX1-1, newY1, newX1, newY1, offsetX, offsetY);
            if (_map[newY2, newX2] != '.')
            {
                // always '['
                MoveBoxVertically(newX2, newY2, newX2 + 1, newY2, offsetX, offsetY);
            }

            _map[newY1, newX1] = _map[y1, x1];
            _map[newY2, newX2] = _map[y2, x2];
            _map[y1, x1] = '.';
            _map[y2, x2] = '.';
        }

        if (_map[newY2, newX2] == '[' && _map[newY2, newX2+1] == ']')
        {
            MoveBoxVertically(newX2, newY2, newX2+1, newY2, offsetX, offsetY);
            _map[newY1, newX1] = _map[y1, x1];
            _map[newY2, newX2] = _map[y2, x2];
            _map[y1, x1] = '.';
            _map[y2, x2] = '.';
        }
    }

    private bool CanMoveBoxVertically(int x, int y, int offsetX, int offsetY)
    {
        var newX = x + offsetX;
        var newY = y + offsetY;

        if (newX < 0 || newX >= Width || newY < 0 || newY >= Height) return false;
        switch (_map[newY, newX])
        {
            case '[': return CanMoveBoxVertically(newX, newY, offsetX, offsetY) && CanMoveBoxVertically(newX + 1, newY, offsetX, offsetY);
            case ']': return CanMoveBoxVertically(newX - 1, newY, offsetX, offsetY) && CanMoveBoxVertically(newX, newY, offsetX, offsetY);
            case '.': return true;
        }

        return false;
    }

    private bool MoveRobotHorizontally(int x, int y, int offsetX, int offsetY)
    {
        var newX = x + offsetX;
        var newY = y + offsetY;

        if (newX < 0 || newX >= Width || newY < 0 || newY >= Height) return false;
        switch (_map[y + offsetY, x + offsetX])
        {
            case '[':
            case ']':
                if (MoveRobotHorizontally(newX, newY, offsetX, offsetY))
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