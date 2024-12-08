namespace Day2.Logic.States;

internal class AscendingState : MovingState<AscendingState>
{
    // Stryker disable once Equality
    // n == c already covered by State.IsValueCloseEnough, never reaches here
    public AscendingState(int current, int index, IState previous)
        : base(current, index, previous, (n, c) => n > c, (n, i, s) => new(n, i, s))
    {
    }
}
