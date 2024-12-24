namespace Day21.Logic;

public class KeypadTyping : IKeypadTyping
{
    private readonly Dictionary<char, Dictionary<char, string>> _layout;

    public static IKeypadTyping CreateNumericKeypad() =>
        new KeypadTyping(new() {
            { 'A', new() { { 'A', "A" }, { '0', "<A" }, { '1', "^<<A" }, { '2', "<^A" }, { '3', "^A" }, { '4', "^^<<A" }, { '5', "<^^A" }, { '6', "^^A" }, { '7', "^^^<<A" }, { '8', "<^^^A" }, { '9',  "^^^A" } } },
            { '0', new() { { 'A', ">A" }, { '0', "A" }, { '1', "^<A" }, { '2', "^A" }, { '3', "^>A" }, { '4', "^^<A" }, { '5', "^^A" }, { '6', "^^>A" }, { '7', "^^^<A" }, { '8', "^^^A" }, { '9', "^^^>A" } } },
            { '1', new() { { 'A', ">>vA" }, { '0', ">vA" }, { '1', "A" }, { '2', ">A" }, { '3', ">>A" }, { '4', "^A" }, { '5', "^>A" }, { '6', "^>>A" }, { '7', "^^A" }, { '8', "^^>A" }, { '9', "^^>>A" } } },
            { '2', new() { { 'A', "v>A" }, { '0', "vA" }, { '1', "<A" }, { '2', "A" }, { '3', ">A" }, { '4', "<^A" }, { '5', "^A" }, { '6', "^>A" }, { '7', "<^^" }, { '8', "^^A" }, { '9', "^^>A" } } },
            { '3', new() { { 'A', "vA" }, { '0', "<vA" }, { '1', "<<A" }, { '2', "<A" }, { '3', "A" }, { '4', "<<^A" }, { '5', "<^A" }, { '6', "^A" }, { '7', "<<^^A" }, { '8', "<^^A" }, { '9', "^^A" } } },
            { '4', new() { { 'A', ">>vvA" }, { '0', ">vvA" }, { '1', "vA" }, { '2', "v>A" }, { '3', "v>>A" }, { '4', "A" }, { '5', ">A" }, { '6', ">>A" }, { '7', "^A" }, { '8', "^>A" }, { '9', "^>>A" } } },
            { '5', new() { { 'A', "vv>A" }, { '0', "vvA" }, { '1', "<vA" }, { '2', "vA" }, { '3', "v>A" }, { '4', "<A" }, { '5', "A" }, { '6', ">A" }, { '7', "<^A" }, { '8', "^A" }, { '9', "^>A" } } },
            { '6', new() { { 'A', "vvA" }, { '0', "<vvA" }, { '1', "<<vA" }, { '2', "<vA" }, { '3', "vA" }, { '4', "<<A" }, { '5', "<A" }, { '6', "A" }, { '7', "<<^A" }, { '8', "<^A" }, { '9', "^A" } } },
            { '7', new() { { 'A', ">>vvvA" }, { '0', ">vvvA" }, { '1', "vvA" }, { '2', "vv>A" }, { '3', ">>vvA" }, { '4', "vA" }, { '5', "v>A" }, { '6', "v>>A" }, { '7', "A" }, { '8', ">A" }, { '9', ">>A" } } },
            { '8', new() { { 'A', "vvv>A" }, { '0', "vvvA" }, { '1', "<vvA" }, { '2', "vvA" }, { '3', "vv>A" }, { '4', "<vA" }, { '5', "vA" }, { '6', "v>A" }, { '7', "<A" }, { '8', "A" }, { '9', ">A" } } },
            { '9', new() { { 'A', "vvvA" }, { '0', "<vvvA" }, { '1', "<<vvA" }, { '2', "<vvA" }, { '3', "vvA" }, { '4', "<<vA" }, { '5', "<vA" }, { '6', "vA" }, { '7', "<<A" }, { '8', "<A" }, { '9', "A" } } }
        });

    public static KeypadTyping CreateDirectionalKeypad() =>
        new(new() {
            { 'A', new() { { 'A', "A" }, { '^', "<A" }, { 'v', "<vA" }, { '<', "v<<A" }, { '>', "vA" } } },
            { '^', new() { { 'A', ">A" }, { '^', "A" }, { 'v', "vA" }, { '<', "v<A" }, { '>', "v>A" } } },
            { 'v', new() { { 'A', "^>A" }, { '^', "^A" }, { 'v', "A" }, { '<', "<A" }, { '>', ">A" } } },
            { '<', new() { { 'A', ">>^A" }, { '^', ">^A" }, { 'v', ">A" }, { '<', "A" }, { '>', ">>A" } } },
            { '>', new() { { 'A', "^A" }, { '^', "<^A" }, { 'v', "<A" }, { '<', "<<A" }, { '>', "A" } } }
        });

    private KeypadTyping(Dictionary<char, Dictionary<char, string>> layout)
    {
        _layout = layout;
    }

    public string CalculateShortestSequence(string sequenceToType)
    {
        var currentAimed = 'A';
        var currentSequence = string.Empty;

        foreach (var character in sequenceToType)
        {
            var sequence = _layout[currentAimed][character];
            currentSequence += sequence;
            currentAimed = character;
        }

        return currentSequence;
    }

    public void CountShortestSequence(string sequenceToType, Dictionary<string, long> memoization)
    {
        var currentAimed = 'A';

        if (string.IsNullOrEmpty(sequenceToType))
        {
            var currentMemoization = memoization.Where(p => p.Value > 0).ToDictionary(p => p.Key, p => p.Value);
            foreach (var currentGroup in currentMemoization)
            {
                foreach (var character in currentGroup.Key)
                {
                    var sequence = _layout[currentAimed][character];
                    memoization.TryAdd(sequence, 0);
                    memoization[sequence] += currentGroup.Value;
                    currentAimed = character;
                }

                memoization[currentGroup.Key] -= currentGroup.Value;
            }
        }
        else
        {
            foreach (var character in sequenceToType)
            {
                var sequence = _layout[currentAimed][character];
                memoization.TryAdd(sequence, 0);
                memoization[sequence]++;
                currentAimed = character;
            }
        }
    }
}