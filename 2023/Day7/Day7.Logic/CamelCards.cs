
namespace Day7.Logic;
public class CamelCards
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Hands => _lines.Length;

    public CamelCards(string input)
    {
        _input = input;
        _lines = input.Split("\n");
    }

}
