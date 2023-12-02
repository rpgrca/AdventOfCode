
namespace Day2.Logic;

public class CubeConundrumGame
{
    private readonly string _input;
    private readonly string[] _games;

    public int Games => _games.Length;

    public CubeConundrumGame(string input)
    {
        _input = input;
        _games = _input.Split("\n");
    }
}
