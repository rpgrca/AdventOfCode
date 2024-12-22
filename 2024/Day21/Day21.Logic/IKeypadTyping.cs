namespace Day21.Logic;

public interface IKeypadTyping
{
    List<List<string>> CalculateShortestSequence(List<List<string>> sequenceToType);
    string CalculateShortestSequence(string sequenceToType);
}