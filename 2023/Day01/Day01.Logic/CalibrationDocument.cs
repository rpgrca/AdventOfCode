
namespace Day01.Logic;

public class CalibrationDocument
{
    private readonly string _input;

    public CalibrationDocument(string input)
    {
        _input = input;
        var lines = _input.Split("\n");
        LineCount = lines.Length;
    }

    public int LineCount { get; private set; }
}
