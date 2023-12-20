using System.Diagnostics;

namespace Day19.Logic;

[DebuggerDisplay("{_input}")]
public class NegatedFilter : IFilter
{
    private string _input;

    public char Variable { get; }
    public ulong MinimumAcceptedValue { get; }
    public ulong MaximumAcceptedValue { get; }
    public string Result => throw new NotImplementedException();
    public IFilter Negation => throw new NotImplementedException();

    public NegatedFilter(string input, char variable, ulong minimum, ulong maximum)
    {
        _input = input;
        Variable = variable;
        MinimumAcceptedValue = minimum;
        MaximumAcceptedValue = maximum;
    }

   public bool Apply(Part part)
    {
        throw new NotImplementedException();
    }
}