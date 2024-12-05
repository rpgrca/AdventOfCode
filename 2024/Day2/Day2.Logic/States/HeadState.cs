using System.Diagnostics;

namespace Day2.Logic.States;

 internal class HeadState : State
{
    public HeadState(int current, IState state)
        : base(current, 0, state)
    {
    }

    public override IState NextValue(int next)
    {
        IState result = IsValueNearEnough(next);
        result.WhenSuccessful(() =>
        {
            if (next > _current)
            {
                result = new AscendingState(next, _index + 1, this);
            }
            else if (next < _current)
            {
                result = new DescendingState(next, _index + 1, this);
            }
            else
            {
                result = new InvalidState(_index, this);
            }
        });

        return result;
    }
}
