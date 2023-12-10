using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests;

public class PipeMazeMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 5, 5)]
    [InlineData(THIRD_SAMPLE_INPUT, 5, 5)]
    [InlineData(PUZZLE_INPUT, 140, 140)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new PipeMaze(input);
        Assert.Equal(expectedWidth, sut.W);
        Assert.Equal(expectedHeight, sut.H);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 1, 1)]
    [InlineData(THIRD_SAMPLE_INPUT, 0, 2)]
    [InlineData(PUZZLE_INPUT, 74, 95)]
    public void ParseInputCorrectly(string input, int expectedStartX, int expectedStartY)
    {
        var sut = new PipeMaze(input);
        Assert.Equal(expectedStartX, sut.X);
        Assert.Equal(expectedStartY, sut.Y);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 'F')]
    [InlineData(SECOND_SAMPLE_INPUT, 'F')]
    public void GuessInitialPipeCorrectly_WithSampleInput(string input, char expectedPipe)
    {
        var sut = new PipeMaze(input);
        Assert.Equal(expectedPipe, sut.StartingPipe);
    }

    [Theory]
    [InlineData(THIRD_SAMPLE_INPUT, 'F')]
    [InlineData(FOURTH_SAMPLE_INPUT, 'F')]
    public void GuessInitialPipeCorrectly_WithComplexSampleInput(string input, char expectedPipe)
    {
        var sut = new PipeMaze(input);
        Assert.Equal(expectedPipe, sut.StartingPipe);
    }

    [Fact]
    public void GuessInitialPipeCorrectly_WithPuzzleInput()
    {
        var sut = new PipeMaze(PUZZLE_INPUT);
        Assert.Equal('L', sut.StartingPipe);
    }
}