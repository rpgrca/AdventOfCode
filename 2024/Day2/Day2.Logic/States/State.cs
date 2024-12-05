using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Day2.Logic.States;

internal abstract class State : IState, IResult
{
    protected IState _previousState;
    protected readonly int _current;
    protected readonly int _index;

    public IState PreviousState => _previousState;
    public int Index => _index;

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
        return 1 <= difference && difference <= 3
            ? new SuccessfulState(_current, _index, this)
            : new InvalidState(_index, this);
    }

    [ExcludeFromCodeCoverage]
    public virtual IResult WhenSuccessful(Action action) =>
        throw new UnreachableException();

    [ExcludeFromCodeCoverage]
    public virtual IResult WhenInvalid(Action result) =>
        throw new UnreachableException();
}