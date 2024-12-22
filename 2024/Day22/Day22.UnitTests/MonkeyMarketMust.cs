using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests;

public class MonkeyMarketMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 4)]
    [InlineData(PUZZLE_INPUT, 2032)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new MonkeyMarket(input, 0);
        Assert.Equal(expectedCount, sut.Count);
    }

    [Theory]
    [InlineData(1, 15887950)]
    [InlineData(2, 16495136)]
    [InlineData(3, 527345)]
    [InlineData(4, 704524)]
    [InlineData(5, 1553684)]
    [InlineData(6, 12683156)]
    [InlineData(7, 11100544)]
    [InlineData(8, 12249484)]
    [InlineData(9, 7753432)]
    [InlineData(10, 5908254)]
    public void CalculateSumOfSecrets(int generations, int expectedResult)
    {
        var sut = new MonkeyMarket("123", generations);
        var result = sut.Generate(0, generations);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1, 8685429)]
    [InlineData(10, 4700978)]
    [InlineData(100, 15273692)]
    [InlineData(2024, 8667524)]
    public void Calculate2000thSecretNumber(int initial, int expectedValue)
    {
        var sut = new MonkeyMarket(initial.ToString(), 2000);
        var value = sut.Generate(0, 2000);
        Assert.Equal(expectedValue, value);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new MonkeyMarket(SAMPLE_INPUT, 2000);
        sut.CalculateSumOfLastSecrets();
        Assert.Equal(37327623, sut.SumOfSecrets);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new MonkeyMarket(PUZZLE_INPUT, 2000);
        sut.CalculateSumOfLastSecrets();
        Assert.True(67070480906 > sut.SumOfSecrets);
        Assert.Equal(16999668565, sut.SumOfSecrets);
    }

    [Theory]
    [InlineData(0, 3)]
    [InlineData(1, 0)]
    [InlineData(2, 6)]
    [InlineData(3, 5)]
    [InlineData(4, 4)]
    [InlineData(5, 4)]
    [InlineData(6, 6)]
    [InlineData(7, 4)]
    [InlineData(8, 4)]
    [InlineData(9, 2)]
    public void CalculatePricesCorrectly(int count, int expectedPrice)
    {
        var sut = new MonkeyMarket("123", count);
        var result = sut.GeneratePrice(0, count);
        Assert.Equal(expectedPrice, result);
    }

    [Theory]
    [InlineData(1, -3)]
    [InlineData(2, 6)]
    public void CalculatePriceChangesCorrectly(int changeNumber, int expectedChange)
    {
        var sut = new MonkeyMarket("123", 10);
        var result = sut.CalculateChange(0, changeNumber);
        Assert.Equal(expectedChange, result);
    }
}