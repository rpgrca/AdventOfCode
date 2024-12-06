namespace Day5.Logic;

public class UpdatesLoader
{
    private readonly string _input;
    public List<List<int>> Updates { get; }

    public UpdatesLoader(string input)
    {
        _input = input;
        Updates = new();

        Load();
    }

    private void Load()
    {
        var lines = _input.Split('\n');

        foreach (var line in lines)
        {
            Updates.Add(line.Split(',').Select(int.Parse).ToList());
        }
    }
}