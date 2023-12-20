namespace Day20.Logic;

public enum PulseState
{
    Low = 0,
    High = 1
}

public class PulsePropagation
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly string[] _broadcastTarget;
    private readonly Dictionary<string, PulseState> _flipflops;
    private readonly List<string> _conjunctions;
    private readonly List<string> _unnameds;

    public int CommandsCount => _lines.Length;
    public int FlipFlopCount => _flipflops.Count;
    public int ConjuntionCount => _conjunctions.Count;
    public int UnnamedCount => _unnameds.Count;
    public int HighPulseCount { get; set; }
    public int LowPulseCount { get; set; }
    public int BroadcasterTargets => _broadcastTarget.Length;


    public PulsePropagation(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _flipflops = new Dictionary<string, PulseState>();
        _conjunctions = new List<string>();
        _unnameds = new List<string>();
        _broadcastTarget = Array.Empty<string>();

        foreach (var line in _lines)
        {
            var command = line.Split(" -> ");
            if (command[0] == "broadcaster")
            {
                _broadcastTarget = command[1].Split(",").Select(p => p.Trim()).ToArray();
            }
            else
            if (command[0][0] == '%')
            {
                _flipflops.Add(command[0][1..], PulseState.Low);
            }
            else
            if (command[0][0] == '&')
            {
                _conjunctions.Add(command[0][1..]);
            }
        }

        foreach (var line in _lines)
        {
            var command = line.Split(" -> ");
            var targets = command[1].Split(",");
            foreach (var target in targets.Select(p => p.Trim()))
            {
                if (!_flipflops.ContainsKey(target) && !_conjunctions.Contains(target))
                {
                    _unnameds.Add(target);
                }
            }
        }
    }

    public void Pulse()
    {
        LowPulseCount++;
    }
}
