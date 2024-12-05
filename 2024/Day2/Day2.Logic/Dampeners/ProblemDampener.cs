using Day2.Logic.States;

namespace Day2.Logic.Dampeners;

// 9 1 2 3 4
// 1 9 2 3 4
// 1 3 2 1 0
// 3 1 2 1 0
internal class ProblemDampener : IDampener
{
    private IState _state;

    internal IState PreviousState => throw new NotImplementedException();

    public ProblemDampener() => _state = new NullState();

    public IEnumerable<int[]> GenerateCombinations(int[] values, IState state)
    {
        for (var index = state.PreviousState.PreviousState.Index; index <= state.Index; index++)
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
}