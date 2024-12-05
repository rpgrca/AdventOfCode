namespace Day2.Logic.States;

internal class DescendingState : SuccessfulState
{
    public DescendingState(int current, int index, IState previousState)
        : base(current, index, previousState)
    {
    }

    public override IState NextValue(int next)
    {
        IState result = IsValueNearEnough(next);
        result.WhenSuccessful(() =>
        {
            result = next < _current
                ? new DescendingState(next, _index + 1, this)
                : new InvalidState(_index, this);
        });

        return result;
    }
}