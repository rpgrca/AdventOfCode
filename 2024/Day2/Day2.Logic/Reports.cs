


using System.Diagnostics;

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
        var lines = new List<List<int[]>>();
        for (var subIndex = 0; subIndex < Length; subIndex++)
        {
            var input = _input[subIndex];
            var levels = input.Split(" ").Select(int.Parse).ToArray();

            lines.Add(new List<int[]>());
            lines[subIndex].Add(levels);

            for (var subSubIndex = 0; subSubIndex < levels.Length; subSubIndex++)
            {
                lines[subIndex].Add(levels.Select((p, i) => (p, i)).Where(p => p.i != subSubIndex).Select(p => p.p).ToArray());
            }
        }

        foreach (var line in lines)
        {
            for (var combination = 0; combination < line.Count; combination++)
            {
                var levels = line[combination];
                if (levels[0] == levels[1])
                {
                    continue;
                }

                var ascending = levels[0] < levels[1];
                var safe = true;
                var next = 0;
                var index = 0;
                while (next + 1 < levels.Length)
                {
                    next++;
                    var difference = levels[next] - levels[index];
                    if (difference == 0 || (ascending && difference < 0) || (!ascending && difference > 0))
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

                    index++;
                }

                if (safe)
                {
                    if (combination == 0)
                    {
                        SafeReportsCount += 1;
                    }
                    else
                    {
                        SafeReportsWithDampener += 1;
                        break;
                    }
                }
            }
        }
    }

    public int Length { get; private set; }
    public int SafeReportsCount { get; private set; }
    public int SafeReportsWithDampener { get; private set;}
}
