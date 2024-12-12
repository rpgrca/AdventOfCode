using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Day8.Logic;

public class AntinodeMap
{
    private readonly List<ICreator> _creators;
    private readonly string[] _map;
    private readonly HashSet<Antinode> _antinodes;
    private readonly Dictionary<char, List<Antenna>> _antennasByFrequency;

    public int Size => _map.Length;
    public int AntinodeCount => _antinodes.Count;

    private static readonly Func<int, int, bool> _lowerThan = (x1, x2) => x1 < x2;
    private static List<ICreator> CreateAntinodes(bool withHarmonics) =>
        new() {
            new AntinodeCreator((a1, a2) => _lowerThan(a1.X, a2.X), (a1, a2, dx, dy, c) => new(a1.X - dx * c, a1.Y - dy * c), withHarmonics),
            new AntinodeCreator((a1, a2) => _lowerThan(a1.X, a2.X), (a1, a2, dx, dy, c) => new(a2.X + dx * c, a2.Y + dy * c), withHarmonics),
            new AntinodeCreator((a1, a2) => !_lowerThan(a1.X, a2.X), (a1, a2, dx, dy, c) => new(a2.X - dx * c, a2.Y + dy * c), withHarmonics),
            new AntinodeCreator((a1, a2) => !_lowerThan(a1.X, a2.X), (a1, a2, dx, dy, c) => new(a1.X + dx * c, a1.Y - dy * c), withHarmonics)
        };

    public static AntinodeMap CreateWithoutHarmonics(string input) =>
        new(input, CreateAntinodes(false));

    public static AntinodeMap CreateWithHarmonics(string input)
    {
        var creators = new List<ICreator> {
            new AntinodeCreator((_, _) => true, (a1, _, _, _, _) => new(a1.X, a1.Y), false),
            new AntinodeCreator((_, _) => true, (_, a2, _, _, _) => new(a2.X, a2.Y), false)
        };

        creators.AddRange(CreateAntinodes(true));
        return new(input, creators);
    }

    private AntinodeMap(string input, List<ICreator> creators)
    {
        _map = input.Split('\n');
        _creators = creators;
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
                    var antenna = new Antenna(x, y);
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
        foreach (var (_, antennas) in _antennasByFrequency)
        {
            for (var index = 0; index <= antennas.Count - 1; index++)
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
                            creator.Repeat(count => {
                                var addMore = false;
                                var antinode = creator.CreateAntinode(first, second, xDiff, yDiff, count);

                                if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                                {
                                    _antinodes.Add(antinode);
                                    addMore = creator.HasHarmonics;
                                }

                                return addMore;
                            });
                        }
                    }
                }
            }
        }
    }
}