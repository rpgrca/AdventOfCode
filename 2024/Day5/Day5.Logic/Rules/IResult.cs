namespace Day5.Logic.Rules;

public interface IResult
{
    IResult IfSo(Action action);
    IResult IfNot(Action action);
    bool AsBoolean();
}
