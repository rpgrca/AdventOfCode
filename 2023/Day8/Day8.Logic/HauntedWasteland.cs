





namespace Day8.Logic;
public class HauntedWasteland
{
    private readonly string _input;
    private int _currentIndex;

    public int StateCount { get; private set; }
    public int InstructionCount { get; private set; }
    public string Instructions { get; private set; }
    public Dictionary<string, Dictionary<char, string>> Steps { get; private set; }
    public long StepsToReachGoal { get; private set; }
    public string[] CurrentStates { get; private set; }

    public HauntedWasteland(string input, bool forGhosts = false)
    {
        _input = input;
        Instructions = string.Empty;
        Steps = new Dictionary<string, Dictionary<char, string>>();
        CurrentStates = Array.Empty<string>();

        Parse();

        if (!forGhosts)
        {
            CalculateStepsToGoal();
        }
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        var currentStates = new List<string>();
        Instructions = lines[0];
        InstructionCount = lines[0].Length;

        StateCount = lines.Length - 2;
        foreach (var line in lines[2..])
        {
            var values = line.Split("=");
            var key = values[0].Trim();
            Steps.Add(key, new Dictionary<char, string>());

            var branches = values[1].Trim()[1..^1].Split(",");
            Steps[key].Add('L', branches[0].Trim());
            Steps[key].Add('R', branches[1].Trim());

            if (key[^1] == 'A')
            {
                currentStates.Add(key);
            }
        }

        CurrentStates = currentStates.ToArray();
    }

    private void CalculateStepsToGoal()
    {
        var index = 0;
        StepsToReachGoal = 0;

        var currentStep = "AAA";
        while (currentStep != "ZZZ")
        {
            currentStep = Steps[currentStep][Instructions[index]];
            StepsToReachGoal++;
            index++;
            if (index >= InstructionCount)
            {
                index = 0;
            }
        }
    }

    public void Step()
    {
        for (var index = 0; index < CurrentStates.Length; index++)
        {
            CurrentStates[index] = Steps[CurrentStates[index]][Instructions[_currentIndex]];
        }

        StepsToReachGoal++;
        _currentIndex++;
        if (_currentIndex >= InstructionCount)
        {
            _currentIndex = 0;
        }
    }

    public void ReachGoalInGhostMode()
    {
        while (CurrentStates.Any(p => p[^1] != 'Z'))
        {
            Step();
        }
    }
}
