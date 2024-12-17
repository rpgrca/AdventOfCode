namespace Day17.Logic;

public class ChronospatialComputer
{
    private readonly string _input;
    private readonly List<int> _program;

    public long A { get; private set; }
    public long B { get; private set; }
    public long C { get; private set; }
    public int IP { get; private set;}
    public int Length => _program.Count;

    public ChronospatialComputer(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
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
        _program = programs[1].Split(',').Select(int.Parse).ToList();
    }

    public void Run()
    {
        IP = 0;
        while (IP < Length)
        {
            var opcode = _program[IP++];
            var operand = _program[IP];

            switch (opcode)
            {
                case 0: // adv
                    switch (operand)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            A /= operand;
                            break;
                        case 4:
                            A /= A;
                            break;
                        case 5:
                            A /= B;
                            break;
                        case 6:
                            A /= C;
                            break;
                        case 7:
                            throw new ArgumentException("Invalid operand 7");
                    }
                    IP++;
                    break;
            }
        }
    }
}