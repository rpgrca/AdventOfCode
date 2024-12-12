namespace Day5.Logic.Rules;

internal interface IResult
{
    IResult IfSo(Action action);
    IResult IfNot(Action action);
    bool AsBoolean();
}
