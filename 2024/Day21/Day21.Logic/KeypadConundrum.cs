
namespace Day21.Logic;

public class KeypadConundrum
{
    private readonly char _start;
    private readonly string[] _lines;

    public List<int> Codes { get; set; }
    public string ShortestSequence { get; private set; }

    public KeypadConundrum(char start, string input)
    {
        _start = start;
        _lines = input.Split('\n');
        Codes = _lines.Select(p => int.Parse(p[0..^1])).ToList();
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