


namespace Day1.Logic;

public class HistoricallySignificantLocations
{
    private string[] _input;

    public HistoricallySignificantLocations(string input)
    {
        _input = input.Split("\n");
        Length = _input.Length;

        CalculateTotalDistance();
    }

    private void CalculateTotalDistance()
    {
        foreach (var input in _input)
        {
            var values = _input[0].Split(' ').Where(p => !string.IsNullOrWhiteSpace(p)).Select(int.Parse).ToList();
            TotalDistance += Math.Abs(values[0] - values[1]);
        }
    }

    public int Length { get; private set; }
    public int TotalDistance { get; set; }
}
