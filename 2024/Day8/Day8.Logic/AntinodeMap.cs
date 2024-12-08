

using System.Xml.Linq;

namespace Day8.Logic;

public record Antenna(char Frequency, int X, int Y);

public class AntinodeMap
{
    private readonly string _input;
    private readonly string[] _map;

    public AntinodeMap(string input)
    {
        _input = input;
        _map = _input.Split('\n');
        Antennas = new();

        Parse();
    }

    private void Parse()
    {
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_map[y][x] != '.')
                {
                    Antennas.Add(new(_map[y][x], x, y));
                }
            }
        }
    }

    public int Size => _map.Length;

    public List<Antenna> Antennas { get; set; }
}
