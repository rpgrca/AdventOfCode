
namespace Day3.Logic;

public class ProgramMemory
{
    private string _input;

    public ProgramMemory(string input)
    {
        _input = input.Replace("\n", "");
    }

    public int Length => _input.Length;
}
