using Day9.Logic;
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
    public void MapFileWithoutContiguousSpaceCorrectly()
    {
        var sut = new DiskFragmenter("1");
        Assert.Collection(sut.Map,
            p1 => {
                var space = Assert.IsType<ContiguousSpace>(p1);
                Assert.Equal(0, space.Id);
                Assert.Equal(1, space.Length);
            });
    }

    [Fact]
    public void MapFileWithContiguousSpaceCorrectly()
    {
        var sut = new DiskFragmenter("12");
        Assert.Collection(sut.Map,
            p1 => {
                var space = Assert.IsType<ContiguousSpace>(p1);
                Assert.Equal(0, space.Id);
                Assert.Equal(1, space.Length);
            },
            p2 => {
                var space = Assert.IsType<ContiguousSpace>(p2);
                Assert.Equal(2, space.Length);
            });
    }

    [Fact]
    public void MapSampleCorrectly()
    {
        var sut = new DiskFragmenter(SAMPLE_INPUT);
        Assert.Collection(sut.Map,
            p1 => {
                var space = Assert.IsType<ContiguousSpace>(p1);
                Assert.Equal(0, space.Id);
                Assert.Equal(2, space.Length);
            },
            p2 => {
                var space = Assert.IsType<ContiguousSpace>(p2);
                Assert.Equal(3, space.Length);
            },
            p3 => {
                var space = Assert.IsType<ContiguousSpace>(p3);
                Assert.Equal(1, space.Id);
                Assert.Equal(3, space.Length);
            },
            p4 => {
                var space = Assert.IsType<ContiguousSpace>(p4);
                Assert.Equal(3, space.Length);
            },
            p5 => {
                var space = Assert.IsType<ContiguousSpace>(p5);
                Assert.Equal(2, space.Id);
                Assert.Equal(1, space.Length);
            },
            p6 => {
                var space = Assert.IsType<ContiguousSpace>(p6);
                Assert.Equal(3, space.Length);
            },
            p7 => {
                var space = Assert.IsType<ContiguousSpace>(p7);
                Assert.Equal(3, space.Id);
                Assert.Equal(3, space.Length);
            },
            p8 => {
                var space = Assert.IsType<ContiguousSpace>(p8);
                Assert.Equal(1, space.Length);
            },
            p9 => {
                var space = Assert.IsType<ContiguousSpace>(p9);
                Assert.Equal(4, space.Id);
                Assert.Equal(2, space.Length);
            },
            p10 =>{
                var space = Assert.IsType<ContiguousSpace>(p10);
                Assert.Equal(1, space.Length);
            },
            p11 =>{
                var space = Assert.IsType<ContiguousSpace>(p11);
                Assert.Equal(5, space.Id);
                Assert.Equal(4, space.Length);
            },
            p12 =>{
                var space = Assert.IsType<ContiguousSpace>(p12);
                Assert.Equal(1, space.Length);
            },
            p13 =>{
                var space = Assert.IsType<ContiguousSpace>(p13);
                Assert.Equal(6, space.Id);
                Assert.Equal(4, space.Length);
            },
            p14 =>{
                var space = Assert.IsType<ContiguousSpace>(p14);
                Assert.Equal(1, space.Length);
            },
            p15 =>{
                var space = Assert.IsType<ContiguousSpace>(p15);
                Assert.Equal(7, space.Id);
                Assert.Equal(3, space.Length);
            },
            p16 =>{
                var space = Assert.IsType<ContiguousSpace>(p16);
                 Assert.Equal(1, space.Length);
            },
            p17 =>{
                var space = Assert.IsType<ContiguousSpace>(p17);
                Assert.Equal(8, space.Id);
                Assert.Equal(4, space.Length);
            },
            p18 =>{
                var space = Assert.IsType<ContiguousSpace>(p18);
                Assert.Equal(9, space.Id);
                Assert.Equal(2, space.Length);
            }
        );
    }

    [Fact]
    public void CompactAlreadyCompactedFileSystemCorrectly()
    {
        var sut = new DiskFragmenter(THIRD_SAMPLE_INPUT);
        sut.Compact();
        Assert.Collection(sut.Map,
            p1 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p1);
                Assert.Equal(0, space.Id);
                Assert.Equal(9, space.Length);
            },
            p2 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p2);
                Assert.Equal(1, space.Id);
                Assert.Equal(9, space.Length);
            },
            p3 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p3);
                Assert.Equal(2, space.Id);
                Assert.Equal(9, space.Length);
            });
    }

    [Fact]
    public void CompactFileSystemCorrectly()
    {
        var sut = new DiskFragmenter(SECOND_SAMPLE_INPUT);
        sut.Compact();
        Assert.Collection(sut.Map,
            p1 =>
            {
                var space= Assert.IsType<ContiguousSpace>(p1);
                Assert.Equal(0, space.Id);
                Assert.Equal(1, space.Length);
            },
            p2 =>
            {
                var space= Assert.IsType<ContiguousSpace>(p2);
                Assert.Equal(2, space.Id);
                Assert.Equal(2, space.Length);
            },
            p3 =>
            {
                var space= Assert.IsType<ContiguousSpace>(p3);
                Assert.Equal(1, space.Id);
                Assert.Equal(3, space.Length);
            },
            p4 =>
            {
                var space= Assert.IsType<ContiguousSpace>(p4);
                Assert.Equal(2, space.Id);
                Assert.Equal(3, space.Length);
            },
            p5 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p5);
                Assert.Equal(6, space.Length);
            });
    }

    [Fact]
    public void CompactSampleFileSystemCorrectly()
    {
        var sut = new DiskFragmenter(SAMPLE_INPUT);
        sut.Compact();
        Assert.Collection(sut.Map,
            p1 => {
                var space = Assert.IsType<ContiguousSpace>(p1);
                Assert.Equal(0, space.Id);
                Assert.Equal(2, space.Length);
            },
            p2 => {
                var space = Assert.IsType<ContiguousSpace>(p2);
                Assert.Equal(9, space.Id);
                Assert.Equal(2, space.Length);
            },
            p3 => {
                var space = Assert.IsType<ContiguousSpace>(p3);
                Assert.Equal(8, space.Id);
                Assert.Equal(1, space.Length);
            },
            p4 => {
                var space = Assert.IsType<ContiguousSpace>(p4);
                Assert.Equal(1, space.Id);
                Assert.Equal(3, space.Length);
            },
            p5 => {
                var space = Assert.IsType<ContiguousSpace>(p5);
                Assert.Equal(8, space.Id);
                Assert.Equal(3, space.Length);
            },
            p6 => {
                var space = Assert.IsType<ContiguousSpace>(p6);
                Assert.Equal(2, space.Id);
                Assert.Equal(1, space.Length);
            },
            p7 => {
                var space = Assert.IsType<ContiguousSpace>(p7);
                Assert.Equal(7, space.Id);
                Assert.Equal(3, space.Length);
            },
            p8 => {
                var space = Assert.IsType<ContiguousSpace>(p8);
                Assert.Equal(3, space.Id);
                Assert.Equal(3, space.Length);
            },
            p9 => {
                var space = Assert.IsType<ContiguousSpace>(p9);
                Assert.Equal(6, space.Id);
                Assert.Equal(1, space.Length);
            },
            p10 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p10);
                Assert.Equal(4, space.Id);
                Assert.Equal(2, space.Length);
            },
            p11 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p11);
                Assert.Equal(6, space.Id);
                Assert.Equal(1, space.Length);
            },
            p12 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p12);
                Assert.Equal(5, space.Id);
                Assert.Equal(4, space.Length);
            },
            p13 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p13);
                Assert.Equal(6, space.Id);
                Assert.Equal(2, space.Length);
            },
            p14 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p14);
                Assert.Equal(14, space.Length);
            });
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
            p1 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p1);
                Assert.Equal(0, space.Id);
                Assert.Equal(2, space.Length);
            },
            p2 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p2);
                Assert.Equal(9, space.Id);
                Assert.Equal(2, space.Length);
            },
            p3 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p3);
                Assert.Equal(2, space.Id);
                Assert.Equal(1, space.Length);
            },
            p4 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p4);
                Assert.Equal(1, space.Id);
                Assert.Equal(3, space.Length);
            },
            p5 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p5);
                Assert.Equal(7, space.Id);
                Assert.Equal(3, space.Length);
            },
            p6 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p6);
                Assert.Equal(1, space.Length);
            },
            p7 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p7);
                Assert.Equal(4, space.Id);
                Assert.Equal(2, space.Length);
            },
            p8 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p8);
                Assert.Equal(1, space.Length);
            },
            p9 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p9);
                Assert.Equal(3, space.Id);
                Assert.Equal(3, space.Length);
            },
            p10 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p10);
                Assert.Equal(4, space.Length);
            },
            p11 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p11);
                Assert.Equal(5, space.Id);
                Assert.Equal(4, space.Length);
            },
            p12 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p12);
                Assert.Equal(1, space.Length);
            },
            p13 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p13);
                Assert.Equal(6, space.Id);
                Assert.Equal(4, space.Length);
            },
            p14 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p14);
                Assert.Equal(5, space.Length);
            },
            p15 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p15);
                Assert.Equal(8, space.Id);
                Assert.Equal(4, space.Length);
            },
            p16 =>
            {
                var space = Assert.IsType<ContiguousSpace>(p16);
                Assert.Equal(2, space.Length);
            });
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