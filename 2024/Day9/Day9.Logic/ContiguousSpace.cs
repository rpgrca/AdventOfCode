namespace Day9.Logic;

public record ContiguousSpace
{
    public int Length;

    public int Id;

    public ContiguousSpace(int id, int length)
    {
        Id = id;
        Length = length;
    }
}