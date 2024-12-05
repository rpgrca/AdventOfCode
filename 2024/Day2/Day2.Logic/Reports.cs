namespace Day2.Logic;

public class Reports
{
    private readonly string[] _input;
    private readonly IDampener _dampener;

    public Reports(string input, IDampener dampener)
    {
        _input = input.Split("\n");
        _dampener = dampener;
        Length = _input.Length;

        CountSafeReports();
    }

    public int Length { get; private set; }
    public int SafeReportsCount { get; private set; }
    public int SafeReportsWithDampener { get; private set;}

    private void CountSafeReports()
    {
        foreach (var input in _input)
        {
            var values = input.Split(" ").Select(int.Parse).ToArray();
            var levels = new Levels(values, _dampener);
            levels.State.WhenSuccessful(() => SafeReportsCount++);
        }
    }
}


public class Levels
{
    private readonly int[] _values;
    private readonly IDampener _problemDampener;

    public IState State { get; private set; }

    public Levels(int[] values, IDampener problemDampener)
    {
        _values = values;
        _problemDampener = problemDampener;

        State = new StartState();
        Run();
    }

    private void Run()
    {
        foreach (var value in _values)
        {
            State = State.NextValue(value);
        }

        State.WhenInvalid(() =>
        {
            var combinationFound = false;
            var combinations = _problemDampener.GenerateCombinations(_values, State);

            foreach (var combination in combinations)
            {
                var subLevel = new Levels(combination, new NullDampener());
                subLevel.State.WhenSuccessful(() => {
                    State = subLevel.State;
                    combinationFound = true;
                });

                if (combinationFound)
                {
                    break;
                }
            }
        });
    }
}

// 9 1 2 3 4
// 1 9 2 3 4
// 1 3 2 1 0
// 3 1 2 1 0
public class ProblemDampener : IDampener
{
    private IState _state;

    public IState PreviousState => throw new NotImplementedException();

    public IEnumerable<int[]> GenerateCombinations(int[] values, IState state)
    {
        for (var index = 0; index < values.Length; index++)
        {
            yield return values
                .Select((p, i) => new { p, i })
                .Where(p => p.i != index)
                .Select(p => p.p)
                .ToArray();
        }
    }

    public IState NextValue(int next)
    {
        _state = _state.NextValue(next);
        return _state;
    }

    public void WhenInvalid(Action action)
    {
        action();
    }

    public void WhenSuccessful(Action action)
    {
        action();
    }
}