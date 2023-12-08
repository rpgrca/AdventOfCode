





namespace Day8.Logic;
public class HauntedWasteland
{
    private readonly string _input;
    private int _currentIndex;
    private Dictionary<int, Dictionary<char, int>> _numericStates;
    public int[] _currentNumericStates;
    private int[] _finalStates;
    private int _startingState;
    private int _endingState;

    public int StateCount { get; private set; }
    public int InstructionCount { get; private set; }
    public string Instructions { get; private set; }
    public Dictionary<string, Dictionary<char, string>> Steps { get; private set; }
    public long StepsToReachGoal { get; private set; }
    public string[] CurrentStates { get; private set; }

    public HauntedWasteland(string input, bool forGhosts = false)
    {
        _input = input;
        _numericStates = new Dictionary<int, Dictionary<char, int>>();
        _currentNumericStates = Array.Empty<int>();
        _finalStates = Array.Empty<int>();
        Instructions = string.Empty;
        Steps = new Dictionary<string, Dictionary<char, string>>();
        CurrentStates = Array.Empty<string>();

        Parse();

        if (!forGhosts)
        {
            //CalculateStepsToGoal();
            CalculateStepsToGoalWithNumericStates();
        }
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        var currentStates = new List<string>();
        var finalStates = new List<int>();
        var dictionary = new Dictionary<string, int>();
        var currentNumericStates = new List<int>();

        Instructions = lines[0];
        InstructionCount = lines[0].Length;

        StateCount = lines.Length - 2;
        foreach (var line in lines[2..])
        {
            var values = line.Split("=");
            var key = values[0].Trim();

            Steps.Add(key, new Dictionary<char, string>());
            var oldIndex = dictionary.Count;
            dictionary.Add(key, oldIndex);
            _numericStates.Add(dictionary[key], new Dictionary<char, int>());

            var branches = values[1].Trim()[1..^1].Split(",");
            Steps[key].Add('L', branches[0].Trim());
            Steps[key].Add('R', branches[1].Trim());

            if (key[^1] == 'A')
            {
                if (key == "AAA")
                {
                    _startingState = dictionary[key];
                }

                currentStates.Add(key);
                currentNumericStates.Add(dictionary[key]);
            }

            if (key[^1] == 'Z')
            {
                if (key == "ZZZ")
                {
                    _endingState = dictionary[key];
                }

                finalStates.Add(dictionary[key]);
            }
        }

        foreach (var entry in Steps)
        {
            _numericStates[dictionary[entry.Key]].Add('L', dictionary[entry.Value['L']]);
            _numericStates[dictionary[entry.Key]].Add('R', dictionary[entry.Value['R']]);
        }

        CurrentStates = currentStates.ToArray();
        _finalStates = finalStates.ToArray();
        _currentNumericStates = currentNumericStates.ToArray();
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

    private void CalculateStepsToGoalWithNumericStates()
    {
        var index = 0;
        StepsToReachGoal = 0;

        while (_startingState != _endingState)
        {
            if (StepsToReachGoal > 21407)
            {
                System.Diagnostics.Debugger.Break();
            }
            _startingState = _numericStates[_startingState][Instructions[index]];
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

    public void ReachGoalInGhostModeWithNumericStates()
    {
        var stepsToFinalState = new List<int>();
        var currentInstruction = 0;
        for (var index = 0; index < _currentNumericStates.Length; index++)
        {
            var currentState = _currentNumericStates[index];
            var legCount = 0;

            while (! _finalStates.Contains(currentState))
            {
                currentState = _numericStates[currentState][Instructions[currentInstruction++]];
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
