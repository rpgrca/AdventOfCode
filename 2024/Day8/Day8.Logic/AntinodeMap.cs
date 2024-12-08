namespace Day8.Logic;

public record Antenna(char Frequency, int X, int Y);

public class AntinodeMap
{
    private readonly string _input;
    private readonly string[] _map;
    private readonly Dictionary<char, List<Antenna>> _antennasByFrequency;

    public int Size => _map.Length;
    public List<Antenna> Antennas { get; private set; }
    public int AntinodeCount { get; private set; }

    public AntinodeMap(string input)
    {
        _input = input;
        _map = _input.Split('\n');
        _antennasByFrequency = new();
        Antennas = new();

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
        int antinodeX = 0;
        int antinodeY = 0;

        foreach (var (_, antennas) in _antennasByFrequency)
        {
            for (var index = 0; index < antennas.Count - 1; index++)
            {
                var first = antennas[index];
                var second = antennas[index + 1];

                var xDiff = Math.Abs(first.X - second.X);
                var yDiff = first.Y - second.Y;

                if (first.X < second.X)
                {
                    antinodeX = first.X - xDiff;
                    antinodeY = first.Y - yDiff;
                    if (antinodeX >= 0 && antinodeX < Size && antinodeY >= 0 && antinodeY < Size)
                    {
                        AntinodeCount++;
                    }

                    antinodeX = second.X + xDiff;
                    antinodeY = second.Y + yDiff;
                    if (antinodeX >= 0 && antinodeX < Size && antinodeY >= 0 && antinodeY < Size)
                    {
                        AntinodeCount++;
                    }
                }
            }
        }
    }
}