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
        var sut = new MonkeyMarket(input);
        Assert.Equal(expectedCount, sut.Count);
    }

    [Theory]
    [InlineData(1, 15887950)]
    [InlineData(2, 32383086)]
    [InlineData(3, 32910431)]
    [InlineData(4, 33614955)]
    [InlineData(5, 35168639)]
    [InlineData(6, 47851795)]
    [InlineData(7, 58952339)]
    [InlineData(8, 71201823)]
    [InlineData(9, 78955255)]
    [InlineData(10, 84863509)]
    public void CalculateSumOfSecrets(int generations, int expectedResult)
    {
        var sut = new MonkeyMarket("123");
        sut.CalculateSumOfSecrets(generations);
        Assert.Equal(expectedResult, sut.SumOfSecrets);
    }

    [Theory]
    [InlineData(1, 8685429)]
    [InlineData(10, 4700978)]
    [InlineData(100, 15273692)]
    [InlineData(2024, 8667524)]
    public void Calculate2000thSecretNumber(int initial, int expectedValue)
    {
        var sut = new MonkeyMarket(initial.ToString());
        var value = sut.Generate(0, 2000);
        Assert.Equal(expectedValue, value);
    }

/*
    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new MonkeyMarket(SAMPLE_INPUT);
        sut.Generate(2000);
        Assert.Equal(37327623, sut.SumOfSecrets);
        //Assert.True(67070480906 > sut.SumOfSecrets);
    }*/
}