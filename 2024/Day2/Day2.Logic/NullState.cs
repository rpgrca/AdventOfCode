namespace Day2.Logic;

public class NullState : IState
{
    public IState PreviousState => throw new NotImplementedException();

    public IState NextValue(int next) => throw new NotImplementedException();

    public IResult WhenInvalid(Action action) => throw new NotImplementedException();

    public IResult WhenSuccessful(Action action) => throw new NotImplementedException();
}
