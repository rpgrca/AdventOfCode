


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
        for (var x = 0; x < CurrentMap[0].Count; x++)
        {
            for (var y = 0; y < CurrentMap.Count; y++)
            {
                if (CurrentMap[y][x] == 'O')
                {
                    var calculatedY = y - 1;
                    while (calculatedY >= 0 && CurrentMap[calculatedY][x] == '.')
                    {
                        calculatedY--;
                    }

                    calculatedY += 1;
                    CurrentMap[y][x] = '.';
                    CurrentMap[calculatedY][x] = 'O';
                }
            }
        }
    }
}
