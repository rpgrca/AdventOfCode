namespace Day2.Logic;

public class NullDampener : IDampener
{
    public IEnumerable<int[]> GenerateCombinations(int[] values, IState state) =>
        Enumerable.Empty<int[]>();
}
