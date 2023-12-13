
namespace Day13.Logic;
public class PointOfIncidence
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<List<string>> _maps;

    public PointOfIncidence(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _maps = new List<List<string>>();

        var currentMap = new List<string>();
        foreach (var line in _lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                _maps.Add(currentMap);
                currentMap = new List<string>();
            }
            else
            {
                currentMap.Add(line);
            }
        }

        _maps.Add(currentMap);
    }

    public int MapCount => _maps.Count;
}
