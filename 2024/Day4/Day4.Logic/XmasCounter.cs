namespace Day4.Logic;

public class XmasCounter : IXmasCounter
{
    public int Count(string[] block)
    {
        var height = block.Length;
        var width = block[0].Length;
        var count = 0;
        var xmasConditionals = new ConditionalCoordinates[]
        {
            new ((x, _) => x <= width - 4, new[] { (1, 0), (2, 0), (3, 0) }),
            new ((x, _) => x >= 3, new[] { (-1, 0), (-2, 0), (-3, 0) }),
            new ((_, y) => y <= height - 4, new[] { (0, 1), (0, 2), (0, 3) }),
            new ((_, y) => y >= 3, new[] { (0, -1), (0, -2), (0, -3)}),
            new ((x, y) => x <= width - 4 && y <= height - 4, new[] { (1, 1), (2, 2), (3, 3) }),
            new ((x, y) => x >= 3 && y <= height - 4, new[] { (-1, 1), (-2, 2), (-3, 3) }),
            new ((x, y) => x <= width - 4 && y >= 3, new[] { (1, -1), (2, -2), (3, -3) }),
            new ((x, y) => x >= 3 && y >= 3, new[] { (-1, -1), (-2, -2), (-3, -3) })
        };

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (block[y][x] == 'X')
                {
                    var result = xmasConditionals
                        .Where(p => p.Condition(x, y))
                        .Select(p => p.Coordinates)
                        .Count(p => block[y + p[0].Y][x + p[0].X] == 'M' &&
                                    block[y + p[1].Y][x + p[1].X] == 'A' &&
                                    block[y + p[2].Y][x + p[2].X] == 'S');

                    count += result;
                }
            }
        }

        return count;
    }
}