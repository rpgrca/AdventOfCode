using Day2.Logic.Dampeners;

namespace Day2.Logic;

public class Reports
{
    private readonly string[] _input;
    private readonly IDampener _dampener;

    public int Length => _input.Length;
    public int SafeReportsCount { get; private set; }

    public static Reports CreateWithoutDampener(string input) =>
        new(input, new NullDampener());

    public static Reports CreateWithDampener(string input) =>
        new(input, new ProblemDampener());

    private Reports(string input, IDampener dampener)
    {
        _input = input.Split("\n");
        _dampener = dampener;

        CountSafeReports();
    }

    private void CountSafeReports()
    {
        foreach (var input in _input)
        {
            var values = input.Split(" ")
                .Select(int.Parse)
                .ToArray();

            new Levels(values, _dampener).State
                .WhenSuccessful(() => {
                    SafeReportsCount++;
                });
        }
    }
}