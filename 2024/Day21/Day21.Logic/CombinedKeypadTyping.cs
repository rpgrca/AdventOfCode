namespace Day21.Logic;

public class CombinedKeypadTyping : IKeypadTyping
{
    private readonly List<IKeypadTyping> _keypads;

    public CombinedKeypadTyping(List<IKeypadTyping> keypads)
    {
        _keypads = keypads;
    }

    public string CalculateShortestSequence(char initialKey, string sequenceToType)
    {
        var currentSequence = sequenceToType;
        foreach (var keypad in _keypads)
        {
            currentSequence = keypad.CalculateShortestSequence(initialKey, currentSequence);
        }

        return currentSequence;
    }
}