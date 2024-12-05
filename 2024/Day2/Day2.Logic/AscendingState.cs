namespace Day2.Logic;

public class AscendingState : SuccessfulState
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
            if (next > _current)
            {
                result = new AscendingState(next, _index + 1, this);
            }
            else
            {
                result = new InvalidState(_index, this);
            }
        });

        return result;
    }
}
