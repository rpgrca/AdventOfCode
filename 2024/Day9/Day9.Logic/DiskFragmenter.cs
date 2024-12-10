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

public class DiskFragmenter
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
        var isFile = true;
        var id = 0;
        foreach (var space in _input.Select(p => p - '0'))
        {
            if (isFile)
            {
                Map.AddLast(new LinkedListNode<ContiguousSpace>(new(id++, space)));
            }
            else
            {
                if (space > 0)
                {
                    Map.AddLast(new LinkedListNode<ContiguousSpace>(new (-1, space)));
                }
            }

            isFile = !isFile;
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
                    var emptySpaceValue = emptySpace.Value;
                    if (emptySpaceValue.Id == -1)
                    {
                        if (length == emptySpaceValue.Length)
                        {
                            emptySpaceValue.Id = file.ValueRef.Id;
                            file.ValueRef.Id = -1;
                            length = 0;
                        }
                        else
                        {
                            if (length < emptySpaceValue.Length)
                            {
                                var newNode = new LinkedListNode<ContiguousSpace>(new(file.ValueRef.Id, length));
                                Map.AddBefore(emptySpace, newNode);
                                emptySpaceValue.Length -= length;
                                file.ValueRef.Id = -1;
                                length = 0;
                            }
                            else
                            {
                                if (! wholeFile)
                                {
                                    emptySpaceValue.Id = file.ValueRef.Id;
                                    file.ValueRef.Length -= emptySpaceValue.Length;

                                    var newNode = new LinkedListNode<ContiguousSpace>(new(-1, emptySpaceValue.Length));
                                    Map.AddAfter(file, newNode);
                                    length -= emptySpaceValue.Length;
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

        head = Map.First;
        var position = 0;
        while (head != null)
        {
            if (head.ValueRef.Id != -1)
            {
                for (var index = 0; index < head.ValueRef.Length; index++)
                {
                    Checksum += (position + index) * head.ValueRef.Id;
                }
            }

            position += head.ValueRef.Length;
            head = head.Next;
        }
    }
}