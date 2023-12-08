





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

    public void ReachGoalInGhostModeWithNumericStates()
    {
        var stepsToFinalState = new List<int>();
        var currentInstruction = 0;
        for (var index = 0; index < CurrentStates.Length; index++)
        {
            var legCount = 0;

            while (CurrentStates[index][^1] != 'Z')
            {
                CurrentStates[index] = Steps[CurrentStates[index]][Instructions[currentInstruction++]];
                legCount++;

                if (currentInstruction >= InstructionCount)
                {
                    currentInstruction = 0;
                }
            }

            stepsToFinalState.Add(legCount);
        }

        CalculateLeastCommonMultiple(stepsToFinalState);
    }

    private void CalculateLeastCommonMultiple(List<int> values)
    {
        var leastCommonMultiple = new Dictionary<int, int>();
        foreach (var value in values)
        {
            var primes = CalculatePrimeNumbersFor(value);
            foreach (var (key, repeat) in primes)
            {
                if (leastCommonMultiple.ContainsKey(key))
                {
                    if (leastCommonMultiple[key] < repeat)
                    {
                        leastCommonMultiple[key] = repeat;
                    }
                }
                else
                {
                    leastCommonMultiple.Add(key, repeat);
                }
            }
        }

        StepsToReachGoal = leastCommonMultiple.Aggregate(1L, (t, i) => t * (i.Key * i.Value));
    }

    private Dictionary<int, int> CalculatePrimeNumbersFor(int value)
    {
        var result = new Dictionary<int, int>();
        var repeat = 0;
        while (value % 2 == 0)
        {
            result.Add(2, ++repeat);
            value /= 2;
        }

        for (var index = 3; value > 1; index += 2)
        {
            repeat = 0;
            while (value % index == 0)
            {
                result.Add(index, ++repeat);
                value /= index;
            }
        }

        return result;
    }
}
