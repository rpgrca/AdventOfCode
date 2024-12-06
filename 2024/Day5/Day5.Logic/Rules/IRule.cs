namespace Day5.Logic.Rules;

public interface IRule
{
    IResult BreaksAnyRule(List<int> update, int index);
}