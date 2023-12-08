
namespace Day8.Logic;
public class HauntedWasteland
{
    private readonly string _input;

    public int StateCount { get; private set; } = 7;
    public int InstructionCount { get; private set; } = 2;

    public HauntedWasteland(string input)
    {
        _input = input;

        Parse();
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        InstructionCount = lines[0].Length;
        StateCount = lines.Length - 2;
    }
}
