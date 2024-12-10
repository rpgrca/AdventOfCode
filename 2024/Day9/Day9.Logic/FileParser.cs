namespace Day9.Logic;

public class FileParser : IParser
{
    private int _id;

    public FileParser() => _id = 0;

    public void Add(LinkedList<ContiguousSpace> map, int space) =>
        map.AddLast(new LinkedListNode<ContiguousSpace>(new ContiguousSpace(_id++, space)));
}