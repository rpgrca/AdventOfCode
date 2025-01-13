using Day17.Logic;
using Microsoft.VisualBasic;
using static Day17.UnitTests.Constants;

namespace Day17.UnitTests;

public class ChronospatialComputerMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 729, 0, 0, 6)]
    [InlineData(PUZZLE_INPUT, 63281501, 0, 0, 16)]
    public void LoadInputCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC, int expectedLength)
    {
        var sut = new ChronospatialComputerOriginal(input);
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Theory]
    [InlineData("Register A: 0\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1", 0, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1", 32, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,2", 16, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,3", 8, 0, 0)]
    //[InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,4", 0, 2, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,5", 16, 2, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,6", 2, 2, 5)]
    public void SetAWithDivisionOfABy2PowerComboOperand_WhenExecutingAdvOpcodeCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Fact]
    public void ThrowException_WhenAdvOperandIs7()
    {
        var sut = new ChronospatialComputerOriginal("Register A: 0\nRegister B: 0\nRegister C: 0\n\nProgram: 0,7");
        var exception = Assert.Throws<ArgumentException>(() => sut.Run());
        Assert.Equal("Invalid operand 7", exception.Message);
    }

    [Theory]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,0", 2, 15, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,1", 2, 14, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,2", 2, 13, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,3", 2, 12, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,4", 2, 11, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,5", 2, 10, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,6", 2, 9, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,7", 2, 8, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,8", 2, 7, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,9", 2, 6, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,10", 2, 5, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,11", 2, 4, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,12", 2, 3, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,13", 2, 2, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,14", 2, 1, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,15", 2, 0, 3)]
    public void ExecuteBxlOpcodeCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,0", 2, 0, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,1", 2, 1, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,2", 2, 2, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,3", 2, 3, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,4", 2, 2, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,5", 2, 7, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,6", 2, 3, 3)]
    public void ExecuteBstOpcodeCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 0\nRegister B: 15\nRegister C: 3\n\nProgram: 3,4,0,2", 0, 15, 3)]
    [InlineData("Register A: 64\nRegister B: 15\nRegister C: 3\n\nProgram: 3,4,0,2", 64, 15, 3)]
    public void ExecuteJnzOpcodeCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 64\nRegister B: 15\nRegister C: 15\n\nProgram: 4,1", 64, 0, 15)]
    [InlineData("Register A: 64\nRegister B: 15\nRegister C: 1\n\nProgram: 4,2", 64, 14, 1)]
    public void SetRegisterBWithRegisterBXorRegisterA_WhenExecutingBxcOpcodeCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,0", 64, 25, 36, "0")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,1", 64, 25, 36, "1")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,2", 64, 25, 36, "2")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,3", 64, 25, 36, "3")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,4", 64, 25, 36, "0")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,5", 64, 25, 36, "1")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,6", 64, 25, 36, "4")]
    public void ReturnResult_WhenUsingOutOpcode(string input, ulong expectedA, ulong expectedB, ulong expectedC, string expectedOutput)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
        Assert.Equal(expectedOutput, sut.OUT);
    }

    [Theory]
    [InlineData("Register A: 0\nRegister B: 0\nRegister C: 0\n\nProgram: 6,1", 0, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 6,1", 64, 32, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 6,2", 64, 16, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 6,3", 64, 8, 0)]
    //[InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 6,4", 64, 0, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 6,5", 64, 16, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 6,6", 64, 2, 5)]
    public void SetBWithDivisionOfABy2PowerComboOperand_WhenExecutingBdvOpcodeCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 0\nRegister B: 0\nRegister C: 0\n\nProgram: 7,1", 0, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 7,1", 64, 0, 32)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 7,2", 64, 0, 16)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 7,3", 64, 0, 8)]
    //[InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 7,4", 64, 2, 0)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 7,5", 64, 2, 16)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 7,6", 64, 2, 2)]
    public void SetCWithDivisionOfABy2PowerComboOperand_WhenExecutingCdvOpcodeCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 0\nRegister B: 0\nRegister C: 9\n\nProgram: 2,6", 0, 1, 9, "")]
    [InlineData("Register A: 10\nRegister B: 0\nRegister C: 0\n\nProgram: 5,0,5,1,5,4", 10, 0, 0, "0,1,2")]
    [InlineData("Register A: 2024\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1,5,4,3,0", 0, 0, 0, "4,2,5,6,7,7,7,7,3,1,0")]
    [InlineData("Register A: 0\nRegister B: 29\nRegister C: 0\n\nProgram: 1,7", 0, 26, 0, "")]
    [InlineData("Register A: 0\nRegister B: 2024\nRegister C: 43690\n\nProgram: 4,0", 0, 44354, 43690, "")]
    public void ExecuteSamplesCorrectly(string input, ulong expectedA, ulong expectedB, ulong expectedC, string expectedOut)
    {
        var sut = new ChronospatialComputerOriginal(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
        Assert.Equal(expectedOut, sut.OUT);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new ChronospatialComputerOriginal(SAMPLE_INPUT);
        sut.Run();
        Assert.Equal("4,6,3,5,6,3,5,2,1,0", sut.OUT);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new ChronospatialComputerOriginal(PUZZLE_INPUT);
        sut.Run();
        Assert.Equal("3,4,3,1,7,6,5,6,0", sut.OUT);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new ChronospatialComputerOriginal(SECOND_SAMPLE_INPUT);
        sut.Solve(0);
        Assert.Equal(117440UL, sut.Answer);
    }

/*
    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new ChronospatialComputer(PUZZLE_INPUT);
        //sut.Solve(267411);
        //sut.Solve("1000001010010010011", 267411);
        sut.Solve("1110001010010101010011010000000100010011011");
        Assert.Equal("", sut.Answer);
    }
*/

    [Fact(Skip = "For testing")]
    public void Test()
    {
        //var value = 202341093744911;
        //var value = 241264265751990; todo 3
        //var value = 40210710958665; todo 6
        //var value = 412799239201;
        //var value = 26419149414664;
        //var value = 277_145_634_763_263;
        //var value = 267411; // 2,4,1,5,6,3,2
        //var value =   20_038_813_851;  // 2,4,1,5,7,5,4,5,0,3,1,1?
        //var value =  7_785_339_685_019;  // 2,4,1,5,7,5,4,5,0,3,1,6,5,4
        //var value =  // 2,4,1,5,7,5,4,5,0,3,6,2,3,0,5,5,1,7,2
        //var ending = 20_038_813_851;
        //var ending = 23_595_163;
        //var ending = 109019828586651; // 2,4,1,5,7,1,5,6,2,3,1,6,5,5,3,0
        //var ending = 109019836975259; // 2,4,1,5,7,1,5,3,2,3,1,6,5,5,3,0
        //var ending = 109019866335387; // 2,4,1,5,7,5,4,5,7,3,1,6,5,5,3,0
        //var ending = 109019870529691; // 2,4,1,5,7,1,4,3,7,3,1,6,5,5,3,0
        //var ending = 109019891501211; // 2,4,1,5,7,5,4,3,4,3,1,6,5,5,3,0
        //var ending = 109019857946779; // 2,4,1,5,7,5,5,7,0,3,1,6,5,5,3,0
        //var ending = 109019841169563; // 2,4,1,5,7,5,5,5,2,3,1,6,5,5,3,0
        //var ending = 109019832780955; // 2,4,1,5,7,5,5,5,2,3,1,6,5,5,3,0
        //var ending = 109019934492827; // 2,4,1,5,7,4,6,5,0,3,1,6,5,5,3,0
                                        // 2,4,1,5,7,5,4,5,0,3,1,6,5,5,3,0
        //var ending = 109019930298523; // 2,4,1,5,7,0,4,5,0,3,1,6,5,5,3,0 - 11000110010011100101110001110000000100010011011
        //var ending = 109019849558171; // 2,4,1,5,7,5,5,5,0,3,1,6,5,5,3,0 - 11000110010011100101001011010000000100010011011
        var ending = 109019849820315;
        //var ending = 13_579_585_691;
        //var ending = 1_785_202_843;
        //var ending = 6_817_947;
        //var ending = 67_739;
        //var ending = 6_299;
        //var ending = 2_219_062_069_403;
        //var ending = 5_517_596_952_731;
        //var ending = 1_119_550_441_627;
        //var ending = 13_214_178_347_163; //2,4,1,5,7,5,4,5,0,3,1,5,5,3,0
        var endingBits = Convert.ToString(ending, 2);
        var bitsLength = endingBits.Length;
        var index = 0UL;
        var maximum = 0;
        while (true)
        {
            /*var bits = Convert.ToString(index, 2) + endingBits;
            var value = Convert.ToUInt64(bits, 2);*/
            var value = ((ulong)index << bitsLength) | (ulong)ending;
            //var value = 19_330_211_776_667; // 2,4,1,5,7,5,4,5,0,3,5,0,3,0,5
            //var value = 7_785_339_685_019;

            //var value =  ((ulong)101532 << 30) | ((ulong)index << 20 ) | 526491; // casi
            var sut = new ChronospatialComputerOptimized(@$"Register A: {value}
Register B: 0
Register C: 0

Program: 2,4,1,5,7,5,4,5,0,3,1,6,5,5,3,0");
            var result = sut.Run();
            //File.AppendAllText("/home/roberto/ddebug4.txt", $"{value} - {Convert.ToString((long)value, 2)} - {sut.OUT} - {index}\n");
            if ("2,4,1,5,7,5,4,5,0,3,1,6,5,5,3,0" == sut.OUT)
            {
                //Console.WriteLine($"Found match {sut.OUT} with {value} ({index})");
                return;
            }
                if (maximum < result)
                {
                    maximum = result;
                    //Console.WriteLine($"Found best match {sut.OUT} with ({value})");
                }

            if (sut.OUT.Length > 31)
            {
                //Console.WriteLine($"Attempt {sut.OUT} with ({value}) longer than program, aborting.");
                return;
            }

            index++;/*
            if (index % 1_000_000 == 0)
            {
                Console.WriteLine($"{index} ({value})");
            }*/
        }
    }

/*
    [Theory]
    [InlineData(0, 0, 0, "0,1", 0, 0, 0)]
    [InlineData(32, 0, 0, "0,1", 64, 0, 0)]
    [InlineData(16, 0, 0, "0,2", 64, 0, 0)]
    [InlineData(8, 0, 0, "0,3", 64, 0, 0)]
    [InlineData(0, 2, 5, "0,4", 64, 2, 5)]
    [InlineData(16, 2, 5, "0,5", 64, 2, 5)]
    [InlineData(2, 2, 5, "0,6", 64, 2, 5)]
    public void ReverseAdvOperationCorrectly(int a, int b, int c, string program, int expectedA, int expectedB, int expectedC)
    {
        var sut = new ChronospatialComputer($"Register A: {a}\nRegister B: {b}\nRegister C: {c}\n\nProgram: {program}");
        sut.Reverse();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }*/

/*
    [Theory]
    [InlineData(2, 15, 3, "1,0", 2, 15, 3)]
    [InlineData(2, 14, 3, "1,1", 2, 15, 3)]
    [InlineData(2, 13, 3, "1,2", 2, 15, 3)]
    [InlineData(2, 12, 3, "1,3", 2, 15, 3)]
    [InlineData(2, 11, 3, "1,4", 2, 15, 3)]
    [InlineData(2, 10, 3, "1,5", 2, 15, 3)]
    [InlineData(2, 9, 3, "1,6", 2, 15, 3)]
    [InlineData(2, 8, 3, "1,7", 2, 15, 3)]
    [InlineData(2, 7, 3, "1,8", 2, 15, 3)]
    [InlineData(2, 6, 3, "1,9", 2, 15, 3)]
    [InlineData(2, 5, 3, "1,10", 2, 15, 3)]
    [InlineData(2, 4, 3, "1,11", 2, 15, 3)]
    [InlineData(2, 3, 3, "1,12", 2, 15, 3)]
    [InlineData(2, 2, 3, "1,13", 2, 15, 3)]
    [InlineData(2, 1, 3, "1,14", 2, 15, 3)]
    [InlineData(2, 0, 3, "1,15", 2, 15, 3)]
    public void ReverseBxlCorrectly(int a, int b, int c, string program, int expectedA, int expectedB, int expectedC)
    {
        var sut = new ChronospatialComputer($"Register A: {a}\nRegister B: {b}\nRegister C: {c}\n\nProgram: {program}");
        sut.Reverse();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }
*/
    [Fact]
    public void ReverseEngineerCode()
    {
        var sut = new ChronospatialDebugger(PUZZLE_INPUT);
        sut.Debug();
        //Console.WriteLine(sut.Result);
    }
}

public class ChronospatialDebugger
{
    private readonly List<long> _program;
    private long A;
    private long B;
    private long C;

    public ChronospatialDebugger(string input)
    {
        _program = input.Split("\n\n")[1].Split(':', StringSplitOptions.TrimEntries)[1].Split(',').Select(long.Parse).ToList();
    }

    public ulong Result { get; private set; }

    public void Debug()
    {
        long a, b, c;

        var possibleValidEndValues = new Dictionary<int, List<string>>();
        var index = 0;
        foreach (var value in _program)
        {
            possibleValidEndValues.Add(index, new());
            B = value;
            B ^= 6;
            var possibleBandCvalues = Find_BxorC_Combinations();
            foreach (var possibleBandCvalue in possibleBandCvalues)
            {
                var last3Abits = possibleBandCvalue.B ^ 5;
                var possibleAending = possibleBandCvalue.C << (int)possibleBandCvalue.B;
                var testAending = (possibleAending | last3Abits) >> (int)possibleBandCvalue.B;
                if (testAending == possibleBandCvalue.C)
                {
                    if (possibleBandCvalue.B - 3 >= 0)
                    {
                        var temp = ConvertTo3BitString(possibleBandCvalue.C) + new string('x', (int)possibleBandCvalue.B - 3) + ConvertTo3BitString(last3Abits);
                        //var temp = ConvertTo3BitString(last3Abits);
                        possibleValidEndValues[index].Add(temp);
                    }
                    else
                    {
                        /*
                        switch (3 - possibleBandCvalue.B)
                        {
                            case 0:
                                possibleValidValues[index].Add(ConvertTo3BitString(possibleBandCvalue.C));
                                break;
                            case 1:
                                var temp2 = ConvertTo3BitString(possibleBandCvalue.C) + (possibleBandCvalue.B % 2);
                                possibleValidValues[index].Add(temp2);
                                break;
                            case 2:
                                var temp3 = ConvertTo3BitString(possibleBandCvalue.C) + (possibleBandCvalue.B % 4);
                                possibleValidValues[index].Add(temp3);
                                break;
                        }*/
                        possibleValidEndValues[index].Add(ConvertTo3BitString(possibleBandCvalue.B) + "->" + ConvertTo3BitString(possibleBandCvalue.C));
                    }
                }
                else
                {
                        var possibleMergedValue = possibleAending | last3Abits;
                        if ((possibleMergedValue & last3Abits) == 0)
                        {

                        }

                        var temp = ConvertTo3BitString(possibleAending | last3Abits);
                        //var temp = ConvertTo3BitString(last3Abits);
                        possibleValidEndValues[index].Add(temp);

                }
            }

            index++;
        }

        var bits = string.Empty;


        foreach (var possibleValues in possibleValidEndValues)
        {
            //Console.WriteLine(possibleValues.Key);
            foreach (var possibleValue in possibleValues.Value)
            {
                //Console.WriteLine(possibleValue);
            }
        }
/*
        foreach (var possibleValues0 in possibleValidValues[0].OrderBy(p => p.Length))
        {
            foreach (var possibleValues1 in possibleValidValues[1].OrderBy(p => p.Length))
            {
                foreach (var possibleValues2 in possibleValidValues[2].OrderBy(p => p.Length))
                {
                    foreach (var possibleValues3 in possibleValidValues[3].OrderBy(p => p.Length))
                    {
                        foreach (var possibleValues4 in possibleValidValues[4].OrderBy(p => p.Length))
                        {
                            foreach (var possibleValues5 in possibleValidValues[5].OrderBy(p => p.Length))
                            {
                                foreach (var possibleValues6 in possibleValidValues[6].OrderBy(p => p.Length))
                                {
                                    foreach (var possibleValues7 in possibleValidValues[7].OrderBy(p => p.Length))
                                    {
                                        foreach (var possibleValues8 in possibleValidValues[8].OrderBy(p => p.Length))
                                        {
                                            foreach (var possibleValues9 in possibleValidValues[9].OrderBy(p => p.Length))
                                            {
                                                foreach (var possibleValues10 in possibleValidValues[10].OrderBy(p => p.Length))
                                                {
                                                    foreach (var possibleValues11 in possibleValidValues[11].OrderBy(p => p.Length))
                                                    {
                                                        foreach (var possibleValues12 in possibleValidValues[12].OrderBy(p => p.Length))
                                                        {
                                                            foreach (var possibleValues13 in possibleValidValues[13].OrderBy(p => p.Length))
                                                            {
                                                                foreach (var possibleValues14 in possibleValidValues[14].OrderBy(p => p.Length))
                                                                {
                                                                    foreach (var possibleValues15 in possibleValidValues[15].OrderBy(p => p.Length))
                                                                    {
                                                                        bits =  possibleValues15 + possibleValues14 +
                                                                                possibleValues13 + possibleValues12 +
                                                                                possibleValues11 + possibleValues10 +
                                                                                possibleValues9 + possibleValues8 +
                                                                                possibleValues7 + possibleValues6 +
                                                                                possibleValues5 + possibleValues4 +
                                                                                possibleValues3 + possibleValues2 +
                                                                                possibleValues1 + possibleValues0;
                                                                        Result = Convert.ToUInt64(bits, 2);

                                                                        var sut = new ChronospatialComputer(@$"Register A: {Result}
Register B: 0
Register C: 0

Program: 2,4,1,5,7,5,4,5,0,3,1,6,5,5,3,0");
                                                                        sut.RunForTest();
                                                                        if (sut.OUT.StartsWith("2,4,1,5"))
                                                                        {
                                                                            Console.WriteLine(sut.OUT);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }*/
    }

    private string ConvertTo3BitString(long value) =>
        value switch
            {
                0 => "000",
                1 => "001",
                2 => "010",
                3 => "011",
                4 => "100",
                5 => "101",
                6 => "110",
                _ => "111"
            };

    private List<(long B, long C)> Find_BxorC_Combinations()
    {
        var result = new List<(long B, long C)>();
        for (var index = 0; index < 8; index++)
        {
            result.Add((index, B^index));
        }

        return result;
    }
}