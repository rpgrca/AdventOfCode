
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
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (_block[y][x] == 'X')
                {
                    FindXmasHorizontally(y, x);
                    FindXmasReverseHorizontally(y, x);
                    FindXmasVertically(y, x);
                    FindXmasReverseVertically(y, x);
                    FindXmasDiagonallyDownwards(y, x);
                    FindXmasDiagonallyReverseDownwards(y, x);
                    FindXmasDiagonallyUpwards(y, x);
                    FindXmasDiagonallyReverseUpwards(y, x);
                }

                if (_block[y][x] == 'A')
                {
                    FindX_MasDownwards(y, x);
                    FindX_MasUpwards(y, x);
                    FindX_MasDownwardsUpwards(y, x);
                    FindX_MasUpwardsDownwards(y, x);
                }
            }
        }
    }

    private void FindX_MasDownwards(int y, int x)
    {
        if (y >= 1 && y <= Height - 2 && x >= 1 && x <= Width - 2)
        {
            if (_block[y-1][x-1] == 'M' && _block[y+1][x+1] == 'S' && _block[y-1][x+1] == 'M' && _block[y+1][x-1] == 'S')
            {
                X_MasCount++;
            }
        }
    }

    private void FindX_MasUpwards(int y, int x)
    {
        if (y >= 1 && y <= Height - 2 && x >= 1 && x <= Width - 2)
        {
            if (_block[y-1][x-1] == 'S' && _block[y+1][x+1] == 'M' && _block[y-1][x+1] == 'S' && _block[y+1][x-1] == 'M')
            {
                X_MasCount++;
            }
        }
    }

    private void FindX_MasDownwardsUpwards(int y, int x)
    {
        if (y >= 1 && y <= Height - 2 && x >= 1 && x <= Width - 2)
        {
            if (_block[y-1][x-1] == 'M' && _block[y+1][x+1] == 'S' && _block[y-1][x+1] == 'S' && _block[y+1][x-1] == 'M')
            {
                X_MasCount++;
            }
        }
    }

    private void FindX_MasUpwardsDownwards(int y, int x)
    {
        if (y >= 1 && y <= Height - 2 && x >= 1 && x <= Width - 2)
        {
            if (_block[y-1][x-1] == 'S' && _block[y+1][x+1] == 'M' && _block[y-1][x+1] == 'M' && _block[y+1][x-1] == 'S')
            {
                X_MasCount++;
            }
        }
    }

    private void FindXmasHorizontally(int y, int x)
    {
        if (x <= Width - 4)
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

    private void FindXmasVertically(int y, int x)
    {
        if (y <= Height - 4)
        {
            if (_block[y+1][x] == 'M' && _block[y+2][x] == 'A' && _block[y+3][x] == 'S')
            {
                XmasCount++;
            }
        }
    }

    private void FindXmasReverseVertically(int y, int x)
    {
        if (y >= 3)
        {
            if (_block[y-1][x] == 'M' && _block[y-2][x] == 'A' && _block[y-3][x] == 'S')
            {
                XmasCount++;
            }
        }
    }

    private void FindXmasDiagonallyDownwards(int y, int x)
    {
        if ((x <= Width - 4) && (y <= Height - 4))
        {
            if (_block[y+1][x+1] == 'M' && _block[y+2][x+2] == 'A' && _block[y+3][x+3] == 'S')
            {
                XmasCount++;
            }
        }
    }

    private void FindXmasDiagonallyReverseDownwards(int y, int x)
    {
        if ((x >= 3) && (y <= Height - 4))
        {
            if (_block[y+1][x-1] == 'M' && _block[y+2][x-2] == 'A' && _block[y+3][x-3] == 'S')
            {
                XmasCount++;
            }
        }
    }

    private void FindXmasDiagonallyUpwards(int y, int x)
    {
        if ((x <= Width - 4) && (y >= 3))
        {
            if (_block[y-1][x+1] == 'M' && _block[y-2][x+2] == 'A' && _block[y-3][x+3] == 'S')
            {
                XmasCount++;
            }
        }
    }

    private void FindXmasDiagonallyReverseUpwards(int y, int x)
    {
        if ((x >= 3) && (y >= 3))
        {
            if (_block[y-1][x-1] == 'M' && _block[y-2][x-2] == 'A' && _block[y-3][x-3] == 'S')
            {
                XmasCount++;
            }
        }
    }

    public int Width => _block[0].Length;

    public int Height => _block.Length;

    public int XmasCount { get; private set; }
    public int X_MasCount { get; private set; }
}
