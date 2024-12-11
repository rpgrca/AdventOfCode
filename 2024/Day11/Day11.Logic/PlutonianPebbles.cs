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
            cycle.Clear();
            cycle.Add(0, 0);
            cycle.Add(1, 0);
            cycle.Add(2024, 0);

            foreach (var (key, value) in _pebbles.Where(p => p.Value > 0))
            {
                switch (key)
                {
                    case 0:
                        cycle[1] += value;
                        cycle[0] -= value;
                        break;

                    case 1:
                        cycle[2024] += value;
                        cycle[1] -= value;
                        break;

                    default:
                        var valueAsString = key.ToString();
                        var digits = valueAsString.Length;
                        if (digits % 2 == 0)
                        {
                            var (quotient, remainder) = Math.DivRem(key, (long)Math.Pow(10, digits / 2));
                            cycle.TryAdd(quotient, 0);
                            cycle.TryAdd(remainder, 0);
                            cycle.TryAdd(key, 0);

                            cycle[quotient] += value;
                            cycle[remainder] += value;
                            cycle[key] -= value;
                        }
                        else
                        {
                            var newValue = key * 2024;
                            cycle.TryAdd(newValue, 0);
                            cycle.TryAdd(key, 0);

                            cycle[newValue] += value;
                            cycle[key] -= value;
                        }
                        break;
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
