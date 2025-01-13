using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Transactions;

namespace Day17.Logic;

public class ChronospatialComputerOriginal
{
    private readonly string _input;
    private readonly string _textProgram;
    private readonly List<int> _program;

    public ulong A { get; private set; }
    public ulong B { get; private set; }
    public ulong C { get; private set; }
    public int IP { get; private set;}
    public int Length => _program.Count;
    public string OUT { get; private set; }
    public ulong Answer { get; private set; }

    public ChronospatialComputerOriginal(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        OUT = string.Empty;
        foreach (var section in sections[0].Split('\n'))
        {
            var words = section.Split(':', StringSplitOptions.TrimEntries);
            switch (words[0][^1])
            {
                case 'A': A = ulong.Parse(words[1]); break;
                case 'B': B = ulong.Parse(words[1]); break;
                case 'C': C = ulong.Parse(words[1]); break;
            }
        }

        var programs = sections[1].Split(':', StringSplitOptions.TrimEntries);
        _textProgram = programs[1];
        _program = programs[1].Split(',').Select(int.Parse).ToList();
    }

    public int Run()
    {
        IP = 0;
        var jumps = new HashSet<(ulong, ulong, ulong, int, string)>();
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = (ulong)_program[IP++];

            switch (opcode)
            {
                case 0: // adv
                    var divisor = (ulong)Math.Pow(2, GetComboOperand(operand));
                    if (divisor == 0)
                    {
                        return -1;
                    }
                    A /= divisor;
                    break;

                case 1: // bxl
                    B ^= operand;
                    break;

                case 2: // bst
                    B = GetComboOperand(operand) % 8;
                    break;

                case 3: // jnz
                    if (A != 0)
                    {
                        if (jumps.Contains((A, B, C, IP, OUT)))
                        {
                            return jumps.Count;
                        }
                        IP = (int)operand;
                    }
                    break;

                case 4: // bxc
                    B ^= C;
                    break;

                case 5: // out
                    var result = GetComboOperand(operand) % 8;
                    if (string.IsNullOrEmpty(OUT))
                    {
                        OUT += result;
                    }
                    else
                    {
                        OUT += $",{result}";
                    }
                    break;

                case 6: // bdv
                    divisor = (ulong)Math.Pow(2, GetComboOperand(operand));
                    if (divisor == 0)
                    {
                        return -1;
                    }
                    B = A / divisor;
                    break;

                case 7: // cdv
                    divisor = (ulong)Math.Pow(2, GetComboOperand(operand));
                    if (divisor == 0)
                    {
                        return -1;
                    }
                    C = A / divisor;
                    break;
            }
        }

