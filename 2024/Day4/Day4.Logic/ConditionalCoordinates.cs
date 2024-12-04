namespace Day4.Logic;

public record ConditionalCoordinates(Func<int, int, bool> Condition, (int X, int Y)[] Coordinates);
