



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

    public void CalibrateWithWords()
    {
        SumOfCalibrationValues = 0;

        foreach (var line in _lines)
        {
            var first = 0;
            var last = 0;

            first = FindFirstValue(line);
            last = FindLastValue(line);

            SumOfCalibrationValues += first * 10 + last;
        }
    }

    private int FindLastValue(string line)
    {
        var currentLastIndex = 0;
        var result = -1;

        foreach (var number in Enumerable.Range(0, 10))
        {
            var character = (char)(number + '0');
            var index = line.LastIndexOf(character);
            if (index != -1 && index > currentLastIndex)
            {
                currentLastIndex = index;
                result = number;
            }
        }

        return result;
    }

    private int FindFirstValue(string line)
    {
        var currentFirstIndex = line.Length;
        var result = -1;

        foreach (var number in Enumerable.Range(0, 10))
        {
            var character = (char)(number + '0');
            var index = line.IndexOf(character);
            if (index != -1 && index < currentFirstIndex)
            {
                currentFirstIndex = index;
                result = number;
            }
        }

        return result;
    }


}
