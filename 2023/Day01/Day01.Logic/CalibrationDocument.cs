using System.Reflection.Metadata.Ecma335;

namespace Day01.Logic;

public class CalibrationDocument
{
    public class Builder
    {
        private List<string> _words;

        public Builder() => _words = new();

        public Builder SupportingDigits()
        {
            _words.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            return this;
        }

        public Builder SupportingNames()
        {
            _words.AddRange(new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" });
            return this;
        }

        public CalibrationDocument Build(string input) => new(_words, input);
    }

    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<string> _words;

    private CalibrationDocument(List<string> words, string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _words = words;
    }

    public int LineCount => _lines.Length;

    public int SumOfCalibrationValues { get; private set; }

    public void Calibrate()
    {
        SumOfCalibrationValues = 0;
        foreach (var line in _lines)
        {
            var first = FindFirstValue(line);
            var last = FindLastValue(line);
            SumOfCalibrationValues += first * 10 + last;
        }
    }

    public void CalibrateWithWords()
    {
        SumOfCalibrationValues = 0;

        foreach (var line in _lines)
        {
            var first = FindFirstValue(line);
            var last = FindLastValue(line);
            SumOfCalibrationValues += first * 10 + last;
        }
    }

    private int FindLastValue(string line)
    {
        var currentLastIndex = 0;
        var result = -1;

        for (var currentDigit = 0; currentDigit < _words.Count; currentDigit++)
        {
            var value = _words[currentDigit];
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

        for (var currentDigit = 0; currentDigit < _words.Count; currentDigit++)
        {
            var value = _words[currentDigit];
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
