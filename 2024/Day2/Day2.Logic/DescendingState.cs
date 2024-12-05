namespace Day2.Logic;

public class DescendingState : SuccessfulState
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
            if (next < _current)
            {
                result = new DescendingState(next, _index + 1, this);
            }
            else
            {
                result = new InvalidState(_index, this);
            }
        });

        return result;
    }
}