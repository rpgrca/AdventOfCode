using System.ComponentModel.DataAnnotations;

namespace Day8.Logic;

public record Antenna(char Frequency, int X, int Y);
public record Antinode(int X, int Y);

public class AntinodeMap
{
    private readonly string _input;
    private readonly string[] _map;
    private readonly HashSet<Antinode> _antinodes;
    private readonly Dictionary<char, List<Antenna>> _antennasByFrequency;

    public int Size => _map.Length;
    public List<Antenna> Antennas { get; private set; }
    public int AntinodeCount => _antinodes.Count;

    public AntinodeMap(string input, bool withHarmonics = false)
    {
        _input = input;
        _map = _input.Split('\n');
        _antennasByFrequency = new();
        _antinodes = new();
        Antennas = new();

        Parse();

        if (withHarmonics)
        {
            CalculateAntinodesWithHarmonics();
        }
        else
        {
            CalculateAntinodes();
        }
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
                    Antennas.Add(antenna);
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

                    if (first.X < second.X)
                    {
                        antinode = new Antinode(first.X - xDiff, first.Y - yDiff);
                        if (! _antinodes.Contains(antinode))
                        {
                            if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                            {
                                _antinodes.Add(antinode);
                            }
                        }

                        antinode = new(second.X + xDiff, second.Y + yDiff);
                        if (! _antinodes.Contains(antinode))
                        {
                            if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                            {
                                _antinodes.Add(antinode);
                            }
                        }
                    }
                    else
                    {
                        antinode = new(second.X - xDiff, second.Y + yDiff);
                        if (! _antinodes.Contains(antinode))
                        {
                            if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                            {
                                _antinodes.Add(antinode);
                            }
                        }

                        antinode = new(first.X + xDiff, first.Y - yDiff);
                        if (! _antinodes.Contains(antinode))
                        {
                            if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                            {
                                _antinodes.Add(antinode);
                            }
                        }
                    }
                }
            }
        }
    }

    private void CalculateAntinodesWithHarmonics()
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

                    var antennaAsAntinode = new Antinode(first.X, first.Y);
                    if (! _antinodes.Contains(antennaAsAntinode))
                    {
                        _antinodes.Add(antennaAsAntinode);
                    }

                    antennaAsAntinode = new Antinode(second.X, second.Y);
                    if (! _antinodes.Contains(antennaAsAntinode))
                    {
                        _antinodes.Add(antennaAsAntinode);
                    }

                    var xDiff = Math.Abs(first.X - second.X);
                    var yDiff = Math.Abs(first.Y - second.Y);

                    if (first.X < second.X)
                    {
                        var addMore = true;
                        var count = 1;
                        while (addMore)
                        {
                            antinode = new Antinode(first.X - (xDiff * count), first.Y - (yDiff * count));
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

                            count++;
                        }

                        addMore = true;
                        count = 1;
                        while (addMore)
                        {
                            antinode = new(second.X + (xDiff * count), second.Y + (yDiff * count));
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

                            count++;
                        }

                    }
                    else
                    {
                        antinode = new(second.X - xDiff, second.Y + yDiff);
                        if (! _antinodes.Contains(antinode))
                        {
                            if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                            {
                                _antinodes.Add(antinode);
                            }
                        }

                        antinode = new(first.X + xDiff, first.Y - yDiff);
                        if (! _antinodes.Contains(antinode))
                        {
                            if (antinode.X >= 0 && antinode.X < Size && antinode.Y >= 0 && antinode.Y < Size)
                            {
                                _antinodes.Add(antinode);
                            }
                        }
                    }
                }
            }
        }
    }
}