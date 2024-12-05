using System.Diagnostics;

namespace Day2.Logic.States;

internal class StartState : State
{
    public StartState()
        : base(0, 0, new NullState())
    {
    }

    public override IState NextValue(int next) =>
        new HeadState(next, this);

    public override IResult WhenInvalid(Action result) =>
        throw new UnreachableException();

    public override IResult WhenSuccessful(Action action) =>
        throw new UnreachableException();
}