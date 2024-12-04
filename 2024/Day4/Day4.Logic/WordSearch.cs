namespace Day4.Logic;

public class WordSearch
{
    private readonly string[] _block;

    public int Width => _block[0].Length;

    public int Height => _block.Length;

    public int XmasCount { get; private set; }

    public WordSearch(string input, IXmasCounter xmasCounter)
    {
        _block = input.Split("\n");
        XmasCount = xmasCounter.Count(_block);
    }
}