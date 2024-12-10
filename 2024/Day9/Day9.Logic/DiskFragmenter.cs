namespace Day9.Logic;

public partial class DiskFragmenter
{
    private readonly string _input;
    public int Length => _input.Length;
    public LinkedList<ContiguousSpace> Map { get; set; }
    public long Checksum { get; private set; }

    public DiskFragmenter(string input)
    {
        _input = input;
        Map = new();

        Parse();
    }

    private void Parse()
    {
        var index = 0;
        var parser = new IParser[]
        {
            new FileParser(),
            new FreeSpaceParser()
        };

        foreach (var space in _input.Select(p => p - '0'))
        {
            parser[index++ & 1].Add(Map, space);
        }
    }

    public interface IMover
    {
        int Move(LinkedList<ContiguousSpace> map, LinkedListNode<ContiguousSpace> lastFile, LinkedListNode<ContiguousSpace> emptySpace);
    }

    public class SameSizeMover : IMover
    {
        public int Move(LinkedList<ContiguousSpace> map, LinkedListNode<ContiguousSpace> lastFile, LinkedListNode<ContiguousSpace> emptySpace)
        {
            (lastFile.ValueRef, emptySpace.ValueRef) = (emptySpace.ValueRef, lastFile.ValueRef);
            return 0;
        }
    }

    public class LargerFileMover : IMover
    {
        public int Move(LinkedList<ContiguousSpace> map, LinkedListNode<ContiguousSpace> lastFile, LinkedListNode<ContiguousSpace> emptySpace)
        {
            map.AddAfter(emptySpace, new LinkedListNode<ContiguousSpace>(lastFile.ValueRef.SplitAt(emptySpace.ValueRef.Length)));
            map.Remove(emptySpace);
            map.AddAfter(lastFile, emptySpace);
            return lastFile.ValueRef.Length;
        }
    }

    public class SmallerFileMover : IMover
    {
        public int Move(LinkedList<ContiguousSpace> map, LinkedListNode<ContiguousSpace> lastFile, LinkedListNode<ContiguousSpace> emptySpace)
        {
            map.AddBefore(emptySpace, new LinkedListNode<ContiguousSpace>(lastFile.ValueRef));
            lastFile.ValueRef = new FreeSpace(lastFile.ValueRef.Length);
            emptySpace.ValueRef.Length -= lastFile.ValueRef.Length;
            return 0;
        }
    }

    public void Compact()
    {
        var smallerMover = new SmallerFileMover();
        var sameSizeMover = new SameSizeMover();
        var largerFileMover = new LargerFileMover();

        var compacted = true;
        var lastFile = Map.Last;
        while (lastFile != null && compacted)
        {
            lastFile.ValueRef.WhenOccupied(o => {
                var length = o.Length;
                var emptySpace = Map.First;

                compacted = false;
                while (emptySpace != null && emptySpace != lastFile && length > 0)
                {
                    var nextSpace = emptySpace.Next;
                    emptySpace.ValueRef.WhenFree(e => {
                        if (length == e.Length)
                        {
                            length = sameSizeMover.Move(Map, lastFile, emptySpace);
                        }
                        else
                        {
                            if (length < e.Length)
                            {
                                length = smallerMover.Move(Map, lastFile, emptySpace);
                            }
                            else
                            {
                                length = largerFileMover.Move(Map, lastFile, emptySpace);
                            }
                        }
                    });

                    compacted = true;
                    emptySpace = nextSpace;
                }

            });

            lastFile = lastFile.Previous;
        }

        MergeContiguousSpace();
        CalculateChecksum();
    }

    private void CalculateChecksum()
    {
        var head = Map.First;
        var position = 0;
        while (head != null)
        {
            head.ValueRef.WhenOccupied(o => {
                for (var index = 0; index < head.ValueRef.Length; index++)
                {
                    Checksum += (position + index) * o.Id;
                }
            });

            position += head.ValueRef.Length;
            head = head.Next;
        }
    }

    private void MergeContiguousSpace()
    {
        var head = Map.First;
        while (head != null)
        {
            var counter = 0;
            var next = head.Next;
            while (next != null && next.ValueRef.SameSpaceAs(head.ValueRef))
            {
                counter += next.ValueRef.Length;
                var toDelete = next;
                next = next.Next;
                Map.Remove(toDelete);
            }

            head.ValueRef.Length += counter;
            head = head.Next;
        }
    }

    public void Compact2()
    {
        var compacted = true;
        var last = Map.Last;
        while (last != null && compacted)
        {
            last.ValueRef.WhenOccupied(o => {

                var length = o.Length;
                compacted = false;
                var emptySpace = Map.First;
                while (emptySpace != null && emptySpace != last && length > 0)
                {
                    var nextSpace = emptySpace.Next;
                    emptySpace.ValueRef.WhenFree(_ => {
                        if (length == emptySpace.ValueRef.Length)
                        {
                            (last.ValueRef, emptySpace.ValueRef) = (emptySpace.ValueRef, last.ValueRef);
                            length = 0;
                        }
                        else
                        {
                            if (length < emptySpace.ValueRef.Length)
                            {
                                var newNode = new LinkedListNode<ContiguousSpace>(last.ValueRef);
                                Map.AddBefore(emptySpace, newNode);

                                last.ValueRef = new FreeSpace(length);
                                emptySpace.ValueRef.Length -= length;
                                length = 0;
                            }
                        }
                    });

                    compacted = true;
                    emptySpace = nextSpace;
                }

            });

            last = last.Previous;
        }

        MergeContiguousSpace();
        CalculateChecksum();
    }
}