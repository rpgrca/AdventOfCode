
namespace Day17.Logic;

public class ChronospatialComputer
{
    private readonly string _input;
    private readonly List<int> _program;

    public int A { get; private set; }
    public int B { get; private set; }
    public int C { get; private set; }
    public int IP { get; private set;}
    public int Length => _program.Count;
    public string OUT { get; private set; }

    public ChronospatialComputer(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        foreach (var section in sections[0].Split('\n'))
        {
            var words = section.Split(':', StringSplitOptions.TrimEntries);
            switch (words[0][^1])
            {
                case 'A': A = int.Parse(words[1]); break;
                case 'B': B = int.Parse(words[1]); break;
                case 'C': C = int.Parse(words[1]); break;
            }
        }

        var programs = sections[1].Split(':', StringSplitOptions.TrimEntries);
        _program = programs[1].Split(',').Select(int.Parse).ToList();
    }

    public void Run()
    {
        IP = 0;
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
            }
        }
    }

    private int GetComboOperand(int operand) =>
        operand switch
        {
            < 4 => operand,
            4 => A,
            5 => B,
            6 => C,
            _ => throw new ArgumentException($"Invalid operand {operand}")
        };
}