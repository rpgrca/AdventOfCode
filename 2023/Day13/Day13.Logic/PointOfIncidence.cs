


namespace Day13.Logic;
public class PointOfIncidence
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<(List<string> Pattern, List<int> Vertical, List<int> Horizontal)> _maps;

    public PointOfIncidence(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _maps = new List<(List<string> Pattern, List<int> Horizontal, List<int> Vertical)>();

        var currentMap = new List<string>();
        foreach (var line in _lines)
        {
            if (string.IsNullOrEmpty(line))
            {

                _maps.Add((currentMap, GenerateVerticalNumbering(currentMap), GenerateHorizontalNumbering(currentMap)));
                currentMap = new List<string>();
            }
            else
            {
                currentMap.Add(line);
            }
        }

        _maps.Add((currentMap, GenerateVerticalNumbering(currentMap), GenerateHorizontalNumbering(currentMap)));

        PatternSummary = 0;
        foreach (var map in _maps)
        {
            var lastValue = -1;
            for (var column = 0; column < map.Vertical.Count; column++)
            {
                if (map.Vertical[column] == lastValue)
                {
                    PatternSummary += column;
                    break;
                }

                lastValue = map.Vertical[column];
            }
        }
    }

    private List<int> GenerateHorizontalNumbering(List<string> currentMap)
    {
        return new List<int>();
    }

    private List<int> GenerateVerticalNumbering(List<string> currentMap)
    {
        var verticalNumbering = new List<int>();
        for (var x = 0; x < currentMap[0].Length; x++)
        {
            var code = 0;
            for (var y = 0; y < currentMap.Count; y++)
            {
                code = (code << 1) | (currentMap[y][x] == '.'? 0 : 1);
            }

            verticalNumbering.Add(code);
        }

        return verticalNumbering;
    }

    public int MapCount => _maps.Count;

    public int PatternSummary { get; private set; }
}
