
namespace Day17.Logic;

public class ClumsyCrucible
{
    private readonly string _input;

    public int Width { get; private set; } = 10;
    public int Height { get; private set; } = 10;

    public ClumsyCrucible(string input)
    {
        _input = input;
    }
}
