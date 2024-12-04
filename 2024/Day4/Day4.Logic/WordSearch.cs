namespace Day4.Logic;

public record ConditionalCoordinates(Func<int, int, bool> Condition, (int X, int Y)[] Coordinates);

public class WordSearch
{
    private readonly string _input;
    private readonly string[] _block;

    public int Width => _block[0].Length;

    public int Height => _block.Length;

    public int XmasCount { get; private set; }

    public int X_MasCount { get; private set; }

    public WordSearch(string input)
    {
        _input = input;
        _block = input.Split("\n");

        FindXmas();
    }

    private void FindXmas()
    {
        var xmasConditionals = new ConditionalCoordinates[]
        {
            new ((x, _) => x <= Width - 4, new[] { (1, 0), (2, 0), (3, 0) }),
            new ((x, _) => x >= 3, new[] { (-1, 0), (-2, 0), (-3, 0) }),
            new ((_, y) => y <= Height - 4, new[] { (0, 1), (0, 2), (0, 3) }),
            new ((_, y) => y >= 3, new[] { (0, -1), (0, -2), (0, -3)}),
            new ((x, y) => x <= Width - 4 && y <= Height - 4, new[] { (1, 1), (2, 2), (3, 3) }),
            new ((x, y) => x >= 3 && y <= Height - 4, new[] { (-1, 1), (-2, 2), (-3, 3) }),
            new ((x, y) => x <= Width - 4 && y >= 3, new[] { (1, -1), (2, -2), (3, -3) }),
            new ((x, y) => x >= 3 && y >= 3, new[] { (-1, -1), (-2, -2), (-3, -3) })
        };

        Func<int, int, bool> condition = (x, y) => y >= 1 && y <= Height - 2 && x >= 1 && x <= Width - 2;
        var x_masConditionals = new ConditionalCoordinates[]
        {
            new(condition, new[] { (-1, -1), (1, 1), (1, -1), (-1, 1) }),
            new(condition, new[] { (1, 1), (-1, -1), (-1, 1), (1, -1) }),
            new(condition, new[] { (-1, -1), (1, 1), (-1, 1), (1, -1) }),
            new(condition, new[] { (1, 1), (-1, -1), (1, -1), (-1, 1) })
        };

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (_block[y][x] == 'X')
                {
                    var result = xmasConditionals
                        .Where(p => p.Condition(x, y))
                        .Select(p => p.Coordinates)
                        .Count(p => _block[y + p[0].Y][x + p[0].X] == 'M' &&
                                    _block[y + p[1].Y][x + p[1].X] == 'A' &&
                                    _block[y + p[2].Y][x + p[2].X] == 'S');

                    XmasCount += result;
                }

                if (_block[y][x] == 'A')
                {
                    var result = x_masConditionals
                        .Where(p => p.Condition(x, y))
                        .Select(p => p.Coordinates)
                        .Count(p => _block[y + p[0].Y][x + p[0].X] == 'M' &&
                                    _block[y + p[1].Y][x + p[1].X] == 'S' &&
                                    _block[y + p[2].Y][x + p[2].X] == 'M' &&
                                    _block[y + p[3].Y][x + p[3].X] == 'S');

                    X_MasCount += result;
                }
            }
        }
    }
}