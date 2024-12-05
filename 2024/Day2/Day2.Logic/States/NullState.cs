using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Day2.Logic.States;

[ExcludeFromCodeCoverage]
internal class NullState : IState
{
    public int Index => throw new UnreachableException();

    public IState PreviousState => throw new UnreachableException();

    public IState NextValue(int next) => throw new UnreachableException();

    public IResult WhenInvalid(Action action) => throw new UnreachableException();

    public IResult WhenSuccessful(Action action) => throw new UnreachableException();
}
