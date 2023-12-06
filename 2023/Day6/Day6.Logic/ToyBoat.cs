

namespace Day6.Logic;
public class ToyBoat
{
    private readonly string _input;
    private int[] _times;
    private int[] _distances;

    public int RaceCount => _times.Length;
    public int WaysToBreakRecord { get; private set; }

    public ToyBoat(string input)
    {
        _input = input;
        _times = Array.Empty<int>();
        _distances = Array.Empty<int>();

        Parse();
        CalculateBestTime();
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        _times = lines[0].Split(":")[1].Split(" ").Where(p => !string.IsNullOrEmpty(p)).Select(int.Parse).ToArray();
        _distances = lines[1].Split(":")[1].Split(" ").Where(p => !string.IsNullOrEmpty(p)).Select(int.Parse).ToArray();
    }

    private void CalculateBestTime()
    {
        WaysToBreakRecord = 1;

        for (var index = 0; index < _times.Length; index++)
        {
            var time = _times[index];
            var recordBreakingTimes = new List<int>();

            for (var pressedDown = 1; pressedDown < time; pressedDown++)
            {
                var leftTime = time - pressedDown;
                var totalDistance = leftTime * pressedDown;
                if (totalDistance > _distances[index])
                {
                    recordBreakingTimes.Add(totalDistance);
                }
            }

            WaysToBreakRecord *= recordBreakingTimes.Count;
        }
    }
}
