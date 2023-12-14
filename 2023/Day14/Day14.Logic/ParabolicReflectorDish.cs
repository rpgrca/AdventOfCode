


using System.Security.Cryptography.X509Certificates;

namespace Day14.Logic;

public class ParabolicReflectorDish
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Height { get; private set; }
    public int Width { get; private set; }
    public List<List<char>> CurrentMap { get; private set; }

    public ParabolicReflectorDish(string input)
    {
        _input = input;
        _lines = input.Split("\n");

        Height = _lines.Length;
        Width = _lines[0].Length;
        CurrentMap = new List<List<char>>();

        foreach (var line in _lines)
        {
            CurrentMap.Add(line.Select(c => c).ToList());
        }
    }

    public void TiltNorth()
    {
        for (var y = 0; y < CurrentMap.Count; y++)
        {
            if (CurrentMap[y][0] == 'O')
            {
                var calculatedY = y - 1;
                while (calculatedY >= 0 && CurrentMap[calculatedY][0] == '.')
                {
                    calculatedY--;
                }

                calculatedY += 1;
                CurrentMap[y][0] = '.';
                CurrentMap[calculatedY][0] = 'O';
            }
        }
    }
}
