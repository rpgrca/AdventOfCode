

namespace Day11.Logic;

public class PlutonianPebbles
{
    private readonly string _input;
    private readonly List<long> _line;
    private readonly LinkedList<long> _pebbles;

    public int Count => _line.Count;

    public LinkedList<long> Pebbles => _pebbles;

    public PlutonianPebbles(string input)
    {
        _input = input;
        _line = _input.Split(' ').Select(long.Parse).ToList();
        _pebbles = new();
        foreach (var number in _line)
        {
            _pebbles.AddLast(new LinkedListNode<long>(number));
        }
    }

    public void Blink(int count = 1)
    {
        for (; count > 0; count--)
        {
            var current = _pebbles.First;
            while (current != null)
            {
                if (current.Value == 0)
                {
                    current.Value = 1;
                }
                else
                {
                    if (current.Value == 1)
                    {
                        current.Value *= 2024;
                    }
                    else
                    {
                        var valueAsString = current.Value.ToString();
                        if (valueAsString.Length % 2 == 0)
                        {
                            var left = valueAsString[0..(valueAsString.Length / 2)];
                            var right = valueAsString[(valueAsString.Length / 2)..];
                            _pebbles.AddBefore(current, long.Parse(left));
                            current.Value = long.Parse(right);
                        }
                        else
                        {
                            current.Value *= 2024;
                        }
                    }
                }
                current = current.Next;
            }
            }
    }
}
