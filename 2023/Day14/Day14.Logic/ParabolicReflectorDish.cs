


using System.Security.Cryptography.X509Certificates;

namespace Day14.Logic;

public class ParabolicReflectorDish
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Height { get; private set; }
    public int Width { get; private set; }
    public List<List<char>> CurrentMap { get; private set; }
    public int NorthernLoad { get; private set; }

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

    public void CalculateNorthernLoad()
    {
        NorthernLoad = 0;
        for (var y = 0; y < CurrentMap.Count; y++)
        {
            for (var x = 0; x < CurrentMap[y].Count; x++)
            {
                if (CurrentMap[y][x] == 'O')
                {
                    NorthernLoad += Height - y;
                }
            }
        }
    }

    public void TiltWest()
    {
        for (var y = 0; y < CurrentMap.Count; y++)
        {
            for (var x = 0; x < CurrentMap[y].Count; x++)
            {
                if (CurrentMap[y][x] == 'O')
                {
                    var calculatedX = x - 1;
                    while (calculatedX >= 0 && CurrentMap[y][calculatedX] == '.')
                    {
                        calculatedX--;
                    }

                    calculatedX += 1;
                    CurrentMap[y][x] = '.';
                    CurrentMap[y][calculatedX] = 'O';
                }
            }
        }
    }

    public void TiltEast()
    {
        for (var y = 0; y < CurrentMap.Count; y++)
        {
            for (var x = CurrentMap[y].Count - 1; x >= 0; x--)
            {
                if (CurrentMap[y][x] == 'O')
                {
                    var calculatedX = x + 1;
                    while (calculatedX < CurrentMap[y].Count && CurrentMap[y][calculatedX] == '.')
                    {
                        calculatedX++;
                    }

                    calculatedX -= 1;
                    CurrentMap[y][x] = '.';
                    CurrentMap[y][calculatedX] = 'O';
                }
            }
        }
    }

    public void TiltSouth()
    {
        for (var x = 0; x < CurrentMap[0].Count; x++)
        {
            for (var y = CurrentMap.Count - 1; y >= 0; y--)
            {
                if (CurrentMap[y][x] == 'O')
                {
                    var calculatedY = y + 1;
                    while (calculatedY < CurrentMap[0].Count && CurrentMap[calculatedY][x] == '.')
                    {
                        calculatedY++;
                    }

                    calculatedY -= 1;
                    CurrentMap[y][x] = '.';
                    CurrentMap[calculatedY][x] = 'O';
                }
            }
        }
    }

    public void Spin()
    {
        TiltNorth();
        TiltWest();
        TiltSouth();
        TiltEast();
    }
}
