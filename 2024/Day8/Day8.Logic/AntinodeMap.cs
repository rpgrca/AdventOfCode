namespace Day8.Logic;

public record Antenna(char Frequency, int X, int Y);
public record Antinode(int X, int Y);

public class AntinodeMap
{
    private readonly string _input;
    private readonly ICreator[] _creators;
    private readonly string[] _map;
    private readonly HashSet<Antinode> _antinodes;
    private readonly Dictionary<char, List<Antenna>> _antennasByFrequency;

    public int Size => _map.Length;
    public int AntinodeCount => _antinodes.Count;

    public static AntinodeMap CreateWithoutHarmonics(string input) =>
        new(input, new[] {
            new AntinodeCreator((a1, a2) => a1.X < a2.X, (a1, a2, dx, dy, c) => new(a1.X - dx, a1.Y - dy), false),
            new AntinodeCreator((a1, a2) => a1.X < a2.X, (a1, a2, dx, dy, c) => new(a2.X + dx, a2.Y + dy), false),
            new AntinodeCreator((a1, a2) => a1.X >= a2.X, (a1, a2, dx, dy, c) => new(a2.X - dx, a2.Y + dy), false),
            new AntinodeCreator((a1, a2) => a1.X >= a2.X, (a1, a2, dx, dy, c) => new(a1.X + dx, a1.Y - dy), false)
        });

    public static AntinodeMap CreateWithHarmonics(string input) =>
        new(input, new[] {
            new AntinodeCreator((_, _) => true, (a1, _, _, _, _) => new(a1.X, a1.Y), false),
            new AntinodeCreator((_, _) => true, (_, a2, _, _, _) => new(a2.X, a2.Y), false),
            new AntinodeCreator((a1, a2) => a1.X < a2.X, (a1, a2, dx, dy, c) => new(a1.X - dx * c, a1.Y - dy * c), true),
            new AntinodeCreator((a1, a2) => a1.X < a2.X, (a1, a2, dx, dy, c) => new(a2.X + dx * c, a2.Y + dy * c), true),
            new AntinodeCreator((a1, a2) => a1.X >= a2.X, (a1, a2, dx, dy, c) => new(a2.X - dx * c, a2.Y + dy * c), true),
            new AntinodeCreator((a1, a2) => a1.X >= a2.X, (a1, a2, dx, dy, c) => new(a1.X + dx * c, a1.Y - dy * c), true)
        });

    private AntinodeMap(string input, ICreator[] creators)
    {
        _input = input;
        _creators = creators;
        _map = _input.Split('\n');
        _antennasByFrequency = new();
        _antinodes = new();

        Parse();

        CalculateAntinodes();
    }

    private void Parse()
    {
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_map[y][x] != '.')
                {
                    var antenna = new Antenna(_map[y][x], x, y);
                    if (! _antennasByFrequency.ContainsKey(_map[y][x]))
                    {
                        _antennasByFrequency.Add(_map[y][x], new());
                    }

                    _antennasByFrequency[_map[y][x]].Add(antenna);
                }
            }
        }
    }

    private void CalculateAntinodes()
    {
        Antinode antinode;

        foreach (var (_, antennas) in _antennasByFrequency)
        {
            for (var index = 0; index < antennas.Count - 1; index++)
            {
                for (var subIndex = index + 1; subIndex < antennas.Count; subIndex++)
                {
                    var first = antennas[index];
                    var second = antennas[subIndex];

                    var xDiff = Math.Abs(first.X - second.X);
                    var yDiff = Math.Abs(first.Y - second.Y);

                    foreach (var creator in _creators)
                    {
                        if (creator.ShouldExecuteFor(first, second))
                        {
                            var addMore = creator.HasHarmonics;
                            var count = 1;
                            do
                            {
                                antinode = creator.CreateAntinode(first, second, xDiff, yDiff, count++);
                                if (! _antinodes.Contains(antinode))
                                {
                                    if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                                    {
                                        _antinodes.Add(antinode);
                                    }
                                    else
                                    {
                                        addMore = false;
                                    }
                                }
                            }
                            while (addMore);
                        }
                    }
                }
            }
        }
    }
}