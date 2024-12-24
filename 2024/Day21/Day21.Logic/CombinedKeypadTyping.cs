namespace Day21.Logic;

public class CombinedKeypadTyping : IKeypadTyping
{
    private readonly List<IKeypadTyping> _keypads;

    public CombinedKeypadTyping(List<IKeypadTyping> keypads)
    {
        _keypads = keypads;
    }

    public string CalculateShortestSequence(string sequenceToType)
    {
        var currentSequence = _keypads.First().CalculateShortestSequence(sequenceToType);
        foreach (var keypad in _keypads.Skip(1))
        {
            currentSequence = keypad.CalculateShortestSequence(currentSequence);
        }

        return currentSequence;
    }

    public void CountShortestSequence(string sequenceToType, Dictionary<string, long> memoization)
    {
        _keypads.First().CountShortestSequence(sequenceToType, memoization);
        foreach (var keypad in _keypads.Skip(1))
        {
            keypad.CountShortestSequence("", memoization);
        }
    }
}