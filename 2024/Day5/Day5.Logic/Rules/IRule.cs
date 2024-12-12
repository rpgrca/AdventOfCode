namespace Day5.Logic.Rules;

internal interface IRule
{
    IResult BreaksAnyRule(List<int> update, int index);
}