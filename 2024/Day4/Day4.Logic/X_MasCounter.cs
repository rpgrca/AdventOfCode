namespace Day4.Logic;

public class X_MasCounter : IXmasCounter
{
    public int Count(string[] block)
    {
        var height = block.Length;
        var width = block[0].Length;
        var count = 0;
        bool condition(int x, int y) => y >= 1 && y <= height - 2 && x >= 1 && x <= width - 2;
        var xmasConditionals = new ConditionalCoordinates[]
        {
            new(condition, new[] { (-1, -1), (1, 1), (1, -1), (-1, 1) }),
            new(condition, new[] { (1, 1), (-1, -1), (-1, 1), (1, -1) }),
            new(condition, new[] { (-1, -1), (1, 1), (-1, 1), (1, -1) }),
            new(condition, new[] { (1, 1), (-1, -1), (1, -1), (-1, 1) })
        };

        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                if (block[y][x] == 'A')
                {
                    var result = xmasConditionals
                        .Where(p => p.Condition(x, y))
                        .Select(p => p.Coordinates)
                        .Count(p => block[y + p[0].Y][x + p[0].X] == 'M' &&
                                    block[y + p[1].Y][x + p[1].X] == 'S' &&
                                    block[y + p[2].Y][x + p[2].X] == 'M' &&
                                    block[y + p[3].Y][x + p[3].X] == 'S');

                    count += result;
                }
            }
        }

        return count;
    }
}