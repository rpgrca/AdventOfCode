namespace Day01.Logic;

public class CalibrationDocument
{
    public class Builder
    {
        private readonly List<string> _words;

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

    private readonly string[] _lines;
    private readonly List<string> _words;

    public int SumOfCalibrationValues { get; private set; }

    private CalibrationDocument(List<string> words, string input)
    {
        _lines = input.Split("\n");
        _words = words;

        Calibrate();
    }

    private void Calibrate()
    {
        SumOfCalibrationValues = 0;

        foreach (var line in _lines)
        {
            var first = FindFirstValueFrom(line);
            var last = FindLastValueFrom(line);
            SumOfCalibrationValues += first * 10 + last;
        }
    }

    private int FindLastValueFrom(string line) =>
        FindValue(line, 0, (l, s) => l - s.Last().Length, (i, c) => i > c);

    private int FindFirstValueFrom(string line) =>
        FindValue(line, line.Length, (_, s) => s[0].Length, (i, c) => i < c);

    private int FindValue(string line, int initialValue, Func<int, string[], int> indexer, Func<int, int, bool> compare)
    {
        var currentIndex = initialValue;
        var result = -1;

        for (var currentWord = 0; currentWord < _words.Count; currentWord++)
        {
            var value = _words[currentWord];
            var subValues = line.Split(value);
            if (subValues.Length > 0)
            {
                var index = indexer(line.Length, subValues);
                if (compare(index, currentIndex))
                {
                    currentIndex = index;
                    result = currentWord % 9 + 1;
                }
            }
        }

        return result;
    }
}