namespace Day9.Logic;

public class FileParser : IParser
{
    private int _id;

    public FileParser() => _id = 0;

    public void Add(LinkedList<ISpace> map, int space)
    {
        map.AddLast(new LinkedListNode<ISpace>(new OccupiedSpace(_id++, space)));
    }
}