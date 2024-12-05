using Day2.Logic.States;

namespace Day2.Logic.Dampeners;

internal interface IDampener
{
    IEnumerable<int[]> GenerateCombinations(int[] values, IState state);
}
