namespace Day21.Logic;

public class KeypadTyping : IKeypadTyping
{
    private readonly Dictionary<char, Dictionary<char, List<string>>> _layout;
    private char _currentKey;
    private readonly Dictionary<(char currentKey, char targetKey), List<string>> _memoizedPaths = new();

    public static IKeypadTyping CreateNumericKeypad() =>
        new KeypadTyping(new() {
            { 'A', new() { { 'A', new() { "A" } }, { '0', new() { "<A" } }, { '1', new() { "^<<A" /*, "<^<A"*/ } }, { '2', new() { /*"^<A",*/ "<^A" } }, { '3', new() { "^A" } }, { '4', new() { "^^<<A", "^<^<A", "^<<^A", "<^^<A", "<^<^A" } }, { '5', new() { "^^<A", "^<^A", "<^^A" } }, { '6', new() { "^^A" } }, { '7', new() { "^^^<<A", "^^<^<A", "^^<<^A", "^<^^<A", "^<^<^A", "^<<^^A", "<^<^^A", "<^^<^A", "<^^^<A" } }, { '8', new() { "^^^<A", "^^<^A", "^<^^A", "<^^^A" } }, { '9', new() { "^^^A" } } } },
            { '0', new() { { 'A', new() { ">A" } }, { '0', new() { "A" } }, { '1', new() { "^<A" } }, { '2', new() { "^A" } }, { '3', new() { /*"^>A",*/ ">^A" } }, { '4', new() { "^^<A", "^<^A" } }, { '5', new() { "^^A" } }, { '6', new() { "^^>A", "^>^A", ">^^A" } }, { '7', new() { "^^^<A", "^^<^A", "^<^^A" } }, { '8', new() { "^^^A" } }, { '9', new() { "^^^>A", "^^>^A", "^>^^A", ">^^^A" } } } },
            { '1', new() { { 'A', new() { ">>vA", ">v>A" } }, { '0', new() { ">vA" } }, { '1', new() { "A" } }, { '2', new() { ">A" } }, { '3', new () { ">>A" } }, { '4', new() { "^A" } }, { '5', new() { /*"^>A",*/ ">^A" } }, { '6', new() { /*"^>>A", ">^>A",*/ ">>^A" } }, { '7', new() { "^^A" } }, { '8', new() { "^^>A", "^>^A", ">^^A" } }, { '9', new() { "^^>>A", "^>^>A", "^>>^A", ">^^>A", ">^>^A", ">>^^A" } } } },
            { '2', new() { { 'A', new() { /*">vA",*/ "v>A" } }, { '0', new() { "vA" } }, { '1', new() { "<A" } }, { '2', new() { "A" } }, { '3', new() { ">A" } }, { '4', new() { "<^A"/*, "^<A"*/ } }, { '5', new() { "^A" } }, { '6', new() { /*"^>A",*/ ">^A" } }, { '7', new() { "^^<A", "^<^A", "<^^" } }, { '8', new() { "^^A" } }, { '9', new() { ">^^A", "^>^A", "^^>A" } } } },
            { '3', new() { { 'A', new() { "vA" } }, { '0', new() { /*"v<A",*/ "<vA" } }, { '1', new() { "<<A" } }, { '2', new() { "<A" } }, { '3', new() { "A" } }, { '4', new() { /*"^<<A", "<^<A",*/ "<<^A" } }, { '5', new() { /*"^<A",*/ "<^A" } }, { '6', new() { "^A" } }, { '7', new() { "<<^^A", "<^<^A", "<^^<A", "^<<^A", "^<^<A", "^^<<A" } }, { '8', new() { "^^<A", "^<^A", "<^^A" } }, { '9', new() { "^^A" } } } },
            { '4', new() { { 'A', new() { ">>vvA", ">v>vA", ">vv>A", "v>>vA", "v>v>A" } }, { '0', new() { ">vvA", "v>vA" } }, { '1', new() { "vA" } }, { '2', new() { "v>A"/*, ">vA"*/ } }, { '3', new() { "v>>A"/*, ">v>A", ">>vA"*/ } }, { '4', new() { "A" } }, { '5', new() { ">A" } }, { '6', new() { ">>A" } }, { '7', new() { "^A" } }, { '8', new() { /*"^>A",*/ ">^A" } }, { '9', new() { /*"^>>A", ">^>A",*/ ">>^A" } } } },
            { '5', new() { { 'A', new() { "vv>A"/*, "v>vA", ">vvA"*/ } }, { '0', new() { "vvA" } }, { '1', new() { /*"v<A",*/ "<vA" } }, { '2', new() { "vA" } }, { '3', new() { "v>A"/*, ">vA"*/ } }, { '4', new() { "<A" } }, { '5', new() { "A" } }, { '6', new() { ">A" } }, { '7', new() { /*"^<A",*/ "<^A" } }, { '8', new() { "^A" } }, { '9', new() { /*"^>A",*/ ">^A" } } } },
            { '6', new() { { 'A', new() { "vvA" } }, { '0', new() { /*"vv<A",*/ "<vvA" } }, { '1', new() { /*"v<<A", "<v<A",*/ "<<vA" } }, { '2', new() { /*"v<A",*/ "<vA" } }, { '3', new() { "vA" } }, { '4', new() { "<<A" } }, { '5', new() { "<A" } }, { '6', new() { "A" } }, { '7', new() { /*"^<<A", "<^<A",*/ "<<^A" } }, { '8', new() { /*"^<A",*/ "<^A" } }, { '9', new() { "^A" } } } },
            { '7', new() { { 'A', new() { ">>vvvA", ">v>vvA", ">vv>vA", ">vvv>A", "v>>vvA", "v>v>vA", "v>vv>A", "vv>>vA", "vv>v>A" } }, { '0', new() { ">vvvA", "v>vvA", "vv>vA" } }, { '1', new() { "vvA" } }, { '2', new() { "vv>A"/*, "v>vA", ">vvA"*/ } }, { '3', new() { "vv>>A", "v>v>A", "v>>vA", ">vv>A", ">v>vA", ">>vvA" } }, { '4', new() { "vA" } }, { '5', new() { "v>A"/*, ">vA"*/ } }, { '6', new() { "v>>A"/*, ">v>A", ">>vA"*/ } }, { '7', new() { "A" } }, { '8', new() { ">A" } }, { '9', new() { ">>A" } } } },
            { '8', new() { { 'A', new() { "vvv>A", "vv>vA", "v>vvA", ">vvvA" } }, { '0', new() { "vvvA" } }, { '1', new() { /*"vv<A", "v<vA",*/ "<vvA" } }, { '2', new() { "vvA" } }, { '3', new() { "vv>A"/*, "v>vA", ">vvA"*/ } }, { '4', new() { /*"v<A",*/ "<vA" } }, { '5', new() { "vA" } }, { '6', new() { "v>A"/*, ">vA"*/ } }, { '7', new() { "<A" } }, { '8', new() { "A" } }, { '9', new() { ">A" } } } },
            { '9', new() { { 'A', new() { "vvvA" } }, { '0', new() { "vvv<A", "v<vvA", "vv<vA", "<vvvA" } }, { '1', new() { "vv<<A", "v<v<A", "v<<vA", "<vv<A", "<v<vA", "<<vvA" } }, { '2', new() { /*"vv<A", "v<vA",*/ "<vvA" } }, { '3', new() { "vvA" } }, { '4', new() { /*"v<<A", "<v<A",*/ "<<vA" } }, { '5', new() { /*"v<A",*/ "<vA" } }, { '6', new() { "vA" } }, { '7', new() { "<<A" } }, { '8', new() { "<A" } }, { '9', new() { "A" } } } }
        });

