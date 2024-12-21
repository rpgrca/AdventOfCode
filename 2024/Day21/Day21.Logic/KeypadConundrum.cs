namespace Day21.Logic;

public class KeypadConundrum
{
    private readonly char _start;
    private readonly string[] _lines;
    private readonly Dictionary<char, Dictionary<char, string>> _shortestNumericKeypadSequences;

    public List<int> Codes { get; set; }
    public string ShortestSequence { get; private set; }

    public KeypadConundrum(char start, string input)
    {
        _start = start;
        _lines = input.Split('\n');
        Codes = _lines.Select(p => int.Parse(p[0..^1])).ToList();

        _shortestNumericKeypadSequences = new Dictionary<char, Dictionary<char, string>>
        {
            { 'A', new() { { 'A', "A" }, { '0', "<A" }, { '1', "^<<A" }, { '2', "^<A" }, { '3', "^A" }, { '4', "^^<<A" }, { '5', "^^<A" }, { '6', "^^A" }, { '7', "^^^<<A" }, { '8', "^^^<A" }, { '9', "^^^A" } } },
            { '0', new() { { 'A', ">A" }, { '0', "A" }, { '1', "^<A" }, { '2', "^A" }, { '3', "^>A" }, { '4', "^^<A" }, { '5', "^^A" }, { '6', "^^>A" }, { '7', "^^^<A" }, { '8', "^^^A" }, { '9', "^^^>A" } } },
            { '1', new() { { 'A', ">>vA" }, { '0', ">vA" }, { '1', "A" }, { '2', ">A" }, { '3', ">>A" }, { '4', "^A" }, { '5', "^>A" }, { '6', "^>>A" }, { '7', "^^A" }, { '8', "^^>A" }, { '9', "^^>>A" } } },
            { '2', new() { { 'A', ">vA" }, { '0', "vA" }, { '1', "<A" }, { '2', "A" }, { '3', ">A" }, { '4', "<^A" }, { '5', "^A" }, { '6', "^>A" }, { '7', "^^<A" }, { '8', "^^A" }, { '9', "^^>A" } } },
            { '3', new() { { 'A', "v>" }, { '0', "v<A" }, { '1', "<<A" }, { '2', "<A" }, { '3', "A" }, { '4', "^<<A" }, { '5', "^<A" }, { '6', "^A" }, { '7', "^^<<A" }, { '8', "^^<A" }, { '9', "^^A" } } },
            { '4', new() { { 'A', ">>vvA" }, { '0', ">vvA" }, { '1', "vA" }, { '2', "v>A" }, { '3', "v>>A" }, { '4', "A" }, { '5', ">A" }, { '6', ">>A" }, { '7', "^A" }, { '8', "^>A" }, { '9', "^>>A" } } },
            { '5', new() { { 'A', "vv>A" }, { '0', "vv>" }, { '1', "v<A" }, { '2', "v>" }, { '3', "v>A" }, { '4', "<A" }, { '5', "A" }, { '6', ">A" }, { '7', "^<A" }, { '8', "^A" }, { '9', "^>A" } } },
            { '6', new() { { 'A', "vvA" }, { '0', "vv<A" }, { '1', "v<<A" }, { '2', "v<A" }, { '3', "vA" }, { '4', "<<A" }, { '5', "<A" }, { '6', "<" }, { '7', "^<<A" }, { '8', "^<A" }, { '9', "^A" } } },
            { '7', new() { { 'A', ">>vvvA" }, { '0', ">vvvA" }, { '1', "vvA" }, { '2', "vv>A" }, { '3', "vv>>A" }, { '4', "vA" }, { '5', "v>A" }, { '6', "v>>A" }, { '7', "A" }, { '8', ">A" }, { '9', ">>A" } } },
            { '8', new() { { 'A', "vvv>A" }, { '0', "vvvA" }, { '1', "vv<A" }, { '2', "vvA" }, { '3', "vv>A" }, { '4', "v<A" }, { '5', "vA" }, { '6', "v>A" }, { '7', "<A" }, { '8', "A" }, { '9', ">A" } } },
            { '9', new() { { 'A', "vvvA" }, { '0', "vvv<A" }, { '1', "vv<<A" }, { '2', "vv<A" }, { '3', "vvA" }, { '4', "v<<A" }, { '5', "v<A" }, { '6', "vA" }, { '7', "<<A" }, { '8', "<A" }, { '9', "A" } } }
        };
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
}
