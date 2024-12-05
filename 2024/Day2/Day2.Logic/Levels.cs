using Day2.Logic.Dampeners;
using Day2.Logic.States;

namespace Day2.Logic;

internal class Levels
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
