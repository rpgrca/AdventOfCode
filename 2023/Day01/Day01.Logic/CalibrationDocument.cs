


namespace Day01.Logic;

public class CalibrationDocument
{
    private readonly string _input;
    private readonly string[] _lines;

    public CalibrationDocument(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

    public int LineCount => _lines.Length;
    public int SumOfCalibrationValues { get; private set; }

    public void Calibrate()
    {
        var firstFound = false;
        var first = 0;
        var last = 0;

        for (var index = 0; index < _lines[0].Length; index++)
        {
            if (char.IsDigit(_lines[0][index]))
            {
                if (! firstFound)
                {
                    first = last = _lines[0][index] - '0';
                    firstFound = true;
                }
                else
                {
                    last = _lines[0][index] - '0';
                }
            }
        }

        SumOfCalibrationValues = first * 10 + last;
    }
}
