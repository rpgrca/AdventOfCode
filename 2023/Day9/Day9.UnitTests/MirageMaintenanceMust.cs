using System.Security.Cryptography;
using Day9.Logic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
using static Day9.UnitTests.Constants;

namespace Day9.UnitTests;

public class MirageMaintenanceMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 3)]
    [InlineData(PUZZLE_INPUT, 200)]
    public void LoadInputCorrectly(string input, int expectedHistoryCount)
    {
        var sut = new MirageMaintenance(input);
        Assert.Equal(expectedHistoryCount, sut.HistoryCount);
    }

    [Fact]
    public void ParseInputCorrectly()
    {
        var sut = new MirageMaintenance(SAMPLE_INPUT);
        Assert.Collection(sut.Histories,
            p1 => Assert.Equal(new[] { 0, 3, 6, 9, 12, 15 }, p1),
            p2 => Assert.Equal(new[] { 1, 3, 6, 10, 15, 21 }, p2),
            p3 => Assert.Equal(new[] { 10, 13, 16, 21, 30, 45 }, p3));
    }

    [Fact]
    public void CalculateInitialSequenceOfDifferenceCorrectly_WithFirstInput()
    {
        var sut = new MirageMaintenance("0 3 6 9 12 15");
        Assert.Single(sut.SequenceOfDifferences);
        Assert.Collection(sut.SequenceOfDifferences[0],
            p1 => Assert.Equal(new int[] { 0, 3, 6, 9, 12, 15 }, p1));
    }

    [Fact]
    public void CalculateFirstSequenceOfDifferenceCorrectly_WithFirstInput()
    {
        var sut = new MirageMaintenance("0 3 6 9 12 15");
        sut.CalculateSequenceOfDifference();
        Assert.Single(sut.SequenceOfDifferences);
        Assert.Collection(sut.SequenceOfDifferences[0],
            p1 => Assert.Equal(new int[] { 0, 3, 6, 9, 12, 15 }, p1),
            p2 => Assert.Equal(new int[] { 3, 3, 3, 3, 3 }, p2));
    }

    [Fact]
    public void CalculateSecondSequenceOfDifferenceCorrectly_WithFirstInput()
    {
        var sut = new MirageMaintenance("0 3 6 9 12 15");
        sut.CalculateSequenceOfDifference();
        sut.CalculateSequenceOfDifference();
        Assert.Single(sut.SequenceOfDifferences);
        Assert.Collection(sut.SequenceOfDifferences[0],
            p1 => Assert.Equal(new int[] { 0, 3, 6, 9, 12, 15 }, p1),
            p2 => Assert.Equal(new int[] { 3, 3, 3, 3, 3 }, p2),
            p3 => Assert.Equal(new[] { 0, 0, 0, 0 }, p3));
    }

    [Fact]
    public void CalculateSequenceOfDifferencesAutomatically_WithFirstInput()
    {
        var sut = new MirageMaintenance("0 3 6 9 12 15");
        sut.Calculate();
        Assert.Single(sut.SequenceOfDifferences);
        Assert.Collection(sut.SequenceOfDifferences[0],
            p1 => Assert.Equal(new int[] { 0, 3, 6, 9, 12, 15 }, p1),
            p2 => Assert.Equal(new int[] { 3, 3, 3, 3, 3 }, p2),
            p3 => Assert.Equal(new[] { 0, 0, 0, 0 }, p3));
    }

    [Fact]
    public void CalculateSequenceOfDifferencesAutomatically_WithSecondInput()
    {
        var sut = new MirageMaintenance("1 3 6 10 15 21");
        sut.Calculate();
        Assert.Single(sut.SequenceOfDifferences);
        Assert.Collection(sut.SequenceOfDifferences[0],
            p1 => Assert.Equal(new int[] { 1, 3, 6, 10, 15, 21 }, p1),
            p2 => Assert.Equal(new int[] { 2, 3, 4, 5, 6 }, p2),
            p3 => Assert.Equal(new[] { 1, 1, 1, 1 }, p3),
            p4 => Assert.Equal(new[] { 0, 0, 0 }, p4));
    }

}