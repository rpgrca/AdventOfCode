using Day7.Logic;
using static Day7.UnitTests.Constants;

namespace Day7.UnitTests;

public class CamelCardsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT)]
    public void LoadInputCorrectly(string input)
    {
        var sut = new CamelCards(input);
        Assert.Equal(5, sut.Hands);
    }
}