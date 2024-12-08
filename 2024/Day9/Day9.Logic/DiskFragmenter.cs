

using System.Globalization;
using System.Reflection;

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

    public void Compact()
    {
        var compacted = true;
        for (var file = Map.Last; file != Map.First && compacted; file = file.Previous)
        {
            if (file.Value.Id != -1)
            {
                var length = file.Value.Length;
                compacted = false;
                for (var emptySpace = Map.First; emptySpace != file && length > 0; emptySpace = emptySpace.Next)
                {
                    if (emptySpace.Value.Id == -1)
                    {
                        if (length == emptySpace.Value.Length)
                        {
                            emptySpace.ValueRef.Id = file.Value.Id;
                            file.ValueRef.Id = -1;
                            length = 0;
                        }
                        else
                        {
                            if (length < emptySpace.Value.Length)
                            {
                                var newNode = new LinkedListNode<ContiguousSpace>(new(file.Value.Id, length));
                                Map.AddBefore(emptySpace, newNode);
                                emptySpace.ValueRef.Length -= length;
                                file.ValueRef.Id = -1;
                                length = 0;
                            }
                            else
                            {
                                emptySpace.ValueRef.Id = file.Value.Id;
                                file.Value.Length -= emptySpace.Value.Length;

                                var newNode = new LinkedListNode<ContiguousSpace>(new(-1, emptySpace.Value.Length));
                                Map.AddAfter(file, newNode);
                                length -= emptySpace.Value.Length;
                            }
                        }

                        compacted = true;
                    }
                }
            }
        }

        var head = Map.First;
        while (head != null)
        {
            var counter = 0;
            var next = head.Next;
            while (next != null && next.Value.Id == head.Value.Id)
            {
                counter += next.Value.Length;
                var toDelete = next;
                next = next.Next;
                Map.Remove(toDelete);
            }

            head.ValueRef.Length += counter;
            head = head.Next;
        }

        head = Map.First;
        var position = 0;
        while (head != null && head.Value.Id != -1)
        {
            for (var index = 0; index < head.Value.Length; index++)
            {
                Checksum += (position + index) * head.Value.Id;
            }

            position += head.Value.Length;
            head = head.Next;
        }
    }

    public void Compact2()
    {
        for (var file = Map.Last; file != Map.First; file = file.Previous)
        {
            if (file.Value.Id != -1)
            {
                var length = file.Value.Length;
                for (var emptySpace = Map.First; emptySpace != file && length > 0; emptySpace = emptySpace.Next)
                {
                    if (emptySpace.Value.Id == -1)
                    {
                        if (length == emptySpace.Value.Length)
                        {
                            emptySpace.ValueRef.Id = file.Value.Id;
                            file.ValueRef.Id = -1;
                            length = 0;
                        }
                        else
                        {
                            if (length < emptySpace.Value.Length)
                            {
                                var newNode = new LinkedListNode<ContiguousSpace>(new(file.Value.Id, length));
                                Map.AddBefore(emptySpace, newNode);
                                emptySpace.ValueRef.Length -= length;
                                file.ValueRef.Id = -1;
                                length = 0;
                            }
                        }
                    }
                }
            }
        }

        var head = Map.First;
        while (head != null)
        {
            var counter = 0;
            var next = head.Next;
            while (next != null && next.Value.Id == head.Value.Id)
            {
                counter += next.Value.Length;
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
            if (head.Value.Id != -1)
            {
                for (var index = 0; index < head.Value.Length; index++)
                {
                    Checksum += (position + index) * head.Value.Id;
                }
            }

            position += head.Value.Length;
            head = head.Next;
        }
    }
}