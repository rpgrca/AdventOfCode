

namespace Day2.Logic;

public class CubeConundrumGame
{
    private readonly string _input;
    private readonly string[] _lines;

    public int GameCount => _lines.Length;

    public List<(int Index, List<(int Blue, int Red, int Green)> Draws)> Games { get; private set; }
    public int SumOfValidGameIds { get; private set; }
    public int SumOfPowers { get; set; }

    public CubeConundrumGame(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Games = new List<(int, List<(int Blue, int Red, int Green)>)>();

        Parse();
        FilterValidGames();
        CalculateSumOfPowers();
    }

    private void CalculateSumOfPowers()
    {
        foreach (var game in Games)
        {
            var maximumRed = game.Draws.Max(d => d.Red);
            var maximumBlue = game.Draws.Max(d => d.Blue);
            var maximumGreen = game.Draws.Max(d => d.Green);

            SumOfPowers += maximumRed * maximumBlue * maximumGreen;
        }
    }

    private void Parse()
    {
        for (var index = 0; index < _lines.Length; index++)
        {
            var fields = _lines[index].Split(":");
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

            Games.Add((index + 1, draws));
        }
    }

    private void FilterValidGames()
    {
        var filteredGames = Games.Where(IsValidGame);
        SumOfValidGameIds = filteredGames.Sum(g => g.Index);
    }

    private static bool IsValidGame((int Index, List<(int Blue, int Red, int Green)> Draws) draws)
    {
        return !draws.Draws.Any(d => d.Red > 12 || d.Green > 13 || d.Blue > 14);
    }
}
