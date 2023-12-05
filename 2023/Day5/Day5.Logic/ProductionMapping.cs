


namespace Day5.Logic;
public class ProductionMapping
{
    private readonly string _input;
    private List<long> _seeds;
    private readonly List<List<Func<long, long>>> _maps;

    public int SeedsCount => _seeds.Count;
    public int SeedToSoilCount => _maps[0].Count;
    public int SoilToFertilizerCount => _maps[1].Count;
    public int FertilizerToWaterCount => _maps[2].Count;
    public int WaterToLightCount => _maps[3].Count;
    public int LightToTemperatureCount => _maps[4].Count;
    public int TemperatureToHumidityCount => _maps[5].Count;
    public int HumidityToLocationCount => _maps[6].Count;

    public long MinimumLocation { get; private set; }

    public ProductionMapping(string input)
    {
        _input = input;
        _maps = new List<List<Func<long, long>>>();
        for (var index = 0; index < 7; index++)
        {
            _maps.Add(new List<Func<long, long>>());
        }

        Parse();
        //CalculateMinimumLocation();
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


}
