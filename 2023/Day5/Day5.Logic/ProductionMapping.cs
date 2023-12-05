

namespace Day5.Logic;
public class ProductionMapping
{
    private readonly string _input;
    private List<long> _seeds;
    private readonly List<Func<long, long>> _fertilizerToWaterMap;
    private readonly List<Func<long, long>> _soilToFertilizerMap;
    private readonly List<Func<long, long>> _seedToSoilMap;
    private readonly List<Func<long, long>> _waterToLightMap;
    private readonly List<Func<long, long>> _lightToTemperatureMap;
    private readonly List<Func<long, long>> _temperatureToHumidityMap;
    private readonly List<Func<long, long>> _humidityToLocationMap;

    public int SeedsCount => _seeds.Count;
    public int SeedToSoilCount => _seedToSoilMap.Count;
    public int SoilToFertilizerCount => _soilToFertilizerMap.Count;
    public int FertilizerToWaterCount => _fertilizerToWaterMap.Count;
    public int WaterToLightCount => _waterToLightMap.Count;
    public int LightToTemperatureCount => _lightToTemperatureMap.Count;
    public int TemperatureToHumidityCount => _temperatureToHumidityMap.Count;
    public int HumidityToLocationCount => _humidityToLocationMap.Count;

    public ProductionMapping(string input)
    {
        _input = input;
        _seedToSoilMap = new List<Func<long, long>>();
        _soilToFertilizerMap = new List<Func<long, long>>();
        _fertilizerToWaterMap = new List<Func<long, long>>();
        _waterToLightMap = new List<Func<long, long>>();
        _lightToTemperatureMap = new List<Func<long, long>>();
        _temperatureToHumidityMap = new List<Func<long, long>>();
        _humidityToLocationMap = new List<Func<long, long>>();
        Parse();
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
                        _seedToSoilMap.Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "soil-to-fertilizer map":
                        _soilToFertilizerMap.Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "fertilizer-to-water map":
                        _fertilizerToWaterMap.Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "water-to-light map":
                        _waterToLightMap.Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "light-to-temperature map":
                        _lightToTemperatureMap.Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "temperature-to-humidity map":
                        _temperatureToHumidityMap.Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "humidity-to-location map":
                        _humidityToLocationMap.Add(s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;
                }
            }
        }
    }

}
