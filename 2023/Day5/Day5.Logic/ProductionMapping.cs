


namespace Day5.Logic;
public class ProductionMapping
{
    private readonly string _input;
    private List<long> _seeds;
    private readonly List<SortedList<(long Target, long Start, long Count), Func<long, long>>> _maps;
    private readonly List<(long Start, long Count)> _seedRanges;
    private readonly List<List<(long, long, long)>> _simplifiedMap;

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
        _maps = new List<SortedList<(long, long, long), Func<long, long>>>();
        _simplifiedMap = new List<List<(long, long, long)>>();
        _seedRanges = new List<(long Start, long Count)>();
        for (var index = 0; index < 7; index++)
        {
            _maps.Add(new SortedList<(long, long, long), Func<long, long>>());
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
                        _maps[0].Add((values[0], values[1], values[2]), s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "soil-to-fertilizer map":
                        _maps[1].Add((values[0], values[1], values[2]), s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "fertilizer-to-water map":
                        _maps[2].Add((values[0], values[1], values[2]), s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "water-to-light map":
                        _maps[3].Add((values[0], values[1], values[2]), s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "light-to-temperature map":
                        _maps[4].Add((values[0], values[1], values[2]), s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "temperature-to-humidity map":
                        _maps[5].Add((values[0], values[1], values[2]), s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;

                    case "humidity-to-location map":
                        _maps[6].Add((values[0], values[1], values[2]), s => s >= values[1] && s < values[1] + values[2]? values[0] + (s - values[1]) : s);
                        break;
                }
            }
        }

        var list = new List<(long, long, long)>();
        foreach (var range in _maps[6].Keys)
        {
            list.Add((range.Target, range.Start, range.Count));
        }
        _simplifiedMap.Insert(0, list.OrderBy(p => p.Item2).ToList());

        for (var index = 5; index >= 0; index--)
        {
            list = new List<(long, long, long)>();

            foreach (var range in _maps[index].OrderBy(p => p.Key.Start))
            {
                (long, long, long)[] splittedRange = SplitRangeInTwo(range.Key, _simplifiedMap[0]);
                if (splittedRange[0] == (0, 0, 0))
                {
                    _simplifiedMap[0].Add((range.Key.Start, range.Key.Start, range.Key.Count));
                }
                else
                {
                    while (splittedRange.Length > 1)
                    {
                        list.Add(splittedRange[0]);
                        var splittedRange2 = SplitRangeInTwo(splittedRange[1], _simplifiedMap[0]);

                        if (splittedRange2.Length == 1)
                        {
                            if (splittedRange2[0] == (0, 0, 0))
                            {
                                _simplifiedMap[0].Add((splittedRange[1].Item2, splittedRange[1].Item2, splittedRange[1].Item3));
                            }
                        }

                        splittedRange = splittedRange2;
                    }

                    if (splittedRange[0] != (0, 0, 0))
                    {
                        list.Add(splittedRange[0]);
                    }
                }
            }

            _simplifiedMap.Insert(0, list);
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
                foreach (var (i, lambda) in _maps[index])
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
            for (var seedStart = seedRange.Start; seedStart < seedRange.Start + seedRange.Count;)
            {
                var soilRange = FindSoilContaining2(seedStart, _simplifiedMap[0]);
                var currentIndex = soilRange.Conversion + (seedStart - soilRange.Start);

                for (var soilStart = currentIndex; soilStart < soilRange.Conversion + soilRange.Count;)
                {
                    var fertilizerRange = FindSoilContaining2(soilStart, _simplifiedMap[1]);
                    currentIndex = fertilizerRange.Conversion + (soilStart - fertilizerRange.Start);

                    for (var fertilizerStart = currentIndex; fertilizerStart < fertilizerRange.Conversion + fertilizerRange.Count;)
                    {
                        var waterRange = FindSoilContaining2(fertilizerStart, _simplifiedMap[2]);
                        currentIndex = waterRange.Conversion + (fertilizerStart - waterRange.Start);

                        for (var waterStart = currentIndex; waterStart < waterRange.Conversion + waterRange.Count;)
                        {
                            var lightRange = FindSoilContaining2(waterStart, _simplifiedMap[3]);
                            currentIndex = lightRange.Conversion + (waterStart - lightRange.Start);

                            for (var lightStart = currentIndex; lightStart < lightRange.Conversion + lightRange.Count;)
                            {
                                var temperatureRange = FindSoilContaining2(lightStart, _simplifiedMap[4]);
                                currentIndex = temperatureRange.Conversion + (lightStart - temperatureRange.Start);

                                for (var temperatureStart = currentIndex; temperatureStart < temperatureRange.Conversion + temperatureRange.Count;)
                                {
                                    var humidityRange = FindSoilContaining2(temperatureStart, _simplifiedMap[5]);
                                    currentIndex = humidityRange.Conversion + (temperatureStart - humidityRange.Start);

                                    for (var humidityStart = currentIndex; humidityStart < humidityRange.Conversion + humidityRange.Count;)
                                    {
                                        var locationRange = FindSoilContaining2(humidityStart, _simplifiedMap[6]);
                                        currentIndex = locationRange.Conversion + (humidityStart - locationRange.Start);
                                        humidityStart += locationRange.Count;
                                    }

                                    temperatureStart += humidityRange.Count;
                                }

                                lightStart += temperatureRange.Count;
                            }

                            waterStart += lightRange.Count;
                        }

                        fertilizerStart += waterRange.Count;
                    }

                    soilStart += fertilizerRange.Count;
                }

                if (currentIndex < MinimumLocation)
                {
                    MinimumLocation = currentIndex;
                }

                seedStart += soilRange.Count;
            }
        }
    }

    private (long Conversion, long Start, long Count) FindSoilContaining(long start, SortedList<(long Target, long Start, long Count), Func<long, long>> map)
    {
        foreach (var range in map)
        {
            if (range.Key.Start <= start && start < range.Key.Start + range.Key.Count) {
                return range.Key;
            }
        }

        return (start, start, 1);
    }

    private (long Conversion, long Start, long Count) FindSoilContaining2(long start, List<(long Target, long Start, long Count)> map)
    {
        foreach (var range in map)
        {
            if (range.Start <= start && start < range.Start + range.Count) {
                return range;
            }
        }

        return (start, start, 1);
    }



    private (long Target, long Start, long Count)[] SplitRange((long Target, long Start, long Count) range, List<(long Target, long Start, long Count)> maps)
    {
        foreach (var map in maps)
        {
            if (range.Start < map.Start)
            {
                if (range.Start + range.Count < map.Start)
                {
                    // rrrrrrr
                    //          mmmmmmm
                    //
                    // no intersection, try next map
                }
                else
                {
                    if (range.Start + range.Count < map.Start + map.Count)
                    {
                        // 012|3456|78
                        // rrr|rrrr|
                        //    |mmmm|mm

                        var firstLength = map.Start - range.Start;
                        var secondLength = range.Count - firstLength;
                        var thirdLength = map.Count - secondLength;

                        return new[] {
                            (range.Target, range.Start, firstLength),
                            (range.Target + firstLength, map.Start, secondLength ),
                            (range.Target + firstLength + secondLength, map.Start + secondLength, thirdLength)
                        };
                    }
                    else
                    {
                        // 01|2345|6789
                        // rr|rrrr|rrr
                        //   |mmmm|

                        var firstLength = map.Start - range.Start;
                        var secondLength = map.Count;
                        var thirdLength = range.Count - firstLength - secondLength;

                        return new[] {
                            (range.Target, range.Start, firstLength),
                            (range.Target + firstLength, map.Start, secondLength),
                            (range.Target + firstLength + secondLength, range.Start + firstLength + secondLength, thirdLength)
                        };
                    }
                }
            }
            else
            {
                if (map.Start + map.Count < range.Start)
                {
                    //        rrrrrrr
                    // mmmmm
                    //
                    // no intersection, try next map

                }
                else
                {
                    if (map.Start + map.Count < range.Start + range.Count)
                    {
                        // 012|34|56789
                        //    |rr|rrrrr
                        // mmm|mm|

                        var firstLength = range.Start - map.Start;
                        var secondLength = map.Count - firstLength;
                        var thirdLength = range.Count - secondLength;

                        return new[] {
                            (range.Target, map.Start, firstLength),
                            (range.Target + firstLength, range.Start, secondLength),
                            (range.Target + firstLength + secondLength, range.Start + secondLength, thirdLength)
                        };
                    }
                    else
                    {
                        // 012|345|6789
                        //    |rrr|
                        //  mm|mmm|mm

                        var firstLength = range.Start - map.Start;
                        var secondLength = range.Count;
                        var thirdLength = map.Count - firstLength - secondLength;

                        return new[] {
                            (range.Target, map.Start, firstLength),
                            (range.Target + firstLength, range.Start, secondLength),
                            (range.Target + firstLength + secondLength, map.Start + firstLength + secondLength, thirdLength)
                        };
                    }
                }
            }
        }

        return Array.Empty<(long, long, long)>();
    }


    private (long Target, long Start, long Count)[] SplitRangeInTwo((long Target, long Start, long Count) range, List<(long Target, long Start, long Count)> maps)
    {
        foreach (var map in maps)
        {
            if (range.Start < map.Start)
            {
                if (range.Start + range.Count - 1 < map.Start)
                {
                    // rrrrrrr
                    //          mmmmmmm
                    //
                    // no intersection, try next map
                }
                else
                {
                    if (range.Start + range.Count - 1 < map.Start + map.Count - 1)
                    {
                        // 012|345678
                        // rrr|rrrr
                        //    |mmmmmm

                        var firstLength = map.Start - range.Start;

                        return new[] {
                            (range.Target, range.Start, firstLength),
                            (range.Target + firstLength, map.Start, range.Count - firstLength)
                        };
                    }
                    else
                    {
                        // 01|23456789
                        // rr|rrrrrrr
                        //   |mmmm

                        var firstLength = map.Start - range.Start;

                        return new[] {
                            (range.Target, range.Start, firstLength),
                            (range.Target + firstLength, map.Start, range.Count - firstLength)
                        };
                    }
                }
            }
            else
            {
                if (map.Start + map.Count - 1 < range.Start)
                {
                    //        rrrrrrr
                    // mmmmm
                    //
                    // no intersection, try next map
                }
                else
                {
                    if (map.Start + map.Count - 1 < range.Start + range.Count - 1)
                    {
                        // 01234|56789
                        //    rr|rrrrr
                        // mmmmm|

                        var firstLength = map.Start + map.Count - range.Start;

                        return new[] {
                            (range.Target, range.Start, firstLength),
                            (range.Target + firstLength, range.Start + firstLength, range.Count - firstLength)
                        };
                    }
                    else
                    {
                        // 012|345|6789
                        //    |rrr|
                        //  mm|mmm|mm
                        return new[] {
                            (range.Target, range.Start, range.Count)
                        };
                    }
                }
            }
        }

        return new (long Target, long Start, long Count)[] { (0L, 0L, 0L) };
    }
}
