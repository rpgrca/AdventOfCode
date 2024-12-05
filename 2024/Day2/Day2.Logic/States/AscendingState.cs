namespace Day2.Logic.States;

internal class AscendingState : SuccessfulState
{
    public AscendingState(int current, int index, IState previous)
        : base(current, index, previous)
    {
    }

    public override IState NextValue(int next)
    {
        IState result = IsValueNearEnough(next);
        result.WhenSuccessful(() =>
        {
            result = next > _current
                ? new AscendingState(next, _index + 1, this)
                : new InvalidState(_index, this);
        });

        return result;
    }
}
