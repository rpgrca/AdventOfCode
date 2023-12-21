namespace Day20.Logic;

public enum PulseState
{
    Low = 0,
    High = 1
}

public class FlipFlop
{
    public int State { get; set; }
    public string[] Targets { get; }

    public FlipFlop(int state, string[] targets)
    {
        State = state;
        Targets = targets;
    }
}

public class Conjunction
{
    public Dictionary<string, int> States { get; }
    public string[] Targets { get; }

    public Conjunction(Dictionary<string, int> states, string[] targets)
    {
        States = states;
        Targets = targets;
    }
}

public class PulsePropagation
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly string[] _broadcastTarget;
    private readonly Dictionary<string, FlipFlop> _flipflops;
    private readonly Dictionary<string, Conjunction> _conjunctions;
    private readonly HashSet<string> _unnameds;
    private readonly Queue<(string Source, string Target, int Pulse)> _queue;
    private bool _rxReceivedLowPulse = false;

    public int CommandsCount => _lines.Length;
    public int FlipFlopCount => _flipflops.Count;
    public int ConjuntionCount => _conjunctions.Count;
    public int UnnamedCount => _unnameds.Count;
    public int HighPulseCount { get; private set; }
    public int LowPulseCount { get; private set; }
    public int BroadcasterTargets => _broadcastTarget.Length;
    public int PulseMultiplication => LowPulseCount * HighPulseCount;

    public PulsePropagation(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _flipflops = new Dictionary<string, FlipFlop>();
        _conjunctions = new Dictionary<string, Conjunction>();
        _unnameds = new HashSet<string>();
        _broadcastTarget = Array.Empty<string>();
        _queue = new Queue<(string Source, string Target, int Pulse)>();

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
                _flipflops.Add(command[0][1..], new(0, command[1].Split(",").Select(p => p.Trim()).ToArray()));
            }
            else
            if (command[0][0] == '&')
            {
                _conjunctions.Add(command[0][1..], new(new Dictionary<string, int>(), command[1].Split(",").Select(p => p.Trim()).ToArray()));
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
                        conjunction.States.TryAdd(command[0][1..].Trim(), 0);
                    }
                    else if (!_unnameds.Contains(target))
                    {
                        _unnameds.Add(target);
                    }
                }
            }
        }
    }

    public int Pulse(int amount = 1)
    {
        _queue.Clear();

        var current = 0;
        while (current < amount)
        {
            current++;
            LowPulseCount++;

            foreach (var target in _broadcastTarget)
            {
                _queue.Enqueue(("broadcaster", target, 0));
                LowPulseCount++;
            }

            while (_queue.Count > 0)
            {
                var target = _queue.Dequeue();

                if (_flipflops.TryGetValue(target.Target, out var flipflop))
                {
                    if (target.Pulse == 0)
                    {
                        flipflop.State = ~flipflop.State;
                        foreach (var flipflopTarget in flipflop.Targets)
                        {
                            _queue.Enqueue((target.Target, flipflopTarget, flipflop.State));
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
                    conjunction.States[target.Source] = target.Pulse;
                    var pulseToSend = conjunction.States.Values.Any(p => p == 0)? -1 : 0;
                    foreach (var conjunctionTarget in conjunction.Targets)
                    {
                        _queue.Enqueue((target.Target, conjunctionTarget, pulseToSend));
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
                else
                {
                    if (target.Target == "rx" && target.Pulse == 0)
                    {
                        _rxReceivedLowPulse = true;
                        return current;
                    }
                }
            }
        }

        return current;
    }

    public long ButtonPressesUntilRxReceivesLowPulse()
    {
        var result = 0L;
        var first = 0L;
        var second = 0L;
        var third = 0L;
        var fourth = 0L;
        while (first == 0L || second == 0 || third == 0 || fourth == 0)
        {
            result += Pulse();
            if (GetFirstGroup() == 0)
            {
                first = result;
            }

            if (GetSecondGroup() == 0)
            {
                second = result;
            }

            if (GetThirdGroup() == 0)
            {
                third = result;
            }

            if (GetFourthGroup() == 0)
            {
                fourth = result;
            }
        }

        return first * second * third * fourth;
    }

    private int GetFirstGroup()  => _flipflops["zq"].State + _flipflops["jk"].State + _flipflops["tl"].State + _flipflops["kj"].State + _flipflops["pb"].State + _flipflops["gr"].State + _flipflops["mv"].State + _flipflops["js"].State + _flipflops["mp"].State + _flipflops["fm"].State + _flipflops["dt"].State + _flipflops["hp"].State;

    private int GetSecondGroup() => _flipflops["pm"].State + _flipflops["gf"].State + _flipflops["cd"].State + _flipflops["xh"].State + _flipflops["db"].State + _flipflops["jm"].State + _flipflops["qq"].State + _flipflops["gb"].State + _flipflops["vj"].State + _flipflops["sx"].State + _flipflops["sk"].State + _flipflops["qn"].State;

    private int GetThirdGroup()  => _flipflops["gz"].State + _flipflops["bh"].State + _flipflops["vz"].State + _flipflops["sl"].State + _flipflops["mb"].State + _flipflops["zm"].State + _flipflops["lb"].State + _flipflops["bb"].State + _flipflops["df"].State + _flipflops["tx"].State + _flipflops["zc"].State + _flipflops["xv"].State;

    private int GetFourthGroup() => _flipflops["sz"].State + _flipflops["vx"].State + _flipflops["nk"].State + _flipflops["lg"].State + _flipflops["xp"].State + _flipflops["rt"].State + _flipflops["fc"].State + _flipflops["lj"].State + _flipflops["lq"].State + _flipflops["pd"].State + _flipflops["gs"].State + _flipflops["zb"].State;
}
