
using System.IO.Compression;

namespace Day22.Logic;

public class Brick
{
    public (int X, int Y, int Z) Start { get; }
    public (int X, int Y, int Z) End { get; }

    public Brick((int, int, int) start, (int, int, int) end)
    {
        Start = start;
        End = end;
    }
}

public class SandSlabs
{
    private readonly string _input;
    private readonly string[] _lines;
    private List<Brick> _bricks;
    public int BrickCount => _bricks.Count;

    public List<Brick> Bricks => _bricks;

    public SandSlabs(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _bricks = new List<Brick>();

        foreach (var line in _lines)
        {
            var points = line.Split("~")
                .Select(p => p.Split(",").Select(int.Parse).ToArray())
                .Select(d => (d[0], d[1], d[2]))
                .ToArray();

            _bricks.Add(new Brick(points[0], points[1]));
        }
    }

    public void Drop()
    {
        var bricksAfterDrop = new List<Brick>();
        foreach (var brick in _bricks)
        {
            if (brick.Start.Z == 1 || brick.End.Z == 1)
            {
                bricksAfterDrop.Add(brick);
            }
            else
            {
                if (brick.Start.Z == brick.End.Z)
                {
                    if (brick.Start.X == brick.End.X)
                    {
                        for (var z = brick.Start.Z - 1; z > 0; z--)
                        {
                            for (var y = brick.Start.Y; y <= brick.End.Y; y++)
                            {
                                if (bricksAfterDrop.Any(b => (b.Start.Z == z || b.End.Z == z) &&
                                    (b.Start.X == brick.Start.X || b.End.X == brick.Start.X) &&
                                    b.Start.Y <= y && y <= b.End.Y))
                                {
                                    bricksAfterDrop.Add(new Brick((brick.Start.X, brick.Start.Y, z + 1), (brick.End.X, brick.End.Y, z + 1)));
                                    goto Placed;
                                }
                            }
                        }
                    }
                    else
                    {
                        for (var z = brick.Start.Z - 1; z > 0; z--)
                        {
                            for (var x = brick.Start.X; x <= brick.End.X; x++)
                            {
                                if (bricksAfterDrop.Any(b => (b.Start.Z == z || b.End.Z == z) &&
                                    (b.Start.Y == brick.Start.Y || b.End.Y == brick.Start.Y) &&
                                    b.Start.X <= x && x <= b.End.X))
                                {
                                    bricksAfterDrop.Add(new Brick((brick.Start.X, brick.Start.Y, z + 1), (brick.End.X, brick.End.Y, z + 1)));
                                    goto Placed;
                                }
                            }
                        }

                    }
                }
            }

            Placed:;
        }

        _bricks = bricksAfterDrop;
    }
}
