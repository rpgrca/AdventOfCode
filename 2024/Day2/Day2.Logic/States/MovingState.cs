namespace Day2.Logic.States;

internal class MovingState<T> : SuccessfulState where T : class, IState
{
    private readonly Func<int, int, bool> _conditional;
    private readonly Func<int, int, IState, T> _constructor;

    public MovingState(int current, int index, IState previousState,
        Func<int, int, bool> conditional, Func<int, int, IState, T> constructor)
        : base(current, index, previousState)
    {
        _conditional = conditional;
        _constructor = constructor;
    }

    public override IState NextValue(int next)
    {
        IState result = IsValueNearEnough(next);
        result.WhenSuccessful(() =>
        {
            result = _conditional.Invoke(next, _current)
                ? _constructor.Invoke(next, _index + 1, this)
                : new InvalidState(_index, this);
        });

        return result;
    }
}