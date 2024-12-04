

using System.Linq.Expressions;

namespace Day4.Logic;

public class WordSearch
{
    private readonly string _input;
    private readonly string[] _block;

    public WordSearch(string input)
    {
        _input = input;
        _block = input.Split("\n");

        FindXmas();
    }

    private void FindXmas()
    {
        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                if (_block[y][x] == 'X')
                {
                    FindXmasHorizontally(y, x);
                    FindXmasReverseHorizontally(y, x);
                }
            }
        }
    }

    private void FindXmasHorizontally(int y, int x)
    {
        if (x <= Length - 4)
        {
            if (_block[y][x+1] == 'M' && _block[y][x+2] == 'A' && _block[y][x+3] == 'S')
            {
                XmasCount++;
            }
        }
    }

    private void FindXmasReverseHorizontally(int y, int x)
    {
        if (x >= 3)
        {
            if (_block[y][x-1] == 'M' && _block[y][x-2] == 'A' && _block[y][x-3] == 'S')
            {
                XmasCount++;
            }
        }
    }

    public int Length => _block.Length;

    public int XmasCount { get; private set; }
}
