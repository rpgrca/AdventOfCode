namespace Day2.Logic.States;

internal class DescendingState : MovingState<DescendingState>
{
    // Stryker disable once Equality
    // n == c already covered by State.IsValueCloseEnough, never reaches here
    public DescendingState(int current, int index, IState previousState)
        : base(current, index, previousState, (n, c) => n < c, (n, i, s) => new(n, i, s))
    {
    }
}