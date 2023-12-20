using System.Diagnostics;

namespace Day19.Logic;

public interface IFilter
{
    char Variable { get; }
    public ulong MinimumAcceptedValue { get; }
    public ulong MaximumAcceptedValue { get; }
    public string Result { get; }
    public IFilter Negation { get; }
    public bool Apply(Part part);
}

[DebuggerDisplay("{_input}")]
public class Filter : IFilter
{
    private static int _counter = 1;
    private readonly string _input;
    private readonly Func<Part, bool> _method;
    public char Variable { get; }
    public ulong MinimumAcceptedValue { get; }
    public ulong MaximumAcceptedValue { get; }

    public Filter(string input)
    {
        _input = input;
        if (_input.Contains('<'))
        {
            var values = _input.Split('<');
            var jump = values[1].Split(':');
            Result = jump[1];
            Variable = values[0][0];
            MinimumAcceptedValue = 1;
            MaximumAcceptedValue = ulong.Parse(jump[0]);
            Negation = new NegatedFilter($"{Variable}>={MaximumAcceptedValue}", Variable, MaximumAcceptedValue - 1, 4000);
            _method = p => p.Values[Variable] < (int)MaximumAcceptedValue;
        }
        else if (_input.Contains('>'))
        {
            var values = _input.Split('>');
            var jump = values[1].Split(':');

            Result = jump[1];
            Variable = values[0][0];
            MinimumAcceptedValue = ulong.Parse(jump[0]);
            MaximumAcceptedValue = 4000;
            Negation = new NegatedFilter($"{Variable}<={MinimumAcceptedValue}", Variable, 1, MinimumAcceptedValue + 1);
            _method = p => p.Values[Variable] > (int)MinimumAcceptedValue;
        }
        else
        {
            Result = input;
            Variable = '?';
            MinimumAcceptedValue = 0;
            MaximumAcceptedValue = 0;
            _method = p => true;
        }

        if (Result == "A")
        {
            Result = "A" + _counter++;
        }
        else if (Result == "R")
        {
            Result = "R" + _counter++;
        }
    }

    public string Result { get; internal set; }
    public IFilter Negation { get; internal set; }
    public bool Apply(Part part) => _method(part);
}