        return 0;
    }

    private int InvertedRun(List<(int Opcode, long Operand)> program, List<ulong> expectedValues)
    {
        var expectedIndex = 0;

        IP = 0;
        while (IP < program.Count)
        {
            var instruction = program[IP++];

            switch (instruction.Opcode)
            {
                case 0: // adv
                    //A = A * (int)Math.Pow(2, GetComboOperand(instruction.Operand));
                    break;

                case 1: // bxl
                    B ^= (ulong)instruction.Operand;
                    break;
/*
                case 2: // bst
                    B = GetComboOperand(operand) % 8;
                    break;

                case 3: // jnz
                    if (A != 0)
                    {
                        if (jumps.Contains((A, B, C, IP, OUT)))
                        {
                            return jumps.Count;
                        }
                        IP = operand;
                    }
                    break;

                case 4: // bxc
                    B ^= C;
                    break;
*/
                case 5: // out
                    var expectedValue = expectedValues[expectedIndex];
                    SetupRegisterToMatchComboOperand(expectedValue);
                    break;
/*
                case 6: // bdv
                    B = A / (int)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 7: // cdv
                    C = A / (int)Math.Pow(2, GetComboOperand(operand));
                    break;*/
            }
        }

        return 0;
    }



    private ulong GetComboOperand(ulong operand) =>
        operand switch
        {
            < 4 => operand,
            4 => A,
            5 => B,
            6 => C,
            _ => throw new ArgumentException($"Invalid operand {operand}")
        };

    private void SetupRegisterToMatchComboOperand(ulong expectedValue)
    {
        B = 8 * 1 + expectedValue;
    }

    public void Solve(string endingBits, ulong value)
    {
        var originalB = B;
        var originalC = C;
        var originalA = 0UL;
        var previousMax = 0;
        var count = endingBits.ToString().Length;
        var lastA = 0UL;
        while (OUT != _textProgram)
        {
            A = originalA++ << count | value;
            lastA = A;
            B = originalB;
            C = originalC;
            OUT = string.Empty;
            var result = RunForTest();
            if (result != 0)
            {
                if (result != -1)
                {
                    if (previousMax < result)
                    {
                        //Console.WriteLine($"Found new record with A: {lastA} OUT: {OUT}");
                        previousMax = result;
                    }
                }
            }

/*
            if ((originalA % 1_000_000) == 0)
            {
                Console.WriteLine($"{originalA} -> {lastA}");
            }*/
        }

        //Answer = (originalA - 1) * (int)Math.Pow(10, count) + ending;
        //Console.WriteLine($"Found answer with A: {lastA} OUT: {OUT}");
        Answer = lastA;
    }

    public void Solve(ulong ending)
    {
        var originalB = B;
        var originalC = C;
        var originalA = 0UL;
        var previousMax = 0;
        var count = (ulong)ending.ToString().Length;
        var lastA = 0UL;
        while (OUT != _textProgram)
        {
            A = originalA++ * 10UL * count + ending;
            lastA = A;
            B = originalB;
            C = originalC;
            OUT = string.Empty;
            var result = RunForTest();
            if (result != 0)
            {
                if (result != -1)
                {
                    if (previousMax < result)
                    {
                        //Console.WriteLine($"Found new record with A: {lastA} OUT: {OUT}");
                        previousMax = result;
                    }
                }
            }
/*
            if ((originalA % 1_000_000) == 0)
            {
                Console.WriteLine(originalA);
            }*/
        }

        //Answer = (originalA - 1) * (int)Math.Pow(10, count) + ending;
        //Console.WriteLine($"Found answer with A: {lastA} OUT: {OUT}");
        Answer = lastA;
    }



    public int RunForTest()
    {
        IP = 0;
        var jumps = new HashSet<(ulong, ulong, ulong, int, string)>();
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = (ulong)_program[IP++];

            switch (opcode)
            {
                case 0: // adv
                    A /= (ulong)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 1: // bxl
                    B ^= operand;
                    break;

                case 2: // bst
                    B = GetComboOperand(operand) % 8;
                    break;

                case 3: // jnz
                    if (A != 0)
                    {
                        if (jumps.Contains((A, B, C, IP, OUT)))
                        {
                            //Console.WriteLine($"Abort with A: {A - 1} after {jumps.Count} jumps");
                            return -1;
                        }
                        IP = (int)operand;
                    }
                    break;

                case 4: // bxc
                    B ^= C;
                    break;

                case 5: // out
                    var result = GetComboOperand(operand) % 8;
                    if (string.IsNullOrEmpty(OUT))
                    {
                        OUT += result;
                    }
                    else
                    {
                        OUT += $",{result}";
                    }

                    if (! _textProgram.StartsWith(OUT))
                    {
                        return OUT.Length;
                    }
                    break;

                case 6: // bdv
                    B = A / (ulong)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 7: // cdv
                    var divisor = (ulong)Math.Pow(2, GetComboOperand(operand));
                    if (divisor == 0)
                    {
                        return -1;
                    }

                    C = A / divisor;
                    break;
            }
        }

        return 0;
    }

    public void Reverse(long endValue)
    {
        var originalB = B;
        var originalC = C;
        var originalA = endValue;
        var backwardsProgram = new List<(int Opcode, long Operand)>();
        IP = 0;

        for (var i = _program.Count; i > 0; i-=2)
        {
            backwardsProgram.Add((_program[i-2], _program[i-1]));
        }

        var expectedValues = new List<ulong>();
        for (var i = _program.Count - 1; i >= 0; i--)
        {
            expectedValues.Add((ulong)_program[i]);
        }

        InvertedRun(backwardsProgram, expectedValues);
    }
}


public class ChronospatialComputer
{
    private readonly string _input;
    private readonly string _textProgram;
    private readonly List<int> _program;

    public string A { get; private set; }
    public string B { get; private set; }
    public string C { get; private set; }
    public int IP { get; private set;}
    public int Length => _program.Count;
    public string OUT { get; private set; }
    public string Answer { get; private set; }

