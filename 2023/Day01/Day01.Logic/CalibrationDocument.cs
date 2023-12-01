



using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Day01.Logic;

public class CalibrationDocument
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly string[] _validDigits = new[]
    {
        "1", "2", "3", "4", "5", "6", "7", "8", "9",
        "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"
    };

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

        for (var currentDigit = 0; currentDigit < _validDigits.Length; currentDigit++)
        {
            var value = _validDigits[currentDigit];
            var subValues = line.Split(value);
            if (subValues.Length > 0)
            {
                var index = line.Length - subValues.Last().Length;
                if (index > currentLastIndex)
                {
                    currentLastIndex = index;
                    result = currentDigit % 9 + 1;
                }
            }
        }

        return result;
    }

    private int FindFirstValue(string line)
    {
        var currentFirstIndex = line.Length;
        var result = -1;

        for (var currentDigit = 0; currentDigit < _validDigits.Length; currentDigit++)
        {
            var value = _validDigits[currentDigit];
            var subValues = line.Split(value);
            if (subValues.Length > 0)
            {
                var index = subValues[0].Length;
                if (index < currentFirstIndex)
                {
                    currentFirstIndex = index;
                    result = currentDigit % 9 + 1;
                }
            }
        }

        return result;
    }
}
