using Day5.Logic;
using static Day5.UnitTests.Constants;

namespace Day5.UnitTests;

public class ProductionMappingMust
{
    [Fact]
    public void LoadSampleDataCorrectly()
    {
        var sut = new ProductionMapping(SAMPLE_INPUT);
        Assert.Equal(4, sut.SeedsCount);
        Assert.Equal(2, sut.SeedToSoilCount);
        Assert.Equal(3, sut.SoilToFertilizerCount);
        Assert.Equal(4, sut.FertilizerToWaterCount);
        Assert.Equal(2, sut.WaterToLightCount);
        Assert.Equal(3, sut.LightToTemperatureCount);
        Assert.Equal(2, sut.TemperatureToHumidityCount);
        Assert.Equal(2, sut.HumidityToLocationCount);
    }
}