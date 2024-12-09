namespace Day8.Logic;

public class AntinodeCreator : ICreator
{
    private readonly Func<Antenna, Antenna, bool> _condition;
    private readonly Func<Antenna, Antenna, int, int, int, Antinode> _creator;
    public bool HasHarmonics { get; }

    public AntinodeCreator(Func<Antenna, Antenna, bool> condition,
        Func<Antenna, Antenna, int, int, int, Antinode> creator, bool hasHarmonics)
    {
        _condition = condition;
        _creator = creator;
        HasHarmonics = hasHarmonics;
    }

    public Antinode CreateAntinode(Antenna first, Antenna second, int xDiff, int yDiff, int count) =>
        _creator(first, second, xDiff, yDiff, count);

    public bool ShouldExecuteFor(Antenna first, Antenna second) =>
        _condition(first, second);
}
