namespace Day9.Logic;

public interface ISpace
{
    int Length { get; set; }

    bool SameSpaceAs(ISpace value);
    ISpace SplitAt(int length);
    void WhenFree(Action<FreeSpace> action);
    void WhenOccupied(Action<OccupiedSpace> action);
}

public abstract class ContiguousSpace : ISpace
{
    public int Length { get; set; }

    public ContiguousSpace(int length) => Length = length;

    public abstract void WhenFree(Action<FreeSpace> action);
    public abstract void WhenOccupied(Action<OccupiedSpace> action);
    public abstract bool SameSpaceAs(ISpace value);
    public abstract ISpace SplitAt(int length);
}


public class FreeSpace : ContiguousSpace
{
    public FreeSpace(int length) : base(length)
    {
    }

    public override bool SameSpaceAs(ISpace value)
    {
        var result = false;
        value.WhenFree(_ => result = true);
        return result;
    }

    public override ISpace SplitAt(int length)
    {
        var result = new FreeSpace(length);
        Length -= length;
        return result;
    }

    public override void WhenFree(Action<FreeSpace> action) => action(this);

    public override void WhenOccupied(Action<OccupiedSpace> action)
    {
    }
}

public class OccupiedSpace : ContiguousSpace
{
    public int Id { get; }

    public OccupiedSpace(int id, int space) : base(space) => Id = id;

    public override bool SameSpaceAs(ISpace value)
    {
        var result = false;
        value.WhenOccupied(o => result = o.Id == Id);
        return result;
    }

    public override void WhenFree(Action<FreeSpace> action)
    {
    }

    public override void WhenOccupied(Action<OccupiedSpace> action) => action(this);

    public override ISpace SplitAt(int length)
    {
        var result = new OccupiedSpace(Id, length);
        Length -= length;
        return result;
    }
}