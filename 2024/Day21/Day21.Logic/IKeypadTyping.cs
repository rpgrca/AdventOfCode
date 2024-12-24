namespace Day21.Logic;

public interface IKeypadTyping
{
    string CalculateShortestSequence(string sequenceToType);
    void CountShortestSequence(string sequenceToType, Dictionary<string, long> memoization);
}