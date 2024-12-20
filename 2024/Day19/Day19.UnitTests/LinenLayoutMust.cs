using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests;

public class LinenLayoutMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 8, 8)]
    [InlineData(PUZZLE_INPUT, 447, 400)]
    public void LoadInputCorrectly(string input, int expectedTowels, int expectedDesigns)
    {
        var sut = new LinenLayout(input);
        Assert.Equal(expectedTowels, sut.TowelsCount);
        Assert.Equal(expectedDesigns, sut.DesignsCount);
    }

    [Theory]
    [InlineData("r\n\nr", 1)]
    [InlineData("r\n\nr\nrr", 2)]
    public void ValidateDesignCorrectly(string input, int expectedCount)
    {
        var sut = new LinenLayout(input);
        sut.ValidateWithStack();
        Assert.Equal(expectedCount, sut.ValidDesignsCount);
    }

    [Theory]
    [InlineData("r, wr, b, g, bwu, rb, gb, br\n\nubwu")]
    [InlineData("r, wr, b, g, bwu, rb, gb, br\n\nbbrgwb")]
    public void DoNotRecognizeUnknownWord(string input)
    {
        var sut = new LinenLayout(input);
        sut.ValidateWithStack();
        Assert.Equal(0, sut.ValidDesignsCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new LinenLayout(SAMPLE_INPUT);
        sut.ValidateWithStack();
        Assert.Equal(6, sut.ValidDesignsCount);
    }
    /*
    [Fact]
    public void DetectLongChainCorrectly()
    {
        var sut = new LinenLayout("brguub, gbb, bgr, uubb, uwg, wrbbuggu, ubg, bbgu, wugw, rbwur, bgbggur, wugguw, guguw, bbgrr, ggg, rwg, wuu, rbwrb, wbw, gbbug, brbbru, brr, wgww, grg, buwu, rubg, rbu, uwuw, rgb, wbrwbwu, rbgur, bgrwg, wwrgw, guw, gru, wbrbgu, brwu, wuw, bgu, wr, bwbbwb, bbbuu, ruru, wubwurru, rrguu, wguuw, gbrg, ubgg, brrw, bwr, bbg, wwwwbrb, ggrrgwg, gwwrwu, gruguw, uurbu, rgu, brb, ugwrgwrr, br, rwurgg, rbggwrw, bgb, uruw, wwr, bgbrgr, w, rbggu, bbbru, grw, guwu, wbwurg, wubwb, ruubr, wurgruw, bggru, gbuw, rbub, wgb, wb, uuuru, wuwwwbu, ruuggb, bubwuur, burrbrgw, bg, wwbuur, rugw, rwwb, wwwwrrru, wrb, grwrwu, wwggbu, ubb, rwgw, wrg, gbgbr, gwg, gbwuw, bgbwg, urrb, uwuwbbrw, uub, bww, wbggu, wuuwgw, guwr, ggww, ugrbb, uwr, buurg, wwuurwu, rbg, gugbw, uw, wurwubb, gbbb, gwru, ruwwrrw, gbrb, gwwgbb, uugr, urr, ugggub, gugw, wbbgb, rwgrwgg, gbw, rgwrrbr, uuubgwgg, wbrrugrw, ubw, bwgggg, bwwurru, wwb, grwug, rugbrr, ubbwggu, grr, ubbu, ggwwgg, uwb, gurrr, uu, gwbr, bbug, wbg, gwu, wgubrbr, gr, bwwrbgrr, bbbr, ru, rbbg, gug, ur, uuu, rbbu, wur, ruw, brggur, wgr, wwbbbwb, uru, gwgbw, gbguu, ggwgbg, buwur, rwb, uwur, bwwr, bburw, rgbwg, wubu, bbw, rbw, rgg, uww, bbb, bwgr, wwwuwg, bwu, bub, bb, buuw, bbrwbg, wrrb, wbguww, grwgwu, wbrww, grb, wurrr, bruubg, grgww, wwbwg, rguw, rug, gbr, rbbb, gbrr, wwbub, bwb, buubg, wbb, bggr, ww, rwrug, wbu, wrr, bgbw, rbr, wurwrg, uuw, rwbww, gbbgbb, wgbwb, b, wwuu, uggwg, wgruuubr, ug, uuwgw, urrw, wrbgu, burwrrr, gww, bbrbbg, bgw, rrwu, rrru, ruug, buurgu, rgw, rrbwu, uwgg, ugb, ugrwur, bgbg, ggwbg, rwbg, bgwu, wgbbbwb, gbu, ggb, wbr, gbur, brw, gb, bru, bwur, gbg, grguwgw, uwbggbrb, rbgb, ggbr, brbbbu, ugw, guu, bur, r, wgugbw, gggrwb, rru, wwbug, gbbbrw, brugwggw, buu, rubwrw, wguwr, urg, gwwbu, rbgg, bggu, brrrggbg, rgwugbww, rwuur, buw, guww, gwr, rwgg, rbgbbg, rugburw, rbgww, wbbwgbrr, ggr, wuuw, uwu, rrr, rrwgg, ggrgu, bruu, rbwuuww, gburbru, bbugw, uuub, gu, uwgurw, uggu, wurw, rrb, uurwbg, gw, wub, wbwrb, wgu, rur, gwrgw, wuww, gurwr, bbwuu, bggbg, brbgw, rrww, ubww, urguugw, uurwb, uugw, rurg, wwuugg, bbr, ubr, uwrbu, wwgbuu, uwrr, wbrwgbb, bwubwb, rgr, wbbuwbwg, ggu, rwuw, ggruww, ubwrrg, wrgg, gwbrr, rrugg, ubuuwgru, uwrbg, bwg, wwgw, urb, gubb, ugg, grwgrw, ruu, wru, ggbbuw, guwwb, ugrgw, gub, u, wrrurbb, uwuguru, rub, grwwg, wgg, wbbbru, gwrrwb, gwb, ubrgw, rr, gburu, urgubru, uwbwrwg, bwrrruuw, grrr, rw, wbubbru, bgg, urgb, wwg, rbugbuu, ggbb, wggr, wrgbu, rgurr, rrg, gubg, rrgrgrg, rwu, bguubg, bbugb, wgw, rrw, wug, wg, wwur, urw, wbubg, www, wwwwrb, rruwggu, bwbb, rwurr, rggg, wwwur, rbuu, uug, grub, rrug, gurr, wwu, wwwwrrr, ubugur, gbbbwrww, ubu, rwrubu, wrrw, gbguw, wbbgrg, wrw, rbwb, bbrrbw, ugu, rbb, rwwr, bwguuuw, bu, rrgwrg, urgrgr, ggwwwgu, grww, bbbwbbu, wbww, ub, wbbwb, gur, wu, gurgrwg, bubw, urug, uuguww, bwrrug, bbbb, rb, bbu, bguw, buug, ruwubg, wgwurrw, gguggrub, rwr, wrbw, ubbgrwu, bug, uuug, ggrgg, gg\n\nrbugwrbrgggbwbgrwwrrwrguuurbbuwwwgubrbwbrrrrgwggruurrbrg");
        sut.Validate();
        Assert.Equal(1, sut.ValidDesignsCount);
    }
*/
/*
    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new LinenLayout(PUZZLE_INPUT);
        sut.Validate();
        Assert.Equal(0, sut.ValidDesignsCount);
    }*/
}