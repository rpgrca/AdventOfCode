

namespace Day2.Logic;

public class Reports
{
    private readonly string[] _input;

    public Reports(string input)
    {
        _input = input.Split("\n");
        Length = _input.Length;

        CountSafeReports();
    }

    private void CountSafeReports()
    {
        var levels = _input[0].Split(" ").Select(int.Parse).ToArray();

        if (levels[0] == levels[1])
        {
            return;
        }

        var ascending = levels[0] < levels[1];
        var safe = true;
        for (var index = 0; index < levels.Length - 1; index++)
        {
            var difference = levels[index + 1] - levels[index];
            if (difference == 0)
            {
                break;
            }

            if ((ascending && (levels[index + 1] <= levels[index])) || (!ascending && (levels[index + 1] >= levels[index])))
            {
                break;
            }

            var absolute = Math.Abs(difference);
            if (absolute < 1 || absolute > 3)
            {
                safe = false;
            }
        }

        if (safe)
        {
            SafeReportsCount += 1;
        }
    }

    public int Length { get; private set; }
    public int SafeReportsCount { get; private set; }
}
