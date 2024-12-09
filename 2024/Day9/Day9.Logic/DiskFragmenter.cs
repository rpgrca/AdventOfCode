
namespace Day9.Logic;

public partial class DiskFragmenter
{
    private readonly string _input;
    public int Length => _input.Length;
    public LinkedList<ISpace> Map { get; set; }
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

    public void Compact()
    {
        var compacted = true;
        var last = Map.Last;
        while (last != null && compacted)
        {
            last.Value.WhenOccupied(o => {
                var length = last.Value.Length;
                compacted = false;
                var emptySpace = Map.First;
                while (emptySpace != null && emptySpace != last && length > 0)
                {
                    var nextSpace = emptySpace.Next;
                    emptySpace.ValueRef.WhenFree(_ => {
                        if (length == emptySpace.Value.Length)
                        {
                            (last.Value, emptySpace.Value) = (emptySpace.Value, last.Value);
                            length = 0;
                        }
                        else
                        {
                            if (length < emptySpace.Value.Length)
                            {
                                var newNode = new LinkedListNode<ISpace>(last.Value);
                                Map.AddBefore(emptySpace, newNode);

                                last.Value = new FreeSpace(length);
                                emptySpace.ValueRef.Length -= length;
                                length = 0;
                            }
                            else
                            {
                                var newNode = new LinkedListNode<ISpace>(last.Value.SplitAt(emptySpace.Value.Length));
                                Map.AddAfter(emptySpace, newNode);
                                Map.Remove(emptySpace);
                                Map.AddAfter(last, new LinkedListNode<ISpace>(new FreeSpace(emptySpace.Value.Length)));
                                length -= emptySpace.Value.Length;
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

    private void CalculateChecksum()
    {
        var head = Map.First;
        var position = 0;
        while (head != null)
        {
            head.Value.WhenOccupied(o => {
                for (var index = 0; index < head.Value.Length; index++)
                {
                    Checksum += (position + index) * o.Id;
                }
            });

            position += head.Value.Length;
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
            while (next != null && next.Value.SameSpaceAs(head.Value))
            {
                counter += next.Value.Length;
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
            last.Value.WhenOccupied(o => {
                var length = last.Value.Length;
                compacted = false;
                var emptySpace = Map.First;
                while (emptySpace != null && emptySpace != last && length > 0)
                {
                    var nextSpace = emptySpace.Next;
                    emptySpace.ValueRef.WhenFree(_ => {
                        if (length == emptySpace.Value.Length)
                        {
                            (last.Value, emptySpace.Value) = (emptySpace.Value, last.Value);
                            length = 0;
                        }
                        else
                        {
                            if (length < emptySpace.Value.Length)
                            {
                                var newNode = new LinkedListNode<ISpace>(last.Value);
                                Map.AddBefore(emptySpace, newNode);

                                last.Value = new FreeSpace(length);
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