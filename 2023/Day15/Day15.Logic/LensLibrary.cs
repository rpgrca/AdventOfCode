

namespace Day15.Logic;
public class LensLibrary
{
    private readonly string _input;
    private readonly string[] _sequence;
    public int SumOfHashes { get; private set; }

    public LensLibrary(string input)
    {
        _input = input;
        _sequence = _input.Split(",");
        Boxes = new List<List<(string Label, int FocalLength)>>()
        {
            new List<(string Label, int FocalLength)>()
            {
                ("rn", 1)
            },
            new List<(string Label, int FocalLength)>()
            {
                ("qp", 3)
            }
        };

        SumOfHashes = 0;
        foreach (var sentence in _sequence)
        {
            var currentValue = 0;
            foreach (var character in sentence)
            {
                currentValue += character;
                currentValue *= 17;
                currentValue %= 256;
            }

            SumOfHashes += currentValue;
        }
    }

    public int SequenceCount => _sequence.Length;

    public List<List<(string Label, int FocalLength)>> Boxes { get; set; }
}
