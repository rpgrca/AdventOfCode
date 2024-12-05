namespace Day2.Logic.States;

internal class SuccessfulState : State
{
    public SuccessfulState(int current, int index, IState previousState)
        : base(current, index, previousState)
    {
    }

    public override IState NextValue(int next) => this;

    public override IResult WhenInvalid(Action action) => this;

    public override IResult WhenSuccessful(Action action)
    {
        action();
        return this;
    }
}
