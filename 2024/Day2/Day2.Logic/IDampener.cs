namespace Day2.Logic;

public interface IDampener
{
    IEnumerable<int[]> GenerateCombinations(int[] values, IState state);
}
