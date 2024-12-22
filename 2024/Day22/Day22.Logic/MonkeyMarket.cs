
namespace Day22.Logic;

public class PriceVariation
{
    public long Item1;
    public long Item2;
    public long Item3;
    public long Item4;

    public PriceVariation(long item1, long item2, long item3, long item4)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
        Item4 = item4;
    }
}

public class MonkeyMarket
{
    private const int PruneNumber = 16777216;
    private readonly string _input;
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

    public ((long, long, long, long) Combination, long Bananas) FindBestCombination()
    {
        var combinations = new List<PriceVariation>();
        for (var index = 0; index < Count; index++)
        {
            for (var subIndex = 4; subIndex < _changes[index].Count; subIndex++)
            {
                if (_prices[index][subIndex] == 6 || _prices[index][subIndex] == 7)
                {
                    combinations.Add(new(
                        _changes[index][subIndex - 3],
                        _changes[index][subIndex - 2],
                        _changes[index][subIndex - 1],
                        _changes[index][subIndex]));
                }
            }
        }

        PriceVariation? bestCombination = default;
        var maximumSum = 0L;

        foreach (var combination in combinations.Distinct())
        {
            var sum = 0L;
            for (var index = 0; index < _changes.Length; index++)
            {
                var buyer = _changes[index];
                var maximum = 0L;
                for (var subIndex = 4; subIndex < buyer.Count; subIndex++)
                {
                    if (buyer[subIndex] == combination.Item4 && buyer[subIndex-1] == combination.Item3 && buyer[subIndex-2] == combination.Item2 && buyer[subIndex-3] == combination.Item1)
                    {
                        maximum = _prices[index][subIndex];
                        break;
                    }
                }

                sum += maximum;
            }

            if (maximumSum < sum)
            {
                maximumSum = sum;
                bestCombination = combination;
            }
        }

        return ((bestCombination!.Item1, bestCombination.Item2, bestCombination.Item3, bestCombination.Item4), maximumSum);
    }
}
