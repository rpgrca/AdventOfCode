namespace Day5.Logic.Rules;

internal class CorrectResult : IResult
{
    public IResult IfSo(Action action)
    {
        action();
        return this;
    }

    public IResult IfNot(Action action) => this;

    public bool AsBoolean() => true;
}