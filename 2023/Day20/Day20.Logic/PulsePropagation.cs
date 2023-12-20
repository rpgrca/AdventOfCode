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
    private readonly Dictionary<string, (int State, string[] Targets)> _flipflops;
    private readonly Dictionary<string, (Dictionary<string, int> States, string[] Targets)> _conjunctions;
    private readonly HashSet<string> _unnameds;

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
        _flipflops = new Dictionary<string, (int, string[])>();
        _conjunctions = new Dictionary<string, (Dictionary<string, int> States, string[] Targets)>();
        _unnameds = new HashSet<string>();
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
                _flipflops.Add(command[0][1..], (0, command[1].Split(",").Select(p => p.Trim()).ToArray()));
            }
            else
            if (command[0][0] == '&')
            {
                _conjunctions.Add(command[0][1..], (new Dictionary<string, int>(), command[1].Split(",").Select(p => p.Trim()).ToArray()));
            }
        }

        foreach (var line in _lines)
        {
            var command = line.Split(" -> ");
            var targets = command[1].Split(",");
            foreach (var target in targets.Select(p => p.Trim()))
            {
                if (!_flipflops.ContainsKey(target))
                {
                    if (_conjunctions.TryGetValue(target, out var conjunction))
                    {
                        conjunction.States.TryAdd(command[0].Trim(), 0);
                    }
                    else if (!_unnameds.Contains(target))
                    {
                        _unnameds.Add(target);
                    }
                }
            }
        }
    }

    public void Pulse()
    {
        var queue = new Queue<(string Target, int Pulse)>();
        foreach (var target in _broadcastTarget)
        {
            queue.Enqueue((target, 0));
            LowPulseCount++;
        }

        while (queue.Count > 0)
        {
            var target = queue.Dequeue();

            if (_flipflops.TryGetValue(target.Target, out var flipflop))
            {
                if (target.Pulse == 0)
                {
                    flipflop = (~flipflop.State, flipflop.Targets);
                    _flipflops[target.Target] = flipflop;
                    foreach (var flipflopTarget in flipflop.Targets)
                    {
                        queue.Enqueue((flipflopTarget, flipflop.State));
                        if (flipflop.State == 0)
                        {
                            LowPulseCount++;
                        }
                        else
                        {
                            HighPulseCount++;
                        }
                    }
                }
            }
            else if (_conjunctions.TryGetValue(target.Target, out var conjunction))
            {
                conjunction.States[target.Target] = target.Pulse;
                var pulseToSend = conjunction.States.Values.Any(p => p == 0)? 0 : -1;
                foreach (var conjunctionTarget in conjunction.Targets)
                {
                    queue.Enqueue((conjunctionTarget, pulseToSend));
                    if (pulseToSend == 0)
                    {
                        LowPulseCount++;
                    }
                    else
                    {
                        HighPulseCount++;
                    }
                }
            }
        }
    }
}
