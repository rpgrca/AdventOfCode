namespace Day22.Logic;

public class MonkeyMarket
{
    private const long PruneNumber = 16777216;
    private string _input;
    private readonly List<long> _list;
    private readonly long[] _currentPrice;

    public int Count => _list.Count;

    public long SumOfSecrets { get; private set; }

    public MonkeyMarket(string input)
    {
        _input = input;
        _list = _input.Split('\n').Select(long.Parse).ToList();
        _currentPrice = _list.ToArray();
    }

    public void CalculateSumOfSecrets(int count)
    {
        /*
        while (count-- > 0)
        {
            for (var index = 0; index < Count; index++)
            {
                // 1000000000000000000000000
                var secret = _currentPrice[index];
                secret = (secret ^ (secret * 64L)) % PruneNumber;
                secret = ((secret / 32L) ^ secret) % PruneNumber;
                secret = ((secret * 2048L) ^ secret) % PruneNumber;
                _currentPrice[index] = secret;
            }
        }*/

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
}