    public ChronospatialComputer(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        OUT = string.Empty;
        foreach (var section in sections[0].Split('\n'))
        {
            var words = section.Split(':', StringSplitOptions.TrimEntries);
            switch (words[0][^1])
            {
                case 'A': A = Convert.ToString(long.Parse(words[1]), 2); break;
                case 'B': B = Convert.ToString(long.Parse(words[1]), 2); break;
                case 'C': C = Convert.ToString(long.Parse(words[1]), 2); break;
            }
        }

        var programs = sections[1].Split(':', StringSplitOptions.TrimEntries);
        _textProgram = programs[1];
        _program = programs[1].Split(',').Select(int.Parse).ToList();
    }

    private string GetComboOperand(int operand) =>
        operand switch
        {
            < 4 => Convert.ToString(operand, 2).PadRight(3, '0'),
            4 => A,
            5 => B,
            6 => C,
            _ => throw new ArgumentException($"Invalid operand {operand}")
        };

    public void Solve(string endingBits)
    {
        var originalB = B;
        var originalC = C;
        var originalA = 0UL;
        var previousMax = 0;
        var count = endingBits.ToString().Length;
        var lastA = string.Empty;
        while (OUT != _textProgram)
        {
            char[] nextBits = { '0', '1' };
            foreach (var nextBit in nextBits)
            {
                A = nextBit + endingBits;
                lastA = A;
                B = originalB;
                C = originalC;
                OUT = string.Empty;
                var result = RunForTest();
                if (result != 0)
                {
                    if (result != -1)
                    {
                        if (previousMax < result)
                        {
                            //Console.WriteLine($"Found new record with A: {lastA} OUT: {OUT}");
                            previousMax = result;
                        }
                    }
                }
/*
                if ((originalA % 1_000_000) == 0)
                {
                    Console.WriteLine($"{originalA} -> {lastA}");
                }*/
            }
        }

        //Answer = (originalA - 1) * (int)Math.Pow(10, count) + ending;
        //Console.WriteLine($"Found answer with A: {lastA} OUT: {OUT}");
        Answer = lastA;
    }

    public int RunForTest()
    {
        IP = 0;
        var jumps = new HashSet<(ulong, ulong, ulong, int, string)>();
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = _program[IP++];

            switch (opcode)
            {
                case 0: // adv (0,3)
                    if (operand != 3)
                    {
                        throw new UnreachableException();
                    }

                    A = A[..^operand];
                    break;

                case 1: // bxl (1,5), (1,6)
                    var value = Convert.ToByte(B, 2) ^ operand;
                    B = Convert.ToString(value, 2);
                    break;

                case 2: // bst (2,4)
                    B = A[^3..];
                    break;

                case 3: // jnz (3,0)
                    IP = operand;
                    break;

                case 4: // bxc (4,5)
                    B = Xor3(B, C);
                    break;

                case 5: // out (5,5)
                    var result = B[^3..];
                    if (string.IsNullOrEmpty(OUT))
                    {
                        OUT += result;
                    }
                    else
                    {
                        OUT += $",{result}";
                    }

                    if (! _textProgram.StartsWith(OUT))
                    {
                        return OUT.Length;
                    }
                    break;

                case 6: // bdv
                    throw new UnreachableException();

                case 7: // cdv (7,5)
                    var offset = Convert.ToByte(B, 2);
                    C = A[..^offset];
                    break;
            }
        }

        return 0;
    }

    private string Xor3(string b, string c)
    {
        var result = string.Empty;
        for (var index = 0; index < 3; index++)
        {
            if (b[index] == c[index])
            {
                result += 0;
            }
            else
            {
                result += 1;
            }
        }

        return result;
    }

    private bool PureZero(string a) => A.Select(p => p - '0').Sum() == 0;
}


public class ChronospatialComputerOptimized
{
    private readonly string _input;
    private readonly string _textProgram;
    private readonly List<int> _program;

    public ulong A { get; private set; }
    public ulong B { get; private set; }
    public ulong C { get; private set; }
    public int IP { get; private set;}
    public int Length => _program.Count;
    public string OUT { get; private set; }
    public ulong Answer { get; private set; }

