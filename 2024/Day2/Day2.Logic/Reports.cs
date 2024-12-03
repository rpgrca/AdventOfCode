using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Markup;

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

    private void CountSafeReports2()
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

    private void CountSafeReports()
    {
        foreach (var input in _input)
        {
            var values = input.Split(" ").Select(int.Parse).ToArray();
            var levels = new Levels(values);
            levels.State.WhenSuccessful(() => SafeReportsCount++);
        }
    }
}


public class Levels
{
    private readonly int[] _values;

    public IState State { get; private set; }

    public Levels(int[] values)
    {
        _values = values;
        State = new StartState();

        Run();
    }

    private void Run()
    {
        foreach (var value in _values)
        {
            State = State.NextValue(value);
        }
    }
}

public interface IState
{
    IState NextValue(int next);
    void WhenSuccessful(Action action);
}

public abstract class State : IState
{
    public abstract IState NextValue(int next);

    public abstract void WhenSuccessful(Action action);
}

public class SuccessfulState : State
{
    public override IState NextValue(int next) => this;

    public override void WhenSuccessful(Action action) =>
        action();
}

public class InvalidState : State
{
    private readonly int _index;

    public InvalidState(int index) => _index = index;

    public override IState NextValue(int next) => this;

    public override void WhenSuccessful(Action action)
    {
    }
}

public class StartState : SuccessfulState
{
    public override IState NextValue(int next) =>
        new HeadState(next);
}

public class HeadState : SuccessfulState
{
    private readonly int _current;
    private readonly int _index;

    public HeadState(int current)
    {
        _current = current;
        _index = 0;
    }

    public override IState NextValue(int next)
    {
        if (next > _current)
        {
            return new AscendingState(next, _index + 1);
        }
        else if (next < _current)
        {
            return new DescendingState(next, _index + 1);
        }
        else
        {
            return new InvalidState(_index);
        }
    }
}

public class AscendingState : SuccessfulState
{
    private readonly int _current;
    private readonly int _index;

    public AscendingState(int current, int index)
    {
        _current = current;
        _index = index;
    }

    public override IState NextValue(int next)
    {
        if (next > _current)
        {
            return new AscendingState(next, _index + 1);
        }

        return new InvalidState(_index);
    }
}

public class DescendingState : SuccessfulState
{
    private readonly int _current;
    private readonly int _index;

    public DescendingState(int current, int index)
    {
        _current = current;
        _index = index;
    }

    public override IState NextValue(int next)
    {
        if (next < _current)
        {
            return new DescendingState(next, _index + 1);
        }

        return new InvalidState(_index);
    }
}