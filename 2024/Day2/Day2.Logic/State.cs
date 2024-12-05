namespace Day2.Logic;

public abstract class State : IState, IResult
{
    protected IState _previousState;
    protected readonly int _current;
    protected readonly int _index;

    public IState PreviousState => _previousState;

    public State(int current, int index, IState previousState)
    {
        _current = current;
        _index = index;
        _previousState = previousState;
    }

    public abstract IState NextValue(int next);

    protected IState IsValueNearEnough(int next)
    {
        var difference = Math.Abs(next - _current);
        if (1 <= difference && difference <= 3)
        {
            return new SuccessfulState(_current, _index, this);
        }

        return new InvalidState(_index, this);
    }

    public abstract IResult WhenSuccessful(Action action);

    public abstract IResult WhenInvalid(Action result);
}