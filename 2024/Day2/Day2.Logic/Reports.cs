


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
            var safeWithDampener = false;
            var next = 0;
            var index = 0;
            var justActivatedDampener = false;
            while (next + 1 < levels.Length)
            {
                next++;
                var difference = levels[next] - levels[index];
                if (difference == 0 || (ascending && difference < 0) || (!ascending && difference > 0))
                {
                    safe = false;
                    if (! safeWithDampener)
                    {
                        safeWithDampener = true;
                        justActivatedDampener = true;
                        continue;
                    }
                    else {
                        safeWithDampener = false;
                    }
                    break;
                }

                if ((ascending && (levels[next] <= levels[index])) || (!ascending && (levels[next] >= levels[index])))
                {
                    safe = false;
                    break;
                }

                var absolute = Math.Abs(difference);
                if (absolute < 1 || absolute > 3)
                {
                    safe = false;
                    if (! safeWithDampener)
                    {
                        safeWithDampener = true;
                        justActivatedDampener = true;
                        continue;
                    }
                    else
                    {
                        safeWithDampener = false;
                    }

                    break;
                }

                index++;
                if (justActivatedDampener)
                {
                    index++;
                    justActivatedDampener = false;
                }
            }

            if (safe)
            {
                SafeReportsCount += 1;
            }

            if (safe || safeWithDampener)
            {
                SafeReportsWithDampener += 1;
            }
        }
    }

    public int Length { get; private set; }
    public int SafeReportsCount { get; private set; }
    public int SafeReportsWithDampener { get; private set;}
}
