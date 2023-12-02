

namespace Day2.Logic;

public class CubeConundrumGame
{
    private readonly string _input;
    private readonly string[] _games;

    public int GameCount => _games.Length;

    public List<(int Blue, int Red, int Green)> Games { get; private set; }

    public CubeConundrumGame(string input)
    {
        _input = input;
        _games = _input.Split("\n");
        Games = new List<(int Blue, int Red, int Green)>();

        Parse();
    }

    private void Parse()
    {
        var fields = _input.Split(":");
        var games = fields[1].Split(";");

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

            Games.Add(cubes);
        }
    }
}
