namespace Day11.Logic;

public class PlutonianPebbles
{
    private readonly string _input;
    private readonly List<long> _line;
    private readonly Dictionary<long, long> _pebbles;

    public long Count => _pebbles.Values.Sum();

    public PlutonianPebbles(string input)
    {
        _input = input;
        _line = _input.Split(' ').Select(long.Parse).ToList();
        _pebbles = new();
        foreach (var number in _line)
        {
            _pebbles.TryAdd(number, 0);
            _pebbles[number]++;
        }
    }

    public void Blink(int count = 1)
    {
        var cycle = new Dictionary<long, long>();
        for (; count > 0; count--)
        {
            var keys = _pebbles.Where(p => p.Value > 0).Select(p => p.Key).ToArray();
            cycle.Clear();

            foreach (var key in keys)
            {
                if (key == 0)
                {
                    cycle.TryAdd(1, 0);
                    cycle[1] += _pebbles[0];
                    cycle.TryAdd(0, 0);
                    cycle[0] -= _pebbles[0];
                }
                else
                {
                    if (key == 1)
                    {
                        cycle.TryAdd(2024, 0);
                        cycle[2024] += _pebbles[1];
                        cycle.TryAdd(1, 0);
                        cycle[1] -= _pebbles[1];
                    }
                    else
                    {
                        var valueAsString = key.ToString();
                        if (valueAsString.Length % 2 == 0)
                        {
                            var left = long.Parse(valueAsString[0..(valueAsString.Length / 2)]);
                            var right = long.Parse(valueAsString[(valueAsString.Length / 2)..]);
                            cycle.TryAdd(left, 0);
                            cycle[left] += _pebbles[key];

                            cycle.TryAdd(right, 0);
                            cycle[right] += _pebbles[key];
                            cycle.TryAdd(key, 0);
                            cycle[key] -= _pebbles[key];
                        }
                        else
                        {
                            var value = key * 2024;
                            cycle.TryAdd(value, 0);
                            cycle[value] += _pebbles[key];
                            cycle.TryAdd(key, 0);
                            cycle[key] -= _pebbles[key];
                        }
                    }
                }
            }

            foreach (var (key, value) in cycle)
            {
                _pebbles.TryAdd(key, 0);
                _pebbles[key] += value;
            }
        }
    }
}
