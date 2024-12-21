namespace Day21.Logic;

public class KeypadTyping : IKeypadTyping
{
    private readonly Dictionary<char, Dictionary<char, string>> _layout;

    public static IKeypadTyping CreateNumericKeypad() =>
        new KeypadTyping(new() {
            { 'A', new() { { 'A', "A" }, { '0', "<A" }, { '1', "^<<A" }, { '2', "^<A" }, { '3', "^A" }, { '4', "^^<<A" }, { '5', "^^<A" }, { '6', "^^A" }, { '7', "^^^<<A" }, { '8', "^^^<A" }, { '9', "^^^A" } } },
            { '0', new() { { 'A', ">A" }, { '0', "A" }, { '1', "^<A" }, { '2', "^A" }, { '3', "^>A" }, { '4', "^^<A" }, { '5', "^^A" }, { '6', "^^>A" }, { '7', "^^^<A" }, { '8', "^^^A" }, { '9', "^^^>A" } } },
            { '1', new() { { 'A', ">>vA" }, { '0', ">vA" }, { '1', "A" }, { '2', ">A" }, { '3', ">>A" }, { '4', "^A" }, { '5', "^>A" }, { '6', "^>>A" }, { '7', "^^A" }, { '8', "^^>A" }, { '9', "^^>>A" } } },
            { '2', new() { { 'A', ">vA" }, { '0', "vA" }, { '1', "<A" }, { '2', "A" }, { '3', ">A" }, { '4', "<^A" }, { '5', "^A" }, { '6', "^>A" }, { '7', "^^<A" }, { '8', "^^A" }, { '9', ">^^A" } } },
            { '3', new() { { 'A', "v>" }, { '0', "v<A" }, { '1', "<<A" }, { '2', "<A" }, { '3', "A" }, { '4', "^<<A" }, { '5', "^<A" }, { '6', "^A" }, { '7', "^^<<A" }, { '8', "^^<A" }, { '9', "^^A" } } },
            { '4', new() { { 'A', ">>vvA" }, { '0', ">vvA" }, { '1', "vA" }, { '2', "v>A" }, { '3', "v>>A" }, { '4', "A" }, { '5', ">A" }, { '6', ">>A" }, { '7', "^A" }, { '8', "^>A" }, { '9', "^>>A" } } },
            { '5', new() { { 'A', "vv>A" }, { '0', "vv>" }, { '1', "v<A" }, { '2', "v>" }, { '3', "v>A" }, { '4', "<A" }, { '5', "A" }, { '6', ">A" }, { '7', "^<A" }, { '8', "^A" }, { '9', "^>A" } } },
            { '6', new() { { 'A', "vvA" }, { '0', "vv<A" }, { '1', "v<<A" }, { '2', "v<A" }, { '3', "vA" }, { '4', "<<A" }, { '5', "<A" }, { '6', "<" }, { '7', "^<<A" }, { '8', "^<A" }, { '9', "^A" } } },
            { '7', new() { { 'A', ">>vvvA" }, { '0', ">vvvA" }, { '1', "vvA" }, { '2', "vv>A" }, { '3', "vv>>A" }, { '4', "vA" }, { '5', "v>A" }, { '6', "v>>A" }, { '7', "A" }, { '8', ">A" }, { '9', ">>A" } } },
            { '8', new() { { 'A', "vvv>A" }, { '0', "vvvA" }, { '1', "vv<A" }, { '2', "vvA" }, { '3', "vv>A" }, { '4', "v<A" }, { '5', "vA" }, { '6', "v>A" }, { '7', "<A" }, { '8', "A" }, { '9', ">A" } } },
            { '9', new() { { 'A', "vvvA" }, { '0', "vvv<A" }, { '1', "vv<<A" }, { '2', "vv<A" }, { '3', "vvA" }, { '4', "v<<A" }, { '5', "v<A" }, { '6', "vA" }, { '7', "<<A" }, { '8', "<A" }, { '9', "A" } } }
        });

    public static KeypadTyping CreateDirectionalKeypad() =>
        new(new() {
            { 'A', new() { { 'A', "A" }, { '^', "<A" }, { 'v', "<vA" }, { '<', "v<<A" }, { '>', "vA" } } },
            { '^', new() { { 'A', ">A" }, { '^', "A" }, { 'v', "vA" }, { '<', "<vA" }, { '>', "v>A" } } },
            { 'v', new() { { 'A', ">^A" }, { '^', "^A" }, { 'v', "A" }, { '<', "<A" }, { '>', ">A" } } },
            { '<', new() { { 'A', ">>^A" }, { '^', ">^A" }, { 'v', ">A" }, { '<', "A" }, { '>', ">>A" } } },
            { '>', new() { { 'A', "^A" }, { '^', "<^A" }, { 'v', "<A" }, { '<', "<<A" }, { '>', "A" } } }
        });

    private KeypadTyping(Dictionary<char, Dictionary<char, string>> layout)
    {
        _layout = layout;
        /*
var shortestNumericKeypadSequences = new Dictionary<char, Dictionary<char, string>>();
var numericKeypad = new[,]
{
{ '7', '8', '9'},
{ '4', '5', '6'},
{ '1', '2', '3'},
{ '\0', '0', 'A'}
};

for (var y = 0; y < 4; y++)
{
for (var x = 0; x < 3; x++)
{
for (var y2 = 0; y2 < 4; y2++)
{
for (var x2 = 0; x2 < 3; x2++)
{
var result = FindShortestPath(x, y, x2, y2, numericKeypad);
}
}
}
}*/
    }

    public string CalculateShortestSequence(char initialKey, string sequenceToType)
    {
        var currentAimed = initialKey;
        var currentSequence = string.Empty;

        foreach (var character in sequenceToType)
        {
            currentSequence += _layout[currentAimed][character];
            currentAimed = character;
        }

        return currentSequence;
    }
}