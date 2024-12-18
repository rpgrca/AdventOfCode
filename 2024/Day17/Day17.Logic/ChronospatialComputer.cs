using System.Diagnostics;

namespace Day17.Logic;

public class ChronospatialComputer
{
    private readonly string _input;
    private readonly string _textProgram;
    private readonly List<int> _program;

    public long A { get; private set; }
    public long B { get; private set; }
    public long C { get; private set; }
    public int IP { get; private set;}
    public int Length => _program.Count;
    public string OUT { get; private set; }
    public long Answer { get; private set; }

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
                case 'A': A = long.Parse(words[1]); break;
                case 'B': B = long.Parse(words[1]); break;
                case 'C': C = long.Parse(words[1]); break;
            }
        }

        var programs = sections[1].Split(':', StringSplitOptions.TrimEntries);
        _textProgram = programs[1];
        _program = programs[1].Split(',').Select(int.Parse).ToList();
    }

    public int Run()
    {
        IP = 0;
        var jumps = new HashSet<(long, long, long, long, string)>();
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = _program[IP++];

            switch (opcode)
            {
                case 0: // adv
                    A /= (int)Math.Pow(2, GetComboOperand(operand));
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
                        IP = operand;
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
                    B = A / (int)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 7: // cdv
                    C = A / (int)Math.Pow(2, GetComboOperand(operand));
                    break;
            }
        }

        return 0;
    }

    private int InvertedRun(List<(int Opcode, long Operand)> program, List<int> expectedValues)
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
                    B ^= instruction.Operand;
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



    private long GetComboOperand(int operand) =>
        operand switch
        {
            < 4 => operand,
            4 => A,
            5 => B,
            6 => C,
            _ => throw new ArgumentException($"Invalid operand {operand}")
        };

    private void SetupRegisterToMatchComboOperand(int expectedValue)
    {
        B = 8 * 1 + expectedValue;
    }

    public void Solve(long ending)
    {
        var originalB = B;
        var originalC = C;
        var originalA = 0;
        var previousMax = 0;
        var count = ending.ToString().Length - 1;
        while (OUT != _textProgram)
        {
            A = originalA++ * (int)Math.Pow(10, count) + ending;
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
                        Console.WriteLine($"Found new record with A: {originalA - 1} OUT: {OUT}");
                        previousMax = result;
                    }
                }
            }

            if ((originalA % 1_000_000) == 0)
            {
                Console.WriteLine(originalA * 10 * count + ending);
            }
        }

        Answer = (originalA - 1) * (int)Math.Pow(10, count) + ending;
    }

    public int RunForTest()
    {
        IP = 0;
        var jumps = new HashSet<(long, long, long, long, string)>();
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = _program[IP++];

            switch (opcode)
            {
                case 0: // adv
                    A /= (int)Math.Pow(2, GetComboOperand(operand));
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
                            Console.WriteLine($"Abort with A: {A - 1} after {jumps.Count} jumps");
                            return -1;
                        }
                        IP = operand;
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
                    B = A / (int)Math.Pow(2, GetComboOperand(operand));
                    break;

                case 7: // cdv
                    C = A / (int)Math.Pow(2, GetComboOperand(operand));
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

        var expectedValues = new List<int>();
        for (var i = _program.Count - 1; i >= 0; i--)
        {
            expectedValues.Add(_program[i]);
        }

        InvertedRun(backwardsProgram, expectedValues);
    }
}