    public ChronospatialComputerOptimized(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        OUT = string.Empty;
        foreach (var section in sections[0].Split('\n'))
        {
            var words = section.Split(':', StringSplitOptions.TrimEntries);
            switch (words[0][^1])
            {
                case 'A': A = ulong.Parse(words[1]); break;
                case 'B': B = ulong.Parse(words[1]); break;
                case 'C': C = ulong.Parse(words[1]); break;
            }
        }

        var programs = sections[1].Split(':', StringSplitOptions.TrimEntries);
        _textProgram = programs[1];
        _program = programs[1].Split(',').Select(int.Parse).ToList();
    }

    public int Run()
    {
        IP = 0;
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = (ulong)_program[IP++];

            switch (opcode)
            {
                case 0: // adv (0,3)
                    A = A >> 3;
                    break;

                case 1: // bxl (1,5) (1,6)
                    B ^= operand;
                    break;

                case 2: // bst (2,4)
                    B = A & 0b111;
                    break;

                case 3: // jnz
                    if (A != 0)
                    {
                        IP = (int)operand;
                    }
                    break;

                case 4: // bxc
                    B ^= C;
                    break;

                case 5: // out (5,5)
                    var result = B & 0b111;
                    if (string.IsNullOrEmpty(OUT))
                    {
                        OUT += result;
                    }
                    else
                    {
                        OUT += $",{result}";
                        if (OUT.StartsWith("2,4,1,5,7,5,4,5,0,3,1,6,5"))
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                    }
                    break;

                case 6: // bdv
                    throw new UnreachableException();

                case 7: // cdv (7,5)
                    C = A >> (int)B;
                    break;
            }
        }

        var index = 0;
        for (; index < OUT.Length; index++)
        {
            if (OUT[index] != _textProgram[index])
                break;
        }

