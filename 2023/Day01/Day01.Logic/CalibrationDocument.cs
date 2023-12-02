using Microsoft.VisualBasic;

namespace Day01.Logic;

public class CalibrationDocument
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<string> _validDigits = new()
    {
        "1", "2", "3", "4", "5", "6", "7", "8", "9"
    };

    private readonly List<string> _validWords = new()
    {
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
        var words = new List<string>();
        words.AddRange(_validDigits);

        foreach (var line in _lines)
        {
            var first = FindFirstValue(line, words);
            var last = FindLastValue(line, words);
            SumOfCalibrationValues += first * 10 + last;
        }
    }

    public void CalibrateWithWords()
    {
        SumOfCalibrationValues = 0;
        var words = new List<string>();
        words.AddRange(_validDigits);
        words.AddRange(_validWords);

        foreach (var line in _lines)
        {
            var first = FindFirstValue(line, words);
            var last = FindLastValue(line, words);
            SumOfCalibrationValues += first * 10 + last;
        }
    }

    private int FindLastValue(string line, List<string> words)
    {
        var currentLastIndex = 0;
        var result = -1;

        for (var currentDigit = 0; currentDigit < words.Count; currentDigit++)
        {
            var value = words[currentDigit];
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

    private int FindFirstValue(string line, List<string> words)
    {
        var currentFirstIndex = line.Length;
        var result = -1;

        for (var currentDigit = 0; currentDigit < words.Count; currentDigit++)
        {
            var value = words[currentDigit];
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
