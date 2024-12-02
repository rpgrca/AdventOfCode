namespace Day1.Logic;

public class HistoricallySignificantLocations
{
    private readonly string[] _input;
    private readonly List<int> _firstColumn;
    private readonly List<int> _secondColumn;

    public int Length { get; private set; }
    public int TotalDistance { get; private set; }
    public int SimilarityScore { get; private set; }

    public HistoricallySignificantLocations(string input)
    {
        _firstColumn = new();
        _secondColumn = new();
        _input = input.Split("\n");
        Length = _input.Length;

        SplitLists();
        CalculateTotalDistance();
        CalculateSimilarityScore();
    }

    private void SplitLists()
    {
        var values = _input
            .Select(p => p.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToArray();

        _firstColumn.AddRange(values.Select(p => int.Parse(p[0])).Order());
        _secondColumn.AddRange(values.Select(p => int.Parse(p[1])).Order());
    }

    private void CalculateTotalDistance() =>
        TotalDistance = _firstColumn
            .Zip(_secondColumn)
            .Aggregate(0, (t, i) => t + Math.Abs(i.First - i.Second));

    private void CalculateSimilarityScore() =>
        SimilarityScore = _firstColumn
            .GroupJoin(_secondColumn, p => p, q => q, (p, q) => p * q.Count())
            .Sum();
}