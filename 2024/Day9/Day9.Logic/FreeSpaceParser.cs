namespace Day9.Logic;

public class FreeSpaceParser : IParser
{
    public void Add(LinkedList<ISpace> map, int space)
    {
        if (space > 0)
        {
            map.AddLast(new LinkedListNode<ISpace>(new FreeSpace(space)));
        }
    }
}