namespace Day2.Logic.States;

internal class DescendingState : MovingState<DescendingState>
{
    public DescendingState(int current, int index, IState previousState)
        : base(current, index, previousState, (n, c) => n < c, (n, i, s) => new(n, i, s))
    {
    }
}