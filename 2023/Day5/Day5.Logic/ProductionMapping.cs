


namespace Day5.Logic;
public class ProductionMapping
{
    private readonly string _input;
    private List<long> _seeds;
    private readonly List<List<Func<long, long>>> _maps;
    private readonly List<(long Start, long Count)> _seedRanges;

    public int SeedsCount => _seeds.Count;
    public int SeedToSoilCount => _maps[0].Count;
    public int SoilToFertilizerCount => _maps[1].Count;
    public int FertilizerToWaterCount => _maps[2].Count;
    public int WaterToLightCount => _maps[3].Count;
    public int LightToTemperatureCount => _maps[4].Count;
    public int TemperatureToHumidityCount => _maps[5].Count;
    public int HumidityToLocationCount => _maps[6].Count;

    public long MinimumLocation { get; private set; }

    public ProductionMapping(string input, bool asRange = false)
    {
        _input = input;
        _seeds = new List<long>();
        _maps = new List<List<Func<long, long>>>();
        _seedRanges = new List<(long Start, long Count)>();
        for (var index = 0; index < 7; index++)
        {
            _maps.Add(new List<Func<long, long>>());
        }

        Parse();

        if (asRange)
        {
            CalculateMinimumLocationWithRanges();
        }
        else
        {
            CalculateMinimumLocation();
        }
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        var currentSection = "";
        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var section = line.Split(":");
            if (section.Length > 1)
            {
                if (section[0] == "seeds")
                {
                    _seeds = section[1].Trim().Split(" ").Select(long.Parse).ToList();

                    for (var index = 0; index < _seeds.Count - 1; index += 2)
                    {
                        _seedRanges.Add((_seeds[index], _seeds[index + 1]));
                    }
                }
                else
                {
                    currentSection = section[0];
                }
            }
            else
            {
                var values = section[0].Trim().Split(" ").Select(long.Parse).ToArray();

                switch (currentSection)
                {
                    case "seed-to-soil map":
                        _maps[0].Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "soil-to-fertilizer map":
                        _maps[1].Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "fertilizer-to-water map":
                        _maps[2].Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "water-to-light map":
                        _maps[3].Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "light-to-temperature map":
                        _maps[4].Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "temperature-to-humidity map":
                        _maps[5].Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "humidity-to-location map":
                        _maps[6].Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;
                }
            }
        }
    }

    private void CalculateMinimumLocation()
    {
        var results = new List<long>();

        foreach (var seed in _seeds)
        {
            var currentIndex = seed;
            for (var index = 0; index < _maps.Count; index++)
            {
                var list = new List<long>();
                foreach (var lambda in _maps[index])
                {
                    list.Add(lambda(currentIndex));
                }

                var result = list.Distinct().Where(p => p != currentIndex).ToArray();
                if (result.Length != 0)
                {
                    currentIndex = result.Single();
                }
            }

            results.Add(currentIndex);
        }

        MinimumLocation = results.Min();
    }

    private void CalculateMinimumLocationWithRanges()
    {
        MinimumLocation = long.MaxValue;
        foreach (var seedRange in _seedRanges)
        {
            for (var seed = seedRange.Start; seed < seedRange.Start + seedRange.Count; seed++)
            {
                var currentIndex = seed;
                for (var index = 0; index < _maps.Count; index++)
                {
                    var list = new List<long>();
                    foreach (var lambda in _maps[index])
                    {
                        list.Add(lambda(currentIndex));
                    }

                    var result = list.Distinct().Where(p => p != currentIndex).ToArray();
                    if (result.Length != 0)
                    {
                        currentIndex = result.Single();
                    }
                }

                if (currentIndex < MinimumLocation)
                {
                    MinimumLocation = currentIndex;
                }
            }
        }
    }
}
