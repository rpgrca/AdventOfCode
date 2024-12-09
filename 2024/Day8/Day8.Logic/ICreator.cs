namespace Day8.Logic;

public interface ICreator
{
    bool HasHarmonics { get; }
    bool ShouldExecuteFor(Antenna first, Antenna second);
    Antinode CreateAntinode(Antenna first, Antenna second, int xDiff, int yDiff, int count);
    void Repeat(Func<int, bool> block);
}