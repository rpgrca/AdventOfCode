using Day5.Logic;
using static Day5.UnitTests.Constants;

namespace Day5.UnitTests;

public class ProductionMappingMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 4, 2, 3, 4, 2, 3, 2, 2)]
    [InlineData(PUZZLE_INPUT, 20, 32, 18, 48, 33, 36, 29, 28)]
    public void LoadSampleDataCorrectly(string input, int expectedSeeds, int expectedSeedToSoil,
        int expectedSoilToFertilizer, int expectedFertilizerToWater, int expectedWaterToLight,
        int expectedLightToTemperature, int expectedTemperatureToHumidity, int expectedHumidityToLocation)
    {
        var sut = new ProductionMapping(input);
        Assert.Equal(expectedSeeds, sut.SeedsCount);
        Assert.Equal(expectedSeedToSoil, sut.SeedToSoilCount);
        Assert.Equal(expectedSoilToFertilizer, sut.SoilToFertilizerCount);
        Assert.Equal(expectedFertilizerToWater, sut.FertilizerToWaterCount);
        Assert.Equal(expectedWaterToLight, sut.WaterToLightCount);
        Assert.Equal(expectedLightToTemperature, sut.LightToTemperatureCount);
        Assert.Equal(expectedTemperatureToHumidity, sut.TemperatureToHumidityCount);
        Assert.Equal(expectedHumidityToLocation, sut.HumidityToLocationCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new ProductionMapping(SAMPLE_INPUT);
        Assert.Equal(35, sut.MinimumLocation);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new ProductionMapping(PUZZLE_INPUT);
        Assert.Equal(551761867, sut.MinimumLocation);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new ProductionMapping(SAMPLE_INPUT, true);
        Assert.Equal(46, sut.MinimumLocation);
    }
/*
    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new ProductionMapping(PUZZLE_INPUT, true);
        Assert.Equal(0, sut.MinimumLocation);
    }*/
}