namespace Day2.Logic.States;

internal class StartState : State
{
    public StartState()
        : base(0, 0, new NullState())
    {
    }

    public override IState NextValue(int next) =>
        new HeadState(next, this);
}