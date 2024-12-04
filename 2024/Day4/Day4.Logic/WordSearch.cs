
namespace Day4.Logic;

public class WordSearch
{
    private readonly string _input;
    private readonly string[] _block;

    public WordSearch(string input)
    {
        _input = input;
        _block = input.Split("\n");
    }

    public int Length => _block.Length;
}
