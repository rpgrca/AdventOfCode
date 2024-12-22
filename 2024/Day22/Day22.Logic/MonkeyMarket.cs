
namespace Day22.Logic;

public class MonkeyMarket
{
    private const int PruneNumber = 16777216;
    private string _input;
    private readonly List<long> _list;

    public int Count => _list.Count;

    public long SumOfSecrets { get; private set; }

    public MonkeyMarket(string input)
    {
        _input = input;
        _list = _input.Split('\n').Select(long.Parse).ToList();
    }

    public void CalculateSumOfSecrets(int count)
    {
        SumOfSecrets = 0;
        for (var index = 0; index < Count; index++)
        {
            SumOfSecrets += Generate(index, count);
        }
    }

    public long Generate(int index, int count)
    {
        var secret = _list[index];

        while (count-- > 0)
        {
            secret = ((secret * 64) ^ secret) % PruneNumber;
            secret = ((secret / 32) ^ secret) % PruneNumber;
            secret = ((secret * 2048) ^ secret) % PruneNumber;
        }

        return secret;
    }

    public long GeneratePrice(int index, int count) => Generate(index, count) % 10;
}
