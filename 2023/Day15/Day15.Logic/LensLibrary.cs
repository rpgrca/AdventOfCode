

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
        Boxes = new List<List<(string Label, int FocalLength)>>();
        for (var index = 0; index < 256; index++)
        {
            Boxes.Add(new List<(string Label, int FocalLength)>());
        }

        SumOfHashes = 0;
        foreach (var sentence in _sequence)
        {
            SumOfHashes += CalculateHash(sentence);
        }

        foreach (var sentence in _sequence)
        {
            var operands = sentence.Split("=");
            if (operands.Length == 2)
            {
                var hash = CalculateHash(operands[0]);
                var lens = (operands[0], int.Parse(operands[1]));
                for (var index = 0; index < Boxes[hash].Count; index++)
                {
                    if (Boxes[hash][index].Label == operands[0])
                    {
                        Boxes[hash][index] = lens;
                        goto NextSentence;
                    }
                }

                Boxes[hash].Add(lens);
            }
            else
            {
                var label = operands[0][0..^1];
                var hash = CalculateHash(label);
                for (var index = 0; index < Boxes[hash].Count; index++)
                {
                    if (Boxes[hash][index].Label == label)
                    {
                        Boxes[hash].Remove(Boxes[hash][index]);
                        goto NextSentence;
                    }
                }
            }

            NextSentence:;
        }
    }

    private static int CalculateHash(string sentence)
    {
        var currentValue = 0;
        foreach (var character in sentence)
        {
            currentValue += character;
            currentValue *= 17;
            currentValue %= 256;
        }

        return currentValue;
    }

    public int SequenceCount => _sequence.Length;

    public List<List<(string Label, int FocalLength)>> Boxes { get; set; }
}
