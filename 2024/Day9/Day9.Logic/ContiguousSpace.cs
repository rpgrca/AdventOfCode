namespace Day9.Logic;

public record ContiguousSpace
{
    public int Id;
    public int Length;

    public ContiguousSpace(int id, int length)
    {
        Id = id;
        Length = length;
    }
}