    public static KeypadTyping CreateDirectionalKeypad() =>
        new(new() {
            { 'A', new() { { 'A', new() { "A" } }, { '^', new() { "<A" } }, { 'v', new() { "<vA", /*"v<A"*/ } }, { '<', new() { "v<<A"/*, "<v<A"*/ } }, { '>', new() { "vA" } } } },
            { '^', new() { { 'A', new() { ">A" } }, { '^', new() { "A" } }, { 'v', new() { "vA" } }, { '<', new() { "v<A" } }, { '>', new() { "v>A"/*, ">vA"*/ } } } },
            { 'v', new() { { 'A', new() { ">^A"/*, "^>A"*/ } }, { '^', new() { "^A" } }, { 'v', new() { "A" } }, { '<', new() { "<A" } }, { '>', new() { ">A" } } } },
            { '<', new() { { 'A', new() { ">>^A"/*, ">^>A"*/ } }, { '^', new() { ">^A" } }, { 'v', new() { ">A" } }, { '<', new() { "A" } }, { '>', new() { ">>A" } } } },
            { '>', new() { { 'A', new() { "^A" } }, { '^', new() { "<^A"/*, "^<A"*/ } }, { 'v', new() { "<A" } }, { '<', new() { "<<A" } }, { '>', new() { "A" } } } }
        });

    private KeypadTyping(Dictionary<char, Dictionary<char, List<string>>> layout)
    {
        _layout = layout;
        _currentKey = 'A';
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
                        var results = FindShortestPaths(x, y, x2, y2, numericKeypad);
                    }
                }
            }
        }*/
    }

    public string CalculateShortestSequence(string sequenceToType)
    {
        var currentAimed = _currentKey;
        var currentSequence = string.Empty;

        foreach (var character in sequenceToType)
        {
            if (_memoizedPaths.TryGetValue((currentAimed, character), out var cachedResult))
            {
                currentSequence += cachedResult.First();
                currentAimed = character;
            }
            else
            {
                var collection = _layout[currentAimed][character];
                currentSequence += collection.First();
                currentAimed = character;
                _memoizedPaths[(currentAimed, character)] = collection;
            }
        }

        _currentKey = currentAimed;
        return currentSequence;
    }


    public List<List<string>> CalculateShortestSequence(List<List<string>> sequencesToType)
    {
        var result = new List<List<string>>();
        foreach (var sequenceToType in sequencesToType)
        {
            var subSequence = new List<string>();
            var shortestSequence = int.MaxValue;
            foreach (var option in sequenceToType)
            {
                var optionsPerCharacter = new List<List<string>>();
                foreach (var character in option)
                {
                    optionsPerCharacter.Add(_layout[_currentKey][character]);
                    _currentKey = character;
                }

                shortestSequence = BuildCombinations(optionsPerCharacter, subSequence, new(), shortestSequence);
            }

            result.Add(subSequence);
        }

        return result;
    }

    private int BuildCombinations(List<List<string>> optionsPerCharacter, List<string> subSequence, List<string> accumulatedString, int shortestSize, int index = 0)
    {
        if (index == optionsPerCharacter.Count)
        {
            var result = string.Concat(accumulatedString);
            if (result.Length < shortestSize)
            {
                subSequence.Clear();
                subSequence.Add(result);
                return result.Length;
            }
            else if (result.Length == shortestSize)
            {
                subSequence.Add(result);
            }

            return shortestSize;
        }

        foreach (var option in optionsPerCharacter[index])
        {
            accumulatedString.Add(option);
            var newShortestSize = BuildCombinations(optionsPerCharacter, subSequence, accumulatedString, shortestSize, index + 1);
            accumulatedString.RemoveAt(accumulatedString.Count - 1);
            shortestSize = Math.Min(shortestSize, newShortestSize);
        }

        return shortestSize;
    }
}