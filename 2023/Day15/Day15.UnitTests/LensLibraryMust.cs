using System.Collections.Specialized;
using System.Runtime.Intrinsics.X86;
using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests;

public class LensLibraryMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11)]
    [InlineData(PUZZLE_INPUT, 4000)]
    public void ParseInputCorrectly(string input, int expectedCount)
    {
        var sut = new LensLibrary(input);
        Assert.Equal(expectedCount, sut.SequenceCount);
    }

    [Theory]
    [InlineData("HASH", 52)]
    [InlineData("rn=1", 30)]
    [InlineData("cm-", 253)]
    [InlineData("qp=3", 97)]
    [InlineData("cm=2", 47)]
    [InlineData("qp-", 14)]
    [InlineData("pc=4", 180)]
    [InlineData("ot=9", 9)]
    [InlineData("ab=5", 197)]
    [InlineData("pc-", 48)]
    [InlineData("pc=6", 214)]
    [InlineData("ot=7", 231)]
    public void CalculateHashCorrectly(string input, int expectedSumOfHashes)
    {
        var sut = new LensLibrary(input);
        Assert.Equal(expectedSumOfHashes, sut.SumOfHashes);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new LensLibrary(SAMPLE_INPUT);
        Assert.Equal(1320, sut.SumOfHashes);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new LensLibrary(PUZZLE_INPUT);
        Assert.Equal(515495, sut.SumOfHashes);
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting1Step()
    {
        var sut = new LensLibrary("rn=1");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting2Steps()
    {
        var sut = new LensLibrary("rn=1,cm-");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting3Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1));
        Assert.Collection(sut.Boxes[1],
            b1 => Assert.Equal(("qp", 3), b1));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting4Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Collection(sut.Boxes[1],
            b1 => Assert.Equal(("qp", 3), b1));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting5Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2,qp-");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Empty(sut.Boxes[1]);
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting6Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2,qp-,pc=4");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Collection(sut.Boxes[3],
            b1 => Assert.Equal(("pc", 4), b1));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting7Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Collection(sut.Boxes[3],
            b1 => Assert.Equal(("pc", 4), b1),
            b2 => Assert.Equal(("ot", 9), b2));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting8Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Collection(sut.Boxes[3],
            b1 => Assert.Equal(("pc", 4), b1),
            b2 => Assert.Equal(("ot", 9), b2),
            b3 => Assert.Equal(("ab", 5), b3));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting9Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Collection(sut.Boxes[3],
            b1 => Assert.Equal(("ot", 9), b1),
            b2 => Assert.Equal(("ab", 5), b2));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting10Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Collection(sut.Boxes[3],
            b1 => Assert.Equal(("ot", 9), b1),
            b2 => Assert.Equal(("ab", 5), b2),
            b3 => Assert.Equal(("pc", 6), b3));
    }

    [Fact]
    public void SelectBoxCorrectly_WhenExecuting11Steps()
    {
        var sut = new LensLibrary("rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7");
        Assert.Collection(sut.Boxes[0],
            b1 => Assert.Equal(("rn", 1), b1),
            b2 => Assert.Equal(("cm", 2), b2));
        Assert.Collection(sut.Boxes[3],
            b1 => Assert.Equal(("ot", 7), b1),
            b2 => Assert.Equal(("ab", 5), b2),
            b3 => Assert.Equal(("pc", 6), b3));
    }


}