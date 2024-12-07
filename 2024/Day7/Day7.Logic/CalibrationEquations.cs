namespace Day7.Logic;

public class CalibrationEquations
{
    private readonly string _input;
    private readonly string[] _equations;

    public int Count => _equations.Length;

    public CalibrationEquations(string input)
    {
        _input = input;
        _equations = _input.Split('\n');
    }
}
