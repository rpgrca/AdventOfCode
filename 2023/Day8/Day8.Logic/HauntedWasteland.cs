

namespace Day8.Logic;
public class HauntedWasteland
{
    private readonly string _input;

    public int StateCount { get; private set; }
    public int InstructionCount { get; private set; }
    public string Instructions { get; private set; }

    public HauntedWasteland(string input)
    {
        _input = input;
        Instructions = string.Empty;

        Parse();
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        Instructions = lines[0];
        InstructionCount = lines[0].Length;
        StateCount = lines.Length - 2;
    }
}
