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
        var firstColumn = new List<int>();
        var secondColumn = new List<int>();
        foreach (var input in _input)
        {
            var values = input.Split(' ').Where(p => !string.IsNullOrWhiteSpace(p)).Select(int.Parse).ToList();
            firstColumn.Add(values[0]);
            secondColumn.Add(values[1]);
        }

        _firstColumn.AddRange(firstColumn.Order());
        _secondColumn.AddRange(secondColumn.Order());
    }

    private void CalculateTotalDistance()
    {
        for (var index = 0; index < Length; index++)
        {
            TotalDistance += Math.Abs(_firstColumn[index] - _secondColumn[index]);
        }
    }

   private void CalculateSimilarityScore() =>
        SimilarityScore = _firstColumn
            .GroupJoin(_secondColumn, p => p, q => q, (p, q) => p * q.Count())
            .Sum();
}