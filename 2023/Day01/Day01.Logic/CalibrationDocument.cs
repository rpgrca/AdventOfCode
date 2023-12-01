


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
        SumOfCalibrationValues = 0;

        foreach (var line in _lines)
        {
            var firstFound = false;
            var first = 0;
            var last = 0;

            for (var index = 0; index < line.Length; index++)
            {
                if (char.IsDigit(line[index]))
                {
                    if (! firstFound)
                    {
                        first = last = line[index] - '0';
                        firstFound = true;
                    }
                    else
                    {
                        last = line[index] - '0';
                    }
                }
            }

            SumOfCalibrationValues += first * 10 + last;
        }
    }
}
