namespace Day23.Logic;

public static class HashSetExtensions
{
    public static bool Contains(this HashSet<int> visited, int x, int y) => visited.Contains((y << 8) | x);

    public static bool Add(this HashSet<int> visited, int x, int y) => visited.Add((y << 8) | x);

    public static void Remove(this HashSet<int> visited, int x, int y) => visited.Remove((y << 8) | x);
}