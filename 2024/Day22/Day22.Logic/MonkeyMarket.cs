

namespace Day22.Logic;

public class MonkeyMarket
{
    private const int PruneNumber = 16777216;
    private string _input;
    private readonly List<long> _buyers;
    private readonly List<long>[] _secrets;
    private readonly List<long>[] _changes;
    private readonly List<long>[] _prices;

    public int Count => _buyers.Count;

    public long SumOfSecrets { get; private set; }

    public MonkeyMarket(string input, int transactions)
    {
        _input = input;
        _buyers = _input.Split('\n').Select(long.Parse).ToList();
        _secrets = _buyers.Select(p => new List<long>() { p }).ToArray();
        _prices = _secrets.Select(p => new List<long>() { p[0] % 10 }).ToArray();
        _changes = _buyers.Select(p => new List<long>() { 0 }).ToArray();

        for (var index = 0; index < Count; index++)
        {
            var secret = _buyers[index];
            var lastPrice = _prices[index][0];

            for (var currentTransaction = 0; currentTransaction < transactions; currentTransaction++)
            {
                secret = ((secret << 6) ^ secret) % PruneNumber;
                secret = ((secret >> 5) ^ secret) % PruneNumber;
                secret = ((secret << 11) ^ secret) % PruneNumber;

                _secrets[index].Add(secret);
                var price = secret % 10;
                _prices[index].Add(price);
                _changes[index].Add(price - lastPrice);
                lastPrice = price;
            }
        }
    }

    public void CalculateSumOfLastSecrets() => SumOfSecrets = _secrets.Sum(p => p.Last());

    public long Generate(int index, int count) => _secrets[index][count];

    public long GeneratePrice(int index, int count) => _prices[index][count];

    public long CalculateChange(int index, int count) =>
        count == 0? throw new ArgumentException($"Count cannot be zero") : _changes[index][count];
}
