using System.Diagnostics;

namespace Day24.Logic;

public class CrossedWires
{
    private string _input;
    private readonly Dictionary<string, int> _wires;
    private readonly Dictionary<string, (string Left, string Operation, string Right)> _gates;
    private readonly int _maxResult;

    public int GatesCount => _gates.Count;
    public int WiresCount => _wires.Count;

    public ulong OutputAsDecimalNumber { get; private set; }

    public CrossedWires(string input, Dictionary<string, int> overwrittenWires)
        : this(input)
    {
        foreach (var pair in overwrittenWires)
        {
            _wires[pair.Key] = pair.Value;
        }
    }

    public CrossedWires(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        _wires = sections[0]
            .Split('\n')
            .Select(p => p.Split(':', StringSplitOptions.TrimEntries))
            .ToDictionary(p => p[0], p => int.Parse(p[1]));

        _gates = sections[1]
            .Split('\n')
            .Select(p => p.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
            .ToDictionary(p => p[4], p => (p[0], p[1], p[2]));

        _maxResult = _gates
            .Where(g => g.Key.StartsWith('z'))
            .Select(g => int.Parse(g.Key[1..]))
            .OrderDescending()
            .First();
    }

    public void Execute()
    {
        var result = 0UL;
        for (var index = 0; index < _maxResult + 1; index++)
        {
            var value = (ulong)CalculateValueFor($"z{index:00}");
            result = value << index | result;
        }

        OutputAsDecimalNumber = result;
    }

    private int CalculateValueFor(string key)
    {
        if (_wires.ContainsKey(key))
        {
            return _wires[key];
        }

        var value = _gates[key];

        var left = CalculateValueFor(value.Left);
        var right = CalculateValueFor(value.Right);
        var result = value.Operation switch
        {
            "AND" => left & right,
            "OR" => left | right,
            "XOR" => left ^ right,
            _ => throw new UnreachableException()
        };

        _wires.Add(key, result);
        return result;
    }

    public ulong CalculateExpectedResultWith(Func<ulong, ulong, ulong> callback)
    {
        var x = GenerateX();
        var y = GenerateY();
        return callback(x, y);
    }

    private ulong GenerateX()
    {
        var xs = _wires
            .Where(p => p.Key.StartsWith('x'))
            .OrderByDescending(p => p.Key)
            .Select(p => p.Value)
            .Aggregate(0UL, (t, i) => (t << 1) | (uint)i);
        return xs;
    }

    private ulong GenerateY()
    {
        var xs = _wires
            .Where(p => p.Key.StartsWith('y'))
            .OrderByDescending(p => p.Key)
            .Select(p => p.Value)
            .Aggregate(0UL, (t, i) => (t << 1) | (uint)i);
        return xs;
    }

    public ulong CalculateDifferenceWithExpected(Func<ulong, ulong, ulong> callback)
    {
        var expectedResult = CalculateExpectedResultWith(callback);
        var actualResult = OutputAsDecimalNumber;

        return expectedResult ^ actualResult;
    }
}