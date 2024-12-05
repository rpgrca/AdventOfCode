namespace Day2.Logic;

public interface IState : IResult
{
    IState PreviousState { get; }
    IState NextValue(int next);
}
