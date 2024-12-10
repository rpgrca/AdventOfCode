using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using Day9.Logic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
using NuGet.Frameworks;
using static Day9.UnitTests.Constants;

namespace Day9.UnitTests;

public class DiskFragmenterMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 19)]
    [InlineData(SECOND_SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 19999)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new DiskFragmenter(input);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Fact]
    public void MapFileWithoutFreeSpaceCorrectly()
    {
        var sut = new DiskFragmenter("1");
        Assert.Collection(sut.Map, p1 => Assert.Equal(new(0, 1), p1));
    }

    [Fact]
    public void MapFileWithFreeSpaceCorrectly()
    {
        var sut = new DiskFragmenter("12");
        Assert.Collection(sut.Map,
            p1 => Assert.Equal(new(0, 1), p1),
            p2 => Assert.Equal(new(-1, 2), p2));
    }

    [Fact]
    public void MapSampleCorrectly()
    {
        var sut = new DiskFragmenter(SAMPLE_INPUT);
        Assert.Collection(sut.Map,
            p1 => Assert.Equal(new(0, 2), p1),
            p2 => Assert.Equal(new(-1, 3), p2),
            p3 => Assert.Equal(new(1, 3), p3),
            p4 => Assert.Equal(new(-1, 3), p4),
            p5 => Assert.Equal(new(2, 1), p5),
            p6 => Assert.Equal(new(-1, 3), p6),
            p7 => Assert.Equal(new(3, 3), p7),
            p8 => Assert.Equal(new(-1, 1), p8),
            p9 => Assert.Equal(new(4, 2), p9),
            p10 => Assert.Equal(new(-1, 1), p10),
            p11 => Assert.Equal(new(5, 4), p11),
            p12 => Assert.Equal(new(-1, 1), p12),
            p13 => Assert.Equal(new(6, 4), p13),
            p14 => Assert.Equal(new(-1, 1), p14),
            p15 => Assert.Equal(new(7,3), p15),
            p16 => Assert.Equal(new(-1, 1), p16),
            p17 => Assert.Equal(new(8, 4), p17),
            p18 => Assert.Equal(new(9, 2), p18)
        );
    }

    [Fact]
    public void CompactAlreadyCompactedFileSystemCorrectly()
    {
        var sut = new DiskFragmenter(THIRD_SAMPLE_INPUT);
        sut.Compact();
        Assert.Collection(sut.Map,
            p1 => Assert.Equal(new(0, 9), p1),
            p2 => Assert.Equal(new(1, 9), p2),
            p3 => Assert.Equal(new(2, 9), p3));
    }

    [Fact]
    public void CompactFileSystemCorrectly()
    {
        var sut = new DiskFragmenter(SECOND_SAMPLE_INPUT);
        sut.Compact();
        Assert.Collection(sut.Map,
            p1 => Assert.Equal(new(0, 1), p1),
            p2 => Assert.Equal(new(2, 2), p2),
            p3 => Assert.Equal(new(1, 3), p3),
            p4 => Assert.Equal(new(2, 3), p4),
            p5 => Assert.Equal(new(-1, 6), p5));
    }

    [Fact]
    public void CompactSampleFileSystemCorrectly()
    {
        var sut = new DiskFragmenter(SAMPLE_INPUT);
        sut.Compact();
        Assert.Collection(sut.Map,
            p1 => Assert.Equal(new(0, 2), p1),
            p2 => Assert.Equal(new(9, 2), p2),
            p3 => Assert.Equal(new(8, 1), p3),
            p4 => Assert.Equal(new(1, 3), p4),
            p5 => Assert.Equal(new(8, 3), p5),
            p6 => Assert.Equal(new(2, 1), p6),
            p7 => Assert.Equal(new(7, 3), p7),
            p8 => Assert.Equal(new(3, 3), p8),
            p9 => Assert.Equal(new(6, 1), p9),
            p10 => Assert.Equal(new(4, 2), p10),
            p11 => Assert.Equal(new(6, 1), p11),
            p12 => Assert.Equal(new(5, 4), p12),
            p13 => Assert.Equal(new(6, 2), p13),
            p14 => Assert.Equal(new(-1, 14), p14));
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new DiskFragmenter(SAMPLE_INPUT);
        sut.Compact();
        Assert.Equal(1928, sut.Checksum);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new DiskFragmenter(PUZZLE_INPUT);
        sut.Compact();
        Assert.Equal(6607511583593, sut.Checksum);
    }

    [Fact]
    public void MoveWholeFileCorrectly()
    {
        var sut = new DiskFragmenter(SAMPLE_INPUT);
        sut.Compact(true);
        Assert.Collection(sut.Map,
            p1 => Assert.Equal(new(0, 2), p1),
            p2 => Assert.Equal(new(9, 2), p2),
            p3 => Assert.Equal(new(2, 1), p3),
            p4 => Assert.Equal(new(1, 3), p4),
            p5 => Assert.Equal(new(7, 3), p5),
            p6 => Assert.Equal(new(-1, 1), p6),
            p7 => Assert.Equal(new(4, 2), p7),
            p8 => Assert.Equal(new(-1, 1), p8),
            p9 => Assert.Equal(new(3, 3), p9),
            p10 => Assert.Equal(new(-1, 4), p10),
            p11 => Assert.Equal(new(5, 4), p11),
            p12 => Assert.Equal(new(-1, 1), p12),
            p13 => Assert.Equal(new(6, 4), p13),
            p14 => Assert.Equal(new(-1, 5), p14),
            p15 => Assert.Equal(new(8, 4), p15),
            p16 => Assert.Equal(new(-1, 2), p16));
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new DiskFragmenter(SAMPLE_INPUT);
        sut.Compact(true);
        Assert.Equal(2858, sut.Checksum);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new DiskFragmenter(PUZZLE_INPUT);
        sut.Compact(true);
        Assert.Equal(6636608781232, sut.Checksum);
    }
}