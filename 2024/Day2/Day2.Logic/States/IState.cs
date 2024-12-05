namespace Day2.Logic.States;

internal interface IState : IResult
{
    IState PreviousState { get; }
    IState NextValue(int next);
    int Index { get; }
}
