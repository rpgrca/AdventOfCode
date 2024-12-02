


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
        foreach (var input in _input)
        {
            var levels = input.Split(" ").Select(int.Parse).ToArray();

            if (levels[0] == levels[1])
            {
                continue;
            }

            var ascending = levels[0] < levels[1];
            var safe = true;
            for (var index = 0; index < levels.Length - 1; index++)
            {
                var difference = levels[index + 1] - levels[index];
                if (difference == 0 || (ascending && difference < 0) || (!ascending && difference > 0))
                {
                    safe = false;
                    break;
                }

                if ((ascending && (levels[index + 1] <= levels[index])) || (!ascending && (levels[index + 1] >= levels[index])))
                {
                    safe = false;
                    break;
                }

                var absolute = Math.Abs(difference);
                if (absolute < 1 || absolute > 3)
                {
                    safe = false;
                    break;
                }
            }

            if (safe)
            {
                SafeReportsCount += 1;
            }
        }
    }

    public int Length { get; private set; }
    public int SafeReportsCount { get; private set; }
    public int SafeReportsWithDampener => SafeReportsCount;
}
