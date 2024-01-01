
using System.Diagnostics;
using System.IO.Compression;
using System.Runtime.CompilerServices;

namespace Day22.Logic;

[DebuggerDisplay("{Start}...{End}")]
public class Brick
{
    public (int X, int Y, int Z) Start { get; }
    public (int X, int Y, int Z) End { get; }
    public bool Enabled { get; set; }

    public Brick((int, int, int) start, (int, int, int) end)
    {
        Start = start;
        End = end;
        Enabled = true;
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
                .Select(d => (X: d[0], Y: d[1], Z: d[2]))
                .ToArray();

            if (points[0].X > points[1].X)
            {
                throw new Exception("Invalid X format");
            }

            if (points[0].Y > points[1].Y)
            {
                throw new Exception("Invalid Y format");
            }

            if (points[0].Z > points[1].Z)
            {
                throw new Exception("Invalid Z format");
            }
            _bricks.Add(new Brick(points[0], points[1]));
        }

        _bricks = _bricks.OrderBy(p => p.Start.Z).OrderBy(p => p.End.Z).ToList();
    }

    public bool Drop()
    {
        var bricksAfterDrop = new List<Brick>();
        var dropped = Drop(_bricks, bricksAfterDrop);

        if (dropped > 0)
        {
            _bricks = bricksAfterDrop;
        }

        return dropped > 0;
    }

    public int Drop(List<Brick> original, List<Brick> bricksAfterDrop)
    {
        var dropped = 0;
        foreach (var brick in original)
        {
            var canDrop = true;

            if (brick.Start.Z == 1)
            {
                canDrop = false;
            }
            else
            {
                if (brick.Start.Z == brick.End.Z)
                {
                    if (brick.Start.X == brick.End.X)
                    {
                        for (var y = brick.Start.Y; y <= brick.End.Y; y++)
                        {
                            if (bricksAfterDrop.Any(b => (b.End.Z == brick.Start.Z - 1) &&
                                (b.Start.X <= brick.Start.X && brick.Start.X <= b.End.X) &&
                                b.Start.Y <= y && y <= b.End.Y))
                            {
                                canDrop = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (var x = brick.Start.X; x <= brick.End.X; x++)
                        {
                            if (bricksAfterDrop.Any(b => (b.End.Z == brick.Start.Z - 1) &&
                                (b.Start.Y <= brick.Start.Y && brick.Start.Y <= b.End.Y) &&
                                (b.Start.X <= x && x <= b.End.X)))
                            {
                                canDrop = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if ((bricksAfterDrop.Any(b => (b.End.Z == brick.Start.Z - 1) &&
                        (b.Start.X <= brick.Start.X && b.End.X >= brick.Start.X) &&
                        (b.Start.Y <= brick.Start.Y && b.End.Y >= brick.Start.Y))))
                    {
                        canDrop = false;
                    }
                }
            }

            if (canDrop)
            {
                bricksAfterDrop.Add(new Brick((brick.Start.X, brick.Start.Y, brick.Start.Z - 1), (brick.End.X, brick.End.Y, brick.End.Z - 1)));
                dropped++;
            }
            else
            {
                bricksAfterDrop.Add(brick);
            }
        }

        return dropped;
    }

    public void DropUntilRest()
    {
        while (Drop());
    }

    public int CalculateEligibleSlabs()
    {
        var counter = 0;

        foreach (var brick in _bricks)
        {
            var list = _bricks.Where(p => p != brick).ToList();
            var bricksAfterDrop = new List<Brick>();
            counter += Drop(list, bricksAfterDrop) == 0? 1 : 0;
        }

        return counter;
    }

    public int CalculateSumOfChainReaction()
    {
        var counter = 0;

        foreach (var brick in _bricks)
        {
            var list = _bricks.Where(p => p != brick).ToList();
            var bricksAfterDrop = new List<Brick>();

            counter += Drop(list, bricksAfterDrop);
            /*while (accumulator > 0)
            {
                counter += accumulator;
                accumulator = 0;
                list = bricksAfterDrop;
                bricksAfterDrop = new List<Brick>();
                accumulator = Drop(list, bricksAfterDrop);
            }*/
        }

        return counter;
    }
}
