

namespace Day25.Logic;

public class CodeChronicle
{
    private string _input;
    private readonly List<(int, int, int, int, int)> _keys;
    private readonly List<(int, int, int, int, int)> _locks;

    public int Keys => _keys.Count;
    public int Locks => _locks.Count;
    public int UniqueWorkingPairs { get; private set; }

    public CodeChronicle(string input)
    {
        _input = input;

        _keys = new List<(int, int, int, int, int)>();
        _locks = new List<(int, int, int, int, int)>();
        var items = _input.Split("\n\n");
        foreach (var item in items)
        {
            var rows = item.Split('\n');
            if (rows[0].All(p => p == '#'))
            {
                var tumbroll = (rows.Count(p => p[0] == '#') - 1, rows.Count(p => p[1] == '#') - 1,
                                rows.Count(p => p[2] == '#') - 1, rows.Count(p => p[3] == '#') - 1,
                                rows.Count(p => p[4] == '#') - 1);
                _locks.Add(tumbroll);
            }
            else
            {
                var key = (rows.Count(p => p[0] == '#') - 1, rows.Count(p => p[1] == '#') - 1,
                                rows.Count(p => p[2] == '#') - 1, rows.Count(p => p[3] == '#') - 1,
                                rows.Count(p => p[4] == '#') - 1);
                _keys.Add(key);
            }
        }

        for (var y = 0; y < _locks.Count; y++)
        {
            for (var x = 0; x < _keys.Count; x++)
            {
                if (_locks[y].Item1 + _keys[x].Item1 <= 5 && _locks[y].Item2 + _keys[x].Item2 <= 5 &&
                    _locks[y].Item3 + _keys[x].Item3 <= 5 && _locks[y].Item4 + _keys[x].Item4 <= 5 &&
                    _locks[y].Item5 + _keys[x].Item5 <= 5)
                {
                    UniqueWorkingPairs++;
                }
            }
        }
    }
}
