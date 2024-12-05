using Day2.Logic.States;

namespace Day2.Logic.Dampeners;

internal class NullDampener : IDampener
{
    public IEnumerable<int[]> GenerateCombinations(int[] values, IState state) =>
        Enumerable.Empty<int[]>();
}
