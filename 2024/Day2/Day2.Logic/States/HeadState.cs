namespace Day2.Logic.States;

 internal class HeadState : State
{
    public HeadState(int current, IState state)
        : base(current, 0, state)
    {
    }

    public override IState NextValue(int next)
    {
        IState result = IsValueNearEnough(next);
        result
            .WhenSuccessful(() =>
            {
                result = next > _current
                    ? new AscendingState(next, _index + 1, this)
                    : new DescendingState(next, _index + 1, this);
            })
            .WhenInvalid(() => {
                result = new InvalidState(_index + 1, this);
            });

        return result;
    }
}
