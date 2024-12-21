
namespace Day21.Logic;

public class KeypadConundrum
{
    private readonly string[] _lines;
    private readonly List<KeypadTyping> _transformers;

    public List<int> Codes { get; set; }
    public string ShortestSequence { get; private set; }
    public int SumOfComplexities { get; private set;}

    public KeypadConundrum(string input, List<KeypadTyping> transformers)
    {
        _lines = input.Split('\n');
        _transformers = transformers;

        Codes = _lines.Select(p => int.Parse(p[0..^1])).ToList();
        ShortestSequence = string.Empty;

        foreach (var line in _lines)
        {
            var currentSequence = line;
            foreach (var transformer in _transformers)
            {
                currentSequence = transformer.CalculateShortestSequence('A', currentSequence);
            }

            SumOfComplexities += currentSequence.Length * int.Parse(line[..^1]);
        }
    }

/*
    public void CalculateShortestNumericKeypad()
    {
        var currentAimed = _start;
        var currentSequence = string.Empty;

        foreach (var line in _lines)
        {
            foreach (var character in line)
            {
                currentSequence += _shortestNumericKeypadSequences[currentAimed][character];
                currentAimed = character;
            }
        }

        ShortestSequence = currentSequence;
    }

    public void CalculateShortestDirectionalKeypad()
    {
        var currentAimed = _start;
        var currentSequence = string.Empty;

        foreach (var line in _lines)
        {
            foreach (var character in line)
            {
                currentSequence += _shortestNumericKeypadSequences[currentAimed][character];
                currentAimed = character;
            }
        }

        ShortestSequence = currentSequence;

    }*/
}