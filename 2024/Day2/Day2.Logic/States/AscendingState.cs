namespace Day2.Logic.States;

internal class AscendingState : MovingState<AscendingState>
{
    public AscendingState(int current, int index, IState previous)
        : base(current, index, previous, (n, c) => n > c, (n, i, s) => new(n, i + 1, s))
    {
    }
}
