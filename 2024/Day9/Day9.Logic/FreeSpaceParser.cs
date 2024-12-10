namespace Day9.Logic;

public class FreeSpaceParser : IParser
{
    public void Add(LinkedList<ContiguousSpace> map, int space)
    {
        if (space > 0)
        {
            map.AddLast(new LinkedListNode<ContiguousSpace>(new FreeSpace(space)));
        }
    }
}