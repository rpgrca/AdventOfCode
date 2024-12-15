



namespace Day15.Logic;

public class WarehouseWoes
{
    private string _input;

    public int Size { get; private set; }

    private char[,] _map;
    private char[] _movements;

    public int Count => _movements.Length;

    public int RobotX { get; private set; }
    public int RobotY { get; private set; }

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
                if (lines[y][x] == '@')
                {
                    RobotX = x;
                    RobotY = y;
                    _map[y, x] = '.';
                }
                else
                {
                    _map[y, x] = lines[y][x];
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
                    if (_map[RobotY, RobotX-1] == '.')
                    {
                        RobotX -= 1;
                    }
                    break;
                case '^':
                    if (_map[RobotY-1, RobotX] == '.')
                    {
                        RobotY -= 1;
                    }
                    break;
                case '>':
                    if (_map[RobotY, RobotX+1] == '.')
                    {
                        RobotX += 1;
                    }
                    break;
                case 'V':
                    if (_map[RobotY+1, RobotX] == '.')
                    {
                        RobotY += 1;
                    }
                    break;
            }
        }
    }
}
