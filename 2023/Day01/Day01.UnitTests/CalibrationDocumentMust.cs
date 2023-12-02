using Day01.Logic;
using static Day01.UnitTests.Constants;

namespace Day01.UnitTests;

public class CalibrationDocumentMust
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void CalculateCalibrationValueCorrectly(string input, int expectedValue)
    {
        var sut = new CalibrationDocument.Builder()
            .SupportingDigits()
            .Build(input);

        Assert.Equal(expectedValue, sut.SumOfCalibrationValues);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new CalibrationDocument.Builder()
            .SupportingDigits()
            .Build(SAMPLE_INPUT);

        Assert.Equal(142, sut.SumOfCalibrationValues);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new CalibrationDocument.Builder()
            .SupportingDigits()
            .Build(PUZZLE_INPUT);

        Assert.Equal(54644, sut.SumOfCalibrationValues);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void CalculateCalibrationValueCorrectly_WhenWordsAreAvailable(string input, int expectedValue)
    {
        var sut = new CalibrationDocument.Builder()
            .SupportingDigits()
            .SupportingNames()
            .Build(input);

        Assert.Equal(expectedValue, sut.SumOfCalibrationValues);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new CalibrationDocument.Builder()
            .SupportingDigits()
            .SupportingNames()
            .Build(SECOND_SAMPLE_INPUT);

        Assert.Equal(281, sut.SumOfCalibrationValues);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new CalibrationDocument.Builder()
            .SupportingDigits()
            .SupportingNames()
            .Build(PUZZLE_INPUT);

        Assert.Equal(53348, sut.SumOfCalibrationValues);
    }
}