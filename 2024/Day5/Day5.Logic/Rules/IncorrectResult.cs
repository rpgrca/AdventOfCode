namespace Day5.Logic.Rules;

internal class IncorrectResult : IResult
{
    public IResult IfSo(Action action) => this;

    public IResult IfNot(Action action)
    {
        action();
        return this;
    }

    public bool AsBoolean() => false;
}
