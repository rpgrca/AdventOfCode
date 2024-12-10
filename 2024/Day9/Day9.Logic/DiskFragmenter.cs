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

    public void Compact(bool wholeFile = false)
    {
        var compacted = true;
        var file = Map.Last;
        while (file != null && compacted)
        {
            if (file.ValueRef.Id != -1)
            {
                var length = file.ValueRef.Length;
                var emptySpace = Map.First;

                compacted = false;
                while (emptySpace != null && emptySpace != file && length > 0)
                {
                    if (emptySpace.ValueRef.Id == -1)
                    {
                        if (length == emptySpace.ValueRef.Length)
                        {
                            (emptySpace.ValueRef.Id, file.ValueRef.Id) = (file.ValueRef.Id, emptySpace.ValueRef.Id);
                            length = 0;
                        }
                        else
                        {
                            if (length < emptySpace.ValueRef.Length)
                            {
                                var newNode = new LinkedListNode<ContiguousSpace>(new(file.ValueRef.Id, length));
                                Map.AddBefore(emptySpace, newNode);
                                emptySpace.ValueRef.Length -= length;
                                file.ValueRef.Id = -1;
                                length = 0;
                            }
                            else
                            {
                                if (!wholeFile)
                                {
                                    emptySpace.ValueRef.Id = file.ValueRef.Id;
                                    file.ValueRef.Length -= emptySpace.ValueRef.Length;

                                    var newNode = new LinkedListNode<ContiguousSpace>(new(-1, emptySpace.ValueRef.Length));
                                    Map.AddAfter(file, newNode);
                                    length -= emptySpace.ValueRef.Length;
                                }
                            }
                        }

                        compacted = true;
                    }

                    emptySpace = emptySpace.Next;
                }
            }

            file = file.Previous;
        }

        MergeFragmentedSpace();
        CalculateChecksum();
    }

    private void CalculateChecksum()
    {
        var head = Map.First;
        var position = 0;
        while (head != null)
        {
            if (head.ValueRef.Id != -1)
            {
                Checksum += (long)head.ValueRef.Length * (2 * position + head.ValueRef.Length - 1) / 2 * head.ValueRef.Id;
            }

            position += head.ValueRef.Length;
            head = head.Next;
        }
    }

    private void MergeFragmentedSpace()
    {
        var head = Map.First;
        while (head != null)
        {
            var counter = 0;
            var next = head.Next;
            while (next != null && next.ValueRef.Id == head.ValueRef.Id)
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
}