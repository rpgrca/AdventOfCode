using System.Text;

namespace Day18.Logic;

public class RamRun
{
    private readonly string _input;
    private readonly List<(int X, int Y)> _corruptedMemory;

    public int Count => _corruptedMemory.Count;

    public int Size { get; private set; }
    private readonly char[,] _memoryMap;

    public RamRun(string input, int size)
    {
        _input = input;
        Size = size;
        _memoryMap = new char[Size,Size];
        for (var y = 0; y < Size; y++)
            for (var x = 0; x < Size; x++)
                _memoryMap[y,x] = '.';

        _corruptedMemory = _input.Split('\n')
            .Select(p => (int.Parse(p.Split(',')[0]), int.Parse(p.Split(',')[1])))
            .ToList();
    }

    public void Load(int bytes)
    {
        foreach (var corruptedMemory in _corruptedMemory.Take(bytes))
        {
            _memoryMap[corruptedMemory.Y, corruptedMemory.X] = '#';
        }
    }

    public string Plot()
    {
        var sb = new StringBuilder();
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                sb.Append(_memoryMap[y, x]);
            }

            sb.AppendLine();
        }

        return sb.ToString().Trim();
    }
}
