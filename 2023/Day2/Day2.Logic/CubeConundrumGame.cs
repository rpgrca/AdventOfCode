

namespace Day2.Logic;

public class CubeConundrumGame
{
    private readonly string _input;
    private readonly string[] _lines;

    public int GameCount => _lines.Length;

    public List<List<(int Blue, int Red, int Green)>> Games { get; private set; }

    public CubeConundrumGame(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Games = new List<List<(int Blue, int Red, int Green)>>();

        Parse();
    }

    private void Parse()
    {
        foreach (var line in _lines)
        {
            var fields = line.Split(":");
            var games = fields[1].Split(";");

            var draws = new List<(int, int, int)>();

            foreach (var game in games)
            {
                var values = game.Trim().Split(",");

                (int Blue, int Red, int Green) cubes = (0, 0, 0);
                foreach (var value in values)
                {
                    var data = value.Trim().Split(" ");
                    switch (data[1].Trim())
                    {
                        case "red": cubes.Red = int.Parse(data[0].Trim()); break;
                        case "blue": cubes.Blue = int.Parse(data[0].Trim()); break;
                        case "green": cubes.Green = int.Parse(data[0].Trim()); break;
                    }
                }

                draws.Add(cubes);
            }

            Games.Add(draws);
        }
    }
}
