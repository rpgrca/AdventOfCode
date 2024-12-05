namespace Day2.Logic;

public class InvalidState : State
{
    public InvalidState(int index, IState previousState)
        : base(0, index, previousState)
    {
    }

    public override IState NextValue(int next) => this;

    public override IResult WhenSuccessful(Action action) => this;

    public override IResult WhenInvalid(Action action)
    {
        action();
        return this;
    }
}