        if (index > 0)
        {
            return index;
        }
        return index;
    }

    public int RunForTest2()
    {
        IP = 0;
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = (ulong)_program[IP++];

            switch (opcode)
            {
                case 0: // adv (0,3)
                    A = A >> 3;
                    break;

                case 1: // bxl (1,5) (1,6)
                    B ^= operand;
                    break;

                case 2: // bst (2,4)
                    B = A & 0b111;
                    break;

                case 3: // jnz
                    if (A != 0)
                    {
                        IP = (int)operand;
                    }
                    break;

                case 4: // bxc
                    B ^= C;
                    break;

                case 5: // out (5,5)
                    var result = B & 0b111;
                    if (string.IsNullOrEmpty(OUT))
                    {
                        OUT += result;
                    }
                    else
                    {
                        OUT += $",{result}";
                    }

                    if (! _textProgram.StartsWith(OUT))
                    {
                        return OUT.Length;
                    }
                    break;

                case 6: // bdv
                    throw new UnreachableException();

                case 7: // cdv (7,5)
                    C = A >> (int)B;
                    break;
            }
        }

        return 0;
    }



    private int InvertedRun(List<(int Opcode, long Operand)> program, List<ulong> expectedValues)
    {
        var expectedIndex = 0;

        IP = 0;
        while (IP < program.Count)
        {
            var instruction = program[IP++];

            switch (instruction.Opcode)
            {
                case 0: // adv
                    //A = A * (int)Math.Pow(2, GetComboOperand(instruction.Operand));
                    break;

                case 1: // bxl
                    B ^= (ulong)instruction.Operand;
                    break;
/*
                case 2: // bst
                    B = GetComboOperand(operand) % 8;
                    break;

                case 3: // jnz
                    if (A != 0)
                    {
                        if (jumps.Contains((A, B, C, IP, OUT)))
                        {
                            return jumps.Count;
                        }
                        IP = operand;
                    }
                    break;

                case 4: // bxc
                    B ^= C;
                    break;
*/
                case 5: // out
                    var expectedValue = expectedValues[expectedIndex];
                    SetupRegisterToMatchComboOperand(expectedValue);
                    break;
/*
                case 6: // bdv
                    B = A / (int)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 7: // cdv
                    C = A / (int)Math.Pow(2, GetComboOperand(operand));
                    break;*/
            }
        }

        return 0;
    }



    private ulong GetComboOperand(ulong operand) =>
        operand switch
        {
            < 4 => operand,
            4 => A,
            5 => B,
            6 => C,
            _ => throw new ArgumentException($"Invalid operand {operand}")
        };

    private void SetupRegisterToMatchComboOperand(ulong expectedValue)
    {
        B = 8 * 1 + expectedValue;
    }

    public void Solve(string endingBits, ulong value)
    {
        var originalB = B;
        var originalC = C;
        var originalA = 0UL;
        var previousMax = 0;
        var count = endingBits.ToString().Length;
        var lastA = 0UL;
        while (OUT != _textProgram)
        {
            A = originalA++ << count | value;
            lastA = A;
            B = originalB;
            C = originalC;
            OUT = string.Empty;
            var result = RunForTest();
            if (result != 0)
            {
                if (result != -1)
                {
                    if (previousMax < result)
                    {
                        //Console.WriteLine($"Found new record with A: {lastA} OUT: {OUT}");
                        previousMax = result;
                    }
                }
            }
/*
            if ((originalA % 1_000_000) == 0)
            {
                Console.WriteLine($"{originalA} -> {lastA}");
            }*/
        }

        //Answer = (originalA - 1) * (int)Math.Pow(10, count) + ending;
        //Console.WriteLine($"Found answer with A: {lastA} OUT: {OUT}");
        Answer = lastA;
    }

    public void Solve(ulong ending)
    {
        var originalB = B;
        var originalC = C;
        var originalA = 0UL;
        var previousMax = 0;
        var count = (ulong)ending.ToString().Length;
        var lastA = 0UL;
        while (OUT != _textProgram)
        {
            A = originalA++ * 10UL * count + ending;
            lastA = A;
            B = originalB;
            C = originalC;
            OUT = string.Empty;
            var result = RunForTest();
            if (result != 0)
            {
                if (result != -1)
                {
                    if (previousMax < result)
                    {
                        //Console.WriteLine($"Found new record with A: {lastA} OUT: {OUT}");
                        previousMax = result;
                    }
                }
            }
/*
            if ((originalA % 1_000_000) == 0)
            {
                Console.WriteLine(originalA);
            }*/
        }

        //Answer = (originalA - 1) * (int)Math.Pow(10, count) + ending;
        //Console.WriteLine($"Found answer with A: {lastA} OUT: {OUT}");
        Answer = lastA;
    }



    public int RunForTest()
    {
        IP = 0;
        var jumps = new HashSet<(ulong, ulong, ulong, int, string)>();
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = (ulong)_program[IP++];

            switch (opcode)
            {
                case 0: // adv
                    A /= (ulong)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 1: // bxl
                    B ^= operand;
                    break;

                case 2: // bst
                    B = GetComboOperand(operand) % 8;
                    break;

                case 3: // jnz
                    if (A != 0)
                    {
                        if (jumps.Contains((A, B, C, IP, OUT)))
                        {
                            //Console.WriteLine($"Abort with A: {A - 1} after {jumps.Count} jumps");
                            return -1;
                        }
                        IP = (int)operand;
                    }
                    break;

                case 4: // bxc
                    B ^= C;
                    break;

                case 5: // out
                    var result = GetComboOperand(operand) % 8;
                    if (string.IsNullOrEmpty(OUT))
                    {
                        OUT += result;
                    }
                    else
                    {
                        OUT += $",{result}";
                    }

                    if (! _textProgram.StartsWith(OUT))
                    {
                        return OUT.Length;
                    }
                    break;

                case 6: // bdv
                    B = A / (ulong)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 7: // cdv
                    var divisor = (ulong)Math.Pow(2, GetComboOperand(operand));
                    if (divisor == 0)
                    {
                        return -1;
                    }

                    C = A / divisor;
                    break;
            }
        }

        return 0;
    }

    public void Reverse(long endValue)
    {
        var originalB = B;
        var originalC = C;
        var originalA = endValue;
        var backwardsProgram = new List<(int Opcode, long Operand)>();
        IP = 0;

        for (var i = _program.Count; i > 0; i-=2)
        {
            backwardsProgram.Add((_program[i-2], _program[i-1]));
        }

        var expectedValues = new List<ulong>();
        for (var i = _program.Count - 1; i >= 0; i--)
        {
            expectedValues.Add((ulong)_program[i]);
        }

        InvertedRun(backwardsProgram, expectedValues);
    }
}

