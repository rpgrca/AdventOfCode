namespace Day5.Logic;

public interface IPrinter
{
    int RuleCount { get; }
    int SumOfMiddlePages { get; }
    int UpdatesCount { get; }
}